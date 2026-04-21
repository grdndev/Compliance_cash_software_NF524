Imports System.Data.SqlClient
Imports System.Drawing
Imports System.Drawing.Imaging
Imports Microsoft.Reporting.WinForms
Imports CompletIT.Windows.Forms.Export.Pdf
Imports System.Windows.Forms.VisualStyles.VisualStyleElement
Imports System.Web.UI.WebControls
Imports System.Xml


Public Class FormClient
#Region "Variables form"
    'Déclaration des variables du formulaire
    Public id_t_client As Integer = 0
    Dim bs As New BindingSource
    Dim bs2 As New BindingSource
    Dim bs3 As New BindingSource
    Dim bs4 As New BindingSource
    Dim bs5 As New BindingSource
    Private CopieFiche As CLIDataSet.T_ClientRow = Nothing
#End Region
#Region "Formulaire"
    'Fonctions de gestion des évènements du formulaire
    Private Sub FormFournisseur_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'CLIDataSet.V_reglement' table. You can move, or remove it, as needed.
        AddHandler MaskedTextBoxDateNaissance.DataBindings("text").Parse, AddressOf ValeurNulleMaskedTextboxDate

        NouveauToolStripButton.Enabled = gVente_w
        SupprimerToolStripButton.Enabled = gVente_w
        Me.T_PaysTableAdapter.Fill(Me.CLIDataSet.T_Pays)
        Dim vSourceVilleCP As DataTable

        BT_Enregistrer.Enabled = gVente_w
        Dim vVilleCP As New AutoCompleteStringCollection
        Dim vCPVille As New AutoCompleteStringCollection
        vSourceVilleCP = ExecuteRequeteR("select codepostal,ville from t_cpvillefr", My.Settings.CLIConnectionString)

        For Each r As DataRow In vSourceVilleCP.Rows
            vVilleCP.Add(r("ville") & " (" & r("codepostal") & ")")
            vCPVille.Add(r("codepostal") & " (" & r("ville") & ")")
        Next

        VilleTextBox.AutoCompleteCustomSource = vVilleCP
        CodePostalTextBox.AutoCompleteCustomSource = vCPVille

        If id_t_client = 0 Then
            ToolStrip2.Visible = False
        Else
            ToolStrip2.Visible = True
        End If

        TabControl1.SelectTab("TabPageGeneral")


        TitreComboBox.DisplayMember = "Text"
        TitreComboBox.ValueMember = "Value"
        Dim tb As New DataTable
        tb.Columns.Add("Text", GetType(String))
        tb.Columns.Add("Value", GetType(Integer))
        tb.Rows.Add("", 0)
        tb.Rows.Add("M", 1)
        tb.Rows.Add("Mme", 2)

        TitreComboBox.DataSource = tb

        Refresh_data()
    End Sub
#End Region
#Region "Boutons"
    Private Sub BT_Enregistrer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BT_Enregistrer.Click
        'on test les champs obligatoires généraux
        'check des champs prestashop si besoin
        Dim err_msg As String = ""
        If NomTextBox.Text.Trim = "" Then
            err_msg = err_msg & vbCrLf & "- Nom"
        End If
        If VilleTextBox.Text.Trim = "" Then
            err_msg = err_msg & vbCrLf & "- Ville"
        End If

        If PaysComboBox.Text.Trim = "" Then
            err_msg = err_msg & vbCrLf & "- Pays"
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
            If id_t_client = 0 Then
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

        FormClientRecherche.bs.MoveNext()
        id_t_client = FormClientRecherche.bs.Current.Item("ref")
        Refresh_data()


    End Sub

    Private Sub ToolStripButton1_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButtonMovePrevious.Click

        FormClientRecherche.bs.MovePrevious()
        id_t_client = FormClientRecherche.bs.Current.Item("ref")
        Refresh_data()

    End Sub

    Private Sub ToolStripButton3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButtonMoveLast.Click

        FormClientRecherche.bs.MoveLast()
        id_t_client = FormClientRecherche.bs.Current.Item("ref")
        Refresh_data()

    End Sub

    Private Sub ToolStripButton4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButtonMovefirst.Click

        FormClientRecherche.bs.MoveFirst()
        id_t_client = FormClientRecherche.bs.Current.Item("ref")
        Refresh_data()

    End Sub

    Private Sub NouveauToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NouveauToolStripButton.Click
        NouveauGene()
    End Sub
    Private Sub SupprimerToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SupprimerToolStripButton.Click
        'vérification que le fournisseur ne possède pas d'article lié
        If bs.Count > 0 Or bs2.Count > 0 Or bs3.Count > 0 Then
            MessageBox.Show("Non conseillé. Vous ne pouvez pas supprimer un client qui possède des commandes, des avoirs ou des fiches dépôt-vente" & vbCrLf & "Faires les changements nécessaires avant suppression", "Attention !", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        Else

            Dim reponse As DialogResult = MessageBox.Show("Souhaitez vous vraiment supprimer ce client ?", "Attention", MessageBoxButtons.OKCancel, MessageBoxIcon.Question)
            If reponse = Windows.Forms.DialogResult.OK Then
                Dim idCustomerPrestashop As String = T_ClientBindingSource.Current.Item("IdCustomerPrestashop").ToString()
                T_ClientBindingSource.Remove(T_ClientBindingSource.Current)
                Enregistrer()
                'Suppression du client dans prestashop
                If ToSyncCheckBox.Checked And IsNumeric(idCustomerPrestashop) Then
                    Dim cliDto As New ToCliDto
                    cliDto.Id = CLng(idCustomerPrestashop)
                    CliApi.CustomerDeletePSByIdAsync(cliDto)
                End If
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
        Dim courant As CLIDataSet.T_ClientRow = Me.CLIDataSet.T_Client(T_ClientBindingSource.Position)
        CopieFiche = Me.CLIDataSet.T_Client.NewT_ClientRow

        For Each col In courant.Table.Columns
            If UCase(col.ColumnName) <> "ID_T_CLIENT" And UCase(col.ColumnName) <> "CREELE" And UCase(col.ColumnName) <> "MODIFIELE" And UCase(col.ColumnName) <> "MODIFIEPAR" And UCase(col.ColumnName) <> "CREEPAR" Then

                CopieFiche.Item(col.ColumnName) = courant.Item(col.ColumnName)
            End If
        Next
        CollerToolStripButton.Enabled = True
    End Sub

    Private Sub CollerToolStripButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles CollerToolStripButton.Click
        Dim col As DataColumn
        Dim courant As CLIDataSet.T_ClientRow = Me.CLIDataSet.T_Client(0)
        For Each col In courant.Table.Columns
            If UCase(col.ColumnName) <> "ID_T_CLIENT" Then
                Me.CLIDataSet.T_Client(Me.CLIDataSet.T_Client.Rows.Count - 1).Item(col.ColumnName) = CopieFiche.Item(col.ColumnName)
            End If
        Next
    End Sub
#End Region
#Region "DGview"
    Private Sub DGVIEW_CellFormatting(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellFormattingEventArgs) Handles DGview.CellFormatting
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
        If Not FormClientRecherche.bs.Current Is Nothing Then

            If FormClientRecherche.bs.Find("ref", id_t_client) = -1 Then
                FormClientRecherche.bs.MoveFirst()
                id_t_client = FormClientRecherche.bs.Current.item("ref")
                Refresh_data()
            End If
            ToolStripLabelPosition.Text = String.Format("{0}/{1}", FormClientRecherche.bs.Find("ref", id_t_client) + 1, FormClientRecherche.bs.Count)

            If FormClientRecherche.bs.Position = FormClientRecherche.bs.Count - 1 Then
                ToolStripButtonMoveNext.Enabled = False
                ToolStripButtonMoveLast.Enabled = False
            Else
                ToolStripButtonMoveNext.Enabled = True
                ToolStripButtonMoveLast.Enabled = True
            End If
            If FormClientRecherche.bs.Position = 0 Then
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
        If FormClientRecherche.Visible Then
            FormClientRecherche.Recherche(False, False)
            FormClientRecherche.bs.Position = FormClientRecherche.bs.Find("ref", id_t_client)

        End If
    End Sub

    Private Sub Enregistrer()
        Cursor = Cursors.WaitCursor

        Try

            Me.Validate()


            If Not Me.T_ClientBindingSource.Current Is Nothing Then
                Me.T_ClientBindingSource.Current.item("ModifieLe") = Date.Now
                Me.T_ClientBindingSource.Current.item("ModifiePar") = gLogin
            End If

            Me.T_ClientBindingSource.EndEdit()

            Me.T_ClientTableAdapter.Update(Me.CLIDataSet.T_Client)
            If Not Me.T_ClientBindingSource.Current Is Nothing Then
                id_t_client = T_ClientBindingSource.Current.item("id_t_client")
            Else
                id_t_client = 0
            End If
            'syncronisation Prestashop
            If ToSyncCheckBox.Checked Then

                CliApi.CustomerAddOrUpdatePSfromCLIByIdAsync(New ToCliDto() With {.Id = id_t_client, .AssociatedAddress = False, .AssociatedCartRule = False})
            End If


            Me.T_ClientTableAdapter.FillByid_t_client(Me.CLIDataSet.T_Client, id_t_client)


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
        PasswordTextBox.ReadOnly = False
        I_EtatSynchroPrestashop.Text = ""
        I_ErrorDetail.Text = ""

        If id_t_client > 0 Then
            Me.T_ClientTableAdapter.FillByid_t_client(Me.CLIDataSet.T_Client, id_t_client)
            RefreshArticles(id_t_client)
            RefreshCommandes(id_t_client)
            RefreshAvoir(id_t_client)
            RefreshChequeCadeau(id_t_client)
            RefreshEcheance(id_t_client)
            RefreshAdresses(id_t_client)
            PasswordTextBox.ReadOnly = Me.CLIDataSet.T_Client.Rows(0)("IdCustomerPrestashop").ToString <> ""
            'Récupération de l'état de synchro prestashop
            Dim vEtatSynchroDt As DataTable = ExecuteRequeteR("select LogType,Logdetail from V_Log where LogAssociatedRecordId=" & Me.CLIDataSet.T_Client.Rows(0).Item("ID_T_Client").ToString & " and LogAssociatedRecordType='t_client' ", gCnn.ConnectionString)
            Dim vEtatSynchro As String = "Non"
            Dim vLogDetail As String = ""
            BT_DetailSynchro.Enabled = False
            If vEtatSynchroDt.Rows.Count > 0 Then
                vEtatSynchro = vEtatSynchroDt.Rows(0)("LogType")
                vLogDetail = vEtatSynchroDt.Rows(0)("Logdetail")
                BT_DetailSynchro.Enabled = True
            End If
            I_EtatSynchroPrestashop.Text = vEtatSynchro


            'Récupération de l'erreur de syncronisation
            If vEtatSynchro = "Erreur" Then
                Dim vErreurSynchroDt As DataTable = ExecuteRequeteR("select errors from V_Log where LogAssociatedRecordId=" & Me.CLIDataSet.T_Client.Rows(0).Item("ID_T_Client").ToString & " and LogAssociatedRecordType='t_client' and LogType='Erreur' ", gCnn.ConnectionString)
                If vErreurSynchroDt.Rows.Count > 0 Then
                    Try
                        Dim doc As New XmlDocument()
                        doc.LoadXml(vErreurSynchroDt.Rows(0)("Errors"))

                        ' Initialize a StringBuilder to hold error messages
                        Dim sb As New System.Text.StringBuilder()

                        ' Extract data from XML
                        For Each errorNode As XmlNode In doc.SelectNodes("//error")
                            Dim errorCode As String = errorNode.SelectSingleNode("code").InnerText
                            Dim errorMessage As String = errorNode.SelectSingleNode("message").InnerText

                            ' Append error message to StringBuilder with newline
                            sb.AppendLine($"Code: {errorCode}, Message: {errorMessage}")
                        Next
                        I_ErrorDetail.Text = sb.ToString
                    Catch ex As Exception
                        I_ErrorDetail.Text = ""
                    End Try

                Else
                    I_ErrorDetail.Text = ""
                End If
                'recuperation du detail de l'erreur
                If I_ErrorDetail.Text = "" Then
                    I_ErrorDetail.Text = vLogDetail
                End If

            End If
        Else
                NouveauGene()
            End If
            MajPosition()
            'refraichissement du nombre d'enregistrements utilisant celui ci

            Cursor = Cursors.Default
    End Sub
    Private Sub NouveauGene()

        'clear de la table client
        CLIDataSet.T_Client.Clear()
        T_ClientBindingSource.AddNew()
        T_ClientBindingSource.EndEdit()


        RefreshArticles(0)
        DGVIEW_avoir.DataSource = Nothing
        DGview.DataSource = Nothing

        DGview_Commandes.DataSource = Nothing




        PaysComboBox.SelectedIndex = -1

        NouveauToolStripButton.Enabled = False


        SupprimerToolStripButton.Enabled = False

        ToolStripButtonMovefirst.Enabled = False
        ToolStripButtonMovePrevious.Enabled = False
        ToolStripButtonMoveNext.Enabled = False
        ToolStripButtonMoveLast.Enabled = False
        PasswordTextBox.ReadOnly = False

    End Sub
    Private Sub RefreshAdresses(ByVal id_t_client As Integer)
        Cursor = Cursors.WaitCursor

        Dim cnn As New SqlClient.SqlConnection(My.Settings.CLIConnectionString)
        cnn.Open()
        Dim strsql_recherche As String

        strsql_recherche = "select id_t_adresse,id_t_client,Libelle,Société,Nom,Prenom,AdresseL1,AdresseL2,AdresseL3,CodePostal,Ville,Pays,Tel,Mobile,NoTva,NumeroIdentite,Autre,IdAddressPrestashop,CreeLe,CreePar,ModifieLe,ModifiePar from T_adresse where id_t_client=" & id_t_client

        Dim oSqlDataAdapter As New Data.SqlClient.SqlDataAdapter(strsql_recherche, cnn)
        Dim oDataSet As New DataSet("RechercheDataset")

        oSqlDataAdapter.Fill(oDataSet, "Recherche")

        bs5.DataSource = oDataSet.Tables("Recherche")

        AdressesDGView.DataSource = bs5
        'ToolStripStatusLabelNbEnregistrementsArticles.Text = System.String.Format("{0} enregistrement(s) sélectionné(s)", oDataSet.Tables("Recherche").Rows.Count.ToString)

        cnn.Close()

        Cursor = Cursors.Default

    End Sub
    Private Sub RefreshArticles(ByVal id_t_client As Integer)
        Cursor = Cursors.WaitCursor

        Dim cnn As New SqlClient.SqlConnection(My.Settings.CLIConnectionString)
        cnn.Open()
        Dim strsql_recherche As String

        strsql_recherche = "select active_on,ref,[description courte],prix_vente_initial_TTC,remise,prix_vente_remise_TTC,web_on,magasin_on,stock from v_recherche_article where depot_vente=1 and  id_t_client=" & id_t_client

        Dim oSqlDataAdapter As New Data.SqlClient.SqlDataAdapter(strsql_recherche, cnn)
        Dim oDataSet As New DataSet("RechercheDataset")

        oSqlDataAdapter.Fill(oDataSet, "Recherche")

        bs.DataSource = oDataSet.Tables("Recherche")

        DGview.DataSource = bs
        ToolStripStatusLabelNbEnregistrementsArticles.Text = System.String.Format("{0} enregistrement(s) sélectionné(s)", oDataSet.Tables("Recherche").Rows.Count.ToString)

        cnn.Close()

        Cursor = Cursors.Default

    End Sub
    Private Sub RefreshCommandes(ByVal id_t_client As Integer)
        Cursor = Cursors.WaitCursor

        Dim cnn As New SqlClient.SqlConnection(My.Settings.CLIConnectionString)
        cnn.Open()
        Dim strsql_recherche As String

        strsql_recherche = "select * from v_recherche_commande_vente where  [Ref client]=" & id_t_client

        Dim oSqlDataAdapter As New Data.SqlClient.SqlDataAdapter(strsql_recherche, cnn)
        Dim oDataSet As New DataSet("RechercheDataset")

        oSqlDataAdapter.Fill(oDataSet, "Recherche")

        bs2.DataSource = oDataSet.Tables("Recherche")

        DGview_Commandes.DataSource = bs2
        ToolStripStatusLabelNbEnregistrementsCommandes.Text = System.String.Format("{0} enregistrement(s) sélectionné(s)", oDataSet.Tables("Recherche").Rows.Count.ToString)

        cnn.Close()

        Cursor = Cursors.Default

    End Sub
    Private Sub RefreshAvoir(ByVal id_t_client As Integer)
        Cursor = Cursors.WaitCursor

        Dim cnn As New SqlClient.SqlConnection(My.Settings.CLIConnectionString)
        cnn.Open()
        Dim strsql_recherche As String

        strsql_recherche = "select ID_T_Avoir,ID_T_CommandeVente,Montant,Commentaire,AvoirCreePar,AvoirCreeLe,UtiliseLe from v_avoir_client where  id_t_client=" & id_t_client

        Dim oSqlDataAdapter As New Data.SqlClient.SqlDataAdapter(strsql_recherche, cnn)
        Dim oDataSet As New DataSet("RechercheDataset")

        oSqlDataAdapter.Fill(oDataSet, "Recherche")

        bs3.DataSource = oDataSet.Tables("Recherche")

        DGVIEW_avoir.DataSource = bs3
        ToolStripStatusLabelNbEnregistrementAvoir.Text = System.String.Format("{0} enregistrement(s) sélectionné(s)", oDataSet.Tables("Recherche").Rows.Count.ToString)

        cnn.Close()

        Cursor = Cursors.Default

    End Sub
    Private Sub RefreshChequeCadeau(ByVal id_t_client As Integer)
        Cursor = Cursors.WaitCursor

        Dim cnn As New SqlClient.SqlConnection(My.Settings.CLIConnectionString)
        cnn.Open()
        Dim strsql_recherche As String

        strsql_recherche = "select ID_T_Avoir,ID_T_CommandeVente,Montant,Commentaire,AvoirCreePar,AvoirCreeLe,UtiliseLe from v_chequecadeau_client where  id_t_client=" & id_t_client

        Dim oSqlDataAdapter As New Data.SqlClient.SqlDataAdapter(strsql_recherche, cnn)
        Dim oDataSet As New DataSet("RechercheDataset")

        oSqlDataAdapter.Fill(oDataSet, "Recherche")

        bs4.DataSource = oDataSet.Tables("Recherche")

        DGVIEW_ChequeCadeau.DataSource = bs4
        ToolStripStatusLabelNbEnregistrementChequeCadeau.Text = System.String.Format("{0} enregistrement(s) sélectionné(s)", oDataSet.Tables("Recherche").Rows.Count.ToString)

        cnn.Close()

        Cursor = Cursors.Default

    End Sub


    Private Sub RefreshEcheance(ByVal id_t_client As Integer)
        Cursor = Cursors.WaitCursor

        Me.V_reglementTableAdapter.FillBy_id_t_client(Me.CLIDataSet.V_reglement, id_t_client)


        ToolStripStatusLabelNbEnregistrementAvoir.Text = System.String.Format("{0} enregistrement(s) sélectionné(s)", Me.CLIDataSet.V_reglement.Rows.Count.ToString)



        Cursor = Cursors.Default

    End Sub

    Private Sub DGview_Commandes_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGview_Commandes.CellDoubleClick

    End Sub


    Private Sub DGVIEW_Commandes_CellFormatting(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellFormattingEventArgs) Handles DGview_Commandes.CellFormatting
        If DGview_Commandes.Rows(e.RowIndex).Cells("Codeetat").Value.ToString <> "" Then
            Select Case DGview_Commandes.Rows(e.RowIndex).Cells("Codeetat").Value
                Case 90 : e.CellStyle.BackColor = Color.Gray
                Case 40 : e.CellStyle.BackColor = Color.DarkGreen
                    e.CellStyle.ForeColor = Color.White
                Case 30 : e.CellStyle.BackColor = Color.LimeGreen
                Case 20, 25 : e.CellStyle.BackColor = Color.LightGreen
                Case 10, 15 : e.CellStyle.BackColor = Color.White
            End Select

        Else
            e.CellStyle.BackColor = Color.Gray
        End If
    End Sub

    Private Sub DGVIEW_avoir_CellFormatting(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellFormattingEventArgs) Handles DGVIEW_avoir.CellFormatting
        If e.RowIndex > -1 Then
            If DGVIEW_avoir.Rows(e.RowIndex).Cells("utiliseLe").Value.ToString <> "" Then
                e.CellStyle.BackColor = Color.Gray
            End If

        End If

    End Sub

    Private Sub DGVIEW_chequecadeau_CellFormatting(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellFormattingEventArgs) Handles DGVIEW_ChequeCadeau.CellFormatting
        If e.RowIndex > -1 Then
            If DGVIEW_ChequeCadeau.Rows(e.RowIndex).Cells("ChequeCadeauutiliseLe").Value.ToString <> "" Then
                e.CellStyle.BackColor = Color.Gray
            End If

        End If

    End Sub


#End Region




    Private Sub DGview_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGview.CellContentClick

    End Sub

    Private Sub DGview_Commandes_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGview_Commandes.CellContentClick

    End Sub

    Private Sub DGview_Commandes_CellMouseDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles DGview_Commandes.CellMouseDoubleClick
        If Not e.RowIndex = -1 And e.Button = Windows.Forms.MouseButtons.Left Then
            FormCommandeRecherche.MdiParent = FormPrincipale

            FormCommandeRecherche.Show()
            FormCommandeRecherche.WindowState = FormWindowState.Normal
            Me.BringToFront()
            FormCommandeRecherche.I_Reference.Text = DGview_Commandes.Rows(e.RowIndex).Cells("RefCommande").Value.ToString
            FormCommandeRecherche.Recherche(False, True)
        End If
    End Sub

    Private Sub DGview_Avoir_CellMouseDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles DGVIEW_avoir.CellMouseDoubleClick
        If Not e.RowIndex = -1 And e.Button = Windows.Forms.MouseButtons.Left Then
            FormCommandeRecherche.MdiParent = FormPrincipale

            FormCommandeRecherche.Show()
            FormCommandeRecherche.WindowState = FormWindowState.Normal
            Me.BringToFront()
            FormCommandeRecherche.I_Reference.Text = DGVIEW_avoir.Rows(e.RowIndex).Cells("RefCommandeVente").Value.ToString
            FormCommandeRecherche.Recherche(False, True)
        End If
    End Sub

    Private Sub BT_Impression_Avoir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BT_Impression_Avoir.Click, BT_Email_Avoir.Click
        Dim critere As String = ""
        Dim settings As New CompletIT.Windows.Forms.Printing.DGVEPrintSettings
        Dim PdfExporter As DGVEPdfExporter = New DGVEPdfExporter()
        Dim ExportSettings As DGVEPdfExportSettings = New DGVEPdfExportSettings()
        settings.PrintHeaderText = True
        If ID_T_ClientTextBox.Text <> "" Then
            critere = critere & vbCrLf & "Reference : " & ID_T_ClientTextBox.Text
        End If
        If SociétéTextBox.Text <> "" Then
            critere = critere & vbCrLf & "Société : " & SociétéTextBox.Text
        End If
        If NomTextBox.Text <> "" Then
            critere = critere & vbCrLf & "Nom : " & NomTextBox.Text
        End If
        If PrenomTextBox.Text <> "" Then
            critere = critere & vbCrLf & "Prénom : " & PrenomTextBox.Text
        End If


        Dim f As New DialogImpression
        f.pDgview = DGVIEW_avoir

        If f.ShowDialog = Windows.Forms.DialogResult.OK Then
            settings.HeaderText = "CLI : Listing des avoirs" & critere & vbCrLf & vbCrLf & "Impression le " & Now()
            settings.PrintRowHeaders = False
            ExportSettings.HeaderText = "CLI : Listing des avoirs" & critere & vbCrLf & vbCrLf & "Impression le " & Now()
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
                    DGVIEW_avoir.Columns(r.Cells(2).Value).visible = False

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
                Case "BT_Impression_Avoir"
                    CompletIT.Windows.Forms.Printing.DGVEPrintManager.PrintPreview(DGVIEW_avoir, settings)
                Case "BT_Email_Avoir"
                    PdfExporter.Export(DGVIEW_avoir, ExportSettings)
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
                    DGVIEW_avoir.Columns(r.Cells(2).Value).visible = True

                End If
            Next
        End If

    End Sub

    Private Sub BT_Creer_Avoir_Global_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BT_Creer_Avoir_Global.Click
        Dim vMontantTotal As Double = 0
        Dim vListeRefAvoir As String = ""

        Dim cnn As New SqlClient.SqlConnection(My.Settings.CLIConnectionString)
        Dim cnn2 As New SqlClient.SqlConnection(My.Settings.CLIConnectionString)

        cnn.Open()
        Dim command As New SqlClient.SqlCommand
        Dim command2 As New SqlClient.SqlCommand
        'listing des avoirs du client
        command.CommandText = "select id_t_avoir,montant as Montant from t_avoir where  chequecadeau=0 and utilisele is null and  id_t_client=" & id_t_client

        command.Connection = cnn
        Dim reader As SqlClient.SqlDataReader = command.ExecuteReader
        ' comptage des avoirs

        Do While reader.Read()
            vMontantTotal = vMontantTotal + reader("montant")
            If vListeRefAvoir = "" Then
                vListeRefAvoir = reader("id_t_avoir")
            Else
                vListeRefAvoir = vListeRefAvoir & ", " & reader("id_t_avoir")
            End If

        Loop
        reader.Close()
        If vListeRefAvoir <> "" And vMontantTotal > 0 Then
            'désactivation de l'avoir

            cnn2.Open()


            command2.CommandText = "update t_avoir set utilisele='" & Now() & "' where id_t_avoir in (" & vListeRefAvoir & ")"

            command2.Connection = cnn2
            command2.ExecuteNonQuery()
            cnn2.Close()

            'insertion du nouvel avoir
            cnn2.Open()
            command2.Connection = cnn2
            command2.CommandText = "INSERT INTO [T_Avoir]( [ID_T_Client],ID_T_CommandeVente, [Montant], [Commentaire], [CreePar], [CreeLe]) VALUES('" & id_t_client & "',0, '" & vMontantTotal.ToString.Replace(",", ".") & "','Avoir global (comprenant les avoirs " & vListeRefAvoir & ")', '" & gLogin & "', '" & Now() & "')"
            command2.ExecuteNonQuery()
            cnn2.Close()
            MessageBox.Show("Creation d'un avoir global terminée", "Traitement ok", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Else
            MessageBox.Show("Impossible de creer un avoir global", "attention", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If


        cnn.Close()
        RefreshAvoir(id_t_client)
        Enregistrer()
        'syncronisation Prestashop
        If ToSyncCheckBox.Checked Then

            CliApi.CustomerAddOrUpdatePSfromCLIByIdAsync(New ToCliDto() With {.Id = id_t_client, .AssociatedAddress = False, .AssociatedCartRule = True})
        End If

    End Sub

    Private Sub V_reglementDataGridView_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles V_reglementDataGridView.CellContentClick

    End Sub

    Private Sub V_reglementDataGridView_CellFormatting(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellFormattingEventArgs) Handles V_reglementDataGridView.CellFormatting
        If V_reglementDataGridView.Rows(e.RowIndex).Cells("Encaisse_le").Value.ToString <> "" Then
            e.CellStyle.BackColor = Color.Gray
        End If
    End Sub

    Private Sub V_reglementDataGridView_CellMouseDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles V_reglementDataGridView.CellMouseDoubleClick
        If Not e.RowIndex = -1 And e.Button = Windows.Forms.MouseButtons.Left Then
            FormCommandeRecherche.MdiParent = FormPrincipale

            FormCommandeRecherche.Show()
            FormCommandeRecherche.WindowState = FormWindowState.Normal
            Me.BringToFront()
            FormCommandeRecherche.I_Reference.Text = V_reglementDataGridView.Rows(e.RowIndex).Cells("RefCommandeEcheance").Value.ToString
            FormCommandeRecherche.Recherche(False, True)
        End If

    End Sub

    Private Sub BT_Impression_Article_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BT_Impression_Article.Click, BT_Email_Article.Click
        Dim critere As String = ""
        Dim settings As New CompletIT.Windows.Forms.Printing.DGVEPrintSettings
        Dim PdfExporter As DGVEPdfExporter = New DGVEPdfExporter()
        Dim ExportSettings As DGVEPdfExportSettings = New DGVEPdfExportSettings()

        settings.PrintHeaderText = True
        If ID_T_ClientTextBox.Text <> "" Then
            critere = critere & vbCrLf & "Reference : " & ID_T_ClientTextBox.Text
        End If
        If SociétéTextBox.Text <> "" Then
            critere = critere & vbCrLf & "Société : " & SociétéTextBox.Text
        End If
        If NomTextBox.Text <> "" Then
            critere = critere & vbCrLf & "Nom : " & NomTextBox.Text
        End If
        If PrenomTextBox.Text <> "" Then
            critere = critere & vbCrLf & "Prénom : " & PrenomTextBox.Text
        End If

        'critere = critere & vbCrLf & vbCrLf & "EN DEPOT-VENTE:" & vbCrLf & "Les articles vendus en dépôt-vente donnent droit à un avoir. Cet avoir (sans commission sur le prix de vos articles vendus), est valable 2 ans, sur tous les articles du magasin et du site internet." & vbCrLf & vbCrLf & "Les avoirs sont remboursables,sur demande. Une commission de 30% de la valeur de l'avoir sera retirée lors du remboursement."
        critere = critere & vbCrLf & vbCrLf & $"Madame, Monsieur,
Veuillez-trouver le listing de votre dépôt-vente, en pièce jointe.
 
Notre équipe se mobilise et Chinook-Leucate vous propose son service de dépôt-vente pour votre matériel. Dès qu 'il est vendu, chaque article se transforme en avoir sur votre compte client Chinook Leucate. 
Cet avoir est valable au magasin directement, mais aussi sur le site Web, en vous connectant à votre espace client. 
 
Votre avoir est valable 2 ans et vous pouvez l' utiliser, en 1 ou plusieurs fois, et de différentes façons:
 
1/Pour un achat, il est utilisable sur tous les articles du magasin et du site internet. Sans commission. 
ou
2/Vous pouvez faire bénéficier de votre avoir à d' autres personnes. Sous forme de chèque-cadeau. Sans commission. 
ou
3/Si vous ne souhaitez pas racheter de matériel, faites utiliser votre avoir par une autre personne. Sans commission. Nous prévenir. 
ou
4/Les avoirs sont remboursables, en partie ou totalité, sur demande. Une commission de 30% de la valeur de l'avoir sera retirée lors du remboursement. 
 
N' hésitez pas à nous contacter, si besoin, pour utiliser votre avoir.  
 
Cordialement,
L'équipe www.chinook-leucate.com"

        Dim f As New DialogImpression

        f.pDgview = DGview
        CType(f.pDgview.DataSource, BindingSource).Filter = "active_on=1"
        f.pDepot = True

        If f.ShowDialog = Windows.Forms.DialogResult.OK Then
            settings.HeaderText = "CLI : Listing des dépots ventes" & critere & vbCrLf & vbCrLf & "Impression le " & Now()
            settings.PrintRowHeaders = False
            ExportSettings.HeaderText = "CLI : Listing des dépots ventes" & critere & vbCrLf & vbCrLf & "Impression le " & Now()
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
                Case "BT_Impression_Article"
                    CompletIT.Windows.Forms.Printing.DGVEPrintManager.PrintPreview(DGview, settings)
                Case "BT_Email_Article"
                    PdfExporter.Export(DGview, ExportSettings)
                    Dim fmail As New FormMail
                    fmail.Text = "Envoi d'email"
                    fmail.I_From.Text = gEmailFacture
                    fmail.I_smtp.Text = gSmtp
                    fmail.I_subject.Text = "Listing  www.chinook-leucate.com"
                    'fmail.I_message.Text = "Madame, Monsieur," & vbCrLf & "Veuillez-trouver ci-joint le listing en pièce jointe" & vbCrLf & vbCrLf & "EN DEPOT-VENTE:" & vbCrLf & "Les articles vendus en dépôt-vente donnent droit à un avoir. Cet avoir (sans commission sur le prix de vos articles vendus), est valable 2 ans, sur tous les articles du magasin et du site internet." & vbCrLf & vbCrLf & "Les avoirs sont remboursables,sur demande. Une commission de 30% de la valeur de l'avoir sera retirée lors du remboursement." & vbCrLf & vbCrLf & "Cordialement," & vbCrLf & "L'équipe www.chinook-leucate.com"
                    fmail.I_message.Text = $"Madame, Monsieur,
Veuillez-trouver le listing de votre dépôt-vente, en pièce jointe.
 
Notre équipe se mobilise et Chinook-Leucate vous propose son service de dépôt-vente pour votre matériel. Dès qu 'il est vendu, chaque article se transforme en avoir sur votre compte client Chinook Leucate. 
Cet avoir est valable au magasin directement, mais aussi sur le site Web, en vous connectant à votre espace client. 
 
Votre avoir est valable 2 ans et vous pouvez l' utiliser, en 1 ou plusieurs fois, et de différentes façons:
 
1/Pour un achat, il est utilisable sur tous les articles du magasin et du site internet. Sans commission. 
ou
2/Vous pouvez faire bénéficier de votre avoir à d' autres personnes. Sous forme de chèque-cadeau. Sans commission. 
ou
3/Si vous ne souhaitez pas racheter de matériel, faites utiliser votre avoir par une autre personne. Sans commission. Nous prévenir. 
ou
4/Les avoirs sont remboursables, en partie ou totalité, sur demande. Une commission de 30% de la valeur de l'avoir sera retirée lors du remboursement. 
 
N' hésitez pas à nous contacter, si besoin, pour utiliser votre avoir.  
 
Cordialement,
L'équipe www.chinook-leucate.com"

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
        CType(f.pDgview.DataSource, BindingSource).Filter = ""
    End Sub

    Private Sub BT_Impression_ChequeCadeau_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BT_Impression_ChequeCadeau.Click
        Dim critere As String = ""
        Dim settings As New CompletIT.Windows.Forms.Printing.DGVEPrintSettings
        settings.PrintHeaderText = True
        If ID_T_ClientTextBox.Text <> "" Then
            critere = critere & vbCrLf & "Reference : " & ID_T_ClientTextBox.Text
        End If
        If SociétéTextBox.Text <> "" Then
            critere = critere & vbCrLf & "Société : " & SociétéTextBox.Text
        End If
        If NomTextBox.Text <> "" Then
            critere = critere & vbCrLf & "Nom : " & NomTextBox.Text
        End If
        If PrenomTextBox.Text <> "" Then
            critere = critere & vbCrLf & "Prénom : " & PrenomTextBox.Text
        End If


        Dim f As New DialogImpression
        f.pDgview = DGVIEW_ChequeCadeau

        If f.ShowDialog = Windows.Forms.DialogResult.OK Then
            settings.HeaderText = "CLI : Listing des chèques cadeaux" & critere & vbCrLf & vbCrLf & "Impression le " & Now()
            settings.PrintRowHeaders = False

            If f.ComboBoxOrientation.SelectedIndex = 1 Then
                settings.Landscape = True
            Else
                settings.Landscape = False
            End If

            For Each r As DataGridViewRow In f.DataGridViewColonnes.Rows
                If Not r.Cells(1).Value Then
                    DGVIEW_ChequeCadeau.Columns(r.Cells(2).Value).visible = False

                End If
            Next
            settings.MarginLeft = 50
            settings.MarginRight = 50
            settings.PrintVisualStyles = False
            CompletIT.Windows.Forms.Printing.DGVEPrintManager.PrintPreview(DGVIEW_ChequeCadeau, settings)
            For Each r As DataGridViewRow In f.DataGridViewColonnes.Rows
                If Not r.Cells(1).Value Then
                    DGVIEW_ChequeCadeau.Columns(r.Cells(2).Value).visible = True

                End If
            Next
        End If
    End Sub

    Private Sub DGVIEW_ChequeCadeau_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGVIEW_ChequeCadeau.CellContentClick

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

    Private Sub CodePostalTextBox_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CodePostalTextBox.TextChanged

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


    Private Sub BT_DetailSynchro_Click(sender As Object, e As EventArgs) Handles BT_DetailSynchro.Click
        Dim f As New FormLog
        f.vLogAssociatedRecordId = Me.CLIDataSet.T_Client.Rows(0).Item("ID_t_client")
        f.vLogAssociatedRecordType = "t_client"
        f.ShowDialog()
    End Sub

    Private Sub TabPageGeneral_Click(sender As Object, e As EventArgs) Handles TabPageGeneral.Click

    End Sub

    Private Sub BT_SyncAvoirs_Click(sender As Object, e As EventArgs) Handles BT_SyncAvoirs.Click
        'syncronisation Prestashop
        If ToSyncCheckBox.Checked Then

            CliApi.CustomerAddOrUpdatePSfromCLIByIdAsync(New ToCliDto() With {.Id = id_t_client, .AssociatedAddress = False, .AssociatedCartRule = True})
        End If
    End Sub

    Private Sub BT_SyncAdresses_Click(sender As Object, e As EventArgs) Handles BT_SyncAdresses.Click
        'syncronisation Prestashop
        If ToSyncCheckBox.Checked Then

            CliApi.CustomerAddOrUpdatePSfromCLIByIdAsync(New ToCliDto() With {.Id = id_t_client, .AssociatedAddress = True, .AssociatedCartRule = False})
        End If
    End Sub
End Class