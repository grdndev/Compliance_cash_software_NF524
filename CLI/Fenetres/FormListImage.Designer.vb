<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormListImage
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
        Me.ListBox1 = New System.Windows.Forms.ListBox()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.BT_Ajouter = New System.Windows.Forms.Button()
        Me.BT_Supprimer = New System.Windows.Forms.Button()
        Me.BT_Reset = New System.Windows.Forms.Button()
        Me.BT_Fermer = New System.Windows.Forms.Button()
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.I_Default = New System.Windows.Forms.ComboBox()
        Me.LabelDefault = New System.Windows.Forms.Label()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ListBox1
        '
        Me.ListBox1.FormattingEnabled = True
        Me.ListBox1.Location = New System.Drawing.Point(12, 12)
        Me.ListBox1.Name = "ListBox1"
        Me.ListBox1.Size = New System.Drawing.Size(120, 95)
        Me.ListBox1.TabIndex = 1
        '
        'PictureBox1
        '
        Me.PictureBox1.Location = New System.Drawing.Point(138, 12)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(383, 267)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox1.TabIndex = 0
        Me.PictureBox1.TabStop = False
        '
        'BT_Ajouter
        '
        Me.BT_Ajouter.Location = New System.Drawing.Point(12, 113)
        Me.BT_Ajouter.Name = "BT_Ajouter"
        Me.BT_Ajouter.Size = New System.Drawing.Size(75, 23)
        Me.BT_Ajouter.TabIndex = 2
        Me.BT_Ajouter.Text = "Ajouter"
        Me.BT_Ajouter.UseVisualStyleBackColor = True
        '
        'BT_Supprimer
        '
        Me.BT_Supprimer.Location = New System.Drawing.Point(12, 142)
        Me.BT_Supprimer.Name = "BT_Supprimer"
        Me.BT_Supprimer.Size = New System.Drawing.Size(75, 23)
        Me.BT_Supprimer.TabIndex = 2
        Me.BT_Supprimer.Text = "Supprimer"
        Me.BT_Supprimer.UseVisualStyleBackColor = True
        '
        'BT_Reset
        '
        Me.BT_Reset.Location = New System.Drawing.Point(12, 171)
        Me.BT_Reset.Name = "BT_Reset"
        Me.BT_Reset.Size = New System.Drawing.Size(75, 23)
        Me.BT_Reset.TabIndex = 3
        Me.BT_Reset.Text = "Reset"
        Me.BT_Reset.UseVisualStyleBackColor = True
        '
        'BT_Fermer
        '
        Me.BT_Fermer.Location = New System.Drawing.Point(446, 294)
        Me.BT_Fermer.Name = "BT_Fermer"
        Me.BT_Fermer.Size = New System.Drawing.Size(75, 23)
        Me.BT_Fermer.TabIndex = 4
        Me.BT_Fermer.Text = "Fermer"
        Me.BT_Fermer.UseVisualStyleBackColor = True
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        Me.OpenFileDialog1.Filter = "Fichiers Jpg|*.jpg"
        '
        'I_Default
        '
        Me.I_Default.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.I_Default.FormattingEnabled = True
        Me.I_Default.Location = New System.Drawing.Point(319, 294)
        Me.I_Default.Name = "I_Default"
        Me.I_Default.Size = New System.Drawing.Size(121, 21)
        Me.I_Default.TabIndex = 5
        '
        'LabelDefault
        '
        Me.LabelDefault.AutoSize = True
        Me.LabelDefault.Location = New System.Drawing.Point(226, 297)
        Me.LabelDefault.Name = "LabelDefault"
        Me.LabelDefault.Size = New System.Drawing.Size(87, 13)
        Me.LabelDefault.TabIndex = 6
        Me.LabelDefault.Text = "Image par défaut"
        '
        'FormListImage
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(531, 329)
        Me.Controls.Add(Me.LabelDefault)
        Me.Controls.Add(Me.I_Default)
        Me.Controls.Add(Me.BT_Fermer)
        Me.Controls.Add(Me.BT_Reset)
        Me.Controls.Add(Me.BT_Supprimer)
        Me.Controls.Add(Me.BT_Ajouter)
        Me.Controls.Add(Me.ListBox1)
        Me.Controls.Add(Me.PictureBox1)
        Me.Name = "FormListImage"
        Me.Text = "Images du produit"
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents ListBox1 As ListBox
    Friend WithEvents BT_Ajouter As Button
    Friend WithEvents BT_Supprimer As Button
    Friend WithEvents BT_Reset As Button
    Friend WithEvents BT_Fermer As Button
    Friend WithEvents OpenFileDialog1 As OpenFileDialog
    Friend WithEvents I_Default As ComboBox
    Friend WithEvents LabelDefault As Label
End Class
