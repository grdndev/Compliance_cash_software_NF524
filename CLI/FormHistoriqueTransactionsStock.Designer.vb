<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormHistoriqueTransactionsStock
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
        Me.CLIDataSet = New CLI.CLIDataSet()
        Me.T_Article_StockBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.T_Article_StockTableAdapter = New CLI.CLIDataSetTableAdapters.T_Article_StockTableAdapter()
        Me.T_Article_StockDataGridView = New System.Windows.Forms.DataGridView()
        Me.LabelDu = New System.Windows.Forms.Label()
        Me.LabelAu = New System.Windows.Forms.Label()
        Me.DateTimePickerDu = New System.Windows.Forms.DateTimePicker()
        Me.DateTimePickerAu = New System.Windows.Forms.DateTimePicker()
        Me.BT_OK = New System.Windows.Forms.Button()
        Me.LabelEntree = New System.Windows.Forms.Label()
        Me.LabelSortie = New System.Windows.Forms.Label()
        Me.TextBoxTotalEntree = New System.Windows.Forms.TextBox()
        Me.TextBoxTotalSortie = New System.Windows.Forms.TextBox()
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Site = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn6 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn7 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        CType(Me.CLIDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.T_Article_StockBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.T_Article_StockDataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'CLIDataSet
        '
        Me.CLIDataSet.DataSetName = "CLIDataSet"
        Me.CLIDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'T_Article_StockBindingSource
        '
        Me.T_Article_StockBindingSource.DataMember = "T_Article_Stock"
        Me.T_Article_StockBindingSource.DataSource = Me.CLIDataSet
        '
        'T_Article_StockTableAdapter
        '
        Me.T_Article_StockTableAdapter.ClearBeforeFill = True
        '
        'T_Article_StockDataGridView
        '
        Me.T_Article_StockDataGridView.AllowUserToAddRows = False
        Me.T_Article_StockDataGridView.AllowUserToDeleteRows = False
        Me.T_Article_StockDataGridView.AllowUserToResizeColumns = False
        Me.T_Article_StockDataGridView.AllowUserToResizeRows = False
        Me.T_Article_StockDataGridView.AutoGenerateColumns = False
        Me.T_Article_StockDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.T_Article_StockDataGridView.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewTextBoxColumn1, Me.DataGridViewTextBoxColumn2, Me.DataGridViewTextBoxColumn3, Me.DataGridViewTextBoxColumn4, Me.DataGridViewTextBoxColumn5, Me.Site, Me.DataGridViewTextBoxColumn6, Me.DataGridViewTextBoxColumn7})
        Me.T_Article_StockDataGridView.DataSource = Me.T_Article_StockBindingSource
        Me.T_Article_StockDataGridView.Location = New System.Drawing.Point(0, 35)
        Me.T_Article_StockDataGridView.Name = "T_Article_StockDataGridView"
        Me.T_Article_StockDataGridView.ReadOnly = True
        Me.T_Article_StockDataGridView.RowHeadersVisible = False
        Me.T_Article_StockDataGridView.Size = New System.Drawing.Size(795, 320)
        Me.T_Article_StockDataGridView.TabIndex = 1
        '
        'LabelDu
        '
        Me.LabelDu.AutoSize = True
        Me.LabelDu.Location = New System.Drawing.Point(6, 13)
        Me.LabelDu.Name = "LabelDu"
        Me.LabelDu.Size = New System.Drawing.Size(30, 13)
        Me.LabelDu.TabIndex = 2
        Me.LabelDu.Text = "Du : "
        '
        'LabelAu
        '
        Me.LabelAu.AutoSize = True
        Me.LabelAu.Location = New System.Drawing.Point(139, 13)
        Me.LabelAu.Name = "LabelAu"
        Me.LabelAu.Size = New System.Drawing.Size(29, 13)
        Me.LabelAu.TabIndex = 2
        Me.LabelAu.Text = "Au : "
        '
        'DateTimePickerDu
        '
        Me.DateTimePickerDu.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DateTimePickerDu.Location = New System.Drawing.Point(33, 9)
        Me.DateTimePickerDu.Name = "DateTimePickerDu"
        Me.DateTimePickerDu.Size = New System.Drawing.Size(100, 20)
        Me.DateTimePickerDu.TabIndex = 3
        '
        'DateTimePickerAu
        '
        Me.DateTimePickerAu.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DateTimePickerAu.Location = New System.Drawing.Point(174, 9)
        Me.DateTimePickerAu.Name = "DateTimePickerAu"
        Me.DateTimePickerAu.Size = New System.Drawing.Size(100, 20)
        Me.DateTimePickerAu.TabIndex = 3
        '
        'BT_OK
        '
        Me.BT_OK.Location = New System.Drawing.Point(280, 9)
        Me.BT_OK.Name = "BT_OK"
        Me.BT_OK.Size = New System.Drawing.Size(55, 21)
        Me.BT_OK.TabIndex = 4
        Me.BT_OK.Text = "OK"
        Me.BT_OK.UseVisualStyleBackColor = True
        '
        'LabelEntree
        '
        Me.LabelEntree.AutoSize = True
        Me.LabelEntree.Location = New System.Drawing.Point(353, 12)
        Me.LabelEntree.Name = "LabelEntree"
        Me.LabelEntree.Size = New System.Drawing.Size(76, 13)
        Me.LabelEntree.TabIndex = 5
        Me.LabelEntree.Text = "Total Entrées :"
        '
        'LabelSortie
        '
        Me.LabelSortie.AutoSize = True
        Me.LabelSortie.Location = New System.Drawing.Point(529, 13)
        Me.LabelSortie.Name = "LabelSortie"
        Me.LabelSortie.Size = New System.Drawing.Size(72, 13)
        Me.LabelSortie.TabIndex = 5
        Me.LabelSortie.Text = "Total Sorties :"
        '
        'TextBoxTotalEntree
        '
        Me.TextBoxTotalEntree.Location = New System.Drawing.Point(431, 9)
        Me.TextBoxTotalEntree.Name = "TextBoxTotalEntree"
        Me.TextBoxTotalEntree.Size = New System.Drawing.Size(92, 20)
        Me.TextBoxTotalEntree.TabIndex = 6
        '
        'TextBoxTotalSortie
        '
        Me.TextBoxTotalSortie.Location = New System.Drawing.Point(599, 9)
        Me.TextBoxTotalSortie.Name = "TextBoxTotalSortie"
        Me.TextBoxTotalSortie.Size = New System.Drawing.Size(92, 20)
        Me.TextBoxTotalSortie.TabIndex = 6
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.DataPropertyName = "ID_t_article_stock"
        Me.DataGridViewTextBoxColumn1.HeaderText = "N°"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.ReadOnly = True
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.DataPropertyName = "ID_t_article_version"
        Me.DataGridViewTextBoxColumn2.HeaderText = "Ref"
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        Me.DataGridViewTextBoxColumn2.ReadOnly = True
        '
        'DataGridViewTextBoxColumn3
        '
        Me.DataGridViewTextBoxColumn3.DataPropertyName = "operation"
        Me.DataGridViewTextBoxColumn3.HeaderText = "Operation"
        Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
        Me.DataGridViewTextBoxColumn3.ReadOnly = True
        '
        'DataGridViewTextBoxColumn4
        '
        Me.DataGridViewTextBoxColumn4.DataPropertyName = "ID_t_commande_vente"
        Me.DataGridViewTextBoxColumn4.HeaderText = "Ref CV"
        Me.DataGridViewTextBoxColumn4.Name = "DataGridViewTextBoxColumn4"
        Me.DataGridViewTextBoxColumn4.ReadOnly = True
        '
        'DataGridViewTextBoxColumn5
        '
        Me.DataGridViewTextBoxColumn5.DataPropertyName = "ID_t_commande_achat"
        Me.DataGridViewTextBoxColumn5.HeaderText = "Ref CA"
        Me.DataGridViewTextBoxColumn5.Name = "DataGridViewTextBoxColumn5"
        Me.DataGridViewTextBoxColumn5.ReadOnly = True
        '
        'Site
        '
        Me.Site.DataPropertyName = "numcaisse"
        Me.Site.HeaderText = "Site"
        Me.Site.Name = "Site"
        Me.Site.ReadOnly = True
        Me.Site.Visible = False
        '
        'DataGridViewTextBoxColumn6
        '
        Me.DataGridViewTextBoxColumn6.DataPropertyName = "Signature"
        Me.DataGridViewTextBoxColumn6.HeaderText = "Signature"
        Me.DataGridViewTextBoxColumn6.Name = "DataGridViewTextBoxColumn6"
        Me.DataGridViewTextBoxColumn6.ReadOnly = True
        '
        'DataGridViewTextBoxColumn7
        '
        Me.DataGridViewTextBoxColumn7.DataPropertyName = "Date"
        Me.DataGridViewTextBoxColumn7.HeaderText = "Date"
        Me.DataGridViewTextBoxColumn7.Name = "DataGridViewTextBoxColumn7"
        Me.DataGridViewTextBoxColumn7.ReadOnly = True
        '
        'FormHistoriqueTransactionsStock
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(797, 355)
        Me.Controls.Add(Me.TextBoxTotalSortie)
        Me.Controls.Add(Me.TextBoxTotalEntree)
        Me.Controls.Add(Me.LabelSortie)
        Me.Controls.Add(Me.LabelEntree)
        Me.Controls.Add(Me.BT_OK)
        Me.Controls.Add(Me.DateTimePickerAu)
        Me.Controls.Add(Me.DateTimePickerDu)
        Me.Controls.Add(Me.LabelAu)
        Me.Controls.Add(Me.LabelDu)
        Me.Controls.Add(Me.T_Article_StockDataGridView)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "FormHistoriqueTransactionsStock"
        Me.Text = "Historique des transactions de stock"
        CType(Me.CLIDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.T_Article_StockBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.T_Article_StockDataGridView, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents CLIDataSet As CLI.CLIDataSet
    Friend WithEvents T_Article_StockBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents T_Article_StockTableAdapter As CLI.CLIDataSetTableAdapters.T_Article_StockTableAdapter
    Friend WithEvents T_Article_StockDataGridView As System.Windows.Forms.DataGridView
    Friend WithEvents LabelDu As System.Windows.Forms.Label
    Friend WithEvents LabelAu As System.Windows.Forms.Label
    Friend WithEvents DateTimePickerDu As System.Windows.Forms.DateTimePicker
    Friend WithEvents DateTimePickerAu As System.Windows.Forms.DateTimePicker
    Friend WithEvents BT_OK As System.Windows.Forms.Button
    Friend WithEvents LabelEntree As System.Windows.Forms.Label
    Friend WithEvents LabelSortie As System.Windows.Forms.Label
    Friend WithEvents TextBoxTotalEntree As System.Windows.Forms.TextBox
    Friend WithEvents TextBoxTotalSortie As System.Windows.Forms.TextBox
    Friend WithEvents DataGridViewTextBoxColumn1 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn3 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn4 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn5 As DataGridViewTextBoxColumn
    Friend WithEvents Site As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn6 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn7 As DataGridViewTextBoxColumn
End Class
