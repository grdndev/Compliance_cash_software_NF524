<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FormClient
    Inherits System.Windows.Forms.Form

    'Form remplace la méthode Dispose pour nettoyer la liste des composants.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Requise par le Concepteur Windows Form
    Private components As System.ComponentModel.IContainer

    'REMARQUE : la procédure suivante est requise par le Concepteur Windows Form
    'Elle peut être modifiée à l'aide du Concepteur Windows Form.  
    'Ne la modifiez pas à l'aide de l'éditeur de code.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim ID_T_FournisseurLabel As System.Windows.Forms.Label
        Dim SociétéLabel As System.Windows.Forms.Label
        Dim NomLabel As System.Windows.Forms.Label
        Dim PrenomLabel As System.Windows.Forms.Label
        Dim AdresseL1Label As System.Windows.Forms.Label
        Dim AdresseL2Label As System.Windows.Forms.Label
        Dim AdresseL3Label As System.Windows.Forms.Label
        Dim CodePostalLabel As System.Windows.Forms.Label
        Dim VilleLabel As System.Windows.Forms.Label
        Dim PaysLabel As System.Windows.Forms.Label
        Dim TelLabel As System.Windows.Forms.Label
        Dim MobileLabel As System.Windows.Forms.Label
        Dim FaxLabel As System.Windows.Forms.Label
        Dim EmailLabel As System.Windows.Forms.Label
        Dim CreeParLabel As System.Windows.Forms.Label
        Dim CreeLeLabel As System.Windows.Forms.Label
        Dim ModifieParLabel As System.Windows.Forms.Label
        Dim ModifieLeLabel As System.Windows.Forms.Label
        Dim ActifLabel As System.Windows.Forms.Label
        Dim PasswordLabel As System.Windows.Forms.Label
        Dim NumeroIdentiteLabel As System.Windows.Forms.Label
        Dim NoTVALabel As System.Windows.Forms.Label
        Dim NoSiretLabel As System.Windows.Forms.Label
        Dim CommentairesLabel As System.Windows.Forms.Label
        Dim WindLabel As System.Windows.Forms.Label
        Dim ExportLabel As System.Windows.Forms.Label
        Dim Label1 As System.Windows.Forms.Label
        Dim Label2 As System.Windows.Forms.Label
        Dim TitreLabel As System.Windows.Forms.Label
        Dim LabelDatenaissance As System.Windows.Forms.Label
        Dim Label3 As System.Windows.Forms.Label
        Dim EtatSynchroPrestashopLabel As System.Windows.Forms.Label
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormClient))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle10 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle11 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle12 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle17 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle18 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle13 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle14 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle15 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle16 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle19 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle20 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle22 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle23 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle21 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle24 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle25 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.CLIDataSet = New CLI.CLIDataSet()
        Me.ToolStrip2 = New System.Windows.Forms.ToolStrip()
        Me.ToolStripButtonMovefirst = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButtonMovePrevious = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripLabelPosition = New System.Windows.Forms.ToolStripLabel()
        Me.ToolStripButtonMoveNext = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButtonMoveLast = New System.Windows.Forms.ToolStripButton()
        Me.BT_Enregistrer = New System.Windows.Forms.Button()
        Me.BT_Fermer = New System.Windows.Forms.Button()
        Me.BT_Refresh = New System.Windows.Forms.Button()
        Me.T_ClientBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.TPaysBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.T_PaysTableAdapter = New CLI.CLIDataSetTableAdapters.T_PaysTableAdapter()
        Me.T_ClientTableAdapter = New CLI.CLIDataSetTableAdapters.T_ClientTableAdapter()
        Me.TabPageCommandes = New System.Windows.Forms.TabPage()
        Me.DGview_Commandes = New System.Windows.Forms.DataGridView()
        Me.RefCommande = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.EtatCommande = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TotalDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DateCommandeDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.VendeurDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.RefClientDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SociétéDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.NomDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PrénomDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CodePostalDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.VilleDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PaysDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DateFactureDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DateExpeditionDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.WebDataGridViewCheckBoxColumn = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.CodeEtat = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.VRechercheCommandeVenteBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.StatusStripCommandes = New System.Windows.Forms.StatusStrip()
        Me.ToolStripStatusLabelNbEnregistrementsCommandes = New System.Windows.Forms.ToolStripStatusLabel()
        Me.TabPageAvoir = New System.Windows.Forms.TabPage()
        Me.BT_Creer_Avoir_Global = New System.Windows.Forms.Button()
        Me.BT_Email_Avoir = New System.Windows.Forms.Button()
        Me.BT_Impression_Avoir = New System.Windows.Forms.Button()
        Me.DGVIEW_avoir = New System.Windows.Forms.DataGridView()
        Me.RefAvoir = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.RefCommandeVente = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.MontantDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CommentaireDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.AvoirCreeParDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.AvoirCreeLeDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.UtiliseLe = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.V_Avoir_clientBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.ToolStripStatusLabelNbEnregistrementAvoir = New System.Windows.Forms.ToolStripStatusLabel()
        Me.TabPageArticle = New System.Windows.Forms.TabPage()
        Me.BT_Email_Article = New System.Windows.Forms.Button()
        Me.BT_Impression_Article = New System.Windows.Forms.Button()
        Me.DGview = New System.Windows.Forms.DataGridView()
        Me.Active_on = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.Ref = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Descriptioncourte = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.prix_vente_initial_TTC = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.remise = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.prix_vente_remise_TTC = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.web_on = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.magasin_on = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.Stock = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.RefDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.FamilleDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SousFamilleDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DescriptionCourteDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.MarqueDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ModeleDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.WebonDataGridViewCheckBoxColumn = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.MagasinonDataGridViewCheckBoxColumn = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.StockDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ActiveonDataGridViewCheckBoxColumn = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.PrixventeinitialTTCDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PrixventeremiseTTCDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.RemiseDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DepotventeDataGridViewCheckBoxColumn = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.OccazDataGridViewCheckBoxColumn = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.IDtarticleenteteDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.IDtarticledetailDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.IDTFournisseurDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ReffournisseurDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.IDTClientDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.VRechercheArticleBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.StatusStripArticles = New System.Windows.Forms.StatusStrip()
        Me.ToolStripStatusLabelNbEnregistrementsArticles = New System.Windows.Forms.ToolStripStatusLabel()
        Me.TabPageGeneral = New System.Windows.Forms.TabPage()
        Me.BT_SyncAdresses = New System.Windows.Forms.Button()
        Me.BT_SyncAvoirs = New System.Windows.Forms.Button()
        Me.BT_DetailSynchro = New System.Windows.Forms.Button()
        Me.I_EtatSynchroPrestashop = New System.Windows.Forms.TextBox()
        Me.ToSyncCheckBox = New System.Windows.Forms.CheckBox()
        Me.MaskedTextBoxDateNaissance = New System.Windows.Forms.MaskedTextBox()
        Me.TitreComboBox = New System.Windows.Forms.ComboBox()
        Me.IdCustomerPrestashopTextBox = New System.Windows.Forms.TextBox()
        Me.ExportCheckBox = New System.Windows.Forms.CheckBox()
        Me.SupCheckBox = New System.Windows.Forms.CheckBox()
        Me.KiteCheckBox = New System.Windows.Forms.CheckBox()
        Me.WindCheckBox = New System.Windows.Forms.CheckBox()
        Me.CommentairesTextBox = New System.Windows.Forms.TextBox()
        Me.ApeTextBox = New System.Windows.Forms.TextBox()
        Me.NoSiretTextBox = New System.Windows.Forms.TextBox()
        Me.NoTVATextBox = New System.Windows.Forms.TextBox()
        Me.NumeroIdentiteTextBox = New System.Windows.Forms.TextBox()
        Me.NewsLetterCheckBox = New System.Windows.Forms.CheckBox()
        Me.PasswordTextBox = New System.Windows.Forms.TextBox()
        Me.ActifCheckBox = New System.Windows.Forms.CheckBox()
        Me.ModifieLeTextBox = New System.Windows.Forms.TextBox()
        Me.ModifieParTextBox = New System.Windows.Forms.TextBox()
        Me.CreeLeTextBox = New System.Windows.Forms.TextBox()
        Me.CreeParTextBox = New System.Windows.Forms.TextBox()
        Me.EmailTextBox = New System.Windows.Forms.TextBox()
        Me.FaxTextBox = New System.Windows.Forms.TextBox()
        Me.MobileTextBox = New System.Windows.Forms.TextBox()
        Me.TelTextBox = New System.Windows.Forms.TextBox()
        Me.VilleTextBox = New System.Windows.Forms.TextBox()
        Me.CodePostalTextBox = New System.Windows.Forms.TextBox()
        Me.AdresseL3TextBox = New System.Windows.Forms.TextBox()
        Me.AdresseL2TextBox = New System.Windows.Forms.TextBox()
        Me.AdresseL1TextBox = New System.Windows.Forms.TextBox()
        Me.PrenomTextBox = New System.Windows.Forms.TextBox()
        Me.NomTextBox = New System.Windows.Forms.TextBox()
        Me.SociétéTextBox = New System.Windows.Forms.TextBox()
        Me.ID_T_ClientTextBox = New System.Windows.Forms.TextBox()
        Me.PaysComboBox = New System.Windows.Forms.ComboBox()
        Me.ToolStrip = New System.Windows.Forms.ToolStrip()
        Me.NouveauToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButton2 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.CopierToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.CollerToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.SupprimerToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButton5 = New System.Windows.Forms.ToolStripButton()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPageChequeCadeau = New System.Windows.Forms.TabPage()
        Me.BT_Impression_ChequeCadeau = New System.Windows.Forms.Button()
        Me.DGVIEW_ChequeCadeau = New System.Windows.Forms.DataGridView()
        Me.ChequeUtiliseLe = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn6 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn7 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn8 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ChequeCadeauUtiliseLe = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.StatusStrip2 = New System.Windows.Forms.StatusStrip()
        Me.ToolStripStatusLabelNbEnregistrementChequeCadeau = New System.Windows.Forms.ToolStripStatusLabel()
        Me.TabPageEcheances = New System.Windows.Forms.TabPage()
        Me.V_reglementDataGridView = New System.Windows.Forms.DataGridView()
        Me.RefCommandeEcheance = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn10 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn9 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Enregistre_le = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Echeance_le = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Encaisse_le = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.V_reglementBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.TabPageAdresses = New System.Windows.Forms.TabPage()
        Me.AdressesDGView = New System.Windows.Forms.DataGridView()
        Me.idtclient = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.idtAdresse = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.idAddressPrestashop = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.V_Recherche_ArticleTableAdapter = New CLI.CLIDataSetTableAdapters.V_Recherche_ArticleTableAdapter()
        Me.V_reglementTableAdapter = New CLI.CLIDataSetTableAdapters.V_reglementTableAdapter()
        Me.I_ErrorDetail = New System.Windows.Forms.TextBox()
        ID_T_FournisseurLabel = New System.Windows.Forms.Label()
        SociétéLabel = New System.Windows.Forms.Label()
        NomLabel = New System.Windows.Forms.Label()
        PrenomLabel = New System.Windows.Forms.Label()
        AdresseL1Label = New System.Windows.Forms.Label()
        AdresseL2Label = New System.Windows.Forms.Label()
        AdresseL3Label = New System.Windows.Forms.Label()
        CodePostalLabel = New System.Windows.Forms.Label()
        VilleLabel = New System.Windows.Forms.Label()
        PaysLabel = New System.Windows.Forms.Label()
        TelLabel = New System.Windows.Forms.Label()
        MobileLabel = New System.Windows.Forms.Label()
        FaxLabel = New System.Windows.Forms.Label()
        EmailLabel = New System.Windows.Forms.Label()
        CreeParLabel = New System.Windows.Forms.Label()
        CreeLeLabel = New System.Windows.Forms.Label()
        ModifieParLabel = New System.Windows.Forms.Label()
        ModifieLeLabel = New System.Windows.Forms.Label()
        ActifLabel = New System.Windows.Forms.Label()
        PasswordLabel = New System.Windows.Forms.Label()
        NumeroIdentiteLabel = New System.Windows.Forms.Label()
        NoTVALabel = New System.Windows.Forms.Label()
        NoSiretLabel = New System.Windows.Forms.Label()
        CommentairesLabel = New System.Windows.Forms.Label()
        WindLabel = New System.Windows.Forms.Label()
        ExportLabel = New System.Windows.Forms.Label()
        Label1 = New System.Windows.Forms.Label()
        Label2 = New System.Windows.Forms.Label()
        TitreLabel = New System.Windows.Forms.Label()
        LabelDatenaissance = New System.Windows.Forms.Label()
        Label3 = New System.Windows.Forms.Label()
        EtatSynchroPrestashopLabel = New System.Windows.Forms.Label()
        CType(Me.CLIDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ToolStrip2.SuspendLayout()
        CType(Me.T_ClientBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TPaysBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPageCommandes.SuspendLayout()
        CType(Me.DGview_Commandes, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.VRechercheCommandeVenteBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.StatusStripCommandes.SuspendLayout()
        Me.TabPageAvoir.SuspendLayout()
        CType(Me.DGVIEW_avoir, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.V_Avoir_clientBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.StatusStrip1.SuspendLayout()
        Me.TabPageArticle.SuspendLayout()
        CType(Me.DGview, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.VRechercheArticleBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.StatusStripArticles.SuspendLayout()
        Me.TabPageGeneral.SuspendLayout()
        Me.ToolStrip.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.TabPageChequeCadeau.SuspendLayout()
        CType(Me.DGVIEW_ChequeCadeau, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.StatusStrip2.SuspendLayout()
        Me.TabPageEcheances.SuspendLayout()
        CType(Me.V_reglementDataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.V_reglementBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPageAdresses.SuspendLayout()
        CType(Me.AdressesDGView, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ID_T_FournisseurLabel
        '
        ID_T_FournisseurLabel.AutoSize = True
        ID_T_FournisseurLabel.Location = New System.Drawing.Point(91, 75)
        ID_T_FournisseurLabel.Name = "ID_T_FournisseurLabel"
        ID_T_FournisseurLabel.Size = New System.Drawing.Size(27, 13)
        ID_T_FournisseurLabel.TabIndex = 130
        ID_T_FournisseurLabel.Text = "Ref:"
        '
        'SociétéLabel
        '
        SociétéLabel.AutoSize = True
        SociétéLabel.Location = New System.Drawing.Point(72, 101)
        SociétéLabel.Name = "SociétéLabel"
        SociétéLabel.Size = New System.Drawing.Size(46, 13)
        SociétéLabel.TabIndex = 131
        SociétéLabel.Text = "Société:"
        '
        'NomLabel
        '
        NomLabel.AutoSize = True
        NomLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        NomLabel.Location = New System.Drawing.Point(82, 232)
        NomLabel.Name = "NomLabel"
        NomLabel.Size = New System.Drawing.Size(36, 13)
        NomLabel.TabIndex = 132
        NomLabel.Text = "Nom:"
        '
        'PrenomLabel
        '
        PrenomLabel.AutoSize = True
        PrenomLabel.Location = New System.Drawing.Point(72, 258)
        PrenomLabel.Name = "PrenomLabel"
        PrenomLabel.Size = New System.Drawing.Size(46, 13)
        PrenomLabel.TabIndex = 133
        PrenomLabel.Text = "Prenom:"
        '
        'AdresseL1Label
        '
        AdresseL1Label.AutoSize = True
        AdresseL1Label.Location = New System.Drawing.Point(55, 284)
        AdresseL1Label.Name = "AdresseL1Label"
        AdresseL1Label.Size = New System.Drawing.Size(63, 13)
        AdresseL1Label.TabIndex = 134
        AdresseL1Label.Text = "Adresse L1:"
        '
        'AdresseL2Label
        '
        AdresseL2Label.AutoSize = True
        AdresseL2Label.Location = New System.Drawing.Point(55, 310)
        AdresseL2Label.Name = "AdresseL2Label"
        AdresseL2Label.Size = New System.Drawing.Size(63, 13)
        AdresseL2Label.TabIndex = 135
        AdresseL2Label.Text = "Adresse L2:"
        '
        'AdresseL3Label
        '
        AdresseL3Label.AutoSize = True
        AdresseL3Label.Location = New System.Drawing.Point(55, 336)
        AdresseL3Label.Name = "AdresseL3Label"
        AdresseL3Label.Size = New System.Drawing.Size(63, 13)
        AdresseL3Label.TabIndex = 136
        AdresseL3Label.Text = "Adresse L3:"
        '
        'CodePostalLabel
        '
        CodePostalLabel.AutoSize = True
        CodePostalLabel.Location = New System.Drawing.Point(51, 362)
        CodePostalLabel.Name = "CodePostalLabel"
        CodePostalLabel.Size = New System.Drawing.Size(67, 13)
        CodePostalLabel.TabIndex = 137
        CodePostalLabel.Text = "Code Postal:"
        '
        'VilleLabel
        '
        VilleLabel.AutoSize = True
        VilleLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        VilleLabel.Location = New System.Drawing.Point(83, 388)
        VilleLabel.Name = "VilleLabel"
        VilleLabel.Size = New System.Drawing.Size(35, 13)
        VilleLabel.TabIndex = 138
        VilleLabel.Text = "Ville:"
        '
        'PaysLabel
        '
        PaysLabel.AutoSize = True
        PaysLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        PaysLabel.Location = New System.Drawing.Point(80, 414)
        PaysLabel.Name = "PaysLabel"
        PaysLabel.Size = New System.Drawing.Size(38, 13)
        PaysLabel.TabIndex = 139
        PaysLabel.Text = "Pays:"
        '
        'TelLabel
        '
        TelLabel.AutoSize = True
        TelLabel.Location = New System.Drawing.Point(93, 441)
        TelLabel.Name = "TelLabel"
        TelLabel.Size = New System.Drawing.Size(25, 13)
        TelLabel.TabIndex = 140
        TelLabel.Text = "Tel:"
        '
        'MobileLabel
        '
        MobileLabel.AutoSize = True
        MobileLabel.Location = New System.Drawing.Point(234, 441)
        MobileLabel.Name = "MobileLabel"
        MobileLabel.Size = New System.Drawing.Size(41, 13)
        MobileLabel.TabIndex = 141
        MobileLabel.Text = "Mobile:"
        '
        'FaxLabel
        '
        FaxLabel.AutoSize = True
        FaxLabel.Location = New System.Drawing.Point(386, 444)
        FaxLabel.Name = "FaxLabel"
        FaxLabel.Size = New System.Drawing.Size(27, 13)
        FaxLabel.TabIndex = 142
        FaxLabel.Text = "Fax:"
        '
        'EmailLabel
        '
        EmailLabel.AutoSize = True
        EmailLabel.Location = New System.Drawing.Point(83, 467)
        EmailLabel.Name = "EmailLabel"
        EmailLabel.Size = New System.Drawing.Size(35, 13)
        EmailLabel.TabIndex = 143
        EmailLabel.Text = "Email:"
        '
        'CreeParLabel
        '
        CreeParLabel.AutoSize = True
        CreeParLabel.Location = New System.Drawing.Point(562, 394)
        CreeParLabel.Name = "CreeParLabel"
        CreeParLabel.Size = New System.Drawing.Size(51, 13)
        CreeParLabel.TabIndex = 145
        CreeParLabel.Text = "Cree Par:"
        '
        'CreeLeLabel
        '
        CreeLeLabel.AutoSize = True
        CreeLeLabel.Location = New System.Drawing.Point(566, 420)
        CreeLeLabel.Name = "CreeLeLabel"
        CreeLeLabel.Size = New System.Drawing.Size(47, 13)
        CreeLeLabel.TabIndex = 146
        CreeLeLabel.Text = "Cree Le:"
        '
        'ModifieParLabel
        '
        ModifieParLabel.AutoSize = True
        ModifieParLabel.Location = New System.Drawing.Point(788, 397)
        ModifieParLabel.Name = "ModifieParLabel"
        ModifieParLabel.Size = New System.Drawing.Size(63, 13)
        ModifieParLabel.TabIndex = 147
        ModifieParLabel.Text = "Modifie Par:"
        '
        'ModifieLeLabel
        '
        ModifieLeLabel.AutoSize = True
        ModifieLeLabel.Location = New System.Drawing.Point(792, 423)
        ModifieLeLabel.Name = "ModifieLeLabel"
        ModifieLeLabel.Size = New System.Drawing.Size(59, 13)
        ModifieLeLabel.TabIndex = 148
        ModifieLeLabel.Text = "Modifie Le:"
        '
        'ActifLabel
        '
        ActifLabel.AutoSize = True
        ActifLabel.Location = New System.Drawing.Point(376, 69)
        ActifLabel.Name = "ActifLabel"
        ActifLabel.Size = New System.Drawing.Size(31, 13)
        ActifLabel.TabIndex = 149
        ActifLabel.Text = "Actif:"
        '
        'PasswordLabel
        '
        PasswordLabel.AutoSize = True
        PasswordLabel.Location = New System.Drawing.Point(62, 539)
        PasswordLabel.Name = "PasswordLabel"
        PasswordLabel.Size = New System.Drawing.Size(56, 13)
        PasswordLabel.TabIndex = 150
        PasswordLabel.Text = "Password:"
        '
        'NumeroIdentiteLabel
        '
        NumeroIdentiteLabel.AutoSize = True
        NumeroIdentiteLabel.Location = New System.Drawing.Point(0, 514)
        NumeroIdentiteLabel.Name = "NumeroIdentiteLabel"
        NumeroIdentiteLabel.Size = New System.Drawing.Size(118, 13)
        NumeroIdentiteLabel.TabIndex = 152
        NumeroIdentiteLabel.Text = "N° Passeport / Identite:"
        '
        'NoTVALabel
        '
        NoTVALabel.AutoSize = True
        NoTVALabel.Location = New System.Drawing.Point(67, 127)
        NoTVALabel.Name = "NoTVALabel"
        NoTVALabel.Size = New System.Drawing.Size(48, 13)
        NoTVALabel.TabIndex = 152
        NoTVALabel.Text = "No TVA:"
        '
        'NoSiretLabel
        '
        NoSiretLabel.AutoSize = True
        NoSiretLabel.Location = New System.Drawing.Point(67, 153)
        NoSiretLabel.Name = "NoSiretLabel"
        NoSiretLabel.Size = New System.Drawing.Size(48, 13)
        NoSiretLabel.TabIndex = 153
        NoSiretLabel.Text = "No Siret:"
        '
        'CommentairesLabel
        '
        CommentairesLabel.AutoSize = True
        CommentairesLabel.Location = New System.Drawing.Point(479, 69)
        CommentairesLabel.Name = "CommentairesLabel"
        CommentairesLabel.Size = New System.Drawing.Size(76, 13)
        CommentairesLabel.TabIndex = 153
        CommentairesLabel.Text = "Commentaires:"
        '
        'WindLabel
        '
        WindLabel.AutoSize = True
        WindLabel.Location = New System.Drawing.Point(80, 567)
        WindLabel.Name = "WindLabel"
        WindLabel.Size = New System.Drawing.Size(0, 13)
        WindLabel.TabIndex = 154
        '
        'ExportLabel
        '
        ExportLabel.AutoSize = True
        ExportLabel.Location = New System.Drawing.Point(345, 99)
        ExportLabel.Name = "ExportLabel"
        ExportLabel.Size = New System.Drawing.Size(64, 13)
        ExportLabel.TabIndex = 158
        ExportLabel.Text = "Tarif Export:"
        '
        'Label1
        '
        Label1.AutoSize = True
        Label1.Location = New System.Drawing.Point(528, 368)
        Label1.Name = "Label1"
        Label1.Size = New System.Drawing.Size(82, 13)
        Label1.TabIndex = 161
        Label1.Text = "Ref prestashop:"
        '
        'Label2
        '
        Label2.AutoSize = True
        Label2.Location = New System.Drawing.Point(67, 179)
        Label2.Name = "Label2"
        Label2.Size = New System.Drawing.Size(46, 13)
        Label2.TabIndex = 153
        Label2.Text = "No Ape:"
        '
        'TitreLabel
        '
        TitreLabel.AutoSize = True
        TitreLabel.Location = New System.Drawing.Point(84, 205)
        TitreLabel.Name = "TitreLabel"
        TitreLabel.Size = New System.Drawing.Size(31, 13)
        TitreLabel.TabIndex = 161
        TitreLabel.Text = "Titre:"
        '
        'LabelDatenaissance
        '
        LabelDatenaissance.AutoSize = True
        LabelDatenaissance.Location = New System.Drawing.Point(19, 487)
        LabelDatenaissance.Name = "LabelDatenaissance"
        LabelDatenaissance.Size = New System.Drawing.Size(99, 13)
        LabelDatenaissance.TabIndex = 140
        LabelDatenaissance.Text = "Date de naissance:"
        '
        'Label3
        '
        Label3.AutoSize = True
        Label3.Location = New System.Drawing.Point(227, 539)
        Label3.Name = "Label3"
        Label3.Size = New System.Drawing.Size(165, 13)
        Label3.TabIndex = 164
        Label3.Text = "(lecture seule si dans Prestashop)"
        '
        'EtatSynchroPrestashopLabel
        '
        EtatSynchroPrestashopLabel.AutoSize = True
        EtatSynchroPrestashopLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        EtatSynchroPrestashopLabel.Location = New System.Drawing.Point(727, 465)
        EtatSynchroPrestashopLabel.Name = "EtatSynchroPrestashopLabel"
        EtatSynchroPrestashopLabel.Size = New System.Drawing.Size(127, 13)
        EtatSynchroPrestashopLabel.TabIndex = 166
        EtatSynchroPrestashopLabel.Text = "Etat Synchro Prestashop:"
        '
        'CLIDataSet
        '
        Me.CLIDataSet.DataSetName = "CLIDataSet"
        Me.CLIDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'ToolStrip2
        '
        Me.ToolStrip2.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStrip2.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripButtonMovefirst, Me.ToolStripButtonMovePrevious, Me.ToolStripLabelPosition, Me.ToolStripButtonMoveNext, Me.ToolStripButtonMoveLast})
        Me.ToolStrip2.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip2.Name = "ToolStrip2"
        Me.ToolStrip2.Size = New System.Drawing.Size(1041, 25)
        Me.ToolStrip2.TabIndex = 44
        Me.ToolStrip2.Text = "ToolStrip2"
        '
        'ToolStripButtonMovefirst
        '
        Me.ToolStripButtonMovefirst.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButtonMovefirst.Image = CType(resources.GetObject("ToolStripButtonMovefirst.Image"), System.Drawing.Image)
        Me.ToolStripButtonMovefirst.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButtonMovefirst.Name = "ToolStripButtonMovefirst"
        Me.ToolStripButtonMovefirst.Size = New System.Drawing.Size(23, 22)
        Me.ToolStripButtonMovefirst.Text = "Premier"
        '
        'ToolStripButtonMovePrevious
        '
        Me.ToolStripButtonMovePrevious.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButtonMovePrevious.Image = CType(resources.GetObject("ToolStripButtonMovePrevious.Image"), System.Drawing.Image)
        Me.ToolStripButtonMovePrevious.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButtonMovePrevious.Name = "ToolStripButtonMovePrevious"
        Me.ToolStripButtonMovePrevious.Size = New System.Drawing.Size(23, 22)
        Me.ToolStripButtonMovePrevious.Text = "Pécèdent"
        '
        'ToolStripLabelPosition
        '
        Me.ToolStripLabelPosition.Name = "ToolStripLabelPosition"
        Me.ToolStripLabelPosition.Size = New System.Drawing.Size(40, 22)
        Me.ToolStripLabelPosition.Text = "{0}/{1}"
        '
        'ToolStripButtonMoveNext
        '
        Me.ToolStripButtonMoveNext.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButtonMoveNext.Image = CType(resources.GetObject("ToolStripButtonMoveNext.Image"), System.Drawing.Image)
        Me.ToolStripButtonMoveNext.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButtonMoveNext.Name = "ToolStripButtonMoveNext"
        Me.ToolStripButtonMoveNext.Size = New System.Drawing.Size(23, 22)
        Me.ToolStripButtonMoveNext.Text = "Suivant"
        '
        'ToolStripButtonMoveLast
        '
        Me.ToolStripButtonMoveLast.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButtonMoveLast.Image = CType(resources.GetObject("ToolStripButtonMoveLast.Image"), System.Drawing.Image)
        Me.ToolStripButtonMoveLast.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButtonMoveLast.Name = "ToolStripButtonMoveLast"
        Me.ToolStripButtonMoveLast.Size = New System.Drawing.Size(23, 22)
        Me.ToolStripButtonMoveLast.Text = "Dernier"
        '
        'BT_Enregistrer
        '
        Me.BT_Enregistrer.Image = CType(resources.GetObject("BT_Enregistrer.Image"), System.Drawing.Image)
        Me.BT_Enregistrer.Location = New System.Drawing.Point(5, 28)
        Me.BT_Enregistrer.Name = "BT_Enregistrer"
        Me.BT_Enregistrer.Size = New System.Drawing.Size(82, 31)
        Me.BT_Enregistrer.TabIndex = 0
        Me.BT_Enregistrer.Text = "Enregistrer"
        Me.BT_Enregistrer.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.BT_Enregistrer.UseVisualStyleBackColor = True
        '
        'BT_Fermer
        '
        Me.BT_Fermer.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BT_Fermer.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.BT_Fermer.Image = CType(resources.GetObject("BT_Fermer.Image"), System.Drawing.Image)
        Me.BT_Fermer.Location = New System.Drawing.Point(943, 28)
        Me.BT_Fermer.Name = "BT_Fermer"
        Me.BT_Fermer.Size = New System.Drawing.Size(82, 31)
        Me.BT_Fermer.TabIndex = 2
        Me.BT_Fermer.Text = "Fermer"
        Me.BT_Fermer.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.BT_Fermer.UseVisualStyleBackColor = True
        '
        'BT_Refresh
        '
        Me.BT_Refresh.Image = CType(resources.GetObject("BT_Refresh.Image"), System.Drawing.Image)
        Me.BT_Refresh.Location = New System.Drawing.Point(93, 28)
        Me.BT_Refresh.Name = "BT_Refresh"
        Me.BT_Refresh.Size = New System.Drawing.Size(82, 31)
        Me.BT_Refresh.TabIndex = 1
        Me.BT_Refresh.Text = "Refresh"
        Me.BT_Refresh.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.BT_Refresh.UseVisualStyleBackColor = True
        '
        'T_ClientBindingSource
        '
        Me.T_ClientBindingSource.DataMember = "T_Client"
        Me.T_ClientBindingSource.DataSource = Me.CLIDataSet
        '
        'TPaysBindingSource
        '
        Me.TPaysBindingSource.DataMember = "T_Pays"
        Me.TPaysBindingSource.DataSource = Me.CLIDataSet
        '
        'T_PaysTableAdapter
        '
        Me.T_PaysTableAdapter.ClearBeforeFill = True
        '
        'T_ClientTableAdapter
        '
        Me.T_ClientTableAdapter.ClearBeforeFill = True
        '
        'TabPageCommandes
        '
        Me.TabPageCommandes.Controls.Add(Me.DGview_Commandes)
        Me.TabPageCommandes.Controls.Add(Me.StatusStripCommandes)
        Me.TabPageCommandes.Location = New System.Drawing.Point(4, 22)
        Me.TabPageCommandes.Name = "TabPageCommandes"
        Me.TabPageCommandes.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPageCommandes.Size = New System.Drawing.Size(1021, 646)
        Me.TabPageCommandes.TabIndex = 3
        Me.TabPageCommandes.Text = "Commandes"
        Me.TabPageCommandes.UseVisualStyleBackColor = True
        '
        'DGview_Commandes
        '
        Me.DGview_Commandes.AllowUserToAddRows = False
        Me.DGview_Commandes.AllowUserToDeleteRows = False
        Me.DGview_Commandes.AllowUserToResizeRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.DGview_Commandes.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.DGview_Commandes.AutoGenerateColumns = False
        Me.DGview_Commandes.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DGview_Commandes.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.DGview_Commandes.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.RefCommande, Me.EtatCommande, Me.TotalDataGridViewTextBoxColumn, Me.DateCommandeDataGridViewTextBoxColumn, Me.VendeurDataGridViewTextBoxColumn, Me.RefClientDataGridViewTextBoxColumn, Me.SociétéDataGridViewTextBoxColumn, Me.NomDataGridViewTextBoxColumn, Me.PrénomDataGridViewTextBoxColumn, Me.CodePostalDataGridViewTextBoxColumn, Me.VilleDataGridViewTextBoxColumn, Me.PaysDataGridViewTextBoxColumn, Me.DateFactureDataGridViewTextBoxColumn, Me.DateExpeditionDataGridViewTextBoxColumn, Me.WebDataGridViewCheckBoxColumn, Me.CodeEtat})
        Me.DGview_Commandes.DataSource = Me.VRechercheCommandeVenteBindingSource
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DGview_Commandes.DefaultCellStyle = DataGridViewCellStyle4
        Me.DGview_Commandes.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DGview_Commandes.Location = New System.Drawing.Point(3, 3)
        Me.DGview_Commandes.MultiSelect = False
        Me.DGview_Commandes.Name = "DGview_Commandes"
        Me.DGview_Commandes.ReadOnly = True
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DGview_Commandes.RowHeadersDefaultCellStyle = DataGridViewCellStyle5
        Me.DGview_Commandes.RowHeadersVisible = False
        Me.DGview_Commandes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DGview_Commandes.Size = New System.Drawing.Size(1015, 618)
        Me.DGview_Commandes.TabIndex = 13
        '
        'RefCommande
        '
        Me.RefCommande.DataPropertyName = "Ref commande"
        Me.RefCommande.HeaderText = "Ref commande"
        Me.RefCommande.Name = "RefCommande"
        Me.RefCommande.ReadOnly = True
        Me.RefCommande.Width = 104
        '
        'EtatCommande
        '
        Me.EtatCommande.DataPropertyName = "Etat Commande"
        Me.EtatCommande.HeaderText = "Etat Commande"
        Me.EtatCommande.Name = "EtatCommande"
        Me.EtatCommande.ReadOnly = True
        Me.EtatCommande.Width = 107
        '
        'TotalDataGridViewTextBoxColumn
        '
        Me.TotalDataGridViewTextBoxColumn.DataPropertyName = "Total"
        DataGridViewCellStyle3.Format = "C2"
        Me.TotalDataGridViewTextBoxColumn.DefaultCellStyle = DataGridViewCellStyle3
        Me.TotalDataGridViewTextBoxColumn.HeaderText = "Total"
        Me.TotalDataGridViewTextBoxColumn.Name = "TotalDataGridViewTextBoxColumn"
        Me.TotalDataGridViewTextBoxColumn.ReadOnly = True
        Me.TotalDataGridViewTextBoxColumn.Width = 56
        '
        'DateCommandeDataGridViewTextBoxColumn
        '
        Me.DateCommandeDataGridViewTextBoxColumn.DataPropertyName = "Date commande"
        Me.DateCommandeDataGridViewTextBoxColumn.HeaderText = "Date commande"
        Me.DateCommandeDataGridViewTextBoxColumn.Name = "DateCommandeDataGridViewTextBoxColumn"
        Me.DateCommandeDataGridViewTextBoxColumn.ReadOnly = True
        Me.DateCommandeDataGridViewTextBoxColumn.Width = 110
        '
        'VendeurDataGridViewTextBoxColumn
        '
        Me.VendeurDataGridViewTextBoxColumn.DataPropertyName = "Vendeur"
        Me.VendeurDataGridViewTextBoxColumn.HeaderText = "Vendeur"
        Me.VendeurDataGridViewTextBoxColumn.Name = "VendeurDataGridViewTextBoxColumn"
        Me.VendeurDataGridViewTextBoxColumn.ReadOnly = True
        Me.VendeurDataGridViewTextBoxColumn.Width = 72
        '
        'RefClientDataGridViewTextBoxColumn
        '
        Me.RefClientDataGridViewTextBoxColumn.DataPropertyName = "Ref client"
        Me.RefClientDataGridViewTextBoxColumn.HeaderText = "Ref client"
        Me.RefClientDataGridViewTextBoxColumn.Name = "RefClientDataGridViewTextBoxColumn"
        Me.RefClientDataGridViewTextBoxColumn.ReadOnly = True
        Me.RefClientDataGridViewTextBoxColumn.Width = 77
        '
        'SociétéDataGridViewTextBoxColumn
        '
        Me.SociétéDataGridViewTextBoxColumn.DataPropertyName = "Société"
        Me.SociétéDataGridViewTextBoxColumn.HeaderText = "Société"
        Me.SociétéDataGridViewTextBoxColumn.Name = "SociétéDataGridViewTextBoxColumn"
        Me.SociétéDataGridViewTextBoxColumn.ReadOnly = True
        Me.SociétéDataGridViewTextBoxColumn.Width = 68
        '
        'NomDataGridViewTextBoxColumn
        '
        Me.NomDataGridViewTextBoxColumn.DataPropertyName = "Nom"
        Me.NomDataGridViewTextBoxColumn.HeaderText = "Nom"
        Me.NomDataGridViewTextBoxColumn.Name = "NomDataGridViewTextBoxColumn"
        Me.NomDataGridViewTextBoxColumn.ReadOnly = True
        Me.NomDataGridViewTextBoxColumn.Width = 54
        '
        'PrénomDataGridViewTextBoxColumn
        '
        Me.PrénomDataGridViewTextBoxColumn.DataPropertyName = "Prénom"
        Me.PrénomDataGridViewTextBoxColumn.HeaderText = "Prénom"
        Me.PrénomDataGridViewTextBoxColumn.Name = "PrénomDataGridViewTextBoxColumn"
        Me.PrénomDataGridViewTextBoxColumn.ReadOnly = True
        Me.PrénomDataGridViewTextBoxColumn.Width = 68
        '
        'CodePostalDataGridViewTextBoxColumn
        '
        Me.CodePostalDataGridViewTextBoxColumn.DataPropertyName = "CodePostal"
        Me.CodePostalDataGridViewTextBoxColumn.HeaderText = "CodePostal"
        Me.CodePostalDataGridViewTextBoxColumn.Name = "CodePostalDataGridViewTextBoxColumn"
        Me.CodePostalDataGridViewTextBoxColumn.ReadOnly = True
        Me.CodePostalDataGridViewTextBoxColumn.Width = 86
        '
        'VilleDataGridViewTextBoxColumn
        '
        Me.VilleDataGridViewTextBoxColumn.DataPropertyName = "Ville"
        Me.VilleDataGridViewTextBoxColumn.HeaderText = "Ville"
        Me.VilleDataGridViewTextBoxColumn.Name = "VilleDataGridViewTextBoxColumn"
        Me.VilleDataGridViewTextBoxColumn.ReadOnly = True
        Me.VilleDataGridViewTextBoxColumn.Width = 51
        '
        'PaysDataGridViewTextBoxColumn
        '
        Me.PaysDataGridViewTextBoxColumn.DataPropertyName = "Pays"
        Me.PaysDataGridViewTextBoxColumn.HeaderText = "Pays"
        Me.PaysDataGridViewTextBoxColumn.Name = "PaysDataGridViewTextBoxColumn"
        Me.PaysDataGridViewTextBoxColumn.ReadOnly = True
        Me.PaysDataGridViewTextBoxColumn.Width = 55
        '
        'DateFactureDataGridViewTextBoxColumn
        '
        Me.DateFactureDataGridViewTextBoxColumn.DataPropertyName = "Date facture"
        Me.DateFactureDataGridViewTextBoxColumn.HeaderText = "Date facture"
        Me.DateFactureDataGridViewTextBoxColumn.Name = "DateFactureDataGridViewTextBoxColumn"
        Me.DateFactureDataGridViewTextBoxColumn.ReadOnly = True
        Me.DateFactureDataGridViewTextBoxColumn.Width = 91
        '
        'DateExpeditionDataGridViewTextBoxColumn
        '
        Me.DateExpeditionDataGridViewTextBoxColumn.DataPropertyName = "Date Expedition"
        Me.DateExpeditionDataGridViewTextBoxColumn.HeaderText = "Date Expedition"
        Me.DateExpeditionDataGridViewTextBoxColumn.Name = "DateExpeditionDataGridViewTextBoxColumn"
        Me.DateExpeditionDataGridViewTextBoxColumn.ReadOnly = True
        Me.DateExpeditionDataGridViewTextBoxColumn.Width = 107
        '
        'WebDataGridViewCheckBoxColumn
        '
        Me.WebDataGridViewCheckBoxColumn.DataPropertyName = "Web ?"
        Me.WebDataGridViewCheckBoxColumn.HeaderText = "Web ?"
        Me.WebDataGridViewCheckBoxColumn.Name = "WebDataGridViewCheckBoxColumn"
        Me.WebDataGridViewCheckBoxColumn.ReadOnly = True
        Me.WebDataGridViewCheckBoxColumn.Width = 45
        '
        'CodeEtat
        '
        Me.CodeEtat.DataPropertyName = "Code etat"
        Me.CodeEtat.HeaderText = "Code etat"
        Me.CodeEtat.Name = "CodeEtat"
        Me.CodeEtat.ReadOnly = True
        Me.CodeEtat.Visible = False
        Me.CodeEtat.Width = 78
        '
        'VRechercheCommandeVenteBindingSource
        '
        Me.VRechercheCommandeVenteBindingSource.DataMember = "V_Recherche_Commande_Vente"
        Me.VRechercheCommandeVenteBindingSource.DataSource = Me.CLIDataSet
        '
        'StatusStripCommandes
        '
        Me.StatusStripCommandes.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripStatusLabelNbEnregistrementsCommandes})
        Me.StatusStripCommandes.Location = New System.Drawing.Point(3, 621)
        Me.StatusStripCommandes.Name = "StatusStripCommandes"
        Me.StatusStripCommandes.Size = New System.Drawing.Size(1015, 22)
        Me.StatusStripCommandes.TabIndex = 12
        Me.StatusStripCommandes.Text = "StatusStrip"
        '
        'ToolStripStatusLabelNbEnregistrementsCommandes
        '
        Me.ToolStripStatusLabelNbEnregistrementsCommandes.Name = "ToolStripStatusLabelNbEnregistrementsCommandes"
        Me.ToolStripStatusLabelNbEnregistrementsCommandes.Size = New System.Drawing.Size(203, 17)
        Me.ToolStripStatusLabelNbEnregistrementsCommandes.Text = "{0000} enregistrement(s) sélectionnés"
        '
        'TabPageAvoir
        '
        Me.TabPageAvoir.Controls.Add(Me.BT_Creer_Avoir_Global)
        Me.TabPageAvoir.Controls.Add(Me.BT_Email_Avoir)
        Me.TabPageAvoir.Controls.Add(Me.BT_Impression_Avoir)
        Me.TabPageAvoir.Controls.Add(Me.DGVIEW_avoir)
        Me.TabPageAvoir.Controls.Add(Me.StatusStrip1)
        Me.TabPageAvoir.Location = New System.Drawing.Point(4, 22)
        Me.TabPageAvoir.Name = "TabPageAvoir"
        Me.TabPageAvoir.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPageAvoir.Size = New System.Drawing.Size(1021, 646)
        Me.TabPageAvoir.TabIndex = 2
        Me.TabPageAvoir.Text = "Avoirs"
        Me.TabPageAvoir.UseVisualStyleBackColor = True
        '
        'BT_Creer_Avoir_Global
        '
        Me.BT_Creer_Avoir_Global.Image = CType(resources.GetObject("BT_Creer_Avoir_Global.Image"), System.Drawing.Image)
        Me.BT_Creer_Avoir_Global.Location = New System.Drawing.Point(173, 3)
        Me.BT_Creer_Avoir_Global.Name = "BT_Creer_Avoir_Global"
        Me.BT_Creer_Avoir_Global.Size = New System.Drawing.Size(126, 23)
        Me.BT_Creer_Avoir_Global.TabIndex = 45
        Me.BT_Creer_Avoir_Global.Text = "Créer avoir global"
        Me.BT_Creer_Avoir_Global.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.BT_Creer_Avoir_Global.UseVisualStyleBackColor = True
        '
        'BT_Email_Avoir
        '
        Me.BT_Email_Avoir.Image = CType(resources.GetObject("BT_Email_Avoir.Image"), System.Drawing.Image)
        Me.BT_Email_Avoir.Location = New System.Drawing.Point(89, 3)
        Me.BT_Email_Avoir.Name = "BT_Email_Avoir"
        Me.BT_Email_Avoir.Size = New System.Drawing.Size(78, 23)
        Me.BT_Email_Avoir.TabIndex = 45
        Me.BT_Email_Avoir.Text = "Email"
        Me.BT_Email_Avoir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.BT_Email_Avoir.UseVisualStyleBackColor = True
        '
        'BT_Impression_Avoir
        '
        Me.BT_Impression_Avoir.Image = CType(resources.GetObject("BT_Impression_Avoir.Image"), System.Drawing.Image)
        Me.BT_Impression_Avoir.Location = New System.Drawing.Point(5, 3)
        Me.BT_Impression_Avoir.Name = "BT_Impression_Avoir"
        Me.BT_Impression_Avoir.Size = New System.Drawing.Size(78, 23)
        Me.BT_Impression_Avoir.TabIndex = 45
        Me.BT_Impression_Avoir.Text = "Imprimer"
        Me.BT_Impression_Avoir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.BT_Impression_Avoir.UseVisualStyleBackColor = True
        '
        'DGVIEW_avoir
        '
        Me.DGVIEW_avoir.AllowUserToAddRows = False
        Me.DGVIEW_avoir.AllowUserToDeleteRows = False
        Me.DGVIEW_avoir.AllowUserToResizeRows = False
        DataGridViewCellStyle6.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.DGVIEW_avoir.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle6
        Me.DGVIEW_avoir.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DGVIEW_avoir.AutoGenerateColumns = False
        Me.DGVIEW_avoir.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DGVIEW_avoir.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle7
        Me.DGVIEW_avoir.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.RefAvoir, Me.RefCommandeVente, Me.MontantDataGridViewTextBoxColumn, Me.CommentaireDataGridViewTextBoxColumn, Me.AvoirCreeParDataGridViewTextBoxColumn, Me.AvoirCreeLeDataGridViewTextBoxColumn, Me.UtiliseLe})
        Me.DGVIEW_avoir.DataSource = Me.V_Avoir_clientBindingSource
        DataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle9.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        DataGridViewCellStyle9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DGVIEW_avoir.DefaultCellStyle = DataGridViewCellStyle9
        Me.DGVIEW_avoir.Location = New System.Drawing.Point(3, 28)
        Me.DGVIEW_avoir.MultiSelect = False
        Me.DGVIEW_avoir.Name = "DGVIEW_avoir"
        Me.DGVIEW_avoir.ReadOnly = True
        DataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle10.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle10.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle10.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle10.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle10.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DGVIEW_avoir.RowHeadersDefaultCellStyle = DataGridViewCellStyle10
        Me.DGVIEW_avoir.RowHeadersVisible = False
        Me.DGVIEW_avoir.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DGVIEW_avoir.Size = New System.Drawing.Size(1012, 599)
        Me.DGVIEW_avoir.TabIndex = 11
        '
        'RefAvoir
        '
        Me.RefAvoir.DataPropertyName = "ID_T_Avoir"
        Me.RefAvoir.HeaderText = "Ref Avoir"
        Me.RefAvoir.Name = "RefAvoir"
        Me.RefAvoir.ReadOnly = True
        Me.RefAvoir.Width = 76
        '
        'RefCommandeVente
        '
        Me.RefCommandeVente.DataPropertyName = "ID_T_CommandeVente"
        Me.RefCommandeVente.HeaderText = "Ref Commande Vente"
        Me.RefCommandeVente.Name = "RefCommandeVente"
        Me.RefCommandeVente.ReadOnly = True
        Me.RefCommandeVente.Width = 136
        '
        'MontantDataGridViewTextBoxColumn
        '
        Me.MontantDataGridViewTextBoxColumn.DataPropertyName = "Montant"
        DataGridViewCellStyle8.Format = "C2"
        Me.MontantDataGridViewTextBoxColumn.DefaultCellStyle = DataGridViewCellStyle8
        Me.MontantDataGridViewTextBoxColumn.HeaderText = "Montant"
        Me.MontantDataGridViewTextBoxColumn.Name = "MontantDataGridViewTextBoxColumn"
        Me.MontantDataGridViewTextBoxColumn.ReadOnly = True
        Me.MontantDataGridViewTextBoxColumn.Width = 71
        '
        'CommentaireDataGridViewTextBoxColumn
        '
        Me.CommentaireDataGridViewTextBoxColumn.DataPropertyName = "Commentaire"
        Me.CommentaireDataGridViewTextBoxColumn.HeaderText = "Commentaire"
        Me.CommentaireDataGridViewTextBoxColumn.Name = "CommentaireDataGridViewTextBoxColumn"
        Me.CommentaireDataGridViewTextBoxColumn.ReadOnly = True
        Me.CommentaireDataGridViewTextBoxColumn.Width = 93
        '
        'AvoirCreeParDataGridViewTextBoxColumn
        '
        Me.AvoirCreeParDataGridViewTextBoxColumn.DataPropertyName = "AvoirCreePar"
        Me.AvoirCreeParDataGridViewTextBoxColumn.HeaderText = "Cree Par"
        Me.AvoirCreeParDataGridViewTextBoxColumn.Name = "AvoirCreeParDataGridViewTextBoxColumn"
        Me.AvoirCreeParDataGridViewTextBoxColumn.ReadOnly = True
        Me.AvoirCreeParDataGridViewTextBoxColumn.Width = 73
        '
        'AvoirCreeLeDataGridViewTextBoxColumn
        '
        Me.AvoirCreeLeDataGridViewTextBoxColumn.DataPropertyName = "AvoirCreeLe"
        Me.AvoirCreeLeDataGridViewTextBoxColumn.HeaderText = "Cree Le"
        Me.AvoirCreeLeDataGridViewTextBoxColumn.Name = "AvoirCreeLeDataGridViewTextBoxColumn"
        Me.AvoirCreeLeDataGridViewTextBoxColumn.ReadOnly = True
        Me.AvoirCreeLeDataGridViewTextBoxColumn.Width = 69
        '
        'UtiliseLe
        '
        Me.UtiliseLe.DataPropertyName = "UtiliseLe"
        Me.UtiliseLe.HeaderText = "Utilise Le"
        Me.UtiliseLe.Name = "UtiliseLe"
        Me.UtiliseLe.ReadOnly = True
        Me.UtiliseLe.Width = 75
        '
        'V_Avoir_clientBindingSource
        '
        Me.V_Avoir_clientBindingSource.DataMember = "V_Avoir_client"
        Me.V_Avoir_clientBindingSource.DataSource = Me.CLIDataSet
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripStatusLabelNbEnregistrementAvoir})
        Me.StatusStrip1.Location = New System.Drawing.Point(3, 621)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(1015, 22)
        Me.StatusStrip1.TabIndex = 10
        Me.StatusStrip1.Text = "StatusStrip"
        '
        'ToolStripStatusLabelNbEnregistrementAvoir
        '
        Me.ToolStripStatusLabelNbEnregistrementAvoir.Name = "ToolStripStatusLabelNbEnregistrementAvoir"
        Me.ToolStripStatusLabelNbEnregistrementAvoir.Size = New System.Drawing.Size(203, 17)
        Me.ToolStripStatusLabelNbEnregistrementAvoir.Text = "{0000} enregistrement(s) sélectionnés"
        '
        'TabPageArticle
        '
        Me.TabPageArticle.Controls.Add(Me.BT_Email_Article)
        Me.TabPageArticle.Controls.Add(Me.BT_Impression_Article)
        Me.TabPageArticle.Controls.Add(Me.DGview)
        Me.TabPageArticle.Controls.Add(Me.StatusStripArticles)
        Me.TabPageArticle.Location = New System.Drawing.Point(4, 22)
        Me.TabPageArticle.Name = "TabPageArticle"
        Me.TabPageArticle.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPageArticle.Size = New System.Drawing.Size(1021, 646)
        Me.TabPageArticle.TabIndex = 1
        Me.TabPageArticle.Text = "Articles"
        Me.TabPageArticle.UseVisualStyleBackColor = True
        '
        'BT_Email_Article
        '
        Me.BT_Email_Article.Image = CType(resources.GetObject("BT_Email_Article.Image"), System.Drawing.Image)
        Me.BT_Email_Article.Location = New System.Drawing.Point(88, 3)
        Me.BT_Email_Article.Name = "BT_Email_Article"
        Me.BT_Email_Article.Size = New System.Drawing.Size(78, 23)
        Me.BT_Email_Article.TabIndex = 46
        Me.BT_Email_Article.Text = "Email"
        Me.BT_Email_Article.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.BT_Email_Article.UseVisualStyleBackColor = True
        '
        'BT_Impression_Article
        '
        Me.BT_Impression_Article.Image = CType(resources.GetObject("BT_Impression_Article.Image"), System.Drawing.Image)
        Me.BT_Impression_Article.Location = New System.Drawing.Point(4, 3)
        Me.BT_Impression_Article.Name = "BT_Impression_Article"
        Me.BT_Impression_Article.Size = New System.Drawing.Size(78, 23)
        Me.BT_Impression_Article.TabIndex = 46
        Me.BT_Impression_Article.Text = "Imprimer"
        Me.BT_Impression_Article.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.BT_Impression_Article.UseVisualStyleBackColor = True
        '
        'DGview
        '
        Me.DGview.AllowUserToAddRows = False
        Me.DGview.AllowUserToDeleteRows = False
        Me.DGview.AllowUserToResizeRows = False
        DataGridViewCellStyle11.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.DGview.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle11
        Me.DGview.AutoGenerateColumns = False
        Me.DGview.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells
        DataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle12.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle12.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle12.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle12.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle12.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle12.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DGview.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle12
        Me.DGview.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Active_on, Me.Ref, Me.Descriptioncourte, Me.prix_vente_initial_TTC, Me.remise, Me.prix_vente_remise_TTC, Me.web_on, Me.magasin_on, Me.Stock, Me.RefDataGridViewTextBoxColumn, Me.FamilleDataGridViewTextBoxColumn, Me.SousFamilleDataGridViewTextBoxColumn, Me.DescriptionCourteDataGridViewTextBoxColumn, Me.MarqueDataGridViewTextBoxColumn, Me.ModeleDataGridViewTextBoxColumn, Me.WebonDataGridViewCheckBoxColumn, Me.MagasinonDataGridViewCheckBoxColumn, Me.StockDataGridViewTextBoxColumn, Me.ActiveonDataGridViewCheckBoxColumn, Me.PrixventeinitialTTCDataGridViewTextBoxColumn, Me.PrixventeremiseTTCDataGridViewTextBoxColumn, Me.RemiseDataGridViewTextBoxColumn, Me.DepotventeDataGridViewCheckBoxColumn, Me.OccazDataGridViewCheckBoxColumn, Me.IDtarticleenteteDataGridViewTextBoxColumn, Me.IDtarticledetailDataGridViewTextBoxColumn, Me.IDTFournisseurDataGridViewTextBoxColumn, Me.ReffournisseurDataGridViewTextBoxColumn, Me.IDTClientDataGridViewTextBoxColumn})
        Me.DGview.DataSource = Me.VRechercheArticleBindingSource
        DataGridViewCellStyle17.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle17.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        DataGridViewCellStyle17.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle17.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle17.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle17.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle17.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DGview.DefaultCellStyle = DataGridViewCellStyle17
        Me.DGview.Location = New System.Drawing.Point(3, 27)
        Me.DGview.MultiSelect = False
        Me.DGview.Name = "DGview"
        Me.DGview.ReadOnly = True
        DataGridViewCellStyle18.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle18.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle18.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle18.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle18.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle18.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle18.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DGview.RowHeadersDefaultCellStyle = DataGridViewCellStyle18
        Me.DGview.RowHeadersVisible = False
        Me.DGview.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DGview.Size = New System.Drawing.Size(1012, 600)
        Me.DGview.TabIndex = 10
        '
        'Active_on
        '
        Me.Active_on.DataPropertyName = "Active_on"
        Me.Active_on.HeaderText = "Activé ?"
        Me.Active_on.Name = "Active_on"
        Me.Active_on.ReadOnly = True
        Me.Active_on.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.Active_on.Width = 71
        '
        'Ref
        '
        Me.Ref.DataPropertyName = "Ref"
        Me.Ref.HeaderText = "Ref"
        Me.Ref.Name = "Ref"
        Me.Ref.ReadOnly = True
        Me.Ref.Width = 49
        '
        'Descriptioncourte
        '
        Me.Descriptioncourte.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.Descriptioncourte.DataPropertyName = "Description courte"
        Me.Descriptioncourte.HeaderText = "Description courte"
        Me.Descriptioncourte.Name = "Descriptioncourte"
        Me.Descriptioncourte.ReadOnly = True
        Me.Descriptioncourte.Width = 118
        '
        'prix_vente_initial_TTC
        '
        Me.prix_vente_initial_TTC.DataPropertyName = "prix_vente_initial_TTC"
        DataGridViewCellStyle13.Format = "C2"
        DataGridViewCellStyle13.NullValue = Nothing
        Me.prix_vente_initial_TTC.DefaultCellStyle = DataGridViewCellStyle13
        Me.prix_vente_initial_TTC.HeaderText = "PV initial TTC"
        Me.prix_vente_initial_TTC.Name = "prix_vente_initial_TTC"
        Me.prix_vente_initial_TTC.ReadOnly = True
        Me.prix_vente_initial_TTC.Width = 96
        '
        'remise
        '
        Me.remise.DataPropertyName = "remise"
        DataGridViewCellStyle14.Format = "0 %"
        DataGridViewCellStyle14.NullValue = "-"
        Me.remise.DefaultCellStyle = DataGridViewCellStyle14
        Me.remise.HeaderText = "Remise"
        Me.remise.Name = "remise"
        Me.remise.ReadOnly = True
        Me.remise.Width = 67
        '
        'prix_vente_remise_TTC
        '
        Me.prix_vente_remise_TTC.DataPropertyName = "prix_vente_remise_TTC"
        DataGridViewCellStyle15.Format = "C2"
        Me.prix_vente_remise_TTC.DefaultCellStyle = DataGridViewCellStyle15
        Me.prix_vente_remise_TTC.HeaderText = "PV Remisé TTC"
        Me.prix_vente_remise_TTC.Name = "prix_vente_remise_TTC"
        Me.prix_vente_remise_TTC.ReadOnly = True
        Me.prix_vente_remise_TTC.Width = 108
        '
        'web_on
        '
        Me.web_on.DataPropertyName = "web_on"
        Me.web_on.HeaderText = "Web?"
        Me.web_on.Name = "web_on"
        Me.web_on.ReadOnly = True
        Me.web_on.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.web_on.Width = 61
        '
        'magasin_on
        '
        Me.magasin_on.DataPropertyName = "magasin_on"
        Me.magasin_on.HeaderText = "Magasin?"
        Me.magasin_on.Name = "magasin_on"
        Me.magasin_on.ReadOnly = True
        Me.magasin_on.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.magasin_on.Width = 78
        '
        'Stock
        '
        Me.Stock.DataPropertyName = "Stock"
        DataGridViewCellStyle16.NullValue = "0"
        Me.Stock.DefaultCellStyle = DataGridViewCellStyle16
        Me.Stock.HeaderText = "Stock"
        Me.Stock.Name = "Stock"
        Me.Stock.ReadOnly = True
        Me.Stock.Width = 60
        '
        'RefDataGridViewTextBoxColumn
        '
        Me.RefDataGridViewTextBoxColumn.DataPropertyName = "Ref"
        Me.RefDataGridViewTextBoxColumn.HeaderText = "Ref"
        Me.RefDataGridViewTextBoxColumn.Name = "RefDataGridViewTextBoxColumn"
        Me.RefDataGridViewTextBoxColumn.ReadOnly = True
        Me.RefDataGridViewTextBoxColumn.Visible = False
        Me.RefDataGridViewTextBoxColumn.Width = 49
        '
        'FamilleDataGridViewTextBoxColumn
        '
        Me.FamilleDataGridViewTextBoxColumn.DataPropertyName = "Famille"
        Me.FamilleDataGridViewTextBoxColumn.HeaderText = "Famille"
        Me.FamilleDataGridViewTextBoxColumn.Name = "FamilleDataGridViewTextBoxColumn"
        Me.FamilleDataGridViewTextBoxColumn.ReadOnly = True
        Me.FamilleDataGridViewTextBoxColumn.Width = 64
        '
        'SousFamilleDataGridViewTextBoxColumn
        '
        Me.SousFamilleDataGridViewTextBoxColumn.DataPropertyName = "Sous Famille"
        Me.SousFamilleDataGridViewTextBoxColumn.HeaderText = "Sous Famille"
        Me.SousFamilleDataGridViewTextBoxColumn.Name = "SousFamilleDataGridViewTextBoxColumn"
        Me.SousFamilleDataGridViewTextBoxColumn.ReadOnly = True
        Me.SousFamilleDataGridViewTextBoxColumn.Width = 91
        '
        'DescriptionCourteDataGridViewTextBoxColumn
        '
        Me.DescriptionCourteDataGridViewTextBoxColumn.DataPropertyName = "Description courte"
        Me.DescriptionCourteDataGridViewTextBoxColumn.HeaderText = "Description courte"
        Me.DescriptionCourteDataGridViewTextBoxColumn.Name = "DescriptionCourteDataGridViewTextBoxColumn"
        Me.DescriptionCourteDataGridViewTextBoxColumn.ReadOnly = True
        Me.DescriptionCourteDataGridViewTextBoxColumn.Visible = False
        Me.DescriptionCourteDataGridViewTextBoxColumn.Width = 118
        '
        'MarqueDataGridViewTextBoxColumn
        '
        Me.MarqueDataGridViewTextBoxColumn.DataPropertyName = "marque"
        Me.MarqueDataGridViewTextBoxColumn.HeaderText = "marque"
        Me.MarqueDataGridViewTextBoxColumn.Name = "MarqueDataGridViewTextBoxColumn"
        Me.MarqueDataGridViewTextBoxColumn.ReadOnly = True
        Me.MarqueDataGridViewTextBoxColumn.Visible = False
        Me.MarqueDataGridViewTextBoxColumn.Width = 67
        '
        'ModeleDataGridViewTextBoxColumn
        '
        Me.ModeleDataGridViewTextBoxColumn.DataPropertyName = "modele"
        Me.ModeleDataGridViewTextBoxColumn.HeaderText = "modele"
        Me.ModeleDataGridViewTextBoxColumn.Name = "ModeleDataGridViewTextBoxColumn"
        Me.ModeleDataGridViewTextBoxColumn.ReadOnly = True
        Me.ModeleDataGridViewTextBoxColumn.Visible = False
        Me.ModeleDataGridViewTextBoxColumn.Width = 66
        '
        'WebonDataGridViewCheckBoxColumn
        '
        Me.WebonDataGridViewCheckBoxColumn.DataPropertyName = "web_on"
        Me.WebonDataGridViewCheckBoxColumn.HeaderText = "web_on"
        Me.WebonDataGridViewCheckBoxColumn.Name = "WebonDataGridViewCheckBoxColumn"
        Me.WebonDataGridViewCheckBoxColumn.ReadOnly = True
        Me.WebonDataGridViewCheckBoxColumn.Visible = False
        Me.WebonDataGridViewCheckBoxColumn.Width = 51
        '
        'MagasinonDataGridViewCheckBoxColumn
        '
        Me.MagasinonDataGridViewCheckBoxColumn.DataPropertyName = "magasin_on"
        Me.MagasinonDataGridViewCheckBoxColumn.HeaderText = "magasin_on"
        Me.MagasinonDataGridViewCheckBoxColumn.Name = "MagasinonDataGridViewCheckBoxColumn"
        Me.MagasinonDataGridViewCheckBoxColumn.ReadOnly = True
        Me.MagasinonDataGridViewCheckBoxColumn.Visible = False
        Me.MagasinonDataGridViewCheckBoxColumn.Width = 70
        '
        'StockDataGridViewTextBoxColumn
        '
        Me.StockDataGridViewTextBoxColumn.DataPropertyName = "Stock"
        Me.StockDataGridViewTextBoxColumn.HeaderText = "Stock"
        Me.StockDataGridViewTextBoxColumn.Name = "StockDataGridViewTextBoxColumn"
        Me.StockDataGridViewTextBoxColumn.ReadOnly = True
        Me.StockDataGridViewTextBoxColumn.Visible = False
        Me.StockDataGridViewTextBoxColumn.Width = 60
        '
        'ActiveonDataGridViewCheckBoxColumn
        '
        Me.ActiveonDataGridViewCheckBoxColumn.DataPropertyName = "Active_on"
        Me.ActiveonDataGridViewCheckBoxColumn.HeaderText = "Active_on"
        Me.ActiveonDataGridViewCheckBoxColumn.Name = "ActiveonDataGridViewCheckBoxColumn"
        Me.ActiveonDataGridViewCheckBoxColumn.ReadOnly = True
        Me.ActiveonDataGridViewCheckBoxColumn.Visible = False
        Me.ActiveonDataGridViewCheckBoxColumn.Width = 61
        '
        'PrixventeinitialTTCDataGridViewTextBoxColumn
        '
        Me.PrixventeinitialTTCDataGridViewTextBoxColumn.DataPropertyName = "prix_vente_initial_TTC"
        Me.PrixventeinitialTTCDataGridViewTextBoxColumn.HeaderText = "prix_vente_initial_TTC"
        Me.PrixventeinitialTTCDataGridViewTextBoxColumn.Name = "PrixventeinitialTTCDataGridViewTextBoxColumn"
        Me.PrixventeinitialTTCDataGridViewTextBoxColumn.ReadOnly = True
        Me.PrixventeinitialTTCDataGridViewTextBoxColumn.Visible = False
        Me.PrixventeinitialTTCDataGridViewTextBoxColumn.Width = 137
        '
        'PrixventeremiseTTCDataGridViewTextBoxColumn
        '
        Me.PrixventeremiseTTCDataGridViewTextBoxColumn.DataPropertyName = "prix_vente_remise_TTC"
        Me.PrixventeremiseTTCDataGridViewTextBoxColumn.HeaderText = "prix_vente_remise_TTC"
        Me.PrixventeremiseTTCDataGridViewTextBoxColumn.Name = "PrixventeremiseTTCDataGridViewTextBoxColumn"
        Me.PrixventeremiseTTCDataGridViewTextBoxColumn.ReadOnly = True
        Me.PrixventeremiseTTCDataGridViewTextBoxColumn.Visible = False
        Me.PrixventeremiseTTCDataGridViewTextBoxColumn.Width = 144
        '
        'RemiseDataGridViewTextBoxColumn
        '
        Me.RemiseDataGridViewTextBoxColumn.DataPropertyName = "remise"
        Me.RemiseDataGridViewTextBoxColumn.HeaderText = "remise"
        Me.RemiseDataGridViewTextBoxColumn.Name = "RemiseDataGridViewTextBoxColumn"
        Me.RemiseDataGridViewTextBoxColumn.ReadOnly = True
        Me.RemiseDataGridViewTextBoxColumn.Visible = False
        Me.RemiseDataGridViewTextBoxColumn.Width = 62
        '
        'DepotventeDataGridViewCheckBoxColumn
        '
        Me.DepotventeDataGridViewCheckBoxColumn.DataPropertyName = "depot_vente"
        Me.DepotventeDataGridViewCheckBoxColumn.HeaderText = "depot_vente"
        Me.DepotventeDataGridViewCheckBoxColumn.Name = "DepotventeDataGridViewCheckBoxColumn"
        Me.DepotventeDataGridViewCheckBoxColumn.ReadOnly = True
        Me.DepotventeDataGridViewCheckBoxColumn.Visible = False
        Me.DepotventeDataGridViewCheckBoxColumn.Width = 73
        '
        'OccazDataGridViewCheckBoxColumn
        '
        Me.OccazDataGridViewCheckBoxColumn.DataPropertyName = "occaz"
        Me.OccazDataGridViewCheckBoxColumn.HeaderText = "occaz"
        Me.OccazDataGridViewCheckBoxColumn.Name = "OccazDataGridViewCheckBoxColumn"
        Me.OccazDataGridViewCheckBoxColumn.ReadOnly = True
        Me.OccazDataGridViewCheckBoxColumn.Visible = False
        Me.OccazDataGridViewCheckBoxColumn.Width = 42
        '
        'IDtarticleenteteDataGridViewTextBoxColumn
        '
        Me.IDtarticleenteteDataGridViewTextBoxColumn.DataPropertyName = "ID_t_article_entete"
        Me.IDtarticleenteteDataGridViewTextBoxColumn.HeaderText = "ID_t_article_entete"
        Me.IDtarticleenteteDataGridViewTextBoxColumn.Name = "IDtarticleenteteDataGridViewTextBoxColumn"
        Me.IDtarticleenteteDataGridViewTextBoxColumn.ReadOnly = True
        Me.IDtarticleenteteDataGridViewTextBoxColumn.Visible = False
        Me.IDtarticleenteteDataGridViewTextBoxColumn.Width = 122
        '
        'IDtarticledetailDataGridViewTextBoxColumn
        '
        Me.IDtarticledetailDataGridViewTextBoxColumn.DataPropertyName = "ID_t_article_detail"
        Me.IDtarticledetailDataGridViewTextBoxColumn.HeaderText = "ID_t_article_detail"
        Me.IDtarticledetailDataGridViewTextBoxColumn.Name = "IDtarticledetailDataGridViewTextBoxColumn"
        Me.IDtarticledetailDataGridViewTextBoxColumn.ReadOnly = True
        Me.IDtarticledetailDataGridViewTextBoxColumn.Visible = False
        Me.IDtarticledetailDataGridViewTextBoxColumn.Width = 117
        '
        'IDTFournisseurDataGridViewTextBoxColumn
        '
        Me.IDTFournisseurDataGridViewTextBoxColumn.DataPropertyName = "ID_T_Fournisseur"
        Me.IDTFournisseurDataGridViewTextBoxColumn.HeaderText = "ID_T_Fournisseur"
        Me.IDTFournisseurDataGridViewTextBoxColumn.Name = "IDTFournisseurDataGridViewTextBoxColumn"
        Me.IDTFournisseurDataGridViewTextBoxColumn.ReadOnly = True
        Me.IDTFournisseurDataGridViewTextBoxColumn.Visible = False
        Me.IDTFournisseurDataGridViewTextBoxColumn.Width = 116
        '
        'ReffournisseurDataGridViewTextBoxColumn
        '
        Me.ReffournisseurDataGridViewTextBoxColumn.DataPropertyName = "ref_fournisseur"
        Me.ReffournisseurDataGridViewTextBoxColumn.HeaderText = "ref_fournisseur"
        Me.ReffournisseurDataGridViewTextBoxColumn.Name = "ReffournisseurDataGridViewTextBoxColumn"
        Me.ReffournisseurDataGridViewTextBoxColumn.ReadOnly = True
        Me.ReffournisseurDataGridViewTextBoxColumn.Visible = False
        Me.ReffournisseurDataGridViewTextBoxColumn.Width = 101
        '
        'IDTClientDataGridViewTextBoxColumn
        '
        Me.IDTClientDataGridViewTextBoxColumn.DataPropertyName = "ID_T_Client"
        Me.IDTClientDataGridViewTextBoxColumn.HeaderText = "ID_T_Client"
        Me.IDTClientDataGridViewTextBoxColumn.Name = "IDTClientDataGridViewTextBoxColumn"
        Me.IDTClientDataGridViewTextBoxColumn.ReadOnly = True
        Me.IDTClientDataGridViewTextBoxColumn.Visible = False
        Me.IDTClientDataGridViewTextBoxColumn.Width = 88
        '
        'VRechercheArticleBindingSource
        '
        Me.VRechercheArticleBindingSource.DataMember = "V_Recherche_Article"
        Me.VRechercheArticleBindingSource.DataSource = Me.CLIDataSet
        '
        'StatusStripArticles
        '
        Me.StatusStripArticles.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripStatusLabelNbEnregistrementsArticles})
        Me.StatusStripArticles.Location = New System.Drawing.Point(3, 621)
        Me.StatusStripArticles.Name = "StatusStripArticles"
        Me.StatusStripArticles.Size = New System.Drawing.Size(1015, 22)
        Me.StatusStripArticles.TabIndex = 9
        Me.StatusStripArticles.Text = "StatusStrip"
        '
        'ToolStripStatusLabelNbEnregistrementsArticles
        '
        Me.ToolStripStatusLabelNbEnregistrementsArticles.Name = "ToolStripStatusLabelNbEnregistrementsArticles"
        Me.ToolStripStatusLabelNbEnregistrementsArticles.Size = New System.Drawing.Size(203, 17)
        Me.ToolStripStatusLabelNbEnregistrementsArticles.Text = "{0000} enregistrement(s) sélectionnés"
        '
        'TabPageGeneral
        '
        Me.TabPageGeneral.AutoScroll = True
        Me.TabPageGeneral.Controls.Add(Me.I_ErrorDetail)
        Me.TabPageGeneral.Controls.Add(Me.BT_SyncAdresses)
        Me.TabPageGeneral.Controls.Add(Me.BT_SyncAvoirs)
        Me.TabPageGeneral.Controls.Add(Me.BT_DetailSynchro)
        Me.TabPageGeneral.Controls.Add(Me.I_EtatSynchroPrestashop)
        Me.TabPageGeneral.Controls.Add(EtatSynchroPrestashopLabel)
        Me.TabPageGeneral.Controls.Add(Me.ToSyncCheckBox)
        Me.TabPageGeneral.Controls.Add(Label3)
        Me.TabPageGeneral.Controls.Add(Me.MaskedTextBoxDateNaissance)
        Me.TabPageGeneral.Controls.Add(TitreLabel)
        Me.TabPageGeneral.Controls.Add(Me.TitreComboBox)
        Me.TabPageGeneral.Controls.Add(Me.IdCustomerPrestashopTextBox)
        Me.TabPageGeneral.Controls.Add(Label1)
        Me.TabPageGeneral.Controls.Add(ExportLabel)
        Me.TabPageGeneral.Controls.Add(Me.ExportCheckBox)
        Me.TabPageGeneral.Controls.Add(Me.SupCheckBox)
        Me.TabPageGeneral.Controls.Add(Me.KiteCheckBox)
        Me.TabPageGeneral.Controls.Add(WindLabel)
        Me.TabPageGeneral.Controls.Add(Me.WindCheckBox)
        Me.TabPageGeneral.Controls.Add(CommentairesLabel)
        Me.TabPageGeneral.Controls.Add(Me.CommentairesTextBox)
        Me.TabPageGeneral.Controls.Add(Label2)
        Me.TabPageGeneral.Controls.Add(NoSiretLabel)
        Me.TabPageGeneral.Controls.Add(Me.ApeTextBox)
        Me.TabPageGeneral.Controls.Add(Me.NoSiretTextBox)
        Me.TabPageGeneral.Controls.Add(NoTVALabel)
        Me.TabPageGeneral.Controls.Add(Me.NoTVATextBox)
        Me.TabPageGeneral.Controls.Add(NumeroIdentiteLabel)
        Me.TabPageGeneral.Controls.Add(Me.NumeroIdentiteTextBox)
        Me.TabPageGeneral.Controls.Add(Me.NewsLetterCheckBox)
        Me.TabPageGeneral.Controls.Add(PasswordLabel)
        Me.TabPageGeneral.Controls.Add(Me.PasswordTextBox)
        Me.TabPageGeneral.Controls.Add(ActifLabel)
        Me.TabPageGeneral.Controls.Add(Me.ActifCheckBox)
        Me.TabPageGeneral.Controls.Add(ModifieLeLabel)
        Me.TabPageGeneral.Controls.Add(Me.ModifieLeTextBox)
        Me.TabPageGeneral.Controls.Add(Me.ModifieParTextBox)
        Me.TabPageGeneral.Controls.Add(Me.CreeLeTextBox)
        Me.TabPageGeneral.Controls.Add(Me.CreeParTextBox)
        Me.TabPageGeneral.Controls.Add(Me.EmailTextBox)
        Me.TabPageGeneral.Controls.Add(Me.FaxTextBox)
        Me.TabPageGeneral.Controls.Add(Me.MobileTextBox)
        Me.TabPageGeneral.Controls.Add(Me.TelTextBox)
        Me.TabPageGeneral.Controls.Add(Me.VilleTextBox)
        Me.TabPageGeneral.Controls.Add(Me.CodePostalTextBox)
        Me.TabPageGeneral.Controls.Add(Me.AdresseL3TextBox)
        Me.TabPageGeneral.Controls.Add(Me.AdresseL2TextBox)
        Me.TabPageGeneral.Controls.Add(Me.AdresseL1TextBox)
        Me.TabPageGeneral.Controls.Add(Me.PrenomTextBox)
        Me.TabPageGeneral.Controls.Add(Me.NomTextBox)
        Me.TabPageGeneral.Controls.Add(Me.SociétéTextBox)
        Me.TabPageGeneral.Controls.Add(Me.ID_T_ClientTextBox)
        Me.TabPageGeneral.Controls.Add(ModifieParLabel)
        Me.TabPageGeneral.Controls.Add(CreeLeLabel)
        Me.TabPageGeneral.Controls.Add(CreeParLabel)
        Me.TabPageGeneral.Controls.Add(EmailLabel)
        Me.TabPageGeneral.Controls.Add(FaxLabel)
        Me.TabPageGeneral.Controls.Add(MobileLabel)
        Me.TabPageGeneral.Controls.Add(LabelDatenaissance)
        Me.TabPageGeneral.Controls.Add(TelLabel)
        Me.TabPageGeneral.Controls.Add(PaysLabel)
        Me.TabPageGeneral.Controls.Add(Me.PaysComboBox)
        Me.TabPageGeneral.Controls.Add(VilleLabel)
        Me.TabPageGeneral.Controls.Add(CodePostalLabel)
        Me.TabPageGeneral.Controls.Add(AdresseL3Label)
        Me.TabPageGeneral.Controls.Add(AdresseL2Label)
        Me.TabPageGeneral.Controls.Add(AdresseL1Label)
        Me.TabPageGeneral.Controls.Add(PrenomLabel)
        Me.TabPageGeneral.Controls.Add(NomLabel)
        Me.TabPageGeneral.Controls.Add(SociétéLabel)
        Me.TabPageGeneral.Controls.Add(ID_T_FournisseurLabel)
        Me.TabPageGeneral.Controls.Add(Me.ToolStrip)
        Me.TabPageGeneral.Location = New System.Drawing.Point(4, 22)
        Me.TabPageGeneral.Name = "TabPageGeneral"
        Me.TabPageGeneral.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPageGeneral.Size = New System.Drawing.Size(1021, 646)
        Me.TabPageGeneral.TabIndex = 0
        Me.TabPageGeneral.Text = "Infos générales"
        Me.TabPageGeneral.UseVisualStyleBackColor = True
        '
        'BT_SyncAdresses
        '
        Me.BT_SyncAdresses.Location = New System.Drawing.Point(857, 545)
        Me.BT_SyncAdresses.Name = "BT_SyncAdresses"
        Me.BT_SyncAdresses.Size = New System.Drawing.Size(122, 23)
        Me.BT_SyncAdresses.TabIndex = 169
        Me.BT_SyncAdresses.Text = "Syncroniser Adresses"
        Me.BT_SyncAdresses.UseVisualStyleBackColor = True
        '
        'BT_SyncAvoirs
        '
        Me.BT_SyncAvoirs.Location = New System.Drawing.Point(857, 516)
        Me.BT_SyncAvoirs.Name = "BT_SyncAvoirs"
        Me.BT_SyncAvoirs.Size = New System.Drawing.Size(122, 23)
        Me.BT_SyncAvoirs.TabIndex = 169
        Me.BT_SyncAvoirs.Text = "Syncroniser Avoirs"
        Me.BT_SyncAvoirs.UseVisualStyleBackColor = True
        '
        'BT_DetailSynchro
        '
        Me.BT_DetailSynchro.Location = New System.Drawing.Point(857, 487)
        Me.BT_DetailSynchro.Name = "BT_DetailSynchro"
        Me.BT_DetailSynchro.Size = New System.Drawing.Size(75, 23)
        Me.BT_DetailSynchro.TabIndex = 168
        Me.BT_DetailSynchro.Text = "Detail"
        Me.BT_DetailSynchro.UseVisualStyleBackColor = True
        '
        'I_EtatSynchroPrestashop
        '
        Me.I_EtatSynchroPrestashop.Location = New System.Drawing.Point(857, 460)
        Me.I_EtatSynchroPrestashop.Name = "I_EtatSynchroPrestashop"
        Me.I_EtatSynchroPrestashop.ReadOnly = True
        Me.I_EtatSynchroPrestashop.Size = New System.Drawing.Size(100, 20)
        Me.I_EtatSynchroPrestashop.TabIndex = 167
        '
        'ToSyncCheckBox
        '
        Me.ToSyncCheckBox.DataBindings.Add(New System.Windows.Forms.Binding("CheckState", Me.T_ClientBindingSource, "ToSync", True))
        Me.ToSyncCheckBox.Location = New System.Drawing.Point(722, 363)
        Me.ToSyncCheckBox.Name = "ToSyncCheckBox"
        Me.ToSyncCheckBox.Size = New System.Drawing.Size(16, 24)
        Me.ToSyncCheckBox.TabIndex = 165
        Me.ToSyncCheckBox.UseVisualStyleBackColor = True
        '
        'MaskedTextBoxDateNaissance
        '
        Me.MaskedTextBoxDateNaissance.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.T_ClientBindingSource, "Datenaissance", True))
        Me.MaskedTextBoxDateNaissance.Location = New System.Drawing.Point(122, 487)
        Me.MaskedTextBoxDateNaissance.Mask = "00/00/0000"
        Me.MaskedTextBoxDateNaissance.Name = "MaskedTextBoxDateNaissance"
        Me.MaskedTextBoxDateNaissance.Size = New System.Drawing.Size(100, 20)
        Me.MaskedTextBoxDateNaissance.TabIndex = 163
        Me.MaskedTextBoxDateNaissance.ValidatingType = GetType(Date)
        '
        'TitreComboBox
        '
        Me.TitreComboBox.DataBindings.Add(New System.Windows.Forms.Binding("SelectedValue", Me.T_ClientBindingSource, "Titre", True))
        Me.TitreComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.TitreComboBox.FormattingEnabled = True
        Me.TitreComboBox.Location = New System.Drawing.Point(121, 202)
        Me.TitreComboBox.Name = "TitreComboBox"
        Me.TitreComboBox.Size = New System.Drawing.Size(140, 21)
        Me.TitreComboBox.TabIndex = 162
        '
        'IdCustomerPrestashopTextBox
        '
        Me.IdCustomerPrestashopTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.T_ClientBindingSource, "IdCustomerPrestashop", True))
        Me.IdCustomerPrestashopTextBox.Location = New System.Drawing.Point(616, 365)
        Me.IdCustomerPrestashopTextBox.Name = "IdCustomerPrestashopTextBox"
        Me.IdCustomerPrestashopTextBox.ReadOnly = True
        Me.IdCustomerPrestashopTextBox.Size = New System.Drawing.Size(100, 20)
        Me.IdCustomerPrestashopTextBox.TabIndex = 160
        '
        'ExportCheckBox
        '
        Me.ExportCheckBox.DataBindings.Add(New System.Windows.Forms.Binding("CheckState", Me.T_ClientBindingSource, "Export", True))
        Me.ExportCheckBox.Location = New System.Drawing.Point(413, 94)
        Me.ExportCheckBox.Name = "ExportCheckBox"
        Me.ExportCheckBox.Size = New System.Drawing.Size(104, 24)
        Me.ExportCheckBox.TabIndex = 159
        Me.ExportCheckBox.UseVisualStyleBackColor = True
        '
        'SupCheckBox
        '
        Me.SupCheckBox.DataBindings.Add(New System.Windows.Forms.Binding("CheckState", Me.T_ClientBindingSource, "Sup", True))
        Me.SupCheckBox.Location = New System.Drawing.Point(253, 562)
        Me.SupCheckBox.Name = "SupCheckBox"
        Me.SupCheckBox.Size = New System.Drawing.Size(104, 24)
        Me.SupCheckBox.TabIndex = 157
        Me.SupCheckBox.Text = "Sup"
        Me.SupCheckBox.UseVisualStyleBackColor = True
        '
        'KiteCheckBox
        '
        Me.KiteCheckBox.DataBindings.Add(New System.Windows.Forms.Binding("CheckState", Me.T_ClientBindingSource, "Kite", True))
        Me.KiteCheckBox.Location = New System.Drawing.Point(192, 562)
        Me.KiteCheckBox.Name = "KiteCheckBox"
        Me.KiteCheckBox.Size = New System.Drawing.Size(104, 24)
        Me.KiteCheckBox.TabIndex = 156
        Me.KiteCheckBox.Text = "Kitesurf"
        Me.KiteCheckBox.UseVisualStyleBackColor = True
        '
        'WindCheckBox
        '
        Me.WindCheckBox.DataBindings.Add(New System.Windows.Forms.Binding("CheckState", Me.T_ClientBindingSource, "Wind", True))
        Me.WindCheckBox.Location = New System.Drawing.Point(121, 562)
        Me.WindCheckBox.Name = "WindCheckBox"
        Me.WindCheckBox.Size = New System.Drawing.Size(104, 24)
        Me.WindCheckBox.TabIndex = 155
        Me.WindCheckBox.Text = "Windsurf"
        Me.WindCheckBox.UseVisualStyleBackColor = True
        '
        'CommentairesTextBox
        '
        Me.CommentairesTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.T_ClientBindingSource, "Commentaires", True))
        Me.CommentairesTextBox.Location = New System.Drawing.Point(561, 72)
        Me.CommentairesTextBox.MaxLength = 4000
        Me.CommentairesTextBox.Multiline = True
        Me.CommentairesTextBox.Name = "CommentairesTextBox"
        Me.CommentairesTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.CommentairesTextBox.Size = New System.Drawing.Size(331, 283)
        Me.CommentairesTextBox.TabIndex = 154
        '
        'ApeTextBox
        '
        Me.ApeTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.T_ClientBindingSource, "Ape", True))
        Me.ApeTextBox.Location = New System.Drawing.Point(121, 176)
        Me.ApeTextBox.Name = "ApeTextBox"
        Me.ApeTextBox.Size = New System.Drawing.Size(140, 20)
        Me.ApeTextBox.TabIndex = 3
        '
        'NoSiretTextBox
        '
        Me.NoSiretTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.T_ClientBindingSource, "NoSiret", True))
        Me.NoSiretTextBox.Location = New System.Drawing.Point(121, 150)
        Me.NoSiretTextBox.Name = "NoSiretTextBox"
        Me.NoSiretTextBox.Size = New System.Drawing.Size(140, 20)
        Me.NoSiretTextBox.TabIndex = 3
        '
        'NoTVATextBox
        '
        Me.NoTVATextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.T_ClientBindingSource, "NoTVA", True))
        Me.NoTVATextBox.Location = New System.Drawing.Point(121, 124)
        Me.NoTVATextBox.Name = "NoTVATextBox"
        Me.NoTVATextBox.Size = New System.Drawing.Size(140, 20)
        Me.NoTVATextBox.TabIndex = 2
        '
        'NumeroIdentiteTextBox
        '
        Me.NumeroIdentiteTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.T_ClientBindingSource, "NumeroIdentite", True))
        Me.NumeroIdentiteTextBox.Location = New System.Drawing.Point(121, 511)
        Me.NumeroIdentiteTextBox.Name = "NumeroIdentiteTextBox"
        Me.NumeroIdentiteTextBox.Size = New System.Drawing.Size(221, 20)
        Me.NumeroIdentiteTextBox.TabIndex = 16
        '
        'NewsLetterCheckBox
        '
        Me.NewsLetterCheckBox.DataBindings.Add(New System.Windows.Forms.Binding("CheckState", Me.T_ClientBindingSource, "NewsLetter", True))
        Me.NewsLetterCheckBox.Location = New System.Drawing.Point(348, 464)
        Me.NewsLetterCheckBox.Name = "NewsLetterCheckBox"
        Me.NewsLetterCheckBox.Size = New System.Drawing.Size(157, 24)
        Me.NewsLetterCheckBox.TabIndex = 152
        Me.NewsLetterCheckBox.Text = "Abonnement NewsLetter"
        Me.NewsLetterCheckBox.UseVisualStyleBackColor = True
        '
        'PasswordTextBox
        '
        Me.PasswordTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.T_ClientBindingSource, "password", True))
        Me.PasswordTextBox.Location = New System.Drawing.Point(121, 536)
        Me.PasswordTextBox.Name = "PasswordTextBox"
        Me.PasswordTextBox.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.PasswordTextBox.Size = New System.Drawing.Size(100, 20)
        Me.PasswordTextBox.TabIndex = 17
        '
        'ActifCheckBox
        '
        Me.ActifCheckBox.DataBindings.Add(New System.Windows.Forms.Binding("CheckState", Me.T_ClientBindingSource, "Actif", True))
        Me.ActifCheckBox.Location = New System.Drawing.Point(413, 64)
        Me.ActifCheckBox.Name = "ActifCheckBox"
        Me.ActifCheckBox.Size = New System.Drawing.Size(104, 24)
        Me.ActifCheckBox.TabIndex = 150
        Me.ActifCheckBox.UseVisualStyleBackColor = True
        '
        'ModifieLeTextBox
        '
        Me.ModifieLeTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.T_ClientBindingSource, "ModifieLe", True))
        Me.ModifieLeTextBox.Location = New System.Drawing.Point(857, 420)
        Me.ModifieLeTextBox.Name = "ModifieLeTextBox"
        Me.ModifieLeTextBox.ReadOnly = True
        Me.ModifieLeTextBox.Size = New System.Drawing.Size(100, 20)
        Me.ModifieLeTextBox.TabIndex = 19
        '
        'ModifieParTextBox
        '
        Me.ModifieParTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.T_ClientBindingSource, "ModifiePar", True))
        Me.ModifieParTextBox.Location = New System.Drawing.Point(857, 394)
        Me.ModifieParTextBox.Name = "ModifieParTextBox"
        Me.ModifieParTextBox.ReadOnly = True
        Me.ModifieParTextBox.Size = New System.Drawing.Size(100, 20)
        Me.ModifieParTextBox.TabIndex = 20
        '
        'CreeLeTextBox
        '
        Me.CreeLeTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.T_ClientBindingSource, "CreeLe", True))
        Me.CreeLeTextBox.Location = New System.Drawing.Point(616, 417)
        Me.CreeLeTextBox.Name = "CreeLeTextBox"
        Me.CreeLeTextBox.ReadOnly = True
        Me.CreeLeTextBox.Size = New System.Drawing.Size(100, 20)
        Me.CreeLeTextBox.TabIndex = 19
        '
        'CreeParTextBox
        '
        Me.CreeParTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.T_ClientBindingSource, "CreePar", True))
        Me.CreeParTextBox.Location = New System.Drawing.Point(616, 391)
        Me.CreeParTextBox.Name = "CreeParTextBox"
        Me.CreeParTextBox.ReadOnly = True
        Me.CreeParTextBox.Size = New System.Drawing.Size(100, 20)
        Me.CreeParTextBox.TabIndex = 18
        '
        'EmailTextBox
        '
        Me.EmailTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.T_ClientBindingSource, "Email", True))
        Me.EmailTextBox.Location = New System.Drawing.Point(122, 464)
        Me.EmailTextBox.MaxLength = 255
        Me.EmailTextBox.Name = "EmailTextBox"
        Me.EmailTextBox.Size = New System.Drawing.Size(220, 20)
        Me.EmailTextBox.TabIndex = 15
        '
        'FaxTextBox
        '
        Me.FaxTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.T_ClientBindingSource, "Fax", True))
        Me.FaxTextBox.Location = New System.Drawing.Point(417, 441)
        Me.FaxTextBox.MaxLength = 255
        Me.FaxTextBox.Name = "FaxTextBox"
        Me.FaxTextBox.Size = New System.Drawing.Size(100, 20)
        Me.FaxTextBox.TabIndex = 14
        '
        'MobileTextBox
        '
        Me.MobileTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.T_ClientBindingSource, "Mobile", True))
        Me.MobileTextBox.Location = New System.Drawing.Point(279, 438)
        Me.MobileTextBox.MaxLength = 255
        Me.MobileTextBox.Name = "MobileTextBox"
        Me.MobileTextBox.Size = New System.Drawing.Size(100, 20)
        Me.MobileTextBox.TabIndex = 13
        '
        'TelTextBox
        '
        Me.TelTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.T_ClientBindingSource, "Tel", True))
        Me.TelTextBox.Location = New System.Drawing.Point(122, 438)
        Me.TelTextBox.MaxLength = 255
        Me.TelTextBox.Name = "TelTextBox"
        Me.TelTextBox.Size = New System.Drawing.Size(100, 20)
        Me.TelTextBox.TabIndex = 12
        '
        'VilleTextBox
        '
        Me.VilleTextBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.VilleTextBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource
        Me.VilleTextBox.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.VilleTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.T_ClientBindingSource, "Ville", True))
        Me.VilleTextBox.Location = New System.Drawing.Point(122, 385)
        Me.VilleTextBox.MaxLength = 255
        Me.VilleTextBox.Name = "VilleTextBox"
        Me.VilleTextBox.Size = New System.Drawing.Size(220, 20)
        Me.VilleTextBox.TabIndex = 10
        '
        'CodePostalTextBox
        '
        Me.CodePostalTextBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.CodePostalTextBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource
        Me.CodePostalTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.T_ClientBindingSource, "CodePostal", True))
        Me.CodePostalTextBox.Location = New System.Drawing.Point(122, 359)
        Me.CodePostalTextBox.MaxLength = 255
        Me.CodePostalTextBox.Name = "CodePostalTextBox"
        Me.CodePostalTextBox.Size = New System.Drawing.Size(220, 20)
        Me.CodePostalTextBox.TabIndex = 9
        '
        'AdresseL3TextBox
        '
        Me.AdresseL3TextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.T_ClientBindingSource, "AdresseL3", True))
        Me.AdresseL3TextBox.Location = New System.Drawing.Point(122, 333)
        Me.AdresseL3TextBox.MaxLength = 35
        Me.AdresseL3TextBox.Name = "AdresseL3TextBox"
        Me.AdresseL3TextBox.Size = New System.Drawing.Size(220, 20)
        Me.AdresseL3TextBox.TabIndex = 8
        '
        'AdresseL2TextBox
        '
        Me.AdresseL2TextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.T_ClientBindingSource, "AdresseL2", True))
        Me.AdresseL2TextBox.Location = New System.Drawing.Point(122, 307)
        Me.AdresseL2TextBox.MaxLength = 35
        Me.AdresseL2TextBox.Name = "AdresseL2TextBox"
        Me.AdresseL2TextBox.Size = New System.Drawing.Size(220, 20)
        Me.AdresseL2TextBox.TabIndex = 7
        '
        'AdresseL1TextBox
        '
        Me.AdresseL1TextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.T_ClientBindingSource, "AdresseL1", True))
        Me.AdresseL1TextBox.Location = New System.Drawing.Point(122, 281)
        Me.AdresseL1TextBox.MaxLength = 35
        Me.AdresseL1TextBox.Name = "AdresseL1TextBox"
        Me.AdresseL1TextBox.Size = New System.Drawing.Size(220, 20)
        Me.AdresseL1TextBox.TabIndex = 6
        '
        'PrenomTextBox
        '
        Me.PrenomTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.T_ClientBindingSource, "Prenom", True))
        Me.PrenomTextBox.Location = New System.Drawing.Point(122, 255)
        Me.PrenomTextBox.MaxLength = 255
        Me.PrenomTextBox.Name = "PrenomTextBox"
        Me.PrenomTextBox.Size = New System.Drawing.Size(139, 20)
        Me.PrenomTextBox.TabIndex = 5
        '
        'NomTextBox
        '
        Me.NomTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.T_ClientBindingSource, "Nom", True))
        Me.NomTextBox.Location = New System.Drawing.Point(122, 229)
        Me.NomTextBox.MaxLength = 255
        Me.NomTextBox.Name = "NomTextBox"
        Me.NomTextBox.Size = New System.Drawing.Size(139, 20)
        Me.NomTextBox.TabIndex = 4
        '
        'SociétéTextBox
        '
        Me.SociétéTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.T_ClientBindingSource, "Société", True))
        Me.SociétéTextBox.Location = New System.Drawing.Point(122, 98)
        Me.SociétéTextBox.MaxLength = 255
        Me.SociétéTextBox.Name = "SociétéTextBox"
        Me.SociétéTextBox.Size = New System.Drawing.Size(139, 20)
        Me.SociétéTextBox.TabIndex = 1
        '
        'ID_T_ClientTextBox
        '
        Me.ID_T_ClientTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.T_ClientBindingSource, "ID_T_Client", True))
        Me.ID_T_ClientTextBox.Location = New System.Drawing.Point(122, 72)
        Me.ID_T_ClientTextBox.Name = "ID_T_ClientTextBox"
        Me.ID_T_ClientTextBox.ReadOnly = True
        Me.ID_T_ClientTextBox.Size = New System.Drawing.Size(100, 20)
        Me.ID_T_ClientTextBox.TabIndex = 0
        '
        'PaysComboBox
        '
        Me.PaysComboBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.T_ClientBindingSource, "Pays", True))
        Me.PaysComboBox.DataBindings.Add(New System.Windows.Forms.Binding("SelectedValue", Me.T_ClientBindingSource, "Pays", True))
        Me.PaysComboBox.DataSource = Me.TPaysBindingSource
        Me.PaysComboBox.DisplayMember = "Libelle"
        Me.PaysComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.PaysComboBox.FormattingEnabled = True
        Me.PaysComboBox.Location = New System.Drawing.Point(122, 411)
        Me.PaysComboBox.MaxLength = 255
        Me.PaysComboBox.Name = "PaysComboBox"
        Me.PaysComboBox.Size = New System.Drawing.Size(139, 21)
        Me.PaysComboBox.TabIndex = 11
        Me.PaysComboBox.ValueMember = "Libelle"
        '
        'ToolStrip
        '
        Me.ToolStrip.Dock = System.Windows.Forms.DockStyle.None
        Me.ToolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.NouveauToolStripButton, Me.ToolStripButton2, Me.ToolStripSeparator2, Me.CopierToolStripButton, Me.CollerToolStripButton, Me.ToolStripSeparator3, Me.SupprimerToolStripButton, Me.ToolStripButton5})
        Me.ToolStrip.Location = New System.Drawing.Point(5, 3)
        Me.ToolStrip.Name = "ToolStrip"
        Me.ToolStrip.Size = New System.Drawing.Size(107, 25)
        Me.ToolStrip.TabIndex = 119
        Me.ToolStrip.Text = "ToolStrip3"
        '
        'NouveauToolStripButton
        '
        Me.NouveauToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.NouveauToolStripButton.Image = CType(resources.GetObject("NouveauToolStripButton.Image"), System.Drawing.Image)
        Me.NouveauToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.NouveauToolStripButton.Name = "NouveauToolStripButton"
        Me.NouveauToolStripButton.Size = New System.Drawing.Size(23, 22)
        Me.NouveauToolStripButton.Text = "&Nouvelle Fiche Générale"
        '
        'ToolStripButton2
        '
        Me.ToolStripButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton2.Image = CType(resources.GetObject("ToolStripButton2.Image"), System.Drawing.Image)
        Me.ToolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton2.Name = "ToolStripButton2"
        Me.ToolStripButton2.Size = New System.Drawing.Size(23, 22)
        Me.ToolStripButton2.Text = "&Imprimer"
        Me.ToolStripButton2.Visible = False
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 25)
        '
        'CopierToolStripButton
        '
        Me.CopierToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.CopierToolStripButton.Image = CType(resources.GetObject("CopierToolStripButton.Image"), System.Drawing.Image)
        Me.CopierToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.CopierToolStripButton.Name = "CopierToolStripButton"
        Me.CopierToolStripButton.Size = New System.Drawing.Size(23, 22)
        Me.CopierToolStripButton.Text = "Co&pier une Fiche"
        '
        'CollerToolStripButton
        '
        Me.CollerToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.CollerToolStripButton.Enabled = False
        Me.CollerToolStripButton.Image = CType(resources.GetObject("CollerToolStripButton.Image"), System.Drawing.Image)
        Me.CollerToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.CollerToolStripButton.Name = "CollerToolStripButton"
        Me.CollerToolStripButton.Size = New System.Drawing.Size(23, 22)
        Me.CollerToolStripButton.Text = "Co&ller une Fiche"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(6, 25)
        '
        'SupprimerToolStripButton
        '
        Me.SupprimerToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.SupprimerToolStripButton.Image = CType(resources.GetObject("SupprimerToolStripButton.Image"), System.Drawing.Image)
        Me.SupprimerToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.SupprimerToolStripButton.Name = "SupprimerToolStripButton"
        Me.SupprimerToolStripButton.Size = New System.Drawing.Size(23, 22)
        Me.SupprimerToolStripButton.Text = "Supprimer"
        '
        'ToolStripButton5
        '
        Me.ToolStripButton5.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton5.Image = CType(resources.GetObject("ToolStripButton5.Image"), System.Drawing.Image)
        Me.ToolStripButton5.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton5.Name = "ToolStripButton5"
        Me.ToolStripButton5.Size = New System.Drawing.Size(23, 22)
        Me.ToolStripButton5.Text = "&?"
        Me.ToolStripButton5.Visible = False
        '
        'TabControl1
        '
        Me.TabControl1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TabControl1.Controls.Add(Me.TabPageGeneral)
        Me.TabControl1.Controls.Add(Me.TabPageArticle)
        Me.TabControl1.Controls.Add(Me.TabPageAvoir)
        Me.TabControl1.Controls.Add(Me.TabPageChequeCadeau)
        Me.TabControl1.Controls.Add(Me.TabPageCommandes)
        Me.TabControl1.Controls.Add(Me.TabPageEcheances)
        Me.TabControl1.Controls.Add(Me.TabPageAdresses)
        Me.TabControl1.Location = New System.Drawing.Point(1, 65)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(1029, 672)
        Me.TabControl1.TabIndex = 0
        '
        'TabPageChequeCadeau
        '
        Me.TabPageChequeCadeau.Controls.Add(Me.BT_Impression_ChequeCadeau)
        Me.TabPageChequeCadeau.Controls.Add(Me.DGVIEW_ChequeCadeau)
        Me.TabPageChequeCadeau.Controls.Add(Me.StatusStrip2)
        Me.TabPageChequeCadeau.Location = New System.Drawing.Point(4, 22)
        Me.TabPageChequeCadeau.Name = "TabPageChequeCadeau"
        Me.TabPageChequeCadeau.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPageChequeCadeau.Size = New System.Drawing.Size(1021, 646)
        Me.TabPageChequeCadeau.TabIndex = 5
        Me.TabPageChequeCadeau.Text = "Chèques cadeaux"
        Me.TabPageChequeCadeau.UseVisualStyleBackColor = True
        '
        'BT_Impression_ChequeCadeau
        '
        Me.BT_Impression_ChequeCadeau.Image = CType(resources.GetObject("BT_Impression_ChequeCadeau.Image"), System.Drawing.Image)
        Me.BT_Impression_ChequeCadeau.Location = New System.Drawing.Point(5, 3)
        Me.BT_Impression_ChequeCadeau.Name = "BT_Impression_ChequeCadeau"
        Me.BT_Impression_ChequeCadeau.Size = New System.Drawing.Size(78, 23)
        Me.BT_Impression_ChequeCadeau.TabIndex = 48
        Me.BT_Impression_ChequeCadeau.Text = "Imprimer"
        Me.BT_Impression_ChequeCadeau.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.BT_Impression_ChequeCadeau.UseVisualStyleBackColor = True
        '
        'DGVIEW_ChequeCadeau
        '
        Me.DGVIEW_ChequeCadeau.AllowUserToAddRows = False
        Me.DGVIEW_ChequeCadeau.AllowUserToDeleteRows = False
        Me.DGVIEW_ChequeCadeau.AllowUserToResizeRows = False
        DataGridViewCellStyle19.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.DGVIEW_ChequeCadeau.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle19
        Me.DGVIEW_ChequeCadeau.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DGVIEW_ChequeCadeau.AutoGenerateColumns = False
        Me.DGVIEW_ChequeCadeau.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells
        DataGridViewCellStyle20.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle20.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle20.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle20.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle20.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle20.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle20.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DGVIEW_ChequeCadeau.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle20
        Me.DGVIEW_ChequeCadeau.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ChequeUtiliseLe, Me.DataGridViewTextBoxColumn2, Me.DataGridViewTextBoxColumn3, Me.DataGridViewTextBoxColumn6, Me.DataGridViewTextBoxColumn7, Me.DataGridViewTextBoxColumn8, Me.ChequeCadeauUtiliseLe})
        Me.DGVIEW_ChequeCadeau.DataSource = Me.V_Avoir_clientBindingSource
        DataGridViewCellStyle22.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle22.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        DataGridViewCellStyle22.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle22.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle22.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle22.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle22.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DGVIEW_ChequeCadeau.DefaultCellStyle = DataGridViewCellStyle22
        Me.DGVIEW_ChequeCadeau.Location = New System.Drawing.Point(3, 28)
        Me.DGVIEW_ChequeCadeau.MultiSelect = False
        Me.DGVIEW_ChequeCadeau.Name = "DGVIEW_ChequeCadeau"
        Me.DGVIEW_ChequeCadeau.ReadOnly = True
        DataGridViewCellStyle23.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle23.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle23.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle23.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle23.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle23.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle23.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DGVIEW_ChequeCadeau.RowHeadersDefaultCellStyle = DataGridViewCellStyle23
        Me.DGVIEW_ChequeCadeau.RowHeadersVisible = False
        Me.DGVIEW_ChequeCadeau.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DGVIEW_ChequeCadeau.Size = New System.Drawing.Size(1012, 599)
        Me.DGVIEW_ChequeCadeau.TabIndex = 47
        '
        'ChequeUtiliseLe
        '
        Me.ChequeUtiliseLe.DataPropertyName = "ID_T_Avoir"
        Me.ChequeUtiliseLe.HeaderText = "Ref Chèque Cadeau"
        Me.ChequeUtiliseLe.Name = "ChequeUtiliseLe"
        Me.ChequeUtiliseLe.ReadOnly = True
        Me.ChequeUtiliseLe.Width = 129
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.DataPropertyName = "ID_T_CommandeVente"
        Me.DataGridViewTextBoxColumn2.HeaderText = "Ref Commande Vente"
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        Me.DataGridViewTextBoxColumn2.ReadOnly = True
        Me.DataGridViewTextBoxColumn2.Width = 136
        '
        'DataGridViewTextBoxColumn3
        '
        Me.DataGridViewTextBoxColumn3.DataPropertyName = "Montant"
        DataGridViewCellStyle21.Format = "C2"
        Me.DataGridViewTextBoxColumn3.DefaultCellStyle = DataGridViewCellStyle21
        Me.DataGridViewTextBoxColumn3.HeaderText = "Montant"
        Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
        Me.DataGridViewTextBoxColumn3.ReadOnly = True
        Me.DataGridViewTextBoxColumn3.Width = 71
        '
        'DataGridViewTextBoxColumn6
        '
        Me.DataGridViewTextBoxColumn6.DataPropertyName = "Commentaire"
        Me.DataGridViewTextBoxColumn6.HeaderText = "Commentaire"
        Me.DataGridViewTextBoxColumn6.Name = "DataGridViewTextBoxColumn6"
        Me.DataGridViewTextBoxColumn6.ReadOnly = True
        Me.DataGridViewTextBoxColumn6.Width = 93
        '
        'DataGridViewTextBoxColumn7
        '
        Me.DataGridViewTextBoxColumn7.DataPropertyName = "AvoirCreePar"
        Me.DataGridViewTextBoxColumn7.HeaderText = "Cree Par"
        Me.DataGridViewTextBoxColumn7.Name = "DataGridViewTextBoxColumn7"
        Me.DataGridViewTextBoxColumn7.ReadOnly = True
        Me.DataGridViewTextBoxColumn7.Width = 73
        '
        'DataGridViewTextBoxColumn8
        '
        Me.DataGridViewTextBoxColumn8.DataPropertyName = "AvoirCreeLe"
        Me.DataGridViewTextBoxColumn8.HeaderText = "Cree Le"
        Me.DataGridViewTextBoxColumn8.Name = "DataGridViewTextBoxColumn8"
        Me.DataGridViewTextBoxColumn8.ReadOnly = True
        Me.DataGridViewTextBoxColumn8.Width = 69
        '
        'ChequeCadeauUtiliseLe
        '
        Me.ChequeCadeauUtiliseLe.DataPropertyName = "UtiliseLe"
        Me.ChequeCadeauUtiliseLe.HeaderText = "Utilise Le"
        Me.ChequeCadeauUtiliseLe.Name = "ChequeCadeauUtiliseLe"
        Me.ChequeCadeauUtiliseLe.ReadOnly = True
        Me.ChequeCadeauUtiliseLe.Width = 75
        '
        'StatusStrip2
        '
        Me.StatusStrip2.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripStatusLabelNbEnregistrementChequeCadeau})
        Me.StatusStrip2.Location = New System.Drawing.Point(3, 621)
        Me.StatusStrip2.Name = "StatusStrip2"
        Me.StatusStrip2.Size = New System.Drawing.Size(1015, 22)
        Me.StatusStrip2.TabIndex = 46
        Me.StatusStrip2.Text = "StatusStrip"
        '
        'ToolStripStatusLabelNbEnregistrementChequeCadeau
        '
        Me.ToolStripStatusLabelNbEnregistrementChequeCadeau.Name = "ToolStripStatusLabelNbEnregistrementChequeCadeau"
        Me.ToolStripStatusLabelNbEnregistrementChequeCadeau.Size = New System.Drawing.Size(203, 17)
        Me.ToolStripStatusLabelNbEnregistrementChequeCadeau.Text = "{0000} enregistrement(s) sélectionnés"
        '
        'TabPageEcheances
        '
        Me.TabPageEcheances.Controls.Add(Me.V_reglementDataGridView)
        Me.TabPageEcheances.Location = New System.Drawing.Point(4, 22)
        Me.TabPageEcheances.Name = "TabPageEcheances"
        Me.TabPageEcheances.Size = New System.Drawing.Size(1021, 646)
        Me.TabPageEcheances.TabIndex = 4
        Me.TabPageEcheances.Text = "Echéances"
        Me.TabPageEcheances.UseVisualStyleBackColor = True
        '
        'V_reglementDataGridView
        '
        Me.V_reglementDataGridView.AllowUserToAddRows = False
        Me.V_reglementDataGridView.AllowUserToDeleteRows = False
        DataGridViewCellStyle24.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.V_reglementDataGridView.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle24
        Me.V_reglementDataGridView.AutoGenerateColumns = False
        Me.V_reglementDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.V_reglementDataGridView.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.RefCommandeEcheance, Me.DataGridViewTextBoxColumn10, Me.DataGridViewTextBoxColumn9, Me.DataGridViewTextBoxColumn4, Me.DataGridViewTextBoxColumn5, Me.Enregistre_le, Me.Echeance_le, Me.Encaisse_le})
        Me.V_reglementDataGridView.DataSource = Me.V_reglementBindingSource
        Me.V_reglementDataGridView.Dock = System.Windows.Forms.DockStyle.Fill
        Me.V_reglementDataGridView.Location = New System.Drawing.Point(0, 0)
        Me.V_reglementDataGridView.MultiSelect = False
        Me.V_reglementDataGridView.Name = "V_reglementDataGridView"
        Me.V_reglementDataGridView.ReadOnly = True
        Me.V_reglementDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.V_reglementDataGridView.Size = New System.Drawing.Size(1021, 646)
        Me.V_reglementDataGridView.TabIndex = 0
        '
        'RefCommandeEcheance
        '
        Me.RefCommandeEcheance.DataPropertyName = "id_t_commande_vente"
        Me.RefCommandeEcheance.HeaderText = "Ref Commande"
        Me.RefCommandeEcheance.Name = "RefCommandeEcheance"
        Me.RefCommandeEcheance.ReadOnly = True
        '
        'DataGridViewTextBoxColumn10
        '
        Me.DataGridViewTextBoxColumn10.DataPropertyName = "Libelle_modereglement"
        Me.DataGridViewTextBoxColumn10.HeaderText = "Mode Règlement"
        Me.DataGridViewTextBoxColumn10.Name = "DataGridViewTextBoxColumn10"
        Me.DataGridViewTextBoxColumn10.ReadOnly = True
        '
        'DataGridViewTextBoxColumn9
        '
        Me.DataGridViewTextBoxColumn9.DataPropertyName = "Libelle_moyenpaiement"
        Me.DataGridViewTextBoxColumn9.HeaderText = "Moyen de paiement"
        Me.DataGridViewTextBoxColumn9.Name = "DataGridViewTextBoxColumn9"
        Me.DataGridViewTextBoxColumn9.ReadOnly = True
        '
        'DataGridViewTextBoxColumn4
        '
        Me.DataGridViewTextBoxColumn4.DataPropertyName = "Montant"
        Me.DataGridViewTextBoxColumn4.HeaderText = "Montant"
        Me.DataGridViewTextBoxColumn4.Name = "DataGridViewTextBoxColumn4"
        Me.DataGridViewTextBoxColumn4.ReadOnly = True
        '
        'DataGridViewTextBoxColumn5
        '
        Me.DataGridViewTextBoxColumn5.DataPropertyName = "Reference_avoir_bon"
        Me.DataGridViewTextBoxColumn5.HeaderText = "Reference avoir"
        Me.DataGridViewTextBoxColumn5.Name = "DataGridViewTextBoxColumn5"
        Me.DataGridViewTextBoxColumn5.ReadOnly = True
        '
        'Enregistre_le
        '
        Me.Enregistre_le.DataPropertyName = "Enregistre_le"
        Me.Enregistre_le.HeaderText = "Date de saisie"
        Me.Enregistre_le.Name = "Enregistre_le"
        Me.Enregistre_le.ReadOnly = True
        '
        'Echeance_le
        '
        Me.Echeance_le.DataPropertyName = "Echeance_le"
        Me.Echeance_le.HeaderText = "Echeance le"
        Me.Echeance_le.Name = "Echeance_le"
        Me.Echeance_le.ReadOnly = True
        '
        'Encaisse_le
        '
        Me.Encaisse_le.DataPropertyName = "Encaisse_le"
        Me.Encaisse_le.HeaderText = "Encaisse le"
        Me.Encaisse_le.Name = "Encaisse_le"
        Me.Encaisse_le.ReadOnly = True
        '
        'V_reglementBindingSource
        '
        Me.V_reglementBindingSource.DataMember = "V_reglement"
        Me.V_reglementBindingSource.DataSource = Me.CLIDataSet
        '
        'TabPageAdresses
        '
        Me.TabPageAdresses.Controls.Add(Me.AdressesDGView)
        Me.TabPageAdresses.Location = New System.Drawing.Point(4, 22)
        Me.TabPageAdresses.Name = "TabPageAdresses"
        Me.TabPageAdresses.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPageAdresses.Size = New System.Drawing.Size(1021, 646)
        Me.TabPageAdresses.TabIndex = 6
        Me.TabPageAdresses.Text = "Adresses"
        Me.TabPageAdresses.UseVisualStyleBackColor = True
        '
        'AdressesDGView
        '
        Me.AdressesDGView.AllowUserToAddRows = False
        Me.AdressesDGView.AllowUserToDeleteRows = False
        DataGridViewCellStyle25.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.AdressesDGView.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle25
        Me.AdressesDGView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.AdressesDGView.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.idtclient, Me.idtAdresse, Me.idAddressPrestashop})
        Me.AdressesDGView.Dock = System.Windows.Forms.DockStyle.Fill
        Me.AdressesDGView.Location = New System.Drawing.Point(3, 3)
        Me.AdressesDGView.MultiSelect = False
        Me.AdressesDGView.Name = "AdressesDGView"
        Me.AdressesDGView.ReadOnly = True
        Me.AdressesDGView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.AdressesDGView.Size = New System.Drawing.Size(1015, 640)
        Me.AdressesDGView.TabIndex = 1
        '
        'idtclient
        '
        Me.idtclient.DataPropertyName = "id_t_client"
        Me.idtclient.HeaderText = "id_t_client"
        Me.idtclient.Name = "idtclient"
        Me.idtclient.ReadOnly = True
        Me.idtclient.Visible = False
        '
        'idtAdresse
        '
        Me.idtAdresse.DataPropertyName = "id_t_adresse"
        Me.idtAdresse.HeaderText = "id_t_adresse"
        Me.idtAdresse.Name = "idtAdresse"
        Me.idtAdresse.ReadOnly = True
        Me.idtAdresse.Visible = False
        '
        'idAddressPrestashop
        '
        Me.idAddressPrestashop.DataPropertyName = "idAddressPrestashop"
        Me.idAddressPrestashop.HeaderText = "idAddressPrestashop"
        Me.idAddressPrestashop.Name = "idAddressPrestashop"
        Me.idAddressPrestashop.ReadOnly = True
        Me.idAddressPrestashop.Visible = False
        '
        'V_Recherche_ArticleTableAdapter
        '
        Me.V_Recherche_ArticleTableAdapter.ClearBeforeFill = True
        '
        'V_reglementTableAdapter
        '
        Me.V_reglementTableAdapter.ClearBeforeFill = True
        '
        'I_ErrorDetail
        '
        Me.I_ErrorDetail.Location = New System.Drawing.Point(722, 576)
        Me.I_ErrorDetail.Multiline = True
        Me.I_ErrorDetail.Name = "I_ErrorDetail"
        Me.I_ErrorDetail.ReadOnly = True
        Me.I_ErrorDetail.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.I_ErrorDetail.Size = New System.Drawing.Size(257, 64)
        Me.I_ErrorDetail.TabIndex = 171
        '
        'FormClient
        '
        Me.AcceptButton = Me.BT_Enregistrer
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.BT_Fermer
        Me.ClientSize = New System.Drawing.Size(1041, 749)
        Me.Controls.Add(Me.ToolStrip2)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.BT_Enregistrer)
        Me.Controls.Add(Me.BT_Refresh)
        Me.Controls.Add(Me.BT_Fermer)
        Me.Name = "FormClient"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Client"
        CType(Me.CLIDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ToolStrip2.ResumeLayout(False)
        Me.ToolStrip2.PerformLayout()
        CType(Me.T_ClientBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TPaysBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPageCommandes.ResumeLayout(False)
        Me.TabPageCommandes.PerformLayout()
        CType(Me.DGview_Commandes, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.VRechercheCommandeVenteBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.StatusStripCommandes.ResumeLayout(False)
        Me.StatusStripCommandes.PerformLayout()
        Me.TabPageAvoir.ResumeLayout(False)
        Me.TabPageAvoir.PerformLayout()
        CType(Me.DGVIEW_avoir, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.V_Avoir_clientBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.TabPageArticle.ResumeLayout(False)
        Me.TabPageArticle.PerformLayout()
        CType(Me.DGview, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.VRechercheArticleBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.StatusStripArticles.ResumeLayout(False)
        Me.StatusStripArticles.PerformLayout()
        Me.TabPageGeneral.ResumeLayout(False)
        Me.TabPageGeneral.PerformLayout()
        Me.ToolStrip.ResumeLayout(False)
        Me.ToolStrip.PerformLayout()
        Me.TabControl1.ResumeLayout(False)
        Me.TabPageChequeCadeau.ResumeLayout(False)
        Me.TabPageChequeCadeau.PerformLayout()
        CType(Me.DGVIEW_ChequeCadeau, System.ComponentModel.ISupportInitialize).EndInit()
        Me.StatusStrip2.ResumeLayout(False)
        Me.StatusStrip2.PerformLayout()
        Me.TabPageEcheances.ResumeLayout(False)
        CType(Me.V_reglementDataGridView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.V_reglementBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPageAdresses.ResumeLayout(False)
        CType(Me.AdressesDGView, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents CLIDataSet As CLI.CLIDataSet
    Friend WithEvents BT_Enregistrer As System.Windows.Forms.Button
    Friend WithEvents BT_Fermer As System.Windows.Forms.Button
    Friend WithEvents BT_Refresh As System.Windows.Forms.Button
    Friend WithEvents ToolStrip2 As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStripButtonMovePrevious As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripButtonMoveNext As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripButtonMoveLast As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripButtonMovefirst As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripLabelPosition As System.Windows.Forms.ToolStripLabel

    Friend WithEvents T_ClientBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents TPaysBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents T_PaysTableAdapter As CLI.CLIDataSetTableAdapters.T_PaysTableAdapter
    Friend WithEvents T_ClientTableAdapter As CLI.CLIDataSetTableAdapters.T_ClientTableAdapter
    Friend WithEvents TabPageCommandes As System.Windows.Forms.TabPage
    Friend WithEvents TabPageAvoir As System.Windows.Forms.TabPage
    Friend WithEvents TabPageArticle As System.Windows.Forms.TabPage
    Friend WithEvents DGview As System.Windows.Forms.DataGridView
    Friend WithEvents StatusStripArticles As System.Windows.Forms.StatusStrip
    Friend WithEvents ToolStripStatusLabelNbEnregistrementsArticles As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents TabPageGeneral As System.Windows.Forms.TabPage
    Friend WithEvents ActifCheckBox As System.Windows.Forms.CheckBox
    Friend WithEvents ModifieLeTextBox As System.Windows.Forms.TextBox
    Friend WithEvents ModifieParTextBox As System.Windows.Forms.TextBox
    Friend WithEvents CreeLeTextBox As System.Windows.Forms.TextBox
    Friend WithEvents CreeParTextBox As System.Windows.Forms.TextBox
    Friend WithEvents EmailTextBox As System.Windows.Forms.TextBox
    Friend WithEvents FaxTextBox As System.Windows.Forms.TextBox
    Friend WithEvents MobileTextBox As System.Windows.Forms.TextBox
    Friend WithEvents TelTextBox As System.Windows.Forms.TextBox
    Friend WithEvents VilleTextBox As System.Windows.Forms.TextBox
    Friend WithEvents CodePostalTextBox As System.Windows.Forms.TextBox
    Friend WithEvents AdresseL3TextBox As System.Windows.Forms.TextBox
    Friend WithEvents AdresseL2TextBox As System.Windows.Forms.TextBox
    Friend WithEvents AdresseL1TextBox As System.Windows.Forms.TextBox
    Friend WithEvents PrenomTextBox As System.Windows.Forms.TextBox
    Friend WithEvents NomTextBox As System.Windows.Forms.TextBox
    Friend WithEvents SociétéTextBox As System.Windows.Forms.TextBox
    Friend WithEvents ID_T_ClientTextBox As System.Windows.Forms.TextBox
    Friend WithEvents PaysComboBox As System.Windows.Forms.ComboBox
    Friend WithEvents ToolStrip As System.Windows.Forms.ToolStrip
    Friend WithEvents NouveauToolStripButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripButton2 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents CopierToolStripButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents CollerToolStripButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents SupprimerToolStripButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripButton5 As System.Windows.Forms.ToolStripButton
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents StatusStripCommandes As System.Windows.Forms.StatusStrip
    Friend WithEvents ToolStripStatusLabelNbEnregistrementsCommandes As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents DGview_Commandes As System.Windows.Forms.DataGridView
    Friend WithEvents VRechercheCommandeVenteBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents RefCommande As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents EtatCommande As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TotalDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DateCommandeDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents VendeurDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents RefClientDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SociétéDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents NomDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PrénomDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CodePostalDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents VilleDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PaysDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DateFactureDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DateExpeditionDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents WebDataGridViewCheckBoxColumn As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents CodeEtat As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents V_Avoir_clientBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents ToolStripStatusLabelNbEnregistrementAvoir As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents DGVIEW_avoir As System.Windows.Forms.DataGridView
    Friend WithEvents VRechercheArticleBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents V_Recherche_ArticleTableAdapter As CLI.CLIDataSetTableAdapters.V_Recherche_ArticleTableAdapter
    Friend WithEvents PasswordTextBox As System.Windows.Forms.TextBox
    Friend WithEvents RefAvoir As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents RefCommandeVente As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents MontantDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CommentaireDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents AvoirCreeParDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents AvoirCreeLeDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents UtiliseLe As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents NewsLetterCheckBox As System.Windows.Forms.CheckBox
    Friend WithEvents BT_Impression_Avoir As System.Windows.Forms.Button
    Friend WithEvents BT_Creer_Avoir_Global As System.Windows.Forms.Button
    Friend WithEvents TabPageEcheances As System.Windows.Forms.TabPage
    Friend WithEvents V_reglementBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents V_reglementTableAdapter As CLI.CLIDataSetTableAdapters.V_reglementTableAdapter
    Friend WithEvents V_reglementDataGridView As System.Windows.Forms.DataGridView
    Friend WithEvents RefCommandeEcheance As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn10 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn9 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn5 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Enregistre_le As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Echeance_le As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Encaisse_le As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents BT_Impression_Article As System.Windows.Forms.Button
    Friend WithEvents Active_on As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents Ref As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Descriptioncourte As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents prix_vente_initial_TTC As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents remise As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents prix_vente_remise_TTC As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents web_on As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents magasin_on As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents Stock As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents RefDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents FamilleDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SousFamilleDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DescriptionCourteDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents AnneeDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents MarqueDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ModeleDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents WebonDataGridViewCheckBoxColumn As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents MagasinonDataGridViewCheckBoxColumn As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents StockDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ActiveonDataGridViewCheckBoxColumn As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents PrixventeinitialTTCDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PrixventeremiseTTCDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents RemiseDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DepotventeDataGridViewCheckBoxColumn As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents OccazDataGridViewCheckBoxColumn As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents IDtarticleenteteDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents IDtarticledetailDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents IDTFournisseurDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ReffournisseurDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents IDTClientDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TabPageChequeCadeau As System.Windows.Forms.TabPage
    Friend WithEvents BT_Impression_ChequeCadeau As System.Windows.Forms.Button
    Friend WithEvents DGVIEW_ChequeCadeau As System.Windows.Forms.DataGridView
    Friend WithEvents StatusStrip2 As System.Windows.Forms.StatusStrip
    Friend WithEvents ToolStripStatusLabelNbEnregistrementChequeCadeau As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents NumeroIdentiteTextBox As System.Windows.Forms.TextBox
    Friend WithEvents ChequeUtiliseLe As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn6 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn7 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn8 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ChequeCadeauUtiliseLe As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents NoSiretTextBox As System.Windows.Forms.TextBox
    Friend WithEvents NoTVATextBox As System.Windows.Forms.TextBox
    Friend WithEvents BT_Email_Article As System.Windows.Forms.Button
    Friend WithEvents BT_Email_Avoir As System.Windows.Forms.Button
    Friend WithEvents CommentairesTextBox As System.Windows.Forms.TextBox
    Friend WithEvents WindCheckBox As CheckBox
    Friend WithEvents SupCheckBox As CheckBox
    Friend WithEvents KiteCheckBox As CheckBox
    Friend WithEvents ExportCheckBox As CheckBox
    Friend WithEvents IdCustomerPrestashopTextBox As TextBox
    Friend WithEvents TabPageAdresses As TabPage
    Friend WithEvents AdressesDGView As DataGridView
    Friend WithEvents idtclient As DataGridViewTextBoxColumn
    Friend WithEvents idtAdresse As DataGridViewTextBoxColumn
    Friend WithEvents idAddressPrestashop As DataGridViewTextBoxColumn
    Friend WithEvents TitreComboBox As ComboBox
    Friend WithEvents ApeTextBox As TextBox
    Friend WithEvents MaskedTextBoxDateNaissance As MaskedTextBox
    Friend WithEvents ToSyncCheckBox As CheckBox
    Friend WithEvents BT_DetailSynchro As Button
    Friend WithEvents I_EtatSynchroPrestashop As TextBox
    Friend WithEvents BT_SyncAdresses As Button
    Friend WithEvents BT_SyncAvoirs As Button
    Friend WithEvents I_ErrorDetail As TextBox
End Class
