Imports CompletIT.Windows.Forms.Export.Pdf
Public Class FormArticleRecherche
    Public bs As New BindingSource
    Public vref As String = ""
    Public Ids As List(Of Long)



    Private Sub FormArticleRecherche_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If FormArticle2.Visible Then
            FormArticle2.Close()
        End If
    End Sub

    Private Sub FormArticleRecherche_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        'activation de certaines colonnes / champs en fonction du droit gPrixStock dans le profil de l'utilisateur
        If gPrixStock Then
            prix_fournisseur.Visible = True
            remise_fournisseur.Visible = True
            prix_remise_fournisseur.Visible = True
            IL_TotalStockHT.Visible = True
            I_TotalStockHT.Visible = True
            TotalStockHT.Visible = True
        End If


        BT_Nouvel_Article.Enabled = gArticle_w
        ContextMenuStripRecherche.Enabled = gArticle_stock
        ActiverToolStripMenuItem1.Enabled = gmenuActivationWeb
        'désactivation des boutons inutiles en fonction du type d'affichage de fenetre (mdi ou modale)
        If Me.Modal Then
            BT_Nouvel_Article.Visible = False
            ContextMenuStripRecherche.Visible = False
        End If

        Raz()
        ToolStripStatusLabelNbEnregistrements.Text = System.String.Format("{0} enregistrement(s) sélectionné(s)", "0")
        'TODO : cette ligne de code charge les données dans la table 'CLIDataSet.V_Recherche_Article'. Vous pouvez la déplacer ou la supprimer selon vos besoins.
        'Me.V_Recherche_ArticleTableAdapter.Fill(Me.CLIDataSet.V_Recherche_Article)
        'Me.WindowState = FormWindowState.Maximized
    End Sub



    Private Sub OuvertureFicheArticle(ByVal index As Integer)
        Cursor = Cursors.WaitCursor
        Try
            If FormArticle2.Visible Then
                FormArticle2.Close()
            End If
            FormArticle2.MdiParent = Me.MdiParent

            'cas de l'affichage d'une fiche
            If index <> -1 Then
                FormArticle2.id_t_article_version = DGview.Rows(index).Cells("Ref").Value

            Else
                'cas d'une nouvelle fiche
                FormArticle2.id_t_article_version = 0
            End If

            FormArticle2.Show()
            FormArticle2.BringToFront()
        Finally
            Cursor = Cursors.Default
        End Try


    End Sub

    Private Sub V_Recherche_ArticleDataGridView_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGview.CellClick

    End Sub

    Private Sub V_Recherche_ArticleDataGridView_CellFormatting(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellFormattingEventArgs) Handles DGview.CellFormatting
        If e.RowIndex <> -1 Then
            If DGview.Rows(e.RowIndex).Cells("active_on").Value.ToString <> "" Then
                If Not DGview.Rows(e.RowIndex).Cells("active_on").Value Then
                    e.CellStyle.BackColor = Color.Gray
                End If
            Else
                e.CellStyle.BackColor = Color.Gray
            End If
        End If
    End Sub


    Private Sub V_Recherche_ArticleDataGridView_CellMouseDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles DGview.CellMouseDoubleClick

        If Not e.RowIndex = -1 And e.Button = Windows.Forms.MouseButtons.Left And DGview.SelectedRows.Count = 1 Then
            If Me.Modal Then
                vref = DGview.Rows(e.RowIndex).Cells("Ref").Value.ToString
                Me.DialogResult = Windows.Forms.DialogResult.OK
                Me.Close()
            Else
                Dim index As Integer = e.RowIndex
                OuvertureFicheArticle(index)
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





    Private Sub I_Famille_DropDown(ByVal sender As Object, ByVal e As System.EventArgs) Handles I_Famille.DropDown
        I_Famille.DataSource = Nothing
        I_SousFamille.DataSource = Nothing

        Dim cnn As New SqlClient.SqlConnection(My.Settings.CLIConnectionString)
        cnn.Open()
        Dim bs As New BindingSource
        Dim command As New SqlClient.SqlCommand
        command.CommandText = "select distinct famille from v_recherche_article  Union select null as famille order by famille"
        command.Connection = cnn
        Dim reader As SqlClient.SqlDataReader = command.ExecuteReader
        bs.DataSource = reader
        I_Famille.DataSource = bs
        I_Famille.DisplayMember = "famille"
        cnn.Close()

    End Sub
    Private Sub I_Marque_DropDown(ByVal sender As Object, ByVal e As System.EventArgs) Handles I_Marque.DropDown
        I_Marque.DataSource = Nothing
        I_Modele.DataSource = Nothing


        Dim cnn As New SqlClient.SqlConnection(My.Settings.CLIConnectionString)
        cnn.Open()
        Dim bs As New BindingSource
        Dim command As New SqlClient.SqlCommand
        command.CommandText = "select distinct Marque from v_recherche_article  Union select null as marque order by marque"
        command.Connection = cnn
        Dim reader As SqlClient.SqlDataReader = command.ExecuteReader
        bs.DataSource = reader
        I_Marque.DataSource = bs
        I_Marque.DisplayMember = "marque"
        cnn.Close()

    End Sub
    Private Sub I_Modele_DropDown(ByVal sender As Object, ByVal e As System.EventArgs) Handles I_Modele.DropDown
        If I_Marque.Text <> "" Then
            I_Modele.DataSource = Nothing

            Dim cnn As New SqlClient.SqlConnection(My.Settings.CLIConnectionString)
            cnn.Open()
            Dim bs As New BindingSource
            Dim command As New SqlClient.SqlCommand
            command.CommandText = "select distinct modele from v_recherche_article where marque='" & Replace(I_Marque.Text, "'", "''") & "'  Union select null as modele order by modele"
            command.Connection = cnn
            Dim reader As SqlClient.SqlDataReader = command.ExecuteReader
            bs.DataSource = reader
            I_Modele.DataSource = bs
            I_Modele.DisplayMember = "modele"
            cnn.Close()
        End If
    End Sub



    Private Sub I_SousFamille_DropDown(ByVal sender As Object, ByVal e As System.EventArgs) Handles I_SousFamille.DropDown
        If I_Famille.Text <> "" Then
            I_SousFamille.DataSource = Nothing
            Dim cnn As New SqlClient.SqlConnection(My.Settings.CLIConnectionString)
            cnn.Open()
            Dim bs As New BindingSource
            Dim command As New SqlClient.SqlCommand

            command.CommandText = "select distinct [sous famille] from v_recherche_article  where famille='" & Replace(I_Famille.Text, "'", "''") & "' Union select null as [sous famille] order by [sous famille]"



            command.Connection = cnn
            Dim reader As SqlClient.SqlDataReader = command.ExecuteReader
            bs.DataSource = reader

            I_SousFamille.DataSource = bs
            I_SousFamille.DisplayMember = "sous famille"
            cnn.Close()
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
            strsql_recherche = "select * from v_recherche_article where ref=0"
        Else
            strsql_recherche = "select * from v_recherche_article where ref>0"
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

        If id_t_article_entete <> "" Then
            strsql_recherche = "select * from v_recherche_article where id_t_article_entete=" & id_t_article_entete
            GoTo fin
        End If

        If id_t_article_detail <> "" Then
            strsql_recherche = "select * from v_recherche_article where id_t_article_detail=" & id_t_article_detail
            GoTo fin
        End If

        If Not String.IsNullOrEmpty(Trim(I_Description.Text)) Then
            strsql = strsql & " and [description courte] like '%" & Replace(I_Description.Text, "'", "''") & "%'"
        End If
        If Not String.IsNullOrEmpty(Trim(I_Famille.Text)) Then
            strsql = strsql & " and [famille] = '" & Replace(I_Famille.Text, "'", "''") & "'"
        End If
        If Not String.IsNullOrEmpty(Trim(I_SousFamille.Text)) Then
            strsql = strsql & " and [sous famille] = '" & Replace(I_SousFamille.Text, "'", "''") & "'"
        End If
        If Not String.IsNullOrEmpty(Trim(I_Type.Text)) Then
            strsql = strsql & " and [type] = '" & Replace(I_Type.Text, "'", "''") & "'"
        End If
        If Not String.IsNullOrEmpty(Trim(I_Type2.Text)) Then
            strsql = strsql & " and [type2] = '" & Replace(I_Type2.Text, "'", "''") & "'"
        End If
        If Not String.IsNullOrEmpty(Trim(I_Type3.Text)) Then
            strsql = strsql & " and [type3] = '" & Replace(I_Type3.Text, "'", "''") & "'"
        End If
        If Not String.IsNullOrEmpty(Trim(I_Type4.Text)) Then
            strsql = strsql & " and [type4] = '" & Replace(I_Type4.Text, "'", "''") & "'"
        End If
        If Not String.IsNullOrEmpty(Trim(I_Programme.Text)) Then
            strsql = strsql & " and [programme] = '" & Replace(I_Programme.Text, "'", "''") & "'"
        End If

        If Not String.IsNullOrEmpty(Trim(I_Marque.Text)) Then
            strsql = strsql & " and [marque] = '" & Replace(I_Marque.Text, "'", "''") & "'"
        End If
        If Not String.IsNullOrEmpty(Trim(I_Modele.Text)) Then
            strsql = strsql & " and [modele] = '" & Replace(I_Modele.Text, "'", "''") & "'"
        End If
        If Not String.IsNullOrEmpty(Trim(I_Annee.Text)) Then
            strsql = strsql & " and [Annee] like '%" & Replace(I_Annee.Text, "'", "''") & "%'"
        End If
        If IsNumeric(I_Fournisseur.SelectedValue) Then
            strsql = strsql & " and [ID_T_Fournisseur] = '" & I_Fournisseur.SelectedValue & "'"
        End If
        If IsNumeric(I_ClientMin.Text) Then
            strsql = strsql & " and [ID_T_client] >= " & I_ClientMin.Text
        End If
        If IsNumeric(I_ClientMax.Text) Then
            strsql = strsql & " and [ID_T_client] <= " & I_ClientMax.Text
        End If
        If IsDate(I_CreeMin.Text) Then
            strsql = strsql & " and [CreeLe] >= '" & I_CreeMin.Text & "'"
        End If
        If IsDate(I_creeMax.Text) Then
            strsql = strsql & " and [CreeLe] <= '" & I_creeMax.Text & "'"
        End If
        If Not String.IsNullOrEmpty(Trim(I_CreePar.Text)) Then
            strsql = strsql & " and [creepar] Like '" & Replace(I_CreePar.Text, "'", "''") & "'"
        End If



        If IsNumeric(I_Ref_Fournisseur.Text) Then
            strsql = strsql & " and [Ref_Fournisseur] = '" & Replace(I_Ref_Fournisseur.Text, "'", "''") & "'"
        End If
        If IsNumeric(I_StockMin.Text) Then
            strsql = strsql & " and [Stock] >= " & I_StockMin.Text
        End If
        If IsNumeric(I_StockMax.Text) Then
            strsql = strsql & " and [Stock] <= " & I_StockMax.Text
        End If
        Select Case I_Active.Text
            Case "Oui" : strsql = strsql & " and [active_on] = 1"
            Case "Non" : strsql = strsql & " and [active_on] = 0"
        End Select
        Select Case I_Web.Text
            Case "Oui" : strsql = strsql & " and [web_on] = 1"
            Case "Non" : strsql = strsql & " and [web_on] = 0"
        End Select
        Select Case I_Magasin.Text
            Case "Oui" : strsql = strsql & " and [magasin_on] = 1"
            Case "Non" : strsql = strsql & " and [magasin_on] = 0"
        End Select
        Select Case I_Occaz.Text
            Case "Oui" : strsql = strsql & " and [Occaz] = 1"
            Case "Non" : strsql = strsql & " and [Occaz] = 0"
        End Select
        Select Case I_Depot.Text
            Case "Oui" : strsql = strsql & " and [Depot_vente] = 1"
            Case "Non" : strsql = strsql & " and [Depot_vente] = 0"
        End Select
        Select Case I_RepriseDepot.Text
            Case "Oui" : strsql = strsql & " and ([Occaz]=1 or [Depot_vente] = 1  or [test] = 1)"
            Case "Non" : strsql = strsql & " and ([Occaz]=0 and [Depot_vente] = 0 and  [test] = 0)"
        End Select
        Select Case I_test.Text
            Case "Oui" : strsql = strsql & " and [test] = 1"
            Case "Non" : strsql = strsql & " and [test] = 0"
        End Select
        Select Case I_Promo.Text
            Case "Oui" : strsql = strsql & " and [remise] <> 0"
            Case "Non" : strsql = strsql & " and [remise] = 0"
        End Select
        Select Case I_SynchroPrestashop.Text
            Case "Ok" : strsql = strsql & " and [SynchroPrestashop] = 'Ok'"
            Case "Erreur" : strsql = strsql & " and [SynchroPrestashop] = 'Erreur'"
            Case "Non" : strsql = strsql & " and [SynchroPrestashop] = 'Non'"
        End Select


fin:

        Dim oSqlDataAdapter As New Data.SqlClient.SqlDataAdapter(strsql_recherche & strsql & " order by ref", cnn)
        Dim oDataSet As New DataSet("RechercheDataset")

        oSqlDataAdapter.Fill(oDataSet, "Recherche")
        ToolStripStatusLabelNbEnregistrements.Text = System.String.Format("{0} enregistrement(s) sélectionné(s)", oDataSet.Tables("Recherche").Rows.Count.ToString)

        bs.DataSource = oDataSet.Tables("Recherche")
        ' on parcourt la table pour avoir le total du stock HT

        I_TotalStockHT.Text = 0
        For Each r As DataRow In oDataSet.Tables("Recherche").Rows
            If IsNumeric(r("Total stock HT").ToString) Then
                I_TotalStockHT.Text = I_TotalStockHT.Text + r("Total stock HT")
            End If

        Next
        I_TotalStockHT.Text = Format(I_TotalStockHT.Text, "Currency")

        DGview.DataSource = bs

        cnn.Close()
        'si un seul enregistrement on ouvre le formulaire directement
        If DGview.Rows.Count = 1 And bAutoOpen Then
            OuvertureFicheArticle(0)
        End If

        Cursor = Cursors.Default
    End Sub
    Private Sub Raz()
        DGview.DataSource = Nothing
        I_Reference.Text = ""
        I_Annee.Text = ""
        I_Description.Text = ""
        I_Famille.Text = ""
        I_SousFamille.Text = ""
        I_Marque.Text = ""
        I_Modele.Text = ""
        I_Web.SelectedIndex = 0
        I_Magasin.SelectedIndex = 0
        I_Active.SelectedIndex = 1
        I_Occaz.SelectedIndex = 0
        I_Depot.SelectedIndex = 0
        I_RepriseDepot.SelectedIndex = 0
        I_ClientMax.Text = ""
        I_ClientMin.Text = ""
        I_creeMax.Text = ""
        I_CreeMin.Text = ""
        I_TotalStockHT.Text = 0
        I_StockMin.Text = ""
        I_StockMax.Text = ""
        I_test.SelectedIndex = 0
        I_Type.Text = ""
        I_Type2.Text = ""
        I_Type3.Text = ""
        I_Type4.Text = ""
        I_Programme.Text = ""
        I_Promo.SelectedIndex = 0
        I_SynchroPrestashop.SelectedIndex = 0


        I_CreePar.Clear()


    End Sub

    Private Sub ContextMenuStrip_Opening(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles ContextMenuStripRecherche.Opening
        If DGview.SelectedRows.Count < 1 Then
            'on ferme le menu si aucune ligne selectionnée
            e.Cancel = True
        Else
            If DGview.SelectedRows.Count > 1 Then
                'on desactive la partie stock/copie si plusieurs article selectionnés
                StockToolStripMenuItem.Visible = False
                CopieDarticlecompletToolStripMenuItem.Visible = False
                CréationRepriseToolStripMenuItem.Visible = False
                CréationDépotVenteToolStripMenuItem.Visible = False
            Else
                StockToolStripMenuItem.Visible = True
                CopieDarticlecompletToolStripMenuItem.Visible = True
                CréationRepriseToolStripMenuItem.Visible = True
                CréationDépotVenteToolStripMenuItem.Visible = True
            End If



        End If
    End Sub

    Private Sub V_Recherche_ArticleDataGridView_CellMouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles DGview.CellMouseClick

    End Sub


    Private Sub InventaireToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles InventaireToolStripMenuItem.Click
        FormArticle2.Inventaire(bs.Current.item("Ref"))

    End Sub

    Private Sub MouvementToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MouvementToolStripMenuItem.Click
        FormArticle2.MajStock(bs.Current.item("Ref"))
    End Sub


    Private Sub V_Recherche_ArticleDataGridView_CellMouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles DGview.CellMouseDown
        If e.Button = Windows.Forms.MouseButtons.Right And e.RowIndex <> -1 Then
            bs.Position = e.RowIndex

        End If
    End Sub

    Private Sub BT_Nouvel_Article_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BT_Nouvel_Article.Click

        Nouvel_article()
    End Sub
    Public Sub Nouvel_article()
        I_Reference.Text = 0
        Recherche(True, False)
        OuvertureFicheArticle(-1)
    End Sub



    Private Sub I_Reference_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles I_Reference.GotFocus, I_Ref_Fournisseur.GotFocus
        sender.text = ""
    End Sub

    Private Sub BT_Fermer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BT_Fermer.Click
        Me.Close()
    End Sub

    Private Sub DGview_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles DGview.MouseDown

    End Sub

    Private Sub I_SousFamille_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles I_SousFamille.SelectedIndexChanged

    End Sub

    Private Sub I_Fournisseur_DropDown(ByVal sender As Object, ByVal e As System.EventArgs) Handles I_Fournisseur.DropDown

        remplissageFournisseur()

    End Sub
    Public Sub remplissageFournisseur()
        I_Fournisseur.DataSource = Nothing
        Dim cnn As New SqlClient.SqlConnection(My.Settings.CLIConnectionString)
        cnn.Open()
        Dim bs As New BindingSource
        Dim command As New SqlClient.SqlCommand

        command.CommandText = "select * from  V_Fournisseur_combo Union select null as [Id_T_Fournisseur],null as Libelle order by [Libelle]"



        command.Connection = cnn
        Dim reader As SqlClient.SqlDataReader = command.ExecuteReader
        bs.DataSource = reader

        I_Fournisseur.DataSource = bs

        I_Fournisseur.DisplayMember = "Libelle"
        I_Fournisseur.ValueMember = "ID_T_Fournisseur"
        cnn.Close()
    End Sub



    Private Sub BT_Impression_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BT_Impression.Click, BT_Email.Click

        Dim critere As String = ""
        Dim settings As New CompletIT.Windows.Forms.Printing.DGVEPrintSettings

        Dim PdfExporter As DGVEPdfExporter = New DGVEPdfExporter()
        Dim ExportSettings As DGVEPdfExportSettings = New DGVEPdfExportSettings()
        settings.PrintHeaderText = True

        If I_Famille.Text <> "" Then
            critere = critere & vbCrLf & "Famille : " & I_Famille.Text
        End If
        If I_SousFamille.Text <> "" Then
            critere = critere & vbCrLf & "Sous Famille : " & I_SousFamille.Text
        End If
        If I_Marque.Text <> "" Then
            critere = critere & vbCrLf & "Marque : " & I_Marque.Text
        End If
        If I_Modele.Text <> "" Then
            critere = critere & vbCrLf & "Modele : " & I_Modele.Text
        End If
        If I_Annee.Text <> "" Then
            critere = critere & vbCrLf & "Annee : " & I_Annee.Text
        End If
        If I_Description.Text <> "" Then
            critere = critere & vbCrLf & "Description : " & I_Description.Text
        End If
        If I_Fournisseur.Text <> "" Then
            critere = critere & vbCrLf & "Fournisseur : " & I_Fournisseur.Text
        End If
        If I_StockMin.Text <> "" Then
            critere = critere & vbCrLf & "Stock mini : " & I_StockMin.Text
        End If
        If I_StockMax.Text <> "" Then
            critere = critere & vbCrLf & "Stock maxi : " & I_StockMax.Text
        End If
        If I_Active.Text <> "<Tous>" Then
            critere = critere & vbCrLf & "Actif ? : " & I_Active.Text
        End If
        If I_Web.Text <> "<Tous>" Then
            critere = critere & vbCrLf & "Web ? : " & I_Web.Text
        End If
        If I_Magasin.Text <> "<Tous>" Then
            critere = critere & vbCrLf & "Magasin ? : " & I_Magasin.Text
        End If
        If I_Occaz.Text <> "<Tous>" Then
            critere = critere & vbCrLf & "Reprise magasin : " & I_Occaz.Text
        End If
        If I_Depot.Text <> "<Tous>" Then
            critere = critere & vbCrLf & "Dépôt vente : " & I_Depot.Text
        End If
        If I_RepriseDepot.Text <> "<Tous>" Then
            critere = critere & vbCrLf & "Dépôt vente ou reprise magasin : " & I_RepriseDepot.Text
        End If
        If I_test.Text <> "<Tous>" Then
            critere = critere & vbCrLf & "Test : " & I_test.Text
        End If
        If I_Promo.Text <> "<Tous>" Then
            critere = critere & vbCrLf & "Promo : " & I_Promo.Text
        End If


        'If gPrixStock And sender.name <> "BT_Email" Then
        '    critere = critere & vbCrLf & "Total stock HT : " & I_TotalStockHT.Text
        'End If

        If gPrixStock Then
            critere = critere & vbCrLf & "Total stock HT : " & I_TotalStockHT.Text
        End If
        Dim bDepotList As Boolean = DirectCast(DirectCast(DGview.DataSource, System.Windows.Forms.BindingSource).List, System.Data.DataView).Table.Select("depot_vente=True").Length > 0

        If bDepotList Then
            critere = critere & vbCrLf & vbCrLf & "EN DEPOT-VENTE:" & vbCrLf & "Les articles vendus en dépôt-vente donnent droit à un avoir. Cet avoir (sans commission sur le prix de vos articles vendus), est valable 2 ans, sur tous les articles du magasin et du site internet." & vbCrLf & vbCrLf & "Les avoirs sont remboursables,sur demande. Une commission de 30% de la valeur de l'avoir sera retirée lors du remboursement."
        End If


        Dim f As New DialogImpression
        f.pDgview = DGview
        f.pDepot = bDepotList


        If f.ShowDialog = Windows.Forms.DialogResult.OK Then
            settings.HeaderText = "CLI : Listing des articles" & critere & vbCrLf & vbCrLf & "Impression le " & Now()
            settings.PrintRowHeaders = False

            ExportSettings.HeaderText = "CLI : Listing des articles" & critere & vbCrLf & vbCrLf & "Impression le " & Now()
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
                    fmail.I_message.Text = "Madame, Monsieur," & vbCrLf & "Veuillez-trouver ci-joint le listing en pièce jointe" & vbCrLf & vbCrLf & "EN DEPOT-VENTE:" & vbCrLf & "Les articles vendus en dépôt-vente donnent droit à un avoir. Cet avoir (sans commission sur le prix de vos articles vendus), est valable 2 ans, sur tous les articles du magasin et du site internet." & vbCrLf & vbCrLf & "Les avoirs sont remboursables,sur demande. Une commission de 30% de la valeur de l'avoir sera retirée lors du remboursement." & vbCrLf & vbCrLf & "Cordialement," & vbCrLf & "L'équipe www.chinook-leucate.com"

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


    Private Sub CopieDarticlecompletToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CopieDarticlecompletToolStripMenuItem.Click
        Dim vReponse As DialogResult = MessageBox.Show("Etes-vous sûr de vouloir dupliquer cet article dans toutes ses versions ? Attention il faudra modifier les articles après coup pour éviter des doublons", "Attention", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If vReponse = Windows.Forms.DialogResult.Yes Then
            Dim vT_Article_EnteteDataTable As New CLIDataSet.T_Article_EnteteDataTable
            Dim vT_Article_EnteteDataTableNew As New CLIDataSet.T_Article_EnteteDataTable
            Dim vT_Article_EnteteDataTableRow As CLIDataSet.T_Article_EnteteRow
            Dim vT_Article_EnteteTableAdapter As New CLIDataSetTableAdapters.T_Article_EnteteTableAdapter

            Dim vT_Article_DetailDataTable As New CLIDataSet.T_Article_DetailDataTable
            Dim vT_Article_DetailDataTableNew As New CLIDataSet.T_Article_DetailDataTable
            Dim vT_Article_DetailDataTableRow As CLIDataSet.T_Article_DetailRow
            Dim vT_Article_DetailTableAdapter As New CLIDataSetTableAdapters.T_Article_DetailTableAdapter

            Dim vT_Article_versionDataTable As New CLIDataSet.T_Article_versionDataTable
            Dim vT_Article_versionDataTableNew As New CLIDataSet.T_Article_versionDataTable
            Dim vT_Article_versionDataTableRow As CLIDataSet.T_Article_versionRow
            Dim vT_Article_versionTableAdapter As New CLIDataSetTableAdapters.T_Article_versionTableAdapter

            Dim vTempDatatable As DataTable
            Dim vId_t_Article_enteteSource As Integer = 0
            Dim vId_t_Article_enteteSourceNew As Integer = 0
            Dim vId_t_Article_DetailSource As Integer = 0
            Dim vId_t_Article_DetailSourceNew As Integer = 0
            Dim vId_t_Article_versionSourceNew As Integer = 0
            Cursor = Cursors.WaitCursor
            'on recupere la l'entete
            vTempDatatable = ExecuteRequeteR("select t_article_entete.id_t_article_entete from t_article_version,t_article_detail,t_article_entete where t_article_version.id_t_article_detail=t_article_detail.id_t_article_detail and t_article_detail.id_t_article_entete=t_article_entete.id_t_article_entete and id_t_article_version=" & DGview.SelectedRows(0).Cells("Ref").Value, My.Settings.CLIConnectionString)
            If vTempDatatable.Rows.Count >= 1 Then
                vId_t_Article_enteteSource = vTempDatatable.Rows(0)("id_t_article_entete")
                vT_Article_EnteteTableAdapter.FillByIdTArticleEntete(vT_Article_EnteteDataTable, vId_t_Article_enteteSource)
                'on copie (sauf les photos et la clef d'entete)
                vT_Article_EnteteDataTableRow = vT_Article_EnteteDataTableNew.NewT_Article_EnteteRow
                For i As Integer = 0 To vT_Article_EnteteDataTable.Columns.Count - 1
                    If vT_Article_EnteteDataTable.Columns(i).ColumnName.ToUpper <> "ID_T_ARTICLE_ENTETE" And vT_Article_EnteteDataTable.Columns(i).ColumnName.ToUpper <> "MODIFIELE" And vT_Article_EnteteDataTable.Columns(i).ColumnName.ToUpper <> "MODIFIEPAR" And vT_Article_EnteteDataTable.Columns(i).ColumnName.ToUpper <> "CREELE" And vT_Article_EnteteDataTable.Columns(i).ColumnName.ToUpper <> "CREEPAR" And Not vT_Article_EnteteDataTable.Columns(i).ColumnName.ToUpper.StartsWith("PHOTO") Then
                        vT_Article_EnteteDataTableRow(i) = vT_Article_EnteteDataTable.Rows(0)(i)
                    End If
                Next
                vT_Article_EnteteDataTableRow("creepar") = gLogin
                vT_Article_EnteteDataTableRow("creele") = Now()
                vT_Article_EnteteDataTableNew.AddT_Article_EnteteRow(vT_Article_EnteteDataTableRow)
                'mise à jour
                vT_Article_EnteteTableAdapter.Update(vT_Article_EnteteDataTableNew)
                vId_t_Article_enteteSourceNew = vT_Article_EnteteDataTableNew.Rows(0)("id_t_article_entete")

                'recupereation de tous les details d'article
                vT_Article_DetailTableAdapter.FillByIdTArticleEntete(vT_Article_DetailDataTable, vId_t_Article_enteteSource)
                For Each r As DataRow In vT_Article_DetailDataTable.Rows
                    'pour chaque detail on copie la ligne
                    vT_Article_DetailDataTableRow = vT_Article_DetailDataTableNew.NewT_Article_DetailRow
                    For i As Integer = 0 To vT_Article_DetailDataTable.Columns.Count - 1
                        If vT_Article_DetailDataTable.Columns(i).ColumnName.ToUpper <> "ID_T_ARTICLE_DETAIL" And vT_Article_DetailDataTable.Columns(i).ColumnName.ToUpper <> "ID_T_ARTICLE_ENTETE" And vT_Article_DetailDataTable.Columns(i).ColumnName.ToUpper <> "MODIFIELE" And vT_Article_DetailDataTable.Columns(i).ColumnName.ToUpper <> "MODIFIEPAR" And vT_Article_DetailDataTable.Columns(i).ColumnName.ToUpper <> "CREELE" And vT_Article_DetailDataTable.Columns(i).ColumnName.ToUpper <> "CREEPAR" Then
                            vT_Article_DetailDataTableRow(i) = r(i)
                        End If
                    Next
                    vT_Article_DetailDataTableRow("id_t_article_entete") = vId_t_Article_enteteSourceNew
                    vT_Article_DetailDataTableRow("creepar") = gLogin
                    vT_Article_DetailDataTableRow("creele") = Now()
                    vT_Article_DetailDataTableNew.AddT_Article_DetailRow(vT_Article_DetailDataTableRow)
                    'mise à jour
                    vT_Article_DetailTableAdapter.Update(vT_Article_DetailDataTableNew)
                    vId_t_Article_DetailSourceNew = vT_Article_DetailDataTableNew.Rows(0)("id_t_article_detail")
                    'recupereation de toute les version d'article
                    vId_t_Article_DetailSource = r("id_t_article_detail")
                    vT_Article_versionTableAdapter.FillByIdTArticleDetail(vT_Article_versionDataTable, vId_t_Article_DetailSource)
                    For Each r2 As DataRow In vT_Article_versionDataTable.Rows
                        'pour chaque version on copie la ligne
                        vT_Article_versionDataTableRow = vT_Article_versionDataTableNew.NewT_Article_versionRow
                        For i As Integer = 0 To vT_Article_versionDataTable.Columns.Count - 1
                            If vT_Article_versionDataTable.Columns(i).ColumnName.ToUpper <> "ID_T_ARTICLE_VERSION" And vT_Article_versionDataTable.Columns(i).ColumnName.ToUpper <> "ID_T_ARTICLE_DETAIL" And vT_Article_versionDataTable.Columns(i).ColumnName.ToUpper <> "MODIFIELE" And vT_Article_versionDataTable.Columns(i).ColumnName.ToUpper <> "MODIFIEPAR" And vT_Article_versionDataTable.Columns(i).ColumnName.ToUpper <> "CREELE" And vT_Article_versionDataTable.Columns(i).ColumnName.ToUpper <> "CREEPAR" Then
                                vT_Article_versionDataTableRow(i) = r2(i)
                            End If
                        Next
                        vT_Article_versionDataTableRow("id_t_article_detail") = vId_t_Article_DetailSourceNew
                        vT_Article_versionDataTableRow("creepar") = gLogin
                        vT_Article_versionDataTableRow("creele") = Now()
                        vT_Article_versionDataTableNew.AddT_Article_versionRow(vT_Article_versionDataTableRow)
                        'mise à jour
                        vT_Article_versionTableAdapter.Update(vT_Article_versionDataTableNew)
                        vId_t_Article_versionSourceNew = vT_Article_versionDataTableNew.Rows(0)("id_t_article_version")
                        vT_Article_versionDataTableNew.Clear()
                    Next

                    vT_Article_DetailDataTableNew.Clear()
                Next

                MessageBox.Show("copie terminee : ouverture sur la liste des nouveaux articles", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)

                'on ouvre sur un article dupliqué ou la liste
                Recherche(False, True, vId_t_Article_enteteSourceNew)



                'copie terminee
                Cursor = Cursors.Default

            End If

        End If

    End Sub


    Private Sub ActiverToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ActiverToolStripMenuItem.Click
        'magasin_on
        UpdateColumnValue("magasin_on", "1")
    End Sub

    Private Sub DeasctiverToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DeasctiverToolStripMenuItem.Click
        'magasin_on
        UpdateColumnValue("magasin_on", "0")
    End Sub

    Private Sub ActiverToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ActiverToolStripMenuItem1.Click
        'web_on
        UpdateColumnValue("web_on", "1")
    End Sub

    Private Sub DésactiverToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DésactiverToolStripMenuItem.Click
        'web_on
        UpdateColumnValue("web_on", "0")
    End Sub

    Private Sub ActiverToolStripMenuItem2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ActiverToolStripMenuItem2.Click
        'active_on
        UpdateColumnValue("active_on", "1")
    End Sub

    Private Sub DésactiverToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DésactiverToolStripMenuItem1.Click
        'active_on
        UpdateColumnValue("active_on", "0")
    End Sub

    Private Sub ActiverToolStripMenuItem3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ActiverToolStripMenuItem3.Click
        'precommande activer
        UpdateColumnValue("precommande", "1")

    End Sub

    Private Sub DésactiverToolStripMenuItem2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DésactiverToolStripMenuItem2.Click
        'precommande desactiver
        UpdateColumnValue("precommande", "0")
    End Sub

    Private Sub ActiverToolStripMenuItem4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ActiverToolStripMenuItem4.Click
        'reappro
        UpdateColumnValue("reappro", "1")
    End Sub

    Private Sub DésactiverToolStripMenuItem3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DésactiverToolStripMenuItem3.Click
        'reappro
        UpdateColumnValue("reappro", "0")
    End Sub

    Private Sub ActioverToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ActioverToolStripMenuItem.Click
        'stock_limite
        UpdateColumnValue("stock_limite", "1")
    End Sub

    Private Sub DésactiverToolStripMenuItem4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DésactiverToolStripMenuItem4.Click
        'stock_limite
        UpdateColumnValue("stock_limite", "0")
    End Sub

    Private Sub ActiverToolStripMenuItem5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ActiverToolStripMenuItem5.Click
        'surcommande activer
        UpdateColumnValue("surcommande", "1")
    End Sub

    Private Sub DésactiverToolStripMenuItem5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DésactiverToolStripMenuItem5.Click
        'surcommande desactiver
        UpdateColumnValue("surcommande", "0")
    End Sub

    Private Sub AvecPrixToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AvecPrixToolStripMenuItem.Click
        Dim DymoAddIn As New Dymo.DymoAddIn
        Dim DymoLabels As New Dymo.DymoLabels
        Cursor = Cursors.WaitCursor

        Dim reponse As String = InputBox("Combien d'étiquettes souhaitez-vous imprimer ?", "Nombre d'étiquettes à imprimer", 1)

        If IsNumeric(reponse) Then
            If reponse > 0 Then
                For i As Integer = 0 To DGview.SelectedRows.Count - 1

                    DymoAddIn.Open(Application.StartupPath & "\11354CodeBarrePrix.label")
                    If DGview.SelectedRows(i).Cells("DescriptionCourte").Value.ToString.Length >= 30 Then
                        DymoLabels.SetField("DESCRIPTION", DGview.SelectedRows(i).Cells("DescriptionCourte").Value.ToString.Substring(0, 30) & vbCrLf & DGview.SelectedRows(i).Cells("DescriptionCourte").Value.ToString.Substring(30))
                    Else
                        DymoLabels.SetField("DESCRIPTION", DGview.SelectedRows(i).Cells("DescriptionCourte").Value.ToString)
                    End If
                    DymoLabels.SetField("CODE-BARRES", DGview.SelectedRows(i).Cells("Ref").Value)
                    DymoLabels.SetField("PRIX", Math.Round(DGview.SelectedRows(i).Cells("prix_vente_remise_TTC").Value, 2) & " €")
                    If DGview.SelectedRows(i).Cells("prix_vente_remise_TTC").Value <> DGview.SelectedRows(i).Cells("prix_vente_initial_TTC").Value Then
                        DymoLabels.SetField("PrixBarre", Math.Round(DGview.SelectedRows(i).Cells("prix_vente_initial_TTC").Value, 2) & " €")
                        DymoLabels.SetField("Remise", "- " & DGview.SelectedRows(i).Cells("remise").Value * 100 & " %")

                    Else
                        DymoLabels.SetField("PrixBarre", "")
                        DymoLabels.SetField("Remise", "")


                    End If
                    DymoAddIn.SelectPrinter(gNomImprimanteEtiquette)
                    DymoAddIn.Print2(reponse, False, 2)




                Next


            End If
        End If


        Cursor = Cursors.Default



    End Sub

    Private Sub SansPrixToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SansPrixToolStripMenuItem.Click
        Dim DymoAddIn As New Dymo.DymoAddIn
        Dim DymoLabels As New Dymo.DymoLabels
        Cursor = Cursors.WaitCursor


        Dim reponse As String = InputBox("Combien d'étiquettes souhaitez-vous imprimer ?", "Nombre d'étiquettes à imprimer", 1)
        If IsNumeric(reponse) Then
            If reponse > 0 Then
                For i As Integer = 0 To DGview.SelectedRows.Count - 1
                    'crystalReport21.SetParameterValue("Description", DescriptionCodeBarre(T_Article_versionBindingSource.Current.item("description_panier").ToString))
                    'crystalReport21.SetParameterValue("BarCode", BarCodeCodeBarre(T_Article_versionBindingSource.Current.item("id_t_article_version").ToString))
                    'crystalReport21.PrintOptions.PrinterName = gNomImprimanteEtiquette
                    'crystalReport21.PrintToPrinter(reponse, False, 1, 1)
                    DymoAddIn.Open(Application.StartupPath & "\11354CodeBarre.label")
                    If DGview.SelectedRows(i).Cells("DescriptionCourte").Value.ToString.Length >= 30 Then
                        DymoLabels.SetField("DESCRIPTION", DGview.SelectedRows(i).Cells("DescriptionCourte").Value.ToString.Substring(0, 30) & vbCrLf & DGview.SelectedRows(i).Cells("DescriptionCourte").Value.ToString.Substring(30))
                    Else
                        DymoLabels.SetField("DESCRIPTION", DGview.SelectedRows(i).Cells("DescriptionCourte").Value.ToString)
                    End If
                    DymoLabels.SetField("CODE-BARRES", DGview.SelectedRows(i).Cells("Ref").Value)

                    DymoAddIn.SelectPrinter(gNomImprimanteEtiquette)
                    DymoAddIn.Print2(reponse, False, 2)
                  
                Next
            End If
        End If



   
        Recherche(False, False)
        Cursor = Cursors.Default
    End Sub

    Private Sub CodeBarreToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CodeBarreToolStripMenuItem.Click

    End Sub
    Private Sub I_Programme_DropDown(ByVal sender As Object, ByVal e As System.EventArgs) Handles I_Programme.DropDown
        If I_SousFamille.Text <> "" Then
            I_Programme.DataSource = Nothing
            Dim cnn As New SqlClient.SqlConnection(My.Settings.CLIConnectionString)
            cnn.Open()
            Dim bs As New BindingSource
            Dim command As New SqlClient.SqlCommand

            command.CommandText = "select distinct [programme] from v_recherche_article  where [Sous Famille]='" & Replace(I_SousFamille.Text, "'", "''") & "' Union select null as [programme] order by [programme]"



            command.Connection = cnn
            Dim reader As SqlClient.SqlDataReader = command.ExecuteReader
            bs.DataSource = reader

            I_Programme.DataSource = bs
            I_Programme.DisplayMember = "programme"
            cnn.Close()
        End If
    End Sub
    Private Sub I_Type_DropDown(ByVal sender As Object, ByVal e As System.EventArgs) Handles I_Type.DropDown
        If I_SousFamille.Text <> "" Then
            I_Type.DataSource = Nothing
            Dim cnn As New SqlClient.SqlConnection(My.Settings.CLIConnectionString)
            cnn.Open()
            Dim bs As New BindingSource
            Dim command As New SqlClient.SqlCommand

            command.CommandText = "select distinct [type] from v_recherche_article  where [Sous Famille]='" & Replace(I_SousFamille.Text, "'", "''") & "' Union select null as [Type] order by [Type]"



            command.Connection = cnn
            Dim reader As SqlClient.SqlDataReader = command.ExecuteReader
            bs.DataSource = reader

            I_Type.DataSource = bs
            I_Type.DisplayMember = "Type"
            cnn.Close()
        End If
    End Sub
    Private Sub I_Type2_DropDown(ByVal sender As Object, ByVal e As System.EventArgs) Handles I_Type2.DropDown
        If I_SousFamille.Text <> "" Then
            I_Type2.DataSource = Nothing
            Dim cnn As New SqlClient.SqlConnection(My.Settings.CLIConnectionString)
            cnn.Open()
            Dim bs As New BindingSource
            Dim command As New SqlClient.SqlCommand

            command.CommandText = "select distinct [type2] from v_recherche_article  where [Sous Famille]='" & Replace(I_SousFamille.Text, "'", "''") & "' Union select null as [Type2] order by [Type2]"



            command.Connection = cnn
            Dim reader As SqlClient.SqlDataReader = command.ExecuteReader
            bs.DataSource = reader

            I_Type2.DataSource = bs
            I_Type2.DisplayMember = "Type2"
            cnn.Close()
        End If
    End Sub
    Private Sub I_Type3_DropDown(ByVal sender As Object, ByVal e As System.EventArgs) Handles I_Type3.DropDown
        If I_SousFamille.Text <> "" Then
            I_Type3.DataSource = Nothing
            Dim cnn As New SqlClient.SqlConnection(My.Settings.CLIConnectionString)
            cnn.Open()
            Dim bs As New BindingSource
            Dim command As New SqlClient.SqlCommand

            command.CommandText = "select distinct [type3] from v_recherche_article  where [Sous Famille]='" & Replace(I_SousFamille.Text, "'", "''") & "' Union select null as [Type3] order by [Type3]"



            command.Connection = cnn
            Dim reader As SqlClient.SqlDataReader = command.ExecuteReader
            bs.DataSource = reader

            I_Type3.DataSource = bs
            I_Type3.DisplayMember = "Type3"
            cnn.Close()
        End If
    End Sub
    Private Sub I_Type4_DropDown(ByVal sender As Object, ByVal e As System.EventArgs) Handles I_Type4.DropDown
        If I_SousFamille.Text <> "" Then
            I_Type4.DataSource = Nothing
            Dim cnn As New SqlClient.SqlConnection(My.Settings.CLIConnectionString)
            cnn.Open()
            Dim bs As New BindingSource
            Dim command As New SqlClient.SqlCommand

            command.CommandText = "select distinct [type4] from v_recherche_article  where [Sous Famille]='" & Replace(I_SousFamille.Text, "'", "''") & "' Union select null as [Type4] order by [Type4]"
            command.Connection = cnn
            Dim reader As SqlClient.SqlDataReader = command.ExecuteReader
            bs.DataSource = reader

            I_Type4.DataSource = bs
            I_Type4.DisplayMember = "Type4"
            cnn.Close()
        End If
    End Sub


    Private Sub CréationRepriseToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CréationRepriseToolStripMenuItem.Click



        Dim index As Integer = DGview.SelectedRows(0).Index
        OuvertureFicheArticle(index)
        FormArticle2.NewRepriseOccaz("reprise", sender, e)


    End Sub

    Private Sub CréationDépotVenteToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CréationDépotVenteToolStripMenuItem.Click
        Dim index As Integer = DGview.SelectedRows(0).Index
        OuvertureFicheArticle(index)
        FormArticle2.NewRepriseOccaz("depot", sender, e)
    End Sub
    Private Sub UpdateColumnValue(columnName As String, value As String)
        Cursor = Cursors.WaitCursor
        Dim ids As New List(Of Long)
        For i As Integer = 0 To DGview.SelectedRows.Count - 1
            ExecuteRequeteR("update t_article_version set " & columnName & "=" & value & ", modifiele=getdate(), modifiepar='" & Replace(gLogin, "'", "''") & "'  where id_t_article_version=" & DGview.SelectedRows(i).Cells("Ref").Value, My.Settings.CLIConnectionString)
            ' récupération de id_t_article_entete correspondant à id_t_article_version depuis v_recherche_article
            Dim vTempDatatable As DataTable = ExecuteRequeteR("select id_t_article_entete from v_recherche_article where ref=" & DGview.SelectedRows(i).Cells("Ref").Value, My.Settings.CLIConnectionString)
            'ajout de id_t_article_entete s'il n'existe pas deja dans ids
            If Not ids.Contains(vTempDatatable.Rows(0)("id_t_article_entete")) Then
                ids.Add(vTempDatatable.Rows(0)("id_t_article_entete"))
            End If
        Next
        CliApi.ProductAddOrUpdateMultiplePSfromCLIByIdsAsync(New ToCliDto() With {.Ids = ids})
        Recherche(False, False)
        Cursor = Cursors.Default
    End Sub

End Class