<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormFamille
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormFamille))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.T_FamilleBindingNavigator = New System.Windows.Forms.BindingNavigator(Me.components)
        Me.BindingNavigatorAddNewItem = New System.Windows.Forms.ToolStripButton()
        Me.T_FamilleBindingSource = New System.Windows.Forms.BindingSource(Me.components)
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
        Me.T_FamilleBindingNavigatorSaveItem = New System.Windows.Forms.ToolStripButton()
        Me.T_FamilleDataGridView = New System.Windows.Forms.DataGridView()
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.BoutiqueTexte = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.BoutiqueCuber = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.BoutiqueOccasionTexte = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.BoutiqueOccasionCuber = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.BoutiquePromotionTexte = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.BoutiquePromotionCuber = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.T_FamilleTableAdapter = New CLI.CLIDataSetTableAdapters.T_FamilleTableAdapter()
        CType(Me.T_FamilleBindingNavigator, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.T_FamilleBindingNavigator.SuspendLayout()
        CType(Me.T_FamilleBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CLIDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.T_FamilleDataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'T_FamilleBindingNavigator
        '
        Me.T_FamilleBindingNavigator.AddNewItem = Me.BindingNavigatorAddNewItem
        Me.T_FamilleBindingNavigator.BindingSource = Me.T_FamilleBindingSource
        Me.T_FamilleBindingNavigator.CountItem = Me.BindingNavigatorCountItem
        Me.T_FamilleBindingNavigator.DeleteItem = Me.BindingNavigatorDeleteItem
        Me.T_FamilleBindingNavigator.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BindingNavigatorMoveFirstItem, Me.BindingNavigatorMovePreviousItem, Me.BindingNavigatorSeparator, Me.BindingNavigatorPositionItem, Me.BindingNavigatorCountItem, Me.BindingNavigatorSeparator1, Me.BindingNavigatorMoveNextItem, Me.BindingNavigatorMoveLastItem, Me.BindingNavigatorSeparator2, Me.BindingNavigatorAddNewItem, Me.BindingNavigatorDeleteItem, Me.T_FamilleBindingNavigatorSaveItem})
        Me.T_FamilleBindingNavigator.Location = New System.Drawing.Point(0, 0)
        Me.T_FamilleBindingNavigator.MoveFirstItem = Me.BindingNavigatorMoveFirstItem
        Me.T_FamilleBindingNavigator.MoveLastItem = Me.BindingNavigatorMoveLastItem
        Me.T_FamilleBindingNavigator.MoveNextItem = Me.BindingNavigatorMoveNextItem
        Me.T_FamilleBindingNavigator.MovePreviousItem = Me.BindingNavigatorMovePreviousItem
        Me.T_FamilleBindingNavigator.Name = "T_FamilleBindingNavigator"
        Me.T_FamilleBindingNavigator.PositionItem = Me.BindingNavigatorPositionItem
        Me.T_FamilleBindingNavigator.Size = New System.Drawing.Size(1243, 25)
        Me.T_FamilleBindingNavigator.TabIndex = 0
        Me.T_FamilleBindingNavigator.Text = "BindingNavigator1"
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
        'T_FamilleBindingSource
        '
        Me.T_FamilleBindingSource.DataMember = "T_Famille"
        Me.T_FamilleBindingSource.DataSource = Me.CLIDataSet
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
        'T_FamilleBindingNavigatorSaveItem
        '
        Me.T_FamilleBindingNavigatorSaveItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.T_FamilleBindingNavigatorSaveItem.Image = CType(resources.GetObject("T_FamilleBindingNavigatorSaveItem.Image"), System.Drawing.Image)
        Me.T_FamilleBindingNavigatorSaveItem.Name = "T_FamilleBindingNavigatorSaveItem"
        Me.T_FamilleBindingNavigatorSaveItem.Size = New System.Drawing.Size(23, 22)
        Me.T_FamilleBindingNavigatorSaveItem.Text = "Enregistrer les données"
        '
        'T_FamilleDataGridView
        '
        Me.T_FamilleDataGridView.AutoGenerateColumns = False
        Me.T_FamilleDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.T_FamilleDataGridView.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewTextBoxColumn1, Me.DataGridViewTextBoxColumn2, Me.DataGridViewTextBoxColumn3, Me.BoutiqueTexte, Me.BoutiqueCuber, Me.BoutiqueOccasionTexte, Me.BoutiqueOccasionCuber, Me.BoutiquePromotionTexte, Me.BoutiquePromotionCuber})
        Me.T_FamilleDataGridView.DataSource = Me.T_FamilleBindingSource
        Me.T_FamilleDataGridView.Dock = System.Windows.Forms.DockStyle.Fill
        Me.T_FamilleDataGridView.Location = New System.Drawing.Point(0, 25)
        Me.T_FamilleDataGridView.Name = "T_FamilleDataGridView"
        Me.T_FamilleDataGridView.Size = New System.Drawing.Size(1243, 252)
        Me.T_FamilleDataGridView.TabIndex = 1
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.DataPropertyName = "ID_T_Famille"
        Me.DataGridViewTextBoxColumn1.HeaderText = "ID_T_Famille"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.ReadOnly = True
        Me.DataGridViewTextBoxColumn1.Visible = False
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.DataPropertyName = "Libelle"
        Me.DataGridViewTextBoxColumn2.HeaderText = "Libelle"
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        '
        'DataGridViewTextBoxColumn3
        '
        Me.DataGridViewTextBoxColumn3.DataPropertyName = "tri"
        Me.DataGridViewTextBoxColumn3.HeaderText = "tri"
        Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
        '
        'BoutiqueTexte
        '
        Me.BoutiqueTexte.DataPropertyName = "BoutiqueTexte"
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.BoutiqueTexte.DefaultCellStyle = DataGridViewCellStyle1
        Me.BoutiqueTexte.HeaderText = "BoutiqueTexte"
        Me.BoutiqueTexte.Name = "BoutiqueTexte"
        '
        'BoutiqueCuber
        '
        Me.BoutiqueCuber.DataPropertyName = "BoutiqueCuber"
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.BoutiqueCuber.DefaultCellStyle = DataGridViewCellStyle2
        Me.BoutiqueCuber.HeaderText = "BoutiqueCuber"
        Me.BoutiqueCuber.Name = "BoutiqueCuber"
        '
        'BoutiqueOccasionTexte
        '
        Me.BoutiqueOccasionTexte.DataPropertyName = "BoutiqueOccasionTexte"
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.BoutiqueOccasionTexte.DefaultCellStyle = DataGridViewCellStyle3
        Me.BoutiqueOccasionTexte.HeaderText = "BoutiqueOccasionTexte"
        Me.BoutiqueOccasionTexte.Name = "BoutiqueOccasionTexte"
        '
        'BoutiqueOccasionCuber
        '
        Me.BoutiqueOccasionCuber.DataPropertyName = "BoutiqueOccasionCuber"
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.BoutiqueOccasionCuber.DefaultCellStyle = DataGridViewCellStyle4
        Me.BoutiqueOccasionCuber.HeaderText = "BoutiqueOccasionCuber"
        Me.BoutiqueOccasionCuber.Name = "BoutiqueOccasionCuber"
        '
        'BoutiquePromotionTexte
        '
        Me.BoutiquePromotionTexte.DataPropertyName = "BoutiquePromotionTexte"
        DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.BoutiquePromotionTexte.DefaultCellStyle = DataGridViewCellStyle5
        Me.BoutiquePromotionTexte.HeaderText = "BoutiquePromotionTexte"
        Me.BoutiquePromotionTexte.Name = "BoutiquePromotionTexte"
        '
        'BoutiquePromotionCuber
        '
        Me.BoutiquePromotionCuber.DataPropertyName = "BoutiquePromotionCuber"
        DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.BoutiquePromotionCuber.DefaultCellStyle = DataGridViewCellStyle6
        Me.BoutiquePromotionCuber.HeaderText = "BoutiquePromotionCuber"
        Me.BoutiquePromotionCuber.Name = "BoutiquePromotionCuber"
        '
        'T_FamilleTableAdapter
        '
        Me.T_FamilleTableAdapter.ClearBeforeFill = True
        '
        'FormFamille
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoScroll = True
        Me.ClientSize = New System.Drawing.Size(1243, 277)
        Me.Controls.Add(Me.T_FamilleDataGridView)
        Me.Controls.Add(Me.T_FamilleBindingNavigator)
        Me.Name = "FormFamille"
        Me.Text = "Familles d'articles"
        CType(Me.T_FamilleBindingNavigator, System.ComponentModel.ISupportInitialize).EndInit()
        Me.T_FamilleBindingNavigator.ResumeLayout(False)
        Me.T_FamilleBindingNavigator.PerformLayout()
        CType(Me.T_FamilleBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CLIDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.T_FamilleDataGridView, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents CLIDataSet As CLI.CLIDataSet
    Friend WithEvents T_FamilleBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents T_FamilleTableAdapter As CLI.CLIDataSetTableAdapters.T_FamilleTableAdapter
    Friend WithEvents T_FamilleBindingNavigator As System.Windows.Forms.BindingNavigator
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
    Friend WithEvents T_FamilleBindingNavigatorSaveItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents T_FamilleDataGridView As System.Windows.Forms.DataGridView
    Friend WithEvents DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents BoutiqueTexte As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents BoutiqueCuber As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents BoutiqueOccasionTexte As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents BoutiqueOccasionCuber As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents BoutiquePromotionTexte As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents BoutiquePromotionCuber As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
