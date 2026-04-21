<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormFournisseur
    Inherits System.Windows.Forms.Form

    'Form remplace la méthode Dispose pour nettoyer la liste des composants.
    <System.Diagnostics.DebuggerNonUserCode()> _
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
    <System.Diagnostics.DebuggerStepThrough()> _
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
        Dim ModeReglementLabel As System.Windows.Forms.Label
        Dim CreeParLabel As System.Windows.Forms.Label
        Dim CreeLeLabel As System.Windows.Forms.Label
        Dim ModifieParLabel As System.Windows.Forms.Label
        Dim ModifieLeLabel As System.Windows.Forms.Label
        Dim ActifLabel As System.Windows.Forms.Label
        Dim NoTVALabel As System.Windows.Forms.Label
        Dim NoSiretLabel As System.Windows.Forms.Label
        Dim CommentairesLabel As System.Windows.Forms.Label
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormFournisseur))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim ExportFileLabel As System.Windows.Forms.Label
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
        Me.T_FournisseurTableAdapter = New CLI.CLIDataSetTableAdapters.T_FournisseurTableAdapter()
        Me.TabPageGeneral = New System.Windows.Forms.TabPage()
        Me.CommentairesTextBox = New System.Windows.Forms.TextBox()
        Me.T_FournisseurBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.NoSiretTextBox = New System.Windows.Forms.TextBox()
        Me.NoTVATextBox = New System.Windows.Forms.TextBox()
        Me.ActifCheckBox = New System.Windows.Forms.CheckBox()
        Me.ModifieLeTextBox = New System.Windows.Forms.TextBox()
        Me.ModifieParTextBox = New System.Windows.Forms.TextBox()
        Me.CreeLeTextBox = New System.Windows.Forms.TextBox()
        Me.CreeParTextBox = New System.Windows.Forms.TextBox()
        Me.ModeReglementComboBox = New System.Windows.Forms.ComboBox()
        Me.TmodeReglementBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.EmailTextBox = New System.Windows.Forms.TextBox()
        Me.FaxTextBox = New System.Windows.Forms.TextBox()
        Me.MobileTextBox = New System.Windows.Forms.TextBox()
        Me.TelTextBox = New System.Windows.Forms.TextBox()
        Me.PaysComboBox = New System.Windows.Forms.ComboBox()
        Me.TPaysBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.VilleTextBox = New System.Windows.Forms.TextBox()
        Me.CodePostalTextBox = New System.Windows.Forms.TextBox()
        Me.AdresseL3TextBox = New System.Windows.Forms.TextBox()
        Me.AdresseL2TextBox = New System.Windows.Forms.TextBox()
        Me.AdresseL1TextBox = New System.Windows.Forms.TextBox()
        Me.PrenomTextBox = New System.Windows.Forms.TextBox()
        Me.NomTextBox = New System.Windows.Forms.TextBox()
        Me.SociétéTextBox = New System.Windows.Forms.TextBox()
        Me.ID_T_FournisseurTextBox = New System.Windows.Forms.TextBox()
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
        Me.TabPageArticle = New System.Windows.Forms.TabPage()
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
        Me.StatusStripArticles = New System.Windows.Forms.StatusStrip()
        Me.ToolStripStatusLabelNbEnregistrementsArticles = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ContextMenuStripRecherche = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.StockToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.InventaireToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MouvementToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.T_PaysTableAdapter = New CLI.CLIDataSetTableAdapters.T_PaysTableAdapter()
        Me.T_modeReglementTableAdapter = New CLI.CLIDataSetTableAdapters.T_modeReglementTableAdapter()
        Me.ExportFileTextBox = New System.Windows.Forms.TextBox()
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
        ModeReglementLabel = New System.Windows.Forms.Label()
        CreeParLabel = New System.Windows.Forms.Label()
        CreeLeLabel = New System.Windows.Forms.Label()
        ModifieParLabel = New System.Windows.Forms.Label()
        ModifieLeLabel = New System.Windows.Forms.Label()
        ActifLabel = New System.Windows.Forms.Label()
        NoTVALabel = New System.Windows.Forms.Label()
        NoSiretLabel = New System.Windows.Forms.Label()
        CommentairesLabel = New System.Windows.Forms.Label()
        ExportFileLabel = New System.Windows.Forms.Label()
        CType(Me.CLIDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ToolStrip2.SuspendLayout()
        Me.TabPageGeneral.SuspendLayout()
        CType(Me.T_FournisseurBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TmodeReglementBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TPaysBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ToolStrip.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.TabPageArticle.SuspendLayout()
        CType(Me.DGview, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.StatusStripArticles.SuspendLayout()
        Me.ContextMenuStripRecherche.SuspendLayout()
        Me.SuspendLayout()
        '
        'ID_T_FournisseurLabel
        '
        ID_T_FournisseurLabel.AutoSize = True
        ID_T_FournisseurLabel.Location = New System.Drawing.Point(85, 75)
        ID_T_FournisseurLabel.Name = "ID_T_FournisseurLabel"
        ID_T_FournisseurLabel.Size = New System.Drawing.Size(27, 13)
        ID_T_FournisseurLabel.TabIndex = 130
        ID_T_FournisseurLabel.Text = "Ref:"
        '
        'SociétéLabel
        '
        SociétéLabel.AutoSize = True
        SociétéLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        SociétéLabel.Location = New System.Drawing.Point(58, 101)
        SociétéLabel.Name = "SociétéLabel"
        SociétéLabel.Size = New System.Drawing.Size(54, 13)
        SociétéLabel.TabIndex = 131
        SociétéLabel.Text = "Société:"
        '
        'NomLabel
        '
        NomLabel.AutoSize = True
        NomLabel.Location = New System.Drawing.Point(80, 179)
        NomLabel.Name = "NomLabel"
        NomLabel.Size = New System.Drawing.Size(32, 13)
        NomLabel.TabIndex = 132
        NomLabel.Text = "Nom:"
        '
        'PrenomLabel
        '
        PrenomLabel.AutoSize = True
        PrenomLabel.Location = New System.Drawing.Point(66, 205)
        PrenomLabel.Name = "PrenomLabel"
        PrenomLabel.Size = New System.Drawing.Size(46, 13)
        PrenomLabel.TabIndex = 133
        PrenomLabel.Text = "Prenom:"
        '
        'AdresseL1Label
        '
        AdresseL1Label.AutoSize = True
        AdresseL1Label.Location = New System.Drawing.Point(49, 231)
        AdresseL1Label.Name = "AdresseL1Label"
        AdresseL1Label.Size = New System.Drawing.Size(63, 13)
        AdresseL1Label.TabIndex = 134
        AdresseL1Label.Text = "Adresse L1:"
        '
        'AdresseL2Label
        '
        AdresseL2Label.AutoSize = True
        AdresseL2Label.Location = New System.Drawing.Point(49, 257)
        AdresseL2Label.Name = "AdresseL2Label"
        AdresseL2Label.Size = New System.Drawing.Size(63, 13)
        AdresseL2Label.TabIndex = 135
        AdresseL2Label.Text = "Adresse L2:"
        '
        'AdresseL3Label
        '
        AdresseL3Label.AutoSize = True
        AdresseL3Label.Location = New System.Drawing.Point(49, 283)
        AdresseL3Label.Name = "AdresseL3Label"
        AdresseL3Label.Size = New System.Drawing.Size(63, 13)
        AdresseL3Label.TabIndex = 136
        AdresseL3Label.Text = "Adresse L3:"
        '
        'CodePostalLabel
        '
        CodePostalLabel.AutoSize = True
        CodePostalLabel.Location = New System.Drawing.Point(45, 309)
        CodePostalLabel.Name = "CodePostalLabel"
        CodePostalLabel.Size = New System.Drawing.Size(67, 13)
        CodePostalLabel.TabIndex = 137
        CodePostalLabel.Text = "Code Postal:"
        '
        'VilleLabel
        '
        VilleLabel.AutoSize = True
        VilleLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        VilleLabel.Location = New System.Drawing.Point(83, 335)
        VilleLabel.Name = "VilleLabel"
        VilleLabel.Size = New System.Drawing.Size(35, 13)
        VilleLabel.TabIndex = 138
        VilleLabel.Text = "Ville:"
        '
        'PaysLabel
        '
        PaysLabel.AutoSize = True
        PaysLabel.Location = New System.Drawing.Point(79, 361)
        PaysLabel.Name = "PaysLabel"
        PaysLabel.Size = New System.Drawing.Size(33, 13)
        PaysLabel.TabIndex = 139
        PaysLabel.Text = "Pays:"
        '
        'TelLabel
        '
        TelLabel.AutoSize = True
        TelLabel.Location = New System.Drawing.Point(87, 388)
        TelLabel.Name = "TelLabel"
        TelLabel.Size = New System.Drawing.Size(25, 13)
        TelLabel.TabIndex = 140
        TelLabel.Text = "Tel:"
        '
        'MobileLabel
        '
        MobileLabel.AutoSize = True
        MobileLabel.Location = New System.Drawing.Point(71, 414)
        MobileLabel.Name = "MobileLabel"
        MobileLabel.Size = New System.Drawing.Size(41, 13)
        MobileLabel.TabIndex = 141
        MobileLabel.Text = "Mobile:"
        '
        'FaxLabel
        '
        FaxLabel.AutoSize = True
        FaxLabel.Location = New System.Drawing.Point(85, 440)
        FaxLabel.Name = "FaxLabel"
        FaxLabel.Size = New System.Drawing.Size(27, 13)
        FaxLabel.TabIndex = 142
        FaxLabel.Text = "Fax:"
        '
        'EmailLabel
        '
        EmailLabel.AutoSize = True
        EmailLabel.Location = New System.Drawing.Point(77, 466)
        EmailLabel.Name = "EmailLabel"
        EmailLabel.Size = New System.Drawing.Size(35, 13)
        EmailLabel.TabIndex = 143
        EmailLabel.Text = "Email:"
        '
        'ModeReglementLabel
        '
        ModeReglementLabel.AutoSize = True
        ModeReglementLabel.Location = New System.Drawing.Point(21, 492)
        ModeReglementLabel.Name = "ModeReglementLabel"
        ModeReglementLabel.Size = New System.Drawing.Size(91, 13)
        ModeReglementLabel.TabIndex = 144
        ModeReglementLabel.Text = "Mode Reglement:"
        '
        'CreeParLabel
        '
        CreeParLabel.AutoSize = True
        CreeParLabel.Location = New System.Drawing.Point(61, 519)
        CreeParLabel.Name = "CreeParLabel"
        CreeParLabel.Size = New System.Drawing.Size(51, 13)
        CreeParLabel.TabIndex = 145
        CreeParLabel.Text = "Cree Par:"
        '
        'CreeLeLabel
        '
        CreeLeLabel.AutoSize = True
        CreeLeLabel.Location = New System.Drawing.Point(65, 545)
        CreeLeLabel.Name = "CreeLeLabel"
        CreeLeLabel.Size = New System.Drawing.Size(47, 13)
        CreeLeLabel.TabIndex = 146
        CreeLeLabel.Text = "Cree Le:"
        '
        'ModifieParLabel
        '
        ModifieParLabel.AutoSize = True
        ModifieParLabel.Location = New System.Drawing.Point(290, 522)
        ModifieParLabel.Name = "ModifieParLabel"
        ModifieParLabel.Size = New System.Drawing.Size(63, 13)
        ModifieParLabel.TabIndex = 147
        ModifieParLabel.Text = "Modifie Par:"
        '
        'ModifieLeLabel
        '
        ModifieLeLabel.AutoSize = True
        ModifieLeLabel.Location = New System.Drawing.Point(294, 548)
        ModifieLeLabel.Name = "ModifieLeLabel"
        ModifieLeLabel.Size = New System.Drawing.Size(59, 13)
        ModifieLeLabel.TabIndex = 148
        ModifieLeLabel.Text = "Modifie Le:"
        '
        'ActifLabel
        '
        ActifLabel.AutoSize = True
        ActifLabel.Location = New System.Drawing.Point(318, 75)
        ActifLabel.Name = "ActifLabel"
        ActifLabel.Size = New System.Drawing.Size(31, 13)
        ActifLabel.TabIndex = 149
        ActifLabel.Text = "Actif:"
        '
        'NoTVALabel
        '
        NoTVALabel.AutoSize = True
        NoTVALabel.Location = New System.Drawing.Point(64, 127)
        NoTVALabel.Name = "NoTVALabel"
        NoTVALabel.Size = New System.Drawing.Size(48, 13)
        NoTVALabel.TabIndex = 150
        NoTVALabel.Text = "No TVA:"
        '
        'NoSiretLabel
        '
        NoSiretLabel.AutoSize = True
        NoSiretLabel.Location = New System.Drawing.Point(64, 153)
        NoSiretLabel.Name = "NoSiretLabel"
        NoSiretLabel.Size = New System.Drawing.Size(48, 13)
        NoSiretLabel.TabIndex = 151
        NoSiretLabel.Text = "No Siret:"
        '
        'CommentairesLabel
        '
        CommentairesLabel.AutoSize = True
        CommentairesLabel.Location = New System.Drawing.Point(443, 75)
        CommentairesLabel.Name = "CommentairesLabel"
        CommentairesLabel.Size = New System.Drawing.Size(76, 13)
        CommentairesLabel.TabIndex = 151
        CommentairesLabel.Text = "Commentaires:"
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
        Me.ToolStrip2.Size = New System.Drawing.Size(896, 25)
        Me.ToolStrip2.TabIndex = 44
        Me.ToolStrip2.Text = "ToolStrip2"
        '
        'ToolStripButtonMovefirst
        '
        Me.ToolStripButtonMovefirst.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButtonMovefirst.Image = Global.CLI.My.Resources.Resources.DataContainer_MoveFirstHS
        Me.ToolStripButtonMovefirst.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButtonMovefirst.Name = "ToolStripButtonMovefirst"
        Me.ToolStripButtonMovefirst.Size = New System.Drawing.Size(23, 22)
        Me.ToolStripButtonMovefirst.Text = "Premier"
        '
        'ToolStripButtonMovePrevious
        '
        Me.ToolStripButtonMovePrevious.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButtonMovePrevious.Image = Global.CLI.My.Resources.Resources.DataContainer_MovePreviousHS
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
        Me.ToolStripButtonMoveNext.Image = Global.CLI.My.Resources.Resources.DataContainer_MoveNextHS
        Me.ToolStripButtonMoveNext.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButtonMoveNext.Name = "ToolStripButtonMoveNext"
        Me.ToolStripButtonMoveNext.Size = New System.Drawing.Size(23, 22)
        Me.ToolStripButtonMoveNext.Text = "Suivant"
        '
        'ToolStripButtonMoveLast
        '
        Me.ToolStripButtonMoveLast.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButtonMoveLast.Image = Global.CLI.My.Resources.Resources.DataContainer_MoveLastHS
        Me.ToolStripButtonMoveLast.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButtonMoveLast.Name = "ToolStripButtonMoveLast"
        Me.ToolStripButtonMoveLast.Size = New System.Drawing.Size(23, 22)
        Me.ToolStripButtonMoveLast.Text = "Dernier"
        '
        'BT_Enregistrer
        '
        Me.BT_Enregistrer.Image = Global.CLI.My.Resources.Resources.saveHS
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
        Me.BT_Fermer.Image = Global.CLI.My.Resources.Resources.GoRtlHS
        Me.BT_Fermer.Location = New System.Drawing.Point(798, 28)
        Me.BT_Fermer.Name = "BT_Fermer"
        Me.BT_Fermer.Size = New System.Drawing.Size(82, 31)
        Me.BT_Fermer.TabIndex = 2
        Me.BT_Fermer.Text = "Fermer"
        Me.BT_Fermer.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.BT_Fermer.UseVisualStyleBackColor = True
        '
        'BT_Refresh
        '
        Me.BT_Refresh.Image = Global.CLI.My.Resources.Resources.Edit_UndoHS
        Me.BT_Refresh.Location = New System.Drawing.Point(93, 28)
        Me.BT_Refresh.Name = "BT_Refresh"
        Me.BT_Refresh.Size = New System.Drawing.Size(82, 31)
        Me.BT_Refresh.TabIndex = 1
        Me.BT_Refresh.Text = "Refresh"
        Me.BT_Refresh.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.BT_Refresh.UseVisualStyleBackColor = True
        '
        'T_FournisseurTableAdapter
        '
        Me.T_FournisseurTableAdapter.ClearBeforeFill = True
        '
        'TabPageGeneral
        '
        Me.TabPageGeneral.AutoScroll = True
        Me.TabPageGeneral.Controls.Add(ExportFileLabel)
        Me.TabPageGeneral.Controls.Add(Me.ExportFileTextBox)
        Me.TabPageGeneral.Controls.Add(CommentairesLabel)
        Me.TabPageGeneral.Controls.Add(Me.CommentairesTextBox)
        Me.TabPageGeneral.Controls.Add(NoSiretLabel)
        Me.TabPageGeneral.Controls.Add(Me.NoSiretTextBox)
        Me.TabPageGeneral.Controls.Add(NoTVALabel)
        Me.TabPageGeneral.Controls.Add(Me.NoTVATextBox)
        Me.TabPageGeneral.Controls.Add(ActifLabel)
        Me.TabPageGeneral.Controls.Add(Me.ActifCheckBox)
        Me.TabPageGeneral.Controls.Add(ModifieLeLabel)
        Me.TabPageGeneral.Controls.Add(Me.ModifieLeTextBox)
        Me.TabPageGeneral.Controls.Add(ModifieParLabel)
        Me.TabPageGeneral.Controls.Add(Me.ModifieParTextBox)
        Me.TabPageGeneral.Controls.Add(CreeLeLabel)
        Me.TabPageGeneral.Controls.Add(Me.CreeLeTextBox)
        Me.TabPageGeneral.Controls.Add(CreeParLabel)
        Me.TabPageGeneral.Controls.Add(Me.CreeParTextBox)
        Me.TabPageGeneral.Controls.Add(ModeReglementLabel)
        Me.TabPageGeneral.Controls.Add(Me.ModeReglementComboBox)
        Me.TabPageGeneral.Controls.Add(EmailLabel)
        Me.TabPageGeneral.Controls.Add(Me.EmailTextBox)
        Me.TabPageGeneral.Controls.Add(FaxLabel)
        Me.TabPageGeneral.Controls.Add(Me.FaxTextBox)
        Me.TabPageGeneral.Controls.Add(MobileLabel)
        Me.TabPageGeneral.Controls.Add(Me.MobileTextBox)
        Me.TabPageGeneral.Controls.Add(TelLabel)
        Me.TabPageGeneral.Controls.Add(Me.TelTextBox)
        Me.TabPageGeneral.Controls.Add(PaysLabel)
        Me.TabPageGeneral.Controls.Add(Me.PaysComboBox)
        Me.TabPageGeneral.Controls.Add(VilleLabel)
        Me.TabPageGeneral.Controls.Add(Me.VilleTextBox)
        Me.TabPageGeneral.Controls.Add(CodePostalLabel)
        Me.TabPageGeneral.Controls.Add(Me.CodePostalTextBox)
        Me.TabPageGeneral.Controls.Add(AdresseL3Label)
        Me.TabPageGeneral.Controls.Add(Me.AdresseL3TextBox)
        Me.TabPageGeneral.Controls.Add(AdresseL2Label)
        Me.TabPageGeneral.Controls.Add(Me.AdresseL2TextBox)
        Me.TabPageGeneral.Controls.Add(AdresseL1Label)
        Me.TabPageGeneral.Controls.Add(Me.AdresseL1TextBox)
        Me.TabPageGeneral.Controls.Add(PrenomLabel)
        Me.TabPageGeneral.Controls.Add(Me.PrenomTextBox)
        Me.TabPageGeneral.Controls.Add(NomLabel)
        Me.TabPageGeneral.Controls.Add(Me.NomTextBox)
        Me.TabPageGeneral.Controls.Add(SociétéLabel)
        Me.TabPageGeneral.Controls.Add(Me.SociétéTextBox)
        Me.TabPageGeneral.Controls.Add(ID_T_FournisseurLabel)
        Me.TabPageGeneral.Controls.Add(Me.ID_T_FournisseurTextBox)
        Me.TabPageGeneral.Controls.Add(Me.ToolStrip)
        Me.TabPageGeneral.Location = New System.Drawing.Point(4, 22)
        Me.TabPageGeneral.Name = "TabPageGeneral"
        Me.TabPageGeneral.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPageGeneral.Size = New System.Drawing.Size(876, 652)
        Me.TabPageGeneral.TabIndex = 0
        Me.TabPageGeneral.Text = "Infos générales"
        Me.TabPageGeneral.UseVisualStyleBackColor = True
        '
        'CommentairesTextBox
        '
        Me.CommentairesTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.T_FournisseurBindingSource, "Commentaires", True))
        Me.CommentairesTextBox.Location = New System.Drawing.Point(525, 72)
        Me.CommentairesTextBox.MaxLength = 4000
        Me.CommentairesTextBox.Multiline = True
        Me.CommentairesTextBox.Name = "CommentairesTextBox"
        Me.CommentairesTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.CommentairesTextBox.Size = New System.Drawing.Size(322, 280)
        Me.CommentairesTextBox.TabIndex = 152
        '
        'T_FournisseurBindingSource
        '
        Me.T_FournisseurBindingSource.DataMember = "T_Fournisseur"
        Me.T_FournisseurBindingSource.DataSource = Me.CLIDataSet
        '
        'NoSiretTextBox
        '
        Me.NoSiretTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.T_FournisseurBindingSource, "NoSiret", True))
        Me.NoSiretTextBox.Location = New System.Drawing.Point(118, 150)
        Me.NoSiretTextBox.Name = "NoSiretTextBox"
        Me.NoSiretTextBox.Size = New System.Drawing.Size(139, 20)
        Me.NoSiretTextBox.TabIndex = 3
        '
        'NoTVATextBox
        '
        Me.NoTVATextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.T_FournisseurBindingSource, "NoTVA", True))
        Me.NoTVATextBox.Location = New System.Drawing.Point(118, 124)
        Me.NoTVATextBox.Name = "NoTVATextBox"
        Me.NoTVATextBox.Size = New System.Drawing.Size(139, 20)
        Me.NoTVATextBox.TabIndex = 2
        '
        'ActifCheckBox
        '
        Me.ActifCheckBox.DataBindings.Add(New System.Windows.Forms.Binding("CheckState", Me.T_FournisseurBindingSource, "Actif", True))
        Me.ActifCheckBox.Location = New System.Drawing.Point(355, 70)
        Me.ActifCheckBox.Name = "ActifCheckBox"
        Me.ActifCheckBox.Size = New System.Drawing.Size(104, 24)
        Me.ActifCheckBox.TabIndex = 150
        Me.ActifCheckBox.UseVisualStyleBackColor = True
        '
        'ModifieLeTextBox
        '
        Me.ModifieLeTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.T_FournisseurBindingSource, "ModifieLe", True))
        Me.ModifieLeTextBox.Location = New System.Drawing.Point(359, 545)
        Me.ModifieLeTextBox.Name = "ModifieLeTextBox"
        Me.ModifieLeTextBox.ReadOnly = True
        Me.ModifieLeTextBox.Size = New System.Drawing.Size(100, 20)
        Me.ModifieLeTextBox.TabIndex = 149
        '
        'ModifieParTextBox
        '
        Me.ModifieParTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.T_FournisseurBindingSource, "ModifiePar", True))
        Me.ModifieParTextBox.Location = New System.Drawing.Point(359, 519)
        Me.ModifieParTextBox.Name = "ModifieParTextBox"
        Me.ModifieParTextBox.ReadOnly = True
        Me.ModifieParTextBox.Size = New System.Drawing.Size(100, 20)
        Me.ModifieParTextBox.TabIndex = 148
        '
        'CreeLeTextBox
        '
        Me.CreeLeTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.T_FournisseurBindingSource, "CreeLe", True))
        Me.CreeLeTextBox.Location = New System.Drawing.Point(118, 542)
        Me.CreeLeTextBox.Name = "CreeLeTextBox"
        Me.CreeLeTextBox.ReadOnly = True
        Me.CreeLeTextBox.Size = New System.Drawing.Size(100, 20)
        Me.CreeLeTextBox.TabIndex = 147
        '
        'CreeParTextBox
        '
        Me.CreeParTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.T_FournisseurBindingSource, "CreePar", True))
        Me.CreeParTextBox.Location = New System.Drawing.Point(118, 516)
        Me.CreeParTextBox.Name = "CreeParTextBox"
        Me.CreeParTextBox.ReadOnly = True
        Me.CreeParTextBox.Size = New System.Drawing.Size(100, 20)
        Me.CreeParTextBox.TabIndex = 146
        '
        'ModeReglementComboBox
        '
        Me.ModeReglementComboBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.T_FournisseurBindingSource, "ModeReglement", True))
        Me.ModeReglementComboBox.DataBindings.Add(New System.Windows.Forms.Binding("SelectedValue", Me.T_FournisseurBindingSource, "ModeReglement", True))
        Me.ModeReglementComboBox.DataSource = Me.TmodeReglementBindingSource
        Me.ModeReglementComboBox.DisplayMember = "Libelle"
        Me.ModeReglementComboBox.FormattingEnabled = True
        Me.ModeReglementComboBox.Location = New System.Drawing.Point(118, 489)
        Me.ModeReglementComboBox.MaxLength = 255
        Me.ModeReglementComboBox.Name = "ModeReglementComboBox"
        Me.ModeReglementComboBox.Size = New System.Drawing.Size(220, 21)
        Me.ModeReglementComboBox.TabIndex = 16
        Me.ModeReglementComboBox.ValueMember = "Libelle"
        '
        'TmodeReglementBindingSource
        '
        Me.TmodeReglementBindingSource.DataMember = "T_modeReglement"
        Me.TmodeReglementBindingSource.DataSource = Me.CLIDataSet
        '
        'EmailTextBox
        '
        Me.EmailTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.T_FournisseurBindingSource, "Email", True))
        Me.EmailTextBox.Location = New System.Drawing.Point(118, 463)
        Me.EmailTextBox.MaxLength = 255
        Me.EmailTextBox.Name = "EmailTextBox"
        Me.EmailTextBox.Size = New System.Drawing.Size(220, 20)
        Me.EmailTextBox.TabIndex = 15
        '
        'FaxTextBox
        '
        Me.FaxTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.T_FournisseurBindingSource, "Fax", True))
        Me.FaxTextBox.Location = New System.Drawing.Point(118, 437)
        Me.FaxTextBox.MaxLength = 255
        Me.FaxTextBox.Name = "FaxTextBox"
        Me.FaxTextBox.Size = New System.Drawing.Size(100, 20)
        Me.FaxTextBox.TabIndex = 14
        '
        'MobileTextBox
        '
        Me.MobileTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.T_FournisseurBindingSource, "Mobile", True))
        Me.MobileTextBox.Location = New System.Drawing.Point(118, 411)
        Me.MobileTextBox.MaxLength = 255
        Me.MobileTextBox.Name = "MobileTextBox"
        Me.MobileTextBox.Size = New System.Drawing.Size(100, 20)
        Me.MobileTextBox.TabIndex = 13
        '
        'TelTextBox
        '
        Me.TelTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.T_FournisseurBindingSource, "Tel", True))
        Me.TelTextBox.Location = New System.Drawing.Point(118, 385)
        Me.TelTextBox.MaxLength = 255
        Me.TelTextBox.Name = "TelTextBox"
        Me.TelTextBox.Size = New System.Drawing.Size(100, 20)
        Me.TelTextBox.TabIndex = 12
        '
        'PaysComboBox
        '
        Me.PaysComboBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.T_FournisseurBindingSource, "Pays", True))
        Me.PaysComboBox.DataBindings.Add(New System.Windows.Forms.Binding("SelectedValue", Me.T_FournisseurBindingSource, "Pays", True))
        Me.PaysComboBox.DataSource = Me.TPaysBindingSource
        Me.PaysComboBox.DisplayMember = "Libelle"
        Me.PaysComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.PaysComboBox.FormattingEnabled = True
        Me.PaysComboBox.Location = New System.Drawing.Point(118, 358)
        Me.PaysComboBox.MaxLength = 255
        Me.PaysComboBox.Name = "PaysComboBox"
        Me.PaysComboBox.Size = New System.Drawing.Size(139, 21)
        Me.PaysComboBox.TabIndex = 11
        Me.PaysComboBox.ValueMember = "Libelle"
        '
        'TPaysBindingSource
        '
        Me.TPaysBindingSource.DataMember = "T_Pays"
        Me.TPaysBindingSource.DataSource = Me.CLIDataSet
        '
        'VilleTextBox
        '
        Me.VilleTextBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.VilleTextBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource
        Me.VilleTextBox.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.VilleTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.T_FournisseurBindingSource, "Ville", True))
        Me.VilleTextBox.Location = New System.Drawing.Point(118, 332)
        Me.VilleTextBox.MaxLength = 255
        Me.VilleTextBox.Name = "VilleTextBox"
        Me.VilleTextBox.Size = New System.Drawing.Size(220, 20)
        Me.VilleTextBox.TabIndex = 10
        '
        'CodePostalTextBox
        '
        Me.CodePostalTextBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.CodePostalTextBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource
        Me.CodePostalTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.T_FournisseurBindingSource, "CodePostal", True))
        Me.CodePostalTextBox.Location = New System.Drawing.Point(118, 306)
        Me.CodePostalTextBox.MaxLength = 255
        Me.CodePostalTextBox.Name = "CodePostalTextBox"
        Me.CodePostalTextBox.Size = New System.Drawing.Size(220, 20)
        Me.CodePostalTextBox.TabIndex = 9
        '
        'AdresseL3TextBox
        '
        Me.AdresseL3TextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.T_FournisseurBindingSource, "AdresseL3", True))
        Me.AdresseL3TextBox.Location = New System.Drawing.Point(118, 280)
        Me.AdresseL3TextBox.MaxLength = 255
        Me.AdresseL3TextBox.Name = "AdresseL3TextBox"
        Me.AdresseL3TextBox.Size = New System.Drawing.Size(220, 20)
        Me.AdresseL3TextBox.TabIndex = 8
        '
        'AdresseL2TextBox
        '
        Me.AdresseL2TextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.T_FournisseurBindingSource, "AdresseL2", True))
        Me.AdresseL2TextBox.Location = New System.Drawing.Point(118, 254)
        Me.AdresseL2TextBox.MaxLength = 255
        Me.AdresseL2TextBox.Name = "AdresseL2TextBox"
        Me.AdresseL2TextBox.Size = New System.Drawing.Size(220, 20)
        Me.AdresseL2TextBox.TabIndex = 7
        '
        'AdresseL1TextBox
        '
        Me.AdresseL1TextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.T_FournisseurBindingSource, "AdresseL1", True))
        Me.AdresseL1TextBox.Location = New System.Drawing.Point(118, 228)
        Me.AdresseL1TextBox.MaxLength = 255
        Me.AdresseL1TextBox.Name = "AdresseL1TextBox"
        Me.AdresseL1TextBox.Size = New System.Drawing.Size(220, 20)
        Me.AdresseL1TextBox.TabIndex = 6
        '
        'PrenomTextBox
        '
        Me.PrenomTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.T_FournisseurBindingSource, "Prenom", True))
        Me.PrenomTextBox.Location = New System.Drawing.Point(118, 202)
        Me.PrenomTextBox.MaxLength = 255
        Me.PrenomTextBox.Name = "PrenomTextBox"
        Me.PrenomTextBox.Size = New System.Drawing.Size(139, 20)
        Me.PrenomTextBox.TabIndex = 5
        '
        'NomTextBox
        '
        Me.NomTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.T_FournisseurBindingSource, "Nom", True))
        Me.NomTextBox.Location = New System.Drawing.Point(118, 176)
        Me.NomTextBox.MaxLength = 255
        Me.NomTextBox.Name = "NomTextBox"
        Me.NomTextBox.Size = New System.Drawing.Size(139, 20)
        Me.NomTextBox.TabIndex = 4
        '
        'SociétéTextBox
        '
        Me.SociétéTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.T_FournisseurBindingSource, "Société", True))
        Me.SociétéTextBox.Location = New System.Drawing.Point(118, 98)
        Me.SociétéTextBox.MaxLength = 255
        Me.SociétéTextBox.Name = "SociétéTextBox"
        Me.SociétéTextBox.Size = New System.Drawing.Size(139, 20)
        Me.SociétéTextBox.TabIndex = 1
        '
        'ID_T_FournisseurTextBox
        '
        Me.ID_T_FournisseurTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.T_FournisseurBindingSource, "ID_T_Fournisseur", True))
        Me.ID_T_FournisseurTextBox.Location = New System.Drawing.Point(118, 72)
        Me.ID_T_FournisseurTextBox.Name = "ID_T_FournisseurTextBox"
        Me.ID_T_FournisseurTextBox.ReadOnly = True
        Me.ID_T_FournisseurTextBox.Size = New System.Drawing.Size(100, 20)
        Me.ID_T_FournisseurTextBox.TabIndex = 0
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
        Me.SupprimerToolStripButton.Image = Global.CLI.My.Resources.Resources.DeleteHS
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
        Me.TabControl1.Location = New System.Drawing.Point(0, 65)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(884, 678)
        Me.TabControl1.TabIndex = 0
        '
        'TabPageArticle
        '
        Me.TabPageArticle.Controls.Add(Me.DGview)
        Me.TabPageArticle.Controls.Add(Me.StatusStripArticles)
        Me.TabPageArticle.Location = New System.Drawing.Point(4, 22)
        Me.TabPageArticle.Name = "TabPageArticle"
        Me.TabPageArticle.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPageArticle.Size = New System.Drawing.Size(876, 652)
        Me.TabPageArticle.TabIndex = 1
        Me.TabPageArticle.Text = "Articles"
        Me.TabPageArticle.UseVisualStyleBackColor = True
        '
        'DGview
        '
        Me.DGview.AllowUserToAddRows = False
        Me.DGview.AllowUserToDeleteRows = False
        Me.DGview.AllowUserToResizeRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.DGview.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.DGview.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DGview.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.DGview.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Active_on, Me.Ref, Me.Descriptioncourte, Me.prix_vente_initial_TTC, Me.remise, Me.prix_vente_remise_TTC, Me.web_on, Me.magasin_on, Me.Stock})
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle7.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        DataGridViewCellStyle7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DGview.DefaultCellStyle = DataGridViewCellStyle7
        Me.DGview.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DGview.Location = New System.Drawing.Point(3, 3)
        Me.DGview.MultiSelect = False
        Me.DGview.Name = "DGview"
        Me.DGview.ReadOnly = True
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DGview.RowHeadersDefaultCellStyle = DataGridViewCellStyle8
        Me.DGview.RowHeadersVisible = False
        Me.DGview.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DGview.Size = New System.Drawing.Size(870, 624)
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
        Me.Descriptioncourte.DataPropertyName = "Description courte"
        Me.Descriptioncourte.HeaderText = "Description courte"
        Me.Descriptioncourte.Name = "Descriptioncourte"
        Me.Descriptioncourte.ReadOnly = True
        Me.Descriptioncourte.Width = 118
        '
        'prix_vente_initial_TTC
        '
        Me.prix_vente_initial_TTC.DataPropertyName = "prix_vente_initial_TTC"
        DataGridViewCellStyle3.Format = "C2"
        DataGridViewCellStyle3.NullValue = Nothing
        Me.prix_vente_initial_TTC.DefaultCellStyle = DataGridViewCellStyle3
        Me.prix_vente_initial_TTC.HeaderText = "PV initial TTC"
        Me.prix_vente_initial_TTC.Name = "prix_vente_initial_TTC"
        Me.prix_vente_initial_TTC.ReadOnly = True
        Me.prix_vente_initial_TTC.Width = 96
        '
        'remise
        '
        Me.remise.DataPropertyName = "remise"
        DataGridViewCellStyle4.Format = "0 %"
        DataGridViewCellStyle4.NullValue = "-"
        Me.remise.DefaultCellStyle = DataGridViewCellStyle4
        Me.remise.HeaderText = "Remise"
        Me.remise.Name = "remise"
        Me.remise.ReadOnly = True
        Me.remise.Width = 67
        '
        'prix_vente_remise_TTC
        '
        Me.prix_vente_remise_TTC.DataPropertyName = "prix_vente_remise_TTC"
        DataGridViewCellStyle5.Format = "C2"
        Me.prix_vente_remise_TTC.DefaultCellStyle = DataGridViewCellStyle5
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
        DataGridViewCellStyle6.NullValue = "0"
        Me.Stock.DefaultCellStyle = DataGridViewCellStyle6
        Me.Stock.HeaderText = "Stock"
        Me.Stock.Name = "Stock"
        Me.Stock.ReadOnly = True
        Me.Stock.Width = 60
        '
        'StatusStripArticles
        '
        Me.StatusStripArticles.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripStatusLabelNbEnregistrementsArticles})
        Me.StatusStripArticles.Location = New System.Drawing.Point(3, 627)
        Me.StatusStripArticles.Name = "StatusStripArticles"
        Me.StatusStripArticles.Size = New System.Drawing.Size(870, 22)
        Me.StatusStripArticles.TabIndex = 9
        Me.StatusStripArticles.Text = "StatusStrip"
        '
        'ToolStripStatusLabelNbEnregistrementsArticles
        '
        Me.ToolStripStatusLabelNbEnregistrementsArticles.Name = "ToolStripStatusLabelNbEnregistrementsArticles"
        Me.ToolStripStatusLabelNbEnregistrementsArticles.Size = New System.Drawing.Size(203, 17)
        Me.ToolStripStatusLabelNbEnregistrementsArticles.Text = "{0000} enregistrement(s) sélectionnés"
        '
        'ContextMenuStripRecherche
        '
        Me.ContextMenuStripRecherche.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.StockToolStripMenuItem})
        Me.ContextMenuStripRecherche.Name = "ContextMenuStrip"
        Me.ContextMenuStripRecherche.Size = New System.Drawing.Size(104, 26)
        '
        'StockToolStripMenuItem
        '
        Me.StockToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.InventaireToolStripMenuItem, Me.MouvementToolStripMenuItem})
        Me.StockToolStripMenuItem.Image = Global.CLI.My.Resources.Resources.TaskHS1
        Me.StockToolStripMenuItem.Name = "StockToolStripMenuItem"
        Me.StockToolStripMenuItem.Size = New System.Drawing.Size(103, 22)
        Me.StockToolStripMenuItem.Text = "Stock"
        '
        'InventaireToolStripMenuItem
        '
        Me.InventaireToolStripMenuItem.Image = Global.CLI.My.Resources.Resources.MonthlyViewHS
        Me.InventaireToolStripMenuItem.Name = "InventaireToolStripMenuItem"
        Me.InventaireToolStripMenuItem.Size = New System.Drawing.Size(139, 22)
        Me.InventaireToolStripMenuItem.Text = "Inventaire"
        '
        'MouvementToolStripMenuItem
        '
        Me.MouvementToolStripMenuItem.Image = Global.CLI.My.Resources.Resources.AddTableHS
        Me.MouvementToolStripMenuItem.Name = "MouvementToolStripMenuItem"
        Me.MouvementToolStripMenuItem.Size = New System.Drawing.Size(139, 22)
        Me.MouvementToolStripMenuItem.Text = "Mouvement"
        '
        'T_PaysTableAdapter
        '
        Me.T_PaysTableAdapter.ClearBeforeFill = True
        '
        'T_modeReglementTableAdapter
        '
        Me.T_modeReglementTableAdapter.ClearBeforeFill = True
        '
        'ExportFileLabel
        '
        ExportFileLabel.AutoSize = True
        ExportFileLabel.Location = New System.Drawing.Point(482, 522)
        ExportFileLabel.Name = "ExportFileLabel"
        ExportFileLabel.Size = New System.Drawing.Size(109, 13)
        ExportFileLabel.TabIndex = 152
        ExportFileLabel.Text = "Transfert WebCaisse:"
        '
        'ExportFileTextBox
        '
        Me.ExportFileTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.T_FournisseurBindingSource, "ExportFile", True))
        Me.ExportFileTextBox.Location = New System.Drawing.Point(594, 519)
        Me.ExportFileTextBox.Name = "ExportFileTextBox"
        Me.ExportFileTextBox.ReadOnly = True
        Me.ExportFileTextBox.Size = New System.Drawing.Size(253, 20)
        Me.ExportFileTextBox.TabIndex = 153
        Me.ExportFileTextBox.Tag = "1"
        '
        'FormFournisseur
        '
        Me.AcceptButton = Me.BT_Enregistrer
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.BT_Fermer
        Me.ClientSize = New System.Drawing.Size(896, 755)
        Me.Controls.Add(Me.ToolStrip2)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.BT_Enregistrer)
        Me.Controls.Add(Me.BT_Refresh)
        Me.Controls.Add(Me.BT_Fermer)
        Me.Name = "FormFournisseur"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Fournisseur"
        CType(Me.CLIDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ToolStrip2.ResumeLayout(False)
        Me.ToolStrip2.PerformLayout()
        Me.TabPageGeneral.ResumeLayout(False)
        Me.TabPageGeneral.PerformLayout()
        CType(Me.T_FournisseurBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TmodeReglementBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TPaysBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ToolStrip.ResumeLayout(False)
        Me.ToolStrip.PerformLayout()
        Me.TabControl1.ResumeLayout(False)
        Me.TabPageArticle.ResumeLayout(False)
        Me.TabPageArticle.PerformLayout()
        CType(Me.DGview, System.ComponentModel.ISupportInitialize).EndInit()
        Me.StatusStripArticles.ResumeLayout(False)
        Me.StatusStripArticles.PerformLayout()
        Me.ContextMenuStripRecherche.ResumeLayout(False)
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
    Friend WithEvents T_FournisseurTableAdapter As CLI.CLIDataSetTableAdapters.T_FournisseurTableAdapter

    Friend WithEvents TabPageGeneral As System.Windows.Forms.TabPage
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
    Friend WithEvents ModifieLeTextBox As System.Windows.Forms.TextBox
    Friend WithEvents T_FournisseurBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents ModifieParTextBox As System.Windows.Forms.TextBox
    Friend WithEvents CreeLeTextBox As System.Windows.Forms.TextBox
    Friend WithEvents CreeParTextBox As System.Windows.Forms.TextBox
    Friend WithEvents ModeReglementComboBox As System.Windows.Forms.ComboBox
    Friend WithEvents EmailTextBox As System.Windows.Forms.TextBox
    Friend WithEvents FaxTextBox As System.Windows.Forms.TextBox
    Friend WithEvents MobileTextBox As System.Windows.Forms.TextBox
    Friend WithEvents TelTextBox As System.Windows.Forms.TextBox
    Friend WithEvents PaysComboBox As System.Windows.Forms.ComboBox
    Friend WithEvents VilleTextBox As System.Windows.Forms.TextBox
    Friend WithEvents CodePostalTextBox As System.Windows.Forms.TextBox
    Friend WithEvents AdresseL3TextBox As System.Windows.Forms.TextBox
    Friend WithEvents AdresseL2TextBox As System.Windows.Forms.TextBox
    Friend WithEvents AdresseL1TextBox As System.Windows.Forms.TextBox
    Friend WithEvents PrenomTextBox As System.Windows.Forms.TextBox
    Friend WithEvents NomTextBox As System.Windows.Forms.TextBox
    Friend WithEvents SociétéTextBox As System.Windows.Forms.TextBox
    Friend WithEvents ID_T_FournisseurTextBox As System.Windows.Forms.TextBox
    Friend WithEvents ActifCheckBox As System.Windows.Forms.CheckBox
    Friend WithEvents TPaysBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents T_PaysTableAdapter As CLI.CLIDataSetTableAdapters.T_PaysTableAdapter
    Friend WithEvents TmodeReglementBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents T_modeReglementTableAdapter As CLI.CLIDataSetTableAdapters.T_modeReglementTableAdapter
    Friend WithEvents TabPageArticle As System.Windows.Forms.TabPage
    Friend WithEvents StatusStripArticles As System.Windows.Forms.StatusStrip
    Friend WithEvents ToolStripStatusLabelNbEnregistrementsArticles As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents DGview As System.Windows.Forms.DataGridView
    Friend WithEvents Active_on As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents Ref As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Descriptioncourte As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents prix_vente_initial_TTC As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents remise As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents prix_vente_remise_TTC As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents web_on As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents magasin_on As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents Stock As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ContextMenuStripRecherche As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents StockToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents InventaireToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MouvementToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents NoSiretTextBox As System.Windows.Forms.TextBox
    Friend WithEvents NoTVATextBox As System.Windows.Forms.TextBox
    Friend WithEvents CommentairesTextBox As System.Windows.Forms.TextBox
    Friend WithEvents ExportFileTextBox As TextBox
End Class
