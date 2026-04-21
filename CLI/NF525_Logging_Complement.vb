' =============================================
' NF525 PHASE 2 - LOGGING COMPLEMENT
' =============================================
' Fichier: NF525_Logging_Complement.vb
' Date: 2026-02-12
' Objectif: Finaliser Phase 2 à 100%
' - Logging modifications TVA
' - Logging accès admin
' - Logging échecs authentification
' - Logging fermeture caisse
' =============================================

Imports System.Data.SqlClient

''' <summary>
''' Module complémentaire pour finaliser la journalisation NF525
''' À intégrer dans les formulaires existants
''' </summary>
Public Module NF525_Logging_Complement

#Region "TVA - Modifications"

    ''' <summary>
    ''' À appeler dans FormParamTva.vb lors de la sauvegarde
    ''' </summary>
    Public Sub LogModificationTVA(codeTVA As String, ancienTaux As Decimal, nouveauTaux As Decimal)
        Try
            LogEventTechnique("MODIFICATION_TVA",
                            "Changement du taux de TVA : " & codeTVA,
                            ancienTaux.ToString("F2") & "%",
                            nouveauTaux.ToString("F2") & "%")
        Catch ex As Exception
            ' Ne pas bloquer l'opération si le log échoue
            Debug.WriteLine("Erreur logging TVA : " & ex.Message)
        End Try
    End Sub

    ''' <summary>
    ''' À appeler lors de la CRÉATION d'un nouveau code TVA
    ''' </summary>
    Public Sub LogCreationTVA(codeTVA As String, taux As Decimal)
        Try
            LogEventTechnique("CREATION_CODE_TVA",
                            "Nouveau code TVA créé : " & codeTVA,
                            "",
                            taux.ToString("F2") & "%")
        Catch ex As Exception
            Debug.WriteLine("Erreur logging création TVA : " & ex.Message)
        End Try
    End Sub

    ''' <summary>
    ''' À appeler lors de la SUPPRESSION d'un code TVA (si autorisé)
    ''' </summary>
    Public Sub LogSuppressionTVA(codeTVA As String, taux As Decimal)
        Try
            LogEventTechnique("SUPPRESSION_CODE_TVA",
                            "Code TVA supprimé : " & codeTVA,
                            taux.ToString("F2") & "%",
                            "")
        Catch ex As Exception
            Debug.WriteLine("Erreur logging suppression TVA : " & ex.Message)
        End Try
    End Sub

#End Region

#Region "Accès Admin"

    ''' <summary>
    ''' À appeler lors de la connexion en mode administrateur
    ''' </summary>
    Public Sub LogAccesAdmin(username As String, roleOuPermission As String)
        Try
            LogEventTechnique("ACCES_ADMIN",
                            "Connexion administrateur",
                            "",
                            "User: " & username & " | Role: " & roleOuPermission & _
                            " | Machine: " & Environment.MachineName & _
                            " | IP: " & GetLocalIPAddress())
        Catch ex As Exception
            Debug.WriteLine("Erreur logging accès admin : " & ex.Message)
        End Try
    End Sub

    ''' <summary>
    ''' À appeler lors d'actions sensibles admin
    ''' </summary>
    Public Sub LogActionAdmin(action As String, cible As String, Optional details As String = "")
        Try
            LogEventTechnique("ACTION_ADMIN",
                            action & " - " & cible,
                            "",
                            details &" | User: " & gLogin)
        Catch ex As Exception
            Debug.WriteLine("Erreur logging action admin : " & ex.Message)
        End Try
    End Sub

    ''' <summary>
    ''' Récupère l'adresse IP locale (helper)
    ''' </summary>
    Private Function GetLocalIPAddress() As String
        Try
            Dim hostName As String = System.Net.Dns.GetHostName()
            Dim ipEntry As System.Net.IPHostEntry = System.Net.Dns.GetHostEntry(hostName)
            For Each ip As System.Net.IPAddress In ipEntry.AddressList
                If ip.AddressFamily = System.Net.Sockets.AddressFamily.InterNetwork Then
                    Return ip.ToString()
                End If
            Next
            Return "Unknown"
        Catch
            Return "Unknown"
        End Try
    End Function

#End Region

#Region "Authentification"

    ''' <summary>
    ''' À appeler lors d'une tentative de connexion RÉUSSIE
    ''' </summary>
    Public Sub LogConnexionReussie(username As String)
        Try
            LogEventTechnique("CONNEXION_REUSSIE",
                            "Authentification réussie",
                            "",
                            "User: " & username & _
                            " | Machine: " & Environment.MachineName & _
                            " | Session: " & DateTime.Now.ToString("yyyyMMddHHmmss"))
        Catch ex As Exception
            Debug.WriteLine("Erreur logging connexion : " & ex.Message)
        End Try
    End Sub

    ''' <summary>
    ''' À appeler lors d'une tentative de connexion ÉCHOUÉE
    ''' CRITIQUE pour NF525 - Détecter les tentatives d'intrusion
    ''' </summary>
    Public Sub LogEchecAuthentification(username As String, motif As String)
        Try
            LogEventTechnique("ECHEC_AUTHENTIFICATION",
                            "Tentative de connexion échouée",
                            username,
                            "Motif: " & motif & _
                            " | Machine: " & Environment.MachineName & _
                            " | Heure: " & DateTime.Now.ToString("HH:mm:ss"))
        Catch ex As Exception
            ' Toujours logger les échecs auth, même si JET échoue
            ' Fallback sur fichier log
            Try
                System.IO.File.AppendAllText("C:\temp\cli\auth_failures.log",
                    DateTime.Now.ToString() & " | " & username & " | " & motif & vbCrLf)
            Catch
            End Try
        End Try
    End Sub

    ''' <summary>
    ''' Compteur d'échecs (helper pour détecter brute force)
    ''' </summary>
    Public Function CompterEchecsRecents(username As String, minutesPrecedentes As Integer) As Integer
        Try
            Dim sql As String = "SELECT COUNT(*) FROM T_JournalEvenements " &
                               "WHERE TypeEvent = 'ECHEC_AUTHENTIFICATION' " &
                               "AND AncienneValeur = @User " &
                               "AND DateEvent >= DATEADD(MINUTE, -@Minutes, GETDATE())"

            Using cnn As New SqlConnection(My.Settings.CLIConnectionString)
                cnn.Open()
                Using cmd As New SqlCommand(sql, cnn)
                    cmd.Parameters.AddWithValue("@User", username)
                    cmd.Parameters.AddWithValue("@Minutes", minutesPrecedentes)
                    Return Convert.ToInt32(cmd.ExecuteScalar())
                End Using
            End Using
        Catch
            Return 0
        End Try
    End Function

    ''' <summary>
    ''' Déconnexion (volontaire)
    ''' </summary>
    Public Sub LogDeconnexion(username As String)
        Try
            LogEventTechnique("DECONNEXION",
                            "Déconnexion utilisateur",
                            "",
                            "User: " & username & " | Durée session: " & GetSessionDuration())
        Catch ex As Exception
            Debug.WriteLine("Erreur logging déconnexion : " & ex.Message)
        End Try
    End Sub

    Private sessionStartTime As DateTime = DateTime.Now

    Private Function GetSessionDuration() As String
        Dim duration As TimeSpan = DateTime.Now - sessionStartTime
        Return String.Format("{0}h{1}m{2}s", duration.Hours, duration.Minutes, duration.Seconds)
    End Function

#End Region

#Region "Fermeture Caisse"

    ''' <summary>
    ''' À appeler dans FormCaisse.FormClosing ou FormCaisse.Dispose
    ''' </summary>
    Public Sub LogFermetureCaisse(Optional infos As String = "")
        Try
            ' Récupérer stats de la session (nombre de ventes, CA, etc.)
            Dim stats As String = GetStatistiquesSession()

            LogEventTechnique("FERMETURE_CAISSE",
                            "Fermeture du module de caisse",
                            "",
                            "User: " & gLogin & _
                            " | Machine: " & Environment.MachineName & _
                            " | Stats: " & stats & _
                            If(infos <> "", " | " & infos, ""))
        Catch ex As Exception
            Debug.WriteLine("Erreur logging fermeture caisse : " & ex.Message)
        End Try
    End Sub

    ''' <summary>
    ''' Helper : récupère les stats de la session en cours
    ''' </summary>
    Private Function GetStatistiquesSession() As String
        Try
            ' Compter les ventes créées pendant cette session
            ' Note: Nécessite de tracker l'heure de début de session
            Dim sql As String = "SELECT COUNT(*), ISNULL(SUM(Total_TTC), 0) " &
                               "FROM T_CommandeVente " &
                               "WHERE CreePar = @User " &
                               "AND TicketLe >= @DebutSession"

            Using cnn As New SqlConnection(My.Settings.CLIConnectionString)
                cnn.Open()
                Using cmd As New SqlCommand(sql, cnn)
                    cmd.Parameters.AddWithValue("@User", gLogin)
                    cmd.Parameters.AddWithValue("@DebutSession", sessionStartTime)

                    Using reader As SqlDataReader = cmd.ExecuteReader()
                        If reader.Read() Then
                            Dim nbVentes As Integer = reader.GetInt32(0)
                            Dim caTotal As Decimal = reader.GetDecimal(1)
                            Return String.Format("{0} vente(s), CA: {1:F2}€", nbVentes, caTotal)
                        End If
                    End Using
                End Using
            End Using

            Return "N/A"
        Catch
            Return "N/A"
        End Try
    End Function

#End Region

End Module


' =============================================
' INSTRUCTIONS D'INTÉGRATION
' =============================================
'
' 1. FormParamTva.vb - Lors de la sauvegarde d'un taux TVA:
'    ---------------------------------------------------------
'    Private Sub BtnSave_Click(...)
'        Dim ancienTaux As Decimal = ... ' Récupérer avant modif
'        Dim nouveauTaux As Decimal = ... ' Nouvelle valeur
'        
'        ' Sauvegarder en base...
'        T_code_tvaTableAdapter.Update(...)
'        
'        ' ✅ NF525 : Logger la modification
'        LogModificationTVA(CodeTVAComboBox.Text, ancienTaux, nouveauTaux)
'    End Sub
'
'
' 2. FormLogin.vb (ou Module de connexion) - Authentification:
'    ---------------------------------------------------------
'    Private Sub BtnLogin_Click(...)
'        If ValidateCredentials(username, password) Then
'            ' Connexion réussie
'            gLogin = username
'            
'            ' ✅ NF525 : Logger la connexion
'            LogConnexionReussie(username)
'            
'            ' Vérifier si admin
'            If IsAdministrator(username) Then
'                LogAccesAdmin(username, "Administrateur")
'            End If
'            
'            Me.DialogResult = DialogResult.OK
'        Else
'            ' ✅ NF525 : Logger l'échec
'            LogEchecAuthentification(username, "Mot de passe incorrect")
'            
'            ' Vérifier nombre d'échecs (sécurité)
'            Dim nbEchecs = CompterEchecsRecents(username, 15) ' 15 dernières minutes
'            If nbEchecs >= 5 Then
'                MessageBox.Show("⚠️ Compte temporairement bloqué après " & nbEchecs & " tentatives échouées")
'                ' TODO: Bloquer le compte ou alerter admin
'            End If
'        End If
'    End Sub
'
'
' 3. FormCaisse.vb - Fermeture du formulaire:
'    ---------------------------------------------------------
'    Private Sub FormCaisse_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
'        ' ✅ NF525 : Logger la fermeture
'        LogFermetureCaisse()
'        
'        ' Reste du code de fermeture...
'    End Sub
'
'
' 4. Actions Admin - Exemples d'utilisation:
'    ---------------------------------------------------------
'    ' Modification paramètres
'    LogActionAdmin("Modification paramètres", "Prix article #123", "Ancien: 10€, Nouveau: 12€")
'    
'    ' Export de données
'    LogActionAdmin("Export données", "T_Client", "250 enregistrements exportés")
'    
'    ' Suppression
'    LogActionAdmin("Suppression", "Article #456", "Supprimé par décision commerciale")
'
' =============================================
