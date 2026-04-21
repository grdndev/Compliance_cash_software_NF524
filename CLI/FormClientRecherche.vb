Imports System.ComponentModel
Imports CompletIT.Windows.Forms.Export.Pdf
Public Class FormClientRecherche
    Public bs As New BindingSource
    Public vref As String = ""

    Private Sub FormClientRecherche_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If Not Me.Modal Then
            If FormClient.Visible = True Then
                FormClient.Close()
            End If
        End If

    End Sub

    Private Sub FormClientRecherche_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim vVilleCP As New AutoCompleteStringCollection
        Dim vCPVille As New AutoCompleteStringCollection
        Dim vSourceVilleCP As DataTable
        vSourceVilleCP = ExecuteRequeteR("select codepostal,ville from t_cpvillefr", My.Settings.CLIConnectionString)

        For Each r As DataRow In vSourceVilleCP.Rows
            vVilleCP.Add(r("ville") & " (" & r("codepostal") & ")")
            vCPVille.Add(r("codepostal") & " (" & r("ville") & ")")
        Next

        VilleTextBox.AutoCompleteCustomSource = vVilleCP
        CodePostalTextbox.AutoCompleteCustomSource = vCPVille




        BT_Nouveau_Client.Enabled = gVente_w
        'On affiche le total des avoirs uniquement si l'utilisateur a le droit de voir les avoirs (statistiques dans les droits du profil coché)
        I_TotalAvoir.Visible = gStatistiques
        IL_TotalAvoir.Visible = gStatistiques

        ' If Me.Modal Then
        'BT_Nouveau_Client.Visible = False
        'ContextMenuStripRecherche.Visible = False
        'End If

        Raz()


        ToolStripStatusLabelNbEnregistrements.Text = System.String.Format("{0} enregistrement(s) sélectionné(s)", "0")



        'TODO : cette ligne de code charge les données dans la table 'CLIDataSet.V_Recherche_Article'. Vous pouvez la déplacer ou la supprimer selon vos besoins.
        'Me.V_Recherche_ArticleTableAdapter.Fill(Me.CLIDataSet.V_Recherche_Article)
        'Me.WindowState = FormWindowState.Maximized
    End Sub



    Private Sub OuvertureFiche(ByVal index As Integer, Optional bOngletArticle As Boolean = False)
        Cursor = Cursors.WaitCursor
        Try
            If FormClient.Visible Then
                FormClient.Close()
            End If
            FormClient.MdiParent = Me.MdiParent

            'cas de l'affichage d'une fiche
            If index <> -1 Then
                FormClient.id_t_client = DGview.Rows(index).Cells("ref").Value

            Else
                'cas d'une nouvelle fiche
                FormClient.id_t_client = 0
            End If

            FormClient.Show()

            If bOngletArticle Then
                FormClient.TabControl1.SelectTab("TabPageArticle")

            End If
            FormClient.BringToFront()
        Finally
            Cursor = Cursors.Default
        End Try


    End Sub

    Private Sub V_Recherche_ArticleDataGridView_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGview.CellClick

    End Sub

    Private Sub V_Recherche_ArticleDataGridView_CellFormatting(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellFormattingEventArgs) Handles DGview.CellFormatting
        If e.RowIndex <> -1 Then
            If DGview.Rows(e.RowIndex).Cells("actif").Value.ToString <> "" Then
                If Not DGview.Rows(e.RowIndex).Cells("actif").Value Then
                    e.CellStyle.BackColor = Color.Gray
                End If
            Else
                e.CellStyle.BackColor = Color.Gray
            End If
        End If
    End Sub


    Private Sub V_Recherche_ArticleDataGridView_CellMouseDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles DGview.CellMouseDoubleClick
        If Not e.RowIndex = -1 And e.Button = Windows.Forms.MouseButtons.Left Then
            If Me.Modal Then
                vref = DGview.Rows(e.RowIndex).Cells("Ref").Value.ToString
                Me.DialogResult = Windows.Forms.DialogResult.OK
                Me.Close()
            Else
                Dim index As Integer = e.RowIndex
                OuvertureFiche(index)
            End If

        End If

    End Sub

    Private Sub BT_Go_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BT_Go.Click

        If Me.Modal Then
            Recherche(False, False)
        Else
            Recherche(False, True)
        End If


    End Sub



    Private Sub BT_RAZ_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BT_RAZ.Click
        Raz()

    End Sub
    Public Sub Recherche(Optional ByVal bNouveau As Boolean = False, Optional ByVal bAutoOpen As Boolean = True, Optional ByVal id_t_article_entete As String = "", Optional ByVal id_t_article_detail As String = "", Optional ByVal bOngletArticle As Boolean = False)
        Cursor = Cursors.WaitCursor
        Dim cnn As New SqlClient.SqlConnection(My.Settings.CLIConnectionString)
        cnn.Open()



        Dim strsql_recherche As String
        If bNouveau Then
            strsql_recherche = "select * from v_recherche_client where ref=0"
        Else
            strsql_recherche = "select * from v_recherche_client where ref>0"
        End If

        Dim strsql As String = ""

        If bNouveau = False And I_Reference.Text = "0" Then
            I_Reference.Text = ""
        End If

        If IsNumeric(I_Reference.Text) Then
            strsql = strsql & " and ref='" & I_Reference.Text & "'"
            GoTo fin
        Else
            I_Reference.Text = ""
        End If

        If IsNumeric(I_NbArticlesMin.Text) Then
            strsql = strsql & " and nbarticle >=" & I_NbArticlesMin.Text
        Else
            I_NbArticlesMin.Text = ""
        End If
        If IsNumeric(I_NbArticlesMax.Text) Then
            strsql = strsql & " and nbarticle <=" & I_NbArticlesMax.Text
        Else
            I_NbArticlesMax.Text = ""
        End If

        If IsNumeric(I_EchanceMin.Text) Then
            strsql = strsql & " and [Echéances] >=" & I_EchanceMin.Text
        Else
            I_EchanceMin.Text = ""
        End If
        If IsNumeric(I_EcheanceMax.Text) Then
            strsql = strsql & " and [Echéances]  <=" & I_EcheanceMax.Text
        Else
            I_EcheanceMax.Text = ""
        End If


        If IsNumeric(I_NbCommandesMin.Text) Then
            strsql = strsql & " and nbcommande >=" & I_NbCommandesMin.Text
        Else
            I_NbCommandesMin.Text = ""
        End If
        If IsNumeric(I_NbCommandesMax.Text) Then
            strsql = strsql & " and nbcommande <=" & I_NbCommandesMax.Text
        Else
            I_NbArticlesMax.Text = ""
        End If

        If IsNumeric(I_AvoirMin.Text) Then
            strsql = strsql & " and [Montant avoir] >=" & I_AvoirMin.Text
        Else
            I_NbCommandesMin.Text = ""
        End If
        If IsNumeric(I_AvoirMax.Text) Then
            strsql = strsql & " and [Montant avoir] <=" & I_AvoirMax.Text
        Else
            I_NbArticlesMax.Text = ""
        End If


        If Not String.IsNullOrEmpty(Trim(I_Societe.Text)) Then
            strsql = strsql & " and [Société] like '%" & I_Societe.Text & "%'"
        End If


        If Not String.IsNullOrEmpty(Trim(I_Nom.Text)) Then
            strsql = strsql & " and [Nom] like '%" & I_Nom.Text & "%'"
        End If

        If Not String.IsNullOrEmpty(Trim(I_Prenom.Text)) Then
            strsql = strsql & " and [Prenom] like '%" & I_Prenom.Text & "%'"
        End If
        If Not String.IsNullOrEmpty(Trim(CodePostalTextbox.Text)) Then
            strsql = strsql & " and [codepostal] like '%" & CodePostalTextbox.Text & "%'"
        End If
        If Not String.IsNullOrEmpty(Trim(VilleTextBox.Text)) Then
            strsql = strsql & " and [ville] like '%" & VilleTextBox.Text & "%'"
        End If
        If Not String.IsNullOrEmpty(Trim(I_Pays.Text)) Then
            strsql = strsql & " and [Pays] like '%" & I_Pays.Text & "%'"
        End If
        If Not String.IsNullOrEmpty(Trim(I_Email.Text)) Then
            strsql = strsql & " and [Email] like '%" & I_Email.Text.Replace("'", "''") & "%'"
        End If

        If I_Wind.Checked Then
            strsql = strsql & " and [wind] = 1"
        End If
        If I_kite.Checked Then
            strsql = strsql & " and [kite] = 1"
        End If
        If I_sup.Checked Then
            strsql = strsql & " and [sup] = 1"
        End If

        Select Case I_Active.Text
            Case "Oui" : strsql = strsql & " and [actif] = 1"
            Case "Non" : strsql = strsql & " and [actif] = 0"
        End Select

        Select Case I_SynchroPrestashop.Text
            Case "Ok" : strsql = strsql & " and [SynchroPrestashop] = 'Ok'"
            Case "Erreur" : strsql = strsql & " and [SynchroPrestashop] = 'Erreur'"
            Case "Non" : strsql = strsql & " and [SynchroPrestashop] = 'Non'"
        End Select


fin:

        Dim oSqlDataAdapter As New Data.SqlClient.SqlDataAdapter(strsql_recherche & strsql, cnn)
        Dim oDataSet As New DataSet("RechercheDataset")

        oSqlDataAdapter.Fill(oDataSet, "Recherche")
        ToolStripStatusLabelNbEnregistrements.Text = System.String.Format("{0} enregistrement(s) sélectionné(s)", oDataSet.Tables("Recherche").Rows.Count.ToString)

        bs.DataSource = oDataSet.Tables("Recherche")


        I_TotalAvoir.Text = 0
        For Each r As DataRow In oDataSet.Tables("Recherche").Rows
            If IsNumeric(r("Montant Avoir").ToString) Then
                I_TotalAvoir.Text = I_TotalAvoir.Text + r("Montant Avoir")
            End If

        Next

        I_TotalAvoir.Text = Format(I_TotalAvoir.Text, "Currency")

        DGview.DataSource = bs

        cnn.Close()
        'si un seul enregistrement on ouvre le formulaire directement
        If DGview.Rows.Count = 1 And bAutoOpen Then
            OuvertureFiche(0, bOngletArticle)
        End If

        Cursor = Cursors.Default
    End Sub
    Private Sub Raz()
        DGview.DataSource = Nothing
        I_Reference.Text = ""
        CodePostalTextbox.Text = ""
        I_NbArticlesMin.Text = ""
        I_NbArticlesMax.Text = ""
        I_NbCommandesMax.Text = ""
        I_NbCommandesMin.Text = ""
        I_EchanceMin.Text = ""
        I_EcheanceMax.Text = ""
        I_AvoirMax.Text = ""
        I_AvoirMin.Text = ""
        I_Societe.Text = ""
        I_Nom.Text = ""
        I_Prenom.Text = ""
        VilleTextBox.Text = ""
        I_Pays.Text = ""
        I_Active.SelectedIndex = 0
        I_TotalAvoir.Text = 0
        I_Wind.Checked = False
        I_kite.Checked = False
        I_sup.Checked = False
        I_SynchroPrestashop.SelectedIndex = 0
        I_Email.Text = ""

    End Sub

    Private Sub DGview_CellMouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles DGview.CellMouseDown
        If e.Button = Windows.Forms.MouseButtons.Right And e.RowIndex <> -1 Then
            bs.Position = e.RowIndex

        End If
    End Sub

    Private Sub BT_Nouvel_Article_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BT_Nouveau_Client.Click
        Nouvelle_Fiche()
    End Sub
    Public Sub Nouvelle_Fiche()
        I_Reference.Text = 0
        Recherche(True, False)
        OuvertureFiche(-1)
    End Sub
    Private Sub I_Reference_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles I_Reference.GotFocus
        sender.text = ""
    End Sub

    Private Sub BT_Fermer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BT_Fermer.Click
        Me.Close()
    End Sub

    Private Sub SuppressionToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub I_Pays_DropDown(ByVal sender As Object, ByVal e As System.EventArgs) Handles I_Pays.DropDown
        I_Pays.DataSource = Nothing
        Dim cnn As New SqlClient.SqlConnection(My.Settings.CLIConnectionString)
        cnn.Open()
        Dim bs As New BindingSource
        Dim command As New SqlClient.SqlCommand
        command.CommandText = "select distinct pays from v_recherche_client  Union select null as pays order by pays"
        command.Connection = cnn
        Dim reader As SqlClient.SqlDataReader = command.ExecuteReader
        bs.DataSource = reader
        I_Pays.DataSource = bs
        I_Pays.DisplayMember = "pays"
        cnn.Close()
    End Sub




    Private Sub PaysComboBox_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles I_Pays.SelectedIndexChanged
        Select Case I_Pays.Text.ToUpper
            Case "FRANCE", "GUADELOUPE", "GUYANE", "LA RÉUNION", "NOUVELLE CALÉDONIE", "POLYNÉSIE FRANÇAISE", "SAINT-MARTIN", "SIANT-PIERRE-ET-MIQUELON", "SAINT BARTHÉLEMY"
                AddHandler CodePostalTextbox.Validated, AddressOf CodePostalTextBox_Validated
                AddHandler CodePostalTextbox.KeyDown, AddressOf CodePostalTextBox_KeyDown
                AddHandler VilleTextBox.Validated, AddressOf VilleTextBox_Validated
                AddHandler VilleTextBox.KeyDown, AddressOf VilleTextBox_KeyDown
                CodePostalTextbox.AutoCompleteMode = AutoCompleteMode.SuggestAppend
                VilleTextBox.AutoCompleteMode = AutoCompleteMode.SuggestAppend

            Case Else
                RemoveHandler CodePostalTextbox.Validated, AddressOf CodePostalTextBox_Validated
                RemoveHandler CodePostalTextbox.KeyDown, AddressOf CodePostalTextBox_KeyDown
                RemoveHandler VilleTextBox.Validated, AddressOf VilleTextBox_Validated
                RemoveHandler VilleTextBox.KeyDown, AddressOf VilleTextBox_KeyDown
                CodePostalTextbox.AutoCompleteMode = AutoCompleteMode.None
                VilleTextBox.AutoCompleteMode = AutoCompleteMode.None

        End Select

    End Sub

    Private Sub BT_Impression_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BT_Impression.Click, BT_Email.Click

        Dim critere As String = ""
        Dim settings As New CompletIT.Windows.Forms.Printing.DGVEPrintSettings


        Dim PdfExporter As DGVEPdfExporter = New DGVEPdfExporter()
        Dim ExportSettings As DGVEPdfExportSettings = New DGVEPdfExportSettings()

        settings.PrintHeaderText = True
        If I_NbArticlesMin.Text <> "" Then
            critere = critere & vbCrLf & "Nb Dépôt-Vente min : " & I_NbArticlesMin.Text
        End If
        If I_NbArticlesMax.Text <> "" Then
            critere = critere & vbCrLf & "Nb Dépôt-Vente max :  " & I_NbArticlesMax.Text
        End If

        If I_NbCommandesMin.Text <> "" Then
            critere = critere & vbCrLf & "Nb Commande min :  " & I_NbCommandesMin.Text
        End If
        If I_NbCommandesMax.Text <> "" Then
            critere = critere & vbCrLf & "Nb Commande max :  " & I_NbCommandesMax.Text
        End If
        If I_AvoirMin.Text <> "" Then
            critere = critere & vbCrLf & "Montant Avoir / Chèque min : " & I_AvoirMin.Text
        End If

        If I_AvoirMax.Text <> "" Then
            critere = critere & vbCrLf & "Montant Avoir / Chèque max : " & I_AvoirMax.Text
        End If


        If I_EchanceMin.Text <> "" Then
            critere = critere & vbCrLf & "Montant échéances min : de " & I_EchanceMin.Text
        End If

        If I_EcheanceMax.Text <> "" Then
            critere = critere & vbCrLf & "Montant échéances max : de " & I_EcheanceMax.Text
        End If

        If I_Societe.Text <> "" Then
            critere = critere & vbCrLf & "Société : " & I_Societe.Text
        End If
        If I_Nom.Text <> "" Then
            critere = critere & vbCrLf & "Nom : " & I_Nom.Text
        End If
        If I_Prenom.Text <> "" Then
            critere = critere & vbCrLf & "Prénom : " & I_Prenom.Text
        End If
        If CodePostalTextbox.Text <> "" Then
            critere = critere & vbCrLf & "Code postal : " & CodePostalTextbox.Text
        End If
        If VilleTextBox.Text <> "" Then
            critere = critere & vbCrLf & "Ville : " & VilleTextBox.Text
        End If
        If I_Pays.Text <> "" Then
            critere = critere & vbCrLf & "Pays : " & I_Pays.Text
        End If
        If I_Active.Text <> "<Tous>" Then
            critere = critere & vbCrLf & "Actif ? : " & I_Active.Text
        End If
        If I_Wind.Checked Then
            critere = critere & vbCrLf & "Wind ? : oui"
        End If
        If I_kite.Checked Then
            critere = critere & vbCrLf & "Kite ? : oui"
        End If
        If I_sup.Checked Then
            critere = critere & vbCrLf & "Sup ? : oui"
        End If

        If gStatistiques Then
            critere = critere & vbCrLf & "Total avoirs : " & I_TotalAvoir.Text
        End If



        Dim f As New DialogImpression
        f.pDgview = DGview

        If f.ShowDialog = Windows.Forms.DialogResult.OK Then
            settings.HeaderText = "CLI : Listing des clients" & critere & vbCrLf & vbCrLf & "Impression le " & Now()
            settings.PrintRowHeaders = False
            ExportSettings.HeaderText = "CLI : Listing des clients" & critere & vbCrLf & vbCrLf & "Impression le " & Now()
            ExportSettings.ExportRowHeaders = False

            If f.ComboBoxOrientation.SelectedIndex = 1 Then
                settings.Landscape = True
                ExportSettings.Landscape = True
            Else
                settings.Landscape = False
                ExportSettings.Landscape = False
            End If





            For Each r As DataGridViewRow In f.DataGridViewColonnes.Rows
                If Not r.Cells(1).Value Then
                    DGview.Columns(r.Cells(2).Value).visible = False

                End If
            Next
            settings.MarginLeft = 50
            settings.MarginRight = 50
            settings.PrintVisualStyles = False
            ExportSettings.MarginLeft = 50
            ExportSettings.MarginRight = 50

            ExportSettings.MarginLeft = 50
            ExportSettings.MarginRight = 50
            ExportSettings.ExportHeaderText = True

            ExportSettings.ExportFileName = gChemin_local_piece_jointe 'Absolute path to the export file
            ExportSettings.OpenFileAfterGeneration = False 'Open generated file after export
            ExportSettings.OpenFolderAfterGeneration = False
            ExportSettings.ExportHiddenColumns = False

            Select Case sender.name
                Case "BT_Impression"
                    CompletIT.Windows.Forms.Printing.DGVEPrintManager.PrintPreview(DGview, settings)
                Case "BT_Email"
                    PdfExporter.Export(DGview, ExportSettings)
                    Dim fmail As New FormMail
                    fmail.Text = "Envoi d'email"
                    fmail.I_From.Text = gEmailFacture
                    fmail.I_smtp.Text = gSmtp
                    fmail.I_subject.Text = "Listing  www.chinook-leucate.com"
                    fmail.I_message.Text = "Madame, Monsieur," & vbCrLf & "Veuillez-trouver ci-joint le listing en pièce jointe" & vbCrLf & "Cordialement," & vbCrLf & "L'équipe www.chinook-leucate.com"

                    If fmail.ShowDialog() = Windows.Forms.DialogResult.OK Then
                        MessageBox.Show("Message envoyé", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Else
                        MessageBox.Show("Message annulé", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    End If
            End Select




            For Each r As DataGridViewRow In f.DataGridViewColonnes.Rows
                If Not r.Cells(1).Value Then
                    DGview.Columns(r.Cells(2).Value).visible = True

                End If
            Next
        End If
    End Sub
    Private Sub CodePostalTextBox_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        If e.KeyCode = 13 Then
            validecp()
        End If
    End Sub



    Private Sub CodePostalTextBox_Validated(ByVal sender As Object, ByVal e As System.EventArgs)
        validecp()

    End Sub

    Private Sub VilleTextBox_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        If e.KeyCode = 13 Then
            valideVille()
        End If
    End Sub

    Private Sub VilleTextBox_Validated(ByVal sender As Object, ByVal e As System.EventArgs)
        valideVille()
    End Sub
    Sub validecp()
        'test de la valeur du champ après split
        Dim vCodePostal As String
        Dim vVille As String
        If CodePostalTextbox.Text.Length >= 5 Then
            vCodePostal = CodePostalTextbox.Text.Substring(0, 5)

            If CodePostalTextbox.Text.Length > 5 Then
                vVille = CodePostalTextbox.Text.Substring(6).Replace("(", "").Replace(")", "")
                VilleTextBox.Text = vVille
            End If
            CodePostalTextbox.Text = vCodePostal
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

                    CodePostalTextbox.Text = vCodePostal
                End If

            End If
        End If

    End Sub


    Private Sub EtiquetteAdresseToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EtiquetteAdresseToolStripMenuItem.Click
        'Dim objPS As New System.Drawing.Printing.PrinterSettings
        'Dim objPaperSource As New System.Drawing.Printing.PaperSource

        'T_ClientTableAdapter.FillByid_t_client(Me.CLIDataSet.T_Client, DGview.SelectedRows(0).Cells("Ref").Value)
        'etiquetteExpedition1.SetDataSource(Me.CLIDataSet)
        'etiquetteExpedition1.PrintOptions.PrinterName = objPS.PrinterName
        '' etiquetteExpedition1.PrintOptions.PrinterName = gNomImprimanteEtiquette
        'etiquetteExpedition1.PrintOptions.PaperSource = CrystalDecisions.Shared.PaperSource.Auto


        '' etiquetteExpedition1.PrintToPrinter(1, False, 1, 1)
        Dim DymoAddIn As New Dymo.DymoAddIn
        Dim DymoLabels As New Dymo.DymoLabels
        Dim vDatatable As DataTable = ExecuteRequeteR("Select * from t_client where id_t_client=" & DGview.SelectedRows(0).Cells("Ref").Value, My.Settings.CLIConnectionString)
        Dim vAdresse As String
        vAdresse = vDatatable.Rows(0)("société").ToString
        vAdresse = vAdresse & vbCrLf & vDatatable.Rows(0)("nom").ToString & " " & vDatatable.Rows(0)("prenom").ToString
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


    Private Sub CodePostalTextbox_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CodePostalTextbox.TextChanged

    End Sub

    Private Sub EnvoyerMailRelanceAvoirsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EnvoyerMailRelanceAvoirsToolStripMenuItem.Click
        Dim fmail As New FormMail
        fmail.Text = "Envoi d'email relance avoirs"
        fmail.LinkLabel1.Visible = False
        fmail.PictureBox1.Visible = False

        fmail.I_From.Text = gEmailFacture
        fmail.I_smtp.Text = gSmtp

        'avoir du client selectionné
        Dim id_t_client As Long = DGview.SelectedRows(0).Cells("ref").Value
        Dim dtClient As DataTable = ExecuteRequeteR("select * from t_client where id_t_client=" & id_t_client, gCnn.ConnectionString)
        'fmail.I_To.Text = dtClient.Rows(0)("email").ToString
        fmail.vEmailClient = dtClient.Rows(0)("email").ToString
        fmail.vPiecejointe = False

        Dim dtAvoirs As DataTable = ExecuteRequeteR("select * from t_avoir where utilisele is null and montant>0 and id_t_client=" & id_t_client, gCnn.ConnectionString)

        Dim avoirs = ""
        For Each avoir As DataRow In dtAvoirs.Rows
            avoirs = avoirs & "N° " & avoir("id_t_avoir") & " d'un montant de " & FormatCurrency(avoir("montant"), 2) & " , créé le " & FormatDateTime(avoir("creele"), vbShortDate) & vbCrLf

        Next


        fmail.I_subject.Text = "Utilisation de vos avoirs www.chinook-leucate.com"
        fmail.I_message.Text = "Madame, Monsieur," & vbCrLf & "Vous disposez du/des avoir(s) suivant(s): " & vbCrLf & avoirs & "Nous vous invitons à le(s) utiliser lors d'une prochaine commande, au magasin, ou sur le site web, en vous connectant à votre <a href=""https://www.chinook-leucate.com/espaceclient-infos.aspx"">espace client</a> (dans ""j'ai déjà commandé, je m'identifie"") " & vbCrLf & "Cordialement," & vbCrLf & "L'équipe www.chinook-leucate.com"

        If fmail.ShowDialog() = Windows.Forms.DialogResult.OK Then

            'mise à jour de la dernière relance

            ExecuteRequeteR("INSERT INTO [dbo].[T_Relance]
           ([id_t_client]
           ,[TypeRelance]
           ,[DateRelance])
     VALUES
           (" & id_t_client & "
           ,'avoir'
           ,'" & Now.ToString & "')", gCnn.ConnectionString)
            'changement de la date dans le DG pour éviter le rechargement
            DGview.SelectedRows(0).Cells("DerniereRelanceAvoir").Value = Now.ToString
            MessageBox.Show("Message envoyé", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Else
            MessageBox.Show("Message annulé", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub

    Private Sub ContextMenuStripRecherche_Opening(sender As Object, e As CancelEventArgs) Handles ContextMenuStripRecherche.Opening
        Dim id_t_client As Long = DGview.SelectedRows(0).Cells("ref").Value
        Dim dtAvoirs As DataTable = ExecuteRequeteR("select * from t_avoir where utilisele is null and montant>0 and id_t_client=" & id_t_client, gCnn.ConnectionString)
        EnvoyerMailRelanceAvoirsToolStripMenuItem.Enabled = dtAvoirs.Rows.Count > 0



    End Sub


End Class