<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FormEcheanceRecherche
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormEcheanceRecherche))
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.DGview = New System.Windows.Forms.DataGridView()
        Me.RefCommandeDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DateCommandeDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Société = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.NomDataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PrénomDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.RefClientDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ModeRèglementDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.MoyenPaiementDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.MontantDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.EchéanceDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.WebonDataGridViewCheckBoxColumn = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.ContextMenuStripRecherche = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.EtiquetteAdresseToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EnvoyerMailRelanceAvoirsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.V_Recherche_EcheanceBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.CLIDataSet = New CLI.CLIDataSet()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.I_MoyenPaiement = New System.Windows.Forms.ComboBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.I_DateCommande_fin = New System.Windows.Forms.DateTimePicker()
        Me.I_DateCommande_debut = New System.Windows.Forms.DateTimePicker()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.I_echeance_fin = New System.Windows.Forms.DateTimePicker()
        Me.I_echeance_debut = New System.Windows.Forms.DateTimePicker()
        Me.I_RefClient = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.I_RefCommande = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.I_EcheanceMax = New System.Windows.Forms.TextBox()
        Me.I_Prenom = New System.Windows.Forms.TextBox()
        Me.I_Nom = New System.Windows.Forms.TextBox()
        Me.I_Societe = New System.Windows.Forms.TextBox()
        Me.I_EchanceMin = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.ToolTip = New System.Windows.Forms.ToolTip(Me.components)
        Me.StatusStrip = New System.Windows.Forms.StatusStrip()
        Me.ToolStripStatusLabelNbEnregistrements = New System.Windows.Forms.ToolStripStatusLabel()
        Me.BT_Go = New System.Windows.Forms.Button()
        Me.BT_RAZ = New System.Windows.Forms.Button()
        Me.BT_Fermer = New System.Windows.Forms.Button()
        Me.SociétéDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.NomDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PrenomDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CodePostalDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.VilleDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PaysDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.NbArticleDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.BT_Impression = New System.Windows.Forms.Button()
        Me.BT_Email = New System.Windows.Forms.Button()
        Me.SociétéDataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.NomDataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PrenomDataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CodePostalDataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.VilleDataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PaysDataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.NbCommande = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.NbArticleDataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.MontantAvoirDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.V_Recherche_EcheanceTableAdapter = New CLI.CLIDataSetTableAdapters.V_Recherche_EcheanceTableAdapter()
        Me.IL_TotalAvoir = New System.Windows.Forms.Label()
        Me.I_TotalEcheances = New System.Windows.Forms.TextBox()
        CType(Me.DGview, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ContextMenuStripRecherche.SuspendLayout()
        CType(Me.V_Recherche_EcheanceBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CLIDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
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
        Me.DGview.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DGview.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.DGview.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.RefCommandeDataGridViewTextBoxColumn, Me.DateCommandeDataGridViewTextBoxColumn, Me.Société, Me.NomDataGridViewTextBoxColumn2, Me.PrénomDataGridViewTextBoxColumn, Me.RefClientDataGridViewTextBoxColumn, Me.ModeRèglementDataGridViewTextBoxColumn, Me.MoyenPaiementDataGridViewTextBoxColumn, Me.MontantDataGridViewTextBoxColumn, Me.EchéanceDataGridViewTextBoxColumn, Me.WebonDataGridViewCheckBoxColumn})
        Me.DGview.ContextMenuStrip = Me.ContextMenuStripRecherche
        Me.DGview.DataSource = Me.V_Recherche_EcheanceBindingSource
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DGview.DefaultCellStyle = DataGridViewCellStyle3
        Me.DGview.Location = New System.Drawing.Point(4, 340)
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
        Me.DGview.Size = New System.Drawing.Size(994, 286)
        Me.DGview.TabIndex = 3
        '
        'RefCommandeDataGridViewTextBoxColumn
        '
        Me.RefCommandeDataGridViewTextBoxColumn.DataPropertyName = "Ref Commande"
        Me.RefCommandeDataGridViewTextBoxColumn.HeaderText = "Ref Commande"
        Me.RefCommandeDataGridViewTextBoxColumn.Name = "RefCommandeDataGridViewTextBoxColumn"
        Me.RefCommandeDataGridViewTextBoxColumn.ReadOnly = True
        Me.RefCommandeDataGridViewTextBoxColumn.Width = 105
        '
        'DateCommandeDataGridViewTextBoxColumn
        '
        Me.DateCommandeDataGridViewTextBoxColumn.DataPropertyName = "Date commande"
        Me.DateCommandeDataGridViewTextBoxColumn.HeaderText = "Date commande"
        Me.DateCommandeDataGridViewTextBoxColumn.Name = "DateCommandeDataGridViewTextBoxColumn"
        Me.DateCommandeDataGridViewTextBoxColumn.ReadOnly = True
        Me.DateCommandeDataGridViewTextBoxColumn.Width = 110
        '
        'Société
        '
        Me.Société.DataPropertyName = "Société"
        Me.Société.HeaderText = "Société"
        Me.Société.Name = "Société"
        Me.Société.ReadOnly = True
        Me.Société.Width = 68
        '
        'NomDataGridViewTextBoxColumn2
        '
        Me.NomDataGridViewTextBoxColumn2.DataPropertyName = "Nom"
        Me.NomDataGridViewTextBoxColumn2.HeaderText = "Nom"
        Me.NomDataGridViewTextBoxColumn2.Name = "NomDataGridViewTextBoxColumn2"
        Me.NomDataGridViewTextBoxColumn2.ReadOnly = True
        Me.NomDataGridViewTextBoxColumn2.Width = 54
        '
        'PrénomDataGridViewTextBoxColumn
        '
        Me.PrénomDataGridViewTextBoxColumn.DataPropertyName = "Prénom"
        Me.PrénomDataGridViewTextBoxColumn.HeaderText = "Prénom"
        Me.PrénomDataGridViewTextBoxColumn.Name = "PrénomDataGridViewTextBoxColumn"
        Me.PrénomDataGridViewTextBoxColumn.ReadOnly = True
        Me.PrénomDataGridViewTextBoxColumn.Width = 68
        '
        'RefClientDataGridViewTextBoxColumn
        '
        Me.RefClientDataGridViewTextBoxColumn.DataPropertyName = "Ref client"
        Me.RefClientDataGridViewTextBoxColumn.HeaderText = "Ref client"
        Me.RefClientDataGridViewTextBoxColumn.Name = "RefClientDataGridViewTextBoxColumn"
        Me.RefClientDataGridViewTextBoxColumn.ReadOnly = True
        Me.RefClientDataGridViewTextBoxColumn.Width = 77
        '
        'ModeRèglementDataGridViewTextBoxColumn
        '
        Me.ModeRèglementDataGridViewTextBoxColumn.DataPropertyName = "Mode règlement"
        Me.ModeRèglementDataGridViewTextBoxColumn.HeaderText = "Mode règlement"
        Me.ModeRèglementDataGridViewTextBoxColumn.Name = "ModeRèglementDataGridViewTextBoxColumn"
        Me.ModeRèglementDataGridViewTextBoxColumn.ReadOnly = True
        Me.ModeRèglementDataGridViewTextBoxColumn.Width = 108
        '
        'MoyenPaiementDataGridViewTextBoxColumn
        '
        Me.MoyenPaiementDataGridViewTextBoxColumn.DataPropertyName = "Moyen paiement"
        Me.MoyenPaiementDataGridViewTextBoxColumn.HeaderText = "Moyen paiement"
        Me.MoyenPaiementDataGridViewTextBoxColumn.Name = "MoyenPaiementDataGridViewTextBoxColumn"
        Me.MoyenPaiementDataGridViewTextBoxColumn.ReadOnly = True
        Me.MoyenPaiementDataGridViewTextBoxColumn.Width = 110
        '
        'MontantDataGridViewTextBoxColumn
        '
        Me.MontantDataGridViewTextBoxColumn.DataPropertyName = "Montant"
        Me.MontantDataGridViewTextBoxColumn.HeaderText = "Montant"
        Me.MontantDataGridViewTextBoxColumn.Name = "MontantDataGridViewTextBoxColumn"
        Me.MontantDataGridViewTextBoxColumn.ReadOnly = True
        Me.MontantDataGridViewTextBoxColumn.Width = 71
        '
        'EchéanceDataGridViewTextBoxColumn
        '
        Me.EchéanceDataGridViewTextBoxColumn.DataPropertyName = "Echéance"
        Me.EchéanceDataGridViewTextBoxColumn.HeaderText = "Date Echéance"
        Me.EchéanceDataGridViewTextBoxColumn.Name = "EchéanceDataGridViewTextBoxColumn"
        Me.EchéanceDataGridViewTextBoxColumn.ReadOnly = True
        Me.EchéanceDataGridViewTextBoxColumn.Width = 107
        '
        'WebonDataGridViewCheckBoxColumn
        '
        Me.WebonDataGridViewCheckBoxColumn.DataPropertyName = "Web_on"
        Me.WebonDataGridViewCheckBoxColumn.HeaderText = "Web_on"
        Me.WebonDataGridViewCheckBoxColumn.Name = "WebonDataGridViewCheckBoxColumn"
        Me.WebonDataGridViewCheckBoxColumn.ReadOnly = True
        Me.WebonDataGridViewCheckBoxColumn.Width = 54
        '
        'ContextMenuStripRecherche
        '
        Me.ContextMenuStripRecherche.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.EtiquetteAdresseToolStripMenuItem, Me.EnvoyerMailRelanceAvoirsToolStripMenuItem})
        Me.ContextMenuStripRecherche.Name = "ContextMenuStrip"
        Me.ContextMenuStripRecherche.Size = New System.Drawing.Size(218, 48)
        '
        'EtiquetteAdresseToolStripMenuItem
        '
        Me.EtiquetteAdresseToolStripMenuItem.Image = CType(resources.GetObject("EtiquetteAdresseToolStripMenuItem.Image"), System.Drawing.Image)
        Me.EtiquetteAdresseToolStripMenuItem.Name = "EtiquetteAdresseToolStripMenuItem"
        Me.EtiquetteAdresseToolStripMenuItem.Size = New System.Drawing.Size(217, 22)
        Me.EtiquetteAdresseToolStripMenuItem.Text = "Etiquette adresse"
        '
        'EnvoyerMailRelanceAvoirsToolStripMenuItem
        '
        Me.EnvoyerMailRelanceAvoirsToolStripMenuItem.Image = CType(resources.GetObject("EnvoyerMailRelanceAvoirsToolStripMenuItem.Image"), System.Drawing.Image)
        Me.EnvoyerMailRelanceAvoirsToolStripMenuItem.Name = "EnvoyerMailRelanceAvoirsToolStripMenuItem"
        Me.EnvoyerMailRelanceAvoirsToolStripMenuItem.Size = New System.Drawing.Size(217, 22)
        Me.EnvoyerMailRelanceAvoirsToolStripMenuItem.Text = "Envoyer mail relance avoirs"
        '
        'V_Recherche_EcheanceBindingSource
        '
        Me.V_Recherche_EcheanceBindingSource.DataMember = "V_Recherche_Echeance"
        Me.V_Recherche_EcheanceBindingSource.DataSource = Me.CLIDataSet
        '
        'CLIDataSet
        '
        Me.CLIDataSet.DataSetName = "CLIDataSet"
        Me.CLIDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.I_MoyenPaiement)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.I_DateCommande_fin)
        Me.GroupBox1.Controls.Add(Me.I_DateCommande_debut)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.I_echeance_fin)
        Me.GroupBox1.Controls.Add(Me.I_echeance_debut)
        Me.GroupBox1.Controls.Add(Me.I_RefClient)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.I_RefCommande)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.I_EcheanceMax)
        Me.GroupBox1.Controls.Add(Me.I_Prenom)
        Me.GroupBox1.Controls.Add(Me.I_Nom)
        Me.GroupBox1.Controls.Add(Me.I_Societe)
        Me.GroupBox1.Controls.Add(Me.I_EchanceMin)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.Label9)
        Me.GroupBox1.Controls.Add(Me.Label11)
        Me.GroupBox1.Controls.Add(Me.Label10)
        Me.GroupBox1.Controls.Add(Me.Label17)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label16)
        Me.GroupBox1.Location = New System.Drawing.Point(4, 7)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(711, 298)
        Me.GroupBox1.TabIndex = 1
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Multi-critère"
        '
        'I_MoyenPaiement
        '
        Me.I_MoyenPaiement.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.I_MoyenPaiement.FormattingEnabled = True
        Me.I_MoyenPaiement.Location = New System.Drawing.Point(125, 260)
        Me.I_MoyenPaiement.Name = "I_MoyenPaiement"
        Me.I_MoyenPaiement.Size = New System.Drawing.Size(121, 21)
        Me.I_MoyenPaiement.TabIndex = 19
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(231, 61)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(19, 13)
        Me.Label6.TabIndex = 18
        Me.Label6.Text = "au"
        '
        'I_DateCommande_fin
        '
        Me.I_DateCommande_fin.Checked = False
        Me.I_DateCommande_fin.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.I_DateCommande_fin.Location = New System.Drawing.Point(265, 55)
        Me.I_DateCommande_fin.Name = "I_DateCommande_fin"
        Me.I_DateCommande_fin.ShowCheckBox = True
        Me.I_DateCommande_fin.Size = New System.Drawing.Size(101, 20)
        Me.I_DateCommande_fin.TabIndex = 3
        Me.I_DateCommande_fin.Value = New Date(2009, 12, 20, 0, 0, 0, 0)
        '
        'I_DateCommande_debut
        '
        Me.I_DateCommande_debut.Checked = False
        Me.I_DateCommande_debut.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.I_DateCommande_debut.Location = New System.Drawing.Point(125, 56)
        Me.I_DateCommande_debut.Name = "I_DateCommande_debut"
        Me.I_DateCommande_debut.ShowCheckBox = True
        Me.I_DateCommande_debut.Size = New System.Drawing.Size(98, 20)
        Me.I_DateCommande_debut.TabIndex = 2
        Me.I_DateCommande_debut.Value = New Date(2009, 12, 20, 0, 0, 0, 0)
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(6, 62)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(86, 13)
        Me.Label7.TabIndex = 15
        Me.Label7.Text = "Date Commande"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(231, 99)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(19, 13)
        Me.Label5.TabIndex = 14
        Me.Label5.Text = "au"
        '
        'I_echeance_fin
        '
        Me.I_echeance_fin.Checked = False
        Me.I_echeance_fin.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.I_echeance_fin.Location = New System.Drawing.Point(265, 93)
        Me.I_echeance_fin.Name = "I_echeance_fin"
        Me.I_echeance_fin.ShowCheckBox = True
        Me.I_echeance_fin.Size = New System.Drawing.Size(101, 20)
        Me.I_echeance_fin.TabIndex = 5
        Me.I_echeance_fin.Value = New Date(2009, 12, 20, 0, 0, 0, 0)
        '
        'I_echeance_debut
        '
        Me.I_echeance_debut.Checked = False
        Me.I_echeance_debut.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.I_echeance_debut.Location = New System.Drawing.Point(125, 94)
        Me.I_echeance_debut.Name = "I_echeance_debut"
        Me.I_echeance_debut.ShowCheckBox = True
        Me.I_echeance_debut.Size = New System.Drawing.Size(98, 20)
        Me.I_echeance_debut.TabIndex = 4
        Me.I_echeance_debut.Value = New Date(2009, 12, 20, 0, 0, 0, 0)
        '
        'I_RefClient
        '
        Me.I_RefClient.Location = New System.Drawing.Point(125, 156)
        Me.I_RefClient.Name = "I_RefClient"
        Me.I_RefClient.Size = New System.Drawing.Size(98, 20)
        Me.I_RefClient.TabIndex = 8
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(9, 159)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(52, 13)
        Me.Label2.TabIndex = 11
        Me.Label2.Text = "Réf client"
        '
        'I_RefCommande
        '
        Me.I_RefCommande.Location = New System.Drawing.Point(125, 21)
        Me.I_RefCommande.Name = "I_RefCommande"
        Me.I_RefCommande.Size = New System.Drawing.Size(98, 20)
        Me.I_RefCommande.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(6, 24)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(79, 13)
        Me.Label1.TabIndex = 11
        Me.Label1.Text = "Réf commande"
        '
        'I_EcheanceMax
        '
        Me.I_EcheanceMax.Location = New System.Drawing.Point(186, 126)
        Me.I_EcheanceMax.Name = "I_EcheanceMax"
        Me.I_EcheanceMax.Size = New System.Drawing.Size(37, 20)
        Me.I_EcheanceMax.TabIndex = 7
        '
        'I_Prenom
        '
        Me.I_Prenom.Location = New System.Drawing.Point(125, 233)
        Me.I_Prenom.Name = "I_Prenom"
        Me.I_Prenom.Size = New System.Drawing.Size(98, 20)
        Me.I_Prenom.TabIndex = 11
        '
        'I_Nom
        '
        Me.I_Nom.Location = New System.Drawing.Point(125, 207)
        Me.I_Nom.Name = "I_Nom"
        Me.I_Nom.Size = New System.Drawing.Size(98, 20)
        Me.I_Nom.TabIndex = 10
        '
        'I_Societe
        '
        Me.I_Societe.Location = New System.Drawing.Point(125, 182)
        Me.I_Societe.Name = "I_Societe"
        Me.I_Societe.Size = New System.Drawing.Size(98, 20)
        Me.I_Societe.TabIndex = 9
        '
        'I_EchanceMin
        '
        Me.I_EchanceMin.Location = New System.Drawing.Point(125, 127)
        Me.I_EchanceMin.Name = "I_EchanceMin"
        Me.I_EchanceMin.Size = New System.Drawing.Size(37, 20)
        Me.I_EchanceMin.TabIndex = 6
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(6, 49)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(0, 13)
        Me.Label4.TabIndex = 7
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(9, 264)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(85, 13)
        Me.Label9.TabIndex = 6
        Me.Label9.Text = "Moyen paiement"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(9, 239)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(43, 13)
        Me.Label11.TabIndex = 6
        Me.Label11.Text = "Prénom"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(9, 213)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(29, 13)
        Me.Label10.TabIndex = 6
        Me.Label10.Text = "Nom"
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(167, 130)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(13, 13)
        Me.Label17.TabIndex = 6
        Me.Label17.Text = "à"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(9, 188)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(43, 13)
        Me.Label8.TabIndex = 6
        Me.Label8.Text = "Société"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(6, 100)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(87, 13)
        Me.Label3.TabIndex = 6
        Me.Label3.Text = "Date Echéances"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(9, 130)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(76, 13)
        Me.Label16.TabIndex = 6
        Me.Label16.Text = "Mt Echéances"
        '
        'StatusStrip
        '
        Me.StatusStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripStatusLabelNbEnregistrements})
        Me.StatusStrip.Location = New System.Drawing.Point(0, 629)
        Me.StatusStrip.Name = "StatusStrip"
        Me.StatusStrip.Size = New System.Drawing.Size(998, 22)
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
        Me.BT_Go.Image = CType(resources.GetObject("BT_Go.Image"), System.Drawing.Image)
        Me.BT_Go.Location = New System.Drawing.Point(740, 51)
        Me.BT_Go.Name = "BT_Go"
        Me.BT_Go.Size = New System.Drawing.Size(61, 31)
        Me.BT_Go.TabIndex = 2
        Me.BT_Go.Text = "Go"
        Me.BT_Go.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.BT_Go.UseVisualStyleBackColor = True
        '
        'BT_RAZ
        '
        Me.BT_RAZ.Image = CType(resources.GetObject("BT_RAZ.Image"), System.Drawing.Image)
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
        Me.BT_Fermer.Image = CType(resources.GetObject("BT_Fermer.Image"), System.Drawing.Image)
        Me.BT_Fermer.Location = New System.Drawing.Point(740, 12)
        Me.BT_Fermer.Name = "BT_Fermer"
        Me.BT_Fermer.Size = New System.Drawing.Size(82, 25)
        Me.BT_Fermer.TabIndex = 10
        Me.BT_Fermer.Text = "Fermer"
        Me.BT_Fermer.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.BT_Fermer.UseVisualStyleBackColor = True
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
        'BT_Impression
        '
        Me.BT_Impression.Image = CType(resources.GetObject("BT_Impression.Image"), System.Drawing.Image)
        Me.BT_Impression.Location = New System.Drawing.Point(4, 311)
        Me.BT_Impression.Name = "BT_Impression"
        Me.BT_Impression.Size = New System.Drawing.Size(78, 23)
        Me.BT_Impression.TabIndex = 11
        Me.BT_Impression.Text = "Imprimer"
        Me.BT_Impression.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.BT_Impression.UseVisualStyleBackColor = True
        '
        'BT_Email
        '
        Me.BT_Email.Image = CType(resources.GetObject("BT_Email.Image"), System.Drawing.Image)
        Me.BT_Email.Location = New System.Drawing.Point(88, 311)
        Me.BT_Email.Name = "BT_Email"
        Me.BT_Email.Size = New System.Drawing.Size(77, 23)
        Me.BT_Email.TabIndex = 12
        Me.BT_Email.Text = "Email"
        Me.BT_Email.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.BT_Email.UseVisualStyleBackColor = True
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
        'V_Recherche_EcheanceTableAdapter
        '
        Me.V_Recherche_EcheanceTableAdapter.ClearBeforeFill = True
        '
        'IL_TotalAvoir
        '
        Me.IL_TotalAvoir.AutoSize = True
        Me.IL_TotalAvoir.Location = New System.Drawing.Point(729, 316)
        Me.IL_TotalAvoir.Name = "IL_TotalAvoir"
        Me.IL_TotalAvoir.Size = New System.Drawing.Size(88, 13)
        Me.IL_TotalAvoir.TabIndex = 14
        Me.IL_TotalAvoir.Text = "Total Echeances"
        '
        'I_TotalEcheances
        '
        Me.I_TotalEcheances.Location = New System.Drawing.Point(823, 313)
        Me.I_TotalEcheances.Name = "I_TotalEcheances"
        Me.I_TotalEcheances.ReadOnly = True
        Me.I_TotalEcheances.Size = New System.Drawing.Size(83, 20)
        Me.I_TotalEcheances.TabIndex = 13
        '
        'FormEcheanceRecherche
        '
        Me.AcceptButton = Me.BT_Go
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.BT_Fermer
        Me.ClientSize = New System.Drawing.Size(998, 651)
        Me.Controls.Add(Me.I_TotalEcheances)
        Me.Controls.Add(Me.IL_TotalAvoir)
        Me.Controls.Add(Me.BT_Email)
        Me.Controls.Add(Me.BT_Impression)
        Me.Controls.Add(Me.BT_Fermer)
        Me.Controls.Add(Me.StatusStrip)
        Me.Controls.Add(Me.BT_RAZ)
        Me.Controls.Add(Me.BT_Go)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.DGview)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "FormEcheanceRecherche"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Rechercher une échéance"
        CType(Me.DGview, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ContextMenuStripRecherche.ResumeLayout(False)
        CType(Me.V_Recherche_EcheanceBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CLIDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.StatusStrip.ResumeLayout(False)
        Me.StatusStrip.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents CLIDataSet As CLI.CLIDataSet
    Friend WithEvents V_Recherche_EcheanceBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents DGview As System.Windows.Forms.DataGridView
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents BT_Go As System.Windows.Forms.Button
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents ToolTip As System.Windows.Forms.ToolTip
    Friend WithEvents BT_RAZ As System.Windows.Forms.Button
    Friend WithEvents StatusStrip As System.Windows.Forms.StatusStrip
    Friend WithEvents ToolStripStatusLabelNbEnregistrements As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ContextMenuStripRecherche As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents BT_Fermer As System.Windows.Forms.Button
    Friend WithEvents I_Societe As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label

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
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents BT_Impression As System.Windows.Forms.Button
    Friend WithEvents BT_Email As System.Windows.Forms.Button
    Friend WithEvents EtiquetteAdresseToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
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
    Friend WithEvents V_Recherche_EcheanceTableAdapter As CLIDataSetTableAdapters.V_Recherche_EcheanceTableAdapter
    Friend WithEvents IL_TotalAvoir As Label
    Friend WithEvents I_TotalEcheances As TextBox
    Friend WithEvents I_RefCommande As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents I_RefClient As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents I_echeance_fin As DateTimePicker
    Friend WithEvents I_echeance_debut As DateTimePicker
    Friend WithEvents I_EcheanceMax As TextBox
    Friend WithEvents I_EchanceMin As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents I_DateCommande_fin As DateTimePicker
    Friend WithEvents I_DateCommande_debut As DateTimePicker
    Friend WithEvents Label7 As Label
    Friend WithEvents RefCommandeDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents DateCommandeDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents Société As DataGridViewTextBoxColumn
    Friend WithEvents NomDataGridViewTextBoxColumn2 As DataGridViewTextBoxColumn
    Friend WithEvents PrénomDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents RefClientDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents ModeRèglementDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents MoyenPaiementDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents MontantDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents EchéanceDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents WebonDataGridViewCheckBoxColumn As DataGridViewCheckBoxColumn
    Friend WithEvents I_MoyenPaiement As ComboBox
    Friend WithEvents Label9 As Label
End Class
