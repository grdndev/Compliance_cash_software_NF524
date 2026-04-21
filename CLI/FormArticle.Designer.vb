<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormArticle
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
        Dim ID_t_sousfamilleLabel As System.Windows.Forms.Label
        Dim AnneeLabel As System.Windows.Forms.Label
        Dim MarqueLabel As System.Windows.Forms.Label
        Dim ModeleLabel As System.Windows.Forms.Label
        Dim DescriptionLabel As System.Windows.Forms.Label
        Dim ID_t_article_detailLabel As System.Windows.Forms.Label
        Dim ID_t_article_enteteLabel As System.Windows.Forms.Label
        Dim SurfaceLabel As System.Windows.Forms.Label
        Dim GuindantLabel As System.Windows.Forms.Label
        Dim WishboneLabel As System.Windows.Forms.Label
        Dim MatLabel As System.Windows.Forms.Label
        Dim LattesLabel As System.Windows.Forms.Label
        Dim CamLabel As System.Windows.Forms.Label
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormArticle))
        Dim ID_t_article_versionLabel As System.Windows.Forms.Label
        Dim ID_t_article_detailLabel1 As System.Windows.Forms.Label
        Dim Ref_chinookLabel As System.Windows.Forms.Label
        Dim PrixLabel As System.Windows.Forms.Label
        Dim Prix_fournisseurLabel As System.Windows.Forms.Label
        Dim RemiseLabel As System.Windows.Forms.Label
        Dim StockLabel As System.Windows.Forms.Label
        Dim PoidsLabel As System.Windows.Forms.Label
        Dim LibelleLabel As System.Windows.Forms.Label
        Dim Description_panierLabel As System.Windows.Forms.Label
        Dim Stock_limiteLabel As System.Windows.Forms.Label
        Dim ReapproLabel As System.Windows.Forms.Label
        Dim PrecommandeLabel As System.Windows.Forms.Label
        Dim Web_onLabel As System.Windows.Forms.Label
        Dim Magasin_onLabel As System.Windows.Forms.Label
        Dim ID_t_article_enteteLabel1 As System.Windows.Forms.Label
        Me.TabControl1 = New System.Windows.Forms.TabControl
        Me.TabPageInfosGenerales = New System.Windows.Forms.TabPage
        Me.TabPageInfosTechniques = New System.Windows.Forms.TabPage
        Me.CLIDataSet = New CLI.CLIDataSet
        Me.T_Article_EnteteBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.T_Article_EnteteTableAdapter = New CLI.CLIDataSetTableAdapters.T_Article_EnteteTableAdapter
        Me.T_Article_EnteteBindingNavigator = New System.Windows.Forms.BindingNavigator(Me.components)
        Me.BindingNavigatorMoveFirstItem = New System.Windows.Forms.ToolStripButton
        Me.BindingNavigatorMovePreviousItem = New System.Windows.Forms.ToolStripButton
        Me.BindingNavigatorSeparator = New System.Windows.Forms.ToolStripSeparator
        Me.BindingNavigatorPositionItem = New System.Windows.Forms.ToolStripTextBox
        Me.BindingNavigatorCountItem = New System.Windows.Forms.ToolStripLabel
        Me.BindingNavigatorSeparator1 = New System.Windows.Forms.ToolStripSeparator
        Me.BindingNavigatorMoveNextItem = New System.Windows.Forms.ToolStripButton
        Me.BindingNavigatorMoveLastItem = New System.Windows.Forms.ToolStripButton
        Me.BindingNavigatorSeparator2 = New System.Windows.Forms.ToolStripSeparator
        Me.BindingNavigatorAddNewItem = New System.Windows.Forms.ToolStripButton
        Me.BindingNavigatorDeleteItem = New System.Windows.Forms.ToolStripButton
        Me.T_Article_EnteteBindingNavigatorSaveItem = New System.Windows.Forms.ToolStripButton
        Me.ID_t_sousfamilleComboBox = New System.Windows.Forms.ComboBox
        Me.AnneeTextBox = New System.Windows.Forms.TextBox
        Me.MarqueTextBox = New System.Windows.Forms.TextBox
        Me.ModeleTextBox = New System.Windows.Forms.TextBox
        Me.DescriptionTextBox = New System.Windows.Forms.TextBox
        Me.T_Article_DetailBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.T_Article_DetailTableAdapter = New CLI.CLIDataSetTableAdapters.T_Article_DetailTableAdapter
        Me.ID_t_article_detailTextBox = New System.Windows.Forms.TextBox
        Me.ID_t_article_enteteTextBox = New System.Windows.Forms.TextBox
        Me.SurfaceTextBox = New System.Windows.Forms.TextBox
        Me.GuindantTextBox = New System.Windows.Forms.TextBox
        Me.WishboneTextBox = New System.Windows.Forms.TextBox
        Me.MatTextBox = New System.Windows.Forms.TextBox
        Me.LattesTextBox = New System.Windows.Forms.TextBox
        Me.CamTextBox = New System.Windows.Forms.TextBox
        Me.T_Article_versionBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.T_Article_versionTableAdapter = New CLI.CLIDataSetTableAdapters.T_Article_versionTableAdapter
        Me.BindingNavigator1 = New System.Windows.Forms.BindingNavigator(Me.components)
        Me.BindingNavigatorMoveFirstItem1 = New System.Windows.Forms.ToolStripButton
        Me.BindingNavigatorMovePreviousItem1 = New System.Windows.Forms.ToolStripButton
        Me.BindingNavigatorSeparator3 = New System.Windows.Forms.ToolStripSeparator
        Me.BindingNavigatorPositionItem1 = New System.Windows.Forms.ToolStripTextBox
        Me.BindingNavigatorCountItem1 = New System.Windows.Forms.ToolStripLabel
        Me.BindingNavigatorSeparator4 = New System.Windows.Forms.ToolStripSeparator
        Me.BindingNavigatorMoveNextItem1 = New System.Windows.Forms.ToolStripButton
        Me.BindingNavigatorMoveLastItem1 = New System.Windows.Forms.ToolStripButton
        Me.BindingNavigatorSeparator5 = New System.Windows.Forms.ToolStripSeparator
        Me.BindingNavigatorAddNewItem1 = New System.Windows.Forms.ToolStripButton
        Me.BindingNavigatorDeleteItem1 = New System.Windows.Forms.ToolStripButton
        Me.TabPageVersions = New System.Windows.Forms.TabPage
        Me.ID_t_article_versionTextBox = New System.Windows.Forms.TextBox
        Me.ID_t_article_detailTextBox1 = New System.Windows.Forms.TextBox
        Me.Ref_chinookTextBox = New System.Windows.Forms.TextBox
        Me.PrixTextBox = New System.Windows.Forms.TextBox
        Me.Prix_fournisseurTextBox = New System.Windows.Forms.TextBox
        Me.RemiseTextBox = New System.Windows.Forms.TextBox
        Me.StockTextBox = New System.Windows.Forms.TextBox
        Me.PoidsTextBox = New System.Windows.Forms.TextBox
        Me.LibelleTextBox = New System.Windows.Forms.TextBox
        Me.Description_panierTextBox = New System.Windows.Forms.TextBox
        Me.Stock_limiteCheckBox = New System.Windows.Forms.CheckBox
        Me.ReapproCheckBox = New System.Windows.Forms.CheckBox
        Me.PrecommandeCheckBox = New System.Windows.Forms.CheckBox
        Me.Web_onCheckBox = New System.Windows.Forms.CheckBox
        Me.Magasin_onCheckBox = New System.Windows.Forms.CheckBox
        Me.BindingNavigator2 = New System.Windows.Forms.BindingNavigator(Me.components)
        Me.ToolStripButton1 = New System.Windows.Forms.ToolStripButton
        Me.ToolStripLabel1 = New System.Windows.Forms.ToolStripLabel
        Me.ToolStripButton2 = New System.Windows.Forms.ToolStripButton
        Me.ToolStripButton3 = New System.Windows.Forms.ToolStripButton
        Me.ToolStripButton4 = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator
        Me.ToolStripTextBox1 = New System.Windows.Forms.ToolStripTextBox
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator
        Me.ToolStripButton5 = New System.Windows.Forms.ToolStripButton
        Me.ToolStripButton6 = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator
        Me.ID_t_article_enteteTextBox1 = New System.Windows.Forms.TextBox
        Me.T_Article_DetailDataGridView = New System.Windows.Forms.DataGridView
        Me.DataGridViewTextBoxColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn4 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn5 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn6 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn7 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn8 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.T_Article_versionDataGridView = New System.Windows.Forms.DataGridView
        Me.DataGridViewTextBoxColumn9 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn10 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn11 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn12 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn13 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn14 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn15 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn16 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewCheckBoxColumn1 = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Me.DataGridViewCheckBoxColumn2 = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Me.DataGridViewCheckBoxColumn3 = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Me.DataGridViewCheckBoxColumn4 = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Me.DataGridViewCheckBoxColumn5 = New System.Windows.Forms.DataGridViewCheckBoxColumn
        ID_t_sousfamilleLabel = New System.Windows.Forms.Label
        AnneeLabel = New System.Windows.Forms.Label
        MarqueLabel = New System.Windows.Forms.Label
        ModeleLabel = New System.Windows.Forms.Label
        DescriptionLabel = New System.Windows.Forms.Label
        ID_t_article_detailLabel = New System.Windows.Forms.Label
        ID_t_article_enteteLabel = New System.Windows.Forms.Label
        SurfaceLabel = New System.Windows.Forms.Label
        GuindantLabel = New System.Windows.Forms.Label
        WishboneLabel = New System.Windows.Forms.Label
        MatLabel = New System.Windows.Forms.Label
        LattesLabel = New System.Windows.Forms.Label
        CamLabel = New System.Windows.Forms.Label
        ID_t_article_versionLabel = New System.Windows.Forms.Label
        ID_t_article_detailLabel1 = New System.Windows.Forms.Label
        Ref_chinookLabel = New System.Windows.Forms.Label
        PrixLabel = New System.Windows.Forms.Label
        Prix_fournisseurLabel = New System.Windows.Forms.Label
        RemiseLabel = New System.Windows.Forms.Label
        StockLabel = New System.Windows.Forms.Label
        PoidsLabel = New System.Windows.Forms.Label
        LibelleLabel = New System.Windows.Forms.Label
        Description_panierLabel = New System.Windows.Forms.Label
        Stock_limiteLabel = New System.Windows.Forms.Label
        ReapproLabel = New System.Windows.Forms.Label
        PrecommandeLabel = New System.Windows.Forms.Label
        Web_onLabel = New System.Windows.Forms.Label
        Magasin_onLabel = New System.Windows.Forms.Label
        ID_t_article_enteteLabel1 = New System.Windows.Forms.Label
        Me.TabControl1.SuspendLayout()
        Me.TabPageInfosGenerales.SuspendLayout()
        Me.TabPageInfosTechniques.SuspendLayout()
        CType(Me.CLIDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.T_Article_EnteteBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.T_Article_EnteteBindingNavigator, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.T_Article_EnteteBindingNavigator.SuspendLayout()
        CType(Me.T_Article_DetailBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.T_Article_versionBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BindingNavigator1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.BindingNavigator1.SuspendLayout()
        Me.TabPageVersions.SuspendLayout()
        CType(Me.BindingNavigator2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.BindingNavigator2.SuspendLayout()
        CType(Me.T_Article_DetailDataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.T_Article_versionDataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPageInfosGenerales)
        Me.TabControl1.Controls.Add(Me.TabPageInfosTechniques)
        Me.TabControl1.Controls.Add(Me.TabPageVersions)
        Me.TabControl1.Location = New System.Drawing.Point(0, 28)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(983, 491)
        Me.TabControl1.TabIndex = 0
        '
        'TabPageInfosGenerales
        '
        Me.TabPageInfosGenerales.AutoScroll = True
        Me.TabPageInfosGenerales.Controls.Add(Me.T_Article_DetailDataGridView)
        Me.TabPageInfosGenerales.Controls.Add(ID_t_article_enteteLabel1)
        Me.TabPageInfosGenerales.Controls.Add(Me.ID_t_article_enteteTextBox1)
        Me.TabPageInfosGenerales.Controls.Add(DescriptionLabel)
        Me.TabPageInfosGenerales.Controls.Add(Me.DescriptionTextBox)
        Me.TabPageInfosGenerales.Controls.Add(ModeleLabel)
        Me.TabPageInfosGenerales.Controls.Add(Me.ModeleTextBox)
        Me.TabPageInfosGenerales.Controls.Add(MarqueLabel)
        Me.TabPageInfosGenerales.Controls.Add(Me.MarqueTextBox)
        Me.TabPageInfosGenerales.Controls.Add(AnneeLabel)
        Me.TabPageInfosGenerales.Controls.Add(Me.AnneeTextBox)
        Me.TabPageInfosGenerales.Controls.Add(ID_t_sousfamilleLabel)
        Me.TabPageInfosGenerales.Controls.Add(Me.ID_t_sousfamilleComboBox)
        Me.TabPageInfosGenerales.Location = New System.Drawing.Point(4, 22)
        Me.TabPageInfosGenerales.Name = "TabPageInfosGenerales"
        Me.TabPageInfosGenerales.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPageInfosGenerales.Size = New System.Drawing.Size(975, 465)
        Me.TabPageInfosGenerales.TabIndex = 0
        Me.TabPageInfosGenerales.Text = "Infos générales"
        Me.TabPageInfosGenerales.UseVisualStyleBackColor = True
        '
        'TabPageInfosTechniques
        '
        Me.TabPageInfosTechniques.AutoScroll = True
        Me.TabPageInfosTechniques.Controls.Add(Me.T_Article_versionDataGridView)
        Me.TabPageInfosTechniques.Controls.Add(Me.BindingNavigator1)
        Me.TabPageInfosTechniques.Controls.Add(ID_t_article_detailLabel)
        Me.TabPageInfosTechniques.Controls.Add(Me.ID_t_article_detailTextBox)
        Me.TabPageInfosTechniques.Controls.Add(ID_t_article_enteteLabel)
        Me.TabPageInfosTechniques.Controls.Add(Me.ID_t_article_enteteTextBox)
        Me.TabPageInfosTechniques.Controls.Add(SurfaceLabel)
        Me.TabPageInfosTechniques.Controls.Add(Me.SurfaceTextBox)
        Me.TabPageInfosTechniques.Controls.Add(GuindantLabel)
        Me.TabPageInfosTechniques.Controls.Add(Me.GuindantTextBox)
        Me.TabPageInfosTechniques.Controls.Add(WishboneLabel)
        Me.TabPageInfosTechniques.Controls.Add(Me.WishboneTextBox)
        Me.TabPageInfosTechniques.Controls.Add(MatLabel)
        Me.TabPageInfosTechniques.Controls.Add(Me.MatTextBox)
        Me.TabPageInfosTechniques.Controls.Add(LattesLabel)
        Me.TabPageInfosTechniques.Controls.Add(Me.LattesTextBox)
        Me.TabPageInfosTechniques.Controls.Add(CamLabel)
        Me.TabPageInfosTechniques.Controls.Add(Me.CamTextBox)
        Me.TabPageInfosTechniques.Location = New System.Drawing.Point(4, 22)
        Me.TabPageInfosTechniques.Name = "TabPageInfosTechniques"
        Me.TabPageInfosTechniques.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPageInfosTechniques.Size = New System.Drawing.Size(975, 465)
        Me.TabPageInfosTechniques.TabIndex = 1
        Me.TabPageInfosTechniques.Text = "Infos techniques"
        Me.TabPageInfosTechniques.UseVisualStyleBackColor = True
        '
        'CLIDataSet
        '
        Me.CLIDataSet.DataSetName = "CLIDataSet"
        Me.CLIDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'T_Article_EnteteBindingSource
        '
        Me.T_Article_EnteteBindingSource.DataMember = "T_Article_Entete"
        Me.T_Article_EnteteBindingSource.DataSource = Me.CLIDataSet
        '
        'T_Article_EnteteTableAdapter
        '
        Me.T_Article_EnteteTableAdapter.ClearBeforeFill = True
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
        Me.T_Article_EnteteBindingNavigator.Size = New System.Drawing.Size(995, 25)
        Me.T_Article_EnteteBindingNavigator.TabIndex = 1
        Me.T_Article_EnteteBindingNavigator.Text = "BindingNavigator1"
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
        'BindingNavigatorCountItem
        '
        Me.BindingNavigatorCountItem.Name = "BindingNavigatorCountItem"
        Me.BindingNavigatorCountItem.Size = New System.Drawing.Size(38, 22)
        Me.BindingNavigatorCountItem.Text = "de {0}"
        Me.BindingNavigatorCountItem.ToolTipText = "Nombre total d'éléments"
        '
        'BindingNavigatorSeparator1
        '
        Me.BindingNavigatorSeparator1.Name = "BindingNavigatorSeparator"
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
        Me.BindingNavigatorSeparator2.Name = "BindingNavigatorSeparator"
        Me.BindingNavigatorSeparator2.Size = New System.Drawing.Size(6, 25)
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
        'BindingNavigatorDeleteItem
        '
        Me.BindingNavigatorDeleteItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BindingNavigatorDeleteItem.Image = CType(resources.GetObject("BindingNavigatorDeleteItem.Image"), System.Drawing.Image)
        Me.BindingNavigatorDeleteItem.Name = "BindingNavigatorDeleteItem"
        Me.BindingNavigatorDeleteItem.RightToLeftAutoMirrorImage = True
        Me.BindingNavigatorDeleteItem.Size = New System.Drawing.Size(23, 22)
        Me.BindingNavigatorDeleteItem.Text = "Supprimer"
        '
        'T_Article_EnteteBindingNavigatorSaveItem
        '
        Me.T_Article_EnteteBindingNavigatorSaveItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.T_Article_EnteteBindingNavigatorSaveItem.Image = CType(resources.GetObject("T_Article_EnteteBindingNavigatorSaveItem.Image"), System.Drawing.Image)
        Me.T_Article_EnteteBindingNavigatorSaveItem.Name = "T_Article_EnteteBindingNavigatorSaveItem"
        Me.T_Article_EnteteBindingNavigatorSaveItem.Size = New System.Drawing.Size(23, 22)
        Me.T_Article_EnteteBindingNavigatorSaveItem.Text = "Enregistrer les données"
        '
        'ID_t_sousfamilleLabel
        '
        ID_t_sousfamilleLabel.AutoSize = True
        ID_t_sousfamilleLabel.Location = New System.Drawing.Point(18, 47)
        ID_t_sousfamilleLabel.Name = "ID_t_sousfamilleLabel"
        ID_t_sousfamilleLabel.Size = New System.Drawing.Size(81, 13)
        ID_t_sousfamilleLabel.TabIndex = 0
        ID_t_sousfamilleLabel.Text = "ID t sousfamille:"
        '
        'ID_t_sousfamilleComboBox
        '
        Me.ID_t_sousfamilleComboBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.T_Article_EnteteBindingSource, "ID_t_sousfamille", True))
        Me.ID_t_sousfamilleComboBox.FormattingEnabled = True
        Me.ID_t_sousfamilleComboBox.Location = New System.Drawing.Point(105, 44)
        Me.ID_t_sousfamilleComboBox.Name = "ID_t_sousfamilleComboBox"
        Me.ID_t_sousfamilleComboBox.Size = New System.Drawing.Size(121, 21)
        Me.ID_t_sousfamilleComboBox.TabIndex = 1
        '
        'AnneeLabel
        '
        AnneeLabel.AutoSize = True
        AnneeLabel.Location = New System.Drawing.Point(59, 74)
        AnneeLabel.Name = "AnneeLabel"
        AnneeLabel.Size = New System.Drawing.Size(40, 13)
        AnneeLabel.TabIndex = 2
        AnneeLabel.Text = "annee:"
        '
        'AnneeTextBox
        '
        Me.AnneeTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.T_Article_EnteteBindingSource, "annee", True))
        Me.AnneeTextBox.Location = New System.Drawing.Point(105, 71)
        Me.AnneeTextBox.Name = "AnneeTextBox"
        Me.AnneeTextBox.Size = New System.Drawing.Size(100, 20)
        Me.AnneeTextBox.TabIndex = 3
        '
        'MarqueLabel
        '
        MarqueLabel.AutoSize = True
        MarqueLabel.Location = New System.Drawing.Point(54, 100)
        MarqueLabel.Name = "MarqueLabel"
        MarqueLabel.Size = New System.Drawing.Size(45, 13)
        MarqueLabel.TabIndex = 4
        MarqueLabel.Text = "marque:"
        '
        'MarqueTextBox
        '
        Me.MarqueTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.T_Article_EnteteBindingSource, "marque", True))
        Me.MarqueTextBox.Location = New System.Drawing.Point(105, 97)
        Me.MarqueTextBox.Name = "MarqueTextBox"
        Me.MarqueTextBox.Size = New System.Drawing.Size(100, 20)
        Me.MarqueTextBox.TabIndex = 5
        '
        'ModeleLabel
        '
        ModeleLabel.AutoSize = True
        ModeleLabel.Location = New System.Drawing.Point(55, 126)
        ModeleLabel.Name = "ModeleLabel"
        ModeleLabel.Size = New System.Drawing.Size(44, 13)
        ModeleLabel.TabIndex = 6
        ModeleLabel.Text = "modele:"
        '
        'ModeleTextBox
        '
        Me.ModeleTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.T_Article_EnteteBindingSource, "modele", True))
        Me.ModeleTextBox.Location = New System.Drawing.Point(105, 123)
        Me.ModeleTextBox.Name = "ModeleTextBox"
        Me.ModeleTextBox.Size = New System.Drawing.Size(100, 20)
        Me.ModeleTextBox.TabIndex = 7
        '
        'DescriptionLabel
        '
        DescriptionLabel.AutoSize = True
        DescriptionLabel.Location = New System.Drawing.Point(38, 152)
        DescriptionLabel.Name = "DescriptionLabel"
        DescriptionLabel.Size = New System.Drawing.Size(61, 13)
        DescriptionLabel.TabIndex = 8
        DescriptionLabel.Text = "description:"
        '
        'DescriptionTextBox
        '
        Me.DescriptionTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.T_Article_EnteteBindingSource, "description", True))
        Me.DescriptionTextBox.Location = New System.Drawing.Point(105, 149)
        Me.DescriptionTextBox.Multiline = True
        Me.DescriptionTextBox.Name = "DescriptionTextBox"
        Me.DescriptionTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.DescriptionTextBox.Size = New System.Drawing.Size(656, 114)
        Me.DescriptionTextBox.TabIndex = 9
        '
        'T_Article_DetailBindingSource
        '
        Me.T_Article_DetailBindingSource.DataMember = "FK_T_Article_Detail_T_Article_Entete"
        Me.T_Article_DetailBindingSource.DataSource = Me.T_Article_EnteteBindingSource
        '
        'T_Article_DetailTableAdapter
        '
        Me.T_Article_DetailTableAdapter.ClearBeforeFill = True
        '
        'ID_t_article_detailLabel
        '
        ID_t_article_detailLabel.AutoSize = True
        ID_t_article_detailLabel.Location = New System.Drawing.Point(8, 39)
        ID_t_article_detailLabel.Name = "ID_t_article_detailLabel"
        ID_t_article_detailLabel.Size = New System.Drawing.Size(86, 13)
        ID_t_article_detailLabel.TabIndex = 0
        ID_t_article_detailLabel.Text = "ID t article detail:"
        '
        'ID_t_article_detailTextBox
        '
        Me.ID_t_article_detailTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.T_Article_DetailBindingSource, "ID_t_article_detail", True))
        Me.ID_t_article_detailTextBox.Location = New System.Drawing.Point(105, 36)
        Me.ID_t_article_detailTextBox.Name = "ID_t_article_detailTextBox"
        Me.ID_t_article_detailTextBox.ReadOnly = True
        Me.ID_t_article_detailTextBox.Size = New System.Drawing.Size(100, 20)
        Me.ID_t_article_detailTextBox.TabIndex = 1
        '
        'ID_t_article_enteteLabel
        '
        ID_t_article_enteteLabel.AutoSize = True
        ID_t_article_enteteLabel.Location = New System.Drawing.Point(8, 65)
        ID_t_article_enteteLabel.Name = "ID_t_article_enteteLabel"
        ID_t_article_enteteLabel.Size = New System.Drawing.Size(91, 13)
        ID_t_article_enteteLabel.TabIndex = 2
        ID_t_article_enteteLabel.Text = "ID t article entete:"
        '
        'ID_t_article_enteteTextBox
        '
        Me.ID_t_article_enteteTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.T_Article_DetailBindingSource, "ID_t_article_entete", True))
        Me.ID_t_article_enteteTextBox.Location = New System.Drawing.Point(105, 62)
        Me.ID_t_article_enteteTextBox.Name = "ID_t_article_enteteTextBox"
        Me.ID_t_article_enteteTextBox.ReadOnly = True
        Me.ID_t_article_enteteTextBox.Size = New System.Drawing.Size(100, 20)
        Me.ID_t_article_enteteTextBox.TabIndex = 3
        '
        'SurfaceLabel
        '
        SurfaceLabel.AutoSize = True
        SurfaceLabel.Location = New System.Drawing.Point(8, 91)
        SurfaceLabel.Name = "SurfaceLabel"
        SurfaceLabel.Size = New System.Drawing.Size(45, 13)
        SurfaceLabel.TabIndex = 4
        SurfaceLabel.Text = "surface:"
        '
        'SurfaceTextBox
        '
        Me.SurfaceTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.T_Article_DetailBindingSource, "surface", True))
        Me.SurfaceTextBox.Location = New System.Drawing.Point(105, 88)
        Me.SurfaceTextBox.Name = "SurfaceTextBox"
        Me.SurfaceTextBox.Size = New System.Drawing.Size(100, 20)
        Me.SurfaceTextBox.TabIndex = 5
        '
        'GuindantLabel
        '
        GuindantLabel.AutoSize = True
        GuindantLabel.Location = New System.Drawing.Point(8, 117)
        GuindantLabel.Name = "GuindantLabel"
        GuindantLabel.Size = New System.Drawing.Size(51, 13)
        GuindantLabel.TabIndex = 6
        GuindantLabel.Text = "guindant:"
        '
        'GuindantTextBox
        '
        Me.GuindantTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.T_Article_DetailBindingSource, "guindant", True))
        Me.GuindantTextBox.Location = New System.Drawing.Point(105, 114)
        Me.GuindantTextBox.Name = "GuindantTextBox"
        Me.GuindantTextBox.Size = New System.Drawing.Size(100, 20)
        Me.GuindantTextBox.TabIndex = 7
        '
        'WishboneLabel
        '
        WishboneLabel.AutoSize = True
        WishboneLabel.Location = New System.Drawing.Point(8, 143)
        WishboneLabel.Name = "WishboneLabel"
        WishboneLabel.Size = New System.Drawing.Size(55, 13)
        WishboneLabel.TabIndex = 8
        WishboneLabel.Text = "wishbone:"
        '
        'WishboneTextBox
        '
        Me.WishboneTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.T_Article_DetailBindingSource, "wishbone", True))
        Me.WishboneTextBox.Location = New System.Drawing.Point(105, 140)
        Me.WishboneTextBox.Name = "WishboneTextBox"
        Me.WishboneTextBox.Size = New System.Drawing.Size(100, 20)
        Me.WishboneTextBox.TabIndex = 9
        '
        'MatLabel
        '
        MatLabel.AutoSize = True
        MatLabel.Location = New System.Drawing.Point(8, 169)
        MatLabel.Name = "MatLabel"
        MatLabel.Size = New System.Drawing.Size(28, 13)
        MatLabel.TabIndex = 10
        MatLabel.Text = "Mat:"
        '
        'MatTextBox
        '
        Me.MatTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.T_Article_DetailBindingSource, "Mat", True))
        Me.MatTextBox.Location = New System.Drawing.Point(105, 166)
        Me.MatTextBox.Name = "MatTextBox"
        Me.MatTextBox.Size = New System.Drawing.Size(100, 20)
        Me.MatTextBox.TabIndex = 11
        '
        'LattesLabel
        '
        LattesLabel.AutoSize = True
        LattesLabel.Location = New System.Drawing.Point(8, 195)
        LattesLabel.Name = "LattesLabel"
        LattesLabel.Size = New System.Drawing.Size(39, 13)
        LattesLabel.TabIndex = 12
        LattesLabel.Text = "Lattes:"
        '
        'LattesTextBox
        '
        Me.LattesTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.T_Article_DetailBindingSource, "Lattes", True))
        Me.LattesTextBox.Location = New System.Drawing.Point(105, 192)
        Me.LattesTextBox.Name = "LattesTextBox"
        Me.LattesTextBox.Size = New System.Drawing.Size(100, 20)
        Me.LattesTextBox.TabIndex = 13
        '
        'CamLabel
        '
        CamLabel.AutoSize = True
        CamLabel.Location = New System.Drawing.Point(8, 221)
        CamLabel.Name = "CamLabel"
        CamLabel.Size = New System.Drawing.Size(31, 13)
        CamLabel.TabIndex = 14
        CamLabel.Text = "Cam:"
        '
        'CamTextBox
        '
        Me.CamTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.T_Article_DetailBindingSource, "Cam", True))
        Me.CamTextBox.Location = New System.Drawing.Point(105, 218)
        Me.CamTextBox.Name = "CamTextBox"
        Me.CamTextBox.Size = New System.Drawing.Size(100, 20)
        Me.CamTextBox.TabIndex = 15
        '
        'T_Article_versionBindingSource
        '
        Me.T_Article_versionBindingSource.DataMember = "FK_T_Article_version_T_Article_Detail"
        Me.T_Article_versionBindingSource.DataSource = Me.T_Article_DetailBindingSource
        '
        'T_Article_versionTableAdapter
        '
        Me.T_Article_versionTableAdapter.ClearBeforeFill = True
        '
        'BindingNavigator1
        '
        Me.BindingNavigator1.AddNewItem = Me.BindingNavigatorAddNewItem1
        Me.BindingNavigator1.BindingSource = Me.T_Article_DetailBindingSource
        Me.BindingNavigator1.CountItem = Me.BindingNavigatorCountItem1
        Me.BindingNavigator1.DeleteItem = Me.BindingNavigatorDeleteItem1
        Me.BindingNavigator1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BindingNavigatorMoveFirstItem1, Me.BindingNavigatorMovePreviousItem1, Me.BindingNavigatorSeparator3, Me.BindingNavigatorPositionItem1, Me.BindingNavigatorCountItem1, Me.BindingNavigatorSeparator4, Me.BindingNavigatorMoveNextItem1, Me.BindingNavigatorMoveLastItem1, Me.BindingNavigatorSeparator5, Me.BindingNavigatorAddNewItem1, Me.BindingNavigatorDeleteItem1})
        Me.BindingNavigator1.Location = New System.Drawing.Point(3, 3)
        Me.BindingNavigator1.MoveFirstItem = Me.BindingNavigatorMoveFirstItem1
        Me.BindingNavigator1.MoveLastItem = Me.BindingNavigatorMoveLastItem1
        Me.BindingNavigator1.MoveNextItem = Me.BindingNavigatorMoveNextItem1
        Me.BindingNavigator1.MovePreviousItem = Me.BindingNavigatorMovePreviousItem1
        Me.BindingNavigator1.Name = "BindingNavigator1"
        Me.BindingNavigator1.PositionItem = Me.BindingNavigatorPositionItem1
        Me.BindingNavigator1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System
        Me.BindingNavigator1.Size = New System.Drawing.Size(952, 25)
        Me.BindingNavigator1.TabIndex = 17
        Me.BindingNavigator1.Text = "BindingNavigator1"
        '
        'BindingNavigatorMoveFirstItem1
        '
        Me.BindingNavigatorMoveFirstItem1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BindingNavigatorMoveFirstItem1.Image = CType(resources.GetObject("BindingNavigatorMoveFirstItem1.Image"), System.Drawing.Image)
        Me.BindingNavigatorMoveFirstItem1.Name = "BindingNavigatorMoveFirstItem"
        Me.BindingNavigatorMoveFirstItem1.RightToLeftAutoMirrorImage = True
        Me.BindingNavigatorMoveFirstItem1.Size = New System.Drawing.Size(23, 22)
        Me.BindingNavigatorMoveFirstItem1.Text = "Placer en premier"
        '
        'BindingNavigatorMovePreviousItem1
        '
        Me.BindingNavigatorMovePreviousItem1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BindingNavigatorMovePreviousItem1.Image = CType(resources.GetObject("BindingNavigatorMovePreviousItem1.Image"), System.Drawing.Image)
        Me.BindingNavigatorMovePreviousItem1.Name = "BindingNavigatorMovePreviousItem"
        Me.BindingNavigatorMovePreviousItem1.RightToLeftAutoMirrorImage = True
        Me.BindingNavigatorMovePreviousItem1.Size = New System.Drawing.Size(23, 22)
        Me.BindingNavigatorMovePreviousItem1.Text = "Déplacer vers le haut"
        '
        'BindingNavigatorSeparator3
        '
        Me.BindingNavigatorSeparator3.Name = "BindingNavigatorSeparator"
        Me.BindingNavigatorSeparator3.Size = New System.Drawing.Size(6, 25)
        '
        'BindingNavigatorPositionItem1
        '
        Me.BindingNavigatorPositionItem1.AccessibleName = "Position"
        Me.BindingNavigatorPositionItem1.AutoSize = False
        Me.BindingNavigatorPositionItem1.Name = "BindingNavigatorPositionItem"
        Me.BindingNavigatorPositionItem1.Size = New System.Drawing.Size(50, 21)
        Me.BindingNavigatorPositionItem1.Text = "0"
        Me.BindingNavigatorPositionItem1.ToolTipText = "Position actuelle"
        '
        'BindingNavigatorCountItem1
        '
        Me.BindingNavigatorCountItem1.Name = "BindingNavigatorCountItem"
        Me.BindingNavigatorCountItem1.Size = New System.Drawing.Size(38, 22)
        Me.BindingNavigatorCountItem1.Text = "de {0}"
        Me.BindingNavigatorCountItem1.ToolTipText = "Nombre total d'éléments"
        '
        'BindingNavigatorSeparator4
        '
        Me.BindingNavigatorSeparator4.Name = "BindingNavigatorSeparator"
        Me.BindingNavigatorSeparator4.Size = New System.Drawing.Size(6, 25)
        '
        'BindingNavigatorMoveNextItem1
        '
        Me.BindingNavigatorMoveNextItem1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BindingNavigatorMoveNextItem1.Image = CType(resources.GetObject("BindingNavigatorMoveNextItem1.Image"), System.Drawing.Image)
        Me.BindingNavigatorMoveNextItem1.Name = "BindingNavigatorMoveNextItem"
        Me.BindingNavigatorMoveNextItem1.RightToLeftAutoMirrorImage = True
        Me.BindingNavigatorMoveNextItem1.Size = New System.Drawing.Size(23, 22)
        Me.BindingNavigatorMoveNextItem1.Text = "Déplacer vers le bas"
        '
        'BindingNavigatorMoveLastItem1
        '
        Me.BindingNavigatorMoveLastItem1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BindingNavigatorMoveLastItem1.Image = CType(resources.GetObject("BindingNavigatorMoveLastItem1.Image"), System.Drawing.Image)
        Me.BindingNavigatorMoveLastItem1.Name = "BindingNavigatorMoveLastItem"
        Me.BindingNavigatorMoveLastItem1.RightToLeftAutoMirrorImage = True
        Me.BindingNavigatorMoveLastItem1.Size = New System.Drawing.Size(23, 22)
        Me.BindingNavigatorMoveLastItem1.Text = "Placer en dernier"
        '
        'BindingNavigatorSeparator5
        '
        Me.BindingNavigatorSeparator5.Name = "BindingNavigatorSeparator"
        Me.BindingNavigatorSeparator5.Size = New System.Drawing.Size(6, 25)
        '
        'BindingNavigatorAddNewItem1
        '
        Me.BindingNavigatorAddNewItem1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BindingNavigatorAddNewItem1.Image = CType(resources.GetObject("BindingNavigatorAddNewItem1.Image"), System.Drawing.Image)
        Me.BindingNavigatorAddNewItem1.Name = "BindingNavigatorAddNewItem"
        Me.BindingNavigatorAddNewItem1.RightToLeftAutoMirrorImage = True
        Me.BindingNavigatorAddNewItem1.Size = New System.Drawing.Size(23, 22)
        Me.BindingNavigatorAddNewItem1.Text = "Ajouter nouveau"
        '
        'BindingNavigatorDeleteItem1
        '
        Me.BindingNavigatorDeleteItem1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BindingNavigatorDeleteItem1.Image = CType(resources.GetObject("BindingNavigatorDeleteItem1.Image"), System.Drawing.Image)
        Me.BindingNavigatorDeleteItem1.Name = "BindingNavigatorDeleteItem"
        Me.BindingNavigatorDeleteItem1.RightToLeftAutoMirrorImage = True
        Me.BindingNavigatorDeleteItem1.Size = New System.Drawing.Size(23, 22)
        Me.BindingNavigatorDeleteItem1.Text = "Supprimer"
        '
        'TabPageVersions
        '
        Me.TabPageVersions.AutoScroll = True
        Me.TabPageVersions.Controls.Add(Me.BindingNavigator2)
        Me.TabPageVersions.Controls.Add(ID_t_article_versionLabel)
        Me.TabPageVersions.Controls.Add(Me.ID_t_article_versionTextBox)
        Me.TabPageVersions.Controls.Add(ID_t_article_detailLabel1)
        Me.TabPageVersions.Controls.Add(Me.ID_t_article_detailTextBox1)
        Me.TabPageVersions.Controls.Add(Ref_chinookLabel)
        Me.TabPageVersions.Controls.Add(Me.Ref_chinookTextBox)
        Me.TabPageVersions.Controls.Add(PrixLabel)
        Me.TabPageVersions.Controls.Add(Me.PrixTextBox)
        Me.TabPageVersions.Controls.Add(Prix_fournisseurLabel)
        Me.TabPageVersions.Controls.Add(Me.Prix_fournisseurTextBox)
        Me.TabPageVersions.Controls.Add(RemiseLabel)
        Me.TabPageVersions.Controls.Add(Me.RemiseTextBox)
        Me.TabPageVersions.Controls.Add(StockLabel)
        Me.TabPageVersions.Controls.Add(Me.StockTextBox)
        Me.TabPageVersions.Controls.Add(PoidsLabel)
        Me.TabPageVersions.Controls.Add(Me.PoidsTextBox)
        Me.TabPageVersions.Controls.Add(LibelleLabel)
        Me.TabPageVersions.Controls.Add(Me.LibelleTextBox)
        Me.TabPageVersions.Controls.Add(Description_panierLabel)
        Me.TabPageVersions.Controls.Add(Me.Description_panierTextBox)
        Me.TabPageVersions.Controls.Add(Stock_limiteLabel)
        Me.TabPageVersions.Controls.Add(Me.Stock_limiteCheckBox)
        Me.TabPageVersions.Controls.Add(ReapproLabel)
        Me.TabPageVersions.Controls.Add(Me.ReapproCheckBox)
        Me.TabPageVersions.Controls.Add(PrecommandeLabel)
        Me.TabPageVersions.Controls.Add(Me.PrecommandeCheckBox)
        Me.TabPageVersions.Controls.Add(Web_onLabel)
        Me.TabPageVersions.Controls.Add(Me.Web_onCheckBox)
        Me.TabPageVersions.Controls.Add(Magasin_onLabel)
        Me.TabPageVersions.Controls.Add(Me.Magasin_onCheckBox)
        Me.TabPageVersions.Location = New System.Drawing.Point(4, 22)
        Me.TabPageVersions.Name = "TabPageVersions"
        Me.TabPageVersions.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPageVersions.Size = New System.Drawing.Size(975, 465)
        Me.TabPageVersions.TabIndex = 2
        Me.TabPageVersions.Text = "Versions"
        Me.TabPageVersions.UseVisualStyleBackColor = True
        '
        'ID_t_article_versionLabel
        '
        ID_t_article_versionLabel.AutoSize = True
        ID_t_article_versionLabel.Location = New System.Drawing.Point(8, 32)
        ID_t_article_versionLabel.Name = "ID_t_article_versionLabel"
        ID_t_article_versionLabel.Size = New System.Drawing.Size(95, 13)
        ID_t_article_versionLabel.TabIndex = 0
        ID_t_article_versionLabel.Text = "ID t article version:"
        '
        'ID_t_article_versionTextBox
        '
        Me.ID_t_article_versionTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.T_Article_versionBindingSource, "ID_t_article_version", True))
        Me.ID_t_article_versionTextBox.Location = New System.Drawing.Point(109, 31)
        Me.ID_t_article_versionTextBox.Name = "ID_t_article_versionTextBox"
        Me.ID_t_article_versionTextBox.Size = New System.Drawing.Size(104, 20)
        Me.ID_t_article_versionTextBox.TabIndex = 1
        '
        'ID_t_article_detailLabel1
        '
        ID_t_article_detailLabel1.AutoSize = True
        ID_t_article_detailLabel1.Location = New System.Drawing.Point(8, 60)
        ID_t_article_detailLabel1.Name = "ID_t_article_detailLabel1"
        ID_t_article_detailLabel1.Size = New System.Drawing.Size(86, 13)
        ID_t_article_detailLabel1.TabIndex = 2
        ID_t_article_detailLabel1.Text = "ID t article detail:"
        '
        'ID_t_article_detailTextBox1
        '
        Me.ID_t_article_detailTextBox1.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.T_Article_versionBindingSource, "ID_t_article_detail", True))
        Me.ID_t_article_detailTextBox1.Location = New System.Drawing.Point(109, 57)
        Me.ID_t_article_detailTextBox1.Name = "ID_t_article_detailTextBox1"
        Me.ID_t_article_detailTextBox1.ReadOnly = True
        Me.ID_t_article_detailTextBox1.Size = New System.Drawing.Size(104, 20)
        Me.ID_t_article_detailTextBox1.TabIndex = 3
        '
        'Ref_chinookLabel
        '
        Ref_chinookLabel.AutoSize = True
        Ref_chinookLabel.Location = New System.Drawing.Point(8, 86)
        Ref_chinookLabel.Name = "Ref_chinookLabel"
        Ref_chinookLabel.Size = New System.Drawing.Size(63, 13)
        Ref_chinookLabel.TabIndex = 4
        Ref_chinookLabel.Text = "ref chinook:"
        '
        'Ref_chinookTextBox
        '
        Me.Ref_chinookTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.T_Article_versionBindingSource, "ref_chinook", True))
        Me.Ref_chinookTextBox.Location = New System.Drawing.Point(109, 83)
        Me.Ref_chinookTextBox.Name = "Ref_chinookTextBox"
        Me.Ref_chinookTextBox.Size = New System.Drawing.Size(104, 20)
        Me.Ref_chinookTextBox.TabIndex = 5
        '
        'PrixLabel
        '
        PrixLabel.AutoSize = True
        PrixLabel.Location = New System.Drawing.Point(8, 112)
        PrixLabel.Name = "PrixLabel"
        PrixLabel.Size = New System.Drawing.Size(26, 13)
        PrixLabel.TabIndex = 6
        PrixLabel.Text = "prix:"
        '
        'PrixTextBox
        '
        Me.PrixTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.T_Article_versionBindingSource, "prix", True))
        Me.PrixTextBox.Location = New System.Drawing.Point(109, 109)
        Me.PrixTextBox.Name = "PrixTextBox"
        Me.PrixTextBox.Size = New System.Drawing.Size(104, 20)
        Me.PrixTextBox.TabIndex = 7
        '
        'Prix_fournisseurLabel
        '
        Prix_fournisseurLabel.AutoSize = True
        Prix_fournisseurLabel.Location = New System.Drawing.Point(8, 138)
        Prix_fournisseurLabel.Name = "Prix_fournisseurLabel"
        Prix_fournisseurLabel.Size = New System.Drawing.Size(80, 13)
        Prix_fournisseurLabel.TabIndex = 8
        Prix_fournisseurLabel.Text = "prix fournisseur:"
        '
        'Prix_fournisseurTextBox
        '
        Me.Prix_fournisseurTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.T_Article_versionBindingSource, "prix_fournisseur", True))
        Me.Prix_fournisseurTextBox.Location = New System.Drawing.Point(109, 135)
        Me.Prix_fournisseurTextBox.Name = "Prix_fournisseurTextBox"
        Me.Prix_fournisseurTextBox.Size = New System.Drawing.Size(104, 20)
        Me.Prix_fournisseurTextBox.TabIndex = 9
        '
        'RemiseLabel
        '
        RemiseLabel.AutoSize = True
        RemiseLabel.Location = New System.Drawing.Point(8, 164)
        RemiseLabel.Name = "RemiseLabel"
        RemiseLabel.Size = New System.Drawing.Size(40, 13)
        RemiseLabel.TabIndex = 10
        RemiseLabel.Text = "remise:"
        '
        'RemiseTextBox
        '
        Me.RemiseTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.T_Article_versionBindingSource, "remise", True))
        Me.RemiseTextBox.Location = New System.Drawing.Point(109, 161)
        Me.RemiseTextBox.Name = "RemiseTextBox"
        Me.RemiseTextBox.Size = New System.Drawing.Size(104, 20)
        Me.RemiseTextBox.TabIndex = 11
        '
        'StockLabel
        '
        StockLabel.AutoSize = True
        StockLabel.Location = New System.Drawing.Point(8, 190)
        StockLabel.Name = "StockLabel"
        StockLabel.Size = New System.Drawing.Size(36, 13)
        StockLabel.TabIndex = 12
        StockLabel.Text = "stock:"
        '
        'StockTextBox
        '
        Me.StockTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.T_Article_versionBindingSource, "stock", True))
        Me.StockTextBox.Location = New System.Drawing.Point(109, 187)
        Me.StockTextBox.Name = "StockTextBox"
        Me.StockTextBox.Size = New System.Drawing.Size(104, 20)
        Me.StockTextBox.TabIndex = 13
        '
        'PoidsLabel
        '
        PoidsLabel.AutoSize = True
        PoidsLabel.Location = New System.Drawing.Point(8, 216)
        PoidsLabel.Name = "PoidsLabel"
        PoidsLabel.Size = New System.Drawing.Size(35, 13)
        PoidsLabel.TabIndex = 14
        PoidsLabel.Text = "poids:"
        '
        'PoidsTextBox
        '
        Me.PoidsTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.T_Article_versionBindingSource, "poids", True))
        Me.PoidsTextBox.Location = New System.Drawing.Point(109, 213)
        Me.PoidsTextBox.Name = "PoidsTextBox"
        Me.PoidsTextBox.Size = New System.Drawing.Size(104, 20)
        Me.PoidsTextBox.TabIndex = 15
        '
        'LibelleLabel
        '
        LibelleLabel.AutoSize = True
        LibelleLabel.Location = New System.Drawing.Point(8, 242)
        LibelleLabel.Name = "LibelleLabel"
        LibelleLabel.Size = New System.Drawing.Size(36, 13)
        LibelleLabel.TabIndex = 16
        LibelleLabel.Text = "libelle:"
        '
        'LibelleTextBox
        '
        Me.LibelleTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.T_Article_versionBindingSource, "libelle", True))
        Me.LibelleTextBox.Location = New System.Drawing.Point(109, 239)
        Me.LibelleTextBox.Name = "LibelleTextBox"
        Me.LibelleTextBox.Size = New System.Drawing.Size(104, 20)
        Me.LibelleTextBox.TabIndex = 17
        '
        'Description_panierLabel
        '
        Description_panierLabel.AutoSize = True
        Description_panierLabel.Location = New System.Drawing.Point(8, 268)
        Description_panierLabel.Name = "Description_panierLabel"
        Description_panierLabel.Size = New System.Drawing.Size(93, 13)
        Description_panierLabel.TabIndex = 18
        Description_panierLabel.Text = "description panier:"
        '
        'Description_panierTextBox
        '
        Me.Description_panierTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.T_Article_versionBindingSource, "description_panier", True))
        Me.Description_panierTextBox.Location = New System.Drawing.Point(109, 265)
        Me.Description_panierTextBox.Name = "Description_panierTextBox"
        Me.Description_panierTextBox.Size = New System.Drawing.Size(104, 20)
        Me.Description_panierTextBox.TabIndex = 19
        '
        'Stock_limiteLabel
        '
        Stock_limiteLabel.AutoSize = True
        Stock_limiteLabel.Location = New System.Drawing.Point(8, 296)
        Stock_limiteLabel.Name = "Stock_limiteLabel"
        Stock_limiteLabel.Size = New System.Drawing.Size(62, 13)
        Stock_limiteLabel.TabIndex = 20
        Stock_limiteLabel.Text = "stock limite:"
        '
        'Stock_limiteCheckBox
        '
        Me.Stock_limiteCheckBox.DataBindings.Add(New System.Windows.Forms.Binding("CheckState", Me.T_Article_versionBindingSource, "stock_limite", True))
        Me.Stock_limiteCheckBox.Location = New System.Drawing.Point(109, 291)
        Me.Stock_limiteCheckBox.Name = "Stock_limiteCheckBox"
        Me.Stock_limiteCheckBox.Size = New System.Drawing.Size(104, 24)
        Me.Stock_limiteCheckBox.TabIndex = 21
        '
        'ReapproLabel
        '
        ReapproLabel.AutoSize = True
        ReapproLabel.Location = New System.Drawing.Point(8, 326)
        ReapproLabel.Name = "ReapproLabel"
        ReapproLabel.Size = New System.Drawing.Size(46, 13)
        ReapproLabel.TabIndex = 22
        ReapproLabel.Text = "reappro:"
        '
        'ReapproCheckBox
        '
        Me.ReapproCheckBox.DataBindings.Add(New System.Windows.Forms.Binding("CheckState", Me.T_Article_versionBindingSource, "reappro", True))
        Me.ReapproCheckBox.Location = New System.Drawing.Point(109, 321)
        Me.ReapproCheckBox.Name = "ReapproCheckBox"
        Me.ReapproCheckBox.Size = New System.Drawing.Size(104, 24)
        Me.ReapproCheckBox.TabIndex = 23
        '
        'PrecommandeLabel
        '
        PrecommandeLabel.AutoSize = True
        PrecommandeLabel.Location = New System.Drawing.Point(8, 356)
        PrecommandeLabel.Name = "PrecommandeLabel"
        PrecommandeLabel.Size = New System.Drawing.Size(77, 13)
        PrecommandeLabel.TabIndex = 24
        PrecommandeLabel.Text = "precommande:"
        '
        'PrecommandeCheckBox
        '
        Me.PrecommandeCheckBox.DataBindings.Add(New System.Windows.Forms.Binding("CheckState", Me.T_Article_versionBindingSource, "precommande", True))
        Me.PrecommandeCheckBox.Location = New System.Drawing.Point(109, 351)
        Me.PrecommandeCheckBox.Name = "PrecommandeCheckBox"
        Me.PrecommandeCheckBox.Size = New System.Drawing.Size(104, 24)
        Me.PrecommandeCheckBox.TabIndex = 25
        '
        'Web_onLabel
        '
        Web_onLabel.AutoSize = True
        Web_onLabel.Location = New System.Drawing.Point(8, 386)
        Web_onLabel.Name = "Web_onLabel"
        Web_onLabel.Size = New System.Drawing.Size(45, 13)
        Web_onLabel.TabIndex = 26
        Web_onLabel.Text = "web on:"
        '
        'Web_onCheckBox
        '
        Me.Web_onCheckBox.DataBindings.Add(New System.Windows.Forms.Binding("CheckState", Me.T_Article_versionBindingSource, "web_on", True))
        Me.Web_onCheckBox.Location = New System.Drawing.Point(109, 381)
        Me.Web_onCheckBox.Name = "Web_onCheckBox"
        Me.Web_onCheckBox.Size = New System.Drawing.Size(104, 24)
        Me.Web_onCheckBox.TabIndex = 27
        '
        'Magasin_onLabel
        '
        Magasin_onLabel.AutoSize = True
        Magasin_onLabel.Location = New System.Drawing.Point(8, 416)
        Magasin_onLabel.Name = "Magasin_onLabel"
        Magasin_onLabel.Size = New System.Drawing.Size(64, 13)
        Magasin_onLabel.TabIndex = 28
        Magasin_onLabel.Text = "magasin on:"
        '
        'Magasin_onCheckBox
        '
        Me.Magasin_onCheckBox.DataBindings.Add(New System.Windows.Forms.Binding("CheckState", Me.T_Article_versionBindingSource, "magasin_on", True))
        Me.Magasin_onCheckBox.Location = New System.Drawing.Point(109, 411)
        Me.Magasin_onCheckBox.Name = "Magasin_onCheckBox"
        Me.Magasin_onCheckBox.Size = New System.Drawing.Size(104, 24)
        Me.Magasin_onCheckBox.TabIndex = 29
        '
        'BindingNavigator2
        '
        Me.BindingNavigator2.AddNewItem = Me.ToolStripButton1
        Me.BindingNavigator2.BindingSource = Me.T_Article_versionBindingSource
        Me.BindingNavigator2.CountItem = Me.ToolStripLabel1
        Me.BindingNavigator2.DeleteItem = Me.ToolStripButton2
        Me.BindingNavigator2.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripButton3, Me.ToolStripButton4, Me.ToolStripSeparator1, Me.ToolStripTextBox1, Me.ToolStripLabel1, Me.ToolStripSeparator2, Me.ToolStripButton5, Me.ToolStripButton6, Me.ToolStripSeparator3, Me.ToolStripButton1, Me.ToolStripButton2})
        Me.BindingNavigator2.Location = New System.Drawing.Point(3, 3)
        Me.BindingNavigator2.MoveFirstItem = Me.ToolStripButton3
        Me.BindingNavigator2.MoveLastItem = Me.ToolStripButton6
        Me.BindingNavigator2.MoveNextItem = Me.ToolStripButton5
        Me.BindingNavigator2.MovePreviousItem = Me.ToolStripButton4
        Me.BindingNavigator2.Name = "BindingNavigator2"
        Me.BindingNavigator2.PositionItem = Me.ToolStripTextBox1
        Me.BindingNavigator2.RenderMode = System.Windows.Forms.ToolStripRenderMode.System
        Me.BindingNavigator2.Size = New System.Drawing.Size(969, 25)
        Me.BindingNavigator2.TabIndex = 30
        Me.BindingNavigator2.Text = "BindingNavigator2"
        '
        'ToolStripButton1
        '
        Me.ToolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton1.Image = CType(resources.GetObject("ToolStripButton1.Image"), System.Drawing.Image)
        Me.ToolStripButton1.Name = "ToolStripButton1"
        Me.ToolStripButton1.RightToLeftAutoMirrorImage = True
        Me.ToolStripButton1.Size = New System.Drawing.Size(23, 22)
        Me.ToolStripButton1.Text = "Ajouter nouveau"
        '
        'ToolStripLabel1
        '
        Me.ToolStripLabel1.Name = "ToolStripLabel1"
        Me.ToolStripLabel1.Size = New System.Drawing.Size(38, 22)
        Me.ToolStripLabel1.Text = "de {0}"
        Me.ToolStripLabel1.ToolTipText = "Nombre total d'éléments"
        '
        'ToolStripButton2
        '
        Me.ToolStripButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton2.Image = CType(resources.GetObject("ToolStripButton2.Image"), System.Drawing.Image)
        Me.ToolStripButton2.Name = "ToolStripButton2"
        Me.ToolStripButton2.RightToLeftAutoMirrorImage = True
        Me.ToolStripButton2.Size = New System.Drawing.Size(23, 22)
        Me.ToolStripButton2.Text = "Supprimer"
        '
        'ToolStripButton3
        '
        Me.ToolStripButton3.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton3.Image = CType(resources.GetObject("ToolStripButton3.Image"), System.Drawing.Image)
        Me.ToolStripButton3.Name = "ToolStripButton3"
        Me.ToolStripButton3.RightToLeftAutoMirrorImage = True
        Me.ToolStripButton3.Size = New System.Drawing.Size(23, 22)
        Me.ToolStripButton3.Text = "Placer en premier"
        '
        'ToolStripButton4
        '
        Me.ToolStripButton4.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton4.Image = CType(resources.GetObject("ToolStripButton4.Image"), System.Drawing.Image)
        Me.ToolStripButton4.Name = "ToolStripButton4"
        Me.ToolStripButton4.RightToLeftAutoMirrorImage = True
        Me.ToolStripButton4.Size = New System.Drawing.Size(23, 22)
        Me.ToolStripButton4.Text = "Déplacer vers le haut"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 25)
        '
        'ToolStripTextBox1
        '
        Me.ToolStripTextBox1.AccessibleName = "Position"
        Me.ToolStripTextBox1.AutoSize = False
        Me.ToolStripTextBox1.Name = "ToolStripTextBox1"
        Me.ToolStripTextBox1.Size = New System.Drawing.Size(50, 21)
        Me.ToolStripTextBox1.Text = "0"
        Me.ToolStripTextBox1.ToolTipText = "Position actuelle"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 25)
        '
        'ToolStripButton5
        '
        Me.ToolStripButton5.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton5.Image = CType(resources.GetObject("ToolStripButton5.Image"), System.Drawing.Image)
        Me.ToolStripButton5.Name = "ToolStripButton5"
        Me.ToolStripButton5.RightToLeftAutoMirrorImage = True
        Me.ToolStripButton5.Size = New System.Drawing.Size(23, 22)
        Me.ToolStripButton5.Text = "Déplacer vers le bas"
        '
        'ToolStripButton6
        '
        Me.ToolStripButton6.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton6.Image = CType(resources.GetObject("ToolStripButton6.Image"), System.Drawing.Image)
        Me.ToolStripButton6.Name = "ToolStripButton6"
        Me.ToolStripButton6.RightToLeftAutoMirrorImage = True
        Me.ToolStripButton6.Size = New System.Drawing.Size(23, 22)
        Me.ToolStripButton6.Text = "Placer en dernier"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(6, 25)
        '
        'ID_t_article_enteteLabel1
        '
        ID_t_article_enteteLabel1.AutoSize = True
        ID_t_article_enteteLabel1.Location = New System.Drawing.Point(8, 16)
        ID_t_article_enteteLabel1.Name = "ID_t_article_enteteLabel1"
        ID_t_article_enteteLabel1.Size = New System.Drawing.Size(91, 13)
        ID_t_article_enteteLabel1.TabIndex = 10
        ID_t_article_enteteLabel1.Text = "ID t article entete:"
        '
        'ID_t_article_enteteTextBox1
        '
        Me.ID_t_article_enteteTextBox1.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.T_Article_EnteteBindingSource, "ID_t_article_entete", True))
        Me.ID_t_article_enteteTextBox1.Location = New System.Drawing.Point(105, 13)
        Me.ID_t_article_enteteTextBox1.Name = "ID_t_article_enteteTextBox1"
        Me.ID_t_article_enteteTextBox1.ReadOnly = True
        Me.ID_t_article_enteteTextBox1.Size = New System.Drawing.Size(100, 20)
        Me.ID_t_article_enteteTextBox1.TabIndex = 11
        '
        'T_Article_DetailDataGridView
        '
        Me.T_Article_DetailDataGridView.AutoGenerateColumns = False
        Me.T_Article_DetailDataGridView.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewTextBoxColumn3, Me.DataGridViewTextBoxColumn4, Me.DataGridViewTextBoxColumn5, Me.DataGridViewTextBoxColumn6, Me.DataGridViewTextBoxColumn7, Me.DataGridViewTextBoxColumn8})
        Me.T_Article_DetailDataGridView.DataSource = Me.T_Article_DetailBindingSource
        Me.T_Article_DetailDataGridView.Location = New System.Drawing.Point(105, 269)
        Me.T_Article_DetailDataGridView.Name = "T_Article_DetailDataGridView"
        Me.T_Article_DetailDataGridView.Size = New System.Drawing.Size(847, 170)
        Me.T_Article_DetailDataGridView.TabIndex = 12
        '
        'DataGridViewTextBoxColumn3
        '
        Me.DataGridViewTextBoxColumn3.DataPropertyName = "surface"
        Me.DataGridViewTextBoxColumn3.HeaderText = "surface"
        Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
        '
        'DataGridViewTextBoxColumn4
        '
        Me.DataGridViewTextBoxColumn4.DataPropertyName = "guindant"
        Me.DataGridViewTextBoxColumn4.HeaderText = "guindant"
        Me.DataGridViewTextBoxColumn4.Name = "DataGridViewTextBoxColumn4"
        '
        'DataGridViewTextBoxColumn5
        '
        Me.DataGridViewTextBoxColumn5.DataPropertyName = "wishbone"
        Me.DataGridViewTextBoxColumn5.HeaderText = "wishbone"
        Me.DataGridViewTextBoxColumn5.Name = "DataGridViewTextBoxColumn5"
        '
        'DataGridViewTextBoxColumn6
        '
        Me.DataGridViewTextBoxColumn6.DataPropertyName = "Mat"
        Me.DataGridViewTextBoxColumn6.HeaderText = "Mat"
        Me.DataGridViewTextBoxColumn6.Name = "DataGridViewTextBoxColumn6"
        '
        'DataGridViewTextBoxColumn7
        '
        Me.DataGridViewTextBoxColumn7.DataPropertyName = "Lattes"
        Me.DataGridViewTextBoxColumn7.HeaderText = "Lattes"
        Me.DataGridViewTextBoxColumn7.Name = "DataGridViewTextBoxColumn7"
        '
        'DataGridViewTextBoxColumn8
        '
        Me.DataGridViewTextBoxColumn8.DataPropertyName = "Cam"
        Me.DataGridViewTextBoxColumn8.HeaderText = "Cam"
        Me.DataGridViewTextBoxColumn8.Name = "DataGridViewTextBoxColumn8"
        '
        'T_Article_versionDataGridView
        '
        Me.T_Article_versionDataGridView.AutoGenerateColumns = False
        Me.T_Article_versionDataGridView.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewTextBoxColumn9, Me.DataGridViewTextBoxColumn10, Me.DataGridViewTextBoxColumn11, Me.DataGridViewTextBoxColumn12, Me.DataGridViewTextBoxColumn13, Me.DataGridViewTextBoxColumn14, Me.DataGridViewTextBoxColumn15, Me.DataGridViewTextBoxColumn16, Me.DataGridViewCheckBoxColumn1, Me.DataGridViewCheckBoxColumn2, Me.DataGridViewCheckBoxColumn3, Me.DataGridViewCheckBoxColumn4, Me.DataGridViewCheckBoxColumn5})
        Me.T_Article_versionDataGridView.DataSource = Me.T_Article_versionBindingSource
        Me.T_Article_versionDataGridView.Location = New System.Drawing.Point(6, 245)
        Me.T_Article_versionDataGridView.Name = "T_Article_versionDataGridView"
        Me.T_Article_versionDataGridView.Size = New System.Drawing.Size(921, 220)
        Me.T_Article_versionDataGridView.TabIndex = 17
        '
        'DataGridViewTextBoxColumn9
        '
        Me.DataGridViewTextBoxColumn9.DataPropertyName = "ref_chinook"
        Me.DataGridViewTextBoxColumn9.HeaderText = "ref_chinook"
        Me.DataGridViewTextBoxColumn9.Name = "DataGridViewTextBoxColumn9"
        '
        'DataGridViewTextBoxColumn10
        '
        Me.DataGridViewTextBoxColumn10.DataPropertyName = "prix"
        Me.DataGridViewTextBoxColumn10.HeaderText = "prix"
        Me.DataGridViewTextBoxColumn10.Name = "DataGridViewTextBoxColumn10"
        '
        'DataGridViewTextBoxColumn11
        '
        Me.DataGridViewTextBoxColumn11.DataPropertyName = "prix_fournisseur"
        Me.DataGridViewTextBoxColumn11.HeaderText = "prix_fournisseur"
        Me.DataGridViewTextBoxColumn11.Name = "DataGridViewTextBoxColumn11"
        '
        'DataGridViewTextBoxColumn12
        '
        Me.DataGridViewTextBoxColumn12.DataPropertyName = "remise"
        Me.DataGridViewTextBoxColumn12.HeaderText = "remise"
        Me.DataGridViewTextBoxColumn12.Name = "DataGridViewTextBoxColumn12"
        '
        'DataGridViewTextBoxColumn13
        '
        Me.DataGridViewTextBoxColumn13.DataPropertyName = "stock"
        Me.DataGridViewTextBoxColumn13.HeaderText = "stock"
        Me.DataGridViewTextBoxColumn13.Name = "DataGridViewTextBoxColumn13"
        '
        'DataGridViewTextBoxColumn14
        '
        Me.DataGridViewTextBoxColumn14.DataPropertyName = "poids"
        Me.DataGridViewTextBoxColumn14.HeaderText = "poids"
        Me.DataGridViewTextBoxColumn14.Name = "DataGridViewTextBoxColumn14"
        '
        'DataGridViewTextBoxColumn15
        '
        Me.DataGridViewTextBoxColumn15.DataPropertyName = "libelle"
        Me.DataGridViewTextBoxColumn15.HeaderText = "libelle"
        Me.DataGridViewTextBoxColumn15.Name = "DataGridViewTextBoxColumn15"
        '
        'DataGridViewTextBoxColumn16
        '
        Me.DataGridViewTextBoxColumn16.DataPropertyName = "description_panier"
        Me.DataGridViewTextBoxColumn16.HeaderText = "description_panier"
        Me.DataGridViewTextBoxColumn16.Name = "DataGridViewTextBoxColumn16"
        '
        'DataGridViewCheckBoxColumn1
        '
        Me.DataGridViewCheckBoxColumn1.DataPropertyName = "stock_limite"
        Me.DataGridViewCheckBoxColumn1.HeaderText = "stock_limite"
        Me.DataGridViewCheckBoxColumn1.Name = "DataGridViewCheckBoxColumn1"
        '
        'DataGridViewCheckBoxColumn2
        '
        Me.DataGridViewCheckBoxColumn2.DataPropertyName = "reappro"
        Me.DataGridViewCheckBoxColumn2.HeaderText = "reappro"
        Me.DataGridViewCheckBoxColumn2.Name = "DataGridViewCheckBoxColumn2"
        '
        'DataGridViewCheckBoxColumn3
        '
        Me.DataGridViewCheckBoxColumn3.DataPropertyName = "precommande"
        Me.DataGridViewCheckBoxColumn3.HeaderText = "precommande"
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
        Me.DataGridViewCheckBoxColumn5.DataPropertyName = "magasin_on"
        Me.DataGridViewCheckBoxColumn5.HeaderText = "magasin_on"
        Me.DataGridViewCheckBoxColumn5.Name = "DataGridViewCheckBoxColumn5"
        '
        'FormArticle
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(995, 543)
        Me.Controls.Add(Me.T_Article_EnteteBindingNavigator)
        Me.Controls.Add(Me.TabControl1)
        Me.Name = "FormArticle"
        Me.Text = "FormArticle"
        Me.TabControl1.ResumeLayout(False)
        Me.TabPageInfosGenerales.ResumeLayout(False)
        Me.TabPageInfosGenerales.PerformLayout()
        Me.TabPageInfosTechniques.ResumeLayout(False)
        Me.TabPageInfosTechniques.PerformLayout()
        CType(Me.CLIDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.T_Article_EnteteBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.T_Article_EnteteBindingNavigator, System.ComponentModel.ISupportInitialize).EndInit()
        Me.T_Article_EnteteBindingNavigator.ResumeLayout(False)
        Me.T_Article_EnteteBindingNavigator.PerformLayout()
        CType(Me.T_Article_DetailBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.T_Article_versionBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BindingNavigator1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.BindingNavigator1.ResumeLayout(False)
        Me.BindingNavigator1.PerformLayout()
        Me.TabPageVersions.ResumeLayout(False)
        Me.TabPageVersions.PerformLayout()
        CType(Me.BindingNavigator2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.BindingNavigator2.ResumeLayout(False)
        Me.BindingNavigator2.PerformLayout()
        CType(Me.T_Article_DetailDataGridView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.T_Article_versionDataGridView, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPageInfosGenerales As System.Windows.Forms.TabPage
    Friend WithEvents TabPageInfosTechniques As System.Windows.Forms.TabPage
    Friend WithEvents CLIDataSet As CLI.CLIDataSet
    Friend WithEvents T_Article_EnteteBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents T_Article_EnteteTableAdapter As CLI.CLIDataSetTableAdapters.T_Article_EnteteTableAdapter
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
    Friend WithEvents DescriptionTextBox As System.Windows.Forms.TextBox
    Friend WithEvents ModeleTextBox As System.Windows.Forms.TextBox
    Friend WithEvents MarqueTextBox As System.Windows.Forms.TextBox
    Friend WithEvents AnneeTextBox As System.Windows.Forms.TextBox
    Friend WithEvents ID_t_sousfamilleComboBox As System.Windows.Forms.ComboBox
    Friend WithEvents T_Article_DetailBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents T_Article_DetailTableAdapter As CLI.CLIDataSetTableAdapters.T_Article_DetailTableAdapter
    Friend WithEvents ID_t_article_detailTextBox As System.Windows.Forms.TextBox
    Friend WithEvents ID_t_article_enteteTextBox As System.Windows.Forms.TextBox
    Friend WithEvents SurfaceTextBox As System.Windows.Forms.TextBox
    Friend WithEvents GuindantTextBox As System.Windows.Forms.TextBox
    Friend WithEvents WishboneTextBox As System.Windows.Forms.TextBox
    Friend WithEvents MatTextBox As System.Windows.Forms.TextBox
    Friend WithEvents LattesTextBox As System.Windows.Forms.TextBox
    Friend WithEvents CamTextBox As System.Windows.Forms.TextBox
    Friend WithEvents T_Article_versionBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents T_Article_versionTableAdapter As CLI.CLIDataSetTableAdapters.T_Article_versionTableAdapter
    Friend WithEvents BindingNavigator1 As System.Windows.Forms.BindingNavigator
    Friend WithEvents BindingNavigatorAddNewItem1 As System.Windows.Forms.ToolStripButton
    Friend WithEvents BindingNavigatorCountItem1 As System.Windows.Forms.ToolStripLabel
    Friend WithEvents BindingNavigatorDeleteItem1 As System.Windows.Forms.ToolStripButton
    Friend WithEvents BindingNavigatorMoveFirstItem1 As System.Windows.Forms.ToolStripButton
    Friend WithEvents BindingNavigatorMovePreviousItem1 As System.Windows.Forms.ToolStripButton
    Friend WithEvents BindingNavigatorSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents BindingNavigatorPositionItem1 As System.Windows.Forms.ToolStripTextBox
    Friend WithEvents BindingNavigatorSeparator4 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents BindingNavigatorMoveNextItem1 As System.Windows.Forms.ToolStripButton
    Friend WithEvents BindingNavigatorMoveLastItem1 As System.Windows.Forms.ToolStripButton
    Friend WithEvents BindingNavigatorSeparator5 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents TabPageVersions As System.Windows.Forms.TabPage
    Friend WithEvents ID_t_article_versionTextBox As System.Windows.Forms.TextBox
    Friend WithEvents ID_t_article_detailTextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents Ref_chinookTextBox As System.Windows.Forms.TextBox
    Friend WithEvents PrixTextBox As System.Windows.Forms.TextBox
    Friend WithEvents Prix_fournisseurTextBox As System.Windows.Forms.TextBox
    Friend WithEvents RemiseTextBox As System.Windows.Forms.TextBox
    Friend WithEvents StockTextBox As System.Windows.Forms.TextBox
    Friend WithEvents PoidsTextBox As System.Windows.Forms.TextBox
    Friend WithEvents LibelleTextBox As System.Windows.Forms.TextBox
    Friend WithEvents Description_panierTextBox As System.Windows.Forms.TextBox
    Friend WithEvents Stock_limiteCheckBox As System.Windows.Forms.CheckBox
    Friend WithEvents ReapproCheckBox As System.Windows.Forms.CheckBox
    Friend WithEvents PrecommandeCheckBox As System.Windows.Forms.CheckBox
    Friend WithEvents Web_onCheckBox As System.Windows.Forms.CheckBox
    Friend WithEvents Magasin_onCheckBox As System.Windows.Forms.CheckBox
    Friend WithEvents BindingNavigator2 As System.Windows.Forms.BindingNavigator
    Friend WithEvents ToolStripButton1 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripLabel1 As System.Windows.Forms.ToolStripLabel
    Friend WithEvents ToolStripButton2 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripButton3 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripButton4 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripTextBox1 As System.Windows.Forms.ToolStripTextBox
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripButton5 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripButton6 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ID_t_article_enteteTextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents T_Article_DetailDataGridView As System.Windows.Forms.DataGridView
    Friend WithEvents DataGridViewTextBoxColumn3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn5 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn6 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn7 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn8 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents T_Article_versionDataGridView As System.Windows.Forms.DataGridView
    Friend WithEvents DataGridViewTextBoxColumn9 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn10 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn11 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn12 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn13 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn14 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn15 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn16 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewCheckBoxColumn1 As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents DataGridViewCheckBoxColumn2 As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents DataGridViewCheckBoxColumn3 As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents DataGridViewCheckBoxColumn4 As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents DataGridViewCheckBoxColumn5 As System.Windows.Forms.DataGridViewCheckBoxColumn
End Class
