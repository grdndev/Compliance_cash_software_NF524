<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormTransactionManuelle
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormTransactionManuelle))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.T_transaction_manuelleBindingNavigator = New System.Windows.Forms.BindingNavigator(Me.components)
        Me.BindingNavigatorAddNewItem = New System.Windows.Forms.ToolStripButton()
        Me.T_transaction_manuelleBindingSource = New System.Windows.Forms.BindingSource(Me.components)
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
        Me.T_transaction_manuelleBindingNavigatorSaveItem = New System.Windows.Forms.ToolStripButton()
        Me.T_transaction_manuelleDataGridView = New System.Windows.Forms.DataGridView()
        Me.DataGridViewTextBoxColumn10 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn3 = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.VcompteBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.DataGridViewTextBoxColumn5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn6 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn7 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn8 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn9 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.id_t_transaction_manuelle = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Login = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.T_transaction_manuelleTableAdapter = New CLI.CLIDataSetTableAdapters.T_transaction_manuelleTableAdapter()
        Me.V_compteTableAdapter = New CLI.CLIDataSetTableAdapters.V_compteTableAdapter()
        Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
        CType(Me.T_transaction_manuelleBindingNavigator, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.T_transaction_manuelleBindingNavigator.SuspendLayout()
        CType(Me.T_transaction_manuelleBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CLIDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.T_transaction_manuelleDataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.VcompteBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'T_transaction_manuelleBindingNavigator
        '
        Me.T_transaction_manuelleBindingNavigator.AddNewItem = Me.BindingNavigatorAddNewItem
        Me.T_transaction_manuelleBindingNavigator.BindingSource = Me.T_transaction_manuelleBindingSource
        Me.T_transaction_manuelleBindingNavigator.CountItem = Me.BindingNavigatorCountItem
        Me.T_transaction_manuelleBindingNavigator.DeleteItem = Me.BindingNavigatorDeleteItem
        Me.T_transaction_manuelleBindingNavigator.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BindingNavigatorMoveFirstItem, Me.BindingNavigatorMovePreviousItem, Me.BindingNavigatorSeparator, Me.BindingNavigatorPositionItem, Me.BindingNavigatorCountItem, Me.BindingNavigatorSeparator1, Me.BindingNavigatorMoveNextItem, Me.BindingNavigatorMoveLastItem, Me.BindingNavigatorSeparator2, Me.BindingNavigatorAddNewItem, Me.BindingNavigatorDeleteItem, Me.T_transaction_manuelleBindingNavigatorSaveItem})
        Me.T_transaction_manuelleBindingNavigator.Location = New System.Drawing.Point(0, 0)
        Me.T_transaction_manuelleBindingNavigator.MoveFirstItem = Me.BindingNavigatorMoveFirstItem
        Me.T_transaction_manuelleBindingNavigator.MoveLastItem = Me.BindingNavigatorMoveLastItem
        Me.T_transaction_manuelleBindingNavigator.MoveNextItem = Me.BindingNavigatorMoveNextItem
        Me.T_transaction_manuelleBindingNavigator.MovePreviousItem = Me.BindingNavigatorMovePreviousItem
        Me.T_transaction_manuelleBindingNavigator.Name = "T_transaction_manuelleBindingNavigator"
        Me.T_transaction_manuelleBindingNavigator.PositionItem = Me.BindingNavigatorPositionItem
        Me.T_transaction_manuelleBindingNavigator.Size = New System.Drawing.Size(1043, 25)
        Me.T_transaction_manuelleBindingNavigator.TabIndex = 0
        Me.T_transaction_manuelleBindingNavigator.Text = "BindingNavigator1"
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
        'T_transaction_manuelleBindingSource
        '
        Me.T_transaction_manuelleBindingSource.DataMember = "T_transaction_manuelle"
        Me.T_transaction_manuelleBindingSource.DataSource = Me.CLIDataSet
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
        Me.BindingNavigatorPositionItem.Name = "BindingNavigatorPositionItem"
        Me.BindingNavigatorPositionItem.Size = New System.Drawing.Size(50, 23)
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
        'T_transaction_manuelleBindingNavigatorSaveItem
        '
        Me.T_transaction_manuelleBindingNavigatorSaveItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.T_transaction_manuelleBindingNavigatorSaveItem.Image = CType(resources.GetObject("T_transaction_manuelleBindingNavigatorSaveItem.Image"), System.Drawing.Image)
        Me.T_transaction_manuelleBindingNavigatorSaveItem.Name = "T_transaction_manuelleBindingNavigatorSaveItem"
        Me.T_transaction_manuelleBindingNavigatorSaveItem.Size = New System.Drawing.Size(23, 22)
        Me.T_transaction_manuelleBindingNavigatorSaveItem.Text = "Enregistrer les données"
        '
        'T_transaction_manuelleDataGridView
        '
        Me.T_transaction_manuelleDataGridView.AutoGenerateColumns = False
        Me.T_transaction_manuelleDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.T_transaction_manuelleDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.T_transaction_manuelleDataGridView.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewTextBoxColumn10, Me.DataGridViewTextBoxColumn3, Me.DataGridViewTextBoxColumn5, Me.DataGridViewTextBoxColumn6, Me.DataGridViewTextBoxColumn7, Me.DataGridViewTextBoxColumn8, Me.DataGridViewTextBoxColumn9, Me.DataGridViewTextBoxColumn4, Me.DataGridViewTextBoxColumn2, Me.id_t_transaction_manuelle, Me.Login})
        Me.T_transaction_manuelleDataGridView.DataSource = Me.T_transaction_manuelleBindingSource
        Me.T_transaction_manuelleDataGridView.Dock = System.Windows.Forms.DockStyle.Fill
        Me.T_transaction_manuelleDataGridView.Location = New System.Drawing.Point(0, 25)
        Me.T_transaction_manuelleDataGridView.Name = "T_transaction_manuelleDataGridView"
        Me.T_transaction_manuelleDataGridView.Size = New System.Drawing.Size(1043, 446)
        Me.T_transaction_manuelleDataGridView.TabIndex = 1
        '
        'DataGridViewTextBoxColumn10
        '
        Me.DataGridViewTextBoxColumn10.DataPropertyName = "Date_encaissement"
        Me.DataGridViewTextBoxColumn10.HeaderText = "Date encaissement"
        Me.DataGridViewTextBoxColumn10.Name = "DataGridViewTextBoxColumn10"
        Me.DataGridViewTextBoxColumn10.Width = 113
        '
        'DataGridViewTextBoxColumn3
        '
        Me.DataGridViewTextBoxColumn3.DataPropertyName = "Num Compte"
        Me.DataGridViewTextBoxColumn3.DataSource = Me.VcompteBindingSource
        Me.DataGridViewTextBoxColumn3.DisplayMember = "libelle"
        Me.DataGridViewTextBoxColumn3.HeaderText = "Num Compte"
        Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
        Me.DataGridViewTextBoxColumn3.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridViewTextBoxColumn3.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.DataGridViewTextBoxColumn3.ValueMember = "id_t_compte"
        Me.DataGridViewTextBoxColumn3.Width = 86
        '
        'VcompteBindingSource
        '
        Me.VcompteBindingSource.DataMember = "V_compte"
        Me.VcompteBindingSource.DataSource = Me.CLIDataSet
        '
        'DataGridViewTextBoxColumn5
        '
        Me.DataGridViewTextBoxColumn5.DataPropertyName = "Montant"
        Me.DataGridViewTextBoxColumn5.HeaderText = "Montant"
        Me.DataGridViewTextBoxColumn5.Name = "DataGridViewTextBoxColumn5"
        Me.DataGridViewTextBoxColumn5.Width = 71
        '
        'DataGridViewTextBoxColumn6
        '
        Me.DataGridViewTextBoxColumn6.DataPropertyName = "Prix fournisseur"
        Me.DataGridViewTextBoxColumn6.HeaderText = "Prix fournisseur"
        Me.DataGridViewTextBoxColumn6.Name = "DataGridViewTextBoxColumn6"
        Me.DataGridViewTextBoxColumn6.Width = 95
        '
        'DataGridViewTextBoxColumn7
        '
        Me.DataGridViewTextBoxColumn7.DataPropertyName = "Marge"
        Me.DataGridViewTextBoxColumn7.HeaderText = "Marge"
        Me.DataGridViewTextBoxColumn7.Name = "DataGridViewTextBoxColumn7"
        Me.DataGridViewTextBoxColumn7.Width = 62
        '
        'DataGridViewTextBoxColumn8
        '
        Me.DataGridViewTextBoxColumn8.DataPropertyName = "Description"
        Me.DataGridViewTextBoxColumn8.HeaderText = "Description"
        Me.DataGridViewTextBoxColumn8.Name = "DataGridViewTextBoxColumn8"
        Me.DataGridViewTextBoxColumn8.Width = 85
        '
        'DataGridViewTextBoxColumn9
        '
        Me.DataGridViewTextBoxColumn9.DataPropertyName = "id_t_commande_vente"
        Me.DataGridViewTextBoxColumn9.HeaderText = "ID Commande vente"
        Me.DataGridViewTextBoxColumn9.Name = "DataGridViewTextBoxColumn9"
        Me.DataGridViewTextBoxColumn9.Width = 118
        '
        'DataGridViewTextBoxColumn4
        '
        Me.DataGridViewTextBoxColumn4.DataPropertyName = "libelle"
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.Silver
        Me.DataGridViewTextBoxColumn4.DefaultCellStyle = DataGridViewCellStyle1
        Me.DataGridViewTextBoxColumn4.HeaderText = "libelle"
        Me.DataGridViewTextBoxColumn4.Name = "DataGridViewTextBoxColumn4"
        Me.DataGridViewTextBoxColumn4.ReadOnly = True
        Me.DataGridViewTextBoxColumn4.Visible = False
        Me.DataGridViewTextBoxColumn4.Width = 58
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.DataPropertyName = "dateTransaction"
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.Silver
        Me.DataGridViewTextBoxColumn2.DefaultCellStyle = DataGridViewCellStyle2
        Me.DataGridViewTextBoxColumn2.HeaderText = "Date système"
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        Me.DataGridViewTextBoxColumn2.ReadOnly = True
        Me.DataGridViewTextBoxColumn2.Width = 88
        '
        'id_t_transaction_manuelle
        '
        Me.id_t_transaction_manuelle.DataPropertyName = "id_t_transaction_manuelle"
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.Silver
        Me.id_t_transaction_manuelle.DefaultCellStyle = DataGridViewCellStyle3
        Me.id_t_transaction_manuelle.HeaderText = "ID Transaction"
        Me.id_t_transaction_manuelle.Name = "id_t_transaction_manuelle"
        Me.id_t_transaction_manuelle.ReadOnly = True
        Me.id_t_transaction_manuelle.Width = 94
        '
        'Login
        '
        Me.Login.DataPropertyName = "Login"
        DataGridViewCellStyle4.BackColor = System.Drawing.Color.Silver
        Me.Login.DefaultCellStyle = DataGridViewCellStyle4
        Me.Login.HeaderText = "Login"
        Me.Login.Name = "Login"
        Me.Login.ReadOnly = True
        Me.Login.Width = 58
        '
        'T_transaction_manuelleTableAdapter
        '
        Me.T_transaction_manuelleTableAdapter.ClearBeforeFill = True
        '
        'V_compteTableAdapter
        '
        Me.V_compteTableAdapter.ClearBeforeFill = True
        '
        'ErrorProvider1
        '
        Me.ErrorProvider1.ContainerControl = Me
        '
        'FormTransactionManuelle
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1043, 471)
        Me.Controls.Add(Me.T_transaction_manuelleDataGridView)
        Me.Controls.Add(Me.T_transaction_manuelleBindingNavigator)
        Me.Name = "FormTransactionManuelle"
        Me.Text = "Correction erreur de caisse"
        CType(Me.T_transaction_manuelleBindingNavigator, System.ComponentModel.ISupportInitialize).EndInit()
        Me.T_transaction_manuelleBindingNavigator.ResumeLayout(False)
        Me.T_transaction_manuelleBindingNavigator.PerformLayout()
        CType(Me.T_transaction_manuelleBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CLIDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.T_transaction_manuelleDataGridView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.VcompteBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents CLIDataSet As CLI.CLIDataSet
    Friend WithEvents T_transaction_manuelleBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents T_transaction_manuelleTableAdapter As CLI.CLIDataSetTableAdapters.T_transaction_manuelleTableAdapter
    Friend WithEvents T_transaction_manuelleBindingNavigator As System.Windows.Forms.BindingNavigator
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
    Friend WithEvents T_transaction_manuelleBindingNavigatorSaveItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents T_transaction_manuelleDataGridView As System.Windows.Forms.DataGridView
    Friend WithEvents VcompteBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents V_compteTableAdapter As CLI.CLIDataSetTableAdapters.V_compteTableAdapter
    Friend WithEvents DataGridViewTextBoxColumn10 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn3 As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn5 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn6 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn7 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn8 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn9 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents id_t_transaction_manuelle As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Login As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
End Class
