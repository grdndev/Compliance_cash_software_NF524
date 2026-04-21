<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormCommandeRecherche
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
        Me.components = New System.ComponentModel.Container()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormCommandeRecherche))
        Me.DGview = New System.Windows.Forms.DataGridView()
        Me.RefCommande = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewCheckBoxColumn1 = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.EtatCommandeDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TotalDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DateCommandeDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.VendeurDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.RefClientDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SociétéDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.NomDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PrénomDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CodePostal = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Ville = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Pays = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DateFactureDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DateExpeditionDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.WebDataGridViewCheckBoxColumn = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.CodeEtat = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.numcaisse = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ReferencePrestashop = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PanierPrestashop = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SynchroPrestashop = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.VRechercheCommandeBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.CLIDataSet = New CLI.CLIDataSet()
        Me.I_Reference = New System.Windows.Forms.TextBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.I_SynchroPrestashop = New System.Windows.Forms.ComboBox()
        Me.IL_SynchroPS = New System.Windows.Forms.Label()
        Me.I_NumCaisse = New System.Windows.Forms.ComboBox()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.I_Encaisse = New System.Windows.Forms.ComboBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.I_Web = New System.Windows.Forms.ComboBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.I_Date_expedition_fin = New System.Windows.Forms.TextBox()
        Me.I_Date_facture_fin = New System.Windows.Forms.TextBox()
        Me.I_Date_commande_fin = New System.Windows.Forms.TextBox()
        Me.I_Date_expedition_debut = New System.Windows.Forms.TextBox()
        Me.I_Date_facture_debut = New System.Windows.Forms.TextBox()
        Me.I_Date_commande_debut = New System.Windows.Forms.TextBox()
        Me.I_Vendeur = New System.Windows.Forms.ComboBox()
        Me.I_Pays = New System.Windows.Forms.ComboBox()
        Me.VilleTextBox = New System.Windows.Forms.TextBox()
        Me.I_Nom = New System.Windows.Forms.TextBox()
        Me.I_Societe = New System.Windows.Forms.TextBox()
        Me.CodePostalTextBox = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.I_etat_max = New System.Windows.Forms.ComboBox()
        Me.TEtatCommandeVenteMaxBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.I_Etat_min = New System.Windows.Forms.ComboBox()
        Me.TEtatCommandeVenteMinBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label_Ville = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.I_Ref_Client = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.ToolTip = New System.Windows.Forms.ToolTip(Me.components)
        Me.StatusStrip = New System.Windows.Forms.StatusStrip()
        Me.ToolStripStatusLabelNbEnregistrements = New System.Windows.Forms.ToolStripStatusLabel()
        Me.BT_Go = New System.Windows.Forms.Button()
        Me.BT_Nouveau = New System.Windows.Forms.Button()
        Me.BT_RAZ = New System.Windows.Forms.Button()
        Me.BT_Fermer = New System.Windows.Forms.Button()
        Me.Ref = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.RefCommandeDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.V_Recherche_ArticleBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.V_Recherche_ArticleTableAdapter = New CLI.CLIDataSetTableAdapters.V_Recherche_ArticleTableAdapter()
        Me.V_Recherche_Commande_VenteTableAdapter = New CLI.CLIDataSetTableAdapters.V_Recherche_Commande_VenteTableAdapter()
        Me.T_EtatCommandeVenteTableAdapter = New CLI.CLIDataSetTableAdapters.T_EtatCommandeVenteTableAdapter()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.I_ReferencePrestashop = New System.Windows.Forms.TextBox()
        Me.Label23 = New System.Windows.Forms.Label()
        CType(Me.DGview, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.VRechercheCommandeBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CLIDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        CType(Me.TEtatCommandeVenteMaxBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TEtatCommandeVenteMinBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.DGview.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.RefCommande, Me.DataGridViewCheckBoxColumn1, Me.EtatCommandeDataGridViewTextBoxColumn, Me.TotalDataGridViewTextBoxColumn, Me.DateCommandeDataGridViewTextBoxColumn, Me.VendeurDataGridViewTextBoxColumn, Me.RefClientDataGridViewTextBoxColumn, Me.SociétéDataGridViewTextBoxColumn, Me.NomDataGridViewTextBoxColumn, Me.PrénomDataGridViewTextBoxColumn, Me.CodePostal, Me.Ville, Me.Pays, Me.DateFactureDataGridViewTextBoxColumn, Me.DateExpeditionDataGridViewTextBoxColumn, Me.WebDataGridViewCheckBoxColumn, Me.CodeEtat, Me.numcaisse, Me.ReferencePrestashop, Me.PanierPrestashop, Me.SynchroPrestashop})
        Me.DGview.DataSource = Me.VRechercheCommandeBindingSource
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DGview.DefaultCellStyle = DataGridViewCellStyle4
        Me.DGview.Location = New System.Drawing.Point(4, 352)
        Me.DGview.MultiSelect = False
        Me.DGview.Name = "DGview"
        Me.DGview.ReadOnly = True
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DGview.RowHeadersDefaultCellStyle = DataGridViewCellStyle5
        Me.DGview.RowHeadersVisible = False
        Me.DGview.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DGview.Size = New System.Drawing.Size(1788, 360)
        Me.DGview.TabIndex = 3
        '
        'RefCommande
        '
        Me.RefCommande.DataPropertyName = "Ref commande"
        Me.RefCommande.HeaderText = "Ref commande"
        Me.RefCommande.Name = "RefCommande"
        Me.RefCommande.ReadOnly = True
        Me.RefCommande.Width = 104
        '
        'DataGridViewCheckBoxColumn1
        '
        Me.DataGridViewCheckBoxColumn1.DataPropertyName = "Encaissé ?"
        Me.DataGridViewCheckBoxColumn1.HeaderText = "Encaissé ?"
        Me.DataGridViewCheckBoxColumn1.Name = "DataGridViewCheckBoxColumn1"
        Me.DataGridViewCheckBoxColumn1.ReadOnly = True
        Me.DataGridViewCheckBoxColumn1.Width = 65
        '
        'EtatCommandeDataGridViewTextBoxColumn
        '
        Me.EtatCommandeDataGridViewTextBoxColumn.DataPropertyName = "Etat Commande"
        Me.EtatCommandeDataGridViewTextBoxColumn.HeaderText = "Etat Commande"
        Me.EtatCommandeDataGridViewTextBoxColumn.Name = "EtatCommandeDataGridViewTextBoxColumn"
        Me.EtatCommandeDataGridViewTextBoxColumn.ReadOnly = True
        Me.EtatCommandeDataGridViewTextBoxColumn.Width = 107
        '
        'TotalDataGridViewTextBoxColumn
        '
        Me.TotalDataGridViewTextBoxColumn.DataPropertyName = "Total"
        DataGridViewCellStyle3.Format = "C2"
        DataGridViewCellStyle3.NullValue = "0.00 €"
        Me.TotalDataGridViewTextBoxColumn.DefaultCellStyle = DataGridViewCellStyle3
        Me.TotalDataGridViewTextBoxColumn.HeaderText = "Total"
        Me.TotalDataGridViewTextBoxColumn.Name = "TotalDataGridViewTextBoxColumn"
        Me.TotalDataGridViewTextBoxColumn.ReadOnly = True
        Me.TotalDataGridViewTextBoxColumn.Width = 56
        '
        'DateCommandeDataGridViewTextBoxColumn
        '
        Me.DateCommandeDataGridViewTextBoxColumn.DataPropertyName = "Date commande"
        Me.DateCommandeDataGridViewTextBoxColumn.HeaderText = "Date commande"
        Me.DateCommandeDataGridViewTextBoxColumn.Name = "DateCommandeDataGridViewTextBoxColumn"
        Me.DateCommandeDataGridViewTextBoxColumn.ReadOnly = True
        Me.DateCommandeDataGridViewTextBoxColumn.Width = 110
        '
        'VendeurDataGridViewTextBoxColumn
        '
        Me.VendeurDataGridViewTextBoxColumn.DataPropertyName = "Vendeur"
        Me.VendeurDataGridViewTextBoxColumn.HeaderText = "Vendeur"
        Me.VendeurDataGridViewTextBoxColumn.Name = "VendeurDataGridViewTextBoxColumn"
        Me.VendeurDataGridViewTextBoxColumn.ReadOnly = True
        Me.VendeurDataGridViewTextBoxColumn.Width = 72
        '
        'RefClientDataGridViewTextBoxColumn
        '
        Me.RefClientDataGridViewTextBoxColumn.DataPropertyName = "Ref client"
        Me.RefClientDataGridViewTextBoxColumn.HeaderText = "Ref client"
        Me.RefClientDataGridViewTextBoxColumn.Name = "RefClientDataGridViewTextBoxColumn"
        Me.RefClientDataGridViewTextBoxColumn.ReadOnly = True
        Me.RefClientDataGridViewTextBoxColumn.Width = 77
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
        'PrénomDataGridViewTextBoxColumn
        '
        Me.PrénomDataGridViewTextBoxColumn.DataPropertyName = "Prénom"
        Me.PrénomDataGridViewTextBoxColumn.HeaderText = "Prénom"
        Me.PrénomDataGridViewTextBoxColumn.Name = "PrénomDataGridViewTextBoxColumn"
        Me.PrénomDataGridViewTextBoxColumn.ReadOnly = True
        Me.PrénomDataGridViewTextBoxColumn.Width = 68
        '
        'CodePostal
        '
        Me.CodePostal.DataPropertyName = "CodePostal"
        Me.CodePostal.HeaderText = "CodePostal"
        Me.CodePostal.Name = "CodePostal"
        Me.CodePostal.ReadOnly = True
        Me.CodePostal.Width = 86
        '
        'Ville
        '
        Me.Ville.DataPropertyName = "Ville"
        Me.Ville.HeaderText = "Ville"
        Me.Ville.Name = "Ville"
        Me.Ville.ReadOnly = True
        Me.Ville.Width = 51
        '
        'Pays
        '
        Me.Pays.DataPropertyName = "Pays"
        Me.Pays.HeaderText = "Pays"
        Me.Pays.Name = "Pays"
        Me.Pays.ReadOnly = True
        Me.Pays.Width = 55
        '
        'DateFactureDataGridViewTextBoxColumn
        '
        Me.DateFactureDataGridViewTextBoxColumn.DataPropertyName = "Date facture"
        Me.DateFactureDataGridViewTextBoxColumn.HeaderText = "Date facture"
        Me.DateFactureDataGridViewTextBoxColumn.Name = "DateFactureDataGridViewTextBoxColumn"
        Me.DateFactureDataGridViewTextBoxColumn.ReadOnly = True
        Me.DateFactureDataGridViewTextBoxColumn.Width = 91
        '
        'DateExpeditionDataGridViewTextBoxColumn
        '
        Me.DateExpeditionDataGridViewTextBoxColumn.DataPropertyName = "Date Expedition"
        Me.DateExpeditionDataGridViewTextBoxColumn.HeaderText = "Date Expedition"
        Me.DateExpeditionDataGridViewTextBoxColumn.Name = "DateExpeditionDataGridViewTextBoxColumn"
        Me.DateExpeditionDataGridViewTextBoxColumn.ReadOnly = True
        Me.DateExpeditionDataGridViewTextBoxColumn.Width = 107
        '
        'WebDataGridViewCheckBoxColumn
        '
        Me.WebDataGridViewCheckBoxColumn.DataPropertyName = "Web ?"
        Me.WebDataGridViewCheckBoxColumn.HeaderText = "Web ?"
        Me.WebDataGridViewCheckBoxColumn.Name = "WebDataGridViewCheckBoxColumn"
        Me.WebDataGridViewCheckBoxColumn.ReadOnly = True
        Me.WebDataGridViewCheckBoxColumn.Width = 45
        '
        'CodeEtat
        '
        Me.CodeEtat.DataPropertyName = "Code etat"
        Me.CodeEtat.HeaderText = "Code etat"
        Me.CodeEtat.Name = "CodeEtat"
        Me.CodeEtat.ReadOnly = True
        Me.CodeEtat.Visible = False
        Me.CodeEtat.Width = 78
        '
        'numcaisse
        '
        Me.numcaisse.DataPropertyName = "numcaisse"
        Me.numcaisse.HeaderText = "Caisse"
        Me.numcaisse.Name = "numcaisse"
        Me.numcaisse.ReadOnly = True
        Me.numcaisse.Width = 63
        '
        'ReferencePrestashop
        '
        Me.ReferencePrestashop.DataPropertyName = "ReferenceCommandePrestashop"
        Me.ReferencePrestashop.HeaderText = "Reference Prestashop"
        Me.ReferencePrestashop.Name = "ReferencePrestashop"
        Me.ReferencePrestashop.ReadOnly = True
        Me.ReferencePrestashop.Width = 138
        '
        'PanierPrestashop
        '
        Me.PanierPrestashop.DataPropertyName = "PanierPrestashop"
        Me.PanierPrestashop.HeaderText = "Panier Prestashop"
        Me.PanierPrestashop.Name = "PanierPrestashop"
        Me.PanierPrestashop.ReadOnly = True
        Me.PanierPrestashop.Width = 118
        '
        'SynchroPrestashop
        '
        Me.SynchroPrestashop.DataPropertyName = "SynchroPrestashop"
        Me.SynchroPrestashop.HeaderText = "SynchroPrestashop"
        Me.SynchroPrestashop.Name = "SynchroPrestashop"
        Me.SynchroPrestashop.ReadOnly = True
        Me.SynchroPrestashop.Width = 124
        '
        'VRechercheCommandeBindingSource
        '
        Me.VRechercheCommandeBindingSource.DataMember = "V_Recherche_Commande_Vente"
        Me.VRechercheCommandeBindingSource.DataSource = Me.CLIDataSet
        '
        'CLIDataSet
        '
        Me.CLIDataSet.DataSetName = "CLIDataSet"
        Me.CLIDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'I_Reference
        '
        Me.I_Reference.Location = New System.Drawing.Point(91, 24)
        Me.I_Reference.Name = "I_Reference"
        Me.I_Reference.Size = New System.Drawing.Size(100, 20)
        Me.I_Reference.TabIndex = 0
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.I_SynchroPrestashop)
        Me.GroupBox1.Controls.Add(Me.IL_SynchroPS)
        Me.GroupBox1.Controls.Add(Me.I_NumCaisse)
        Me.GroupBox1.Controls.Add(Me.Label21)
        Me.GroupBox1.Controls.Add(Me.Label20)
        Me.GroupBox1.Controls.Add(Me.I_Encaisse)
        Me.GroupBox1.Controls.Add(Me.Label16)
        Me.GroupBox1.Controls.Add(Me.I_Web)
        Me.GroupBox1.Controls.Add(Me.Label14)
        Me.GroupBox1.Controls.Add(Me.Label12)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.I_Date_expedition_fin)
        Me.GroupBox1.Controls.Add(Me.I_Date_facture_fin)
        Me.GroupBox1.Controls.Add(Me.I_Date_commande_fin)
        Me.GroupBox1.Controls.Add(Me.I_Date_expedition_debut)
        Me.GroupBox1.Controls.Add(Me.I_Date_facture_debut)
        Me.GroupBox1.Controls.Add(Me.I_Date_commande_debut)
        Me.GroupBox1.Controls.Add(Me.I_Vendeur)
        Me.GroupBox1.Controls.Add(Me.I_Pays)
        Me.GroupBox1.Controls.Add(Me.VilleTextBox)
        Me.GroupBox1.Controls.Add(Me.I_Nom)
        Me.GroupBox1.Controls.Add(Me.I_Societe)
        Me.GroupBox1.Controls.Add(Me.CodePostalTextBox)
        Me.GroupBox1.Controls.Add(Me.Label9)
        Me.GroupBox1.Controls.Add(Me.I_etat_max)
        Me.GroupBox1.Controls.Add(Me.I_Etat_min)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.Label15)
        Me.GroupBox1.Controls.Add(Me.Label19)
        Me.GroupBox1.Controls.Add(Me.Label13)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.Label18)
        Me.GroupBox1.Controls.Add(Me.Label11)
        Me.GroupBox1.Controls.Add(Me.Label_Ville)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Location = New System.Drawing.Point(291, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(432, 334)
        Me.GroupBox1.TabIndex = 1
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Multi-critère"
        '
        'I_SynchroPrestashop
        '
        Me.I_SynchroPrestashop.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.I_SynchroPrestashop.FormattingEnabled = True
        Me.I_SynchroPrestashop.Items.AddRange(New Object() {"<Tous>", "Ok", "Erreur", "Non"})
        Me.I_SynchroPrestashop.Location = New System.Drawing.Point(238, 274)
        Me.I_SynchroPrestashop.Name = "I_SynchroPrestashop"
        Me.I_SynchroPrestashop.Size = New System.Drawing.Size(121, 21)
        Me.I_SynchroPrestashop.TabIndex = 27
        '
        'IL_SynchroPS
        '
        Me.IL_SynchroPS.AutoSize = True
        Me.IL_SynchroPS.Location = New System.Drawing.Point(238, 257)
        Me.IL_SynchroPS.Name = "IL_SynchroPS"
        Me.IL_SynchroPS.Size = New System.Drawing.Size(122, 13)
        Me.IL_SynchroPS.TabIndex = 26
        Me.IL_SynchroPS.Text = "Etat synchro Prestashop"
        '
        'I_NumCaisse
        '
        Me.I_NumCaisse.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.I_NumCaisse.FormattingEnabled = True
        Me.I_NumCaisse.Items.AddRange(New Object() {"<Tout>", "1", "2"})
        Me.I_NumCaisse.Location = New System.Drawing.Point(102, 237)
        Me.I_NumCaisse.Name = "I_NumCaisse"
        Me.I_NumCaisse.Size = New System.Drawing.Size(98, 21)
        Me.I_NumCaisse.TabIndex = 25
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Location = New System.Drawing.Point(6, 240)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(38, 13)
        Me.Label21.TabIndex = 24
        Me.Label21.Text = "Caisse"
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Location = New System.Drawing.Point(8, 270)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(59, 13)
        Me.Label20.TabIndex = 23
        Me.Label20.Text = "Encaissé ?"
        '
        'I_Encaisse
        '
        Me.I_Encaisse.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.I_Encaisse.FormattingEnabled = True
        Me.I_Encaisse.Items.AddRange(New Object() {"<Tous>", "Oui", "Non"})
        Me.I_Encaisse.Location = New System.Drawing.Point(102, 267)
        Me.I_Encaisse.Name = "I_Encaisse"
        Me.I_Encaisse.Size = New System.Drawing.Size(70, 21)
        Me.I_Encaisse.TabIndex = 12
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(233, 212)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(39, 13)
        Me.Label16.TabIndex = 23
        Me.Label16.Text = "Web ?"
        '
        'I_Web
        '
        Me.I_Web.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.I_Web.FormattingEnabled = True
        Me.I_Web.Items.AddRange(New Object() {"<Tous>", "Oui", "Non"})
        Me.I_Web.Location = New System.Drawing.Point(287, 209)
        Me.I_Web.Name = "I_Web"
        Me.I_Web.Size = New System.Drawing.Size(70, 21)
        Me.I_Web.TabIndex = 12
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(4, 177)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(81, 13)
        Me.Label14.TabIndex = 21
        Me.Label14.Text = "Date expédition"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(4, 142)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(66, 13)
        Me.Label12.TabIndex = 21
        Me.Label12.Text = "Date facture"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(4, 110)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(85, 13)
        Me.Label3.TabIndex = 21
        Me.Label3.Text = "Date commande"
        '
        'I_Date_expedition_fin
        '
        Me.I_Date_expedition_fin.Location = New System.Drawing.Point(287, 174)
        Me.I_Date_expedition_fin.Name = "I_Date_expedition_fin"
        Me.I_Date_expedition_fin.Size = New System.Drawing.Size(100, 20)
        Me.I_Date_expedition_fin.TabIndex = 10
        '
        'I_Date_facture_fin
        '
        Me.I_Date_facture_fin.Location = New System.Drawing.Point(287, 139)
        Me.I_Date_facture_fin.Name = "I_Date_facture_fin"
        Me.I_Date_facture_fin.Size = New System.Drawing.Size(100, 20)
        Me.I_Date_facture_fin.TabIndex = 8
        '
        'I_Date_commande_fin
        '
        Me.I_Date_commande_fin.Location = New System.Drawing.Point(287, 105)
        Me.I_Date_commande_fin.Name = "I_Date_commande_fin"
        Me.I_Date_commande_fin.Size = New System.Drawing.Size(100, 20)
        Me.I_Date_commande_fin.TabIndex = 6
        '
        'I_Date_expedition_debut
        '
        Me.I_Date_expedition_debut.Location = New System.Drawing.Point(102, 174)
        Me.I_Date_expedition_debut.Name = "I_Date_expedition_debut"
        Me.I_Date_expedition_debut.Size = New System.Drawing.Size(100, 20)
        Me.I_Date_expedition_debut.TabIndex = 9
        '
        'I_Date_facture_debut
        '
        Me.I_Date_facture_debut.Location = New System.Drawing.Point(102, 139)
        Me.I_Date_facture_debut.Name = "I_Date_facture_debut"
        Me.I_Date_facture_debut.Size = New System.Drawing.Size(100, 20)
        Me.I_Date_facture_debut.TabIndex = 7
        '
        'I_Date_commande_debut
        '
        Me.I_Date_commande_debut.Location = New System.Drawing.Point(102, 107)
        Me.I_Date_commande_debut.Name = "I_Date_commande_debut"
        Me.I_Date_commande_debut.Size = New System.Drawing.Size(100, 20)
        Me.I_Date_commande_debut.TabIndex = 5
        '
        'I_Vendeur
        '
        Me.I_Vendeur.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.I_Vendeur.FormattingEnabled = True
        Me.I_Vendeur.Location = New System.Drawing.Point(102, 209)
        Me.I_Vendeur.Name = "I_Vendeur"
        Me.I_Vendeur.Size = New System.Drawing.Size(98, 21)
        Me.I_Vendeur.TabIndex = 11
        '
        'I_Pays
        '
        Me.I_Pays.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.I_Pays.FormattingEnabled = True
        Me.I_Pays.Location = New System.Drawing.Point(102, 78)
        Me.I_Pays.Name = "I_Pays"
        Me.I_Pays.Size = New System.Drawing.Size(98, 21)
        Me.I_Pays.TabIndex = 4
        '
        'VilleTextBox
        '
        Me.VilleTextBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource
        Me.VilleTextBox.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.VilleTextBox.Location = New System.Drawing.Point(289, 50)
        Me.VilleTextBox.Name = "VilleTextBox"
        Me.VilleTextBox.Size = New System.Drawing.Size(137, 20)
        Me.VilleTextBox.TabIndex = 3
        '
        'I_Nom
        '
        Me.I_Nom.Location = New System.Drawing.Point(289, 20)
        Me.I_Nom.Name = "I_Nom"
        Me.I_Nom.Size = New System.Drawing.Size(137, 20)
        Me.I_Nom.TabIndex = 1
        '
        'I_Societe
        '
        Me.I_Societe.Location = New System.Drawing.Point(102, 19)
        Me.I_Societe.Name = "I_Societe"
        Me.I_Societe.Size = New System.Drawing.Size(98, 20)
        Me.I_Societe.TabIndex = 0
        '
        'CodePostalTextBox
        '
        Me.CodePostalTextBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource
        Me.CodePostalTextBox.Location = New System.Drawing.Point(102, 47)
        Me.CodePostalTextBox.Name = "CodePostalTextBox"
        Me.CodePostalTextBox.Size = New System.Drawing.Size(98, 20)
        Me.CodePostalTextBox.TabIndex = 2
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(6, 293)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(35, 13)
        Me.Label9.TabIndex = 17
        Me.Label9.Text = "Etat ?"
        '
        'I_etat_max
        '
        Me.I_etat_max.DataSource = Me.TEtatCommandeVenteMaxBindingSource
        Me.I_etat_max.DisplayMember = "Libelle"
        Me.I_etat_max.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.I_etat_max.FormattingEnabled = True
        Me.I_etat_max.Location = New System.Drawing.Point(233, 309)
        Me.I_etat_max.Name = "I_etat_max"
        Me.I_etat_max.Size = New System.Drawing.Size(190, 21)
        Me.I_etat_max.TabIndex = 14
        Me.I_etat_max.ValueMember = "ID_T_EtatCommandeVente"
        '
        'TEtatCommandeVenteMaxBindingSource
        '
        Me.TEtatCommandeVenteMaxBindingSource.DataMember = "T_EtatCommandeVente"
        Me.TEtatCommandeVenteMaxBindingSource.DataSource = Me.CLIDataSet
        '
        'I_Etat_min
        '
        Me.I_Etat_min.DataSource = Me.TEtatCommandeVenteMinBindingSource
        Me.I_Etat_min.DisplayMember = "Libelle"
        Me.I_Etat_min.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.I_Etat_min.FormattingEnabled = True
        Me.I_Etat_min.Location = New System.Drawing.Point(9, 309)
        Me.I_Etat_min.Name = "I_Etat_min"
        Me.I_Etat_min.Size = New System.Drawing.Size(190, 21)
        Me.I_Etat_min.TabIndex = 13
        Me.I_Etat_min.ValueMember = "ID_T_EtatCommandeVente"
        '
        'TEtatCommandeVenteMinBindingSource
        '
        Me.TEtatCommandeVenteMinBindingSource.DataMember = "T_EtatCommandeVente"
        Me.TEtatCommandeVenteMinBindingSource.DataSource = Me.CLIDataSet
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(6, 49)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(0, 13)
        Me.Label4.TabIndex = 7
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(6, 212)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(47, 13)
        Me.Label15.TabIndex = 6
        Me.Label15.Text = "Vendeur"
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(209, 312)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(13, 13)
        Me.Label19.TabIndex = 6
        Me.Label19.Text = "à"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(238, 179)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(13, 13)
        Me.Label13.TabIndex = 6
        Me.Label13.Text = "à"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(6, 81)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(30, 13)
        Me.Label7.TabIndex = 6
        Me.Label7.Text = "Pays"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(238, 144)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(13, 13)
        Me.Label6.TabIndex = 6
        Me.Label6.Text = "à"
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(225, 50)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(26, 13)
        Me.Label18.TabIndex = 6
        Me.Label18.Text = "Ville"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(222, 22)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(29, 13)
        Me.Label11.TabIndex = 6
        Me.Label11.Text = "Nom"
        '
        'Label_Ville
        '
        Me.Label_Ville.AutoSize = True
        Me.Label_Ville.Location = New System.Drawing.Point(238, 112)
        Me.Label_Ville.Name = "Label_Ville"
        Me.Label_Ville.Size = New System.Drawing.Size(13, 13)
        Me.Label_Ville.TabIndex = 6
        Me.Label_Ville.Text = "à"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(4, 24)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(43, 13)
        Me.Label8.TabIndex = 6
        Me.Label8.Text = "Société"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(4, 52)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(64, 13)
        Me.Label5.TabIndex = 6
        Me.Label5.Text = "Code Postal"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.Label23)
        Me.GroupBox2.Controls.Add(Me.Label22)
        Me.GroupBox2.Controls.Add(Me.I_ReferencePrestashop)
        Me.GroupBox2.Controls.Add(Me.Label17)
        Me.GroupBox2.Controls.Add(Me.Label10)
        Me.GroupBox2.Controls.Add(Me.I_Ref_Client)
        Me.GroupBox2.Controls.Add(Me.Label1)
        Me.GroupBox2.Controls.Add(Me.I_Reference)
        Me.GroupBox2.Location = New System.Drawing.Point(12, 12)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(200, 159)
        Me.GroupBox2.TabIndex = 0
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Critère unique"
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.Location = New System.Drawing.Point(89, 101)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(23, 13)
        Me.Label17.TabIndex = 7
        Me.Label17.Text = "Ou"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(6, 129)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(53, 13)
        Me.Label10.TabIndex = 3
        Me.Label10.Text = "Réf Client"
        '
        'I_Ref_Client
        '
        Me.I_Ref_Client.Location = New System.Drawing.Point(91, 126)
        Me.I_Ref_Client.Name = "I_Ref_Client"
        Me.I_Ref_Client.Size = New System.Drawing.Size(100, 20)
        Me.I_Ref_Client.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(6, 27)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(79, 13)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Référence CLI "
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
        Me.StatusStrip.ImageScalingSize = New System.Drawing.Size(32, 32)
        Me.StatusStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripStatusLabelNbEnregistrements})
        Me.StatusStrip.Location = New System.Drawing.Point(0, 715)
        Me.StatusStrip.Name = "StatusStrip"
        Me.StatusStrip.Size = New System.Drawing.Size(1804, 22)
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
        'BT_Nouveau
        '
        Me.BT_Nouveau.Image = Global.CLI.My.Resources.Resources.DataContainer_NewRecordHS
        Me.BT_Nouveau.Location = New System.Drawing.Point(740, 119)
        Me.BT_Nouveau.Name = "BT_Nouveau"
        Me.BT_Nouveau.Size = New System.Drawing.Size(135, 39)
        Me.BT_Nouveau.TabIndex = 4
        Me.BT_Nouveau.Text = "Nouveau devis / commande"
        Me.BT_Nouveau.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.BT_Nouveau.UseVisualStyleBackColor = True
        '
        'BT_RAZ
        '
        Me.BT_RAZ.Image = Global.CLI.My.Resources.Resources.Edit_UndoHS
        Me.BT_RAZ.Location = New System.Drawing.Point(740, 85)
        Me.BT_RAZ.Name = "BT_RAZ"
        Me.BT_RAZ.Size = New System.Drawing.Size(61, 23)
        Me.BT_RAZ.TabIndex = 3
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
        Me.BT_Fermer.TabIndex = 5
        Me.BT_Fermer.Text = "Fermer"
        Me.BT_Fermer.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.BT_Fermer.UseVisualStyleBackColor = True
        '
        'Ref
        '
        Me.Ref.DataPropertyName = "Ref commande"
        Me.Ref.HeaderText = "Ref commande"
        Me.Ref.Name = "Ref"
        Me.Ref.Width = 49
        '
        'RefCommandeDataGridViewTextBoxColumn
        '
        Me.RefCommandeDataGridViewTextBoxColumn.DataPropertyName = "Ref commande"
        Me.RefCommandeDataGridViewTextBoxColumn.HeaderText = "Ref commande"
        Me.RefCommandeDataGridViewTextBoxColumn.Name = "RefCommandeDataGridViewTextBoxColumn"
        Me.RefCommandeDataGridViewTextBoxColumn.Width = 104
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
        'V_Recherche_Commande_VenteTableAdapter
        '
        Me.V_Recherche_Commande_VenteTableAdapter.ClearBeforeFill = True
        '
        'T_EtatCommandeVenteTableAdapter
        '
        Me.T_EtatCommandeVenteTableAdapter.ClearBeforeFill = True
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Location = New System.Drawing.Point(2, 65)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(63, 39)
        Me.Label22.TabIndex = 9
        Me.Label22.Text = "Prestashop " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "(commande" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & " ou panier)"
        '
        'I_ReferencePrestashop
        '
        Me.I_ReferencePrestashop.Location = New System.Drawing.Point(93, 65)
        Me.I_ReferencePrestashop.Name = "I_ReferencePrestashop"
        Me.I_ReferencePrestashop.Size = New System.Drawing.Size(100, 20)
        Me.I_ReferencePrestashop.TabIndex = 8
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label23.Location = New System.Drawing.Point(91, 49)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(23, 13)
        Me.Label23.TabIndex = 10
        Me.Label23.Text = "Ou"
        '
        'FormCommandeRecherche
        '
        Me.AcceptButton = Me.BT_Go
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.BT_Fermer
        Me.ClientSize = New System.Drawing.Size(1804, 737)
        Me.Controls.Add(Me.BT_Fermer)
        Me.Controls.Add(Me.StatusStrip)
        Me.Controls.Add(Me.BT_Nouveau)
        Me.Controls.Add(Me.BT_RAZ)
        Me.Controls.Add(Me.BT_Go)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.DGview)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "FormCommandeRecherche"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Rechercher une commande"
        CType(Me.DGview, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.VRechercheCommandeBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CLIDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.TEtatCommandeVenteMaxBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TEtatCommandeVenteMinBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
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
    Friend WithEvents ToolTip As System.Windows.Forms.ToolTip
    Friend WithEvents BT_RAZ As System.Windows.Forms.Button
    Friend WithEvents StatusStrip As System.Windows.Forms.StatusStrip
    Friend WithEvents ToolStripStatusLabelNbEnregistrements As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents I_Etat_min As System.Windows.Forms.ComboBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents BT_Nouveau As System.Windows.Forms.Button
    Friend WithEvents BT_Fermer As System.Windows.Forms.Button
    Friend WithEvents VRechercheCommandeBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents VilleTextBox As System.Windows.Forms.TextBox
    Friend WithEvents CodePostalTextBox As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label_Ville As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents I_Pays As System.Windows.Forms.ComboBox
    Friend WithEvents I_Societe As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents V_Recherche_Commande_VenteTableAdapter As CLI.CLIDataSetTableAdapters.V_Recherche_Commande_VenteTableAdapter
    Friend WithEvents Ref As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents RefCommandeDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents I_Ref_Client As System.Windows.Forms.TextBox
    Friend WithEvents TEtatCommandeVenteMinBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents T_EtatCommandeVenteTableAdapter As CLI.CLIDataSetTableAdapters.T_EtatCommandeVenteTableAdapter
    Friend WithEvents I_Nom As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents I_Date_commande_fin As System.Windows.Forms.TextBox
    Friend WithEvents I_Date_commande_debut As System.Windows.Forms.TextBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents I_Date_expedition_fin As System.Windows.Forms.TextBox
    Friend WithEvents I_Date_facture_fin As System.Windows.Forms.TextBox
    Friend WithEvents I_Date_expedition_debut As System.Windows.Forms.TextBox
    Friend WithEvents I_Date_facture_debut As System.Windows.Forms.TextBox
    Friend WithEvents I_Vendeur As System.Windows.Forms.ComboBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents I_Web As System.Windows.Forms.ComboBox
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents I_etat_max As System.Windows.Forms.ComboBox
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents TEtatCommandeVenteMaxBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents I_Encaisse As System.Windows.Forms.ComboBox
    Friend WithEvents I_NumCaisse As ComboBox
    Friend WithEvents Label21 As Label
    Friend WithEvents I_SynchroPrestashop As ComboBox
    Friend WithEvents IL_SynchroPS As Label
    Friend WithEvents RefCommande As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewCheckBoxColumn1 As DataGridViewCheckBoxColumn
    Friend WithEvents EtatCommandeDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents TotalDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents DateCommandeDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents VendeurDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents RefClientDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents SociétéDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents NomDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents PrénomDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents CodePostal As DataGridViewTextBoxColumn
    Friend WithEvents Ville As DataGridViewTextBoxColumn
    Friend WithEvents Pays As DataGridViewTextBoxColumn
    Friend WithEvents DateFactureDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents DateExpeditionDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents WebDataGridViewCheckBoxColumn As DataGridViewCheckBoxColumn
    Friend WithEvents CodeEtat As DataGridViewTextBoxColumn
    Friend WithEvents numcaisse As DataGridViewTextBoxColumn
    Friend WithEvents ReferencePrestashop As DataGridViewTextBoxColumn
    Friend WithEvents PanierPrestashop As DataGridViewTextBoxColumn
    Friend WithEvents SynchroPrestashop As DataGridViewTextBoxColumn
    Friend WithEvents Label23 As Label
    Friend WithEvents Label22 As Label
    Friend WithEvents I_ReferencePrestashop As TextBox
End Class
