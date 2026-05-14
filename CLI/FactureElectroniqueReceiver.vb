' =============================================
' Réforme facturation électronique 2026-2027
' RÉCEPTEUR DE FACTURES ÉLECTRONIQUES — Côté entrant
' =============================================
' Obligation : à compter du 1er septembre 2026, TOUTES les entreprises
' (y compris Chinook) doivent pouvoir RECEVOIR les factures électroniques
' de leurs fournisseurs au format Factur-X / UBL / CII via une PDP.
'
' Ce service :
'   - Poll la PDP via HTTP pour récupérer la liste des factures fournisseur
'     en attente
'   - Télécharge les PDF/A-3 Factur-X correspondants
'   - Extrait le XML embarqué et le parse pour pré-remplir les champs
'   - Insère dans T_FactureElectronique_Recue (statut RECUE)
'   - Trace dans le JET (RECEPTION_FACTURE_ELEC)
'
' Le contrôle métier (validation par un comptable, mise en paiement) reste
' assuré par l'utilisateur via une UI dédiée à développer côté FormCaisse
' admin (hors périmètre de ce service : ce service est uniquement le
' "récepteur" qui rapatrie les données).
' =============================================

Imports System.Data.SqlClient
Imports System.IO
Imports System.Net
Imports System.Text
Imports System.Xml

Public Class FactureElectroniqueReceiver

    Private _connectionString As String

    Public Sub New(connectionString As String)
        _connectionString = connectionString
    End Sub

#Region "Cycle complet : poll PDP + télécharger + parser + stocker"

    ''' <summary>
    ''' Exécute un cycle de réception : poll la PDP, télécharge les nouvelles
    ''' factures fournisseur, extrait les données et insère en base.
    ''' </summary>
    ''' <returns>Nombre de factures réceptionnées</returns>
    Public Function ExecuterCycleReception() As Integer
        Dim nbRecues As Integer = 0
        Try
            Dim ids As System.Collections.Generic.List(Of String) = ListerFacturesPDP()
            For Each idPdp As String In ids
                Try
                    ' Vérifier qu'on ne l'a pas déjà reçue
                    If Not FactureDejaRecue(idPdp) Then
                        Dim pdfBytes As Byte() = TelechargerPDF(idPdp)
                        Dim xml As String = ExtraireXmlDuPdf(pdfBytes)
                        Dim resume As ResumeFactureRecue = ParserXmlFacturX(xml)
                        resume.IdentifiantPDP = idPdp
                        InsererFactureRecue(resume, pdfBytes, xml)
                        nbRecues += 1
                        LogJET("RECEPTION_FACTURE_ELEC",
                            "Facture reçue de " & resume.FournisseurNom & " — " & resume.NumeroFacture,
                            "", "ID PDP : " & idPdp & " | Montant TTC : " & resume.MontantTTC.ToString("F2"))
                    End If
                Catch exFact As Exception
                    LogJET("ERREUR_RECEPTION_FACTURE",
                        "Échec réception facture PDP " & idPdp,
                        "", exFact.Message)
                End Try
            Next
        Catch ex As Exception
            LogJET("ERREUR_CYCLE_RECEPTION", "Erreur cycle réception : " & ex.Message, "", "")
            Throw
        End Try
        Return nbRecues
    End Function

#End Region

#Region "Communication PDP"

    ''' <summary>Liste les IDs PDP des factures fournisseur non encore réceptionnées.</summary>
    Private Function ListerFacturesPDP() As System.Collections.Generic.List(Of String)
        Dim ids As New System.Collections.Generic.List(Of String)()
        Dim baseUrl As String = LireParamString("PDP_API_URL")
        Dim apiKey As String = LireParamString("PDP_API_KEY")
        Dim authType As String = If(String.IsNullOrEmpty(LireParamString("PDP_API_AUTH_TYPE")), "BEARER", LireParamString("PDP_API_AUTH_TYPE"))
        Dim endpoint As String = If(String.IsNullOrEmpty(LireParamString("PDP_API_ENDPOINT_INBOX")),
                                    "invoices/inbox?status=new", LireParamString("PDP_API_ENDPOINT_INBOX"))

        If String.IsNullOrEmpty(baseUrl) OrElse String.IsNullOrEmpty(apiKey) Then
            Throw New InvalidOperationException("PDP non configurée (T_Param PDP_API_URL / PDP_API_KEY).")
        End If

        Dim url As String = baseUrl.TrimEnd("/"c) & "/" & endpoint.TrimStart("/"c)
        Dim request As HttpWebRequest = CType(WebRequest.Create(url), HttpWebRequest)
        request.Method = "GET"
        request.Accept = "application/json"
        AjouterAuth(request, apiKey, authType)
        request.Timeout = 60000

        Using response As HttpWebResponse = CType(request.GetResponse(), HttpWebResponse)
            Using sr As New StreamReader(response.GetResponseStream())
                Dim body As String = sr.ReadToEnd()
                ' Parsing minimaliste JSON : on cherche les IDs dans la réponse
                ' Format attendu : { "invoices": [ { "id": "xxx" }, ... ] }
                Dim idx As Integer = 0
                While True
                    idx = body.IndexOf("""id""", idx, StringComparison.OrdinalIgnoreCase)
                    If idx < 0 Then Exit While
                    Dim colonIdx As Integer = body.IndexOf(":", idx)
                    Dim startQuote As Integer = body.IndexOf("""", colonIdx + 1)
                    Dim endQuote As Integer = body.IndexOf("""", startQuote + 1)
                    If startQuote > 0 AndAlso endQuote > startQuote Then
                        Dim id As String = body.Substring(startQuote + 1, endQuote - startQuote - 1)
                        If Not String.IsNullOrEmpty(id) Then ids.Add(id)
                    End If
                    idx = endQuote + 1
                End While
            End Using
        End Using
        Return ids
    End Function

    ''' <summary>Télécharge le PDF Factur-X d'une facture identifiée par son ID PDP.</summary>
    Private Function TelechargerPDF(idPdp As String) As Byte()
        Dim baseUrl As String = LireParamString("PDP_API_URL")
        Dim apiKey As String = LireParamString("PDP_API_KEY")
        Dim authType As String = If(String.IsNullOrEmpty(LireParamString("PDP_API_AUTH_TYPE")), "BEARER", LireParamString("PDP_API_AUTH_TYPE"))
        Dim endpointTpl As String = If(String.IsNullOrEmpty(LireParamString("PDP_API_ENDPOINT_DOWNLOAD")),
                                        "invoices/{id}/download", LireParamString("PDP_API_ENDPOINT_DOWNLOAD"))
        Dim url As String = baseUrl.TrimEnd("/"c) & "/" & endpointTpl.TrimStart("/"c).Replace("{id}", idPdp)

        Dim request As HttpWebRequest = CType(WebRequest.Create(url), HttpWebRequest)
        request.Method = "GET"
        request.Accept = "application/pdf"
        AjouterAuth(request, apiKey, authType)
        request.Timeout = 120000

        Using response As HttpWebResponse = CType(request.GetResponse(), HttpWebResponse)
            Using rs As Stream = response.GetResponseStream()
                Using ms As New MemoryStream()
                    Dim buf(8191) As Byte
                    Dim n As Integer = rs.Read(buf, 0, buf.Length)
                    While n > 0
                        ms.Write(buf, 0, n)
                        n = rs.Read(buf, 0, buf.Length)
                    End While
                    Return ms.ToArray()
                End Using
            End Using
        End Using
    End Function

    Private Shared Sub AjouterAuth(request As HttpWebRequest, apiKey As String, authType As String)
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
    End Sub

#End Region

#Region "Extraction du XML embarqué dans le PDF"

    ''' <summary>
    ''' Extrait le XML Factur-X embarqué dans un PDF/A-3.
    ''' Recherche un EmbeddedFile dont le filename est factur-x.xml (ou xrechnung.xml,
    ''' ou ZUGFeRD-invoice.xml selon la norme allemande équivalente).
    ''' </summary>
    Public Shared Function ExtraireXmlDuPdf(pdfBytes As Byte()) As String
        ' Convertir en texte ASCII pour parser le PDF de bas niveau
        Dim contenu As String = Encoding.GetEncoding("ISO-8859-1").GetString(pdfBytes)

        ' Chercher la séquence /Type /EmbeddedFile suivie d'un stream
        Dim noms As String() = New String() {"factur-x.xml", "xrechnung.xml", "ZUGFeRD-invoice.xml"}
        For Each nom As String In noms
            Dim idxNom As Integer = contenu.IndexOf("(" & nom & ")", StringComparison.OrdinalIgnoreCase)
            If idxNom < 0 Then idxNom = contenu.IndexOf(nom, StringComparison.OrdinalIgnoreCase)
            If idxNom < 0 Then Continue For

            ' Chercher le stream le plus proche
            Dim idxStream As Integer = contenu.IndexOf("stream" & vbLf, idxNom)
            If idxStream < 0 Then idxStream = contenu.IndexOf("stream" & vbCrLf, idxNom)
            If idxStream < 0 Then Continue For

            Dim startContent As Integer = idxStream + "stream".Length
            ' Sauter le saut de ligne après "stream"
            While startContent < pdfBytes.Length AndAlso (pdfBytes(startContent) = 10 OrElse pdfBytes(startContent) = 13)
                startContent += 1
            End While

            Dim idxEndStream As Integer = contenu.IndexOf("endstream", startContent)
            If idxEndStream < 0 Then Continue For

            Dim length As Integer = idxEndStream - startContent
            ' Trim trailing newlines avant endstream
            While length > 0 AndAlso (pdfBytes(startContent + length - 1) = 10 OrElse pdfBytes(startContent + length - 1) = 13)
                length -= 1
            End While

            Dim xmlBytes(length - 1) As Byte
            Array.Copy(pdfBytes, startContent, xmlBytes, 0, length)
            Return Encoding.UTF8.GetString(xmlBytes)
        Next
        Throw New InvalidDataException("Aucun XML Factur-X / XRechnung / ZUGFeRD trouvé dans le PDF.")
    End Function

#End Region

#Region "Parsing XML Factur-X / EN 16931"

    Public Class ResumeFactureRecue
        Public IdentifiantPDP As String = ""
        Public NumeroFacture As String = ""
        Public DateFacture As DateTime
        Public DateEcheance As DateTime
        Public FournisseurNom As String = ""
        Public FournisseurSiret As String = ""
        Public FournisseurTvaIntracom As String = ""
        Public MontantHT As Decimal
        Public MontantTVA As Decimal
        Public MontantTTC As Decimal
        Public Devises As String = "EUR"
        Public Profil As String = ""
    End Class

    Public Shared Function ParserXmlFacturX(xml As String) As ResumeFactureRecue
        Dim r As New ResumeFactureRecue()
        Dim doc As New XmlDocument()
        doc.LoadXml(xml)

        Dim nsmgr As New XmlNamespaceManager(doc.NameTable)
        nsmgr.AddNamespace("rsm", "urn:un:unece:uncefact:data:standard:CrossIndustryInvoice:100")
        nsmgr.AddNamespace("ram", "urn:un:unece:uncefact:data:standard:ReusableAggregateBusinessInformationEntity:100")
        nsmgr.AddNamespace("udt", "urn:un:unece:uncefact:data:standard:UnqualifiedDataType:100")

        r.NumeroFacture = LireNoeudTexte(doc, "//rsm:ExchangedDocument/ram:ID", nsmgr)
        Dim dateStr As String = LireNoeudTexte(doc, "//rsm:ExchangedDocument/ram:IssueDateTime/udt:DateTimeString", nsmgr)
        Dim parsedDate As DateTime
        If DateTime.TryParseExact(dateStr, "yyyyMMdd", System.Globalization.CultureInfo.InvariantCulture, Globalization.DateTimeStyles.None, parsedDate) Then
            r.DateFacture = parsedDate
        End If

        r.FournisseurNom = LireNoeudTexte(doc, "//ram:SellerTradeParty/ram:Name", nsmgr)
        r.FournisseurSiret = LireNoeudTexte(doc, "//ram:SellerTradeParty/ram:SpecifiedLegalOrganization/ram:ID", nsmgr)
        r.FournisseurTvaIntracom = LireNoeudTexte(doc, "//ram:SellerTradeParty/ram:SpecifiedTaxRegistration/ram:ID", nsmgr)

        Dim totalHTStr As String = LireNoeudTexte(doc, "//ram:SpecifiedTradeSettlementHeaderMonetarySummation/ram:LineTotalAmount", nsmgr)
        Dim totalTVAStr As String = LireNoeudTexte(doc, "//ram:SpecifiedTradeSettlementHeaderMonetarySummation/ram:TaxTotalAmount", nsmgr)
        Dim totalTTCStr As String = LireNoeudTexte(doc, "//ram:SpecifiedTradeSettlementHeaderMonetarySummation/ram:GrandTotalAmount", nsmgr)
        Decimal.TryParse(totalHTStr, Globalization.NumberStyles.Any, Globalization.CultureInfo.InvariantCulture, r.MontantHT)
        Decimal.TryParse(totalTVAStr, Globalization.NumberStyles.Any, Globalization.CultureInfo.InvariantCulture, r.MontantTVA)
        Decimal.TryParse(totalTTCStr, Globalization.NumberStyles.Any, Globalization.CultureInfo.InvariantCulture, r.MontantTTC)

        r.Devises = LireNoeudTexte(doc, "//ram:ApplicableHeaderTradeSettlement/ram:InvoiceCurrencyCode", nsmgr)
        If String.IsNullOrEmpty(r.Devises) Then r.Devises = "EUR"

        Dim dueStr As String = LireNoeudTexte(doc, "//ram:SpecifiedTradePaymentTerms/ram:DueDateDateTime/udt:DateTimeString", nsmgr)
        If DateTime.TryParseExact(dueStr, "yyyyMMdd", System.Globalization.CultureInfo.InvariantCulture, Globalization.DateTimeStyles.None, parsedDate) Then
            r.DateEcheance = parsedDate
        End If

        r.Profil = LireNoeudTexte(doc, "//ram:GuidelineSpecifiedDocumentContextParameter/ram:ID", nsmgr)

        Return r
    End Function

    Private Shared Function LireNoeudTexte(doc As XmlDocument, xpath As String, nsmgr As XmlNamespaceManager) As String
        Dim n As XmlNode = doc.SelectSingleNode(xpath, nsmgr)
        If n Is Nothing Then Return ""
        Return n.InnerText
    End Function

#End Region

#Region "Persistance + JET"

    Private Function FactureDejaRecue(idPdp As String) As Boolean
        Using cnn As New SqlConnection(_connectionString)
            cnn.Open()
            Using cmd As New SqlCommand("SELECT COUNT(*) FROM T_FactureElectronique_Recue WHERE IdentifiantPDP = @Id", cnn)
                cmd.Parameters.AddWithValue("@Id", idPdp)
                Return Convert.ToInt32(cmd.ExecuteScalar()) > 0
            End Using
        End Using
    End Function

    Private Sub InsererFactureRecue(r As ResumeFactureRecue, pdfBytes As Byte(), xml As String)
        Using cnn As New SqlConnection(_connectionString)
            cnn.Open()
            Using cmd As New SqlCommand(
                "INSERT INTO T_FactureElectronique_Recue " &
                "(IdentifiantPDP, NumeroFacture, DateFacture, DateEcheance, FournisseurNom, FournisseurSiret, " &
                " FournisseurTvaIntracom, MontantHT, MontantTVA, MontantTTC, Devises, Profil, " &
                " XmlContent, PdfBytes, Statut, DateReception) " &
                "VALUES (@IdPdp, @NoFac, @DateFac, @DateEch, @FourNom, @FourSiret, " &
                "        @FourTva, @MtHT, @MtTVA, @MtTTC, @Devises, @Profil, " &
                "        @Xml, @Pdf, 'RECUE', GETDATE())", cnn)
                cmd.Parameters.AddWithValue("@IdPdp", r.IdentifiantPDP)
                cmd.Parameters.AddWithValue("@NoFac", r.NumeroFacture)
                cmd.Parameters.AddWithValue("@DateFac", r.DateFacture)
                cmd.Parameters.AddWithValue("@DateEch", r.DateEcheance)
                cmd.Parameters.AddWithValue("@FourNom", r.FournisseurNom)
                cmd.Parameters.AddWithValue("@FourSiret", r.FournisseurSiret)
                cmd.Parameters.AddWithValue("@FourTva", r.FournisseurTvaIntracom)
                cmd.Parameters.AddWithValue("@MtHT", r.MontantHT)
                cmd.Parameters.AddWithValue("@MtTVA", r.MontantTVA)
                cmd.Parameters.AddWithValue("@MtTTC", r.MontantTTC)
                cmd.Parameters.AddWithValue("@Devises", r.Devises)
                cmd.Parameters.AddWithValue("@Profil", r.Profil)
                cmd.Parameters.AddWithValue("@Xml", xml)
                cmd.Parameters.AddWithValue("@Pdf", pdfBytes)
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
            ModuleNF525.LogEventTechnique(typeEvent, description, ancienneVal, nouvelleVal)
        Catch
        End Try
    End Sub

#End Region

End Class
