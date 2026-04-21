Namespace DataGridViewPrinter
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class PrintOptions
        Inherits System.Windows.Forms.Form

        'Form overrides dispose to clean up the component list.
        <System.Diagnostics.DebuggerNonUserCode()> _
        Protected Overrides Sub Dispose(ByVal disposing As Boolean)
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
            MyBase.Dispose(disposing)
        End Sub

        'Required by the Windows Form Designer
        Private components As System.ComponentModel.IContainer

        'NOTE: The following procedure is required by the Windows Form Designer
        'It can be modified using the Windows Form Designer.  
        'Do not modify it using the code editor.
        <System.Diagnostics.DebuggerStepThrough()> _
        Private Sub InitializeComponent()
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(PrintOptions))
            Me.chklst = New System.Windows.Forms.CheckedListBox
            Me.btnOK = New System.Windows.Forms.Button
            Me.BT_Annuler = New System.Windows.Forms.Button
            Me.gboxRowsToPrint = New System.Windows.Forms.GroupBox
            Me.rdoSelectedRows = New System.Windows.Forms.RadioButton
            Me.rdoAllRows = New System.Windows.Forms.RadioButton
            Me.btnFont = New System.Windows.Forms.Button
            Me.txtTitle = New System.Windows.Forms.TextBox
            Me.CheckBoxCenterReportOnPage = New System.Windows.Forms.CheckBox
            Me.CheckBoxSelectColumns = New System.Windows.Forms.CheckBox
            Me.CheckBoxNoneItems = New System.Windows.Forms.CheckBox
            Me.ButtonClearAll = New System.Windows.Forms.Button
            Me.CheckBoxPrintRowColors = New System.Windows.Forms.CheckBox
            Me.I_Imprimante = New System.Windows.Forms.ComboBox
            Me.GroupBox1 = New System.Windows.Forms.GroupBox
            Me.IG_MEP = New System.Windows.Forms.GroupBox
            Me.IG_Orientation = New System.Windows.Forms.GroupBox
            Me.IC_Paysage = New System.Windows.Forms.RadioButton
            Me.IC_Portrait = New System.Windows.Forms.RadioButton
            Me.gboxRowsToPrint.SuspendLayout()
            Me.GroupBox1.SuspendLayout()
            Me.IG_MEP.SuspendLayout()
            Me.IG_Orientation.SuspendLayout()
            Me.SuspendLayout()
            '
            'chklst
            '
            Me.chklst.CheckOnClick = True
            Me.chklst.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.chklst.FormattingEnabled = True
            Me.chklst.Location = New System.Drawing.Point(9, 43)
            Me.chklst.Name = "chklst"
            Me.chklst.Size = New System.Drawing.Size(185, 244)
            Me.chklst.TabIndex = 0
            '
            'btnOK
            '
            Me.btnOK.BackColor = System.Drawing.SystemColors.Control
            Me.btnOK.Cursor = System.Windows.Forms.Cursors.Default
            Me.btnOK.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.btnOK.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
            Me.btnOK.ForeColor = System.Drawing.SystemColors.ControlText
            Me.btnOK.Image = CType(resources.GetObject("btnOK.Image"), System.Drawing.Image)
            Me.btnOK.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
            Me.btnOK.Location = New System.Drawing.Point(250, 289)
            Me.btnOK.Name = "btnOK"
            Me.btnOK.RightToLeft = System.Windows.Forms.RightToLeft.No
            Me.btnOK.Size = New System.Drawing.Size(105, 25)
            Me.btnOK.TabIndex = 4
            Me.btnOK.Text = "&OK"
            Me.btnOK.UseVisualStyleBackColor = False
            '
            'BT_Annuler
            '
            Me.BT_Annuler.BackColor = System.Drawing.SystemColors.Control
            Me.BT_Annuler.Cursor = System.Windows.Forms.Cursors.Default
            Me.BT_Annuler.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.BT_Annuler.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.BT_Annuler.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
            Me.BT_Annuler.ForeColor = System.Drawing.SystemColors.ControlText
            Me.BT_Annuler.Image = CType(resources.GetObject("BT_Annuler.Image"), System.Drawing.Image)
            Me.BT_Annuler.Location = New System.Drawing.Point(250, 320)
            Me.BT_Annuler.Name = "BT_Annuler"
            Me.BT_Annuler.RightToLeft = System.Windows.Forms.RightToLeft.No
            Me.BT_Annuler.Size = New System.Drawing.Size(105, 25)
            Me.BT_Annuler.TabIndex = 5
            Me.BT_Annuler.Text = "&Annuler"
            Me.BT_Annuler.UseVisualStyleBackColor = False
            '
            'gboxRowsToPrint
            '
            Me.gboxRowsToPrint.Controls.Add(Me.rdoSelectedRows)
            Me.gboxRowsToPrint.Controls.Add(Me.rdoAllRows)
            Me.gboxRowsToPrint.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.gboxRowsToPrint.Location = New System.Drawing.Point(208, 58)
            Me.gboxRowsToPrint.Name = "gboxRowsToPrint"
            Me.gboxRowsToPrint.Size = New System.Drawing.Size(185, 42)
            Me.gboxRowsToPrint.TabIndex = 8
            Me.gboxRowsToPrint.TabStop = False
            Me.gboxRowsToPrint.Text = "Lignes"
            '
            'rdoSelectedRows
            '
            Me.rdoSelectedRows.AutoSize = True
            Me.rdoSelectedRows.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.rdoSelectedRows.Location = New System.Drawing.Point(82, 19)
            Me.rdoSelectedRows.Name = "rdoSelectedRows"
            Me.rdoSelectedRows.Size = New System.Drawing.Size(78, 17)
            Me.rdoSelectedRows.TabIndex = 1
            Me.rdoSelectedRows.TabStop = True
            Me.rdoSelectedRows.Text = "Selection"
            Me.rdoSelectedRows.UseVisualStyleBackColor = True
            '
            'rdoAllRows
            '
            Me.rdoAllRows.AutoSize = True
            Me.rdoAllRows.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.rdoAllRows.Location = New System.Drawing.Point(9, 19)
            Me.rdoAllRows.Name = "rdoAllRows"
            Me.rdoAllRows.Size = New System.Drawing.Size(64, 17)
            Me.rdoAllRows.TabIndex = 0
            Me.rdoAllRows.TabStop = True
            Me.rdoAllRows.Text = "Toutes"
            Me.rdoAllRows.UseVisualStyleBackColor = True
            '
            'btnFont
            '
            Me.btnFont.BackColor = System.Drawing.SystemColors.Control
            Me.btnFont.Cursor = System.Windows.Forms.Cursors.Default
            Me.btnFont.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.btnFont.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
            Me.btnFont.ForeColor = System.Drawing.SystemColors.ControlText
            Me.btnFont.Image = CType(resources.GetObject("btnFont.Image"), System.Drawing.Image)
            Me.btnFont.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
            Me.btnFont.Location = New System.Drawing.Point(9, 19)
            Me.btnFont.Name = "btnFont"
            Me.btnFont.RightToLeft = System.Windows.Forms.RightToLeft.No
            Me.btnFont.Size = New System.Drawing.Size(80, 25)
            Me.btnFont.TabIndex = 9
            Me.btnFont.Text = "&Police"
            Me.btnFont.UseVisualStyleBackColor = False
            '
            'txtTitle
            '
            Me.txtTitle.AcceptsReturn = True
            Me.txtTitle.Location = New System.Drawing.Point(3, 2)
            Me.txtTitle.Multiline = True
            Me.txtTitle.Name = "txtTitle"
            Me.txtTitle.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
            Me.txtTitle.Size = New System.Drawing.Size(381, 50)
            Me.txtTitle.TabIndex = 10
            '
            'CheckBoxCenterReportOnPage
            '
            Me.CheckBoxCenterReportOnPage.AutoSize = True
            Me.CheckBoxCenterReportOnPage.Location = New System.Drawing.Point(9, 54)
            Me.CheckBoxCenterReportOnPage.Name = "CheckBoxCenterReportOnPage"
            Me.CheckBoxCenterReportOnPage.Size = New System.Drawing.Size(109, 17)
            Me.CheckBoxCenterReportOnPage.TabIndex = 12
            Me.CheckBoxCenterReportOnPage.Text = "Centrer le tableau"
            Me.CheckBoxCenterReportOnPage.UseVisualStyleBackColor = True
            '
            'CheckBoxSelectColumns
            '
            Me.CheckBoxSelectColumns.AutoSize = True
            Me.CheckBoxSelectColumns.Location = New System.Drawing.Point(9, 20)
            Me.CheckBoxSelectColumns.Name = "CheckBoxSelectColumns"
            Me.CheckBoxSelectColumns.Size = New System.Drawing.Size(59, 17)
            Me.CheckBoxSelectColumns.TabIndex = 13
            Me.CheckBoxSelectColumns.Text = "Toutes"
            Me.CheckBoxSelectColumns.UseVisualStyleBackColor = True
            '
            'CheckBoxNoneItems
            '
            Me.CheckBoxNoneItems.AutoSize = True
            Me.CheckBoxNoneItems.Location = New System.Drawing.Point(95, 23)
            Me.CheckBoxNoneItems.Name = "CheckBoxNoneItems"
            Me.CheckBoxNoneItems.Size = New System.Drawing.Size(52, 17)
            Me.CheckBoxNoneItems.TabIndex = 14
            Me.CheckBoxNoneItems.Text = "None"
            Me.CheckBoxNoneItems.UseVisualStyleBackColor = True
            Me.CheckBoxNoneItems.Visible = False
            '
            'ButtonClearAll
            '
            Me.ButtonClearAll.Location = New System.Drawing.Point(86, 16)
            Me.ButtonClearAll.Name = "ButtonClearAll"
            Me.ButtonClearAll.Size = New System.Drawing.Size(64, 21)
            Me.ButtonClearAll.TabIndex = 15
            Me.ButtonClearAll.Text = "Effacer"
            Me.ButtonClearAll.UseVisualStyleBackColor = True
            '
            'CheckBoxPrintRowColors
            '
            Me.CheckBoxPrintRowColors.AutoSize = True
            Me.CheckBoxPrintRowColors.Location = New System.Drawing.Point(9, 77)
            Me.CheckBoxPrintRowColors.Name = "CheckBoxPrintRowColors"
            Me.CheckBoxPrintRowColors.Size = New System.Drawing.Size(142, 17)
            Me.CheckBoxPrintRowColors.TabIndex = 16
            Me.CheckBoxPrintRowColors.Text = "couleur de ligne alternée"
            Me.CheckBoxPrintRowColors.UseVisualStyleBackColor = True
            '
            'I_Imprimante
            '
            Me.I_Imprimante.FormattingEnabled = True
            Me.I_Imprimante.Location = New System.Drawing.Point(6, 100)
            Me.I_Imprimante.Name = "I_Imprimante"
            Me.I_Imprimante.Size = New System.Drawing.Size(173, 21)
            Me.I_Imprimante.TabIndex = 17
            '
            'GroupBox1
            '
            Me.GroupBox1.Controls.Add(Me.CheckBoxSelectColumns)
            Me.GroupBox1.Controls.Add(Me.ButtonClearAll)
            Me.GroupBox1.Controls.Add(Me.chklst)
            Me.GroupBox1.Location = New System.Drawing.Point(3, 58)
            Me.GroupBox1.Name = "GroupBox1"
            Me.GroupBox1.Size = New System.Drawing.Size(199, 294)
            Me.GroupBox1.TabIndex = 18
            Me.GroupBox1.TabStop = False
            Me.GroupBox1.Text = "Colonnes"
            '
            'IG_MEP
            '
            Me.IG_MEP.Controls.Add(Me.IG_Orientation)
            Me.IG_MEP.Controls.Add(Me.CheckBoxPrintRowColors)
            Me.IG_MEP.Controls.Add(Me.CheckBoxCenterReportOnPage)
            Me.IG_MEP.Controls.Add(Me.I_Imprimante)
            Me.IG_MEP.Controls.Add(Me.btnFont)
            Me.IG_MEP.Controls.Add(Me.CheckBoxNoneItems)
            Me.IG_MEP.Location = New System.Drawing.Point(208, 106)
            Me.IG_MEP.Name = "IG_MEP"
            Me.IG_MEP.Size = New System.Drawing.Size(185, 166)
            Me.IG_MEP.TabIndex = 19
            Me.IG_MEP.TabStop = False
            Me.IG_MEP.Text = "Mise en page"
            '
            'IG_Orientation
            '
            Me.IG_Orientation.Controls.Add(Me.IC_Paysage)
            Me.IG_Orientation.Controls.Add(Me.IC_Portrait)
            Me.IG_Orientation.Location = New System.Drawing.Point(6, 126)
            Me.IG_Orientation.Name = "IG_Orientation"
            Me.IG_Orientation.Size = New System.Drawing.Size(173, 34)
            Me.IG_Orientation.TabIndex = 18
            Me.IG_Orientation.TabStop = False
            Me.IG_Orientation.Text = "Orientation"
            '
            'IC_Paysage
            '
            Me.IC_Paysage.AutoSize = True
            Me.IC_Paysage.Location = New System.Drawing.Point(76, 11)
            Me.IC_Paysage.Name = "IC_Paysage"
            Me.IC_Paysage.Size = New System.Drawing.Size(66, 17)
            Me.IC_Paysage.TabIndex = 1
            Me.IC_Paysage.TabStop = True
            Me.IC_Paysage.Text = "Paysage"
            Me.IC_Paysage.UseVisualStyleBackColor = True
            '
            'IC_Portrait
            '
            Me.IC_Portrait.AutoSize = True
            Me.IC_Portrait.Location = New System.Drawing.Point(7, 11)
            Me.IC_Portrait.Name = "IC_Portrait"
            Me.IC_Portrait.Size = New System.Drawing.Size(58, 17)
            Me.IC_Portrait.TabIndex = 0
            Me.IC_Portrait.TabStop = True
            Me.IC_Portrait.Text = "Portrait"
            Me.IC_Portrait.UseVisualStyleBackColor = True
            '
            'PrintOptions
            '
            Me.AcceptButton = Me.btnOK
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.CancelButton = Me.BT_Annuler
            Me.ClientSize = New System.Drawing.Size(396, 357)
            Me.Controls.Add(Me.IG_MEP)
            Me.Controls.Add(Me.GroupBox1)
            Me.Controls.Add(Me.txtTitle)
            Me.Controls.Add(Me.gboxRowsToPrint)
            Me.Controls.Add(Me.btnOK)
            Me.Controls.Add(Me.BT_Annuler)
            Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
            Me.Name = "PrintOptions"
            Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
            Me.Text = "options d'impression"
            Me.gboxRowsToPrint.ResumeLayout(False)
            Me.gboxRowsToPrint.PerformLayout()
            Me.GroupBox1.ResumeLayout(False)
            Me.GroupBox1.PerformLayout()
            Me.IG_MEP.ResumeLayout(False)
            Me.IG_MEP.PerformLayout()
            Me.IG_Orientation.ResumeLayout(False)
            Me.IG_Orientation.PerformLayout()
            Me.ResumeLayout(False)
            Me.PerformLayout()

        End Sub
        Friend WithEvents chklst As System.Windows.Forms.CheckedListBox
        Protected WithEvents btnOK As System.Windows.Forms.Button
        Protected WithEvents BT_Annuler As System.Windows.Forms.Button
        Friend WithEvents gboxRowsToPrint As System.Windows.Forms.GroupBox
        Friend WithEvents rdoAllRows As System.Windows.Forms.RadioButton
        Friend WithEvents rdoSelectedRows As System.Windows.Forms.RadioButton
        Protected WithEvents btnFont As System.Windows.Forms.Button
        Friend WithEvents txtTitle As System.Windows.Forms.TextBox
        Friend WithEvents CheckBoxCenterReportOnPage As System.Windows.Forms.CheckBox
        Friend WithEvents CheckBoxSelectColumns As System.Windows.Forms.CheckBox
        Friend WithEvents CheckBoxNoneItems As System.Windows.Forms.CheckBox
        Friend WithEvents ButtonClearAll As System.Windows.Forms.Button
        Friend WithEvents CheckBoxPrintRowColors As System.Windows.Forms.CheckBox
        Friend WithEvents I_Imprimante As System.Windows.Forms.ComboBox
        Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
        Friend WithEvents IG_MEP As System.Windows.Forms.GroupBox
        Friend WithEvents IG_Orientation As System.Windows.Forms.GroupBox
        Friend WithEvents IC_Paysage As System.Windows.Forms.RadioButton
        Friend WithEvents IC_Portrait As System.Windows.Forms.RadioButton
    End Class
End Namespace