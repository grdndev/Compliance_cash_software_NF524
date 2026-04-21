<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FormChequeCadeauAuto
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
        Me.T_CodePromoDataGridView = New System.Windows.Forms.DataGridView()
        Me.DuDateTimePicker = New System.Windows.Forms.DateTimePicker()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.AuDateTimePicker = New System.Windows.Forms.DateTimePicker()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.FamilleComboBox = New System.Windows.Forms.ComboBox()
        Me.SousFamilleComboBox = New System.Windows.Forms.ComboBox()
        Me.TypeComboBox = New System.Windows.Forms.ComboBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.RemiseTextBox = New System.Windows.Forms.TextBox()
        Me.ValideCheckBox = New System.Windows.Forms.CheckBox()
        Me.BT_Save = New System.Windows.Forms.Button()
        Me.NeufOccazToutComboBox = New System.Windows.Forms.ComboBox()
        Me.BT_Annuler = New System.Windows.Forms.Button()
        Me.IDTextBox = New System.Windows.Forms.TextBox()
        Me.BT_supprimer = New System.Windows.Forms.Button()
        Me.DetailPanel = New System.Windows.Forms.Panel()
        Me.DescriptionTextBox = New System.Windows.Forms.TextBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.ListPanel = New System.Windows.Forms.Panel()
        Me.BT_Ajouter = New System.Windows.Forms.Button()
        Me.T_ChequeCadeauAutoBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.CLIDataSet = New CLI.CLIDataSet()
        Me.T_ChequeCadeauAutoTableAdapter = New CLI.CLIDataSetTableAdapters.T_ChequeCadeauAutoTableAdapter()
        Me.I_Id_t_ChequeCadeauAuto = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Description = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Du = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Au = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PourcentageRemise = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Valide = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        CType(Me.T_CodePromoDataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.DetailPanel.SuspendLayout()
        Me.ListPanel.SuspendLayout()
        CType(Me.T_ChequeCadeauAutoBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CLIDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'T_CodePromoDataGridView
        '
        Me.T_CodePromoDataGridView.AllowUserToAddRows = False
        Me.T_CodePromoDataGridView.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.T_CodePromoDataGridView.AutoGenerateColumns = False
        Me.T_CodePromoDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.T_CodePromoDataGridView.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.T_CodePromoDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.T_CodePromoDataGridView.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.I_Id_t_ChequeCadeauAuto, Me.Description, Me.Du, Me.Au, Me.PourcentageRemise, Me.Valide})
        Me.T_CodePromoDataGridView.DataSource = Me.T_ChequeCadeauAutoBindingSource
        Me.T_CodePromoDataGridView.Location = New System.Drawing.Point(0, 36)
        Me.T_CodePromoDataGridView.Margin = New System.Windows.Forms.Padding(2)
        Me.T_CodePromoDataGridView.Name = "T_CodePromoDataGridView"
        Me.T_CodePromoDataGridView.RowTemplate.Height = 33
        Me.T_CodePromoDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.T_CodePromoDataGridView.Size = New System.Drawing.Size(1279, 524)
        Me.T_CodePromoDataGridView.TabIndex = 1
        '
        'DuDateTimePicker
        '
        Me.DuDateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DuDateTimePicker.Location = New System.Drawing.Point(123, 36)
        Me.DuDateTimePicker.Margin = New System.Windows.Forms.Padding(2)
        Me.DuDateTimePicker.Name = "DuDateTimePicker"
        Me.DuDateTimePicker.Size = New System.Drawing.Size(187, 20)
        Me.DuDateTimePicker.TabIndex = 4
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(98, 39)
        Me.Label2.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(21, 13)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Du"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(99, 58)
        Me.Label3.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(20, 13)
        Me.Label3.TabIndex = 3
        Me.Label3.Text = "Au"
        '
        'AuDateTimePicker
        '
        Me.AuDateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.AuDateTimePicker.Location = New System.Drawing.Point(123, 55)
        Me.AuDateTimePicker.Margin = New System.Windows.Forms.Padding(2)
        Me.AuDateTimePicker.Name = "AuDateTimePicker"
        Me.AuDateTimePicker.Size = New System.Drawing.Size(187, 20)
        Me.AuDateTimePicker.TabIndex = 4
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(80, 80)
        Me.Label4.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(39, 13)
        Me.Label4.TabIndex = 5
        Me.Label4.Text = "Famille"
        '
        'FamilleComboBox
        '
        Me.FamilleComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.FamilleComboBox.FormattingEnabled = True
        Me.FamilleComboBox.Location = New System.Drawing.Point(123, 80)
        Me.FamilleComboBox.Margin = New System.Windows.Forms.Padding(2)
        Me.FamilleComboBox.Name = "FamilleComboBox"
        Me.FamilleComboBox.Size = New System.Drawing.Size(187, 21)
        Me.FamilleComboBox.TabIndex = 6
        '
        'SousFamilleComboBox
        '
        Me.SousFamilleComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.SousFamilleComboBox.FormattingEnabled = True
        Me.SousFamilleComboBox.Location = New System.Drawing.Point(123, 101)
        Me.SousFamilleComboBox.Margin = New System.Windows.Forms.Padding(2)
        Me.SousFamilleComboBox.Name = "SousFamilleComboBox"
        Me.SousFamilleComboBox.Size = New System.Drawing.Size(187, 21)
        Me.SousFamilleComboBox.TabIndex = 6
        '
        'TypeComboBox
        '
        Me.TypeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.TypeComboBox.FormattingEnabled = True
        Me.TypeComboBox.Location = New System.Drawing.Point(123, 121)
        Me.TypeComboBox.Margin = New System.Windows.Forms.Padding(2)
        Me.TypeComboBox.Name = "TypeComboBox"
        Me.TypeComboBox.Size = New System.Drawing.Size(187, 21)
        Me.TypeComboBox.TabIndex = 6
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(77, 175)
        Me.Label5.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(42, 13)
        Me.Label5.TabIndex = 7
        Me.Label5.Text = "Remise"
        '
        'RemiseTextBox
        '
        Me.RemiseTextBox.Location = New System.Drawing.Point(123, 172)
        Me.RemiseTextBox.Margin = New System.Windows.Forms.Padding(2)
        Me.RemiseTextBox.Name = "RemiseTextBox"
        Me.RemiseTextBox.Size = New System.Drawing.Size(187, 20)
        Me.RemiseTextBox.TabIndex = 8
        '
        'ValideCheckBox
        '
        Me.ValideCheckBox.AutoSize = True
        Me.ValideCheckBox.Location = New System.Drawing.Point(123, 223)
        Me.ValideCheckBox.Margin = New System.Windows.Forms.Padding(2)
        Me.ValideCheckBox.Name = "ValideCheckBox"
        Me.ValideCheckBox.Size = New System.Drawing.Size(64, 17)
        Me.ValideCheckBox.TabIndex = 9
        Me.ValideCheckBox.Text = "Valide ?"
        Me.ValideCheckBox.UseVisualStyleBackColor = True
        '
        'BT_Save
        '
        Me.BT_Save.Location = New System.Drawing.Point(123, 247)
        Me.BT_Save.Margin = New System.Windows.Forms.Padding(2)
        Me.BT_Save.Name = "BT_Save"
        Me.BT_Save.Size = New System.Drawing.Size(100, 29)
        Me.BT_Save.TabIndex = 10
        Me.BT_Save.Text = "Sauvegarder"
        Me.BT_Save.UseVisualStyleBackColor = True
        '
        'NeufOccazToutComboBox
        '
        Me.NeufOccazToutComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.NeufOccazToutComboBox.FormattingEnabled = True
        Me.NeufOccazToutComboBox.Location = New System.Drawing.Point(123, 146)
        Me.NeufOccazToutComboBox.Margin = New System.Windows.Forms.Padding(2)
        Me.NeufOccazToutComboBox.Name = "NeufOccazToutComboBox"
        Me.NeufOccazToutComboBox.Size = New System.Drawing.Size(187, 21)
        Me.NeufOccazToutComboBox.TabIndex = 6
        '
        'BT_Annuler
        '
        Me.BT_Annuler.Location = New System.Drawing.Point(335, 247)
        Me.BT_Annuler.Margin = New System.Windows.Forms.Padding(2)
        Me.BT_Annuler.Name = "BT_Annuler"
        Me.BT_Annuler.Size = New System.Drawing.Size(92, 29)
        Me.BT_Annuler.TabIndex = 12
        Me.BT_Annuler.Text = "Annuler"
        Me.BT_Annuler.UseVisualStyleBackColor = True
        '
        'IDTextBox
        '
        Me.IDTextBox.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.IDTextBox.Location = New System.Drawing.Point(123, 12)
        Me.IDTextBox.Margin = New System.Windows.Forms.Padding(2)
        Me.IDTextBox.Name = "IDTextBox"
        Me.IDTextBox.ReadOnly = True
        Me.IDTextBox.Size = New System.Drawing.Size(187, 20)
        Me.IDTextBox.TabIndex = 2
        '
        'BT_supprimer
        '
        Me.BT_supprimer.Location = New System.Drawing.Point(235, 247)
        Me.BT_supprimer.Margin = New System.Windows.Forms.Padding(2)
        Me.BT_supprimer.Name = "BT_supprimer"
        Me.BT_supprimer.Size = New System.Drawing.Size(92, 29)
        Me.BT_supprimer.TabIndex = 12
        Me.BT_supprimer.Text = "Supprimer"
        Me.BT_supprimer.UseVisualStyleBackColor = True
        '
        'DetailPanel
        '
        Me.DetailPanel.Controls.Add(Me.DescriptionTextBox)
        Me.DetailPanel.Controls.Add(Me.IDTextBox)
        Me.DetailPanel.Controls.Add(Me.BT_supprimer)
        Me.DetailPanel.Controls.Add(Me.BT_Annuler)
        Me.DetailPanel.Controls.Add(Me.Label2)
        Me.DetailPanel.Controls.Add(Me.BT_Save)
        Me.DetailPanel.Controls.Add(Me.DuDateTimePicker)
        Me.DetailPanel.Controls.Add(Me.ValideCheckBox)
        Me.DetailPanel.Controls.Add(Me.Label14)
        Me.DetailPanel.Controls.Add(Me.Label13)
        Me.DetailPanel.Controls.Add(Me.Label3)
        Me.DetailPanel.Controls.Add(Me.RemiseTextBox)
        Me.DetailPanel.Controls.Add(Me.AuDateTimePicker)
        Me.DetailPanel.Controls.Add(Me.Label12)
        Me.DetailPanel.Controls.Add(Me.Label5)
        Me.DetailPanel.Controls.Add(Me.Label11)
        Me.DetailPanel.Controls.Add(Me.Label7)
        Me.DetailPanel.Controls.Add(Me.Label6)
        Me.DetailPanel.Controls.Add(Me.Label4)
        Me.DetailPanel.Controls.Add(Me.NeufOccazToutComboBox)
        Me.DetailPanel.Controls.Add(Me.FamilleComboBox)
        Me.DetailPanel.Controls.Add(Me.SousFamilleComboBox)
        Me.DetailPanel.Controls.Add(Me.TypeComboBox)
        Me.DetailPanel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DetailPanel.Location = New System.Drawing.Point(0, 0)
        Me.DetailPanel.Name = "DetailPanel"
        Me.DetailPanel.Size = New System.Drawing.Size(1279, 560)
        Me.DetailPanel.TabIndex = 13
        Me.DetailPanel.Visible = False
        '
        'DescriptionTextBox
        '
        Me.DescriptionTextBox.Location = New System.Drawing.Point(123, 198)
        Me.DescriptionTextBox.Name = "DescriptionTextBox"
        Me.DescriptionTextBox.Size = New System.Drawing.Size(326, 20)
        Me.DescriptionTextBox.TabIndex = 13
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(314, 39)
        Me.Label14.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(43, 13)
        Me.Label14.TabIndex = 3
        Me.Label14.Text = "à 00:00"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(314, 58)
        Me.Label13.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(43, 13)
        Me.Label13.TabIndex = 3
        Me.Label13.Text = "à 00:00"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(59, 201)
        Me.Label12.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(60, 13)
        Me.Label12.TabIndex = 7
        Me.Label12.Text = "Description"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(14, 149)
        Me.Label11.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(105, 13)
        Me.Label11.TabIndex = 5
        Me.Label11.Text = "Neuf / Occaz / Tout"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(88, 124)
        Me.Label7.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(31, 13)
        Me.Label7.TabIndex = 5
        Me.Label7.Text = "Type"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(53, 104)
        Me.Label6.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(66, 13)
        Me.Label6.TabIndex = 5
        Me.Label6.Text = "Sous Famille"
        '
        'ListPanel
        '
        Me.ListPanel.Controls.Add(Me.BT_Ajouter)
        Me.ListPanel.Controls.Add(Me.T_CodePromoDataGridView)
        Me.ListPanel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ListPanel.Location = New System.Drawing.Point(0, 0)
        Me.ListPanel.Name = "ListPanel"
        Me.ListPanel.Size = New System.Drawing.Size(1279, 560)
        Me.ListPanel.TabIndex = 14
        '
        'BT_Ajouter
        '
        Me.BT_Ajouter.Location = New System.Drawing.Point(4, 4)
        Me.BT_Ajouter.Name = "BT_Ajouter"
        Me.BT_Ajouter.Size = New System.Drawing.Size(96, 28)
        Me.BT_Ajouter.TabIndex = 2
        Me.BT_Ajouter.Text = "Ajouter"
        Me.BT_Ajouter.UseVisualStyleBackColor = True
        '
        'T_ChequeCadeauAutoBindingSource
        '
        Me.T_ChequeCadeauAutoBindingSource.DataMember = "T_ChequeCadeauAuto"
        Me.T_ChequeCadeauAutoBindingSource.DataSource = Me.CLIDataSet
        '
        'CLIDataSet
        '
        Me.CLIDataSet.DataSetName = "CLIDataSet"
        Me.CLIDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'T_ChequeCadeauAutoTableAdapter
        '
        Me.T_ChequeCadeauAutoTableAdapter.ClearBeforeFill = True
        '
        'I_Id_t_ChequeCadeauAuto
        '
        Me.I_Id_t_ChequeCadeauAuto.DataPropertyName = "Id_t_ChequeCadeauAuto"
        Me.I_Id_t_ChequeCadeauAuto.HeaderText = "Id_t_ChequeCadeauAuto"
        Me.I_Id_t_ChequeCadeauAuto.Name = "I_Id_t_ChequeCadeauAuto"
        Me.I_Id_t_ChequeCadeauAuto.ReadOnly = True
        Me.I_Id_t_ChequeCadeauAuto.Visible = False
        Me.I_Id_t_ChequeCadeauAuto.Width = 152
        '
        'Description
        '
        Me.Description.DataPropertyName = "Description"
        Me.Description.HeaderText = "Description"
        Me.Description.Name = "Description"
        Me.Description.ReadOnly = True
        Me.Description.Width = 85
        '
        'Du
        '
        Me.Du.DataPropertyName = "Du"
        Me.Du.HeaderText = "Du"
        Me.Du.Name = "Du"
        Me.Du.ReadOnly = True
        Me.Du.Width = 46
        '
        'Au
        '
        Me.Au.DataPropertyName = "Au"
        Me.Au.HeaderText = "Au"
        Me.Au.Name = "Au"
        Me.Au.ReadOnly = True
        Me.Au.Width = 45
        '
        'PourcentageRemise
        '
        Me.PourcentageRemise.DataPropertyName = "PourcentageRemise"
        Me.PourcentageRemise.HeaderText = "PourcentageRemise"
        Me.PourcentageRemise.Name = "PourcentageRemise"
        Me.PourcentageRemise.ReadOnly = True
        Me.PourcentageRemise.Width = 128
        '
        'Valide
        '
        Me.Valide.DataPropertyName = "Valide"
        Me.Valide.HeaderText = "Valide"
        Me.Valide.Name = "Valide"
        Me.Valide.ReadOnly = True
        Me.Valide.Width = 42
        '
        'FormChequeCadeauAuto
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1279, 560)
        Me.Controls.Add(Me.ListPanel)
        Me.Controls.Add(Me.DetailPanel)
        Me.Margin = New System.Windows.Forms.Padding(2)
        Me.Name = "FormChequeCadeauAuto"
        Me.Text = "Gestion des chèques cadeaux auto"
        CType(Me.T_CodePromoDataGridView, System.ComponentModel.ISupportInitialize).EndInit()
        Me.DetailPanel.ResumeLayout(False)
        Me.DetailPanel.PerformLayout()
        Me.ListPanel.ResumeLayout(False)
        CType(Me.T_ChequeCadeauAutoBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CLIDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents CLIDataSet As CLIDataSet
    Friend WithEvents T_ChequeCadeauAutoBindingSource As BindingSource
    Friend WithEvents T_CodePromoDataGridView As DataGridView
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents AuDateTimePicker As DateTimePicker
    Friend WithEvents Label4 As Label
    Friend WithEvents FamilleComboBox As ComboBox
    Friend WithEvents SousFamilleComboBox As ComboBox
    Friend WithEvents TypeComboBox As ComboBox
    Friend WithEvents Label5 As Label
    Friend WithEvents RemiseTextBox As TextBox
    Friend WithEvents ValideCheckBox As CheckBox
    Friend WithEvents BT_Save As Button
    Friend WithEvents NeufOccazToutComboBox As ComboBox
    Friend WithEvents BT_Annuler As Button
    Friend WithEvents IDTextBox As TextBox
    Friend WithEvents BT_supprimer As Button
    Friend WithEvents DetailPanel As Panel
    Friend WithEvents ListPanel As Panel
    Friend WithEvents BT_Ajouter As Button
    Friend WithEvents Label11 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents DescriptionTextBox As TextBox
    Friend WithEvents Label12 As Label
    Friend WithEvents DuDateTimePicker As DateTimePicker
    Friend WithEvents Label14 As Label
    Friend WithEvents Label13 As Label
    Friend WithEvents T_ChequeCadeauAutoTableAdapter As CLIDataSetTableAdapters.T_ChequeCadeauAutoTableAdapter
    Friend WithEvents I_Id_t_ChequeCadeauAuto As DataGridViewTextBoxColumn
    Friend WithEvents Description As DataGridViewTextBoxColumn
    Friend WithEvents Du As DataGridViewTextBoxColumn
    Friend WithEvents Au As DataGridViewTextBoxColumn
    Friend WithEvents PourcentageRemise As DataGridViewTextBoxColumn
    Friend WithEvents Valide As DataGridViewCheckBoxColumn
End Class
