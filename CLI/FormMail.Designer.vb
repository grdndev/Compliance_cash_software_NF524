<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormMail
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
        Me.components = New System.ComponentModel.Container
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel
        Me.OK_Button = New System.Windows.Forms.Button
        Me.Cancel_Button = New System.Windows.Forms.Button
        Me.I_From = New System.Windows.Forms.TextBox
        Me.I_To = New System.Windows.Forms.TextBox
        Me.I_subject = New System.Windows.Forms.TextBox
        Me.I_message = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.LinkLabel1 = New System.Windows.Forms.LinkLabel
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        Me.I_smtp = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.ContextMenuStripMail = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.RechercherToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.RechercherFournisseurToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.TableLayoutPanel1.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ContextMenuStripMail.SuspendLayout()
        Me.SuspendLayout()
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TableLayoutPanel1.ColumnCount = 2
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.OK_Button, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Cancel_Button, 1, 0)
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(307, 324)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 1
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(146, 29)
        Me.TableLayoutPanel1.TabIndex = 6
        '
        'OK_Button
        '
        Me.OK_Button.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.OK_Button.Location = New System.Drawing.Point(3, 3)
        Me.OK_Button.Name = "OK_Button"
        Me.OK_Button.Size = New System.Drawing.Size(67, 23)
        Me.OK_Button.TabIndex = 0
        Me.OK_Button.Text = "Envoyer"
        '
        'Cancel_Button
        '
        Me.Cancel_Button.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Cancel_Button.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Cancel_Button.Location = New System.Drawing.Point(76, 3)
        Me.Cancel_Button.Name = "Cancel_Button"
        Me.Cancel_Button.Size = New System.Drawing.Size(67, 23)
        Me.Cancel_Button.TabIndex = 1
        Me.Cancel_Button.Text = "Annuler"
        '
        'I_From
        '
        Me.I_From.Location = New System.Drawing.Point(100, 16)
        Me.I_From.Name = "I_From"
        Me.I_From.ReadOnly = True
        Me.I_From.Size = New System.Drawing.Size(277, 20)
        Me.I_From.TabIndex = 0
        '
        'I_To
        '
        Me.I_To.ContextMenuStrip = Me.ContextMenuStripMail
        Me.I_To.Location = New System.Drawing.Point(100, 42)
        Me.I_To.Name = "I_To"
        Me.I_To.Size = New System.Drawing.Size(277, 20)
        Me.I_To.TabIndex = 1
        '
        'I_subject
        '
        Me.I_subject.Location = New System.Drawing.Point(100, 92)
        Me.I_subject.Name = "I_subject"
        Me.I_subject.Size = New System.Drawing.Size(349, 20)
        Me.I_subject.TabIndex = 3
        '
        'I_message
        '
        Me.I_message.Location = New System.Drawing.Point(100, 118)
        Me.I_message.Multiline = True
        Me.I_message.Name = "I_message"
        Me.I_message.Size = New System.Drawing.Size(350, 171)
        Me.I_message.TabIndex = 4
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(70, 19)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(24, 13)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "De:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(77, 41)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(17, 13)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "A:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(60, 91)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(34, 13)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "Sujet:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(41, 117)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(53, 13)
        Me.Label4.TabIndex = 4
        Me.Label4.Text = "Message:"
        '
        'LinkLabel1
        '
        Me.LinkLabel1.AutoSize = True
        Me.LinkLabel1.Location = New System.Drawing.Point(122, 308)
        Me.LinkLabel1.Name = "LinkLabel1"
        Me.LinkLabel1.Size = New System.Drawing.Size(62, 13)
        Me.LinkLabel1.TabIndex = 5
        Me.LinkLabel1.TabStop = True
        Me.LinkLabel1.Text = "Pièce jointe"
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.CLI.My.Resources.Resources.ActualSizeHS
        Me.PictureBox1.Location = New System.Drawing.Point(100, 308)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(21, 16)
        Me.PictureBox1.TabIndex = 6
        Me.PictureBox1.TabStop = False
        '
        'I_smtp
        '
        Me.I_smtp.Location = New System.Drawing.Point(100, 66)
        Me.I_smtp.Name = "I_smtp"
        Me.I_smtp.Size = New System.Drawing.Size(277, 20)
        Me.I_smtp.TabIndex = 2
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(22, 65)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(72, 13)
        Me.Label5.TabIndex = 4
        Me.Label5.Text = "Serveur smtp:"
        '
        'ContextMenuStripMail
        '
        Me.ContextMenuStripMail.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.RechercherToolStripMenuItem, Me.RechercherFournisseurToolStripMenuItem})
        Me.ContextMenuStripMail.Name = "ContextMenuStripArticle"
        Me.ContextMenuStripMail.Size = New System.Drawing.Size(196, 70)
        '
        'RechercherToolStripMenuItem
        '
        Me.RechercherToolStripMenuItem.Image = Global.CLI.My.Resources.Resources.ActualSizeHS
        Me.RechercherToolStripMenuItem.Name = "RechercherToolStripMenuItem"
        Me.RechercherToolStripMenuItem.Size = New System.Drawing.Size(195, 22)
        Me.RechercherToolStripMenuItem.Text = "Rechercher client"
        '
        'RechercherFournisseurToolStripMenuItem
        '
        Me.RechercherFournisseurToolStripMenuItem.Image = Global.CLI.My.Resources.Resources.ActualSizeHS
        Me.RechercherFournisseurToolStripMenuItem.Name = "RechercherFournisseurToolStripMenuItem"
        Me.RechercherFournisseurToolStripMenuItem.Size = New System.Drawing.Size(195, 22)
        Me.RechercherFournisseurToolStripMenuItem.Text = "Rechercher fournisseur"
        '
        'FormMail
        '
        Me.AcceptButton = Me.OK_Button
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.Cancel_Button
        Me.ClientSize = New System.Drawing.Size(465, 365)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.LinkLabel1)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.I_message)
        Me.Controls.Add(Me.I_subject)
        Me.Controls.Add(Me.I_smtp)
        Me.Controls.Add(Me.I_To)
        Me.Controls.Add(Me.I_From)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FormMail"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Envoi email"
        Me.TableLayoutPanel1.ResumeLayout(False)
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ContextMenuStripMail.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents OK_Button As System.Windows.Forms.Button
    Friend WithEvents Cancel_Button As System.Windows.Forms.Button
    Friend WithEvents I_From As System.Windows.Forms.TextBox
    Friend WithEvents I_To As System.Windows.Forms.TextBox
    Friend WithEvents I_subject As System.Windows.Forms.TextBox
    Friend WithEvents I_message As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents LinkLabel1 As System.Windows.Forms.LinkLabel
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents I_smtp As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents ContextMenuStripMail As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents RechercherToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents RechercherFournisseurToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem

End Class
