<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormModeReglement
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormModeReglement))
        Me.T_ModeReglementBindingNavigator = New System.Windows.Forms.BindingNavigator(Me.components)
        Me.T_ModeReglementBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.CLIDataSet = New CLI.CLIDataSet
        Me.BindingNavigatorCountItem = New System.Windows.Forms.ToolStripLabel
        Me.BindingNavigatorSeparator = New System.Windows.Forms.ToolStripSeparator
        Me.BindingNavigatorPositionItem = New System.Windows.Forms.ToolStripTextBox
        Me.BindingNavigatorSeparator1 = New System.Windows.Forms.ToolStripSeparator
        Me.BindingNavigatorSeparator2 = New System.Windows.Forms.ToolStripSeparator
        Me.T_ParamDataGridView = New System.Windows.Forms.DataGridView
        Me.T_modeReglementTableAdapter = New CLI.CLIDataSetTableAdapters.T_modeReglementTableAdapter
        Me.IdTModeReglementDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.LibelleDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DelaiDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.FinmoisDataGridViewCheckBoxColumn = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Me.JourmoisDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.NbpaiementDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.TriDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.BindingNavigatorAddNewItem = New System.Windows.Forms.ToolStripButton
        Me.BindingNavigatorDeleteItem = New System.Windows.Forms.ToolStripButton
        Me.BindingNavigatorMoveFirstItem = New System.Windows.Forms.ToolStripButton
        Me.BindingNavigatorMovePreviousItem = New System.Windows.Forms.ToolStripButton
        Me.BindingNavigatorMoveNextItem = New System.Windows.Forms.ToolStripButton
        Me.BindingNavigatorMoveLastItem = New System.Windows.Forms.ToolStripButton
        Me.T_ParamBindingNavigatorSaveItem = New System.Windows.Forms.ToolStripButton
        CType(Me.T_ModeReglementBindingNavigator, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.T_ModeReglementBindingNavigator.SuspendLayout()
        CType(Me.T_ModeReglementBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CLIDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.T_ParamDataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'T_ModeReglementBindingNavigator
        '
        Me.T_ModeReglementBindingNavigator.AddNewItem = Me.BindingNavigatorAddNewItem
        Me.T_ModeReglementBindingNavigator.BindingSource = Me.T_ModeReglementBindingSource
        Me.T_ModeReglementBindingNavigator.CountItem = Me.BindingNavigatorCountItem
        Me.T_ModeReglementBindingNavigator.DeleteItem = Me.BindingNavigatorDeleteItem
        Me.T_ModeReglementBindingNavigator.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BindingNavigatorMoveFirstItem, Me.BindingNavigatorMovePreviousItem, Me.BindingNavigatorSeparator, Me.BindingNavigatorPositionItem, Me.BindingNavigatorCountItem, Me.BindingNavigatorSeparator1, Me.BindingNavigatorMoveNextItem, Me.BindingNavigatorMoveLastItem, Me.BindingNavigatorSeparator2, Me.BindingNavigatorAddNewItem, Me.BindingNavigatorDeleteItem, Me.T_ParamBindingNavigatorSaveItem})
        Me.T_ModeReglementBindingNavigator.Location = New System.Drawing.Point(0, 0)
        Me.T_ModeReglementBindingNavigator.MoveFirstItem = Me.BindingNavigatorMoveFirstItem
        Me.T_ModeReglementBindingNavigator.MoveLastItem = Me.BindingNavigatorMoveLastItem
        Me.T_ModeReglementBindingNavigator.MoveNextItem = Me.BindingNavigatorMoveNextItem
        Me.T_ModeReglementBindingNavigator.MovePreviousItem = Me.BindingNavigatorMovePreviousItem
        Me.T_ModeReglementBindingNavigator.Name = "T_ModeReglementBindingNavigator"
        Me.T_ModeReglementBindingNavigator.PositionItem = Me.BindingNavigatorPositionItem
        Me.T_ModeReglementBindingNavigator.Size = New System.Drawing.Size(868, 25)
        Me.T_ModeReglementBindingNavigator.TabIndex = 0
        Me.T_ModeReglementBindingNavigator.Text = "BindingNavigator1"
        '
        'T_ModeReglementBindingSource
        '
        Me.T_ModeReglementBindingSource.DataMember = "T_modeReglement"
        Me.T_ModeReglementBindingSource.DataSource = Me.CLIDataSet
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
        'BindingNavigatorSeparator2
        '
        Me.BindingNavigatorSeparator2.Name = "BindingNavigatorSeparator2"
        Me.BindingNavigatorSeparator2.Size = New System.Drawing.Size(6, 25)
        '
        'T_ParamDataGridView
        '
        Me.T_ParamDataGridView.AutoGenerateColumns = False
        Me.T_ParamDataGridView.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.IdTModeReglementDataGridViewTextBoxColumn, Me.LibelleDataGridViewTextBoxColumn, Me.DelaiDataGridViewTextBoxColumn, Me.FinmoisDataGridViewCheckBoxColumn, Me.JourmoisDataGridViewTextBoxColumn, Me.NbpaiementDataGridViewTextBoxColumn, Me.TriDataGridViewTextBoxColumn})
        Me.T_ParamDataGridView.DataSource = Me.T_ModeReglementBindingSource
        Me.T_ParamDataGridView.Dock = System.Windows.Forms.DockStyle.Fill
        Me.T_ParamDataGridView.Location = New System.Drawing.Point(0, 25)
        Me.T_ParamDataGridView.Name = "T_ParamDataGridView"
        Me.T_ParamDataGridView.Size = New System.Drawing.Size(868, 417)
        Me.T_ParamDataGridView.TabIndex = 1
        '
        'T_modeReglementTableAdapter
        '
        Me.T_modeReglementTableAdapter.ClearBeforeFill = True
        '
        'IdTModeReglementDataGridViewTextBoxColumn
        '
        Me.IdTModeReglementDataGridViewTextBoxColumn.DataPropertyName = "Id_T_ModeReglement"
        Me.IdTModeReglementDataGridViewTextBoxColumn.HeaderText = "Id_T_ModeReglement"
        Me.IdTModeReglementDataGridViewTextBoxColumn.Name = "IdTModeReglementDataGridViewTextBoxColumn"
        Me.IdTModeReglementDataGridViewTextBoxColumn.ReadOnly = True
        '
        'LibelleDataGridViewTextBoxColumn
        '
        Me.LibelleDataGridViewTextBoxColumn.DataPropertyName = "Libelle"
        Me.LibelleDataGridViewTextBoxColumn.HeaderText = "Libelle"
        Me.LibelleDataGridViewTextBoxColumn.Name = "LibelleDataGridViewTextBoxColumn"
        '
        'DelaiDataGridViewTextBoxColumn
        '
        Me.DelaiDataGridViewTextBoxColumn.DataPropertyName = "delai"
        Me.DelaiDataGridViewTextBoxColumn.HeaderText = "delai"
        Me.DelaiDataGridViewTextBoxColumn.Name = "DelaiDataGridViewTextBoxColumn"
        '
        'FinmoisDataGridViewCheckBoxColumn
        '
        Me.FinmoisDataGridViewCheckBoxColumn.DataPropertyName = "fin_mois"
        Me.FinmoisDataGridViewCheckBoxColumn.HeaderText = "fin_mois"
        Me.FinmoisDataGridViewCheckBoxColumn.Name = "FinmoisDataGridViewCheckBoxColumn"
        '
        'JourmoisDataGridViewTextBoxColumn
        '
        Me.JourmoisDataGridViewTextBoxColumn.DataPropertyName = "jour_mois"
        Me.JourmoisDataGridViewTextBoxColumn.HeaderText = "jour_mois"
        Me.JourmoisDataGridViewTextBoxColumn.Name = "JourmoisDataGridViewTextBoxColumn"
        '
        'NbpaiementDataGridViewTextBoxColumn
        '
        Me.NbpaiementDataGridViewTextBoxColumn.DataPropertyName = "nb_paiement"
        Me.NbpaiementDataGridViewTextBoxColumn.HeaderText = "nb_paiement"
        Me.NbpaiementDataGridViewTextBoxColumn.Name = "NbpaiementDataGridViewTextBoxColumn"
        '
        'TriDataGridViewTextBoxColumn
        '
        Me.TriDataGridViewTextBoxColumn.DataPropertyName = "tri"
        Me.TriDataGridViewTextBoxColumn.HeaderText = "tri"
        Me.TriDataGridViewTextBoxColumn.Name = "TriDataGridViewTextBoxColumn"
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
        'T_ParamBindingNavigatorSaveItem
        '
        Me.T_ParamBindingNavigatorSaveItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.T_ParamBindingNavigatorSaveItem.Image = CType(resources.GetObject("T_ParamBindingNavigatorSaveItem.Image"), System.Drawing.Image)
        Me.T_ParamBindingNavigatorSaveItem.Name = "T_ParamBindingNavigatorSaveItem"
        Me.T_ParamBindingNavigatorSaveItem.Size = New System.Drawing.Size(23, 22)
        Me.T_ParamBindingNavigatorSaveItem.Text = "Enregistrer les données"
        '
        'FormModeReglement
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(868, 442)
        Me.Controls.Add(Me.T_ParamDataGridView)
        Me.Controls.Add(Me.T_ModeReglementBindingNavigator)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "FormModeReglement"
        Me.Text = "Gestion des modes de règlement"
        CType(Me.T_ModeReglementBindingNavigator, System.ComponentModel.ISupportInitialize).EndInit()
        Me.T_ModeReglementBindingNavigator.ResumeLayout(False)
        Me.T_ModeReglementBindingNavigator.PerformLayout()
        CType(Me.T_ModeReglementBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CLIDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.T_ParamDataGridView, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents CLIDataSet As CLI.CLIDataSet
    Friend WithEvents T_ModeReglementBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents T_ModeReglementBindingNavigator As System.Windows.Forms.BindingNavigator
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
    Friend WithEvents T_modeReglementTableAdapter As CLI.CLIDataSetTableAdapters.T_modeReglementTableAdapter
    Friend WithEvents IdTModeReglementDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents LibelleDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DelaiDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents FinmoisDataGridViewCheckBoxColumn As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents JourmoisDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents NbpaiementDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TriDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
