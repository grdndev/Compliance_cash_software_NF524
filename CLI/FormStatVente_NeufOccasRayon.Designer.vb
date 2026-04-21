<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormStatVente_neufoccasRayon
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
        Me.components = New System.ComponentModel.Container
        Dim ReportDataSource1 As Microsoft.Reporting.WinForms.ReportDataSource = New Microsoft.Reporting.WinForms.ReportDataSource
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormStatVente_neufoccasRayon))
        Me.V_Stats_vente1BindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.CLIDataSet = New CLI.CLIDataSet
        Me.ReportViewer1 = New Microsoft.Reporting.WinForms.ReportViewer
        Me.Label1 = New System.Windows.Forms.Label
        Me.I_debut = New System.Windows.Forms.DateTimePicker
        Me.Label2 = New System.Windows.Forms.Label
        Me.I_fin = New System.Windows.Forms.DateTimePicker
        Me.BT_Go = New System.Windows.Forms.Button
        Me.V_Stats_vente1TableAdapter = New CLI.CLIDataSetTableAdapters.V_Stats_vente1TableAdapter
        CType(Me.V_Stats_vente1BindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CLIDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.ReportViewer1.LocalReport.ReportEmbeddedResource = "CLI.CA_NeufOccasRayon.rdlc"
        Me.ReportViewer1.Location = New System.Drawing.Point(0, 38)
        Me.ReportViewer1.Name = "ReportViewer1"
        Me.ReportViewer1.Size = New System.Drawing.Size(899, 573)
        Me.ReportViewer1.TabIndex = 0
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
        Me.I_fin.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.I_fin.Location = New System.Drawing.Point(151, 5)
        Me.I_fin.Name = "I_fin"
        Me.I_fin.Size = New System.Drawing.Size(85, 20)
        Me.I_fin.TabIndex = 2
        '
        'BT_Go
        '
        Me.BT_Go.Location = New System.Drawing.Point(240, 4)
        Me.BT_Go.Name = "BT_Go"
        Me.BT_Go.Size = New System.Drawing.Size(75, 23)
        Me.BT_Go.TabIndex = 3
        Me.BT_Go.Text = "Go"
        Me.BT_Go.UseVisualStyleBackColor = True
        '
        'V_Stats_vente1TableAdapter
        '
        Me.V_Stats_vente1TableAdapter.ClearBeforeFill = True
        '
        'FormStatVente_neufoccasRayon
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(899, 611)
        Me.Controls.Add(Me.BT_Go)
        Me.Controls.Add(Me.I_fin)
        Me.Controls.Add(Me.I_debut)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.ReportViewer1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "FormStatVente_neufoccasRayon"
        Me.Text = "CA par Rayon (neuf et occas)"
        CType(Me.V_Stats_vente1BindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CLIDataSet, System.ComponentModel.ISupportInitialize).EndInit()
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
End Class
