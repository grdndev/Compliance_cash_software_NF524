Public Class FormIdentification

    ' TODO : insérez le code pour effectuer une authentification personnalisée à l'aide du nom d'utilisateur et du mot de passe fournis 
    ' (Voir http://go.microsoft.com/fwlink/?LinkId=35339).  
    ' L'objet Principal personnalisé peut ensuite être associé à l'objet Principal du thread actuel comme suit : 
    '     My.User.CurrentPrincipal = CustomPrincipal
    ' CustomPrincipal est l'implémentation IPrincipal utilisée pour effectuer l'authentification. 
    ' Par la suite, My.User retournera les informations d'identité encapsulées dans l'objet CustomPrincipal
    ' telles que le nom d'utilisateur, le nom complet, etc.

    Private Sub OK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK.Click
        If CodeBarreTextBox.Text.Trim <> "" Or (UsernameTextBox.Text.Trim <> "" And PasswordTextBox.Text.Trim <> "") Then

            Dim saisieLogin As String = UsernameTextBox.Text.Trim()
            Dim saisieMotDePasse As String = PasswordTextBox.Text
            Dim saisieCodebar As String = CodeBarreTextBox.Text.Trim()

            Using cnn As New SqlClient.SqlConnection(My.Settings.CLIConnectionString)
                cnn.Open()

                ' ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━
                ' ✅ NF525 SÉCURITÉ : Requête paramétrée (fix injection SQL)
                ' Étape 1 : rechercher l'utilisateur par login ou codebar UNIQUEMENT
                ' La vérification du mot de passe se fait ensuite en code (PBKDF2)
                ' ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━
                Dim strsql As String
                If saisieCodebar <> "" Then
                    strsql = "SELECT u.*, p.* FROM t_user u " &
                             "INNER JOIN t_profil p ON u.id_t_profil = p.id_t_profil " &
                             "WHERE u.actif = 1 AND u.codebar = @Codebar"
                Else
                    strsql = "SELECT u.*, p.* FROM t_user u " &
                             "INNER JOIN t_profil p ON u.id_t_profil = p.id_t_profil " &
                             "WHERE u.actif = 1 AND u.login = @Login"
                End If

                Using command As New SqlClient.SqlCommand(strsql, cnn)
                    If saisieCodebar <> "" Then
                        command.Parameters.AddWithValue("@Codebar", saisieCodebar)
                    Else
                        command.Parameters.AddWithValue("@Login", saisieLogin)
                    End If

                    ' Lire toutes les données AVANT de fermer le reader
                    Dim utilisateurTrouve As Boolean = False
                    Dim motDePasseStocke As String = ""
                    Dim tmpAdmin As Boolean = False
                    Dim tmpStatistiques As Boolean = False
                    Dim tmpVente_r As Boolean = False : Dim tmpVente_w As Boolean = False
                    Dim tmpAchat_r As Boolean = False : Dim tmpAchat_w As Boolean = False
                    Dim tmpArticle_r As Boolean = False : Dim tmpArticle_w As Boolean = False
                    Dim tmpArticle_stock As Boolean = False
                    Dim tmpOccazOnly As Boolean = False : Dim tmpOccazTestOnly As Boolean = False
                    Dim tmpArticle_Web As Boolean = False : Dim tmpArticle_Mag As Boolean = False
                    Dim tmpProfilName As String = "" : Dim tmpLogin As String = ""
                    Dim tmpProfil As String = "" : Dim tmpTransaction As Boolean = False
                    Dim tmpMenuWeb As Boolean = False : Dim tmpPrixStock As Boolean = False
                    Dim tmpJournalUn As Boolean = False : Dim tmpJournalDeux As Boolean = False

                    Using reader As SqlClient.SqlDataReader = command.ExecuteReader()
                        If reader.HasRows Then
                            reader.Read()
                            utilisateurTrouve = True
                            motDePasseStocke = reader("password").ToString()
                            tmpAdmin = CBool(reader("admin"))
                            tmpStatistiques = CBool(reader("statistiques"))
                            tmpVente_r = CBool(reader("Vente_r")) : tmpVente_w = CBool(reader("Vente_w"))
                            tmpAchat_r = CBool(reader("Achat_r")) : tmpAchat_w = CBool(reader("Achat_w"))
                            tmpArticle_r = CBool(reader("Article_r")) : tmpArticle_w = CBool(reader("Article_w"))
                            tmpArticle_stock = CBool(reader("Article_stock"))
                            tmpOccazOnly = CBool(reader("Article_OccazOnly"))
                            tmpOccazTestOnly = CBool(reader("Article_OccazTestOnly"))
                            tmpArticle_Web = CBool(reader("Article_web"))
                            tmpArticle_Mag = CBool(reader("Article_mag"))
                            tmpProfilName = reader("libelle").ToString()
                            tmpLogin = reader("login").ToString()
                            tmpProfil = reader("id_t_profil").ToString()
                            tmpTransaction = CBool(reader("transactions"))
                            tmpMenuWeb = CBool(reader("menu_activation_web"))
                            tmpPrixStock = CBool(reader("PrixStock"))
                            tmpJournalUn = If(IsDBNull(reader("JournalCaisseUn")), False, CBool(reader("JournalCaisseUn")))
                            tmpJournalDeux = If(IsDBNull(reader("JournalCaisseDeux")), False, CBool(reader("JournalCaisseDeux")))
                        End If
                    End Using ' reader fermé ici — connexion libre pour la migration

                    If Not utilisateurTrouve Then
                        ' ✅ NF525 : Logger tentative sur utilisateur inconnu
                        LogEchecAuthentification(saisieLogin, "Utilisateur introuvable ou inactif")
                        MessageBox.Show("Identification incorrecte !", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                        CodeBarreTextBox.Clear() : UsernameTextBox.Clear() : PasswordTextBox.Clear()
                        CodeBarreTextBox.Focus()
                        Return
                    End If

                    ' ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━
                    ' ✅ NF525 SÉCURITÉ : Vérification du mot de passe en code
                    ' Détection automatique du format (PBKDF2 ou ancien plaintext)
                    ' ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━
                    Dim authOk As Boolean = False

                    If saisieCodebar <> "" Then
                        ' Authentification par code-barre : pas de vérification mot de passe
                        authOk = True
                    ElseIf NF525.PasswordHasherNF525.EstUnHashNF525(motDePasseStocke) Then
                        ' ✅ Format sécurisé PBKDF2 — vérification cryptographique
                        authOk = NF525.PasswordHasherNF525.VerifierMotDePasse(saisieMotDePasse, motDePasseStocke)
                    Else
                        ' ⚠️ Ancien format plaintext — comparaison directe + migration automatique
                        authOk = (motDePasseStocke = saisieMotDePasse)
                        If authOk Then
                            ' Migration transparente vers PBKDF2
                            MigrerMotDePasseVersPBKDF2(saisieLogin, saisieMotDePasse, cnn)
                        End If
                    End If

                    If authOk Then
                        ' Charger les droits dans les variables globales
                        gadmin = tmpAdmin : gStatistiques = tmpStatistiques
                        gVente_r = tmpVente_r : gVente_w = tmpVente_w
                        gAchat_r = tmpAchat_r : gAchat_w = tmpAchat_w
                        gArticle_r = tmpArticle_r : gArticle_w = tmpArticle_w
                        gArticle_stock = tmpArticle_stock
                        gArticle_OccazOnly = tmpOccazOnly : gArticle_OccazTestOnly = tmpOccazTestOnly
                        gArticle_Web = tmpArticle_Web : gArticle_Mag = tmpArticle_Mag
                        gProfilName = tmpProfilName : gLogin = tmpLogin
                        gProfil = tmpProfil : gTransaction = tmpTransaction
                        gmenuActivationWeb = tmpMenuWeb : gPrixStock = tmpPrixStock
                        gJournalCaisseUn = tmpJournalUn : gJournalCaisseDeux = tmpJournalDeux

                        ' ✅ NF525 : Logger la connexion réussie dans le JET
                        LogConnexionReussie(gLogin)
                        If gadmin Then LogAccesAdmin(gLogin, gProfilName)

                        DeverouillageMenuPrincipal()
                        CodeBarreTextBox.Clear() : UsernameTextBox.Clear() : PasswordTextBox.Clear()
                        CodeBarreTextBox.Focus()
                        Me.Close()
                        FormCommandeRecherche.MdiParent = FormPrincipale
                        FormCommandeRecherche.Show()
                        FormCommandeRecherche.WindowState = FormWindowState.Normal
                        FormCommandeRecherche.BringToFront()
                    Else
                        ' ✅ NF525 : Logger l'échec d'authentification dans le JET
                        LogEchecAuthentification(saisieLogin, "Mot de passe incorrect")

                        ' Protection brute-force : alerter après 5 échecs en 15 minutes
                        Dim nbEchecs As Integer = CompterEchecsRecents(saisieLogin, 15)
                        If nbEchecs >= 5 Then
                            MessageBox.Show("Attention : " & nbEchecs & " tentatives de connexion echouees (15 min)." & vbCrLf &
                                           "Contactez l'administrateur si vous n'etes pas a l'origine de ces tentatives.",
                                           "Securite NF525", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        End If

                        MessageBox.Show("Identification incorrecte !", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                        CodeBarreTextBox.Clear() : UsernameTextBox.Clear() : PasswordTextBox.Clear()
                        CodeBarreTextBox.Focus()
                    End If
                End Using
            End Using
        Else
            MessageBox.Show("Merci de vous identifier !", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End If

    End Sub

    ''' <summary>
    ''' Migration automatique d'un mot de passe en clair vers PBKDF2.
    ''' Appelée lors de la première connexion réussie avec l'ancien format.
    ''' </summary>
    Private Sub MigrerMotDePasseVersPBKDF2(login As String, motDePasseClair As String, cnn As SqlClient.SqlConnection)
        Try
            Dim hashPBKDF2 As String = NF525.PasswordHasherNF525.HacherMotDePasse(motDePasseClair)
            Dim sql As String = "UPDATE t_user SET password = @Hash WHERE login = @Login"
            Using cmd As New SqlClient.SqlCommand(sql, cnn)
                cmd.Parameters.AddWithValue("@Hash", hashPBKDF2)
                cmd.Parameters.AddWithValue("@Login", login)
                cmd.ExecuteNonQuery()
            End Using
            LogEventTechnique("MIGRATION_MDP_PBKDF2",
                             "Migration mot de passe vers PBKDF2 pour : " & login,
                             "plaintext", "PBKDF2-SHA1-600000")
        Catch ex As Exception
            Debug.WriteLine("NF525 - Erreur migration mot de passe : " & ex.Message)
        End Try
    End Sub

    Private Sub Cancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel.Click
        Me.Close()
    End Sub

    Private Sub FormIdentification_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        VerouillageMenuPrincipal()
        CodeBarreTextBox.Focus()
    End Sub
    Private Sub DeverouillageMenuPrincipal()
        With FormPrincipale
            If Not gDatabase.ToUpper = "CLI" Or gServer.ToUpper <> "WWW.CHINOOK-LEUCATE.COM" Then
                .StatusStrip.BackColor = Color.Red
            End If

            .ToolStripStatusLabelLogin.Text = gLogin
            .ToolStripStatusLabelProfil.Text = gProfilName
            .ToolStripStatusLabelServerDatabase.Text = gServer & " : " & gDatabase
            .AchatsToolStripMenuItem.Enabled = gAchat_r
            .VentesToolStripMenuItem.Enabled = gVente_r
            .ArticlesToolStripMenuItem.Enabled = gArticle_r
            .AdministrationToolStripMenuItem.Enabled = gadmin
            .NouveauArticleToolStripMenuItem2.Enabled = gArticle_w
            .NouveauFournisseurToolStripMenuItem.Enabled = gAchat_w
            .NouvelleCommandeToolStripMenuItem2.Enabled = gVente_w
            .NouveauClientToolStripMenuItem1.Enabled = gVente_w
            .CommandeToolStripMenuItem.Enabled = gVente_w
            .RechercheToolStripMenuItem1.Enabled = gAchat_r
            .RechercheToolStripMenuItem.Enabled = gArticle_r
            .StatiToolStripMenuItem.Enabled = gStatistiques
            .JournauxToolStripMenuItem.Enabled = gJournalCaisseUn Or gJournalCaisseDeux

            .TransactionsManuellesSuresLesComptesToolStripMenuItem.Enabled = gTransaction
            .ToolStripStatusLabelPCName.Text = gNomPC
            .ToolStripStatusLabelnumCaisse.Text = " Caisse : " & gNumCaisse

        End With
    End Sub
    Private Sub VerouillageMenuPrincipal()
        With FormPrincipale
            .ToolStripStatusLabelLogin.Text = ""
            .ToolStripStatusLabelProfil.Text = ""
            .ToolStripStatusLabelServerDatabase.Text = ""
            .AchatsToolStripMenuItem.Enabled = False
            .VentesToolStripMenuItem.Enabled = False
            .ArticlesToolStripMenuItem.Enabled = False
            .AdministrationToolStripMenuItem.Enabled = False
            .CommandeToolStripMenuItem.Enabled = False
            .RechercheToolStripMenuItem1.Enabled = False
            .RechercheToolStripMenuItem.Enabled = False
            .StatiToolStripMenuItem.Enabled = False
            .JournauxToolStripMenuItem.Enabled = False
            .TransactionsManuellesSuresLesComptesToolStripMenuItem.Enabled = False
            .ToolStripStatusLabelPCName.Text = ""
            .ToolStripStatusLabelnumCaisse.Text = ""
        End With


    End Sub

    Private Sub CodeBarreTextBox_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles CodeBarreTextBox.Enter
        UsernameTextBox.Clear()
        PasswordTextBox.Clear()
    End Sub

    Private Sub UsernameTextBox_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles UsernameTextBox.Enter, PasswordTextBox.Enter
        CodeBarreTextBox.Clear()
    End Sub

    Private Sub FormIdentification_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        CodeBarreTextBox.Focus()
    End Sub
End Class
