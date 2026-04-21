<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormImportCommande
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
        Me.BT_Import = New System.Windows.Forms.Button()
        Me.I_Numero = New System.Windows.Forms.TextBox()
        Me.IL_Numero = New System.Windows.Forms.Label()
        Me.CB_Force = New System.Windows.Forms.CheckBox()
        Me.SuspendLayout()
        '
        'BT_Import
        '
        Me.BT_Import.Location = New System.Drawing.Point(12, 65)
        Me.BT_Import.Name = "BT_Import"
        Me.BT_Import.Size = New System.Drawing.Size(75, 23)
        Me.BT_Import.TabIndex = 0
        Me.BT_Import.Text = "Importer"
        Me.BT_Import.UseVisualStyleBackColor = True
        '
        'I_Numero
        '
        Me.I_Numero.Location = New System.Drawing.Point(132, 16)
        Me.I_Numero.Name = "I_Numero"
        Me.I_Numero.Size = New System.Drawing.Size(100, 20)
        Me.I_Numero.TabIndex = 1
        '
        'IL_Numero
        '
        Me.IL_Numero.AutoSize = True
        Me.IL_Numero.Location = New System.Drawing.Point(12, 19)
        Me.IL_Numero.Name = "IL_Numero"
        Me.IL_Numero.Size = New System.Drawing.Size(114, 13)
        Me.IL_Numero.TabIndex = 2
        Me.IL_Numero.Text = "Numéro de commande"
        '
        'CB_Force
        '
        Me.CB_Force.AutoSize = True
        Me.CB_Force.Location = New System.Drawing.Point(132, 43)
        Me.CB_Force.Name = "CB_Force"
        Me.CB_Force.Size = New System.Drawing.Size(111, 17)
        Me.CB_Force.TabIndex = 3
        Me.CB_Force.Text = "Forcer si existante"
        Me.CB_Force.UseVisualStyleBackColor = True
        '
        'FormImportCommande
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(308, 100)
        Me.Controls.Add(Me.CB_Force)
        Me.Controls.Add(Me.IL_Numero)
        Me.Controls.Add(Me.I_Numero)
        Me.Controls.Add(Me.BT_Import)
        Me.Name = "FormImportCommande"
        Me.Text = "Import commande prestashop"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents BT_Import As Button
    Friend WithEvents I_Numero As TextBox
    Friend WithEvents IL_Numero As Label
    Friend WithEvents CB_Force As CheckBox
End Class
