<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormTruncateLog
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
        Me.BT_Tronquer = New System.Windows.Forms.Button()
        Me.I_Number = New System.Windows.Forms.TextBox()
        Me.IL_Number = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'BT_Tronquer
        '
        Me.BT_Tronquer.Location = New System.Drawing.Point(262, 11)
        Me.BT_Tronquer.Name = "BT_Tronquer"
        Me.BT_Tronquer.Size = New System.Drawing.Size(93, 21)
        Me.BT_Tronquer.TabIndex = 2
        Me.BT_Tronquer.Text = "Tronquer"
        Me.BT_Tronquer.UseVisualStyleBackColor = True
        '
        'I_Number
        '
        Me.I_Number.Location = New System.Drawing.Point(201, 12)
        Me.I_Number.Name = "I_Number"
        Me.I_Number.Size = New System.Drawing.Size(46, 20)
        Me.I_Number.TabIndex = 3
        Me.I_Number.Text = "10"
        '
        'IL_Number
        '
        Me.IL_Number.AutoSize = True
        Me.IL_Number.Location = New System.Drawing.Point(12, 16)
        Me.IL_Number.Name = "IL_Number"
        Me.IL_Number.Size = New System.Drawing.Size(183, 13)
        Me.IL_Number.TabIndex = 4
        Me.IL_Number.Text = "Nombre maxi d'enrgistrement par type"
        '
        'FormTruncateLog
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(376, 50)
        Me.Controls.Add(Me.IL_Number)
        Me.Controls.Add(Me.I_Number)
        Me.Controls.Add(Me.BT_Tronquer)
        Me.Name = "FormTruncateLog"
        Me.Text = "Tronquer le log"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents BT_Tronquer As Button
    Friend WithEvents I_Number As TextBox
    Friend WithEvents IL_Number As Label
End Class
