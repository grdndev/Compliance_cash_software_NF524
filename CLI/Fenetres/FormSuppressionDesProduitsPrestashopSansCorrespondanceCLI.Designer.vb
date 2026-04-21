<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormSuppressionDesProduitsPrestashopSansCorrespondanceCLI
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
        Me.Button1 = New System.Windows.Forms.Button()
        Me.IL_Description = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(24, 49)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 0
        Me.Button1.Text = "Suppression"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'IL_Description
        '
        Me.IL_Description.AutoSize = True
        Me.IL_Description.Location = New System.Drawing.Point(21, 23)
        Me.IL_Description.Name = "IL_Description"
        Me.IL_Description.Size = New System.Drawing.Size(365, 13)
        Me.IL_Description.TabIndex = 1
        Me.IL_Description.Text = "Permet de supprimer les produits prestashop sans correspondance avec CLI" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        '
        'FormSuppressionDesProduitsPrestashopSansCorrespondanceCLI
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(464, 99)
        Me.Controls.Add(Me.IL_Description)
        Me.Controls.Add(Me.Button1)
        Me.Name = "FormSuppressionDesProduitsPrestashopSansCorrespondanceCLI"
        Me.Text = "Suppression des produits sans correspondance"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Button1 As Button
    Friend WithEvents IL_Description As Label
End Class
