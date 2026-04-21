<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormFournisseurRecherche
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormFournisseurRecherche))
        Me.DGview = New System.Windows.Forms.DataGridView
        Me.Actif = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Me.Ref = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.SociétéDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.NomDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PrenomDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.CodePostalDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.VilleDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PaysDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.NbArticleDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.VRechercheFournisseurBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.CLIDataSet = New CLI.CLIDataSet
        Me.ContextMenuStripRecherche = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.SuppressionToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.I_Reference = New System.Windows.Forms.TextBox
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.I_Pays = New System.Windows.Forms.ComboBox
        Me.I_NbArticlesMax = New System.Windows.Forms.TextBox
        Me.VilleTextBox = New System.Windows.Forms.TextBox
        Me.I_Societe = New System.Windows.Forms.TextBox
        Me.CodePostalTextBox = New System.Windows.Forms.TextBox
        Me.I_NbArticlesMin = New System.Windows.Forms.TextBox
        Me.Label9 = New System.Windows.Forms.Label
        Me.I_Active = New System.Windows.Forms.ComboBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label_Ville = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.ToolTip = New System.Windows.Forms.ToolTip(Me.components)
        Me.StatusStrip = New System.Windows.Forms.StatusStrip
        Me.ToolStripStatusLabelNbEnregistrements = New System.Windows.Forms.ToolStripStatusLabel
        Me.BT_Go = New System.Windows.Forms.Button
        Me.BT_Nouveau_Fournisseur = New System.Windows.Forms.Button
        Me.BT_RAZ = New System.Windows.Forms.Button
        Me.BT_Fermer = New System.Windows.Forms.Button
        Me.V_Recherche_ArticleBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.V_Recherche_ArticleTableAdapter = New CLI.CLIDataSetTableAdapters.V_Recherche_ArticleTableAdapter
        Me.V_Recherche_FournisseurTableAdapter = New CLI.CLIDataSetTableAdapters.V_Recherche_FournisseurTableAdapter
        CType(Me.DGview, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.VRechercheFournisseurBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CLIDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ContextMenuStripRecherche.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.StatusStrip.SuspendLayout()
        CType(Me.V_Recherche_ArticleBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'DGview
        '
        Me.DGview.AllowUserToAddRows = False
        Me.DGview.AllowUserToDeleteRows = False
        Me.DGview.AllowUserToResizeRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.DGview.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.DGview.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DGview.AutoGenerateColumns = False
        Me.DGview.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DGview.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.DGview.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Actif, Me.Ref, Me.SociétéDataGridViewTextBoxColumn, Me.NomDataGridViewTextBoxColumn, Me.PrenomDataGridViewTextBoxColumn, Me.CodePostalDataGridViewTextBoxColumn, Me.VilleDataGridViewTextBoxColumn, Me.PaysDataGridViewTextBoxColumn, Me.NbArticleDataGridViewTextBoxColumn})
        Me.DGview.DataSource = Me.VRechercheFournisseurBindingSource
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DGview.DefaultCellStyle = DataGridViewCellStyle3
        Me.DGview.Location = New System.Drawing.Point(4, 209)
        Me.DGview.MultiSelect = False
        Me.DGview.Name = "DGview"
        Me.DGview.ReadOnly = True
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DGview.RowHeadersDefaultCellStyle = DataGridViewCellStyle4
        Me.DGview.RowHeadersVisible = False
        Me.DGview.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DGview.Size = New System.Drawing.Size(918, 349)
        Me.DGview.TabIndex = 3
        '
        'Actif
        '
        Me.Actif.DataPropertyName = "Actif"
        Me.Actif.HeaderText = "Actif ?"
        Me.Actif.Name = "Actif"
        Me.Actif.ReadOnly = True
        Me.Actif.Width = 43
        '
        'Ref
        '
        Me.Ref.DataPropertyName = "Ref"
        Me.Ref.HeaderText = "Ref"
        Me.Ref.Name = "Ref"
        Me.Ref.ReadOnly = True
        Me.Ref.Width = 49
        '
        'SociétéDataGridViewTextBoxColumn
        '
        Me.SociétéDataGridViewTextBoxColumn.DataPropertyName = "Société"
        Me.SociétéDataGridViewTextBoxColumn.HeaderText = "Société"
        Me.SociétéDataGridViewTextBoxColumn.Name = "SociétéDataGridViewTextBoxColumn"
        Me.SociétéDataGridViewTextBoxColumn.ReadOnly = True
        Me.SociétéDataGridViewTextBoxColumn.Width = 68
        '
        'NomDataGridViewTextBoxColumn
        '
        Me.NomDataGridViewTextBoxColumn.DataPropertyName = "Nom"
        Me.NomDataGridViewTextBoxColumn.HeaderText = "Nom"
        Me.NomDataGridViewTextBoxColumn.Name = "NomDataGridViewTextBoxColumn"
        Me.NomDataGridViewTextBoxColumn.ReadOnly = True
        Me.NomDataGridViewTextBoxColumn.Width = 54
        '
        'PrenomDataGridViewTextBoxColumn
        '
        Me.PrenomDataGridViewTextBoxColumn.DataPropertyName = "Prenom"
        Me.PrenomDataGridViewTextBoxColumn.HeaderText = "Prenom"
        Me.PrenomDataGridViewTextBoxColumn.Name = "PrenomDataGridViewTextBoxColumn"
        Me.PrenomDataGridViewTextBoxColumn.ReadOnly = True
        Me.PrenomDataGridViewTextBoxColumn.Width = 68
        '
        'CodePostalDataGridViewTextBoxColumn
        '
        Me.CodePostalDataGridViewTextBoxColumn.DataPropertyName = "CodePostal"
        Me.CodePostalDataGridViewTextBoxColumn.HeaderText = "Code Postal"
        Me.CodePostalDataGridViewTextBoxColumn.Name = "CodePostalDataGridViewTextBoxColumn"
        Me.CodePostalDataGridViewTextBoxColumn.ReadOnly = True
        Me.CodePostalDataGridViewTextBoxColumn.Width = 89
        '
        'VilleDataGridViewTextBoxColumn
        '
        Me.VilleDataGridViewTextBoxColumn.DataPropertyName = "Ville"
        Me.VilleDataGridViewTextBoxColumn.HeaderText = "Ville"
        Me.VilleDataGridViewTextBoxColumn.Name = "VilleDataGridViewTextBoxColumn"
        Me.VilleDataGridViewTextBoxColumn.ReadOnly = True
        Me.VilleDataGridViewTextBoxColumn.Width = 51
        '
        'PaysDataGridViewTextBoxColumn
        '
        Me.PaysDataGridViewTextBoxColumn.DataPropertyName = "Pays"
        Me.PaysDataGridViewTextBoxColumn.HeaderText = "Pays"
        Me.PaysDataGridViewTextBoxColumn.Name = "PaysDataGridViewTextBoxColumn"
        Me.PaysDataGridViewTextBoxColumn.ReadOnly = True
        Me.PaysDataGridViewTextBoxColumn.Width = 55
        '
        'NbArticleDataGridViewTextBoxColumn
        '
        Me.NbArticleDataGridViewTextBoxColumn.DataPropertyName = "NbArticle"
        Me.NbArticleDataGridViewTextBoxColumn.HeaderText = "Nb Article"
        Me.NbArticleDataGridViewTextBoxColumn.Name = "NbArticleDataGridViewTextBoxColumn"
        Me.NbArticleDataGridViewTextBoxColumn.ReadOnly = True
        Me.NbArticleDataGridViewTextBoxColumn.Width = 78
        '
        'VRechercheFournisseurBindingSource
        '
        Me.VRechercheFournisseurBindingSource.DataMember = "V_Recherche_Fournisseur"
        Me.VRechercheFournisseurBindingSource.DataSource = Me.CLIDataSet
        '
        'CLIDataSet
        '
        Me.CLIDataSet.DataSetName = "CLIDataSet"
        Me.CLIDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'ContextMenuStripRecherche
        '
        Me.ContextMenuStripRecherche.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.SuppressionToolStripMenuItem})
        Me.ContextMenuStripRecherche.Name = "ContextMenuStrip"
        Me.ContextMenuStripRecherche.Size = New System.Drawing.Size(139, 26)
        '
        'SuppressionToolStripMenuItem
        '
        Me.SuppressionToolStripMenuItem.Image = Global.CLI.My.Resources.Resources.DeleteHS
        Me.SuppressionToolStripMenuItem.Name = "SuppressionToolStripMenuItem"
        Me.SuppressionToolStripMenuItem.Size = New System.Drawing.Size(138, 22)
        Me.SuppressionToolStripMenuItem.Text = "Suppression"
        '
        'I_Reference
        '
        Me.I_Reference.Location = New System.Drawing.Point(69, 24)
        Me.I_Reference.Name = "I_Reference"
        Me.I_Reference.Size = New System.Drawing.Size(100, 20)
        Me.I_Reference.TabIndex = 2
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.I_Pays)
        Me.GroupBox1.Controls.Add(Me.I_NbArticlesMax)
        Me.GroupBox1.Controls.Add(Me.VilleTextBox)
        Me.GroupBox1.Controls.Add(Me.I_Societe)
        Me.GroupBox1.Controls.Add(Me.CodePostalTextBox)
        Me.GroupBox1.Controls.Add(Me.I_NbArticlesMin)
        Me.GroupBox1.Controls.Add(Me.Label9)
        Me.GroupBox1.Controls.Add(Me.I_Active)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.Label_Ville)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Location = New System.Drawing.Point(291, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(432, 191)
        Me.GroupBox1.TabIndex = 1
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Multi-critère"
        '
        'I_Pays
        '
        Me.I_Pays.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.I_Pays.FormattingEnabled = True
        Me.I_Pays.Location = New System.Drawing.Point(81, 107)
        Me.I_Pays.Name = "I_Pays"
        Me.I_Pays.Size = New System.Drawing.Size(98, 21)
        Me.I_Pays.TabIndex = 19
        '
        'I_NbArticlesMax
        '
        Me.I_NbArticlesMax.Location = New System.Drawing.Point(142, 20)
        Me.I_NbArticlesMax.Name = "I_NbArticlesMax"
        Me.I_NbArticlesMax.Size = New System.Drawing.Size(37, 20)
        Me.I_NbArticlesMax.TabIndex = 18
        '
        'VilleTextBox
        '
        Me.VilleTextBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource
        Me.VilleTextBox.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.VilleTextBox.Location = New System.Drawing.Point(268, 76)
        Me.VilleTextBox.Name = "VilleTextBox"
        Me.VilleTextBox.Size = New System.Drawing.Size(98, 20)
        Me.VilleTextBox.TabIndex = 18
        '
        'I_Societe
        '
        Me.I_Societe.Location = New System.Drawing.Point(81, 48)
        Me.I_Societe.Name = "I_Societe"
        Me.I_Societe.Size = New System.Drawing.Size(98, 20)
        Me.I_Societe.TabIndex = 18
        '
        'CodePostalTextBox
        '
        Me.CodePostalTextBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource
        Me.CodePostalTextBox.Location = New System.Drawing.Point(81, 76)
        Me.CodePostalTextBox.Name = "CodePostalTextBox"
        Me.CodePostalTextBox.Size = New System.Drawing.Size(98, 20)
        Me.CodePostalTextBox.TabIndex = 18
        '
        'I_NbArticlesMin
        '
        Me.I_NbArticlesMin.Location = New System.Drawing.Point(81, 21)
        Me.I_NbArticlesMin.Name = "I_NbArticlesMin"
        Me.I_NbArticlesMin.Size = New System.Drawing.Size(37, 20)
        Me.I_NbArticlesMin.TabIndex = 18
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(6, 146)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(37, 13)
        Me.Label9.TabIndex = 17
        Me.Label9.Text = "Actif ?"
        '
        'I_Active
        '
        Me.I_Active.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.I_Active.FormattingEnabled = True
        Me.I_Active.Items.AddRange(New Object() {"<Tous>", "Oui", "Non"})
        Me.I_Active.Location = New System.Drawing.Point(6, 162)
        Me.I_Active.Name = "I_Active"
        Me.I_Active.Size = New System.Drawing.Size(70, 21)
        Me.I_Active.TabIndex = 16
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(6, 49)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(0, 13)
        Me.Label4.TabIndex = 7
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(6, 110)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(30, 13)
        Me.Label7.TabIndex = 6
        Me.Label7.Text = "Pays"
        '
        'Label_Ville
        '
        Me.Label_Ville.AutoSize = True
        Me.Label_Ville.Location = New System.Drawing.Point(191, 81)
        Me.Label_Ville.Name = "Label_Ville"
        Me.Label_Ville.Size = New System.Drawing.Size(26, 13)
        Me.Label_Ville.TabIndex = 6
        Me.Label_Ville.Text = "Ville"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(4, 53)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(43, 13)
        Me.Label8.TabIndex = 6
        Me.Label8.Text = "Société"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(123, 24)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(13, 13)
        Me.Label6.TabIndex = 6
        Me.Label6.Text = "à"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(4, 81)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(64, 13)
        Me.Label5.TabIndex = 6
        Me.Label5.Text = "Code Postal"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(4, 23)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(53, 13)
        Me.Label3.TabIndex = 6
        Me.Label3.Text = "Nb Article"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.Label1)
        Me.GroupBox2.Controls.Add(Me.I_Reference)
        Me.GroupBox2.Location = New System.Drawing.Point(12, 12)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(200, 159)
        Me.GroupBox2.TabIndex = 0
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Critère unique"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(6, 27)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(57, 13)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Référence"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(235, 58)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(32, 20)
        Me.Label2.TabIndex = 6
        Me.Label2.Text = "Ou"
        '
        'StatusStrip
        '
        Me.StatusStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripStatusLabelNbEnregistrements})
        Me.StatusStrip.Location = New System.Drawing.Point(0, 561)
        Me.StatusStrip.Name = "StatusStrip"
        Me.StatusStrip.Size = New System.Drawing.Size(922, 22)
        Me.StatusStrip.TabIndex = 8
        Me.StatusStrip.Text = "StatusStrip"
        '
        'ToolStripStatusLabelNbEnregistrements
        '
        Me.ToolStripStatusLabelNbEnregistrements.Name = "ToolStripStatusLabelNbEnregistrements"
        Me.ToolStripStatusLabelNbEnregistrements.Size = New System.Drawing.Size(203, 17)
        Me.ToolStripStatusLabelNbEnregistrements.Text = "{0000} enregistrement(s) sélectionnés"
        '
        'BT_Go
        '
        Me.BT_Go.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BT_Go.Image = Global.CLI.My.Resources.Resources.ActualSizeHS
        Me.BT_Go.Location = New System.Drawing.Point(740, 51)
        Me.BT_Go.Name = "BT_Go"
        Me.BT_Go.Size = New System.Drawing.Size(61, 31)
        Me.BT_Go.TabIndex = 2
        Me.BT_Go.Text = "Go"
        Me.BT_Go.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.BT_Go.UseVisualStyleBackColor = True
        '
        'BT_Nouveau_Fournisseur
        '
        Me.BT_Nouveau_Fournisseur.Image = Global.CLI.My.Resources.Resources.DataContainer_NewRecordHS
        Me.BT_Nouveau_Fournisseur.Location = New System.Drawing.Point(740, 119)
        Me.BT_Nouveau_Fournisseur.Name = "BT_Nouveau_Fournisseur"
        Me.BT_Nouveau_Fournisseur.Size = New System.Drawing.Size(135, 23)
        Me.BT_Nouveau_Fournisseur.TabIndex = 9
        Me.BT_Nouveau_Fournisseur.Text = "Nouveau Fournisseur"
        Me.BT_Nouveau_Fournisseur.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.BT_Nouveau_Fournisseur.UseVisualStyleBackColor = True
        '
        'BT_RAZ
        '
        Me.BT_RAZ.Image = Global.CLI.My.Resources.Resources.Edit_UndoHS
        Me.BT_RAZ.Location = New System.Drawing.Point(740, 85)
        Me.BT_RAZ.Name = "BT_RAZ"
        Me.BT_RAZ.Size = New System.Drawing.Size(61, 23)
        Me.BT_RAZ.TabIndex = 7
        Me.BT_RAZ.Text = "RAZ"
        Me.BT_RAZ.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.BT_RAZ.UseVisualStyleBackColor = True
        '
        'BT_Fermer
        '
        Me.BT_Fermer.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.BT_Fermer.Image = Global.CLI.My.Resources.Resources.GoRtlHS
        Me.BT_Fermer.Location = New System.Drawing.Point(740, 12)
        Me.BT_Fermer.Name = "BT_Fermer"
        Me.BT_Fermer.Size = New System.Drawing.Size(82, 25)
        Me.BT_Fermer.TabIndex = 10
        Me.BT_Fermer.Text = "Fermer"
        Me.BT_Fermer.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.BT_Fermer.UseVisualStyleBackColor = True
        '
        'V_Recherche_ArticleBindingSource
        '
        Me.V_Recherche_ArticleBindingSource.DataMember = "V_Recherche_Article"
        Me.V_Recherche_ArticleBindingSource.DataSource = Me.CLIDataSet
        '
        'V_Recherche_ArticleTableAdapter
        '
        Me.V_Recherche_ArticleTableAdapter.ClearBeforeFill = True
        '
        'V_Recherche_FournisseurTableAdapter
        '
        Me.V_Recherche_FournisseurTableAdapter.ClearBeforeFill = True
        '
        'FormFournisseurRecherche
        '
        Me.AcceptButton = Me.BT_Go
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.BT_Fermer
        Me.ClientSize = New System.Drawing.Size(922, 583)
        Me.Controls.Add(Me.BT_Fermer)
        Me.Controls.Add(Me.StatusStrip)
        Me.Controls.Add(Me.BT_Nouveau_Fournisseur)
        Me.Controls.Add(Me.BT_RAZ)
        Me.Controls.Add(Me.BT_Go)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.DGview)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "FormFournisseurRecherche"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Rechercher un Fournisseur"
        CType(Me.DGview, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.VRechercheFournisseurBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CLIDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ContextMenuStripRecherche.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.StatusStrip.ResumeLayout(False)
        Me.StatusStrip.PerformLayout()
        CType(Me.V_Recherche_ArticleBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents CLIDataSet As CLI.CLIDataSet
    Friend WithEvents V_Recherche_ArticleBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents V_Recherche_ArticleTableAdapter As CLI.CLIDataSetTableAdapters.V_Recherche_ArticleTableAdapter
    Friend WithEvents DGview As System.Windows.Forms.DataGridView
    Friend WithEvents I_Reference As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents BT_Go As System.Windows.Forms.Button
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents ToolTip As System.Windows.Forms.ToolTip
    Friend WithEvents BT_RAZ As System.Windows.Forms.Button
    Friend WithEvents StatusStrip As System.Windows.Forms.StatusStrip
    Friend WithEvents ToolStripStatusLabelNbEnregistrements As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents I_Active As System.Windows.Forms.ComboBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents ContextMenuStripRecherche As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents BT_Nouveau_Fournisseur As System.Windows.Forms.Button
    Friend WithEvents BT_Fermer As System.Windows.Forms.Button
    Friend WithEvents VRechercheFournisseurBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents V_Recherche_FournisseurTableAdapter As CLI.CLIDataSetTableAdapters.V_Recherche_FournisseurTableAdapter
    Friend WithEvents Actif As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents Ref As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SociétéDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents NomDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PrenomDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CodePostalDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents VilleDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PaysDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents NbArticleDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents I_NbArticlesMin As System.Windows.Forms.TextBox
    Friend WithEvents I_NbArticlesMax As System.Windows.Forms.TextBox
    Friend WithEvents VilleTextBox As System.Windows.Forms.TextBox
    Friend WithEvents CodePostalTextBox As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label_Ville As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents I_Pays As System.Windows.Forms.ComboBox
    Friend WithEvents I_Societe As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents SuppressionToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
End Class
