<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormImportArticleParSousFamilleAncienSite
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
        Me.I_Famille = New System.Windows.Forms.ComboBox()
        Me.I_SousFamille = New System.Windows.Forms.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.BT_Import = New System.Windows.Forms.Button()
        Me.I_LegacyImage = New System.Windows.Forms.CheckBox()
        Me.I_OnlyErrors = New System.Windows.Forms.CheckBox()
        Me.I_OnlyNewSync = New System.Windows.Forms.CheckBox()
        Me.DateTimePickerUpdatedDateFrom = New System.Windows.Forms.DateTimePicker()
        Me.I_DateModif = New System.Windows.Forms.CheckBox()
        Me.I_ImportStock = New System.Windows.Forms.CheckBox()
        Me.I_DeleteBeforeImport = New System.Windows.Forms.CheckBox()
        Me.SuspendLayout()
        '
        'I_Famille
        '
        Me.I_Famille.DisplayMember = "Famille"
        Me.I_Famille.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.I_Famille.FormattingEnabled = True
        Me.I_Famille.Location = New System.Drawing.Point(92, 12)
        Me.I_Famille.Name = "I_Famille"
        Me.I_Famille.Size = New System.Drawing.Size(121, 21)
        Me.I_Famille.TabIndex = 5
        Me.I_Famille.ValueMember = "Famille"
        '
        'I_SousFamille
        '
        Me.I_SousFamille.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.I_SousFamille.FormattingEnabled = True
        Me.I_SousFamille.Location = New System.Drawing.Point(92, 39)
        Me.I_SousFamille.Name = "I_SousFamille"
        Me.I_SousFamille.Size = New System.Drawing.Size(121, 21)
        Me.I_SousFamille.TabIndex = 6
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(2, 42)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(66, 13)
        Me.Label4.TabIndex = 9
        Me.Label4.Text = "Sous Famille" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(2, 15)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(39, 13)
        Me.Label3.TabIndex = 8
        Me.Label3.Text = "Famille"
        '
        'BT_Import
        '
        Me.BT_Import.Location = New System.Drawing.Point(12, 233)
        Me.BT_Import.Name = "BT_Import"
        Me.BT_Import.Size = New System.Drawing.Size(75, 23)
        Me.BT_Import.TabIndex = 10
        Me.BT_Import.Text = "Importer"
        Me.BT_Import.UseVisualStyleBackColor = True
        '
        'I_LegacyImage
        '
        Me.I_LegacyImage.AutoSize = True
        Me.I_LegacyImage.Location = New System.Drawing.Point(92, 200)
        Me.I_LegacyImage.Name = "I_LegacyImage"
        Me.I_LegacyImage.Size = New System.Drawing.Size(154, 17)
        Me.I_LegacyImage.TabIndex = 11
        Me.I_LegacyImage.Text = "Importer images ancien site"
        Me.I_LegacyImage.UseVisualStyleBackColor = True
        '
        'I_OnlyErrors
        '
        Me.I_OnlyErrors.AutoSize = True
        Me.I_OnlyErrors.Location = New System.Drawing.Point(92, 154)
        Me.I_OnlyErrors.Name = "I_OnlyErrors"
        Me.I_OnlyErrors.Size = New System.Drawing.Size(127, 17)
        Me.I_OnlyErrors.TabIndex = 12
        Me.I_OnlyErrors.Text = "Seulement les erreurs"
        Me.I_OnlyErrors.UseVisualStyleBackColor = True
        '
        'I_OnlyNewSync
        '
        Me.I_OnlyNewSync.AutoSize = True
        Me.I_OnlyNewSync.Location = New System.Drawing.Point(92, 131)
        Me.I_OnlyNewSync.Name = "I_OnlyNewSync"
        Me.I_OnlyNewSync.Size = New System.Drawing.Size(192, 17)
        Me.I_OnlyNewSync.TabIndex = 12
        Me.I_OnlyNewSync.Text = "Seulement les syncros manquantes"
        Me.I_OnlyNewSync.UseVisualStyleBackColor = True
        '
        'DateTimePickerUpdatedDateFrom
        '
        Me.DateTimePickerUpdatedDateFrom.Location = New System.Drawing.Point(205, 101)
        Me.DateTimePickerUpdatedDateFrom.Name = "DateTimePickerUpdatedDateFrom"
        Me.DateTimePickerUpdatedDateFrom.Size = New System.Drawing.Size(200, 20)
        Me.DateTimePickerUpdatedDateFrom.TabIndex = 13
        Me.DateTimePickerUpdatedDateFrom.Visible = False
        '
        'I_DateModif
        '
        Me.I_DateModif.AutoSize = True
        Me.I_DateModif.Location = New System.Drawing.Point(92, 104)
        Me.I_DateModif.Name = "I_DateModif"
        Me.I_DateModif.Size = New System.Drawing.Size(107, 17)
        Me.I_DateModif.TabIndex = 12
        Me.I_DateModif.Text = "Date de modif >="
        Me.I_DateModif.UseVisualStyleBackColor = True
        '
        'I_ImportStock
        '
        Me.I_ImportStock.AutoSize = True
        Me.I_ImportStock.Location = New System.Drawing.Point(92, 177)
        Me.I_ImportStock.Name = "I_ImportStock"
        Me.I_ImportStock.Size = New System.Drawing.Size(104, 17)
        Me.I_ImportStock.TabIndex = 11
        Me.I_ImportStock.Text = "Importer le stock"
        Me.I_ImportStock.UseVisualStyleBackColor = True
        '
        'I_DeleteBeforeImport
        '
        Me.I_DeleteBeforeImport.AutoSize = True
        Me.I_DeleteBeforeImport.Location = New System.Drawing.Point(92, 78)
        Me.I_DeleteBeforeImport.Name = "I_DeleteBeforeImport"
        Me.I_DeleteBeforeImport.Size = New System.Drawing.Size(146, 17)
        Me.I_DeleteBeforeImport.TabIndex = 14
        Me.I_DeleteBeforeImport.Text = "! Supprimer avant import !"
        Me.I_DeleteBeforeImport.UseVisualStyleBackColor = True
        '
        'FormImportArticleParSousFamilleAncienSite
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(553, 268)
        Me.Controls.Add(Me.I_DeleteBeforeImport)
        Me.Controls.Add(Me.DateTimePickerUpdatedDateFrom)
        Me.Controls.Add(Me.I_DateModif)
        Me.Controls.Add(Me.I_OnlyNewSync)
        Me.Controls.Add(Me.I_OnlyErrors)
        Me.Controls.Add(Me.I_ImportStock)
        Me.Controls.Add(Me.I_LegacyImage)
        Me.Controls.Add(Me.BT_Import)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.I_Famille)
        Me.Controls.Add(Me.I_SousFamille)
        Me.Name = "FormImportArticleParSousFamilleAncienSite"
        Me.Text = "Importer articles par sous famille"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents I_Famille As ComboBox
    Friend WithEvents I_SousFamille As ComboBox
    Friend WithEvents Label4 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents BT_Import As Button
    Friend WithEvents I_LegacyImage As CheckBox
    Friend WithEvents I_OnlyErrors As CheckBox
    Friend WithEvents I_OnlyNewSync As CheckBox
    Friend WithEvents DateTimePickerUpdatedDateFrom As DateTimePicker
    Friend WithEvents I_DateModif As CheckBox
    Friend WithEvents I_ImportStock As CheckBox
    Friend WithEvents I_DeleteBeforeImport As CheckBox
End Class
