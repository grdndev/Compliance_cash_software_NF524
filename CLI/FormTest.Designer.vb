<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormTest
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
        Dim ID_t_article_enteteLabel As System.Windows.Forms.Label
        Dim AnneeLabel As System.Windows.Forms.Label
        Dim ID_t_article_detailLabel As System.Windows.Forms.Label
        Dim ID_t_article_enteteLabel1 As System.Windows.Forms.Label
        Dim ID_t_article_detailLabel1 As System.Windows.Forms.Label
        Dim ID_t_article_versionLabel As System.Windows.Forms.Label
        Dim Description_panierLabel As System.Windows.Forms.Label
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormTest))
        Me.T_Article_EnteteBindingNavigator = New System.Windows.Forms.BindingNavigator(Me.components)
        Me.BindingNavigatorAddNewItem = New System.Windows.Forms.ToolStripButton
        Me.T_Article_EnteteBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.CLIDataSet = New CLI.CLIDataSet
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
        Me.ID_t_article_enteteTextBox = New System.Windows.Forms.TextBox
        Me.AnneeTextBox = New System.Windows.Forms.TextBox
        Me.T_Article_DetailBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.ID_t_article_detailTextBox = New System.Windows.Forms.TextBox
        Me.ID_t_article_enteteTextBox1 = New System.Windows.Forms.TextBox
        Me.T_Article_versionBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.ID_t_article_detailTextBox1 = New System.Windows.Forms.TextBox
        Me.ID_t_article_versionTextBox = New System.Windows.Forms.TextBox
        Me.Description_panierTextBox = New System.Windows.Forms.TextBox
        Me.T_Article_EnteteTableAdapter = New CLI.CLIDataSetTableAdapters.T_Article_EnteteTableAdapter
        Me.T_Article_DetailTableAdapter = New CLI.CLIDataSetTableAdapters.T_Article_DetailTableAdapter
        Me.T_Article_versionTableAdapter = New CLI.CLIDataSetTableAdapters.T_Article_versionTableAdapter
        Me.Button1 = New System.Windows.Forms.Button
        Me.BindingNavigator1 = New System.Windows.Forms.BindingNavigator(Me.components)
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
        Me.ToolStripButton7 = New System.Windows.Forms.ToolStripButton
        Me.BindingNavigator2 = New System.Windows.Forms.BindingNavigator(Me.components)
        Me.ToolStripButton8 = New System.Windows.Forms.ToolStripButton
        Me.ToolStripLabel2 = New System.Windows.Forms.ToolStripLabel
        Me.ToolStripButton9 = New System.Windows.Forms.ToolStripButton
        Me.ToolStripButton10 = New System.Windows.Forms.ToolStripButton
        Me.ToolStripButton11 = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator
        Me.ToolStripTextBox2 = New System.Windows.Forms.ToolStripTextBox
        Me.ToolStripSeparator5 = New System.Windows.Forms.ToolStripSeparator
        Me.ToolStripButton12 = New System.Windows.Forms.ToolStripButton
        Me.ToolStripButton13 = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator6 = New System.Windows.Forms.ToolStripSeparator
        Me.ToolStripButton14 = New System.Windows.Forms.ToolStripButton
        ID_t_article_enteteLabel = New System.Windows.Forms.Label
        AnneeLabel = New System.Windows.Forms.Label
        ID_t_article_detailLabel = New System.Windows.Forms.Label
        ID_t_article_enteteLabel1 = New System.Windows.Forms.Label
        ID_t_article_detailLabel1 = New System.Windows.Forms.Label
        ID_t_article_versionLabel = New System.Windows.Forms.Label
        Description_panierLabel = New System.Windows.Forms.Label
        CType(Me.T_Article_EnteteBindingNavigator, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.T_Article_EnteteBindingNavigator.SuspendLayout()
        CType(Me.T_Article_EnteteBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CLIDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.T_Article_DetailBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.T_Article_versionBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BindingNavigator1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.BindingNavigator1.SuspendLayout()
        CType(Me.BindingNavigator2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.BindingNavigator2.SuspendLayout()
        Me.SuspendLayout()
        '
        'ID_t_article_enteteLabel
        '
        ID_t_article_enteteLabel.AutoSize = True
        ID_t_article_enteteLabel.Location = New System.Drawing.Point(13, 152)
        ID_t_article_enteteLabel.Name = "ID_t_article_enteteLabel"
        ID_t_article_enteteLabel.Size = New System.Drawing.Size(91, 13)
        ID_t_article_enteteLabel.TabIndex = 1
        ID_t_article_enteteLabel.Text = "ID t article entete:"
        '
        'AnneeLabel
        '
        AnneeLabel.AutoSize = True
        AnneeLabel.Location = New System.Drawing.Point(64, 178)
        AnneeLabel.Name = "AnneeLabel"
        AnneeLabel.Size = New System.Drawing.Size(40, 13)
        AnneeLabel.TabIndex = 3
        AnneeLabel.Text = "annee:"
        '
        'ID_t_article_detailLabel
        '
        ID_t_article_detailLabel.AutoSize = True
        ID_t_article_detailLabel.Location = New System.Drawing.Point(18, 252)
        ID_t_article_detailLabel.Name = "ID_t_article_detailLabel"
        ID_t_article_detailLabel.Size = New System.Drawing.Size(86, 13)
        ID_t_article_detailLabel.TabIndex = 5
        ID_t_article_detailLabel.Text = "ID t article detail:"
        '
        'ID_t_article_enteteLabel1
        '
        ID_t_article_enteteLabel1.AutoSize = True
        ID_t_article_enteteLabel1.Location = New System.Drawing.Point(13, 226)
        ID_t_article_enteteLabel1.Name = "ID_t_article_enteteLabel1"
        ID_t_article_enteteLabel1.Size = New System.Drawing.Size(91, 13)
        ID_t_article_enteteLabel1.TabIndex = 7
        ID_t_article_enteteLabel1.Text = "ID t article entete:"
        '
        'ID_t_article_detailLabel1
        '
        ID_t_article_detailLabel1.AutoSize = True
        ID_t_article_detailLabel1.Location = New System.Drawing.Point(18, 288)
        ID_t_article_detailLabel1.Name = "ID_t_article_detailLabel1"
        ID_t_article_detailLabel1.Size = New System.Drawing.Size(86, 13)
        ID_t_article_detailLabel1.TabIndex = 9
        ID_t_article_detailLabel1.Text = "ID t article detail:"
        '
        'ID_t_article_versionLabel
        '
        ID_t_article_versionLabel.AutoSize = True
        ID_t_article_versionLabel.Location = New System.Drawing.Point(9, 314)
        ID_t_article_versionLabel.Name = "ID_t_article_versionLabel"
        ID_t_article_versionLabel.Size = New System.Drawing.Size(95, 13)
        ID_t_article_versionLabel.TabIndex = 11
        ID_t_article_versionLabel.Text = "ID t article version:"
        '
        'Description_panierLabel
        '
        Description_panierLabel.AutoSize = True
        Description_panierLabel.Location = New System.Drawing.Point(11, 349)
        Description_panierLabel.Name = "Description_panierLabel"
        Description_panierLabel.Size = New System.Drawing.Size(93, 13)
        Description_panierLabel.TabIndex = 13
        Description_panierLabel.Text = "description panier:"
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
        Me.T_Article_EnteteBindingNavigator.Size = New System.Drawing.Size(830, 25)
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
        Me.T_Article_EnteteBindingSource.DataSource = Me.CLIDataSet
        '
        'CLIDataSet
        '
        Me.CLIDataSet.DataSetName = "CLIDataSet"
        Me.CLIDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
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
        'ID_t_article_enteteTextBox
        '
        Me.ID_t_article_enteteTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.T_Article_EnteteBindingSource, "ID_t_article_entete", True))
        Me.ID_t_article_enteteTextBox.Location = New System.Drawing.Point(110, 149)
        Me.ID_t_article_enteteTextBox.Name = "ID_t_article_enteteTextBox"
        Me.ID_t_article_enteteTextBox.Size = New System.Drawing.Size(100, 20)
        Me.ID_t_article_enteteTextBox.TabIndex = 2
        '
        'AnneeTextBox
        '
        Me.AnneeTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.T_Article_EnteteBindingSource, "annee", True))
        Me.AnneeTextBox.Location = New System.Drawing.Point(110, 175)
        Me.AnneeTextBox.Name = "AnneeTextBox"
        Me.AnneeTextBox.Size = New System.Drawing.Size(100, 20)
        Me.AnneeTextBox.TabIndex = 4
        '
        'T_Article_DetailBindingSource
        '
        Me.T_Article_DetailBindingSource.DataMember = "T_Article_Detail"
        Me.T_Article_DetailBindingSource.DataSource = Me.CLIDataSet
        '
        'ID_t_article_detailTextBox
        '
        Me.ID_t_article_detailTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.T_Article_DetailBindingSource, "ID_t_article_detail", True))
        Me.ID_t_article_detailTextBox.Location = New System.Drawing.Point(110, 249)
        Me.ID_t_article_detailTextBox.Name = "ID_t_article_detailTextBox"
        Me.ID_t_article_detailTextBox.Size = New System.Drawing.Size(100, 20)
        Me.ID_t_article_detailTextBox.TabIndex = 6
        '
        'ID_t_article_enteteTextBox1
        '
        Me.ID_t_article_enteteTextBox1.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.T_Article_DetailBindingSource, "ID_t_article_entete", True))
        Me.ID_t_article_enteteTextBox1.Location = New System.Drawing.Point(110, 223)
        Me.ID_t_article_enteteTextBox1.Name = "ID_t_article_enteteTextBox1"
        Me.ID_t_article_enteteTextBox1.Size = New System.Drawing.Size(100, 20)
        Me.ID_t_article_enteteTextBox1.TabIndex = 8
        '
        'T_Article_versionBindingSource
        '
        Me.T_Article_versionBindingSource.DataMember = "T_Article_version"
        Me.T_Article_versionBindingSource.DataSource = Me.CLIDataSet
        '
        'ID_t_article_detailTextBox1
        '
        Me.ID_t_article_detailTextBox1.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.T_Article_versionBindingSource, "ID_t_article_detail", True))
        Me.ID_t_article_detailTextBox1.Location = New System.Drawing.Point(110, 285)
        Me.ID_t_article_detailTextBox1.Name = "ID_t_article_detailTextBox1"
        Me.ID_t_article_detailTextBox1.Size = New System.Drawing.Size(100, 20)
        Me.ID_t_article_detailTextBox1.TabIndex = 10
        '
        'ID_t_article_versionTextBox
        '
        Me.ID_t_article_versionTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.T_Article_versionBindingSource, "ID_t_article_version", True))
        Me.ID_t_article_versionTextBox.Location = New System.Drawing.Point(110, 311)
        Me.ID_t_article_versionTextBox.Name = "ID_t_article_versionTextBox"
        Me.ID_t_article_versionTextBox.Size = New System.Drawing.Size(100, 20)
        Me.ID_t_article_versionTextBox.TabIndex = 12
        '
        'Description_panierTextBox
        '
        Me.Description_panierTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.T_Article_versionBindingSource, "description_panier", True))
        Me.Description_panierTextBox.Location = New System.Drawing.Point(110, 346)
        Me.Description_panierTextBox.Name = "Description_panierTextBox"
        Me.Description_panierTextBox.Size = New System.Drawing.Size(100, 20)
        Me.Description_panierTextBox.TabIndex = 14
        '
        'T_Article_EnteteTableAdapter
        '
        Me.T_Article_EnteteTableAdapter.ClearBeforeFill = True
        '
        'T_Article_DetailTableAdapter
        '
        Me.T_Article_DetailTableAdapter.ClearBeforeFill = True
        '
        'T_Article_versionTableAdapter
        '
        Me.T_Article_versionTableAdapter.ClearBeforeFill = True
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(16, 392)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 15
        Me.Button1.Text = "Button1"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'BindingNavigator1
        '
        Me.BindingNavigator1.AddNewItem = Me.ToolStripButton1
        Me.BindingNavigator1.BindingSource = Me.T_Article_DetailBindingSource
        Me.BindingNavigator1.CountItem = Me.ToolStripLabel1
        Me.BindingNavigator1.DeleteItem = Me.ToolStripButton2
        Me.BindingNavigator1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripButton3, Me.ToolStripButton4, Me.ToolStripSeparator1, Me.ToolStripTextBox1, Me.ToolStripLabel1, Me.ToolStripSeparator2, Me.ToolStripButton5, Me.ToolStripButton6, Me.ToolStripSeparator3, Me.ToolStripButton1, Me.ToolStripButton2, Me.ToolStripButton7})
        Me.BindingNavigator1.Location = New System.Drawing.Point(0, 25)
        Me.BindingNavigator1.MoveFirstItem = Me.ToolStripButton3
        Me.BindingNavigator1.MoveLastItem = Me.ToolStripButton6
        Me.BindingNavigator1.MoveNextItem = Me.ToolStripButton5
        Me.BindingNavigator1.MovePreviousItem = Me.ToolStripButton4
        Me.BindingNavigator1.Name = "BindingNavigator1"
        Me.BindingNavigator1.PositionItem = Me.ToolStripTextBox1
        Me.BindingNavigator1.Size = New System.Drawing.Size(830, 25)
        Me.BindingNavigator1.TabIndex = 16
        Me.BindingNavigator1.Text = "BindingNavigator1"
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
        'ToolStripButton7
        '
        Me.ToolStripButton7.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton7.Image = CType(resources.GetObject("ToolStripButton7.Image"), System.Drawing.Image)
        Me.ToolStripButton7.Name = "ToolStripButton7"
        Me.ToolStripButton7.Size = New System.Drawing.Size(23, 22)
        Me.ToolStripButton7.Text = "Enregistrer les données"
        '
        'BindingNavigator2
        '
        Me.BindingNavigator2.AddNewItem = Me.ToolStripButton8
        Me.BindingNavigator2.BindingSource = Me.T_Article_versionBindingSource
        Me.BindingNavigator2.CountItem = Me.ToolStripLabel2
        Me.BindingNavigator2.DeleteItem = Me.ToolStripButton9
        Me.BindingNavigator2.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripButton10, Me.ToolStripButton11, Me.ToolStripSeparator4, Me.ToolStripTextBox2, Me.ToolStripLabel2, Me.ToolStripSeparator5, Me.ToolStripButton12, Me.ToolStripButton13, Me.ToolStripSeparator6, Me.ToolStripButton8, Me.ToolStripButton9, Me.ToolStripButton14})
        Me.BindingNavigator2.Location = New System.Drawing.Point(0, 50)
        Me.BindingNavigator2.MoveFirstItem = Me.ToolStripButton10
        Me.BindingNavigator2.MoveLastItem = Me.ToolStripButton13
        Me.BindingNavigator2.MoveNextItem = Me.ToolStripButton12
        Me.BindingNavigator2.MovePreviousItem = Me.ToolStripButton11
        Me.BindingNavigator2.Name = "BindingNavigator2"
        Me.BindingNavigator2.PositionItem = Me.ToolStripTextBox2
        Me.BindingNavigator2.Size = New System.Drawing.Size(830, 25)
        Me.BindingNavigator2.TabIndex = 17
        Me.BindingNavigator2.Text = "BindingNavigator1"
        '
        'ToolStripButton8
        '
        Me.ToolStripButton8.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton8.Image = CType(resources.GetObject("ToolStripButton8.Image"), System.Drawing.Image)
        Me.ToolStripButton8.Name = "ToolStripButton8"
        Me.ToolStripButton8.RightToLeftAutoMirrorImage = True
        Me.ToolStripButton8.Size = New System.Drawing.Size(23, 22)
        Me.ToolStripButton8.Text = "Ajouter nouveau"
        '
        'ToolStripLabel2
        '
        Me.ToolStripLabel2.Name = "ToolStripLabel2"
        Me.ToolStripLabel2.Size = New System.Drawing.Size(38, 22)
        Me.ToolStripLabel2.Text = "de {0}"
        Me.ToolStripLabel2.ToolTipText = "Nombre total d'éléments"
        '
        'ToolStripButton9
        '
        Me.ToolStripButton9.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton9.Image = CType(resources.GetObject("ToolStripButton9.Image"), System.Drawing.Image)
        Me.ToolStripButton9.Name = "ToolStripButton9"
        Me.ToolStripButton9.RightToLeftAutoMirrorImage = True
        Me.ToolStripButton9.Size = New System.Drawing.Size(23, 22)
        Me.ToolStripButton9.Text = "Supprimer"
        '
        'ToolStripButton10
        '
        Me.ToolStripButton10.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton10.Image = CType(resources.GetObject("ToolStripButton10.Image"), System.Drawing.Image)
        Me.ToolStripButton10.Name = "ToolStripButton10"
        Me.ToolStripButton10.RightToLeftAutoMirrorImage = True
        Me.ToolStripButton10.Size = New System.Drawing.Size(23, 22)
        Me.ToolStripButton10.Text = "Placer en premier"
        '
        'ToolStripButton11
        '
        Me.ToolStripButton11.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton11.Image = CType(resources.GetObject("ToolStripButton11.Image"), System.Drawing.Image)
        Me.ToolStripButton11.Name = "ToolStripButton11"
        Me.ToolStripButton11.RightToLeftAutoMirrorImage = True
        Me.ToolStripButton11.Size = New System.Drawing.Size(23, 22)
        Me.ToolStripButton11.Text = "Déplacer vers le haut"
        '
        'ToolStripSeparator4
        '
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        Me.ToolStripSeparator4.Size = New System.Drawing.Size(6, 25)
        '
        'ToolStripTextBox2
        '
        Me.ToolStripTextBox2.AccessibleName = "Position"
        Me.ToolStripTextBox2.AutoSize = False
        Me.ToolStripTextBox2.Name = "ToolStripTextBox2"
        Me.ToolStripTextBox2.Size = New System.Drawing.Size(50, 21)
        Me.ToolStripTextBox2.Text = "0"
        Me.ToolStripTextBox2.ToolTipText = "Position actuelle"
        '
        'ToolStripSeparator5
        '
        Me.ToolStripSeparator5.Name = "ToolStripSeparator5"
        Me.ToolStripSeparator5.Size = New System.Drawing.Size(6, 25)
        '
        'ToolStripButton12
        '
        Me.ToolStripButton12.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton12.Image = CType(resources.GetObject("ToolStripButton12.Image"), System.Drawing.Image)
        Me.ToolStripButton12.Name = "ToolStripButton12"
        Me.ToolStripButton12.RightToLeftAutoMirrorImage = True
        Me.ToolStripButton12.Size = New System.Drawing.Size(23, 22)
        Me.ToolStripButton12.Text = "Déplacer vers le bas"
        '
        'ToolStripButton13
        '
        Me.ToolStripButton13.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton13.Image = CType(resources.GetObject("ToolStripButton13.Image"), System.Drawing.Image)
        Me.ToolStripButton13.Name = "ToolStripButton13"
        Me.ToolStripButton13.RightToLeftAutoMirrorImage = True
        Me.ToolStripButton13.Size = New System.Drawing.Size(23, 22)
        Me.ToolStripButton13.Text = "Placer en dernier"
        '
        'ToolStripSeparator6
        '
        Me.ToolStripSeparator6.Name = "ToolStripSeparator6"
        Me.ToolStripSeparator6.Size = New System.Drawing.Size(6, 25)
        '
        'ToolStripButton14
        '
        Me.ToolStripButton14.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton14.Image = CType(resources.GetObject("ToolStripButton14.Image"), System.Drawing.Image)
        Me.ToolStripButton14.Name = "ToolStripButton14"
        Me.ToolStripButton14.Size = New System.Drawing.Size(23, 22)
        Me.ToolStripButton14.Text = "Enregistrer les données"
        '
        'FormTest
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(830, 624)
        Me.Controls.Add(Me.BindingNavigator2)
        Me.Controls.Add(Me.BindingNavigator1)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Description_panierLabel)
        Me.Controls.Add(Me.Description_panierTextBox)
        Me.Controls.Add(ID_t_article_versionLabel)
        Me.Controls.Add(Me.ID_t_article_versionTextBox)
        Me.Controls.Add(ID_t_article_detailLabel1)
        Me.Controls.Add(Me.ID_t_article_detailTextBox1)
        Me.Controls.Add(ID_t_article_enteteLabel1)
        Me.Controls.Add(Me.ID_t_article_enteteTextBox1)
        Me.Controls.Add(ID_t_article_detailLabel)
        Me.Controls.Add(Me.ID_t_article_detailTextBox)
        Me.Controls.Add(AnneeLabel)
        Me.Controls.Add(Me.AnneeTextBox)
        Me.Controls.Add(ID_t_article_enteteLabel)
        Me.Controls.Add(Me.ID_t_article_enteteTextBox)
        Me.Controls.Add(Me.T_Article_EnteteBindingNavigator)
        Me.Name = "FormTest"
        Me.Text = "FormTest"
        CType(Me.T_Article_EnteteBindingNavigator, System.ComponentModel.ISupportInitialize).EndInit()
        Me.T_Article_EnteteBindingNavigator.ResumeLayout(False)
        Me.T_Article_EnteteBindingNavigator.PerformLayout()
        CType(Me.T_Article_EnteteBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CLIDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.T_Article_DetailBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.T_Article_versionBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BindingNavigator1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.BindingNavigator1.ResumeLayout(False)
        Me.BindingNavigator1.PerformLayout()
        CType(Me.BindingNavigator2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.BindingNavigator2.ResumeLayout(False)
        Me.BindingNavigator2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
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
    Friend WithEvents ID_t_article_enteteTextBox As System.Windows.Forms.TextBox
    Friend WithEvents AnneeTextBox As System.Windows.Forms.TextBox
    Friend WithEvents T_Article_DetailBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents T_Article_DetailTableAdapter As CLI.CLIDataSetTableAdapters.T_Article_DetailTableAdapter
    Friend WithEvents ID_t_article_detailTextBox As System.Windows.Forms.TextBox
    Friend WithEvents ID_t_article_enteteTextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents T_Article_versionBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents T_Article_versionTableAdapter As CLI.CLIDataSetTableAdapters.T_Article_versionTableAdapter
    Friend WithEvents ID_t_article_detailTextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents ID_t_article_versionTextBox As System.Windows.Forms.TextBox
    Friend WithEvents Description_panierTextBox As System.Windows.Forms.TextBox
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents BindingNavigator1 As System.Windows.Forms.BindingNavigator
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
    Friend WithEvents ToolStripButton7 As System.Windows.Forms.ToolStripButton
    Friend WithEvents BindingNavigator2 As System.Windows.Forms.BindingNavigator
    Friend WithEvents ToolStripButton8 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripLabel2 As System.Windows.Forms.ToolStripLabel
    Friend WithEvents ToolStripButton9 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripButton10 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripButton11 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator4 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripTextBox2 As System.Windows.Forms.ToolStripTextBox
    Friend WithEvents ToolStripSeparator5 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripButton12 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripButton13 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator6 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripButton14 As System.Windows.Forms.ToolStripButton
End Class
