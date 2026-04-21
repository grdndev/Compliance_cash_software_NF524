<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FormArticleRecherche
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
        Dim DataGridViewCellStyle11 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle12 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle10 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormArticleRecherche))
        Me.DGview = New System.Windows.Forms.DataGridView()
        Me.Active_on = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.ref = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DescriptionCourte = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.surface = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.volume = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.taille = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Libelle = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.prix_vente_initial_TTC = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.remise = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.prix_vente_remise_TTC = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Stock = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.prix_fournisseur = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.remise_fournisseur = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.prix_remise_fournisseur = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ID_T_Client = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ID_T_Fournisseur = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.web_on = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.magasin_on = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.surcommande = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.precommande = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.TotalStockHT = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.creele = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Code_port = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.code_tva = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.EtatSynchroPrestashop = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ContextMenuStripRecherche = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.StockToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.InventaireToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MouvementToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CopieDarticlecompletToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EtatToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MagasinonToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ActiverToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DeasctiverToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.WebonToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ActiverToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.DésactiverToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ActiveonToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ActiverToolStripMenuItem2 = New System.Windows.Forms.ToolStripMenuItem()
        Me.DésactiverToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.PrecommandeToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ActiverToolStripMenuItem3 = New System.Windows.Forms.ToolStripMenuItem()
        Me.DésactiverToolStripMenuItem2 = New System.Windows.Forms.ToolStripMenuItem()
        Me.RéapproToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ActiverToolStripMenuItem4 = New System.Windows.Forms.ToolStripMenuItem()
        Me.DésactiverToolStripMenuItem3 = New System.Windows.Forms.ToolStripMenuItem()
        Me.StockLimiteToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ActioverToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DésactiverToolStripMenuItem4 = New System.Windows.Forms.ToolStripMenuItem()
        Me.SurCommandeToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ActiverToolStripMenuItem5 = New System.Windows.Forms.ToolStripMenuItem()
        Me.DésactiverToolStripMenuItem5 = New System.Windows.Forms.ToolStripMenuItem()
        Me.CodeBarreToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AvecPrixToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SansPrixToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CréationRepriseToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CréationDépotVenteToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.V_Recherche_ArticleBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.CLIDataSet = New CLI.CLIDataSet()
        Me.I_Reference = New System.Windows.Forms.TextBox()
        Me.I_Famille = New System.Windows.Forms.ComboBox()
        Me.I_SousFamille = New System.Windows.Forms.ComboBox()
        Me.I_Description = New System.Windows.Forms.TextBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label30 = New System.Windows.Forms.Label()
        Me.I_Type4 = New System.Windows.Forms.ComboBox()
        Me.Label29 = New System.Windows.Forms.Label()
        Me.I_Type3 = New System.Windows.Forms.ComboBox()
        Me.Label28 = New System.Windows.Forms.Label()
        Me.I_Type2 = New System.Windows.Forms.ComboBox()
        Me.I_SynchroPrestashop = New System.Windows.Forms.ComboBox()
        Me.IL_SynchroPS = New System.Windows.Forms.Label()
        Me.Label27 = New System.Windows.Forms.Label()
        Me.I_Promo = New System.Windows.Forms.ComboBox()
        Me.I_CreePar = New System.Windows.Forms.TextBox()
        Me.Label26 = New System.Windows.Forms.Label()
        Me.I_creeMax = New System.Windows.Forms.TextBox()
        Me.I_ClientMax = New System.Windows.Forms.TextBox()
        Me.I_StockMax = New System.Windows.Forms.TextBox()
        Me.I_CreeMin = New System.Windows.Forms.TextBox()
        Me.I_ClientMin = New System.Windows.Forms.TextBox()
        Me.I_StockMin = New System.Windows.Forms.TextBox()
        Me.I_Fournisseur = New System.Windows.Forms.ComboBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.I_test = New System.Windows.Forms.ComboBox()
        Me.I_RepriseDepot = New System.Windows.Forms.ComboBox()
        Me.I_Depot = New System.Windows.Forms.ComboBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.I_Occaz = New System.Windows.Forms.ComboBox()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.I_Magasin = New System.Windows.Forms.ComboBox()
        Me.I_Web = New System.Windows.Forms.ComboBox()
        Me.I_Active = New System.Windows.Forms.ComboBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.I_Marque = New System.Windows.Forms.ComboBox()
        Me.I_Annee = New System.Windows.Forms.TextBox()
        Me.I_Type = New System.Windows.Forms.ComboBox()
        Me.I_Modele = New System.Windows.Forms.ComboBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.I_Ref_Fournisseur = New System.Windows.Forms.TextBox()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.ToolTip = New System.Windows.Forms.ToolTip(Me.components)
        Me.StatusStrip = New System.Windows.Forms.StatusStrip()
        Me.ToolStripStatusLabelNbEnregistrements = New System.Windows.Forms.ToolStripStatusLabel()
        Me.BT_Go = New System.Windows.Forms.Button()
        Me.BT_Fermer = New System.Windows.Forms.Button()
        Me.BT_Nouvel_Article = New System.Windows.Forms.Button()
        Me.BT_Impression = New System.Windows.Forms.Button()
        Me.BT_RAZ = New System.Windows.Forms.Button()
        Me.I_TotalStockHT = New System.Windows.Forms.TextBox()
        Me.IL_TotalStockHT = New System.Windows.Forms.Label()
        Me.BT_Email = New System.Windows.Forms.Button()
        Me.V_Recherche_ArticleTableAdapter = New CLI.CLIDataSetTableAdapters.V_Recherche_ArticleTableAdapter()
        Me.Label31 = New System.Windows.Forms.Label()
        Me.I_Programme = New System.Windows.Forms.ComboBox()
        CType(Me.DGview, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ContextMenuStripRecherche.SuspendLayout()
        CType(Me.V_Recherche_ArticleBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CLIDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.StatusStrip.SuspendLayout()
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
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DGview.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.DGview.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGview.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Active_on, Me.ref, Me.DescriptionCourte, Me.surface, Me.volume, Me.taille, Me.Libelle, Me.prix_vente_initial_TTC, Me.remise, Me.prix_vente_remise_TTC, Me.Stock, Me.prix_fournisseur, Me.remise_fournisseur, Me.prix_remise_fournisseur, Me.ID_T_Client, Me.ID_T_Fournisseur, Me.web_on, Me.magasin_on, Me.surcommande, Me.precommande, Me.TotalStockHT, Me.creele, Me.Code_port, Me.code_tva, Me.EtatSynchroPrestashop})
        Me.DGview.ContextMenuStrip = Me.ContextMenuStripRecherche
        Me.DGview.DataSource = Me.V_Recherche_ArticleBindingSource
        DataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle11.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        DataGridViewCellStyle11.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle11.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle11.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle11.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DGview.DefaultCellStyle = DataGridViewCellStyle11
        Me.DGview.Location = New System.Drawing.Point(4, 376)
        Me.DGview.Name = "DGview"
        Me.DGview.ReadOnly = True
        DataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle12.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle12.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle12.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle12.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle12.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle12.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DGview.RowHeadersDefaultCellStyle = DataGridViewCellStyle12
        Me.DGview.RowHeadersVisible = False
        Me.DGview.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DGview.Size = New System.Drawing.Size(1366, 281)
        Me.DGview.TabIndex = 3
        '
        'Active_on
        '
        Me.Active_on.DataPropertyName = "Active_on"
        Me.Active_on.HeaderText = "Activé ?"
        Me.Active_on.Name = "Active_on"
        Me.Active_on.ReadOnly = True
        Me.Active_on.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.Active_on.Width = 89
        '
        'ref
        '
        Me.ref.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.ref.DataPropertyName = "Ref"
        Me.ref.HeaderText = "Ref"
        Me.ref.Name = "ref"
        Me.ref.ReadOnly = True
        Me.ref.Width = 49
        '
        'DescriptionCourte
        '
        Me.DescriptionCourte.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.DescriptionCourte.DataPropertyName = "Description courte"
        Me.DescriptionCourte.HeaderText = "Description courte"
        Me.DescriptionCourte.Name = "DescriptionCourte"
        Me.DescriptionCourte.ReadOnly = True
        Me.DescriptionCourte.Width = 108
        '
        'surface
        '
        Me.surface.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.surface.DataPropertyName = "surface"
        Me.surface.HeaderText = "Surface"
        Me.surface.Name = "surface"
        Me.surface.ReadOnly = True
        Me.surface.Width = 69
        '
        'volume
        '
        Me.volume.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.volume.DataPropertyName = "volume"
        Me.volume.HeaderText = "Volume"
        Me.volume.Name = "volume"
        Me.volume.ReadOnly = True
        Me.volume.Width = 67
        '
        'taille
        '
        Me.taille.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.taille.DataPropertyName = "taille"
        Me.taille.HeaderText = "Taille"
        Me.taille.Name = "taille"
        Me.taille.ReadOnly = True
        Me.taille.Width = 57
        '
        'Libelle
        '
        Me.Libelle.DataPropertyName = "Libelle"
        Me.Libelle.HeaderText = "Libelle"
        Me.Libelle.Name = "Libelle"
        Me.Libelle.ReadOnly = True
        '
        'prix_vente_initial_TTC
        '
        Me.prix_vente_initial_TTC.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.prix_vente_initial_TTC.DataPropertyName = "prix_vente_initial_TTC"
        DataGridViewCellStyle3.Format = "C2"
        DataGridViewCellStyle3.NullValue = Nothing
        Me.prix_vente_initial_TTC.DefaultCellStyle = DataGridViewCellStyle3
        Me.prix_vente_initial_TTC.HeaderText = "PV initial TTC"
        Me.prix_vente_initial_TTC.Name = "prix_vente_initial_TTC"
        Me.prix_vente_initial_TTC.ReadOnly = True
        Me.prix_vente_initial_TTC.Width = 65
        '
        'remise
        '
        Me.remise.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.remise.DataPropertyName = "remise"
        DataGridViewCellStyle4.Format = "0 %"
        DataGridViewCellStyle4.NullValue = "-"
        Me.remise.DefaultCellStyle = DataGridViewCellStyle4
        Me.remise.HeaderText = "Remise"
        Me.remise.Name = "remise"
        Me.remise.ReadOnly = True
        Me.remise.Width = 50
        '
        'prix_vente_remise_TTC
        '
        Me.prix_vente_remise_TTC.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.prix_vente_remise_TTC.DataPropertyName = "prix_vente_remise_TTC"
        DataGridViewCellStyle5.Format = "C2"
        Me.prix_vente_remise_TTC.DefaultCellStyle = DataGridViewCellStyle5
        Me.prix_vente_remise_TTC.HeaderText = "PV Remisé TTC"
        Me.prix_vente_remise_TTC.Name = "prix_vente_remise_TTC"
        Me.prix_vente_remise_TTC.ReadOnly = True
        Me.prix_vente_remise_TTC.Width = 65
        '
        'Stock
        '
        Me.Stock.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.Stock.DataPropertyName = "Stock"
        DataGridViewCellStyle6.NullValue = "0"
        Me.Stock.DefaultCellStyle = DataGridViewCellStyle6
        Me.Stock.HeaderText = "Stock"
        Me.Stock.Name = "Stock"
        Me.Stock.ReadOnly = True
        Me.Stock.Width = 60
        '
        'prix_fournisseur
        '
        Me.prix_fournisseur.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.prix_fournisseur.DataPropertyName = "prix_fournisseur"
        DataGridViewCellStyle7.Format = "C2"
        DataGridViewCellStyle7.NullValue = "0.00 €"
        Me.prix_fournisseur.DefaultCellStyle = DataGridViewCellStyle7
        Me.prix_fournisseur.HeaderText = "Prix fournisseur"
        Me.prix_fournisseur.Name = "prix_fournisseur"
        Me.prix_fournisseur.ReadOnly = True
        Me.prix_fournisseur.Visible = False
        Me.prix_fournisseur.Width = 70
        '
        'remise_fournisseur
        '
        Me.remise_fournisseur.DataPropertyName = "remise_fournisseur"
        DataGridViewCellStyle8.Format = "0 %"
        Me.remise_fournisseur.DefaultCellStyle = DataGridViewCellStyle8
        Me.remise_fournisseur.HeaderText = "Remise fournisseur"
        Me.remise_fournisseur.Name = "remise_fournisseur"
        Me.remise_fournisseur.ReadOnly = True
        Me.remise_fournisseur.Visible = False
        '
        'prix_remise_fournisseur
        '
        Me.prix_remise_fournisseur.DataPropertyName = "prix_remise_fournisseur"
        DataGridViewCellStyle9.Format = "C2"
        Me.prix_remise_fournisseur.DefaultCellStyle = DataGridViewCellStyle9
        Me.prix_remise_fournisseur.HeaderText = "Prix fournisseur tarif Chinook"
        Me.prix_remise_fournisseur.Name = "prix_remise_fournisseur"
        Me.prix_remise_fournisseur.ReadOnly = True
        Me.prix_remise_fournisseur.Visible = False
        '
        'ID_T_Client
        '
        Me.ID_T_Client.DataPropertyName = "ID_T_Client"
        Me.ID_T_Client.HeaderText = "Code Client"
        Me.ID_T_Client.Name = "ID_T_Client"
        Me.ID_T_Client.ReadOnly = True
        '
        'ID_T_Fournisseur
        '
        Me.ID_T_Fournisseur.DataPropertyName = "ID_T_Fournisseur"
        Me.ID_T_Fournisseur.HeaderText = "Code Fournisseur"
        Me.ID_T_Fournisseur.Name = "ID_T_Fournisseur"
        Me.ID_T_Fournisseur.ReadOnly = True
        '
        'web_on
        '
        Me.web_on.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.web_on.DataPropertyName = "web_on"
        Me.web_on.HeaderText = "Web?"
        Me.web_on.Name = "web_on"
        Me.web_on.ReadOnly = True
        Me.web_on.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.web_on.Width = 61
        '
        'magasin_on
        '
        Me.magasin_on.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.magasin_on.DataPropertyName = "magasin_on"
        Me.magasin_on.HeaderText = "Magasin?"
        Me.magasin_on.Name = "magasin_on"
        Me.magasin_on.ReadOnly = True
        Me.magasin_on.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.magasin_on.Width = 78
        '
        'surcommande
        '
        Me.surcommande.DataPropertyName = "surcommande"
        Me.surcommande.HeaderText = "Sur commande ?"
        Me.surcommande.Name = "surcommande"
        Me.surcommande.ReadOnly = True
        '
        'precommande
        '
        Me.precommande.DataPropertyName = "precommande"
        Me.precommande.HeaderText = "Precommande ?"
        Me.precommande.Name = "precommande"
        Me.precommande.ReadOnly = True
        '
        'TotalStockHT
        '
        Me.TotalStockHT.DataPropertyName = "Total stock HT"
        DataGridViewCellStyle10.Format = "C2"
        DataGridViewCellStyle10.NullValue = "0.00 €"
        Me.TotalStockHT.DefaultCellStyle = DataGridViewCellStyle10
        Me.TotalStockHT.HeaderText = "Total stock HT"
        Me.TotalStockHT.Name = "TotalStockHT"
        Me.TotalStockHT.ReadOnly = True
        Me.TotalStockHT.Visible = False
        '
        'creele
        '
        Me.creele.DataPropertyName = "creele"
        Me.creele.HeaderText = "Créé le"
        Me.creele.Name = "creele"
        Me.creele.ReadOnly = True
        '
        'Code_port
        '
        Me.Code_port.DataPropertyName = "code_port"
        Me.Code_port.HeaderText = "Code port"
        Me.Code_port.Name = "Code_port"
        Me.Code_port.ReadOnly = True
        Me.Code_port.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Code_port.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'code_tva
        '
        Me.code_tva.DataPropertyName = "code_tva"
        Me.code_tva.HeaderText = "Code TVA"
        Me.code_tva.Name = "code_tva"
        Me.code_tva.ReadOnly = True
        '
        'EtatSynchroPrestashop
        '
        Me.EtatSynchroPrestashop.DataPropertyName = "SynchroPrestashop"
        Me.EtatSynchroPrestashop.HeaderText = "EtatSynchroPrestashop"
        Me.EtatSynchroPrestashop.Name = "EtatSynchroPrestashop"
        Me.EtatSynchroPrestashop.ReadOnly = True
        '
        'ContextMenuStripRecherche
        '
        Me.ContextMenuStripRecherche.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.StockToolStripMenuItem, Me.CopieDarticlecompletToolStripMenuItem, Me.EtatToolStripMenuItem, Me.CodeBarreToolStripMenuItem, Me.CréationRepriseToolStripMenuItem, Me.CréationDépotVenteToolStripMenuItem})
        Me.ContextMenuStripRecherche.Name = "ContextMenuStrip"
        Me.ContextMenuStripRecherche.Size = New System.Drawing.Size(293, 136)
        '
        'StockToolStripMenuItem
        '
        Me.StockToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.InventaireToolStripMenuItem, Me.MouvementToolStripMenuItem})
        Me.StockToolStripMenuItem.Image = Global.CLI.My.Resources.Resources.TaskHS1
        Me.StockToolStripMenuItem.Name = "StockToolStripMenuItem"
        Me.StockToolStripMenuItem.Size = New System.Drawing.Size(292, 22)
        Me.StockToolStripMenuItem.Text = "Stock"
        '
        'InventaireToolStripMenuItem
        '
        Me.InventaireToolStripMenuItem.Image = Global.CLI.My.Resources.Resources.MonthlyViewHS
        Me.InventaireToolStripMenuItem.Name = "InventaireToolStripMenuItem"
        Me.InventaireToolStripMenuItem.Size = New System.Drawing.Size(139, 22)
        Me.InventaireToolStripMenuItem.Text = "Inventaire"
        '
        'MouvementToolStripMenuItem
        '
        Me.MouvementToolStripMenuItem.Image = Global.CLI.My.Resources.Resources.AddTableHS
        Me.MouvementToolStripMenuItem.Name = "MouvementToolStripMenuItem"
        Me.MouvementToolStripMenuItem.Size = New System.Drawing.Size(139, 22)
        Me.MouvementToolStripMenuItem.Text = "Mouvement"
        '
        'CopieDarticlecompletToolStripMenuItem
        '
        Me.CopieDarticlecompletToolStripMenuItem.Image = Global.CLI.My.Resources.Resources.AddTableHS
        Me.CopieDarticlecompletToolStripMenuItem.Name = "CopieDarticlecompletToolStripMenuItem"
        Me.CopieDarticlecompletToolStripMenuItem.Size = New System.Drawing.Size(292, 22)
        Me.CopieDarticlecompletToolStripMenuItem.Text = "Copie de l'article et de toutes ses versions"
        '
        'EtatToolStripMenuItem
        '
        Me.EtatToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MagasinonToolStripMenuItem, Me.WebonToolStripMenuItem, Me.ActiveonToolStripMenuItem, Me.PrecommandeToolStripMenuItem, Me.RéapproToolStripMenuItem, Me.StockLimiteToolStripMenuItem, Me.SurCommandeToolStripMenuItem})
        Me.EtatToolStripMenuItem.Image = Global.CLI.My.Resources.Resources.GoToNextHS
        Me.EtatToolStripMenuItem.Name = "EtatToolStripMenuItem"
        Me.EtatToolStripMenuItem.Size = New System.Drawing.Size(292, 22)
        Me.EtatToolStripMenuItem.Text = "Etat"
        '
        'MagasinonToolStripMenuItem
        '
        Me.MagasinonToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ActiverToolStripMenuItem, Me.DeasctiverToolStripMenuItem})
        Me.MagasinonToolStripMenuItem.Name = "MagasinonToolStripMenuItem"
        Me.MagasinonToolStripMenuItem.Size = New System.Drawing.Size(157, 22)
        Me.MagasinonToolStripMenuItem.Text = "Magasin"
        '
        'ActiverToolStripMenuItem
        '
        Me.ActiverToolStripMenuItem.Name = "ActiverToolStripMenuItem"
        Me.ActiverToolStripMenuItem.Size = New System.Drawing.Size(128, 22)
        Me.ActiverToolStripMenuItem.Text = "Activer"
        '
        'DeasctiverToolStripMenuItem
        '
        Me.DeasctiverToolStripMenuItem.Name = "DeasctiverToolStripMenuItem"
        Me.DeasctiverToolStripMenuItem.Size = New System.Drawing.Size(128, 22)
        Me.DeasctiverToolStripMenuItem.Text = "Désactiver"
        '
        'WebonToolStripMenuItem
        '
        Me.WebonToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ActiverToolStripMenuItem1, Me.DésactiverToolStripMenuItem})
        Me.WebonToolStripMenuItem.Name = "WebonToolStripMenuItem"
        Me.WebonToolStripMenuItem.Size = New System.Drawing.Size(157, 22)
        Me.WebonToolStripMenuItem.Text = "Web"
        '
        'ActiverToolStripMenuItem1
        '
        Me.ActiverToolStripMenuItem1.Name = "ActiverToolStripMenuItem1"
        Me.ActiverToolStripMenuItem1.Size = New System.Drawing.Size(128, 22)
        Me.ActiverToolStripMenuItem1.Text = "Activer"
        '
        'DésactiverToolStripMenuItem
        '
        Me.DésactiverToolStripMenuItem.Name = "DésactiverToolStripMenuItem"
        Me.DésactiverToolStripMenuItem.Size = New System.Drawing.Size(128, 22)
        Me.DésactiverToolStripMenuItem.Text = "Désactiver"
        '
        'ActiveonToolStripMenuItem
        '
        Me.ActiveonToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ActiverToolStripMenuItem2, Me.DésactiverToolStripMenuItem1})
        Me.ActiveonToolStripMenuItem.Name = "ActiveonToolStripMenuItem"
        Me.ActiveonToolStripMenuItem.Size = New System.Drawing.Size(157, 22)
        Me.ActiveonToolStripMenuItem.Text = "Active"
        '
        'ActiverToolStripMenuItem2
        '
        Me.ActiverToolStripMenuItem2.Name = "ActiverToolStripMenuItem2"
        Me.ActiverToolStripMenuItem2.Size = New System.Drawing.Size(128, 22)
        Me.ActiverToolStripMenuItem2.Text = "Activer"
        '
        'DésactiverToolStripMenuItem1
        '
        Me.DésactiverToolStripMenuItem1.Name = "DésactiverToolStripMenuItem1"
        Me.DésactiverToolStripMenuItem1.Size = New System.Drawing.Size(128, 22)
        Me.DésactiverToolStripMenuItem1.Text = "Désactiver"
        '
        'PrecommandeToolStripMenuItem
        '
        Me.PrecommandeToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ActiverToolStripMenuItem3, Me.DésactiverToolStripMenuItem2})
        Me.PrecommandeToolStripMenuItem.Name = "PrecommandeToolStripMenuItem"
        Me.PrecommandeToolStripMenuItem.Size = New System.Drawing.Size(157, 22)
        Me.PrecommandeToolStripMenuItem.Text = "Pre-commande"
        '
        'ActiverToolStripMenuItem3
        '
        Me.ActiverToolStripMenuItem3.Name = "ActiverToolStripMenuItem3"
        Me.ActiverToolStripMenuItem3.Size = New System.Drawing.Size(128, 22)
        Me.ActiverToolStripMenuItem3.Text = "Activer"
        '
        'DésactiverToolStripMenuItem2
        '
        Me.DésactiverToolStripMenuItem2.Name = "DésactiverToolStripMenuItem2"
        Me.DésactiverToolStripMenuItem2.Size = New System.Drawing.Size(128, 22)
        Me.DésactiverToolStripMenuItem2.Text = "Désactiver"
        '
        'RéapproToolStripMenuItem
        '
        Me.RéapproToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ActiverToolStripMenuItem4, Me.DésactiverToolStripMenuItem3})
        Me.RéapproToolStripMenuItem.Name = "RéapproToolStripMenuItem"
        Me.RéapproToolStripMenuItem.Size = New System.Drawing.Size(157, 22)
        Me.RéapproToolStripMenuItem.Text = "Réappro"
        '
        'ActiverToolStripMenuItem4
        '
        Me.ActiverToolStripMenuItem4.Name = "ActiverToolStripMenuItem4"
        Me.ActiverToolStripMenuItem4.Size = New System.Drawing.Size(128, 22)
        Me.ActiverToolStripMenuItem4.Text = "Activer"
        '
        'DésactiverToolStripMenuItem3
        '
        Me.DésactiverToolStripMenuItem3.Name = "DésactiverToolStripMenuItem3"
        Me.DésactiverToolStripMenuItem3.Size = New System.Drawing.Size(128, 22)
        Me.DésactiverToolStripMenuItem3.Text = "Désactiver"
        '
        'StockLimiteToolStripMenuItem
        '
        Me.StockLimiteToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ActioverToolStripMenuItem, Me.DésactiverToolStripMenuItem4})
        Me.StockLimiteToolStripMenuItem.Name = "StockLimiteToolStripMenuItem"
        Me.StockLimiteToolStripMenuItem.Size = New System.Drawing.Size(157, 22)
        Me.StockLimiteToolStripMenuItem.Text = "Stock limite"
        '
        'ActioverToolStripMenuItem
        '
        Me.ActioverToolStripMenuItem.Name = "ActioverToolStripMenuItem"
        Me.ActioverToolStripMenuItem.Size = New System.Drawing.Size(128, 22)
        Me.ActioverToolStripMenuItem.Text = "Activer"
        '
        'DésactiverToolStripMenuItem4
        '
        Me.DésactiverToolStripMenuItem4.Name = "DésactiverToolStripMenuItem4"
        Me.DésactiverToolStripMenuItem4.Size = New System.Drawing.Size(128, 22)
        Me.DésactiverToolStripMenuItem4.Text = "Désactiver"
        '
        'SurCommandeToolStripMenuItem
        '
        Me.SurCommandeToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ActiverToolStripMenuItem5, Me.DésactiverToolStripMenuItem5})
        Me.SurCommandeToolStripMenuItem.Name = "SurCommandeToolStripMenuItem"
        Me.SurCommandeToolStripMenuItem.Size = New System.Drawing.Size(157, 22)
        Me.SurCommandeToolStripMenuItem.Text = "Sur commande"
        '
        'ActiverToolStripMenuItem5
        '
        Me.ActiverToolStripMenuItem5.Name = "ActiverToolStripMenuItem5"
        Me.ActiverToolStripMenuItem5.Size = New System.Drawing.Size(128, 22)
        Me.ActiverToolStripMenuItem5.Text = "Activer"
        '
        'DésactiverToolStripMenuItem5
        '
        Me.DésactiverToolStripMenuItem5.Name = "DésactiverToolStripMenuItem5"
        Me.DésactiverToolStripMenuItem5.Size = New System.Drawing.Size(128, 22)
        Me.DésactiverToolStripMenuItem5.Text = "Désactiver"
        '
        'CodeBarreToolStripMenuItem
        '
        Me.CodeBarreToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AvecPrixToolStripMenuItem, Me.SansPrixToolStripMenuItem})
        Me.CodeBarreToolStripMenuItem.Image = Global.CLI.My.Resources.Resources.BarCodeHS
        Me.CodeBarreToolStripMenuItem.Name = "CodeBarreToolStripMenuItem"
        Me.CodeBarreToolStripMenuItem.Size = New System.Drawing.Size(292, 22)
        Me.CodeBarreToolStripMenuItem.Text = "Code Barre"
        '
        'AvecPrixToolStripMenuItem
        '
        Me.AvecPrixToolStripMenuItem.Name = "AvecPrixToolStripMenuItem"
        Me.AvecPrixToolStripMenuItem.Size = New System.Drawing.Size(123, 22)
        Me.AvecPrixToolStripMenuItem.Text = "Avec Prix"
        '
        'SansPrixToolStripMenuItem
        '
        Me.SansPrixToolStripMenuItem.Name = "SansPrixToolStripMenuItem"
        Me.SansPrixToolStripMenuItem.Size = New System.Drawing.Size(123, 22)
        Me.SansPrixToolStripMenuItem.Text = "Sans Prix"
        '
        'CréationRepriseToolStripMenuItem
        '
        Me.CréationRepriseToolStripMenuItem.Image = Global.CLI.My.Resources.Resources.AddTableHS
        Me.CréationRepriseToolStripMenuItem.Name = "CréationRepriseToolStripMenuItem"
        Me.CréationRepriseToolStripMenuItem.Size = New System.Drawing.Size(292, 22)
        Me.CréationRepriseToolStripMenuItem.Text = "Création reprise"
        '
        'CréationDépotVenteToolStripMenuItem
        '
        Me.CréationDépotVenteToolStripMenuItem.Image = Global.CLI.My.Resources.Resources.AddTableHS
        Me.CréationDépotVenteToolStripMenuItem.Name = "CréationDépotVenteToolStripMenuItem"
        Me.CréationDépotVenteToolStripMenuItem.Size = New System.Drawing.Size(292, 22)
        Me.CréationDépotVenteToolStripMenuItem.Text = "Création dépot vente"
        '
        'V_Recherche_ArticleBindingSource
        '
        Me.V_Recherche_ArticleBindingSource.DataMember = "V_Recherche_Article"
        Me.V_Recherche_ArticleBindingSource.DataSource = Me.CLIDataSet
        '
        'CLIDataSet
        '
        Me.CLIDataSet.DataSetName = "CLIDataSet"
        Me.CLIDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'I_Reference
        '
        Me.I_Reference.Location = New System.Drawing.Point(94, 24)
        Me.I_Reference.Name = "I_Reference"
        Me.I_Reference.Size = New System.Drawing.Size(100, 20)
        Me.I_Reference.TabIndex = 0
        '
        'I_Famille
        '
        Me.I_Famille.DisplayMember = "Famille"
        Me.I_Famille.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.I_Famille.FormattingEnabled = True
        Me.I_Famille.Location = New System.Drawing.Point(99, 18)
        Me.I_Famille.Name = "I_Famille"
        Me.I_Famille.Size = New System.Drawing.Size(121, 21)
        Me.I_Famille.TabIndex = 3
        Me.I_Famille.ValueMember = "Famille"
        '
        'I_SousFamille
        '
        Me.I_SousFamille.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.I_SousFamille.FormattingEnabled = True
        Me.I_SousFamille.Location = New System.Drawing.Point(99, 45)
        Me.I_SousFamille.Name = "I_SousFamille"
        Me.I_SousFamille.Size = New System.Drawing.Size(121, 21)
        Me.I_SousFamille.TabIndex = 4
        '
        'I_Description
        '
        Me.I_Description.Location = New System.Drawing.Point(99, 180)
        Me.I_Description.Name = "I_Description"
        Me.I_Description.Size = New System.Drawing.Size(335, 20)
        Me.I_Description.TabIndex = 5
        Me.ToolTip.SetToolTip(Me.I_Description, "Utiliser % pour effectuer une recherche générique" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "ex : Starboard%" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10))
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.I_Programme)
        Me.GroupBox1.Controls.Add(Me.Label31)
        Me.GroupBox1.Controls.Add(Me.Label30)
        Me.GroupBox1.Controls.Add(Me.I_Type4)
        Me.GroupBox1.Controls.Add(Me.Label29)
        Me.GroupBox1.Controls.Add(Me.I_Type3)
        Me.GroupBox1.Controls.Add(Me.Label28)
        Me.GroupBox1.Controls.Add(Me.I_Type2)
        Me.GroupBox1.Controls.Add(Me.I_SynchroPrestashop)
        Me.GroupBox1.Controls.Add(Me.IL_SynchroPS)
        Me.GroupBox1.Controls.Add(Me.Label27)
        Me.GroupBox1.Controls.Add(Me.I_Promo)
        Me.GroupBox1.Controls.Add(Me.I_CreePar)
        Me.GroupBox1.Controls.Add(Me.Label26)
        Me.GroupBox1.Controls.Add(Me.I_creeMax)
        Me.GroupBox1.Controls.Add(Me.I_ClientMax)
        Me.GroupBox1.Controls.Add(Me.I_StockMax)
        Me.GroupBox1.Controls.Add(Me.I_CreeMin)
        Me.GroupBox1.Controls.Add(Me.I_ClientMin)
        Me.GroupBox1.Controls.Add(Me.I_StockMin)
        Me.GroupBox1.Controls.Add(Me.I_Fournisseur)
        Me.GroupBox1.Controls.Add(Me.Label11)
        Me.GroupBox1.Controls.Add(Me.Label24)
        Me.GroupBox1.Controls.Add(Me.Label13)
        Me.GroupBox1.Controls.Add(Me.Label19)
        Me.GroupBox1.Controls.Add(Me.Label12)
        Me.GroupBox1.Controls.Add(Me.I_test)
        Me.GroupBox1.Controls.Add(Me.I_RepriseDepot)
        Me.GroupBox1.Controls.Add(Me.I_Depot)
        Me.GroupBox1.Controls.Add(Me.Label10)
        Me.GroupBox1.Controls.Add(Me.I_Occaz)
        Me.GroupBox1.Controls.Add(Me.Label23)
        Me.GroupBox1.Controls.Add(Me.Label21)
        Me.GroupBox1.Controls.Add(Me.Label16)
        Me.GroupBox1.Controls.Add(Me.Label22)
        Me.GroupBox1.Controls.Add(Me.Label20)
        Me.GroupBox1.Controls.Add(Me.Label15)
        Me.GroupBox1.Controls.Add(Me.Label14)
        Me.GroupBox1.Controls.Add(Me.Label9)
        Me.GroupBox1.Controls.Add(Me.I_Magasin)
        Me.GroupBox1.Controls.Add(Me.I_Web)
        Me.GroupBox1.Controls.Add(Me.I_Active)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.Label25)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Controls.Add(Me.I_Marque)
        Me.GroupBox1.Controls.Add(Me.I_Annee)
        Me.GroupBox1.Controls.Add(Me.I_Type)
        Me.GroupBox1.Controls.Add(Me.I_Modele)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.I_Famille)
        Me.GroupBox1.Controls.Add(Me.I_Description)
        Me.GroupBox1.Controls.Add(Me.I_SousFamille)
        Me.GroupBox1.Location = New System.Drawing.Point(269, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(630, 358)
        Me.GroupBox1.TabIndex = 1
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Multi-critère"
        '
        'Label30
        '
        Me.Label30.AutoSize = True
        Me.Label30.Location = New System.Drawing.Point(34, 156)
        Me.Label30.Name = "Label30"
        Me.Label30.Size = New System.Drawing.Size(37, 13)
        Me.Label30.TabIndex = 31
        Me.Label30.Text = "Type4"
        '
        'I_Type4
        '
        Me.I_Type4.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.I_Type4.FormattingEnabled = True
        Me.I_Type4.Location = New System.Drawing.Point(100, 153)
        Me.I_Type4.Name = "I_Type4"
        Me.I_Type4.Size = New System.Drawing.Size(121, 21)
        Me.I_Type4.TabIndex = 30
        '
        'Label29
        '
        Me.Label29.AutoSize = True
        Me.Label29.Location = New System.Drawing.Point(34, 129)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(37, 13)
        Me.Label29.TabIndex = 29
        Me.Label29.Text = "Type3"
        '
        'I_Type3
        '
        Me.I_Type3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.I_Type3.FormattingEnabled = True
        Me.I_Type3.Location = New System.Drawing.Point(100, 126)
        Me.I_Type3.Name = "I_Type3"
        Me.I_Type3.Size = New System.Drawing.Size(121, 21)
        Me.I_Type3.TabIndex = 28
        '
        'Label28
        '
        Me.Label28.AutoSize = True
        Me.Label28.Location = New System.Drawing.Point(34, 102)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(37, 13)
        Me.Label28.TabIndex = 27
        Me.Label28.Text = "Type2"
        '
        'I_Type2
        '
        Me.I_Type2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.I_Type2.FormattingEnabled = True
        Me.I_Type2.Location = New System.Drawing.Point(100, 99)
        Me.I_Type2.Name = "I_Type2"
        Me.I_Type2.Size = New System.Drawing.Size(121, 21)
        Me.I_Type2.TabIndex = 26
        '
        'I_SynchroPrestashop
        '
        Me.I_SynchroPrestashop.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.I_SynchroPrestashop.FormattingEnabled = True
        Me.I_SynchroPrestashop.Items.AddRange(New Object() {"<Tous>", "Ok", "Erreur", "Non"})
        Me.I_SynchroPrestashop.Location = New System.Drawing.Point(310, 283)
        Me.I_SynchroPrestashop.Name = "I_SynchroPrestashop"
        Me.I_SynchroPrestashop.Size = New System.Drawing.Size(121, 21)
        Me.I_SynchroPrestashop.TabIndex = 25
        '
        'IL_SynchroPS
        '
        Me.IL_SynchroPS.AutoSize = True
        Me.IL_SynchroPS.Location = New System.Drawing.Point(310, 266)
        Me.IL_SynchroPS.Name = "IL_SynchroPS"
        Me.IL_SynchroPS.Size = New System.Drawing.Size(122, 13)
        Me.IL_SynchroPS.TabIndex = 24
        Me.IL_SynchroPS.Text = "Etat synchro Prestashop"
        '
        'Label27
        '
        Me.Label27.AutoSize = True
        Me.Label27.Location = New System.Drawing.Point(211, 317)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(46, 13)
        Me.Label27.TabIndex = 23
        Me.Label27.Text = "Promo ?"
        '
        'I_Promo
        '
        Me.I_Promo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.I_Promo.FormattingEnabled = True
        Me.I_Promo.Items.AddRange(New Object() {"<Tous>", "Oui", "Non"})
        Me.I_Promo.Location = New System.Drawing.Point(214, 333)
        Me.I_Promo.Name = "I_Promo"
        Me.I_Promo.Size = New System.Drawing.Size(63, 21)
        Me.I_Promo.TabIndex = 22
        '
        'I_CreePar
        '
        Me.I_CreePar.Location = New System.Drawing.Point(312, 206)
        Me.I_CreePar.Name = "I_CreePar"
        Me.I_CreePar.Size = New System.Drawing.Size(119, 20)
        Me.I_CreePar.TabIndex = 21
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.Location = New System.Drawing.Point(246, 209)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(50, 13)
        Me.Label26.TabIndex = 20
        Me.Label26.Text = "N° import"
        '
        'I_creeMax
        '
        Me.I_creeMax.Location = New System.Drawing.Point(189, 260)
        Me.I_creeMax.Name = "I_creeMax"
        Me.I_creeMax.Size = New System.Drawing.Size(69, 20)
        Me.I_creeMax.TabIndex = 19
        '
        'I_ClientMax
        '
        Me.I_ClientMax.Location = New System.Drawing.Point(189, 233)
        Me.I_ClientMax.Name = "I_ClientMax"
        Me.I_ClientMax.Size = New System.Drawing.Size(69, 20)
        Me.I_ClientMax.TabIndex = 19
        '
        'I_StockMax
        '
        Me.I_StockMax.Location = New System.Drawing.Point(188, 289)
        Me.I_StockMax.Name = "I_StockMax"
        Me.I_StockMax.Size = New System.Drawing.Size(69, 20)
        Me.I_StockMax.TabIndex = 19
        '
        'I_CreeMin
        '
        Me.I_CreeMin.Location = New System.Drawing.Point(99, 259)
        Me.I_CreeMin.Name = "I_CreeMin"
        Me.I_CreeMin.Size = New System.Drawing.Size(66, 20)
        Me.I_CreeMin.TabIndex = 19
        '
        'I_ClientMin
        '
        Me.I_ClientMin.Location = New System.Drawing.Point(99, 232)
        Me.I_ClientMin.Name = "I_ClientMin"
        Me.I_ClientMin.Size = New System.Drawing.Size(66, 20)
        Me.I_ClientMin.TabIndex = 19
        '
        'I_StockMin
        '
        Me.I_StockMin.Location = New System.Drawing.Point(98, 288)
        Me.I_StockMin.Name = "I_StockMin"
        Me.I_StockMin.Size = New System.Drawing.Size(66, 20)
        Me.I_StockMin.TabIndex = 19
        '
        'I_Fournisseur
        '
        Me.I_Fournisseur.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.I_Fournisseur.FormattingEnabled = True
        Me.I_Fournisseur.Location = New System.Drawing.Point(99, 206)
        Me.I_Fournisseur.Name = "I_Fournisseur"
        Me.I_Fournisseur.Size = New System.Drawing.Size(121, 21)
        Me.I_Fournisseur.TabIndex = 18
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(74, 317)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(39, 13)
        Me.Label11.TabIndex = 17
        Me.Label11.Text = "Web ?"
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.Location = New System.Drawing.Point(427, 317)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(37, 13)
        Me.Label24.TabIndex = 17
        Me.Label24.Text = "Test ?"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(346, 317)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(75, 13)
        Me.Label13.TabIndex = 17
        Me.Label13.Text = "Dépot vente ?"
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(493, 317)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(129, 13)
        Me.Label19.TabIndex = 17
        Me.Label19.Text = "Reprise ou dépot ou test?"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(277, 317)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(52, 13)
        Me.Label12.TabIndex = 17
        Me.Label12.Text = "Reprise ?"
        '
        'I_test
        '
        Me.I_test.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.I_test.FormattingEnabled = True
        Me.I_test.Items.AddRange(New Object() {"<Tous>", "Oui", "Non"})
        Me.I_test.Location = New System.Drawing.Point(430, 333)
        Me.I_test.Name = "I_test"
        Me.I_test.Size = New System.Drawing.Size(63, 21)
        Me.I_test.TabIndex = 16
        '
        'I_RepriseDepot
        '
        Me.I_RepriseDepot.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.I_RepriseDepot.FormattingEnabled = True
        Me.I_RepriseDepot.Items.AddRange(New Object() {"<Tous>", "Oui", "Non"})
        Me.I_RepriseDepot.Location = New System.Drawing.Point(496, 333)
        Me.I_RepriseDepot.Name = "I_RepriseDepot"
        Me.I_RepriseDepot.Size = New System.Drawing.Size(63, 21)
        Me.I_RepriseDepot.TabIndex = 16
        '
        'I_Depot
        '
        Me.I_Depot.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.I_Depot.FormattingEnabled = True
        Me.I_Depot.Items.AddRange(New Object() {"<Tous>", "Oui", "Non"})
        Me.I_Depot.Location = New System.Drawing.Point(349, 333)
        Me.I_Depot.Name = "I_Depot"
        Me.I_Depot.Size = New System.Drawing.Size(63, 21)
        Me.I_Depot.TabIndex = 16
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(141, 317)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(56, 13)
        Me.Label10.TabIndex = 17
        Me.Label10.Text = "Magasin ?"
        '
        'I_Occaz
        '
        Me.I_Occaz.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.I_Occaz.FormattingEnabled = True
        Me.I_Occaz.Items.AddRange(New Object() {"<Tous>", "Oui", "Non"})
        Me.I_Occaz.Location = New System.Drawing.Point(280, 333)
        Me.I_Occaz.Name = "I_Occaz"
        Me.I_Occaz.Size = New System.Drawing.Size(63, 21)
        Me.I_Occaz.TabIndex = 16
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Location = New System.Drawing.Point(171, 263)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(19, 13)
        Me.Label23.TabIndex = 17
        Me.Label23.Text = "au"
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Location = New System.Drawing.Point(171, 236)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(13, 13)
        Me.Label21.TabIndex = 17
        Me.Label21.Text = "à"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(170, 292)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(13, 13)
        Me.Label16.TabIndex = 17
        Me.Label16.Text = "à"
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Location = New System.Drawing.Point(7, 262)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(92, 13)
        Me.Label22.TabIndex = 17
        Me.Label22.Text = "Créé (jj/mm/aaaa)"
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Location = New System.Drawing.Point(7, 235)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(33, 13)
        Me.Label20.TabIndex = 17
        Me.Label20.Text = "Client"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(6, 291)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(35, 13)
        Me.Label15.TabIndex = 17
        Me.Label15.Text = "Stock"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(7, 209)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(61, 13)
        Me.Label14.TabIndex = 17
        Me.Label14.Text = "Fournisseur"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(6, 317)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(37, 13)
        Me.Label9.TabIndex = 17
        Me.Label9.Text = "Actif ?"
        '
        'I_Magasin
        '
        Me.I_Magasin.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.I_Magasin.FormattingEnabled = True
        Me.I_Magasin.Items.AddRange(New Object() {"<Tous>", "Oui", "Non"})
        Me.I_Magasin.Location = New System.Drawing.Point(144, 333)
        Me.I_Magasin.Name = "I_Magasin"
        Me.I_Magasin.Size = New System.Drawing.Size(63, 21)
        Me.I_Magasin.TabIndex = 16
        '
        'I_Web
        '
        Me.I_Web.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.I_Web.FormattingEnabled = True
        Me.I_Web.Items.AddRange(New Object() {"<Tous>", "Oui", "Non"})
        Me.I_Web.Location = New System.Drawing.Point(77, 333)
        Me.I_Web.Name = "I_Web"
        Me.I_Web.Size = New System.Drawing.Size(63, 21)
        Me.I_Web.TabIndex = 16
        '
        'I_Active
        '
        Me.I_Active.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.I_Active.FormattingEnabled = True
        Me.I_Active.Items.AddRange(New Object() {"<Tous>", "Oui", "Non"})
        Me.I_Active.Location = New System.Drawing.Point(6, 333)
        Me.I_Active.Name = "I_Active"
        Me.I_Active.Size = New System.Drawing.Size(63, 21)
        Me.I_Active.TabIndex = 16
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(247, 73)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(53, 13)
        Me.Label6.TabIndex = 14
        Me.Label6.Text = "Collection"
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.Location = New System.Drawing.Point(34, 75)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(31, 13)
        Me.Label25.TabIndex = 13
        Me.Label25.Text = "Type"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(247, 46)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(42, 13)
        Me.Label7.TabIndex = 13
        Me.Label7.Text = "Modele"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(247, 21)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(43, 13)
        Me.Label8.TabIndex = 12
        Me.Label8.Text = "Marque"
        '
        'I_Marque
        '
        Me.I_Marque.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.I_Marque.FormattingEnabled = True
        Me.I_Marque.Location = New System.Drawing.Point(313, 16)
        Me.I_Marque.Name = "I_Marque"
        Me.I_Marque.Size = New System.Drawing.Size(121, 21)
        Me.I_Marque.TabIndex = 9
        '
        'I_Annee
        '
        Me.I_Annee.Location = New System.Drawing.Point(313, 70)
        Me.I_Annee.Name = "I_Annee"
        Me.I_Annee.Size = New System.Drawing.Size(121, 20)
        Me.I_Annee.TabIndex = 11
        '
        'I_Type
        '
        Me.I_Type.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.I_Type.FormattingEnabled = True
        Me.I_Type.Location = New System.Drawing.Point(100, 72)
        Me.I_Type.Name = "I_Type"
        Me.I_Type.Size = New System.Drawing.Size(121, 21)
        Me.I_Type.TabIndex = 10
        '
        'I_Modele
        '
        Me.I_Modele.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.I_Modele.FormattingEnabled = True
        Me.I_Modele.Location = New System.Drawing.Point(313, 43)
        Me.I_Modele.Name = "I_Modele"
        Me.I_Modele.Size = New System.Drawing.Size(121, 21)
        Me.I_Modele.TabIndex = 10
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(6, 180)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(65, 13)
        Me.Label5.TabIndex = 8
        Me.Label5.Tag = ""
        Me.Label5.Text = "Desc courte"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(6, 49)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(66, 13)
        Me.Label4.TabIndex = 7
        Me.Label4.Text = "Sous Famille" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(6, 24)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(39, 13)
        Me.Label3.TabIndex = 6
        Me.Label3.Text = "Famille"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.Label18)
        Me.GroupBox2.Controls.Add(Me.Label1)
        Me.GroupBox2.Controls.Add(Me.I_Ref_Fournisseur)
        Me.GroupBox2.Controls.Add(Me.I_Reference)
        Me.GroupBox2.Controls.Add(Me.Label17)
        Me.GroupBox2.Location = New System.Drawing.Point(12, 12)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(200, 105)
        Me.GroupBox2.TabIndex = 0
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Critère unique"
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(6, 77)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(78, 13)
        Me.Label18.TabIndex = 3
        Me.Label18.Text = "Réf fournisseur"
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
        'I_Ref_Fournisseur
        '
        Me.I_Ref_Fournisseur.Location = New System.Drawing.Point(94, 77)
        Me.I_Ref_Fournisseur.Name = "I_Ref_Fournisseur"
        Me.I_Ref_Fournisseur.Size = New System.Drawing.Size(100, 20)
        Me.I_Ref_Fournisseur.TabIndex = 1
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.Location = New System.Drawing.Point(66, 53)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(23, 13)
        Me.Label17.TabIndex = 6
        Me.Label17.Text = "Ou"
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
        Me.StatusStrip.Location = New System.Drawing.Point(0, 660)
        Me.StatusStrip.Name = "StatusStrip"
        Me.StatusStrip.Size = New System.Drawing.Size(1370, 22)
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
        Me.BT_Go.Location = New System.Drawing.Point(914, 60)
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
        Me.BT_Fermer.Location = New System.Drawing.Point(914, 21)
        Me.BT_Fermer.Name = "BT_Fermer"
        Me.BT_Fermer.Size = New System.Drawing.Size(82, 25)
        Me.BT_Fermer.TabIndex = 10
        Me.BT_Fermer.Text = "Fermer"
        Me.BT_Fermer.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.BT_Fermer.UseVisualStyleBackColor = True
        '
        'BT_Nouvel_Article
        '
        Me.BT_Nouvel_Article.Image = Global.CLI.My.Resources.Resources.DataContainer_NewRecordHS
        Me.BT_Nouvel_Article.Location = New System.Drawing.Point(914, 180)
        Me.BT_Nouvel_Article.Name = "BT_Nouvel_Article"
        Me.BT_Nouvel_Article.Size = New System.Drawing.Size(99, 23)
        Me.BT_Nouvel_Article.TabIndex = 9
        Me.BT_Nouvel_Article.Text = "Nouvel article"
        Me.BT_Nouvel_Article.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.BT_Nouvel_Article.UseVisualStyleBackColor = True
        '
        'BT_Impression
        '
        Me.BT_Impression.Image = Global.CLI.My.Resources.Resources.PrintHS
        Me.BT_Impression.Location = New System.Drawing.Point(21, 343)
        Me.BT_Impression.Name = "BT_Impression"
        Me.BT_Impression.Size = New System.Drawing.Size(78, 23)
        Me.BT_Impression.TabIndex = 7
        Me.BT_Impression.Text = "Imprimer"
        Me.BT_Impression.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.BT_Impression.UseVisualStyleBackColor = True
        '
        'BT_RAZ
        '
        Me.BT_RAZ.Image = Global.CLI.My.Resources.Resources.Edit_UndoHS
        Me.BT_RAZ.Location = New System.Drawing.Point(914, 94)
        Me.BT_RAZ.Name = "BT_RAZ"
        Me.BT_RAZ.Size = New System.Drawing.Size(61, 23)
        Me.BT_RAZ.TabIndex = 7
        Me.BT_RAZ.Text = "RAZ"
        Me.BT_RAZ.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.BT_RAZ.UseVisualStyleBackColor = True
        '
        'I_TotalStockHT
        '
        Me.I_TotalStockHT.Location = New System.Drawing.Point(993, 343)
        Me.I_TotalStockHT.Name = "I_TotalStockHT"
        Me.I_TotalStockHT.ReadOnly = True
        Me.I_TotalStockHT.Size = New System.Drawing.Size(83, 20)
        Me.I_TotalStockHT.TabIndex = 11
        Me.I_TotalStockHT.Visible = False
        '
        'IL_TotalStockHT
        '
        Me.IL_TotalStockHT.AutoSize = True
        Me.IL_TotalStockHT.Location = New System.Drawing.Point(910, 346)
        Me.IL_TotalStockHT.Name = "IL_TotalStockHT"
        Me.IL_TotalStockHT.Size = New System.Drawing.Size(80, 13)
        Me.IL_TotalStockHT.TabIndex = 12
        Me.IL_TotalStockHT.Text = "Total Stock HT"
        Me.IL_TotalStockHT.Visible = False
        '
        'BT_Email
        '
        Me.BT_Email.Image = Global.CLI.My.Resources.Resources.EnvelopeHS
        Me.BT_Email.Location = New System.Drawing.Point(105, 343)
        Me.BT_Email.Name = "BT_Email"
        Me.BT_Email.Size = New System.Drawing.Size(78, 23)
        Me.BT_Email.TabIndex = 7
        Me.BT_Email.Text = "Email"
        Me.BT_Email.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.BT_Email.UseVisualStyleBackColor = True
        '
        'V_Recherche_ArticleTableAdapter
        '
        Me.V_Recherche_ArticleTableAdapter.ClearBeforeFill = True
        '
        'Label31
        '
        Me.Label31.AutoSize = True
        Me.Label31.Location = New System.Drawing.Point(247, 102)
        Me.Label31.Name = "Label31"
        Me.Label31.Size = New System.Drawing.Size(60, 13)
        Me.Label31.TabIndex = 33
        Me.Label31.Text = "Programme"
        '
        'I_Programme
        '
        Me.I_Programme.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.I_Programme.FormattingEnabled = True
        Me.I_Programme.Location = New System.Drawing.Point(313, 96)
        Me.I_Programme.Name = "I_Programme"
        Me.I_Programme.Size = New System.Drawing.Size(121, 21)
        Me.I_Programme.TabIndex = 34
        '
        'FormArticleRecherche
        '
        Me.AcceptButton = Me.BT_Go
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.BT_Fermer
        Me.ClientSize = New System.Drawing.Size(1370, 682)
        Me.Controls.Add(Me.StatusStrip)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.I_TotalStockHT)
        Me.Controls.Add(Me.BT_Fermer)
        Me.Controls.Add(Me.BT_Impression)
        Me.Controls.Add(Me.BT_Nouvel_Article)
        Me.Controls.Add(Me.BT_Email)
        Me.Controls.Add(Me.BT_RAZ)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.DGview)
        Me.Controls.Add(Me.BT_Go)
        Me.Controls.Add(Me.IL_TotalStockHT)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "FormArticleRecherche"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Rechercher un article"
        CType(Me.DGview, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ContextMenuStripRecherche.ResumeLayout(False)
        CType(Me.V_Recherche_ArticleBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CLIDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.StatusStrip.ResumeLayout(False)
        Me.StatusStrip.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents CLIDataSet As CLI.CLIDataSet
    Friend WithEvents V_Recherche_ArticleBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents V_Recherche_ArticleTableAdapter As CLI.CLIDataSetTableAdapters.V_Recherche_ArticleTableAdapter
    Friend WithEvents DGview As System.Windows.Forms.DataGridView
    Friend WithEvents I_Reference As System.Windows.Forms.TextBox
    Friend WithEvents I_Famille As System.Windows.Forms.ComboBox
    Friend WithEvents I_SousFamille As System.Windows.Forms.ComboBox
    Friend WithEvents I_Description As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents BT_Go As System.Windows.Forms.Button
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents I_Marque As System.Windows.Forms.ComboBox
    Friend WithEvents I_Annee As System.Windows.Forms.TextBox
    Friend WithEvents I_Modele As System.Windows.Forms.ComboBox
    Friend WithEvents ToolTip As System.Windows.Forms.ToolTip
    Friend WithEvents BT_RAZ As System.Windows.Forms.Button
    Friend WithEvents StatusStrip As System.Windows.Forms.StatusStrip
    Friend WithEvents ToolStripStatusLabelNbEnregistrements As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents I_Active As System.Windows.Forms.ComboBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents I_Magasin As System.Windows.Forms.ComboBox
    Friend WithEvents I_Web As System.Windows.Forms.ComboBox
    Friend WithEvents ContextMenuStripRecherche As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents StockToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents InventaireToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MouvementToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents BT_Nouvel_Article As System.Windows.Forms.Button
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents I_Depot As System.Windows.Forms.ComboBox
    Friend WithEvents I_Occaz As System.Windows.Forms.ComboBox
    Friend WithEvents BT_Fermer As System.Windows.Forms.Button
    Friend WithEvents I_StockMax As System.Windows.Forms.TextBox
    Friend WithEvents I_StockMin As System.Windows.Forms.TextBox
    Friend WithEvents I_Fournisseur As System.Windows.Forms.ComboBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents I_Ref_Fournisseur As System.Windows.Forms.TextBox
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents BT_Impression As System.Windows.Forms.Button
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents I_RepriseDepot As System.Windows.Forms.ComboBox
    Friend WithEvents CopieDarticlecompletToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EtatToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MagasinonToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents WebonToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ActiveonToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PrecommandeToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents RéapproToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents StockLimiteToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SurCommandeToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ActiverToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DeasctiverToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ActiverToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DésactiverToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ActiverToolStripMenuItem2 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DésactiverToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ActiverToolStripMenuItem3 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DésactiverToolStripMenuItem2 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ActiverToolStripMenuItem4 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DésactiverToolStripMenuItem3 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ActioverToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DésactiverToolStripMenuItem4 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ActiverToolStripMenuItem5 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DésactiverToolStripMenuItem5 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents I_ClientMax As System.Windows.Forms.TextBox
    Friend WithEvents I_ClientMin As System.Windows.Forms.TextBox
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents I_creeMax As System.Windows.Forms.TextBox
    Friend WithEvents I_CreeMin As System.Windows.Forms.TextBox
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents I_TotalStockHT As System.Windows.Forms.TextBox
    Friend WithEvents IL_TotalStockHT As System.Windows.Forms.Label
    Friend WithEvents BT_Email As System.Windows.Forms.Button
    Friend WithEvents CodeBarreToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AvecPrixToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SansPrixToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents I_test As System.Windows.Forms.ComboBox
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents I_Type As System.Windows.Forms.ComboBox
    Friend WithEvents I_CreePar As TextBox
    Friend WithEvents Label26 As Label
    Friend WithEvents Label27 As Label
    Friend WithEvents I_Promo As ComboBox
    Friend WithEvents CréationRepriseToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents CréationDépotVenteToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents I_SynchroPrestashop As ComboBox
    Friend WithEvents IL_SynchroPS As Label
    Friend WithEvents Label30 As Label
    Friend WithEvents I_Type4 As ComboBox
    Friend WithEvents Label29 As Label
    Friend WithEvents I_Type3 As ComboBox
    Friend WithEvents Label28 As Label
    Friend WithEvents I_Type2 As ComboBox
    Friend WithEvents Active_on As DataGridViewCheckBoxColumn
    Friend WithEvents ref As DataGridViewTextBoxColumn
    Friend WithEvents DescriptionCourte As DataGridViewTextBoxColumn
    Friend WithEvents surface As DataGridViewTextBoxColumn
    Friend WithEvents volume As DataGridViewTextBoxColumn
    Friend WithEvents taille As DataGridViewTextBoxColumn
    Friend WithEvents Libelle As DataGridViewTextBoxColumn
    Friend WithEvents prix_vente_initial_TTC As DataGridViewTextBoxColumn
    Friend WithEvents remise As DataGridViewTextBoxColumn
    Friend WithEvents prix_vente_remise_TTC As DataGridViewTextBoxColumn
    Friend WithEvents Stock As DataGridViewTextBoxColumn
    Friend WithEvents prix_fournisseur As DataGridViewTextBoxColumn
    Friend WithEvents remise_fournisseur As DataGridViewTextBoxColumn
    Friend WithEvents prix_remise_fournisseur As DataGridViewTextBoxColumn
    Friend WithEvents ID_T_Client As DataGridViewTextBoxColumn
    Friend WithEvents ID_T_Fournisseur As DataGridViewTextBoxColumn
    Friend WithEvents web_on As DataGridViewCheckBoxColumn
    Friend WithEvents magasin_on As DataGridViewCheckBoxColumn
    Friend WithEvents surcommande As DataGridViewCheckBoxColumn
    Friend WithEvents precommande As DataGridViewCheckBoxColumn
    Friend WithEvents TotalStockHT As DataGridViewTextBoxColumn
    Friend WithEvents creele As DataGridViewTextBoxColumn
    Friend WithEvents Code_port As DataGridViewTextBoxColumn
    Friend WithEvents code_tva As DataGridViewTextBoxColumn
    Friend WithEvents EtatSynchroPrestashop As DataGridViewTextBoxColumn
    Friend WithEvents I_Programme As ComboBox
    Friend WithEvents Label31 As Label
End Class
