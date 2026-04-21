<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormStatVente
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormStatVente))
        Me.V_Stats_vente1BindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.CLIDataSet = New CLI.CLIDataSet()
        Me.ReportViewer1 = New Microsoft.Reporting.WinForms.ReportViewer()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.I_debut = New System.Windows.Forms.DateTimePicker()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.I_fin = New System.Windows.Forms.DateTimePicker()
        Me.BT_Go = New System.Windows.Forms.Button()
        Me.I_rapport = New System.Windows.Forms.ComboBox()
        Me.V_Stats_vente1TableAdapter = New CLI.CLIDataSetTableAdapters.V_Stats_vente1TableAdapter()
        Me.T_Article_versionBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.T_Article_versionTableAdapter = New CLI.CLIDataSetTableAdapters.T_Article_versionTableAdapter()
        CType(Me.V_Stats_vente1BindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CLIDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.T_Article_versionBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'V_Stats_vente1BindingSource
        '
        Me.V_Stats_vente1BindingSource.DataMember = "V_Stats_vente1"
        Me.V_Stats_vente1BindingSource.DataSource = Me.CLIDataSet
        '
        'CLIDataSet
        '
        Me.CLIDataSet.DataSetName = "CLIDataSet"
        Me.CLIDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'ReportViewer1
        '
        Me.ReportViewer1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        ReportDataSource1.Name = "CLIDataSet_V_Stats_vente1"
        ReportDataSource1.Value = Me.V_Stats_vente1BindingSource
        Me.ReportViewer1.LocalReport.DataSources.Add(ReportDataSource1)
        Me.ReportViewer1.LocalReport.ReportEmbeddedResource = "CLI.CA_NeufOccas.rdlc"
        Me.ReportViewer1.Location = New System.Drawing.Point(0, 73)
        Me.ReportViewer1.Margin = New System.Windows.Forms.Padding(6, 6, 6, 6)
        Me.ReportViewer1.Name = "ReportViewer1"
        Me.ReportViewer1.Size = New System.Drawing.Size(1796, 1100)
        Me.ReportViewer1.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(4, 21)
        Me.Label1.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(39, 25)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Du"
        '
        'I_debut
        '
        Me.I_debut.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.I_debut.Location = New System.Drawing.Point(58, 13)
        Me.I_debut.Margin = New System.Windows.Forms.Padding(6, 6, 6, 6)
        Me.I_debut.Name = "I_debut"
        Me.I_debut.Size = New System.Drawing.Size(178, 31)
        Me.I_debut.TabIndex = 2
        Me.I_debut.Value = New Date(2009, 12, 20, 0, 0, 0, 0)
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(250, 21)
        Me.Label2.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(38, 25)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Au"
        '
        'I_fin
        '
        Me.I_fin.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.I_fin.Location = New System.Drawing.Point(302, 13)
        Me.I_fin.Margin = New System.Windows.Forms.Padding(6, 6, 6, 6)
        Me.I_fin.Name = "I_fin"
        Me.I_fin.Size = New System.Drawing.Size(166, 31)
        Me.I_fin.TabIndex = 2
        '
        'BT_Go
        '
        Me.BT_Go.Location = New System.Drawing.Point(1000, 12)
        Me.BT_Go.Margin = New System.Windows.Forms.Padding(6, 6, 6, 6)
        Me.BT_Go.Name = "BT_Go"
        Me.BT_Go.Size = New System.Drawing.Size(150, 44)
        Me.BT_Go.TabIndex = 3
        Me.BT_Go.Text = "Go"
        Me.BT_Go.UseVisualStyleBackColor = True
        '
        'I_rapport
        '
        Me.I_rapport.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.I_rapport.FormattingEnabled = True
        Me.I_rapport.Location = New System.Drawing.Point(484, 13)
        Me.I_rapport.Margin = New System.Windows.Forms.Padding(6, 6, 6, 6)
        Me.I_rapport.Name = "I_rapport"
        Me.I_rapport.Size = New System.Drawing.Size(482, 33)
        Me.I_rapport.TabIndex = 4
        '
        'V_Stats_vente1TableAdapter
        '
        Me.V_Stats_vente1TableAdapter.ClearBeforeFill = True
        '
        'T_Article_versionBindingSource
        '
        Me.T_Article_versionBindingSource.DataMember = "T_Article_version"
        Me.T_Article_versionBindingSource.DataSource = Me.CLIDataSet
        '
        'T_Article_versionTableAdapter
        '
        Me.T_Article_versionTableAdapter.ClearBeforeFill = True
        '
        'FormStatVente
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(12.0!, 25.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1798, 1175)
        Me.Controls.Add(Me.I_rapport)
        Me.Controls.Add(Me.BT_Go)
        Me.Controls.Add(Me.I_fin)
        Me.Controls.Add(Me.I_debut)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.ReportViewer1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(6, 6, 6, 6)
        Me.Name = "FormStatVente"
        Me.Text = "Statistiques (CA)"
        CType(Me.V_Stats_vente1BindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CLIDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.T_Article_versionBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ReportViewer1 As Microsoft.Reporting.WinForms.ReportViewer
    Friend WithEvents CLIDataSet As CLI.CLIDataSet
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents I_debut As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents I_fin As System.Windows.Forms.DateTimePicker
    Friend WithEvents BT_Go As System.Windows.Forms.Button
    Friend WithEvents V_Stats_vente1BindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents V_Stats_vente1TableAdapter As CLI.CLIDataSetTableAdapters.V_Stats_vente1TableAdapter
    Friend WithEvents I_rapport As System.Windows.Forms.ComboBox
    Friend WithEvents T_Article_versionBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents T_Article_versionTableAdapter As CLI.CLIDataSetTableAdapters.T_Article_versionTableAdapter
End Class
