<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormImport
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
        Me.BT_Charger = New System.Windows.Forms.Button()
        Me.FolderBrowserDialog1 = New System.Windows.Forms.FolderBrowserDialog()
        Me.I_import = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'BT_Charger
        '
        Me.BT_Charger.Location = New System.Drawing.Point(67, 22)
        Me.BT_Charger.Name = "BT_Charger"
        Me.BT_Charger.Size = New System.Drawing.Size(130, 57)
        Me.BT_Charger.TabIndex = 0
        Me.BT_Charger.Text = "Charger CSV"
        Me.BT_Charger.UseVisualStyleBackColor = True
        '
        'I_import
        '
        Me.I_import.Location = New System.Drawing.Point(38, 125)
        Me.I_import.Name = "I_import"
        Me.I_import.ReadOnly = True
        Me.I_import.Size = New System.Drawing.Size(188, 20)
        Me.I_import.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(35, 109)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(50, 13)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "N° import"
        '
        'FormImport
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(279, 184)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.I_import)
        Me.Controls.Add(Me.BT_Charger)
        Me.Name = "FormImport"
        Me.Text = "import"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents BT_Charger As Button
    Friend WithEvents FolderBrowserDialog1 As FolderBrowserDialog
    Friend WithEvents I_import As TextBox
    Friend WithEvents Label1 As Label
End Class
