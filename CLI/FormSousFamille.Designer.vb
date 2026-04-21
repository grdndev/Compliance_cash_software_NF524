<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FormSousFamille
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormSousFamille))
        Me.T_SousFamilleBindingNavigator = New System.Windows.Forms.BindingNavigator(Me.components)
        Me.BindingNavigatorAddNewItem = New System.Windows.Forms.ToolStripButton()
        Me.T_SousFamilleBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.CLIDataSet = New CLI.CLIDataSet()
        Me.BindingNavigatorCountItem = New System.Windows.Forms.ToolStripLabel()
        Me.BindingNavigatorDeleteItem = New System.Windows.Forms.ToolStripButton()
        Me.BindingNavigatorMoveFirstItem = New System.Windows.Forms.ToolStripButton()
        Me.BindingNavigatorMovePreviousItem = New System.Windows.Forms.ToolStripButton()
        Me.BindingNavigatorSeparator = New System.Windows.Forms.ToolStripSeparator()
        Me.BindingNavigatorPositionItem = New System.Windows.Forms.ToolStripTextBox()
        Me.BindingNavigatorSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.BindingNavigatorMoveNextItem = New System.Windows.Forms.ToolStripButton()
        Me.BindingNavigatorMoveLastItem = New System.Windows.Forms.ToolStripButton()
        Me.BindingNavigatorSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.T_SousFamilleBindingNavigatorSaveItem = New System.Windows.Forms.ToolStripButton()
        Me.T_SousFamilleDataGridView = New System.Windows.Forms.DataGridView()
        Me.TFamilleBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.T_SousFamilleTableAdapter = New CLI.CLIDataSetTableAdapters.T_SousFamilleTableAdapter()
        Me.T_FamilleTableAdapter = New CLI.CLIDataSetTableAdapters.T_FamilleTableAdapter()
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colonneweb = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.DataGridViewTextBoxColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.toSync = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.DataGridViewTextBoxColumn4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.annee_on = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.description_panier = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.LibelleTech = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ChampTech = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.LibelleVersion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ChampVersion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ChampsObligatoiresMagasin = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ChampsWeb = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ChampsOptionnels = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Marque = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Programme = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Type = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.RDMType = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Poids = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Boitier = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Taille = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Type2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Type3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Type4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.LibelleListe = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Vignette = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CaracteristiquesPrestashop = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.AttributsPrestashop = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SousSousFamille = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SousSousFamille2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SousSousFamille3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SousSousFamille4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ChampTriAttributsPrestashop = New System.Windows.Forms.DataGridViewTextBoxColumn()
        CType(Me.T_SousFamilleBindingNavigator, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.T_SousFamilleBindingNavigator.SuspendLayout()
        CType(Me.T_SousFamilleBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CLIDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.T_SousFamilleDataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TFamilleBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'T_SousFamilleBindingNavigator
        '
        Me.T_SousFamilleBindingNavigator.AddNewItem = Me.BindingNavigatorAddNewItem
        Me.T_SousFamilleBindingNavigator.BindingSource = Me.T_SousFamilleBindingSource
        Me.T_SousFamilleBindingNavigator.CountItem = Me.BindingNavigatorCountItem
        Me.T_SousFamilleBindingNavigator.DeleteItem = Me.BindingNavigatorDeleteItem
        Me.T_SousFamilleBindingNavigator.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BindingNavigatorMoveFirstItem, Me.BindingNavigatorMovePreviousItem, Me.BindingNavigatorSeparator, Me.BindingNavigatorPositionItem, Me.BindingNavigatorCountItem, Me.BindingNavigatorSeparator1, Me.BindingNavigatorMoveNextItem, Me.BindingNavigatorMoveLastItem, Me.BindingNavigatorSeparator2, Me.BindingNavigatorAddNewItem, Me.BindingNavigatorDeleteItem, Me.T_SousFamilleBindingNavigatorSaveItem})
        Me.T_SousFamilleBindingNavigator.Location = New System.Drawing.Point(0, 0)
        Me.T_SousFamilleBindingNavigator.MoveFirstItem = Me.BindingNavigatorMoveFirstItem
        Me.T_SousFamilleBindingNavigator.MoveLastItem = Me.BindingNavigatorMoveLastItem
        Me.T_SousFamilleBindingNavigator.MoveNextItem = Me.BindingNavigatorMoveNextItem
        Me.T_SousFamilleBindingNavigator.MovePreviousItem = Me.BindingNavigatorMovePreviousItem
        Me.T_SousFamilleBindingNavigator.Name = "T_SousFamilleBindingNavigator"
        Me.T_SousFamilleBindingNavigator.PositionItem = Me.BindingNavigatorPositionItem
        Me.T_SousFamilleBindingNavigator.Size = New System.Drawing.Size(969, 25)
        Me.T_SousFamilleBindingNavigator.TabIndex = 0
        Me.T_SousFamilleBindingNavigator.Text = "BindingNavigator1"
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
        'T_SousFamilleBindingSource
        '
        Me.T_SousFamilleBindingSource.DataMember = "T_SousFamille"
        Me.T_SousFamilleBindingSource.DataSource = Me.CLIDataSet
        '
        'CLIDataSet
        '
        Me.CLIDataSet.DataSetName = "CLIDataSet"
        Me.CLIDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'BindingNavigatorCountItem
        '
        Me.BindingNavigatorCountItem.Name = "BindingNavigatorCountItem"
        Me.BindingNavigatorCountItem.Size = New System.Drawing.Size(37, 22)
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
        Me.BindingNavigatorPositionItem.Font = New System.Drawing.Font("Segoe UI", 9.0!)
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
        'T_SousFamilleBindingNavigatorSaveItem
        '
        Me.T_SousFamilleBindingNavigatorSaveItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.T_SousFamilleBindingNavigatorSaveItem.Image = CType(resources.GetObject("T_SousFamilleBindingNavigatorSaveItem.Image"), System.Drawing.Image)
        Me.T_SousFamilleBindingNavigatorSaveItem.Name = "T_SousFamilleBindingNavigatorSaveItem"
        Me.T_SousFamilleBindingNavigatorSaveItem.Size = New System.Drawing.Size(23, 22)
        Me.T_SousFamilleBindingNavigatorSaveItem.Text = "Enregistrer les données"
        '
        'T_SousFamilleDataGridView
        '
        Me.T_SousFamilleDataGridView.AutoGenerateColumns = False
        Me.T_SousFamilleDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.T_SousFamilleDataGridView.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewTextBoxColumn1, Me.colonneweb, Me.DataGridViewTextBoxColumn2, Me.DataGridViewTextBoxColumn3, Me.toSync, Me.DataGridViewTextBoxColumn4, Me.annee_on, Me.description_panier, Me.LibelleTech, Me.ChampTech, Me.LibelleVersion, Me.ChampVersion, Me.ChampsObligatoiresMagasin, Me.ChampsWeb, Me.ChampsOptionnels, Me.Marque, Me.Programme, Me.Type, Me.RDMType, Me.Poids, Me.Boitier, Me.Taille, Me.Type2, Me.Type3, Me.Type4, Me.LibelleListe, Me.Vignette, Me.CaracteristiquesPrestashop, Me.AttributsPrestashop, Me.SousSousFamille, Me.SousSousFamille2, Me.SousSousFamille3, Me.SousSousFamille4, Me.ChampTriAttributsPrestashop})
        Me.T_SousFamilleDataGridView.DataSource = Me.T_SousFamilleBindingSource
        Me.T_SousFamilleDataGridView.Dock = System.Windows.Forms.DockStyle.Fill
        Me.T_SousFamilleDataGridView.Location = New System.Drawing.Point(0, 25)
        Me.T_SousFamilleDataGridView.Name = "T_SousFamilleDataGridView"
        Me.T_SousFamilleDataGridView.Size = New System.Drawing.Size(969, 286)
        Me.T_SousFamilleDataGridView.TabIndex = 2
        '
        'TFamilleBindingSource
        '
        Me.TFamilleBindingSource.DataMember = "T_Famille"
        Me.TFamilleBindingSource.DataSource = Me.CLIDataSet
        '
        'T_SousFamilleTableAdapter
        '
        Me.T_SousFamilleTableAdapter.ClearBeforeFill = True
        '
        'T_FamilleTableAdapter
        '
        Me.T_FamilleTableAdapter.ClearBeforeFill = True
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.DataPropertyName = "ID_T_SousFamille"
        Me.DataGridViewTextBoxColumn1.HeaderText = "ID_T_SousFamille"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.ReadOnly = True
        Me.DataGridViewTextBoxColumn1.Visible = False
        '
        'colonneweb
        '
        Me.colonneweb.DataPropertyName = "colonneweb"
        Me.colonneweb.HeaderText = "colonneweb"
        Me.colonneweb.Name = "colonneweb"
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.DataPropertyName = "ID_T_Famille"
        Me.DataGridViewTextBoxColumn2.DataSource = Me.TFamilleBindingSource
        Me.DataGridViewTextBoxColumn2.DisplayMember = "Libelle"
        Me.DataGridViewTextBoxColumn2.HeaderText = "Famille"
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        Me.DataGridViewTextBoxColumn2.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridViewTextBoxColumn2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.DataGridViewTextBoxColumn2.ValueMember = "ID_T_Famille"
        '
        'DataGridViewTextBoxColumn3
        '
        Me.DataGridViewTextBoxColumn3.DataPropertyName = "Libelle"
        Me.DataGridViewTextBoxColumn3.HeaderText = "Libelle"
        Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
        '
        'toSync
        '
        Me.toSync.DataPropertyName = "toSync"
        Me.toSync.HeaderText = "toSync"
        Me.toSync.Name = "toSync"
        '
        'DataGridViewTextBoxColumn4
        '
        Me.DataGridViewTextBoxColumn4.DataPropertyName = "tri"
        Me.DataGridViewTextBoxColumn4.HeaderText = "tri"
        Me.DataGridViewTextBoxColumn4.Name = "DataGridViewTextBoxColumn4"
        '
        'annee_on
        '
        Me.annee_on.DataPropertyName = "annee_on"
        Me.annee_on.HeaderText = "Annee ?"
        Me.annee_on.Name = "annee_on"
        '
        'description_panier
        '
        Me.description_panier.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.description_panier.DataPropertyName = "description_panier"
        Me.description_panier.HeaderText = "Description panier auto"
        Me.description_panier.Name = "description_panier"
        Me.description_panier.Width = 110
        '
        'LibelleTech
        '
        Me.LibelleTech.DataPropertyName = "LibelleTech"
        Me.LibelleTech.HeaderText = "LibelleTech"
        Me.LibelleTech.Name = "LibelleTech"
        '
        'ChampTech
        '
        Me.ChampTech.DataPropertyName = "ChampTech"
        Me.ChampTech.HeaderText = "ChampTech"
        Me.ChampTech.Name = "ChampTech"
        '
        'LibelleVersion
        '
        Me.LibelleVersion.DataPropertyName = "LibelleVersion"
        Me.LibelleVersion.HeaderText = "LibelleVersion"
        Me.LibelleVersion.Name = "LibelleVersion"
        '
        'ChampVersion
        '
        Me.ChampVersion.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.ChampVersion.DataPropertyName = "ChampVersion"
        Me.ChampVersion.HeaderText = "ChampVersion"
        Me.ChampVersion.Name = "ChampVersion"
        '
        'ChampsObligatoiresMagasin
        '
        Me.ChampsObligatoiresMagasin.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.ChampsObligatoiresMagasin.DataPropertyName = "ChampsObligatoiresMagasin"
        Me.ChampsObligatoiresMagasin.HeaderText = "ChampsObligatoiresMagasin"
        Me.ChampsObligatoiresMagasin.Name = "ChampsObligatoiresMagasin"
        Me.ChampsObligatoiresMagasin.Width = 165
        '
        'ChampsWeb
        '
        Me.ChampsWeb.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.ChampsWeb.DataPropertyName = "ChampsWeb"
        Me.ChampsWeb.HeaderText = "ChampsWeb"
        Me.ChampsWeb.Name = "ChampsWeb"
        Me.ChampsWeb.Width = 93
        '
        'ChampsOptionnels
        '
        Me.ChampsOptionnels.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.ChampsOptionnels.DataPropertyName = "ChampsOptionnels"
        Me.ChampsOptionnels.HeaderText = "ChampsOptionnels"
        Me.ChampsOptionnels.Name = "ChampsOptionnels"
        Me.ChampsOptionnels.Width = 120
        '
        'Marque
        '
        Me.Marque.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.Marque.DataPropertyName = "Marque"
        Me.Marque.HeaderText = "Marque"
        Me.Marque.Name = "Marque"
        Me.Marque.Width = 68
        '
        'Programme
        '
        Me.Programme.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.Programme.DataPropertyName = "Programme"
        Me.Programme.HeaderText = "Programme"
        Me.Programme.Name = "Programme"
        Me.Programme.Width = 85
        '
        'Type
        '
        Me.Type.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.Type.DataPropertyName = "Type"
        Me.Type.HeaderText = "Type"
        Me.Type.Name = "Type"
        Me.Type.Width = 56
        '
        'RDMType
        '
        Me.RDMType.DataPropertyName = "RDMType"
        Me.RDMType.HeaderText = "RDMType"
        Me.RDMType.Name = "RDMType"
        '
        'Poids
        '
        Me.Poids.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.Poids.DataPropertyName = "Poids"
        Me.Poids.HeaderText = "Poids"
        Me.Poids.Name = "Poids"
        Me.Poids.Width = 58
        '
        'Boitier
        '
        Me.Boitier.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.Boitier.DataPropertyName = "Boitier"
        Me.Boitier.HeaderText = "Boitier"
        Me.Boitier.Name = "Boitier"
        Me.Boitier.Width = 61
        '
        'Taille
        '
        Me.Taille.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.Taille.DataPropertyName = "Taille"
        Me.Taille.HeaderText = "Taille"
        Me.Taille.Name = "Taille"
        Me.Taille.Width = 57
        '
        'Type2
        '
        Me.Type2.DataPropertyName = "Type2"
        Me.Type2.HeaderText = "Type2"
        Me.Type2.Name = "Type2"
        '
        'Type3
        '
        Me.Type3.DataPropertyName = "Type3"
        Me.Type3.HeaderText = "Type3"
        Me.Type3.Name = "Type3"
        '
        'Type4
        '
        Me.Type4.DataPropertyName = "Type4"
        Me.Type4.HeaderText = "Type4"
        Me.Type4.Name = "Type4"
        '
        'LibelleListe
        '
        Me.LibelleListe.DataPropertyName = "LibelleListe"
        Me.LibelleListe.HeaderText = "LibelleListe"
        Me.LibelleListe.Name = "LibelleListe"
        '
        'Vignette
        '
        Me.Vignette.DataPropertyName = "Vignette"
        Me.Vignette.HeaderText = "Vignette"
        Me.Vignette.Name = "Vignette"
        '
        'CaracteristiquesPrestashop
        '
        Me.CaracteristiquesPrestashop.DataPropertyName = "CaracteristiquesPrestashop"
        Me.CaracteristiquesPrestashop.HeaderText = "CaracteristiquesPrestashop"
        Me.CaracteristiquesPrestashop.Name = "CaracteristiquesPrestashop"
        '
        'AttributsPrestashop
        '
        Me.AttributsPrestashop.DataPropertyName = "AttributsPrestashop"
        Me.AttributsPrestashop.HeaderText = "AttributsPrestashop"
        Me.AttributsPrestashop.Name = "AttributsPrestashop"
        '
        'SousSousFamille
        '
        Me.SousSousFamille.DataPropertyName = "SousSousFamille"
        Me.SousSousFamille.HeaderText = "SousSousFamille"
        Me.SousSousFamille.Name = "SousSousFamille"
        '
        'SousSousFamille2
        '
        Me.SousSousFamille2.DataPropertyName = "SousSousFamille2"
        Me.SousSousFamille2.HeaderText = "SousSousFamille2"
        Me.SousSousFamille2.Name = "SousSousFamille2"
        '
        'SousSousFamille3
        '
        Me.SousSousFamille3.DataPropertyName = "SousSousFamille3"
        Me.SousSousFamille3.HeaderText = "SousSousFamille3"
        Me.SousSousFamille3.Name = "SousSousFamille3"
        '
        'SousSousFamille4
        '
        Me.SousSousFamille4.DataPropertyName = "SousSousFamille4"
        Me.SousSousFamille4.HeaderText = "SousSousFamille4"
        Me.SousSousFamille4.Name = "SousSousFamille4"
        '
        'ChampTriAttributsPrestashop
        '
        Me.ChampTriAttributsPrestashop.DataPropertyName = "ChampTriAttributsPrestashop"
        Me.ChampTriAttributsPrestashop.HeaderText = "ChampTriAttributsPrestashop"
        Me.ChampTriAttributsPrestashop.Name = "ChampTriAttributsPrestashop"
        '
        'FormSousFamille
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(969, 311)
        Me.Controls.Add(Me.T_SousFamilleDataGridView)
        Me.Controls.Add(Me.T_SousFamilleBindingNavigator)
        Me.Name = "FormSousFamille"
        Me.Text = "Sous Famille d'articles"
        CType(Me.T_SousFamilleBindingNavigator, System.ComponentModel.ISupportInitialize).EndInit()
        Me.T_SousFamilleBindingNavigator.ResumeLayout(False)
        Me.T_SousFamilleBindingNavigator.PerformLayout()
        CType(Me.T_SousFamilleBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CLIDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.T_SousFamilleDataGridView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TFamilleBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents CLIDataSet As CLI.CLIDataSet
    Friend WithEvents T_SousFamilleBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents T_SousFamilleTableAdapter As CLI.CLIDataSetTableAdapters.T_SousFamilleTableAdapter
    Friend WithEvents T_SousFamilleBindingNavigator As System.Windows.Forms.BindingNavigator
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
    Friend WithEvents T_SousFamilleBindingNavigatorSaveItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents TFamilleBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents T_FamilleTableAdapter As CLI.CLIDataSetTableAdapters.T_FamilleTableAdapter
    Friend WithEvents T_SousFamilleDataGridView As System.Windows.Forms.DataGridView
    Friend WithEvents DataGridViewTextBoxColumn1 As DataGridViewTextBoxColumn
    Friend WithEvents colonneweb As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As DataGridViewComboBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn3 As DataGridViewTextBoxColumn
    Friend WithEvents toSync As DataGridViewCheckBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn4 As DataGridViewTextBoxColumn
    Friend WithEvents annee_on As DataGridViewCheckBoxColumn
    Friend WithEvents description_panier As DataGridViewTextBoxColumn
    Friend WithEvents LibelleTech As DataGridViewTextBoxColumn
    Friend WithEvents ChampTech As DataGridViewTextBoxColumn
    Friend WithEvents LibelleVersion As DataGridViewTextBoxColumn
    Friend WithEvents ChampVersion As DataGridViewTextBoxColumn
    Friend WithEvents ChampsObligatoiresMagasin As DataGridViewTextBoxColumn
    Friend WithEvents ChampsWeb As DataGridViewTextBoxColumn
    Friend WithEvents ChampsOptionnels As DataGridViewTextBoxColumn
    Friend WithEvents Marque As DataGridViewTextBoxColumn
    Friend WithEvents Programme As DataGridViewTextBoxColumn
    Friend WithEvents Type As DataGridViewTextBoxColumn
    Friend WithEvents RDMType As DataGridViewTextBoxColumn
    Friend WithEvents Poids As DataGridViewTextBoxColumn
    Friend WithEvents Boitier As DataGridViewTextBoxColumn
    Friend WithEvents Taille As DataGridViewTextBoxColumn
    Friend WithEvents Type2 As DataGridViewTextBoxColumn
    Friend WithEvents Type3 As DataGridViewTextBoxColumn
    Friend WithEvents Type4 As DataGridViewTextBoxColumn
    Friend WithEvents LibelleListe As DataGridViewTextBoxColumn
    Friend WithEvents Vignette As DataGridViewTextBoxColumn
    Friend WithEvents CaracteristiquesPrestashop As DataGridViewTextBoxColumn
    Friend WithEvents AttributsPrestashop As DataGridViewTextBoxColumn
    Friend WithEvents SousSousFamille As DataGridViewTextBoxColumn
    Friend WithEvents SousSousFamille2 As DataGridViewTextBoxColumn
    Friend WithEvents SousSousFamille3 As DataGridViewTextBoxColumn
    Friend WithEvents SousSousFamille4 As DataGridViewTextBoxColumn
    Friend WithEvents ChampTriAttributsPrestashop As DataGridViewTextBoxColumn
End Class
