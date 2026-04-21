Public Class FormCommandeRecherche
    Public bs As New BindingSource

    Private Sub FormFournisseurRecherche_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If FormCaisse.Visible = True Then
            FormCaisse.Close()
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


        'TODO : cette ligne de code charge les données dans la table 'CLIDataSet.T_EtatCommandeVente'. Vous pouvez la déplacer ou la supprimer selon vos besoins.
        BT_Nouveau.Enabled = gVente_w
        Dim rEtatCommande As CLIDataSet.T_EtatCommandeVenteRow

        Me.T_EtatCommandeVenteTableAdapter.Fill(Me.CLIDataSet.T_EtatCommandeVente)
        rEtatCommande = Me.CLIDataSet.T_EtatCommandeVente.NewT_EtatCommandeVenteRow
        rEtatCommande("ID_T_EtatCommandeVente") = 0
        rEtatCommande("Libelle") = "<Tous>"
        Me.CLIDataSet.T_EtatCommandeVente.Rows.InsertAt(rEtatCommande, 0)

        'TODO : cette ligne de code charge les données dans la table 'CLIDataSet.V_Recherche_Commande_Vente'. Vous pouvez la déplacer ou la supprimer selon vos besoins.
        Raz()
        ToolStripStatusLabelNbEnregistrements.Text = System.String.Format("{0} enregistrement(s) sélectionné(s)", "0")
        'TODO : cette ligne de code charge les données dans la table 'CLIDataSet.V_Recherche_Article'. Vous pouvez la déplacer ou la supprimer selon vos besoins.
        'Me.V_Recherche_ArticleTableAdapter.Fill(Me.CLIDataSet.V_Recherche_Article)
        'Me.WindowState = FormWindowState.Maximized
    End Sub



    Private Sub OuvertureFiche(ByVal index As Integer)
        Cursor = Cursors.WaitCursor
        'Try
        If FormCaisse.Visible Then
            FormCaisse.Close()
        End If
        FormCaisse.MdiParent = Me.MdiParent

        'cas de l'affichage d'une fiche
        If index <> -1 Then
            FormCaisse.id_t_commande_vente = DGview.Rows(index).Cells("RefCommande").Value

        Else
            'cas d'une nouvelle fiche
            FormCaisse.id_t_commande_vente = 0
        End If

        FormCaisse.Show()
        FormCaisse.BringToFront()
        'Finally
        Cursor = Cursors.Default
        'End Try


    End Sub

    Private Sub V_Recherche_ArticleDataGridView_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGview.CellClick

    End Sub

    Private Sub V_Recherche_ArticleDataGridView_CellFormatting(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellFormattingEventArgs) Handles DGview.CellFormatting
        If DGview.Rows(e.RowIndex).Cells("Codeetat").Value.ToString <> "" Then
            Select Case DGview.Rows(e.RowIndex).Cells("Codeetat").Value
                Case 90 : e.CellStyle.BackColor = Color.Gray
                Case 40, 45 : e.CellStyle.BackColor = Color.DarkGreen
                    e.CellStyle.ForeColor = Color.White
                Case 30 : e.CellStyle.BackColor = Color.LimeGreen
                Case 20, 25 : e.CellStyle.BackColor = Color.LightGreen
                Case 10, 15 : e.CellStyle.BackColor = Color.White
            End Select
       
        Else
            e.CellStyle.BackColor = Color.Gray
        End If
    End Sub


    Private Sub V_Recherche_ArticleDataGridView_CellMouseDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles DGview.CellMouseDoubleClick

        If Not e.RowIndex = -1 And e.Button = Windows.Forms.MouseButtons.Left Then
            Dim index As Integer = e.RowIndex
            OuvertureFiche(index)
        End If
    End Sub

    Private Sub BT_Go_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BT_Go.Click

        Recherche(False, True)


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
            strsql_recherche = "select * from v_recherche_commande_vente where [Ref commande]=0"
        Else
            strsql_recherche = "select * from v_recherche_commande_vente where [Ref commande]>0"
        End If

        Dim strsql As String = ""

        If bNouveau = False And I_Reference.Text = "0" Then
            I_Reference.Text = ""
        End If

        If IsNumeric(I_Reference.Text) Then
            strsql = strsql & " and ([Ref commande]='" & I_Reference.Text & "')"
            GoTo fin
        End If

        If IsNumeric(I_ReferencePrestashop.Text) Then
            strsql = strsql & " and ([PanierPrestashop]='" & I_ReferencePrestashop.Text & "')"
            GoTo fin
        ElseIf I_ReferencePrestashop.Text <> "" Then
            strsql = strsql & " and ([ReferenceCommandePrestashop]='" & I_ReferencePrestashop.Text.Replace("'", "''") & "')"
            GoTo fin
        End If

        If IsNumeric(I_Ref_Client.Text) Then
            strsql = strsql & " and [Ref client]='" & I_Ref_Client.Text & "'"
            GoTo fin
        Else
            I_Ref_Client.Text = ""
        End If
        If I_Etat_min.Text <> "<Tous>" Then
            If IsNumeric(I_Etat_min.SelectedValue) Then
                strsql = strsql & " and  [code etat] >=" & I_Etat_min.SelectedValue
            End If
        End If
        If I_etat_max.Text <> "<Tous>" Then
            If IsNumeric(I_etat_max.SelectedValue) Then
                strsql = strsql & " and  [code etat] <=" & I_etat_max.SelectedValue
            End If
        End If

        If IsDate(I_Date_commande_debut.Text) Then
            strsql = strsql & " and  [date commande] >='" & I_Date_commande_debut.Text & "'"
        Else
            I_Date_commande_debut.Text = ""
        End If
        If IsDate(I_Date_expedition_debut.Text) Then
            strsql = strsql & " and  [date expedition] >='" & I_Date_expedition_debut.Text & "'"
        Else
            I_Date_expedition_debut.Text = ""
        End If
        If IsDate(I_Date_facture_debut.Text) Then
            strsql = strsql & " and  [date facture] >='" & I_Date_facture_debut.Text & "'"
        Else
            I_Date_facture_debut.Text = ""
        End If

        If IsDate(I_Date_commande_fin.Text) Then
            strsql = strsql & " and  [date commande] <='" & I_Date_commande_fin.Text & "'"
        Else
            I_Date_commande_fin.Text = ""
        End If
        If IsDate(I_Date_expedition_fin.Text) Then
            strsql = strsql & " and  [date expedition] <='" & I_Date_expedition_fin.Text & "'"
        Else
            I_Date_expedition_fin.Text = ""
        End If
        If IsDate(I_Date_facture_fin.Text) Then
            strsql = strsql & " and  [date facture] <='" & I_Date_facture_fin.Text & "'"
        Else
            I_Date_facture_fin.Text = ""
        End If




        If Not String.IsNullOrEmpty(Trim(I_Societe.Text)) Then
            strsql = strsql & " and [Société] like '%" & I_Societe.Text & "%'"
        End If
        If Not String.IsNullOrEmpty(Trim(I_Nom.Text)) Then
            strsql = strsql & " and [nom] like '%" & I_Nom.Text & "%'"
        End If
        If Not String.IsNullOrEmpty(Trim(CodePostalTextBox.Text)) Then
            strsql = strsql & " and [codepostal] like '%" & CodePostalTextBox.Text & "%'"
        End If
        If Not String.IsNullOrEmpty(Trim(VilleTextBox.Text)) Then
            strsql = strsql & " and [ville] like '%" & VilleTextBox.Text & "%'"
        End If
        If Not String.IsNullOrEmpty(Trim(I_Vendeur.Text)) Then
            strsql = strsql & " and [Vendeur] like '%" & I_Vendeur.Text & "%'"
        End If

        If Not String.IsNullOrEmpty(Trim(I_Pays.Text)) Then
            strsql = strsql & " and [Pays] like '%" & I_Pays.Text & "%'"
        End If

        Select Case I_Web.Text
            Case "Oui" : strsql = strsql & " and [web ?] = 1"
            Case "Non" : strsql = strsql & " and [web ?] = 0"
        End Select

        Select Case I_Encaisse.Text
            Case "Oui" : strsql = strsql & " and [Encaissé ?] = 1"
            Case "Non" : strsql = strsql & " and [Encaissé ?] = 0"
        End Select

        If I_NumCaisse.Text <> "<Tout>" Then
            If IsNumeric(I_NumCaisse.Text) Then
                strsql = strsql & " and  [numcaisse] =" & I_NumCaisse.Text
            End If
        End If

        Select Case I_SynchroPrestashop.Text
            Case "Ok" : strsql = strsql & " and [SynchroPrestashop] = 'Ok'"
            Case "Erreur" : strsql = strsql & " and [SynchroPrestashop] = 'Erreur'"
            Case "Non" : strsql = strsql & " and [SynchroPrestashop] = 'Non'"
        End Select

fin:

        Dim oSqlDataAdapter As New Data.SqlClient.SqlDataAdapter(strsql_recherche & strsql & "order by [date commande] desc", cnn)
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
        I_ReferencePrestashop.text = ""
        CodePostalTextBox.Text = ""
        I_Date_commande_debut.Text = ""
        I_Date_expedition_debut.Text = ""
        I_Date_facture_debut.Text = ""
        I_Date_commande_fin.Text = ""
        I_Date_expedition_fin.Text = ""
        I_Date_facture_fin.Text = ""

        I_Societe.Text = ""
        I_Nom.Text = ""
        VilleTextBox.Text = ""
        I_Pays.Text = ""
        I_Web.SelectedIndex = 0
        'changé de 0 à 2 le 24/04/2012 pour réduire le filtre par defaut et accélérer CLI
        I_Encaisse.SelectedIndex = 2
        I_Vendeur.Text = ""
        I_Etat_min.SelectedValue = 10

        I_etat_max.SelectedValue = 45

        'on règle par défaut sur la caisse du PC
        ' I_NumCaisse.SelectedIndex = I_NumCaisse.FindStringExact(gNumCaisse)
        'on règle la caisse sur "tout"
        I_NumCaisse.SelectedIndex = 0
        I_SynchroPrestashop.SelectedIndex = 0
    End Sub

    Private Sub DGview_CellMouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles DGview.CellMouseDown
        If e.Button = Windows.Forms.MouseButtons.Right And e.RowIndex <> -1 Then
            bs.Position = e.RowIndex

        End If
    End Sub

    Private Sub BT_Nouvel_Article_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BT_Nouveau.Click
        Nouvelle_Fiche()
    End Sub
    Public Sub Nouvelle_Fiche()
        I_Reference.Text = 0
        Recherche(True, False)
        OuvertureFiche(-1)
    End Sub
    Private Sub I_Reference_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles I_Reference.GotFocus, I_Ref_Client.GotFocus
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
        command.CommandText = "select distinct pays from v_recherche_commande_vente  Union select null as pays order by pays"
        command.Connection = cnn
        Dim reader As SqlClient.SqlDataReader = command.ExecuteReader
        bs.DataSource = reader
        I_Pays.DataSource = bs
        I_Pays.DisplayMember = "pays"
        cnn.Close()
    End Sub
    Private Sub I_vendeur_DropDown(ByVal sender As Object, ByVal e As System.EventArgs) Handles I_Vendeur.DropDown
        I_Vendeur.DataSource = Nothing
        Dim cnn As New SqlClient.SqlConnection(My.Settings.CLIConnectionString)
        cnn.Open()
        Dim bs As New BindingSource
        Dim command As New SqlClient.SqlCommand
        command.CommandText = "select distinct vendeur from v_recherche_commande_vente  Union select null as vendeur order by vendeur"
        command.Connection = cnn
        Dim reader As SqlClient.SqlDataReader = command.ExecuteReader
        bs.DataSource = reader
        I_Vendeur.DataSource = bs
        I_Vendeur.DisplayMember = "vendeur"
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

    Private Sub I_Web_SelectedIndexChanged(sender As Object, e As EventArgs) Handles I_Web.SelectedIndexChanged

    End Sub


End Class