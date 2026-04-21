<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormCustomMessage
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
        Me.TextBoxMessage = New System.Windows.Forms.TextBox()
        Me.BT_Fermer = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'TextBoxMessage
        '
        Me.TextBoxMessage.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TextBoxMessage.Location = New System.Drawing.Point(12, 12)
        Me.TextBoxMessage.Multiline = True
        Me.TextBoxMessage.Name = "TextBoxMessage"
        Me.TextBoxMessage.ReadOnly = True
        Me.TextBoxMessage.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.TextBoxMessage.Size = New System.Drawing.Size(399, 192)
        Me.TextBoxMessage.TabIndex = 1
        '
        'BT_Fermer
        '
        Me.BT_Fermer.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BT_Fermer.Location = New System.Drawing.Point(338, 208)
        Me.BT_Fermer.Name = "BT_Fermer"
        Me.BT_Fermer.Size = New System.Drawing.Size(75, 23)
        Me.BT_Fermer.TabIndex = 0
        Me.BT_Fermer.Text = "Fermer"
        Me.BT_Fermer.UseVisualStyleBackColor = True
        '
        'FormCustomMessage
        '
        Me.AcceptButton = Me.BT_Fermer
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(416, 240)
        Me.Controls.Add(Me.BT_Fermer)
        Me.Controls.Add(Me.TextBoxMessage)
        Me.Name = "FormCustomMessage"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents TextBoxMessage As TextBox
    Friend WithEvents BT_Fermer As Button
End Class
