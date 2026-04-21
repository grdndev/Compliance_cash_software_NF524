Imports System.Data.SqlClient
Imports System.Drawing
Imports System.Drawing.Imaging
Imports Microsoft.Reporting.WinForms


Public Class FormFournisseur
#Region "Variables form"
    'Déclaration des variables du formulaire
    Public id_t_fournisseur As Integer = 0
    Dim bs As New BindingSource
    Private CopieFiche As CLIDataSet.T_FournisseurRow = Nothing
#End Region
#Region "Formulaire"
    'Fonctions de gestion des évènements du formulaire
    Private Sub FormFournisseur_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'TODO : cette ligne de code charge les données dans la table 'CLIDataSet.T_modeReglement'. Vous pouvez la déplacer ou la supprimer selon vos besoins.
        NouveauToolStripButton.Enabled = gAchat_w
        BT_Enregistrer.Enabled = gAchat_w
        SupprimerToolStripButton.Enabled = gAchat_w
        Me.T_modeReglementTableAdapter.Fill(Me.CLIDataSet.T_modeReglement)
        'TODO : cette ligne de code charge les données dans la table 'CLIDataSet.T_Pays'. Vous pouvez la déplacer ou la supprimer selon vos besoins.
        Me.T_PaysTableAdapter.Fill(Me.CLIDataSet.T_Pays)


        If id_t_fournisseur = 0 Then
            ToolStrip2.Visible = False
        Else
            ToolStrip2.Visible = True
        End If

        Dim vSourceVilleCP As DataTable
        Dim vVilleCP As New AutoCompleteStringCollection
        Dim vCPVille As New AutoCompleteStringCollection
        vSourceVilleCP = ExecuteRequeteR("select codepostal,ville from t_cpvillefr", My.Settings.CLIConnectionString)

        For Each r As DataRow In vSourceVilleCP.Rows
            vVilleCP.Add(r("ville") & " (" & r("codepostal") & ")")
            vCPVille.Add(r("codepostal") & " (" & r("ville") & ")")
        Next

        VilleTextBox.AutoCompleteCustomSource = vVilleCP
        CodePostalTextBox.AutoCompleteCustomSource = vCPVille

        TabControl1.SelectTab("TabPageGeneral")

        Refresh_data()
    End Sub
#End Region
#Region "Boutons"
    Private Sub BT_Enregistrer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BT_Enregistrer.Click
        'on test les champs obligatoires généraux
        Dim err_msg As String = ""
        If SociétéTextBox.Text.Trim = "" Then
            err_msg = err_msg & vbCrLf & "- Société"
        End If

        If VilleTextBox.Text.Trim = "" Then
            err_msg = err_msg & vbCrLf & "- Ville"
        End If


        If err_msg = "" Then
            Enregistrer()

            NouveauToolStripButton.Enabled = True


            SupprimerToolStripButton.Enabled = True
            ToolStripButtonMovefirst.Enabled = True
            ToolStripButtonMovePrevious.Enabled = True
            ToolStripButtonMoveNext.Enabled = True
            ToolStripButtonMoveLast.Enabled = True
            ToolStripLabelPosition.Enabled = True
            If id_t_fournisseur = 0 Then
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
    Private Sub BT_Refresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BT_Refresh.Click
        Refresh_data()

        NouveauToolStripButton.Enabled = True
        SupprimerToolStripButton.Enabled = True
        ToolStripButtonMovefirst.Enabled = True
        ToolStripButtonMovePrevious.Enabled = True
        ToolStripButtonMoveNext.Enabled = True
        ToolStripButtonMoveLast.Enabled = True
        ToolStripLabelPosition.Enabled = True
    End Sub

    Private Sub BT_Fermer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BT_Fermer.Click
        Me.Close()
    End Sub
    Private Sub ToolStripButton2_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButtonMoveNext.Click

        FormFournisseurRecherche.bs.MoveNext()
        id_t_fournisseur = FormFournisseurRecherche.bs.Current.Item("Ref")
        Refresh_data()


    End Sub

    Private Sub ToolStripButton1_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButtonMovePrevious.Click

        FormFournisseurRecherche.bs.MovePrevious()
        id_t_fournisseur = FormFournisseurRecherche.bs.Current.Item("Ref")
        Refresh_data()

    End Sub

    Private Sub ToolStripButton3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButtonMoveLast.Click

        FormFournisseurRecherche.bs.MoveLast()
        id_t_fournisseur = FormFournisseurRecherche.bs.Current.Item("Ref")
        Refresh_data()

    End Sub

    Private Sub ToolStripButton4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButtonMovefirst.Click

        FormFournisseurRecherche.bs.MoveFirst()
        id_t_fournisseur = FormFournisseurRecherche.bs.Current.Item("Ref")
        Refresh_data()

    End Sub

    Private Sub NouveauToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NouveauToolStripButton.Click
        NouveauGene()
    End Sub
    Private Sub SupprimerToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SupprimerToolStripButton.Click
        'vérification que le fournisseur ne possède pas d'article lié
        If bs.Count > 0 Then
            MessageBox.Show("Vous ne pouvez pas supprimer un fournisseur utilisé dans des fiches article" & vbCrLf & "Merci de changer les article correspondants avant suppression", "Attention !", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        Else
            Dim reponse As DialogResult = MessageBox.Show("Souhaitez vous vraiment supprimer ce fournisseur ?", "Attention", MessageBoxButtons.OKCancel, MessageBoxIcon.Question)
            If reponse = Windows.Forms.DialogResult.OK Then

                T_FournisseurBindingSource.Remove(T_FournisseurBindingSource.Current)
                Enregistrer()
                'rafraichissement du moteur de recherche et repositionnement sur l'enregistrement
                RafraichissementDuMoteurDeRecherche()
                MajPosition()
                MessageBox.Show("Enregistrement(s) supprimé(s)", "CLI", MessageBoxButtons.OK, MessageBoxIcon.Information)
                'Fermer la form si dernier enregistrement
                If ToolStripLabelPosition.Text = "0/0" Then
                    Me.Close()
                End If
            End If
        End If

       
    End Sub

    Private Sub CopierToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CopierToolStripButton.Click
        Dim col As DataColumn
        Dim courant As CLIDataSet.T_FournisseurRow = Me.CLIDataSet.T_Fournisseur(T_FournisseurBindingSource.Position)
        CopieFiche = Me.CLIDataSet.T_Fournisseur.NewT_FournisseurRow

        For Each col In courant.Table.Columns
            If UCase(col.ColumnName) <> "ID_T_FOURNISSEUR" And UCase(col.ColumnName) <> "CREELE" And UCase(col.ColumnName) <> "MODIFIELE" And UCase(col.ColumnName) <> "MODIFIEPAR" And UCase(col.ColumnName) <> "CREEPAR" Then

                CopieFiche.Item(col.ColumnName) = courant.Item(col.ColumnName)
            End If
        Next
        CollerToolStripButton.Enabled = True
    End Sub

    Private Sub CollerToolStripButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles CollerToolStripButton.Click
        Dim col As DataColumn
        Dim courant As CLIDataSet.T_FournisseurRow = Me.CLIDataSet.T_Fournisseur(0)
        For Each col In courant.Table.Columns
            If UCase(col.ColumnName) <> "ID_T_FOURNISSEUR" Then
                Me.CLIDataSet.T_Fournisseur(Me.CLIDataSet.T_Fournisseur.Rows.Count - 1).Item(col.ColumnName) = CopieFiche.Item(col.ColumnName)
            End If
        Next
    End Sub
#End Region
#Region "DGview"
    Private Sub DGview_CellFormatting(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellFormattingEventArgs)
        If DGview.Rows(e.RowIndex).Cells("active_on").Value.ToString <> "" Then
            If Not DGview.Rows(e.RowIndex).Cells("active_on").Value Then
                e.CellStyle.BackColor = Color.Gray
            End If
        Else
            e.CellStyle.BackColor = Color.Gray
        End If
    End Sub




    Private Sub DGview_CellMouseDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles DGview.CellMouseDoubleClick
        If Not e.RowIndex = -1 And e.Button = Windows.Forms.MouseButtons.Left Then
            FormArticleRecherche.MdiParent = FormPrincipale

            FormArticleRecherche.Show()
            FormArticleRecherche.WindowState = FormWindowState.Normal
            Me.BringToFront()
            FormArticleRecherche.I_Reference.Text = DGview.Rows(e.RowIndex).Cells("Ref").Value.ToString
            FormArticleRecherche.Recherche(False, True)
        End If
    End Sub
    Private Sub DGview_CellMouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles DGview.CellMouseDown
        If e.Button = Windows.Forms.MouseButtons.Right And e.RowIndex <> -1 Then
            bs.Position = e.RowIndex

        End If
    End Sub
#End Region
#Region "Procédures"
    Private Sub MajPosition()
        If Not FormFournisseurRecherche.bs.Current Is Nothing Then

            If FormFournisseurRecherche.bs.Find("Ref", id_t_fournisseur) = -1 Then
                FormFournisseurRecherche.bs.MoveFirst()
                id_t_fournisseur = FormFournisseurRecherche.bs.Current.item("ref")
                Refresh_data()
            End If
            ToolStripLabelPosition.Text = String.Format("{0}/{1}", FormFournisseurRecherche.bs.Find("Ref", id_t_fournisseur) + 1, FormFournisseurRecherche.bs.Count)

            If FormFournisseurRecherche.bs.Position = FormFournisseurRecherche.bs.Count - 1 Then
                ToolStripButtonMoveNext.Enabled = False
                ToolStripButtonMoveLast.Enabled = False
            Else
                ToolStripButtonMoveNext.Enabled = True
                ToolStripButtonMoveLast.Enabled = True
            End If
            If FormFournisseurRecherche.bs.Position = 0 Then
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
    Private Sub RafraichissementDuMoteurDeRecherche()
        If FormFournisseurRecherche.Visible Then
            FormFournisseurRecherche.Recherche(False, False)
            FormFournisseurRecherche.bs.Position = FormFournisseurRecherche.bs.Find("Ref", id_t_fournisseur)

        End If
    End Sub

    Private Sub Enregistrer()
        Cursor = Cursors.WaitCursor

        Try

            Me.Validate()


            If Not Me.T_FournisseurBindingSource.Current Is Nothing Then
                Me.T_FournisseurBindingSource.Current.item("ModifieLe") = Date.Now
                Me.T_FournisseurBindingSource.Current.item("ModifiePar") = gLogin
            End If

            Me.T_FournisseurBindingSource.EndEdit()

            Me.T_FournisseurTableAdapter.Update(Me.CLIDataSet.T_Fournisseur)
            If Not Me.T_FournisseurBindingSource.Current Is Nothing Then
                id_t_fournisseur = T_FournisseurBindingSource.Current.item("Id_t_fournisseur")
            Else
                id_t_fournisseur = 0
            End If



            'rafraichissement du moteur de recherche et repositionnement sur l'enregistrement
            RafraichissementDuMoteurDeRecherche()
            MajPosition()

        Catch ex As Exception
        Finally
            Cursor = Cursors.Default
        End Try


    End Sub
    Private Sub Refresh_data()
        Cursor = Cursors.WaitCursor

        If id_t_fournisseur > 0 Then
            Me.T_FournisseurTableAdapter.FillByID_T_Fournisseur(Me.CLIDataSet.T_Fournisseur, id_t_fournisseur)
            RefreshArticles(id_t_fournisseur)
        Else
            NouveauGene()
        End If

        MajPosition()
        'refraichissement du nombre d'enregistrements utilisant celui ci

        Cursor = Cursors.Default
    End Sub
    Private Sub NouveauGene()
        T_FournisseurBindingSource.AddNew()
        T_FournisseurBindingSource.EndEdit()

        RefreshArticles(0)

        DGview.DataSource = Nothing



        PaysComboBox.SelectedIndex = -1

        NouveauToolStripButton.Enabled = False


        SupprimerToolStripButton.Enabled = False

        ToolStripButtonMovefirst.Enabled = False
        ToolStripButtonMovePrevious.Enabled = False
        ToolStripButtonMoveNext.Enabled = False
        ToolStripButtonMoveLast.Enabled = False


    End Sub
    Private Sub RefreshArticles(ByVal id_t_fournisseur As Integer)
        Cursor = Cursors.WaitCursor

        Dim cnn As New SqlClient.SqlConnection(My.Settings.CLIConnectionString)
        cnn.Open()
        Dim strsql_recherche As String

        strsql_recherche = "select active_on,ref,[description courte],prix_vente_initial_TTC,remise,prix_vente_remise_TTC,web_on,magasin_on,stock from v_recherche_article where id_t_fournisseur=" & id_t_fournisseur

        Dim oSqlDataAdapter As New Data.SqlClient.SqlDataAdapter(strsql_recherche, cnn)
        Dim oDataSet As New DataSet("RechercheDataset")

        oSqlDataAdapter.Fill(oDataSet, "Recherche")

        bs.DataSource = oDataSet.Tables("Recherche")

        DGview.DataSource = bs
        ToolStripStatusLabelNbEnregistrementsArticles.Text = System.String.Format("{0} enregistrement(s) sélectionné(s)", oDataSet.Tables("Recherche").Rows.Count.ToString)

        cnn.Close()

        Cursor = Cursors.Default

    End Sub
#End Region

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


    Private Sub PaysComboBox_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles PaysComboBox.SelectedIndexChanged
        Select Case PaysComboBox.Text.ToUpper
            Case "FRANCE", "GUADELOUPE", "GUYANE", "LA RÉUNION", "NOUVELLE CALÉDONIE", "POLYNÉSIE FRANÇAISE", "SAINT-MARTIN", "SIANT-PIERRE-ET-MIQUELON", "SAINT BARTHÉLEMY"
                AddHandler CodePostalTextBox.Validated, AddressOf CodePostalTextBox_Validated
                AddHandler CodePostalTextBox.KeyDown, AddressOf CodePostalTextBox_KeyDown
                AddHandler VilleTextBox.Validated, AddressOf VilleTextBox_Validated
                AddHandler VilleTextBox.KeyDown, AddressOf VilleTextBox_KeyDown
                CodePostalTextBox.AutoCompleteMode = AutoCompleteMode.SuggestAppend
                VilleTextBox.AutoCompleteMode = AutoCompleteMode.SuggestAppend

            Case Else
                RemoveHandler CodePostalTextBox.Validated, AddressOf CodePostalTextBox_Validated
                RemoveHandler CodePostalTextBox.KeyDown, AddressOf CodePostalTextBox_KeyDown
                RemoveHandler VilleTextBox.Validated, AddressOf VilleTextBox_Validated
                RemoveHandler VilleTextBox.KeyDown, AddressOf VilleTextBox_KeyDown
                CodePostalTextBox.AutoCompleteMode = AutoCompleteMode.None
                VilleTextBox.AutoCompleteMode = AutoCompleteMode.None

        End Select

    End Sub
End Class