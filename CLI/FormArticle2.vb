Imports System.ComponentModel
Imports System.Data.SqlClient
Imports System.Drawing
Imports System.Drawing.Imaging
Imports System.Xml
Imports CLI.CLIDataSetTableAdapters
'Imports Microsoft.PointOfService
Imports Microsoft.Reporting.WinForms
Imports RestSharp

Public Class FormArticle2
    Public id_t_article_version As Integer = 0

    Private CopieVersion As CLIDataSet.T_Article_versionRow = Nothing
    Private CopieDetail As CLIDataSet.T_Article_DetailRow = Nothing
    Private CopieEntete As CLIDataSet.T_Article_EnteteRow = Nothing
    Private PrixInitialTTC As Double = 0
    Private PrixRemiseTTC As Double = 0
    Private Remise As Double = 0
    Private PrixFournisseur As Double = 0
    Private PrixFournisseurRemise As Double = 0
    Private Remise_Fournisseur As Double = 0
    'Private m_Display As LineDisplay = Nothing
    Private vCodeClient As Integer = 0
    Private vCodeFournisseur As Integer = 0
    Private vDepotVenteReportComplete As Boolean = False
    Private vImageToDeleteList As List(Of Long)
    Private vImageToAddList As List(Of ImageData)
    Private vDefaultImageId As Long



    Private Sub T_Article_EnteteBindingNavigatorSaveItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub MajPosition()
        If Not FormArticleRecherche.bs.Current Is Nothing Then

            If FormArticleRecherche.bs.Find("Ref", id_t_article_version) = -1 Then
                FormArticleRecherche.bs.MoveFirst()
                id_t_article_version = FormArticleRecherche.bs.Current.item("ref")
                Refresh_data()
            End If
            ToolStripLabelPosition.Text = String.Format("{0}/{1}", FormArticleRecherche.bs.Find("Ref", id_t_article_version) + 1, FormArticleRecherche.bs.Count)

            If FormArticleRecherche.bs.Position = FormArticleRecherche.bs.Count - 1 Then
                ToolStripButtonMoveNext.Enabled = False
                ToolStripButtonMoveLast.Enabled = False
            Else
                ToolStripButtonMoveNext.Enabled = True
                ToolStripButtonMoveLast.Enabled = True
            End If
            If FormArticleRecherche.bs.Position = 0 Then
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


    Private Sub FormArticle2_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'legende couleurs 
        Obligatoire.BackColor = gCouleurObligatoireFond
        Web.BackColor = gCouleurWebFond
        Optionnel.BackColor = gCouleurOptionnelFond

        'champs de base
        ID_t_sousfamilleComboBox.BackColor = gCouleurObligatoireFond
        ID_t_sousfamilleComboBox.ForeColor = gCouleurObligatoireEcriture
        FamilleComboBox.BackColor = gCouleurObligatoireFond
        FamilleComboBox.ForeColor = gCouleurObligatoireEcriture



        BT_Enregistrer.Enabled = gArticle_w
        NouveauGeneToolStripButton.Enabled = gArticle_w
        NouveauTechToolStripButton.Enabled = gArticle_w
        NouveauToolStripButton.Enabled = gArticle_w
        SupprimerEnteteToolStripButton.Enabled = gArticle_w
        SupprimerVersionToolStripButton.Enabled = gArticle_w
        SupprimerDetailToolStripButton.Enabled = gArticle_w

        'TODO : cette ligne de code charge les données dans la table 'CLIDataSet.V_Article_Depot_Vente_Rapport'. Vous pouvez la déplacer ou la supprimer selon vos besoins.
        'TODO : cette ligne de code charge les données dans la table 'CLIDataSet.T_Article_version'. Vous pouvez la déplacer ou la supprimer selon vos besoins.
        'Me.T_Article_versionTableAdapter.Fill(Me.CLIDataSet.T_Article_version)
        'Dim strLogicalName As String
        'Dim deviceInfo As DeviceInfo
        'Dim posExplorer As PosExplorer

        'strLogicalName = "LineDisplay"

        ''Crate PosExplorer
        'posExplorer = New PosExplorer

        'Try

        '    deviceInfo = posExplorer.GetDevice(DeviceType.LineDisplay, strLogicalName)
        '    m_Display = posExplorer.CreateInstance(deviceInfo)

        'Catch ex As Exception

        '    Return
        'End Try

        'Try

        '    'Open the device
        '    m_Display.Open()

        '    'Get the exclusive control right for the opened device.
        '    'Then the device is disable from other application.
        '    m_Display.Claim(1000)

        '    'If support the CapPowerReporting, enable the Power Reporting Requirements.
        '    If Not m_Display.CapPowerReporting = PowerReporting.None Then

        '        m_Display.PowerNotify = PowerNotification.Enabled

        '    End If

        '    'Enable the device.
        '    m_Display.DeviceEnabled = True

        'Catch ex As PosControlException



        'End Try

        'desactivation des valeur nulles sur les champs numeriques
        AddHandler AnneeTextBox.DataBindings("text").Parse, AddressOf ValeurNulle
        AddHandler SurfaceTextBox.DataBindings("text").Parse, AddressOf ValeurNulle
        AddHandler LattesTextBox.DataBindings("text").Parse, AddressOf ValeurNulle
        AddHandler CamTextBox.DataBindings("text").Parse, AddressOf ValeurNulle
        AddHandler LongueurTextBox.DataBindings("text").Parse, AddressOf ValeurNulle
        AddHandler LargeurTextBox.DataBindings("text").Parse, AddressOf ValeurNulle
        AddHandler SurfaceTextBox.DataBindings("text").Parse, AddressOf ValeurNulle
        AddHandler Largeur_arriereTextBox.DataBindings("text").Parse, AddressOf ValeurNulle
        AddHandler VolumeTextBox.DataBindings("text").Parse, AddressOf ValeurNulle
        AddHandler Nombre_de_lignesTextBox.DataBindings("text").Parse, AddressOf ValeurNulle
        AddHandler Longueur_ligneTextBox.DataBindings("text").Parse, AddressOf ValeurNulle
        AddHandler SurfaceTextBox.DataBindings("text").Parse, AddressOf ValeurNulle
        AddHandler IMCSTextBox.DataBindings("text").Parse, AddressOf ValeurNulle
        AddHandler Size_minTextBox.DataBindings("text").Parse, AddressOf ValeurNulle
        AddHandler Size_maxTextBox.DataBindings("text").Parse, AddressOf ValeurNulle
        AddHandler RemiseTextBox.DataBindings("text").Parse, AddressOf ValeurNulle
        AddHandler PoidsComboBox.DataBindings("text").Parse, AddressOf ValeurNulle
        AddHandler ID_T_ClientTextBox.DataBindings("text").Parse, AddressOf ValeurNulle
        AddHandler ID_T_FournisseurTextBox.DataBindings("text").Parse, AddressOf ValeurNulle
        AddHandler StockTextBox.DataBindings("text").Parse, AddressOf ValeurNulle
        AddHandler Stock1TextBox.DataBindings("text").Parse, AddressOf ValeurNulle
        AddHandler Stock2TextBox.DataBindings("text").Parse, AddressOf ValeurNulle
        AddHandler RemiseAutoTextBox.DataBindings("text").Parse, AddressOf ValeurNulle
        AddHandler RemiseAutoDuTextBox.DataBindings("text").Parse, AddressOf ValeurNulle
        AddHandler RemiseAutoAuTextBox.DataBindings("text").Parse, AddressOf ValeurNulle
        AddHandler NouveauDuTextBox.DataBindings("text").Parse, AddressOf ValeurNulle
        AddHandler NouveauAuTextBox.DataBindings("text").Parse, AddressOf ValeurNulle
        AddHandler AileAvantTextBox.DataBindings("text").Parse, AddressOf ValeurNulle
        AddHandler AileArriereTextBox.DataBindings("text").Parse, AddressOf ValeurNulle
        AddHandler FuselageTextBox.DataBindings("text").Parse, AddressOf ValeurNulle
        AddHandler MatTextBox.DataBindings("text").Parse, AddressOf ValeurNulle

        'TODO : cette ligne de code charge les données dans la table 'CLIDataSet.V_liste_code_port_pays'. Vous pouvez la déplacer ou la supprimer selon vos besoins.
        Me.V_liste_code_port_paysTableAdapter.Fill(Me.CLIDataSet.V_liste_code_port_pays)
        'TODO : cette ligne de code charge les données dans la table 'CLIDataSet.T_liste_code_port_pays'. Vous pouvez la déplacer ou la supprimer selon vos besoins.
        Me.T_liste_code_port_paysTableAdapter.Fill(Me.CLIDataSet.T_liste_code_port_pays)
        'TODO : cette ligne de code charge les données dans la table 'CLIDataSet.T_code_tva'. Vous pouvez la déplacer ou la supprimer selon vos besoins.
        Me.T_code_tvaTableAdapter.Fill(Me.CLIDataSet.T_code_tva)
        'TODO : cette ligne de code charge les données dans la table 'CLIDataSet.V_Fournisseur_Combo'. Vous pouvez la déplacer ou la supprimer selon vos besoins.
        If id_t_article_version = 0 Then
            ToolStrip2.Visible = False
        Else
            ToolStrip2.Visible = True
        End If

        TabControl1.SelectTab("TabPageVersion")
        TabControl1.SelectTab("TabPageTechnique")
        TabControl1.SelectTab("TabPageGeneral")
        Refresh_data()
        RafraichissementLiensPhoto()

        T_Article_EnteteBindingSource.EndEdit()
        RefreshChampsObligatoires()
        If Not T_Article_DetailBindingSource.Current Is Nothing And Not T_Article_EnteteBindingSource.Current Is Nothing And Not T_Article_versionBindingSource.Current Is Nothing Then
            RefreshListesDeroulantes()
        End If






        Me.DepotVenteReportViewer.RefreshReport()
    End Sub

    Public Sub Inventaire(ByVal Id_T_Article_Version As Integer)
        Dim bActive As Boolean = False
        Dim cnn As New SqlClient.SqlConnection(My.Settings.CLIConnectionString)
        cnn.Open()
        Dim command As New SqlClient.SqlCommand
        command.CommandText = "select active_on from t_article_version where ID_t_article_version=" & Id_T_Article_Version
        command.Connection = cnn
        Dim reader As SqlClient.SqlDataReader = command.ExecuteReader
        If reader.HasRows Then
            reader.Read()
            If reader("active_on") = True Then
                bActive = True
            Else
                bActive = False
            End If



        End If

        reader.Close()
        cnn.Close()
        If Not bActive Then
            MessageBox.Show("Impossible de mettre du stock sur un article désactivé !", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If

        'par defaut sur le site 1
        Dim site As String = 1
        'site = InputBox("Indiquer le site pour l'inventaire",, gNumCaisse)
        'If Not IsNumeric(site) Then
        '    Return
        'End If
        'If site <> 1 And site <> 2 Then
        '    Return
        'End If


        Dim reponse As String
        Dim stock_souhaite As Double
        Dim stock_actuel As Double
        'suppression de la notion de site
        ' reponse = InputBox("Indiquez la quantité inventoriée pour cet article sur le site " & site)
        reponse = InputBox("Indiquez la quantité inventoriée pour cet article ",, 1)
        If IsNumeric(reponse) Then
            stock_souhaite = reponse
            cnn = New SqlClient.SqlConnection(My.Settings.CLIConnectionString)
            cnn.Open()
            command = New SqlClient.SqlCommand
            command.CommandText = "select * from v_article_stock where ID_t_article_version=" & Id_T_Article_Version
            'command.CommandText = "select * from v_article_stock_numcaisse where ID_t_article_version=" & Id_T_Article_Version & " and numcaisse=" & site

            command.Connection = cnn
            reader = command.ExecuteReader
            If reader.HasRows Then
                reader.Read()
                If IsNumeric(reader("stock")) Then
                    stock_actuel = reader("stock")
                Else
                    stock_actuel = 0
                End If
            End If
            reader.Close()
            command.CommandText = "INSERT INTO T_Article_Stock (id_t_article_version,operation,date,signature,numcaisse) VALUES (" & Id_T_Article_Version & "," & Replace(stock_souhaite - stock_actuel, ",", ".") & ",getdate(),'" & gLogin & "'," & site & ")"
            command.ExecuteNonQuery()
            command.CommandText = "update t_article_version set exportfile = null,modifiele=getdate(),modifiepar='" & gLogin & "' where id_t_article_version=" & Id_T_Article_Version
            command.ExecuteNonQuery()
            cnn.Close()
            If Id_T_Article_Version > 0 Then

                Me.V_Article_StockTableAdapter.FillByIdTArticleVersion(Me.CLIDataSet.V_Article_Stock, Id_T_Article_Version)
                Me.V_Article_Stock_numcaisse1TableAdapter1.FillByIdTArticleVersionNumCaisse(Me.CLIDataSet.V_Article_Stock_numcaisse1, Id_T_Article_Version)
                Me.V_Article_Stock_numcaisse2TableAdapter1.FillByIdTArticleVersionNumCaisse(Me.CLIDataSet.V_Article_Stock_numcaisse2, Id_T_Article_Version)
            Else

                Me.V_Article_StockTableAdapter.Fill(Me.CLIDataSet.V_Article_Stock)
                Me.V_Article_Stock_numcaisse1TableAdapter1.Fill(Me.CLIDataSet.V_Article_Stock_numcaisse1)
                Me.V_Article_Stock_numcaisse2TableAdapter1.Fill(Me.CLIDataSet.V_Article_Stock_numcaisse2)
            End If
            CliApi.ProductUpdatePSStockfromCLIByIdAsync(New ToCliDto() With {.Id = Id_T_Article_Version, .AssociatedAddress = False, .AssociatedCartRule = False})

            RafraichissementDuMoteurDeRecherche()


        End If
    End Sub
    Private Sub BT_Inventaire_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BT_Inventaire.Click
        Inventaire(ID_t_article_versionTextBox.Text)

    End Sub

    Private Sub RafraichissementDuMoteurDeRecherche()
        If FormArticleRecherche.Visible Then
            'FormArticleRecherche.BT_RAZ.PerformClick()
            FormArticleRecherche.Recherche(False, False)
            FormArticleRecherche.bs.Position = FormArticleRecherche.bs.Find("Ref", id_t_article_version)

        End If
    End Sub
    Private Sub Enregistrer()
        Cursor = Cursors.WaitCursor
        Dim photo1, photo2, photo3
        Try

            Me.Validate()
            Try
                Dim client As New Utilities.FTP.FTPclient
                'Dim client As New FtpConnection
                client.Hostname = gFTP_host
                client.Username = gFTP_UID
                client.Password = gFTP_PWD
                Me.T_Article_EnteteBindingSource.EndEdit()
                Me.T_Article_EnteteTableAdapter.Update(Me.CLIDataSet.T_Article_Entete)
                If Not Me.T_Article_EnteteBindingSource.Current Is Nothing Then
                    'effacement des images
                    'client.Connect()
                    'If client.IsConnected Then
                    'If T_Article_EnteteBindingSource.Current.item("photo_modele").ToString = "" Then
                    '    client.FtpDelete(gChemin_Vignette & "photo_modele_" & T_Article_EnteteBindingSource.Current.item("ID_T_article_entete") & ".jpg")
                    'End If
                    'If T_Article_EnteteBindingSource.Current.item("photo_big1").ToString = "" Then
                    '    client.FtpDelete(gChemin_Vignette & "photo_big1_" & T_Article_EnteteBindingSource.Current.item("ID_T_article_entete") & ".jpg")
                    'End If
                    'If T_Article_EnteteBindingSource.Current.item("photo_big2").ToString = "" Then
                    '    client.FtpDelete(gChemin_Vignette & "photo_big2_" & T_Article_EnteteBindingSource.Current.item("ID_T_article_entete") & ".jpg")
                    'End If
                    'If T_Article_EnteteBindingSource.Current.item("photo_big3").ToString = "" Then
                    '    client.FtpDelete(gChemin_Vignette & "photo_big3_" & T_Article_EnteteBindingSource.Current.item("ID_T_article_entete") & ".jpg")
                    'End If
                    'If T_Article_EnteteBindingSource.Current.item("photo_mini1").ToString = "" Then
                    '    client.FtpDelete(gChemin_Vignette & "photo_mini1_" & T_Article_EnteteBindingSource.Current.item("ID_T_article_entete") & ".jpg")
                    'End If
                    'If T_Article_EnteteBindingSource.Current.item("photo_mini2").ToString = "" Then
                    '    client.FtpDelete(gChemin_Vignette & "photo_mini2_" & T_Article_EnteteBindingSource.Current.item("ID_T_article_entete") & ".jpg")
                    'End If
                    'If T_Article_EnteteBindingSource.Current.item("photo_mini3").ToString = "" Then
                    '    client.FtpDelete(gChemin_Vignette & "photo_mini3_" & T_Article_EnteteBindingSource.Current.item("ID_T_article_entete") & ".jpg")
                    'End If


                    'End If


                End If
            Catch ex As Exception
                MessageBox.Show("Un probleme s'est produit pendant le transfert FTP des images." & vbCrLf & "  Merci de ré-enregister la fiche article.", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            End Try

            If Not Me.T_Article_EnteteBindingSource.Current Is Nothing Then
                Me.T_Article_EnteteBindingSource.Current.item("ModifieLe") = Date.Now
                Me.T_Article_EnteteBindingSource.Current.item("ModifiePar") = gLogin
                Me.T_Article_EnteteBindingSource.EndEdit()
            End If
            Try
                Me.T_Article_EnteteTableAdapter.Update(Me.CLIDataSet.T_Article_Entete)
            Catch ex As Exception

            End Try


            If Not Me.T_Article_EnteteBindingSource.Current Is Nothing And Not Me.T_Article_DetailBindingSource.Current Is Nothing Then
                Me.T_Article_DetailBindingSource.Current.item("id_t_article_entete") = Me.T_Article_EnteteBindingSource.Current.item("id_t_article_entete")
            End If

            If Not Me.T_Article_DetailBindingSource.Current Is Nothing Then
                Me.T_Article_DetailBindingSource.Current.item("ModifieLe") = Date.Now
                Me.T_Article_DetailBindingSource.Current.item("ModifiePar") = gLogin
                Me.T_Article_DetailBindingSource.EndEdit()
            End If

            Try
                Me.T_Article_DetailTableAdapter.Update(Me.CLIDataSet.T_Article_Detail)
            Catch ex As Exception

            End Try

            If Not Me.T_Article_versionBindingSource.Current Is Nothing And Not Me.T_Article_DetailBindingSource.Current Is Nothing Then
                Me.T_Article_versionBindingSource.Current.item("id_t_article_detail") = Me.T_Article_DetailBindingSource.Current.item("id_t_article_detail")
            End If

            If Not Me.T_Article_versionBindingSource.Current Is Nothing Then
                Me.T_Article_versionBindingSource.Current.item("ModifieLe") = Date.Now
                Me.T_Article_versionBindingSource.Current.item("ModifiePar") = gLogin
                Me.T_Article_versionBindingSource.EndEdit()
            End If
            Try
                Me.T_Article_versionTableAdapter.Update(Me.CLIDataSet.T_Article_version)
            Catch ex As Exception

            End Try

            If Not Me.T_Article_DetailBindingSource.Current Is Nothing Then
                id_t_article_version = T_Article_versionBindingSource.Current.item("Id_t_article_version")
            Else
                id_t_article_version = 0
            End If

            Dim AssociatedLegayImages = False
            Try
                AssociatedLegayImages = CheckBoxImportLegacy.Checked
            Catch ex As Exception

            End Try

            CliApi.ProductAddOrUpdatePSfromCLIByIdAsync(New ToCliDto() With {.Id = id_t_article_version, .AssociatedAddress = False, .AssociatedCartRule = False, .AssociatedLegacyImages = AssociatedLegayImages, .ImportStock = True})

            'gestion des images à supprimer
            If vImageToDeleteList.Count() Then
                CliApi.ProductDeleteProductImagesAsync(New ToCliDto() With {.Id = id_t_article_version, .ToDeleteImages = vImageToDeleteList, .AssociatedAddress = False, .AssociatedCartRule = False})

            End If

            'gestion des images à ajouter
            If vImageToAddList.Count() Then
                CliApi.ProductAddProductImagesAsync(New ToCliDto() With {.Id = id_t_article_version, .ToAddImages = vImageToAddList, .AssociatedAddress = False, .AssociatedCartRule = False})

            End If

            'gestion de la photo de couverture
            If vDefaultImageId > 0 Then
                CliApi.ProductSetProductDefaultImageIdAsync(New ToCliDto() With {.Id = id_t_article_version, .DefaultImageId = vDefaultImageId, .AssociatedAddress = False, .AssociatedCartRule = False})
            End If


            'rafraichissement du moteur de recherche et repositionnement sur l'enregistrement
            RafraichissementDuMoteurDeRecherche()
            RafraichissementLiensPhoto()
            MajPosition()
            MajNbEnregistrements()
        Catch ex As Exception
        Finally
            Cursor = Cursors.Default
        End Try


    End Sub
    Private Sub BT_Enregistrer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BT_Enregistrer.Click
        Dim tabselected As TabPage

        tabselected = TabControl1.SelectedTab

        'mise en automatique du taux de tva si occasion
        'on mets un taux de tva à 0%
        If T_Article_versionBindingSource.Current.item("Depot_vente") Or T_Article_versionBindingSource.Current.item("occaz") Then
            Code_tvaComboBox.Text = 0
        End If



        'vérification que l'on essaie pas de saisir un depot vente  ou reprise dans une entete ou detail deja existante

        'on test si l'utilisateur n'a droit qu'au occasions ou dépot-vente
        If T_Article_EnteteBindingSource.Current.item("id_t_sousfamille").ToString <> "" Then
            If T_Article_versionBindingSource.Current.item("description_auto").ToString = "True" Then
                'description auto rec

                Dim description_auto_text = Description_Auto()
                ' If T_Article_versionBindingSource.Current.item("description_panier").ToString = "" Then
                T_Article_versionBindingSource.Current.item("description_panier") = description_auto_text
                T_Article_versionBindingSource.EndEdit()
            End If

        End If
        ' End If
        ' on parcourt tous les onglets
        For Each t As TabPage In TabControl1.TabPages
            TabControl1.SelectedTab = t
        Next

        TabControl1.SelectedTab = tabselected

        'on test les champs obligatoires généraux
        Dim err_msg As String = ""




        'If FamilleComboBox.Text.Trim = "" Then
        '    err_msg = err_msg & vbCrLf & "- Famille"
        'End If
        'If ID_t_sousfamilleComboBox.Text.Trim = "" Then
        '    err_msg = err_msg & vbCrLf & "- Sous famille"
        'End If
        'If AnneeTextBox.Text.Trim = "" Then
        '    err_msg = err_msg & vbCrLf & "- Annee"
        'End If
        'If MarqueTextBox.Text.Trim = "" Then
        '    err_msg = err_msg & vbCrLf & "- Marque"
        'End If
        'If ModeleTextBox.Text.Trim = "" Then
        '    err_msg = err_msg & vbCrLf & "- Modele"
        'End If
        'If Code_portComboBox.Text.Trim = "" Then
        '    err_msg = err_msg & vbCrLf & "- Code Port"
        'End If
        'If Code_tvaComboBox.Text.Trim = "" Then
        '    err_msg = err_msg & vbCrLf & "- Code TVA"
        'End If
        If Depot_venteCheckBox.Checked And OccazCheckBox.Checked Then
            err_msg = err_msg & vbCrLf & "- Ne peut être à la fois un dépot-vente et une reprise magasin !"
        End If

        If (Depot_venteCheckBox.Checked Or OccazCheckBox.Checked) And (ID_T_ClientTextBox.Text = "0" Or ID_T_ClientTextBox.Text = "") Then
            err_msg = err_msg & vbCrLf & "- Merci de saisir un code client pour ce dépôt vente ou cette reprise magasin  !"
        End If

        If (Depot_venteCheckBox.Checked Or OccazCheckBox.Checked) And CDbl(Prix_fournisseurTextBox.Text) = 0 Then
            err_msg = err_msg & vbCrLf & "- Merci de saisir un prix fournisseur  !"
        End If

        If (Depot_venteCheckBox.Checked Or OccazCheckBox.Checked) And CDbl(Prix_vente_remise_TTCTextBox.Text) = 0 Then
            err_msg = err_msg & vbCrLf & "- Merci de saisir un prix de vente  !"
        End If

        If IsNumeric(gMontantRepriseCodeClient) And Prix_fournisseurTextBox.Text <> "" Then
            If OccazCheckBox.Checked And (ID_T_ClientTextBox.Text = "0" Or ID_T_ClientTextBox.Text = "") And CDbl(Prix_fournisseurTextBox.Text) > CDbl(gMontantRepriseCodeClient) Then
                err_msg = err_msg & vbCrLf & "- Merci de saisir un code client pour cette reprise magasin  ! Le prix dépasse " & gMontantRepriseCodeClient & " Euros"
            End If
        End If


        ' If Depot_venteCheckBox.Checked Or OccazCheckBox.Checked Then
        'If NbEnregistrementsEntete(T_Article_EnteteBindingSource.Current.item("id_t_article_entete").ToString) > 1 Then
        ' err_msg = err_msg & vbCrLf & "- Il ne peut y avoir plus d'un article dépot-vente ou reprise magasin ratataché à cette fiche entete ou detail !"
        ' End If
        ' End If




        'champs nouveau

        If (NouveauDuTextBox.Text <> "" And NouveauAuTextBox.Text = "") Or (NouveauDuTextBox.Text = "" And NouveauAuTextBox.Text <> "") Then
            err_msg = err_msg & vbCrLf & "- Merci de saisir les deux champs pour mettre le produit en ""nouveau"" !"
        End If

        If NouveauDuTextBox.Text <> "" Then
            If Not IsDate(NouveauDuTextBox.Text) Then
                err_msg = err_msg & vbCrLf & "- Merci de saisir une date valide pour le champ ""nouveau du"" !"
            End If
        End If

        If NouveauAuTextBox.Text <> "" Then
            If Not IsDate(NouveauAuTextBox.Text) Then
                err_msg = err_msg & vbCrLf & "- Merci de saisir une date valide pour le champ ""nouveau au"" !"
            End If
        End If


        'champs de remise automatique

        If (RemiseAutoDuTextBox.Text <> "" And RemiseAutoAuTextBox.Text = "") Or (RemiseAutoDuTextBox.Text = "" And RemiseAutoAuTextBox.Text <> "") Then
            err_msg = err_msg & vbCrLf & "- Merci de saisir les deux champs pour mettre le produit en ""remise auto"" !"
        End If


        If RemiseAutoDuTextBox.Text <> "" Then
            If Not IsDate(RemiseAutoDuTextBox.Text) Then
                err_msg = err_msg & vbCrLf & "- Merci de saisir une date valide pour le champ ""Remise auto du"" !"
            End If
        End If

        If RemiseAutoAuTextBox.Text <> "" Then
            If Not IsDate(RemiseAutoAuTextBox.Text) Then
                err_msg = err_msg & vbCrLf & "- Merci de saisir une date valide pour le champ ""Remise auto au"" !"
            End If
        End If

        If (RemiseAutoDuTextBox.Text <> "" And RemiseAutoAuTextBox.Text <> "" And RemiseAutoTextBox.Text = "") Then

            err_msg = err_msg & vbCrLf & "- Merci de saisir le champs ""remise auto"" avec une valeur entre 0 et 1 !"
        Else
            If IsNumeric(RemiseAutoTextBox.Text) Then
                If RemiseAutoTextBox.Text <= 0 Or RemiseAutoTextBox.Text > 1 Then
                    err_msg = err_msg & vbCrLf & "- Merci de saisir le champs ""remise auto"" avec une valeur entre 0 et 1 !"
                End If
            End If

        End If



        'If Depot_venteCheckBox.Checked Then
        '    If ID_T_ClientTextBox.Text.Trim = "" Or ID_T_ClientTextBox.Text.Trim = "0" Then
        '        err_msg = err_msg & vbCrLf & "- Client"
        '    End If
        'Else
        '    If ID_T_FournisseurTextBox.Text.Trim = "" Or ID_T_FournisseurTextBox.Text.Trim = "0" Then
        '        err_msg = err_msg & vbCrLf & "- Fournisseur"
        '    End If
        'End If

        'If OccazCheckBox.Checked Then
        '    If Prix_fournisseurTextBox.Text = "" Or Prix_fournisseurTextBox.Text = "0" Then
        '        err_msg = err_msg & vbCrLf & "- Prix fournisseur"
        '    End If
        'End If


        'If Prix_vente_initial_TTCTextBox.Text.Trim = "" Then
        '    err_msg = err_msg & vbCrLf & "- Prix de vente initial"
        'End If
        'If Description_panierTextBox.Text.Trim = "" Then
        '    err_msg = err_msg & vbCrLf & "- Description panier"
        'End If

        'en fonction des familles
        If FamilleComboBox.Text.Trim = "" And ID_t_sousfamilleComboBox.Text.Trim = "" Then


        End If

        If err_msg = "" And TestChamps() Then


            If gArticle_OccazTestOnly Then
                If Not T_Article_versionBindingSource.Current.item("occaz") And Not T_Article_versionBindingSource.Current.item("depot_vente") And Not T_Article_versionBindingSource.Current.item("test") Then
                    MessageBox.Show("Vous êtes autorisé seulement à saisir/modifier des occasions ou des dépôts vente ou des tests", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Exit Sub
                End If
            Else
                If gArticle_OccazOnly Then
                    If Not T_Article_versionBindingSource.Current.item("occaz") And Not T_Article_versionBindingSource.Current.item("depot_vente") Then
                        MessageBox.Show("Vous êtes autorisé seulement à saisir/modifier des occasions ou des dépôts vente", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        Exit Sub
                    End If
                End If
            End If

            Enregistrer()
            BT_Inventaire.Enabled = gArticle_stock Or (gArticle_OccazOnly And (T_Article_versionBindingSource.Current.item("occaz") Or T_Article_versionBindingSource.Current.item("depot_vente")))
            BT_MajStock.Enabled = gArticle_stock Or (gArticle_OccazOnly And (T_Article_versionBindingSource.Current.item("occaz") Or T_Article_versionBindingSource.Current.item("depot_vente")))

            BT_CodeBarre.Enabled = True
            BT_CodeBarrePrix.Enabled = True
            BT_BonDepotVente.Enabled = True
            NouveauGeneToolStripButton.Enabled = gArticle_w
            NouveauTechToolStripButton.Enabled = gArticle_w
            NouveauToolStripButton.Enabled = gArticle_w
            SupprimerDetailToolStripButton.Enabled = True
            SupprimerEnteteToolStripButton.Enabled = True
            SupprimerVersionToolStripButton.Enabled = True
            ToolStripButtonMovefirst.Enabled = True
            ToolStripButtonMovePrevious.Enabled = True
            ToolStripButtonMoveNext.Enabled = True
            ToolStripButtonMoveLast.Enabled = True
            ToolStripLabelPosition.Enabled = True
            If id_t_article_version = 0 Then
                ToolStrip2.Visible = False
            Else
                ToolStrip2.Visible = True
            End If
            If (Depot_venteCheckBox.Checked Or OccazCheckBox.Checked) And (StockTextBox.Text = "" Or StockTextBox.Text = "0") Then
                Inventaire(ID_t_article_versionTextBox.Text)
            End If


            MessageBox.Show("Enregistrement ok", "CLI", MessageBoxButtons.OK, MessageBoxIcon.Information)

        Else
            If err_msg = "" Then
                err_msg = "Merci de saisir les champs obligatoires ! voir les erreurs" & vbCrLf & err_msg
            Else
                err_msg = "Voir les erreurs" & vbCrLf & err_msg
            End If

            MessageBox.Show(err_msg, "Attention", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If


    End Sub
    Private Sub Refresh_data()
        Cursor = Cursors.WaitCursor

        Me.V_Fournisseur_ComboTableAdapter.Fill(Me.CLIDataSet.V_Fournisseur_Combo)
        Me.T_FamilleTableAdapter.Fill(Me.CLIDataSet.T_Famille)

        Me.T_SousFamilleTableAdapter.Fill(Me.CLIDataSet.T_SousFamille)
        If id_t_article_version > 0 Then
            Me.T_Article_versionTableAdapter.FillByIdTArticleVersion(Me.CLIDataSet.T_Article_version, id_t_article_version)
            Me.T_Article_DetailTableAdapter.FillByIdTArticleDetail(Me.CLIDataSet.T_Article_Detail, Me.CLIDataSet.T_Article_version.Rows(0).Item("ID_t_article_detail").ToString)

            Me.T_Article_EnteteTableAdapter.FillByIdTArticleEntete(Me.CLIDataSet.T_Article_Entete, Me.CLIDataSet.T_Article_Detail.Rows(0).Item("ID_t_article_entete").ToString)

            Me.V_Article_StockTableAdapter.FillByIdTArticleVersion(Me.CLIDataSet.V_Article_Stock, id_t_article_version)
            Me.V_Article_Stock_numcaisse1TableAdapter1.FillByIdTArticleVersionNumCaisse(Me.CLIDataSet.V_Article_Stock_numcaisse1, id_t_article_version)
            Me.V_Article_Stock_numcaisse2TableAdapter1.FillByIdTArticleVersionNumCaisse(Me.CLIDataSet.V_Article_Stock_numcaisse2, id_t_article_version)


            'Récupération de l'état de synchro prestashop
            Dim vEtatSynchroDt As DataTable = ExecuteRequeteR("select LogType,logdetail from V_Log where LogAssociatedRecordId=" & Me.CLIDataSet.T_Article_Detail.Rows(0).Item("ID_t_article_entete").ToString & " and LogAssociatedRecordType='t_article_entete' ", gCnn.ConnectionString)
            Dim vEtatSynchro As String = "Non"
            Dim vLogDetail As String = ""
            BT_DetailSynchroGeneral.Enabled = False
            If vEtatSynchroDt.Rows.Count > 0 Then
                vEtatSynchro = vEtatSynchroDt.Rows(0)("LogType")
                vLogDetail = vEtatSynchroDt.Rows(0)("Logdetail")
                BT_DetailSynchroGeneral.Enabled = True
            End If
            I_EtatSynchroPrestashopGeneral.Text = vEtatSynchro
            I_EtatSynchroPrestashopDetail.Text = vEtatSynchro
            I_EtatSynchroPrestashopVersion.Text = vEtatSynchro


            'Récupération de l'erreur de syncronisation
            If vEtatSynchro = "Erreur" Then
                Dim vErreurSynchroDt As DataTable = ExecuteRequeteR("select errors from V_Log where LogAssociatedRecordId=" & Me.CLIDataSet.T_Article_Detail.Rows(0).Item("ID_t_article_entete").ToString & " and LogAssociatedRecordType='t_article_entete' and LogType='Erreur' ", gCnn.ConnectionString)
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
                        I_ErrorDetailVersion.Text = sb.ToString
                    Catch ex As Exception
                        I_ErrorDetailVersion.Text = ""
                    End Try

                Else
                    I_ErrorDetailVersion.Text = ""
                End If
                'recuperation du detail de l'erreur
                If I_ErrorDetailVersion.Text = "" Then
                    I_ErrorDetailVersion.Text = vLogDetail
                End If

            End If
            I_ErrorDetailVersion.Text = vLogDetail
            I_ErrorDetailDetail.Text = I_ErrorDetailVersion.Text
            I_ErrorDetailEntete.Text = I_ErrorDetailVersion.Text

            'on remets la famille et la sous famille
            'sous_famille = ID_t_sousfamilleComboBox.SelectedValue
            '           FamilleComboBox.SelectedValue = ID_t_sousfamilleComboBox.SelectedValue
            'ID_t_sousfamilleComboBox.SelectedValue = sous_famille
            RafraichissementLiensPhoto()
            BT_Inventaire.Enabled = gArticle_stock Or (gArticle_OccazOnly And (T_Article_versionBindingSource.Current.item("occaz") Or T_Article_versionBindingSource.Current.item("depot_vente")))
            BT_MajStock.Enabled = gArticle_stock Or (gArticle_OccazOnly And (T_Article_versionBindingSource.Current.item("occaz") Or T_Article_versionBindingSource.Current.item("depot_vente")))
            BT_CodeBarre.Enabled = True
            BT_CodeBarrePrix.Enabled = True
            BT_BonDepotVente.Enabled = True
            NouveauGeneToolStripButton.Enabled = gArticle_w
            NouveauTechToolStripButton.Enabled = gArticle_w
            NouveauToolStripButton.Enabled = gArticle_w
            BT_NewDepot.Enabled = gArticle_w
            BT_NewReprise.Enabled = gArticle_w
            SupprimerDetailToolStripButton.Enabled = gArticle_w
            SupprimerEnteteToolStripButton.Enabled = gArticle_w
            SupprimerVersionToolStripButton.Enabled = gArticle_w




            ToolStripButtonMovefirst.Enabled = True
            ToolStripButtonMovePrevious.Enabled = True
            ToolStripButtonMoveNext.Enabled = True
            ToolStripButtonMoveLast.Enabled = True
            ToolStripLabelPosition.Enabled = True





        Else
            NouveauGene()
        End If
        'rafraischissement du line display
        'Try
        '    m_Display.ClearText()
        '    m_Display.DisplayTextAt(0, 0, T_Article_versionBindingSource.Current.item("description_panier").ToString, DisplayTextMode.Normal)
        '    'm_Display.DisplayTextAt(1, 5, T_Article_versionBindingSource.Current.item("Prix_vente_remise_TTC").ToString & "€", DisplayTextMode.Normal)

        'Catch ex As Exception

        'End Try


        MajPosition()
        'refraichissement du nombre d'enregistrements utilisant celui ci
        MajNbEnregistrements()
        'rafraichissement de la case texte contenant le nom du fournisseur ou du client
        If T_Article_versionBindingSource.Current.item("id_t_fournisseur").ToString <> "" And T_Article_versionBindingSource.Current.item("id_t_fournisseur").ToString <> "0" Then
            CheckFournisseur()
        End If
        If T_Article_versionBindingSource.Current.item("id_t_client").ToString <> "" And T_Article_versionBindingSource.Current.item("id_t_client").ToString <> "0" Then
            CheckClient()
        End If
        If T_Article_versionBindingSource.Current.item("depot_vente") = True Then
            'rafraichissement des données pour le dépot vente
            Me.V_Article_Depot_Vente_RapportTableAdapter.FillByid_t_article_version(Me.CLIDataSet.V_Article_Depot_Vente_Rapport, id_t_article_version)
            DepotVenteReportViewer.RefreshReport()
        End If

        Cursor = Cursors.Default
    End Sub


    Private Sub BT_Refresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BT_Refresh.Click
        Refresh_data()

    End Sub

    Private Sub BT_Fermer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BT_Fermer.Click
        Me.Close()
    End Sub







    Private Sub FormArticle2_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown

    End Sub



    Private Sub NouveauToolStripButton_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NouveauToolStripButton.Click
        T_Article_versionBindingSource.AddNew()
        T_Article_versionBindingSource.EndEdit()
        BT_Inventaire.Enabled = False
        BT_MajStock.Enabled = False
        BT_CodeBarre.Enabled = False
        BT_CodeBarrePrix.Enabled = False
        BT_BonDepotVente.Enabled = False
        BT_NewDepot.Enabled = False
        BT_NewReprise.Enabled = False
        NouveauGeneToolStripButton.Enabled = False
        NouveauTechToolStripButton.Enabled = False
        NouveauToolStripButton.Enabled = False
        SupprimerDetailToolStripButton.Enabled = False
        SupprimerEnteteToolStripButton.Enabled = False
        SupprimerVersionToolStripButton.Enabled = False
        ToolStripButtonMovefirst.Enabled = False
        ToolStripButtonMovePrevious.Enabled = False
        ToolStripButtonMoveNext.Enabled = False
        ToolStripButtonMoveLast.Enabled = False
        ToolStripLabelPosition.Enabled = False
        StockTextBox.Text = "0"
        Stock1TextBox.Text = "0"
        Stock2TextBox.Text = "0"
        PoidsComboBox.SelectedIndex = -1




    End Sub

    Private Sub CopierToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CopierToolStripButton.Click

        Dim courant As CLIDataSet.T_Article_versionRow = Me.CLIDataSet.T_Article_version(T_Article_versionBindingSource.Position)
        CopieVersion = Me.CLIDataSet.T_Article_version.NewT_Article_versionRow
        Dim col As DataColumn
        For Each col In courant.Table.Columns
            If UCase(col.ColumnName) <> "ID_T_ARTICLE_VERSION" And UCase(col.ColumnName) <> "CREELE" And UCase(col.ColumnName) <> "MODIFIELE" And UCase(col.ColumnName) <> "MODIFIEPAR" And UCase(col.ColumnName) <> "CREEPAR" Then
                CopieVersion.Item(col.ColumnName) = courant.Item(col.ColumnName)
            End If
        Next
        CollerToolStripButton.Enabled = True






    End Sub

    Private Sub CollerToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CollerToolStripButton.Click

        Dim courant As CLIDataSet.T_Article_versionRow = Me.CLIDataSet.T_Article_version(0)


        Dim col As DataColumn

        For Each col In courant.Table.Columns
            If UCase(col.ColumnName) <> "ID_T_ARTICLE_VERSION" Then
                Me.CLIDataSet.T_Article_version(Me.CLIDataSet.T_Article_version.Rows.Count - 1).Item(col.ColumnName) = CopieVersion.Item(col.ColumnName)
            End If
        Next




    End Sub

    Private Sub ToolStripButton2_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButtonMoveNext.Click

        FormArticleRecherche.bs.MoveNext()
        id_t_article_version = FormArticleRecherche.bs.Current.Item("Ref")
        Refresh_data()


    End Sub

    Private Sub ToolStripButton1_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButtonMovePrevious.Click

        FormArticleRecherche.bs.MovePrevious()
        id_t_article_version = FormArticleRecherche.bs.Current.Item("Ref")
        Refresh_data()

    End Sub

    Private Sub ToolStripButton3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButtonMoveLast.Click

        FormArticleRecherche.bs.MoveLast()
        id_t_article_version = FormArticleRecherche.bs.Current.Item("Ref")
        Refresh_data()

    End Sub

    Private Sub ToolStripButton4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButtonMovefirst.Click

        FormArticleRecherche.bs.MoveFirst()
        id_t_article_version = FormArticleRecherche.bs.Current.Item("Ref")
        Refresh_data()

    End Sub

    Private Sub NouveauGene()



        T_Article_EnteteBindingSource.AddNew()
        T_Article_EnteteBindingSource.AddNew()
        T_Article_EnteteBindingSource.RemoveAt(T_Article_EnteteBindingSource.Count - 1)
        T_Article_EnteteBindingSource.EndEdit()

        T_Article_DetailBindingSource.AddNew()
        T_Article_DetailBindingSource.EndEdit()
        T_Article_versionBindingSource.AddNew()
        T_Article_versionBindingSource.EndEdit()

        FamilleComboBox.SelectedIndex = -1
        ID_t_sousfamilleComboBox.SelectedIndex = -1
        Code_portComboBox.SelectedIndex = -1

        'mise automatique du taux de TVA à 20, changement manuel si besoin
        Code_tvaComboBox.Text = "20"
        'Code_tvaComboBox.SelectedIndex = -1
        MarqueComboBox.SelectedIndex = -1

        BT_Inventaire.Enabled = False
        BT_MajStock.Enabled = False
        BT_CodeBarre.Enabled = False
        BT_CodeBarrePrix.Enabled = False
        BT_BonDepotVente.Enabled = False
        BT_NewDepot.Enabled = False
        BT_NewReprise.Enabled = False

        NouveauGeneToolStripButton.Enabled = False
        NouveauTechToolStripButton.Enabled = False
        NouveauToolStripButton.Enabled = False

        SupprimerDetailToolStripButton.Enabled = False
        SupprimerEnteteToolStripButton.Enabled = False
        SupprimerVersionToolStripButton.Enabled = False
        ToolStripButtonMovefirst.Enabled = False
        ToolStripButtonMovePrevious.Enabled = False
        ToolStripButtonMoveNext.Enabled = False
        ToolStripButtonMoveLast.Enabled = False
        ToolStripLabelPosition.Enabled = False
        StockTextBox.Text = "0"
        Stock1TextBox.Text = "0"
        Stock2TextBox.Text = "0"


        RafraichissementLiensPhoto()
        RefreshChampsObligatoires()

    End Sub
    Private Sub NouveauGeneToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NouveauGeneToolStripButton.Click
        NouveauGene()
    End Sub

    Private Sub SupprimerEnteteToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SupprimerEnteteToolStripButton.Click
        If (gArticle_w And Not gArticle_OccazOnly) Or (gArticle_w And gArticle_OccazOnly And (T_Article_versionBindingSource.Current.item("occaz") Or T_Article_versionBindingSource.Current.item("depot_vente"))) Then

            Dim reponse As DialogResult = MessageBox.Show("Souhaitez vous vraiment supprimer cette entete d'article ainsi que tous les article s'y rattachant ?", "Attention", MessageBoxButtons.OKCancel, MessageBoxIcon.Question)
            If reponse = Windows.Forms.DialogResult.OK Then
                'suppression des images
                Dim client As New Utilities.FTP.FTPclient
                'Dim client As New FtpConnection
                client.Hostname = gFTP_host
                client.Username = gFTP_UID
                client.Password = gFTP_PWD

                'effacement des images
                'client.Connect()
                'If client.IsConnected Then

                'client.FtpDelete(gChemin_Vignette & "photo_modele_" & T_Article_EnteteBindingSource.Current.item("ID_T_article_entete") & ".jpg")


                'client.FtpDelete(gChemin_Vignette & "photo_big1_" & T_Article_EnteteBindingSource.Current.item("ID_T_article_entete") & ".jpg")


                'client.FtpDelete(gChemin_Vignette & "photo_big2_" & T_Article_EnteteBindingSource.Current.item("ID_T_article_entete") & ".jpg")


                'client.FtpDelete(gChemin_Vignette & "photo_big3_" & T_Article_EnteteBindingSource.Current.item("ID_T_article_entete") & ".jpg")

                'client.FtpDelete(gChemin_Vignette & "photo_mini1_" & T_Article_EnteteBindingSource.Current.item("ID_T_article_entete") & ".jpg")

                'client.FtpDelete(gChemin_Vignette & "photo_mini2_" & T_Article_EnteteBindingSource.Current.item("ID_T_article_entete") & ".jpg")

                'client.FtpDelete(gChemin_Vignette & "photo_mini3_" & T_Article_EnteteBindingSource.Current.item("ID_T_article_entete") & ".jpg")



                'End If
                'suppression des versions
                Dim idToDelete As Long = T_Article_EnteteBindingSource.Current.item("id_t_article_entete")



                T_Article_EnteteBindingSource.RemoveCurrent()
                ' T_Article_EnteteBindingSource.Remove(T_Article_EnteteBindingSource.Current)
                'Récupération des versions
                Dim vVersionsDt As DataTable = ExecuteRequeteR("select id_t_article_version from t_article_version where id_t_article_detail in (select id_t_article_detail from t_article_detail where id_t_article_entete=" & idToDelete & ")", gCnn.ConnectionString)

                Enregistrer()
                For Each dr As DataRow In vVersionsDt.Rows
                    'Supression de la combinaison dans PS
                    CliApi.ProductDeletePSCombinaisonfromCLIByIdAsync(New ToCliDto() With {.Id = dr("id_t_article_version")})
                Next

                'rafraichissement du moteur de recherche et repositionnement sur l'enregistrement
                RafraichissementDuMoteurDeRecherche()
                MajPosition()
                MessageBox.Show("Enregistrement(s) supprimé(s)", "CLI", MessageBoxButtons.OK, MessageBoxIcon.Information)
                'Fermer la form si dernier enregistrement
                If ToolStripLabelPosition.Text = "0/0" Then
                    Me.Close()
                End If
            End If
        Else
            MessageBox.Show("Désolé vous ne pouvez pas supprimer cet article. il n'est ni un article d'occasion, ni un article dépôt-vente.", "CLI", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

        End If

    End Sub

    Private Sub SupprimerVersionToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SupprimerVersionToolStripButton.Click
        If (gArticle_w And Not gArticle_OccazOnly) Or (gArticle_w And gArticle_OccazOnly And (T_Article_versionBindingSource.Current.item("occaz") Or T_Article_versionBindingSource.Current.item("depot_vente"))) Then

            Dim reponse As DialogResult = MessageBox.Show("Souhaitez vous vraiment supprimer cette version d'article ?", "Attention", MessageBoxButtons.OKCancel, MessageBoxIcon.Question)

            If reponse = Windows.Forms.DialogResult.OK Then
                'si derniere version également supprimer le detail avant
                '....
                Dim reader As SqlDataReader
                Dim cmd As New SqlClient.SqlCommand
                cmd.Connection = gCnn
                Dim previousConnectionState As ConnectionState = gCnn.State
                Try
                    If gCnn.State = ConnectionState.Closed Then
                        gCnn.Open()
                    End If
                    cmd.CommandText = "select count(*) as total from t_article_version where id_t_article_detail=" & T_Article_versionBindingSource.Current.item("id_t_article_detail")
                    reader = cmd.ExecuteReader()
                    Using reader
                        reader.Read()
                        If reader("total") = 1 Then
                            reader.Close()
                            'verification que le detail est le dernier enregistrement 
                            Dim reader2 As SqlDataReader
                            Dim cmd2 As New SqlClient.SqlCommand
                            cmd2.Connection = gCnn

                            Try

                                cmd2.CommandText = "select count(*) as total from t_article_detail where id_t_article_entete=" & T_Article_EnteteBindingSource.Current.item("id_t_article_entete")
                                reader2 = cmd2.ExecuteReader()
                                Using reader2
                                    reader2.Read()
                                    If reader2("total") = 1 Then
                                        'suppression des images
                                        'suppression des images
                                        Dim client As New Utilities.FTP.FTPclient
                                        'Dim client As New FtpConnection
                                        client.Hostname = gFTP_host
                                        client.Username = gFTP_UID
                                        client.Password = gFTP_PWD

                                        'effacement des images

                                        'client.Connect()
                                        'If client.IsConnected Then

                                        client.FtpDelete(gChemin_Vignette & "photo_modele_" & T_Article_EnteteBindingSource.Current.item("ID_T_article_entete") & ".jpg")


                                        client.FtpDelete(gChemin_Vignette & "photo_big1_" & T_Article_EnteteBindingSource.Current.item("ID_T_article_entete") & ".jpg")


                                        client.FtpDelete(gChemin_Vignette & "photo_big2_" & T_Article_EnteteBindingSource.Current.item("ID_T_article_entete") & ".jpg")


                                        client.FtpDelete(gChemin_Vignette & "photo_big3_" & T_Article_EnteteBindingSource.Current.item("ID_T_article_entete") & ".jpg")

                                        client.FtpDelete(gChemin_Vignette & "photo_mini1_" & T_Article_EnteteBindingSource.Current.item("ID_T_article_entete") & ".jpg")

                                        client.FtpDelete(gChemin_Vignette & "photo_mini2_" & T_Article_EnteteBindingSource.Current.item("ID_T_article_entete") & ".jpg")

                                        client.FtpDelete(gChemin_Vignette & "photo_mini3_" & T_Article_EnteteBindingSource.Current.item("ID_T_article_entete") & ".jpg")



                                        'End If
                                        T_Article_EnteteBindingSource.Remove(T_Article_EnteteBindingSource.Current)
                                    End If
                                End Using
                            Finally

                            End Try

                            T_Article_DetailBindingSource.Remove(T_Article_DetailBindingSource.Current)
                        End If
                    End Using
                Finally
                    If previousConnectionState = ConnectionState.Closed Then
                        gCnn.Close()
                    End If
                End Try


                Dim idToDelete As Long = T_Article_versionBindingSource.Current.item("id_t_article_version")
                T_Article_versionBindingSource.Remove(T_Article_versionBindingSource.Current)


                Enregistrer()
                'Supression de la combinaison dans PS
                CliApi.ProductDeletePSCombinaisonfromCLIByIdAsync(New ToCliDto() With {.Id = idToDelete})

                'rafraichissement du moteur de recherche et repositionnement sur l'enregistrement
                RafraichissementDuMoteurDeRecherche()
                MajPosition()
                MessageBox.Show("Enregistrement supprimé", "CLI", MessageBoxButtons.OK, MessageBoxIcon.Information)
                'Fermer la form si dernier enregistrement
                If ToolStripLabelPosition.Text = "0/0" Then
                    Me.Close()
                End If
            End If
        Else
            MessageBox.Show("Désolé vous ne pouvez pas supprimer cet article. il n'est ni un article d'occasion, ni un article dépôt-vente.", "CLI", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

        End If
    End Sub

    Private Sub CopierGeneToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CopierGeneToolStripButton.Click
        Dim col As DataColumn
        Dim courantVersion As CLIDataSet.T_Article_versionRow = Me.CLIDataSet.T_Article_version(T_Article_versionBindingSource.Position)
        CopieVersion = Me.CLIDataSet.T_Article_version.NewT_Article_versionRow

        For Each col In courantVersion.Table.Columns
            If UCase(col.ColumnName) <> "ID_T_ARTICLE_VERSION" And UCase(col.ColumnName) <> "CREELE" And UCase(col.ColumnName) <> "MODIFIELE" And UCase(col.ColumnName) <> "MODIFIEPAR" And UCase(col.ColumnName) <> "CREEPAR" Then

                CopieVersion.Item(col.ColumnName) = courantVersion.Item(col.ColumnName)
            End If
        Next
        Dim courantDetail As CLIDataSet.T_Article_DetailRow = Me.CLIDataSet.T_Article_Detail(T_Article_DetailBindingSource.Position)
        CopieDetail = Me.CLIDataSet.T_Article_Detail.NewT_Article_DetailRow
        For Each col In courantDetail.Table.Columns
            If UCase(col.ColumnName) <> "ID_T_ARTICLE_DETAIL" And UCase(col.ColumnName) <> "CREELE" And UCase(col.ColumnName) <> "MODIFIELE" And UCase(col.ColumnName) <> "MODIFIEPAR" And UCase(col.ColumnName) <> "CREEPAR" Then

                CopieDetail.Item(col.ColumnName) = courantDetail.Item(col.ColumnName)
            End If
        Next
        'Dim courantEntete As CLIDataSet.T_Article_EnteteRow = Me.CLIDataSet.T_Article_Entete(T_Article_EnteteBindingSource.Position)
        Dim courantEntete As CLIDataSet.T_Article_EnteteRow = Me.CLIDataSet.T_Article_Entete(0)

        CopieEntete = Me.CLIDataSet.T_Article_Entete.NewT_Article_EnteteRow
        For Each col In courantEntete.Table.Columns
            If UCase(col.ColumnName) <> "ID_T_ARTICLE_VERSION" And UCase(col.ColumnName) <> "CREELE" And UCase(col.ColumnName) <> "MODIFIELE" And UCase(col.ColumnName) <> "MODIFIEPAR" And UCase(col.ColumnName) <> "CREEPAR" And Not UCase(col.ColumnName).StartsWith("PHOTO") Then
                CopieEntete.Item(col.ColumnName) = courantEntete.Item(col.ColumnName)
            End If
        Next
        CollerToolStripButton.Enabled = True
        CollerInfoTechToolStripButton.Enabled = True
        CollerGeneToolStripButton.Enabled = True
    End Sub

    Private Sub CopierInfoTechToolStripButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles CopierInfoTechToolStripButton.Click
        Dim col As DataColumn
        Dim courantVersion As CLIDataSet.T_Article_versionRow = Me.CLIDataSet.T_Article_version(T_Article_versionBindingSource.Position)
        CopieVersion = Me.CLIDataSet.T_Article_version.NewT_Article_versionRow

        For Each col In courantVersion.Table.Columns
            If UCase(col.ColumnName) <> "ID_T_ARTICLE_VERSION" And UCase(col.ColumnName) <> "CREELE" And UCase(col.ColumnName) <> "MODIFIELE" And UCase(col.ColumnName) <> "MODIFIEPAR" And UCase(col.ColumnName) <> "CREEPAR" Then

                CopieVersion.Item(col.ColumnName) = courantVersion.Item(col.ColumnName)
            End If
        Next
        Dim courantDetail As CLIDataSet.T_Article_DetailRow = Me.CLIDataSet.T_Article_Detail(T_Article_DetailBindingSource.Position)
        CopieDetail = Me.CLIDataSet.T_Article_Detail.NewT_Article_DetailRow
        For Each col In courantDetail.Table.Columns
            If UCase(col.ColumnName) <> "ID_T_ARTICLE_DETAIL" And UCase(col.ColumnName) <> "CREELE" And UCase(col.ColumnName) <> "MODIFIELE" And UCase(col.ColumnName) <> "MODIFIEPAR" And UCase(col.ColumnName) <> "CREEPAR" Then

                CopieDetail.Item(col.ColumnName) = courantDetail.Item(col.ColumnName)
            End If
        Next
        CollerToolStripButton.Enabled = True
        CollerInfoTechToolStripButton.Enabled = True

    End Sub

    Private Sub CollerInfoTechToolStripButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles CollerInfoTechToolStripButton.Click
        Dim col As DataColumn
        Dim reponse As DialogResult = Windows.Forms.DialogResult.No
        Dim courantDetail As CLIDataSet.T_Article_DetailRow = Me.CLIDataSet.T_Article_Detail(0)
        For Each col In courantDetail.Table.Columns
            If UCase(col.ColumnName) <> "ID_T_ARTICLE_DETAIL" Then
                Me.CLIDataSet.T_Article_Detail(Me.CLIDataSet.T_Article_Detail.Rows.Count - 1).Item(col.ColumnName) = CopieDetail.Item(col.ColumnName)
            End If
        Next
        reponse = MessageBox.Show("Coller également les informations de Version ?", "Attention", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If reponse = Windows.Forms.DialogResult.Yes Then
            Dim courantVersion As CLIDataSet.T_Article_versionRow = Me.CLIDataSet.T_Article_version(0)
            For Each col In courantVersion.Table.Columns
                If UCase(col.ColumnName) <> "ID_T_ARTICLE_VERSION" Then
                    Me.CLIDataSet.T_Article_version(Me.CLIDataSet.T_Article_version.Rows.Count - 1).Item(col.ColumnName) = CopieVersion.Item(col.ColumnName)
                End If
            Next
        End If

    End Sub

    Private Sub CollerGeneToolStripButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles CollerGeneToolStripButton.Click
        Dim col As DataColumn
        Dim reponse As DialogResult = Windows.Forms.DialogResult.No



        Dim courantEntete As CLIDataSet.T_Article_EnteteRow = Me.CLIDataSet.T_Article_Entete(T_Article_EnteteBindingSource.Position)
        'Dim courantEntete As CLIDataSet.T_Article_EnteteRow = Me.CLIDataSet.T_Article_Entete(0)

        For Each col In courantEntete.Table.Columns
            If UCase(col.ColumnName) <> "ID_T_ARTICLE_ENTETE" Then
                Me.CLIDataSet.T_Article_Entete(Me.CLIDataSet.T_Article_Entete.Rows.Count - 1).Item(col.ColumnName) = CopieEntete.Item(col.ColumnName)
            End If
        Next

        'on ajuste la famille associée à la sous famille
        RemoveHandler FamilleComboBox.SelectedIndexChanged, AddressOf FamilleComboBox_SelectedIndexChanged
        FamilleComboBox.SelectedValue = ExecuteRequeteR("select id_t_famille from t_sousfamille where id_t_sousfamille=" & ID_t_sousfamilleComboBox.SelectedValue, My.Settings("CLIConnectionString")).Rows(0)("id_t_famille")
        AddHandler FamilleComboBox.SelectedIndexChanged, AddressOf FamilleComboBox_SelectedIndexChanged
        ID_t_sousfamilleComboBox_SelectedIndexChanged(sender, e)

        reponse = MessageBox.Show("Coller également les informations de Detail ?", "Attention", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If reponse = Windows.Forms.DialogResult.Yes Then
            Dim courantDetail As CLIDataSet.T_Article_DetailRow = Me.CLIDataSet.T_Article_Detail(T_Article_DetailBindingSource.Position)
            ' Dim courantDetail As CLIDataSet.T_Article_DetailRow = Me.CLIDataSet.T_Article_Detail(0)
            For Each col In courantDetail.Table.Columns
                If UCase(col.ColumnName) <> "ID_T_ARTICLE_DETAIL" Then
                    Me.CLIDataSet.T_Article_Detail(Me.CLIDataSet.T_Article_Detail.Rows.Count - 1).Item(col.ColumnName) = CopieDetail.Item(col.ColumnName)
                End If
            Next
            reponse = MessageBox.Show("Coller également les informations de Version ?", "Attention", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            If reponse = Windows.Forms.DialogResult.Yes Then
                Dim courantVersion As CLIDataSet.T_Article_versionRow = Me.CLIDataSet.T_Article_version(T_Article_versionBindingSource.Position)
                ' Dim courantVersion As CLIDataSet.T_Article_versionRow = Me.CLIDataSet.T_Article_version(0)
                For Each col In courantVersion.Table.Columns
                    If UCase(col.ColumnName) <> "ID_T_ARTICLE_VERSION" Then
                        Me.CLIDataSet.T_Article_version(Me.CLIDataSet.T_Article_version.Rows.Count - 1).Item(col.ColumnName) = CopieVersion.Item(col.ColumnName)
                    End If
                Next
            End If
        End If

    End Sub

    Private Sub SupprimerDetailToolStripButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles SupprimerDetailToolStripButton.Click
        If (gArticle_w And Not gArticle_OccazOnly) Or (gArticle_w And gArticle_OccazOnly And (T_Article_versionBindingSource.Current.item("occaz") Or T_Article_versionBindingSource.Current.item("depot_vente"))) Then

            Dim reponse As DialogResult = MessageBox.Show("Souhaitez vous vraiment supprimer cette fiche detail d'article ainsi que tous les article s'y rattachant ?", "Attention", MessageBoxButtons.OKCancel, MessageBoxIcon.Question)
            If reponse = Windows.Forms.DialogResult.OK Then
                'si dernier detail également supprimer l'entete  avant
                '....
                Dim reader As SqlDataReader
                Dim cmd As New SqlClient.SqlCommand
                cmd.Connection = gCnn
                Dim previousConnectionState As ConnectionState = gCnn.State
                Try
                    If gCnn.State = ConnectionState.Closed Then
                        gCnn.Open()
                    End If
                    cmd.CommandText = "select count(*) as total from t_article_detail where id_t_article_entete=" & T_Article_EnteteBindingSource.Current.item("id_t_article_entete")
                    reader = cmd.ExecuteReader()
                    Using reader
                        reader.Read()
                        If reader("total") = 1 Then
                            'suppression des images
                            'suppression des images
                            Dim client As New Utilities.FTP.FTPclient
                            'Dim client As New FtpConnection
                            client.Hostname = gFTP_host
                            client.Username = gFTP_UID
                            client.Password = gFTP_PWD

                            'effacement des images
                            ' client.Connect()
                            'If client.IsConnected Then

                            client.FtpDelete(gChemin_Vignette & "photo_modele_" & T_Article_EnteteBindingSource.Current.item("ID_T_article_entete") & ".jpg")


                            client.FtpDelete(gChemin_Vignette & "photo_big1_" & T_Article_EnteteBindingSource.Current.item("ID_T_article_entete") & ".jpg")


                            client.FtpDelete(gChemin_Vignette & "photo_big2_" & T_Article_EnteteBindingSource.Current.item("ID_T_article_entete") & ".jpg")


                            client.FtpDelete(gChemin_Vignette & "photo_big3_" & T_Article_EnteteBindingSource.Current.item("ID_T_article_entete") & ".jpg")

                            client.FtpDelete(gChemin_Vignette & "photo_mini1_" & T_Article_EnteteBindingSource.Current.item("ID_T_article_entete") & ".jpg")

                            client.FtpDelete(gChemin_Vignette & "photo_mini2_" & T_Article_EnteteBindingSource.Current.item("ID_T_article_entete") & ".jpg")

                            client.FtpDelete(gChemin_Vignette & "photo_mini3_" & T_Article_EnteteBindingSource.Current.item("ID_T_article_entete") & ".jpg")



                            'End If
                            T_Article_EnteteBindingSource.Remove(T_Article_EnteteBindingSource.Current)
                        End If
                    End Using
                Finally
                    If previousConnectionState = ConnectionState.Closed Then
                        gCnn.Close()
                    End If
                End Try


                Dim idToDelete As Long = T_Article_DetailBindingSource.Current.item("id_t_article_detail")
                T_Article_DetailBindingSource.Remove(T_Article_DetailBindingSource.Current)
                Dim dt As DataTable = ExecuteRequeteR("select id_t_article_version from t_article_version where id_t_article_detail=" & idToDelete, My.Settings("CLIConnectionString"))
                Enregistrer()
                'Récupération des versions à supprimer

                For Each dr As DataRow In dt.Rows
                    'Supression de la combinaison dans PS
                    CliApi.ProductDeletePSCombinaisonfromCLIByIdAsync(New ToCliDto() With {.Id = dr("id_t_article_version")})
                Next
                'rafraichissement du moteur de recherche et repositionnement sur l'enregistrement
                RafraichissementDuMoteurDeRecherche()
                MajPosition()
                MessageBox.Show("Enregistrement(s) supprimé(s)", "CLI", MessageBoxButtons.OK, MessageBoxIcon.Information)
                'Fermer la form si dernier enregistrement
                If ToolStripLabelPosition.Text = "0/0" Then
                    Me.Close()
                End If
            End If
        Else
            MessageBox.Show("Désolé vous ne pouvez pas supprimer cet article. il n'est ni un article d'occasion, ni un article dépôt-vente.", "CLI", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

        End If
    End Sub

    Private Sub NouveauTechToolStripButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles NouveauTechToolStripButton.Click

        T_Article_DetailBindingSource.AddNew()
        T_Article_DetailBindingSource.EndEdit()
        T_Article_versionBindingSource.AddNew()
        T_Article_versionBindingSource.EndEdit()
        BT_Inventaire.Enabled = False
        BT_MajStock.Enabled = False
        BT_CodeBarre.Enabled = False
        BT_CodeBarrePrix.Enabled = False
        BT_BonDepotVente.Enabled = False
        BT_NewDepot.Enabled = False
        BT_NewReprise.Enabled = False
        NouveauGeneToolStripButton.Enabled = False
        NouveauTechToolStripButton.Enabled = False
        NouveauToolStripButton.Enabled = False
        SupprimerDetailToolStripButton.Enabled = False
        SupprimerEnteteToolStripButton.Enabled = False
        SupprimerVersionToolStripButton.Enabled = False
        ToolStripButtonMovefirst.Enabled = False
        ToolStripButtonMovePrevious.Enabled = False
        ToolStripButtonMoveNext.Enabled = False
        ToolStripButtonMoveLast.Enabled = False
        ToolStripLabelPosition.Enabled = False

        StockTextBox.Text = "0"
        Stock1TextBox.Text = "0"
        Stock2TextBox.Text = "0"
        'gestion des listes déroulantes de la page
        ProgrammeComboBox.SelectedIndex = -1
        TypeComboBox.SelectedIndex = -1
        TailleComboBox.SelectedIndex = -1
        BoitierComboBox.SelectedIndex = -1
        CarboneComboBox.SelectedIndex = -1
        FoilBoitierComboBox.SelectedIndex = -1
        LibelleComboBox.SelectedIndex = -1




    End Sub

    Public Sub MajStock(ByVal id_t_article_version As Integer)

        Dim bActive As Boolean = False
        Dim cnn As New SqlClient.SqlConnection(My.Settings.CLIConnectionString)
        cnn.Open()
        Dim command As New SqlClient.SqlCommand
        command.CommandText = "select active_on from t_article_version where ID_t_article_version=" & id_t_article_version
        command.Connection = cnn
        Dim reader As SqlClient.SqlDataReader = command.ExecuteReader
        If reader.HasRows Then
            reader.Read()
            If reader("active_on") = True Then
                bActive = True
            Else
                bActive = False
            End If



        End If

        reader.Close()
        cnn.Close()
        If Not bActive Then
            MessageBox.Show("Impossible de mettre du stock sur un article désactivé !", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If

        'suppression de la notion de site
        Dim site As String = 1
        'site = InputBox("Indiquer le site pour l'inventaire",, gNumCaisse)
        'If Not IsNumeric(site) Then
        '    Return
        'End If
        'If site <> 1 And site <> 2 Then
        '    Return
        'End If

        Dim reponse As String
        Dim Transaction As Double
        Dim stock_actuel As Double
        reponse = InputBox("Indiquez quantité prélevée ou rentrée en stock pour cet article")
        If IsNumeric(reponse) Then
            Transaction = reponse

            cnn = New SqlClient.SqlConnection(My.Settings.CLIConnectionString)
            cnn.Open()

            command.CommandText = "select * from v_article_stock where ID_t_article_version=" & id_t_article_version
            'command.CommandText = "select * from v_article_stock_numcaisse where ID_t_article_version=" & id_t_article_version & " and numcaisse=" & site

            command.Connection = cnn
            reader = command.ExecuteReader
            If reader.HasRows Then
                reader.Read()
                If IsNumeric(reader("stock")) Then
                    stock_actuel = reader("stock")
                Else
                    stock_actuel = 0
                End If
            End If
            reader.Close()

            If stock_actuel + Transaction < 0 Then
                MessageBox.Show("Le stock passe en négatif !", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                ' MessageBox.Show("Le stock passe en négatif sur le site " & site & " !", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)

            End If
            command.CommandText = "INSERT INTO T_Article_Stock (id_t_article_version,operation,date,signature,numcaisse) VALUES (" & id_t_article_version & "," & Replace(Transaction, ",", ".") & ",getdate(),'" & gLogin & "'," & site & ")"
            command.ExecuteNonQuery()
            command.CommandText = "update t_article_version set exportfile= null,modifiele=getdate(),modifiepar='" & gLogin & "' where id_t_article_version=" & id_t_article_version
            command.ExecuteNonQuery()
            cnn.Close()
            If id_t_article_version > 0 Then

                Me.V_Article_StockTableAdapter.FillByIdTArticleVersion(Me.CLIDataSet.V_Article_Stock, id_t_article_version)
                Me.V_Article_Stock_numcaisse1TableAdapter1.FillByIdTArticleVersionNumCaisse(Me.CLIDataSet.V_Article_Stock_numcaisse1, id_t_article_version)
                Me.V_Article_Stock_numcaisse2TableAdapter1.FillByIdTArticleVersionNumCaisse(Me.CLIDataSet.V_Article_Stock_numcaisse2, id_t_article_version)
            Else

                Me.V_Article_StockTableAdapter.Fill(Me.CLIDataSet.V_Article_Stock)
                Me.V_Article_Stock_numcaisse1TableAdapter1.Fill(Me.CLIDataSet.V_Article_Stock_numcaisse1)
                Me.V_Article_Stock_numcaisse2TableAdapter1.Fill(Me.CLIDataSet.V_Article_Stock_numcaisse2)
            End If
            CliApi.ProductUpdatePSStockfromCLIByIdAsync(New ToCliDto() With {.Id = id_t_article_version, .AssociatedAddress = False, .AssociatedCartRule = False})
            RafraichissementDuMoteurDeRecherche()

        End If
    End Sub
    Private Sub BT_MajStock_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BT_MajStock.Click
        MajStock(ID_t_article_versionTextBox.Text)
    End Sub

    Private Sub ID_t_sousfamilleComboBox_DropDown(ByVal sender As Object, ByVal e As System.EventArgs) Handles ID_t_sousfamilleComboBox.DropDown
        Me.T_SousFamilleTableAdapter.FillByID_T_Famille(Me.CLIDataSet.T_SousFamille, TFamilleBindingSource.Current.item("ID_T_Famille"))

    End Sub

    Private Sub ID_t_sousfamilleComboBox_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles ID_t_sousfamilleComboBox.GotFocus
        AddHandler ID_t_sousfamilleComboBox.SelectedIndexChanged, AddressOf ID_t_sousfamilleComboBox_SelectedIndexChanged
    End Sub

    Private Sub ID_t_sousfamilleComboBox_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles ID_t_sousfamilleComboBox.Leave
        RemoveHandler ID_t_sousfamilleComboBox.SelectedIndexChanged, AddressOf ID_t_sousfamilleComboBox_SelectedIndexChanged
    End Sub

    Private Sub ID_t_sousfamilleComboBox_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) ' Handles ID_t_sousfamilleComboBox.SelectedIndexChanged
        T_Article_EnteteBindingSource.EndEdit()
        RefreshChampsObligatoires()
        If Not T_Article_DetailBindingSource.Current Is Nothing And Not T_Article_EnteteBindingSource.Current Is Nothing And Not T_Article_versionBindingSource.Current Is Nothing Then
            RefreshListesDeroulantes()
        End If

    End Sub

    Private Sub FamilleComboBox_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FamilleComboBox.SelectedIndexChanged
        ID_t_sousfamilleComboBox.SelectedIndex = -1

    End Sub

    Private Sub Photo_voir(ByVal pChamp As String)
        Dim f As New FormPhoto
        Dim im As Image
        Dim s As New Size

        f.MdiParent = Me.MdiParent
        f.Show()

        If My.Computer.FileSystem.FileExists(gChemin_local_vignette & T_Article_EnteteBindingSource.Current.item(pChamp)) Then
            My.Computer.FileSystem.DeleteFile(gChemin_local_vignette & T_Article_EnteteBindingSource.Current.item(pChamp))
        End If

        Dim client As New Utilities.FTP.FTPclient
        'Dim client As New FtpConnection
        client.Hostname = gFTP_host
        client.Username = gFTP_UID
        client.Password = gFTP_PWD

        'client.Connect()
        'If client.IsConnected Then

        If client.Download(gChemin_Vignette & T_Article_EnteteBindingSource.Current.item(pChamp), gChemin_local_vignette & T_Article_EnteteBindingSource.Current.item(pChamp), True) Then
            im = Image.FromFile(gChemin_local_vignette & T_Article_EnteteBindingSource.Current.item(pChamp))
            f.PictureBox1.Image = New Bitmap(im)
            im.Dispose()
            im = Nothing
            s.Width = f.PictureBox1.Size.Width
            s.Height = f.PictureBox1.Size.Height + 20
            f.Size = s


        End If

        'client.Disconnect()
        'End If
    End Sub
    Private Sub LinkLabelPhotoGerer_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabelPhotoGerer.LinkClicked
        Dim images As List(Of ImageData) = New List(Of ImageData)
        Dim vDefault As List(Of Object) = New List(Of Object)
        vDefault.Add(0)
        Dim ret As Boolean = CliApi.ProductGetImagesPSfromCLIByIdAsync(New ToCliDto() With {.Id = id_t_article_version, .AssociatedAddress = False, .AssociatedCartRule = False}, images)
        If ret Then
            CliApi.ProductGetProductDefaultImageIdAsync(New ToCliDto() With {.Id = id_t_article_version, .AssociatedAddress = False, .AssociatedCartRule = False}, vDefault)
            Dim formListImage As New FormListImage()
            formListImage._imageList = images
            formListImage._imageToAddList = vImageToAddList
            formListImage._imageToDeleteList = vImageToDeleteList
            If vDefault.Count > 0 Then
                formListImage._defaultImage = vDefault(0)
            End If

            formListImage.ShowDialog()
            vImageToAddList = formListImage._imageToAddList
            vImageToDeleteList = formListImage._imageToDeleteList
            vDefaultImageId = formListImage._defaultImage
            'Photo_voir("photo_modele")
        End If

    End Sub





    Private Sub Supprimer_PhotoModele(ByVal lLinkLabel As LinkLabel, ByVal lTextbox As TextBox)
        lTextbox.Text = ""
        lLinkLabel.Tag = ""
        lLinkLabel.LinkColor = Color.Blue
    End Sub
    Private Sub Supprimer_Photo(ByVal lLinkLabel As LinkLabel, ByVal lTextbox As TextBox, ByVal lTextbox1 As TextBox)
        lTextbox.Text = ""
        lTextbox1.Text = ""
        lLinkLabel.Tag = ""
        lLinkLabel.LinkColor = Color.Blue
    End Sub



    Private Sub RafraichissementLiensPhoto()








        vImageToAddList = New List(Of ImageData)
        vImageToDeleteList = New List(Of Long)
        vDefaultImageId = 0

    End Sub



    Private Sub RemiseTextBox_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles RemiseTextBox.Enter
        If IsNumeric(sender.text) Then
            Remise = sender.text
        End If
    End Sub
    Private Sub RemiseFournisseurTextBox_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles Remise_FournisseurTextBox.Enter
        If IsNumeric(sender.text) Then
            Remise_Fournisseur = sender.text
        End If
    End Sub


    Private Sub RemiseTextBox_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RemiseTextBox.TextChanged, Remise_FournisseurTextBox.TextChanged

    End Sub











    Private Sub Prix_vente_remise_TTCTextBox_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles Prix_vente_remise_TTCTextBox.Enter, prix_remise_fournisseurTextBox.Enter
        If IsNumeric(sender.text) Then
            PrixRemiseTTC = sender.text
        End If
    End Sub



    Private Sub Prix_vente_remise_TTCTextBox_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Prix_vente_remise_TTCTextBox.Validated
        If RemiseTextBox.Text = "" Or RemiseTextBox.Text = "0.00" Then
            Prix_vente_remise_TTCTextBox.Text = Prix_vente_initial_TTCTextBox.Text
        End If
        If IsNumeric(Prix_vente_remise_TTCTextBox.Text) Then
            If PrixRemiseTTC <> Prix_vente_remise_TTCTextBox.Text Then
                If IsNumeric(Prix_vente_initial_TTCTextBox.Text) Then
                    If Prix_vente_initial_TTCTextBox.Text <> 0 Then
                        RemiseTextBox.Text = Math.Round(1 - (Prix_vente_remise_TTCTextBox.Text / Prix_vente_initial_TTCTextBox.Text), 4)
                    Else
                        RemiseTextBox.Text = 0
                    End If
                End If
            End If
        End If
    End Sub
    Private Sub PrixFournisseurremise_TTCTextBox_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles prix_remise_fournisseurTextBox.Validated
        If Remise_FournisseurTextBox.Text = "" Or Remise_FournisseurTextBox.Text = "0.00" Then
            prix_remise_fournisseurTextBox.Text = Prix_fournisseurTextBox.Text
        End If
        If IsNumeric(prix_remise_fournisseurTextBox.Text) Then
            If PrixFournisseurRemise <> prix_remise_fournisseurTextBox.Text Then
                If IsNumeric(Prix_fournisseurTextBox.Text) Then
                    If Prix_fournisseurTextBox.Text <> 0 Then
                        Remise_FournisseurTextBox.Text = Math.Round(1 - (prix_remise_fournisseurTextBox.Text / Prix_fournisseurTextBox.Text), 4)
                    Else
                        Remise_FournisseurTextBox.Text = 0
                    End If
                End If
            End If
        End If
    End Sub


    Private Sub Prix_vente_initial_TTCTextBox_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles Prix_vente_initial_TTCTextBox.Enter
        If IsNumeric(sender.text) Then
            PrixInitialTTC = sender.text
        End If
    End Sub



    Private Sub Prix_vente_initial_TTCTextBox_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Prix_vente_initial_TTCTextBox.Validated
        If IsNumeric(Prix_vente_initial_TTCTextBox.Text) Then
            If PrixInitialTTC <> Prix_vente_initial_TTCTextBox.Text Then
                If IsNumeric(RemiseTextBox.Text) Then
                    Prix_vente_remise_TTCTextBox.Text = Math.Round(Prix_vente_initial_TTCTextBox.Text * (1 - RemiseTextBox.Text), 2)
                End If
            End If
        End If
    End Sub

    Private Sub PrixFournisseurTextBox_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Prix_fournisseurTextBox.Validated
        If IsNumeric(Prix_fournisseurTextBox.Text) Then
            If PrixFournisseur <> Prix_fournisseurTextBox.Text Then
                If IsNumeric(Remise_FournisseurTextBox.Text) Then
                    prix_remise_fournisseurTextBox.Text = Math.Round(Prix_fournisseurTextBox.Text * (1 - Remise_FournisseurTextBox.Text), 2)
                End If
            End If
        End If
    End Sub


    Private Sub RemiseTextBox_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles RemiseTextBox.Validated
        If Remise.ToString <> RemiseTextBox.Text Then
            Prix_vente_remise_TTCTextBox.Text = Math.Round(Prix_vente_initial_TTCTextBox.Text * (1 - RemiseTextBox.Text), 2)
        End If
    End Sub

    Private Sub RemiseFournisseurTextBox_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Remise_FournisseurTextBox.Validated
        If Remise_Fournisseur.ToString <> Remise_FournisseurTextBox.Text Then
            prix_remise_fournisseurTextBox.Text = Math.Round(Prix_fournisseurTextBox.Text * (1 - Remise_FournisseurTextBox.Text), 2)
        End If
    End Sub

    Private Sub BT_Description_Auto_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BT_Description_Auto.Click
        'If Trim(Description_Auto(FamilleComboBox.Text, ID_t_sousfamilleComboBox.Text)) <> "" Then
        '    Description_panierTextBox.Focus()
        '    Description_panierTextBox.Text = Description_Auto(FamilleComboBox.Text, ID_t_sousfamilleComboBox.Text)

        'End If
        Description_panierTextBox.Text = Description_Auto()
    End Sub
    Public Function Description_Auto() As String
        'construction de la description auto differente en fonction du rayon
        Dim chaine_retour As String = ""
        Dim famille_libelle As String = ""
        Dim sousfamille_libelle As String = ""
        Dim famille_id As Integer = 0
        Dim masque As String = ""
        Dim TabMasque As Array
        Dim descriptiontemp
        Dim dt As DataTable = ExecuteRequeteR("select description_panier,libelle,id_t_famille from t_sousfamille where id_t_sousfamille=" & T_Article_EnteteBindingSource.Current.item("id_t_sousfamille").ToString, My.Settings.CLIConnectionString)
        If dt.Rows.Count > 0 Then
            masque = dt.Rows(0)("description_panier").ToString
            sousfamille_libelle = dt.Rows(0)("libelle").ToString
            famille_id = dt.Rows(0)("id_t_famille").ToString
        End If
        dt = ExecuteRequeteR("select libelle from t_famille where id_t_famille=" & famille_id, My.Settings.CLIConnectionString)
        If dt.Rows.Count > 0 Then
            famille_libelle = dt.Rows(0)("libelle").ToString
        End If

        'découpage du masque

        TabMasque = masque.Split("+")
        masque = ""
        descriptiontemp = ""
        For i As Integer = 0 To TabMasque.Length - 1
            'Cas d'un champ
            If TabMasque(i).ToString.StartsWith("<") And TabMasque(i).ToString.EndsWith(">") Then
                descriptiontemp = Description_champValeur(TabMasque(i).ToString.Substring(1, TabMasque(i).ToString.Length - 2), famille_libelle, sousfamille_libelle)
                If masque = "" Then
                    masque = descriptiontemp
                Else
                    If descriptiontemp <> "" Then
                        masque = masque & " " & descriptiontemp
                    End If

                End If

            End If
            'Cas d'un texte libre
            If TabMasque(i).ToString.StartsWith("""") And TabMasque(i).ToString.EndsWith("""") Then
                If (T_Article_versionBindingSource.Current.item("occaz").ToString = "True" Or T_Article_versionBindingSource.Current.item("depot_vente").ToString = "True") And TabMasque(i).ToString.Substring(1, TabMasque(i).ToString.Length - 2) = "occasion" Then
                    If masque = "" Then
                        masque = TabMasque(i).ToString.Substring(1, TabMasque(i).ToString.Length - 2)
                    Else
                        masque = masque & " " & TabMasque(i).ToString.Substring(1, TabMasque(i).ToString.Length - 2)
                    End If
                Else
                    If T_Article_versionBindingSource.Current.item("test").ToString = "True" And TabMasque(i).ToString.Substring(1, TabMasque(i).ToString.Length - 2) = "test" Then
                        If masque = "" Then
                            masque = TabMasque(i).ToString.Substring(1, TabMasque(i).ToString.Length - 2)
                        Else
                            masque = masque & " " & TabMasque(i).ToString.Substring(1, TabMasque(i).ToString.Length - 2).ToUpper
                        End If
                    Else

                        If TabMasque(i).ToString.Substring(1, TabMasque(i).ToString.Length - 2) <> "occasion" And TabMasque(i).ToString.Substring(1, TabMasque(i).ToString.Length - 2) <> "test" Then
                            If masque = "" Then
                                masque = TabMasque(i).ToString.Substring(1, TabMasque(i).ToString.Length - 2)
                            Else
                                masque = masque & " " & TabMasque(i).ToString.Substring(1, TabMasque(i).ToString.Length - 2)
                            End If
                        End If
                    End If


                End If


            End If
        Next

        Description_Auto = masque

    End Function
    Public Function Description_champValeur(ByVal champ As String, ByVal famille As String, ByVal sousfamille As String) As String
        Description_champValeur = ""
        Select Case champ.ToUpper
            Case "FAMILLE"
                Description_champValeur = famille
            Case "SOUSFAMILLE"
                Description_champValeur = sousfamille

            Case Else
                'on determine de quel binding source il vient et on retourne sa valeur
                For Each c As DataColumn In T_Article_EnteteBindingSource.Current.row.table.columns
                    If c.ColumnName.ToUpper = champ.ToUpper Then
                        Description_champValeur = T_Article_EnteteBindingSource.Current.item(champ).ToString

                        Return Description_champValeur
                    End If
                Next
                For Each c As DataColumn In T_Article_DetailBindingSource.Current.row.table.columns
                    If c.ColumnName.ToUpper = champ.ToUpper Then
                        Description_champValeur = T_Article_DetailBindingSource.Current.item(champ).ToString.Trim
                        Select Case champ.ToUpper
                            Case "RDM"
                                Return IIf(Description_champValeur, "RDM", "SDM")
                            Case Else
                                Return Description_champValeur

                        End Select
                    End If
                Next
                For Each c As DataColumn In T_Article_versionBindingSource.Current.row.table.columns
                    If c.ColumnName.ToUpper = champ.ToUpper Then
                        Description_champValeur = T_Article_versionBindingSource.Current.item(champ).ToString

                        Return Description_champValeur




                    End If
                Next


        End Select


    End Function
    'Public Function Description_Auto_old(ByVal famille As String, ByVal sousfamille As String) As String
    '    'construction de la description auto differente en fonction du rayon
    '    Dim chaine_retour As String = ""
    '    Select Case famille
    '        Case "Windsurf"
    '            Select Case sousfamille
    '                Case "Flotteurs"
    '                    chaine_retour = Trim(MarqueTextBox.Text & " " & ModeleTextBox.Text & " " & VolumeTextBox.Text & " " & AnneeTextBox.Text & " " & LibelleTextBox.Text)
    '                Case "Voiles"
    '                    chaine_retour = Trim(MarqueTextBox.Text & " " & ModeleTextBox.Text & " " & SurfaceTextBox.Text & " m² " & AnneeTextBox.Text & " " & LibelleTextBox.Text)
    '                Case "Mâts"
    '                    chaine_retour = Trim(MarqueTextBox.Text & " " & ModeleTextBox.Text & " " & TailleTextBox.Text & " " & AnneeTextBox.Text & " " & LibelleTextBox.Text)
    '                Case "Wish"
    '                    chaine_retour = Trim(MarqueTextBox.Text & " " & ModeleTextBox.Text & " " & Size_minTextBox.Text & "/" & Size_maxTextBox.Text & " " & AnneeTextBox.Text & " " & LibelleTextBox.Text)
    '                Case "Ailerons"
    '                    chaine_retour = Trim(MarqueTextBox.Text & " " & ModeleTextBox.Text & " " & TailleTextBox.Text & " " & AnneeTextBox.Text & " " & LibelleTextBox.Text)
    '                Case "Harnais"
    '                    chaine_retour = Trim(MarqueTextBox.Text & " " & ModeleTextBox.Text & " " & TailleTextBox.Text & " " & AnneeTextBox.Text & " " & LibelleTextBox.Text)
    '                Case "Bagagerie"
    '                    chaine_retour = Trim(MarqueTextBox.Text & " " & ModeleTextBox.Text & " " & AnneeTextBox.Text & " " & LibelleTextBox.Text)

    '            End Select
    '        Case "Kitesurf"
    '            Select Case sousfamille
    '                Case "Flotteurs"
    '                    chaine_retour = Trim(MarqueTextBox.Text & " " & ModeleTextBox.Text & " " & LongueurTextBox.Text & "x" & LargeurTextBox.Text & " " & AnneeTextBox.Text & " " & LibelleTextBox.Text)
    '                Case "Ailes"
    '                    chaine_retour = Trim(MarqueTextBox.Text & " " & ModeleTextBox.Text & " " & TypeTextBox.Text & " " & SurfaceTextBox.Text & " m² " & AnneeTextBox.Text & " " & LibelleTextBox.Text)
    '                Case "Harnais"
    '                    chaine_retour = Trim(MarqueTextBox.Text & " " & ModeleTextBox.Text & " " & TailleTextBox.Text & " " & AnneeTextBox.Text & " " & LibelleTextBox.Text)
    '                Case "Bagagerie"
    '                    chaine_retour = Trim(MarqueTextBox.Text & " " & ModeleTextBox.Text & " " & AnneeTextBox.Text & " " & LibelleTextBox.Text)

    '            End Select
    '    End Select

    '    Description_Auto_old = chaine_retour

    'End Function


    Private Function NbEnregistrementsEntete(ByVal id_t_article_entete As String) As Integer

        If IsNumeric(id_t_article_entete) Then

            Dim cnn As New SqlClient.SqlConnection(My.Settings.CLIConnectionString)
            cnn.Open()
            Dim command As New SqlClient.SqlCommand

            command.CommandText = "SELECT COUNT(T_Article_version.ID_t_article_version) AS total FROM T_Article_Detail INNER JOIN T_Article_Entete ON T_Article_Detail.ID_t_article_entete = T_Article_Entete.ID_t_article_entete INNER JOIN T_Article_version ON T_Article_Detail.ID_t_article_detail = T_Article_version.ID_t_article_detail " _
    & "GROUP BY T_Article_Entete.ID_t_article_entete" _
    & " HAVING(T_Article_Entete.ID_t_article_entete = " & id_t_article_entete & ")"

            command.Connection = cnn
            Dim reader As SqlClient.SqlDataReader = command.ExecuteReader
            If reader.HasRows Then
                reader.Read()
                If reader("total").ToString <> "" Then
                    Return reader("total")
                Else
                    Return 0
                End If

            End If
            reader.Close()
            cnn.Close()
        Else
            Return 0
        End If


    End Function
    Private Function NbEnregistrementsDetail(ByVal id_t_article_detail As String) As Integer

        If IsNumeric(id_t_article_detail) Then

            Dim cnn As New SqlClient.SqlConnection(My.Settings.CLIConnectionString)
            cnn.Open()
            Dim command As New SqlClient.SqlCommand

            command.CommandText = "SELECT COUNT(T_Article_version.ID_t_article_version) AS total FROM  T_Article_Detail INNER JOIN T_Article_version ON T_Article_Detail.ID_t_article_detail = T_Article_version.ID_t_article_detail " _
    & "GROUP BY T_Article_detail.ID_t_article_detail" _
    & " HAVING(T_Article_detail.ID_t_article_detail = " & id_t_article_detail & ")"

            command.Connection = cnn
            Dim reader As SqlClient.SqlDataReader = command.ExecuteReader
            If reader.HasRows Then
                reader.Read()
                If reader("total").ToString <> "" Then
                    Return reader("total")
                Else
                    Return 0
                End If

            End If
            reader.Close()
            cnn.Close()
        Else
            Return 0
        End If


    End Function
    Sub MajNbEnregistrements()
        LabelNbEntete.Text = String.Format("{0} enregistrement(s) utilisent ces infos générales", NbEnregistrementsEntete(T_Article_EnteteBindingSource.Current.item("id_t_article_entete").ToString))
        LabelNbDetail.Text = String.Format("{0} enregistrement(s) utilisent ces infos techniques", NbEnregistrementsDetail(T_Article_DetailBindingSource.Current.item("id_t_article_detail").ToString))
    End Sub



    Private Sub LabelNbEntete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LabelNbEntete.Click
        FormArticleRecherche.Recherche(False, False, T_Article_EnteteBindingSource.Current.item("id_t_article_entete").ToString())
        id_t_article_version = FormArticleRecherche.bs.Current.Item("Ref")
        Refresh_data()
    End Sub

    Private Sub LabelNbDetail_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LabelNbDetail.Click
        FormArticleRecherche.Recherche(False, False, , T_Article_DetailBindingSource.Current.item("id_t_article_detail").ToString())
        id_t_article_version = FormArticleRecherche.bs.Current.Item("Ref")
        Refresh_data()
    End Sub

    Private Sub BT_CodeBarre_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BT_CodeBarre.Click
        Dim DymoAddIn As New Dymo.DymoAddIn
        Dim DymoLabels As New Dymo.DymoLabels
        Dim reponse As String = InputBox("Combien d'étiquettes souhaitez-vous imprimer ?", "Nombre d'étiquettes à imprimer", 1)
        If IsNumeric(reponse) Then
            If reponse > 0 Then
                DymoAddIn.Open(Application.StartupPath & "\11354CodeBarre.label")
                If T_Article_versionBindingSource.Current.item("description_panier").ToString.Length >= 30 Then
                    DymoLabels.SetField("DESCRIPTION", T_Article_versionBindingSource.Current.item("description_panier").ToString.Substring(0, 30) & vbCrLf & T_Article_versionBindingSource.Current.item("description_panier").ToString.Substring(30))
                Else
                    DymoLabels.SetField("DESCRIPTION", T_Article_versionBindingSource.Current.item("description_panier").ToString)
                End If

                DymoLabels.SetField("CODE-BARRES", T_Article_versionBindingSource.Current.item("id_t_article_version").ToString)
                DymoAddIn.SelectPrinter(gNomImprimanteEtiquette)
                DymoAddIn.Print2(reponse, False, 2)

            End If
        End If


    End Sub
    Private Sub BT_CodeBarrePrix_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BT_CodeBarrePrix.Click
        Dim DymoAddIn As New Dymo.DymoAddIn
        Dim DymoLabels As New Dymo.DymoLabels

        Dim reponse As String = InputBox("Combien d'étiquettes souhaitez-vous imprimer ?", "Nombre d'étiquettes à imprimer", 1)

        If IsNumeric(reponse) Then
            If reponse > 0 Then
                DymoAddIn.Open(Application.StartupPath & "\11354CodeBarrePrix.label")
                If T_Article_versionBindingSource.Current.item("description_panier").ToString.Length >= 30 Then
                    DymoLabels.SetField("DESCRIPTION", T_Article_versionBindingSource.Current.item("description_panier").ToString.Substring(0, 30) & vbCrLf & T_Article_versionBindingSource.Current.item("description_panier").ToString.Substring(30))
                Else
                    DymoLabels.SetField("DESCRIPTION", T_Article_versionBindingSource.Current.item("description_panier").ToString)
                End If
                DymoLabels.SetField("CODE-BARRES", T_Article_versionBindingSource.Current.item("id_t_article_version").ToString)
                DymoLabels.SetField("PRIX", Math.Round(T_Article_versionBindingSource.Current.item("prix_vente_remise_TTC"), 2) & " €")
                If T_Article_versionBindingSource.Current.item("prix_vente_remise_TTC").ToString <> T_Article_versionBindingSource.Current.item("prix_vente_initial_TTC").ToString Then
                    DymoLabels.SetField("PrixBarre", Math.Round(T_Article_versionBindingSource.Current.item("prix_vente_initial_TTC"), 2) & " €")
                    DymoLabels.SetField("Remise", "- " & T_Article_versionBindingSource.Current.item("Remise") * 100 & " %")

                Else
                    DymoLabels.SetField("PrixBarre", "")
                    DymoLabels.SetField("Remise", "")


                End If
                DymoAddIn.SelectPrinter(gNomImprimanteEtiquette)
                DymoAddIn.Print2(reponse, False, 2)

            End If
        End If

    End Sub

    Private Sub LinkLabelTransactionStock_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabelTransactionStock.LinkClicked
        'on affiche la fenetre d'historique des transactions de stock


        Dim f As New FormHistoriqueTransactionsStock
        f.vId = T_Article_versionBindingSource.Current.item("id_t_article_version").ToString
        f.MdiParent = Me.MdiParent

        f.Show()

    End Sub

    Private Sub Prix_vente_initial_TTCTextBox_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Prix_vente_initial_TTCTextBox.TextChanged

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        CheckClient()
        CheckFournisseur()
    End Sub
    Function CheckClient() As Boolean
        Dim T_ClientTableAdapter As New CLIDataSetTableAdapters.T_ClientTableAdapter
        Dim T_Client As New CLIDataSet.T_ClientDataTable

        'verification qu'un numéro de client est saisi
        If (ID_T_ClientTextBox.Text <> "" And ID_T_ClientTextBox.Text <> "0") Then
            T_ClientTableAdapter.FillByid_t_client(T_Client, ID_T_ClientTextBox.Text)
            'on efface le code fournisseur 
            ID_T_FournisseurTextBox.Text = "0"

            'verification que le numero d'avoir existe
            If T_Client.Count > 0 Then
                'verification que le client n'est pas inactif
                If T_Client.Rows(0)("actif") Then
                    SocieteNomPrenomTextBox.Text = T_Client.Rows(0)("Société").ToString & " " & T_Client.Rows(0)("Nom").ToString & " " & T_Client.Rows(0)("Prenom").ToString
                    CheckClient = True

                Else
                    CheckClient = False
                    ID_T_ClientTextBox.Focus()
                    ID_T_ClientTextBox.Text = 0
                    SocieteNomPrenomTextBox.Text = ""

                    MessageBox.Show("Client désactivé", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Warning)

                End If

            Else
                ID_T_ClientTextBox.Focus()
                ID_T_ClientTextBox.Text = 0
                SocieteNomPrenomTextBox.Text = ""

                MessageBox.Show("Client inconnu", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                CheckClient = False

            End If
        Else
            ID_T_ClientTextBox.Focus()
            ID_T_ClientTextBox.Text = 0
            SocieteNomPrenomTextBox.Text = ""
            CheckClient = False

        End If
    End Function
    Function CheckFournisseur() As Boolean
        Dim T_fournisseurTableAdapter As New CLIDataSetTableAdapters.T_FournisseurTableAdapter
        Dim T_fournisseur As New CLIDataSet.T_FournisseurDataTable

        'verification qu'un numéro de client est saisi
        If (ID_T_FournisseurTextBox.Text <> "" And ID_T_FournisseurTextBox.Text <> "0") Then
            T_fournisseurTableAdapter.FillByID_T_Fournisseur(T_fournisseur, ID_T_FournisseurTextBox.Text)
            'on efface le code client
            ID_T_ClientTextBox.Text = "0"
            'verification que le numero d'avoir existe
            If T_fournisseur.Count > 0 Then
                'verification que le client n'est pas inactif
                If T_fournisseur.Rows(0)("actif") Then
                    SocieteNomPrenomTextBox.Text = T_fournisseur.Rows(0)("Société").ToString & " " & T_fournisseur.Rows(0)("Nom").ToString & " " & T_fournisseur.Rows(0)("Prenom").ToString
                    CheckFournisseur = True

                Else
                    CheckFournisseur = False
                    ID_T_FournisseurTextBox.Focus()
                    ID_T_FournisseurTextBox.Text = 0
                    SocieteNomPrenomTextBox.Text = ""

                    MessageBox.Show("Fournisseur désactivé", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Warning)

                End If

            Else
                ID_T_FournisseurTextBox.Focus()
                ID_T_FournisseurTextBox.Text = 0
                SocieteNomPrenomTextBox.Text = ""

                MessageBox.Show("Fournisseur inconnu", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                CheckFournisseur = False

            End If
        Else
            ID_T_ClientTextBox.Focus()
            ID_T_ClientTextBox.Text = 0
            SocieteNomPrenomTextBox.Text = ""
            CheckFournisseur = False

        End If
    End Function
    Private Sub ID_T_ClientTextBox_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles ID_T_ClientTextBox.Enter
        If IsNumeric(sender.text) Then
            vCodeClient = sender.text
        End If
    End Sub
    Private Sub ID_T_ClientTextBox_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles ID_T_ClientTextBox.Validated
        If IsNumeric(sender.text) Then
            If ID_T_ClientTextBox.Text <> "0" And CInt(ID_T_ClientTextBox.Text) <> vCodeClient Then
                CheckClient()
            End If
        End If
    End Sub
    Private Sub ID_T_FournisseurTextBox_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles ID_T_FournisseurTextBox.Enter
        If IsNumeric(sender.text) Then
            vCodeFournisseur = sender.text
        End If
    End Sub
    Private Sub ID_T_FournisseurTextBox_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles ID_T_FournisseurTextBox.Validated
        If IsNumeric(sender.text) Then
            If ID_T_FournisseurTextBox.Text <> "0" And CInt(ID_T_FournisseurTextBox.Text) <> vCodeFournisseur Then
                CheckFournisseur()
            End If
        End If
    End Sub

    Private Sub BT_BonDepotVente_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BT_BonDepotVente.Click
        If T_Article_versionBindingSource.Current.item("depot_vente") Then
            Refresh_data()

            Do While Not vDepotVenteReportComplete
                Application.DoEvents()
            Loop

            DepotVenteReportViewer.PrintDialog()
        Else
            MessageBox.Show("Pas de bon de dépôt-vente à imprimer", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End If

    End Sub

    Private Sub DepotVenteReportViewer_RenderingBegin(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles DepotVenteReportViewer.RenderingBegin, ReportViewer1.RenderingBegin
        vDepotVenteReportComplete = False
    End Sub

    Private Sub DepotVenteReportViewer_RenderingComplete(ByVal sender As Object, ByVal e As Microsoft.Reporting.WinForms.RenderingCompleteEventArgs) Handles DepotVenteReportViewer.RenderingComplete, ReportViewer1.RenderingComplete
        vDepotVenteReportComplete = True
    End Sub

    Private Sub ToolStripMenuItem2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem2.Click
        Dim f As New FormClientRecherche
        f.ShowDialog()
        If f.DialogResult = Windows.Forms.DialogResult.OK Then
            ID_T_ClientTextBox.Focus()
            ID_T_ClientTextBox.Text = f.vref
            SocieteNomPrenomTextBox.Focus()
            ID_T_ClientTextBox.Focus()
        End If
    End Sub

    Private Sub ToolStripMenuItem3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem3.Click
        Dim f As New FormFournisseurRecherche
        f.ShowDialog()
        If f.DialogResult = Windows.Forms.DialogResult.OK Then
            ID_T_FournisseurTextBox.Focus()
            ID_T_FournisseurTextBox.Text = f.vref
            SocieteNomPrenomTextBox.Focus()
            ID_T_FournisseurTextBox.Focus()
        End If
    End Sub

    Private Sub Prix_vente_remise_TTCTextBox_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Prix_vente_remise_TTCTextBox.TextChanged, prix_remise_fournisseurTextBox.TextChanged

    End Sub


    Private Sub RefreshChampsObligatoires()
        '        If T_Article_EnteteBindingSource.Current.item("id_t_sousfamille").ToString <> "" Then
        Dim strObligatoireMagasin As String = ""
        Dim tabObligatoireMagasin As Array
        Dim id_t_sousfamille As Integer = 0
        If T_Article_EnteteBindingSource.Current.item("id_t_sousfamille").ToString = "" Then
            id_t_sousfamille = 0
        Else
            id_t_sousfamille = T_Article_EnteteBindingSource.Current.item("id_t_sousfamille")
        End If
        Dim dt As DataTable = ExecuteRequeteR("select ChampsObligatoiresMagasin from t_sousfamille where id_t_sousfamille=" & id_t_sousfamille, My.Settings.CLIConnectionString)
        If dt.Rows.Count > 0 Then
            strObligatoireMagasin = dt.Rows(0)("ChampsObligatoiresMagasin").ToString

        End If
        Dim vTabObligatoireMagasin As New ArrayList
        tabObligatoireMagasin = strObligatoireMagasin.Split("+")
        For i As Integer = 0 To tabObligatoireMagasin.Length - 1
            If tabObligatoireMagasin(i).ToString.Length > 2 Then
                vTabObligatoireMagasin.Add(tabObligatoireMagasin(i).ToString.Substring(1, tabObligatoireMagasin(i).ToString.Length - 2).ToUpper)
            End If
        Next
        vTabObligatoireMagasin.Add("ID_T_FAMILLE")
        vTabObligatoireMagasin.Add("ID_T_SOUSFAMILLE")

        Dim strObligatoireWeb As String = ""
        Dim tabObligatoireWeb As Array
        dt = ExecuteRequeteR("select ChampsWeb from t_sousfamille where id_t_sousfamille=" & id_t_sousfamille, My.Settings.CLIConnectionString)
        If dt.Rows.Count > 0 Then
            strObligatoireWeb = dt.Rows(0)("ChampsWeb").ToString

        End If
        Dim vTabObligatoireWeb As New ArrayList
        tabObligatoireWeb = strObligatoireWeb.Split("+")
        For i As Integer = 0 To tabObligatoireWeb.Length - 1
            If tabObligatoireWeb(i).ToString.Length > 2 Then
                vTabObligatoireWeb.Add(tabObligatoireWeb(i).ToString.Substring(1, tabObligatoireWeb(i).ToString.Length - 2).ToUpper)
            End If

        Next


        Dim strSaisissable As String = ""
        Dim tabSaisissable As Array
        dt = ExecuteRequeteR("select ChampsOptionnels from t_sousfamille where id_t_sousfamille=" & id_t_sousfamille, My.Settings.CLIConnectionString)
        If dt.Rows.Count > 0 Then
            strSaisissable = dt.Rows(0)("ChampsOptionnels").ToString

        End If
        Dim vTabSaisissable As New ArrayList
        tabSaisissable = strSaisissable.Split("+")
        For i As Integer = 0 To tabSaisissable.Length - 1
            If tabSaisissable(i).ToString.Length > 2 Then
                vTabSaisissable.Add(tabSaisissable(i).ToString.Substring(1, tabSaisissable(i).ToString.Length - 2).ToUpper)
            End If
        Next

        If gProfilName.ToUpper = "ADMINISTRATEUR" Then
            vTabSaisissable.Add("NOUVEAUDU")
            vTabSaisissable.Add("NOUVEAUAU")
            vTabSaisissable.Add("REMISEAUTODU")
            vTabSaisissable.Add("REMISEAUTOAU")
            vTabSaisissable.Add("REMISEAUTO")
        End If

        'modif 24/04/2015 pour les champs entete lié
        '
        If gProfilName.ToUpper = "ADMINISTRATEUR" Or gProfilName.ToUpper = "GESTIONNAIRE" Then
            vTabSaisissable.Add("ID_T_ARTICLE_ENTETE_LIES")

        End If









        Dim valeur As String = ""

        For Each t As TabPage In TabControl1.TabPages
            For Each c As Control In t.Controls
                valeur = ""
                If TypeOf (c) Is TextBox Or TypeOf (c) Is ComboBox Or TypeOf (c) Is CheckBox Then
                    If c.DataBindings.Count > 0 Then
                        For Each i As Binding In c.DataBindings

                            If i.PropertyName = "Text" Then
                                valeur = c.DataBindings.Item("text").BindingMemberInfo.BindingField.ToUpper
                            End If
                            If i.PropertyName = "SelectedValue" Then
                                valeur = c.DataBindings.Item("SelectedValue").BindingMemberInfo.BindingField.ToUpper
                            End If
                            If i.PropertyName = "CheckState" Then
                                valeur = c.DataBindings.Item("CheckState").BindingMemberInfo.BindingField.ToUpper
                            End If
                        Next
                        Select Case vTabObligatoireMagasin.Contains(valeur)
                            Case True
                                c.BackColor = gCouleurObligatoireFond
                                c.ForeColor = gCouleurObligatoireEcriture

                                If TypeOf (c) Is TextBox Then
                                    CType(c, TextBox).ReadOnly = False
                                End If
                                If TypeOf (c) Is ComboBox Then
                                    CType(c, ComboBox).Enabled = True
                                End If
                                If TypeOf (c) Is CheckBox Then
                                    CType(c, CheckBox).Enabled = True
                                End If
                            Case False

                                Select Case vTabObligatoireWeb.Contains(valeur)
                                    Case True
                                        c.BackColor = gCouleurWebFond
                                        c.ForeColor = gCouleurWebEcriture
                                        If TypeOf (c) Is TextBox Then
                                            CType(c, TextBox).ReadOnly = False
                                        End If
                                        If TypeOf (c) Is ComboBox Then
                                            CType(c, ComboBox).Enabled = True
                                        End If
                                        If TypeOf (c) Is CheckBox Then
                                            CType(c, CheckBox).Enabled = True
                                        End If
                                    Case False
                                        Select Case vTabSaisissable.Contains(valeur)
                                            Case True
                                                c.BackColor = gCouleurOptionnelFond
                                                c.ForeColor = gCouleurOptionnelEcriture
                                                If TypeOf (c) Is TextBox Then
                                                    CType(c, TextBox).ReadOnly = False
                                                End If
                                                If TypeOf (c) Is ComboBox Then
                                                    CType(c, ComboBox).Enabled = True
                                                End If
                                                If TypeOf (c) Is CheckBox Then
                                                    CType(c, CheckBox).Enabled = True
                                                End If
                                            Case False
                                                c.BackColor = Control.DefaultBackColor
                                                c.ForeColor = Control.DefaultForeColor
                                                If TypeOf (c) Is TextBox Then
                                                    CType(c, TextBox).ReadOnly = True
                                                End If
                                                If TypeOf (c) Is ComboBox Then
                                                    CType(c, ComboBox).Enabled = False
                                                End If
                                                If TypeOf (c) Is CheckBox Then
                                                    CType(c, CheckBox).Enabled = False
                                                End If

                                        End Select
                                End Select
                        End Select

                    End If

                End If
                If TypeOf (c) Is GroupBox Then
                    For Each d As Control In c.Controls
                        valeur = ""
                        If TypeOf (d) Is TextBox Or TypeOf (d) Is ComboBox Or TypeOf (d) Is CheckBox Then
                            If d.DataBindings.Count > 0 Then
                                For Each i As Binding In d.DataBindings

                                    If i.PropertyName = "Text" Then
                                        valeur = d.DataBindings.Item("text").BindingMemberInfo.BindingField.ToUpper
                                    End If
                                    If i.PropertyName = "SelectedValue" Then
                                        valeur = d.DataBindings.Item("SelectedValue").BindingMemberInfo.BindingField.ToUpper
                                    End If
                                    If i.PropertyName = "CheckState" Then
                                        valeur = d.DataBindings.Item("CheckState").BindingMemberInfo.BindingField.ToUpper
                                    End If
                                Next
                                Select Case vTabObligatoireMagasin.Contains(valeur)
                                    Case True
                                        d.BackColor = gCouleurObligatoireFond
                                        d.ForeColor = gCouleurObligatoireEcriture

                                        If TypeOf (d) Is TextBox Then
                                            CType(d, TextBox).ReadOnly = False
                                        End If
                                        If TypeOf (d) Is ComboBox Then
                                            CType(d, ComboBox).Enabled = True
                                        End If
                                        If TypeOf (d) Is CheckBox Then
                                            CType(d, CheckBox).Enabled = True
                                        End If
                                    Case False

                                        Select Case vTabObligatoireWeb.Contains(valeur)
                                            Case True
                                                d.BackColor = gCouleurWebFond
                                                d.ForeColor = gCouleurWebEcriture
                                                If TypeOf (d) Is TextBox Then
                                                    CType(d, TextBox).ReadOnly = False
                                                End If
                                                If TypeOf (d) Is ComboBox Then
                                                    CType(d, ComboBox).Enabled = True
                                                End If
                                                If TypeOf (d) Is CheckBox Then
                                                    CType(d, CheckBox).Enabled = True
                                                End If
                                            Case False
                                                Select Case vTabSaisissable.Contains(valeur)
                                                    Case True
                                                        d.BackColor = gCouleurOptionnelFond
                                                        d.ForeColor = gCouleurOptionnelEcriture
                                                        If TypeOf (d) Is TextBox Then
                                                            CType(d, TextBox).ReadOnly = False
                                                        End If
                                                        If TypeOf (d) Is ComboBox Then
                                                            CType(d, ComboBox).Enabled = True
                                                        End If
                                                        If TypeOf (d) Is CheckBox Then
                                                            CType(d, CheckBox).Enabled = True
                                                        End If
                                                    Case False
                                                        d.BackColor = Control.DefaultBackColor
                                                        d.ForeColor = Control.DefaultForeColor
                                                        If TypeOf (d) Is TextBox Then
                                                            CType(d, TextBox).ReadOnly = True
                                                        End If
                                                        If TypeOf (d) Is ComboBox Then
                                                            CType(d, ComboBox).Enabled = False
                                                        End If
                                                        If TypeOf (d) Is CheckBox Then
                                                            CType(d, CheckBox).Enabled = False
                                                        End If

                                                End Select
                                        End Select
                                End Select

                            End If

                        End If

                    Next


                End If
            Next

        Next
        '       End If
        Description_panierTextBox.ReadOnly = gArticle_OccazOnly
        Description_autoCheckBox.Enabled = Not gArticle_OccazOnly Or gArticle_OccazTestOnly
        'champs nouveaudu , nouveauau, remiseAutoAu, remiseAutoAu

        'NouveauDuTextBox.ReadOnly = False
        'NouveauDuTextBox.BackColor = gCouleurOptionnelFond
        'NouveauDuTextBox.ForeColor = gCouleurOptionnelEcriture

        'NouveauAuTextBox.ReadOnly = False
        'NouveauAuTextBox.BackColor = gCouleurOptionnelFond
        'NouveauAuTextBox.ForeColor = gCouleurOptionnelEcriture


        'RemiseAutoDuTextBox.ReadOnly = False
        'RemiseAutoAuTextBox.ReadOnly = False
        'RemiseAutoTextBox.ReadOnly = False



        'RemiseAutoDuTextBox.BackColor = gCouleurOptionnelFond
        'RemiseAutoDuTextBox.ForeColor = gCouleurOptionnelEcriture
        'RemiseAutoAuTextBox.BackColor = gCouleurOptionnelFond
        'RemiseAutoAuTextBox.ForeColor = gCouleurOptionnelEcriture
        'RemiseAutoTextBox.BackColor = gCouleurOptionnelFond
        'RemiseAutoTextBox.ForeColor = gCouleurOptionnelEcriture


        '



    End Sub
    Private Sub RefreshListesDeroulantes()

        Dim strProgramme As String = ""
        Dim tabProgramme As Array
        Dim strBoitier As String = ""
        Dim tabBoitier As Array
        Dim strLibelle As String = ""
        Dim tabLibelle As Array

        Dim strType As String = ""
        Dim tabType As Array
        Dim strMarque As String = ""
        Dim tabMarque As Array
        Dim strPoids As String = ""
        Dim tabPoids As Array
        Dim strTaille As String = ""
        Dim tabTaille As Array
        Dim strCarbone As String = ""
        Dim tabCarbone As Array
        Dim strRDM As String = ""
        Dim tabRDM As Array
        Dim strType2 As String = ""
        Dim tabType2 As Array
        Dim strType3 As String = ""
        Dim tabType3 As Array
        Dim strType4 As String = ""
        Dim tabType4 As Array



        Dim id_t_sousfamille As Integer = 0
        Dim libellesousfamille As String = ""
        Dim id_t_famille As Integer = 0

        If T_Article_EnteteBindingSource.Current.item("id_t_sousfamille").ToString = "" Then
            id_t_sousfamille = 0
        Else
            id_t_sousfamille = T_Article_EnteteBindingSource.Current.item("id_t_sousfamille")
        End If
        Dim dt As DataTable = ExecuteRequeteR("select libelle,id_t_famille,programme,boitier,type,type2,type3,type4,marque,poids,taille,carbone,rdmtype,libelleListe from t_sousfamille where id_t_sousfamille=" & id_t_sousfamille, My.Settings.CLIConnectionString)
        If dt.Rows.Count > 0 Then
            strProgramme = dt.Rows(0)("programme").ToString
            strBoitier = dt.Rows(0)("boitier").ToString
            strLibelle = dt.Rows(0)("libelleListe").ToString
            strType = dt.Rows(0)("type").ToString
            strType2 = dt.Rows(0)("type2").ToString
            strType3 = dt.Rows(0)("type3").ToString
            strType4 = dt.Rows(0)("type4").ToString

            strMarque = dt.Rows(0)("marque").ToString
            strPoids = dt.Rows(0)("Poids").ToString
            strTaille = dt.Rows(0)("Taille").ToString
            strCarbone = dt.Rows(0)("Carbone").ToString
            strRDM = dt.Rows(0)("RdmType").ToString
            id_t_famille = dt.Rows(0)("id_t_famille").ToString
            libellesousfamille = dt.Rows(0)("libelle").ToString
        End If


        tabProgramme = strProgramme.Split("+")
        If tabProgramme.Length > 0 Then
            If tabProgramme(0) <> "" Then
                ProgrammeComboBox.DropDownStyle = ComboBoxStyle.DropDownList
            Else
                ProgrammeComboBox.DropDownStyle = ComboBoxStyle.DropDown
            End If
        Else
            ProgrammeComboBox.DropDownStyle = ComboBoxStyle.DropDown
        End If
        ProgrammeComboBox.Items.Clear()
        For i As Integer = 0 To tabProgramme.Length - 1
            If tabProgramme(i).ToString.Length > 2 Then
                ProgrammeComboBox.Items.Add(tabProgramme(i).ToString.Substring(1, tabProgramme(i).ToString.Length - 2))
            End If
        Next
        If Not T_Article_DetailBindingSource.Current Is Nothing Then
            If ProgrammeComboBox.FindStringExact(T_Article_DetailBindingSource.Current.item("programme").ToString) < 0 Then
                ProgrammeComboBox.Items.Add(T_Article_DetailBindingSource.Current.item("programme").ToString)
            End If
            ProgrammeComboBox.Text = T_Article_DetailBindingSource.Current.item("programme").ToString
        End If

        tabLibelle = strLibelle.Split("+")
        If tabLibelle.Length > 0 Then
            If tabLibelle(0) <> "" Then
                LibelleComboBox.DropDownStyle = ComboBoxStyle.DropDownList
            Else
                LibelleComboBox.DropDownStyle = ComboBoxStyle.DropDown
            End If
        Else
            LibelleComboBox.DropDownStyle = ComboBoxStyle.DropDown
        End If
        LibelleComboBox.Items.Clear()
        For i As Integer = 0 To tabLibelle.Length - 1
            If tabLibelle(i).ToString.Length > 2 Then
                LibelleComboBox.Items.Add(tabLibelle(i).ToString.Substring(1, tabLibelle(i).ToString.Length - 2))
            End If

        Next
        If Not T_Article_versionBindingSource.Current Is Nothing Then
            If LibelleComboBox.FindStringExact(T_Article_versionBindingSource.Current.item("libelle").ToString) < 0 Then
                LibelleComboBox.Items.Add(T_Article_versionBindingSource.Current.item("libelle").ToString)
            End If
            LibelleComboBox.Text = T_Article_versionBindingSource.Current.item("libelle").ToString
        End If


        tabBoitier = strBoitier.Split("+")
        If tabBoitier.Length > 0 Then
            If tabBoitier(0) <> "" Then
                BoitierComboBox.DropDownStyle = ComboBoxStyle.DropDownList
                FoilBoitierComboBox.DropDownStyle = ComboBoxStyle.DropDownList
            Else
                BoitierComboBox.DropDownStyle = ComboBoxStyle.DropDown
                FoilBoitierComboBox.DropDownStyle = ComboBoxStyle.DropDown
            End If
        Else
            BoitierComboBox.DropDownStyle = ComboBoxStyle.DropDown
            FoilBoitierComboBox.DropDownStyle = ComboBoxStyle.DropDown
        End If
        BoitierComboBox.Items.Clear()
        FoilBoitierComboBox.Items.Clear()
        For i As Integer = 0 To tabBoitier.Length - 1
            If tabBoitier(i).ToString.Length > 2 Then
                BoitierComboBox.Items.Add(tabBoitier(i).ToString.Substring(1, tabBoitier(i).ToString.Length - 2))
                FoilBoitierComboBox.Items.Add(tabBoitier(i).ToString.Substring(1, tabBoitier(i).ToString.Length - 2))
            End If
        Next
        If Not T_Article_DetailBindingSource.Current Is Nothing Then
            If BoitierComboBox.FindStringExact(T_Article_DetailBindingSource.Current.item("Boitier").ToString) < 0 Then
                BoitierComboBox.Items.Add(T_Article_DetailBindingSource.Current.item("Boitier").ToString)
            End If
            BoitierComboBox.Text = T_Article_DetailBindingSource.Current.item("Boitier").ToString
            If FoilBoitierComboBox.FindStringExact(T_Article_DetailBindingSource.Current.item("FoilBoitier").ToString) < 0 Then
                FoilBoitierComboBox.Items.Add(T_Article_DetailBindingSource.Current.item("FoilBoitier").ToString)
            End If
            FoilBoitierComboBox.Text = T_Article_DetailBindingSource.Current.item("FoilBoitier").ToString


        End If

        tabTaille = strTaille.Split("+")
        If tabTaille.Length > 0 Then
            If tabTaille(0) <> "" Then
                TailleComboBox.DropDownStyle = ComboBoxStyle.DropDownList
            Else
                TailleComboBox.DropDownStyle = ComboBoxStyle.DropDown
            End If
        Else
            TailleComboBox.DropDownStyle = ComboBoxStyle.DropDown
        End If
        TailleComboBox.Items.Clear()
        For i As Integer = 0 To tabTaille.Length - 1
            If tabTaille(i).ToString.Length > 2 Then
                TailleComboBox.Items.Add(tabTaille(i).ToString.Substring(1, tabTaille(i).ToString.Length - 2))
            End If
        Next
        If Not T_Article_DetailBindingSource.Current Is Nothing Then
            If TailleComboBox.FindStringExact(T_Article_DetailBindingSource.Current.item("Taille").ToString) < 0 Then
                TailleComboBox.Items.Add(T_Article_DetailBindingSource.Current.item("Taille").ToString)
            End If
            TailleComboBox.Text = T_Article_DetailBindingSource.Current.item("Taille").ToString
        End If

        tabCarbone = strCarbone.Split("+")
        If tabCarbone.Length > 0 Then
            If tabCarbone(0) <> "" Then
                CarboneComboBox.DropDownStyle = ComboBoxStyle.DropDownList
            Else
                CarboneComboBox.DropDownStyle = ComboBoxStyle.DropDown
            End If
        Else
            CarboneComboBox.DropDownStyle = ComboBoxStyle.DropDown
        End If
        CarboneComboBox.Items.Clear()
        For i As Integer = 0 To tabCarbone.Length - 1
            If tabCarbone(i).ToString.Length > 2 Then
                CarboneComboBox.Items.Add(tabCarbone(i).ToString.Substring(1, tabCarbone(i).ToString.Length - 2))
            End If
        Next
        If Not T_Article_DetailBindingSource.Current Is Nothing Then
            If CarboneComboBox.FindStringExact(T_Article_DetailBindingSource.Current.item("Carbone").ToString) < 0 Then
                CarboneComboBox.Items.Add(T_Article_DetailBindingSource.Current.item("Carbone").ToString)
            End If
            CarboneComboBox.Text = T_Article_DetailBindingSource.Current.item("Carbone").ToString
        End If

        '###########                        RDM        ###########################################
        tabRDM = strRDM.Split("+")
        If tabRDM.Length > 0 Then
            If tabRDM(0) <> "" Then
                RDMtypeComboBox.DropDownStyle = ComboBoxStyle.DropDownList
            Else
                RDMtypeComboBox.DropDownStyle = ComboBoxStyle.DropDown
            End If
        Else
            RDMtypeComboBox.DropDownStyle = ComboBoxStyle.DropDown
        End If
        RDMtypeComboBox.Items.Clear()
        For i As Integer = 0 To tabRDM.Length - 1
            If tabRDM(i).ToString.Length > 2 Then
                RDMtypeComboBox.Items.Add(tabRDM(i).ToString.Substring(1, tabRDM(i).ToString.Length - 2))
            End If
        Next
        If Not T_Article_DetailBindingSource.Current Is Nothing Then
            If RDMtypeComboBox.FindStringExact(T_Article_DetailBindingSource.Current.item("rdmtype").ToString) < 0 Then
                RDMtypeComboBox.Items.Add(T_Article_DetailBindingSource.Current.item("rdmtype").ToString)
            End If
            RDMtypeComboBox.Text = T_Article_DetailBindingSource.Current.item("rdmtype").ToString
        End If



        '#########################################################################################
        'Type2

        tabType2 = strType2.Split("+")
        If tabType2.Length > 0 Then
            If tabType2(0) <> "" Then
                Type2ComboBox.DropDownStyle = ComboBoxStyle.DropDownList
            Else
                Type2ComboBox.DropDownStyle = ComboBoxStyle.DropDown
            End If
        Else
            Type2ComboBox.DropDownStyle = ComboBoxStyle.DropDown
        End If
        Type2ComboBox.Items.Clear()
        For i As Integer = 0 To tabType2.Length - 1
            If tabType2(i).ToString.Length > 2 Then
                Type2ComboBox.Items.Add(tabType2(i).ToString.Substring(1, tabType2(i).ToString.Length - 2))
            End If
        Next


        '#########################################################################################
        'Type3
        tabType3 = strType3.Split("+")
        If tabType3.Length > 0 Then
            If tabType3(0) <> "" Then
                Type3ComboBox.DropDownStyle = ComboBoxStyle.DropDownList
            Else
                Type3ComboBox.DropDownStyle = ComboBoxStyle.DropDown
            End If
        Else
            Type3ComboBox.DropDownStyle = ComboBoxStyle.DropDown
        End If
        Type3ComboBox.Items.Clear()
        For i As Integer = 0 To tabType3.Length - 1
            If tabType3(i).ToString.Length > 2 Then
                Type3ComboBox.Items.Add(tabType3(i).ToString.Substring(1, tabType3(i).ToString.Length - 2))
            End If
        Next
        '#########################################################################################
        'Type4
        tabType4 = strType4.Split("+")
        If tabType4.Length > 0 Then
            If tabType4(0) <> "" Then
                Type4ComboBox.DropDownStyle = ComboBoxStyle.DropDownList
            Else
                Type4ComboBox.DropDownStyle = ComboBoxStyle.DropDown
            End If
        Else
            Type4ComboBox.DropDownStyle = ComboBoxStyle.DropDown
        End If
        Type4ComboBox.Items.Clear()
        For i As Integer = 0 To tabType4.Length - 1
            If tabType4(i).ToString.Length > 2 Then
                Type4ComboBox.Items.Add(tabType4(i).ToString.Substring(1, tabType4(i).ToString.Length - 2))
            End If
        Next
        '#########################################################################################

        tabType = strType.Split("+")
        If tabType.Length > 0 Then
            If tabType(0) <> "" Or id_t_famille = 3 Then
                TypeComboBox.DropDownStyle = ComboBoxStyle.DropDownList
            Else
                TypeComboBox.DropDownStyle = ComboBoxStyle.DropDown
            End If
        Else
            TypeComboBox.DropDownStyle = ComboBoxStyle.DropDown
        End If
        TypeComboBox.Items.Clear()
        For i As Integer = 0 To tabType.Length - 1
            If tabType(i).ToString.Length > 2 Then
                TypeComboBox.Items.Add(tabType(i).ToString.Substring(1, tabType(i).ToString.Length - 2))
            End If
        Next



        If id_t_famille = 3 And (tabType.Length = 0 Or (tabType.Length = 1 AndAlso Trim(tabType(0).ToString) = "")) Then
            TypeComboBox.Items.Clear()
            If id_t_sousfamille <> 25 Then
                TypeComboBox.Items.Add(libellesousfamille)
            Else
                TypeComboBox.Items.Add("Chausson été")
                TypeComboBox.Items.Add("Chausson hiver")
            End If
        End If

        If Not T_Article_DetailBindingSource.Current Is Nothing Then
            If TypeComboBox.FindStringExact(T_Article_DetailBindingSource.Current.item("Type").ToString) < 0 Then
                TypeComboBox.Items.Add(T_Article_DetailBindingSource.Current.item("Type").ToString)
            End If

        End If
        TypeComboBox.Text = T_Article_DetailBindingSource.Current.item("Type").ToString






        tabMarque = strMarque.Split("+")
        If tabMarque.Length > 0 Then
            If tabMarque(0) <> "" Then
                MarqueComboBox.DropDownStyle = ComboBoxStyle.DropDownList
            Else
                MarqueComboBox.DropDownStyle = ComboBoxStyle.DropDown
            End If
        Else
            MarqueComboBox.DropDownStyle = ComboBoxStyle.DropDown
        End If
        MarqueComboBox.Items.Clear()
        For i As Integer = 0 To tabMarque.Length - 1
            If tabMarque(i).ToString.Length > 2 Then
                MarqueComboBox.Items.Add(tabMarque(i).ToString.Substring(1, tabMarque(i).ToString.Length - 2))
            End If
        Next
        If Not T_Article_EnteteBindingSource.Current Is Nothing Then
            If MarqueComboBox.FindStringExact(T_Article_EnteteBindingSource.Current.item("Marque").ToString) < 0 Then
                MarqueComboBox.Items.Add(T_Article_EnteteBindingSource.Current.item("Marque").ToString)
            End If
            MarqueComboBox.Text = T_Article_EnteteBindingSource.Current.item("Marque").ToString
        End If

        tabPoids = strPoids.Split("+")
        If tabPoids.Length > 0 Then
            If tabPoids(0) <> "" Then
                PoidsComboBox.DropDownStyle = ComboBoxStyle.DropDownList
            Else
                PoidsComboBox.DropDownStyle = ComboBoxStyle.DropDown
            End If
        Else
            PoidsComboBox.DropDownStyle = ComboBoxStyle.DropDown
        End If
        PoidsComboBox.Items.Clear()
        For i As Integer = 0 To tabPoids.Length - 1
            If tabPoids(i).ToString.Length > 2 Then
                If IsNumeric(tabPoids(i).ToString.Substring(1, tabPoids(i).ToString.Length - 2).ToUpper) Then
                    PoidsComboBox.Items.Add(CDbl(tabPoids(i).ToString.Substring(1, tabPoids(i).ToString.Length - 2)))
                End If

            End If
        Next
        If Not T_Article_versionBindingSource.Current Is Nothing Then
            If PoidsComboBox.FindStringExact(T_Article_versionBindingSource.Current.item("Poids").ToString) < 0 Then
                PoidsComboBox.Items.Add(T_Article_versionBindingSource.Current.item("Poids").ToString)
            End If
            PoidsComboBox.Text = T_Article_versionBindingSource.Current.item("Poids").ToString
        End If


    End Sub
    Private Function TestChamps() As Boolean
        TestChamps = True
        Dim id_t_sousfamille As Integer = 0
        If T_Article_EnteteBindingSource.Current.item("id_t_sousfamille").ToString = "" Then
            id_t_sousfamille = 0
        Else
            id_t_sousfamille = T_Article_EnteteBindingSource.Current.item("id_t_sousfamille")
        End If
        ' If T_Article_EnteteBindingSource.Current.item("id_t_sousfamille").ToString <> "" Then
        Dim bOk As Boolean = True
        Dim tabErreur As New ArrayList
        Dim strObligatoireMagasin As String = ""
        Dim tabObligatoireMagasin As Array
        Dim dt As DataTable = ExecuteRequeteR("select ChampsObligatoiresMagasin from t_sousfamille where id_t_sousfamille=" & id_t_sousfamille, My.Settings.CLIConnectionString)
        If dt.Rows.Count > 0 Then
            strObligatoireMagasin = dt.Rows(0)("ChampsObligatoiresMagasin").ToString

        End If
        Dim vTabObligatoireMagasin As New ArrayList
        tabObligatoireMagasin = strObligatoireMagasin.Split("+")
        For i As Integer = 0 To tabObligatoireMagasin.Length - 1
            If tabObligatoireMagasin(i).ToString.Length > 2 Then
                vTabObligatoireMagasin.Add(tabObligatoireMagasin(i).ToString.Substring(1, tabObligatoireMagasin(i).ToString.Length - 2).ToUpper)
            End If
        Next
        vTabObligatoireMagasin.Add("ID_T_FAMILLE")
        vTabObligatoireMagasin.Add("ID_T_SOUSFAMILLE")

        Dim strObligatoireWeb As String = ""
        Dim tabObligatoireWeb As Array
        dt = ExecuteRequeteR("select ChampsWeb from t_sousfamille where id_t_sousfamille=" & id_t_sousfamille, My.Settings.CLIConnectionString)
        If dt.Rows.Count > 0 Then
            strObligatoireWeb = dt.Rows(0)("ChampsWeb").ToString

        End If
        Dim vTabObligatoireWeb As New ArrayList
        tabObligatoireWeb = strObligatoireWeb.Split("+")
        For i As Integer = 0 To tabObligatoireWeb.Length - 1
            If tabObligatoireWeb(i).ToString.Length > 2 Then
                vTabObligatoireWeb.Add(tabObligatoireWeb(i).ToString.Substring(1, tabObligatoireWeb(i).ToString.Length - 2).ToUpper)
            End If

        Next


        Dim strSaisissable As String = ""
        Dim tabSaisissable As Array
        dt = ExecuteRequeteR("select ChampsOptionnels from t_sousfamille where id_t_sousfamille=" & id_t_sousfamille, My.Settings.CLIConnectionString)
        If dt.Rows.Count > 0 Then
            strSaisissable = dt.Rows(0)("ChampsOptionnels").ToString

        End If
        Dim vTabSaisissable As New ArrayList
        tabSaisissable = strSaisissable.Split("+")
        For i As Integer = 0 To tabSaisissable.Length - 1
            If tabSaisissable(i).ToString.Length > 2 Then
                vTabSaisissable.Add(tabSaisissable(i).ToString.Substring(1, tabSaisissable(i).ToString.Length - 2).ToUpper)
            End If
        Next




        Dim valeur As String = ""

        For Each t As TabPage In TabControl1.TabPages
            For Each c As Control In t.Controls
                valeur = ""
                If TypeOf (c) Is TextBox Or TypeOf (c) Is ComboBox Or TypeOf (c) Is CheckBox Then
                    If c.DataBindings.Count > 0 Then
                        For Each i As Binding In c.DataBindings

                            If i.PropertyName = "Text" Then
                                valeur = c.DataBindings.Item("text").BindingMemberInfo.BindingField.ToUpper
                            End If
                            If i.PropertyName = "SelectedValue" Then
                                valeur = c.DataBindings.Item("SelectedValue").BindingMemberInfo.BindingField.ToUpper
                            End If
                            If i.PropertyName = "CheckState" Then
                                valeur = c.DataBindings.Item("CheckState").BindingMemberInfo.BindingField.ToUpper
                            End If
                        Next
                        Select Case vTabObligatoireMagasin.Contains(valeur)
                            Case True


                                If TypeOf (c) Is TextBox Then
                                    If CType(c, TextBox).Text = "" Then
                                        TestChamps = False
                                        tabErreur.Add(valeur)

                                    End If
                                End If
                                If TypeOf (c) Is ComboBox Then

                                    If CType(c, ComboBox).Text = "" Then
                                        TestChamps = False
                                        tabErreur.Add(valeur)
                                    End If


                                End If
                                If TypeOf (c) Is CheckBox Then

                                    If CType(c, CheckBox).CheckState = CheckState.Indeterminate Then
                                        TestChamps = False
                                        tabErreur.Add(valeur)
                                    End If
                                End If
                            Case False
                                If T_Article_versionBindingSource.Current.item("web_on") Then
                                    Select Case vTabObligatoireWeb.Contains(valeur)
                                        Case True

                                            If TypeOf (c) Is TextBox Then
                                                If CType(c, TextBox).Text = "" Then
                                                    TestChamps = False
                                                    tabErreur.Add(valeur)

                                                End If
                                            End If
                                            If TypeOf (c) Is ComboBox Then
                                                If CType(c, ComboBox).Text = "" Then
                                                    TestChamps = False
                                                    tabErreur.Add(valeur)
                                                End If


                                            End If
                                            If TypeOf (c) Is CheckBox Then

                                                If CType(c, CheckBox).CheckState = CheckState.Indeterminate Then
                                                    TestChamps = False
                                                    tabErreur.Add(valeur)
                                                End If
                                            End If

                                    End Select
                                End If
                        End Select

                    End If

                End If
                If TypeOf (c) Is GroupBox Then
                    For Each d As Control In c.Controls
                        valeur = ""
                        If TypeOf (d) Is TextBox Or TypeOf (d) Is ComboBox Or TypeOf (d) Is CheckBox Then
                            If d.DataBindings.Count > 0 Then
                                For Each i As Binding In d.DataBindings

                                    If i.PropertyName = "Text" Then
                                        valeur = d.DataBindings.Item("text").BindingMemberInfo.BindingField.ToUpper
                                    End If
                                    If i.PropertyName = "SelectedValue" Then
                                        valeur = d.DataBindings.Item("SelectedValue").BindingMemberInfo.BindingField.ToUpper
                                    End If
                                    If i.PropertyName = "CheckState" Then
                                        valeur = d.DataBindings.Item("CheckState").BindingMemberInfo.BindingField.ToUpper
                                    End If
                                Next
                                Select Case vTabObligatoireMagasin.Contains(valeur)
                                    Case True


                                        If TypeOf (d) Is TextBox Then
                                            If CType(d, TextBox).Text = "" Then
                                                TestChamps = False
                                                tabErreur.Add(valeur)

                                            End If
                                        End If
                                        If TypeOf (d) Is ComboBox Then
                                            If CType(d, ComboBox).Text = "" Then
                                                TestChamps = False
                                                tabErreur.Add(valeur)
                                            End If


                                        End If
                                        If TypeOf (d) Is CheckBox Then

                                            If CType(d, CheckBox).CheckState = CheckState.Indeterminate Then
                                                TestChamps = False
                                                tabErreur.Add(valeur)
                                            End If
                                        End If
                                    Case False
                                        If T_Article_versionBindingSource.Current.item("web_on") Then
                                            Select Case vTabObligatoireWeb.Contains(valeur)
                                                Case True

                                                    If TypeOf (d) Is TextBox Then
                                                        If CType(d, TextBox).Text = "" Then
                                                            TestChamps = False
                                                            tabErreur.Add(valeur)

                                                        End If
                                                    End If
                                                    If TypeOf (d) Is ComboBox Then
                                                        If CType(d, ComboBox).Text = "" Then
                                                            TestChamps = False
                                                            tabErreur.Add(valeur)
                                                        End If


                                                    End If
                                                    If TypeOf (d) Is CheckBox Then

                                                        If CType(d, CheckBox).CheckState = CheckState.Indeterminate Then
                                                            TestChamps = False
                                                            tabErreur.Add(valeur)
                                                        End If
                                                    End If

                                            End Select
                                        End If

                                End Select

                            End If

                        End If

                    Next


                End If
            Next

        Next
        'For Each e As String In tabErreur
        '    MsgBox(e)
        'Next           
        If tabErreur.Contains("WEB_ON") And tabErreur.Contains("MAGASIN_ON") Then
        Else
            If tabErreur.Contains("ID_T_FOURNISSEUR") And tabErreur.Contains("ID_T_CLIENT") Then
            Else

                For Each e As String In tabErreur
                    If e <> "WEB_ON" And e <> "MAGASIN_ON" And e <> "ID_T_FOURNISSEUR" And e <> "ID_T_CLIENT" Then
                        TestChamps = False
                        Exit For
                    Else
                        TestChamps = True
                    End If
                Next

            End If


        End If



        '  End If


        Return TestChamps

    End Function

    Private Sub Button1_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs)

        'RefreshChampsObligatoires()
        MsgBox(TestChamps().ToString)




    End Sub


    Private Sub crystalReport41_InitReport(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub NouveauDuTextBox_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles NouveauDuTextBox.DoubleClick, NouveauAuTextBox.DoubleClick, RemiseAutoDuTextBox.DoubleClick, RemiseAutoAuTextBox.DoubleClick
        Dim f As New FormDateAndTimePicker

        If IsDate(sender.text) Then
            f.DateTimePicker1.Value = sender.text
            f.MonthCalendar1.SetDate(sender.text)
        End If

        If f.ShowDialog = Windows.Forms.DialogResult.OK Then
            sender.text = f.MonthCalendar1.SelectionRange.Start.ToShortDateString & " " & f.DateTimePicker1.Value.ToShortTimeString
        End If
    End Sub

    Private Sub LinkLabelPhoto2Definir_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs)

    End Sub

    Private Sub Label11_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub TabPageGeneral_Click(sender As Object, e As EventArgs) Handles TabPageGeneral.Click

    End Sub



    Private Sub AnneeTextBox_Validating(sender As Object, e As CancelEventArgs) Handles AnneeTextBox.Validating
        Dim valeur As Integer
        If CType(sender, TextBox).Text <> "" And CType(sender, TextBox).Text <> " " Then
            If CType(sender, TextBox).Text.Length <> 4 Then
                MessageBox.Show("Le champ collection doit faire 4 caractères", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Error)
                e.Cancel = True
            Else
                If Not Integer.TryParse(CType(sender, TextBox).Text, valeur) Then
                    MessageBox.Show("Le champ collection doit être numérique", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    e.Cancel = True
                End If

            End If

        End If
    End Sub

    Private Sub BT_NewReprise_Click(sender As Object, e As EventArgs) Handles BT_NewReprise.Click

        NewRepriseOccaz("reprise", sender, e)

    End Sub
    Sub NewRepriseOccaz(operation As String, sender As Object, e As EventArgs)

        Dim col As DataColumn
        Dim courantVersion As CLIDataSet.T_Article_versionRow = Me.CLIDataSet.T_Article_version(T_Article_versionBindingSource.Position)
        CopieVersion = Me.CLIDataSet.T_Article_version.NewT_Article_versionRow

        For Each col In courantVersion.Table.Columns
            If UCase(col.ColumnName) <> "ID_T_ARTICLE_VERSION" And UCase(col.ColumnName) <> "CREELE" And UCase(col.ColumnName) <> "MODIFIELE" And UCase(col.ColumnName) <> "MODIFIEPAR" And UCase(col.ColumnName) <> "CREEPAR" Then

                CopieVersion.Item(col.ColumnName) = courantVersion.Item(col.ColumnName)
            End If
        Next
        Dim courantDetail As CLIDataSet.T_Article_DetailRow = Me.CLIDataSet.T_Article_Detail(T_Article_DetailBindingSource.Position)
        CopieDetail = Me.CLIDataSet.T_Article_Detail.NewT_Article_DetailRow
        For Each col In courantDetail.Table.Columns
            If UCase(col.ColumnName) <> "ID_T_ARTICLE_DETAIL" And UCase(col.ColumnName) <> "CREELE" And UCase(col.ColumnName) <> "MODIFIELE" And UCase(col.ColumnName) <> "MODIFIEPAR" And UCase(col.ColumnName) <> "CREEPAR" Then

                CopieDetail.Item(col.ColumnName) = courantDetail.Item(col.ColumnName)
            End If
        Next
        'Dim courantEntete As CLIDataSet.T_Article_EnteteRow = Me.CLIDataSet.T_Article_Entete(T_Article_EnteteBindingSource.Position)
        Dim courantEntete As CLIDataSet.T_Article_EnteteRow = Me.CLIDataSet.T_Article_Entete(0)

        CopieEntete = Me.CLIDataSet.T_Article_Entete.NewT_Article_EnteteRow
        For Each col In courantEntete.Table.Columns
            If UCase(col.ColumnName) <> "ID_T_ARTICLE_VERSION" And UCase(col.ColumnName) <> "CREELE" And UCase(col.ColumnName) <> "MODIFIELE" And UCase(col.ColumnName) <> "MODIFIEPAR" And UCase(col.ColumnName) <> "CREEPAR" And Not UCase(col.ColumnName).StartsWith("PHOTO") Then
                CopieEntete.Item(col.ColumnName) = courantEntete.Item(col.ColumnName)
            End If
        Next


        NouveauGene()


        courantEntete = Me.CLIDataSet.T_Article_Entete(T_Article_EnteteBindingSource.Position)


        For Each col In courantEntete.Table.Columns
            If UCase(col.ColumnName) <> "ID_T_ARTICLE_ENTETE" Then
                Me.CLIDataSet.T_Article_Entete(Me.CLIDataSet.T_Article_Entete.Rows.Count - 1).Item(col.ColumnName) = CopieEntete.Item(col.ColumnName)
            End If
        Next

        'on ajuste la famille associée à la sous famille
        RemoveHandler FamilleComboBox.SelectedIndexChanged, AddressOf FamilleComboBox_SelectedIndexChanged
        FamilleComboBox.SelectedValue = ExecuteRequeteR("select id_t_famille from t_sousfamille where id_t_sousfamille=" & ID_t_sousfamilleComboBox.SelectedValue, My.Settings("CLIConnectionString")).Rows(0)("id_t_famille")
        AddHandler FamilleComboBox.SelectedIndexChanged, AddressOf FamilleComboBox_SelectedIndexChanged
        ID_t_sousfamilleComboBox_SelectedIndexChanged(sender, e)

        courantDetail = Me.CLIDataSet.T_Article_Detail(T_Article_DetailBindingSource.Position)
        ' Dim courantDetail As CLIDataSet.T_Article_DetailRow = Me.CLIDataSet.T_Article_Detail(0)
        For Each col In courantDetail.Table.Columns
            If UCase(col.ColumnName) <> "ID_T_ARTICLE_DETAIL" Then
                Me.CLIDataSet.T_Article_Detail(Me.CLIDataSet.T_Article_Detail.Rows.Count - 1).Item(col.ColumnName) = CopieDetail.Item(col.ColumnName)
            End If
        Next

        courantVersion = Me.CLIDataSet.T_Article_version(T_Article_versionBindingSource.Position)
        Me.CLIDataSet.T_Article_version(Me.CLIDataSet.T_Article_version.Rows.Count - 1).Item("libelle") = CopieVersion.Item("libelle")
        Me.CLIDataSet.T_Article_version(Me.CLIDataSet.T_Article_version.Rows.Count - 1).Item("poids") = CopieVersion.Item("poids")
        Me.CLIDataSet.T_Article_version(Me.CLIDataSet.T_Article_version.Rows.Count - 1).Item("Stock_limite") = 1
        If operation = "reprise" Then
            Me.CLIDataSet.T_Article_version(Me.CLIDataSet.T_Article_version.Rows.Count - 1).Item("occaz") = True

        End If
        If operation = "depot" Then
            Me.CLIDataSet.T_Article_version(Me.CLIDataSet.T_Article_version.Rows.Count - 1).Item("depot_vente") = True

        End If

        StockTextBox.Text = 0
        Stock1TextBox.Text = 0
        Stock2TextBox.Text = 0
        SocieteNomPrenomTextBox.Text = 0

        LabelNbEntete.Text = String.Format("{0} enregistrement(s) utilisent ces infos générales", "1")
        LabelNbDetail.Text = String.Format("{0} enregistrement(s) utilisent ces infos techniques", "1")

        'remise à zero du moteur de recherche
        FormArticleRecherche.BT_RAZ.PerformClick()

    End Sub

    Private Sub BT_NewDepot_Click(sender As Object, e As EventArgs) Handles BT_NewDepot.Click

        NewRepriseOccaz("depot", sender, e)
    End Sub

    Private Sub BT_DetailSynchro_Click(sender As Object, e As EventArgs) Handles BT_DetailSynchroGeneral.Click, BT_DetailSynchroDetail.Click, BT_DetailSynchroVersion.Click
        Dim f As New FormLog
        f.vLogAssociatedRecordId = Me.CLIDataSet.T_Article_Detail.Rows(0).Item("ID_t_article_entete")
        f.vLogAssociatedRecordType = "t_article_entete"
        f.ShowDialog()
    End Sub

    Private Sub LinkLabelVoirProduit_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabelVoirGeneral.LinkClicked, LinkLabelVoirDetail.LinkClicked, LinkLabelVoirVersion.LinkClicked

        Dim url As List(Of Object) = New List(Of Object)
        CliApi.ProductGetProductUrlFromPSAsync(New ToCliDto With {.Id = T_Article_EnteteBindingSource.Current.item("ID_T_article_entete")}, url)
        If url.Count > 0 Then
            Process.Start(url(0))
        End If


    End Sub


End Class