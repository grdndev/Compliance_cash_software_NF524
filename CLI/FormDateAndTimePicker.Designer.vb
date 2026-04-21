<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormDateAndTimePicker
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
        Me.MonthCalendar1 = New System.Windows.Forms.MonthCalendar
        Me.DateTimePicker1 = New System.Windows.Forms.DateTimePicker
        Me.BT_OK = New System.Windows.Forms.Button
        Me.BT_Annuler = New System.Windows.Forms.Button
        Me.SuspendLayout()
        '
        'MonthCalendar1
        '
        Me.MonthCalendar1.Location = New System.Drawing.Point(9, 5)
        Me.MonthCalendar1.Name = "MonthCalendar1"
        Me.MonthCalendar1.TabIndex = 1
        '
        'DateTimePicker1
        '
        Me.DateTimePicker1.CustomFormat = ""
        Me.DateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Time
        Me.DateTimePicker1.Location = New System.Drawing.Point(11, 168)
        Me.DateTimePicker1.Name = "DateTimePicker1"
        Me.DateTimePicker1.ShowUpDown = True
        Me.DateTimePicker1.Size = New System.Drawing.Size(225, 20)
        Me.DateTimePicker1.TabIndex = 2
        '
        'BT_OK
        '
        Me.BT_OK.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.BT_OK.Location = New System.Drawing.Point(10, 188)
        Me.BT_OK.Name = "BT_OK"
        Me.BT_OK.Size = New System.Drawing.Size(114, 21)
        Me.BT_OK.TabIndex = 0
        Me.BT_OK.Text = "OK"
        Me.BT_OK.UseVisualStyleBackColor = True
        '
        'BT_Annuler
        '
        Me.BT_Annuler.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.BT_Annuler.Location = New System.Drawing.Point(130, 188)
        Me.BT_Annuler.Name = "BT_Annuler"
        Me.BT_Annuler.Size = New System.Drawing.Size(106, 21)
        Me.BT_Annuler.TabIndex = 0
        Me.BT_Annuler.Text = "Annuler"
        Me.BT_Annuler.UseVisualStyleBackColor = True
        '
        'FormDateAndTimePicker
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(242, 215)
        Me.ControlBox = False
        Me.Controls.Add(Me.BT_Annuler)
        Me.Controls.Add(Me.BT_OK)
        Me.Controls.Add(Me.DateTimePicker1)
        Me.Controls.Add(Me.MonthCalendar1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Name = "FormDateAndTimePicker"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Veuillez-choisir"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents MonthCalendar1 As System.Windows.Forms.MonthCalendar
    Friend WithEvents DateTimePicker1 As System.Windows.Forms.DateTimePicker
    Friend WithEvents BT_OK As System.Windows.Forms.Button
    Friend WithEvents BT_Annuler As System.Windows.Forms.Button
End Class
