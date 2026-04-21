<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormApiCall
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
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.id = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CreatedDate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Url = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Params = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.HttpMethod = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CallDate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.AllowUserToDeleteRows = False
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.id, Me.CreatedDate, Me.Url, Me.Params, Me.HttpMethod, Me.CallDate})
        Me.DataGridView1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DataGridView1.Location = New System.Drawing.Point(0, 0)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.ReadOnly = True
        Me.DataGridView1.Size = New System.Drawing.Size(800, 450)
        Me.DataGridView1.TabIndex = 0
        '
        'id
        '
        Me.id.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.id.DataPropertyName = "id"
        Me.id.HeaderText = "id"
        Me.id.Name = "id"
        Me.id.ReadOnly = True
        Me.id.Width = 40
        '
        'CreatedDate
        '
        Me.CreatedDate.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.CreatedDate.DataPropertyName = "CreatedDate"
        Me.CreatedDate.HeaderText = "CreatedDate"
        Me.CreatedDate.Name = "CreatedDate"
        Me.CreatedDate.ReadOnly = True
        Me.CreatedDate.Width = 92
        '
        'Url
        '
        Me.Url.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.Url.DataPropertyName = "Url"
        Me.Url.HeaderText = "Url"
        Me.Url.Name = "Url"
        Me.Url.ReadOnly = True
        Me.Url.Width = 45
        '
        'Params
        '
        Me.Params.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.Params.DataPropertyName = "Params"
        Me.Params.HeaderText = "Params"
        Me.Params.Name = "Params"
        Me.Params.ReadOnly = True
        Me.Params.Width = 300
        '
        'HttpMethod
        '
        Me.HttpMethod.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.HttpMethod.DataPropertyName = "HttpMethod"
        Me.HttpMethod.HeaderText = "HttpMethod"
        Me.HttpMethod.Name = "HttpMethod"
        Me.HttpMethod.ReadOnly = True
        Me.HttpMethod.Width = 88
        '
        'CallDate
        '
        Me.CallDate.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.CallDate.DataPropertyName = "CallDate"
        Me.CallDate.HeaderText = "CallDate"
        Me.CallDate.Name = "CallDate"
        Me.CallDate.ReadOnly = True
        Me.CallDate.Width = 72
        '
        'FormApiCall
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.DataGridView1)
        Me.Name = "FormApiCall"
        Me.Text = "Log appels différés"
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents id As DataGridViewTextBoxColumn
    Friend WithEvents CreatedDate As DataGridViewTextBoxColumn
    Friend WithEvents Url As DataGridViewTextBoxColumn
    Friend WithEvents Params As DataGridViewTextBoxColumn
    Friend WithEvents HttpMethod As DataGridViewTextBoxColumn
    Friend WithEvents CallDate As DataGridViewTextBoxColumn
End Class
