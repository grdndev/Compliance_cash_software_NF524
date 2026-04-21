<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FormClientRecherche
    Inherits System.Windows.Forms.Form

    'Form remplace la méthode Dispose pour nettoyer la liste des composants.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormClientRecherche))
        Me.DGview = New System.Windows.Forms.DataGridView()
        Me.Ref = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SociétéDataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.NomDataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PrenomDataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CodePostalDataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.VilleDataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PaysDataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.NbArticleDataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.EchéancesDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.MontantAvoirDataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DerniereUtilisation = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DernierAvoirCree = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DerniereRelanceAvoir = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.actif = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.NbCommandeDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.NumeroIdentiteDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.WindDataGridViewCheckBoxColumn = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.KiteDataGridViewCheckBoxColumn = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.SupDataGridViewCheckBoxColumn = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.EtatSynchroPrestashop = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ContextMenuStripRecherche = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.EtiquetteAdresseToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EnvoyerMailRelanceAvoirsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.VRechercheClientBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.CLIDataSet = New CLI.CLIDataSet()
        Me.I_Reference = New System.Windows.Forms.TextBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.I_SynchroPrestashop = New System.Windows.Forms.ComboBox()
        Me.IL_SynchroPS = New System.Windows.Forms.Label()
        Me.I_sup = New System.Windows.Forms.CheckBox()
        Me.I_kite = New System.Windows.Forms.CheckBox()
        Me.I_Wind = New System.Windows.Forms.CheckBox()
        Me.I_Pays = New System.Windows.Forms.ComboBox()
        Me.I_EcheanceMax = New System.Windows.Forms.TextBox()
        Me.I_AvoirMax = New System.Windows.Forms.TextBox()
        Me.I_NbCommandesMax = New System.Windows.Forms.TextBox()
        Me.I_NbArticlesMax = New System.Windows.Forms.TextBox()
        Me.VilleTextBox = New System.Windows.Forms.TextBox()
        Me.I_Prenom = New System.Windows.Forms.TextBox()
        Me.I_Nom = New System.Windows.Forms.TextBox()
        Me.I_Societe = New System.Windows.Forms.TextBox()
        Me.CodePostalTextbox = New System.Windows.Forms.TextBox()
        Me.I_EchanceMin = New System.Windows.Forms.TextBox()
        Me.I_AvoirMin = New System.Windows.Forms.TextBox()
        Me.I_NbCommandesMin = New System.Windows.Forms.TextBox()
        Me.I_NbArticlesMin = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.I_Active = New System.Windows.Forms.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label_Ville = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.ToolTip = New System.Windows.Forms.ToolTip(Me.components)
        Me.StatusStrip = New System.Windows.Forms.StatusStrip()
        Me.ToolStripStatusLabelNbEnregistrements = New System.Windows.Forms.ToolStripStatusLabel()
        Me.SociétéDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.NomDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PrenomDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CodePostalDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.VilleDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PaysDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.NbArticleDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SociétéDataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.NomDataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PrenomDataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CodePostalDataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.VilleDataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PaysDataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.NbCommande = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.NbArticleDataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.MontantAvoirDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.V_Recherche_ArticleBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.V_Recherche_ArticleTableAdapter = New CLI.CLIDataSetTableAdapters.V_Recherche_ArticleTableAdapter()
        Me.V_Recherche_ClientTableAdapter = New CLI.CLIDataSetTableAdapters.V_Recherche_ClientTableAdapter()
        Me.T_ClientTableAdapter = New CLI.CLIDataSetTableAdapters.T_ClientTableAdapter()
        Me.I_TotalAvoir = New System.Windows.Forms.TextBox()
        Me.IL_TotalAvoir = New System.Windows.Forms.Label()
        Me.BT_Go = New System.Windows.Forms.Button()
        Me.BT_Fermer = New System.Windows.Forms.Button()
        Me.BT_Email = New System.Windows.Forms.Button()
        Me.BT_Impression = New System.Windows.Forms.Button()
        Me.BT_Nouveau_Client = New System.Windows.Forms.Button()
        Me.BT_RAZ = New System.Windows.Forms.Button()
        Me.I_Email = New System.Windows.Forms.TextBox()
        Me.IL_Email = New System.Windows.Forms.Label()
        CType(Me.DGview, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ContextMenuStripRecherche.SuspendLayout()
        CType(Me.VRechercheClientBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CLIDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.DGview.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Ref, Me.SociétéDataGridViewTextBoxColumn2, Me.NomDataGridViewTextBoxColumn2, Me.PrenomDataGridViewTextBoxColumn2, Me.CodePostalDataGridViewTextBoxColumn2, Me.VilleDataGridViewTextBoxColumn2, Me.PaysDataGridViewTextBoxColumn2, Me.NbArticleDataGridViewTextBoxColumn2, Me.EchéancesDataGridViewTextBoxColumn, Me.MontantAvoirDataGridViewTextBoxColumn1, Me.DerniereUtilisation, Me.DernierAvoirCree, Me.DerniereRelanceAvoir, Me.actif, Me.NbCommandeDataGridViewTextBoxColumn, Me.NumeroIdentiteDataGridViewTextBoxColumn, Me.WindDataGridViewCheckBoxColumn, Me.KiteDataGridViewCheckBoxColumn, Me.SupDataGridViewCheckBoxColumn, Me.EtatSynchroPrestashop})
        Me.DGview.ContextMenuStrip = Me.ContextMenuStripRecherche
        Me.DGview.DataSource = Me.VRechercheClientBindingSource
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DGview.DefaultCellStyle = DataGridViewCellStyle3
        Me.DGview.Location = New System.Drawing.Point(4, 372)
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
        Me.DGview.Size = New System.Drawing.Size(942, 295)
        Me.DGview.TabIndex = 3
        '
        'Ref
        '
        Me.Ref.DataPropertyName = "Ref"
        Me.Ref.HeaderText = "Ref"
        Me.Ref.Name = "Ref"
        Me.Ref.ReadOnly = True
        Me.Ref.Width = 49
        '
        'SociétéDataGridViewTextBoxColumn2
        '
        Me.SociétéDataGridViewTextBoxColumn2.DataPropertyName = "Société"
        Me.SociétéDataGridViewTextBoxColumn2.HeaderText = "Société"
        Me.SociétéDataGridViewTextBoxColumn2.Name = "SociétéDataGridViewTextBoxColumn2"
        Me.SociétéDataGridViewTextBoxColumn2.ReadOnly = True
        Me.SociétéDataGridViewTextBoxColumn2.Width = 68
        '
        'NomDataGridViewTextBoxColumn2
        '
        Me.NomDataGridViewTextBoxColumn2.DataPropertyName = "Nom"
        Me.NomDataGridViewTextBoxColumn2.HeaderText = "Nom"
        Me.NomDataGridViewTextBoxColumn2.Name = "NomDataGridViewTextBoxColumn2"
        Me.NomDataGridViewTextBoxColumn2.ReadOnly = True
        Me.NomDataGridViewTextBoxColumn2.Width = 54
        '
        'PrenomDataGridViewTextBoxColumn2
        '
        Me.PrenomDataGridViewTextBoxColumn2.DataPropertyName = "Prenom"
        Me.PrenomDataGridViewTextBoxColumn2.HeaderText = "Prenom"
        Me.PrenomDataGridViewTextBoxColumn2.Name = "PrenomDataGridViewTextBoxColumn2"
        Me.PrenomDataGridViewTextBoxColumn2.ReadOnly = True
        Me.PrenomDataGridViewTextBoxColumn2.Width = 68
        '
        'CodePostalDataGridViewTextBoxColumn2
        '
        Me.CodePostalDataGridViewTextBoxColumn2.DataPropertyName = "CodePostal"
        Me.CodePostalDataGridViewTextBoxColumn2.HeaderText = "CodePostal"
        Me.CodePostalDataGridViewTextBoxColumn2.Name = "CodePostalDataGridViewTextBoxColumn2"
        Me.CodePostalDataGridViewTextBoxColumn2.ReadOnly = True
        Me.CodePostalDataGridViewTextBoxColumn2.Width = 86
        '
        'VilleDataGridViewTextBoxColumn2
        '
        Me.VilleDataGridViewTextBoxColumn2.DataPropertyName = "Ville"
        Me.VilleDataGridViewTextBoxColumn2.HeaderText = "Ville"
        Me.VilleDataGridViewTextBoxColumn2.Name = "VilleDataGridViewTextBoxColumn2"
        Me.VilleDataGridViewTextBoxColumn2.ReadOnly = True
        Me.VilleDataGridViewTextBoxColumn2.Width = 51
        '
        'PaysDataGridViewTextBoxColumn2
        '
        Me.PaysDataGridViewTextBoxColumn2.DataPropertyName = "Pays"
        Me.PaysDataGridViewTextBoxColumn2.HeaderText = "Pays"
        Me.PaysDataGridViewTextBoxColumn2.Name = "PaysDataGridViewTextBoxColumn2"
        Me.PaysDataGridViewTextBoxColumn2.ReadOnly = True
        Me.PaysDataGridViewTextBoxColumn2.Width = 55
        '
        'NbArticleDataGridViewTextBoxColumn2
        '
        Me.NbArticleDataGridViewTextBoxColumn2.DataPropertyName = "NbArticle"
        Me.NbArticleDataGridViewTextBoxColumn2.HeaderText = "NbArticle"
        Me.NbArticleDataGridViewTextBoxColumn2.Name = "NbArticleDataGridViewTextBoxColumn2"
        Me.NbArticleDataGridViewTextBoxColumn2.ReadOnly = True
        Me.NbArticleDataGridViewTextBoxColumn2.Width = 75
        '
        'EchéancesDataGridViewTextBoxColumn
        '
        Me.EchéancesDataGridViewTextBoxColumn.DataPropertyName = "Echéances"
        Me.EchéancesDataGridViewTextBoxColumn.HeaderText = "Echéances"
        Me.EchéancesDataGridViewTextBoxColumn.Name = "EchéancesDataGridViewTextBoxColumn"
        Me.EchéancesDataGridViewTextBoxColumn.ReadOnly = True
        Me.EchéancesDataGridViewTextBoxColumn.Width = 86
        '
        'MontantAvoirDataGridViewTextBoxColumn1
        '
        Me.MontantAvoirDataGridViewTextBoxColumn1.DataPropertyName = "Montant Avoir"
        Me.MontantAvoirDataGridViewTextBoxColumn1.HeaderText = "Montant Avoir"
        Me.MontantAvoirDataGridViewTextBoxColumn1.Name = "MontantAvoirDataGridViewTextBoxColumn1"
        Me.MontantAvoirDataGridViewTextBoxColumn1.ReadOnly = True
        Me.MontantAvoirDataGridViewTextBoxColumn1.Width = 98
        '
        'DerniereUtilisation
        '
        Me.DerniereUtilisation.DataPropertyName = "DerniereUtilisation"
        Me.DerniereUtilisation.HeaderText = "Derniere Utilisation avoir"
        Me.DerniereUtilisation.Name = "DerniereUtilisation"
        Me.DerniereUtilisation.ReadOnly = True
        Me.DerniereUtilisation.Width = 146
        '
        'DernierAvoirCree
        '
        Me.DernierAvoirCree.DataPropertyName = "DernierAvoirCree"
        Me.DernierAvoirCree.HeaderText = "Dernier Avoir Cree"
        Me.DernierAvoirCree.Name = "DernierAvoirCree"
        Me.DernierAvoirCree.ReadOnly = True
        Me.DernierAvoirCree.Width = 118
        '
        'DerniereRelanceAvoir
        '
        Me.DerniereRelanceAvoir.DataPropertyName = "DerniereRelanceAvoir"
        Me.DerniereRelanceAvoir.HeaderText = "Derniere Relance Avoir"
        Me.DerniereRelanceAvoir.Name = "DerniereRelanceAvoir"
        Me.DerniereRelanceAvoir.ReadOnly = True
        Me.DerniereRelanceAvoir.Width = 142
        '
        'actif
        '
        Me.actif.DataPropertyName = "Actif"
        Me.actif.HeaderText = "Actif"
        Me.actif.Name = "actif"
        Me.actif.ReadOnly = True
        Me.actif.Width = 34
        '
        'NbCommandeDataGridViewTextBoxColumn
        '
        Me.NbCommandeDataGridViewTextBoxColumn.DataPropertyName = "NbCommande"
        Me.NbCommandeDataGridViewTextBoxColumn.HeaderText = "NbCommande"
        Me.NbCommandeDataGridViewTextBoxColumn.Name = "NbCommandeDataGridViewTextBoxColumn"
        Me.NbCommandeDataGridViewTextBoxColumn.ReadOnly = True
        Me.NbCommandeDataGridViewTextBoxColumn.Width = 99
        '
        'NumeroIdentiteDataGridViewTextBoxColumn
        '
        Me.NumeroIdentiteDataGridViewTextBoxColumn.DataPropertyName = "NumeroIdentite"
        Me.NumeroIdentiteDataGridViewTextBoxColumn.HeaderText = "NumeroIdentite"
        Me.NumeroIdentiteDataGridViewTextBoxColumn.Name = "NumeroIdentiteDataGridViewTextBoxColumn"
        Me.NumeroIdentiteDataGridViewTextBoxColumn.ReadOnly = True
        Me.NumeroIdentiteDataGridViewTextBoxColumn.Width = 104
        '
        'WindDataGridViewCheckBoxColumn
        '
        Me.WindDataGridViewCheckBoxColumn.DataPropertyName = "Wind"
        Me.WindDataGridViewCheckBoxColumn.HeaderText = "Wind"
        Me.WindDataGridViewCheckBoxColumn.Name = "WindDataGridViewCheckBoxColumn"
        Me.WindDataGridViewCheckBoxColumn.ReadOnly = True
        Me.WindDataGridViewCheckBoxColumn.Width = 38
        '
        'KiteDataGridViewCheckBoxColumn
        '
        Me.KiteDataGridViewCheckBoxColumn.DataPropertyName = "Kite"
        Me.KiteDataGridViewCheckBoxColumn.HeaderText = "Kite"
        Me.KiteDataGridViewCheckBoxColumn.Name = "KiteDataGridViewCheckBoxColumn"
        Me.KiteDataGridViewCheckBoxColumn.ReadOnly = True
        Me.KiteDataGridViewCheckBoxColumn.Width = 31
        '
        'SupDataGridViewCheckBoxColumn
        '
        Me.SupDataGridViewCheckBoxColumn.DataPropertyName = "Sup"
        Me.SupDataGridViewCheckBoxColumn.HeaderText = "Sup"
        Me.SupDataGridViewCheckBoxColumn.Name = "SupDataGridViewCheckBoxColumn"
        Me.SupDataGridViewCheckBoxColumn.ReadOnly = True
        Me.SupDataGridViewCheckBoxColumn.Width = 32
        '
        'EtatSynchroPrestashop
        '
        Me.EtatSynchroPrestashop.DataPropertyName = "SynchroPrestashop"
        Me.EtatSynchroPrestashop.HeaderText = "EtatSynchroPrestashop"
        Me.EtatSynchroPrestashop.Name = "EtatSynchroPrestashop"
        Me.EtatSynchroPrestashop.ReadOnly = True
        Me.EtatSynchroPrestashop.Width = 143
        '
        'ContextMenuStripRecherche
        '
        Me.ContextMenuStripRecherche.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.EtiquetteAdresseToolStripMenuItem, Me.EnvoyerMailRelanceAvoirsToolStripMenuItem})
        Me.ContextMenuStripRecherche.Name = "ContextMenuStrip"
        Me.ContextMenuStripRecherche.Size = New System.Drawing.Size(218, 48)
        '
        'EtiquetteAdresseToolStripMenuItem
        '
        Me.EtiquetteAdresseToolStripMenuItem.Image = Global.CLI.My.Resources.Resources.PrintHS
        Me.EtiquetteAdresseToolStripMenuItem.Name = "EtiquetteAdresseToolStripMenuItem"
        Me.EtiquetteAdresseToolStripMenuItem.Size = New System.Drawing.Size(217, 22)
        Me.EtiquetteAdresseToolStripMenuItem.Text = "Etiquette adresse"
        '
        'EnvoyerMailRelanceAvoirsToolStripMenuItem
        '
        Me.EnvoyerMailRelanceAvoirsToolStripMenuItem.Image = Global.CLI.My.Resources.Resources.EnvelopeHS
        Me.EnvoyerMailRelanceAvoirsToolStripMenuItem.Name = "EnvoyerMailRelanceAvoirsToolStripMenuItem"
        Me.EnvoyerMailRelanceAvoirsToolStripMenuItem.Size = New System.Drawing.Size(217, 22)
        Me.EnvoyerMailRelanceAvoirsToolStripMenuItem.Text = "Envoyer mail relance avoirs"
        '
        'VRechercheClientBindingSource
        '
        Me.VRechercheClientBindingSource.DataMember = "V_Recherche_Client"
        Me.VRechercheClientBindingSource.DataSource = Me.CLIDataSet
        '
        'CLIDataSet
        '
        Me.CLIDataSet.DataSetName = "CLIDataSet"
        Me.CLIDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
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
        Me.GroupBox1.Controls.Add(Me.I_Email)
        Me.GroupBox1.Controls.Add(Me.IL_Email)
        Me.GroupBox1.Controls.Add(Me.I_SynchroPrestashop)
        Me.GroupBox1.Controls.Add(Me.IL_SynchroPS)
        Me.GroupBox1.Controls.Add(Me.I_sup)
        Me.GroupBox1.Controls.Add(Me.I_kite)
        Me.GroupBox1.Controls.Add(Me.I_Wind)
        Me.GroupBox1.Controls.Add(Me.I_Pays)
        Me.GroupBox1.Controls.Add(Me.I_EcheanceMax)
        Me.GroupBox1.Controls.Add(Me.I_AvoirMax)
        Me.GroupBox1.Controls.Add(Me.I_NbCommandesMax)
        Me.GroupBox1.Controls.Add(Me.I_NbArticlesMax)
        Me.GroupBox1.Controls.Add(Me.VilleTextBox)
        Me.GroupBox1.Controls.Add(Me.I_Prenom)
        Me.GroupBox1.Controls.Add(Me.I_Nom)
        Me.GroupBox1.Controls.Add(Me.I_Societe)
        Me.GroupBox1.Controls.Add(Me.CodePostalTextbox)
        Me.GroupBox1.Controls.Add(Me.I_EchanceMin)
        Me.GroupBox1.Controls.Add(Me.I_AvoirMin)
        Me.GroupBox1.Controls.Add(Me.I_NbCommandesMin)
        Me.GroupBox1.Controls.Add(Me.I_NbArticlesMin)
        Me.GroupBox1.Controls.Add(Me.Label9)
        Me.GroupBox1.Controls.Add(Me.I_Active)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.Label11)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.Label10)
        Me.GroupBox1.Controls.Add(Me.Label17)
        Me.GroupBox1.Controls.Add(Me.Label15)
        Me.GroupBox1.Controls.Add(Me.Label_Ville)
        Me.GroupBox1.Controls.Add(Me.Label13)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Controls.Add(Me.Label16)
        Me.GroupBox1.Controls.Add(Me.Label14)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.Label12)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Location = New System.Drawing.Point(291, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(432, 354)
        Me.GroupBox1.TabIndex = 1
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Multi-critère"
        '
        'I_SynchroPrestashop
        '
        Me.I_SynchroPrestashop.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.I_SynchroPrestashop.FormattingEnabled = True
        Me.I_SynchroPrestashop.Items.AddRange(New Object() {"<Tous>", "Ok", "Erreur", "Non"})
        Me.I_SynchroPrestashop.Location = New System.Drawing.Point(307, 319)
        Me.I_SynchroPrestashop.Name = "I_SynchroPrestashop"
        Me.I_SynchroPrestashop.Size = New System.Drawing.Size(121, 21)
        Me.I_SynchroPrestashop.TabIndex = 27
        '
        'IL_SynchroPS
        '
        Me.IL_SynchroPS.AutoSize = True
        Me.IL_SynchroPS.Location = New System.Drawing.Point(307, 302)
        Me.IL_SynchroPS.Name = "IL_SynchroPS"
        Me.IL_SynchroPS.Size = New System.Drawing.Size(122, 13)
        Me.IL_SynchroPS.TabIndex = 26
        Me.IL_SynchroPS.Text = "Etat synchro Prestashop"
        '
        'I_sup
        '
        Me.I_sup.AutoSize = True
        Me.I_sup.Location = New System.Drawing.Point(241, 322)
        Me.I_sup.Name = "I_sup"
        Me.I_sup.Size = New System.Drawing.Size(45, 17)
        Me.I_sup.TabIndex = 18
        Me.I_sup.Text = "Sup"
        Me.I_sup.UseVisualStyleBackColor = True
        '
        'I_kite
        '
        Me.I_kite.AutoSize = True
        Me.I_kite.Location = New System.Drawing.Point(176, 322)
        Me.I_kite.Name = "I_kite"
        Me.I_kite.Size = New System.Drawing.Size(61, 17)
        Me.I_kite.TabIndex = 18
        Me.I_kite.Text = "Kitesurf"
        Me.I_kite.UseVisualStyleBackColor = True
        '
        'I_Wind
        '
        Me.I_Wind.AutoSize = True
        Me.I_Wind.Location = New System.Drawing.Point(102, 322)
        Me.I_Wind.Name = "I_Wind"
        Me.I_Wind.Size = New System.Drawing.Size(68, 17)
        Me.I_Wind.TabIndex = 18
        Me.I_Wind.Text = "Windsurf"
        Me.I_Wind.UseVisualStyleBackColor = True
        '
        'I_Pays
        '
        Me.I_Pays.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.I_Pays.FormattingEnabled = True
        Me.I_Pays.Location = New System.Drawing.Point(125, 242)
        Me.I_Pays.Name = "I_Pays"
        Me.I_Pays.Size = New System.Drawing.Size(98, 21)
        Me.I_Pays.TabIndex = 13
        '
        'I_EcheanceMax
        '
        Me.I_EcheanceMax.Location = New System.Drawing.Point(186, 96)
        Me.I_EcheanceMax.Name = "I_EcheanceMax"
        Me.I_EcheanceMax.Size = New System.Drawing.Size(37, 20)
        Me.I_EcheanceMax.TabIndex = 7
        '
        'I_AvoirMax
        '
        Me.I_AvoirMax.Location = New System.Drawing.Point(186, 70)
        Me.I_AvoirMax.Name = "I_AvoirMax"
        Me.I_AvoirMax.Size = New System.Drawing.Size(37, 20)
        Me.I_AvoirMax.TabIndex = 5
        '
        'I_NbCommandesMax
        '
        Me.I_NbCommandesMax.Location = New System.Drawing.Point(186, 44)
        Me.I_NbCommandesMax.Name = "I_NbCommandesMax"
        Me.I_NbCommandesMax.Size = New System.Drawing.Size(37, 20)
        Me.I_NbCommandesMax.TabIndex = 3
        '
        'I_NbArticlesMax
        '
        Me.I_NbArticlesMax.Location = New System.Drawing.Point(186, 19)
        Me.I_NbArticlesMax.Name = "I_NbArticlesMax"
        Me.I_NbArticlesMax.Size = New System.Drawing.Size(37, 20)
        Me.I_NbArticlesMax.TabIndex = 1
        '
        'VilleTextBox
        '
        Me.VilleTextBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource
        Me.VilleTextBox.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.VilleTextBox.Location = New System.Drawing.Point(312, 211)
        Me.VilleTextBox.Name = "VilleTextBox"
        Me.VilleTextBox.Size = New System.Drawing.Size(98, 20)
        Me.VilleTextBox.TabIndex = 12
        '
        'I_Prenom
        '
        Me.I_Prenom.Location = New System.Drawing.Point(125, 185)
        Me.I_Prenom.Name = "I_Prenom"
        Me.I_Prenom.Size = New System.Drawing.Size(98, 20)
        Me.I_Prenom.TabIndex = 10
        '
        'I_Nom
        '
        Me.I_Nom.Location = New System.Drawing.Point(125, 159)
        Me.I_Nom.Name = "I_Nom"
        Me.I_Nom.Size = New System.Drawing.Size(98, 20)
        Me.I_Nom.TabIndex = 9
        '
        'I_Societe
        '
        Me.I_Societe.Location = New System.Drawing.Point(125, 134)
        Me.I_Societe.Name = "I_Societe"
        Me.I_Societe.Size = New System.Drawing.Size(98, 20)
        Me.I_Societe.TabIndex = 8
        '
        'CodePostalTextbox
        '
        Me.CodePostalTextbox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource
        Me.CodePostalTextbox.Location = New System.Drawing.Point(125, 211)
        Me.CodePostalTextbox.Name = "CodePostalTextbox"
        Me.CodePostalTextbox.Size = New System.Drawing.Size(98, 20)
        Me.CodePostalTextbox.TabIndex = 11
        '
        'I_EchanceMin
        '
        Me.I_EchanceMin.Location = New System.Drawing.Point(125, 97)
        Me.I_EchanceMin.Name = "I_EchanceMin"
        Me.I_EchanceMin.Size = New System.Drawing.Size(37, 20)
        Me.I_EchanceMin.TabIndex = 6
        '
        'I_AvoirMin
        '
        Me.I_AvoirMin.Location = New System.Drawing.Point(125, 71)
        Me.I_AvoirMin.Name = "I_AvoirMin"
        Me.I_AvoirMin.Size = New System.Drawing.Size(37, 20)
        Me.I_AvoirMin.TabIndex = 4
        '
        'I_NbCommandesMin
        '
        Me.I_NbCommandesMin.Location = New System.Drawing.Point(125, 45)
        Me.I_NbCommandesMin.Name = "I_NbCommandesMin"
        Me.I_NbCommandesMin.Size = New System.Drawing.Size(37, 20)
        Me.I_NbCommandesMin.TabIndex = 2
        '
        'I_NbArticlesMin
        '
        Me.I_NbArticlesMin.Location = New System.Drawing.Point(125, 20)
        Me.I_NbArticlesMin.Name = "I_NbArticlesMin"
        Me.I_NbArticlesMin.Size = New System.Drawing.Size(37, 20)
        Me.I_NbArticlesMin.TabIndex = 0
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(9, 302)
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
        Me.I_Active.Location = New System.Drawing.Point(9, 318)
        Me.I_Active.Name = "I_Active"
        Me.I_Active.Size = New System.Drawing.Size(70, 21)
        Me.I_Active.TabIndex = 14
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(6, 49)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(0, 13)
        Me.Label4.TabIndex = 7
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(4, 191)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(43, 13)
        Me.Label11.TabIndex = 6
        Me.Label11.Text = "Prénom"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(6, 246)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(30, 13)
        Me.Label7.TabIndex = 6
        Me.Label7.Text = "Pays"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(4, 165)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(29, 13)
        Me.Label10.TabIndex = 6
        Me.Label10.Text = "Nom"
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(167, 100)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(13, 13)
        Me.Label17.TabIndex = 6
        Me.Label17.Text = "à"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(167, 74)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(13, 13)
        Me.Label15.TabIndex = 6
        Me.Label15.Text = "à"
        '
        'Label_Ville
        '
        Me.Label_Ville.AutoSize = True
        Me.Label_Ville.Location = New System.Drawing.Point(235, 216)
        Me.Label_Ville.Name = "Label_Ville"
        Me.Label_Ville.Size = New System.Drawing.Size(26, 13)
        Me.Label_Ville.TabIndex = 6
        Me.Label_Ville.Text = "Ville"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(167, 48)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(13, 13)
        Me.Label13.TabIndex = 6
        Me.Label13.Text = "à"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(4, 140)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(43, 13)
        Me.Label8.TabIndex = 6
        Me.Label8.Text = "Société"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(4, 100)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(76, 13)
        Me.Label16.TabIndex = 6
        Me.Label16.Text = "Mt Echéances"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(4, 74)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(121, 13)
        Me.Label14.TabIndex = 6
        Me.Label14.Text = "Montant Avoir / Chèque"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(167, 23)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(13, 13)
        Me.Label6.TabIndex = 6
        Me.Label6.Text = "à"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(4, 48)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(77, 13)
        Me.Label12.TabIndex = 6
        Me.Label12.Text = "Nb Commande"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(4, 217)
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
        Me.Label3.Size = New System.Drawing.Size(84, 13)
        Me.Label3.TabIndex = 6
        Me.Label3.Text = "Nb Dépôt-Vente"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.Label1)
        Me.GroupBox2.Controls.Add(Me.I_Reference)
        Me.GroupBox2.Location = New System.Drawing.Point(12, 12)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(200, 253)
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
        Me.StatusStrip.Location = New System.Drawing.Point(0, 670)
        Me.StatusStrip.Name = "StatusStrip"
        Me.StatusStrip.Size = New System.Drawing.Size(946, 22)
        Me.StatusStrip.TabIndex = 8
        Me.StatusStrip.Text = "StatusStrip"
        '
        'ToolStripStatusLabelNbEnregistrements
        '
        Me.ToolStripStatusLabelNbEnregistrements.Name = "ToolStripStatusLabelNbEnregistrements"
        Me.ToolStripStatusLabelNbEnregistrements.Size = New System.Drawing.Size(203, 17)
        Me.ToolStripStatusLabelNbEnregistrements.Text = "{0000} enregistrement(s) sélectionnés"
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
        'SociétéDataGridViewTextBoxColumn1
        '
        Me.SociétéDataGridViewTextBoxColumn1.DataPropertyName = "Société"
        Me.SociétéDataGridViewTextBoxColumn1.HeaderText = "Société"
        Me.SociétéDataGridViewTextBoxColumn1.Name = "SociétéDataGridViewTextBoxColumn1"
        Me.SociétéDataGridViewTextBoxColumn1.Width = 68
        '
        'NomDataGridViewTextBoxColumn1
        '
        Me.NomDataGridViewTextBoxColumn1.DataPropertyName = "Nom"
        Me.NomDataGridViewTextBoxColumn1.HeaderText = "Nom"
        Me.NomDataGridViewTextBoxColumn1.Name = "NomDataGridViewTextBoxColumn1"
        Me.NomDataGridViewTextBoxColumn1.Width = 54
        '
        'PrenomDataGridViewTextBoxColumn1
        '
        Me.PrenomDataGridViewTextBoxColumn1.DataPropertyName = "Prenom"
        Me.PrenomDataGridViewTextBoxColumn1.HeaderText = "Prenom"
        Me.PrenomDataGridViewTextBoxColumn1.Name = "PrenomDataGridViewTextBoxColumn1"
        Me.PrenomDataGridViewTextBoxColumn1.Width = 68
        '
        'CodePostalDataGridViewTextBoxColumn1
        '
        Me.CodePostalDataGridViewTextBoxColumn1.DataPropertyName = "CodePostal"
        Me.CodePostalDataGridViewTextBoxColumn1.HeaderText = "CodePostal"
        Me.CodePostalDataGridViewTextBoxColumn1.Name = "CodePostalDataGridViewTextBoxColumn1"
        Me.CodePostalDataGridViewTextBoxColumn1.Width = 86
        '
        'VilleDataGridViewTextBoxColumn1
        '
        Me.VilleDataGridViewTextBoxColumn1.DataPropertyName = "Ville"
        Me.VilleDataGridViewTextBoxColumn1.HeaderText = "Ville"
        Me.VilleDataGridViewTextBoxColumn1.Name = "VilleDataGridViewTextBoxColumn1"
        Me.VilleDataGridViewTextBoxColumn1.Width = 51
        '
        'PaysDataGridViewTextBoxColumn1
        '
        Me.PaysDataGridViewTextBoxColumn1.DataPropertyName = "Pays"
        Me.PaysDataGridViewTextBoxColumn1.HeaderText = "Pays"
        Me.PaysDataGridViewTextBoxColumn1.Name = "PaysDataGridViewTextBoxColumn1"
        Me.PaysDataGridViewTextBoxColumn1.Width = 55
        '
        'NbCommande
        '
        Me.NbCommande.DataPropertyName = "NbCommande"
        Me.NbCommande.HeaderText = "NbCommande"
        Me.NbCommande.Name = "NbCommande"
        Me.NbCommande.Width = 99
        '
        'NbArticleDataGridViewTextBoxColumn1
        '
        Me.NbArticleDataGridViewTextBoxColumn1.DataPropertyName = "NbArticle"
        Me.NbArticleDataGridViewTextBoxColumn1.HeaderText = "NbArticle"
        Me.NbArticleDataGridViewTextBoxColumn1.Name = "NbArticleDataGridViewTextBoxColumn1"
        Me.NbArticleDataGridViewTextBoxColumn1.Width = 75
        '
        'MontantAvoirDataGridViewTextBoxColumn
        '
        Me.MontantAvoirDataGridViewTextBoxColumn.DataPropertyName = "Montant Avoir"
        DataGridViewCellStyle5.Format = "C2"
        Me.MontantAvoirDataGridViewTextBoxColumn.DefaultCellStyle = DataGridViewCellStyle5
        Me.MontantAvoirDataGridViewTextBoxColumn.HeaderText = "Montant Avoir / Chèque"
        Me.MontantAvoirDataGridViewTextBoxColumn.Name = "MontantAvoirDataGridViewTextBoxColumn"
        Me.MontantAvoirDataGridViewTextBoxColumn.Width = 146
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
        'V_Recherche_ClientTableAdapter
        '
        Me.V_Recherche_ClientTableAdapter.ClearBeforeFill = True
        '
        'T_ClientTableAdapter
        '
        Me.T_ClientTableAdapter.ClearBeforeFill = True
        '
        'I_TotalAvoir
        '
        Me.I_TotalAvoir.Location = New System.Drawing.Point(729, 334)
        Me.I_TotalAvoir.Name = "I_TotalAvoir"
        Me.I_TotalAvoir.ReadOnly = True
        Me.I_TotalAvoir.Size = New System.Drawing.Size(83, 20)
        Me.I_TotalAvoir.TabIndex = 13
        '
        'IL_TotalAvoir
        '
        Me.IL_TotalAvoir.Location = New System.Drawing.Point(727, 308)
        Me.IL_TotalAvoir.Name = "IL_TotalAvoir"
        Me.IL_TotalAvoir.Size = New System.Drawing.Size(85, 23)
        Me.IL_TotalAvoir.TabIndex = 14
        Me.IL_TotalAvoir.Text = "Total Avoir"
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
        'BT_Email
        '
        Me.BT_Email.Image = Global.CLI.My.Resources.Resources.EnvelopeHS
        Me.BT_Email.Location = New System.Drawing.Point(88, 311)
        Me.BT_Email.Name = "BT_Email"
        Me.BT_Email.Size = New System.Drawing.Size(77, 23)
        Me.BT_Email.TabIndex = 12
        Me.BT_Email.Text = "Email"
        Me.BT_Email.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.BT_Email.UseVisualStyleBackColor = True
        '
        'BT_Impression
        '
        Me.BT_Impression.Image = Global.CLI.My.Resources.Resources.PrintHS
        Me.BT_Impression.Location = New System.Drawing.Point(4, 311)
        Me.BT_Impression.Name = "BT_Impression"
        Me.BT_Impression.Size = New System.Drawing.Size(78, 23)
        Me.BT_Impression.TabIndex = 11
        Me.BT_Impression.Text = "Imprimer"
        Me.BT_Impression.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.BT_Impression.UseVisualStyleBackColor = True
        '
        'BT_Nouveau_Client
        '
        Me.BT_Nouveau_Client.Image = Global.CLI.My.Resources.Resources.DataContainer_NewRecordHS
        Me.BT_Nouveau_Client.Location = New System.Drawing.Point(740, 119)
        Me.BT_Nouveau_Client.Name = "BT_Nouveau_Client"
        Me.BT_Nouveau_Client.Size = New System.Drawing.Size(135, 23)
        Me.BT_Nouveau_Client.TabIndex = 9
        Me.BT_Nouveau_Client.Text = "Nouveau Client"
        Me.BT_Nouveau_Client.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.BT_Nouveau_Client.UseVisualStyleBackColor = True
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
        'I_Email
        '
        Me.I_Email.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource
        Me.I_Email.Location = New System.Drawing.Point(125, 275)
        Me.I_Email.Name = "I_Email"
        Me.I_Email.Size = New System.Drawing.Size(187, 20)
        Me.I_Email.TabIndex = 29
        '
        'IL_Email
        '
        Me.IL_Email.AutoSize = True
        Me.IL_Email.Location = New System.Drawing.Point(6, 282)
        Me.IL_Email.Name = "IL_Email"
        Me.IL_Email.Size = New System.Drawing.Size(32, 13)
        Me.IL_Email.TabIndex = 28
        Me.IL_Email.Text = "Email"
        '
        'FormClientRecherche
        '
        Me.AcceptButton = Me.BT_Go
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.BT_Fermer
        Me.ClientSize = New System.Drawing.Size(946, 692)
        Me.Controls.Add(Me.IL_TotalAvoir)
        Me.Controls.Add(Me.I_TotalAvoir)
        Me.Controls.Add(Me.BT_Email)
        Me.Controls.Add(Me.BT_Impression)
        Me.Controls.Add(Me.BT_Fermer)
        Me.Controls.Add(Me.StatusStrip)
        Me.Controls.Add(Me.BT_Nouveau_Client)
        Me.Controls.Add(Me.BT_RAZ)
        Me.Controls.Add(Me.BT_Go)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.DGview)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "FormClientRecherche"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Rechercher un Client"
        CType(Me.DGview, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ContextMenuStripRecherche.ResumeLayout(False)
        CType(Me.VRechercheClientBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CLIDataSet, System.ComponentModel.ISupportInitialize).EndInit()
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
    Friend WithEvents BT_Nouveau_Client As System.Windows.Forms.Button
    Friend WithEvents BT_Fermer As System.Windows.Forms.Button
    Friend WithEvents VRechercheClientBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents I_NbArticlesMin As System.Windows.Forms.TextBox
    Friend WithEvents I_NbArticlesMax As System.Windows.Forms.TextBox
    Friend WithEvents VilleTextBox As System.Windows.Forms.TextBox
    Friend WithEvents CodePostalTextbox As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label_Ville As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents I_Pays As System.Windows.Forms.ComboBox
    Friend WithEvents I_Societe As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents V_Recherche_ClientTableAdapter As CLI.CLIDataSetTableAdapters.V_Recherche_ClientTableAdapter

    Friend WithEvents SociétéDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents NomDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PrenomDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CodePostalDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents VilleDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PaysDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents NbArticleDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents I_Prenom As System.Windows.Forms.TextBox
    Friend WithEvents I_Nom As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents I_AvoirMax As System.Windows.Forms.TextBox
    Friend WithEvents I_NbCommandesMax As System.Windows.Forms.TextBox
    Friend WithEvents I_AvoirMin As System.Windows.Forms.TextBox
    Friend WithEvents I_NbCommandesMin As System.Windows.Forms.TextBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents I_EcheanceMax As System.Windows.Forms.TextBox
    Friend WithEvents I_EchanceMin As System.Windows.Forms.TextBox
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents BT_Impression As System.Windows.Forms.Button
    Friend WithEvents BT_Email As System.Windows.Forms.Button
    Friend WithEvents EtiquetteAdresseToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem

    Friend WithEvents T_ClientTableAdapter As CLI.CLIDataSetTableAdapters.T_ClientTableAdapter
    Friend WithEvents I_Wind As CheckBox
    Friend WithEvents I_sup As CheckBox
    Friend WithEvents I_kite As CheckBox
    'Friend WithEvents Ref As DataGridViewTextBoxColumn
    Friend WithEvents SociétéDataGridViewTextBoxColumn1 As DataGridViewTextBoxColumn
    Friend WithEvents NomDataGridViewTextBoxColumn1 As DataGridViewTextBoxColumn
    Friend WithEvents PrenomDataGridViewTextBoxColumn1 As DataGridViewTextBoxColumn
    Friend WithEvents CodePostalDataGridViewTextBoxColumn1 As DataGridViewTextBoxColumn
    Friend WithEvents VilleDataGridViewTextBoxColumn1 As DataGridViewTextBoxColumn
    Friend WithEvents PaysDataGridViewTextBoxColumn1 As DataGridViewTextBoxColumn
    Friend WithEvents NbCommande As DataGridViewTextBoxColumn
    Friend WithEvents NbArticleDataGridViewTextBoxColumn1 As DataGridViewTextBoxColumn
    Friend WithEvents MontantAvoirDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents EnvoyerMailRelanceAvoirsToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents I_TotalAvoir As TextBox
    Friend WithEvents IL_TotalAvoir As Label
    Friend WithEvents I_SynchroPrestashop As ComboBox
    Friend WithEvents IL_SynchroPS As Label
    Friend WithEvents Ref As DataGridViewTextBoxColumn
    Friend WithEvents SociétéDataGridViewTextBoxColumn2 As DataGridViewTextBoxColumn
    Friend WithEvents NomDataGridViewTextBoxColumn2 As DataGridViewTextBoxColumn
    Friend WithEvents PrenomDataGridViewTextBoxColumn2 As DataGridViewTextBoxColumn
    Friend WithEvents CodePostalDataGridViewTextBoxColumn2 As DataGridViewTextBoxColumn
    Friend WithEvents VilleDataGridViewTextBoxColumn2 As DataGridViewTextBoxColumn
    Friend WithEvents PaysDataGridViewTextBoxColumn2 As DataGridViewTextBoxColumn
    Friend WithEvents NbArticleDataGridViewTextBoxColumn2 As DataGridViewTextBoxColumn
    Friend WithEvents EchéancesDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents MontantAvoirDataGridViewTextBoxColumn1 As DataGridViewTextBoxColumn
    Friend WithEvents DerniereUtilisation As DataGridViewTextBoxColumn
    Friend WithEvents DernierAvoirCree As DataGridViewTextBoxColumn
    Friend WithEvents DerniereRelanceAvoir As DataGridViewTextBoxColumn
    Friend WithEvents actif As DataGridViewCheckBoxColumn
    Friend WithEvents NbCommandeDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents NumeroIdentiteDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents WindDataGridViewCheckBoxColumn As DataGridViewCheckBoxColumn
    Friend WithEvents KiteDataGridViewCheckBoxColumn As DataGridViewCheckBoxColumn
    Friend WithEvents SupDataGridViewCheckBoxColumn As DataGridViewCheckBoxColumn
    Friend WithEvents EtatSynchroPrestashop As DataGridViewTextBoxColumn
    Friend WithEvents I_Email As TextBox
    Friend WithEvents IL_Email As Label
End Class
