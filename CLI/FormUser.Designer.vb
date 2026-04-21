<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormUser
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormUser))
        Me.T_UserBindingNavigator = New System.Windows.Forms.BindingNavigator(Me.components)
        Me.BindingNavigatorAddNewItem = New System.Windows.Forms.ToolStripButton()
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
        Me.T_UserBindingNavigatorSaveItem = New System.Windows.Forms.ToolStripButton()
        Me.T_UserDataGridView = New System.Windows.Forms.DataGridView()
        Me.CodeBar = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Actif = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.ImprimerCodeBarreToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Nom = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Prenom = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.login = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn6 = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.TProfilBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.CLIDataSet = New CLI.CLIDataSet()
        Me.T_UserBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.T_UserTableAdapter = New CLI.CLIDataSetTableAdapters.T_UserTableAdapter()
        Me.T_ProfilTableAdapter = New CLI.CLIDataSetTableAdapters.T_ProfilTableAdapter()
        Me.JournalCaisseUn = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.JournalCaisseDeux = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        CType(Me.T_UserBindingNavigator, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.T_UserBindingNavigator.SuspendLayout()
        CType(Me.T_UserDataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ContextMenuStrip1.SuspendLayout()
        CType(Me.TProfilBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CLIDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.T_UserBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'T_UserBindingNavigator
        '
        Me.T_UserBindingNavigator.AddNewItem = Me.BindingNavigatorAddNewItem
        Me.T_UserBindingNavigator.BindingSource = Me.T_UserBindingSource
        Me.T_UserBindingNavigator.CountItem = Me.BindingNavigatorCountItem
        Me.T_UserBindingNavigator.DeleteItem = Me.BindingNavigatorDeleteItem
        Me.T_UserBindingNavigator.ImageScalingSize = New System.Drawing.Size(32, 32)
        Me.T_UserBindingNavigator.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BindingNavigatorMoveFirstItem, Me.BindingNavigatorMovePreviousItem, Me.BindingNavigatorSeparator, Me.BindingNavigatorPositionItem, Me.BindingNavigatorCountItem, Me.BindingNavigatorSeparator1, Me.BindingNavigatorMoveNextItem, Me.BindingNavigatorMoveLastItem, Me.BindingNavigatorSeparator2, Me.BindingNavigatorAddNewItem, Me.BindingNavigatorDeleteItem, Me.T_UserBindingNavigatorSaveItem})
        Me.T_UserBindingNavigator.Location = New System.Drawing.Point(0, 0)
        Me.T_UserBindingNavigator.MoveFirstItem = Me.BindingNavigatorMoveFirstItem
        Me.T_UserBindingNavigator.MoveLastItem = Me.BindingNavigatorMoveLastItem
        Me.T_UserBindingNavigator.MoveNextItem = Me.BindingNavigatorMoveNextItem
        Me.T_UserBindingNavigator.MovePreviousItem = Me.BindingNavigatorMovePreviousItem
        Me.T_UserBindingNavigator.Name = "T_UserBindingNavigator"
        Me.T_UserBindingNavigator.Padding = New System.Windows.Forms.Padding(0, 0, 2, 0)
        Me.T_UserBindingNavigator.PositionItem = Me.BindingNavigatorPositionItem
        Me.T_UserBindingNavigator.Size = New System.Drawing.Size(2464, 39)
        Me.T_UserBindingNavigator.TabIndex = 0
        Me.T_UserBindingNavigator.Text = "BindingNavigator1"
        '
        'BindingNavigatorAddNewItem
        '
        Me.BindingNavigatorAddNewItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BindingNavigatorAddNewItem.Image = CType(resources.GetObject("BindingNavigatorAddNewItem.Image"), System.Drawing.Image)
        Me.BindingNavigatorAddNewItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.BindingNavigatorAddNewItem.Name = "BindingNavigatorAddNewItem"
        Me.BindingNavigatorAddNewItem.RightToLeftAutoMirrorImage = True
        Me.BindingNavigatorAddNewItem.Size = New System.Drawing.Size(23, 36)
        Me.BindingNavigatorAddNewItem.Text = "Ajouter nouveau"
        '
        'BindingNavigatorCountItem
        '
        Me.BindingNavigatorCountItem.Name = "BindingNavigatorCountItem"
        Me.BindingNavigatorCountItem.Size = New System.Drawing.Size(76, 36)
        Me.BindingNavigatorCountItem.Text = "de {0}"
        Me.BindingNavigatorCountItem.ToolTipText = "Nombre total d'éléments"
        '
        'BindingNavigatorDeleteItem
        '
        Me.BindingNavigatorDeleteItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BindingNavigatorDeleteItem.Image = CType(resources.GetObject("BindingNavigatorDeleteItem.Image"), System.Drawing.Image)
        Me.BindingNavigatorDeleteItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.BindingNavigatorDeleteItem.Name = "BindingNavigatorDeleteItem"
        Me.BindingNavigatorDeleteItem.RightToLeftAutoMirrorImage = True
        Me.BindingNavigatorDeleteItem.Size = New System.Drawing.Size(23, 36)
        Me.BindingNavigatorDeleteItem.Text = "Supprimer"
        '
        'BindingNavigatorMoveFirstItem
        '
        Me.BindingNavigatorMoveFirstItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BindingNavigatorMoveFirstItem.Image = CType(resources.GetObject("BindingNavigatorMoveFirstItem.Image"), System.Drawing.Image)
        Me.BindingNavigatorMoveFirstItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.BindingNavigatorMoveFirstItem.Name = "BindingNavigatorMoveFirstItem"
        Me.BindingNavigatorMoveFirstItem.RightToLeftAutoMirrorImage = True
        Me.BindingNavigatorMoveFirstItem.Size = New System.Drawing.Size(23, 36)
        Me.BindingNavigatorMoveFirstItem.Text = "Placer en premier"
        '
        'BindingNavigatorMovePreviousItem
        '
        Me.BindingNavigatorMovePreviousItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BindingNavigatorMovePreviousItem.Image = CType(resources.GetObject("BindingNavigatorMovePreviousItem.Image"), System.Drawing.Image)
        Me.BindingNavigatorMovePreviousItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.BindingNavigatorMovePreviousItem.Name = "BindingNavigatorMovePreviousItem"
        Me.BindingNavigatorMovePreviousItem.RightToLeftAutoMirrorImage = True
        Me.BindingNavigatorMovePreviousItem.Size = New System.Drawing.Size(23, 36)
        Me.BindingNavigatorMovePreviousItem.Text = "Déplacer vers le haut"
        '
        'BindingNavigatorSeparator
        '
        Me.BindingNavigatorSeparator.Name = "BindingNavigatorSeparator"
        Me.BindingNavigatorSeparator.Size = New System.Drawing.Size(6, 39)
        '
        'BindingNavigatorPositionItem
        '
        Me.BindingNavigatorPositionItem.AccessibleName = "Position"
        Me.BindingNavigatorPositionItem.AutoSize = False
        Me.BindingNavigatorPositionItem.Name = "BindingNavigatorPositionItem"
        Me.BindingNavigatorPositionItem.Size = New System.Drawing.Size(96, 39)
        Me.BindingNavigatorPositionItem.Text = "0"
        Me.BindingNavigatorPositionItem.ToolTipText = "Position actuelle"
        '
        'BindingNavigatorSeparator1
        '
        Me.BindingNavigatorSeparator1.Name = "BindingNavigatorSeparator1"
        Me.BindingNavigatorSeparator1.Size = New System.Drawing.Size(6, 39)
        '
        'BindingNavigatorMoveNextItem
        '
        Me.BindingNavigatorMoveNextItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BindingNavigatorMoveNextItem.Image = CType(resources.GetObject("BindingNavigatorMoveNextItem.Image"), System.Drawing.Image)
        Me.BindingNavigatorMoveNextItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.BindingNavigatorMoveNextItem.Name = "BindingNavigatorMoveNextItem"
        Me.BindingNavigatorMoveNextItem.RightToLeftAutoMirrorImage = True
        Me.BindingNavigatorMoveNextItem.Size = New System.Drawing.Size(23, 36)
        Me.BindingNavigatorMoveNextItem.Text = "Déplacer vers le bas"
        '
        'BindingNavigatorMoveLastItem
        '
        Me.BindingNavigatorMoveLastItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BindingNavigatorMoveLastItem.Image = CType(resources.GetObject("BindingNavigatorMoveLastItem.Image"), System.Drawing.Image)
        Me.BindingNavigatorMoveLastItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.BindingNavigatorMoveLastItem.Name = "BindingNavigatorMoveLastItem"
        Me.BindingNavigatorMoveLastItem.RightToLeftAutoMirrorImage = True
        Me.BindingNavigatorMoveLastItem.Size = New System.Drawing.Size(23, 36)
        Me.BindingNavigatorMoveLastItem.Text = "Placer en dernier"
        '
        'BindingNavigatorSeparator2
        '
        Me.BindingNavigatorSeparator2.Name = "BindingNavigatorSeparator2"
        Me.BindingNavigatorSeparator2.Size = New System.Drawing.Size(6, 39)
        '
        'T_UserBindingNavigatorSaveItem
        '
        Me.T_UserBindingNavigatorSaveItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.T_UserBindingNavigatorSaveItem.Image = CType(resources.GetObject("T_UserBindingNavigatorSaveItem.Image"), System.Drawing.Image)
        Me.T_UserBindingNavigatorSaveItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.T_UserBindingNavigatorSaveItem.Name = "T_UserBindingNavigatorSaveItem"
        Me.T_UserBindingNavigatorSaveItem.Size = New System.Drawing.Size(23, 36)
        Me.T_UserBindingNavigatorSaveItem.Text = "Enregistrer les données"
        '
        'T_UserDataGridView
        '
        Me.T_UserDataGridView.AutoGenerateColumns = False
        Me.T_UserDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.T_UserDataGridView.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewTextBoxColumn1, Me.Nom, Me.Prenom, Me.CodeBar, Me.login, Me.DataGridViewTextBoxColumn5, Me.DataGridViewTextBoxColumn6, Me.Actif, Me.JournalCaisseUn, Me.JournalCaisseDeux})
        Me.T_UserDataGridView.ContextMenuStrip = Me.ContextMenuStrip1
        Me.T_UserDataGridView.DataSource = Me.T_UserBindingSource
        Me.T_UserDataGridView.Dock = System.Windows.Forms.DockStyle.Fill
        Me.T_UserDataGridView.Location = New System.Drawing.Point(0, 39)
        Me.T_UserDataGridView.Margin = New System.Windows.Forms.Padding(6, 6, 6, 6)
        Me.T_UserDataGridView.Name = "T_UserDataGridView"
        Me.T_UserDataGridView.Size = New System.Drawing.Size(2464, 569)
        Me.T_UserDataGridView.TabIndex = 1
        '
        'CodeBar
        '
        Me.CodeBar.DataPropertyName = "CodeBar"
        Me.CodeBar.HeaderText = "Code Barre"
        Me.CodeBar.MaxInputLength = 12
        Me.CodeBar.Name = "CodeBar"
        '
        'Actif
        '
        Me.Actif.DataPropertyName = "Actif"
        Me.Actif.HeaderText = "Actif"
        Me.Actif.Name = "Actif"
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.ImageScalingSize = New System.Drawing.Size(32, 32)
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ImprimerCodeBarreToolStripMenuItem})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(313, 40)
        '
        'ImprimerCodeBarreToolStripMenuItem
        '
        Me.ImprimerCodeBarreToolStripMenuItem.Name = "ImprimerCodeBarreToolStripMenuItem"
        Me.ImprimerCodeBarreToolStripMenuItem.Size = New System.Drawing.Size(312, 36)
        Me.ImprimerCodeBarreToolStripMenuItem.Text = "Imprimer Code Barre"
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.DataPropertyName = "ID_T_User"
        Me.DataGridViewTextBoxColumn1.HeaderText = "ID_T_User"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.ReadOnly = True
        Me.DataGridViewTextBoxColumn1.Visible = False
        '
        'Nom
        '
        Me.Nom.DataPropertyName = "Nom"
        Me.Nom.HeaderText = "Nom"
        Me.Nom.Name = "Nom"
        '
        'Prenom
        '
        Me.Prenom.DataPropertyName = "Prenom"
        Me.Prenom.HeaderText = "Prenom"
        Me.Prenom.Name = "Prenom"
        '
        'login
        '
        Me.login.DataPropertyName = "Login"
        Me.login.HeaderText = "Login"
        Me.login.Name = "login"
        '
        'DataGridViewTextBoxColumn5
        '
        Me.DataGridViewTextBoxColumn5.DataPropertyName = "Password"
        Me.DataGridViewTextBoxColumn5.HeaderText = "Password"
        Me.DataGridViewTextBoxColumn5.Name = "DataGridViewTextBoxColumn5"
        '
        'DataGridViewTextBoxColumn6
        '
        Me.DataGridViewTextBoxColumn6.DataPropertyName = "ID_T_Profil"
        Me.DataGridViewTextBoxColumn6.DataSource = Me.TProfilBindingSource
        Me.DataGridViewTextBoxColumn6.DisplayMember = "Libelle"
        Me.DataGridViewTextBoxColumn6.HeaderText = "Profil"
        Me.DataGridViewTextBoxColumn6.Name = "DataGridViewTextBoxColumn6"
        Me.DataGridViewTextBoxColumn6.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridViewTextBoxColumn6.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.DataGridViewTextBoxColumn6.ValueMember = "ID_T_Profil"
        '
        'TProfilBindingSource
        '
        Me.TProfilBindingSource.DataMember = "T_Profil"
        Me.TProfilBindingSource.DataSource = Me.CLIDataSet
        '
        'CLIDataSet
        '
        Me.CLIDataSet.DataSetName = "CLIDataSet"
        Me.CLIDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'T_UserBindingSource
        '
        Me.T_UserBindingSource.DataMember = "T_User"
        Me.T_UserBindingSource.DataSource = Me.CLIDataSet
        '
        'T_UserTableAdapter
        '
        Me.T_UserTableAdapter.ClearBeforeFill = True
        '
        'T_ProfilTableAdapter
        '
        Me.T_ProfilTableAdapter.ClearBeforeFill = True
        '
        'JournalCaisseUn
        '
        Me.JournalCaisseUn.DataPropertyName = "JournalCaisseUn"
        Me.JournalCaisseUn.HeaderText = "JournalCaisseUn"
        Me.JournalCaisseUn.Name = "JournalCaisseUn"
        '
        'JournalCaisseDeux
        '
        Me.JournalCaisseDeux.DataPropertyName = "JournalCaisseDeux"
        Me.JournalCaisseDeux.HeaderText = "JournalCaisseDeux"
        Me.JournalCaisseDeux.Name = "JournalCaisseDeux"
        '
        'FormUser
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(12.0!, 25.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(2464, 608)
        Me.Controls.Add(Me.T_UserDataGridView)
        Me.Controls.Add(Me.T_UserBindingNavigator)
        Me.Margin = New System.Windows.Forms.Padding(6, 6, 6, 6)
        Me.Name = "FormUser"
        Me.Text = "Utilisateurs"
        CType(Me.T_UserBindingNavigator, System.ComponentModel.ISupportInitialize).EndInit()
        Me.T_UserBindingNavigator.ResumeLayout(False)
        Me.T_UserBindingNavigator.PerformLayout()
        CType(Me.T_UserDataGridView, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ContextMenuStrip1.ResumeLayout(False)
        CType(Me.TProfilBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CLIDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.T_UserBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents CLIDataSet As CLI.CLIDataSet
    Friend WithEvents T_UserBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents T_UserTableAdapter As CLI.CLIDataSetTableAdapters.T_UserTableAdapter
    Friend WithEvents T_UserBindingNavigator As System.Windows.Forms.BindingNavigator
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
    Friend WithEvents T_UserBindingNavigatorSaveItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents T_UserDataGridView As System.Windows.Forms.DataGridView
    Friend WithEvents TProfilBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents T_ProfilTableAdapter As CLI.CLIDataSetTableAdapters.T_ProfilTableAdapter

    Friend WithEvents ContextMenuStrip1 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents ImprimerCodeBarreToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Nom As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Prenom As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CodeBar As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents login As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn5 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn6 As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents Actif As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents JournalCaisseUn As DataGridViewCheckBoxColumn
    Friend WithEvents JournalCaisseDeux As DataGridViewCheckBoxColumn
End Class
