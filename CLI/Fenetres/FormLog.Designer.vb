<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FormLog
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.Id = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.LogType = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.LogAssociatedRecordId = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.LogAssociatedRecordType = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.LogDateTime = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.LogEntry = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.LogDetail = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.FichierToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ImporterToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ExporterToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.LogVersionApi = New System.Windows.Forms.DataGridViewTextBoxColumn()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.MenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.AllowUserToDeleteRows = False
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Id, Me.LogType, Me.LogAssociatedRecordId, Me.LogAssociatedRecordType, Me.LogDateTime, Me.LogEntry, Me.LogDetail, Me.LogVersionApi})
        Me.DataGridView1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DataGridView1.Location = New System.Drawing.Point(0, 24)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.ReadOnly = True
        Me.DataGridView1.Size = New System.Drawing.Size(1056, 426)
        Me.DataGridView1.TabIndex = 0
        '
        'Id
        '
        Me.Id.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.Id.DataPropertyName = "Id"
        Me.Id.HeaderText = "Id"
        Me.Id.Name = "Id"
        Me.Id.ReadOnly = True
        Me.Id.Width = 41
        '
        'LogType
        '
        Me.LogType.DataPropertyName = "LogType"
        Me.LogType.HeaderText = "LogType"
        Me.LogType.Name = "LogType"
        Me.LogType.ReadOnly = True
        '
        'LogAssociatedRecordId
        '
        Me.LogAssociatedRecordId.DataPropertyName = "LogAssociatedRecordId"
        Me.LogAssociatedRecordId.HeaderText = "LogAssociatedRecordId"
        Me.LogAssociatedRecordId.Name = "LogAssociatedRecordId"
        Me.LogAssociatedRecordId.ReadOnly = True
        '
        'LogAssociatedRecordType
        '
        Me.LogAssociatedRecordType.DataPropertyName = "LogAssociatedRecordType"
        Me.LogAssociatedRecordType.HeaderText = "LogAssociatedRecordType"
        Me.LogAssociatedRecordType.Name = "LogAssociatedRecordType"
        Me.LogAssociatedRecordType.ReadOnly = True
        '
        'LogDateTime
        '
        Me.LogDateTime.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.LogDateTime.DataPropertyName = "LogDateTime"
        Me.LogDateTime.HeaderText = "LogDateTime"
        Me.LogDateTime.Name = "LogDateTime"
        Me.LogDateTime.ReadOnly = True
        Me.LogDateTime.Width = 96
        '
        'LogEntry
        '
        Me.LogEntry.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.LogEntry.DataPropertyName = "LogEntry"
        Me.LogEntry.HeaderText = "LogEntry"
        Me.LogEntry.Name = "LogEntry"
        Me.LogEntry.ReadOnly = True
        Me.LogEntry.Width = 74
        '
        'LogDetail
        '
        Me.LogDetail.DataPropertyName = "LogDetail"
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.LogDetail.DefaultCellStyle = DataGridViewCellStyle1
        Me.LogDetail.HeaderText = "LogDetail"
        Me.LogDetail.MinimumWidth = 500
        Me.LogDetail.Name = "LogDetail"
        Me.LogDetail.ReadOnly = True
        Me.LogDetail.Width = 500
        '
        'MenuStrip1
        '
        Me.MenuStrip1.ImageScalingSize = New System.Drawing.Size(32, 32)
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FichierToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(1056, 24)
        Me.MenuStrip1.TabIndex = 1
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'FichierToolStripMenuItem
        '
        Me.FichierToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ImporterToolStripMenuItem, Me.ExporterToolStripMenuItem})
        Me.FichierToolStripMenuItem.Name = "FichierToolStripMenuItem"
        Me.FichierToolStripMenuItem.Size = New System.Drawing.Size(54, 20)
        Me.FichierToolStripMenuItem.Text = "Fichier"
        '
        'ImporterToolStripMenuItem
        '
        Me.ImporterToolStripMenuItem.Name = "ImporterToolStripMenuItem"
        Me.ImporterToolStripMenuItem.Size = New System.Drawing.Size(120, 22)
        Me.ImporterToolStripMenuItem.Text = "Importer"
        '
        'ExporterToolStripMenuItem
        '
        Me.ExporterToolStripMenuItem.Name = "ExporterToolStripMenuItem"
        Me.ExporterToolStripMenuItem.Size = New System.Drawing.Size(120, 22)
        Me.ExporterToolStripMenuItem.Text = "Exporter"
        '
        'LogVersionApi
        '
        Me.LogVersionApi.HeaderText = "LogVersionApi"
        Me.LogVersionApi.Name = "LogVersionApi"
        Me.LogVersionApi.ReadOnly = True
        '
        'FormLog
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1056, 450)
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.MenuStrip1)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "FormLog"
        Me.Text = "Log synchro"
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents Id As DataGridViewTextBoxColumn
    Friend WithEvents LogType As DataGridViewTextBoxColumn
    Friend WithEvents LogAssociatedRecordId As DataGridViewTextBoxColumn
    Friend WithEvents LogAssociatedRecordType As DataGridViewTextBoxColumn
    Friend WithEvents LogDateTime As DataGridViewTextBoxColumn
    Friend WithEvents LogEntry As DataGridViewTextBoxColumn
    Friend WithEvents LogDetail As DataGridViewTextBoxColumn
    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents FichierToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ImporterToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ExporterToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents LogVersionApi As DataGridViewTextBoxColumn
End Class
