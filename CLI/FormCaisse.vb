Imports Microsoft.PointOfService
Imports System.IO
Imports System.Globalization

Imports System.Data
Imports Microsoft.Reporting.WinForms
Imports System.Net.Mail
Imports CLI.CLIDataSetTableAdapters

Public Class FormCaisse
#Region "Variables form"

    Private vDevisReportComplete As Boolean = False
    Private vFactureReportComplete As Boolean = False
    Private vAvoirReportComplete As Boolean = False
    Private vChequeReportComplete As Boolean = False
    Private vNumeroAvoir As Integer = 0
    Private vCodeClient As Integer = 0
    Private vCodeClientChequeCadeau As Integer = 0
    Private vPrixInitialTTC As Double = 0
    Private vPrixRemiseTTC As Double = 0
    Private vRemise As Double = 0
    Public id_t_commande_vente As Integer = 0
    Dim bs As New BindingSource
    Private CopieFiche As CLIDataSet.T_CommandeVenteRow = Nothing
#End Region

#Region "Formulaire"
    Private Sub FormCaisse_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Try
            m_Display.ClearText()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub FormCaisse_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ' ✅ NF525 : Logger le démarrage du module de caisse (JET obligatoire)
        Try
            LogEventTechnique("DEMARRAGE_CAISSE", "Ouverture du module de caisse", "", "User: " & gLogin & " | Poste: " & Environment.MachineName)
        Catch ex As Exception
            ' Ne pas bloquer le démarrage si le JET échoue
        End Try

        ' ✅ NF525 : Alerte clôtures journalières manquantes au démarrage
        ' Exigence NF525 : détection et signalement des jours avec ventes sans Ticket Z
        Try
            AlerterCloturesManquantes()
        Catch ex As Exception
            ' Ne pas bloquer le démarrage si le contrôle échoue
            Try
                LogEventTechnique("ERREUR_CONTROLE_CLOTURES_DEMARRAGE",
                                  "Erreur contrôle clôtures au démarrage : " & ex.Message, "", "")
            Catch
            End Try
        End Try

        'TODO: cette ligne de code charge les données dans la table 'CLIDataSet.T_MoyenPaiementValide'. Vous pouvez la déplacer ou la supprimer selon les besoins.
        Me.T_MoyenPaiementValideTableAdapter.Fill(Me.CLIDataSet.T_MoyenPaiementValide)

        Me.T_ModeReglementValideTableAdapter.Fill(Me.CLIDataSet.T_ModeReglementValide)
        'TODO : cette ligne de code charge les données dans la table 'CLIDataSet.V_Avoir_client'. Vous pouvez la déplacer ou la supprimer selon vos besoins.
        'Me.V_Avoir_clientTableAdapter.Fill(Me.CLIDataSet.V_Avoir_client)
        'TODO : cette ligne de code charge les données dans la table 'CLIDataSet.V_chequecadeau_client'. Vous pouvez la déplacer ou la supprimer selon vos besoins.
        'Me.V_chequecadeau_clientTableAdapter.Fill(Me.CLIDataSet.V_chequecadeau_client)

        'TODO: This line of code loads data into the 'CLIDataSet.V_reglement' table. You can move, or remove it, as needed.

        'TODO : cette ligne de code charge les données dans la table 'CLIDataSet.T_CommandeVente_Ligne'. Vous pouvez la déplacer ou la supprimer selon vos besoins.


        'TODO : cette ligne de code charge les données dans la table 'CLIDataSet.T_CommandeVente_Ligne'. Vous pouvez la déplacer ou la supprimer selon vos besoins.

        'TODO: This line of code loads data into the 'CLIDataSet.T_CommandeVente_Ligne' table. You can move, or remove it, as needed.
        '  Me.T_CommandeVente_LigneTableAdapter.Fill(Me.CLIDataSet.T_CommandeVente_Ligne)
        'TODO: This line of code loads data into the 'CLIDataSet.T_CommandeVente' table. You can move, or remove it, as needed.
        ' Me.T_CommandeVenteTableAdapter.FillbyID_T_CommandeVente(Me.CLIDataSet.T_CommandeVente)

        'ajout d'un handler pour la case a cocher A_encaisser


        'TODO: This line of code loads data into the 'CLIDataSet.T_modeReglement' table. You can move, or remove it, as needed.
        Me.T_modeReglementTableAdapter.Fill(Me.CLIDataSet.T_modeReglement)
        'TODO : cette ligne de code charge les données dans la table 'CLIDataSet.T_Reglement'. Vous pouvez la déplacer ou la supprimer selon vos besoins.

        NouveauToolStripButton.Enabled = gVente_w
        BT_OuvrirCaisse.Enabled = gVente_w
        'TODO : cette ligne de code charge les données dans la table 'CLIDataSet.V_Avoir_client'. Vous pouvez la déplacer ou la supprimer selon vos besoins.

        'TODO : cette ligne de code charge les données dans la table 'CLIDataSet.T_CommandeVente_Ligne'. Vous pouvez la déplacer ou la supprimer selon vos besoins.
        Me.T_MoyenPaiementTableAdapter.Fill(Me.CLIDataSet.T_MoyenPaiement)
        I_ModeReglement.SelectedIndex = -1

        'TODO : cette ligne de code charge les données dans la table 'CLIDataSet.T_Pays'. Vous pouvez la déplacer ou la supprimer selon vos besoins.
        Me.T_PaysTableAdapter.Fill(Me.CLIDataSet.T_Pays)

        'initialisation des transporteurs
        InitCombo(Id_T_TransporteurComboBox, My.Settings.CLIConnectionString, "select id_t_transporteur,libelle from t_transporteur", "libelle", "", "id_t_transporteur")


        'If vPosPrinterOk Then
        '    vPosPrinterOk = PosPrinterInit()
        'End If

        'If vCashDrawerOk Then
        '    vCashDrawerOk = CashDrawerInit()
        'End If

        'If vAfficheurImprimanteOk Then
        '    vAfficheurImprimanteOk = lineDisplayinit()
        'End If


        'TODO : cette ligne de code charge les données dans la table 'CLIDataSet.T_EtatCommandeVente'. Vous pouvez la déplacer ou la supprimer selon vos besoins.




        If id_t_commande_vente = 0 Then
            ToolStrip2.Visible = False
        Else
            ToolStrip2.Visible = True
        End If

        'villeCP
        Dim vSourceVilleCP As DataTable
        Dim vVilleCP As New AutoCompleteStringCollection
        Dim vCPVille As New AutoCompleteStringCollection
        BT_Enregistrer.Enabled = gVente_w
        vSourceVilleCP = ExecuteRequeteR("select codepostal,ville from t_cpvillefr", My.Settings.CLIConnectionString)

        For Each r As DataRow In vSourceVilleCP.Rows
            vVilleCP.Add(r("ville") & " (" & r("codepostal") & ")")
            vCPVille.Add(r("codepostal") & " (" & r("ville") & ")")
        Next

        VilleTextBox.AutoCompleteCustomSource = vVilleCP
        CodePostalTextBox.AutoCompleteCustomSource = vCPVille


        TabControl1.SelectTab("TabCommande")

        Refresh_data()
        I_Ref.Focus()
        Me.Height = 950


    End Sub


#End Region
#Region "Boutons"
    Private Sub NouveauToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NouveauToolStripButton.Click
        Nouveau()
    End Sub
    Private Sub BT_Plus_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BT_Plus.Click
        If Not AjouterLigne() Then
            MessageBox.Show("Impossible d'ajouter la ligne", "Erreur de saisie", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If

    End Sub
    Private Sub BT_Scan_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BT_Scan.Click
        I_Ref.Focus()
    End Sub
    Private Sub RechercherToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RechercherToolStripMenuItem.Click
        Dim f As New FormArticleRecherche
        f.ShowDialog()
        If f.DialogResult = Windows.Forms.DialogResult.OK Then

            I_Ref.Focus()
            I_Ref.Text = f.vref
            I_Qte.Focus()
        End If
    End Sub


    Private Sub ToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem1.Click
        Dim f As New FormClientRecherche
        f.ShowDialog()
        If f.DialogResult = Windows.Forms.DialogResult.OK Then
            ContextMenuStripClient.SourceControl.Focus()
            ContextMenuStripClient.SourceControl.Text = f.vref
            'CodeClientTextBox.Focus()
            'CodeClientTextBox.Text = f.vref
            If ContextMenuStripClient.SourceControl.Name = "CodeClientTextBox" Then
                NomTextBox.Focus()
                CodeClientTextBox.Focus()
            Else
                I_NomBeneficiaire.Focus()
                I_ChequeCadeauIdClient.Focus()
            End If
        End If
    End Sub

    Private Sub BT_ClearTampon_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BT_ClearTampon.Click
        ClearTampon()
    End Sub
    Private Sub ToolStripButton2_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButtonMoveNext.Click
        Try
            FormCommandeRecherche.bs.MoveNext()
            id_t_commande_vente = FormCommandeRecherche.bs.Current.Item("Ref Commande")
            Refresh_data()
        Catch ex As Exception

        End Try



    End Sub

    Private Sub ToolStripButton1_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButtonMovePrevious.Click
        Try
            FormCommandeRecherche.bs.MovePrevious()
            id_t_commande_vente = FormCommandeRecherche.bs.Current.Item("Ref Commande")
            Refresh_data()
        Catch ex As Exception

        End Try


    End Sub

    Private Sub ToolStripButton3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButtonMoveLast.Click
        Try
            FormCommandeRecherche.bs.MoveLast()
            id_t_commande_vente = FormCommandeRecherche.bs.Current.Item("Ref Commande")
            Refresh_data()
        Catch ex As Exception

        End Try


    End Sub

    Private Sub ToolStripButton4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButtonMovefirst.Click
        Try
            FormCommandeRecherche.bs.MoveFirst()
            id_t_commande_vente = FormCommandeRecherche.bs.Current.Item("Ref Commande")
            Refresh_data()
        Catch ex As Exception

        End Try


    End Sub
    Private Sub BT_Enregistrer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BT_Enregistrer.Click
        'on test les champs obligatoires généraux
        Dim err_msg As String = ""
        Dim vReprise As Boolean = False
        'test s'il y a une reprise
        'on oblige la saisie d'un code client
        For Each r As DataGridViewRow In DataGridViewCommande.Rows
            If r.Cells("ref").Value.ToString = "1" Then
                vReprise = True
                Exit For
            Else
                vReprise = False
            End If
        Next
        If vReprise And (CodeClientTextBox.Text = "" Or CodeClientTextBox.Text = "0") And sender.name = "BT_Enregistrer" Then
            err_msg = err_msg & "- Le code client est obligatoire dans le cas d'une reprise"
        End If
        'If PaysComboBox.Text.Trim = "" Then
        '    err_msg = err_msg & vbCrLf & "- Pays"
        'End If


        If err_msg = "" Then

            Select Case sender.name
                Case "BT_Enregistrer"
                    Enregistrer()

                    'on teste l'état de la commande et si le statut est 10 et qu'il y a eu moins un code reprise on ouvre la fiche du client
                    Dim bReprise As Boolean = False
                    For Each r As DataRow In CLIDataSet.T_CommandeVente_Ligne.Rows
                        If r("id_t_article_version") = 1 Then
                            bReprise = True
                            Exit For
                        End If
                    Next

                    If bReprise Then
                        If T_CommandeVenteBindingSource.Current.item("ID_EtatCommandeVente") = 10 Then

                            'si le client à des depots vente actif
                            If ExecuteRequeteR("select * from t_article_version where active_on=1 and depot_vente=1 and id_t_client =" & CodeClientTextBox.Text, gCnn.ConnectionString).Rows.Count > 0 Then
                                MessageBox.Show("Merci de vérifier s'il y a déjà un matériel correspondant en depot vente, et si oui , procéder aux changements nécessaires", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                                Dim f As New FormClientRecherche
                                f.MdiParent = Me.MdiParent
                                f.Show()
                                f.I_Reference.Text = CodeClientTextBox.Text
                                f.Recherche(False, True, "", "", True)




                            End If


                        End If
                    End If



                Case "BT_Imprimer_Devis"
                    EnregistrerAvCommande(5)
            End Select




            NouveauToolStripButton.Enabled = True


            SupprimerToolStripButton.Enabled = True
            ToolStripButtonMovefirst.Enabled = True
            ToolStripButtonMovePrevious.Enabled = True
            ToolStripButtonMoveNext.Enabled = True
            ToolStripButtonMoveLast.Enabled = True
            ToolStripLabelPosition.Enabled = True
            If id_t_commande_vente = 0 Then
                ToolStrip2.Visible = False
            Else
                ToolStrip2.Visible = True
            End If

            MessageBox.Show("Enregistrement ok", "CLI", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Else
            err_msg = "Merci de saisir les champs obligatoires suivants" & vbCrLf & err_msg
            MessageBox.Show(err_msg, "Attention", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub
    Private Sub BT_Facture_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BT_Facture.Click
        Facture()
    End Sub
    Private Sub BT_EnvoiFacture_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BT_Facture_Envoi.Click
        EnvoiFacture()
    End Sub
    Private Sub BT_Paiement_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Paiement()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BT_RendreLaMonnaie.Click
        RendreLaMonnaie(True)
    End Sub



    Private Sub BT_Basculer_Avoir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BT_Basculer_Avoir.Click
        BasculerAvoir()
    End Sub
    Private Sub BT_Expedier_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BT_SortirStock.Click
        SortirStock()
    End Sub
    Private Sub BT_Ticket_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BT_Ticket.Click
        TicketDeCaisse(True)
    End Sub
    Private Sub BT_AvoirUtilise_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        CheckAvoir()
    End Sub
    Private Sub BT_Etape_Règlement_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BT_Etape_Règlement.Click
        TabControl1.SelectTab(TabReglement)
    End Sub
    Private Sub Button1_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BT_revenir_commande.Click
        TabControl1.SelectTab(TabCommande)
    End Sub
    Private Sub TabControl1_Selected(ByVal sender As Object, ByVal e As System.Windows.Forms.TabControlEventArgs) Handles TabControl1.Selected
        If Not m_Display Is Nothing Then
            Try
                m_Display.ClearText()
                Select Case CType(sender, TabControl).SelectedTab.Name

                    Case "TabReglement"
                        AffSelect()

                End Select
            Catch ex As Exception

            End Try

        End If


    End Sub
    Private Sub BT_AnnulerCommande_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BT_AnnulerCommande.Click
        If MessageBox.Show("Attention, vous êtes sur le point d'annluer une commande/devis. Opération inverse impossible. " & vbCrLf & "Etest-vous sûr de vouloir poursuivre ?", "Attention", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
            AnnulerCommande()
        End If
    End Sub
    Private Sub BT_OuvrirCaisse_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BT_OuvrirCaisse.Click
        OuvertureCaisse()
    End Sub
#End Region
#Region "Champs"
    Private Sub I_TVA_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles I_TVA.Validated
        If I_TVA.Text = "" Then
            I_TVA.Text = "20"

        End If
    End Sub

    Private Sub I_Qte_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles I_Qte.Validated
        If I_Qte.Text = "" And I_Ref.Text <> "" Then
            I_Qte.Text = "1"

        End If
    End Sub
    Private Sub I_Ref_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles I_Ref.KeyPress, I_Designation.KeyPress, I_PuTTC.KeyPress, I_Remise.KeyPress, I_Qte.KeyPress, I_TVA.KeyPress
        If e.KeyChar = vbCr Then
            I_Qte.Focus()
            If Not AjouterLigne() Then
                MessageBox.Show("Impossible d'ajouter la ligne", "Erreur de saisie", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
            I_Ref.Focus()
        End If
    End Sub

    Private Sub I_Ref_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles I_Ref.Validated
        I_NomBeneficiaire.ReadOnly = True
        I_ChequeCadeauIdClient.Visible = False
        I_NomBeneficiaire.Visible = False
        IL_codebenef.Visible = False
        I_ChequeCadeauIdClient.Text = ""
        I_NomBeneficiaire.Text = ""
        I_Qte.ReadOnly = False
        I_PuTTC.ReadOnly = False
        I_Remise.ReadOnly = False
        I_PUTTCRemise.ReadOnly = False

        If I_Designation.Text = "" Then
            Select Case I_Ref.Text
                Case "0"
                    I_Designation.Text = "Divers"
                    I_TVA.Text = 20
                    I_Qte.Text = 0
                    I_PuTTC.Text = 0
                    I_Remise.Text = 0
                    I_PUTTCRemise.Text = 0
                    I_Qte.ReadOnly = True
                    I_PuTTC.ReadOnly = True
                    I_Remise.ReadOnly = True
                    I_PUTTCRemise.ReadOnly = True
                    I_TVA.ReadOnly = True

                Case "1"
                    I_Designation.Text = "Reprise occasion"
                    I_TVA.Text = 0
                Case "2"
                    I_Designation.Text = "Réparation"
                    I_TVA.Text = 20
                Case "3"
                    I_Designation.Text = "Location"
                    I_TVA.Text = 20
                Case "4"
                    I_Designation.Text = "Commission sur dépôt vente / avoir"
                    I_TVA.Text = 20
                Case "5"
                    I_Designation.Text = "Port"
                    I_TVA.Text = 20
                Case "6"
                    I_Designation.Text = "Chèque cadeau"
                    I_TVA.Text = 0
                    I_ChequeCadeauIdClient.Visible = True
                    I_NomBeneficiaire.Visible = True
                    IL_codebenef.Visible = True
            End Select

        End If

    End Sub

    Private Sub I_Ref_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles I_Ref.Validating
        Recup_info(I_Ref.Text, ExportCheckBox.Checked)
    End Sub
    Private Sub RemiseTextBox_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles I_Remise.Enter
        If IsNumeric(sender.text) Then
            vRemise = sender.text
        End If
    End Sub

    Private Sub Prix_vente_remise_TTCTextBox_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles I_PUTTCRemise.Enter
        If IsNumeric(sender.text) Then
            vPrixRemiseTTC = sender.text
        End If
    End Sub



    Private Sub Prix_vente_remise_TTCTextBox_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles I_PUTTCRemise.Validated
        If I_Remise.Text = "" Or I_Remise.Text = "0.00" Or I_Remise.Text = "0" Then
            I_PUTTCRemise.Text = I_PuTTC.Text
        End If
        If IsNumeric(I_PUTTCRemise.Text) Then
            If vPrixRemiseTTC <> I_PUTTCRemise.Text Then
                If IsNumeric(I_PuTTC.Text) Then
                    I_Remise.Text = Math.Round(1 - (I_PUTTCRemise.Text / I_PuTTC.Text), 2)
                End If
            End If
        End If
    End Sub

    Private Sub Prix_vente_initial_TTCTextBox_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles I_PuTTC.Enter
        If IsNumeric(sender.text) Then
            vPrixInitialTTC = sender.text

        End If
    End Sub



    Private Sub Prix_vente_initial_TTCTextBox_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles I_PuTTC.Validated
        If IsNumeric(I_PuTTC.Text) Then
            'If vPrixInitialTTC <> I_PuTTC.Text Then
            If IsNumeric(I_Remise.Text) Then
                I_PUTTCRemise.Text = Math.Round(I_PuTTC.Text * (1 - I_Remise.Text), 2)
            Else
                I_Remise.Text = 0
                I_PUTTCRemise.Text = I_PuTTC.Text
            End If
            'End If
            If I_TVA.Text = "" Then
                I_TVA.Text = "20"
            End If
        End If
    End Sub

    Private Sub RemiseTextBox_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles I_Remise.Validated
        If vRemise.ToString <> I_Remise.Text And IsNumeric(I_Remise.Text) Then
            I_PUTTCRemise.Text = Math.Round(I_PuTTC.Text * (1 - I_Remise.Text), 2)
        Else
            I_Remise.Text = 0
            I_PUTTCRemise.Text = I_PuTTC.Text
        End If
    End Sub
    Private Sub BT_Refresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BT_Refresh.Click
        Refresh_data()
        NouveauToolStripButton.Enabled = gVente_w
        SupprimerToolStripButton.Enabled = True
        ToolStripButtonMovefirst.Enabled = True
        ToolStripButtonMovePrevious.Enabled = True
        ToolStripButtonMoveNext.Enabled = True
        ToolStripButtonMoveLast.Enabled = True
        ToolStripLabelPosition.Enabled = True
    End Sub

    Private Sub AvoirUtiliseNoTextBox_Enter(ByVal sender As Object, ByVal e As System.EventArgs)
        vNumeroAvoir = sender.text
    End Sub

    Private Sub CodeClientTextBox_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles CodeClientTextBox.Enter
        If IsNumeric(sender.text) Then
            vCodeClient = sender.text
        End If
    End Sub
    Private Sub CodeClientTextBox_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles CodeClientTextBox.Validated

        If CodeClientTextBox.Text <> "0" And CInt(CodeClientTextBox.Text) <> vCodeClient Then
            CheckClient(CodeClientTextBox)
            'I_RefAvoir.DataSource = Nothing
            'If Not T_CommandeVenteBindingSource.Current.item("Id_t_client") Is DBNull.Value Then

            'InitCombo(I_RefAvoir, My.Settings.CLIConnectionString, "Select id_t_avoir as id,convert(varchar(225),id_t_avoir) + ' - ' + convert(varchar(225),montant) + ' €' as libelle from t_avoir where utilisele is null and id_t_client=" & T_CommandeVenteBindingSource.Current.item("Id_t_client"), "libelle", "<Choisir>", "id")


            '        End If
        End If
    End Sub

    'Private Sub AvoirUtiliseNoTextBox_Validated(ByVal sender As Object, ByVal e As System.EventArgs)
    '    If AvoirUtiliseNoTextBox.Text <> "0" And CInt(AvoirUtiliseNoTextBox.Text) <> vNumeroAvoir Then
    '        CheckAvoir()
    '    End If
    'End Sub
    Private Sub BT_ImprimerAvoir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BT_ImprimerAvoir.Click

        ImprimerAvoir()
    End Sub

    Private Sub FactureReportViewer_RenderingBegin(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles FactureReportViewer.RenderingBegin
        vFactureReportComplete = False
    End Sub

    Private Sub FactureReportViewer_RenderingComplete(ByVal sender As Object, ByVal e As Microsoft.Reporting.WinForms.RenderingCompleteEventArgs) Handles FactureReportViewer.RenderingComplete
        vFactureReportComplete = True
    End Sub

    Private Sub AvoirReportViewer_RenderingBegin(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles AvoirReportViewer.RenderingBegin
        vAvoirReportComplete = False
    End Sub
    Private Sub AvoirReportViewer_RenderingComplete(ByVal sender As Object, ByVal e As Microsoft.Reporting.WinForms.RenderingCompleteEventArgs) Handles AvoirReportViewer.RenderingComplete
        vAvoirReportComplete = True
    End Sub
    Private Sub ChequeReportViewer_RenderingBegin(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles ChequeCadeauReportViewer.RenderingBegin
        vChequeReportComplete = False
    End Sub
    Private Sub ChequeReportViewer_RenderingComplete(ByVal sender As Object, ByVal e As Microsoft.Reporting.WinForms.RenderingCompleteEventArgs) Handles ChequeCadeauReportViewer.RenderingComplete
        vChequeReportComplete = True
    End Sub

#End Region
#Region "Dgview"
    Private Sub DataGridViewCommande_UserDeletedRow(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowEventArgs) Handles DataGridViewCommande.UserDeletedRow
        CalculTotal()
        Try
            MajDisplay("", "", I_TotalTTC.Text & " Euros")

        Catch ex As Exception

        End Try

    End Sub
#End Region
#Region "Procédures"
    Sub AffSelect()
        'Affichage A regler, rendu ou autre selon le cas
        Select Case T_CommandeVenteBindingSource.Current.item("ID_EtatCommandeVente").ToString
            Case "10"
                AffAPayer()
            Case "15"
                AffARendre()
            Case "20"
                AffMerci()
            Case "25"
                AffMerci()
            Case "30"
                AffMerci()
            Case "40"
                AffMerci()
            Case "90"
                AffAnnule()
            Case ""

        End Select
    End Sub
    Sub AnnulerCommande()
        'changement de l'état
        T_CommandeVenteBindingSource.Current.item("ID_EtatCommandeVente") = 90
        'annulation de l'avoir cree
        DestructionAutoAvoir()
        'annulation de l'utilisation de l'avoir
        ResetAvoir()
        'Enregistrement dans la table
        Enregistrer()
    End Sub
    Sub OuvertureCaisse()
        'Ouverture du tiroir
        If Not m_Drawer Is Nothing Then
            Try
                If Not m_Drawer.DrawerOpened Then
                    m_Drawer.OpenDrawer()
                End If
            Catch ex As Exception

            End Try
        End If
    End Sub
    Sub RendreLaMonnaie(Optional ByRef ouvertureTiroir = False)
        If ouvertureTiroir Then
            OuvertureCaisse()
        End If
        T_CommandeVenteBindingSource.Current.item("MontantRenduTTC") = T_CommandeVenteBindingSource.Current.item("MontantARendreTTC")

        'on enregistre la date
        T_CommandeVenteBindingSource.Current.item("RenduLe") = Now()
        'changement de l'état
        If T_CommandeVenteBindingSource.Current.item("ID_EtatCommandeVente") < 20 Then
            T_CommandeVenteBindingSource.Current.item("ID_EtatCommandeVente") = 20
        End If

        T_CommandeVenteBindingSource.EndEdit()
        'Enregistrement dans la table
        Enregistrer()

        TicketDeCaisse()

    End Sub
    Sub AffichageVerouillage()

        Select Case T_CommandeVenteBindingSource.Current.item("ID_EtatCommandeVente").ToString
            Case "4"
                BT_Imprimer_test.FlatStyle = FlatStyle.Flat
                BT_Imprimer_devis.FlatStyle = FlatStyle.Standard
                BT_Imprimer_reservation.FlatStyle = FlatStyle.Standard
                BT_Enregistrer.FlatStyle = FlatStyle.Standard
            Case "5"
                BT_Imprimer_test.FlatStyle = FlatStyle.Standard
                BT_Imprimer_devis.FlatStyle = FlatStyle.Flat
                BT_Imprimer_reservation.FlatStyle = FlatStyle.Standard
                BT_Enregistrer.FlatStyle = FlatStyle.Standard
            Case "6"
                BT_Imprimer_test.FlatStyle = FlatStyle.Standard
                BT_Imprimer_devis.FlatStyle = FlatStyle.Standard
                BT_Imprimer_reservation.FlatStyle = FlatStyle.Flat
                BT_Enregistrer.FlatStyle = FlatStyle.Standard
            Case Else
                BT_Imprimer_test.FlatStyle = FlatStyle.Standard
                BT_Imprimer_devis.FlatStyle = FlatStyle.Standard
                BT_Imprimer_reservation.FlatStyle = FlatStyle.Standard
                BT_Enregistrer.FlatStyle = FlatStyle.Flat
        End Select

        Select Case T_CommandeVenteBindingSource.Current.item("ID_EtatCommandeVente").ToString




            'prêt,devis,reservation
            Case "4", "5", "6"

                'tabcommande

                BT_Scan.Enabled = gVente_w
                BT_Enregistrer.Enabled = gVente_w
                BT_AnnulerCommande.Enabled = gVente_w
                BT_Etape_Règlement.Enabled = False



                'entete client
                If gVente_w Then
                    VerDever(EnteteGroupBox, False, True)
                Else
                    VerDever(EnteteGroupBox, True, True)
                End If

                'dgview
                ' ✅ NF525 : Interdire suppression de lignes
                DataGridViewCommande.AllowUserToDeleteRows = False
                'ajout de ligne
                If gVente_w Then
                    VerDever(GroupBoxAjout, False, True)
                Else
                    VerDever(GroupBoxAjout, True, True)
                End If

                'tabreglement
                'paiement
                VerDever(PaiementGroupBox, True, True)
                Moyenpaiement.ReadOnly = True

                VerDever(GroupBoxAjoutReglement, True, True)
                'rendu
                VerDever(RenduGroupBox, True, True)
                'ticket de caisse  / facture
                VerDever(TicketFactureGroupBox, True, True)
                'Sortie stock
                VerDever(SortieStockGroupBox, True, True)
                'expedition
                VerDever(ExpeditionGroupBox, True, True)


                BT_BL.Enabled = False

            Case "10"

                'tabcommande
                BT_Imprimer_test.Enabled = False
                BT_Imprimer_devis.Enabled = False
                BT_Imprimer_reservation.Enabled = False


                BT_Scan.Enabled = gVente_w
                BT_Enregistrer.Enabled = gVente_w
                BT_AnnulerCommande.Enabled = gVente_w
                BT_Etape_Règlement.Enabled = gVente_w
                'entete client
                If gVente_w Then
                    VerDever(EnteteGroupBox, False, True)
                Else
                    VerDever(EnteteGroupBox, True, True)
                End If

                'dgview
                ' ✅ NF525 : Interdire suppression de lignes
                DataGridViewCommande.AllowUserToDeleteRows = False
                T_ReglementDataGridView.AllowUserToDeleteRows = False
                'ajout de ligne
                If gVente_w Then
                    VerDever(GroupBoxAjout, False, True)
                Else
                    VerDever(GroupBoxAjout, True, True)
                End If

                'tabreglement
                'paiement
                If gVente_w Then
                    VerDever(PaiementGroupBox, False, True)
                    Moyenpaiement.ReadOnly = False
                    ' Moyenpaiement.ReadOnly = True
                    'Conditionreglement.ReadOnly = True
                    'Montant.ReadOnly = True
                    'Echeancele.ReadOnly = True
                    'Encaissele.ReadOnly = True
                    'Enregistrele.ReadOnly = True
                    'T_ReglementDataGridView.AllowUserToDeleteRows = True


                    If gWebCaisse = 1 Then
                        BT_Paiement.Enabled = False
                    End If
                    VerDever(GroupBoxAjoutReglement, False, True)
                    I_ModeReglement.Enabled = False
                    I_RefAvoir.Enabled = False
                    I_encaisse.Enabled = False
                    I_montantReglement.ReadOnly = True
                    I_echeanceLe.ReadOnly = True
                Else
                    VerDever(PaiementGroupBox, True, True)
                    Moyenpaiement.ReadOnly = True
                    VerDever(GroupBoxAjoutReglement, True, True)
                End If

                'rendu
                VerDever(RenduGroupBox, True, True)

                'ticket de caisse  / facture

                VerDever(TicketFactureGroupBox, True, True)

                'Sortie stock
                VerDever(SortieStockGroupBox, True, True)
                'expedition
                VerDever(ExpeditionGroupBox, True, True)

                BT_BL.Enabled = True




            Case "12", "13", "15"
                'tabcommande
                BT_Imprimer_test.Enabled = False
                BT_Imprimer_devis.Enabled = False
                BT_Imprimer_reservation.Enabled = False

                BT_Scan.Enabled = False
                BT_Enregistrer.Enabled = False
                BT_AnnulerCommande.Enabled = gVente_w
                BT_Etape_Règlement.Enabled = gVente_w
                'entete client
                If gVente_w Then
                    VerDever(EnteteGroupBox, False, True)
                Else
                    VerDever(EnteteGroupBox, True, True)
                End If
                'dgview
                DataGridViewCommande.AllowUserToDeleteRows = False
                ' ✅ NF525 : Interdire suppression de lignes
                T_ReglementDataGridView.AllowUserToDeleteRows = False
                'ajout de ligne
                VerDever(GroupBoxAjout, True, True)

                'tabreglement
                'paiement
                VerDever(PaiementGroupBox, True, True)
                Moyenpaiement.ReadOnly = True
                'Conditionreglement.ReadOnly = True
                'Montant.ReadOnly = True
                'Echeancele.ReadOnly = True
                'Encaissele.ReadOnly = True
                'Enregistrele.ReadOnly = True
                'T_ReglementDataGridView.AllowUserToDeleteRows = False
                If Math.Round(T_CommandeVenteBindingSource.Current.item("MontantPaiementTTC"), 2) = Math.Round(T_CommandeVenteBindingSource.Current.item("MontantEncaisseTTC"), 2) And Math.Round(T_CommandeVenteBindingSource.Current.item("MontantPaiementTTC"), 2) >= Math.Round(T_CommandeVenteBindingSource.Current.item("Total_TTC"), 2) Then
                    BT_Paiement.Enabled = False
                    VerDever(GroupBoxAjoutReglement, True, True)
                Else

                    BT_Paiement.Enabled = IIf(gWebCaisse = 1, False, True)
                    'BT_Paiement.Enabled = True
                    If gWebCaisse = 1 Then
                        VerDever(GroupBoxAjoutReglement, True, True)
                    Else
                        VerDever(GroupBoxAjoutReglement, False, True)
                    End If

                    I_ModeReglement.Enabled = False
                    I_RefAvoir.Enabled = False
                    I_encaisse.Enabled = False
                    I_montantReglement.ReadOnly = True
                    I_echeanceLe.ReadOnly = True
                End If
                'rendu
                VerDever(RenduGroupBox, True, False)
                If gWebCaisse = 0 Then
                    If gVente_w Then
                        VerDever(RenduGroupBox, False, False)
                    Else
                        VerDever(RenduGroupBox, True, False)
                    End If
                End If

                BT_Basculer_Avoir.Enabled = IIf(gWebCaisse = 1, False, gVente_w)
                BT_RendreLaMonnaie.Enabled = IIf(gWebCaisse = 1, False, gVente_w)
                'BT_Basculer_Avoir.Enabled = gVente_w
                'BT_RendreLaMonnaie.Enabled = gVente_w
                BT_ImprimerAvoir.Enabled = False
                'ticket de caisse  / facture
                VerDever(TicketFactureGroupBox, True, True)
                'Sortie stock
                VerDever(SortieStockGroupBox, True, True)
                'expedition
                VerDever(ExpeditionGroupBox, True, True)
                BT_BL.Enabled = True
            Case "20"
                'tabcommande
                BT_Imprimer_test.Enabled = False
                BT_Imprimer_devis.Enabled = False
                BT_Imprimer_reservation.Enabled = False
                BT_Scan.Enabled = False
                BT_Enregistrer.Enabled = gVente_w
                BT_AnnulerCommande.Enabled = gVente_w
                BT_Etape_Règlement.Enabled = gVente_w


                'entete client
                If gVente_w Then
                    VerDever(EnteteGroupBox, False, True)
                    I_ModeReglement.Enabled = False
                    I_RefAvoir.Enabled = False
                    I_encaisse.Enabled = False
                    I_montantReglement.ReadOnly = True
                    I_echeanceLe.ReadOnly = True
                    'Moyenpaiement.ReadOnly = True
                    'Conditionreglement.ReadOnly = True
                    'Montant.ReadOnly = True
                    'Echeancele.ReadOnly = True
                    'Enregistrele.ReadOnly = True
                    'T_ReglementDataGridView.AllowUserToDeleteRows = False
                Else
                    VerDever(EnteteGroupBox, True, True)
                End If

                'dgview
                DataGridViewCommande.AllowUserToDeleteRows = False
                ' ✅ NF525 : Interdire suppression de lignes
                T_ReglementDataGridView.AllowUserToDeleteRows = False
                'ajout de ligne
                VerDever(GroupBoxAjout, True, True)

                'tabreglement
                'paiement
                VerDever(PaiementGroupBox, True, True)
                Moyenpaiement.ReadOnly = True
                ' Moyenpaiement.ReadOnly = True
                'Conditionreglement.ReadOnly = True
                'Montant.ReadOnly = True
                'Echeancele.ReadOnly = True
                'Encaissele.ReadOnly = True
                'T_ReglementDataGridView.AllowUserToDeleteRows = False
                If Math.Round(T_CommandeVenteBindingSource.Current.item("MontantPaiementTTC"), 2) = Math.Round(T_CommandeVenteBindingSource.Current.item("MontantEncaisseTTC"), 2) And Math.Round(T_CommandeVenteBindingSource.Current.item("MontantPaiementTTC"), 2) >= Math.Round(T_CommandeVenteBindingSource.Current.item("Total_TTC"), 2) Then
                    BT_Paiement.Enabled = False
                    VerDever(GroupBoxAjoutReglement, True, True)
                Else
                    BT_Paiement.Enabled = True
                    VerDever(GroupBoxAjoutReglement, False, True)
                End If
                'rendu
                VerDever(RenduGroupBox, True, False)
                If T_CommandeVenteBindingSource.Current.item("MontantARendreTTC") <> T_CommandeVenteBindingSource.Current.item("MontantRenduTTC") And T_CommandeVenteBindingSource.Current.item("AvoirCreeNo") = 0 Then
                    BT_Basculer_Avoir.Enabled = True
                    BT_RendreLaMonnaie.Enabled = True
                Else
                    BT_Basculer_Avoir.Enabled = False
                    BT_RendreLaMonnaie.Enabled = False
                End If

                BT_ImprimerAvoir.Enabled = gVente_w
                BT_Ticket.Enabled = gVente_w
                'ticket de caisse  / facture
                If gVente_w Then
                    VerDever(TicketFactureGroupBox, False, False)
                Else
                    VerDever(TicketFactureGroupBox, True, False)
                    I_ModeReglement.Enabled = False
                    I_RefAvoir.Enabled = False
                    I_encaisse.Enabled = False
                    I_montantReglement.ReadOnly = True
                    I_echeanceLe.ReadOnly = True
                    'Enregistrele.ReadOnly = True
                End If
                BT_Ticket.Enabled = gVente_w
                BT_Facture.Enabled = False
                BT_Facture_Envoi.Enabled = False
                'Sortie stock
                VerDever(SortieStockGroupBox, True, True)
                'expedition
                VerDever(ExpeditionGroupBox, True, True)
                BT_BL.Enabled = True
            Case "25"
                'tabcommande
                BT_Imprimer_test.Enabled = False
                BT_Imprimer_devis.Enabled = False
                BT_Imprimer_reservation.Enabled = False
                BT_Scan.Enabled = False
                BT_Enregistrer.Enabled = gVente_w
                BT_AnnulerCommande.Enabled = gVente_w
                BT_Etape_Règlement.Enabled = gVente_w

                'entete client
                If gVente_w Then
                    VerDever(EnteteGroupBox, False, True)
                Else
                    VerDever(EnteteGroupBox, True, True)
                End If
                'dgview
                DataGridViewCommande.AllowUserToDeleteRows = False
                ' ✅ NF525 : Interdire suppression de lignes
                T_ReglementDataGridView.AllowUserToDeleteRows = False
                'ajout de ligne
                VerDever(GroupBoxAjout, True, True)

                'tabreglement
                'paiement
                VerDever(PaiementGroupBox, True, True)
                Moyenpaiement.ReadOnly = False
                'Moyenpaiement.ReadOnly = True
                'Conditionreglement.ReadOnly = True
                'Montant.ReadOnly = True
                'Echeancele.ReadOnly = True
                'Encaissele.ReadOnly = True
                'Enregistrele.ReadOnly = True
                'T_ReglementDataGridView.AllowUserToDeleteRows = False
                If Math.Round(T_CommandeVenteBindingSource.Current.item("MontantPaiementTTC"), 2) = Math.Round(T_CommandeVenteBindingSource.Current.item("MontantEncaisseTTC"), 2) And Math.Round(T_CommandeVenteBindingSource.Current.item("MontantPaiementTTC"), 2) >= Math.Round(T_CommandeVenteBindingSource.Current.item("Total_TTC"), 2) Then
                    BT_Paiement.Enabled = False
                    VerDever(GroupBoxAjoutReglement, True, True)
                Else
                    BT_Paiement.Enabled = True
                    VerDever(GroupBoxAjoutReglement, False, True)
                    I_ModeReglement.Enabled = False
                    I_RefAvoir.Enabled = False
                    I_encaisse.Enabled = False
                    I_montantReglement.ReadOnly = True
                    I_echeanceLe.ReadOnly = True
                End If
                'rendu
                VerDever(RenduGroupBox, True, False)
                If T_CommandeVenteBindingSource.Current.item("MontantARendreTTC") <> T_CommandeVenteBindingSource.Current.item("MontantRenduTTC") And T_CommandeVenteBindingSource.Current.item("AvoirCreeNo") = 0 Then
                    BT_Basculer_Avoir.Enabled = True
                    BT_RendreLaMonnaie.Enabled = True
                Else
                    BT_Basculer_Avoir.Enabled = False
                    BT_RendreLaMonnaie.Enabled = False
                End If
                BT_ImprimerAvoir.Enabled = gVente_w
                'ticket de caisse  / facture
                If gVente_w Then
                    VerDever(TicketFactureGroupBox, False, True)
                Else
                    VerDever(TicketFactureGroupBox, True, True)
                End If
                'Sortie de stock
                If gVente_w Then
                    VerDever(SortieStockGroupBox, False, True)
                Else
                    VerDever(SortieStockGroupBox, True, True)
                End If

                'expedition
                VerDever(ExpeditionGroupBox, True, True)

                BT_BL.Enabled = True
            Case "30"
                'tabcommande
                BT_Imprimer_test.Enabled = False
                BT_Imprimer_devis.Enabled = False
                BT_Imprimer_reservation.Enabled = False
                BT_Scan.Enabled = False
                BT_Enregistrer.Enabled = gVente_w
                BT_AnnulerCommande.Enabled = False
                BT_Etape_Règlement.Enabled = gVente_w

                'entete client
                VerDever(EnteteGroupBox, True, True)
                'dgview
                DataGridViewCommande.AllowUserToDeleteRows = False
                ' ✅ NF525 : Interdire suppression de lignes
                T_ReglementDataGridView.AllowUserToDeleteRows = False
                'ajout de ligne
                VerDever(GroupBoxAjout, True, True)

                'tabreglement
                'paiement
                VerDever(PaiementGroupBox, True, True)
                Moyenpaiement.ReadOnly = False
                ' Moyenpaiement.ReadOnly = True
                ' Conditionreglement.ReadOnly = True
                ' Montant.ReadOnly = True
                ' Echeancele.ReadOnly = True
                ' Encaissele.ReadOnly = True
                ' Enregistrele.ReadOnly = True
                ' T_ReglementDataGridView.AllowUserToDeleteRows = False
                If Math.Round(T_CommandeVenteBindingSource.Current.item("MontantPaiementTTC"), 2) = Math.Round(T_CommandeVenteBindingSource.Current.item("MontantEncaisseTTC"), 2) And Math.Round(T_CommandeVenteBindingSource.Current.item("MontantPaiementTTC"), 2) >= Math.Round(T_CommandeVenteBindingSource.Current.item("Total_TTC"), 2) Then
                    BT_Paiement.Enabled = False
                    VerDever(GroupBoxAjoutReglement, True, True)
                Else
                    BT_Paiement.Enabled = True
                    VerDever(GroupBoxAjoutReglement, False, True)
                    I_ModeReglement.Enabled = False
                    I_RefAvoir.Enabled = False
                    I_encaisse.Enabled = False
                    I_montantReglement.ReadOnly = True
                    I_echeanceLe.ReadOnly = True
                End If
                'rendu
                VerDever(RenduGroupBox, True, False)
                If T_CommandeVenteBindingSource.Current.item("MontantARendreTTC") <> T_CommandeVenteBindingSource.Current.item("MontantRenduTTC") And T_CommandeVenteBindingSource.Current.item("AvoirCreeNo") = 0 Then
                    BT_Basculer_Avoir.Enabled = True
                    BT_RendreLaMonnaie.Enabled = True
                Else
                    BT_Basculer_Avoir.Enabled = False
                    BT_RendreLaMonnaie.Enabled = False
                End If
                BT_ImprimerAvoir.Enabled = gVente_w
                'ticket de caisse  / facture
                If gVente_w Then
                    VerDever(TicketFactureGroupBox, False, True)
                Else
                    VerDever(TicketFactureGroupBox, True, True)
                End If
                'Sorti de stock
                If gVente_w Then
                    VerDever(SortieStockGroupBox, False, True)
                    Commentaires_factureTextBox.ReadOnly = Not gVente_w
                Else
                    VerDever(SortieStockGroupBox, True, True)
                End If
                'expedition
                VerDever(ExpeditionGroupBox, True, True)

                BT_BL.Enabled = True
            Case "40", "45"
                'tabcommande
                BT_Imprimer_test.Enabled = False
                BT_Imprimer_devis.Enabled = False
                BT_Imprimer_reservation.Enabled = False
                BT_Scan.Enabled = False
                BT_Enregistrer.Enabled = False
                BT_AnnulerCommande.Enabled = False
                BT_Etape_Règlement.Enabled = gVente_w


                'entete client
                If T_CommandeVenteBindingSource.Current.item("FactureLe").ToString = "" Then
                    'entete client
                    VerDever(EnteteGroupBox, False, True)
                Else
                    VerDever(EnteteGroupBox, True, True)
                End If

                'dgview
                DataGridViewCommande.AllowUserToDeleteRows = False
                ' ✅ NF525 : Interdire suppression de lignes
                T_ReglementDataGridView.AllowUserToDeleteRows = False
                'ajout de ligne
                VerDever(GroupBoxAjout, True, True)

                'tabreglement
                'paiement
                VerDever(PaiementGroupBox, True, True)
                Moyenpaiement.ReadOnly = False
                ' Moyenpaiement.ReadOnly = True
                ' Conditionreglement.ReadOnly = True
                ' Montant.ReadOnly = True
                ' Echeancele.ReadOnly = True
                ' Encaissele.ReadOnly = True
                ' Enregistrele.ReadOnly = True
                ' T_ReglementDataGridView.AllowUserToDeleteRows = False
                If Math.Round(T_CommandeVenteBindingSource.Current.item("MontantPaiementTTC"), 2) = Math.Round(T_CommandeVenteBindingSource.Current.item("MontantEncaisseTTC"), 2) And Math.Round(T_CommandeVenteBindingSource.Current.item("MontantPaiementTTC"), 2) >= Math.Round(T_CommandeVenteBindingSource.Current.item("Total_TTC"), 2) Then
                    BT_Paiement.Enabled = False
                    VerDever(GroupBoxAjoutReglement, True, True)
                Else
                    BT_Paiement.Enabled = True
                    VerDever(GroupBoxAjoutReglement, False, True)
                    I_ModeReglement.Enabled = False
                    I_RefAvoir.Enabled = False
                    I_encaisse.Enabled = False
                    I_montantReglement.ReadOnly = True
                    I_echeanceLe.ReadOnly = True
                End If


                'rendu
                VerDever(RenduGroupBox, True, False)
                If T_CommandeVenteBindingSource.Current.item("MontantARendreTTC") <> T_CommandeVenteBindingSource.Current.item("MontantRenduTTC") And T_CommandeVenteBindingSource.Current.item("AvoirCreeNo") = 0 Then
                    BT_Basculer_Avoir.Enabled = True
                    BT_RendreLaMonnaie.Enabled = True
                Else
                    BT_Basculer_Avoir.Enabled = False
                    BT_RendreLaMonnaie.Enabled = False
                End If
                BT_ImprimerAvoir.Enabled = gVente_w
                'ticket de caisse  / facture
                VerDever(TicketFactureGroupBox, True, False)
                BT_Facture.Enabled = gVente_w
                BT_Facture_Envoi.Enabled = gVente_w
                'BT_Ticket.Enabled = gVente_w
                BT_Ticket.Enabled = IIf(gWebCaisse = 1, False, gVente_w)
                Commentaires_factureTextBox.ReadOnly = Not gVente_w
                'Sortie de stock
                VerDever(SortieStockGroupBox, True, True)
                BT_ImprimerChequeCadeau.Enabled = True
                'expedition
                If I_Web.CheckState = CheckState.Checked Or I_Vpc_on.CheckState = CheckState.Checked Then
                    VerDever(ExpeditionGroupBox, False, True)
                    If T_CommandeVenteBindingSource.Current.item("ID_EtatCommandeVente").ToString = 45 Then
                        BT_ReExpedier.Enabled = True
                    Else
                        BT_ReExpedier.Enabled = False

                    End If
                Else
                    VerDever(ExpeditionGroupBox, True, True)
                End If

                BT_BL.Enabled = True





            Case "90"
                'tabcommande
                BT_Imprimer_test.Enabled = False
                BT_Imprimer_devis.Enabled = False
                BT_Imprimer_reservation.Enabled = False


                BT_Scan.Enabled = False
                BT_Enregistrer.Enabled = False
                BT_AnnulerCommande.Enabled = False
                BT_Etape_Règlement.Enabled = False
                'entete client
                VerDever(EnteteGroupBox, True, True)
                'dgview
                DataGridViewCommande.AllowUserToDeleteRows = False
                'ajout de ligne
                VerDever(GroupBoxAjout, True, True)

                'tabreglement
                'paiement
                VerDever(PaiementGroupBox, True, True)
                Moyenpaiement.ReadOnly = True
                VerDever(GroupBoxAjoutReglement, True, True)
                'rendu
                VerDever(RenduGroupBox, True, True)
                'ticket de caisse  / facture
                VerDever(TicketFactureGroupBox, True, True)
                'expedition
                VerDever(SortieStockGroupBox, True, True)


            Case Else
                'tabcommande

                BT_Scan.Enabled = gVente_w
                BT_Enregistrer.Enabled = gVente_w
                BT_AnnulerCommande.Enabled = False
                BT_Etape_Règlement.Enabled = False

                'entete client
                If gVente_w Then
                    VerDever(EnteteGroupBox, False, True)
                Else
                    VerDever(EnteteGroupBox, True, True)
                End If

                'dgview
                ' ✅ NF525 : Interdire suppression de lignes
                DataGridViewCommande.AllowUserToDeleteRows = False
                'ajout de ligne
                If gVente_w Then
                    VerDever(GroupBoxAjout, False, True)
                Else
                    VerDever(GroupBoxAjout, True, True)
                End If

                'tabreglement
                'paiement
                VerDever(PaiementGroupBox, True, True)
                Moyenpaiement.ReadOnly = True
                VerDever(GroupBoxAjoutReglement, True, True)
                'rendu
                VerDever(RenduGroupBox, True, True)
                'ticket de caisse  / facture
                VerDever(TicketFactureGroupBox, True, True)
                'Sortir des stock
                VerDever(SortieStockGroupBox, True, True)
                'expedition
                VerDever(ExpeditionGroupBox, True, True)

                BT_Envoi_etat_commande.Enabled = False
                BT_Imprimer.Enabled = False
                BT_BL.Enabled = False
        End Select
        BT_Etiquette.Enabled = True
        I_Vpc_on.Enabled = True


    End Sub
    Sub VerDever(ByVal gbconteneur As GroupBox, ByVal verrou As Boolean, ByVal boutons As Boolean)
        Dim c As Control
        For Each c In gbconteneur.Controls
            If c.Tag <> "1" Then
                If TypeOf c Is TextBox Then
                    CType(c, TextBox).ReadOnly = verrou
                End If
                If TypeOf c Is ComboBox Then
                    CType(c, ComboBox).Enabled = Not verrou
                End If
                If TypeOf c Is CheckBox Then
                    CType(c, CheckBox).Enabled = Not verrou
                End If
                If boutons Then
                    If TypeOf c Is Button Then
                        CType(c, Button).Enabled = Not verrou
                    End If
                End If
            End If
        Next
    End Sub

    Sub ImprimerAvoir()

        If (T_CommandeVenteBindingSource.Current.item("AvoirCreeNo").ToString <> "" And T_CommandeVenteBindingSource.Current.item("AvoirCreeNo").ToString <> "0") Then
            Refresh_data()

            Do While Not vAvoirReportComplete
                Application.DoEvents()
            Loop

            AvoirReportViewer.PrintDialog()
        Else
            MessageBox.Show("Pas d'avoir à imprimer", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub

    Sub ImprimerChequeCadeau()

        '  If (T_CommandeVenteBindingSource.Current.item("AvoirCreeNo").ToString <> "" And T_CommandeVenteBindingSource.Current.item("AvoirCreeNo").ToString <> "0") Then
        Refresh_data()

        Dim s As New ReportDataSource



        For Each r As CLIDataSet.V_chequecadeau_clientRow In Me.CLIDataSet.V_chequecadeau_client.Rows


            ChequeCadeauReportViewer.LocalReport.DataSources.Clear()
            s.Name = "CLIDataSet_V_chequecadeau_client"
            s.Value = Me.CLIDataSet.V_chequecadeau_client.Select("id_t_avoir=" & r.ID_T_Avoir)
            ChequeCadeauReportViewer.LocalReport.DataSources.Add(s)

            ChequeCadeauReportViewer.RefreshReport()
            Do While Not vChequeReportComplete
                Application.DoEvents()
            Loop

            ChequeCadeauReportViewer.PrintDialog()

        Next
        'Else
        'MessageBox.Show("Pas d'avoir à imprimer", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        'End If
    End Sub


    Sub BasculerAvoir()
        Dim T_avoirTableAdapter As New CLIDataSetTableAdapters.T_AvoirTableAdapter
        Dim T_avoir As New CLIDataSet.T_AvoirDataTable
        Dim T_avoirRow As CLIDataSet.T_AvoirRow
        Dim i As Integer

        If Not CheckClientAvoir() Then
            Exit Sub
        End If


        'Vérification  que le montant à rendre est > 0 et que le montant rendu =

        If (Math.Round(CDbl(T_CommandeVenteBindingSource.Current.item("MontantARendreTTC")), 2) > 0) Then

            'basculement de l'avoir
            T_avoirRow = T_avoir.NewT_AvoirRow
            T_avoirRow.ID_T_Client = CodeClientTextBox.Text
            T_avoirRow.ID_T_CommandeVente = id_t_commande_vente
            T_avoirRow.Montant = MontantARendreTTCTextBox.Text
            T_avoirRow.Commentaire = "Avoir commande vente"


            T_avoir.AddT_AvoirRow(T_avoirRow)
            T_avoirTableAdapter.Update(T_avoir)
            T_avoirTableAdapter.FillByid_t_commandevente(T_avoir, id_t_commande_vente)




            'montant à rendre = 0
            'T_CommandeVenteBindingSource.Current.item("MontantARendreTTC") = 0
            'id avoir
            T_CommandeVenteBindingSource.Current.item("AvoirCreeNo") = T_avoir(T_avoir.Rows.Count - 1).ID_T_Avoir
            'on enregistre la date
            T_CommandeVenteBindingSource.Current.item("RenduLe") = Now()
            'changement de l'état
            If T_CommandeVenteBindingSource.Current.item("ID_EtatCommandeVente") < 20 Then
                T_CommandeVenteBindingSource.Current.item("ID_EtatCommandeVente") = 20
            End If

            T_CommandeVenteBindingSource.EndEdit()
            'Enregistrement dans la table
            Enregistrer()
            ImprimerAvoir()

            TicketDeCaisse()
        Else
            MessageBox.Show("Rien à basculer en avoir", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If

    End Sub
    Sub SynchroAvoir()
        'on synchronise les avoirs du client dans prestashop si client prestashop
        'on regarde si c'est un client prestashop et qu'il faut le synchroniser
        Dim dt As DataTable = ExecuteRequeteR("select isnull(toSync,0) as toSync from t_client where id_t_client=" & T_CommandeVenteBindingSource.Current.item("id_t_client") & "", gCnn.ConnectionString)
        If dt.Rows.Count >= 1 Then
            If dt.Rows(0)("tosync") Then
                CliApi.CustomerAddOrUpdateAvoirPSfromCLIByIdAsync(New ToCliDto With {.Id = T_CommandeVenteBindingSource.Current.item("id_t_client")})

            End If

        End If

    End Sub
    Sub Paiement()
        Dim T_avoirTableAdapter As New CLIDataSetTableAdapters.T_AvoirTableAdapter
        Dim T_avoir As New CLIDataSet.T_AvoirDataTable
        Dim reponse As DialogResult = Windows.Forms.DialogResult.Yes
        'Vérification  que le montant de paiement TTC<> montant encaisse et que le montant epaiement> total à payer : erreur car on ne pourra pas rendre la monnaie en plusieurs fois
        T_CommandeVenteBindingSource.EndEdit()
        T_ReglementDataGridView.EndEdit()
        If T_ReglementDataGridView.Rows.Count = 0 Then
            MessageBox.Show("Il n'y a pas de paiement ni d'échéance enregistré  !", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        Else
            'If CDbl(MontantPaiementTTCTextBox.Text) > CDbl(montantEncaisseTextbox.Text) And CDbl(MontantPaiementTTCTextBox.Text) > CDbl(TotalAPayerTextBox.Text) Then
            If MontantARendreTTCTextBox.Text > 0 And CDbl(MontantPaiementTTCTextBox.Text) > CDbl(TotalAPayerTextBox.Text) Then
                ' If RenduLeTextBox.Text <> "" And CDbl(MontantPaiementTTCTextBox.Text) > CDbl(TotalAPayerTextBox.Text) Then

                MessageBox.Show("Le montant du paiement ne peut être supérieur au montant à payer s'il n'est pas encaissé en une seule fois !", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Else
                'verification que le montant encaissé>= totalàpayer
                'If CDbl(montantEncaisseTextbox.Text) < CDbl(TotalAPayerTextBox.Text) Then
                '    reponse = MessageBox.Show("Attention ! le montant encaissé est inférieur au total de la commande." & vbCrLf & "Souhaitez-vous quand même poursuivre ?", "Attention", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                'End If
                If CDbl(MontantPaiementTTCTextBox.Text) < CDbl(TotalAPayerTextBox.Text) Then
                    MessageBox.Show("Attention ! le montant encaissé est inférieur au total de la commande", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Error)

                Else

                    'on calcule le montant à rendre si le paiement n'a pas déja eu lieu !!

                    If T_CommandeVenteBindingSource.Current.item("PayeLe") Is DBNull.Value Or CDbl(T_CommandeVenteBindingSource.Current.item("MontantEncaisseTTC")) > CDbl(T_CommandeVenteBindingSource.Current.item("Total_TTC")) Then
                        If Math.Round(CDbl(T_CommandeVenteBindingSource.Current.item("MontantEncaisseTTC")), 2) > Math.Round(CDbl(T_CommandeVenteBindingSource.Current.item("Total_TTC")), 2) Then
                            T_CommandeVenteBindingSource.Current.item("MontantARendreTTC") = CDbl(T_CommandeVenteBindingSource.Current.item("MontantEncaisseTTC")) - CDbl(T_CommandeVenteBindingSource.Current.item("Total_TTC"))
                        Else
                            T_CommandeVenteBindingSource.Current.item("MontantARendreTTC") = 0
                        End If
                        'on ne change jamais la date inscrite sur le ticket si elle et renseignée(pb journal de caisse)
                        If T_CommandeVenteBindingSource.Current.item("PayeLe") Is DBNull.Value Then
                            T_CommandeVenteBindingSource.Current.item("PayeLe") = Now()
                        End If

                        'changement de l'état
                        If T_CommandeVenteBindingSource.Current.item("ID_EtatCommandeVente") < 15 Then
                            T_CommandeVenteBindingSource.Current.item("ID_EtatCommandeVente") = 15
                        End If

                        T_CommandeVenteBindingSource.EndEdit()
                        'lancement automatique du rendu de la monnaie si le montant à rendre est 0
                        If CDbl(T_CommandeVenteBindingSource.Current.item("MontantARendreTTC")) = 0 Then
                            RendreLaMonnaie(False)

                        End If
                        'lancement automatatique de la creation d'avoir si le montant à rendre est > 0
                        If CDbl(T_CommandeVenteBindingSource.Current.item("MontantARendreTTC")) > 0 Then
                            If CDbl(T_CommandeVenteBindingSource.Current.item("Id_t_Client")) > 0 Then
                                'RendreLaMonnaie(False)
                                BasculerAvoir()
                            Else
                                MessageBox.Show("Attention ! impossible de basculer en avoir sans numero de client.", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Error)

                            End If
                        End If


                    End If
                    'Désactivé le 9-12-2011 pour corriger le bug des paiement qui ne s'encaissent pas. Mise en place d'un trigger sur t_reglement.
                    'on parcourt l'ensemble des ligne afin d'encaisser et de marquer les avoirs utilisés
                    'For i As Integer = 0 To T_ReglementDataGridView.Rows.Count - 1
                    '    If T_ReglementDataGridView.Rows(i).Cells("a_encaisser").Value = True And T_ReglementDataGridView.Rows(i).Cells("encaissele").Value Is DBNull.Value Then
                    '        T_ReglementDataGridView.Rows(i).Cells("encaissele").Value = Now()
                    '        If Not T_ReglementDataGridView.Rows(i).Cells("Reference_avoir_bon").Value Is DBNull.Value Then
                    '            If T_ReglementDataGridView.Rows(i).Cells("Reference_avoir_bon").Value <> 0 Then
                    '                T_avoirTableAdapter.FillByID_T_Avoir(T_avoir, T_ReglementDataGridView.Rows(i).Cells("Reference_avoir_bon").Value)
                    '                If T_avoir.Rows.Count > 0 Then
                    '                    T_avoir.Rows(0)("UtiliseLe") = Now()
                    '                    T_avoirTableAdapter.Update(T_avoir)
                    '                End If



                    '            End If

                    '        End If
                    '    End If

                    'Next

                    'Enregistrement dans la table
                    Enregistrer()

                End If



                'TicketDeCaisse()
            End If

        End If








    End Sub
    'Sub PaiementOld()
    '    Dim T_avoirTableAdapter As New CLIDataSetTableAdapters.T_AvoirTableAdapter
    '    Dim T_avoir As New CLIDataSet.T_AvoirDataTable

    '    'Vérification  que le moyen de paiement ainsi que le montant ont été renseignés
    '    'Verification que le total payé est supérieur ou égal au montant total à payer
    '    T_CommandeVenteBindingSource.EndEdit()
    '    If CDbl(MontantPaiementTTCTextBox.Text) + CDbl(AvoirUtiliseMontantTextBox.Text) >= CDbl(TotalAPayerTextBox.Text) Then
    '        If MontantPaiementTTCTextBox.Text <> "" And ModeReglementComboBox.Text <> "" Then
    '            'Calcul du montant à rendre
    '            T_CommandeVenteBindingSource.Current.item("MontantARendreTTC") = CDbl(T_CommandeVenteBindingSource.Current.item("MontantPaiementTTC")) + CDbl(T_CommandeVenteBindingSource.Current.item("AvoirUtiliseMontant")) - CDbl(T_CommandeVenteBindingSource.Current.item("Total_TTC"))
    '            T_CommandeVenteBindingSource.Current.item("PayeLe") = Now()

    '            T_CommandeVenteBindingSource.EndEdit()


    '            If AvoirUtiliseNoTextBox.Text <> "" And AvoirUtiliseNoTextBox.Text <> "0" Then
    '                T_avoirTableAdapter.FillByID_T_Avoir(T_avoir, T_CommandeVenteBindingSource.Current.item("AvoirUtiliseNo"))
    '                T_avoir.Rows(0)("UtiliseLe") = Now()
    '                T_avoirTableAdapter.Update(T_avoir)
    '            End If

    '            'changement de l'état
    '            T_CommandeVenteBindingSource.Current.item("ID_EtatCommandeVente") = 15

    '            T_CommandeVenteBindingSource.EndEdit()
    '            'Enregistrement dans la table
    '            Enregistrer()



    '            'lancement automatique du rendu de la monnaie si le montant à rendre est 0
    '            If CDbl(T_CommandeVenteBindingSource.Current.item("MontantARendreTTC")) = 0 Then
    '                RendreLaMonnaie(False)
    '            End If




    '        Else
    '            MessageBox.Show("Merci de choisir un mode de règlement et un montant payé", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Warning)

    '        End If
    '    Else
    '        MessageBox.Show("Le montant payé (+ avoir) doit être supérieur ou égal au montant à payer", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Warning)

    '    End If

    'End Sub
    Sub CreationAutoAvoir()
        'creation des avoir automatiquement pour les articles Dépot vente
        'ajout 11/11/2011 : création des avoirs chèques cadeau

        Dim r As DataRowView
        Dim depot_vente As Boolean = False
        Dim id_t_client As Integer = 0
        Dim i As Integer
        For Each r In TCommandeVenteLigneBindingSource
            depot_vente = False
            id_t_client = 0
            If r.Item("ID_T_Article_version").ToString <> "0" Then
                'effectuer les creation d'avoir en automatique
                Dim cnn As New SqlClient.SqlConnection(My.Settings.CLIConnectionString)
                cnn.Open()
                Dim command As New SqlClient.SqlCommand
                Dim reader As SqlClient.SqlDataReader

                command.Connection = cnn
                'verification que l'article est un depot vente
                command.CommandText = "select depot_vente,id_t_client from t_article_version where id_t_article_version =" & r.Item("ID_T_Article_version")
                reader = command.ExecuteReader
                If reader.HasRows Then
                    reader.Read()
                    depot_vente = reader("depot_vente").ToString
                    id_t_client = IIf(reader("id_t_client") Is System.DBNull.Value, 0, reader("id_t_client"))
                End If
                reader.Close()

                If depot_vente Then
                    'on insere l'avoir
                    command.CommandText = "INSERT INTO T_avoir (id_t_client,id_t_commandevente,montant,commentaire,CreeLe,CreePar) VALUES (" & id_t_client & "," & r.Item("ID_T_CommandeVente") & ",'" & r.Item("Prix_total_ttc").ToString.Replace(",", ".") & "','Avoir automatique Commande de vente',getdate(),'" & gLogin & "')"
                    command.ExecuteNonQuery()

                    'on synchronise les avoirs du client dans prestashop si client prestashop
                    'on regarde si c'est un client prestashop et qu'il faut le synchroniser
                    Dim dt As DataTable = ExecuteRequeteR("select isnull(toSync,0) as toSync from t_client where id_t_client=" & id_t_client & "", gCnn.ConnectionString)
                    If dt.Rows.Count >= 1 Then
                        If dt.Rows(0)("tosync") Then
                            CliApi.CustomerAddOrUpdateAvoirPSfromCLIByIdAsync(New ToCliDto With {.Id = id_t_client})

                        End If

                    End If

                    'on desactive l'article
                    command.CommandText = "update t_article_version set active_on=0 where id_t_article_version=" & r.Item("ID_T_Article_version")
                    command.ExecuteNonQuery()

                End If
                If r.Item("ID_T_Article_version").ToString = "6" Then
                    'on insere l'avoir chèque cadeau
                    For i = 0 To r.Item("Qte") - 1
                        command.CommandText = "INSERT INTO T_avoir (id_t_client,id_t_commandevente,montant,commentaire,CreeLe,CreePar,chequecadeau) VALUES (" & r.Item("ChequeCadeauIdClient").ToString & "," & r.Item("ID_T_CommandeVente") & ",'" & (r.Item("Prix_total_ttc") / r.Item("Qte")).ToString.Replace(",", ".") & "','Avoir chèque cadeau',getdate(),'" & gLogin & "',1)"
                        command.ExecuteNonQuery()
                    Next
                    'on synchronise les avoirs du client dans prestashop si client prestashop
                    'on regarde si c'est un client prestashop et qu'il faut le synchroniser
                    Dim dt As DataTable = ExecuteRequeteR("select  isnull(toSync,0) as toSync from t_client where id_t_client=" & r.Item("ChequeCadeauIdClient").ToString & "", gCnn.ConnectionString)
                    If dt.Rows.Count >= 1 Then
                        If dt.Rows(0)("tosync") Then
                            CliApi.CustomerAddOrUpdateAvoirPSfromCLIByIdAsync(New ToCliDto With {.Id = r.Item("ChequeCadeauIdClient").ToString})

                        End If

                    End If

                End If

                cnn.Close()
            End If

        Next
    End Sub
    Sub DestructionAutoAvoir()
        'creation des avoir automatiquement pour les articles Dépot vente

        Dim r As DataRowView
        Dim depot_vente As Boolean = False
        Dim id_t_client As Integer = 0
        For Each r In TCommandeVenteLigneBindingSource
            depot_vente = False
            id_t_client = 0
            If r.Item("ID_T_Article_version").ToString <> "0" Then
                'effectuer la suppression d'avoir en automatique
                Dim cnn As New SqlClient.SqlConnection(My.Settings.CLIConnectionString)
                cnn.Open()
                Dim command As New SqlClient.SqlCommand
                Dim reader As SqlClient.SqlDataReader

                command.Connection = cnn
                'verification que l'article est un depot vente
                command.CommandText = "select depot_vente,id_t_client from t_article_version where id_t_article_version =" & r.Item("ID_T_Article_version")
                reader = command.ExecuteReader
                If reader.HasRows Then
                    reader.Read()
                    depot_vente = reader("depot_vente").ToString
                    id_t_client = reader("id_t_client").ToString
                End If
                reader.Close()

                If depot_vente Then
                    ' ✅ NF525 : Annulation logique au lieu de DELETE
                    ' On ne supprime JAMAIS physiquement les avoirs (données fiscales)
                    command.CommandText = "UPDATE T_avoir SET Annule=1, AnnuleLe=GETDATE(), AnnulePar=@User WHERE id_t_commandevente=" & r.Item("ID_T_CommandeVente")
                    command.Parameters.Clear()
                    command.Parameters.AddWithValue("@User", gLogin)
                    command.ExecuteNonQuery()

                    ' Logger l'événement
                    Try
                        LogEventTechnique("ANNULATION_AVOIR", _
                                         "Annulation avoir dépôt-vente", _
                                         "CommandeVente: " & r.Item("ID_T_CommandeVente"), _
                                         "Client: " & id_t_client & " | Article: " & r.Item("ID_T_Article_version"))
                    Catch
                        ' Ne pas bloquer si le JET échoue
                    End Try

                    'on reactive l'article
                    command.CommandText = "update t_article_version set active_on=1 where id_t_article_version=" & r.Item("ID_T_Article_version")
                    command.ExecuteNonQuery()

                End If
                cnn.Close()
            End If

        Next
    End Sub
    Sub ResetAvoir()
        'Mise à 0 de la date d'utilisation de l'avoir
        Try
            Dim cnn As New SqlClient.SqlConnection(My.Settings.CLIConnectionString)
            cnn.Open()
            Dim command As New SqlClient.SqlCommand


            command.Connection = cnn


            command.CommandText = "update T_avoir set utilisele=null where id_t_avoir=" & T_CommandeVenteBindingSource.Current.item("AvoirUtiliseNo")
            command.ExecuteNonQuery()


            cnn.Close()

        Catch ex As Exception

        End Try



    End Sub
    Function CheckClient(ByVal pcodeClient As TextBox) As Boolean
        Dim T_ClientTableAdapter As New CLIDataSetTableAdapters.T_ClientTableAdapter
        Dim T_Client As New CLIDataSet.T_ClientDataTable

        'verification qu'un numéro de client est saisi
        If (pcodeClient.Text <> "" And pcodeClient.Text <> "0") Then
            T_ClientTableAdapter.FillByid_t_client(T_Client, pcodeClient.Text)
            'verification que le numero d'avoir existe
            If T_Client.Count > 0 Then
                'verification que le client n'est pas inactif
                If Trim(T_Client.Rows(0)("actif")) = True Then
                    If pcodeClient.Name = "CodeClientTextBox" Then
                        T_CommandeVenteBindingSource.Current.item("Société") = T_Client.Rows(0)("Société").ToString
                        T_CommandeVenteBindingSource.Current.item("Nom") = T_Client.Rows(0)("Nom").ToString
                        T_CommandeVenteBindingSource.Current.item("Prénom") = T_Client.Rows(0)("Prenom").ToString
                        T_CommandeVenteBindingSource.Current.item("AdresseL1") = T_Client.Rows(0)("AdresseL1").ToString
                        T_CommandeVenteBindingSource.Current.item("AdresseL2") = T_Client.Rows(0)("AdresseL2").ToString
                        T_CommandeVenteBindingSource.Current.item("AdresseL3") = T_Client.Rows(0)("AdresseL3").ToString
                        T_CommandeVenteBindingSource.Current.item("Codepostal") = T_Client.Rows(0)("Codepostal").ToString
                        T_CommandeVenteBindingSource.Current.item("Ville") = T_Client.Rows(0)("Ville").ToString
                        T_CommandeVenteBindingSource.Current.item("Pays") = T_Client.Rows(0)("Pays").ToString
                        T_CommandeVenteBindingSource.Current.item("Tel") = T_Client.Rows(0)("Tel").ToString
                        T_CommandeVenteBindingSource.Current.item("Fax") = T_Client.Rows(0)("Fax").ToString
                        T_CommandeVenteBindingSource.Current.item("Mobile") = T_Client.Rows(0)("Mobile").ToString
                        T_CommandeVenteBindingSource.Current.item("Email") = T_Client.Rows(0)("Email").ToString
                        T_CommandeVenteBindingSource.Current.item("NoTva") = T_Client.Rows(0)("NoTva").ToString
                        T_CommandeVenteBindingSource.Current.item("NoSiret") = T_Client.Rows(0)("NoSiret").ToString
                        If T_Client.Rows(0)("Export").ToString <> "" Then
                            If T_Client.Rows(0)("Export") Then
                                export(Nothing, Nothing)
                                'T_CommandeVenteBindingSource.Current.item("Export") = T_Client.Rows(0)("Export")

                            End If

                        Else
                            T_CommandeVenteBindingSource.Current.item("Export") = False
                        End If

                        T_CommandeVenteBindingSource.EndEdit()

                    Else
                        I_NomBeneficiaire.Text = T_Client.Rows(0)("Nom").ToString & " " & T_Client.Rows(0)("Prenom").ToString
                    End If
                    CheckClient = True

                Else
                    CheckClient = False
                    pcodeClient.Focus()
                    pcodeClient.Text = 0
                    If pcodeClient.Name <> "CodeClientTextBox" Then
                        I_NomBeneficiaire.Text = ""
                    End If
                    MessageBox.Show("Client désactivé", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Warning)

                End If

            Else
                pcodeClient.Focus()
                pcodeClient.Text = 0
                If pcodeClient.Name <> "CodeClientTextBox" Then
                    I_NomBeneficiaire.Text = ""
                End If
                MessageBox.Show("Client inconnu", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                CheckClient = False

            End If
        Else
            pcodeClient.Focus()
            pcodeClient.Text = 0
            MessageBox.Show("Merci de saisir un numéro de client", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            CheckClient = False

        End If
    End Function



    Function CheckAvoir() As Boolean
        Dim T_avoirTableAdapter As New CLIDataSetTableAdapters.T_AvoirTableAdapter
        Dim T_avoir As New CLIDataSet.T_AvoirDataTable

        'verification qu'un numéro d'avoir est saisi
        If (I_RefAvoir.SelectedValue.ToString <> "") Then
            T_avoirTableAdapter.FillByID_T_Avoir(T_avoir, I_RefAvoir.SelectedValue)
            'verification que le numero d'avoir existe
            If T_avoir.Count > 0 Then
                'verification que le numero d'avoir n'a pas déja été utilisé
                If T_avoir.Rows(0)("utilisele").ToString = "" Then
                    I_montantReglement.Focus()
                    I_montantReglement.Text = T_avoir.Rows(0)("montant").ToString
                    I_ModeReglement.Focus()
                    CheckAvoir = True
                Else

                    I_RefAvoir.Focus()
                    I_RefAvoir.SelectedIndex = 0
                    I_montantReglement.Text = 0

                    MessageBox.Show("Avoir déjà utilisé le " & T_avoir.Rows(0)("utilisele").ToString, "Attention", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    CheckAvoir = False
                End If
            Else
                I_montantReglement.Focus()
                I_RefAvoir.SelectedIndex = 0
                I_montantReglement.Text = 0
                I_ModeReglement.Focus()
                MessageBox.Show("Avoir inconnu", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                CheckAvoir = False

            End If
        Else
            I_montantReglement.Focus()
            I_RefAvoir.SelectedIndex = 0
            I_montantReglement.Text = 0
            I_ModeReglement.Focus()
            MessageBox.Show("Merci de saisir un numéro d'avoir", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            CheckAvoir = False

        End If
    End Function
    'Function CheckAvoirOld() As Boolean
    '    Dim T_avoirTableAdapter As New CLIDataSetTableAdapters.T_AvoirTableAdapter
    '    Dim T_avoir As New CLIDataSet.T_AvoirDataTable

    '    'verification qu'un numéro d'avoir est saisi
    '    If (AvoirUtiliseNoTextBox.Text <> "" And AvoirUtiliseNoTextBox.Text <> "0") Then
    '        T_avoirTableAdapter.FillByID_T_Avoir(T_avoir, AvoirUtiliseNoTextBox.Text)
    '        'verification que le numero d'avoir existe
    '        If T_avoir.Count > 0 Then
    '            'verification que le numero d'avoir n'a pas déja été utilisé
    '            If T_avoir.Rows(0)("utilisele").ToString = "" Then
    '                AvoirUtiliseMontantTextBox.Focus()
    '                AvoirUtiliseMontantTextBox.Text = T_avoir.Rows(0)("montant").ToString
    '                AvoirUtiliseNoTextBox.Focus()
    '                CheckAvoirOld = True
    '            Else

    '                AvoirUtiliseNoTextBox.Focus()
    '                AvoirUtiliseNoTextBox.Text = 0
    '                AvoirUtiliseMontantTextBox.Text = 0

    '                MessageBox.Show("Avoir déjà utilisé le " & T_avoir.Rows(0)("utilisele").ToString, "Attention", MessageBoxButtons.OK, MessageBoxIcon.Warning)
    '                CheckAvoirOld = False
    '            End If
    '        Else
    '            AvoirUtiliseMontantTextBox.Focus()
    '            AvoirUtiliseNoTextBox.Text = 0
    '            AvoirUtiliseMontantTextBox.Text = 0
    '            AvoirUtiliseNoTextBox.Focus()
    '            MessageBox.Show("Avoir inconnu", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Warning)
    '            CheckAvoirOld = False

    '        End If
    '    Else
    '        AvoirUtiliseMontantTextBox.Focus()
    '        AvoirUtiliseNoTextBox.Text = 0
    '        AvoirUtiliseMontantTextBox.Text = 0
    '        AvoirUtiliseNoTextBox.Focus()
    '        MessageBox.Show("Merci de saisir un numéro d'avoir", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Warning)
    '        CheckAvoirOld = False

    '    End If
    'End Function

    Function CheckClientAvoir() As Boolean
        Dim T_clientTableAdapter As New CLIDataSetTableAdapters.T_ClientTableAdapter
        Dim t_client As New CLIDataSet.T_ClientDataTable
        CheckClientAvoir = True
        'Vérification que le code client esr rentré est ok
        If CodeClientTextBox.Text <> "" Then
            T_clientTableAdapter.FillByid_t_client(t_client, CodeClientTextBox.Text)
            If t_client.Count > 0 Then
                If Not CBool(t_client.Rows(0)("Actif")) Then
                    MessageBox.Show("Client non actif", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    CodeClientTextBox.Focus()
                    CodeClientTextBox.Text = 0
                    CodeClientTextBox.Focus()
                    CheckClientAvoir = False
                End If
            Else
                MessageBox.Show("Client inexistant", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                CodeClientTextBox.Focus()
                CodeClientTextBox.Text = 0
                CodeClientTextBox.Focus()
                CheckClientAvoir = False
            End If
        Else
            MessageBox.Show("Merci de saisir un code client pour associer l'avoir", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            CodeClientTextBox.Focus()
            CodeClientTextBox.Text = 0
            CodeClientTextBox.Focus()
            CheckClientAvoir = False
        End If
    End Function
    Private Sub Nouveau()

        AffBienvenue()

        T_CommandeVenteBindingSource.AddNew()
        T_CommandeVenteBindingSource.EndEdit()
        AffichageVerouillage()
        Me.CLIDataSet.T_CommandeVente_Ligne.Clear()
        Me.CLIDataSet.T_EtatCommandeVente.Clear()

        FactureReportViewer.Refresh()

        PaysComboBox.SelectedIndex = -1
        'ModeReglementComboBox.SelectedIndex = -1
        CodeClientTextBox.Text = 0
        NouveauToolStripButton.Enabled = False


        SupprimerToolStripButton.Enabled = False

        ToolStripButtonMovefirst.Enabled = False
        ToolStripButtonMovePrevious.Enabled = False
        ToolStripButtonMoveNext.Enabled = False
        ToolStripButtonMoveLast.Enabled = False
        I_Ref.Focus()


    End Sub





    Sub Recup_info(ByVal Ref As String, Optional ByRef export_on As Boolean = False)
        If IsNumeric(Ref) Then
            Dim cnn As New SqlClient.SqlConnection(My.Settings.CLIConnectionString)
            cnn.Open()
            Dim command As New SqlClient.SqlCommand

            command.CommandText = "SELECT description_panier,prix_vente_initial_TTC,Remise,prix_vente_remise_TTC,code_tva from  T_Article_version,T_Article_detail,T_Article_entete where active_on=1 and  T_Article_detail.id_t_article_detail=t_article_version.id_t_article_detail and T_Article_detail.id_t_article_entete=t_article_entete.id_t_article_entete and id_t_article_version= " & Ref

            command.Connection = cnn
            Dim reader As SqlClient.SqlDataReader = command.ExecuteReader
            If reader.HasRows Then
                reader.Read()
                I_Designation.Text = reader("description_panier").ToString
                If export_on Then
                    I_PuTTC.Text = Math.Round(reader("prix_vente_initial_TTC") / (1 + reader("Code_Tva") / 100), 2)

                    I_PUTTCRemise.Text = Math.Round(reader("prix_vente_remise_TTC") / (1 + reader("Code_Tva") / 100), 2)
                    I_TVA.Text = 0

                Else
                    I_PuTTC.Text = reader("prix_vente_initial_TTC").ToString
                    I_PUTTCRemise.Text = reader("prix_vente_remise_TTC").ToString
                    I_TVA.Text = reader("Code_Tva").ToString

                End If
                I_Remise.Text = reader("Remise").ToString
                I_Qte.Text = 1
                'mise en lecture seule du prix unitaire initial
                I_PuTTC.ReadOnly = True
                I_TVA.ReadOnly = True
            Else
                'mise en ecriture du prix unitaire initial
                I_PuTTC.ReadOnly = False
                I_TVA.ReadOnly = False
            End If
            reader.Close()
            cnn.Close()
        End If

    End Sub
    Function info_article(ByVal Ref As String, ByRef colonne As String)
        info_article = ""
        If IsNumeric(Ref) Then
            Dim cnn As New SqlClient.SqlConnection(My.Settings.CLIConnectionString)
            cnn.Open()
            Dim command As New SqlClient.SqlCommand

            command.CommandText = "SELECT " & colonne & " from  T_Article_version,T_Article_detail,T_Article_entete where active_on=1 and  T_Article_detail.id_t_article_detail=t_article_version.id_t_article_detail and T_Article_detail.id_t_article_entete=t_article_entete.id_t_article_entete and id_t_article_version= " & Ref

            command.Connection = cnn
            Dim reader As SqlClient.SqlDataReader = command.ExecuteReader
            If reader.HasRows Then
                reader.Read()
                info_article = reader(colonne).ToString

            End If
            reader.Close()
            cnn.Close()
        End If

    End Function
    Function ArticleOk(ByVal Ref As String) As Boolean
        If IsNumeric(Ref) Then
            Dim cnn As New SqlClient.SqlConnection(My.Settings.CLIConnectionString)
            cnn.Open()
            Dim command As New SqlClient.SqlCommand

            command.CommandText = "SELECT id_t_article_version from T_Article_version where active_on=1 and id_t_article_version= " & Ref

            command.Connection = cnn
            Dim reader As SqlClient.SqlDataReader = command.ExecuteReader

            ArticleOk = reader.HasRows


            reader.Close()
            cnn.Close()
        Else
            ArticleOk = False
        End If

    End Function
    Function AjouterLigne() As Boolean
        Dim i As Integer
        Dim bTrouve As Boolean = False
        Dim vLigneCourante As Object
        AjouterLigne = False



        'on verifie que la ref n'est pas déja présente
        'si oui on ajoute les quantité et on la supprime
        If IsNumeric(I_Ref.Text) Then
            I_Ref.Text = CInt(I_Ref.Text)
            If I_Ref.Text <> 0 And I_Ref.Text <> 1 And I_Ref.Text <> 2 And I_Ref.Text <> 3 And I_Ref.Text <> 4 And I_Ref.Text <> 5 And I_Ref.Text <> 6 And ArticleOk(I_Ref.Text) Then
                For i = 0 To DataGridViewCommande.Rows.Count - 1
                    If DataGridViewCommande.Rows(i).Cells("Ref").Value = CInt(I_Ref.Text) Then
                        I_Qte.Text = CInt(I_Qte.Text) + CInt(DataGridViewCommande.Rows(i).Cells("Qte").Value)

                        If I_Qte.Text = 0 Then
                            DataGridViewCommande.Rows.RemoveAt(i)
                            AjouterLigne = True
                        Else
                            DataGridViewCommande.Rows(i).Cells("Qte").Value = I_Qte.Text
                            DataGridViewCommande.Rows(i).Cells("PUinitialTTC").Value = I_PuTTC.Text
                            DataGridViewCommande.Rows(i).Cells("TotalLigne").Value = CInt(I_Qte.Text) * CDbl(I_PUTTCRemise.Text)
                            'correction bug d'ajout
                            ' DataGridViewCommande.Rows(i).Cells("prix_total_HT").Value = CInt(I_Qte.Text) * CDbl(I_PUTTCRemise.Text) / (1 + (CDbl(I_TVA.Text) / 100))
                            AjouterLigne = True
                        End If


                        bTrouve = True
                        Exit For
                    End If
                Next
            End If
            If Not bTrouve Then
                If I_Ref.Text = 0 Or I_Ref.Text = 1 Or I_Ref.Text = 2 Or I_Ref.Text = 3 Or I_Ref.Text = 4 Or I_Ref.Text = 5 Or (I_Ref.Text = 6 And I_ChequeCadeauIdClient.Text <> "0" And IsNumeric(I_ChequeCadeauIdClient.Text)) Or ArticleOk(I_Ref.Text) Then

                    If IsNumeric(I_Qte.Text) And I_Designation.Text <> "" And IsNumeric(I_PuTTC.Text) And IsNumeric(I_Remise.Text) And IsNumeric(I_PUTTCRemise.Text) And IsNumeric(I_TVA.Text) Then

                        vLigneCourante = TCommandeVenteLigneBindingSource.AddNew()
                        vLigneCourante.item("Id_t_article_version") = I_Ref.Text
                        vLigneCourante.item("Description_panier") = I_Designation.Text
                        vLigneCourante.item("Qte") = I_Qte.Text
                        vLigneCourante.item("prix_vente_initial_ttc") = I_PuTTC.Text
                        vLigneCourante.item("prix_vente_initial_HT") = CDbl(I_PuTTC.Text) / (1 + (CDbl(I_TVA.Text) / 100))

                        vLigneCourante.item("Remise") = I_Remise.Text
                        vLigneCourante.item("prix_vente_remise_ttc") = I_PUTTCRemise.Text
                        vLigneCourante.item("code_tva") = I_TVA.Text
                        vLigneCourante.item("prix_total_ttc") = CInt(I_Qte.Text) * CDbl(I_PUTTCRemise.Text)
                        vLigneCourante.item("prix_total_HT") = CInt(I_Qte.Text) * CDbl(I_PuTTC.Text) / (1 + (CDbl(I_TVA.Text) / 100))
                        If IsNumeric(info_article(I_Ref.Text, "prix_fournisseur")) Then
                            vLigneCourante.item("prix_fournisseur") = info_article(I_Ref.Text, "prix_fournisseur")
                        End If
                        If IsNumeric(info_article(I_Ref.Text, "poids")) Then
                            vLigneCourante.item("poids") = info_article(I_Ref.Text, "poids")
                        End If
                        If info_article(I_Ref.Text, "depot_vente") <> "False" And info_article(I_Ref.Text, "depot_vente") <> "" Then
                            vLigneCourante.item("depot_vente") = 1 ' CBool(info_article(I_Ref.Text, "depot_vente"))
                        End If
                        If info_article(I_Ref.Text, "occaz") <> "False" And info_article(I_Ref.Text, "occaz") <> "" Then
                            vLigneCourante.item("occaz") = 1
                        End If
                        If IsNumeric(I_ChequeCadeauIdClient.Text) And I_ChequeCadeauIdClient.Text <> "0" Then
                            vLigneCourante.item("ChequeCadeauIdClient") = I_ChequeCadeauIdClient.Text
                            vLigneCourante.item("Description_panier") = vLigneCourante.item("Description_panier") & " : " & I_NomBeneficiaire.Text
                        End If

                        'DataGridViewCommande.Rows.Insert(0, I_Ref.Text, I_Designation.Text, I_Qte.Text, I_PuTTC.Text, I_Remise.Text, I_PUTTCRemise.Text, I_TVA.Text, CInt(I_Qte.Text) * CDbl(I_PUTTCRemise.Text))

                        AjouterLigne = True

                    Else
                        My.Computer.Audio.PlaySystemSound(Media.SystemSounds.Exclamation)
                        AjouterLigne = False
                    End If
                End If

            End If
        Else
            My.Computer.Audio.PlaySystemSound(Media.SystemSounds.Exclamation)
            AjouterLigne = False
        End If

        CalculTotal()
        'deuxième appel pour resoudre bug d'affichage du total
        CalculTotal()


        Try
            MajDisplay(I_Designation.Text, CDbl(I_PUTTCRemise.Text), I_TotalTTC.Text & " Euros")

        Catch ex As Exception

        End Try

        ClearTampon()

    End Function
    Function AjouterReglement() As Boolean
        Dim i As Integer
        Dim bTrouve As Boolean = False
        Dim vLigneCourante As Object
        AjouterReglement = False
        Dim libelle As String
        Dim mode_reglement As Integer
        Dim delai As Integer
        Dim fin_mois As Boolean
        Dim jour_mois As Integer
        Dim nb_paiement As Integer
        Dim moyen_paiement As Integer
        Dim moyen_paiement_libelle As String

        'recup des params des conditions de paiement
        mode_reglement = I_conditions.SelectedValue
        libelle = CLIDataSet.T_modeReglement.FindById_T_ModeReglement(I_conditions.SelectedValue).Libelle
        delai = CLIDataSet.T_modeReglement.FindById_T_ModeReglement(I_conditions.SelectedValue).delai
        fin_mois = CLIDataSet.T_modeReglement.FindById_T_ModeReglement(I_conditions.SelectedValue).fin_mois
        jour_mois = CLIDataSet.T_modeReglement.FindById_T_ModeReglement(I_conditions.SelectedValue).jour_mois
        nb_paiement = CLIDataSet.T_modeReglement.FindById_T_ModeReglement(I_conditions.SelectedValue).nb_paiement
        moyen_paiement_libelle = CLIDataSet.T_MoyenPaiement.FindById_T_MoyenPaiement(I_ModeReglement.SelectedValue).Libelle
        moyen_paiement_libelle = ""
        moyen_paiement = I_ModeReglement.SelectedValue


        Try

            For z As Integer = 1 To nb_paiement

                vLigneCourante = T_ReglementBindingSource.AddNew()

                vLigneCourante.item("Moyen_paiement") = moyen_paiement
                vLigneCourante.item("condition_reglement") = mode_reglement
                If z = 1 Then
                    vLigneCourante.item("Montant") = I_montantReglement.Text
                Else
                    'vLigneCourante.item("Montant") = Math.Round(calculMontantReglementReste() / (nb_paiement - z + 1), 2)
                    vLigneCourante.item("Montant") = calculMontantReglementReste() / (nb_paiement - z + 1)
                End If

                If Not I_RefAvoir.Text = "<choisir>" And I_RefAvoir.Text <> "" Then
                    vLigneCourante.item("Reference_avoir_bon") = I_RefAvoir.SelectedValue
                End If


                If Not I_echeanceLe.Text = "" Then
                    If z = 1 Then
                        vLigneCourante.item("Echeance_le") = I_echeanceLe.Text
                    Else
                        vLigneCourante.item("Echeance_le") = DateAdd(DateInterval.Month, (delai / 30) * (z - 1), CDate(I_echeanceLe.Text))
                    End If

                End If
                If I_encaisse.Checked And z = 1 Then
                    vLigneCourante.item("A_encaisser") = True
                Else
                    vLigneCourante.item("A_encaisser") = False
                End If

                vLigneCourante.item("Enregistre_le") = Now()
                T_ReglementBindingSource.EndEdit()
                calculMontantReglement()
            Next







            'MajDisplay(I_Designation.Text, CDbl(I_PUTTCRemise.Text), I_TotalTTC.Text & " Euros")
            AjouterReglement = True
        Catch ex As Exception
            T_ReglementBindingSource.CancelEdit()
        Finally
            calculMontantReglement()
            calculMontantReglementReste()
            ClearTamponReglement()
        End Try


    End Function
    Function AjouterLigneAncien() As Boolean
        Dim i As Integer
        Dim bTrouve As Boolean = False
        AjouterLigneAncien = False


        'on verifie que la ref n'est pas déja présente
        'si oui on ajoute les quantité et on la supprime
        If IsNumeric(I_Ref.Text) Then
            I_Ref.Text = CInt(I_Ref.Text)
            If I_Ref.Text <> 0 And ArticleOk(I_Ref.Text) Then
                For i = 0 To DataGridViewCommande.Rows.Count - 1
                    If DataGridViewCommande.Rows(i).Cells("Ref").Value = CInt(I_Ref.Text) Then
                        I_Qte.Text = CInt(I_Qte.Text) + CInt(DataGridViewCommande.Rows(i).Cells("Qty").Value)

                        If I_Qte.Text = 0 Then
                            DataGridViewCommande.Rows.RemoveAt(i)
                            AjouterLigneAncien = True
                        Else
                            DataGridViewCommande.Rows(i).Cells("Qty").Value = I_Qte.Text
                            DataGridViewCommande.Rows(i).Cells("PUTTC").Value = I_PuTTC.Text
                            DataGridViewCommande.Rows(i).Cells("TotalLigne").Value = CInt(I_Qte.Text) * CDbl(I_PUTTCRemise.Text)
                            AjouterLigneAncien = True
                        End If


                        bTrouve = True
                        Exit For
                    End If
                Next
            End If
            If Not bTrouve Then
                If I_Ref.Text = 0 Or ArticleOk(I_Ref.Text) Then
                    If IsNumeric(I_Qte.Text) And I_Designation.Text <> "" And IsNumeric(I_PuTTC.Text) And IsNumeric(I_Remise.Text) And IsNumeric(I_PUTTCRemise.Text) And IsNumeric(I_TVA.Text) Then

                        DataGridViewCommande.Rows.Insert(0, I_Ref.Text, I_Designation.Text, I_Qte.Text, I_PuTTC.Text, I_Remise.Text, I_PUTTCRemise.Text, I_TVA.Text, CInt(I_Qte.Text) * CDbl(I_PUTTCRemise.Text))
                        AjouterLigneAncien = True
                    Else
                        My.Computer.Audio.PlaySystemSound(Media.SystemSounds.Exclamation)
                        AjouterLigneAncien = False
                    End If
                End If

            End If
        Else
            My.Computer.Audio.PlaySystemSound(Media.SystemSounds.Exclamation)
            AjouterLigneAncien = False
        End If

        CalculTotal()

        Try
            MajDisplay(I_Designation.Text, CInt(I_Qte.Text) * CDbl(I_PUTTCRemise.Text), I_TotalTTC.Text & " Euros")

        Catch ex As Exception

        End Try

        ClearTampon()

    End Function
    Sub ClearTampon()
        I_Ref.Text = ""
        I_Qte.Text = ""
        I_Designation.Text = ""
        I_PuTTC.Text = ""
        I_Remise.Text = ""
        I_PUTTCRemise.Text = ""
        I_TVA.Text = ""
        I_ChequeCadeauIdClient.Text = 0
        I_NomBeneficiaire.Text = ""
        I_ChequeCadeauIdClient.Visible = False
        I_NomBeneficiaire.Visible = False
        IL_codebenef.Visible = False
        I_Qte.ReadOnly = False
        I_PuTTC.ReadOnly = False
        I_Remise.ReadOnly = False
        I_PUTTCRemise.ReadOnly = False
        I_TVA.ReadOnly = False
    End Sub

    Sub ClearTamponReglement()

        I_conditions.SelectedIndex = -1
        I_ModeReglement.SelectedIndex = -1
        If I_RefAvoir.Items.Count > 0 Then
            I_RefAvoir.SelectedIndex = 0
        End If

        I_montantReglement.Text = ""
        I_encaisse.Checked = False
        I_echeanceLe.Text = ""

        'désactivation de tous les champs sauf conditions
        I_ModeReglement.Enabled = False
        I_RefAvoir.Enabled = False
        I_montantReglement.ReadOnly = True
        I_encaisse.Enabled = False
        I_echeanceLe.ReadOnly = True



    End Sub
    Sub CalculTotal()
        Dim i As Integer
        T_CommandeVenteBindingSource.Current.item("Total_ttc") = 0
        T_CommandeVenteBindingSource.Current.item("Total_HT") = 0
        T_CommandeVenteBindingSource.Current.item("Total_55") = 0
        T_CommandeVenteBindingSource.Current.item("Total_196") = 0
        T_CommandeVenteBindingSource.Current.item("Montant_deduire") = 0


        For i = 0 To DataGridViewCommande.Rows.Count - 1
            If DataGridViewCommande.Rows(i).Cells("Ref").Value = "1" Then
                T_CommandeVenteBindingSource.Current.item("montant_deduire") = T_CommandeVenteBindingSource.Current.item("montant_deduire") + Math.Abs(CDbl(DataGridViewCommande.Rows(i).Cells("TotalLigne").Value))
                T_CommandeVenteBindingSource.Current.item("Total_ttc") = T_CommandeVenteBindingSource.Current.item("Total_ttc") - Math.Abs(CDbl(DataGridViewCommande.Rows(i).Cells("TotalLigne").Value))

            Else
                T_CommandeVenteBindingSource.Current.item("Total_HT") = T_CommandeVenteBindingSource.Current.item("Total_HT") + CDbl(DataGridViewCommande.Rows(i).Cells("TotalLigne").Value) / (1 + CDbl(DataGridViewCommande.Rows(i).Cells("TVA").Value) / 100)
                T_CommandeVenteBindingSource.Current.item("Total_ttc") = T_CommandeVenteBindingSource.Current.item("Total_ttc") + CDbl(DataGridViewCommande.Rows(i).Cells("TotalLigne").Value)

            End If
            If CDbl(DataGridViewCommande.Rows(i).Cells("TVA").Value) = 20 Then
                T_CommandeVenteBindingSource.Current.item("Total_196") = T_CommandeVenteBindingSource.Current.item("Total_196") + CDbl(DataGridViewCommande.Rows(i).Cells("TotalLigne").Value) - CDbl(DataGridViewCommande.Rows(i).Cells("TotalLigne").Value) / (1 + CDbl(DataGridViewCommande.Rows(i).Cells("TVA").Value / 100))
            Else
                T_CommandeVenteBindingSource.Current.item("Total_55") = T_CommandeVenteBindingSource.Current.item("Total_55") + CDbl(DataGridViewCommande.Rows(i).Cells("TotalLigne").Value) - CDbl(DataGridViewCommande.Rows(i).Cells("TotalLigne").Value) / (1 + CDbl(DataGridViewCommande.Rows(i).Cells("TVA").Value / 100))

            End If


        Next
        If IsNumeric(I_TotalTTC.Text) Then
            T_CommandeVenteBindingSource.Current.item("Total_ttc") = Format(Math.Round(CDbl(I_TotalTTC.Text), 2), "##0.00")
        Else
            T_CommandeVenteBindingSource.Current.item("Total_ttc") = 0
        End If

        If IsNumeric(I_TotalHT.Text) Then
            T_CommandeVenteBindingSource.Current.item("Total_HT") = Format(Math.Round(CDbl(I_TotalHT.Text), 2), "##0.00")
        Else
            T_CommandeVenteBindingSource.Current.item("Total_HT") = 0
        End If

        If IsNumeric(I_TVA55.Text) Then
            T_CommandeVenteBindingSource.Current.item("Total_55") = Format(Math.Round(CDbl(I_TVA55.Text), 2), "##0.00")
        Else
            T_CommandeVenteBindingSource.Current.item("Total_55") = 0
        End If

        If IsNumeric(I_TVA196.Text) Then
            T_CommandeVenteBindingSource.Current.item("Total_196") = Format(Math.Round(CDbl(I_TVA196.Text), 2), "##0.00")
        Else
            T_CommandeVenteBindingSource.Current.item("Total_196") = 0
        End If
        If IsNumeric(I_MontantDeduire.Text) Then
            T_CommandeVenteBindingSource.Current.item("montant_deduire") = Format(Math.Round(Math.Abs(CDbl(I_MontantDeduire.Text)), 2), "##0.00")
        Else
            T_CommandeVenteBindingSource.Current.item("Montant_Deduire") = 0
        End If

        I_Total_TTC_avantDeduction.Text = T_CommandeVenteBindingSource.Current.item("Total_HT") + T_CommandeVenteBindingSource.Current.item("Total_55") + T_CommandeVenteBindingSource.Current.item("Total_196")

        T_CommandeVenteBindingSource.EndEdit()

    End Sub
    Sub MajDisplay(ByVal ArticleDesc As String, ByVal PUTTCRemise As String, ByVal TotalTTC As String)
        Try
            m_Display.ClearText()
            'm_Display.DisplayText(ArticleDesc & "   " & PUTTCRemise & "E" & vbCrLf & "Total :" & TotalTTC, DisplayTextMode.Normal)
            Try
                m_Display.DisplayTextAt(0, 0, VingtDigit(ArticleDesc, "", 20), DisplayTextMode.Normal)

            Catch ex As Exception

            End Try
            Try

                m_Display.DisplayTextAt(1, 0, VingtDigit(Format(CDbl(I_TotalTTC.Text), "##0.00") & "E", Format(CDbl(PUTTCRemise), "##0.00") & "E", 20), DisplayTextMode.Normal)

            Catch ex As Exception

            End Try

        Catch ex As PosControlException

        End Try
    End Sub
    Sub MajDisplayAncien(ByVal ArticleDesc As String, ByVal PUTTCRemise As String, ByVal TotalTTC As String)
        Try
            m_Display.ClearText()
            'm_Display.DisplayText(ArticleDesc & "   " & PUTTCRemise & "E" & vbCrLf & "Total :" & TotalTTC, DisplayTextMode.Normal)
            Try
                m_Display.DisplayTextAt(0, 0, VingtDigit(ArticleDesc, Format(CDbl(PUTTCRemise), "##0.00") & "E", 20), DisplayTextMode.Normal)

            Catch ex As Exception

            End Try
            Try
                m_Display.DisplayTextAt(1, 0, VingtDigit("Total", Format(CDbl(I_TotalTTC.Text), "##0.00") & "E", 20), DisplayTextMode.Normal)

            Catch ex As Exception

            End Try

        Catch ex As PosControlException

        End Try
    End Sub
    Sub AffBienvenue()
        Try
            If Not m_Display Is Nothing Then
                m_Display.ClearText()
                m_Display.DisplayText("**** Bienvenue *****" & vbCr & " ******************* ")
            End If

        Catch ex As PosControlException

        End Try
    End Sub
    Sub AffTotCommande()

        Try
            MajDisplay("", "", FormatNumber(T_CommandeVenteBindingSource.Current.item("Total_ttc"), 2) & " Euros")

        Catch ex As Exception

        End Try

    End Sub
    Sub AffAPayer()

        Try
            If Not m_Display Is Nothing Then

                m_Display.ClearText()

                Try
                    m_Display.DisplayTextAt(0, 0, VingtDigit("A Payer", "", 20), DisplayTextMode.Normal)

                Catch ex As Exception

                End Try
                Try
                    m_Display.DisplayTextAt(1, 0, VingtDigit("", FormatNumber(T_CommandeVenteBindingSource.Current.item("total_ttc").ToString, 2) & "E", 20), DisplayTextMode.Normal)
                    '          m_Display.DisplayTextAt(1, 0, VingtDigit(Format(CDbl(I_TotalTTC.Text), "##0.00") & "E", Format(CDbl(PUTTCRemise), "##0.00") & "E", 20), DisplayTextMode.Normal)

                Catch ex As Exception

                End Try
            End If

        Catch ex As PosControlException

        End Try
    End Sub
    Sub AffMerci()
        Try
            If Not m_Display Is Nothing Then
                m_Display.ClearText()
                Try
                    m_Display.DisplayTextAt(0, 0, VingtDigit("Merci", "", 20), DisplayTextMode.Normal)

                Catch ex As Exception

                End Try
                Try
                    m_Display.DisplayTextAt(1, 0, VingtDigit("", "A bientôt", 20), DisplayTextMode.Normal)
                    '          m_Display.DisplayTextAt(1, 0, VingtDigit(Format(CDbl(I_TotalTTC.Text), "##0.00") & "E", Format(CDbl(PUTTCRemise), "##0.00") & "E", 20), DisplayTextMode.Normal)

                Catch ex As Exception

                End Try
            End If
        Catch ex As PosControlException

        End Try
    End Sub
    Sub AffAnnule()
        Try
            If Not m_Display Is Nothing Then
                m_Display.ClearText()
                Try
                    m_Display.DisplayTextAt(0, 0, VingtDigit("Commande annulée", "", 20), DisplayTextMode.Normal)

                Catch ex As Exception

                End Try
                Try
                    m_Display.DisplayTextAt(1, 0, VingtDigit("", "A bientôt", 20), DisplayTextMode.Normal)
                    '          m_Display.DisplayTextAt(1, 0, VingtDigit(Format(CDbl(I_TotalTTC.Text), "##0.00") & "E", Format(CDbl(PUTTCRemise), "##0.00") & "E", 20), DisplayTextMode.Normal)

                Catch ex As Exception

                End Try
            End If
        Catch ex As PosControlException

        End Try
    End Sub
    Sub AffARendre()
        Try
            If Not m_Display Is Nothing Then
                m_Display.ClearText()
                Try
                    m_Display.DisplayTextAt(0, 0, VingtDigit("A Rendre", "", 20), DisplayTextMode.Normal)

                Catch ex As Exception

                End Try
                Try
                    m_Display.DisplayTextAt(1, 0, VingtDigit("", FormatNumber(T_CommandeVenteBindingSource.Current.item("MontantArendrettc").ToString, 2) & "E", 20), DisplayTextMode.Normal)
                    '          m_Display.DisplayTextAt(1, 0, VingtDigit(Format(CDbl(I_TotalTTC.Text), "##0.00") & "E", Format(CDbl(PUTTCRemise), "##0.00") & "E", 20), DisplayTextMode.Normal)

                Catch ex As Exception

                End Try
            End If
        Catch ex As PosControlException

        End Try
    End Sub

    Function VingtDigit(ByVal Gauche As String, ByVal Droite As String, Optional ByVal longueur As Integer = 0) As String
        Dim espacedispo_gauche As Integer
        espacedispo_gauche = longueur - 2 - Len(Droite)
        Dim chaineGauche As String = ""
        Dim i As Integer = 0
        Dim nbespaces As Integer = 0

        If Len(Gauche) > espacedispo_gauche Then
            chaineGauche = Microsoft.VisualBasic.Left(Gauche, espacedispo_gauche)
        Else
            chaineGauche = Gauche
            nbespaces = espacedispo_gauche - Len(Gauche)
            For i = 1 To nbespaces
                chaineGauche = chaineGauche & " "
            Next
        End If
        VingtDigit = chaineGauche & "  " & Droite

    End Function
    Private Sub Refresh_data()
        Cursor = Cursors.WaitCursor

        If id_t_commande_vente > 0 Then
            Me.T_CommandeVenteTableAdapter.FillbyID_T_CommandeVente(Me.CLIDataSet.T_CommandeVente, id_t_commande_vente)
            Me.T_CommandeVente_LigneTableAdapter.FillByID_T_CommandeVente(Me.CLIDataSet.T_CommandeVente_Ligne, id_t_commande_vente)
            Me.T_EtatCommandeVenteTableAdapter.FillByID_T_EtatCommandeVente(Me.CLIDataSet.T_EtatCommandeVente, T_CommandeVenteBindingSource.Current.item("ID_EtatCommandeVente"))
            If T_CommandeVenteBindingSource.Current.item("AvoirCreeNo").ToString = "" Then
                Me.V_Avoir_clientTableAdapter.FillByID_T_Avoir(Me.CLIDataSet.V_Avoir_client, 0)
            Else
                Me.V_Avoir_clientTableAdapter.FillByID_T_Avoir(Me.CLIDataSet.V_Avoir_client, T_CommandeVenteBindingSource.Current.item("AvoirCreeNo").ToString)
            End If
            Me.V_chequecadeau_clientTableAdapter.FillByid_t_commandeVente(Me.CLIDataSet.V_chequecadeau_client, id_t_commande_vente)

            Me.T_ReglementTableAdapter.FillByIdTCommandeVente(Me.CLIDataSet.T_Reglement, id_t_commande_vente)
            Me.V_reglementTableAdapter.FillBy_id_t_commandevente(Me.CLIDataSet.V_reglement, id_t_commande_vente)
            'initialisation des avoirs du clients
            I_RefAvoir.DataSource = Nothing
            If Not T_CommandeVenteBindingSource.Current.item("Id_t_client") Is DBNull.Value Then

                InitCombo(I_RefAvoir, My.Settings.CLIConnectionString, "Select id_t_avoir as id,convert(varchar(225),id_t_avoir) + ' - ' + convert(varchar(225),montant) + ' €' as libelle from t_avoir where utilisele is null and id_t_client=" & T_CommandeVenteBindingSource.Current.item("Id_t_client"), "libelle", "<Choisir>", "id")


            End If
            'Récupération de l'état de synchro prestashop
            Dim vEtatSynchroDt As DataTable = ExecuteRequeteR("select LogType from V_Log where LogAssociatedRecordId=" & Me.CLIDataSet.T_CommandeVente.Rows(0).Item("ID_T_CommandeVente").ToString & " and LogAssociatedRecordType='t_commandeVente' ", gCnn.ConnectionString)
            Dim vEtatSynchro As String = "Non"
            BT_DetailSynchro.Enabled = False
            If vEtatSynchroDt.Rows.Count > 0 Then
                vEtatSynchro = vEtatSynchroDt.Rows(0)("LogType")
                BT_DetailSynchro.Enabled = True
            End If
            I_EtatSynchroPrestashop.Text = vEtatSynchro

        Else
            Nouveau()
            InitCombo(I_RefAvoir, My.Settings.CLIConnectionString, "Select id_t_avoir as id,convert(varchar(225),id_t_avoir) + ' - ' + convert(varchar(225),montant) + ' €' as libelle from t_avoir where utilisele is null and id_t_client<0", "libelle", "<Choisir>", "id")
        End If

        MajPosition()
        'refraichissement du nombre d'enregistrements utilisant celui ci
        AffichageVerouillage()
        AffSelect()
        AvoirReportViewer.RefreshReport()
        ChequeCadeauReportViewer.RefreshReport()
        FactureReportViewer.RefreshReport()
        DevisReportViewer.RefreshReport()

        ClearTampon()
        ClearTamponReglement()
        Cursor = Cursors.Default
    End Sub
    Private Sub MajPosition()
        If Not FormCommandeRecherche.bs.Current Is Nothing Then

            If FormCommandeRecherche.bs.Find("Ref commande", id_t_commande_vente) = -1 Then
                'FormCommandeRecherche.bs.MoveFirst()
                'id_t_commande_vente = FormCommandeRecherche.bs.Current.item("Ref commande")
                'Refresh_data()
            End If
            ToolStripLabelPosition.Text = String.Format("{0}/{1}", FormCommandeRecherche.bs.Find("Ref commande", id_t_commande_vente) + 1, FormCommandeRecherche.bs.Count)

            If FormCommandeRecherche.bs.Position = FormCommandeRecherche.bs.Count - 1 Then
                ToolStripButtonMoveNext.Enabled = False
                ToolStripButtonMoveLast.Enabled = False
            Else
                ToolStripButtonMoveNext.Enabled = True
                ToolStripButtonMoveLast.Enabled = True
            End If
            If FormCommandeRecherche.bs.Position = 0 Then
                ToolStripButtonMovePrevious.Enabled = False
                ToolStripButtonMovefirst.Enabled = False
            Else
                ToolStripButtonMovePrevious.Enabled = True
                ToolStripButtonMovefirst.Enabled = True
            End If
        Else
            ToolStripButtonMoveNext.Enabled = False
            ToolStripButtonMoveLast.Enabled = False
            ToolStripButtonMoveNext.Enabled = True
            ToolStripButtonMoveLast.Enabled = True
            ToolStripButtonMovePrevious.Enabled = False
            ToolStripButtonMovefirst.Enabled = False
            ToolStripButtonMovePrevious.Enabled = True
            ToolStripButtonMovefirst.Enabled = True
            ToolStripLabelPosition.Text = String.Format("{0}/{1}", 0, 0)
        End If

    End Sub
    Private Sub Enregistrer()
        Dim i As Integer
        Cursor = Cursors.WaitCursor

        Try

            Me.Validate()

            ' ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━
            ' ✅ NF525 - ÉTAPE 1 : VÉRIFICATION INALTÉRABILITÉ
            ' ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━
            If Not Me.T_CommandeVenteBindingSource.Current Is Nothing Then
                ' BLOCAGE NF525 : Interdire modification d'un ticket validé
                If Not IsDBNull(T_CommandeVenteBindingSource.Current.item("TicketLe")) AndAlso _
                   T_CommandeVenteBindingSource.Current.item("TicketLe").ToString() <> "" Then
                    MessageBox.Show("NF525 : Impossible de modifier un ticket validé." & vbCrLf & _
                                   "Pour corriger, créez un avoir ou un nouveau ticket.", _
                                   "Conformité fiscale", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    LogEventTechnique("TENTATIVE_MODIF_TICKET", _
                                     "Tentative de modification du ticket " & id_t_commande_vente, _
                                     "", gLogin)
                    Exit Sub
                End If

                ' Gestion de l'état de commande (code original)
                If T_CommandeVenteBindingSource.Current.item("ID_EtatCommandeVente").ToString = "" Then
                    T_CommandeVenteBindingSource.Current.item("ID_EtatCommandeVente") = 10
                Else
                    If T_CommandeVenteBindingSource.Current.item("ID_EtatCommandeVente") < 10 Then
                        T_CommandeVenteBindingSource.Current.item("ID_EtatCommandeVente") = 10
                    End If
                End If

                ' Traçabilité (code original)
                Me.T_CommandeVenteBindingSource.Current.item("ModifieLe") = Date.Now
                Me.T_CommandeVenteBindingSource.Current.item("ModifiePar") = gLogin
            End If

            Me.T_CommandeVenteBindingSource.EndEdit()

            ' ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━
            ' ✅ OPTIMISATION : Premier Update pour obtenir l'ID
            ' ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━
            Me.T_CommandeVenteTableAdapter.Update(Me.CLIDataSet.T_CommandeVente)

            If Not Me.T_CommandeVenteBindingSource.Current Is Nothing Then
                id_t_commande_vente = T_CommandeVenteBindingSource.Current.item("Id_t_commandevente")

                ' Associer les lignes de commande
                For i = 0 To DataGridViewCommande.Rows.Count - 1
                    DataGridViewCommande.Rows(i).Cells("Id_t_commandevente").Value = id_t_commande_vente
                Next

                ' Associer les règlements
                For i = 0 To T_ReglementDataGridView.Rows.Count - 1
                    T_ReglementDataGridView.Rows(i).Cells("Idtcommandevente").Value = id_t_commande_vente
                Next
            End If

            ' ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━
            ' ✅ CALCUL DES TOTAUX (avant signature)
            ' ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━
            CalculTotal()
            Me.T_CommandeVenteBindingSource.EndEdit()

            ' ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━
            ' ✅ NF525 - ÉTAPE 2 : SIGNATURE CRYPTOGRAPHIQUE
            ' ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━
            If Not Me.T_CommandeVenteBindingSource.Current Is Nothing Then
                ' Signer UNIQUEMENT si c'est un ticket (TicketLe renseigné)
                ' Les devis/commandes temporaires ne sont PAS signés
                If Not IsDBNull(T_CommandeVenteBindingSource.Current.item("TicketLe")) AndAlso _
                   T_CommandeVenteBindingSource.Current.item("TicketLe").ToString() <> "" Then

                    Try
                        ' Récupérer la ligne en cours (Header)
                        Dim ticketRow As CLIDataSet.T_CommandeVenteRow = _
                            DirectCast(Me.T_CommandeVenteBindingSource.Current.Row, CLIDataSet.T_CommandeVenteRow)

                        ' Récupérer les lignes de détail
                        Dim lignesFiltrees() As Data.DataRow = Me.CLIDataSet.T_CommandeVente_Ligne.Select( _
                            "ID_T_CommandeVente=" & id_t_commande_vente)

                        Dim linesTable As New CLIDataSet.T_CommandeVente_LigneDataTable()
                        For Each ligne As Data.DataRow In lignesFiltrees
                            linesTable.ImportRow(ligne)
                        Next

                        ' ✅ APPEL AU MODULE NF525
                        NF525.SignatureHelper.SignTransaction(ticketRow, linesTable)

                        ' Copier les signatures calculées dans les lignes du DataSet
                        For Each ligneCalc As CLIDataSet.T_CommandeVente_LigneRow In linesTable.Rows
                            For Each ligneOriginale As CLIDataSet.T_CommandeVente_LigneRow In Me.CLIDataSet.T_CommandeVente_Ligne.Rows
                                If ligneOriginale.ID_T_CommandeVente_Ligne = ligneCalc.ID_T_CommandeVente_Ligne Then
                                    ligneOriginale.Signature = ligneCalc.Signature
                                    If Not ligneCalc.IsPreviousSignatureNull Then
                                        ligneOriginale.PreviousSignature = ligneCalc.PreviousSignature
                                    End If
                                    Exit For
                                End If
                            Next
                        Next

                        ' Logger l'événement NF525
                        LogEventTechnique("SIGNATURE_TICKET", _
                                         "Signature NF525 du ticket " & id_t_commande_vente, _
                                         "", "Signature: " & ticketRow.Signature.Substring(0, Math.Min(16, ticketRow.Signature.Length)) & "...")
                    Catch ex As Exception
                        ' Logger l'erreur mais ne pas bloquer l'enregistrement
                        LogEventTechnique("ERREUR_SIGNATURE", _
                                         "Erreur signature ticket " & id_t_commande_vente & " : " & ex.Message, _
                                         "", ex.StackTrace)
                    End Try
                End If
            End If

            ' ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━
            ' ✅ MISE À JOUR FINALE (avec signatures)
            ' ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━
            Me.T_CommandeVenteBindingSource.EndEdit()
            Me.T_CommandeVenteTableAdapter.Update(Me.CLIDataSet.T_CommandeVente)

            Me.TCommandeVenteLigneBindingSource.EndEdit()
            Me.T_CommandeVente_LigneTableAdapter.Update(Me.CLIDataSet.T_CommandeVente_Ligne)

            Me.T_ReglementBindingSource.EndEdit()
            Me.T_ReglementTableAdapter.Update(Me.CLIDataSet.T_Reglement)

            ' ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━
            ' ✅ SYNCHRONISATIONS EXTERNES
            ' ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━
            If Not Me.T_CommandeVenteBindingSource.Current Is Nothing Then
                Me.T_EtatCommandeVenteTableAdapter.FillByID_T_EtatCommandeVente( _
                    Me.CLIDataSet.T_EtatCommandeVente, _
                    T_CommandeVenteBindingSource.Current.item("ID_EtatCommandeVente"))

                'On synchronise les avoirs
                SynchroAvoir()

                'remise à 0 ???
                'id_t_commande_vente = 0
            End If


            'rafraichissement du moteur de recherche et repositionnement sur l'enregistrement
            RafraichissementDuMoteurDeRecherche()
            MajPosition()
            AffichageVerouillage()
            AffSelect()
            AvoirReportViewer.RefreshReport()
            FactureReportViewer.RefreshReport()
        Catch ex As Exception

        Finally
            Cursor = Cursors.Default
        End Try


    End Sub
    Private Sub EnregistrerAvCommande(ByVal pID_EtatCommande As Integer)
        Dim i As Integer

        Cursor = Cursors.WaitCursor

        Try

            Me.Validate()


            If Not Me.T_CommandeVenteBindingSource.Current Is Nothing Then
                If T_CommandeVenteBindingSource.Current.item("ID_EtatCommandeVente").ToString = "" Then
                    T_CommandeVenteBindingSource.Current.item("ID_EtatCommandeVente") = pID_EtatCommande
                Else
                    If T_CommandeVenteBindingSource.Current.item("ID_EtatCommandeVente") < 10 Then
                        T_CommandeVenteBindingSource.Current.item("ID_EtatCommandeVente") = pID_EtatCommande
                    End If
                End If

                Me.T_CommandeVenteBindingSource.Current.item("ModifieLe") = Date.Now
                Me.T_CommandeVenteBindingSource.Current.item("ModifiePar") = gLogin
            End If

            Me.T_CommandeVenteBindingSource.EndEdit()

            Me.T_CommandeVenteTableAdapter.Update(Me.CLIDataSet.T_CommandeVente)
            CalculTotal()

            Me.T_CommandeVenteBindingSource.EndEdit()

            Me.T_CommandeVenteTableAdapter.Update(Me.CLIDataSet.T_CommandeVente)
            If Not Me.T_CommandeVenteBindingSource.Current Is Nothing Then
                id_t_commande_vente = T_CommandeVenteBindingSource.Current.item("Id_t_commandevente")
                Me.T_EtatCommandeVenteTableAdapter.FillByID_T_EtatCommandeVente(Me.CLIDataSet.T_EtatCommandeVente, T_CommandeVenteBindingSource.Current.item("ID_EtatCommandeVente"))

                For i = 0 To DataGridViewCommande.Rows.Count - 1

                    DataGridViewCommande.Rows(i).Cells("Id_t_commandevente").Value = id_t_commande_vente

                Next
                Me.TCommandeVenteLigneBindingSource.EndEdit()
                Me.T_CommandeVente_LigneTableAdapter.Update(Me.CLIDataSet.T_CommandeVente_Ligne)

                For i = 0 To T_ReglementDataGridView.Rows.Count - 1

                    T_ReglementDataGridView.Rows(i).Cells("Idtcommandevente").Value = id_t_commande_vente

                Next
                Me.T_ReglementBindingSource.EndEdit()
                Me.T_ReglementTableAdapter.Update(Me.CLIDataSet.T_Reglement)

            Else
                id_t_commande_vente = 0
            End If


            'rafraichissement du moteur de recherche et repositionnement sur l'enregistrement
            RafraichissementDuMoteurDeRecherche()
            MajPosition()
            AffichageVerouillage()
            AffSelect()
            AvoirReportViewer.RefreshReport()
            FactureReportViewer.RefreshReport()
        Catch ex As Exception

        Finally
            Cursor = Cursors.Default
        End Try


    End Sub


    Private Sub RafraichissementDuMoteurDeRecherche()
        If FormCommandeRecherche.Visible Then
            FormCommandeRecherche.Recherche(False, False)
            FormCommandeRecherche.bs.Position = FormCommandeRecherche.bs.Find("Ref Commande", id_t_commande_vente)
        End If
    End Sub
    Private Sub Facture()
        Dim vReportParameters(1) As ReportParameter
        T_CommandeVenteBindingSource.EndEdit()
        If T_CommandeVenteBindingSource.Current.item("Nom").ToString <> "" And T_CommandeVenteBindingSource.Current.item("Prénom").ToString <> "" Then

            If T_CommandeVenteBindingSource.Current.item("FactureLe").ToString = "" Then
                'on teste que les champs obligatoires pour faire une facture
                'on enregistre la date
                T_CommandeVenteBindingSource.Current.item("FactureLe") = Now()
                'changement de l'état
                If T_CommandeVenteBindingSource.Current.item("ID_EtatCommandeVente") < 30 Then
                    T_CommandeVenteBindingSource.Current.item("ID_EtatCommandeVente") = 30
                End If
                'T_CommandeVenteBindingSource.EndEdit()
                'Enregistrer()


            End If
            T_CommandeVenteBindingSource.EndEdit()
            Enregistrer()
            Dim vMontantAvoir As String = IIf(AvoirCreeNoTextBox.Text <> "0" And AvoirCreeNoTextBox.Text <> "", MontantARendreTTCTextBox.Text, "0")

            vReportParameters(0) = New ReportParameter("MontantAvoir", vMontantAvoir)
            vReportParameters(1) = New ReportParameter("ReferenceCommandePrestashop", T_CommandeVenteBindingSource.Current.item("ReferenceCommandePrestashop").ToString())

            FactureReportViewer.LocalReport.SetParameters(vReportParameters)
            Refresh_data()



            Do While Not vFactureReportComplete
                Application.DoEvents()
            Loop
            FactureReportViewer.PrintDialog()

            Try

                'modif du 18/04/2015
                'upload de la facture si commande web



                If T_CommandeVenteBindingSource.Current.item("web_on") = True Then
                    'creation de la facture en local puis upload

                    Dim warnings As Warning() = Nothing
                    Dim streamids As String() = Nothing
                    Dim mimeType As String = Nothing
                    Dim encoding As String = Nothing
                    Dim extension As String = Nothing
                    Dim bytes As Byte()

                    bytes = FactureReportViewer.LocalReport.Render("PDF",
                      Nothing, mimeType,
                        encoding, extension, streamids, warnings)

                    'On syncrhonise la facture avec prestashop si c'est une commande prestashop
                    If T_CommandeVenteBindingSource.Current.item("ReferenceCommandePrestashop").ToString() <> "" Then
                        Dim toCliDto As New ToCliDto()
                        toCliDto.Id = T_CommandeVenteBindingSource.Current.item("ID_T_CommandeVente")
                        toCliDto.FactureData = bytes
                        CliApi.OrderSetInvoiceByOrderIdAsync(toCliDto)
                    End If


                    'Dim fs As New FileStream(gChemin_local_facture, FileMode.Create)
                    'fs.Write(bytes, 0, bytes.Length)
                    'fs.Close()



                    'Dim client As New Utilities.FTP.FTPclient
                    ''Dim client As New FtpConnection
                    'client.Hostname = gFTP_host
                    'client.Username = gFTP_UID
                    'client.Password = gFTP_PWD

                    'client.Upload(gChemin_local_facture, gChemin_Facture & T_CommandeVenteBindingSource.Current.item("ID_T_CommandeVente") & ".pdf")
                End If

            Catch ex As Exception

            End Try



        Else
            MessageBox.Show("Merci de saisir au moins un nom et un prénom dans l'entête de commande pour établir la facture", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End If


    End Sub
    Private Sub EtatCommande(ByVal pIdEtatCommande As Integer, Optional ByVal bPrint As Boolean = False)
        Dim vTitre As String = ""
        Dim vBL As Boolean = False
        EnregistrerAvCommande(pIdEtatCommande)
        T_CommandeVenteBindingSource.EndEdit()

        Dim vReportParameters(1) As ReportParameter

        'changement de l'etat en fonction
        Select Case pIdEtatCommande
            Case "4"
                vTitre = "Test"
                vBL = False
            Case "5"
                vTitre = "Devis"
                vBL = False
            Case "6"
                vTitre = "Réservation"
                vBL = False
            Case "10"
                vTitre = "Commande"
                vBL = False
            Case "999"
                vTitre = "Bon de livraison"
                vBL = True
        End Select


        vReportParameters(0) = New ReportParameter("Titre", vTitre)
        vReportParameters(1) = New ReportParameter("BL", vBL)
        DevisReportViewer.LocalReport.SetParameters(vReportParameters)
        Refresh_data()

        Do While Not vDevisReportComplete
            Application.DoEvents()
        Loop
        If bPrint Then
            DevisReportViewer.PrintDialog()
        End If








    End Sub
    Private Sub EnvoiFacture()
        Dim vReportParameters(1) As ReportParameter
        T_CommandeVenteBindingSource.EndEdit()
        If T_CommandeVenteBindingSource.Current.item("nom").ToString() <> "" And T_CommandeVenteBindingSource.Current.item("Prénom").ToString <> "" Then

            If T_CommandeVenteBindingSource.Current.item("FactureLe").ToString = "" Then
                'on teste que les champs obligatoires pour faire une facture
                'on enregistre la date
                T_CommandeVenteBindingSource.Current.item("FactureLe") = Now()
                'changement de l'état
                If T_CommandeVenteBindingSource.Current.item("ID_EtatCommandeVente") < 30 Then
                    T_CommandeVenteBindingSource.Current.item("ID_EtatCommandeVente") = 30
                End If
                'T_CommandeVenteBindingSource.EndEdit()

                'Enregistrer()

            End If
            T_CommandeVenteBindingSource.EndEdit()

            Enregistrer()

            Dim vMontantAvoir As String = IIf(AvoirCreeNoTextBox.Text <> "0" And AvoirCreeNoTextBox.Text <> "", MontantARendreTTCTextBox.Text, "0")

            vReportParameters(0) = New ReportParameter("MontantAvoir", vMontantAvoir)
            vReportParameters(1) = New ReportParameter("ReferenceCommandePrestashop", T_CommandeVenteBindingSource.Current.item("ReferenceCommandePrestashop").ToString())

            FactureReportViewer.LocalReport.SetParameters(vReportParameters)
            Refresh_data()

            Do While Not vFactureReportComplete
                Application.DoEvents()
            Loop
            Dim warnings As Warning() = Nothing
            Dim streamids As String() = Nothing
            Dim mimeType As String = Nothing
            Dim encoding As String = Nothing
            Dim extension As String = Nothing
            Dim bytes As Byte()

            bytes = FactureReportViewer.LocalReport.Render("PDF",
              Nothing, mimeType,
                encoding, extension, streamids, warnings)

            'On syncrhonise la facture avec prestashop si c'est une commande prestashop
            If T_CommandeVenteBindingSource.Current.item("ReferenceCommandePrestashop").ToString() <> "" Then
                Dim toCliDto As New ToCliDto()
                toCliDto.Id = T_CommandeVenteBindingSource.Current.item("ID_T_CommandeVente")
                toCliDto.FactureData = bytes
                CliApi.OrderSetInvoiceByOrderIdAsync(toCliDto)
            End If

            Dim fs As New FileStream(gChemin_local_facture, FileMode.Create)
            fs.Write(bytes, 0, bytes.Length)
            fs.Close()
            Dim f As New FormMailFacture
            f.vEmailClient = T_CommandeVenteBindingSource.Current.item("email").ToString()
            f.I_From.Text = gEmailFacture

            f.vNumFacture = T_CommandeVenteBindingSource.Current.item("id_t_commandevente").ToString()
            f.I_smtp.Text = gSmtp
            If f.ShowDialog() = Windows.Forms.DialogResult.OK Then
                MessageBox.Show("Message envoyé", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                MessageBox.Show("Message annulé", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If



        Else
            MessageBox.Show("Merci de saisir au moins un nom,un prénom dans l'entête de commande pour établir et envoyer la facture", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End If


    End Sub

    Private Sub EnvoiEtatCommande()
        T_CommandeVenteBindingSource.EndEdit()
        EtatCommande(T_CommandeVenteBindingSource.Current("id_etatcommandevente"), False)
        If T_CommandeVenteBindingSource.Current.item("nom").ToString() <> "" And T_CommandeVenteBindingSource.Current.item("Prénom").ToString <> "" Then


            Refresh_data()

            Do While Not vDevisReportComplete
                Application.DoEvents()
            Loop
            Dim warnings As Warning() = Nothing
            Dim streamids As String() = Nothing
            Dim mimeType As String = Nothing
            Dim encoding As String = Nothing
            Dim extension As String = Nothing
            Dim bytes As Byte()
            Dim vTypeDocument As String = ""


            bytes = DevisReportViewer.LocalReport.Render("PDF",
              Nothing, mimeType,
                encoding, extension, streamids, warnings)

            Dim fs As New FileStream(gChemin_local_piece_jointe, FileMode.Create)
            fs.Write(bytes, 0, bytes.Length)
            fs.Close()
            Dim f As New FormMail
            f.Text = "Envoi d'email"

            f.vEmailClient = T_CommandeVenteBindingSource.Current.item("email").ToString()
            f.I_From.Text = gEmailFacture

            f.vNumFacture = T_CommandeVenteBindingSource.Current.item("id_t_commandevente").ToString()
            Select Case T_CommandeVenteBindingSource.Current.item("id_Etatcommandevente").ToString()
                Case "4"
                    vTypeDocument = "Prêt/test"
                Case "5"
                    vTypeDocument = "devis"
                Case "6"
                    vTypeDocument = "réservation"
            End Select
            f.I_smtp.Text = gSmtp
            f.I_subject.Text = "Votre " & vTypeDocument & " www.chinook-leucate.com n°" & f.vNumFacture
            f.I_message.Text = "Madame, Monsieur," & vbCrLf & "Veuillez-trouver ci-jointe votre " & vTypeDocument & "  n°" & f.vNumFacture & vbCrLf & "Cordialement," & vbCrLf & "L'équipe www.chinook-leucate.com"

            If f.ShowDialog() = Windows.Forms.DialogResult.OK Then
                MessageBox.Show("Message envoyé", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                MessageBox.Show("Message annulé", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If



        Else
            MessageBox.Show("Merci de saisir au moins un nom,un prénom dans l'entête de commande pour l'envoi", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End If


    End Sub

    Private Sub SortirStock()
        If T_CommandeVenteBindingSource.Current.item("ExpedieLe").ToString = "" Then
            'Creation d'avoir en auto
            CreationAutoAvoir()


            Dim r As DataRowView
            Dim stock_actuel As Double = 0
            For Each r In TCommandeVenteLigneBindingSource
                If r.Item("ID_T_Article_version").ToString <> "0" And r.Item("ID_T_Article_version").ToString <> "1" And r.Item("ID_T_Article_version").ToString <> "2" And r.Item("ID_T_Article_version").ToString <> "3" And r.Item("ID_T_Article_version").ToString <> "4" And r.Item("ID_T_Article_version").ToString <> "5" And r.Item("ID_T_Article_version").ToString <> "6" Then
                    'effectuer les sorties de stock
                    Dim cnn As New SqlClient.SqlConnection(My.Settings.CLIConnectionString)
                    cnn.Open()
                    Dim command As New SqlClient.SqlCommand

                    command.Connection = cnn
                    'modif pour enlever la notion de stock par site
                    'command.CommandText = "select * from v_article_stock_numcaisse where numcaisse=" & I_Caisse.Text & " and ID_t_article_version=" & r.Item("ID_T_Article_version").ToString
                    command.CommandText = "select * from v_article_stock where ID_t_article_version=" & r.Item("ID_T_Article_version").ToString

                    Dim reader As SqlClient.SqlDataReader = command.ExecuteReader
                    If reader.HasRows Then
                        reader.Read()
                        If IsNumeric(reader("stock")) Then
                            stock_actuel = reader("stock")
                        Else
                            stock_actuel = 0
                        End If
                    End If
                    reader.Close()
                    'Pas de stock négatif permis
                    If stock_actuel - CDbl(r.Item("qte")) >= 0 Then
                        command.CommandText = "INSERT INTO T_Article_Stock (id_t_article_version,operation,date,signature,id_t_commande_vente,numcaisse) VALUES (" & r.Item("ID_T_Article_version") & ",- " & r.Item("qte").ToString.Replace(",", ".") & ",getdate(),'" & gLogin & "'," & r.Item("ID_T_CommandeVente") & "," & I_Caisse.Text & ")"
                        command.ExecuteNonQuery()

                    Else
                        MessageBox.Show("Probleme de stock sur le site : " & I_Caisse.Text & " pour l'article Ref :" & r.Item("ID_T_Article_version").ToString, "Attention", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        command.CommandText = "INSERT INTO T_Article_Stock (id_t_article_version,operation,date,signature,id_t_commande_vente,numcaisse) VALUES (" & r.Item("ID_T_Article_version") & ",- " & r.Item("qte").ToString.Replace(",", ".") & ",getdate(),'" & gLogin & "'," & r.Item("ID_T_CommandeVente") & "," & I_Caisse.Text & ")"
                        command.ExecuteNonQuery()
                    End If
                    'desactivation de l'article s'il est en stock limite, d'occaz ou en depot_vente ou en test
                    command.CommandText = "UPDATE       dbo.T_Article_version" &
                    " set  Active_on = 0" &
" FROM            dbo.T_Article_version INNER JOIN" &
"                         dbo.V_Article_Stock ON dbo.T_Article_version.ID_t_article_version = dbo.V_Article_Stock.ID_t_article_version" &
" WHERE       (dbo.V_Article_Stock.id_t_article_version= " & r.Item("ID_T_Article_version") & ") AND  (dbo.V_Article_Stock.Stock = 0) AND (dbo.T_Article_version.occaz = 1 OR dbo.T_Article_version.depot_vente = 1 or  dbo.T_Article_version.stock_limite = 1 OR dbo.T_Article_version.test = 1 )"
                    command.ExecuteNonQuery()
                    cnn.Close()

                    'synchronisation de l'article et synchro du stock
                    CliApi.ProductAddOrUpdatePSfromCLIByIdAsync(New ToCliDto() With {.Id = r.Item("ID_T_Article_version").ToString, .AssociatedAddress = False, .AssociatedCartRule = False, .AssociatedLegacyImages = False, .ImportStock = True})
                End If

            Next

            'on enregistre la date
            T_CommandeVenteBindingSource.Current.item("ExpedieLe") = Now()
            'changement de l'état
            T_CommandeVenteBindingSource.Current.item("ID_EtatCommandeVente") = 40
            'Enregistrement dans la table
            Enregistrer()
        End If
    End Sub
    Private Sub TicketDeCaisse(Optional impression As Boolean = False)

        If T_CommandeVenteBindingSource.Current.item("TicketLe").ToString = "" Then

            'changement de l'état
            If T_CommandeVenteBindingSource.Current.item("ID_EtatCommandeVente") < 25 Then
                T_CommandeVenteBindingSource.Current.item("ID_EtatCommandeVente") = 25
            End If


        End If
        'on enregistre la date
        T_CommandeVenteBindingSource.Current.item("TicketLe") = Now()
        Me.V_reglementTableAdapter.FillBy_id_t_commandevente(Me.CLIDataSet.V_reglement, id_t_commande_vente)

        T_CommandeVenteBindingSource.EndEdit()

        'Enregistrement dans la table
        Enregistrer()
        'Impression du ticket
        If impression Then
            If Not m_Printer Is Nothing Then
                ImpressionTicketCaisse()

            End If
        End If

        'sortie automatique des stock si commande <> web
        If T_CommandeVenteBindingSource.Current.item("web_on").ToString <> "True" Then
            SortirStock()
        End If
    End Sub
    Sub ImpressionTicketCaisse()
        Dim stream As System.IO.StreamWriter = My.Computer.FileSystem.OpenTextFileWriter("c:\temp\cli\log_tickets.txt", True)
        stream.WriteLine("############ " & Now.ToString)
        stream.WriteLine("Commande :" & id_t_commande_vente)


        Dim z As Integer
        '<<<step2>>>--Start
        'Initialization
        Dim ESC As String
        Dim dateTime As DateTime = New DateTime
        Dim dateFormat As DateTimeFormatInfo = New DateTimeFormatInfo
        Dim strDate As String
        Dim strbcData As String
        Dim sRecLineChars() As String = {""}
        Dim lRecLineCharsCount As Long

        '<<<step4>>--Start
        strbcData = id_t_commande_vente
        '<<<ste4>>--End
        Dim DescString As String = ""
        Dim ItemString As String = ""
        Dim PriceString As String = ""

        Dim DescItem As New Collection
        Dim astrItem As New Collection
        Dim astrPrice As New Collection
        Dim remise As String = ""
        
        ' Récupération des données NF525 (Signature et Grand Total)
        Dim currentTicketId As Long = id_t_commande_vente
        Dim currentSignature As String = T_CommandeVenteBindingSource.Current.item("Signature").ToString()
        Dim grandTotalActuel As Decimal = ModuleNF525.GetGrandTotalActuel()

        stream.WriteLine("Nombre de ligne de commande : " & DataGridViewCommande.RowCount)
        stream.WriteLine("Signature NF525 : " & currentSignature)
        stream.WriteLine("Grand Total Perpétuel : " & grandTotalActuel.ToString("F2") & " €")
        For z = 0 To DataGridViewCommande.RowCount - 1
            If DataGridViewCommande.Rows(z).Cells("remise").Value <> 0 Then
                remise = " (-" & DataGridViewCommande.Rows(z).Cells("remise").Value * 100 & " %)"
            Else
                remise = ""

            End If
            DescItem.Add(DataGridViewCommande.Rows(z).Cells("Ref").Value.ToString & ", " & DataGridViewCommande.Rows(z).Cells("designation").Value.ToString)
            astrItem.Add(IIf(remise <> "", remise & " ", "") & DataGridViewCommande.Rows(z).Cells("qte").Value.ToString & " x " & FormatNumber(DataGridViewCommande.Rows(z).Cells("puremisettc").Value.ToString, 2))
            astrPrice.Add(FormatNumber(DataGridViewCommande.Rows(z).Cells("totalLigne").Value.ToString, 2))


        Next

        'Dim DescItem() As String = {DescString}
        'Dim astrItem() As String = {ItemString}
        'Dim astrPrice() As String = {ItemString}

        'ESC command
        ESC = Chr(&H1B)

        'Get Not Date
        dateTime = System.DateTime.Now()

        dateFormat.MonthDayPattern = "MMMM"

        strDate = dateTime.ToString("dd/mm/yyyy,  HH:mm", dateFormat)
        strDate = FormatDateTime(T_CommandeVenteBindingSource.Current.item("TicketLe"), Microsoft.VisualBasic.DateFormat.ShortDate) & " " & FormatDateTime(T_CommandeVenteBindingSource.Current.item("TicketLe"), Microsoft.VisualBasic.DateFormat.ShortTime)

        '<<<step6>>>--Start
        'When outputting to a printer,a mouse cursor becomes like a hourglass.
        System.Windows.Forms.Cursor.Current = Cursors.WaitCursor

        If m_Printer.CapRecPresent = True Then

            Try

                '<<<step6>>>--Start
                'Batch processing mode
                m_Printer.TransactionPrint(PrinterStation.Receipt _
                 , PrinterTransactionControl.Transaction)

                '<<<step3>>>--Start
                m_Printer.PrintNormal(PrinterStation.Receipt, ESC + "|1B")
                '<<<step3>>>--End

                'Print address
                m_Printer.PrintNormal(PrinterStation.Receipt, ESC + "|N" _
                + vbCrLf + "rte de leucate plage 11370 France" + vbCrLf + "RCS Narbonne B 484 501 481" + vbCrLf + "Siret : 48 450148100010" + vbCrLf)
                'Print phone number
                m_Printer.PrintNormal(PrinterStation.Receipt, ESC + "|rA" _
                + "TEL: (+33) 04.68.40.17.17" + vbCrLf)
                m_Printer.PrintNormal(PrinterStation.Receipt, ESC + "|rA" _
+ "FAX: (+33) 04.68.40.29.29" + vbCrLf)
                m_Printer.PrintNormal(PrinterStation.Receipt, ESC + "|rA" _
+ "Mél: contact@chinook-leucate.com" + vbCrLf + "Web : www.chinook-leucate.com" + vbCrLf)

                '<<<step5>>>--Start
                'Make 2mm speces
                'ESC|#uF = Line Feed
                m_Printer.PrintNormal(PrinterStation.Receipt, ESC + "|200uF")
                '<<<step5>>>--End

                'Change the font size and print the date
                'ESC|cA = Centering char
                lRecLineCharsCount = GetRecLineChars(sRecLineChars)
                If lRecLineCharsCount >= 2 Then
                    m_Printer.RecLineChars = sRecLineChars(1)
                    m_Printer.PrintNormal(PrinterStation.Receipt, ESC + "|cA" + strDate + vbCrLf + vbCrLf)
                    m_Printer.RecLineChars = sRecLineChars(0)
                Else
                    m_Printer.PrintNormal(PrinterStation.Receipt, ESC + "|cA" + strDate + vbCrLf + vbCrLf)
                End If

                'Print buying goods
                Dim total As Double = 0.0
                Dim strPrintData As String = ""
                strPrintData = MakePrintString(m_Printer.RecLineChars, "Code, Designation", "")
                m_Printer.PrintNormal(PrinterStation.Receipt, strPrintData + vbCrLf)
                strPrintData = MakePrintString(m_Printer.RecLineChars, "Qté x Prix Unit. (remise)", "Total")
                m_Printer.PrintNormal(PrinterStation.Receipt, strPrintData + vbCrLf)
                strPrintData = MakePrintString(m_Printer.RecLineChars, "------------------------------------------", "")
                m_Printer.PrintNormal(PrinterStation.Receipt, strPrintData + vbCrLf)
                For i As Integer = 1 To astrItem.Count
                    strPrintData = MakePrintString(m_Printer.RecLineChars, DescItem(i), "")
                    m_Printer.PrintNormal(PrinterStation.Receipt, strPrintData + vbCrLf)
                    strPrintData = MakePrintString(m_Printer.RecLineChars, astrItem(i), FormatCurrency(astrPrice(i), 2))
                    m_Printer.PrintNormal(PrinterStation.Receipt, strPrintData + vbCrLf)



                Next

                'Make 2mm speces
                m_Printer.PrintNormal(PrinterStation.Receipt, ESC + "|200uF")

                'Print the total cost
                strPrintData = MakePrintString(m_Printer.RecLineChars / 2, "Total" _
                , FormatCurrency(T_CommandeVenteBindingSource.Current.item("Total_TTC"), 2))

                m_Printer.PrintNormal(PrinterStation.Receipt, ESC + "|2C" + strPrintData + vbCrLf)

                'bloc impression reglement

                'boucle sur t_reglement avec encaisse_le is not null
                m_Printer.PrintNormal(PrinterStation.Receipt, ESC + "|N" _
                + vbCrLf + "Encaissé" + vbCrLf)
                stream.WriteLine("Nombre de ligne de règlement : " & Me.CLIDataSet.V_reglement.Rows.Count)
                For i As Integer = 0 To Me.CLIDataSet.V_reglement.Rows.Count - 1
                    If Not CLIDataSet.V_reglement.Rows(i).Item("encaisse_le") Is DBNull.Value Then
                        stream.WriteLine("règlement : " & CLIDataSet.V_reglement.Rows(i).Item("Libelle_modereglement") & " : " & CLIDataSet.V_reglement.Rows(i).Item("Libelle_moyenpaiement") & " (" & FormatDateTime(CLIDataSet.V_reglement.Rows(i).Item("encaisse_le"), Microsoft.VisualBasic.DateFormat.ShortDate) & ")", FormatCurrency(CLIDataSet.V_reglement.Rows(i).Item("montant"), 2))
                        strPrintData = MakePrintString(m_Printer.RecLineChars, CLIDataSet.V_reglement.Rows(i).Item("Libelle_modereglement") & " : " & CLIDataSet.V_reglement.Rows(i).Item("Libelle_moyenpaiement") & " (" & FormatDateTime(CLIDataSet.V_reglement.Rows(i).Item("encaisse_le"), Microsoft.VisualBasic.DateFormat.ShortDate) & ")", FormatCurrency(CLIDataSet.V_reglement.Rows(i).Item("montant"), 2))
                        'strPrintData = MakePrintString(50, CLIDataSet.V_reglement.Rows(i).Item("Libelle_modereglement") & " : " & CLIDataSet.V_reglement.Rows(i).Item("Libelle_moyenpaiement") & " (" & FormatDateTime(CLIDataSet.V_reglement.Rows(i).Item("encaisse_le"), Microsoft.VisualBasic.DateFormat.ShortDate) & ")", FormatNumber(CLIDataSet.V_reglement.Rows(i).Item("montant"), 2))
                        m_Printer.PrintNormal(PrinterStation.Receipt, strPrintData + vbCrLf)
                    End If
                Next
                m_Printer.PrintNormal(PrinterStation.Receipt, ESC + "|N" _
              + vbCrLf + "Echéance(s)" + vbCrLf)
                For i As Integer = 0 To Me.CLIDataSet.V_reglement.Rows.Count - 1
                    If CLIDataSet.V_reglement.Rows(i).Item("encaisse_le") Is DBNull.Value Then
                        stream.WriteLine("règlement : " & CLIDataSet.V_reglement.Rows(i).Item("Libelle_modereglement") & " : " & CLIDataSet.V_reglement.Rows(i).Item("Libelle_moyenpaiement") & " (" & FormatDateTime(CLIDataSet.V_reglement.Rows(i).Item("echeance_le"), Microsoft.VisualBasic.DateFormat.ShortDate) & ")", FormatCurrency(CLIDataSet.V_reglement.Rows(i).Item("montant"), 2))
                        strPrintData = MakePrintString(m_Printer.RecLineChars, CLIDataSet.V_reglement.Rows(i).Item("Libelle_modereglement") & " : " & CLIDataSet.V_reglement.Rows(i).Item("Libelle_moyenpaiement") & " (" & FormatDateTime(CLIDataSet.V_reglement.Rows(i).Item("echeance_le"), Microsoft.VisualBasic.DateFormat.ShortDate) & ")", FormatCurrency(CLIDataSet.V_reglement.Rows(i).Item("montant"), 2))
                        m_Printer.PrintNormal(PrinterStation.Receipt, strPrintData + vbCrLf)
                    End If
                Next
                'strPrintData = MakePrintString(m_Printer.RecLineChars, T_CommandeVenteBindingSource.Current.item("ModeReglement") _
                '   , FormatNumber(T_CommandeVenteBindingSource.Current.item("MontantPaiementTTC"), 2))
                'm_Printer.PrintNormal(PrinterStation.Receipt, strPrintData + vbCrLf)
                '            If T_CommandeVenteBindingSource.Current.item("AvoirUtiliseMontant") <> 0 Then
                '                strPrintData = MakePrintString(m_Printer.RecLineChars, "Avoir utilisé" _
                ', FormatNumber(T_CommandeVenteBindingSource.Current.item("AvoirUtiliseMontant"), 2))
                '                m_Printer.PrintNormal(PrinterStation.Receipt, strPrintData + vbCrLf)
                '            End If


                If T_CommandeVenteBindingSource.Current.item("MontantRenduTTC") <> 0 Then
                    strPrintData = MakePrintString(m_Printer.RecLineChars, "Rendu" _
    , FormatCurrency(T_CommandeVenteBindingSource.Current.item("MontantRenduTTC"), 2))
                    m_Printer.PrintNormal(PrinterStation.Receipt, strPrintData + vbCrLf)
                End If
                strPrintData = ""
                m_Printer.PrintNormal(PrinterStation.Receipt, ESC + "|uC" + strPrintData + vbCrLf)
                If T_CommandeVenteBindingSource.Current.item("AvoirCreeNo") <> 0 Then
                    strPrintData = MakePrintString(m_Printer.RecLineChars, "Avoir créé" _
    , T_CommandeVenteBindingSource.Current.item("AvoirCreeNo"))
                    m_Printer.PrintNormal(PrinterStation.Receipt, strPrintData + vbCrLf)
                    'strPrintData = MakePrintString(m_Printer.RecLineChars, "Montant Avoir créé" _
                    ', FormatNumber(T_CommandeVenteBindingSource.Current.item("MontantPaiementTTC") + T_CommandeVenteBindingSource.Current.item("AvoirUtiliseMontant") - T_CommandeVenteBindingSource.Current.item("Total_ttc"), 2))
                    strPrintData = MakePrintString(m_Printer.RecLineChars, "Montant Avoir créé" _
, FormatCurrency(T_CommandeVenteBindingSource.Current.item("MontantPaiementTTC") - T_CommandeVenteBindingSource.Current.item("Total_ttc"), 2))
                    m_Printer.PrintNormal(PrinterStation.Receipt, strPrintData + vbCrLf)
                End If
                strPrintData = ""
                m_Printer.PrintNormal(PrinterStation.Receipt, ESC + "|uC" + strPrintData + vbCrLf)

                strPrintData = MakePrintString(m_Printer.RecLineChars, "Total HT",
                FormatCurrency(T_CommandeVenteBindingSource.Current.item("Total_HT"), 2))
                m_Printer.PrintNormal(PrinterStation.Receipt, strPrintData + vbCrLf)


                strPrintData = MakePrintString(m_Printer.RecLineChars, "TVA 5.5%",
                FormatCurrency(T_CommandeVenteBindingSource.Current.item("Total_55"), 2))
                m_Printer.PrintNormal(PrinterStation.Receipt, strPrintData + vbCrLf)

                'test si commande creele avant 1er janvier 2014, alors tva 19.6 sinon 20 --cbt 14122013
                Dim libelleTVA196 As String = "19.6"
                If CDate(T_CommandeVenteBindingSource.Current.item("creele")) >= "01/01/2014" Then
                    libelleTVA196 = "20"
                End If
                strPrintData = MakePrintString(m_Printer.RecLineChars, "TVA " & libelleTVA196 & "%",
FormatCurrency(T_CommandeVenteBindingSource.Current.item("Total_196"), 2))
                m_Printer.PrintNormal(PrinterStation.Receipt, strPrintData + vbCrLf)

                strPrintData = MakePrintString(m_Printer.RecLineChars, "TOTAL TTC",
                FormatCurrency(T_CommandeVenteBindingSource.Current.item("Total_TTC_avantDeduction"), 2))
                m_Printer.PrintNormal(PrinterStation.Receipt, strPrintData + vbCrLf)

                strPrintData = MakePrintString(m_Printer.RecLineChars, "Montant déduit",
FormatCurrency(T_CommandeVenteBindingSource.Current.item("montant_deduire"), 2))
                m_Printer.PrintNormal(PrinterStation.Receipt, strPrintData + vbCrLf)

                strPrintData = MakePrintString(m_Printer.RecLineChars, "Montant net à payer",
FormatCurrency(T_CommandeVenteBindingSource.Current.item("Total_ttc"), 2))
                m_Printer.PrintNormal(PrinterStation.Receipt, strPrintData + vbCrLf)


                'Make 5mm speces
                m_Printer.PrintNormal(PrinterStation.Receipt, ESC + "|500uF")

                strPrintData = MakePrintString(m_Printer.RecLineChars, "Vendeur",
T_CommandeVenteBindingSource.Current.item("CreePar"))
                m_Printer.PrintNormal(PrinterStation.Receipt, strPrintData + vbCrLf)

                strPrintData = MakePrintString(m_Printer.RecLineChars, "Site",
T_CommandeVenteBindingSource.Current.item("numcaisse"))
                m_Printer.PrintNormal(PrinterStation.Receipt, strPrintData + vbCrLf)

                ' ✅ NF525 : BLOC DE CONFORMITÉ FISCALE
                m_Printer.PrintNormal(PrinterStation.Receipt, ESC + "|500uF")
                m_Printer.PrintNormal(PrinterStation.Receipt, ESC + "|cA" + "--- CONFORMITÉ NF525 ---" + vbCrLf)
                
                ' 1. Numéro de séquence (ID Unique)
                strPrintData = MakePrintString(m_Printer.RecLineChars, "Séquence / Ticket n°", currentTicketId.ToString())
                m_Printer.PrintNormal(PrinterStation.Receipt, strPrintData + vbCrLf)
                
                ' 2. Grand Total Perpétuel (Cumul historique)
                strPrintData = MakePrintString(m_Printer.RecLineChars, "Grand Total Perpétuel", FormatCurrency(grandTotalActuel, 2))
                m_Printer.PrintNormal(PrinterStation.Receipt, strPrintData + vbCrLf)
                
                ' 3. Signature Numérique (Preuve d'inaltérabilité)
                ' On imprime les 16 premiers caractères pour lisibilité + ligne complète en dessous
                m_Printer.PrintNormal(PrinterStation.Receipt, "Sign: " & currentSignature & vbCrLf)
                
                m_Printer.PrintNormal(PrinterStation.Receipt, ESC + "|cA" + "Merci de votre visite !" + vbCrLf)

                'Make 5mm speces
                m_Printer.PrintNormal(PrinterStation.Receipt, ESC + "|500uF")
                '<<<step4>>--Start
                If m_Printer.CapRecBarCode = True Then

                    'Bacode printing
                    m_Printer.PrintBarCode(PrinterStation.Receipt, strbcData,
                    BarCodeSymbology.Code39, 1000,
                    m_Printer.RecLineWidth, PosPrinter.PrinterBarCodeLeft,
                    BarCodeTextPosition.Below)

                End If
                ''<<<step4>>>--End

                ''Feed the receipt to the cutter position automatically, and cut.
                ''ESC|#fP = Line Feed and Paper cut
                m_Printer.PrintNormal(PrinterStation.Receipt, ESC + "|fP")

                'print all the buffer data. and exit the batch processing mode.
                m_Printer.TransactionPrint(PrinterStation.Receipt _
                  , PrinterTransactionControl.Normal)
                '<<<step6>>>--End

            Catch ex As PosControlException

            End Try
            stream.Close()
        End If
        '//<<<step2>>>--End
    End Sub

    Private Function GetRecLineChars(ByRef sRecLineChars() As String) As Long
        Dim lCount As Long
        Dim i As Integer

        'Calculate the element count.
        lCount = m_Printer.RecLineCharsList.GetLength(0)

        If lCount = 0 Then
            GetRecLineChars = 0
        Else
            'Set the element to array.
            ReDim sRecLineChars(lCount)

            For i = 0 To (lCount - 1)
                sRecLineChars(i) = m_Printer.RecLineCharsList(i)
            Next

            GetRecLineChars = lCount
        End If
    End Function
    ''' <summary>
    ''' An appropriate interval is converted into the length of
    ''' the tab about two texts. And make a printing data.
    ''' </summary>
    ''' <param name="iRecLineChars">
    ''' The width of the territory which it prints on is converted into the number of
    ''' characters, and that value is specified.
    ''' </param>
    ''' <param name="strBuf">
    ''' It is necessary as an information for deciding the interval of the text.
    ''' </param>
    ''' <param name="strPrice">
    ''' It is necessary as an information for deciding the interval of the text, too.
    ''' </param>
    ''' <returns>printing data.
    ''' </returns>
    Private Function MakePrintString(ByVal iRecLineChars As Int32,
    ByVal strBuf As String, ByVal strPrice As String) As String

        '<<<step5>>>--Start
        Dim strValue As String
        Dim iSpace As Int32 = 0
        Dim tab As String = ""

        iSpace = iRecLineChars - (strBuf.Length + strPrice.Length)

        For i As Integer = 0 To iSpace - 1
            tab += " "
        Next

        strValue = strBuf + tab + strPrice

        MakePrintString = strValue

        '<<<step5>>>--End
    End Function
#End Region











    Private Sub FormCaisse_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        I_Ref.Focus()
    End Sub





    Public Sub export(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExportCheckBox.Click

        T_CommandeVenteBindingSource.Current.item("export") = Not T_CommandeVenteBindingSource.Current.item("export")

        If T_CommandeVenteBindingSource.Current.item("export") Then
            If MessageBox.Show("Voulez-vous mettre la TVA à 0 pour tous les articles de cette commande ?" & vbCrLf & "Attention : il faudra supprimer les lignes de la commande si vous souhaitez à nouveau la tva", "Attention", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                'on enleve la tva (recalcul)
                For Each r As DataGridViewRow In DataGridViewCommande.Rows


                    r.Cells("PUinitialTTC").Value = r.Cells("PUinitialTTC").Value / (1 + r.Cells("tva").Value / 100)
                    r.Cells("PUremiseTTC").Value = r.Cells("PUinitialTTC").Value * (1 - r.Cells("remise").Value)
                    r.Cells("TotalLigne").Value = r.Cells("PUremiseTTC").Value * r.Cells("qte").Value
                    r.Cells("tva").Value = 0



                    'r.Cells("PUinitialTTC").Value = Math.Round(r.Cells("PUinitialTTC").Value / (1 + r.Cells("tva").Value / 100), 2)
                    'r.Cells("PUremiseTTC").Value = Math.Round(r.Cells("PUinitialTTC").Value * (1 - r.Cells("remise").Value), 2)
                    'r.Cells("TotalLigne").Value = r.Cells("PUremiseTTC").Value * r.Cells("qte").Value
                    'r.Cells("tva").Value = 0
                Next
            Else
                T_CommandeVenteBindingSource.Current.item("export") = False
            End If
        Else
            'on remet la tva (recalcul)
            'pas pour le moment
        End If

        CalculTotal()

    End Sub

    Private Sub TabCommande_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TabCommande.Click

    End Sub


    Private Sub T_ReglementDataGridView_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs)

    End Sub

    Private Sub T_ReglementBindingSource_AddingNew(ByVal sender As Object, ByVal e As System.ComponentModel.AddingNewEventArgs) Handles T_ReglementBindingSource.AddingNew

    End Sub

    Private Sub T_ReglementDataGridView_DataError(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs)

    End Sub

    Private Sub T_ReglementDataGridView_NewRowNeeded(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowEventArgs)
        'e.Row.Cells("mode_reglement").Value = "Carte Bancaire"
        'on enregistre la date du jour pour l'enregistrement
        e.Row.Cells("enregistre_le").Value = Now()
        'on enregistre la date de l'encaissement par defaut
        e.Row.Cells("encaisse_le").Value = Now()
        'on propose par défaut le montant restant à payer (montant total - somme des autres paiements
        If Not MontantPaiementTTCTextBox.Text = "" Then
            e.Row.Cells("montant").Value = TotalAPayerTextBox.Text - MontantPaiementTTCTextBox.Text
        Else
            e.Row.Cells("montant").Value = TotalAPayerTextBox.Text
        End If
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub


    Public Function calculMontantReglementReste() As Double
        If Not T_CommandeVenteBindingSource.Current Is Nothing Then
            T_CommandeVenteBindingSource.EndEdit()
            If Not T_CommandeVenteBindingSource.Current.item("MontantPaiementTTC").ToString = "" Then
                If T_CommandeVenteBindingSource.Current.item("Total_TTC") - T_CommandeVenteBindingSource.Current.item("MontantPaiementTTC") >= 0 Then
                    calculMontantReglementReste = T_CommandeVenteBindingSource.Current.item("Total_TTC") - T_CommandeVenteBindingSource.Current.item("MontantPaiementTTC")
                Else
                    calculMontantReglementReste = 0
                End If

            Else
                calculMontantReglementReste = T_CommandeVenteBindingSource.Current.item("Total_TTC")
            End If
        End If
    End Function
    Public Function calculMontantReglement() As Double
        T_CommandeVenteBindingSource.Current.item("MontantPaiementTTC") = 0
        T_CommandeVenteBindingSource.Current.item("montantEncaisseTTC") = 0
        'MontantPaiementTTCTextBox.Text = 0
        'montantEncaisseTextbox.Text = 0
        For i As Integer = 0 To T_ReglementDataGridView.Rows.Count - 1
            If T_ReglementDataGridView.Rows(i).Cells("a_encaisser").Value = True Then
                ' montantEncaisseTextbox.Text = montantEncaisseTextbox.Text + T_ReglementDataGridView.Rows(i).Cells("montant").Value
                T_CommandeVenteBindingSource.Current.item("montantEncaisseTTC") = T_CommandeVenteBindingSource.Current.item("montantEncaisseTTC") + T_ReglementDataGridView.Rows(i).Cells("montant").Value
            End If
            'MontantPaiementTTCTextBox.Text = MontantPaiementTTCTextBox.Text + T_ReglementDataGridView.Rows(i).Cells("montant").Value
            T_CommandeVenteBindingSource.Current.item("MontantPaiementTTC") = T_CommandeVenteBindingSource.Current.item("MontantPaiementTTC") + T_ReglementDataGridView.Rows(i).Cells("montant").Value
        Next
        'MontantPaiementTTCTextBox.Text = String.Format("{0:C}", MontantPaiementTTCTextBox.Text)
        T_CommandeVenteBindingSource.EndEdit()

    End Function

    Private Sub T_ReglementDataGridView_UserDeletedRow(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowEventArgs)
        calculMontantReglement()
    End Sub

    Private Sub PaiementGroupBox_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PaiementGroupBox.Enter

    End Sub

    Private Sub Lancement_ajouterReglement()
        If I_conditions.SelectedIndex <> -1 And I_ModeReglement.SelectedIndex <> -1 Then
            If I_conditions.Text.ToUpper <> "COMPTANT" And (I_ModeReglement.Text.ToUpper = New String("Espèces").ToUpper Or I_ModeReglement.Text.ToUpper = "AVOIR" Or I_ModeReglement.Text.ToUpper = New String("Chèque cadeau").ToUpper) Then
                MessageBox.Show("Le paiement en espèce/avoir/chèque cadeau n'est possible qu'au comptant", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Exit Sub
            End If
            If I_conditions.Text.ToUpper = "COMPTANT" And (I_ModeReglement.Text.ToUpper = New String("Contre-remboursement").ToUpper) Then
                MessageBox.Show("Le paiement en contre-remboursement n'est pas possible au comptant, choisir un paiement en différé", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Exit Sub
            End If
            If I_echeanceLe.Text = "" Then
                MessageBox.Show("Le champ écheance est obigatoire !", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Exit Sub
            End If

            'supprimer la possibilité de payer plus de 6 fois en chèque
            If (I_conditions.Text.ToUpper = "7 FOIS" Or I_conditions.Text.ToUpper = "8 FOIS" Or I_conditions.Text.ToUpper = "9 FOIS" Or I_conditions.Text.ToUpper = "10 FOIS") And (I_ModeReglement.Text.ToUpper = New String("Chèque").ToUpper) Then
                MessageBox.Show("Le paiement en plus de 6 fois par chèque est impossible", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Exit Sub
            End If



            If Not AjouterReglement() Then
                MessageBox.Show("Impossible d'ajouter la ligne", "Erreur de saisie", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        End If

    End Sub
    Private Sub Bt_addReglement_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Bt_addReglement.Click
        Lancement_ajouterReglement()
    End Sub

    Private Sub Bt_effaceReglement_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Bt_effaceReglement.Click
        ClearTamponReglement()
    End Sub

    Private Sub TabReglement_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TabReglement.Click

    End Sub

    Private Sub I_conditions_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles I_conditions.KeyPress, I_ModeReglement.KeyPress, I_montantReglement.KeyPress, I_echeanceLe.KeyPress, I_encaisse.KeyPress
        If e.KeyChar = vbCr Then
            Lancement_ajouterReglement()
        End If
    End Sub

    Private Sub I_conditions_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles I_conditions.SelectedIndexChanged
        If Not I_conditions.SelectedValue Is Nothing Then
            Dim libelle As String
            Dim delai As Integer
            Dim fin_mois As Boolean
            Dim jour_mois As Integer
            Dim nb_paiement As Integer
            Dim echeance As Date

            'recup des params des conditions de paiement
            libelle = CLIDataSet.T_modeReglement.FindById_T_ModeReglement(I_conditions.SelectedValue).Libelle
            delai = CLIDataSet.T_modeReglement.FindById_T_ModeReglement(I_conditions.SelectedValue).delai
            fin_mois = CLIDataSet.T_modeReglement.FindById_T_ModeReglement(I_conditions.SelectedValue).fin_mois
            jour_mois = CLIDataSet.T_modeReglement.FindById_T_ModeReglement(I_conditions.SelectedValue).jour_mois
            nb_paiement = CLIDataSet.T_modeReglement.FindById_T_ModeReglement(I_conditions.SelectedValue).nb_paiement


            If libelle.ToUpper = "COMPTANT" Then
                I_echeanceLe.ReadOnly = True

            Else
                I_echeanceLe.ReadOnly = False

            End If


            If libelle.ToUpper = "COMPTANT" Or nb_paiement > 1 Then
                I_encaisse.Checked = True

            Else
                I_encaisse.Checked = False

            End If



            If libelle.ToUpper = "COMPTANT" Then
                I_encaisse.Enabled = False
            Else
                I_encaisse.Enabled = True
            End If

            'on calcule le montant en automatique
            I_montantReglement.Text = calculMontantReglementReste() / nb_paiement
            'I_montantReglement.Text = Math.Round(calculMontantReglementReste() / nb_paiement, 2)
            'on calcule l'écheance automatiquement
            If nb_paiement > 1 Then
                I_echeanceLe.Text = Now

            Else
                If fin_mois Then
                    echeance = DateAdd(DateInterval.Day, delai, Now)
                    I_echeanceLe.Text = GetLastDayInMonth(echeance)
                Else
                    echeance = DateAdd(DateInterval.Day, delai, Now)
                    I_echeanceLe.Text = echeance
                End If


            End If


            'on débloque moyen de paiement
            I_ModeReglement.SelectedIndex = -1
            I_ModeReglement.Enabled = True
            If I_RefAvoir.Items.Count > 0 Then
                I_RefAvoir.SelectedIndex = 0
            End If

            I_RefAvoir.Enabled = False
        End If
    End Sub
    Function GetLastDayInMonth(ByVal dtDate As Date) As Date

        'example for #2009-02-20# we want to get the last day in the month 02,
        ' (ie. date for last day in Feb)

        Return DateAdd(DateInterval.Day, ((DateAdd(DateInterval.Month, 1, dtDate))).Day * -1, DateAdd(DateInterval.Month, 1, dtDate))

    End Function
    Private Sub I_ModeReglement_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles I_ModeReglement.SelectedIndexChanged
        If Not I_conditions.SelectedValue Is Nothing Then
            Dim libelle As String
            Dim delai As Integer
            Dim fin_mois As Boolean
            Dim jour_mois As Integer
            Dim nb_paiement As Integer
            'recup des params des conditions de paiement
            libelle = CLIDataSet.T_modeReglement.FindById_T_ModeReglement(I_conditions.SelectedValue).Libelle
            delai = CLIDataSet.T_modeReglement.FindById_T_ModeReglement(I_conditions.SelectedValue).delai
            fin_mois = CLIDataSet.T_modeReglement.FindById_T_ModeReglement(I_conditions.SelectedValue).fin_mois
            jour_mois = CLIDataSet.T_modeReglement.FindById_T_ModeReglement(I_conditions.SelectedValue).jour_mois
            nb_paiement = CLIDataSet.T_modeReglement.FindById_T_ModeReglement(I_conditions.SelectedValue).nb_paiement


            'on débloque moyen de paiement
            If I_ModeReglement.Text.ToUpper = "AVOIR" Or I_ModeReglement.Text.ToUpper = "CHEQUE CADEAU" Then
                I_RefAvoir.DataSource = Nothing
                If Not T_CommandeVenteBindingSource.Current.item("Id_t_client") Is DBNull.Value Then
                    InitCombo(I_RefAvoir, My.Settings.CLIConnectionString, "Select id_t_avoir as id,convert(varchar(225),id_t_avoir) + ' - ' + convert(varchar(225),montant) + ' €' as libelle from t_avoir where utilisele is null and chequecadeau=" & IIf(I_ModeReglement.Text.ToUpper = "CHEQUE CADEAU", "1", "0") & " and id_t_client=" & T_CommandeVenteBindingSource.Current.item("Id_t_client"), "libelle", "<Choisir>", "id")
                End If

                I_montantReglement.ReadOnly = True
                I_RefAvoir.Enabled = True
                I_montantReglement.Text = ""
                If I_RefAvoir.Items.Count > 0 Then
                    I_RefAvoir.SelectedIndex = 0
                End If


            Else


                I_montantReglement.ReadOnly = False
                I_RefAvoir.Enabled = False
                I_montantReglement.Text = calculMontantReglementReste() / nb_paiement
                'I_montantReglement.Text = Math.Round(calculMontantReglementReste() / nb_paiement, 2)
                If I_RefAvoir.Items.Count > 0 Then
                    I_RefAvoir.SelectedIndex = 0
                End If
            End If

        End If
    End Sub

    Private Sub T_ReglementDataGridView_CellMouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles T_ReglementDataGridView.CellMouseClick

    End Sub

    Private Sub T_ReglementDataGridView_CellValidated(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles T_ReglementDataGridView.CellValidated
        If T_ReglementDataGridView.Columns.Count = 9 Then
            If e.ColumnIndex = 7 Then
                If T_ReglementDataGridView.Rows(e.RowIndex).Cells(5).Value.ToString <> "" Then
                    T_ReglementDataGridView.Rows(e.RowIndex).Cells(e.ColumnIndex).Value = True
                End If
                calculMontantReglement()
            End If
        End If
    End Sub

    Private Sub T_ReglementDataGridView_CellValidating(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellValidatingEventArgs) Handles T_ReglementDataGridView.CellValidating

    End Sub

    Private Sub T_ReglementDataGridView_CellValueChanged(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles T_ReglementDataGridView.CellValueChanged

    End Sub



    Private Sub T_ReglementDataGridView_UserAddedRow(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowEventArgs) Handles T_ReglementDataGridView.UserDeletedRow
        calculMontantReglement()
        calculMontantReglementReste()
    End Sub



    Private Sub I_RefAvoir_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles I_RefAvoir.Enter
        If IsNumeric(sender.selectedvalue) Then
            vNumeroAvoir = sender.selectedvalue
        End If

    End Sub



    Private Sub I_RefAvoir_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles I_RefAvoir.Validated
        If I_RefAvoir.Text <> "<choisir>" And (I_ModeReglement.Text.ToUpper = "AVOIR" Or I_ModeReglement.Text.ToUpper = "CHEQUE CADEAU") Then
            CheckAvoir()
        End If

    End Sub

    Private Sub I_RefAvoir_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub I_encaisse_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles I_encaisse.CheckedChanged

    End Sub

    Private Sub T_ReglementDataGridView_CellContentClick_1(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles T_ReglementDataGridView.CellContentClick

    End Sub

    Private Sub T_ReglementDataGridView_RowsRemoved(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowsRemovedEventArgs) Handles T_ReglementDataGridView.RowsRemoved

    End Sub

    Private Sub T_ReglementDataGridView_UserDeletingRow(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowCancelEventArgs) Handles T_ReglementDataGridView.UserDeletingRow
        If e.Row.Cells(5).Value.ToString <> "" Then
            e.Cancel = True
        End If
    End Sub

    Private Sub BT_Paiement_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BT_Paiement.Click
        Paiement()

    End Sub



    Private Sub FactureReportViewer_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FactureReportViewer.Load

    End Sub

    Private Sub Button1_Click_2(ByVal sender As System.Object, ByVal e As System.EventArgs)
        MessageBox.Show(FormatDateTime(Now(), DateFormat.ShortDate))
    End Sub

    Private Sub reportDocument1_InitReport(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub BT_Etiquette_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BT_Etiquette.Click
        Refresh_data()
        'etiquetteExpedition1.SetDataSource(Me.CLIDataSet)
        'etiquetteExpedition1.PrintOptions.PrinterName = gNomImprimanteEtiquette
        'etiquetteExpedition1.PrintOptions.PaperSource = CrystalDecisions.Shared.PaperSource.Auto

        'etiquetteExpedition1.PrintToPrinter(1, False, 1, 1)
        Dim DymoAddIn As New Dymo.DymoAddIn
        Dim DymoLabels As New Dymo.DymoLabels
        Dim vDatatable As DataTable = ExecuteRequeteR("Select * from t_commandevente where id_t_commandevente=" & T_CommandeVenteBindingSource.Current("id_t_commandevente"), My.Settings.CLIConnectionString)
        Dim vAdresse As String
        vAdresse = vDatatable.Rows(0)("société").ToString
        vAdresse = vAdresse & vbCrLf & vDatatable.Rows(0)("nom").ToString & " " & vDatatable.Rows(0)("prénom").ToString
        vAdresse = vAdresse & vbCrLf & vDatatable.Rows(0)("adressel1").ToString
        vAdresse = vAdresse & vbCrLf & vDatatable.Rows(0)("adressel2").ToString
        vAdresse = vAdresse & vbCrLf & vDatatable.Rows(0)("adressel3").ToString
        vAdresse = vAdresse & vbCrLf & vDatatable.Rows(0)("codepostal").ToString & " " & vDatatable.Rows(0)("ville").ToString
        vAdresse = vAdresse & vbCrLf & vDatatable.Rows(0)("pays").ToString

        DymoAddIn.Open(Application.StartupPath & "\adresse11354.label")
        DymoLabels.SetField("ADRESSE", vAdresse)

        DymoAddIn.SelectPrinter(gNomImprimanteEtiquette)
        DymoAddIn.Print2(1, False, 2)

    End Sub

    Private Sub BT_Imprimer_devis_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BT_Imprimer_devis.Click, BT_Imprimer_test.Click, BT_Imprimer_reservation.Click
        Dim err_msg As String = ""
        Select Case sender.name
            Case "BT_Imprimer_devis", "BT_Imprimer_test", "BT_Imprimer_reservation", "BT_Imprimer_commande)"
                If (CodeClientTextBox.Text = "" Or CodeClientTextBox.Text = "0") Then
                    err_msg = err_msg & vbCrLf & "- Le code client est obligatoire"
                End If

        End Select

        Select Case sender.name

            Case "BT_Imprimer_test", "BT_Imprimer_reservation"
                If (VuAvecTextBox.Text = "") Then
                    err_msg = err_msg & vbCrLf & "- Le champ ""Vu avec"" est obligatoire"
                End If
        End Select
        If err_msg <> "" Then
            MessageBox.Show(err_msg, "Attention", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        Else
            Select Case sender.name
                Case "BT_Imprimer_devis"
                    EtatCommande(5, False)
                Case "BT_Imprimer_test"
                    EtatCommande(4, False)
                Case "BT_Imprimer_reservation"
                    EtatCommande(6, False)
                Case "BT_Imprimer_commande"
                    EtatCommande(10, False)
                Case "BT_BL"
                    EtatCommande(999, False)
            End Select


        End If

    End Sub

    Private Sub DevisReportViewer_RenderingBegin(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles DevisReportViewer.RenderingBegin
        vDevisReportComplete = False
    End Sub

    Private Sub DevisReportViewer_RenderingComplete(ByVal sender As Object, ByVal e As Microsoft.Reporting.WinForms.RenderingCompleteEventArgs) Handles DevisReportViewer.RenderingComplete
        vDevisReportComplete = True
    End Sub

    Private Sub ExportCheckBox_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExportCheckBox.CheckedChanged

    End Sub

    Private Sub I_ChequeCadeauIdClient_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles I_ChequeCadeauIdClient.Enter
        If IsNumeric(sender.text) Then
            vCodeClientChequeCadeau = sender.text
        End If
    End Sub

    Private Sub I_ChequeCadeauIdClient_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles I_ChequeCadeauIdClient.MouseClick

    End Sub

    Private Sub I_ChequeCadeauIdClient_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles I_ChequeCadeauIdClient.TextChanged

    End Sub


    Private Sub I_ChequeCadeauIdClient_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles I_ChequeCadeauIdClient.Validated
        If IsNumeric(I_ChequeCadeauIdClient.Text) Then
            If I_ChequeCadeauIdClient.Text <> "0" And CInt(I_ChequeCadeauIdClient.Text) <> vCodeClientChequeCadeau Then
                CheckClient(I_ChequeCadeauIdClient)

            End If
        End If
    End Sub

    Private Sub BT_ImprimerChequeCadeau_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BT_ImprimerChequeCadeau.Click
        ImprimerChequeCadeau()
    End Sub

    Private Sub I_montantReglement_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles I_montantReglement.TextChanged

    End Sub


    Private Sub I_PuTTC_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles I_PuTTC.TextChanged

    End Sub

    Private Sub I_PuTTC_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles I_PuTTC.Validating
        'cas du chèque cadeau
        If I_Ref.Text = "6" Then

            If I_PuTTC.Text = "" Or I_PuTTC.Text = "10" Or I_PuTTC.Text = "20" Or I_PuTTC.Text = "30" Or I_PuTTC.Text = "50" Or I_PuTTC.Text = "75" Or I_PuTTC.Text = "100" Or I_PuTTC.Text = "150" Or I_PuTTC.Text = "500" Then
            Else
                MessageBox.Show("Merci de choisir l'une des valeurs suivantes : 10, 20, 30, 50, 75, 100, 150, ou 500 Euros", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                e.Cancel = True
            End If

        End If
    End Sub


    Private Sub CodePostalTextBox_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles CodePostalTextBox.KeyDown
        If e.KeyCode = 13 Then
            validecp()
        End If
    End Sub



    Private Sub CodePostalTextBox_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles CodePostalTextBox.Validated, CodePostalTextBox.Click
        validecp()

    End Sub

    Private Sub VilleTextBox_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles VilleTextBox.KeyDown
        If e.KeyCode = 13 Then
            valideVille()
        End If
    End Sub

    Private Sub VilleTextBox_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles VilleTextBox.Validated
        valideVille()
    End Sub
    Sub validecp()
        'test de la valeur du champ après split
        Dim vCodePostal As String
        Dim vVille As String
        If CodePostalTextBox.Text.Length >= 5 Then
            vCodePostal = CodePostalTextBox.Text.Substring(0, 5)

            If CodePostalTextBox.Text.Length > 5 Then
                vVille = CodePostalTextBox.Text.Substring(6).Replace("(", "").Replace(")", "")
                VilleTextBox.Text = vVille
            End If
            CodePostalTextBox.Text = vCodePostal
        End If

    End Sub

    Sub valideVille()
        'test de la valeur du champ après split
        Dim vCodePostal As String
        Dim vVille As String
        If VilleTextBox.Text.Contains("(") And VilleTextBox.Text.Contains(")") Then
            If VilleTextBox.Text.Length >= 8 Then


                vCodePostal = VilleTextBox.Text.Substring(VilleTextBox.Text.Length - 7, 7).Replace("(", "").Replace(")", "")


                vVille = VilleTextBox.Text.Substring(0, VilleTextBox.Text.Length - 8)
                If vVille.Length > 1 Then
                    VilleTextBox.Text = vVille

                    CodePostalTextBox.Text = vCodePostal
                End If

            End If
        End If

    End Sub

    Private Sub BT_Imprimer_test_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BT_Imprimer_test.Click

    End Sub

    Private Sub BT_Envoi_etat_commande_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BT_Envoi_etat_commande.Click
        EnvoiEtatCommande()
    End Sub

    Private Sub BT_Imprimer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BT_Imprimer.Click, BT_BL.Click
        T_CommandeVenteBindingSource.EndEdit()

        If sender.name = "BT_BL" Then
            EtatCommande(999, True)
        Else
            EtatCommande(T_CommandeVenteBindingSource.Current("id_etatcommandevente"), True)
        End If

    End Sub

    Private Sub FactureReportViewer_ReportRefresh(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles FactureReportViewer.ReportRefresh

    End Sub

    Private Sub BT_Expedier_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BT_Expedier.Click
        Expedier(False)
    End Sub
    Private Sub BT_ReExpedier_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BT_ReExpedier.Click
        Expedier(True)
    End Sub
    Private Sub Expedier(ByVal re As Boolean)
        If re Then
            If MessageBox.Show("Voulez vous réellement programmer un nouvel envoi la date d'expedition ?", "Attention", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.No Then
                Exit Sub
            End If
        End If

        'on enregistre la date
        If T_CommandeVenteBindingSource.Current.item("ExpeditionLe").ToString = "" Then
            T_CommandeVenteBindingSource.Current.item("ExpeditionLe") = Now()
        End If
        If re Then
            T_CommandeVenteBindingSource.Current.item("ExpeditionLe") = Now()
        End If

        'changement de l'état
        T_CommandeVenteBindingSource.Current.item("ID_EtatCommandeVente") = 45

        ' ── Export DPD (Station.NET CargoNET) ────────────────────────────────
        ' Si le transporteur sélectionné est DPD, générer le fichier V110
        ' déposé dans le dossier surveillé par Station.NET (mode semi-automatique).
        ' Le vendeur complète le poids et sélectionne le compte dans Station.NET.
        Try
            Dim idTransporteur As Integer = 0
            If Not IsDBNull(T_CommandeVenteBindingSource.Current.item("ID_T_Transporteur")) Then
                idTransporteur = Convert.ToInt32(T_CommandeVenteBindingSource.Current.item("ID_T_Transporteur"))
            End If

            If idTransporteur = My.Settings.DPDTransporteurId Then
                Dim idCde As Integer = Convert.ToInt32(T_CommandeVenteBindingSource.Current.item("ID_T_CommandeVente"))
                ' Enregistrer d'abord la commande pour s'assurer que les données sont à jour en base
                Enregistrer()
                ' Générer le fichier V110 pour Station.NET
                Dim cheminFichier As String = ExporterDPD(idCde)
                MessageBox.Show(
                    "Fichier DPD créé et déposé dans Station.NET." & vbCrLf & vbCrLf &
                    "Fichier : " & IO.Path.GetFileName(cheminFichier) & vbCrLf &
                    "Dossier : " & IO.Path.GetDirectoryName(cheminFichier) & vbCrLf & vbCrLf &
                    "Dans Station.NET :" & vbCrLf &
                    "  • Sélectionnez le compte DPD :" & vbCrLf &
                    "      Classic   066-7485 → Pro/professionnel" & vbCrLf &
                    "      Predict   066-7486 → Particulier (SMS)" & vbCrLf &
                    "      Relais    066-7487 → Point Relais" & vbCrLf &
                    "  • Complétez le poids du colis" & vbCrLf &
                    "  • Imprimez l'étiquette",
                    "DPD — Station.NET", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Return ' Enregistrer() déjà appelé ci-dessus
            End If
        Catch exDPD As Exception
            MessageBox.Show(
                "Attention : la commande a été enregistrée mais le fichier DPD n'a pas pu être créé." & vbCrLf & vbCrLf &
                "Erreur : " & exDPD.Message & vbCrLf & vbCrLf &
                "Vérifiez que le dossier DPD est accessible : " & My.Settings.DPDStationNetFolder & vbCrLf &
                "Vous pouvez relancer l'export depuis le bouton Réexpédier.",
                "DPD — Erreur export", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End Try

        'Enregistrement dans la table (cas non-DPD)
        Enregistrer()

    End Sub

    Private Sub I_Vpc_on_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles I_Vpc_on.CheckedChanged

    End Sub

    Private Sub I_Vpc_on_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles I_Vpc_on.Validated
        AffichageVerouillage()

    End Sub

    Private Sub I_Caisse_SelectedIndexChanged(sender As Object, e As EventArgs) Handles I_Caisse.SelectedIndexChanged

    End Sub

    Private Sub BT_versWebCaisse_Click(sender As Object, e As EventArgs)
        'changement de l'état
        T_CommandeVenteBindingSource.Current.item("ID_EtatCommandeVente") = 12
        'Enregistrement dans la table
        Enregistrer()

    End Sub

    Private Sub ToolStrip_ItemClicked(sender As Object, e As ToolStripItemClickedEventArgs) Handles ToolStrip.ItemClicked

    End Sub

    Private Sub ExportFileTextBox_TextChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub ExportFileLabel_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub CommandeWebCaisseLabel_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub EnteteGroupBox_Enter(sender As Object, e As EventArgs) Handles EnteteGroupBox.Enter

    End Sub

    Private Sub BT_DetailSynchro_Click(sender As Object, e As EventArgs) Handles BT_DetailSynchro.Click
        Dim f As New FormLog
        f.vLogAssociatedRecordId = Me.CLIDataSet.T_CommandeVente.Rows(0).Item("ID_t_CommandeVente")
        f.vLogAssociatedRecordType = "t_commandeVente"
        f.ShowDialog()
    End Sub
End Class