<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormMessageDispo
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
        Me.BT_RecupLibelles = New System.Windows.Forms.Button()
        Me.BT_Envoi = New System.Windows.Forms.Button()
        Me.DGV_Data = New System.Windows.Forms.DataGridView()
        Me.TypeDeMessage = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Prestashop = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.MessageDeRemplacement = New System.Windows.Forms.DataGridViewComboBoxColumn()
        CType(Me.DGV_Data, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'BT_RecupLibelles
        '
        Me.BT_RecupLibelles.Location = New System.Drawing.Point(12, 12)
        Me.BT_RecupLibelles.Name = "BT_RecupLibelles"
        Me.BT_RecupLibelles.Size = New System.Drawing.Size(215, 23)
        Me.BT_RecupLibelles.TabIndex = 0
        Me.BT_RecupLibelles.Text = "1 - Récupération des libellés"
        Me.BT_RecupLibelles.UseVisualStyleBackColor = True
        '
        'BT_Envoi
        '
        Me.BT_Envoi.Location = New System.Drawing.Point(12, 197)
        Me.BT_Envoi.Name = "BT_Envoi"
        Me.BT_Envoi.Size = New System.Drawing.Size(215, 23)
        Me.BT_Envoi.TabIndex = 1
        Me.BT_Envoi.Text = "3 - Envoi des modifications"
        Me.BT_Envoi.UseVisualStyleBackColor = True
        '
        'DGV_Data
        '
        Me.DGV_Data.AllowUserToAddRows = False
        Me.DGV_Data.AllowUserToDeleteRows = False
        Me.DGV_Data.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGV_Data.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.TypeDeMessage, Me.Prestashop, Me.MessageDeRemplacement})
        Me.DGV_Data.Location = New System.Drawing.Point(12, 41)
        Me.DGV_Data.Name = "DGV_Data"
        Me.DGV_Data.Size = New System.Drawing.Size(787, 150)
        Me.DGV_Data.TabIndex = 2
        '
        'TypeDeMessage
        '
        Me.TypeDeMessage.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCellsExceptHeader
        Me.TypeDeMessage.DataPropertyName = "TypeDeMessage"
        Me.TypeDeMessage.HeaderText = "Type de Message"
        Me.TypeDeMessage.MinimumWidth = 200
        Me.TypeDeMessage.Name = "TypeDeMessage"
        Me.TypeDeMessage.Width = 200
        '
        'Prestashop
        '
        Me.Prestashop.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCellsExceptHeader
        Me.Prestashop.DataPropertyName = "MessageActuelPrestashop"
        Me.Prestashop.HeaderText = "Message Actuel Prestashop"
        Me.Prestashop.MinimumWidth = 200
        Me.Prestashop.Name = "Prestashop"
        Me.Prestashop.ReadOnly = True
        Me.Prestashop.Width = 200
        '
        'MessageDeRemplacement
        '
        Me.MessageDeRemplacement.DataPropertyName = "MessageDeRemplacement"
        Me.MessageDeRemplacement.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.ComboBox
        Me.MessageDeRemplacement.HeaderText = "Message De Remplacement"
        Me.MessageDeRemplacement.MinimumWidth = 200
        Me.MessageDeRemplacement.Name = "MessageDeRemplacement"
        Me.MessageDeRemplacement.Width = 200
        '
        'FormMessageDispo
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(811, 275)
        Me.Controls.Add(Me.DGV_Data)
        Me.Controls.Add(Me.BT_Envoi)
        Me.Controls.Add(Me.BT_RecupLibelles)
        Me.Name = "FormMessageDispo"
        Me.Text = "Changer messsage de disponibilité en masse"
        CType(Me.DGV_Data, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents BT_RecupLibelles As Button
    Friend WithEvents BT_Envoi As Button
    Friend WithEvents DGV_Data As DataGridView
    Friend WithEvents TypeDeMessage As DataGridViewTextBoxColumn
    Friend WithEvents Prestashop As DataGridViewTextBoxColumn
    Friend WithEvents MessageDeRemplacement As DataGridViewComboBoxColumn
End Class
