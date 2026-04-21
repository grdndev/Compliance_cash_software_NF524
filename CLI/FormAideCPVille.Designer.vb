<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormAideCPVille
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
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel
        Me.OK_Button = New System.Windows.Forms.Button
        Me.Cancel_Button = New System.Windows.Forms.Button
        Me.DGV = New System.Windows.Forms.DataGridView
        Me.CodePostal = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Ville = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.I_CP = New System.Windows.Forms.TextBox
        Me.I_Ville = New System.Windows.Forms.TextBox
        Me.IL_Enregistrements = New System.Windows.Forms.Label
        Me.TableLayoutPanel1.SuspendLayout()
        CType(Me.DGV, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(235, 252)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 1
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(146, 29)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'OK_Button
        '
        Me.OK_Button.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.OK_Button.Location = New System.Drawing.Point(3, 3)
        Me.OK_Button.Name = "OK_Button"
        Me.OK_Button.Size = New System.Drawing.Size(67, 23)
        Me.OK_Button.TabIndex = 0
        Me.OK_Button.Text = "OK"
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
        'DGV
        '
        Me.DGV.AllowUserToAddRows = False
        Me.DGV.AllowUserToDeleteRows = False
        Me.DGV.AllowUserToResizeColumns = False
        Me.DGV.AllowUserToResizeRows = False
        Me.DGV.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.DGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.DGV.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.CodePostal, Me.Ville})
        Me.DGV.Location = New System.Drawing.Point(5, 35)
        Me.DGV.Name = "DGV"
        Me.DGV.ReadOnly = True
        Me.DGV.RowHeadersVisible = False
        Me.DGV.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DGV.Size = New System.Drawing.Size(373, 211)
        Me.DGV.TabIndex = 1
        '
        'CodePostal
        '
        Me.CodePostal.DataPropertyName = "CodePostal"
        Me.CodePostal.HeaderText = "Code Postal"
        Me.CodePostal.Name = "CodePostal"
        Me.CodePostal.ReadOnly = True
        Me.CodePostal.Width = 89
        '
        'Ville
        '
        Me.Ville.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.Ville.DataPropertyName = "Ville"
        Me.Ville.HeaderText = "Ville"
        Me.Ville.Name = "Ville"
        Me.Ville.ReadOnly = True
        Me.Ville.Width = 250
        '
        'I_CP
        '
        Me.I_CP.Location = New System.Drawing.Point(5, 9)
        Me.I_CP.Name = "I_CP"
        Me.I_CP.Size = New System.Drawing.Size(92, 20)
        Me.I_CP.TabIndex = 2
        '
        'I_Ville
        '
        Me.I_Ville.Location = New System.Drawing.Point(103, 9)
        Me.I_Ville.Name = "I_Ville"
        Me.I_Ville.Size = New System.Drawing.Size(245, 20)
        Me.I_Ville.TabIndex = 2
        '
        'IL_Enregistrements
        '
        Me.IL_Enregistrements.AutoSize = True
        Me.IL_Enregistrements.Location = New System.Drawing.Point(5, 252)
        Me.IL_Enregistrements.Name = "IL_Enregistrements"
        Me.IL_Enregistrements.Size = New System.Drawing.Size(0, 13)
        Me.IL_Enregistrements.TabIndex = 3
        '
        'FormAideCPVille
        '
        Me.AcceptButton = Me.OK_Button
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.Cancel_Button
        Me.ClientSize = New System.Drawing.Size(393, 293)
        Me.Controls.Add(Me.IL_Enregistrements)
        Me.Controls.Add(Me.I_Ville)
        Me.Controls.Add(Me.I_CP)
        Me.Controls.Add(Me.DGV)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FormAideCPVille"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Assistant code postal"
        Me.TableLayoutPanel1.ResumeLayout(False)
        CType(Me.DGV, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents OK_Button As System.Windows.Forms.Button
    Friend WithEvents Cancel_Button As System.Windows.Forms.Button
    Friend WithEvents DGV As System.Windows.Forms.DataGridView
    Friend WithEvents I_CP As System.Windows.Forms.TextBox
    Friend WithEvents I_Ville As System.Windows.Forms.TextBox
    Friend WithEvents CodePostal As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Ville As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents IL_Enregistrements As System.Windows.Forms.Label

End Class
