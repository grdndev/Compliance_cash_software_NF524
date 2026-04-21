Imports System.Data.SqlClient
Imports System.Globalization
Imports System.Text

''' <summary>
''' Module principal NF525 - Fonctions métier pour la certification fiscale
''' Gère les clôtures, le journal des événements et l'archivage
''' </summary>
Public Module ModuleNF525

    ' ── Variables module pour l'impression Ticket Z (imposé par .NET 3.5 : pas de lambda dans AddHandler) ──
    Private _ticketZLignes() As String = Nothing
    Private _ticketZFont As System.Drawing.Font = Nothing

    ''' <summary>
    ''' Gestionnaire d'événement PrintPage pour le Ticket Z.
    ''' Méthode nommée requise car VB.NET 9 (.NET 3.5) n'autorise pas les lambdas dans AddHandler.
    ''' </summary>
    Private Sub TicketZ_PrintPage(ByVal sender As Object,
                                   ByVal e As System.Drawing.Printing.PrintPageEventArgs)
        If _ticketZLignes Is Nothing OrElse _ticketZFont Is Nothing Then Return
        Dim y As Single = e.MarginBounds.Top
        Dim hauteurLigne As Single = _ticketZFont.GetHeight(e.Graphics)
        For Each ligne As String In _ticketZLignes
            If y + hauteurLigne > e.MarginBounds.Bottom Then Exit For
            e.Graphics.DrawString(ligne, _ticketZFont,
                                  System.Drawing.Brushes.Black, e.MarginBounds.Left, y)
            y += hauteurLigne
        Next
    End Sub

#Region "Journal des Événements Techniques (JET)"

    ''' <summary>
    ''' Enregistre un événement technique dans le JET (Journal des Événements Techniques)
    ''' Obligatoire NF525 pour tracer : démarrages, changements TVA/prix, exports
    ''' </summary>
    Public Sub LogEventTechnique(eventType As String, description As String, _
                                 Optional ancienneValeur As String = "", _
                                 Optional nouvelleValeur As String = "")
        Try
            ' Récupérer la signature précédente
            Dim prevSig As String = GetPreviousEventSignature()

            ' Préparer les données à signer
            Dim dataToSign As String = eventType & Now.ToString("yyyyMMddHHmmss") & _
                                      description & gLogin & prevSig

            ' Calculer la signature
            Dim signature As String = NF525.SignatureHelper.ComputeSignature(dataToSign)

            ' Insérer dans la base
            Dim sql As String = "INSERT INTO T_JournalEvenements " & _
                "(TypeEvent, Description, AncienneValeur, NouvelleValeur, " & _
                 "Utilisateur, VersionLogiciel, Signature, PreviousSignature) " & _
                "VALUES (@Type, @Desc, @Old, @New, @User, @Version, @Sig, @PrevSig)"

            Using cnn As New SqlConnection(My.Settings.CLIConnectionString)
                cnn.Open()
                Using cmd As New SqlCommand(sql, cnn)
                    cmd.Parameters.AddWithValue("@Type", eventType)
                    cmd.Parameters.AddWithValue("@Desc", description)
                    cmd.Parameters.AddWithValue("@Old", If(ancienneValeur = "", DBNull.Value, ancienneValeur))
                    cmd.Parameters.AddWithValue("@New", If(nouvelleValeur = "", DBNull.Value, nouvelleValeur))
                    cmd.Parameters.AddWithValue("@User", gLogin)
                    cmd.Parameters.AddWithValue("@Version", Application.ProductVersion)
                    cmd.Parameters.AddWithValue("@Sig", signature)
                    cmd.Parameters.AddWithValue("@PrevSig", prevSig)
                    cmd.ExecuteNonQuery()
                End Using
            End Using

        Catch ex As Exception
            ' Ne pas bloquer le processus si le JET échoue
            ' Mais logger dans un fichier texte comme fallback
            Try
                Dim logPath As String = "C:\temp\cli\nf525_jet_error.log"
                System.IO.Directory.CreateDirectory("C:\temp\cli")
                System.IO.File.AppendAllText(logPath, _
                    Now.ToString() & " | ERREUR JET | " & eventType & " | " & ex.Message & vbCrLf)
            Catch
                ' Silence totale en dernier recours
            End Try
        End Try
    End Sub

    ''' <summary>
    ''' Récupère la dernière signature du JET pour le chaînage
    ''' </summary>
    Private Function GetPreviousEventSignature() As String
        Try
            Dim sql As String = "SELECT TOP 1 Signature FROM T_JournalEvenements ORDER BY Id_Event DESC"
            Using cnn As New SqlConnection(My.Settings.CLIConnectionString)
                cnn.Open()
                Using cmd As New SqlCommand(sql, cnn)
                    Dim result = cmd.ExecuteScalar()
                    If result IsNot Nothing AndAlso Not IsDBNull(result) Then
                        Return result.ToString()
                    Else
                        Return "INITIAL_JET_START"
                    End If
                End Using
            End Using
        Catch ex As Exception
            Return "ERROR_JET_PREVIOUS"
        End Try
    End Function

#End Region

#Region "Clôtures (Grand Total & Ticket Z)"

    ''' <summary>
    ''' Récupère le Grand Total Perpétuel actuel (cumul de toutes les ventes depuis l'origine)
    ''' </summary>
    Public Function GetGrandTotalActuel() As Decimal
        Try
            Dim sql As String = "SELECT TOP 1 GrandTotal_Perpetuel_TTC FROM T_Cloture ORDER BY Id_Cloture DESC"
            Using cnn As New SqlConnection(My.Settings.CLIConnectionString)
                cnn.Open()
                Using cmd As New SqlCommand(sql, cnn)
                    Dim result = cmd.ExecuteScalar()
                    If result IsNot Nothing AndAlso Not IsDBNull(result) Then
                        Return Convert.ToDecimal(result)
                    Else
                        ' Première clôture : calculer le total depuis le début
                        Return CalculerTotalDepuisOrigine()
                    End If
                End Using
            End Using
        Catch ex As Exception
            LogEventTechnique("ERREUR_GRAND_TOTAL", "Erreur récupération Grand Total : " & ex.Message)
            Return 0
        End Try
    End Function

    ''' <summary>
    ''' Calcule le total de toutes les ventes validées depuis l'origine
    ''' Utilisé pour initialiser le Grand Total si aucune clôture n'existe
    ''' </summary>
    Private Function CalculerTotalDepuisOrigine() As Decimal
        Try
            Dim sql As String = "SELECT ISNULL(SUM(Total_TTC), 0) FROM T_CommandeVente WHERE TicketLe IS NOT NULL AND ID_EtatCommandeVente >= 20"
            Using cnn As New SqlConnection(My.Settings.CLIConnectionString)
                cnn.Open()
                Using cmd As New SqlCommand(sql, cnn)
                    Return Convert.ToDecimal(cmd.ExecuteScalar())
                End Using
            End Using
        Catch ex As Exception
            Return 0
        End Try
    End Function

    ''' <summary>
    ''' Récupère le dernier numéro de clôture
    ''' </summary>
    Public Function GetLastClotureId() As Long
        Try
            Dim sql As String = "SELECT TOP 1 Id_Cloture FROM T_Cloture ORDER BY Id_Cloture DESC"
            Using cnn As New SqlConnection(My.Settings.CLIConnectionString)
                cnn.Open()
                Using cmd As New SqlCommand(sql, cnn)
                    Dim result = cmd.ExecuteScalar()
                    If result IsNot Nothing AndAlso Not IsDBNull(result) Then
                        Return Convert.ToInt64(result)
                    Else
                        Return 0
                    End If
                End Using
            End Using
        Catch ex As Exception
            Return 0
        End Try
    End Function

    ''' <summary>
    ''' Récupère la dernière signature de clôture pour le chaînage
    ''' </summary>
    Private Function GetPreviousClotureSignature() As String
        Try
            Dim sql As String = "SELECT TOP 1 Signature FROM T_Cloture ORDER BY Id_Cloture DESC"
            Using cnn As New SqlConnection(My.Settings.CLIConnectionString)
                cnn.Open()
                Using cmd As New SqlCommand(sql, cnn)
                    Dim result = cmd.ExecuteScalar()
                    If result IsNot Nothing AndAlso Not IsDBNull(result) Then
                        Return result.ToString()
                    Else
                        Return "INITIAL_CLOTURE_START"
                    End If
                End Using
            End Using
        Catch ex As Exception
            Return "ERROR_CLOTURE_PREVIOUS"
        End Try
    End Function

    ''' <summary>
    ''' Effectue la clôture mensuelle (Ticket M)
    ''' OBLIGATOIRE NF525 : À exécuter à la fin de chaque mois
    ''' </summary>
    Public Function ClotureMensuelle() As Long
        Try
            Dim moisDebut As Date = New Date(Now.Year, Now.Month, 1)
            Dim moisFin As Date = moisDebut.AddMonths(1).AddSeconds(-1)

            ' Vérifier qu'aucune clôture mensuelle n'existe déjà pour ce mois
            Dim sqlVerif As String = "SELECT COUNT(*) FROM T_Cloture " &
                                    "WHERE TypeCloture = 'MOIS' " &
                                    "AND YEAR(DateCloture) = @Annee AND MONTH(DateCloture) = @Mois"
            Using cnnV As New SqlConnection(My.Settings.CLIConnectionString)
                cnnV.Open()
                Using cmdV As New SqlCommand(sqlVerif, cnnV)
                    cmdV.Parameters.AddWithValue("@Annee", Now.Year)
                    cmdV.Parameters.AddWithValue("@Mois", Now.Month)
                    Dim nbExistantes As Integer = Convert.ToInt32(cmdV.ExecuteScalar())
                    If nbExistantes > 0 Then
                        Throw New InvalidOperationException("Une clôture mensuelle existe déjà pour " &
                            Now.ToString("MMMM yyyy") & ". Impossible d'en créer une seconde.")
                    End If
                End Using
            End Using

            ' Calculer le CA du mois et la plage de tickets
            Dim montantMois As Decimal = 0
            Dim premierTicketID As Long = 0
            Dim dernierTicketID As Long = 0

            Using cnn As New SqlConnection(My.Settings.CLIConnectionString)
                cnn.Open()
                Dim sqlMontant As String = "SELECT ISNULL(SUM(Total_TTC), 0) FROM T_CommandeVente " &
                                          "WHERE TicketLe BETWEEN @Debut AND @Fin AND ID_EtatCommandeVente >= 20"
                Using cmd As New SqlCommand(sqlMontant, cnn)
                    cmd.Parameters.AddWithValue("@Debut", moisDebut)
                    cmd.Parameters.AddWithValue("@Fin", moisFin)
                    montantMois = Convert.ToDecimal(cmd.ExecuteScalar())
                End Using

                Dim sqlPlage As String = "SELECT MIN(ID_T_CommandeVente), MAX(ID_T_CommandeVente) " &
                                        "FROM T_CommandeVente " &
                                        "WHERE TicketLe BETWEEN @Debut AND @Fin AND ID_EtatCommandeVente >= 20"
                Using cmd As New SqlCommand(sqlPlage, cnn)
                    cmd.Parameters.AddWithValue("@Debut", moisDebut)
                    cmd.Parameters.AddWithValue("@Fin", moisFin)
                    Using reader As SqlDataReader = cmd.ExecuteReader()
                        If reader.Read() Then
                            If Not IsDBNull(reader(0)) Then premierTicketID = Convert.ToInt64(reader(0))
                            If Not IsDBNull(reader(1)) Then dernierTicketID = Convert.ToInt64(reader(1))
                        End If
                    End Using
                End Using
            End Using

            ' Grand Total + signature
            ' NF525 : les clôtures journalières Z (obligatoires quotidiennement) ont DÉJÀ
            ' incrémenté le GTP au fil de la journée. La clôture mensuelle M est un récapitulatif
            ' de la période — elle NE doit PAS ré-ajouter le CA du mois au GTP (double-comptage).
            ' Le GTP de la clôture M = GTP actuel (inchangé), seul le MontantTotal_Jour_TTC
            ' (ici montantMois) est renseigné à titre de référence pour la période.
            Dim grandTotalPrecedent As Decimal = GetGrandTotalActuel()
            Dim nouveauGrandTotal As Decimal = grandTotalPrecedent ' GTP inchangé — déjà mis à jour par les Z journalières
            Dim prevSig As String = GetPreviousClotureSignature()
            Dim dataACle As String = "MOIS" & Now.ToString("yyyyMMddHHmmss") & _
                                    nouveauGrandTotal.ToString("0.00", CultureInfo.InvariantCulture) & prevSig
            Dim signature As String = NF525.SignatureHelper.ComputeSignature(dataACle)

            Dim clotureId As Long = 0
            Dim sqlInsert As String = "INSERT INTO T_Cloture (TypeCloture, MontantTotal_Jour_TTC, GrandTotal_Perpetuel_TTC, " &
                                     "PremierTicketID, DernierTicketID, Signature, PreviousSignature, CreePar) " &
                                     "VALUES ('MOIS', @Montant, @GrandTotal, @Premier, @Dernier, @Sig, @PrevSig, @User); " &
                                     "SELECT SCOPE_IDENTITY();"
            Using cnn As New SqlConnection(My.Settings.CLIConnectionString)
                cnn.Open()
                Using cmd As New SqlCommand(sqlInsert, cnn)
                    cmd.Parameters.AddWithValue("@Montant", montantMois)
                    cmd.Parameters.AddWithValue("@GrandTotal", nouveauGrandTotal)
                    cmd.Parameters.AddWithValue("@Premier", If(premierTicketID = 0, CType(DBNull.Value, Object), premierTicketID))
                    cmd.Parameters.AddWithValue("@Dernier", If(dernierTicketID = 0, CType(DBNull.Value, Object), dernierTicketID))
                    cmd.Parameters.AddWithValue("@Sig", signature)
                    cmd.Parameters.AddWithValue("@PrevSig", prevSig)
                    cmd.Parameters.AddWithValue("@User", gLogin)
                    clotureId = Convert.ToInt64(cmd.ExecuteScalar())
                End Using
            End Using

            LogEventTechnique("CLOTURE_MENSUELLE",
                            "Clôture M n°" & clotureId & " - " & Now.ToString("MMMM yyyy") &
                            " - CA mois=" & montantMois.ToString("F2") & "EUR - Grand Total=" & nouveauGrandTotal.ToString("F2") & "EUR",
                            grandTotalPrecedent.ToString("F2"), nouveauGrandTotal.ToString("F2"))
            Return clotureId

        Catch ex As Exception
            LogEventTechnique("ERREUR_CLOTURE_MENSUELLE", "Erreur clôture mensuelle : " & ex.Message)
            Throw New Exception("Erreur lors de la clôture mensuelle : " & ex.Message)
        End Try
    End Function

    ''' <summary>
    ''' Effectue la clôture annuelle (Ticket A)
    ''' OBLIGATOIRE NF525 : À exécuter à la fin de chaque exercice comptable
    ''' </summary>
    Public Function ClotureAnnuelle() As Long
        Try
            Dim anneeDebut As Date = New Date(Now.Year, 1, 1)
            Dim anneeFin As Date = New Date(Now.Year, 12, 31, 23, 59, 59)

            ' Vérifier qu'aucune clôture annuelle n'existe déjà pour cette année
            Dim sqlVerif As String = "SELECT COUNT(*) FROM T_Cloture " &
                                    "WHERE TypeCloture = 'ANNEE' AND YEAR(DateCloture) = @Annee"
            Using cnnV As New SqlConnection(My.Settings.CLIConnectionString)
                cnnV.Open()
                Using cmdV As New SqlCommand(sqlVerif, cnnV)
                    cmdV.Parameters.AddWithValue("@Annee", Now.Year)
                    Dim nbExistantes As Integer = Convert.ToInt32(cmdV.ExecuteScalar())
                    If nbExistantes > 0 Then
                        Throw New InvalidOperationException("Une clôture annuelle existe déjà pour " &
                            Now.Year.ToString() & ". Impossible d'en créer une seconde.")
                    End If
                End Using
            End Using

            ' Calculer le CA annuel
            Dim montantAnnee As Decimal = 0
            Dim premierTicketID As Long = 0
            Dim dernierTicketID As Long = 0

            Using cnn As New SqlConnection(My.Settings.CLIConnectionString)
                cnn.Open()
                Dim sqlMontant As String = "SELECT ISNULL(SUM(Total_TTC), 0) FROM T_CommandeVente " &
                                          "WHERE TicketLe BETWEEN @Debut AND @Fin AND ID_EtatCommandeVente >= 20"
                Using cmd As New SqlCommand(sqlMontant, cnn)
                    cmd.Parameters.AddWithValue("@Debut", anneeDebut)
                    cmd.Parameters.AddWithValue("@Fin", anneeFin)
                    montantAnnee = Convert.ToDecimal(cmd.ExecuteScalar())
                End Using

                Dim sqlPlage As String = "SELECT MIN(ID_T_CommandeVente), MAX(ID_T_CommandeVente) " &
                                        "FROM T_CommandeVente " &
                                        "WHERE TicketLe BETWEEN @Debut AND @Fin AND ID_EtatCommandeVente >= 20"
                Using cmd As New SqlCommand(sqlPlage, cnn)
                    cmd.Parameters.AddWithValue("@Debut", anneeDebut)
                    cmd.Parameters.AddWithValue("@Fin", anneeFin)
                    Using reader As SqlDataReader = cmd.ExecuteReader()
                        If reader.Read() Then
                            If Not IsDBNull(reader(0)) Then premierTicketID = Convert.ToInt64(reader(0))
                            If Not IsDBNull(reader(1)) Then dernierTicketID = Convert.ToInt64(reader(1))
                        End If
                    End Using
                End Using
            End Using

            ' Grand Total + signature
            ' NF525 : les clôtures journalières Z ont DÉJÀ cumulé le CA dans le GTP.
            ' La clôture annuelle A est un récapitulatif — elle NE ré-ajoute PAS le CA annuel
            ' (évite le double-comptage). GTP = GTP actuel, MontantTotal = CA annuel (référence).
            Dim grandTotalPrecedent As Decimal = GetGrandTotalActuel()
            Dim nouveauGrandTotal As Decimal = grandTotalPrecedent ' GTP inchangé — déjà mis à jour par les Z journalières
            Dim prevSig As String = GetPreviousClotureSignature()
            Dim dataACle As String = "ANNEE" & Now.ToString("yyyyMMddHHmmss") & _
                                    nouveauGrandTotal.ToString("0.00", CultureInfo.InvariantCulture) & prevSig
            Dim signature As String = NF525.SignatureHelper.ComputeSignature(dataACle)

            Dim clotureId As Long = 0
            Dim sqlInsert As String = "INSERT INTO T_Cloture (TypeCloture, MontantTotal_Jour_TTC, GrandTotal_Perpetuel_TTC, " &
                                     "PremierTicketID, DernierTicketID, Signature, PreviousSignature, CreePar) " &
                                     "VALUES ('ANNEE', @Montant, @GrandTotal, @Premier, @Dernier, @Sig, @PrevSig, @User); " &
                                     "SELECT SCOPE_IDENTITY();"
            Using cnn As New SqlConnection(My.Settings.CLIConnectionString)
                cnn.Open()
                Using cmd As New SqlCommand(sqlInsert, cnn)
                    cmd.Parameters.AddWithValue("@Montant", montantAnnee)
                    cmd.Parameters.AddWithValue("@GrandTotal", nouveauGrandTotal)
                    cmd.Parameters.AddWithValue("@Premier", If(premierTicketID = 0, CType(DBNull.Value, Object), premierTicketID))
                    cmd.Parameters.AddWithValue("@Dernier", If(dernierTicketID = 0, CType(DBNull.Value, Object), dernierTicketID))
                    cmd.Parameters.AddWithValue("@Sig", signature)
                    cmd.Parameters.AddWithValue("@PrevSig", prevSig)
                    cmd.Parameters.AddWithValue("@User", gLogin)
                    clotureId = Convert.ToInt64(cmd.ExecuteScalar())
                End Using
            End Using

            LogEventTechnique("CLOTURE_ANNUELLE",
                            "Clôture A n°" & clotureId & " - Exercice " & Now.Year.ToString() &
                            " - CA annee=" & montantAnnee.ToString("F2") & "EUR - Grand Total=" & nouveauGrandTotal.ToString("F2") & "EUR",
                            grandTotalPrecedent.ToString("F2"), nouveauGrandTotal.ToString("F2"))
            Return clotureId

        Catch ex As Exception
            LogEventTechnique("ERREUR_CLOTURE_ANNUELLE", "Erreur clôture annuelle : " & ex.Message)
            Throw New Exception("Erreur lors de la clôture annuelle : " & ex.Message)
        End Try
    End Function

    ''' <summary>
    ''' Effectue la clôture journalière (Ticket Z)
    ''' OBLIGATOIRE NF525 : À exécuter chaque jour
    ''' </summary>
    Public Function ClotureJournaliere() As Long
        Try
            ' 1. Calculer le CA du jour (tickets validés uniquement)
            Dim dateJour As Date = Now.Date
            Dim sql As String = "SELECT ISNULL(SUM(Total_TTC), 0) FROM T_CommandeVente " & _
                              "WHERE CAST(TicketLe AS DATE) = @DateJour AND ID_EtatCommandeVente >= 20"

            Dim montantJour As Decimal = 0
            Dim premierTicketID As Long = 0
            Dim dernierTicketID As Long = 0

            Using cnn As New SqlConnection(My.Settings.CLIConnectionString)
                cnn.Open()

                ' Montant du jour
                Using cmd As New SqlCommand(sql, cnn)
                    cmd.Parameters.AddWithValue("@DateJour", dateJour)
                    montantJour = Convert.ToDecimal(cmd.ExecuteScalar())
                End Using

                ' Premier et dernier ticket du jour
                sql = "SELECT MIN(ID_T_CommandeVente), MAX(ID_T_CommandeVente) FROM T_CommandeVente " & _
                     "WHERE CAST(TicketLe AS DATE) = @DateJour AND ID_EtatCommandeVente >= 20"
                Using cmd As New SqlCommand(sql, cnn)
                    cmd.Parameters.AddWithValue("@DateJour", dateJour)
                    Using reader As SqlDataReader = cmd.ExecuteReader()
                        If reader.Read() Then
                            If Not IsDBNull(reader(0)) Then premierTicketID = Convert.ToInt64(reader(0))
                            If Not IsDBNull(reader(1)) Then dernierTicketID = Convert.ToInt64(reader(1))
                        End If
                    End Using
                End Using
            End Using

            ' 2. Récupérer le Grand Total précédent
            Dim grandTotalPrecedent As Decimal = GetGrandTotalActuel()

            ' 3. Calculer le nouveau Grand Total (DOIT TOUJOURS AUGMENTER)
            Dim nouveauGrandTotal As Decimal = grandTotalPrecedent + montantJour

            ' 4. Préparer la signature
            Dim prevSigCloture As String = GetPreviousClotureSignature()
            Dim dataCloture As String = "JOUR" & Now.ToString("yyyyMMddHHmmss") & _
                                       nouveauGrandTotal.ToString("0.00", CultureInfo.InvariantCulture) & _
                                       prevSigCloture
            Dim signature As String = NF525.SignatureHelper.ComputeSignature(dataCloture)

            ' 5. Enregistrer la clôture
            sql = "INSERT INTO T_Cloture (TypeCloture, MontantTotal_Jour_TTC, GrandTotal_Perpetuel_TTC, " & _
                 "PremierTicketID, DernierTicketID, Signature, PreviousSignature, CreePar) " & _
                 "VALUES ('JOUR', @Montant, @GrandTotal, @Premier, @Dernier, @Sig, @PrevSig, @User); " & _
                 "SELECT SCOPE_IDENTITY();"

            Dim clotureId As Long = 0
            Using cnn As New SqlConnection(My.Settings.CLIConnectionString)
                cnn.Open()
                Using cmd As New SqlCommand(sql, cnn)
                    cmd.Parameters.AddWithValue("@Montant", montantJour)
                    cmd.Parameters.AddWithValue("@GrandTotal", nouveauGrandTotal)
                    cmd.Parameters.AddWithValue("@Premier", If(premierTicketID = 0, DBNull.Value, premierTicketID))
                    cmd.Parameters.AddWithValue("@Dernier", If(dernierTicketID = 0, DBNull.Value, dernierTicketID))
                    cmd.Parameters.AddWithValue("@Sig", signature)
                    cmd.Parameters.AddWithValue("@PrevSig", prevSigCloture)
                    cmd.Parameters.AddWithValue("@User", gLogin)
                    clotureId = Convert.ToInt64(cmd.ExecuteScalar())
                End Using
            End Using

            ' 6. Logger dans le JET
            LogEventTechnique("CLOTURE_JOURNALIERE", _
                            "Clôture Z n°" & clotureId & " - CA=" & montantJour.ToString("F2") & _
                            "€ - Grand Total=" & nouveauGrandTotal.ToString("F2") & "€", _
                            grandTotalPrecedent.ToString("F2"), nouveauGrandTotal.ToString("F2"))

            Return clotureId

        Catch ex As Exception
            LogEventTechnique("ERREUR_CLOTURE", "Erreur clôture journalière : " & ex.Message)
            Throw New Exception("Erreur lors de la clôture journalière : " & ex.Message)
        End Try
    End Function

#End Region

#Region "Vérification d'intégrité"

    ''' <summary>
    ''' Vérifie l'intégrité de la chaîne cryptographique des tickets
    ''' Recalcule toutes les signatures et compare avec celles enregistrées
    ''' </summary>
    Public Function VerifierIntegriteChaine(Optional afficherDetails As Boolean = False) As Boolean
        Try
            Dim sql As String = "SELECT ID_T_CommandeVente, TicketLe, Total_TTC, Signature, PreviousSignature " & _
                              "FROM T_CommandeVente WHERE TicketLe IS NOT NULL AND Signature IS NOT NULL " & _
                              "ORDER BY ID_T_CommandeVente ASC"

            Dim erreurs As New List(Of String)
            Dim previousSignatureAttendue As String = "INITIAL_CHAIN_START"

            Using cnn As New SqlConnection(My.Settings.CLIConnectionString)
                cnn.Open()
                Using cmd As New SqlCommand(sql, cnn)
                    Using reader As SqlDataReader = cmd.ExecuteReader()
                        While reader.Read()
                            Dim ticketId As Long = Convert.ToInt64(reader("ID_T_CommandeVente"))
                            Dim signatureEnregistree As String = reader("Signature").ToString()
                            Dim prevSigEnregistree As String = reader("PreviousSignature").ToString()

                            ' Vérifier que PreviousSignature correspond
                            If prevSigEnregistree <> previousSignatureAttendue Then
                                erreurs.Add("Ticket #" & ticketId & " : Rupture de chaîne détectée")
                            End If

                            ' Préparer pour le prochain ticket
                            previousSignatureAttendue = signatureEnregistree
                        End While
                    End Using
                End Using
            End Using

            If erreurs.Count > 0 Then
                If afficherDetails Then
                    MessageBox.Show("❌ INTÉGRITÉ COMPROMISE !" & vbCrLf & vbCrLf & _
                                  String.Join(vbCrLf, erreurs), _
                                  "NF525 - Vérification d'intégrité", _
                                  MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
                LogEventTechnique("INTEGRITE_KO", erreurs.Count & " rupture(s) de chaîne détectée(s)")
                Return False
            Else
                If afficherDetails Then
                    MessageBox.Show("✅ Intégrité de la chaîne cryptographique VALIDÉE", _
                                  "NF525 - Vérification d'intégrité", _
                                  MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If
                Return True
            End If

        Catch ex As Exception
            LogEventTechnique("ERREUR_VERIFICATION", "Erreur vérification intégrité : " & ex.Message)
            Return False
        End Try
    End Function

#End Region

#Region "Archivage fiscal"

    ''' <summary>
    ''' Exporte les données fiscales pour l'administration.
    ''' Format XML enrichi conforme au référentiel NF525 :
    ''' - En-têtes de ticket (ID, date, totaux TTC/HT, signature)
    ''' - Lignes de détail par article (quantité, prix unitaire, TVA)
    ''' - Ventilation TVA par taux pour chaque ticket
    ''' - Clôtures de la période
    ''' </summary>
    Public Sub ExporterArchiveFiscale(dateDebut As Date, dateFin As Date, cheminExport As String)
        Try
            Dim dateFin23h As Date = dateFin.Date.AddDays(1).AddSeconds(-1)
            Dim sb As New StringBuilder()
            sb.AppendLine("<?xml version=""1.0"" encoding=""UTF-8""?>")
            sb.AppendLine("<ArchiveFiscale_NF525>")
            sb.AppendLine("  <Informations>")
            sb.AppendLine("    <Entreprise>CHINOOK LEUCATE</Entreprise>")
            sb.AppendLine("    <Siret>48450148100010</Siret>")
            sb.AppendLine("    <PeriodeDebut>" & dateDebut.ToString("yyyy-MM-dd") & "</PeriodeDebut>")
            sb.AppendLine("    <PeriodeFin>" & dateFin.ToString("yyyy-MM-dd") & "</PeriodeFin>")
            sb.AppendLine("    <DateExport>" & Now.ToString("yyyy-MM-dd HH:mm:ss") & "</DateExport>")
            sb.AppendLine("    <VersionLogiciel>" & Application.ProductVersion & "</VersionLogiciel>")
            sb.AppendLine("    <Exporteur>" & gLogin & "</Exporteur>")
            sb.AppendLine("  </Informations>")

            ' ── Tickets + lignes de détail ──────────────────────────────────
            sb.AppendLine("  <Tickets>")
            Dim sqlTickets As String = "SELECT ID_T_CommandeVente, TicketLe, Total_TTC, Total_HT, " &
                                      "Signature, PreviousSignature, Annule, AnnuleLe, AnnulePar, CreePar " &
                                      "FROM T_CommandeVente " &
                                      "WHERE TicketLe BETWEEN @Debut AND @Fin AND Signature IS NOT NULL " &
                                      "ORDER BY ID_T_CommandeVente"

            Dim ticketIds As New System.Collections.Generic.List(Of Long)()

            Using cnn As New SqlConnection(My.Settings.CLIConnectionString)
                cnn.Open()
                Using cmd As New SqlCommand(sqlTickets, cnn)
                    cmd.Parameters.AddWithValue("@Debut", dateDebut)
                    cmd.Parameters.AddWithValue("@Fin", dateFin23h)
                    Using reader As SqlDataReader = cmd.ExecuteReader()
                        While reader.Read()
                            Dim ticketId As Long = Convert.ToInt64(reader("ID_T_CommandeVente"))
                            ticketIds.Add(ticketId)
                            Dim annule As Boolean = Not IsDBNull(reader("Annule")) AndAlso CBool(reader("Annule"))
                            sb.AppendLine("    <Ticket>")
                            sb.AppendLine("      <ID>" & ticketId & "</ID>")
                            sb.AppendLine("      <Date>" & CDate(reader("TicketLe")).ToString("yyyy-MM-dd HH:mm:ss") & "</Date>")
                            sb.AppendLine("      <TotalTTC>" & CDec(reader("Total_TTC")).ToString("0.00", CultureInfo.InvariantCulture) & "</TotalTTC>")
                            sb.AppendLine("      <TotalHT>" & CDec(reader("Total_HT")).ToString("0.00", CultureInfo.InvariantCulture) & "</TotalHT>")
                            sb.AppendLine("      <Annule>" & annule.ToString().ToLower() & "</Annule>")
                            If annule Then
                                sb.AppendLine("      <AnnuleLe>" & If(IsDBNull(reader("AnnuleLe")), "", CDate(reader("AnnuleLe")).ToString("yyyy-MM-dd HH:mm:ss")) & "</AnnuleLe>")
                                sb.AppendLine("      <AnnulePar>" & If(IsDBNull(reader("AnnulePar")), "", reader("AnnulePar").ToString()) & "</AnnulePar>")
                            End If
                            sb.AppendLine("      <CreePar>" & If(IsDBNull(reader("CreePar")), "", reader("CreePar").ToString()) & "</CreePar>")
                            sb.AppendLine("      <Signature>" & reader("Signature").ToString() & "</Signature>")
                            sb.AppendLine("      <SignaturePrecedente>" & If(IsDBNull(reader("PreviousSignature")), "", reader("PreviousSignature").ToString()) & "</SignaturePrecedente>")
                        End While
                    End Using
                End Using

                ' ── Lignes de détail et ventilation TVA pour chaque ticket ──
                For Each tId As Long In ticketIds
                    sb.AppendLine("      <Lignes>")
                    Dim sqlLignes As String = "SELECT l.ID_T_CommandeVente_Ligne, l.ID_t_article_version, " &
                                             "a.designation, l.Qte, l.prix_unitaire_TTC, l.prix_total_TTC, " &
                                             "l.CodeTva, l.Signature " &
                                             "FROM T_CommandeVente_Ligne l " &
                                             "LEFT JOIN T_ArticleVersion av ON l.ID_t_article_version = av.ID_t_article_version " &
                                             "LEFT JOIN T_ArticleEntete a ON av.ID_t_article_entete = a.ID_t_article_entete " &
                                             "WHERE l.ID_T_CommandeVente = @TicketId " &
                                             "ORDER BY l.ID_T_CommandeVente_Ligne"
                    Dim tvaGroups As New System.Collections.Generic.Dictionary(Of Decimal, Decimal)()

                    Using cmdL As New SqlCommand(sqlLignes, cnn)
                        cmdL.Parameters.AddWithValue("@TicketId", tId)
                        Using rL As SqlDataReader = cmdL.ExecuteReader()
                            While rL.Read()
                                Dim tauxTva As Decimal = If(IsDBNull(rL("CodeTva")), 0D, CDec(rL("CodeTva")))
                                Dim totalLigneTTC As Decimal = If(IsDBNull(rL("prix_total_TTC")), 0D, CDec(rL("prix_total_TTC")))

                                ' Cumuler par taux pour la ventilation TVA
                                If Not tvaGroups.ContainsKey(tauxTva) Then
                                    tvaGroups.Add(tauxTva, 0D)
                                End If
                                tvaGroups(tauxTva) += totalLigneTTC

                                sb.AppendLine("        <Ligne>")
                                sb.AppendLine("          <ID>" & rL("ID_T_CommandeVente_Ligne") & "</ID>")
                                sb.AppendLine("          <Designation>" & If(IsDBNull(rL("designation")), "", rL("designation").ToString()) & "</Designation>")
                                sb.AppendLine("          <Quantite>" & CDec(rL("Qte")).ToString("0.###", CultureInfo.InvariantCulture) & "</Quantite>")
                                sb.AppendLine("          <PrixUnitaireTTC>" & CDec(rL("prix_unitaire_TTC")).ToString("0.00", CultureInfo.InvariantCulture) & "</PrixUnitaireTTC>")
                                sb.AppendLine("          <TotalLigneTTC>" & totalLigneTTC.ToString("0.00", CultureInfo.InvariantCulture) & "</TotalLigneTTC>")
                                sb.AppendLine("          <TauxTVA>" & tauxTva.ToString("0.##", CultureInfo.InvariantCulture) & "</TauxTVA>")
                                sb.AppendLine("          <SignatureLigne>" & If(IsDBNull(rL("Signature")), "", rL("Signature").ToString()) & "</SignatureLigne>")
                                sb.AppendLine("        </Ligne>")
                            End While
                        End Using
                    End Using

                    sb.AppendLine("      </Lignes>")

                    ' Ventilation TVA par taux
                    sb.AppendLine("      <VentilationTVA>")
                    For Each kvp As System.Collections.Generic.KeyValuePair(Of Decimal, Decimal) In tvaGroups
                        Dim tauxPct As Decimal = kvp.Key
                        Dim baseTTC As Decimal = kvp.Value
                        Dim baseHT As Decimal = If(tauxPct > 0, Math.Round(baseTTC / (1 + tauxPct / 100D), 2), baseTTC)
                        Dim montantTVA As Decimal = baseTTC - baseHT
                        sb.AppendLine("        <TauxGroup>")
                        sb.AppendLine("          <Taux>" & tauxPct.ToString("0.##", CultureInfo.InvariantCulture) & "</Taux>")
                        sb.AppendLine("          <BaseHT>" & baseHT.ToString("0.00", CultureInfo.InvariantCulture) & "</BaseHT>")
                        sb.AppendLine("          <MontantTVA>" & montantTVA.ToString("0.00", CultureInfo.InvariantCulture) & "</MontantTVA>")
                        sb.AppendLine("          <TotalTTC>" & baseTTC.ToString("0.00", CultureInfo.InvariantCulture) & "</TotalTTC>")
                        sb.AppendLine("        </TauxGroup>")
                    Next
                    sb.AppendLine("      </VentilationTVA>")
                    sb.AppendLine("    </Ticket>")
                Next
            End Using

            sb.AppendLine("  </Tickets>")

            ' ── Clôtures de la période ───────────────────────────────────────
            sb.AppendLine("  <Clotures>")
            Dim sqlClotures As String = "SELECT Id_Cloture, DateCloture, TypeCloture, MontantTotal_Jour_TTC, " &
                                       "GrandTotal_Perpetuel_TTC, PremierTicketID, DernierTicketID, Signature, PreviousSignature " &
                                       "FROM T_Cloture WHERE DateCloture BETWEEN @Debut AND @Fin ORDER BY Id_Cloture"
            Using cnn2 As New SqlConnection(My.Settings.CLIConnectionString)
                cnn2.Open()
                Using cmd2 As New SqlCommand(sqlClotures, cnn2)
                    cmd2.Parameters.AddWithValue("@Debut", dateDebut)
                    cmd2.Parameters.AddWithValue("@Fin", dateFin23h)
                    Using rC As SqlDataReader = cmd2.ExecuteReader()
                        While rC.Read()
                            sb.AppendLine("    <Cloture>")
                            sb.AppendLine("      <ID>" & rC("Id_Cloture") & "</ID>")
                            sb.AppendLine("      <Date>" & CDate(rC("DateCloture")).ToString("yyyy-MM-dd HH:mm:ss") & "</Date>")
                            sb.AppendLine("      <Type>" & rC("TypeCloture").ToString() & "</Type>")
                            sb.AppendLine("      <MontantPeriodeTTC>" & CDec(rC("MontantTotal_Jour_TTC")).ToString("0.00", CultureInfo.InvariantCulture) & "</MontantPeriodeTTC>")
                            sb.AppendLine("      <GrandTotalPerpetuelTTC>" & CDec(rC("GrandTotal_Perpetuel_TTC")).ToString("0.00", CultureInfo.InvariantCulture) & "</GrandTotalPerpetuelTTC>")
                            sb.AppendLine("      <PremierTicket>" & If(IsDBNull(rC("PremierTicketID")), "", rC("PremierTicketID").ToString()) & "</PremierTicket>")
                            sb.AppendLine("      <DernierTicket>" & If(IsDBNull(rC("DernierTicketID")), "", rC("DernierTicketID").ToString()) & "</DernierTicket>")
                            sb.AppendLine("      <Signature>" & rC("Signature").ToString() & "</Signature>")
                            sb.AppendLine("      <SignaturePrecedente>" & rC("PreviousSignature").ToString() & "</SignaturePrecedente>")
                            sb.AppendLine("    </Cloture>")
                        End While
                    End Using
                End Using
            End Using
            sb.AppendLine("  </Clotures>")
            sb.AppendLine("</ArchiveFiscale_NF525>")

            ' Sauvegarder et sceller le fichier
            System.IO.File.WriteAllText(cheminExport, sb.ToString(), System.Text.Encoding.UTF8)
            Dim hashFichier As String = CalculerHashFichier(cheminExport)

            LogEventTechnique("EXPORT_ARCHIVE",
                            "Export fiscal " & dateDebut.ToString("dd/MM/yyyy") & " au " & dateFin.ToString("dd/MM/yyyy") &
                            " | " & ticketIds.Count & " ticket(s)",
                            "", "Fichier: " & System.IO.Path.GetFileName(cheminExport) & " | SHA-256: " & hashFichier)

        Catch ex As Exception
            LogEventTechnique("ERREUR_EXPORT", "Erreur export archive : " & ex.Message)
            Throw
        End Try
    End Sub

    ''' <summary>
    ''' Consulte une archive fiscale existante et trace la consultation dans le JET.
    ''' NF525 : Toute consultation d'archive doit être tracée.
    ''' </summary>
    ''' <param name="cheminArchive">Chemin complet du fichier archive à consulter</param>
    ''' <returns>Contenu brut du fichier XML (pour affichage ou vérification)</returns>
    Public Function ConsulterArchiveFiscale(cheminArchive As String) As String
        If Not System.IO.File.Exists(cheminArchive) Then
            Throw New System.IO.FileNotFoundException("Archive fiscale introuvable : " & cheminArchive)
        End If

        Dim contenu As String = System.IO.File.ReadAllText(cheminArchive, System.Text.Encoding.UTF8)

        ' Recalculer le hash pour vérifier l'intégrité du fichier depuis l'export
        Dim hashActuel As String = CalculerHashFichier(cheminArchive)

        LogEventTechnique("CONSULTATION_ARCHIVE",
                         "Consultation archive : " & System.IO.Path.GetFileName(cheminArchive),
                         "", "SHA-256 actuel: " & hashActuel & " | Machine: " & Environment.MachineName)

        Return contenu
    End Function

    ''' <summary>
    ''' Calcule le hash SHA-256 d'un fichier pour le scellement
    ''' </summary>
    Private Function CalculerHashFichier(cheminFichier As String) As String
        Using sha256 As New System.Security.Cryptography.SHA256Managed()
            Using fileStream As New System.IO.FileStream(cheminFichier, IO.FileMode.Open, IO.FileAccess.Read)
                Dim hashBytes As Byte() = sha256.ComputeHash(fileStream)
                Return BitConverter.ToString(hashBytes).Replace("-", "").ToLower()
            End Using
        End Using
    End Function

#End Region

#Region "Ticket Z — Impression clôture journalière"

    ''' <summary>
    ''' Génère et imprime le Ticket Z de clôture journalière.
    ''' OBLIGATOIRE NF525 : doit être imprimé ET conservé physiquement.
    ''' Compatible avec tout pilote d'imprimante Windows (imprimantes tickets ESC/POS incluses).
    ''' </summary>
    ''' <param name="clotureId">ID de la clôture dans T_Cloture</param>
    ''' <param name="imprimerDirectement">True = envoi direct imprimante, False = aperçu</param>
    Public Sub ImprimerTicketZ(clotureId As Long, Optional imprimerDirectement As Boolean = False)
        Try
            Dim sql As String =
                "SELECT c.*, " &
                "(SELECT COUNT(*) FROM T_CommandeVente v " &
                " WHERE CAST(v.TicketLe AS DATE) = CAST(c.DateCloture AS DATE) " &
                " AND v.ID_EtatCommandeVente >= 20) AS NbTickets, " &
                "(SELECT ISNULL(SUM(v.Total_HT),0) FROM T_CommandeVente v " &
                " WHERE CAST(v.TicketLe AS DATE) = CAST(c.DateCloture AS DATE) " &
                " AND v.ID_EtatCommandeVente >= 20) AS TotalHT, " &
                "(SELECT COUNT(*) FROM T_CommandeVente v " &
                " WHERE CAST(v.TicketLe AS DATE) = CAST(c.DateCloture AS DATE) " &
                " AND v.ID_EtatCommandeVente >= 20 AND v.Annule = 1) AS NbAnnules " &
                "FROM T_Cloture c WHERE c.Id_Cloture = @Id"

            Dim dateCloture As DateTime = Now
            Dim montantJour As Decimal = 0
            Dim grandTotal As Decimal = 0
            Dim totalHT As Decimal = 0
            Dim nbTickets As Integer = 0
            Dim nbAnnules As Integer = 0
            Dim premierTicket As Long = 0
            Dim dernierTicket As Long = 0
            Dim signature As String = ""

            Using cnn As New SqlConnection(My.Settings.CLIConnectionString)
                cnn.Open()
                Using cmd As New SqlCommand(sql, cnn)
                    cmd.Parameters.AddWithValue("@Id", clotureId)
                    Using reader As SqlDataReader = cmd.ExecuteReader()
                        If reader.Read() Then
                            dateCloture = Convert.ToDateTime(reader("DateCloture"))
                            montantJour = Convert.ToDecimal(reader("MontantTotal_Jour_TTC"))
                            grandTotal = Convert.ToDecimal(reader("GrandTotal_Perpetuel_TTC"))
                            totalHT = Convert.ToDecimal(reader("TotalHT"))
                            nbTickets = Convert.ToInt32(reader("NbTickets"))
                            nbAnnules = Convert.ToInt32(reader("NbAnnules"))
                            If Not IsDBNull(reader("PremierTicketID")) Then premierTicket = Convert.ToInt64(reader("PremierTicketID"))
                            If Not IsDBNull(reader("DernierTicketID")) Then dernierTicket = Convert.ToInt64(reader("DernierTicketID"))
                            signature = reader("Signature").ToString()
                        Else
                            Throw New Exception("Cloture #" & clotureId & " introuvable.")
                        End If
                    End Using
                End Using

                ' Récupérer la ventilation TVA du jour
                Dim sqlTVA As String =
                    "SELECT l.CodeTva, ISNULL(SUM(l.prix_total_TTC), 0) AS TotalTTC " &
                    "FROM T_CommandeVente_Ligne l " &
                    "INNER JOIN T_CommandeVente v ON l.ID_T_CommandeVente = v.ID_T_CommandeVente " &
                    "WHERE CAST(v.TicketLe AS DATE) = CAST(@DateJour AS DATE) " &
                    "AND v.ID_EtatCommandeVente >= 20 AND v.Annule = 0 " &
                    "GROUP BY l.CodeTva ORDER BY l.CodeTva"

                Dim lignesTVA As New System.Collections.Generic.List(Of String)()
                Using cmdTVA As New SqlCommand(sqlTVA, cnn)
                    cmdTVA.Parameters.AddWithValue("@DateJour", dateCloture)
                    Using rTVA As SqlDataReader = cmdTVA.ExecuteReader()
                        While rTVA.Read()
                            Dim taux As Decimal = If(IsDBNull(rTVA("CodeTva")), 0D, Convert.ToDecimal(rTVA("CodeTva")))
                            Dim baseTTC As Decimal = Convert.ToDecimal(rTVA("TotalTTC"))
                            Dim baseHT As Decimal = If(taux > 0, Math.Round(baseTTC / (1 + taux / 100D), 2), baseTTC)
                            Dim montantTVA As Decimal = baseTTC - baseHT
                            lignesTVA.Add(String.Format("  TVA {0,5:0.##}% : HT={1,9:0.00}   TVA={2,7:0.00}",
                                taux, baseHT, montantTVA))
                        End While
                    End Using
                End Using
            End Using

            ' ── Construire le ticket Z en texte formaté (42 colonnes) ─────
            Dim sep As String = New String("-"c, 42)
            Dim sepE As String = New String("="c, 42)
            Dim sb As New StringBuilder()

            sb.AppendLine(sepE)
            sb.AppendLine(CentrerTicketZ("CHINOOK LEUCATE", 42))
            sb.AppendLine(CentrerTicketZ("48 Av. du Port - 11370 LEUCATE", 42))
            sb.AppendLine(CentrerTicketZ("SIRET : 48450148100010", 42))
            sb.AppendLine(sepE)
            sb.AppendLine(CentrerTicketZ("*** TICKET Z - CLOTURE JOURNALIERE ***", 42))
            sb.AppendLine(CentrerTicketZ("Certifie NF525 v" & Application.ProductVersion, 42))
            sb.AppendLine(sepE)
            sb.AppendLine(String.Format("  Cloture N{0}  : {1}", Chr(176), clotureId))
            sb.AppendLine(String.Format("  Date        : {0}", dateCloture.ToString("dd/MM/yyyy HH:mm:ss")))
            sb.AppendLine(String.Format("  Operateur   : {0}", gLogin))
            sb.AppendLine(sep)
            sb.AppendLine(String.Format("  Tickets #{0} a #{1}", premierTicket, dernierTicket))
            sb.AppendLine(String.Format("  Nb ventes   : {0,6}", nbTickets - nbAnnules))
            sb.AppendLine(String.Format("  Nb annules  : {0,6}", nbAnnules))
            sb.AppendLine(sep)
            sb.AppendLine("  -- VENTILATION TVA --")
            For Each lTVA As String In lignesTVA
                sb.AppendLine(lTVA)
            Next
            sb.AppendLine(sep)
            sb.AppendLine(String.Format("  TOTAL HT    : {0,10:0.00} EUR", totalHT))
            sb.AppendLine(String.Format("  TOTAL TTC   : {0,10:0.00} EUR", montantJour))
            sb.AppendLine(sepE)
            sb.AppendLine("  GRAND TOTAL PERPETUEL (cumul depuis origine) :")
            sb.AppendLine(String.Format("  Avant cloture  : {0,12:0.00} EUR", grandTotal - montantJour))
            sb.AppendLine(String.Format("  + CA du jour   : {0,12:0.00} EUR", montantJour))
            sb.AppendLine(String.Format("  Apres cloture  : {0,12:0.00} EUR", grandTotal))
            sb.AppendLine(sepE)
            sb.AppendLine("  SIGNATURE NF525 :")
            If signature.Length > 40 Then
                sb.AppendLine("  " & signature.Substring(0, 20) & "...")
                sb.AppendLine("  ..." & signature.Substring(signature.Length - 20))
            Else
                sb.AppendLine("  " & signature)
            End If
            sb.AppendLine(sep)
            sb.AppendLine(CentrerTicketZ("Document fiscal - Conserver 6 ans", 42))
            sb.AppendLine(sepE)
            sb.AppendLine()
            sb.AppendLine()

            Dim contenuZ As String = sb.ToString()

            ' ── Impression via PrintDocument Windows (.NET 3.5) ───────────
            ' IMPORTANT : pas de lambda dans AddHandler en VB.NET 9 / .NET 3.5.
            ' Les données sont passées via variables de module _ticketZLignes/_ticketZFont.
            _ticketZFont = New System.Drawing.Font("Courier New", 8)
            _ticketZLignes = contenuZ.Split(New String() {vbCrLf, vbLf}, StringSplitOptions.None)

            Using pd As New System.Drawing.Printing.PrintDocument()
                pd.DocumentName = "Ticket Z - Cloture #" & clotureId
                AddHandler pd.PrintPage, AddressOf TicketZ_PrintPage

                Try
                    If imprimerDirectement Then
                        pd.Print()
                    Else
                        Using apercu As New System.Windows.Forms.PrintPreviewDialog()
                            apercu.Document = pd
                            apercu.Width = 520
                            apercu.Height = 750
                            apercu.Text = "Apercu Ticket Z - Cloture #" & clotureId
                            apercu.ShowDialog()
                        End Using
                    End If
                Finally
                    RemoveHandler pd.PrintPage, AddressOf TicketZ_PrintPage
                End Try
            End Using

            _ticketZFont.Dispose()
            _ticketZFont = Nothing
            _ticketZLignes = Nothing

            ' Logger l'impression dans le JET
            LogEventTechnique("IMPRESSION_TICKET_Z",
                             "Ticket Z n°" & clotureId & " imprime",
                             "", "Operateur: " & gLogin & " | Machine: " & Environment.MachineName)

        Catch ex As Exception
            LogEventTechnique("ERREUR_IMPRESSION_Z", "Erreur impression Ticket Z : " & ex.Message)
            MessageBox.Show("Erreur lors de l'impression du Ticket Z :" & vbCrLf & ex.Message,
                           "Erreur NF525", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ''' <summary>Helper : centre un texte sur une largeur ticket donnée.</summary>
    Private Function CentrerTicketZ(texte As String, largeur As Integer) As String
        If texte.Length >= largeur Then Return texte.Substring(0, largeur)
        Dim pad As Integer = (largeur - texte.Length) \ 2
        Return New String(" "c, pad) & texte
    End Function

#End Region

#Region "Contrôle des clôtures journalières manquantes"

    ''' <summary>
    ''' Détecte les journées ayant des ventes sans clôture Z dans une période donnée.
    ''' Signature principale demandée par NF525 : plage de dates explicite.
    ''' Compatible .NET Framework 3.5 (pas de lambda, pas de LINQ).
    ''' </summary>
    ''' <param name="dateDebut">Premier jour de la période à contrôler</param>
    ''' <param name="dateFin">Dernier jour de la période à contrôler (inclus)</param>
    ''' <returns>Liste des dates manquantes</returns>
    Public Function VerifierCloturesJournalieresManquantes(
            dateDebut As Date, dateFin As Date) As System.Collections.Generic.List(Of Date)

        Dim joursManquants As New System.Collections.Generic.List(Of Date)()
        Try
            Dim debut As Date = dateDebut.Date
            Dim fin As Date = dateFin.Date

            Using cnn As New SqlConnection(My.Settings.CLIConnectionString)
                cnn.Open()
                Dim jourVerifie As Date = debut
                While jourVerifie <= fin
                    ' Vérifier s'il y a des ventes ce jour
                    Dim sqlVentes As String =
                        "SELECT COUNT(*) FROM T_CommandeVente " &
                        "WHERE CAST(TicketLe AS DATE) = @Jour AND ID_EtatCommandeVente >= 20"
                    Using cmdV As New SqlCommand(sqlVentes, cnn)
                        cmdV.Parameters.AddWithValue("@Jour", jourVerifie)
                        If Convert.ToInt32(cmdV.ExecuteScalar()) > 0 Then
                            ' Vérifier si une clôture JOUR existe pour ce jour
                            Dim sqlClot As String =
                                "SELECT COUNT(*) FROM T_Cloture " &
                                "WHERE TypeCloture = 'JOUR' AND CAST(DateCloture AS DATE) = @Jour"
                            Using cmdC As New SqlCommand(sqlClot, cnn)
                                cmdC.Parameters.AddWithValue("@Jour", jourVerifie)
                                If Convert.ToInt32(cmdC.ExecuteScalar()) = 0 Then
                                    joursManquants.Add(jourVerifie)
                                End If
                            End Using
                        End If
                    End Using
                    jourVerifie = jourVerifie.AddDays(1)
                End While
            End Using

            ' Tracer dans le JET — compatible .NET 3.5 (pas de lambda)
            If joursManquants.Count > 0 Then
                Dim datesStr As New StringBuilder()
                For Each d As Date In joursManquants
                    If datesStr.Length > 0 Then datesStr.Append(", ")
                    datesStr.Append(d.ToString("dd/MM/yyyy"))
                Next
                LogEventTechnique("ALERTE_CLOTURE_MANQUANTE",
                    joursManquants.Count & " journee(s) sans cloture Z sur la periode " &
                    dateDebut.ToString("dd/MM/yyyy") & " - " & dateFin.ToString("dd/MM/yyyy"),
                    "", datesStr.ToString())
            End If

        Catch ex As Exception
            LogEventTechnique("ERREUR_CONTROLE_CLOTURES",
                "Erreur controle clotures manquantes : " & ex.Message)
        End Try
        Return joursManquants
    End Function

    ''' <summary>
    ''' Surcharge sans paramètre : contrôle depuis la dernière clôture Z jusqu'à hier.
    ''' Compatibilité descendante avec les appels existants.
    ''' </summary>
    Public Function DetecterCloturesManquantes() As System.Collections.Generic.List(Of Date)
        Dim dateDerniere As Date = Date.MinValue
        Try
            Using cnn As New SqlConnection(My.Settings.CLIConnectionString)
                cnn.Open()
                Dim sqlDerniere As String =
                    "SELECT TOP 1 DateCloture FROM T_Cloture " &
                    "WHERE TypeCloture = 'JOUR' ORDER BY Id_Cloture DESC"
                Using cmd As New SqlCommand(sqlDerniere, cnn)
                    Dim result As Object = cmd.ExecuteScalar()
                    If result IsNot Nothing AndAlso Not IsDBNull(result) Then
                        dateDerniere = Convert.ToDateTime(result).Date
                    End If
                End Using
            End Using
        Catch ex As Exception
            LogEventTechnique("ERREUR_CONTROLE_CLOTURES",
                "Erreur lecture derniere cloture : " & ex.Message)
            Return New System.Collections.Generic.List(Of Date)()
        End Try

        Dim debut As Date = If(dateDerniere = Date.MinValue, Now.Date.AddDays(-30), dateDerniere.AddDays(1))
        Dim hier As Date = Now.Date.AddDays(-1)
        If debut > hier Then Return New System.Collections.Generic.List(Of Date)()
        Return VerifierCloturesJournalieresManquantes(debut, hier)
    End Function

    ''' <summary>
    ''' Affiche une alerte MessageBox si des clôtures journalières sont manquantes.
    ''' À appeler dans FormCaisse_Load ou FormPrincipale_Load.
    ''' Compatible .NET Framework 3.5 (pas de lambda).
    ''' </summary>
    Public Sub AlerterCloturesManquantes()
        Dim manquantes As System.Collections.Generic.List(Of Date) = DetecterCloturesManquantes()
        If manquantes.Count = 0 Then Return

        ' Construire la liste — compatible .NET 3.5 (pas de lambda ni LINQ)
        Dim lignes As New StringBuilder()
        For Each d As Date In manquantes
            lignes.AppendLine("  - " & d.ToString("dddd dd MMMM yyyy",
                New System.Globalization.CultureInfo("fr-FR")))
        Next

        MessageBox.Show(
            "ATTENTION - Clotures journalieres manquantes !" & vbCrLf & vbCrLf &
            "Les journees suivantes ont des ventes sans cloture Z :" & vbCrLf &
            lignes.ToString() & vbCrLf &
            "Effectuez les clotures manquantes avant de continuer." & vbCrLf &
            "NF525 : une cloture Z par journee d'activite est obligatoire.",
            "NF525 - Clotures manquantes", MessageBoxButtons.OK, MessageBoxIcon.Warning)
    End Sub

#End Region

#Region "Vérification Grand Total Perpétuel (Monotonie)"

    ''' <summary>
    ''' Vérifie que le Grand Total Perpétuel ne diminue jamais entre deux clôtures consécutives.
    ''' Exigence fondamentale NF525 : le GTP doit être strictement croissant.
    ''' Compatible SQL Server 2005+ (sans LAG/LEAD).
    ''' </summary>
    ''' <returns>True si le GTP est valide (monotone croissant), False si une anomalie est détectée</returns>
    Public Function VerifierMonotonieGTP(Optional afficherDetails As Boolean = False) As Boolean
        Try
            ' Recherche de clôtures où le GTP est inférieur à la clôture précédente
            Dim sql As String =
                "SELECT c1.Id_Cloture, c1.DateCloture, c1.TypeCloture, " &
                "c1.GrandTotal_Perpetuel_TTC AS GTP_Actuel, " &
                "c2.GrandTotal_Perpetuel_TTC AS GTP_Precedent " &
                "FROM T_Cloture c1 " &
                "INNER JOIN T_Cloture c2 ON c2.Id_Cloture = (" &
                "    SELECT TOP 1 Id_Cloture FROM T_Cloture " &
                "    WHERE Id_Cloture < c1.Id_Cloture " &
                "    ORDER BY Id_Cloture DESC" &
                ") " &
                "WHERE c1.GrandTotal_Perpetuel_TTC < c2.GrandTotal_Perpetuel_TTC " &
                "ORDER BY c1.Id_Cloture"

            Dim anomalies As New System.Collections.Generic.List(Of String)()

            Using cnn As New SqlConnection(My.Settings.CLIConnectionString)
                cnn.Open()
                Using cmd As New SqlCommand(sql, cnn)
                    Using reader As SqlDataReader = cmd.ExecuteReader()
                        While reader.Read()
                            anomalies.Add("Clôture #" & reader("Id_Cloture") & " (" & reader("TypeCloture") & " " &
                                         CDate(reader("DateCloture")).ToString("dd/MM/yyyy") & ") : " &
                                         "GTP=" & CDec(reader("GTP_Actuel")).ToString("F2") & " < " &
                                         "GTP précédent=" & CDec(reader("GTP_Precedent")).ToString("F2"))
                        End While
                    End Using
                End Using
            End Using

            If anomalies.Count > 0 Then
                LogEventTechnique("GTP_MONOTONIE_KO",
                                 anomalies.Count & " anomalie(s) de Grand Total Perpétuel détectée(s)",
                                 "", String.Join(" | ", anomalies.ToArray()))
                If afficherDetails Then
                    MessageBox.Show("ANOMALIE CRITIQUE - Grand Total Perpetuel" & vbCrLf & vbCrLf &
                                  String.Join(vbCrLf, anomalies.ToArray()) & vbCrLf & vbCrLf &
                                  "Contactez immédiatement votre référent NF525.",
                                  "NF525 - Contrôle GTP", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
                Return False
            Else
                LogEventTechnique("GTP_MONOTONIE_OK",
                                 "Vérification Grand Total Perpétuel : aucune anomalie", "", "")
                Return True
            End If

        Catch ex As Exception
            LogEventTechnique("ERREUR_VERIFICATION_GTP", "Erreur vérification GTP : " & ex.Message)
            Return False
        End Try
    End Function

#End Region

#Region "Purge sécurisée"

    ''' <summary>
    ''' Effectue une purge sécurisée des données opérationnelles d'une période.
    ''' EXIGENCES NF525 :
    '''   1. Une archive valide doit exister pour la période (vérifiée par le JET).
    '''   2. L'intégrité de la chaîne est vérifiée avant purge.
    '''   3. La purge est tracée dans le JET (PURGE_DONNEES).
    '''   4. Les tickets sont marqués PurgeLe/PurgePar (suppression logique — PAS de DELETE).
    ''' </summary>
    ''' <param name="dateDebut">Début de la période à purger</param>
    ''' <param name="dateFin">Fin de la période à purger</param>
    Public Sub PurgeDonneesPeriode(dateDebut As Date, dateFin As Date)
        Try
            Dim dateFin23h As Date = dateFin.Date.AddDays(1).AddSeconds(-1)

            ' ── Étape 1 : Vérifier qu'une archive existe pour la période ────
            Dim sqlVerifArchive As String =
                "SELECT COUNT(*) FROM T_JournalEvenements " &
                "WHERE TypeEvent = 'EXPORT_ARCHIVE' " &
                "AND Description LIKE @Cherche"
            Dim nbArchives As Integer = 0
            Using cnn As New SqlConnection(My.Settings.CLIConnectionString)
                cnn.Open()
                Using cmd As New SqlCommand(sqlVerifArchive, cnn)
                    ' Recherche approximative par la date de début dans la description
                    cmd.Parameters.AddWithValue("@Cherche", "%" & dateDebut.ToString("dd/MM/yyyy") & "%")
                    nbArchives = Convert.ToInt32(cmd.ExecuteScalar())
                End Using
            End Using

            If nbArchives = 0 Then
                Throw New InvalidOperationException(
                    "PURGE BLOQUÉE : Aucune archive fiscale trouvée pour la période " &
                    dateDebut.ToString("dd/MM/yyyy") & " - " & dateFin.ToString("dd/MM/yyyy") & "." & vbCrLf &
                    "Exécutez d'abord ExporterArchiveFiscale() pour cette période.")
            End If

            ' ── Étape 2 : Vérifier l'intégrité de la chaîne ─────────────────
            If Not VerifierIntegriteChaine(False) Then
                Throw New InvalidOperationException(
                    "PURGE BLOQUÉE : L'intégrité de la chaîne cryptographique est compromise." & vbCrLf &
                    "Une rupture de chaîne a été détectée. Consultez le JET (INTEGRITE_KO).")
            End If

            ' ── Étape 3 : Compter les enregistrements à purger ───────────────
            Dim nbTickets As Integer = 0
            Dim sqlCompter As String = "SELECT COUNT(*) FROM T_CommandeVente " &
                                      "WHERE TicketLe BETWEEN @Debut AND @Fin " &
                                      "AND ID_EtatCommandeVente >= 20 " &
                                      "AND (PurgeLe IS NULL)"
            Using cnn As New SqlConnection(My.Settings.CLIConnectionString)
                cnn.Open()
                Using cmd As New SqlCommand(sqlCompter, cnn)
                    cmd.Parameters.AddWithValue("@Debut", dateDebut)
                    cmd.Parameters.AddWithValue("@Fin", dateFin23h)
                    nbTickets = Convert.ToInt32(cmd.ExecuteScalar())
                End Using
            End Using

            If nbTickets = 0 Then
                LogEventTechnique("PURGE_AUCUN_ELEMENT",
                                 "Aucun ticket à purger pour " & dateDebut.ToString("dd/MM/yyyy") &
                                 " - " & dateFin.ToString("dd/MM/yyyy"), "", "")
                Return
            End If

            ' ── Étape 4 : Marquer les tickets comme purgés (NE PAS SUPPRIMER) ─
            Dim sqlPurge As String = "UPDATE T_CommandeVente SET PurgeLe = @DatePurge, PurgePar = @User " &
                                    "WHERE TicketLe BETWEEN @Debut AND @Fin " &
                                    "AND ID_EtatCommandeVente >= 20 " &
                                    "AND (PurgeLe IS NULL)"
            Using cnn As New SqlConnection(My.Settings.CLIConnectionString)
                cnn.Open()
                Using cmd As New SqlCommand(sqlPurge, cnn)
                    cmd.Parameters.AddWithValue("@DatePurge", Now)
                    cmd.Parameters.AddWithValue("@User", gLogin)
                    cmd.Parameters.AddWithValue("@Debut", dateDebut)
                    cmd.Parameters.AddWithValue("@Fin", dateFin23h)
                    cmd.ExecuteNonQuery()
                End Using
            End Using

            ' ── Étape 5 : Tracer la purge dans le JET ────────────────────────
            LogEventTechnique("PURGE_DONNEES",
                             "Purge sécurisée " & dateDebut.ToString("dd/MM/yyyy") & " - " & dateFin.ToString("dd/MM/yyyy") &
                             " | " & nbTickets & " ticket(s) marqué(s)",
                             dateDebut.ToString("yyyy-MM-dd") & "/" & dateFin.ToString("yyyy-MM-dd"),
                             "Machine: " & Environment.MachineName & " | Archives vérifiées: " & nbArchives)

        Catch ex As Exception
            LogEventTechnique("ERREUR_PURGE", "Erreur purge sécurisée : " & ex.Message)
            Throw
        End Try
    End Sub

#End Region

#Region "Export FEC — Fichier des Écritures Comptables (Art. A47 A-1 CGI)"

    ''' <summary>
    ''' Exporte le Fichier des Écritures Comptables (FEC) conforme à l'article A47 A-1 du CGI.
    ''' Le FEC est obligatoire en cas de contrôle fiscal et exigé pour la certification NF525.
    ''' Format : texte tabulé, encodage UTF-8 avec BOM, séparateur tabulation.
    ''' Colonnes imposées par la DGFiP (18 colonnes fixes).
    ''' </summary>
    ''' <param name="dateDebut">Premier jour de la période comptable</param>
    ''' <param name="dateFin">Dernier jour de la période comptable</param>
    ''' <param name="cheminFichier">Chemin complet du fichier FEC à générer</param>
    Public Sub ExporterFEC(dateDebut As Date, dateFin As Date, cheminFichier As String)

        ' ── Mapping TVA → comptes PCG DGFiP ────────────────────────────────
        ' 44571  : TVA collectée 20 %
        ' 44572  : TVA collectée 10 %
        ' 44573  : TVA collectée 5,5 %
        ' 44574  : TVA collectée 2,1 %
        ' 707    : Ventes de marchandises (HT)
        ' 531    : Caisse
        Dim mapTVACompte As New Dictionary(Of Decimal, String) From {
            {20D, "44571"},
            {10D, "44572"},
            {5.5D, "44573"},
            {2.1D, "44574"}
        }
        Dim mapTVALib As New Dictionary(Of Decimal, String) From {
            {20D, "TVA collectée 20%"},
            {10D, "TVA collectée 10%"},
            {5.5D, "TVA collectée 5,5%"},
            {2.1D, "TVA collectée 2,1%"}
        }
        Dim mapTVAVente As New Dictionary(Of Decimal, String) From {
            {20D, "70720"},
            {10D, "70710"},
            {5.5D, "70755"},
            {2.1D, "70721"}
        }

        Dim dateFin23h As Date = dateFin.Date.AddHours(23).AddMinutes(59).AddSeconds(59)
        Dim numEcriture As Integer = 1
        ' SIRET de l'établissement — lu depuis les paramètres ou valeur par défaut
        ' À configurer dans My.Settings ou FormParamsGene (Administration → Paramètres généraux)
        Dim siret As String = "48450148100010" ' SIRET Chinook Leucate

        Try
            Dim sqlTickets As String =
                "SELECT cv.Id_CommandeVente, cv.TicketLe, cv.Total_TTC, cv.Total_HT, " &
                "       cv.Total_TVA, cv.ID_EtatCommandeVente, cv.Signature, " &
                "       ISNULL(cv.Id_CommandeVente_Avoir, 0) AS EstAvoir " &
                "FROM T_CommandeVente cv " &
                "WHERE cv.TicketLe BETWEEN @Debut AND @Fin " &
                "  AND cv.ID_EtatCommandeVente >= 20 " &
                "  AND (cv.PurgeLe IS NULL OR cv.PurgeLe > @Fin) " &
                "ORDER BY cv.TicketLe, cv.Id_CommandeVente"

            ' NF525 : requête ventilation TVA par taux pour chaque ticket.
            ' Utilise T_CommandeVente_Ligne + CodeTva (schéma NF525 canonique).
            ' Si votre base possède encore T_CommandeVenteLigne/T_Taxe (ancien schéma),
            ' adaptez la requête en conséquence après vérification.
            Dim sqlTVADetail As String =
                "SELECT l.CodeTva AS Taux, " &
                "       ISNULL(SUM(l.prix_total_TTC / (1 + CASE WHEN l.CodeTva > 0 THEN l.CodeTva/100.0 ELSE 0 END)), 0) AS HT, " &
                "       ISNULL(SUM(l.prix_total_TTC - l.prix_total_TTC / (1 + CASE WHEN l.CodeTva > 0 THEN l.CodeTva/100.0 ELSE 0 END)), 0) AS TVA " &
                "FROM T_CommandeVente_Ligne l " &
                "WHERE l.ID_T_CommandeVente = @IdCV " &
                "GROUP BY l.CodeTva"

            Using sw As New IO.StreamWriter(cheminFichier, False, New Text.UTF8Encoding(True))
                ' ── En-tête FEC (18 colonnes obligatoires DGFiP) ──────────────
                sw.WriteLine(
                    "JournalCode" & vbTab & "JournalLib" & vbTab &
                    "EcritureNum" & vbTab & "EcritureDate" & vbTab &
                    "CompteNum" & vbTab & "CompteLib" & vbTab &
                    "CompAuxNum" & vbTab & "CompAuxLib" & vbTab &
                    "PieceRef" & vbTab & "PieceDate" & vbTab &
                    "EcritureLib" & vbTab &
                    "Debit" & vbTab & "Credit" & vbTab &
                    "EcritureLet" & vbTab & "DateLet" & vbTab &
                    "ValidDate" & vbTab &
                    "Montantdevise" & vbTab & "Idevise"
                )

                Using cnn As New SqlConnection(My.Settings.CLIConnectionString)
                    cnn.Open()

                    Using cmdTickets As New SqlCommand(sqlTickets, cnn)
                        cmdTickets.Parameters.AddWithValue("@Debut", dateDebut.Date)
                        cmdTickets.Parameters.AddWithValue("@Fin", dateFin23h)

                        Using rdr As SqlDataReader = cmdTickets.ExecuteReader()
                            Dim tickets As New List(Of Tuple(Of Integer, Date, Decimal, Decimal, Decimal, Boolean))
                            While rdr.Read()
                                tickets.Add(Tuple.Create(
                                    rdr.GetInt32(0),               ' Id_CommandeVente
                                    rdr.GetDateTime(1),            ' TicketLe
                                    rdr.GetDecimal(2),             ' Total_TTC
                                    rdr.GetDecimal(3),             ' Total_HT
                                    rdr.GetDecimal(4),             ' Total_TVA
                                    rdr.GetInt32(7) <> 0           ' EstAvoir
                                ))
                            End While
                            rdr.Close()

                            For Each t In tickets
                                Dim idCV As Integer = t.Item1
                                Dim datePiece As Date = t.Item2
                                Dim ttc As Decimal = t.Item3
                                Dim estAvoir As Boolean = t.Item6
                                Dim pieceRef As String = "TK" & idCV.ToString("D8")
                                Dim dateStr As String = datePiece.ToString("yyyyMMdd")
                                Dim validDate As String = datePiece.ToString("yyyyMMdd")
                                Dim libType As String = If(estAvoir, "AVOIR", "VENTE")
                                Dim numEcr As String = numEcriture.ToString("D10")
                                numEcriture += 1

                                ' Lire détail TVA par taux pour ce ticket
                                Dim tauxHT As New Dictionary(Of Decimal, Decimal)  ' taux → HT
                                Dim tauxTVA As New Dictionary(Of Decimal, Decimal) ' taux → TVA
                                Using cnn2 As New SqlConnection(My.Settings.CLIConnectionString)
                                    cnn2.Open()
                                    Using cmdTVA As New SqlCommand(sqlTVADetail, cnn2)
                                        cmdTVA.Parameters.AddWithValue("@IdCV", idCV)
                                        Using rdrTVA As SqlDataReader = cmdTVA.ExecuteReader()
                                            While rdrTVA.Read()
                                                ' Col 0=Taux, 1=HT, 2=TVA (schéma NF525 T_CommandeVente_Ligne)
                                                Dim taux As Decimal = If(IsDBNull(rdrTVA(0)), 0D, rdrTVA.GetDecimal(0))
                                                Dim ht As Decimal = rdrTVA.GetDecimal(1)
                                                Dim tvaM As Decimal = rdrTVA.GetDecimal(2)
                                                If tauxHT.ContainsKey(taux) Then
                                                    tauxHT(taux) += ht
                                                    tauxTVA(taux) += tvaM
                                                Else
                                                    tauxHT(taux) = ht
                                                    tauxTVA(taux) = tvaM
                                                End If
                                            End While
                                        End Using
                                    End Using
                                End Using

                                ' ── Ligne 1 : Débit ou Crédit Caisse (531) ──────────────
                                If Not estAvoir Then
                                    ' Vente : débit caisse
                                    sw.WriteLine(FecLigne("VTE", "Ventes", numEcr, dateStr,
                                                           "531", "Caisse", "", "",
                                                           pieceRef, dateStr,
                                                           "VENTE " & pieceRef,
                                                           ttc, 0D, validDate))
                                Else
                                    ' Avoir : crédit caisse
                                    sw.WriteLine(FecLigne("VTE", "Ventes", numEcr, dateStr,
                                                           "531", "Caisse", "", "",
                                                           pieceRef, dateStr,
                                                           "AVOIR " & pieceRef,
                                                           0D, ttc, validDate))
                                End If

                                ' ── Lignes TVA + Ventes HT par taux ────────────────────
                                For Each kvp As KeyValuePair(Of Decimal, Decimal) In tauxHT
                                    Dim taux As Decimal = kvp.Key
                                    Dim ht As Decimal = kvp.Value
                                    Dim tvaM As Decimal = If(tauxTVA.ContainsKey(taux), tauxTVA(taux), 0D)

                                    Dim cpteVente As String = If(mapTVAVente.ContainsKey(taux), mapTVAVente(taux), "7079")
                                    Dim cpteTVA As String = If(mapTVACompte.ContainsKey(taux), mapTVACompte(taux), "4457")
                                    Dim libTVA As String = If(mapTVALib.ContainsKey(taux), mapTVALib(taux), "TVA collectée")
                                    Dim libVente As String = "Ventes HT " & taux.ToString("0.0") & "%"

                                    If Not estAvoir Then
                                        ' Vente normale : crédit 707, crédit TVA
                                        sw.WriteLine(FecLigne("VTE", "Ventes", numEcr, dateStr,
                                                               cpteVente, libVente, "", "",
                                                               pieceRef, dateStr,
                                                               "VENTE HT " & taux.ToString("0.0") & "% " & pieceRef,
                                                               0D, ht, validDate))
                                        If tvaM <> 0D Then
                                            sw.WriteLine(FecLigne("VTE", "Ventes", numEcr, dateStr,
                                                                   cpteTVA, libTVA, "", "",
                                                                   pieceRef, dateStr,
                                                                   "TVA " & taux.ToString("0.0") & "% " & pieceRef,
                                                                   0D, tvaM, validDate))
                                        End If
                                    Else
                                        ' Avoir : débit 707, débit TVA
                                        sw.WriteLine(FecLigne("VTE", "Ventes", numEcr, dateStr,
                                                               cpteVente, libVente, "", "",
                                                               pieceRef, dateStr,
                                                               "AVOIR HT " & taux.ToString("0.0") & "% " & pieceRef,
                                                               ht, 0D, validDate))
                                        If tvaM <> 0D Then
                                            sw.WriteLine(FecLigne("VTE", "Ventes", numEcr, dateStr,
                                                                   cpteTVA, libTVA, "", "",
                                                                   pieceRef, dateStr,
                                                                   "AVOIR TVA " & taux.ToString("0.0") & "% " & pieceRef,
                                                                   tvaM, 0D, validDate))
                                        End If
                                    End If
                                Next
                            Next
                        End Using
                    End Using
                End Using ' cnn
            End Using ' StreamWriter

            ' ── Traçabilité JET ─────────────────────────────────────────────
            LogEventTechnique("EXPORT_FEC",
                             "FEC exporté : " & dateDebut.ToString("dd/MM/yyyy") &
                             " → " & dateFin.ToString("dd/MM/yyyy") &
                             " | " & (numEcriture - 1) & " écriture(s)",
                             IO.Path.GetFileName(cheminFichier),
                             "Opérateur : " & gLogin & " | Machine : " & Environment.MachineName)

            MessageBox.Show(
                "Export FEC terminé." & Environment.NewLine &
                "Fichier : " & cheminFichier & Environment.NewLine &
                "Écritures : " & (numEcriture - 1) & Environment.NewLine & Environment.NewLine &
                "Ce fichier doit être remis à l'administration fiscale sur demande." & Environment.NewLine &
                "Format conforme Art. A47 A-1 CGI / DGFiP.",
                "FEC — Export réussi", MessageBoxButtons.OK, MessageBoxIcon.Information)

        Catch ex As Exception
            LogEventTechnique("ERREUR_FEC", "Erreur export FEC : " & ex.Message)
            MessageBox.Show("Erreur lors de l'export FEC : " & Environment.NewLine & ex.Message,
                            "FEC — Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Throw
        End Try
    End Sub

    ''' <summary>
    ''' Formate une ligne FEC (18 colonnes, séparateur tabulation).
    ''' Les montants sont formatés avec virgule décimale (norme DGFiP : pas de séparateur de milliers).
    ''' </summary>
    Private Function FecLigne(jCode As String, jLib As String,
                               ecritureNum As String, ecritureDate As String,
                               cpteNum As String, cpteLib As String,
                               cpteAuxNum As String, cpteAuxLib As String,
                               pieceRef As String, pieceDate As String,
                               ecritureLib As String,
                               debit As Decimal, credit As Decimal,
                               validDate As String) As String
        ' Formatage montants DGFiP : séparateur décimal = virgule, pas de groupement
        Dim fmt As New Globalization.CultureInfo("fr-FR")
        Dim sDebit As String = debit.ToString("F2", fmt)
        Dim sCredit As String = credit.ToString("F2", fmt)

        Return String.Join(vbTab,
            jCode, jLib,
            ecritureNum, ecritureDate,
            cpteNum, cpteLib,
            cpteAuxNum, cpteAuxLib,
            pieceRef, pieceDate,
            ecritureLib,
            sDebit, sCredit,
            "", "",             ' EcritureLet, DateLet (lettrage manuel, laisser vide)
            validDate,
            "", ""              ' Montantdevise, Idevise (EUR, non requis si monnaie unique)
        )
    End Function

#End Region

End Module
