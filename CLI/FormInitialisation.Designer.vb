<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormInitialisation
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormInitialisation))
        Me.ProgressBar1 = New System.Windows.Forms.ProgressBar
        Me.Label1 = New System.Windows.Forms.Label
        Me.LabelImprimanteTicketCaisse = New System.Windows.Forms.Label
        Me.LabelAfficheur = New System.Windows.Forms.Label
        Me.LabelTiroirCaisse = New System.Windows.Forms.Label
        Me.BT_Ignorer = New System.Windows.Forms.Button
        Me.SuspendLayout()
        '
        'ProgressBar1
        '
        Me.ProgressBar1.Location = New System.Drawing.Point(12, 25)
        Me.ProgressBar1.Maximum = 3
        Me.ProgressBar1.Name = "ProgressBar1"
        Me.ProgressBar1.Size = New System.Drawing.Size(472, 23)
        Me.ProgressBar1.Step = 1
        Me.ProgressBar1.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(12, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(253, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Initialisation du système de caisse en cours"
        '
        'LabelImprimanteTicketCaisse
        '
        Me.LabelImprimanteTicketCaisse.AutoSize = True
        Me.LabelImprimanteTicketCaisse.Location = New System.Drawing.Point(12, 74)
        Me.LabelImprimanteTicketCaisse.Name = "LabelImprimanteTicketCaisse"
        Me.LabelImprimanteTicketCaisse.Size = New System.Drawing.Size(0, 13)
        Me.LabelImprimanteTicketCaisse.TabIndex = 2
        '
        'LabelAfficheur
        '
        Me.LabelAfficheur.AutoSize = True
        Me.LabelAfficheur.Location = New System.Drawing.Point(12, 51)
        Me.LabelAfficheur.Name = "LabelAfficheur"
        Me.LabelAfficheur.Size = New System.Drawing.Size(0, 13)
        Me.LabelAfficheur.TabIndex = 2
        '
        'LabelTiroirCaisse
        '
        Me.LabelTiroirCaisse.AutoSize = True
        Me.LabelTiroirCaisse.Location = New System.Drawing.Point(12, 99)
        Me.LabelTiroirCaisse.Name = "LabelTiroirCaisse"
        Me.LabelTiroirCaisse.Size = New System.Drawing.Size(0, 13)
        Me.LabelTiroirCaisse.TabIndex = 2
        '
        'BT_Ignorer
        '
        Me.BT_Ignorer.Enabled = False
        Me.BT_Ignorer.Location = New System.Drawing.Point(354, 123)
        Me.BT_Ignorer.Name = "BT_Ignorer"
        Me.BT_Ignorer.Size = New System.Drawing.Size(134, 23)
        Me.BT_Ignorer.TabIndex = 2
        Me.BT_Ignorer.Text = "Ignorer Avertissement(s)"
        Me.BT_Ignorer.UseVisualStyleBackColor = True
        Me.BT_Ignorer.Visible = False
        '
        'FormInitialisation
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(500, 154)
        Me.Controls.Add(Me.BT_Ignorer)
        Me.Controls.Add(Me.LabelAfficheur)
        Me.Controls.Add(Me.LabelTiroirCaisse)
        Me.Controls.Add(Me.LabelImprimanteTicketCaisse)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.ProgressBar1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "FormInitialisation"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Initialisation du système de caisse"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ProgressBar1 As System.Windows.Forms.ProgressBar
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents LabelImprimanteTicketCaisse As System.Windows.Forms.Label
    Friend WithEvents LabelAfficheur As System.Windows.Forms.Label
    Friend WithEvents LabelTiroirCaisse As System.Windows.Forms.Label
    Friend WithEvents BT_Ignorer As System.Windows.Forms.Button
End Class
