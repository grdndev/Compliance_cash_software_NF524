<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormMoyenPaiement
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormMoyenPaiement))
        Me.T_MoyenPaiementBindingNavigator = New System.Windows.Forms.BindingNavigator(Me.components)
        Me.BindingNavigatorAddNewItem = New System.Windows.Forms.ToolStripButton
        Me.T_MoyenPaiementBindingSource = New System.Windows.Forms.BindingSource(Me.components)
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
        Me.T_ParamBindingNavigatorSaveItem = New System.Windows.Forms.ToolStripButton
        Me.T_ParamDataGridView = New System.Windows.Forms.DataGridView
        Me.T_MoyenPaiementTableAdapter = New CLI.CLIDataSetTableAdapters.T_MoyenPaiementTableAdapter
        Me.IdTMoyenPaiementDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.LibelleDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.TriDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        CType(Me.T_MoyenPaiementBindingNavigator, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.T_MoyenPaiementBindingNavigator.SuspendLayout()
        CType(Me.T_MoyenPaiementBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CLIDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.T_ParamDataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'T_MoyenPaiementBindingNavigator
        '
        Me.T_MoyenPaiementBindingNavigator.AddNewItem = Me.BindingNavigatorAddNewItem
        Me.T_MoyenPaiementBindingNavigator.BindingSource = Me.T_MoyenPaiementBindingSource
        Me.T_MoyenPaiementBindingNavigator.CountItem = Me.BindingNavigatorCountItem
        Me.T_MoyenPaiementBindingNavigator.DeleteItem = Me.BindingNavigatorDeleteItem
        Me.T_MoyenPaiementBindingNavigator.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BindingNavigatorMoveFirstItem, Me.BindingNavigatorMovePreviousItem, Me.BindingNavigatorSeparator, Me.BindingNavigatorPositionItem, Me.BindingNavigatorCountItem, Me.BindingNavigatorSeparator1, Me.BindingNavigatorMoveNextItem, Me.BindingNavigatorMoveLastItem, Me.BindingNavigatorSeparator2, Me.BindingNavigatorAddNewItem, Me.BindingNavigatorDeleteItem, Me.T_ParamBindingNavigatorSaveItem})
        Me.T_MoyenPaiementBindingNavigator.Location = New System.Drawing.Point(0, 0)
        Me.T_MoyenPaiementBindingNavigator.MoveFirstItem = Me.BindingNavigatorMoveFirstItem
        Me.T_MoyenPaiementBindingNavigator.MoveLastItem = Me.BindingNavigatorMoveLastItem
        Me.T_MoyenPaiementBindingNavigator.MoveNextItem = Me.BindingNavigatorMoveNextItem
        Me.T_MoyenPaiementBindingNavigator.MovePreviousItem = Me.BindingNavigatorMovePreviousItem
        Me.T_MoyenPaiementBindingNavigator.Name = "T_MoyenPaiementBindingNavigator"
        Me.T_MoyenPaiementBindingNavigator.PositionItem = Me.BindingNavigatorPositionItem
        Me.T_MoyenPaiementBindingNavigator.Size = New System.Drawing.Size(868, 25)
        Me.T_MoyenPaiementBindingNavigator.TabIndex = 0
        Me.T_MoyenPaiementBindingNavigator.Text = "BindingNavigator1"
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
        'T_MoyenPaiementBindingSource
        '
        Me.T_MoyenPaiementBindingSource.DataMember = "T_MoyenPaiement"
        Me.T_MoyenPaiementBindingSource.DataSource = Me.CLIDataSet
        '
        'CLIDataSet
        '
        Me.CLIDataSet.DataSetName = "CLIDataSet"
        Me.CLIDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'BindingNavigatorCountItem
        '
        Me.BindingNavigatorCountItem.Name = "BindingNavigatorCountItem"
        Me.BindingNavigatorCountItem.Size = New System.Drawing.Size(36, 22)
        Me.BindingNavigatorCountItem.Text = "of {0}"
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
        'T_ParamBindingNavigatorSaveItem
        '
        Me.T_ParamBindingNavigatorSaveItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.T_ParamBindingNavigatorSaveItem.Image = CType(resources.GetObject("T_ParamBindingNavigatorSaveItem.Image"), System.Drawing.Image)
        Me.T_ParamBindingNavigatorSaveItem.Name = "T_ParamBindingNavigatorSaveItem"
        Me.T_ParamBindingNavigatorSaveItem.Size = New System.Drawing.Size(23, 22)
        Me.T_ParamBindingNavigatorSaveItem.Text = "Enregistrer les données"
        '
        'T_ParamDataGridView
        '
        Me.T_ParamDataGridView.AutoGenerateColumns = False
        Me.T_ParamDataGridView.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.IdTMoyenPaiementDataGridViewTextBoxColumn, Me.LibelleDataGridViewTextBoxColumn, Me.TriDataGridViewTextBoxColumn})
        Me.T_ParamDataGridView.DataSource = Me.T_MoyenPaiementBindingSource
        Me.T_ParamDataGridView.Dock = System.Windows.Forms.DockStyle.Fill
        Me.T_ParamDataGridView.Location = New System.Drawing.Point(0, 25)
        Me.T_ParamDataGridView.Name = "T_ParamDataGridView"
        Me.T_ParamDataGridView.Size = New System.Drawing.Size(868, 417)
        Me.T_ParamDataGridView.TabIndex = 1
        '
        'T_MoyenPaiementTableAdapter
        '
        Me.T_MoyenPaiementTableAdapter.ClearBeforeFill = True
        '
        'IdTMoyenPaiementDataGridViewTextBoxColumn
        '
        Me.IdTMoyenPaiementDataGridViewTextBoxColumn.DataPropertyName = "Id_T_MoyenPaiement"
        Me.IdTMoyenPaiementDataGridViewTextBoxColumn.HeaderText = "Id_T_MoyenPaiement"
        Me.IdTMoyenPaiementDataGridViewTextBoxColumn.Name = "IdTMoyenPaiementDataGridViewTextBoxColumn"
        Me.IdTMoyenPaiementDataGridViewTextBoxColumn.ReadOnly = True
        '
        'LibelleDataGridViewTextBoxColumn
        '
        Me.LibelleDataGridViewTextBoxColumn.DataPropertyName = "Libelle"
        Me.LibelleDataGridViewTextBoxColumn.HeaderText = "Libelle"
        Me.LibelleDataGridViewTextBoxColumn.Name = "LibelleDataGridViewTextBoxColumn"
        '
        'TriDataGridViewTextBoxColumn
        '
        Me.TriDataGridViewTextBoxColumn.DataPropertyName = "tri"
        Me.TriDataGridViewTextBoxColumn.HeaderText = "tri"
        Me.TriDataGridViewTextBoxColumn.Name = "TriDataGridViewTextBoxColumn"
        '
        'FormMoyenPaiement
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(868, 442)
        Me.Controls.Add(Me.T_ParamDataGridView)
        Me.Controls.Add(Me.T_MoyenPaiementBindingNavigator)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "FormMoyenPaiement"
        Me.Text = "Gestion des moyens de paiement"
        CType(Me.T_MoyenPaiementBindingNavigator, System.ComponentModel.ISupportInitialize).EndInit()
        Me.T_MoyenPaiementBindingNavigator.ResumeLayout(False)
        Me.T_MoyenPaiementBindingNavigator.PerformLayout()
        CType(Me.T_MoyenPaiementBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CLIDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.T_ParamDataGridView, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents CLIDataSet As CLI.CLIDataSet
    Friend WithEvents T_MoyenPaiementBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents T_MoyenPaiementBindingNavigator As System.Windows.Forms.BindingNavigator
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
    Friend WithEvents T_ParamBindingNavigatorSaveItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents T_ParamDataGridView As System.Windows.Forms.DataGridView
    Friend WithEvents T_MoyenPaiementTableAdapter As CLI.CLIDataSetTableAdapters.T_MoyenPaiementTableAdapter
    Friend WithEvents IdTMoyenPaiementDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents LibelleDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TriDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
