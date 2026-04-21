<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormTriAttribut
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
        Me.ComboBoxAttribut = New System.Windows.Forms.ComboBox()
        Me.BT_Tri = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'ComboBoxAttribut
        '
        Me.ComboBoxAttribut.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBoxAttribut.FormattingEnabled = True
        Me.ComboBoxAttribut.Location = New System.Drawing.Point(12, 12)
        Me.ComboBoxAttribut.Name = "ComboBoxAttribut"
        Me.ComboBoxAttribut.Size = New System.Drawing.Size(121, 21)
        Me.ComboBoxAttribut.TabIndex = 0
        '
        'BT_Tri
        '
        Me.BT_Tri.Location = New System.Drawing.Point(139, 12)
        Me.BT_Tri.Name = "BT_Tri"
        Me.BT_Tri.Size = New System.Drawing.Size(93, 21)
        Me.BT_Tri.TabIndex = 1
        Me.BT_Tri.Text = "Tri croissant"
        Me.BT_Tri.UseVisualStyleBackColor = True
        '
        'FormTriAttribut
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(303, 64)
        Me.Controls.Add(Me.BT_Tri)
        Me.Controls.Add(Me.ComboBoxAttribut)
        Me.Name = "FormTriAttribut"
        Me.Text = "Trier les valeurs des attributs"
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents ComboBoxAttribut As ComboBox
    Friend WithEvents BT_Tri As Button
End Class
