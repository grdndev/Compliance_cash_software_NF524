<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class DialogImpression
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel
        Me.OK_Button = New System.Windows.Forms.Button
        Me.Cancel_Button = New System.Windows.Forms.Button
        Me.Label1 = New System.Windows.Forms.Label
        Me.ComboBoxOrientation = New System.Windows.Forms.ComboBox
        Me.DataGridViewColonnes = New System.Windows.Forms.DataGridView
        Me.Colonne = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Imprimer = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Me.ColonneName = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.TableLayoutPanel1.SuspendLayout()
        CType(Me.DataGridViewColonnes, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(120, 300)
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
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(-1, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(64, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Orientation :"
        '
        'ComboBoxOrientation
        '
        Me.ComboBoxOrientation.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBoxOrientation.FormattingEnabled = True
        Me.ComboBoxOrientation.Items.AddRange(New Object() {"Portrait", "Paysage"})
        Me.ComboBoxOrientation.Location = New System.Drawing.Point(69, 6)
        Me.ComboBoxOrientation.Name = "ComboBoxOrientation"
        Me.ComboBoxOrientation.Size = New System.Drawing.Size(121, 21)
        Me.ComboBoxOrientation.TabIndex = 2
        '
        'DataGridViewColonnes
        '
        Me.DataGridViewColonnes.AllowUserToAddRows = False
        Me.DataGridViewColonnes.AllowUserToDeleteRows = False
        Me.DataGridViewColonnes.AllowUserToResizeColumns = False
        Me.DataGridViewColonnes.AllowUserToResizeRows = False
        Me.DataGridViewColonnes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridViewColonnes.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Colonne, Me.Imprimer, Me.ColonneName})
        Me.DataGridViewColonnes.Location = New System.Drawing.Point(2, 33)
        Me.DataGridViewColonnes.Name = "DataGridViewColonnes"
        Me.DataGridViewColonnes.RowHeadersVisible = False
        Me.DataGridViewColonnes.Size = New System.Drawing.Size(267, 252)
        Me.DataGridViewColonnes.TabIndex = 3
        '
        'Colonne
        '
        Me.Colonne.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.Colonne.HeaderText = "Colonne"
        Me.Colonne.Name = "Colonne"
        Me.Colonne.ReadOnly = True
        '
        'Imprimer
        '
        Me.Imprimer.HeaderText = "Imprimer ?"
        Me.Imprimer.Name = "Imprimer"
        Me.Imprimer.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Imprimer.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        '
        'ColonneName
        '
        Me.ColonneName.HeaderText = "NomlColonne"
        Me.ColonneName.Name = "ColonneName"
        Me.ColonneName.ReadOnly = True
        Me.ColonneName.Visible = False
        '
        'DialogImpression
        '
        Me.AcceptButton = Me.OK_Button
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.Cancel_Button
        Me.ClientSize = New System.Drawing.Size(278, 341)
        Me.Controls.Add(Me.DataGridViewColonnes)
        Me.Controls.Add(Me.ComboBoxOrientation)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "DialogImpression"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Impression"
        Me.TableLayoutPanel1.ResumeLayout(False)
        CType(Me.DataGridViewColonnes, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents OK_Button As System.Windows.Forms.Button
    Friend WithEvents Cancel_Button As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents ComboBoxOrientation As System.Windows.Forms.ComboBox
    Friend WithEvents DataGridViewColonnes As System.Windows.Forms.DataGridView
    Friend WithEvents Colonne As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Imprimer As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents ColonneName As System.Windows.Forms.DataGridViewTextBoxColumn

End Class
