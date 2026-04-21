<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormImportClients
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
        Me.BT_Importer = New System.Windows.Forms.Button()
        Me.CheckBoxAdresses = New System.Windows.Forms.CheckBox()
        Me.CheckBoxAvoirs = New System.Windows.Forms.CheckBox()
        Me.DateTimePickerUpdatedDateFrom = New System.Windows.Forms.DateTimePicker()
        Me.I_DateModif = New System.Windows.Forms.CheckBox()
        Me.I_OnlyErrors = New System.Windows.Forms.CheckBox()
        Me.BT_ExportRef = New System.Windows.Forms.Button()
        Me.BT_ImportRef = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'BT_Importer
        '
        Me.BT_Importer.Location = New System.Drawing.Point(230, 92)
        Me.BT_Importer.Name = "BT_Importer"
        Me.BT_Importer.Size = New System.Drawing.Size(75, 23)
        Me.BT_Importer.TabIndex = 0
        Me.BT_Importer.Text = "Importer"
        Me.BT_Importer.UseVisualStyleBackColor = True
        '
        'CheckBoxAdresses
        '
        Me.CheckBoxAdresses.AutoSize = True
        Me.CheckBoxAdresses.Location = New System.Drawing.Point(12, 12)
        Me.CheckBoxAdresses.Name = "CheckBoxAdresses"
        Me.CheckBoxAdresses.Size = New System.Drawing.Size(128, 17)
        Me.CheckBoxAdresses.TabIndex = 1
        Me.CheckBoxAdresses.Text = "Inclure les adresses ?"
        Me.CheckBoxAdresses.UseVisualStyleBackColor = True
        '
        'CheckBoxAvoirs
        '
        Me.CheckBoxAvoirs.AutoSize = True
        Me.CheckBoxAvoirs.Location = New System.Drawing.Point(12, 35)
        Me.CheckBoxAvoirs.Name = "CheckBoxAvoirs"
        Me.CheckBoxAvoirs.Size = New System.Drawing.Size(114, 17)
        Me.CheckBoxAvoirs.TabIndex = 2
        Me.CheckBoxAvoirs.Text = "Inclure les avoirs ?"
        Me.CheckBoxAvoirs.UseVisualStyleBackColor = True
        '
        'DateTimePickerUpdatedDateFrom
        '
        Me.DateTimePickerUpdatedDateFrom.Location = New System.Drawing.Point(125, 55)
        Me.DateTimePickerUpdatedDateFrom.Name = "DateTimePickerUpdatedDateFrom"
        Me.DateTimePickerUpdatedDateFrom.Size = New System.Drawing.Size(200, 20)
        Me.DateTimePickerUpdatedDateFrom.TabIndex = 15
        '
        'I_DateModif
        '
        Me.I_DateModif.AutoSize = True
        Me.I_DateModif.Location = New System.Drawing.Point(12, 58)
        Me.I_DateModif.Name = "I_DateModif"
        Me.I_DateModif.Size = New System.Drawing.Size(107, 17)
        Me.I_DateModif.TabIndex = 14
        Me.I_DateModif.Text = "Date de modif >="
        Me.I_DateModif.UseVisualStyleBackColor = True
        '
        'I_OnlyErrors
        '
        Me.I_OnlyErrors.AutoSize = True
        Me.I_OnlyErrors.Location = New System.Drawing.Point(12, 81)
        Me.I_OnlyErrors.Name = "I_OnlyErrors"
        Me.I_OnlyErrors.Size = New System.Drawing.Size(127, 17)
        Me.I_OnlyErrors.TabIndex = 16
        Me.I_OnlyErrors.Text = "Seulement les erreurs"
        Me.I_OnlyErrors.UseVisualStyleBackColor = True
        '
        'BT_ExportRef
        '
        Me.BT_ExportRef.Location = New System.Drawing.Point(13, 113)
        Me.BT_ExportRef.Name = "BT_ExportRef"
        Me.BT_ExportRef.Size = New System.Drawing.Size(75, 23)
        Me.BT_ExportRef.TabIndex = 17
        Me.BT_ExportRef.Text = "Export Refs"
        Me.BT_ExportRef.UseVisualStyleBackColor = True
        '
        'BT_ImportRef
        '
        Me.BT_ImportRef.Location = New System.Drawing.Point(94, 113)
        Me.BT_ImportRef.Name = "BT_ImportRef"
        Me.BT_ImportRef.Size = New System.Drawing.Size(75, 23)
        Me.BT_ImportRef.TabIndex = 17
        Me.BT_ImportRef.Text = "Import Refs"
        Me.BT_ImportRef.UseVisualStyleBackColor = True
        '
        'FormImportClients
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(364, 148)
        Me.Controls.Add(Me.BT_ImportRef)
        Me.Controls.Add(Me.BT_ExportRef)
        Me.Controls.Add(Me.I_OnlyErrors)
        Me.Controls.Add(Me.DateTimePickerUpdatedDateFrom)
        Me.Controls.Add(Me.I_DateModif)
        Me.Controls.Add(Me.CheckBoxAvoirs)
        Me.Controls.Add(Me.CheckBoxAdresses)
        Me.Controls.Add(Me.BT_Importer)
        Me.Name = "FormImportClients"
        Me.Text = "Importer les clients vers PS"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents BT_Importer As Button
    Friend WithEvents CheckBoxAdresses As CheckBox
    Friend WithEvents CheckBoxAvoirs As CheckBox
    Friend WithEvents DateTimePickerUpdatedDateFrom As DateTimePicker
    Friend WithEvents I_DateModif As CheckBox
    Friend WithEvents I_OnlyErrors As CheckBox
    Friend WithEvents BT_ExportRef As Button
    Friend WithEvents BT_ImportRef As Button
End Class
