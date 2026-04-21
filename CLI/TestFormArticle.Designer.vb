<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class TestFormArticle
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
        Me.components = New System.ComponentModel.Container
        Dim PhotoLabel As System.Windows.Forms.Label
        Dim Photo2Label As System.Windows.Forms.Label
        Dim Photo_promoLabel As System.Windows.Forms.Label
        Dim Photo_promo2Label As System.Windows.Forms.Label
        Dim AnneeLabel As System.Windows.Forms.Label
        Dim MarqueLabel As System.Windows.Forms.Label
        Dim ModeleLabel As System.Windows.Forms.Label
        Dim SurfaceLabel As System.Windows.Forms.Label
        Dim GuindantLabel As System.Windows.Forms.Label
        Dim WishboneLabel As System.Windows.Forms.Label
        Dim MatLabel As System.Windows.Forms.Label
        Dim LattesLabel As System.Windows.Forms.Label
        Dim CamLabel As System.Windows.Forms.Label
        Dim LienLabel As System.Windows.Forms.Label
        Dim ActiveLabel As System.Windows.Forms.Label
        Dim Photo_modeleLabel As System.Windows.Forms.Label
        Dim Code_tvaLabel1 As System.Windows.Forms.Label
        Dim ProgrammeLabel As System.Windows.Forms.Label
        Dim DescriptionLabel As System.Windows.Forms.Label
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(TestFormArticle))
        Me.T_Article_EnteteBindingNavigator = New System.Windows.Forms.BindingNavigator(Me.components)
        Me.BindingNavigatorAddNewItem = New System.Windows.Forms.ToolStripButton
        Me.T_Article_EnteteBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.CHINOOSURDataSet = New CLI.CHINOOSURDataSet
        Me.BindingNavigatorCountItem = New System.Windows.Forms.ToolStripLabel
        Me.BindingNavigatorDeleteItem = New System.Windows.Forms.ToolStripButton
        Me.BindingNavigatorMoveFirstItem = New System.Windows.Forms.ToolStripButton
        Me.BindingNavigatorMovePreviousItem = New System.Windows.Forms.ToolStripButton
        Me.BindingNavigatorSeparator = New System.Windows.Forms.ToolStripSeparator
        Me.BindingNavigatorPositionItem = New System.Windows.Forms.ToolStripTextBox
        Me.BindingNavigatorSeparator1 = New System.Windows.Forms.ToolStripSeparator
        Me.BindingNavigatorMoveNextItem = New System.Windows.Forms.ToolStripButton
        Me.BindingNavigatorMoveLastItem = New System.Windows.Forms.ToolStripButton
        Me.BindingNavigatorSeparator2 = New System.Windows.Forms.ToolStripSeparator
        Me.T_Article_EnteteBindingNavigatorSaveItem = New System.Windows.Forms.ToolStripButton
        Me.PhotoTextBox = New System.Windows.Forms.TextBox
        Me.Photo2TextBox = New System.Windows.Forms.TextBox
        Me.Photo_promoTextBox = New System.Windows.Forms.TextBox
        Me.Photo_promo2TextBox = New System.Windows.Forms.TextBox
        Me.AnneeTextBox = New System.Windows.Forms.TextBox
        Me.MarqueTextBox = New System.Windows.Forms.TextBox
        Me.ModeleTextBox = New System.Windows.Forms.TextBox
        Me.SurfaceTextBox = New System.Windows.Forms.TextBox
        Me.GuindantTextBox = New System.Windows.Forms.TextBox
        Me.WishboneTextBox = New System.Windows.Forms.TextBox
        Me.MatTextBox = New System.Windows.Forms.TextBox
        Me.LattesTextBox = New System.Windows.Forms.TextBox
        Me.CamTextBox = New System.Windows.Forms.TextBox
        Me.LienTextBox = New System.Windows.Forms.TextBox
        Me.ActiveCheckBox = New System.Windows.Forms.CheckBox
        Me.Photo_modeleTextBox = New System.Windows.Forms.TextBox
        Me.T_Article_EnteteTableAdapter = New CLI.CHINOOSURDataSetTableAdapters.T_Article_EnteteTableAdapter
        Me.Code_tvaComboBox = New System.Windows.Forms.ComboBox
        Me.CodetvaBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.GroupBoxGeneral = New System.Windows.Forms.GroupBox
        Me.GroupBoxPhotos = New System.Windows.Forms.GroupBox
        Me.GroupBoxTechnique = New System.Windows.Forms.GroupBox
        Me.ProgrammeComboBox = New System.Windows.Forms.ComboBox
        Me.VprogrammeBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.T_Article_DetailBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.T_Article_DetailTableAdapter = New CLI.CHINOOSURDataSetTableAdapters.T_Article_DetailTableAdapter
        Me.T_Article_DetailDataGridView = New System.Windows.Forms.DataGridView
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn4 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn5 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewCheckBoxColumn1 = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Me.DataGridViewCheckBoxColumn2 = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Me.DataGridViewTextBoxColumn6 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn7 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewCheckBoxColumn3 = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Me.DataGridViewCheckBoxColumn4 = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Me.DataGridViewCheckBoxColumn5 = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Me.DataGridViewTextBoxColumn8 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn9 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewCheckBoxColumn6 = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Me.DataGridViewTextBoxColumn10 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn11 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewImageColumn1 = New System.Windows.Forms.DataGridViewImageColumn
        Me.Code_tvaTableAdapter = New CLI.CHINOOSURDataSetTableAdapters.code_tvaTableAdapter
        Me.V_programmeTableAdapter = New CLI.CHINOOSURDataSetTableAdapters.V_programmeTableAdapter
        Me.GroupBoxDescription = New System.Windows.Forms.GroupBox
        Me.DescriptionTextBox = New System.Windows.Forms.TextBox
        Me.ErrorProviderCli = New System.Windows.Forms.ErrorProvider(Me.components)
        PhotoLabel = New System.Windows.Forms.Label
        Photo2Label = New System.Windows.Forms.Label
        Photo_promoLabel = New System.Windows.Forms.Label
        Photo_promo2Label = New System.Windows.Forms.Label
        AnneeLabel = New System.Windows.Forms.Label
        MarqueLabel = New System.Windows.Forms.Label
        ModeleLabel = New System.Windows.Forms.Label
        SurfaceLabel = New System.Windows.Forms.Label
        GuindantLabel = New System.Windows.Forms.Label
        WishboneLabel = New System.Windows.Forms.Label
        MatLabel = New System.Windows.Forms.Label
        LattesLabel = New System.Windows.Forms.Label
        CamLabel = New System.Windows.Forms.Label
        LienLabel = New System.Windows.Forms.Label
        ActiveLabel = New System.Windows.Forms.Label
        Photo_modeleLabel = New System.Windows.Forms.Label
        Code_tvaLabel1 = New System.Windows.Forms.Label
        ProgrammeLabel = New System.Windows.Forms.Label
        DescriptionLabel = New System.Windows.Forms.Label
        CType(Me.T_Article_EnteteBindingNavigator, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.T_Article_EnteteBindingNavigator.SuspendLayout()
        CType(Me.T_Article_EnteteBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CHINOOSURDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CodetvaBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBoxGeneral.SuspendLayout()
        Me.GroupBoxPhotos.SuspendLayout()
        Me.GroupBoxTechnique.SuspendLayout()
        CType(Me.VprogrammeBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.T_Article_DetailBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.T_Article_DetailDataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBoxDescription.SuspendLayout()
        CType(Me.ErrorProviderCli, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PhotoLabel
        '
        PhotoLabel.AutoSize = True
        PhotoLabel.Location = New System.Drawing.Point(6, 21)
        PhotoLabel.Name = "PhotoLabel"
        PhotoLabel.Size = New System.Drawing.Size(37, 13)
        PhotoLabel.TabIndex = 5
        PhotoLabel.Text = "photo:"
        '
        'Photo2Label
        '
        Photo2Label.AutoSize = True
        Photo2Label.Location = New System.Drawing.Point(6, 47)
        Photo2Label.Name = "Photo2Label"
        Photo2Label.Size = New System.Drawing.Size(43, 13)
        Photo2Label.TabIndex = 7
        Photo2Label.Text = "photo2:"
        '
        'Photo_promoLabel
        '
        Photo_promoLabel.AutoSize = True
        Photo_promoLabel.Location = New System.Drawing.Point(6, 73)
        Photo_promoLabel.Name = "Photo_promoLabel"
        Photo_promoLabel.Size = New System.Drawing.Size(69, 13)
        Photo_promoLabel.TabIndex = 9
        Photo_promoLabel.Text = "photo promo:"
        '
        'Photo_promo2Label
        '
        Photo_promo2Label.AutoSize = True
        Photo_promo2Label.Location = New System.Drawing.Point(6, 99)
        Photo_promo2Label.Name = "Photo_promo2Label"
        Photo_promo2Label.Size = New System.Drawing.Size(75, 13)
        Photo_promo2Label.TabIndex = 11
        Photo_promo2Label.Text = "photo promo2:"
        '
        'AnneeLabel
        '
        AnneeLabel.AutoSize = True
        AnneeLabel.Location = New System.Drawing.Point(6, 21)
        AnneeLabel.Name = "AnneeLabel"
        AnneeLabel.Size = New System.Drawing.Size(40, 13)
        AnneeLabel.TabIndex = 13
        AnneeLabel.Text = "annee:"
        '
        'MarqueLabel
        '
        MarqueLabel.AutoSize = True
        MarqueLabel.Location = New System.Drawing.Point(6, 47)
        MarqueLabel.Name = "MarqueLabel"
        MarqueLabel.Size = New System.Drawing.Size(45, 13)
        MarqueLabel.TabIndex = 15
        MarqueLabel.Text = "marque:"
        '
        'ModeleLabel
        '
        ModeleLabel.AutoSize = True
        ModeleLabel.Location = New System.Drawing.Point(6, 73)
        ModeleLabel.Name = "ModeleLabel"
        ModeleLabel.Size = New System.Drawing.Size(44, 13)
        ModeleLabel.TabIndex = 17
        ModeleLabel.Text = "modele:"
        '
        'SurfaceLabel
        '
        SurfaceLabel.AutoSize = True
        SurfaceLabel.Location = New System.Drawing.Point(6, 28)
        SurfaceLabel.Name = "SurfaceLabel"
        SurfaceLabel.Size = New System.Drawing.Size(45, 13)
        SurfaceLabel.TabIndex = 19
        SurfaceLabel.Text = "surface:"
        '
        'GuindantLabel
        '
        GuindantLabel.AutoSize = True
        GuindantLabel.Location = New System.Drawing.Point(6, 54)
        GuindantLabel.Name = "GuindantLabel"
        GuindantLabel.Size = New System.Drawing.Size(51, 13)
        GuindantLabel.TabIndex = 21
        GuindantLabel.Text = "guindant:"
        '
        'WishboneLabel
        '
        WishboneLabel.AutoSize = True
        WishboneLabel.Location = New System.Drawing.Point(6, 80)
        WishboneLabel.Name = "WishboneLabel"
        WishboneLabel.Size = New System.Drawing.Size(55, 13)
        WishboneLabel.TabIndex = 23
        WishboneLabel.Text = "wishbone:"
        '
        'MatLabel
        '
        MatLabel.AutoSize = True
        MatLabel.Location = New System.Drawing.Point(6, 106)
        MatLabel.Name = "MatLabel"
        MatLabel.Size = New System.Drawing.Size(28, 13)
        MatLabel.TabIndex = 25
        MatLabel.Text = "Mat:"
        '
        'LattesLabel
        '
        LattesLabel.AutoSize = True
        LattesLabel.Location = New System.Drawing.Point(214, 25)
        LattesLabel.Name = "LattesLabel"
        LattesLabel.Size = New System.Drawing.Size(39, 13)
        LattesLabel.TabIndex = 27
        LattesLabel.Text = "Lattes:"
        '
        'CamLabel
        '
        CamLabel.AutoSize = True
        CamLabel.Location = New System.Drawing.Point(214, 51)
        CamLabel.Name = "CamLabel"
        CamLabel.Size = New System.Drawing.Size(31, 13)
        CamLabel.TabIndex = 29
        CamLabel.Text = "Cam:"
        '
        'LienLabel
        '
        LienLabel.AutoSize = True
        LienLabel.Location = New System.Drawing.Point(6, 100)
        LienLabel.Name = "LienLabel"
        LienLabel.Size = New System.Drawing.Size(26, 13)
        LienLabel.TabIndex = 35
        LienLabel.Text = "lien:"
        '
        'ActiveLabel
        '
        ActiveLabel.AutoSize = True
        ActiveLabel.Location = New System.Drawing.Point(6, 128)
        ActiveLabel.Name = "ActiveLabel"
        ActiveLabel.Size = New System.Drawing.Size(39, 13)
        ActiveLabel.TabIndex = 37
        ActiveLabel.Text = "active:"
        '
        'Photo_modeleLabel
        '
        Photo_modeleLabel.AutoSize = True
        Photo_modeleLabel.Location = New System.Drawing.Point(6, 125)
        Photo_modeleLabel.Name = "Photo_modeleLabel"
        Photo_modeleLabel.Size = New System.Drawing.Size(74, 13)
        Photo_modeleLabel.TabIndex = 41
        Photo_modeleLabel.Text = "photo modele:"
        '
        'Code_tvaLabel1
        '
        Code_tvaLabel1.AutoSize = True
        Code_tvaLabel1.Location = New System.Drawing.Point(6, 153)
        Code_tvaLabel1.Name = "Code_tvaLabel1"
        Code_tvaLabel1.Size = New System.Drawing.Size(53, 13)
        Code_tvaLabel1.TabIndex = 42
        Code_tvaLabel1.Text = "Code tva:"
        '
        'ProgrammeLabel
        '
        ProgrammeLabel.AutoSize = True
        ProgrammeLabel.Location = New System.Drawing.Point(214, 77)
        ProgrammeLabel.Name = "ProgrammeLabel"
        ProgrammeLabel.Size = New System.Drawing.Size(62, 13)
        ProgrammeLabel.TabIndex = 30
        ProgrammeLabel.Text = "programme:"
        '
        'DescriptionLabel
        '
        DescriptionLabel.AutoSize = True
        DescriptionLabel.Location = New System.Drawing.Point(6, 16)
        DescriptionLabel.Name = "DescriptionLabel"
        DescriptionLabel.Size = New System.Drawing.Size(61, 13)
        DescriptionLabel.TabIndex = 35
        DescriptionLabel.Text = "description:"
        '
        'T_Article_EnteteBindingNavigator
        '
        Me.T_Article_EnteteBindingNavigator.AddNewItem = Me.BindingNavigatorAddNewItem
        Me.T_Article_EnteteBindingNavigator.BindingSource = Me.T_Article_EnteteBindingSource
        Me.T_Article_EnteteBindingNavigator.CountItem = Me.BindingNavigatorCountItem
        Me.T_Article_EnteteBindingNavigator.DeleteItem = Me.BindingNavigatorDeleteItem
        Me.T_Article_EnteteBindingNavigator.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BindingNavigatorMoveFirstItem, Me.BindingNavigatorMovePreviousItem, Me.BindingNavigatorSeparator, Me.BindingNavigatorPositionItem, Me.BindingNavigatorCountItem, Me.BindingNavigatorSeparator1, Me.BindingNavigatorMoveNextItem, Me.BindingNavigatorMoveLastItem, Me.BindingNavigatorSeparator2, Me.BindingNavigatorAddNewItem, Me.BindingNavigatorDeleteItem, Me.T_Article_EnteteBindingNavigatorSaveItem})
        Me.T_Article_EnteteBindingNavigator.Location = New System.Drawing.Point(0, 0)
        Me.T_Article_EnteteBindingNavigator.MoveFirstItem = Me.BindingNavigatorMoveFirstItem
        Me.T_Article_EnteteBindingNavigator.MoveLastItem = Me.BindingNavigatorMoveLastItem
        Me.T_Article_EnteteBindingNavigator.MoveNextItem = Me.BindingNavigatorMoveNextItem
        Me.T_Article_EnteteBindingNavigator.MovePreviousItem = Me.BindingNavigatorMovePreviousItem
        Me.T_Article_EnteteBindingNavigator.Name = "T_Article_EnteteBindingNavigator"
        Me.T_Article_EnteteBindingNavigator.PositionItem = Me.BindingNavigatorPositionItem
        Me.T_Article_EnteteBindingNavigator.Size = New System.Drawing.Size(556, 25)
        Me.T_Article_EnteteBindingNavigator.TabIndex = 0
        Me.T_Article_EnteteBindingNavigator.Text = "BindingNavigator1"
        '
        'BindingNavigatorAddNewItem
        '
        Me.BindingNavigatorAddNewItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BindingNavigatorAddNewItem.Image = CType(resources.GetObject("BindingNavigatorAddNewItem.Image"), System.Drawing.Image)
        Me.BindingNavigatorAddNewItem.Name = "BindingNavigatorAddNewItem"
        Me.BindingNavigatorAddNewItem.RightToLeftAutoMirrorImage = True
        Me.BindingNavigatorAddNewItem.Size = New System.Drawing.Size(23, 22)
        Me.BindingNavigatorAddNewItem.Text = "Ajouter nouveau"
        '
        'T_Article_EnteteBindingSource
        '
        Me.T_Article_EnteteBindingSource.DataMember = "T_Article_Entete"
        Me.T_Article_EnteteBindingSource.DataSource = Me.CHINOOSURDataSet
        '
        'CHINOOSURDataSet
        '
        Me.CHINOOSURDataSet.DataSetName = "CHINOOSURDataSet"
        Me.CHINOOSURDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'BindingNavigatorCountItem
        '
        Me.BindingNavigatorCountItem.Name = "BindingNavigatorCountItem"
        Me.BindingNavigatorCountItem.Size = New System.Drawing.Size(38, 22)
        Me.BindingNavigatorCountItem.Text = "de {0}"
        Me.BindingNavigatorCountItem.ToolTipText = "Nombre total d'éléments"
        '
        'BindingNavigatorDeleteItem
        '
        Me.BindingNavigatorDeleteItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BindingNavigatorDeleteItem.Image = CType(resources.GetObject("BindingNavigatorDeleteItem.Image"), System.Drawing.Image)
        Me.BindingNavigatorDeleteItem.Name = "BindingNavigatorDeleteItem"
        Me.BindingNavigatorDeleteItem.RightToLeftAutoMirrorImage = True
        Me.BindingNavigatorDeleteItem.Size = New System.Drawing.Size(23, 22)
        Me.BindingNavigatorDeleteItem.Text = "Supprimer"
        '
        'BindingNavigatorMoveFirstItem
        '
        Me.BindingNavigatorMoveFirstItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BindingNavigatorMoveFirstItem.Image = CType(resources.GetObject("BindingNavigatorMoveFirstItem.Image"), System.Drawing.Image)
        Me.BindingNavigatorMoveFirstItem.Name = "BindingNavigatorMoveFirstItem"
        Me.BindingNavigatorMoveFirstItem.RightToLeftAutoMirrorImage = True
        Me.BindingNavigatorMoveFirstItem.Size = New System.Drawing.Size(23, 22)
        Me.BindingNavigatorMoveFirstItem.Text = "Placer en premier"
        '
        'BindingNavigatorMovePreviousItem
        '
        Me.BindingNavigatorMovePreviousItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BindingNavigatorMovePreviousItem.Image = CType(resources.GetObject("BindingNavigatorMovePreviousItem.Image"), System.Drawing.Image)
        Me.BindingNavigatorMovePreviousItem.Name = "BindingNavigatorMovePreviousItem"
        Me.BindingNavigatorMovePreviousItem.RightToLeftAutoMirrorImage = True
        Me.BindingNavigatorMovePreviousItem.Size = New System.Drawing.Size(23, 22)
        Me.BindingNavigatorMovePreviousItem.Text = "Déplacer vers le haut"
        '
        'BindingNavigatorSeparator
        '
        Me.BindingNavigatorSeparator.Name = "BindingNavigatorSeparator"
        Me.BindingNavigatorSeparator.Size = New System.Drawing.Size(6, 25)
        '
        'BindingNavigatorPositionItem
        '
        Me.BindingNavigatorPositionItem.AccessibleName = "Position"
        Me.BindingNavigatorPositionItem.AutoSize = False
        Me.BindingNavigatorPositionItem.Name = "BindingNavigatorPositionItem"
        Me.BindingNavigatorPositionItem.Size = New System.Drawing.Size(50, 21)
        Me.BindingNavigatorPositionItem.Text = "0"
        Me.BindingNavigatorPositionItem.ToolTipText = "Position actuelle"
        '
        'BindingNavigatorSeparator1
        '
        Me.BindingNavigatorSeparator1.Name = "BindingNavigatorSeparator1"
        Me.BindingNavigatorSeparator1.Size = New System.Drawing.Size(6, 25)
        '
        'BindingNavigatorMoveNextItem
        '
        Me.BindingNavigatorMoveNextItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BindingNavigatorMoveNextItem.Image = CType(resources.GetObject("BindingNavigatorMoveNextItem.Image"), System.Drawing.Image)
        Me.BindingNavigatorMoveNextItem.Name = "BindingNavigatorMoveNextItem"
        Me.BindingNavigatorMoveNextItem.RightToLeftAutoMirrorImage = True
        Me.BindingNavigatorMoveNextItem.Size = New System.Drawing.Size(23, 22)
        Me.BindingNavigatorMoveNextItem.Text = "Déplacer vers le bas"
        '
        'BindingNavigatorMoveLastItem
        '
        Me.BindingNavigatorMoveLastItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BindingNavigatorMoveLastItem.Image = CType(resources.GetObject("BindingNavigatorMoveLastItem.Image"), System.Drawing.Image)
        Me.BindingNavigatorMoveLastItem.Name = "BindingNavigatorMoveLastItem"
        Me.BindingNavigatorMoveLastItem.RightToLeftAutoMirrorImage = True
        Me.BindingNavigatorMoveLastItem.Size = New System.Drawing.Size(23, 22)
        Me.BindingNavigatorMoveLastItem.Text = "Placer en dernier"
        '
        'BindingNavigatorSeparator2
        '
        Me.BindingNavigatorSeparator2.Name = "BindingNavigatorSeparator2"
        Me.BindingNavigatorSeparator2.Size = New System.Drawing.Size(6, 25)
        '
        'T_Article_EnteteBindingNavigatorSaveItem
        '
        Me.T_Article_EnteteBindingNavigatorSaveItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.T_Article_EnteteBindingNavigatorSaveItem.Image = CType(resources.GetObject("T_Article_EnteteBindingNavigatorSaveItem.Image"), System.Drawing.Image)
        Me.T_Article_EnteteBindingNavigatorSaveItem.Name = "T_Article_EnteteBindingNavigatorSaveItem"
        Me.T_Article_EnteteBindingNavigatorSaveItem.Size = New System.Drawing.Size(23, 22)
        Me.T_Article_EnteteBindingNavigatorSaveItem.Text = "Enregistrer les données"
        '
        'PhotoTextBox
        '
        Me.PhotoTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.T_Article_EnteteBindingSource, "photo", True))
        Me.PhotoTextBox.Location = New System.Drawing.Point(87, 18)
        Me.PhotoTextBox.Name = "PhotoTextBox"
        Me.PhotoTextBox.Size = New System.Drawing.Size(104, 20)
        Me.PhotoTextBox.TabIndex = 6
        '
        'Photo2TextBox
        '
        Me.Photo2TextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.T_Article_EnteteBindingSource, "photo2", True))
        Me.Photo2TextBox.Location = New System.Drawing.Point(87, 44)
        Me.Photo2TextBox.Name = "Photo2TextBox"
        Me.Photo2TextBox.Size = New System.Drawing.Size(104, 20)
        Me.Photo2TextBox.TabIndex = 8
        '
        'Photo_promoTextBox
        '
        Me.Photo_promoTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.T_Article_EnteteBindingSource, "photo_promo", True))
        Me.Photo_promoTextBox.Location = New System.Drawing.Point(87, 70)
        Me.Photo_promoTextBox.Name = "Photo_promoTextBox"
        Me.Photo_promoTextBox.Size = New System.Drawing.Size(104, 20)
        Me.Photo_promoTextBox.TabIndex = 10
        '
        'Photo_promo2TextBox
        '
        Me.Photo_promo2TextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.T_Article_EnteteBindingSource, "photo_promo2", True))
        Me.Photo_promo2TextBox.Location = New System.Drawing.Point(87, 96)
        Me.Photo_promo2TextBox.Name = "Photo_promo2TextBox"
        Me.Photo_promo2TextBox.Size = New System.Drawing.Size(104, 20)
        Me.Photo_promo2TextBox.TabIndex = 12
        '
        'AnneeTextBox
        '
        Me.AnneeTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.T_Article_EnteteBindingSource, "annee", True))
        Me.AnneeTextBox.Location = New System.Drawing.Point(87, 18)
        Me.AnneeTextBox.Name = "AnneeTextBox"
        Me.AnneeTextBox.Size = New System.Drawing.Size(104, 20)
        Me.AnneeTextBox.TabIndex = 14
        '
        'MarqueTextBox
        '
        Me.MarqueTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.T_Article_EnteteBindingSource, "marque", True))
        Me.MarqueTextBox.Location = New System.Drawing.Point(87, 44)
        Me.MarqueTextBox.Name = "MarqueTextBox"
        Me.MarqueTextBox.Size = New System.Drawing.Size(104, 20)
        Me.MarqueTextBox.TabIndex = 16
        '
        'ModeleTextBox
        '
        Me.ModeleTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.T_Article_EnteteBindingSource, "modele", True))
        Me.ModeleTextBox.Location = New System.Drawing.Point(87, 70)
        Me.ModeleTextBox.Name = "ModeleTextBox"
        Me.ModeleTextBox.Size = New System.Drawing.Size(104, 20)
        Me.ModeleTextBox.TabIndex = 18
        '
        'SurfaceTextBox
        '
        Me.SurfaceTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.T_Article_EnteteBindingSource, "surface", True, System.Windows.Forms.DataSourceUpdateMode.OnValidation, Nothing, "N2"))
        Me.SurfaceTextBox.Location = New System.Drawing.Point(87, 25)
        Me.SurfaceTextBox.Name = "SurfaceTextBox"
        Me.SurfaceTextBox.Size = New System.Drawing.Size(104, 20)
        Me.SurfaceTextBox.TabIndex = 20
        '
        'GuindantTextBox
        '
        Me.GuindantTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.T_Article_EnteteBindingSource, "guindant", True))
        Me.GuindantTextBox.Location = New System.Drawing.Point(87, 51)
        Me.GuindantTextBox.Name = "GuindantTextBox"
        Me.GuindantTextBox.Size = New System.Drawing.Size(104, 20)
        Me.GuindantTextBox.TabIndex = 22
        '
        'WishboneTextBox
        '
        Me.WishboneTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.T_Article_EnteteBindingSource, "wishbone", True))
        Me.WishboneTextBox.Location = New System.Drawing.Point(87, 77)
        Me.WishboneTextBox.Name = "WishboneTextBox"
        Me.WishboneTextBox.Size = New System.Drawing.Size(104, 20)
        Me.WishboneTextBox.TabIndex = 24
        '
        'MatTextBox
        '
        Me.MatTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.T_Article_EnteteBindingSource, "Mat", True))
        Me.MatTextBox.Location = New System.Drawing.Point(87, 103)
        Me.MatTextBox.Name = "MatTextBox"
        Me.MatTextBox.Size = New System.Drawing.Size(104, 20)
        Me.MatTextBox.TabIndex = 26
        '
        'LattesTextBox
        '
        Me.LattesTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.T_Article_EnteteBindingSource, "Lattes", True))
        Me.LattesTextBox.Location = New System.Drawing.Point(295, 22)
        Me.LattesTextBox.Name = "LattesTextBox"
        Me.LattesTextBox.Size = New System.Drawing.Size(104, 20)
        Me.LattesTextBox.TabIndex = 28
        '
        'CamTextBox
        '
        Me.CamTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.T_Article_EnteteBindingSource, "Cam", True))
        Me.CamTextBox.Location = New System.Drawing.Point(295, 48)
        Me.CamTextBox.Name = "CamTextBox"
        Me.CamTextBox.Size = New System.Drawing.Size(104, 20)
        Me.CamTextBox.TabIndex = 30
        '
        'LienTextBox
        '
        Me.LienTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.T_Article_EnteteBindingSource, "lien", True))
        Me.LienTextBox.Location = New System.Drawing.Point(87, 97)
        Me.LienTextBox.Name = "LienTextBox"
        Me.LienTextBox.Size = New System.Drawing.Size(104, 20)
        Me.LienTextBox.TabIndex = 36
        '
        'ActiveCheckBox
        '
        Me.ActiveCheckBox.DataBindings.Add(New System.Windows.Forms.Binding("CheckState", Me.T_Article_EnteteBindingSource, "active", True))
        Me.ActiveCheckBox.Location = New System.Drawing.Point(87, 123)
        Me.ActiveCheckBox.Name = "ActiveCheckBox"
        Me.ActiveCheckBox.Size = New System.Drawing.Size(104, 24)
        Me.ActiveCheckBox.TabIndex = 38
        '
        'Photo_modeleTextBox
        '
        Me.Photo_modeleTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.T_Article_EnteteBindingSource, "photo_modele", True))
        Me.Photo_modeleTextBox.Location = New System.Drawing.Point(87, 122)
        Me.Photo_modeleTextBox.Name = "Photo_modeleTextBox"
        Me.Photo_modeleTextBox.Size = New System.Drawing.Size(104, 20)
        Me.Photo_modeleTextBox.TabIndex = 42
        '
        'T_Article_EnteteTableAdapter
        '
        Me.T_Article_EnteteTableAdapter.ClearBeforeFill = True
        '
        'Code_tvaComboBox
        '
        Me.Code_tvaComboBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.T_Article_EnteteBindingSource, "Code_tva", True))
        Me.Code_tvaComboBox.DataBindings.Add(New System.Windows.Forms.Binding("SelectedValue", Me.T_Article_EnteteBindingSource, "Code_tva", True))
        Me.Code_tvaComboBox.DataSource = Me.CodetvaBindingSource
        Me.Code_tvaComboBox.DisplayMember = "taux"
        Me.Code_tvaComboBox.FormattingEnabled = True
        Me.Code_tvaComboBox.Location = New System.Drawing.Point(87, 153)
        Me.Code_tvaComboBox.Name = "Code_tvaComboBox"
        Me.Code_tvaComboBox.Size = New System.Drawing.Size(121, 21)
        Me.Code_tvaComboBox.TabIndex = 43
        Me.Code_tvaComboBox.ValueMember = "taux"
        '
        'CodetvaBindingSource
        '
        Me.CodetvaBindingSource.DataMember = "code_tva"
        Me.CodetvaBindingSource.DataSource = Me.CHINOOSURDataSet
        '
        'GroupBoxGeneral
        '
        Me.GroupBoxGeneral.Controls.Add(AnneeLabel)
        Me.GroupBoxGeneral.Controls.Add(Me.ModeleTextBox)
        Me.GroupBoxGeneral.Controls.Add(Code_tvaLabel1)
        Me.GroupBoxGeneral.Controls.Add(ModeleLabel)
        Me.GroupBoxGeneral.Controls.Add(Me.Code_tvaComboBox)
        Me.GroupBoxGeneral.Controls.Add(Me.MarqueTextBox)
        Me.GroupBoxGeneral.Controls.Add(MarqueLabel)
        Me.GroupBoxGeneral.Controls.Add(Me.AnneeTextBox)
        Me.GroupBoxGeneral.Controls.Add(Me.ActiveCheckBox)
        Me.GroupBoxGeneral.Controls.Add(ActiveLabel)
        Me.GroupBoxGeneral.Controls.Add(Me.LienTextBox)
        Me.GroupBoxGeneral.Controls.Add(LienLabel)
        Me.GroupBoxGeneral.Location = New System.Drawing.Point(12, 39)
        Me.GroupBoxGeneral.Name = "GroupBoxGeneral"
        Me.GroupBoxGeneral.Size = New System.Drawing.Size(279, 185)
        Me.GroupBoxGeneral.TabIndex = 44
        Me.GroupBoxGeneral.TabStop = False
        Me.GroupBoxGeneral.Text = "Info générales"
        '
        'GroupBoxPhotos
        '
        Me.GroupBoxPhotos.Controls.Add(PhotoLabel)
        Me.GroupBoxPhotos.Controls.Add(Me.Photo_modeleTextBox)
        Me.GroupBoxPhotos.Controls.Add(Photo_modeleLabel)
        Me.GroupBoxPhotos.Controls.Add(Me.Photo_promo2TextBox)
        Me.GroupBoxPhotos.Controls.Add(Photo_promo2Label)
        Me.GroupBoxPhotos.Controls.Add(Me.PhotoTextBox)
        Me.GroupBoxPhotos.Controls.Add(Me.Photo_promoTextBox)
        Me.GroupBoxPhotos.Controls.Add(Photo2Label)
        Me.GroupBoxPhotos.Controls.Add(Photo_promoLabel)
        Me.GroupBoxPhotos.Controls.Add(Me.Photo2TextBox)
        Me.GroupBoxPhotos.Location = New System.Drawing.Point(307, 44)
        Me.GroupBoxPhotos.Name = "GroupBoxPhotos"
        Me.GroupBoxPhotos.Size = New System.Drawing.Size(234, 180)
        Me.GroupBoxPhotos.TabIndex = 45
        Me.GroupBoxPhotos.TabStop = False
        Me.GroupBoxPhotos.Text = "Photos"
        '
        'GroupBoxTechnique
        '
        Me.GroupBoxTechnique.Controls.Add(ProgrammeLabel)
        Me.GroupBoxTechnique.Controls.Add(Me.ProgrammeComboBox)
        Me.GroupBoxTechnique.Controls.Add(SurfaceLabel)
        Me.GroupBoxTechnique.Controls.Add(Me.CamTextBox)
        Me.GroupBoxTechnique.Controls.Add(Me.SurfaceTextBox)
        Me.GroupBoxTechnique.Controls.Add(CamLabel)
        Me.GroupBoxTechnique.Controls.Add(GuindantLabel)
        Me.GroupBoxTechnique.Controls.Add(Me.LattesTextBox)
        Me.GroupBoxTechnique.Controls.Add(Me.GuindantTextBox)
        Me.GroupBoxTechnique.Controls.Add(LattesLabel)
        Me.GroupBoxTechnique.Controls.Add(WishboneLabel)
        Me.GroupBoxTechnique.Controls.Add(Me.MatTextBox)
        Me.GroupBoxTechnique.Controls.Add(Me.WishboneTextBox)
        Me.GroupBoxTechnique.Controls.Add(MatLabel)
        Me.GroupBoxTechnique.Location = New System.Drawing.Point(12, 363)
        Me.GroupBoxTechnique.Name = "GroupBoxTechnique"
        Me.GroupBoxTechnique.Size = New System.Drawing.Size(529, 141)
        Me.GroupBoxTechnique.TabIndex = 46
        Me.GroupBoxTechnique.TabStop = False
        Me.GroupBoxTechnique.Text = "Infos techniques"
        '
        'ProgrammeComboBox
        '
        Me.ProgrammeComboBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.T_Article_EnteteBindingSource, "programme", True))
        Me.ProgrammeComboBox.DataBindings.Add(New System.Windows.Forms.Binding("SelectedValue", Me.T_Article_EnteteBindingSource, "programme", True))
        Me.ProgrammeComboBox.DataSource = Me.VprogrammeBindingSource
        Me.ProgrammeComboBox.DisplayMember = "programme"
        Me.ProgrammeComboBox.FormattingEnabled = True
        Me.ProgrammeComboBox.Location = New System.Drawing.Point(295, 74)
        Me.ProgrammeComboBox.Name = "ProgrammeComboBox"
        Me.ProgrammeComboBox.Size = New System.Drawing.Size(121, 21)
        Me.ProgrammeComboBox.TabIndex = 31
        Me.ProgrammeComboBox.ValueMember = "programme"
        '
        'VprogrammeBindingSource
        '
        Me.VprogrammeBindingSource.DataMember = "V_programme"
        Me.VprogrammeBindingSource.DataSource = Me.CHINOOSURDataSet
        '
        'T_Article_DetailBindingSource
        '
        Me.T_Article_DetailBindingSource.DataMember = "T_Article_Entete_T_Article_Detail"
        Me.T_Article_DetailBindingSource.DataSource = Me.T_Article_EnteteBindingSource
        '
        'T_Article_DetailTableAdapter
        '
        Me.T_Article_DetailTableAdapter.ClearBeforeFill = True
        '
        'T_Article_DetailDataGridView
        '
        Me.T_Article_DetailDataGridView.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.T_Article_DetailDataGridView.AutoGenerateColumns = False
        Me.T_Article_DetailDataGridView.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewTextBoxColumn1, Me.DataGridViewTextBoxColumn2, Me.DataGridViewTextBoxColumn3, Me.DataGridViewTextBoxColumn4, Me.DataGridViewTextBoxColumn5, Me.DataGridViewCheckBoxColumn1, Me.DataGridViewCheckBoxColumn2, Me.DataGridViewTextBoxColumn6, Me.DataGridViewTextBoxColumn7, Me.DataGridViewCheckBoxColumn3, Me.DataGridViewCheckBoxColumn4, Me.DataGridViewCheckBoxColumn5, Me.DataGridViewTextBoxColumn8, Me.DataGridViewTextBoxColumn9, Me.DataGridViewCheckBoxColumn6, Me.DataGridViewTextBoxColumn10, Me.DataGridViewTextBoxColumn11, Me.DataGridViewImageColumn1})
        Me.T_Article_DetailDataGridView.DataSource = Me.T_Article_DetailBindingSource
        Me.T_Article_DetailDataGridView.Location = New System.Drawing.Point(12, 510)
        Me.T_Article_DetailDataGridView.Name = "T_Article_DetailDataGridView"
        Me.T_Article_DetailDataGridView.Size = New System.Drawing.Size(532, 282)
        Me.T_Article_DetailDataGridView.TabIndex = 46
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.DataPropertyName = "id"
        Me.DataGridViewTextBoxColumn1.HeaderText = "id"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.ReadOnly = True
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.DataPropertyName = "id_article_entete"
        Me.DataGridViewTextBoxColumn2.HeaderText = "id_article_entete"
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        '
        'DataGridViewTextBoxColumn3
        '
        Me.DataGridViewTextBoxColumn3.DataPropertyName = "prix"
        Me.DataGridViewTextBoxColumn3.HeaderText = "prix"
        Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
        '
        'DataGridViewTextBoxColumn4
        '
        Me.DataGridViewTextBoxColumn4.DataPropertyName = "stock"
        Me.DataGridViewTextBoxColumn4.HeaderText = "stock"
        Me.DataGridViewTextBoxColumn4.Name = "DataGridViewTextBoxColumn4"
        '
        'DataGridViewTextBoxColumn5
        '
        Me.DataGridViewTextBoxColumn5.DataPropertyName = "ref_chinook"
        Me.DataGridViewTextBoxColumn5.HeaderText = "ref_chinook"
        Me.DataGridViewTextBoxColumn5.Name = "DataGridViewTextBoxColumn5"
        '
        'DataGridViewCheckBoxColumn1
        '
        Me.DataGridViewCheckBoxColumn1.DataPropertyName = "promo"
        Me.DataGridViewCheckBoxColumn1.HeaderText = "promo"
        Me.DataGridViewCheckBoxColumn1.Name = "DataGridViewCheckBoxColumn1"
        '
        'DataGridViewCheckBoxColumn2
        '
        Me.DataGridViewCheckBoxColumn2.DataPropertyName = "precommande"
        Me.DataGridViewCheckBoxColumn2.HeaderText = "precommande"
        Me.DataGridViewCheckBoxColumn2.Name = "DataGridViewCheckBoxColumn2"
        '
        'DataGridViewTextBoxColumn6
        '
        Me.DataGridViewTextBoxColumn6.DataPropertyName = "description_panier"
        Me.DataGridViewTextBoxColumn6.HeaderText = "description_panier"
        Me.DataGridViewTextBoxColumn6.Name = "DataGridViewTextBoxColumn6"
        '
        'DataGridViewTextBoxColumn7
        '
        Me.DataGridViewTextBoxColumn7.DataPropertyName = "photo_couleur"
        Me.DataGridViewTextBoxColumn7.HeaderText = "photo_couleur"
        Me.DataGridViewTextBoxColumn7.Name = "DataGridViewTextBoxColumn7"
        '
        'DataGridViewCheckBoxColumn3
        '
        Me.DataGridViewCheckBoxColumn3.DataPropertyName = "magasin_on"
        Me.DataGridViewCheckBoxColumn3.HeaderText = "magasin_on"
        Me.DataGridViewCheckBoxColumn3.Name = "DataGridViewCheckBoxColumn3"
        '
        'DataGridViewCheckBoxColumn4
        '
        Me.DataGridViewCheckBoxColumn4.DataPropertyName = "web_on"
        Me.DataGridViewCheckBoxColumn4.HeaderText = "web_on"
        Me.DataGridViewCheckBoxColumn4.Name = "DataGridViewCheckBoxColumn4"
        '
        'DataGridViewCheckBoxColumn5
        '
        Me.DataGridViewCheckBoxColumn5.DataPropertyName = "stock_limite"
        Me.DataGridViewCheckBoxColumn5.HeaderText = "stock_limite"
        Me.DataGridViewCheckBoxColumn5.Name = "DataGridViewCheckBoxColumn5"
        '
        'DataGridViewTextBoxColumn8
        '
        Me.DataGridViewTextBoxColumn8.DataPropertyName = "Code_port"
        Me.DataGridViewTextBoxColumn8.HeaderText = "Code_port"
        Me.DataGridViewTextBoxColumn8.Name = "DataGridViewTextBoxColumn8"
        '
        'DataGridViewTextBoxColumn9
        '
        Me.DataGridViewTextBoxColumn9.DataPropertyName = "remise"
        Me.DataGridViewTextBoxColumn9.HeaderText = "remise"
        Me.DataGridViewTextBoxColumn9.Name = "DataGridViewTextBoxColumn9"
        '
        'DataGridViewCheckBoxColumn6
        '
        Me.DataGridViewCheckBoxColumn6.DataPropertyName = "reappro"
        Me.DataGridViewCheckBoxColumn6.HeaderText = "reappro"
        Me.DataGridViewCheckBoxColumn6.Name = "DataGridViewCheckBoxColumn6"
        '
        'DataGridViewTextBoxColumn10
        '
        Me.DataGridViewTextBoxColumn10.DataPropertyName = "couleur"
        Me.DataGridViewTextBoxColumn10.HeaderText = "couleur"
        Me.DataGridViewTextBoxColumn10.Name = "DataGridViewTextBoxColumn10"
        '
        'DataGridViewTextBoxColumn11
        '
        Me.DataGridViewTextBoxColumn11.DataPropertyName = "poids"
        Me.DataGridViewTextBoxColumn11.HeaderText = "poids"
        Me.DataGridViewTextBoxColumn11.Name = "DataGridViewTextBoxColumn11"
        '
        'DataGridViewImageColumn1
        '
        Me.DataGridViewImageColumn1.DataPropertyName = "barcodeimage"
        Me.DataGridViewImageColumn1.HeaderText = "barcodeimage"
        Me.DataGridViewImageColumn1.Name = "DataGridViewImageColumn1"
        '
        'Code_tvaTableAdapter
        '
        Me.Code_tvaTableAdapter.ClearBeforeFill = True
        '
        'V_programmeTableAdapter
        '
        Me.V_programmeTableAdapter.ClearBeforeFill = True
        '
        'GroupBoxDescription
        '
        Me.GroupBoxDescription.Controls.Add(DescriptionLabel)
        Me.GroupBoxDescription.Controls.Add(Me.DescriptionTextBox)
        Me.GroupBoxDescription.Location = New System.Drawing.Point(12, 230)
        Me.GroupBoxDescription.Name = "GroupBoxDescription"
        Me.GroupBoxDescription.Size = New System.Drawing.Size(529, 127)
        Me.GroupBoxDescription.TabIndex = 47
        Me.GroupBoxDescription.TabStop = False
        Me.GroupBoxDescription.Text = "Description"
        '
        'DescriptionTextBox
        '
        Me.DescriptionTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.T_Article_EnteteBindingSource, "description", True))
        Me.DescriptionTextBox.Location = New System.Drawing.Point(87, 13)
        Me.DescriptionTextBox.Multiline = True
        Me.DescriptionTextBox.Name = "DescriptionTextBox"
        Me.DescriptionTextBox.Size = New System.Drawing.Size(436, 104)
        Me.DescriptionTextBox.TabIndex = 36
        '
        'ErrorProviderCli
        '
        Me.ErrorProviderCli.DataMember = ""
        '
        'FormArticle
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(556, 804)
        Me.Controls.Add(Me.GroupBoxDescription)
        Me.Controls.Add(Me.T_Article_DetailDataGridView)
        Me.Controls.Add(Me.GroupBoxTechnique)
        Me.Controls.Add(Me.GroupBoxPhotos)
        Me.Controls.Add(Me.GroupBoxGeneral)
        Me.Controls.Add(Me.T_Article_EnteteBindingNavigator)
        Me.Name = "FormArticle"
        Me.Text = "FormArticle"
        CType(Me.T_Article_EnteteBindingNavigator, System.ComponentModel.ISupportInitialize).EndInit()
        Me.T_Article_EnteteBindingNavigator.ResumeLayout(False)
        Me.T_Article_EnteteBindingNavigator.PerformLayout()
        CType(Me.T_Article_EnteteBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CHINOOSURDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CodetvaBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBoxGeneral.ResumeLayout(False)
        Me.GroupBoxGeneral.PerformLayout()
        Me.GroupBoxPhotos.ResumeLayout(False)
        Me.GroupBoxPhotos.PerformLayout()
        Me.GroupBoxTechnique.ResumeLayout(False)
        Me.GroupBoxTechnique.PerformLayout()
        CType(Me.VprogrammeBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.T_Article_DetailBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.T_Article_DetailDataGridView, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBoxDescription.ResumeLayout(False)
        Me.GroupBoxDescription.PerformLayout()
        CType(Me.ErrorProviderCli, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents CHINOOSURDataSet As CLI.CHINOOSURDataSet
    Friend WithEvents T_Article_EnteteBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents T_Article_EnteteTableAdapter As CLI.CHINOOSURDataSetTableAdapters.T_Article_EnteteTableAdapter
    Friend WithEvents T_Article_EnteteBindingNavigator As System.Windows.Forms.BindingNavigator
    Friend WithEvents BindingNavigatorAddNewItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents BindingNavigatorCountItem As System.Windows.Forms.ToolStripLabel
    Friend WithEvents BindingNavigatorDeleteItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents BindingNavigatorMoveFirstItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents BindingNavigatorMovePreviousItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents BindingNavigatorSeparator As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents BindingNavigatorPositionItem As System.Windows.Forms.ToolStripTextBox
    Friend WithEvents BindingNavigatorSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents BindingNavigatorMoveNextItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents BindingNavigatorMoveLastItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents BindingNavigatorSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents T_Article_EnteteBindingNavigatorSaveItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents PhotoTextBox As System.Windows.Forms.TextBox
    Friend WithEvents Photo2TextBox As System.Windows.Forms.TextBox
    Friend WithEvents Photo_promoTextBox As System.Windows.Forms.TextBox
    Friend WithEvents Photo_promo2TextBox As System.Windows.Forms.TextBox
    Friend WithEvents AnneeTextBox As System.Windows.Forms.TextBox
    Friend WithEvents MarqueTextBox As System.Windows.Forms.TextBox
    Friend WithEvents ModeleTextBox As System.Windows.Forms.TextBox
    Friend WithEvents SurfaceTextBox As System.Windows.Forms.TextBox
    Friend WithEvents GuindantTextBox As System.Windows.Forms.TextBox
    Friend WithEvents WishboneTextBox As System.Windows.Forms.TextBox
    Friend WithEvents MatTextBox As System.Windows.Forms.TextBox
    Friend WithEvents LattesTextBox As System.Windows.Forms.TextBox
    Friend WithEvents CamTextBox As System.Windows.Forms.TextBox
    Friend WithEvents LienTextBox As System.Windows.Forms.TextBox
    Friend WithEvents ActiveCheckBox As System.Windows.Forms.CheckBox
    Friend WithEvents Photo_modeleTextBox As System.Windows.Forms.TextBox
    Friend WithEvents Code_tvaComboBox As System.Windows.Forms.ComboBox
    Friend WithEvents GroupBoxGeneral As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBoxPhotos As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBoxTechnique As System.Windows.Forms.GroupBox
    Friend WithEvents T_Article_DetailBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents T_Article_DetailTableAdapter As CLI.CHINOOSURDataSetTableAdapters.T_Article_DetailTableAdapter
    Friend WithEvents T_Article_DetailDataGridView As System.Windows.Forms.DataGridView
    Friend WithEvents DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn5 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewCheckBoxColumn1 As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents DataGridViewCheckBoxColumn2 As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn6 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn7 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewCheckBoxColumn3 As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents DataGridViewCheckBoxColumn4 As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents DataGridViewCheckBoxColumn5 As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn8 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn9 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewCheckBoxColumn6 As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn10 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn11 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewImageColumn1 As System.Windows.Forms.DataGridViewImageColumn
    Friend WithEvents CodetvaBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents Code_tvaTableAdapter As CLI.CHINOOSURDataSetTableAdapters.code_tvaTableAdapter
    Friend WithEvents ProgrammeComboBox As System.Windows.Forms.ComboBox
    Friend WithEvents VprogrammeBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents V_programmeTableAdapter As CLI.CHINOOSURDataSetTableAdapters.V_programmeTableAdapter
    Friend WithEvents GroupBoxDescription As System.Windows.Forms.GroupBox
    Friend WithEvents DescriptionTextBox As System.Windows.Forms.TextBox
    Friend WithEvents ErrorProviderCli As System.Windows.Forms.ErrorProvider
End Class
