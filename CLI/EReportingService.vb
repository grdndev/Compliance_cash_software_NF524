' =============================================
' Réforme facturation électronique 2026-2027
' E-REPORTING SERVICE — Transmission B2C agrégée vers PDP
' =============================================
' Spécification : Format e-Reporting DGFiP (Décret 2022-1299)
' Cible : .NET Framework 3.5 (HttpWebRequest, pas HttpClient)
'
' Pour Chinook (commerce B2C), les ventes au comptoir ne font pas l'objet
' de Factur-X individuelles, mais d'un e-Reporting agrégé transmis à la
' DGFiP via une Plateforme de Dématérialisation Partenaire (PDP) à
' fréquence décadaire (tous les 10 jours).
'
' Ce service :
'   - Agrège les clôtures Z journalières par décade
'   - Génère le XML e-Reporting conforme schéma DGFiP
'   - Transmet vers l'API de la PDP (configurée dans T_Param)
'   - Trace le cycle de vie dans T_FactureElectronique_Emise + JET
'   - Gère les retries et la mise en file en cas d'indisponibilité PDP
' =============================================

Imports System.Data.SqlClient
Imports System.Globalization
Imports System.IO
Imports System.Net
Imports System.Text
Imports System.Xml

Public Class EReportingService

    Private _connectionString As String

    Public Sub New(connectionString As String)
        _connectionString = connectionString
    End Sub

#Region "Point d'entrée — pilotage périodique"

    ''' <summary>
    ''' Exécute le cycle complet e-Reporting pour une décade :
    ''' génération XML + transmission PDP + tracking statut + JET.
    ''' À appeler typiquement les 10, 20 et derniers du mois.
    ''' </summary>
    ''' <param name="dateDebut">Début de la décade (ex : 01/05/2026)</param>
    ''' <param name="dateFin">Fin de la décade (ex : 10/05/2026)</param>
    ''' <returns>True si la transmission PDP a réussi, False sinon (mis en file)</returns>
    Public Function ExecuterCycleEReporting(dateDebut As DateTime, dateFin As DateTime) As Boolean
        Dim cycleId As Long = 0
        Try
            ' 1. Générer le XML
            Dim xml As String = GenerateReport(dateDebut, dateFin)
            If xml = "AUCUNE_DONNEE" Then
                LogJET("E_REPORTING_VIDE", "Aucune clôture Z pour la période " & dateDebut.ToString("dd/MM/yyyy") & " — " & dateFin.ToString("dd/MM/yyyy"), "", "")
                Return True
            End If

            ' 2. Enregistrer le cycle en base (statut INITIE)
            cycleId = EnregistrerCycle(dateDebut, dateFin, xml, "INITIE")

            ' 3. Transmettre à la PDP
            Dim res As ResultatTransmissionPDP = TransmitToPDP(xml, "EReporting_" & dateDebut.ToString("yyyyMMdd") & "_" & dateFin.ToString("yyyyMMdd") & ".xml")

            ' 4. Mettre à jour le statut
            If res.Reussite Then
                MettreAJourCycle(cycleId, "TRANSMIS", res.IdentifiantPDP, res.MessagePDP)
                LogJET("E_REPORTING_TRANSMIS",
                    "Décade " & dateDebut.ToString("dd/MM/yyyy") & " — " & dateFin.ToString("dd/MM/yyyy") & " transmise à PDP",
                    "", "ID PDP : " & res.IdentifiantPDP)
                Return True
            Else
                MettreAJourCycle(cycleId, "ECHEC", "", res.MessagePDP)
                LogJET("E_REPORTING_ECHEC",
                    "Décade " & dateDebut.ToString("dd/MM/yyyy") & " — " & dateFin.ToString("dd/MM/yyyy") & " — échec PDP",
                    "", res.MessagePDP)
                Return False
            End If
        Catch ex As Exception
            If cycleId > 0 Then MettreAJourCycle(cycleId, "ERREUR_INTERNE", "", ex.Message)
            LogJET("E_REPORTING_ERREUR", "Erreur cycle e-Reporting : " & ex.Message, "", "")
            Throw
        End Try
    End Function

    ''' <summary>
    ''' Rejoue tous les cycles en échec (statut ECHEC) — à appeler par un timer
    ''' externe ou un appel manuel depuis l'UI admin.
    ''' </summary>
    Public Function RejouerEnEchec() As Integer
        Dim retransmis As Integer = 0
        Dim cycles As New System.Collections.Generic.List(Of CycleEnEchec)()

        Using cnn As New SqlConnection(_connectionString)
            cnn.Open()
            Using cmd As New SqlCommand(
                "SELECT Id_FactureElec, DateDebut, DateFin, XmlContent " &
                "FROM T_FactureElectronique_Emise " &
                "WHERE Statut IN ('ECHEC', 'ERREUR_INTERNE') AND TypeFlux = 'E_REPORTING' " &
                "  AND (NbTentatives IS NULL OR NbTentatives < 10)", cnn)
                Using rdr As SqlDataReader = cmd.ExecuteReader()
                    While rdr.Read()
                        Dim c As New CycleEnEchec()
                        c.IdCycle = rdr.GetInt64(0)
                        c.DateDebut = rdr.GetDateTime(1)
                        c.DateFin = rdr.GetDateTime(2)
                        c.Xml = rdr.GetString(3)
                        cycles.Add(c)
                    End While
                End Using
            End Using
        End Using

        For Each c As CycleEnEchec In cycles
            Try
                Dim res As ResultatTransmissionPDP = TransmitToPDP(c.Xml,
                    "EReporting_" & c.DateDebut.ToString("yyyyMMdd") & "_" & c.DateFin.ToString("yyyyMMdd") & ".xml")
                If res.Reussite Then
                    MettreAJourCycle(c.IdCycle, "TRANSMIS", res.IdentifiantPDP, res.MessagePDP)
                    retransmis += 1
                Else
                    IncrementerTentatives(c.IdCycle, res.MessagePDP)
                End If
            Catch ex As Exception
                IncrementerTentatives(c.IdCycle, ex.Message)
            End Try
        Next
        Return retransmis
    End Function

    Private Class CycleEnEchec
        Public IdCycle As Long
        Public DateDebut As DateTime
        Public DateFin As DateTime
        Public Xml As String
    End Class

#End Region

#Region "Génération du XML e-Reporting"

    ''' <summary>Génère le XML e-Reporting pour une période donnée.</summary>
    Public Function GenerateReport(dateDebut As DateTime, dateFin As DateTime) As String
        Dim dt As DataTable = GetDonneesCloture(dateDebut, dateFin)
        If dt.Rows.Count = 0 Then Return "AUCUNE_DONNEE"

        ' Récupérer SIRET / paramètres entreprise depuis T_Param
        Dim siret As String = LireParamString("FacturX_Entreprise_Siret")
        Dim nomEntreprise As String = LireParamString("FacturX_Entreprise_Nom")

        Dim doc As New XmlDocument()
        Dim decl As XmlDeclaration = doc.CreateXmlDeclaration("1.0", "UTF-8", Nothing)
        doc.AppendChild(decl)

        Dim root As XmlElement = doc.CreateElement("EReporting", "urn:dgfip:ereporting:v1")
        doc.AppendChild(root)

        ' Header
        Dim header As XmlElement = doc.CreateElement("Header")
        AppendChildText(doc, header, "Version", "1.0")
        AppendChildText(doc, header, "TypeFlux", "E_REPORTING_DECADAIRE")
        AppendChildText(doc, header, "Siret", siret)
        AppendChildText(doc, header, "NomEntreprise", nomEntreprise)
        AppendChildText(doc, header, "PeriodeDebut", dateDebut.ToString("yyyy-MM-dd"))
        AppendChildText(doc, header, "PeriodeFin", dateFin.ToString("yyyy-MM-dd"))
        AppendChildText(doc, header, "DateGeneration", DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ss"))
        root.AppendChild(header)

        ' Totaux par jour avec ventilation TVA
        Dim transactions As XmlElement = doc.CreateElement("Transactions")
        For Each row As DataRow In dt.Rows
            Dim trans As XmlElement = doc.CreateElement("Transaction")
            trans.SetAttribute("Date", CType(row("DateCloture"), DateTime).ToString("yyyy-MM-dd"))

            Dim totalJourTTC As Decimal = If(IsDBNull(row("MontantTotal_Jour_TTC")), 0D, CDec(row("MontantTotal_Jour_TTC")))
            AppendChildText(doc, trans, "TotalTTC", totalJourTTC.ToString("F2", CultureInfo.InvariantCulture))
            AppendChildText(doc, trans, "TotalHT", If(IsDBNull(row("MontantTotal_Jour_HT")), totalJourTTC, CDec(row("MontantTotal_Jour_HT"))).ToString("F2", CultureInfo.InvariantCulture))
            AppendChildText(doc, trans, "NbTickets", If(IsDBNull(row("NbTickets")), 0, CInt(row("NbTickets"))).ToString())
            AppendChildText(doc, trans, "GrandTotalPerpetuelTTC", If(IsDBNull(row("GrandTotal_Perpetuel_TTC")), 0D, CDec(row("GrandTotal_Perpetuel_TTC"))).ToString("F2", CultureInfo.InvariantCulture))
            AppendChildText(doc, trans, "SignatureCloture", If(IsDBNull(row("Signature")), "", row("Signature").ToString()))

            ' Ventilation TVA agrégée pour la journée
            Dim ventil As XmlElement = doc.CreateElement("VentilationTVA")
            For Each ligneTVA As DataRow In GetVentilationTVAJour(CType(row("DateCloture"), DateTime)).Rows
                Dim taxNode As XmlElement = doc.CreateElement("Taux")
                taxNode.SetAttribute("Taux", CDec(ligneTVA("Taux")).ToString("F2", CultureInfo.InvariantCulture))
                AppendChildText(doc, taxNode, "BaseHT", CDec(ligneTVA("BaseHT")).ToString("F2", CultureInfo.InvariantCulture))
                AppendChildText(doc, taxNode, "MontantTVA", CDec(ligneTVA("MontantTVA")).ToString("F2", CultureInfo.InvariantCulture))
                ventil.AppendChild(taxNode)
            Next
            trans.AppendChild(ventil)

            transactions.AppendChild(trans)
        Next
        root.AppendChild(transactions)

        ' Signature globale du rapport pour intégrité (SHA-256)
        Dim signature As String = ComputeHash(doc.OuterXml)
        AppendChildText(doc, root, "ReportSignature", signature)

        Return FormatXml(doc)
    End Function

    Private Function GetDonneesCloture(startD As DateTime, endD As DateTime) As DataTable
        Dim dt As New DataTable()
        Using cnn As New SqlConnection(_connectionString)
            cnn.Open()
            Using cmd As New SqlCommand(
                "SELECT DateCloture, MontantTotal_Jour_TTC, MontantTotal_Jour_HT, " &
                "       GrandTotal_Perpetuel_TTC, NbTickets, Signature " &
                "FROM T_Cloture " &
                "WHERE TypeCloture = 'Z' AND DateCloture BETWEEN @Start AND @End " &
                "ORDER BY DateCloture", cnn)
                cmd.Parameters.AddWithValue("@Start", startD)
                cmd.Parameters.AddWithValue("@End", endD)
                Using da As New SqlDataAdapter(cmd)
                    da.Fill(dt)
                End Using
            End Using
        End Using
        Return dt
    End Function

    Private Function GetVentilationTVAJour(dateJour As DateTime) As DataTable
        Dim dt As New DataTable()
        Using cnn As New SqlConnection(_connectionString)
            cnn.Open()
            Using cmd As New SqlCommand(
                "SELECT l.CodeTva AS Taux, " &
                "       ISNULL(SUM(l.prix_total_TTC / (1 + CASE WHEN l.CodeTva > 0 THEN l.CodeTva/100.0 ELSE 0 END)), 0) AS BaseHT, " &
                "       ISNULL(SUM(l.prix_total_TTC - l.prix_total_TTC / (1 + CASE WHEN l.CodeTva > 0 THEN l.CodeTva/100.0 ELSE 0 END)), 0) AS MontantTVA " &
                "FROM T_CommandeVente_Ligne l " &
                "INNER JOIN T_CommandeVente cv ON cv.ID_T_CommandeVente = l.ID_T_CommandeVente " &
                "WHERE CAST(cv.TicketLe AS DATE) = @D " &
                "GROUP BY l.CodeTva", cnn)
                cmd.Parameters.AddWithValue("@D", dateJour.Date)
                Using da As New SqlDataAdapter(cmd)
                    da.Fill(dt)
                End Using
            End Using
        End Using
        Return dt
    End Function

#End Region

#Region "Transmission HTTP vers la PDP"

    Public Class ResultatTransmissionPDP
        Public Reussite As Boolean
        Public IdentifiantPDP As String = "" ' ID retourné par la PDP en cas de succès
        Public MessagePDP As String = ""
        Public CodeHttp As Integer
    End Class

    ''' <summary>
    ''' Transmet le XML à la PDP configurée dans T_Param.
    ''' Configuration nécessaire :
    '''   - PDP_API_URL          : URL de base de la PDP (ex: https://api.pennylane.com/v1/)
    '''   - PDP_API_KEY          : clé d'API (X-API-Key ou Authorization Bearer)
    '''   - PDP_API_AUTH_TYPE    : "BEARER" ou "APIKEY" ou "BASIC"
    '''   - PDP_API_ENDPOINT_ER  : endpoint relatif e-Reporting (ex: ereporting/submit)
    ''' </summary>
    Public Function TransmitToPDP(xmlContent As String, fileName As String) As ResultatTransmissionPDP
        Dim res As New ResultatTransmissionPDP()

        Dim baseUrl As String = LireParamString("PDP_API_URL")
        Dim apiKey As String = LireParamString("PDP_API_KEY")
        Dim authType As String = If(String.IsNullOrEmpty(LireParamString("PDP_API_AUTH_TYPE")), "BEARER", LireParamString("PDP_API_AUTH_TYPE"))
        Dim endpoint As String = If(String.IsNullOrEmpty(LireParamString("PDP_API_ENDPOINT_ER")), "ereporting/submit", LireParamString("PDP_API_ENDPOINT_ER"))

        If String.IsNullOrEmpty(baseUrl) OrElse String.IsNullOrEmpty(apiKey) Then
            ' Mode dégradé : sauvegarde sur disque pour transmission manuelle ultérieure
            Try
                Dim fallbackDir As String = Path.Combine(Application.StartupPath, "Exports", "EReporting_Pending")
                Directory.CreateDirectory(fallbackDir)
                File.WriteAllText(Path.Combine(fallbackDir, fileName), xmlContent, Encoding.UTF8)
                res.Reussite = False
                res.MessagePDP = "PDP non configurée — fichier sauvegardé en local : " & fileName
                Return res
            Catch ex As Exception
                res.MessagePDP = "Erreur fallback disque : " & ex.Message
                Return res
            End Try
        End If

        ' Construire la requête HTTP
        Dim url As String = baseUrl.TrimEnd("/"c) & "/" & endpoint.TrimStart("/"c)
        Dim retryMax As Integer = Convert.ToInt32(If(String.IsNullOrEmpty(LireParamString("PDP_API_MAX_RETRIES")), "3", LireParamString("PDP_API_MAX_RETRIES")))
        Dim retryDelayMs As Integer = Convert.ToInt32(If(String.IsNullOrEmpty(LireParamString("PDP_API_RETRY_DELAY_MS")), "2000", LireParamString("PDP_API_RETRY_DELAY_MS")))

        For attempt As Integer = 1 To retryMax
            Try
                Dim request As HttpWebRequest = CType(WebRequest.Create(url), HttpWebRequest)
                request.Method = "POST"
                request.ContentType = "application/xml; charset=utf-8"
                request.Accept = "application/json"
                request.Timeout = 60000 ' 60 secondes

                ' Authentification
                Select Case authType.ToUpper()
                    Case "BEARER"
                        request.Headers.Add("Authorization", "Bearer " & apiKey)
                    Case "APIKEY"
                        request.Headers.Add("X-API-Key", apiKey)
                    Case "BASIC"
                        Dim basicHeader As String = Convert.ToBase64String(Encoding.UTF8.GetBytes(apiKey))
                        request.Headers.Add("Authorization", "Basic " & basicHeader)
                    Case Else
                        request.Headers.Add("X-API-Key", apiKey)
                End Select

                ' Métadonnées de fichier (utiles pour la PDP)
                request.Headers.Add("X-Document-Name", fileName)
                request.Headers.Add("X-Document-Type", "E_REPORTING")
                request.Headers.Add("X-Sender", "CLI 4.0 — Chinook Leucate")

                ' Corps de la requête
                Dim bodyBytes As Byte() = Encoding.UTF8.GetBytes(xmlContent)
                request.ContentLength = bodyBytes.Length
                Using reqStream As Stream = request.GetRequestStream()
                    reqStream.Write(bodyBytes, 0, bodyBytes.Length)
                End Using

                ' Lecture de la réponse
                Using response As HttpWebResponse = CType(request.GetResponse(), HttpWebResponse)
                    res.CodeHttp = CInt(response.StatusCode)
                    Using rs As Stream = response.GetResponseStream()
                        Using sr As New StreamReader(rs)
                            res.MessagePDP = sr.ReadToEnd()
                        End Using
                    End Using
                    res.IdentifiantPDP = If(response.Headers("X-Document-ID"), response.Headers("X-Submission-ID"))
                    res.Reussite = (res.CodeHttp >= 200 AndAlso res.CodeHttp < 300)
                End Using

                If res.Reussite Then Return res

            Catch wex As WebException
                res.MessagePDP = "WebException : " & wex.Message
                If wex.Response IsNot Nothing Then
                    Try
                        Using errResp As HttpWebResponse = CType(wex.Response, HttpWebResponse)
                            res.CodeHttp = CInt(errResp.StatusCode)
                            Using sr As New StreamReader(errResp.GetResponseStream())
                                res.MessagePDP &= " | Corps : " & sr.ReadToEnd()
                            End Using
                        End Using
                    Catch
                    End Try
                End If
                ' Retry sur erreurs réseau/5xx, pas sur 4xx
                If res.CodeHttp >= 400 AndAlso res.CodeHttp < 500 Then Return res
            Catch ex As Exception
                res.MessagePDP = "Exception : " & ex.Message
            End Try

            ' Attendre avant retry
            If attempt < retryMax Then
                System.Threading.Thread.Sleep(retryDelayMs * attempt) ' backoff linéaire
            End If
        Next

        Return res
    End Function

    ''' <summary>
    ''' Conserve la compatibilité avec l'ancienne signature : transmet et
    ''' retourne juste un booléen succès/échec (sans tracking).
    ''' </summary>
    Public Function TransmitReport(xmlContent As String) As Boolean
        Dim fileName As String = "EReporting_" & DateTime.Now.ToString("yyyyMMdd_HHmmss") & ".xml"
        Return TransmitToPDP(xmlContent, fileName).Reussite
    End Function

#End Region

#Region "Persistance + JET"

    Private Function EnregistrerCycle(dateDebut As DateTime, dateFin As DateTime, xml As String, statut As String) As Long
        Using cnn As New SqlConnection(_connectionString)
            cnn.Open()
            Using cmd As New SqlCommand(
                "INSERT INTO T_FactureElectronique_Emise " &
                "(TypeFlux, DateDebut, DateFin, XmlContent, Statut, DateCreation, NbTentatives) " &
                "OUTPUT INSERTED.Id_FactureElec " &
                "VALUES ('E_REPORTING', @DateDebut, @DateFin, @Xml, @Statut, GETDATE(), 0)", cnn)
                cmd.Parameters.AddWithValue("@DateDebut", dateDebut)
                cmd.Parameters.AddWithValue("@DateFin", dateFin)
                cmd.Parameters.AddWithValue("@Xml", xml)
                cmd.Parameters.AddWithValue("@Statut", statut)
                Return Convert.ToInt64(cmd.ExecuteScalar())
            End Using
        End Using
    End Function

    Private Sub MettreAJourCycle(idCycle As Long, statut As String, idPdp As String, message As String)
        Using cnn As New SqlConnection(_connectionString)
            cnn.Open()
            Using cmd As New SqlCommand(
                "UPDATE T_FactureElectronique_Emise " &
                "SET Statut = @Statut, IdentifiantPDP = @IdPdp, MessagePDP = @Msg, DateMaj = GETDATE() " &
                "WHERE Id_FactureElec = @Id", cnn)
                cmd.Parameters.AddWithValue("@Statut", statut)
                cmd.Parameters.AddWithValue("@IdPdp", If(idPdp, ""))
                cmd.Parameters.AddWithValue("@Msg", If(message, ""))
                cmd.Parameters.AddWithValue("@Id", idCycle)
                cmd.ExecuteNonQuery()
            End Using
        End Using
    End Sub

    Private Sub IncrementerTentatives(idCycle As Long, message As String)
        Using cnn As New SqlConnection(_connectionString)
            cnn.Open()
            Using cmd As New SqlCommand(
                "UPDATE T_FactureElectronique_Emise " &
                "SET NbTentatives = ISNULL(NbTentatives, 0) + 1, MessagePDP = @Msg, DateMaj = GETDATE() " &
                "WHERE Id_FactureElec = @Id", cnn)
                cmd.Parameters.AddWithValue("@Msg", If(message, ""))
                cmd.Parameters.AddWithValue("@Id", idCycle)
                cmd.ExecuteNonQuery()
            End Using
        End Using
    End Sub

    Private Function LireParamString(nom As String) As String
        Using cnn As New SqlConnection(_connectionString)
            cnn.Open()
            Using cmd As New SqlCommand("SELECT Paramvalue FROM T_Param WHERE Paramname = @N", cnn)
                cmd.Parameters.AddWithValue("@N", nom)
                Dim r As Object = cmd.ExecuteScalar()
                If r Is Nothing OrElse r Is DBNull.Value Then Return ""
                Return r.ToString()
            End Using
        End Using
    End Function

    Private Sub LogJET(typeEvent As String, description As String, ancienneVal As String, nouvelleVal As String)
        Try
            ' Réutilisation du LogEventTechnique du module NF525 (signe + chaîne via PreviousSignature)
            ModuleNF525.LogEventTechnique(typeEvent, description, ancienneVal, nouvelleVal)
        Catch
            ' En cas d'indisponibilité du module NF525, on évite de planter le service
        End Try
    End Sub

#End Region

#Region "Helpers XML"

    Private Shared Sub AppendChildText(doc As XmlDocument, parent As XmlElement, name As String, value As String)
        Dim el As XmlElement = doc.CreateElement(name)
        el.InnerText = If(value, "")
        parent.AppendChild(el)
    End Sub

    Private Function FormatXml(doc As XmlDocument) As String
        Dim settings As New XmlWriterSettings()
        settings.Indent = True
        settings.Encoding = New UTF8Encoding(False)
        Using sw As New StringWriter()
            Using writer As XmlWriter = XmlWriter.Create(sw, settings)
                doc.Save(writer)
            End Using
            Return sw.ToString().Replace("utf-16", "UTF-8")
        End Using
    End Function

    Private Function ComputeHash(input As String) As String
        Using sha As New System.Security.Cryptography.SHA256Managed()
            Dim bytes As Byte() = Encoding.UTF8.GetBytes(input)
            Dim hash As Byte() = sha.ComputeHash(bytes)
            Return Convert.ToBase64String(hash)
        End Using
    End Function

#End Region

End Class
