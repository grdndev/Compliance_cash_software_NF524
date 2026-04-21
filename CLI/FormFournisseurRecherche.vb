Public Class FormFournisseurRecherche
    Public bs As New BindingSource
    Public vref As String = ""

    Private Sub FormFournisseurRecherche_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If FormFournisseur.Visible = True Then
            FormFournisseur.Close()
        End If
    End Sub

    Private Sub FormFournisseurRecherche_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim vVilleCP As New AutoCompleteStringCollection
        Dim vCPVille As New AutoCompleteStringCollection
        Dim vSourceVilleCP As DataTable
        vSourceVilleCP = ExecuteRequeteR("select codepostal,ville from t_cpvillefr", My.Settings.CLIConnectionString)

        For Each r As DataRow In vSourceVilleCP.Rows
            vVilleCP.Add(r("ville") & " (" & r("codepostal") & ")")
            vCPVille.Add(r("codepostal") & " (" & r("ville") & ")")
        Next

        VilleTextBox.AutoCompleteCustomSource = vVilleCP
        CodePostalTextBox.AutoCompleteCustomSource = vCPVille
        BT_Nouveau_Fournisseur.Enabled = gAchat_w
        If Me.Modal Then
            BT_Nouveau_Fournisseur.Visible = False
            ContextMenuStripRecherche.Visible = False
        End If

        Raz()
        ToolStripStatusLabelNbEnregistrements.Text = System.String.Format("{0} enregistrement(s) sélectionné(s)", "0")
        'TODO : cette ligne de code charge les données dans la table 'CLIDataSet.V_Recherche_Article'. Vous pouvez la déplacer ou la supprimer selon vos besoins.
        'Me.V_Recherche_ArticleTableAdapter.Fill(Me.CLIDataSet.V_Recherche_Article)
        'Me.WindowState = FormWindowState.Maximized
    End Sub



    Private Sub OuvertureFiche(ByVal index As Integer)
        Cursor = Cursors.WaitCursor
        Try
            If FormFournisseur.Visible Then
                FormFournisseur.Close()
            End If
            FormFournisseur.MdiParent = Me.MdiParent

            'cas de l'affichage d'une fiche
            If index <> -1 Then
                FormFournisseur.id_t_fournisseur = DGview.Rows(index).Cells("Ref").Value

            Else
                'cas d'une nouvelle fiche
                FormFournisseur.id_t_fournisseur = 0
            End If

            FormFournisseur.Show()
            FormFournisseur.BringToFront()
        Finally
            Cursor = Cursors.Default
        End Try


    End Sub

    Private Sub V_Recherche_ArticleDataGridView_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGview.CellClick

    End Sub

    Private Sub V_Recherche_ArticleDataGridView_CellFormatting(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellFormattingEventArgs) Handles DGview.CellFormatting
        If DGview.Rows(e.RowIndex).Cells("actif").Value.ToString <> "" Then
            If Not DGview.Rows(e.RowIndex).Cells("actif").Value Then
                e.CellStyle.BackColor = Color.Gray
            End If
        Else
            e.CellStyle.BackColor = Color.Gray
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
    Public Sub Recherche(Optional ByVal bNouveau As Boolean = False, Optional ByVal bAutoOpen As Boolean = True, Optional ByVal id_t_article_entete As String = "", Optional ByVal id_t_article_detail As String = "")
        Cursor = Cursors.WaitCursor
        Dim cnn As New SqlClient.SqlConnection(My.Settings.CLIConnectionString)
        cnn.Open()



        Dim strsql_recherche As String
        If bNouveau Then
            strsql_recherche = "select * from v_recherche_fournisseur where ref=0"
        Else
            strsql_recherche = "select * from v_recherche_fournisseur where ref>0"
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

        If Not String.IsNullOrEmpty(Trim(I_Societe.Text)) Then
            strsql = strsql & " and [Société] like '%" & I_Societe.Text & "%'"
        End If
        If Not String.IsNullOrEmpty(Trim(CodePostalTextBox.Text)) Then
            strsql = strsql & " and [codepostal] like '%" & CodePostalTextBox.Text & "%'"
        End If
        If Not String.IsNullOrEmpty(Trim(VilleTextBox.Text)) Then
            strsql = strsql & " and [ville] like '%" & VilleTextBox.Text & "%'"
        End If
        If Not String.IsNullOrEmpty(Trim(I_Pays.Text)) Then
            strsql = strsql & " and [Pays] like '%" & I_Pays.Text & "%'"
        End If


        Select Case I_Active.Text
            Case "Oui" : strsql = strsql & " and [actif] = 1"
            Case "Non" : strsql = strsql & " and [actif] = 0"
        End Select



fin:

        Dim oSqlDataAdapter As New Data.SqlClient.SqlDataAdapter(strsql_recherche & strsql, cnn)
        Dim oDataSet As New DataSet("RechercheDataset")

        oSqlDataAdapter.Fill(oDataSet, "Recherche")
        ToolStripStatusLabelNbEnregistrements.Text = System.String.Format("{0} enregistrement(s) sélectionné(s)", oDataSet.Tables("Recherche").Rows.Count.ToString)

        bs.DataSource = oDataSet.Tables("Recherche")


        DGview.DataSource = bs

        cnn.Close()
        'si un seul enregistrement on ouvre le formulaire directement
        If DGview.Rows.Count = 1 And bAutoOpen Then
            OuvertureFiche(0)
        End If

        Cursor = Cursors.Default
    End Sub
    Private Sub Raz()
        DGview.DataSource = Nothing
        I_Reference.Text = ""
        CodePostalTextBox.Text = ""
        I_NbArticlesMin.Text = ""
        I_NbArticlesMax.Text = ""
        I_Societe.Text = ""
        VilleTextBox.Text = ""
        I_Pays.Text = ""
        I_Active.SelectedIndex = 0

    End Sub

    Private Sub DGview_CellMouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles DGview.CellMouseDown
        If e.Button = Windows.Forms.MouseButtons.Right And e.RowIndex <> -1 Then
            bs.Position = e.RowIndex

        End If
    End Sub

    Private Sub BT_Nouvel_Article_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BT_Nouveau_Fournisseur.Click
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

    Private Sub SuppressionToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SuppressionToolStripMenuItem.Click

    End Sub

    Private Sub I_Pays_DropDown(ByVal sender As Object, ByVal e As System.EventArgs) Handles I_Pays.DropDown
        I_Pays.DataSource = Nothing
        Dim cnn As New SqlClient.SqlConnection(My.Settings.CLIConnectionString)
        cnn.Open()
        Dim bs As New BindingSource
        Dim command As New SqlClient.SqlCommand
        command.CommandText = "select distinct pays from v_recherche_fournisseur  Union select null as pays order by pays"
        command.Connection = cnn
        Dim reader As SqlClient.SqlDataReader = command.ExecuteReader
        bs.DataSource = reader
        I_Pays.DataSource = bs
        I_Pays.DisplayMember = "pays"
        cnn.Close()
    End Sub

   
    Private Sub DGview_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGview.CellContentClick

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

    Private Sub PaysComboBox_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles I_Pays.SelectedIndexChanged
        Select Case I_Pays.Text.ToUpper
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