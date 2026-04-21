<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormJournalCaisse
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim ReportDataSource1 As Microsoft.Reporting.WinForms.ReportDataSource = New Microsoft.Reporting.WinForms.ReportDataSource()
        Dim ReportDataSource2 As Microsoft.Reporting.WinForms.ReportDataSource = New Microsoft.Reporting.WinForms.ReportDataSource()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormJournalCaisse))
        Me.V_journal_caisseBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.CLIDataSet = New CLI.CLIDataSet()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.I_debut = New System.Windows.Forms.DateTimePicker()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.I_fin = New System.Windows.Forms.DateTimePicker()
        Me.BT_Go = New System.Windows.Forms.Button()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.ReportViewer1 = New Microsoft.Reporting.WinForms.ReportViewer()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.ReportViewer2 = New Microsoft.Reporting.WinForms.ReportViewer()
        Me.V_journal_caisseTableAdapter = New CLI.CLIDataSetTableAdapters.V_journal_caisseTableAdapter()
        Me.V_journal_caisse_1TableAdapter1 = New CLI.CLIDataSetTableAdapters.V_journal_caisse_1TableAdapter()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.I_Caisse = New System.Windows.Forms.ComboBox()
        Me.I_Comptes5 = New System.Windows.Forms.ComboBox()
        CType(Me.V_journal_caisseBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CLIDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        Me.SuspendLayout()
        '
        'V_journal_caisseBindingSource
        '
        Me.V_journal_caisseBindingSource.DataMember = "V_journal_caisse"
        Me.V_journal_caisseBindingSource.DataSource = Me.CLIDataSet
        '
        'CLIDataSet
        '
        Me.CLIDataSet.DataSetName = "CLIDataSet"
        Me.CLIDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(2, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(21, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Du"
        '
        'I_debut
        '
        Me.I_debut.Enabled = False
        Me.I_debut.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.I_debut.Location = New System.Drawing.Point(29, 5)
        Me.I_debut.Name = "I_debut"
        Me.I_debut.Size = New System.Drawing.Size(91, 20)
        Me.I_debut.TabIndex = 2
        Me.I_debut.Value = New Date(2009, 12, 20, 0, 0, 0, 0)
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(125, 9)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(20, 13)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Au"
        '
        'I_fin
        '
        Me.I_fin.Enabled = False
        Me.I_fin.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.I_fin.Location = New System.Drawing.Point(151, 5)
        Me.I_fin.Name = "I_fin"
        Me.I_fin.Size = New System.Drawing.Size(85, 20)
        Me.I_fin.TabIndex = 2
        '
        'BT_Go
        '
        Me.BT_Go.Location = New System.Drawing.Point(577, 2)
        Me.BT_Go.Name = "BT_Go"
        Me.BT_Go.Size = New System.Drawing.Size(75, 23)
        Me.BT_Go.TabIndex = 3
        Me.BT_Go.Text = "Go"
        Me.BT_Go.UseVisualStyleBackColor = True
        '
        'TabControl1
        '
        Me.TabControl1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Location = New System.Drawing.Point(5, 41)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(890, 568)
        Me.TabControl1.TabIndex = 4
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.ReportViewer1)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(882, 542)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Detail"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'ReportViewer1
        '
        Me.ReportViewer1.Dock = System.Windows.Forms.DockStyle.Fill
        ReportDataSource1.Name = "CLIDataSet_V_journal_caisse"
        ReportDataSource1.Value = Me.V_journal_caisseBindingSource
        Me.ReportViewer1.LocalReport.DataSources.Add(ReportDataSource1)
        Me.ReportViewer1.LocalReport.ReportEmbeddedResource = "CLI.Journal_Caisse_Detail.rdlc"
        Me.ReportViewer1.Location = New System.Drawing.Point(3, 3)
        Me.ReportViewer1.Name = "ReportViewer1"
        Me.ReportViewer1.Size = New System.Drawing.Size(876, 536)
        Me.ReportViewer1.TabIndex = 1
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.ReportViewer2)
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(882, 542)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Synthèse"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'ReportViewer2
        '
        Me.ReportViewer2.Dock = System.Windows.Forms.DockStyle.Fill
        ReportDataSource2.Name = "CLIDataSet_V_journal_caisse"
        ReportDataSource2.Value = Me.V_journal_caisseBindingSource
        Me.ReportViewer2.LocalReport.DataSources.Add(ReportDataSource2)
        Me.ReportViewer2.LocalReport.ReportEmbeddedResource = "CLI.Journal_Caisse_Synthese.rdlc"
        Me.ReportViewer2.Location = New System.Drawing.Point(3, 3)
        Me.ReportViewer2.Name = "ReportViewer2"
        Me.ReportViewer2.Size = New System.Drawing.Size(876, 536)
        Me.ReportViewer2.TabIndex = 2
        '
        'V_journal_caisseTableAdapter
        '
        Me.V_journal_caisseTableAdapter.ClearBeforeFill = True
        '
        'V_journal_caisse_1TableAdapter1
        '
        Me.V_journal_caisse_1TableAdapter1.ClearBeforeFill = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(240, 5)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(38, 13)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "Caisse"
        '
        'I_Caisse
        '
        Me.I_Caisse.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.I_Caisse.FormattingEnabled = True
        Me.I_Caisse.Items.AddRange(New Object() {"<Tout>", "1", "2"})
        Me.I_Caisse.Location = New System.Drawing.Point(284, 4)
        Me.I_Caisse.Margin = New System.Windows.Forms.Padding(2)
        Me.I_Caisse.Name = "I_Caisse"
        Me.I_Caisse.Size = New System.Drawing.Size(62, 21)
        Me.I_Caisse.TabIndex = 6
        '
        'I_Comptes5
        '
        Me.I_Comptes5.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.I_Comptes5.FormattingEnabled = True
        Me.I_Comptes5.Items.AddRange(New Object() {"<Tout>", "Comptes 5 uniquement", "Sauf les comptes 5"})
        Me.I_Comptes5.Location = New System.Drawing.Point(361, 4)
        Me.I_Comptes5.Margin = New System.Windows.Forms.Padding(2)
        Me.I_Comptes5.Name = "I_Comptes5"
        Me.I_Comptes5.Size = New System.Drawing.Size(211, 21)
        Me.I_Comptes5.TabIndex = 6
        '
        'FormJournalCaisse
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(842, 536)
        Me.Controls.Add(Me.I_Comptes5)
        Me.Controls.Add(Me.I_Caisse)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.BT_Go)
        Me.Controls.Add(Me.I_fin)
        Me.Controls.Add(Me.I_debut)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "FormJournalCaisse"
        Me.Text = "Journal de Caisse"
        CType(Me.V_journal_caisseBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CLIDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage2.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents V_journal_caisseBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents CLIDataSet As CLI.CLIDataSet
    Friend WithEvents V_journal_caisseTableAdapter As CLI.CLIDataSetTableAdapters.V_journal_caisseTableAdapter
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents I_debut As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents I_fin As System.Windows.Forms.DateTimePicker
    Friend WithEvents BT_Go As System.Windows.Forms.Button
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents ReportViewer1 As Microsoft.Reporting.WinForms.ReportViewer
    Friend WithEvents ReportViewer2 As Microsoft.Reporting.WinForms.ReportViewer
    Friend WithEvents V_journal_caisse_1TableAdapter1 As CLIDataSetTableAdapters.V_journal_caisse_1TableAdapter
    Friend WithEvents Label3 As Label
    Friend WithEvents I_Caisse As ComboBox
    Friend WithEvents I_Comptes5 As ComboBox
End Class
