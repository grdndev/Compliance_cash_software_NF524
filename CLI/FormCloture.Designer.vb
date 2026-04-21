<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormCloture
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

    'REMARQUE : la procédure suivante est requise par le Concepteur Windows Form
    'Elle peut être modifiée à l'aide du Concepteur Windows Form.  
    'Ne la modifiez pas à l'aide de l'éditeur de code.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.lblTitle = New System.Windows.Forms.Label()
        Me.lblLastCloture = New System.Windows.Forms.Label()
        Me.lblGrandTotal = New System.Windows.Forms.Label()
        Me.lblCAJour = New System.Windows.Forms.Label()
        Me.lblInfo = New System.Windows.Forms.Label()
        Me.btnCloturer = New System.Windows.Forms.Button()
        Me.btnAnnuler = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'lblTitle
        '
        Me.lblTitle.AutoSize = True
        Me.lblTitle.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitle.ForeColor = System.Drawing.Color.DarkBlue
        Me.lblTitle.Location = New System.Drawing.Point(12, 9)
        Me.lblTitle.Name = "lblTitle"
        Me.lblTitle.Size = New System.Drawing.Size(348, 24)
        Me.lblTitle.TabIndex = 0
        Me.lblTitle.Text = "🔒 NF525 - Clôture Journalière (Z)"
        '
        'lblLastCloture
        '
        Me.lblLastCloture.AutoSize = True
        Me.lblLastCloture.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLastCloture.Location = New System.Drawing.Point(20, 30)
        Me.lblLastCloture.Name = "lblLastCloture"
        Me.lblLastCloture.Size = New System.Drawing.Size(140, 17)
        Me.lblLastCloture.TabIndex = 1
        Me.lblLastCloture.Text = "Dernière clôture : N/A"
        '
        'lblGrandTotal
        '
        Me.lblGrandTotal.AutoSize = True
        Me.lblGrandTotal.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblGrandTotal.ForeColor = System.Drawing.Color.DarkGreen
        Me.lblGrandTotal.Location = New System.Drawing.Point(20, 60)
        Me.lblGrandTotal.Name = "lblGrandTotal"
        Me.lblGrandTotal.Size = New System.Drawing.Size(190, 18)
        Me.lblGrandTotal.TabIndex = 2
        Me.lblGrandTotal.Text = "Grand Total : 0,00 €"
        '
        'lblCAJour
        '
        Me.lblCAJour.AutoSize = True
        Me.lblCAJour.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCAJour.ForeColor = System.Drawing.Color.DarkOrange
        Me.lblCAJour.Location = New System.Drawing.Point(20, 90)
        Me.lblCAJour.Name = "lblCAJour"
        Me.lblCAJour.Size = New System.Drawing.Size(217, 18)
        Me.lblCAJour.TabIndex = 3
        Me.lblCAJour.Text = "CA de la journée : 0,00 €"
        '
        'lblInfo
        '
        Me.lblInfo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblInfo.ForeColor = System.Drawing.Color.Gray
        Me.lblInfo.Location = New System.Drawing.Point(20, 120)
        Me.lblInfo.Name = "lblInfo"
        Me.lblInfo.Size = New System.Drawing.Size(430, 40)
        Me.lblInfo.TabIndex = 4
        Me.lblInfo.Text = "Chargement..."
        '
        'btnCloturer
        '
        Me.btnCloturer.BackColor = System.Drawing.Color.ForestGreen
        Me.btnCloturer.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCloturer.ForeColor = System.Drawing.Color.White
        Me.btnCloturer.Location = New System.Drawing.Point(100, 220)
        Me.btnCloturer.Name = "btnCloturer"
        Me.btnCloturer.Size = New System.Drawing.Size(150, 40)
        Me.btnCloturer.TabIndex = 5
        Me.btnCloturer.Text = "✅ Clôturer"
        Me.btnCloturer.UseVisualStyleBackColor = False
        '
        'btnAnnuler
        '
        Me.btnAnnuler.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnAnnuler.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAnnuler.Location = New System.Drawing.Point(270, 220)
        Me.btnAnnuler.Name = "btnAnnuler"
        Me.btnAnnuler.Size = New System.Drawing.Size(150, 40)
        Me.btnAnnuler.TabIndex = 6
        Me.btnAnnuler.Text = "❌ Annuler"
        Me.btnAnnuler.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.lblLastCloture)
        Me.GroupBox1.Controls.Add(Me.lblGrandTotal)
        Me.GroupBox1.Controls.Add(Me.lblCAJour)
        Me.GroupBox1.Controls.Add(Me.lblInfo)
        Me.GroupBox1.Location = New System.Drawing.Point(16, 40)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(470, 170)
        Me.GroupBox1.TabIndex = 7
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "📊 Informations de clôture"
        '
        'FormCloture
        '
        Me.AcceptButton = Me.btnCloturer
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.WhiteSmoke
        Me.CancelButton = Me.btnAnnuler
        Me.ClientSize = New System.Drawing.Size(504, 281)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.btnAnnuler)
        Me.Controls.Add(Me.btnCloturer)
        Me.Controls.Add(Me.lblTitle)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FormCloture"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "NF525 - Clôture Journalière"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents lblTitle As System.Windows.Forms.Label
    Friend WithEvents lblLastCloture As System.Windows.Forms.Label
    Friend WithEvents lblGrandTotal As System.Windows.Forms.Label
    Friend WithEvents lblCAJour As System.Windows.Forms.Label
    Friend WithEvents lblInfo As System.Windows.Forms.Label
    Friend WithEvents btnCloturer As System.Windows.Forms.Button
    Friend WithEvents btnAnnuler As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
End Class
