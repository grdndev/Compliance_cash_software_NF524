<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FormCaisse
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
        Dim CreeLeLabel As System.Windows.Forms.Label
        Dim ModifieParLabel As System.Windows.Forms.Label
        Dim ModifieLeLabel As System.Windows.Forms.Label
        Dim EmailLabel As System.Windows.Forms.Label
        Dim MontantPaiementTTCLabel As System.Windows.Forms.Label
        Dim Label12 As System.Windows.Forms.Label
        Dim MontantARendreTTCLabel As System.Windows.Forms.Label
        Dim Label14 As System.Windows.Forms.Label
        Dim Label15 As System.Windows.Forms.Label
        Dim AvoirCreeNoLabel As System.Windows.Forms.Label
        Dim RenduLeLabel As System.Windows.Forms.Label
        Dim ExpedieLeLabel1 As System.Windows.Forms.Label
        Dim TicketLeLabel As System.Windows.Forms.Label
        Dim FactureLeLabel1 As System.Windows.Forms.Label
        Dim ExpeditionNumsuiviLabel As System.Windows.Forms.Label
        Dim MobileLabel As System.Windows.Forms.Label
        Dim FaxLabel As System.Windows.Forms.Label
        Dim TelLabel As System.Windows.Forms.Label
        Dim PaysLabel As System.Windows.Forms.Label
        Dim VilleLabel As System.Windows.Forms.Label
        Dim CodePostalLabel As System.Windows.Forms.Label
        Dim AdresseL3Label As System.Windows.Forms.Label
        Dim AdresseL2Label As System.Windows.Forms.Label
        Dim AdresseL1Label As System.Windows.Forms.Label
        Dim ID_EtatCommandeVenteLabel As System.Windows.Forms.Label
        Dim PrénomLabel As System.Windows.Forms.Label
        Dim NomLabel As System.Windows.Forms.Label
        Dim LabelCodeClient As System.Windows.Forms.Label
        Dim SociétéLabel As System.Windows.Forms.Label
        Dim ID_T_CommandeVenteLabel As System.Windows.Forms.Label
        Dim Commentaires_factureLabel As System.Windows.Forms.Label
        Dim Label20 As System.Windows.Forms.Label
        Dim NoTVALabel As System.Windows.Forms.Label
        Dim NoSiretLabel As System.Windows.Forms.Label
        Dim VuAvecLabel As System.Windows.Forms.Label
        Dim CommentairesCommandeLabel As System.Windows.Forms.Label
        Dim ExpeditionLeLabel As System.Windows.Forms.Label
        Dim Id_T_TransporteurLabel As System.Windows.Forms.Label
        Dim EtatSynchroPrestashopLabel As System.Windows.Forms.Label
        Dim ReportDataSource1 As Microsoft.Reporting.WinForms.ReportDataSource = New Microsoft.Reporting.WinForms.ReportDataSource()
        Dim ReportDataSource2 As Microsoft.Reporting.WinForms.ReportDataSource = New Microsoft.Reporting.WinForms.ReportDataSource()
        Dim ReportDataSource3 As Microsoft.Reporting.WinForms.ReportDataSource = New Microsoft.Reporting.WinForms.ReportDataSource()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle10 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormCaisse))
        Dim ReportDataSource4 As Microsoft.Reporting.WinForms.ReportDataSource = New Microsoft.Reporting.WinForms.ReportDataSource()
        Dim ReportDataSource5 As Microsoft.Reporting.WinForms.ReportDataSource = New Microsoft.Reporting.WinForms.ReportDataSource()
        Dim ReportDataSource6 As Microsoft.Reporting.WinForms.ReportDataSource = New Microsoft.Reporting.WinForms.ReportDataSource()
        Dim ReportDataSource7 As Microsoft.Reporting.WinForms.ReportDataSource = New Microsoft.Reporting.WinForms.ReportDataSource()
        Dim ReportDataSource8 As Microsoft.Reporting.WinForms.ReportDataSource = New Microsoft.Reporting.WinForms.ReportDataSource()
        Dim ReportDataSource9 As Microsoft.Reporting.WinForms.ReportDataSource = New Microsoft.Reporting.WinForms.ReportDataSource()
        Dim ReportDataSource10 As Microsoft.Reporting.WinForms.ReportDataSource = New Microsoft.Reporting.WinForms.ReportDataSource()
        Dim DataGridViewCellStyle11 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle13 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle14 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle12 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.T_CommandeVente_LigneBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.CLIDataSet = New CLI.CLIDataSet()
        Me.T_CommandeVenteBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.V_reglementBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.V_chequecadeau_clientBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.V_Avoir_clientBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.VreglementBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.TReglementBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.T_ReglementBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabCommande = New System.Windows.Forms.TabPage()
        Me.I_IdPanierPrestashop = New System.Windows.Forms.TextBox()
        Me.Label33 = New System.Windows.Forms.Label()
        Me.I_IdCommandePrestashop = New System.Windows.Forms.TextBox()
        Me.I_ReferenceCommandePrestashop = New System.Windows.Forms.TextBox()
        Me.Label32 = New System.Windows.Forms.Label()
        Me.BT_DetailSynchro = New System.Windows.Forms.Button()
        Me.I_EtatSynchroPrestashop = New System.Windows.Forms.TextBox()
        Me.I_Caisse = New System.Windows.Forms.ComboBox()
        Me.Label31 = New System.Windows.Forms.Label()
        Me.Label30 = New System.Windows.Forms.Label()
        Me.I_Total_TTC_avantDeduction = New System.Windows.Forms.TextBox()
        Me.DevisReportViewer = New Microsoft.Reporting.WinForms.ReportViewer()
        Me.BT_Imprimer_reservation = New System.Windows.Forms.Button()
        Me.BT_Imprimer_devis = New System.Windows.Forms.Button()
        Me.GroupBoxCodesSpeciaux = New System.Windows.Forms.GroupBox()
        Me.Label29 = New System.Windows.Forms.Label()
        Me.Label26 = New System.Windows.Forms.Label()
        Me.Label28 = New System.Windows.Forms.Label()
        Me.Label27 = New System.Windows.Forms.Label()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.BT_Imprimer_test = New System.Windows.Forms.Button()
        Me.BT_AnnulerCommande = New System.Windows.Forms.Button()
        Me.EnteteGroupBox = New System.Windows.Forms.GroupBox()
        Me.I_Vpc_on = New System.Windows.Forms.CheckBox()
        Me.BT_BL = New System.Windows.Forms.Button()
        Me.BT_Imprimer = New System.Windows.Forms.Button()
        Me.BT_Envoi_etat_commande = New System.Windows.Forms.Button()
        Me.CommentairesCommandeTextBox = New System.Windows.Forms.TextBox()
        Me.VuAvecTextBox = New System.Windows.Forms.TextBox()
        Me.NoSiretTextBox = New System.Windows.Forms.TextBox()
        Me.NoTVATextBox = New System.Windows.Forms.TextBox()
        Me.ExportCheckBox = New System.Windows.Forms.CheckBox()
        Me.PaysComboBox = New System.Windows.Forms.ComboBox()
        Me.TPaysBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.EtatLibelleTextBox = New System.Windows.Forms.TextBox()
        Me.TEtatCommandeVenteBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.EmailTextBox = New System.Windows.Forms.TextBox()
        Me.MobileTextBox = New System.Windows.Forms.TextBox()
        Me.FaxTextBox = New System.Windows.Forms.TextBox()
        Me.TelTextBox = New System.Windows.Forms.TextBox()
        Me.VilleTextBox = New System.Windows.Forms.TextBox()
        Me.CodePostalTextBox = New System.Windows.Forms.TextBox()
        Me.AdresseL3TextBox = New System.Windows.Forms.TextBox()
        Me.AdresseL2TextBox = New System.Windows.Forms.TextBox()
        Me.AdresseL1TextBox = New System.Windows.Forms.TextBox()
        Me.I_Web = New System.Windows.Forms.CheckBox()
        Me.PrénomTextBox = New System.Windows.Forms.TextBox()
        Me.NomTextBox = New System.Windows.Forms.TextBox()
        Me.CodeClientTextBox = New System.Windows.Forms.TextBox()
        Me.ContextMenuStripClient = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.SociétéTextBox = New System.Windows.Forms.TextBox()
        Me.ID_T_CommandeVenteTextBox = New System.Windows.Forms.TextBox()
        Me.BT_Scan = New System.Windows.Forms.Button()
        Me.BT_Etape_Règlement = New System.Windows.Forms.Button()
        Me.BT_Enregistrer = New System.Windows.Forms.Button()
        Me.ModifieLeTextBox = New System.Windows.Forms.TextBox()
        Me.ModifieParTextBox = New System.Windows.Forms.TextBox()
        Me.CreeLeTextBox = New System.Windows.Forms.TextBox()
        Me.CreeParTextBox = New System.Windows.Forms.TextBox()
        Me.GroupBoxAjout = New System.Windows.Forms.GroupBox()
        Me.I_NomBeneficiaire = New System.Windows.Forms.TextBox()
        Me.IL_codebenef = New System.Windows.Forms.Label()
        Me.I_ChequeCadeauIdClient = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.BT_ClearTampon = New System.Windows.Forms.Button()
        Me.I_Ref = New System.Windows.Forms.TextBox()
        Me.ContextMenuStripArticle = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.RechercherToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.BT_Plus = New System.Windows.Forms.Button()
        Me.I_Designation = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.I_PuTTC = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.I_Remise = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.I_TVA = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.I_PUTTCRemise = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.I_Qte = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.LabelTotalCommandeHT = New System.Windows.Forms.Label()
        Me.I_TotalTTC = New System.Windows.Forms.TextBox()
        Me.I_MontantDeduire = New System.Windows.Forms.TextBox()
        Me.I_TVA196 = New System.Windows.Forms.TextBox()
        Me.I_TVA55 = New System.Windows.Forms.TextBox()
        Me.I_TotalHT = New System.Windows.Forms.TextBox()
        Me.LabelArticles = New System.Windows.Forms.Label()
        Me.DataGridViewCommande = New System.Windows.Forms.DataGridView()
        Me.ID_T_CommandeVenteLigne = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ID_T_CommandeVente = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Ref = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Designation = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Qte = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.prix_vente_initial_HT = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TVA = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PUinitialTTC = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Remise = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PUremiseTTC = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.prix_total_HT = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TotalLigne = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TCommandeVenteLigneBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.ToolStrip = New System.Windows.Forms.ToolStrip()
        Me.NouveauToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButton2 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.CopierGeneToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.CollerGeneToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.SupprimerToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButton5 = New System.Windows.Forms.ToolStripButton()
        Me.TabReglement = New System.Windows.Forms.TabPage()
        Me.ChequeCadeauReportViewer = New Microsoft.Reporting.WinForms.ReportViewer()
        Me.AvoirReportViewer = New Microsoft.Reporting.WinForms.ReportViewer()
        Me.FactureReportViewer = New Microsoft.Reporting.WinForms.ReportViewer()
        Me.ExpeditionGroupBox = New System.Windows.Forms.GroupBox()
        Me.Id_T_TransporteurComboBox = New System.Windows.Forms.ComboBox()
        Me.ExpeditionLeTextBox = New System.Windows.Forms.TextBox()
        Me.BT_ReExpedier = New System.Windows.Forms.Button()
        Me.BT_Expedier = New System.Windows.Forms.Button()
        Me.BT_Etiquette = New System.Windows.Forms.Button()
        Me.ExpeditionNumsuiviTextBox = New System.Windows.Forms.TextBox()
        Me.SortieStockGroupBox = New System.Windows.Forms.GroupBox()
        Me.BT_ImprimerChequeCadeau = New System.Windows.Forms.Button()
        Me.BT_SortirStock = New System.Windows.Forms.Button()
        Me.ExpedieLeTextBox = New System.Windows.Forms.TextBox()
        Me.BT_OuvrirCaisse = New System.Windows.Forms.Button()
        Me.TicketFactureGroupBox = New System.Windows.Forms.GroupBox()
        Me.Commentaires_factureTextBox = New System.Windows.Forms.TextBox()
        Me.TicketLeTextBox = New System.Windows.Forms.TextBox()
        Me.BT_Ticket = New System.Windows.Forms.Button()
        Me.BT_Facture_Envoi = New System.Windows.Forms.Button()
        Me.BT_Facture = New System.Windows.Forms.Button()
        Me.FactureLeTextBox = New System.Windows.Forms.TextBox()
        Me.BT_revenir_commande = New System.Windows.Forms.Button()
        Me.RenduGroupBox = New System.Windows.Forms.GroupBox()
        Me.MontantRenduTTCTextBox = New System.Windows.Forms.TextBox()
        Me.BT_ImprimerAvoir = New System.Windows.Forms.Button()
        Me.BT_Basculer_Avoir = New System.Windows.Forms.Button()
        Me.BT_RendreLaMonnaie = New System.Windows.Forms.Button()
        Me.MontantARendreTTCTextBox = New System.Windows.Forms.TextBox()
        Me.AvoirCreeNoTextBox = New System.Windows.Forms.TextBox()
        Me.RenduLeTextBox = New System.Windows.Forms.TextBox()
        Me.PaiementGroupBox = New System.Windows.Forms.GroupBox()
        Me.TotalAPayerTextBox = New System.Windows.Forms.TextBox()
        Me.GroupBoxAjoutReglement = New System.Windows.Forms.GroupBox()
        Me.I_RefAvoir = New System.Windows.Forms.ComboBox()
        Me.I_encaisse = New System.Windows.Forms.CheckBox()
        Me.Bt_effaceReglement = New System.Windows.Forms.Button()
        Me.Bt_addReglement = New System.Windows.Forms.Button()
        Me.I_echeanceLe = New System.Windows.Forms.TextBox()
        Me.I_montantReglement = New System.Windows.Forms.TextBox()
        Me.I_conditions = New System.Windows.Forms.ComboBox()
        Me.TModeReglementValideBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.I_ModeReglement = New System.Windows.Forms.ComboBox()
        Me.TMoyenPaiementValideBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.Label19 = New System.Windows.Forms.Label()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.T_ReglementDataGridView = New System.Windows.Forms.DataGridView()
        Me.Conditionreglement = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.TmodeReglementBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.Moyenpaiement = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.TMoyenPaiementdgview = New System.Windows.Forms.BindingSource(Me.components)
        Me.Reference_avoir_bon = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Montant = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Echeancele = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Encaissele = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Enregistrele = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.A_Encaisser = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.Idtcommandevente = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.BT_Paiement = New System.Windows.Forms.Button()
        Me.montantEncaisseTextbox = New System.Windows.Forms.TextBox()
        Me.MontantPaiementTTCTextBox = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.TMoyenPaiementBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.FKTReglementTCommandeVenteBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.BT_Refresh = New System.Windows.Forms.Button()
        Me.ToolStrip2 = New System.Windows.Forms.ToolStrip()
        Me.ToolStripButtonMovefirst = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButtonMovePrevious = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripLabelPosition = New System.Windows.Forms.ToolStripLabel()
        Me.ToolStripButtonMoveNext = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButtonMoveLast = New System.Windows.Forms.ToolStripButton()
        Me.T_CommandeVenteTableAdapter = New CLI.CLIDataSetTableAdapters.T_CommandeVenteTableAdapter()
        Me.T_CommandeVente_LigneTableAdapter = New CLI.CLIDataSetTableAdapters.T_CommandeVente_LigneTableAdapter()
        Me.T_EtatCommandeVenteTableAdapter = New CLI.CLIDataSetTableAdapters.T_EtatCommandeVenteTableAdapter()
        Me.T_PaysTableAdapter = New CLI.CLIDataSetTableAdapters.T_PaysTableAdapter()
        Me.T_MoyenPaiementTableAdapter = New CLI.CLIDataSetTableAdapters.T_MoyenPaiementTableAdapter()
        Me.V_Avoir_clientTableAdapter = New CLI.CLIDataSetTableAdapters.V_Avoir_clientTableAdapter()
        Me.T_ReglementTableAdapter = New CLI.CLIDataSetTableAdapters.T_ReglementTableAdapter()
        Me.T_modeReglementTableAdapter = New CLI.CLIDataSetTableAdapters.T_modeReglementTableAdapter()
        Me.V_reglementTableAdapter = New CLI.CLIDataSetTableAdapters.V_reglementTableAdapter()
        Me.V_chequecadeau_clientTableAdapter = New CLI.CLIDataSetTableAdapters.V_chequecadeau_clientTableAdapter()
        Me.T_MoyenPaiementValideTableAdapter = New CLI.CLIDataSetTableAdapters.T_MoyenPaiementValideTableAdapter()
        Me.T_ModeReglementValideTableAdapter = New CLI.CLIDataSetTableAdapters.T_ModeReglementValideTableAdapter()
        CreeLeLabel = New System.Windows.Forms.Label()
        ModifieParLabel = New System.Windows.Forms.Label()
        ModifieLeLabel = New System.Windows.Forms.Label()
        EmailLabel = New System.Windows.Forms.Label()
        MontantPaiementTTCLabel = New System.Windows.Forms.Label()
        Label12 = New System.Windows.Forms.Label()
        MontantARendreTTCLabel = New System.Windows.Forms.Label()
        Label14 = New System.Windows.Forms.Label()
        Label15 = New System.Windows.Forms.Label()
        AvoirCreeNoLabel = New System.Windows.Forms.Label()
        RenduLeLabel = New System.Windows.Forms.Label()
        ExpedieLeLabel1 = New System.Windows.Forms.Label()
        TicketLeLabel = New System.Windows.Forms.Label()
        FactureLeLabel1 = New System.Windows.Forms.Label()
        ExpeditionNumsuiviLabel = New System.Windows.Forms.Label()
        MobileLabel = New System.Windows.Forms.Label()
        FaxLabel = New System.Windows.Forms.Label()
        TelLabel = New System.Windows.Forms.Label()
        PaysLabel = New System.Windows.Forms.Label()
        VilleLabel = New System.Windows.Forms.Label()
        CodePostalLabel = New System.Windows.Forms.Label()
        AdresseL3Label = New System.Windows.Forms.Label()
        AdresseL2Label = New System.Windows.Forms.Label()
        AdresseL1Label = New System.Windows.Forms.Label()
        ID_EtatCommandeVenteLabel = New System.Windows.Forms.Label()
        PrénomLabel = New System.Windows.Forms.Label()
        NomLabel = New System.Windows.Forms.Label()
        LabelCodeClient = New System.Windows.Forms.Label()
        SociétéLabel = New System.Windows.Forms.Label()
        ID_T_CommandeVenteLabel = New System.Windows.Forms.Label()
        Commentaires_factureLabel = New System.Windows.Forms.Label()
        Label20 = New System.Windows.Forms.Label()
        NoTVALabel = New System.Windows.Forms.Label()
        NoSiretLabel = New System.Windows.Forms.Label()
        VuAvecLabel = New System.Windows.Forms.Label()
        CommentairesCommandeLabel = New System.Windows.Forms.Label()
        ExpeditionLeLabel = New System.Windows.Forms.Label()
        Id_T_TransporteurLabel = New System.Windows.Forms.Label()
        EtatSynchroPrestashopLabel = New System.Windows.Forms.Label()
        CType(Me.T_CommandeVente_LigneBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CLIDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.T_CommandeVenteBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.V_reglementBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.V_chequecadeau_clientBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.V_Avoir_clientBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.VreglementBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TReglementBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.T_ReglementBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabControl1.SuspendLayout()
        Me.TabCommande.SuspendLayout()
        Me.GroupBoxCodesSpeciaux.SuspendLayout()
        Me.EnteteGroupBox.SuspendLayout()
        CType(Me.TPaysBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TEtatCommandeVenteBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ContextMenuStripClient.SuspendLayout()
        Me.GroupBoxAjout.SuspendLayout()
        Me.ContextMenuStripArticle.SuspendLayout()
        CType(Me.DataGridViewCommande, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TCommandeVenteLigneBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ToolStrip.SuspendLayout()
        Me.TabReglement.SuspendLayout()
        Me.ExpeditionGroupBox.SuspendLayout()
        Me.SortieStockGroupBox.SuspendLayout()
        Me.TicketFactureGroupBox.SuspendLayout()
        Me.RenduGroupBox.SuspendLayout()
        Me.PaiementGroupBox.SuspendLayout()
        Me.GroupBoxAjoutReglement.SuspendLayout()
        CType(Me.TModeReglementValideBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TMoyenPaiementValideBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.T_ReglementDataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TmodeReglementBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TMoyenPaiementdgview, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TMoyenPaiementBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.FKTReglementTCommandeVenteBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ToolStrip2.SuspendLayout()
        Me.SuspendLayout()
        '
        'CreeLeLabel
        '
        CreeLeLabel.AutoSize = True
        CreeLeLabel.Location = New System.Drawing.Point(947, 96)
        CreeLeLabel.Name = "CreeLeLabel"
        CreeLeLabel.Size = New System.Drawing.Size(47, 13)
        CreeLeLabel.TabIndex = 135
        CreeLeLabel.Text = "Cree Le:"
        '
        'ModifieParLabel
        '
        ModifieParLabel.AutoSize = True
        ModifieParLabel.Location = New System.Drawing.Point(930, 116)
        ModifieParLabel.Name = "ModifieParLabel"
        ModifieParLabel.Size = New System.Drawing.Size(63, 13)
        ModifieParLabel.TabIndex = 136
        ModifieParLabel.Text = "Modifie Par:"
        '
        'ModifieLeLabel
        '
        ModifieLeLabel.AutoSize = True
        ModifieLeLabel.Location = New System.Drawing.Point(935, 145)
        ModifieLeLabel.Name = "ModifieLeLabel"
        ModifieLeLabel.Size = New System.Drawing.Size(59, 13)
        ModifieLeLabel.TabIndex = 137
        ModifieLeLabel.Text = "Modifie Le:"
        '
        'EmailLabel
        '
        EmailLabel.AutoSize = True
        EmailLabel.Location = New System.Drawing.Point(54, 252)
        EmailLabel.Name = "EmailLabel"
        EmailLabel.Size = New System.Drawing.Size(35, 13)
        EmailLabel.TabIndex = 147
        EmailLabel.Text = "Email:"
        '
        'MontantPaiementTTCLabel
        '
        MontantPaiementTTCLabel.AutoSize = True
        MontantPaiementTTCLabel.Location = New System.Drawing.Point(224, 22)
        MontantPaiementTTCLabel.Name = "MontantPaiementTTCLabel"
        MontantPaiementTTCLabel.Size = New System.Drawing.Size(120, 13)
        MontantPaiementTTCLabel.TabIndex = 2
        MontantPaiementTTCLabel.Text = "Montant Paiement TTC:"
        '
        'Label12
        '
        Label12.AutoSize = True
        Label12.Location = New System.Drawing.Point(16, 56)
        Label12.Name = "Label12"
        Label12.Size = New System.Drawing.Size(108, 13)
        Label12.TabIndex = 4
        Label12.Text = "Montant Rendu TTC:"
        '
        'MontantARendreTTCLabel
        '
        MontantARendreTTCLabel.AutoSize = True
        MontantARendreTTCLabel.Location = New System.Drawing.Point(6, 26)
        MontantARendreTTCLabel.Name = "MontantARendreTTCLabel"
        MontantARendreTTCLabel.Size = New System.Drawing.Size(121, 13)
        MontantARendreTTCLabel.TabIndex = 131
        MontantARendreTTCLabel.Text = "Montant A Rendre TTC:"
        '
        'Label14
        '
        Label14.AutoSize = True
        Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Label14.Location = New System.Drawing.Point(274, 136)
        Label14.Name = "Label14"
        Label14.Size = New System.Drawing.Size(23, 13)
        Label14.TabIndex = 132
        Label14.Text = "Ou"
        Label14.Visible = False
        '
        'Label15
        '
        Label15.AutoSize = True
        Label15.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Label15.Location = New System.Drawing.Point(216, 76)
        Label15.Name = "Label15"
        Label15.Size = New System.Drawing.Size(49, 13)
        Label15.TabIndex = 132
        Label15.Text = "Et / Ou"
        '
        'AvoirCreeNoLabel
        '
        AvoirCreeNoLabel.AutoSize = True
        AvoirCreeNoLabel.Location = New System.Drawing.Point(48, 82)
        AvoirCreeNoLabel.Name = "AvoirCreeNoLabel"
        AvoirCreeNoLabel.Size = New System.Drawing.Size(76, 13)
        AvoirCreeNoLabel.TabIndex = 133
        AvoirCreeNoLabel.Text = "Avoir Cree No:"
        '
        'RenduLeLabel
        '
        RenduLeLabel.AutoSize = True
        RenduLeLabel.Location = New System.Drawing.Point(67, 108)
        RenduLeLabel.Name = "RenduLeLabel"
        RenduLeLabel.Size = New System.Drawing.Size(57, 13)
        RenduLeLabel.TabIndex = 135
        RenduLeLabel.Text = "Rendu Le:"
        '
        'ExpedieLeLabel1
        '
        ExpedieLeLabel1.AutoSize = True
        ExpedieLeLabel1.Location = New System.Drawing.Point(8, 22)
        ExpedieLeLabel1.Name = "ExpedieLeLabel1"
        ExpedieLeLabel1.Size = New System.Drawing.Size(46, 13)
        ExpedieLeLabel1.TabIndex = 136
        ExpedieLeLabel1.Text = "Sorti Le:"
        '
        'TicketLeLabel
        '
        TicketLeLabel.AutoSize = True
        TicketLeLabel.Location = New System.Drawing.Point(10, 22)
        TicketLeLabel.Name = "TicketLeLabel"
        TicketLeLabel.Size = New System.Drawing.Size(55, 13)
        TicketLeLabel.TabIndex = 137
        TicketLeLabel.Text = "Ticket Le:"
        '
        'FactureLeLabel1
        '
        FactureLeLabel1.AutoSize = True
        FactureLeLabel1.Location = New System.Drawing.Point(10, 48)
        FactureLeLabel1.Name = "FactureLeLabel1"
        FactureLeLabel1.Size = New System.Drawing.Size(101, 13)
        FactureLeLabel1.TabIndex = 138
        FactureLeLabel1.Text = "Facture imprimee le:"
        '
        'ExpeditionNumsuiviLabel
        '
        ExpeditionNumsuiviLabel.AutoSize = True
        ExpeditionNumsuiviLabel.Location = New System.Drawing.Point(11, 40)
        ExpeditionNumsuiviLabel.Name = "ExpeditionNumsuiviLabel"
        ExpeditionNumsuiviLabel.Size = New System.Drawing.Size(105, 13)
        ExpeditionNumsuiviLabel.TabIndex = 140
        ExpeditionNumsuiviLabel.Text = "Expedition Numsuivi:"
        '
        'MobileLabel
        '
        MobileLabel.AutoSize = True
        MobileLabel.Location = New System.Drawing.Point(432, 226)
        MobileLabel.Name = "MobileLabel"
        MobileLabel.Size = New System.Drawing.Size(41, 13)
        MobileLabel.TabIndex = 179
        MobileLabel.Text = "Mobile:"
        '
        'FaxLabel
        '
        FaxLabel.AutoSize = True
        FaxLabel.Location = New System.Drawing.Point(252, 226)
        FaxLabel.Name = "FaxLabel"
        FaxLabel.Size = New System.Drawing.Size(27, 13)
        FaxLabel.TabIndex = 177
        FaxLabel.Text = "Fax:"
        '
        'TelLabel
        '
        TelLabel.AutoSize = True
        TelLabel.Location = New System.Drawing.Point(64, 226)
        TelLabel.Name = "TelLabel"
        TelLabel.Size = New System.Drawing.Size(25, 13)
        TelLabel.TabIndex = 176
        TelLabel.Text = "Tel:"
        '
        'PaysLabel
        '
        PaysLabel.AutoSize = True
        PaysLabel.Location = New System.Drawing.Point(432, 200)
        PaysLabel.Name = "PaysLabel"
        PaysLabel.Size = New System.Drawing.Size(33, 13)
        PaysLabel.TabIndex = 174
        PaysLabel.Text = "Pays:"
        '
        'VilleLabel
        '
        VilleLabel.AutoSize = True
        VilleLabel.Location = New System.Drawing.Point(250, 200)
        VilleLabel.Name = "VilleLabel"
        VilleLabel.Size = New System.Drawing.Size(29, 13)
        VilleLabel.TabIndex = 172
        VilleLabel.Text = "Ville:"
        '
        'CodePostalLabel
        '
        CodePostalLabel.AutoSize = True
        CodePostalLabel.Location = New System.Drawing.Point(22, 200)
        CodePostalLabel.Name = "CodePostalLabel"
        CodePostalLabel.Size = New System.Drawing.Size(67, 13)
        CodePostalLabel.TabIndex = 170
        CodePostalLabel.Text = "Code Postal:"
        '
        'AdresseL3Label
        '
        AdresseL3Label.AutoSize = True
        AdresseL3Label.Location = New System.Drawing.Point(26, 174)
        AdresseL3Label.Name = "AdresseL3Label"
        AdresseL3Label.Size = New System.Drawing.Size(63, 13)
        AdresseL3Label.TabIndex = 168
        AdresseL3Label.Text = "Adresse L3:"
        '
        'AdresseL2Label
        '
        AdresseL2Label.AutoSize = True
        AdresseL2Label.Location = New System.Drawing.Point(26, 148)
        AdresseL2Label.Name = "AdresseL2Label"
        AdresseL2Label.Size = New System.Drawing.Size(63, 13)
        AdresseL2Label.TabIndex = 166
        AdresseL2Label.Text = "Adresse L2:"
        '
        'AdresseL1Label
        '
        AdresseL1Label.AutoSize = True
        AdresseL1Label.Location = New System.Drawing.Point(26, 122)
        AdresseL1Label.Name = "AdresseL1Label"
        AdresseL1Label.Size = New System.Drawing.Size(63, 13)
        AdresseL1Label.TabIndex = 165
        AdresseL1Label.Text = "Adresse L1:"
        '
        'ID_EtatCommandeVenteLabel
        '
        ID_EtatCommandeVenteLabel.AutoSize = True
        ID_EtatCommandeVenteLabel.Location = New System.Drawing.Point(247, 22)
        ID_EtatCommandeVenteLabel.Name = "ID_EtatCommandeVenteLabel"
        ID_EtatCommandeVenteLabel.Size = New System.Drawing.Size(26, 13)
        ID_EtatCommandeVenteLabel.TabIndex = 162
        ID_EtatCommandeVenteLabel.Text = "Etat"
        '
        'PrénomLabel
        '
        PrénomLabel.AutoSize = True
        PrénomLabel.Location = New System.Drawing.Point(251, 96)
        PrénomLabel.Name = "PrénomLabel"
        PrénomLabel.Size = New System.Drawing.Size(46, 13)
        PrénomLabel.TabIndex = 160
        PrénomLabel.Text = "Prénom:"
        '
        'NomLabel
        '
        NomLabel.AutoSize = True
        NomLabel.Location = New System.Drawing.Point(57, 96)
        NomLabel.Name = "NomLabel"
        NomLabel.Size = New System.Drawing.Size(32, 13)
        NomLabel.TabIndex = 158
        NomLabel.Text = "Nom:"
        '
        'LabelCodeClient
        '
        LabelCodeClient.AutoSize = True
        LabelCodeClient.Location = New System.Drawing.Point(25, 48)
        LabelCodeClient.Name = "LabelCodeClient"
        LabelCodeClient.Size = New System.Drawing.Size(64, 13)
        LabelCodeClient.TabIndex = 155
        LabelCodeClient.Text = "Code Client:"
        '
        'SociétéLabel
        '
        SociétéLabel.AutoSize = True
        SociétéLabel.Location = New System.Drawing.Point(43, 74)
        SociétéLabel.Name = "SociétéLabel"
        SociétéLabel.Size = New System.Drawing.Size(46, 13)
        SociétéLabel.TabIndex = 156
        SociétéLabel.Text = "Société:"
        '
        'ID_T_CommandeVenteLabel
        '
        ID_T_CommandeVenteLabel.AutoSize = True
        ID_T_CommandeVenteLabel.Location = New System.Drawing.Point(11, 22)
        ID_T_CommandeVenteLabel.Name = "ID_T_CommandeVenteLabel"
        ID_T_CommandeVenteLabel.Size = New System.Drawing.Size(78, 13)
        ID_T_CommandeVenteLabel.TabIndex = 154
        ID_T_CommandeVenteLabel.Text = "N° Commande:"
        '
        'Commentaires_factureLabel
        '
        Commentaires_factureLabel.AutoSize = True
        Commentaires_factureLabel.Location = New System.Drawing.Point(443, 16)
        Commentaires_factureLabel.Name = "Commentaires_factureLabel"
        Commentaires_factureLabel.Size = New System.Drawing.Size(112, 13)
        Commentaires_factureLabel.TabIndex = 139
        Commentaires_factureLabel.Text = "Commentaires facture:"
        '
        'Label20
        '
        Label20.AutoSize = True
        Label20.Location = New System.Drawing.Point(476, 22)
        Label20.Name = "Label20"
        Label20.Size = New System.Drawing.Size(119, 13)
        Label20.TabIndex = 2
        Label20.Text = "Montant Encaisse TTC:"
        '
        'NoTVALabel
        '
        NoTVALabel.AutoSize = True
        NoTVALabel.Location = New System.Drawing.Point(249, 74)
        NoTVALabel.Name = "NoTVALabel"
        NoTVALabel.Size = New System.Drawing.Size(48, 13)
        NoTVALabel.TabIndex = 180
        NoTVALabel.Text = "No TVA:"
        '
        'NoSiretLabel
        '
        NoSiretLabel.AutoSize = True
        NoSiretLabel.Location = New System.Drawing.Point(432, 74)
        NoSiretLabel.Name = "NoSiretLabel"
        NoSiretLabel.Size = New System.Drawing.Size(48, 13)
        NoSiretLabel.TabIndex = 181
        NoSiretLabel.Text = "No Siret:"
        '
        'VuAvecLabel
        '
        VuAvecLabel.AutoSize = True
        VuAvecLabel.Location = New System.Drawing.Point(228, 48)
        VuAvecLabel.Name = "VuAvecLabel"
        VuAvecLabel.Size = New System.Drawing.Size(51, 13)
        VuAvecLabel.TabIndex = 181
        VuAvecLabel.Text = "Vu Avec:"
        '
        'CommentairesCommandeLabel
        '
        CommentairesCommandeLabel.AutoSize = True
        CommentairesCommandeLabel.Location = New System.Drawing.Point(630, 22)
        CommentairesCommandeLabel.Name = "CommentairesCommandeLabel"
        CommentairesCommandeLabel.Size = New System.Drawing.Size(76, 13)
        CommentairesCommandeLabel.TabIndex = 182
        CommentairesCommandeLabel.Text = "Commentaires:"
        '
        'ExpeditionLeLabel
        '
        ExpeditionLeLabel.AutoSize = True
        ExpeditionLeLabel.Location = New System.Drawing.Point(42, 18)
        ExpeditionLeLabel.Name = "ExpeditionLeLabel"
        ExpeditionLeLabel.Size = New System.Drawing.Size(74, 13)
        ExpeditionLeLabel.TabIndex = 141
        ExpeditionLeLabel.Text = "Expedition Le:"
        '
        'Id_T_TransporteurLabel
        '
        Id_T_TransporteurLabel.AutoSize = True
        Id_T_TransporteurLabel.Location = New System.Drawing.Point(24, 62)
        Id_T_TransporteurLabel.Name = "Id_T_TransporteurLabel"
        Id_T_TransporteurLabel.Size = New System.Drawing.Size(70, 13)
        Id_T_TransporteurLabel.TabIndex = 142
        Id_T_TransporteurLabel.Text = "Transporteur:"
        '
        'EtatSynchroPrestashopLabel
        '
        EtatSynchroPrestashopLabel.AutoSize = True
        EtatSynchroPrestashopLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        EtatSynchroPrestashopLabel.Location = New System.Drawing.Point(947, 184)
        EtatSynchroPrestashopLabel.Name = "EtatSynchroPrestashopLabel"
        EtatSynchroPrestashopLabel.Size = New System.Drawing.Size(127, 13)
        EtatSynchroPrestashopLabel.TabIndex = 169
        EtatSynchroPrestashopLabel.Text = "Etat Synchro Prestashop:"
        '
        'T_CommandeVente_LigneBindingSource
        '
        Me.T_CommandeVente_LigneBindingSource.DataMember = "T_CommandeVente_Ligne"
        Me.T_CommandeVente_LigneBindingSource.DataSource = Me.CLIDataSet
        '
        'CLIDataSet
        '
        Me.CLIDataSet.DataSetName = "CLIDataSet"
        Me.CLIDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'T_CommandeVenteBindingSource
        '
        Me.T_CommandeVenteBindingSource.DataMember = "T_CommandeVente"
        Me.T_CommandeVenteBindingSource.DataSource = Me.CLIDataSet
        '
        'V_reglementBindingSource
        '
        Me.V_reglementBindingSource.DataMember = "V_reglement"
        Me.V_reglementBindingSource.DataSource = Me.CLIDataSet
        '
        'V_chequecadeau_clientBindingSource
        '
        Me.V_chequecadeau_clientBindingSource.DataMember = "V_chequecadeau_client"
        Me.V_chequecadeau_clientBindingSource.DataSource = Me.CLIDataSet
        '
        'V_Avoir_clientBindingSource
        '
        Me.V_Avoir_clientBindingSource.DataMember = "V_Avoir_client"
        Me.V_Avoir_clientBindingSource.DataSource = Me.CLIDataSet
        '
        'VreglementBindingSource
        '
        Me.VreglementBindingSource.DataMember = "V_reglement"
        Me.VreglementBindingSource.DataSource = Me.CLIDataSet
        '
        'TReglementBindingSource
        '
        Me.TReglementBindingSource.DataMember = "T_Reglement"
        Me.TReglementBindingSource.DataSource = Me.CLIDataSet
        '
        'T_ReglementBindingSource
        '
        Me.T_ReglementBindingSource.DataMember = "FK_T_Reglement_T_CommandeVente"
        Me.T_ReglementBindingSource.DataSource = Me.T_CommandeVenteBindingSource
        '
        'TabControl1
        '
        Me.TabControl1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TabControl1.Controls.Add(Me.TabCommande)
        Me.TabControl1.Controls.Add(Me.TabReglement)
        Me.TabControl1.Location = New System.Drawing.Point(3, 77)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(1328, 989)
        Me.TabControl1.TabIndex = 0
        '
        'TabCommande
        '
        Me.TabCommande.AutoScroll = True
        Me.TabCommande.Controls.Add(Me.I_IdPanierPrestashop)
        Me.TabCommande.Controls.Add(Me.Label33)
        Me.TabCommande.Controls.Add(Me.I_IdCommandePrestashop)
        Me.TabCommande.Controls.Add(Me.I_ReferenceCommandePrestashop)
        Me.TabCommande.Controls.Add(Me.Label32)
        Me.TabCommande.Controls.Add(Me.BT_DetailSynchro)
        Me.TabCommande.Controls.Add(Me.I_EtatSynchroPrestashop)
        Me.TabCommande.Controls.Add(EtatSynchroPrestashopLabel)
        Me.TabCommande.Controls.Add(Me.I_Caisse)
        Me.TabCommande.Controls.Add(Me.Label31)
        Me.TabCommande.Controls.Add(Me.Label30)
        Me.TabCommande.Controls.Add(Me.I_Total_TTC_avantDeduction)
        Me.TabCommande.Controls.Add(Me.DevisReportViewer)
        Me.TabCommande.Controls.Add(Me.BT_Imprimer_reservation)
        Me.TabCommande.Controls.Add(Me.BT_Imprimer_devis)
        Me.TabCommande.Controls.Add(Me.GroupBoxCodesSpeciaux)
        Me.TabCommande.Controls.Add(Me.BT_Imprimer_test)
        Me.TabCommande.Controls.Add(Me.BT_AnnulerCommande)
        Me.TabCommande.Controls.Add(Me.EnteteGroupBox)
        Me.TabCommande.Controls.Add(Me.BT_Scan)
        Me.TabCommande.Controls.Add(Me.BT_Etape_Règlement)
        Me.TabCommande.Controls.Add(Me.BT_Enregistrer)
        Me.TabCommande.Controls.Add(ModifieLeLabel)
        Me.TabCommande.Controls.Add(Me.ModifieLeTextBox)
        Me.TabCommande.Controls.Add(ModifieParLabel)
        Me.TabCommande.Controls.Add(Me.ModifieParTextBox)
        Me.TabCommande.Controls.Add(CreeLeLabel)
        Me.TabCommande.Controls.Add(Me.CreeLeTextBox)
        Me.TabCommande.Controls.Add(Me.CreeParTextBox)
        Me.TabCommande.Controls.Add(Me.GroupBoxAjout)
        Me.TabCommande.Controls.Add(Me.Label5)
        Me.TabCommande.Controls.Add(Me.Label3)
        Me.TabCommande.Controls.Add(Me.Label16)
        Me.TabCommande.Controls.Add(Me.Label2)
        Me.TabCommande.Controls.Add(Me.Label1)
        Me.TabCommande.Controls.Add(Me.LabelTotalCommandeHT)
        Me.TabCommande.Controls.Add(Me.I_TotalTTC)
        Me.TabCommande.Controls.Add(Me.I_MontantDeduire)
        Me.TabCommande.Controls.Add(Me.I_TVA196)
        Me.TabCommande.Controls.Add(Me.I_TVA55)
        Me.TabCommande.Controls.Add(Me.I_TotalHT)
        Me.TabCommande.Controls.Add(Me.LabelArticles)
        Me.TabCommande.Controls.Add(Me.DataGridViewCommande)
        Me.TabCommande.Controls.Add(Me.ToolStrip)
        Me.TabCommande.Location = New System.Drawing.Point(4, 22)
        Me.TabCommande.Name = "TabCommande"
        Me.TabCommande.Padding = New System.Windows.Forms.Padding(3)
        Me.TabCommande.Size = New System.Drawing.Size(1320, 963)
        Me.TabCommande.TabIndex = 0
        Me.TabCommande.Text = "1 - Commande"
        Me.TabCommande.UseVisualStyleBackColor = True
        '
        'I_IdPanierPrestashop
        '
        Me.I_IdPanierPrestashop.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.T_CommandeVenteBindingSource, "IdPanierPrestashopp", True))
        Me.I_IdPanierPrestashop.Location = New System.Drawing.Point(950, 313)
        Me.I_IdPanierPrestashop.Name = "I_IdPanierPrestashop"
        Me.I_IdPanierPrestashop.ReadOnly = True
        Me.I_IdPanierPrestashop.Size = New System.Drawing.Size(100, 20)
        Me.I_IdPanierPrestashop.TabIndex = 176
        Me.I_IdPanierPrestashop.TabStop = False
        Me.I_IdPanierPrestashop.Tag = "1"
        '
        'Label33
        '
        Me.Label33.AutoSize = True
        Me.Label33.Location = New System.Drawing.Point(947, 297)
        Me.Label33.Name = "Label33"
        Me.Label33.Size = New System.Drawing.Size(93, 13)
        Me.Label33.TabIndex = 175
        Me.Label33.Text = "Panier Prestashop"
        '
        'I_IdCommandePrestashop
        '
        Me.I_IdCommandePrestashop.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.T_CommandeVenteBindingSource, "IdCommandePrestashop", True))
        Me.I_IdCommandePrestashop.Location = New System.Drawing.Point(1056, 275)
        Me.I_IdCommandePrestashop.Name = "I_IdCommandePrestashop"
        Me.I_IdCommandePrestashop.ReadOnly = True
        Me.I_IdCommandePrestashop.Size = New System.Drawing.Size(100, 20)
        Me.I_IdCommandePrestashop.TabIndex = 174
        Me.I_IdCommandePrestashop.TabStop = False
        Me.I_IdCommandePrestashop.Tag = "1"
        '
        'I_ReferenceCommandePrestashop
        '
        Me.I_ReferenceCommandePrestashop.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.T_CommandeVenteBindingSource, "ReferenceCommandePrestashop", True))
        Me.I_ReferenceCommandePrestashop.Location = New System.Drawing.Point(950, 275)
        Me.I_ReferenceCommandePrestashop.Name = "I_ReferenceCommandePrestashop"
        Me.I_ReferenceCommandePrestashop.ReadOnly = True
        Me.I_ReferenceCommandePrestashop.Size = New System.Drawing.Size(100, 20)
        Me.I_ReferenceCommandePrestashop.TabIndex = 173
        Me.I_ReferenceCommandePrestashop.TabStop = False
        Me.I_ReferenceCommandePrestashop.Tag = "1"
        '
        'Label32
        '
        Me.Label32.AutoSize = True
        Me.Label32.Location = New System.Drawing.Point(947, 259)
        Me.Label32.Name = "Label32"
        Me.Label32.Size = New System.Drawing.Size(191, 13)
        Me.Label32.TabIndex = 172
        Me.Label32.Text = "Reference Commande Prestashop / ID"
        '
        'BT_DetailSynchro
        '
        Me.BT_DetailSynchro.Location = New System.Drawing.Point(950, 229)
        Me.BT_DetailSynchro.Name = "BT_DetailSynchro"
        Me.BT_DetailSynchro.Size = New System.Drawing.Size(75, 23)
        Me.BT_DetailSynchro.TabIndex = 171
        Me.BT_DetailSynchro.Text = "Detail"
        Me.BT_DetailSynchro.UseVisualStyleBackColor = True
        '
        'I_EtatSynchroPrestashop
        '
        Me.I_EtatSynchroPrestashop.Location = New System.Drawing.Point(950, 206)
        Me.I_EtatSynchroPrestashop.Name = "I_EtatSynchroPrestashop"
        Me.I_EtatSynchroPrestashop.ReadOnly = True
        Me.I_EtatSynchroPrestashop.Size = New System.Drawing.Size(100, 20)
        Me.I_EtatSynchroPrestashop.TabIndex = 170
        '
        'I_Caisse
        '
        Me.I_Caisse.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.T_CommandeVenteBindingSource, "numcaisse", True))
        Me.I_Caisse.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.I_Caisse.FormattingEnabled = True
        Me.I_Caisse.Items.AddRange(New Object() {"1", "2"})
        Me.I_Caisse.Location = New System.Drawing.Point(1000, 39)
        Me.I_Caisse.Margin = New System.Windows.Forms.Padding(2)
        Me.I_Caisse.Name = "I_Caisse"
        Me.I_Caisse.Size = New System.Drawing.Size(100, 21)
        Me.I_Caisse.TabIndex = 152
        Me.I_Caisse.Tag = "1"
        '
        'Label31
        '
        Me.Label31.AutoSize = True
        Me.Label31.Location = New System.Drawing.Point(955, 43)
        Me.Label31.Name = "Label31"
        Me.Label31.Size = New System.Drawing.Size(38, 13)
        Me.Label31.TabIndex = 150
        Me.Label31.Text = "Caisse"
        '
        'Label30
        '
        Me.Label30.AutoSize = True
        Me.Label30.Location = New System.Drawing.Point(776, 633)
        Me.Label30.Name = "Label30"
        Me.Label30.Size = New System.Drawing.Size(58, 13)
        Me.Label30.TabIndex = 149
        Me.Label30.Text = "Total TTC:"
        '
        'I_Total_TTC_avantDeduction
        '
        Me.I_Total_TTC_avantDeduction.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.T_CommandeVenteBindingSource, "Total_TTC_avantDeduction", True, System.Windows.Forms.DataSourceUpdateMode.OnValidation, Nothing, "C2"))
        Me.I_Total_TTC_avantDeduction.Location = New System.Drawing.Point(835, 630)
        Me.I_Total_TTC_avantDeduction.Name = "I_Total_TTC_avantDeduction"
        Me.I_Total_TTC_avantDeduction.ReadOnly = True
        Me.I_Total_TTC_avantDeduction.Size = New System.Drawing.Size(100, 20)
        Me.I_Total_TTC_avantDeduction.TabIndex = 148
        Me.I_Total_TTC_avantDeduction.TabStop = False
        Me.I_Total_TTC_avantDeduction.Tag = "1"
        '
        'DevisReportViewer
        '
        ReportDataSource1.Name = "CLIDataSet_T_CommandeVente_Ligne"
        ReportDataSource1.Value = Me.T_CommandeVente_LigneBindingSource
        ReportDataSource2.Name = "CLIDataSet_T_CommandeVente"
        ReportDataSource2.Value = Me.T_CommandeVenteBindingSource
        ReportDataSource3.Name = "CLIDataSet_V_reglement"
        ReportDataSource3.Value = Me.V_reglementBindingSource
        Me.DevisReportViewer.LocalReport.DataSources.Add(ReportDataSource1)
        Me.DevisReportViewer.LocalReport.DataSources.Add(ReportDataSource2)
        Me.DevisReportViewer.LocalReport.DataSources.Add(ReportDataSource3)
        Me.DevisReportViewer.LocalReport.ReportEmbeddedResource = "CLI.DevisVenteReport.rdlc"
        Me.DevisReportViewer.Location = New System.Drawing.Point(959, 554)
        Me.DevisReportViewer.Name = "DevisReportViewer"
        Me.DevisReportViewer.Size = New System.Drawing.Size(174, 96)
        Me.DevisReportViewer.TabIndex = 147
        Me.DevisReportViewer.Visible = False
        '
        'BT_Imprimer_reservation
        '
        Me.BT_Imprimer_reservation.Image = Global.CLI.My.Resources.Resources.jaune16
        Me.BT_Imprimer_reservation.Location = New System.Drawing.Point(464, 3)
        Me.BT_Imprimer_reservation.Name = "BT_Imprimer_reservation"
        Me.BT_Imprimer_reservation.Size = New System.Drawing.Size(109, 31)
        Me.BT_Imprimer_reservation.TabIndex = 3
        Me.BT_Imprimer_reservation.Text = "Enregistrer resa"
        Me.BT_Imprimer_reservation.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.BT_Imprimer_reservation.UseVisualStyleBackColor = True
        '
        'BT_Imprimer_devis
        '
        Me.BT_Imprimer_devis.Image = Global.CLI.My.Resources.Resources.orange16
        Me.BT_Imprimer_devis.Location = New System.Drawing.Point(346, 3)
        Me.BT_Imprimer_devis.Name = "BT_Imprimer_devis"
        Me.BT_Imprimer_devis.Size = New System.Drawing.Size(116, 31)
        Me.BT_Imprimer_devis.TabIndex = 2
        Me.BT_Imprimer_devis.Text = "Enregistrer devis"
        Me.BT_Imprimer_devis.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.BT_Imprimer_devis.UseVisualStyleBackColor = True
        '
        'GroupBoxCodesSpeciaux
        '
        Me.GroupBoxCodesSpeciaux.Controls.Add(Me.Label29)
        Me.GroupBoxCodesSpeciaux.Controls.Add(Me.Label26)
        Me.GroupBoxCodesSpeciaux.Controls.Add(Me.Label28)
        Me.GroupBoxCodesSpeciaux.Controls.Add(Me.Label27)
        Me.GroupBoxCodesSpeciaux.Controls.Add(Me.Label25)
        Me.GroupBoxCodesSpeciaux.Controls.Add(Me.Label24)
        Me.GroupBoxCodesSpeciaux.Controls.Add(Me.Label22)
        Me.GroupBoxCodesSpeciaux.Location = New System.Drawing.Point(9, 661)
        Me.GroupBoxCodesSpeciaux.Name = "GroupBoxCodesSpeciaux"
        Me.GroupBoxCodesSpeciaux.Size = New System.Drawing.Size(202, 119)
        Me.GroupBoxCodesSpeciaux.TabIndex = 139
        Me.GroupBoxCodesSpeciaux.TabStop = False
        Me.GroupBoxCodesSpeciaux.Text = "Codes spéciaux"
        '
        'Label29
        '
        Me.Label29.AutoSize = True
        Me.Label29.Location = New System.Drawing.Point(4, 95)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(98, 13)
        Me.Label29.TabIndex = 1
        Me.Label29.Text = "6 : Chèque cadeau"
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.Location = New System.Drawing.Point(4, 82)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(80, 13)
        Me.Label26.TabIndex = 0
        Me.Label26.Text = "5 : Frais de port"
        '
        'Label28
        '
        Me.Label28.AutoSize = True
        Me.Label28.Location = New System.Drawing.Point(4, 69)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(185, 13)
        Me.Label28.TabIndex = 0
        Me.Label28.Text = "4 : Commission sur dépôt vente/ avoir"
        '
        'Label27
        '
        Me.Label27.AutoSize = True
        Me.Label27.Location = New System.Drawing.Point(4, 56)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(63, 13)
        Me.Label27.TabIndex = 0
        Me.Label27.Text = "3 : Location"
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.Location = New System.Drawing.Point(4, 43)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(74, 13)
        Me.Label25.TabIndex = 0
        Me.Label25.Text = "2 : Réparation"
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.Location = New System.Drawing.Point(4, 30)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(100, 13)
        Me.Label24.TabIndex = 0
        Me.Label24.Text = "1 : Reprise magasin"
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Location = New System.Drawing.Point(4, 16)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(87, 13)
        Me.Label22.TabIndex = 0
        Me.Label22.Text = "0 : Vente diverse"
        '
        'BT_Imprimer_test
        '
        Me.BT_Imprimer_test.Image = Global.CLI.My.Resources.Resources.rouge16
        Me.BT_Imprimer_test.Location = New System.Drawing.Point(204, 3)
        Me.BT_Imprimer_test.Name = "BT_Imprimer_test"
        Me.BT_Imprimer_test.Size = New System.Drawing.Size(136, 31)
        Me.BT_Imprimer_test.TabIndex = 1
        Me.BT_Imprimer_test.Text = "Enregistrer Test"
        Me.BT_Imprimer_test.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.BT_Imprimer_test.UseVisualStyleBackColor = True
        '
        'BT_AnnulerCommande
        '
        Me.BT_AnnulerCommande.Image = Global.CLI.My.Resources.Resources.DeleteHS
        Me.BT_AnnulerCommande.Location = New System.Drawing.Point(897, 3)
        Me.BT_AnnulerCommande.Name = "BT_AnnulerCommande"
        Me.BT_AnnulerCommande.Size = New System.Drawing.Size(100, 31)
        Me.BT_AnnulerCommande.TabIndex = 6
        Me.BT_AnnulerCommande.Text = "Annuler !"
        Me.BT_AnnulerCommande.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.BT_AnnulerCommande.UseVisualStyleBackColor = True
        '
        'EnteteGroupBox
        '
        Me.EnteteGroupBox.Controls.Add(Me.I_Vpc_on)
        Me.EnteteGroupBox.Controls.Add(Me.BT_BL)
        Me.EnteteGroupBox.Controls.Add(Me.BT_Imprimer)
        Me.EnteteGroupBox.Controls.Add(Me.BT_Envoi_etat_commande)
        Me.EnteteGroupBox.Controls.Add(CommentairesCommandeLabel)
        Me.EnteteGroupBox.Controls.Add(Me.CommentairesCommandeTextBox)
        Me.EnteteGroupBox.Controls.Add(VuAvecLabel)
        Me.EnteteGroupBox.Controls.Add(Me.VuAvecTextBox)
        Me.EnteteGroupBox.Controls.Add(NoSiretLabel)
        Me.EnteteGroupBox.Controls.Add(Me.NoSiretTextBox)
        Me.EnteteGroupBox.Controls.Add(NoTVALabel)
        Me.EnteteGroupBox.Controls.Add(Me.NoTVATextBox)
        Me.EnteteGroupBox.Controls.Add(Me.ExportCheckBox)
        Me.EnteteGroupBox.Controls.Add(Me.PaysComboBox)
        Me.EnteteGroupBox.Controls.Add(Me.EtatLibelleTextBox)
        Me.EnteteGroupBox.Controls.Add(Me.EmailTextBox)
        Me.EnteteGroupBox.Controls.Add(MobileLabel)
        Me.EnteteGroupBox.Controls.Add(Me.MobileTextBox)
        Me.EnteteGroupBox.Controls.Add(FaxLabel)
        Me.EnteteGroupBox.Controls.Add(Me.FaxTextBox)
        Me.EnteteGroupBox.Controls.Add(EmailLabel)
        Me.EnteteGroupBox.Controls.Add(TelLabel)
        Me.EnteteGroupBox.Controls.Add(Me.TelTextBox)
        Me.EnteteGroupBox.Controls.Add(PaysLabel)
        Me.EnteteGroupBox.Controls.Add(VilleLabel)
        Me.EnteteGroupBox.Controls.Add(Me.VilleTextBox)
        Me.EnteteGroupBox.Controls.Add(CodePostalLabel)
        Me.EnteteGroupBox.Controls.Add(Me.CodePostalTextBox)
        Me.EnteteGroupBox.Controls.Add(AdresseL3Label)
        Me.EnteteGroupBox.Controls.Add(Me.AdresseL3TextBox)
        Me.EnteteGroupBox.Controls.Add(AdresseL2Label)
        Me.EnteteGroupBox.Controls.Add(Me.AdresseL2TextBox)
        Me.EnteteGroupBox.Controls.Add(AdresseL1Label)
        Me.EnteteGroupBox.Controls.Add(Me.AdresseL1TextBox)
        Me.EnteteGroupBox.Controls.Add(Me.I_Web)
        Me.EnteteGroupBox.Controls.Add(ID_EtatCommandeVenteLabel)
        Me.EnteteGroupBox.Controls.Add(PrénomLabel)
        Me.EnteteGroupBox.Controls.Add(Me.PrénomTextBox)
        Me.EnteteGroupBox.Controls.Add(NomLabel)
        Me.EnteteGroupBox.Controls.Add(Me.NomTextBox)
        Me.EnteteGroupBox.Controls.Add(LabelCodeClient)
        Me.EnteteGroupBox.Controls.Add(SociétéLabel)
        Me.EnteteGroupBox.Controls.Add(Me.CodeClientTextBox)
        Me.EnteteGroupBox.Controls.Add(Me.SociétéTextBox)
        Me.EnteteGroupBox.Controls.Add(ID_T_CommandeVenteLabel)
        Me.EnteteGroupBox.Controls.Add(Me.ID_T_CommandeVenteTextBox)
        Me.EnteteGroupBox.Location = New System.Drawing.Point(6, 39)
        Me.EnteteGroupBox.Name = "EnteteGroupBox"
        Me.EnteteGroupBox.Size = New System.Drawing.Size(918, 291)
        Me.EnteteGroupBox.TabIndex = 0
        Me.EnteteGroupBox.TabStop = False
        Me.EnteteGroupBox.Text = "Entête de commande"
        '
        'I_Vpc_on
        '
        Me.I_Vpc_on.DataBindings.Add(New System.Windows.Forms.Binding("CheckState", Me.T_CommandeVenteBindingSource, "vpc_on", True))
        Me.I_Vpc_on.Location = New System.Drawing.Point(486, 17)
        Me.I_Vpc_on.Name = "I_Vpc_on"
        Me.I_Vpc_on.Size = New System.Drawing.Size(69, 24)
        Me.I_Vpc_on.TabIndex = 185
        Me.I_Vpc_on.Text = "Vpc Mag"
        Me.I_Vpc_on.UseVisualStyleBackColor = True
        '
        'BT_BL
        '
        Me.BT_BL.Image = Global.CLI.My.Resources.Resources.PrintHS
        Me.BT_BL.Location = New System.Drawing.Point(816, 246)
        Me.BT_BL.Name = "BT_BL"
        Me.BT_BL.Size = New System.Drawing.Size(93, 25)
        Me.BT_BL.TabIndex = 184
        Me.BT_BL.Text = "Bon livraison"
        Me.BT_BL.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.BT_BL.UseVisualStyleBackColor = True
        '
        'BT_Imprimer
        '
        Me.BT_Imprimer.Image = Global.CLI.My.Resources.Resources.PrintHS
        Me.BT_Imprimer.Location = New System.Drawing.Point(726, 246)
        Me.BT_Imprimer.Name = "BT_Imprimer"
        Me.BT_Imprimer.Size = New System.Drawing.Size(87, 25)
        Me.BT_Imprimer.TabIndex = 184
        Me.BT_Imprimer.Text = "Imprimer"
        Me.BT_Imprimer.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.BT_Imprimer.UseVisualStyleBackColor = True
        '
        'BT_Envoi_etat_commande
        '
        Me.BT_Envoi_etat_commande.Image = Global.CLI.My.Resources.Resources.EnvelopeHS
        Me.BT_Envoi_etat_commande.Location = New System.Drawing.Point(633, 246)
        Me.BT_Envoi_etat_commande.Name = "BT_Envoi_etat_commande"
        Me.BT_Envoi_etat_commande.Size = New System.Drawing.Size(87, 25)
        Me.BT_Envoi_etat_commande.TabIndex = 184
        Me.BT_Envoi_etat_commande.Text = "Envoi email "
        Me.BT_Envoi_etat_commande.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.BT_Envoi_etat_commande.UseVisualStyleBackColor = True
        '
        'CommentairesCommandeTextBox
        '
        Me.CommentairesCommandeTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.T_CommandeVenteBindingSource, "CommentairesCommande", True))
        Me.CommentairesCommandeTextBox.Location = New System.Drawing.Point(633, 48)
        Me.CommentairesCommandeTextBox.MaxLength = 255
        Me.CommentairesCommandeTextBox.Multiline = True
        Me.CommentairesCommandeTextBox.Name = "CommentairesCommandeTextBox"
        Me.CommentairesCommandeTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.CommentairesCommandeTextBox.Size = New System.Drawing.Size(255, 195)
        Me.CommentairesCommandeTextBox.TabIndex = 183
        '
        'VuAvecTextBox
        '
        Me.VuAvecTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.T_CommandeVenteBindingSource, "VuAvec", True))
        Me.VuAvecTextBox.Location = New System.Drawing.Point(285, 45)
        Me.VuAvecTextBox.MaxLength = 255
        Me.VuAvecTextBox.Name = "VuAvecTextBox"
        Me.VuAvecTextBox.Size = New System.Drawing.Size(123, 20)
        Me.VuAvecTextBox.TabIndex = 182
        '
        'NoSiretTextBox
        '
        Me.NoSiretTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.T_CommandeVenteBindingSource, "NoSiret", True))
        Me.NoSiretTextBox.Location = New System.Drawing.Point(486, 71)
        Me.NoSiretTextBox.Name = "NoSiretTextBox"
        Me.NoSiretTextBox.Size = New System.Drawing.Size(122, 20)
        Me.NoSiretTextBox.TabIndex = 6
        '
        'NoTVATextBox
        '
        Me.NoTVATextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.T_CommandeVenteBindingSource, "NoTVA", True))
        Me.NoTVATextBox.Location = New System.Drawing.Point(303, 71)
        Me.NoTVATextBox.Name = "NoTVATextBox"
        Me.NoTVATextBox.Size = New System.Drawing.Size(123, 20)
        Me.NoTVATextBox.TabIndex = 5
        '
        'ExportCheckBox
        '
        Me.ExportCheckBox.DataBindings.Add(New System.Windows.Forms.Binding("CheckState", Me.T_CommandeVenteBindingSource, "export", True))
        Me.ExportCheckBox.Location = New System.Drawing.Point(486, 43)
        Me.ExportCheckBox.Name = "ExportCheckBox"
        Me.ExportCheckBox.Size = New System.Drawing.Size(104, 24)
        Me.ExportCheckBox.TabIndex = 180
        Me.ExportCheckBox.Text = "Export"
        Me.ExportCheckBox.UseVisualStyleBackColor = True
        '
        'PaysComboBox
        '
        Me.PaysComboBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.T_CommandeVenteBindingSource, "Pays", True))
        Me.PaysComboBox.DataBindings.Add(New System.Windows.Forms.Binding("SelectedValue", Me.T_CommandeVenteBindingSource, "Pays", True))
        Me.PaysComboBox.DataSource = Me.TPaysBindingSource
        Me.PaysComboBox.DisplayMember = "Libelle"
        Me.PaysComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.PaysComboBox.FormattingEnabled = True
        Me.PaysComboBox.Location = New System.Drawing.Point(484, 196)
        Me.PaysComboBox.Name = "PaysComboBox"
        Me.PaysComboBox.Size = New System.Drawing.Size(123, 21)
        Me.PaysComboBox.TabIndex = 14
        Me.PaysComboBox.ValueMember = "Libelle"
        '
        'TPaysBindingSource
        '
        Me.TPaysBindingSource.DataMember = "T_Pays"
        Me.TPaysBindingSource.DataSource = Me.CLIDataSet
        '
        'EtatLibelleTextBox
        '
        Me.EtatLibelleTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.TEtatCommandeVenteBindingSource, "Libelle", True))
        Me.EtatLibelleTextBox.Location = New System.Drawing.Point(285, 19)
        Me.EtatLibelleTextBox.Name = "EtatLibelleTextBox"
        Me.EtatLibelleTextBox.ReadOnly = True
        Me.EtatLibelleTextBox.Size = New System.Drawing.Size(123, 20)
        Me.EtatLibelleTextBox.TabIndex = 1
        Me.EtatLibelleTextBox.TabStop = False
        Me.EtatLibelleTextBox.Tag = "1"
        '
        'TEtatCommandeVenteBindingSource
        '
        Me.TEtatCommandeVenteBindingSource.DataMember = "T_EtatCommandeVente"
        Me.TEtatCommandeVenteBindingSource.DataSource = Me.CLIDataSet
        '
        'EmailTextBox
        '
        Me.EmailTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.T_CommandeVenteBindingSource, "Email", True))
        Me.EmailTextBox.Location = New System.Drawing.Point(95, 249)
        Me.EmailTextBox.MaxLength = 255
        Me.EmailTextBox.Name = "EmailTextBox"
        Me.EmailTextBox.Size = New System.Drawing.Size(253, 20)
        Me.EmailTextBox.TabIndex = 18
        '
        'MobileTextBox
        '
        Me.MobileTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.T_CommandeVenteBindingSource, "Mobile", True))
        Me.MobileTextBox.Location = New System.Drawing.Point(484, 223)
        Me.MobileTextBox.MaxLength = 255
        Me.MobileTextBox.Name = "MobileTextBox"
        Me.MobileTextBox.Size = New System.Drawing.Size(123, 20)
        Me.MobileTextBox.TabIndex = 17
        '
        'FaxTextBox
        '
        Me.FaxTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.T_CommandeVenteBindingSource, "Fax", True))
        Me.FaxTextBox.Location = New System.Drawing.Point(285, 223)
        Me.FaxTextBox.MaxLength = 255
        Me.FaxTextBox.Name = "FaxTextBox"
        Me.FaxTextBox.Size = New System.Drawing.Size(141, 20)
        Me.FaxTextBox.TabIndex = 16
        '
        'TelTextBox
        '
        Me.TelTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.T_CommandeVenteBindingSource, "Tel", True))
        Me.TelTextBox.Location = New System.Drawing.Point(95, 223)
        Me.TelTextBox.MaxLength = 255
        Me.TelTextBox.Name = "TelTextBox"
        Me.TelTextBox.Size = New System.Drawing.Size(147, 20)
        Me.TelTextBox.TabIndex = 15
        '
        'VilleTextBox
        '
        Me.VilleTextBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.VilleTextBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource
        Me.VilleTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.T_CommandeVenteBindingSource, "Ville", True))
        Me.VilleTextBox.Location = New System.Drawing.Point(285, 197)
        Me.VilleTextBox.MaxLength = 255
        Me.VilleTextBox.Name = "VilleTextBox"
        Me.VilleTextBox.Size = New System.Drawing.Size(141, 20)
        Me.VilleTextBox.TabIndex = 13
        '
        'CodePostalTextBox
        '
        Me.CodePostalTextBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.CodePostalTextBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource
        Me.CodePostalTextBox.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.CodePostalTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.T_CommandeVenteBindingSource, "CodePostal", True))
        Me.CodePostalTextBox.Location = New System.Drawing.Point(95, 197)
        Me.CodePostalTextBox.MaxLength = 255
        Me.CodePostalTextBox.Name = "CodePostalTextBox"
        Me.CodePostalTextBox.Size = New System.Drawing.Size(147, 20)
        Me.CodePostalTextBox.TabIndex = 12
        '
        'AdresseL3TextBox
        '
        Me.AdresseL3TextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.T_CommandeVenteBindingSource, "AdresseL3", True))
        Me.AdresseL3TextBox.Location = New System.Drawing.Point(95, 171)
        Me.AdresseL3TextBox.MaxLength = 35
        Me.AdresseL3TextBox.Name = "AdresseL3TextBox"
        Me.AdresseL3TextBox.Size = New System.Drawing.Size(513, 20)
        Me.AdresseL3TextBox.TabIndex = 11
        '
        'AdresseL2TextBox
        '
        Me.AdresseL2TextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.T_CommandeVenteBindingSource, "AdresseL2", True))
        Me.AdresseL2TextBox.Location = New System.Drawing.Point(95, 145)
        Me.AdresseL2TextBox.MaxLength = 35
        Me.AdresseL2TextBox.Name = "AdresseL2TextBox"
        Me.AdresseL2TextBox.Size = New System.Drawing.Size(513, 20)
        Me.AdresseL2TextBox.TabIndex = 10
        '
        'AdresseL1TextBox
        '
        Me.AdresseL1TextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.T_CommandeVenteBindingSource, "AdresseL1", True))
        Me.AdresseL1TextBox.Location = New System.Drawing.Point(95, 119)
        Me.AdresseL1TextBox.MaxLength = 35
        Me.AdresseL1TextBox.Name = "AdresseL1TextBox"
        Me.AdresseL1TextBox.Size = New System.Drawing.Size(513, 20)
        Me.AdresseL1TextBox.TabIndex = 9
        '
        'I_Web
        '
        Me.I_Web.AutoSize = True
        Me.I_Web.DataBindings.Add(New System.Windows.Forms.Binding("Checked", Me.T_CommandeVenteBindingSource, "Web_on", True))
        Me.I_Web.Enabled = False
        Me.I_Web.Location = New System.Drawing.Point(561, 20)
        Me.I_Web.Name = "I_Web"
        Me.I_Web.Size = New System.Drawing.Size(49, 17)
        Me.I_Web.TabIndex = 2
        Me.I_Web.Tag = "1"
        Me.I_Web.Text = "Web"
        Me.I_Web.UseVisualStyleBackColor = True
        '
        'PrénomTextBox
        '
        Me.PrénomTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.T_CommandeVenteBindingSource, "Prénom", True))
        Me.PrénomTextBox.Location = New System.Drawing.Point(303, 93)
        Me.PrénomTextBox.MaxLength = 255
        Me.PrénomTextBox.Name = "PrénomTextBox"
        Me.PrénomTextBox.Size = New System.Drawing.Size(123, 20)
        Me.PrénomTextBox.TabIndex = 8
        '
        'NomTextBox
        '
        Me.NomTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.T_CommandeVenteBindingSource, "Nom", True))
        Me.NomTextBox.Location = New System.Drawing.Point(95, 93)
        Me.NomTextBox.MaxLength = 255
        Me.NomTextBox.Name = "NomTextBox"
        Me.NomTextBox.Size = New System.Drawing.Size(150, 20)
        Me.NomTextBox.TabIndex = 7
        '
        'CodeClientTextBox
        '
        Me.CodeClientTextBox.ContextMenuStrip = Me.ContextMenuStripClient
        Me.CodeClientTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.T_CommandeVenteBindingSource, "ID_T_Client", True))
        Me.CodeClientTextBox.Location = New System.Drawing.Point(95, 45)
        Me.CodeClientTextBox.Name = "CodeClientTextBox"
        Me.CodeClientTextBox.Size = New System.Drawing.Size(100, 20)
        Me.CodeClientTextBox.TabIndex = 3
        '
        'ContextMenuStripClient
        '
        Me.ContextMenuStripClient.ImageScalingSize = New System.Drawing.Size(32, 32)
        Me.ContextMenuStripClient.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripMenuItem1})
        Me.ContextMenuStripClient.Name = "ContextMenuStripArticle"
        Me.ContextMenuStripClient.Size = New System.Drawing.Size(150, 42)
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.Image = Global.CLI.My.Resources.Resources.ActualSizeHS
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(149, 38)
        Me.ToolStripMenuItem1.Text = "Rechercher"
        '
        'SociétéTextBox
        '
        Me.SociétéTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.T_CommandeVenteBindingSource, "Société", True))
        Me.SociétéTextBox.Location = New System.Drawing.Point(95, 71)
        Me.SociétéTextBox.MaxLength = 255
        Me.SociétéTextBox.Name = "SociétéTextBox"
        Me.SociétéTextBox.Size = New System.Drawing.Size(150, 20)
        Me.SociétéTextBox.TabIndex = 4
        '
        'ID_T_CommandeVenteTextBox
        '
        Me.ID_T_CommandeVenteTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.T_CommandeVenteBindingSource, "ID_T_CommandeVente", True))
        Me.ID_T_CommandeVenteTextBox.Location = New System.Drawing.Point(95, 19)
        Me.ID_T_CommandeVenteTextBox.Name = "ID_T_CommandeVenteTextBox"
        Me.ID_T_CommandeVenteTextBox.ReadOnly = True
        Me.ID_T_CommandeVenteTextBox.Size = New System.Drawing.Size(100, 20)
        Me.ID_T_CommandeVenteTextBox.TabIndex = 0
        Me.ID_T_CommandeVenteTextBox.TabStop = False
        Me.ID_T_CommandeVenteTextBox.Tag = "1"
        '
        'BT_Scan
        '
        Me.BT_Scan.Image = Global.CLI.My.Resources.Resources.AddTableHS
        Me.BT_Scan.Location = New System.Drawing.Point(101, 3)
        Me.BT_Scan.Name = "BT_Scan"
        Me.BT_Scan.Size = New System.Drawing.Size(87, 31)
        Me.BT_Scan.TabIndex = 0
        Me.BT_Scan.Text = "Mode Scan"
        Me.BT_Scan.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.BT_Scan.UseVisualStyleBackColor = True
        '
        'BT_Etape_Règlement
        '
        Me.BT_Etape_Règlement.Image = Global.CLI.My.Resources.Resources.GoToNextHS
        Me.BT_Etape_Règlement.Location = New System.Drawing.Point(733, 3)
        Me.BT_Etape_Règlement.Name = "BT_Etape_Règlement"
        Me.BT_Etape_Règlement.Size = New System.Drawing.Size(135, 31)
        Me.BT_Etape_Règlement.TabIndex = 5
        Me.BT_Etape_Règlement.Text = "Passer au règlement"
        Me.BT_Etape_Règlement.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.BT_Etape_Règlement.UseVisualStyleBackColor = True
        '
        'BT_Enregistrer
        '
        Me.BT_Enregistrer.Image = Global.CLI.My.Resources.Resources.vert16
        Me.BT_Enregistrer.Location = New System.Drawing.Point(579, 3)
        Me.BT_Enregistrer.Name = "BT_Enregistrer"
        Me.BT_Enregistrer.Size = New System.Drawing.Size(148, 31)
        Me.BT_Enregistrer.TabIndex = 4
        Me.BT_Enregistrer.Text = "Enregistrer commande"
        Me.BT_Enregistrer.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.BT_Enregistrer.UseVisualStyleBackColor = True
        '
        'ModifieLeTextBox
        '
        Me.ModifieLeTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.T_CommandeVenteBindingSource, "ModifieLe", True))
        Me.ModifieLeTextBox.Location = New System.Drawing.Point(1000, 142)
        Me.ModifieLeTextBox.Name = "ModifieLeTextBox"
        Me.ModifieLeTextBox.ReadOnly = True
        Me.ModifieLeTextBox.Size = New System.Drawing.Size(100, 20)
        Me.ModifieLeTextBox.TabIndex = 138
        Me.ModifieLeTextBox.TabStop = False
        Me.ModifieLeTextBox.Tag = "1"
        '
        'ModifieParTextBox
        '
        Me.ModifieParTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.T_CommandeVenteBindingSource, "ModifiePar", True))
        Me.ModifieParTextBox.Location = New System.Drawing.Point(1000, 116)
        Me.ModifieParTextBox.Name = "ModifieParTextBox"
        Me.ModifieParTextBox.ReadOnly = True
        Me.ModifieParTextBox.Size = New System.Drawing.Size(100, 20)
        Me.ModifieParTextBox.TabIndex = 137
        Me.ModifieParTextBox.TabStop = False
        Me.ModifieParTextBox.Tag = "1"
        '
        'CreeLeTextBox
        '
        Me.CreeLeTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.T_CommandeVenteBindingSource, "CreeLe", True))
        Me.CreeLeTextBox.Location = New System.Drawing.Point(1000, 93)
        Me.CreeLeTextBox.Name = "CreeLeTextBox"
        Me.CreeLeTextBox.ReadOnly = True
        Me.CreeLeTextBox.Size = New System.Drawing.Size(100, 20)
        Me.CreeLeTextBox.TabIndex = 136
        Me.CreeLeTextBox.TabStop = False
        Me.CreeLeTextBox.Tag = "1"
        '
        'CreeParTextBox
        '
        Me.CreeParTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.T_CommandeVenteBindingSource, "CreePar", True))
        Me.CreeParTextBox.Location = New System.Drawing.Point(1000, 67)
        Me.CreeParTextBox.Name = "CreeParTextBox"
        Me.CreeParTextBox.ReadOnly = True
        Me.CreeParTextBox.Size = New System.Drawing.Size(100, 20)
        Me.CreeParTextBox.TabIndex = 135
        Me.CreeParTextBox.TabStop = False
        Me.CreeParTextBox.Tag = "1"
        '
        'GroupBoxAjout
        '
        Me.GroupBoxAjout.Controls.Add(Me.I_NomBeneficiaire)
        Me.GroupBoxAjout.Controls.Add(Me.IL_codebenef)
        Me.GroupBoxAjout.Controls.Add(Me.I_ChequeCadeauIdClient)
        Me.GroupBoxAjout.Controls.Add(Me.Label6)
        Me.GroupBoxAjout.Controls.Add(Me.BT_ClearTampon)
        Me.GroupBoxAjout.Controls.Add(Me.I_Ref)
        Me.GroupBoxAjout.Controls.Add(Me.BT_Plus)
        Me.GroupBoxAjout.Controls.Add(Me.I_Designation)
        Me.GroupBoxAjout.Controls.Add(Me.Label10)
        Me.GroupBoxAjout.Controls.Add(Me.I_PuTTC)
        Me.GroupBoxAjout.Controls.Add(Me.Label11)
        Me.GroupBoxAjout.Controls.Add(Me.I_Remise)
        Me.GroupBoxAjout.Controls.Add(Me.Label9)
        Me.GroupBoxAjout.Controls.Add(Me.I_TVA)
        Me.GroupBoxAjout.Controls.Add(Me.Label4)
        Me.GroupBoxAjout.Controls.Add(Me.I_PUTTCRemise)
        Me.GroupBoxAjout.Controls.Add(Me.Label8)
        Me.GroupBoxAjout.Controls.Add(Me.I_Qte)
        Me.GroupBoxAjout.Controls.Add(Me.Label7)
        Me.GroupBoxAjout.Location = New System.Drawing.Point(9, 553)
        Me.GroupBoxAjout.Name = "GroupBoxAjout"
        Me.GroupBoxAjout.Size = New System.Drawing.Size(583, 106)
        Me.GroupBoxAjout.TabIndex = 2
        Me.GroupBoxAjout.TabStop = False
        Me.GroupBoxAjout.Text = "Ajout / modification d'une ligne"
        '
        'I_NomBeneficiaire
        '
        Me.I_NomBeneficiaire.Location = New System.Drawing.Point(256, 77)
        Me.I_NomBeneficiaire.Name = "I_NomBeneficiaire"
        Me.I_NomBeneficiaire.Size = New System.Drawing.Size(128, 20)
        Me.I_NomBeneficiaire.TabIndex = 136
        Me.I_NomBeneficiaire.Visible = False
        '
        'IL_codebenef
        '
        Me.IL_codebenef.AutoSize = True
        Me.IL_codebenef.Location = New System.Drawing.Point(68, 61)
        Me.IL_codebenef.Name = "IL_codebenef"
        Me.IL_codebenef.Size = New System.Drawing.Size(117, 13)
        Me.IL_codebenef.TabIndex = 135
        Me.IL_codebenef.Text = "Code client bénéficiaire"
        Me.IL_codebenef.Visible = False
        '
        'I_ChequeCadeauIdClient
        '
        Me.I_ChequeCadeauIdClient.ContextMenuStrip = Me.ContextMenuStripClient
        Me.I_ChequeCadeauIdClient.Location = New System.Drawing.Point(71, 77)
        Me.I_ChequeCadeauIdClient.Name = "I_ChequeCadeauIdClient"
        Me.I_ChequeCadeauIdClient.Size = New System.Drawing.Size(179, 20)
        Me.I_ChequeCadeauIdClient.TabIndex = 2
        Me.I_ChequeCadeauIdClient.Visible = False
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(6, 16)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(24, 13)
        Me.Label6.TabIndex = 133
        Me.Label6.Text = "Ref"
        '
        'BT_ClearTampon
        '
        Me.BT_ClearTampon.Image = Global.CLI.My.Resources.Resources.DeleteHS
        Me.BT_ClearTampon.Location = New System.Drawing.Point(547, 33)
        Me.BT_ClearTampon.Name = "BT_ClearTampon"
        Me.BT_ClearTampon.Size = New System.Drawing.Size(27, 28)
        Me.BT_ClearTampon.TabIndex = 9
        Me.BT_ClearTampon.UseVisualStyleBackColor = True
        '
        'I_Ref
        '
        Me.I_Ref.ContextMenuStrip = Me.ContextMenuStripArticle
        Me.I_Ref.Location = New System.Drawing.Point(6, 38)
        Me.I_Ref.Name = "I_Ref"
        Me.I_Ref.Size = New System.Drawing.Size(59, 20)
        Me.I_Ref.TabIndex = 0
        '
        'ContextMenuStripArticle
        '
        Me.ContextMenuStripArticle.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.RechercherToolStripMenuItem})
        Me.ContextMenuStripArticle.Name = "ContextMenuStripArticle"
        Me.ContextMenuStripArticle.Size = New System.Drawing.Size(134, 26)
        '
        'RechercherToolStripMenuItem
        '
        Me.RechercherToolStripMenuItem.Image = Global.CLI.My.Resources.Resources.ActualSizeHS
        Me.RechercherToolStripMenuItem.Name = "RechercherToolStripMenuItem"
        Me.RechercherToolStripMenuItem.Size = New System.Drawing.Size(133, 22)
        Me.RechercherToolStripMenuItem.Text = "Rechercher"
        '
        'BT_Plus
        '
        Me.BT_Plus.Image = Global.CLI.My.Resources.Resources.AddTableHS
        Me.BT_Plus.Location = New System.Drawing.Point(514, 33)
        Me.BT_Plus.Name = "BT_Plus"
        Me.BT_Plus.Size = New System.Drawing.Size(27, 28)
        Me.BT_Plus.TabIndex = 8
        Me.BT_Plus.Text = "+"
        Me.BT_Plus.UseVisualStyleBackColor = True
        '
        'I_Designation
        '
        Me.I_Designation.Location = New System.Drawing.Point(71, 38)
        Me.I_Designation.MaxLength = 255
        Me.I_Designation.Name = "I_Designation"
        Me.I_Designation.Size = New System.Drawing.Size(179, 20)
        Me.I_Designation.TabIndex = 1
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(342, 16)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(42, 13)
        Me.Label10.TabIndex = 133
        Me.Label10.Text = "Remise"
        '
        'I_PuTTC
        '
        Me.I_PuTTC.Location = New System.Drawing.Point(288, 38)
        Me.I_PuTTC.Name = "I_PuTTC"
        Me.I_PuTTC.Size = New System.Drawing.Size(51, 20)
        Me.I_PuTTC.TabIndex = 4
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(389, 16)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(71, 13)
        Me.Label11.TabIndex = 133
        Me.Label11.Text = "PU TTC Rem"
        '
        'I_Remise
        '
        Me.I_Remise.Location = New System.Drawing.Point(345, 38)
        Me.I_Remise.Name = "I_Remise"
        Me.I_Remise.Size = New System.Drawing.Size(39, 20)
        Me.I_Remise.TabIndex = 5
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(285, 16)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(46, 13)
        Me.Label9.TabIndex = 133
        Me.Label9.Text = "PU TTC"
        '
        'I_TVA
        '
        Me.I_TVA.Location = New System.Drawing.Point(459, 38)
        Me.I_TVA.Name = "I_TVA"
        Me.I_TVA.Size = New System.Drawing.Size(39, 20)
        Me.I_TVA.TabIndex = 7
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(464, 16)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(28, 13)
        Me.Label4.TabIndex = 133
        Me.Label4.Text = "TVA"
        '
        'I_PUTTCRemise
        '
        Me.I_PUTTCRemise.Location = New System.Drawing.Point(392, 38)
        Me.I_PUTTCRemise.Name = "I_PUTTCRemise"
        Me.I_PUTTCRemise.Size = New System.Drawing.Size(61, 20)
        Me.I_PUTTCRemise.TabIndex = 6
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(253, 16)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(24, 13)
        Me.Label8.TabIndex = 133
        Me.Label8.Text = "Qté"
        '
        'I_Qte
        '
        Me.I_Qte.Location = New System.Drawing.Point(256, 38)
        Me.I_Qte.Name = "I_Qte"
        Me.I_Qte.Size = New System.Drawing.Size(26, 20)
        Me.I_Qte.TabIndex = 3
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(68, 16)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(63, 13)
        Me.Label7.TabIndex = 133
        Me.Label7.Text = "Designation"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(947, 68)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(47, 13)
        Me.Label5.TabIndex = 131
        Me.Label5.Text = "Vendeur"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(704, 694)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(125, 13)
        Me.Label3.TabIndex = 129
        Me.Label3.Text = "Montant net à payer:"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(738, 664)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(96, 13)
        Me.Label16.TabIndex = 129
        Me.Label16.Text = "Montant à déduire:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(780, 605)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(54, 13)
        Me.Label2.TabIndex = 129
        Me.Label2.Text = "TVA 20%:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(777, 579)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(57, 13)
        Me.Label1.TabIndex = 129
        Me.Label1.Text = "TVA 5.5%:"
        '
        'LabelTotalCommandeHT
        '
        Me.LabelTotalCommandeHT.AutoSize = True
        Me.LabelTotalCommandeHT.Location = New System.Drawing.Point(782, 553)
        Me.LabelTotalCommandeHT.Name = "LabelTotalCommandeHT"
        Me.LabelTotalCommandeHT.Size = New System.Drawing.Size(52, 13)
        Me.LabelTotalCommandeHT.TabIndex = 129
        Me.LabelTotalCommandeHT.Text = "Total HT:"
        '
        'I_TotalTTC
        '
        Me.I_TotalTTC.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.T_CommandeVenteBindingSource, "Total_TTC", True, System.Windows.Forms.DataSourceUpdateMode.OnValidation, Nothing, "C2"))
        Me.I_TotalTTC.ForeColor = System.Drawing.SystemColors.WindowText
        Me.I_TotalTTC.Location = New System.Drawing.Point(835, 691)
        Me.I_TotalTTC.Name = "I_TotalTTC"
        Me.I_TotalTTC.ReadOnly = True
        Me.I_TotalTTC.Size = New System.Drawing.Size(100, 20)
        Me.I_TotalTTC.TabIndex = 128
        Me.I_TotalTTC.TabStop = False
        Me.I_TotalTTC.Tag = "1"
        '
        'I_MontantDeduire
        '
        Me.I_MontantDeduire.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.T_CommandeVenteBindingSource, "montant_deduire", True, System.Windows.Forms.DataSourceUpdateMode.OnValidation, Nothing, "C2"))
        Me.I_MontantDeduire.Location = New System.Drawing.Point(835, 661)
        Me.I_MontantDeduire.Name = "I_MontantDeduire"
        Me.I_MontantDeduire.ReadOnly = True
        Me.I_MontantDeduire.Size = New System.Drawing.Size(100, 20)
        Me.I_MontantDeduire.TabIndex = 128
        Me.I_MontantDeduire.TabStop = False
        Me.I_MontantDeduire.Tag = "1"
        '
        'I_TVA196
        '
        Me.I_TVA196.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.T_CommandeVenteBindingSource, "Total_196", True, System.Windows.Forms.DataSourceUpdateMode.OnValidation, Nothing, "C2"))
        Me.I_TVA196.Location = New System.Drawing.Point(835, 602)
        Me.I_TVA196.Name = "I_TVA196"
        Me.I_TVA196.ReadOnly = True
        Me.I_TVA196.Size = New System.Drawing.Size(100, 20)
        Me.I_TVA196.TabIndex = 128
        Me.I_TVA196.TabStop = False
        Me.I_TVA196.Tag = "1"
        '
        'I_TVA55
        '
        Me.I_TVA55.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.T_CommandeVenteBindingSource, "Total_55", True, System.Windows.Forms.DataSourceUpdateMode.OnValidation, Nothing, "C2"))
        Me.I_TVA55.Location = New System.Drawing.Point(835, 576)
        Me.I_TVA55.Name = "I_TVA55"
        Me.I_TVA55.ReadOnly = True
        Me.I_TVA55.Size = New System.Drawing.Size(100, 20)
        Me.I_TVA55.TabIndex = 128
        Me.I_TVA55.TabStop = False
        Me.I_TVA55.Tag = "1"
        '
        'I_TotalHT
        '
        Me.I_TotalHT.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.T_CommandeVenteBindingSource, "Total_HT", True, System.Windows.Forms.DataSourceUpdateMode.OnValidation, Nothing, "C2"))
        Me.I_TotalHT.Location = New System.Drawing.Point(835, 550)
        Me.I_TotalHT.Name = "I_TotalHT"
        Me.I_TotalHT.ReadOnly = True
        Me.I_TotalHT.Size = New System.Drawing.Size(100, 20)
        Me.I_TotalHT.TabIndex = 128
        Me.I_TotalHT.TabStop = False
        Me.I_TotalHT.Tag = "1"
        '
        'LabelArticles
        '
        Me.LabelArticles.AutoSize = True
        Me.LabelArticles.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelArticles.Location = New System.Drawing.Point(6, 313)
        Me.LabelArticles.Name = "LabelArticles"
        Me.LabelArticles.Size = New System.Drawing.Size(49, 13)
        Me.LabelArticles.TabIndex = 1
        Me.LabelArticles.Text = "Articles"
        '
        'DataGridViewCommande
        '
        Me.DataGridViewCommande.AllowUserToAddRows = False
        Me.DataGridViewCommande.AllowUserToResizeColumns = False
        Me.DataGridViewCommande.AllowUserToResizeRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.DataGridViewCommande.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.DataGridViewCommande.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DataGridViewCommande.AutoGenerateColumns = False
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridViewCommande.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.DataGridViewCommande.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridViewCommande.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ID_T_CommandeVenteLigne, Me.ID_T_CommandeVente, Me.Ref, Me.Designation, Me.Qte, Me.prix_vente_initial_HT, Me.TVA, Me.PUinitialTTC, Me.Remise, Me.PUremiseTTC, Me.prix_total_HT, Me.TotalLigne})
        Me.DataGridViewCommande.DataSource = Me.TCommandeVenteLigneBindingSource
        DataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle9.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        DataGridViewCellStyle9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DataGridViewCommande.DefaultCellStyle = DataGridViewCellStyle9
        Me.DataGridViewCommande.Location = New System.Drawing.Point(8, 337)
        Me.DataGridViewCommande.Name = "DataGridViewCommande"
        Me.DataGridViewCommande.ReadOnly = True
        DataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle10.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle10.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle10.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle10.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle10.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridViewCommande.RowHeadersDefaultCellStyle = DataGridViewCellStyle10
        Me.DataGridViewCommande.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DataGridViewCommande.Size = New System.Drawing.Size(1539, 205)
        Me.DataGridViewCommande.TabIndex = 121
        '
        'ID_T_CommandeVenteLigne
        '
        Me.ID_T_CommandeVenteLigne.DataPropertyName = "ID_T_CommandeVente_Ligne"
        Me.ID_T_CommandeVenteLigne.HeaderText = "ID_T_CommandeVente_Ligne"
        Me.ID_T_CommandeVenteLigne.Name = "ID_T_CommandeVenteLigne"
        Me.ID_T_CommandeVenteLigne.ReadOnly = True
        Me.ID_T_CommandeVenteLigne.Visible = False
        '
        'ID_T_CommandeVente
        '
        Me.ID_T_CommandeVente.DataPropertyName = "ID_T_CommandeVente"
        Me.ID_T_CommandeVente.HeaderText = "ID_T_CommandeVente"
        Me.ID_T_CommandeVente.Name = "ID_T_CommandeVente"
        Me.ID_T_CommandeVente.ReadOnly = True
        Me.ID_T_CommandeVente.Visible = False
        '
        'Ref
        '
        Me.Ref.DataPropertyName = "ID_t_article_version"
        Me.Ref.HeaderText = "Ref"
        Me.Ref.Name = "Ref"
        Me.Ref.ReadOnly = True
        '
        'Designation
        '
        Me.Designation.DataPropertyName = "description_panier"
        Me.Designation.HeaderText = "Designation"
        Me.Designation.Name = "Designation"
        Me.Designation.ReadOnly = True
        Me.Designation.Width = 200
        '
        'Qte
        '
        Me.Qte.DataPropertyName = "Qte"
        Me.Qte.HeaderText = "Qte"
        Me.Qte.Name = "Qte"
        Me.Qte.ReadOnly = True
        '
        'prix_vente_initial_HT
        '
        Me.prix_vente_initial_HT.DataPropertyName = "prix_vente_initial_HT"
        DataGridViewCellStyle3.Format = "C2"
        Me.prix_vente_initial_HT.DefaultCellStyle = DataGridViewCellStyle3
        Me.prix_vente_initial_HT.HeaderText = "PU HT"
        Me.prix_vente_initial_HT.Name = "prix_vente_initial_HT"
        Me.prix_vente_initial_HT.ReadOnly = True
        '
        'TVA
        '
        Me.TVA.DataPropertyName = "Code_tva"
        DataGridViewCellStyle4.Format = "N2"
        DataGridViewCellStyle4.NullValue = Nothing
        Me.TVA.DefaultCellStyle = DataGridViewCellStyle4
        Me.TVA.HeaderText = "TVA"
        Me.TVA.Name = "TVA"
        Me.TVA.ReadOnly = True
        '
        'PUinitialTTC
        '
        Me.PUinitialTTC.DataPropertyName = "prix_vente_initial_TTC"
        DataGridViewCellStyle5.Format = "C2"
        DataGridViewCellStyle5.NullValue = Nothing
        Me.PUinitialTTC.DefaultCellStyle = DataGridViewCellStyle5
        Me.PUinitialTTC.HeaderText = "PU TTC"
        Me.PUinitialTTC.Name = "PUinitialTTC"
        Me.PUinitialTTC.ReadOnly = True
        '
        'Remise
        '
        Me.Remise.DataPropertyName = "remise"
        Me.Remise.HeaderText = "Remise"
        Me.Remise.Name = "Remise"
        Me.Remise.ReadOnly = True
        '
        'PUremiseTTC
        '
        Me.PUremiseTTC.DataPropertyName = "prix_vente_remise_TTC"
        DataGridViewCellStyle6.Format = "C2"
        DataGridViewCellStyle6.NullValue = Nothing
        Me.PUremiseTTC.DefaultCellStyle = DataGridViewCellStyle6
        Me.PUremiseTTC.HeaderText = "PU Rem TTC"
        Me.PUremiseTTC.Name = "PUremiseTTC"
        Me.PUremiseTTC.ReadOnly = True
        Me.PUremiseTTC.Visible = False
        '
        'prix_total_HT
        '
        Me.prix_total_HT.DataPropertyName = "prix_total_HT"
        DataGridViewCellStyle7.Format = "C2"
        Me.prix_total_HT.DefaultCellStyle = DataGridViewCellStyle7
        Me.prix_total_HT.HeaderText = "Montant HT"
        Me.prix_total_HT.Name = "prix_total_HT"
        Me.prix_total_HT.ReadOnly = True
        Me.prix_total_HT.Visible = False
        '
        'TotalLigne
        '
        Me.TotalLigne.DataPropertyName = "prix_total_TTC"
        DataGridViewCellStyle8.Format = "C2"
        DataGridViewCellStyle8.NullValue = Nothing
        Me.TotalLigne.DefaultCellStyle = DataGridViewCellStyle8
        Me.TotalLigne.HeaderText = "Montant TTC"
        Me.TotalLigne.Name = "TotalLigne"
        Me.TotalLigne.ReadOnly = True
        '
        'TCommandeVenteLigneBindingSource
        '
        Me.TCommandeVenteLigneBindingSource.DataMember = "T_CommandeVente_Ligne"
        Me.TCommandeVenteLigneBindingSource.DataSource = Me.CLIDataSet
        '
        'ToolStrip
        '
        Me.ToolStrip.Dock = System.Windows.Forms.DockStyle.None
        Me.ToolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStrip.ImageScalingSize = New System.Drawing.Size(32, 32)
        Me.ToolStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.NouveauToolStripButton, Me.ToolStripButton2, Me.ToolStripSeparator2, Me.CopierGeneToolStripButton, Me.CollerGeneToolStripButton, Me.ToolStripSeparator3, Me.SupprimerToolStripButton, Me.ToolStripButton5})
        Me.ToolStrip.Location = New System.Drawing.Point(3, 3)
        Me.ToolStrip.Name = "ToolStrip"
        Me.ToolStrip.Size = New System.Drawing.Size(26, 25)
        Me.ToolStrip.TabIndex = 120
        Me.ToolStrip.Text = "ToolStrip3"
        '
        'NouveauToolStripButton
        '
        Me.NouveauToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.NouveauToolStripButton.Image = CType(resources.GetObject("NouveauToolStripButton.Image"), System.Drawing.Image)
        Me.NouveauToolStripButton.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.NouveauToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.NouveauToolStripButton.Name = "NouveauToolStripButton"
        Me.NouveauToolStripButton.Size = New System.Drawing.Size(23, 22)
        Me.NouveauToolStripButton.Text = "&Nouvelle Fiche Générale"
        Me.NouveauToolStripButton.ToolTipText = "Nouveau"
        '
        'ToolStripButton2
        '
        Me.ToolStripButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton2.Image = CType(resources.GetObject("ToolStripButton2.Image"), System.Drawing.Image)
        Me.ToolStripButton2.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.ToolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton2.Name = "ToolStripButton2"
        Me.ToolStripButton2.Size = New System.Drawing.Size(23, 36)
        Me.ToolStripButton2.Text = "&Imprimer"
        Me.ToolStripButton2.Visible = False
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 39)
        Me.ToolStripSeparator2.Visible = False
        '
        'CopierGeneToolStripButton
        '
        Me.CopierGeneToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.CopierGeneToolStripButton.Image = CType(resources.GetObject("CopierGeneToolStripButton.Image"), System.Drawing.Image)
        Me.CopierGeneToolStripButton.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.CopierGeneToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.CopierGeneToolStripButton.Name = "CopierGeneToolStripButton"
        Me.CopierGeneToolStripButton.Size = New System.Drawing.Size(23, 36)
        Me.CopierGeneToolStripButton.Text = "Co&pier une Fiche"
        Me.CopierGeneToolStripButton.Visible = False
        '
        'CollerGeneToolStripButton
        '
        Me.CollerGeneToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.CollerGeneToolStripButton.Enabled = False
        Me.CollerGeneToolStripButton.Image = CType(resources.GetObject("CollerGeneToolStripButton.Image"), System.Drawing.Image)
        Me.CollerGeneToolStripButton.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.CollerGeneToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.CollerGeneToolStripButton.Name = "CollerGeneToolStripButton"
        Me.CollerGeneToolStripButton.Size = New System.Drawing.Size(23, 36)
        Me.CollerGeneToolStripButton.Text = "Co&ller une Fiche"
        Me.CollerGeneToolStripButton.Visible = False
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(6, 39)
        Me.ToolStripSeparator3.Visible = False
        '
        'SupprimerToolStripButton
        '
        Me.SupprimerToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.SupprimerToolStripButton.Image = Global.CLI.My.Resources.Resources.DeleteHS
        Me.SupprimerToolStripButton.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.SupprimerToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.SupprimerToolStripButton.Name = "SupprimerToolStripButton"
        Me.SupprimerToolStripButton.Size = New System.Drawing.Size(23, 36)
        Me.SupprimerToolStripButton.Text = "Supprimer"
        Me.SupprimerToolStripButton.Visible = False
        '
        'ToolStripButton5
        '
        Me.ToolStripButton5.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton5.Image = CType(resources.GetObject("ToolStripButton5.Image"), System.Drawing.Image)
        Me.ToolStripButton5.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton5.Name = "ToolStripButton5"
        Me.ToolStripButton5.Size = New System.Drawing.Size(36, 36)
        Me.ToolStripButton5.Text = "&?"
        Me.ToolStripButton5.Visible = False
        '
        'TabReglement
        '
        Me.TabReglement.AutoScroll = True
        Me.TabReglement.Controls.Add(Me.ChequeCadeauReportViewer)
        Me.TabReglement.Controls.Add(Me.AvoirReportViewer)
        Me.TabReglement.Controls.Add(Me.FactureReportViewer)
        Me.TabReglement.Controls.Add(Me.ExpeditionGroupBox)
        Me.TabReglement.Controls.Add(Me.SortieStockGroupBox)
        Me.TabReglement.Controls.Add(Me.BT_OuvrirCaisse)
        Me.TabReglement.Controls.Add(Me.TicketFactureGroupBox)
        Me.TabReglement.Controls.Add(Me.BT_revenir_commande)
        Me.TabReglement.Controls.Add(Me.RenduGroupBox)
        Me.TabReglement.Controls.Add(Me.PaiementGroupBox)
        Me.TabReglement.Location = New System.Drawing.Point(4, 22)
        Me.TabReglement.Name = "TabReglement"
        Me.TabReglement.Padding = New System.Windows.Forms.Padding(3)
        Me.TabReglement.Size = New System.Drawing.Size(1320, 963)
        Me.TabReglement.TabIndex = 1
        Me.TabReglement.Text = "2 - Règlement"
        Me.TabReglement.UseVisualStyleBackColor = True
        '
        'ChequeCadeauReportViewer
        '
        ReportDataSource4.Name = "CLIDataSet_V_chequecadeau_client"
        ReportDataSource4.Value = Me.V_chequecadeau_clientBindingSource
        ReportDataSource5.Name = "CLIDataSet_T_CommandeVente"
        ReportDataSource5.Value = Me.T_CommandeVenteBindingSource
        Me.ChequeCadeauReportViewer.LocalReport.DataSources.Add(ReportDataSource4)
        Me.ChequeCadeauReportViewer.LocalReport.DataSources.Add(ReportDataSource5)
        Me.ChequeCadeauReportViewer.LocalReport.ReportEmbeddedResource = "CLI.ChequeCadeauReport.rdlc"
        Me.ChequeCadeauReportViewer.Location = New System.Drawing.Point(892, 384)
        Me.ChequeCadeauReportViewer.Name = "ChequeCadeauReportViewer"
        Me.ChequeCadeauReportViewer.Size = New System.Drawing.Size(414, 194)
        Me.ChequeCadeauReportViewer.TabIndex = 147
        Me.ChequeCadeauReportViewer.Visible = False
        '
        'AvoirReportViewer
        '
        ReportDataSource6.Name = "CLIDataSet_V_Avoir_client"
        ReportDataSource6.Value = Me.V_Avoir_clientBindingSource
        ReportDataSource7.Name = "CLIDataSet_T_CommandeVente"
        ReportDataSource7.Value = Me.T_CommandeVenteBindingSource
        Me.AvoirReportViewer.LocalReport.DataSources.Add(ReportDataSource6)
        Me.AvoirReportViewer.LocalReport.DataSources.Add(ReportDataSource7)
        Me.AvoirReportViewer.LocalReport.ReportEmbeddedResource = "CLI.AvoirVenteReport.rdlc"
        Me.AvoirReportViewer.Location = New System.Drawing.Point(509, 384)
        Me.AvoirReportViewer.Name = "AvoirReportViewer"
        Me.AvoirReportViewer.Size = New System.Drawing.Size(124, 109)
        Me.AvoirReportViewer.TabIndex = 146
        Me.AvoirReportViewer.Visible = False
        '
        'FactureReportViewer
        '
        ReportDataSource8.Name = "CLIDataSet_T_CommandeVente_Ligne"
        ReportDataSource8.Value = Me.T_CommandeVente_LigneBindingSource
        ReportDataSource9.Name = "CLIDataSet_T_CommandeVente"
        ReportDataSource9.Value = Me.T_CommandeVenteBindingSource
        ReportDataSource10.Name = "CLIDataSet_V_reglement"
        ReportDataSource10.Value = Me.VreglementBindingSource
        Me.FactureReportViewer.LocalReport.DataSources.Add(ReportDataSource8)
        Me.FactureReportViewer.LocalReport.DataSources.Add(ReportDataSource9)
        Me.FactureReportViewer.LocalReport.DataSources.Add(ReportDataSource10)
        Me.FactureReportViewer.LocalReport.ReportEmbeddedResource = "CLI.FactureVenteReport.rdlc"
        Me.FactureReportViewer.Location = New System.Drawing.Point(639, 388)
        Me.FactureReportViewer.Name = "FactureReportViewer"
        Me.FactureReportViewer.Size = New System.Drawing.Size(228, 123)
        Me.FactureReportViewer.TabIndex = 146
        Me.FactureReportViewer.Visible = False
        '
        'ExpeditionGroupBox
        '
        Me.ExpeditionGroupBox.Controls.Add(Id_T_TransporteurLabel)
        Me.ExpeditionGroupBox.Controls.Add(Me.Id_T_TransporteurComboBox)
        Me.ExpeditionGroupBox.Controls.Add(ExpeditionLeLabel)
        Me.ExpeditionGroupBox.Controls.Add(Me.ExpeditionLeTextBox)
        Me.ExpeditionGroupBox.Controls.Add(Me.BT_ReExpedier)
        Me.ExpeditionGroupBox.Controls.Add(Me.BT_Expedier)
        Me.ExpeditionGroupBox.Controls.Add(Me.BT_Etiquette)
        Me.ExpeditionGroupBox.Controls.Add(Me.ExpeditionNumsuiviTextBox)
        Me.ExpeditionGroupBox.Controls.Add(ExpeditionNumsuiviLabel)
        Me.ExpeditionGroupBox.Location = New System.Drawing.Point(458, 670)
        Me.ExpeditionGroupBox.Name = "ExpeditionGroupBox"
        Me.ExpeditionGroupBox.Size = New System.Drawing.Size(396, 180)
        Me.ExpeditionGroupBox.TabIndex = 3
        Me.ExpeditionGroupBox.TabStop = False
        Me.ExpeditionGroupBox.Text = "Expédition"
        '
        'Id_T_TransporteurComboBox
        '
        Me.Id_T_TransporteurComboBox.DataBindings.Add(New System.Windows.Forms.Binding("SelectedValue", Me.T_CommandeVenteBindingSource, "Id_T_Transporteur", True))
        Me.Id_T_TransporteurComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Id_T_TransporteurComboBox.FormattingEnabled = True
        Me.Id_T_TransporteurComboBox.Location = New System.Drawing.Point(122, 59)
        Me.Id_T_TransporteurComboBox.Name = "Id_T_TransporteurComboBox"
        Me.Id_T_TransporteurComboBox.Size = New System.Drawing.Size(121, 21)
        Me.Id_T_TransporteurComboBox.TabIndex = 143
        '
        'ExpeditionLeTextBox
        '
        Me.ExpeditionLeTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.T_CommandeVenteBindingSource, "ExpeditionLe", True))
        Me.ExpeditionLeTextBox.Location = New System.Drawing.Point(122, 15)
        Me.ExpeditionLeTextBox.Name = "ExpeditionLeTextBox"
        Me.ExpeditionLeTextBox.ReadOnly = True
        Me.ExpeditionLeTextBox.Size = New System.Drawing.Size(100, 20)
        Me.ExpeditionLeTextBox.TabIndex = 142
        Me.ExpeditionLeTextBox.Tag = "1"
        '
        'BT_ReExpedier
        '
        Me.BT_ReExpedier.Image = Global.CLI.My.Resources.Resources.TaskHS
        Me.BT_ReExpedier.Location = New System.Drawing.Point(132, 83)
        Me.BT_ReExpedier.Name = "BT_ReExpedier"
        Me.BT_ReExpedier.Size = New System.Drawing.Size(120, 22)
        Me.BT_ReExpedier.TabIndex = 1
        Me.BT_ReExpedier.Text = "5 - Re-Expédier"
        Me.BT_ReExpedier.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.BT_ReExpedier.UseVisualStyleBackColor = True
        '
        'BT_Expedier
        '
        Me.BT_Expedier.Image = Global.CLI.My.Resources.Resources.TaskHS
        Me.BT_Expedier.Location = New System.Drawing.Point(6, 83)
        Me.BT_Expedier.Name = "BT_Expedier"
        Me.BT_Expedier.Size = New System.Drawing.Size(120, 22)
        Me.BT_Expedier.TabIndex = 1
        Me.BT_Expedier.Text = "5 - Expédier"
        Me.BT_Expedier.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.BT_Expedier.UseVisualStyleBackColor = True
        '
        'BT_Etiquette
        '
        Me.BT_Etiquette.Image = Global.CLI.My.Resources.Resources.TaskHS
        Me.BT_Etiquette.Location = New System.Drawing.Point(253, 83)
        Me.BT_Etiquette.Name = "BT_Etiquette"
        Me.BT_Etiquette.Size = New System.Drawing.Size(123, 22)
        Me.BT_Etiquette.TabIndex = 141
        Me.BT_Etiquette.Text = "Imprimer étiquette"
        Me.BT_Etiquette.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.BT_Etiquette.UseVisualStyleBackColor = True
        '
        'ExpeditionNumsuiviTextBox
        '
        Me.ExpeditionNumsuiviTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.T_CommandeVenteBindingSource, "ExpeditionNumsuivi", True))
        Me.ExpeditionNumsuiviTextBox.Location = New System.Drawing.Point(122, 37)
        Me.ExpeditionNumsuiviTextBox.MaxLength = 255
        Me.ExpeditionNumsuiviTextBox.Name = "ExpeditionNumsuiviTextBox"
        Me.ExpeditionNumsuiviTextBox.Size = New System.Drawing.Size(100, 20)
        Me.ExpeditionNumsuiviTextBox.TabIndex = 0
        '
        'SortieStockGroupBox
        '
        Me.SortieStockGroupBox.Controls.Add(Me.BT_ImprimerChequeCadeau)
        Me.SortieStockGroupBox.Controls.Add(Me.BT_SortirStock)
        Me.SortieStockGroupBox.Controls.Add(Me.ExpedieLeTextBox)
        Me.SortieStockGroupBox.Controls.Add(ExpedieLeLabel1)
        Me.SortieStockGroupBox.Location = New System.Drawing.Point(37, 670)
        Me.SortieStockGroupBox.Name = "SortieStockGroupBox"
        Me.SortieStockGroupBox.Size = New System.Drawing.Size(399, 99)
        Me.SortieStockGroupBox.TabIndex = 3
        Me.SortieStockGroupBox.TabStop = False
        Me.SortieStockGroupBox.Text = "Sortie de stock"
        '
        'BT_ImprimerChequeCadeau
        '
        Me.BT_ImprimerChequeCadeau.Image = Global.CLI.My.Resources.Resources.TaskHS
        Me.BT_ImprimerChequeCadeau.Location = New System.Drawing.Point(235, 15)
        Me.BT_ImprimerChequeCadeau.Name = "BT_ImprimerChequeCadeau"
        Me.BT_ImprimerChequeCadeau.Size = New System.Drawing.Size(154, 26)
        Me.BT_ImprimerChequeCadeau.TabIndex = 148
        Me.BT_ImprimerChequeCadeau.Text = "Imprimer Chèque Cadeau"
        Me.BT_ImprimerChequeCadeau.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.BT_ImprimerChequeCadeau.UseVisualStyleBackColor = True
        '
        'BT_SortirStock
        '
        Me.BT_SortirStock.Image = Global.CLI.My.Resources.Resources.TaskHS
        Me.BT_SortirStock.Location = New System.Drawing.Point(110, 45)
        Me.BT_SortirStock.Name = "BT_SortirStock"
        Me.BT_SortirStock.Size = New System.Drawing.Size(120, 22)
        Me.BT_SortirStock.TabIndex = 1
        Me.BT_SortirStock.Text = "4- Sortie de stock"
        Me.BT_SortirStock.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.BT_SortirStock.UseVisualStyleBackColor = True
        '
        'ExpedieLeTextBox
        '
        Me.ExpedieLeTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.T_CommandeVenteBindingSource, "ExpedieLe", True))
        Me.ExpedieLeTextBox.Location = New System.Drawing.Point(110, 19)
        Me.ExpedieLeTextBox.Name = "ExpedieLeTextBox"
        Me.ExpedieLeTextBox.ReadOnly = True
        Me.ExpedieLeTextBox.Size = New System.Drawing.Size(100, 20)
        Me.ExpedieLeTextBox.TabIndex = 137
        Me.ExpedieLeTextBox.TabStop = False
        Me.ExpedieLeTextBox.Tag = "1"
        '
        'BT_OuvrirCaisse
        '
        Me.BT_OuvrirCaisse.Image = Global.CLI.My.Resources.Resources.RadialChartHS
        Me.BT_OuvrirCaisse.Location = New System.Drawing.Point(33, 6)
        Me.BT_OuvrirCaisse.Name = "BT_OuvrirCaisse"
        Me.BT_OuvrirCaisse.Size = New System.Drawing.Size(108, 31)
        Me.BT_OuvrirCaisse.TabIndex = 4
        Me.BT_OuvrirCaisse.Text = "Ouvrir la caisse"
        Me.BT_OuvrirCaisse.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.BT_OuvrirCaisse.UseVisualStyleBackColor = True
        '
        'TicketFactureGroupBox
        '
        Me.TicketFactureGroupBox.Controls.Add(Commentaires_factureLabel)
        Me.TicketFactureGroupBox.Controls.Add(Me.Commentaires_factureTextBox)
        Me.TicketFactureGroupBox.Controls.Add(Me.TicketLeTextBox)
        Me.TicketFactureGroupBox.Controls.Add(Me.BT_Ticket)
        Me.TicketFactureGroupBox.Controls.Add(Me.BT_Facture_Envoi)
        Me.TicketFactureGroupBox.Controls.Add(Me.BT_Facture)
        Me.TicketFactureGroupBox.Controls.Add(Label15)
        Me.TicketFactureGroupBox.Controls.Add(TicketLeLabel)
        Me.TicketFactureGroupBox.Controls.Add(FactureLeLabel1)
        Me.TicketFactureGroupBox.Controls.Add(Me.FactureLeTextBox)
        Me.TicketFactureGroupBox.Location = New System.Drawing.Point(37, 517)
        Me.TicketFactureGroupBox.Name = "TicketFactureGroupBox"
        Me.TicketFactureGroupBox.Size = New System.Drawing.Size(805, 147)
        Me.TicketFactureGroupBox.TabIndex = 2
        Me.TicketFactureGroupBox.TabStop = False
        Me.TicketFactureGroupBox.Text = "Ticket de caisse  / Facture"
        '
        'Commentaires_factureTextBox
        '
        Me.Commentaires_factureTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.T_CommandeVenteBindingSource, "Commentaires_facture", True))
        Me.Commentaires_factureTextBox.Location = New System.Drawing.Point(446, 45)
        Me.Commentaires_factureTextBox.Multiline = True
        Me.Commentaires_factureTextBox.Name = "Commentaires_factureTextBox"
        Me.Commentaires_factureTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.Commentaires_factureTextBox.Size = New System.Drawing.Size(310, 96)
        Me.Commentaires_factureTextBox.TabIndex = 140
        '
        'TicketLeTextBox
        '
        Me.TicketLeTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.T_CommandeVenteBindingSource, "TicketLe", True))
        Me.TicketLeTextBox.Location = New System.Drawing.Point(130, 22)
        Me.TicketLeTextBox.Name = "TicketLeTextBox"
        Me.TicketLeTextBox.ReadOnly = True
        Me.TicketLeTextBox.Size = New System.Drawing.Size(100, 20)
        Me.TicketLeTextBox.TabIndex = 138
        Me.TicketLeTextBox.TabStop = False
        Me.TicketLeTextBox.Tag = "1"
        '
        'BT_Ticket
        '
        Me.BT_Ticket.Image = Global.CLI.My.Resources.Resources.TaskHS
        Me.BT_Ticket.Location = New System.Drawing.Point(72, 71)
        Me.BT_Ticket.Name = "BT_Ticket"
        Me.BT_Ticket.Size = New System.Drawing.Size(138, 22)
        Me.BT_Ticket.TabIndex = 0
        Me.BT_Ticket.Text = "3-Ticket de caisse"
        Me.BT_Ticket.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.BT_Ticket.UseVisualStyleBackColor = True
        '
        'BT_Facture_Envoi
        '
        Me.BT_Facture_Envoi.Image = Global.CLI.My.Resources.Resources.EnvelopeHS
        Me.BT_Facture_Envoi.Location = New System.Drawing.Point(277, 76)
        Me.BT_Facture_Envoi.Name = "BT_Facture_Envoi"
        Me.BT_Facture_Envoi.Size = New System.Drawing.Size(129, 25)
        Me.BT_Facture_Envoi.TabIndex = 1
        Me.BT_Facture_Envoi.Text = "Envoi email Facture"
        Me.BT_Facture_Envoi.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.BT_Facture_Envoi.UseVisualStyleBackColor = True
        '
        'BT_Facture
        '
        Me.BT_Facture.Image = Global.CLI.My.Resources.Resources.CalculatorHS
        Me.BT_Facture.Location = New System.Drawing.Point(277, 48)
        Me.BT_Facture.Name = "BT_Facture"
        Me.BT_Facture.Size = New System.Drawing.Size(112, 22)
        Me.BT_Facture.TabIndex = 1
        Me.BT_Facture.Text = "Facture"
        Me.BT_Facture.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.BT_Facture.UseVisualStyleBackColor = True
        '
        'FactureLeTextBox
        '
        Me.FactureLeTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.T_CommandeVenteBindingSource, "FactureLe", True))
        Me.FactureLeTextBox.Location = New System.Drawing.Point(130, 48)
        Me.FactureLeTextBox.Name = "FactureLeTextBox"
        Me.FactureLeTextBox.ReadOnly = True
        Me.FactureLeTextBox.Size = New System.Drawing.Size(100, 20)
        Me.FactureLeTextBox.TabIndex = 139
        Me.FactureLeTextBox.TabStop = False
        Me.FactureLeTextBox.Tag = "1"
        '
        'BT_revenir_commande
        '
        Me.BT_revenir_commande.Image = Global.CLI.My.Resources.Resources.GoRtlHS
        Me.BT_revenir_commande.Location = New System.Drawing.Point(149, 6)
        Me.BT_revenir_commande.Name = "BT_revenir_commande"
        Me.BT_revenir_commande.Size = New System.Drawing.Size(145, 31)
        Me.BT_revenir_commande.TabIndex = 5
        Me.BT_revenir_commande.Text = "Revenir à la commande"
        Me.BT_revenir_commande.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.BT_revenir_commande.UseVisualStyleBackColor = True
        '
        'RenduGroupBox
        '
        Me.RenduGroupBox.Controls.Add(MontantARendreTTCLabel)
        Me.RenduGroupBox.Controls.Add(Me.MontantRenduTTCTextBox)
        Me.RenduGroupBox.Controls.Add(Label12)
        Me.RenduGroupBox.Controls.Add(Me.BT_ImprimerAvoir)
        Me.RenduGroupBox.Controls.Add(Me.BT_Basculer_Avoir)
        Me.RenduGroupBox.Controls.Add(Me.BT_RendreLaMonnaie)
        Me.RenduGroupBox.Controls.Add(Me.MontantARendreTTCTextBox)
        Me.RenduGroupBox.Controls.Add(Label14)
        Me.RenduGroupBox.Controls.Add(Me.AvoirCreeNoTextBox)
        Me.RenduGroupBox.Controls.Add(AvoirCreeNoLabel)
        Me.RenduGroupBox.Controls.Add(Me.RenduLeTextBox)
        Me.RenduGroupBox.Controls.Add(RenduLeLabel)
        Me.RenduGroupBox.Location = New System.Drawing.Point(37, 350)
        Me.RenduGroupBox.Name = "RenduGroupBox"
        Me.RenduGroupBox.Size = New System.Drawing.Size(464, 161)
        Me.RenduGroupBox.TabIndex = 1
        Me.RenduGroupBox.TabStop = False
        Me.RenduGroupBox.Text = "Rendu"
        '
        'MontantRenduTTCTextBox
        '
        Me.MontantRenduTTCTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.T_CommandeVenteBindingSource, "MontantRenduTTC", True, System.Windows.Forms.DataSourceUpdateMode.OnValidation, Nothing, "C2"))
        Me.MontantRenduTTCTextBox.Location = New System.Drawing.Point(130, 53)
        Me.MontantRenduTTCTextBox.Name = "MontantRenduTTCTextBox"
        Me.MontantRenduTTCTextBox.ReadOnly = True
        Me.MontantRenduTTCTextBox.Size = New System.Drawing.Size(100, 20)
        Me.MontantRenduTTCTextBox.TabIndex = 5
        Me.MontantRenduTTCTextBox.TabStop = False
        Me.MontantRenduTTCTextBox.Tag = "1"
        '
        'BT_ImprimerAvoir
        '
        Me.BT_ImprimerAvoir.Image = Global.CLI.My.Resources.Resources.TaskHS
        Me.BT_ImprimerAvoir.Location = New System.Drawing.Point(303, 95)
        Me.BT_ImprimerAvoir.Name = "BT_ImprimerAvoir"
        Me.BT_ImprimerAvoir.Size = New System.Drawing.Size(120, 26)
        Me.BT_ImprimerAvoir.TabIndex = 2
        Me.BT_ImprimerAvoir.Text = "Imprimer Avoir"
        Me.BT_ImprimerAvoir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.BT_ImprimerAvoir.UseVisualStyleBackColor = True
        '
        'BT_Basculer_Avoir
        '
        Me.BT_Basculer_Avoir.Image = Global.CLI.My.Resources.Resources.TaskHS
        Me.BT_Basculer_Avoir.Location = New System.Drawing.Point(303, 129)
        Me.BT_Basculer_Avoir.Name = "BT_Basculer_Avoir"
        Me.BT_Basculer_Avoir.Size = New System.Drawing.Size(120, 26)
        Me.BT_Basculer_Avoir.TabIndex = 1
        Me.BT_Basculer_Avoir.Text = "Basculer en  Avoir"
        Me.BT_Basculer_Avoir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.BT_Basculer_Avoir.UseVisualStyleBackColor = True
        '
        'BT_RendreLaMonnaie
        '
        Me.BT_RendreLaMonnaie.Image = Global.CLI.My.Resources.Resources.TaskHS
        Me.BT_RendreLaMonnaie.Location = New System.Drawing.Point(130, 129)
        Me.BT_RendreLaMonnaie.Name = "BT_RendreLaMonnaie"
        Me.BT_RendreLaMonnaie.Size = New System.Drawing.Size(138, 26)
        Me.BT_RendreLaMonnaie.TabIndex = 0
        Me.BT_RendreLaMonnaie.Text = "2-Rendre la monnaie"
        Me.BT_RendreLaMonnaie.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.BT_RendreLaMonnaie.UseVisualStyleBackColor = True
        Me.BT_RendreLaMonnaie.Visible = False
        '
        'MontantARendreTTCTextBox
        '
        Me.MontantARendreTTCTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.T_CommandeVenteBindingSource, "MontantARendreTTC", True, System.Windows.Forms.DataSourceUpdateMode.OnValidation, Nothing, "C2"))
        Me.MontantARendreTTCTextBox.Location = New System.Drawing.Point(130, 23)
        Me.MontantARendreTTCTextBox.Name = "MontantARendreTTCTextBox"
        Me.MontantARendreTTCTextBox.ReadOnly = True
        Me.MontantARendreTTCTextBox.Size = New System.Drawing.Size(100, 20)
        Me.MontantARendreTTCTextBox.TabIndex = 132
        Me.MontantARendreTTCTextBox.TabStop = False
        Me.MontantARendreTTCTextBox.Tag = "1"
        '
        'AvoirCreeNoTextBox
        '
        Me.AvoirCreeNoTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.T_CommandeVenteBindingSource, "AvoirCreeNo", True))
        Me.AvoirCreeNoTextBox.Location = New System.Drawing.Point(130, 79)
        Me.AvoirCreeNoTextBox.Name = "AvoirCreeNoTextBox"
        Me.AvoirCreeNoTextBox.ReadOnly = True
        Me.AvoirCreeNoTextBox.Size = New System.Drawing.Size(100, 20)
        Me.AvoirCreeNoTextBox.TabIndex = 134
        Me.AvoirCreeNoTextBox.TabStop = False
        Me.AvoirCreeNoTextBox.Tag = "1"
        '
        'RenduLeTextBox
        '
        Me.RenduLeTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.T_CommandeVenteBindingSource, "RenduLe", True))
        Me.RenduLeTextBox.Location = New System.Drawing.Point(130, 105)
        Me.RenduLeTextBox.Name = "RenduLeTextBox"
        Me.RenduLeTextBox.ReadOnly = True
        Me.RenduLeTextBox.Size = New System.Drawing.Size(100, 20)
        Me.RenduLeTextBox.TabIndex = 136
        Me.RenduLeTextBox.TabStop = False
        Me.RenduLeTextBox.Tag = "1"
        '
        'PaiementGroupBox
        '
        Me.PaiementGroupBox.Controls.Add(Me.TotalAPayerTextBox)
        Me.PaiementGroupBox.Controls.Add(Me.GroupBoxAjoutReglement)
        Me.PaiementGroupBox.Controls.Add(Me.T_ReglementDataGridView)
        Me.PaiementGroupBox.Controls.Add(Me.BT_Paiement)
        Me.PaiementGroupBox.Controls.Add(Me.montantEncaisseTextbox)
        Me.PaiementGroupBox.Controls.Add(Label20)
        Me.PaiementGroupBox.Controls.Add(Me.MontantPaiementTTCTextBox)
        Me.PaiementGroupBox.Controls.Add(MontantPaiementTTCLabel)
        Me.PaiementGroupBox.Controls.Add(Me.Label13)
        Me.PaiementGroupBox.Location = New System.Drawing.Point(37, 43)
        Me.PaiementGroupBox.Name = "PaiementGroupBox"
        Me.PaiementGroupBox.Size = New System.Drawing.Size(888, 301)
        Me.PaiementGroupBox.TabIndex = 0
        Me.PaiementGroupBox.TabStop = False
        Me.PaiementGroupBox.Text = "Paiement"
        '
        'TotalAPayerTextBox
        '
        Me.TotalAPayerTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.T_CommandeVenteBindingSource, "Total_TTC", True, System.Windows.Forms.DataSourceUpdateMode.OnValidation, Nothing, "C2"))
        Me.TotalAPayerTextBox.ForeColor = System.Drawing.SystemColors.WindowText
        Me.TotalAPayerTextBox.Location = New System.Drawing.Point(101, 19)
        Me.TotalAPayerTextBox.Name = "TotalAPayerTextBox"
        Me.TotalAPayerTextBox.ReadOnly = True
        Me.TotalAPayerTextBox.Size = New System.Drawing.Size(100, 20)
        Me.TotalAPayerTextBox.TabIndex = 130
        Me.TotalAPayerTextBox.TabStop = False
        Me.TotalAPayerTextBox.Tag = "1"
        '
        'GroupBoxAjoutReglement
        '
        Me.GroupBoxAjoutReglement.Controls.Add(Me.I_RefAvoir)
        Me.GroupBoxAjoutReglement.Controls.Add(Me.I_encaisse)
        Me.GroupBoxAjoutReglement.Controls.Add(Me.Bt_effaceReglement)
        Me.GroupBoxAjoutReglement.Controls.Add(Me.Bt_addReglement)
        Me.GroupBoxAjoutReglement.Controls.Add(Me.I_echeanceLe)
        Me.GroupBoxAjoutReglement.Controls.Add(Me.I_montantReglement)
        Me.GroupBoxAjoutReglement.Controls.Add(Me.I_conditions)
        Me.GroupBoxAjoutReglement.Controls.Add(Me.I_ModeReglement)
        Me.GroupBoxAjoutReglement.Controls.Add(Me.Label19)
        Me.GroupBoxAjoutReglement.Controls.Add(Me.Label18)
        Me.GroupBoxAjoutReglement.Controls.Add(Me.Label17)
        Me.GroupBoxAjoutReglement.Controls.Add(Me.Label21)
        Me.GroupBoxAjoutReglement.Controls.Add(Me.Label23)
        Me.GroupBoxAjoutReglement.Location = New System.Drawing.Point(6, 198)
        Me.GroupBoxAjoutReglement.Name = "GroupBoxAjoutReglement"
        Me.GroupBoxAjoutReglement.Size = New System.Drawing.Size(855, 71)
        Me.GroupBoxAjoutReglement.TabIndex = 150
        Me.GroupBoxAjoutReglement.TabStop = False
        Me.GroupBoxAjoutReglement.Text = "Ajout d'un paiement"
        '
        'I_RefAvoir
        '
        Me.I_RefAvoir.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.I_RefAvoir.FormattingEnabled = True
        Me.I_RefAvoir.Location = New System.Drawing.Point(263, 38)
        Me.I_RefAvoir.Name = "I_RefAvoir"
        Me.I_RefAvoir.Size = New System.Drawing.Size(146, 21)
        Me.I_RefAvoir.TabIndex = 135
        '
        'I_encaisse
        '
        Me.I_encaisse.AutoSize = True
        Me.I_encaisse.Location = New System.Drawing.Point(626, 40)
        Me.I_encaisse.Name = "I_encaisse"
        Me.I_encaisse.Size = New System.Drawing.Size(130, 17)
        Me.I_encaisse.TabIndex = 134
        Me.I_encaisse.Text = "A encaisser de suite ?"
        Me.I_encaisse.UseVisualStyleBackColor = True
        '
        'Bt_effaceReglement
        '
        Me.Bt_effaceReglement.Image = Global.CLI.My.Resources.Resources.DeleteHS
        Me.Bt_effaceReglement.Location = New System.Drawing.Point(797, 34)
        Me.Bt_effaceReglement.Name = "Bt_effaceReglement"
        Me.Bt_effaceReglement.Size = New System.Drawing.Size(27, 28)
        Me.Bt_effaceReglement.TabIndex = 9
        Me.Bt_effaceReglement.UseVisualStyleBackColor = True
        '
        'Bt_addReglement
        '
        Me.Bt_addReglement.Image = Global.CLI.My.Resources.Resources.AddTableHS
        Me.Bt_addReglement.Location = New System.Drawing.Point(764, 34)
        Me.Bt_addReglement.Name = "Bt_addReglement"
        Me.Bt_addReglement.Size = New System.Drawing.Size(27, 28)
        Me.Bt_addReglement.TabIndex = 8
        Me.Bt_addReglement.Text = "+"
        Me.Bt_addReglement.UseVisualStyleBackColor = True
        '
        'I_echeanceLe
        '
        Me.I_echeanceLe.Location = New System.Drawing.Point(503, 39)
        Me.I_echeanceLe.MaxLength = 255
        Me.I_echeanceLe.Name = "I_echeanceLe"
        Me.I_echeanceLe.Size = New System.Drawing.Size(115, 20)
        Me.I_echeanceLe.TabIndex = 2
        '
        'I_montantReglement
        '
        Me.I_montantReglement.Location = New System.Drawing.Point(415, 39)
        Me.I_montantReglement.MaxLength = 255
        Me.I_montantReglement.Name = "I_montantReglement"
        Me.I_montantReglement.Size = New System.Drawing.Size(78, 20)
        Me.I_montantReglement.TabIndex = 2
        '
        'I_conditions
        '
        Me.I_conditions.DataSource = Me.TModeReglementValideBindingSource
        Me.I_conditions.DisplayMember = "Libelle"
        Me.I_conditions.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.I_conditions.FormattingEnabled = True
        Me.I_conditions.Location = New System.Drawing.Point(9, 38)
        Me.I_conditions.MaxLength = 50
        Me.I_conditions.Name = "I_conditions"
        Me.I_conditions.Size = New System.Drawing.Size(121, 21)
        Me.I_conditions.TabIndex = 0
        Me.I_conditions.ValueMember = "Id_T_ModeReglement"
        '
        'TModeReglementValideBindingSource
        '
        Me.TModeReglementValideBindingSource.DataMember = "T_ModeReglementValide"
        Me.TModeReglementValideBindingSource.DataSource = Me.CLIDataSet
        '
        'I_ModeReglement
        '
        Me.I_ModeReglement.DataSource = Me.TMoyenPaiementValideBindingSource
        Me.I_ModeReglement.DisplayMember = "Libelle"
        Me.I_ModeReglement.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.I_ModeReglement.FormattingEnabled = True
        Me.I_ModeReglement.Location = New System.Drawing.Point(136, 38)
        Me.I_ModeReglement.MaxLength = 50
        Me.I_ModeReglement.Name = "I_ModeReglement"
        Me.I_ModeReglement.Size = New System.Drawing.Size(121, 21)
        Me.I_ModeReglement.TabIndex = 0
        Me.I_ModeReglement.ValueMember = "Id_T_MoyenPaiement"
        '
        'TMoyenPaiementValideBindingSource
        '
        Me.TMoyenPaiementValideBindingSource.DataMember = "T_MoyenPaiementValide"
        Me.TMoyenPaiementValideBindingSource.DataSource = Me.CLIDataSet
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(500, 17)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(76, 13)
        Me.Label19.TabIndex = 133
        Me.Label19.Text = "Echeance le ?"
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(412, 17)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(46, 13)
        Me.Label18.TabIndex = 133
        Me.Label18.Text = "Montant"
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(257, 17)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(51, 13)
        Me.Label17.TabIndex = 133
        Me.Label17.Text = "Ref Avoir"
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Location = New System.Drawing.Point(6, 16)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(117, 13)
        Me.Label21.TabIndex = 133
        Me.Label21.Text = "Conditions de paiement"
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Location = New System.Drawing.Point(133, 16)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(100, 13)
        Me.Label23.TabIndex = 133
        Me.Label23.Text = "Moyen de paiement"
        '
        'T_ReglementDataGridView
        '
        Me.T_ReglementDataGridView.AllowUserToAddRows = False
        Me.T_ReglementDataGridView.AutoGenerateColumns = False
        DataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle11.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle11.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle11.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle11.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle11.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.T_ReglementDataGridView.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle11
        Me.T_ReglementDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.T_ReglementDataGridView.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Conditionreglement, Me.Moyenpaiement, Me.Reference_avoir_bon, Me.Montant, Me.Echeancele, Me.Encaissele, Me.Enregistrele, Me.A_Encaisser, Me.Idtcommandevente})
        Me.T_ReglementDataGridView.DataSource = Me.T_ReglementBindingSource
        DataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle13.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle13.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle13.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle13.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle13.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle13.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.T_ReglementDataGridView.DefaultCellStyle = DataGridViewCellStyle13
        Me.T_ReglementDataGridView.Location = New System.Drawing.Point(6, 55)
        Me.T_ReglementDataGridView.Name = "T_ReglementDataGridView"
        DataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle14.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle14.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle14.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle14.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle14.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle14.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.T_ReglementDataGridView.RowHeadersDefaultCellStyle = DataGridViewCellStyle14
        Me.T_ReglementDataGridView.Size = New System.Drawing.Size(855, 137)
        Me.T_ReglementDataGridView.TabIndex = 149
        '
        'Conditionreglement
        '
        Me.Conditionreglement.DataPropertyName = "Condition_reglement"
        Me.Conditionreglement.DataSource = Me.TmodeReglementBindingSource
        Me.Conditionreglement.DisplayMember = "Libelle"
        Me.Conditionreglement.HeaderText = "Conditions"
        Me.Conditionreglement.Name = "Conditionreglement"
        Me.Conditionreglement.ReadOnly = True
        Me.Conditionreglement.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Conditionreglement.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.Conditionreglement.ValueMember = "Id_T_ModeReglement"
        '
        'TmodeReglementBindingSource
        '
        Me.TmodeReglementBindingSource.DataMember = "T_modeReglement"
        Me.TmodeReglementBindingSource.DataSource = Me.CLIDataSet
        '
        'Moyenpaiement
        '
        Me.Moyenpaiement.DataPropertyName = "Moyen_paiement"
        Me.Moyenpaiement.DataSource = Me.TMoyenPaiementdgview
        Me.Moyenpaiement.DisplayMember = "Libelle"
        Me.Moyenpaiement.HeaderText = "Moyen"
        Me.Moyenpaiement.Name = "Moyenpaiement"
        Me.Moyenpaiement.ReadOnly = True
        Me.Moyenpaiement.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Moyenpaiement.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.Moyenpaiement.ValueMember = "Id_T_MoyenPaiement"
        '
        'TMoyenPaiementdgview
        '
        Me.TMoyenPaiementdgview.DataMember = "T_MoyenPaiement"
        Me.TMoyenPaiementdgview.DataSource = Me.CLIDataSet
        '
        'Reference_avoir_bon
        '
        Me.Reference_avoir_bon.DataPropertyName = "Reference_avoir_bon"
        Me.Reference_avoir_bon.HeaderText = "Ref Avoir"
        Me.Reference_avoir_bon.Name = "Reference_avoir_bon"
        Me.Reference_avoir_bon.ReadOnly = True
        '
        'Montant
        '
        Me.Montant.DataPropertyName = "Montant"
        DataGridViewCellStyle12.Format = "C2"
        Me.Montant.DefaultCellStyle = DataGridViewCellStyle12
        Me.Montant.HeaderText = "Montant"
        Me.Montant.Name = "Montant"
        Me.Montant.ReadOnly = True
        '
        'Echeancele
        '
        Me.Echeancele.DataPropertyName = "Echeance_le"
        Me.Echeancele.HeaderText = "Echeance le"
        Me.Echeancele.Name = "Echeancele"
        Me.Echeancele.ReadOnly = True
        '
        'Encaissele
        '
        Me.Encaissele.DataPropertyName = "Encaisse_le"
        Me.Encaissele.HeaderText = "Encaisse le"
        Me.Encaissele.Name = "Encaissele"
        '
        'Enregistrele
        '
        Me.Enregistrele.DataPropertyName = "Enregistre_le"
        Me.Enregistrele.HeaderText = "Date saisie"
        Me.Enregistrele.Name = "Enregistrele"
        Me.Enregistrele.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        '
        'A_Encaisser
        '
        Me.A_Encaisser.DataPropertyName = "A_Encaisser"
        Me.A_Encaisser.HeaderText = "A Encaisser ?"
        Me.A_Encaisser.Name = "A_Encaisser"
        '
        'Idtcommandevente
        '
        Me.Idtcommandevente.DataPropertyName = "id_t_commande_vente"
        Me.Idtcommandevente.HeaderText = "id_t_commande_vente"
        Me.Idtcommandevente.Name = "Idtcommandevente"
        Me.Idtcommandevente.ReadOnly = True
        Me.Idtcommandevente.Visible = False
        '
        'BT_Paiement
        '
        Me.BT_Paiement.Image = Global.CLI.My.Resources.Resources.TaskHS
        Me.BT_Paiement.Location = New System.Drawing.Point(11, 272)
        Me.BT_Paiement.Name = "BT_Paiement"
        Me.BT_Paiement.Size = New System.Drawing.Size(111, 23)
        Me.BT_Paiement.TabIndex = 148
        Me.BT_Paiement.Text = "1-Paiement"
        Me.BT_Paiement.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.BT_Paiement.UseVisualStyleBackColor = True
        '
        'montantEncaisseTextbox
        '
        Me.montantEncaisseTextbox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.T_CommandeVenteBindingSource, "MontantEncaisseTTC", True, System.Windows.Forms.DataSourceUpdateMode.OnValidation, Nothing, "C2"))
        Me.montantEncaisseTextbox.Location = New System.Drawing.Point(602, 19)
        Me.montantEncaisseTextbox.Name = "montantEncaisseTextbox"
        Me.montantEncaisseTextbox.ReadOnly = True
        Me.montantEncaisseTextbox.Size = New System.Drawing.Size(100, 20)
        Me.montantEncaisseTextbox.TabIndex = 1
        Me.montantEncaisseTextbox.Tag = "1"
        '
        'MontantPaiementTTCTextBox
        '
        Me.MontantPaiementTTCTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.T_CommandeVenteBindingSource, "MontantPaiementTTC", True, System.Windows.Forms.DataSourceUpdateMode.OnValidation, Nothing, "C2"))
        Me.MontantPaiementTTCTextBox.Location = New System.Drawing.Point(350, 19)
        Me.MontantPaiementTTCTextBox.Name = "MontantPaiementTTCTextBox"
        Me.MontantPaiementTTCTextBox.ReadOnly = True
        Me.MontantPaiementTTCTextBox.Size = New System.Drawing.Size(100, 20)
        Me.MontantPaiementTTCTextBox.TabIndex = 1
        Me.MontantPaiementTTCTextBox.Tag = "1"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(9, 22)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(86, 13)
        Me.Label13.TabIndex = 131
        Me.Label13.Text = "Total à payer:"
        '
        'TMoyenPaiementBindingSource
        '
        Me.TMoyenPaiementBindingSource.DataMember = "T_MoyenPaiement"
        Me.TMoyenPaiementBindingSource.DataSource = Me.CLIDataSet
        '
        'FKTReglementTCommandeVenteBindingSource
        '
        Me.FKTReglementTCommandeVenteBindingSource.DataMember = "FK_T_Reglement_T_CommandeVente"
        Me.FKTReglementTCommandeVenteBindingSource.DataSource = Me.T_CommandeVenteBindingSource
        '
        'BT_Refresh
        '
        Me.BT_Refresh.Image = Global.CLI.My.Resources.Resources.Edit_UndoHS
        Me.BT_Refresh.Location = New System.Drawing.Point(3, 40)
        Me.BT_Refresh.Name = "BT_Refresh"
        Me.BT_Refresh.Size = New System.Drawing.Size(82, 31)
        Me.BT_Refresh.TabIndex = 3
        Me.BT_Refresh.Text = "Refresh"
        Me.BT_Refresh.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.BT_Refresh.UseVisualStyleBackColor = True
        '
        'ToolStrip2
        '
        Me.ToolStrip2.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStrip2.ImageScalingSize = New System.Drawing.Size(32, 32)
        Me.ToolStrip2.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripButtonMovefirst, Me.ToolStripButtonMovePrevious, Me.ToolStripLabelPosition, Me.ToolStripButtonMoveNext, Me.ToolStripButtonMoveLast})
        Me.ToolStrip2.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip2.Name = "ToolStrip2"
        Me.ToolStrip2.Size = New System.Drawing.Size(1285, 25)
        Me.ToolStrip2.TabIndex = 45
        Me.ToolStrip2.Text = "ToolStrip2"
        '
        'ToolStripButtonMovefirst
        '
        Me.ToolStripButtonMovefirst.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButtonMovefirst.Image = Global.CLI.My.Resources.Resources.DataContainer_MoveFirstHS
        Me.ToolStripButtonMovefirst.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.ToolStripButtonMovefirst.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButtonMovefirst.Name = "ToolStripButtonMovefirst"
        Me.ToolStripButtonMovefirst.Size = New System.Drawing.Size(23, 22)
        Me.ToolStripButtonMovefirst.Text = "Premier"
        '
        'ToolStripButtonMovePrevious
        '
        Me.ToolStripButtonMovePrevious.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButtonMovePrevious.Image = Global.CLI.My.Resources.Resources.DataContainer_MovePreviousHS
        Me.ToolStripButtonMovePrevious.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.ToolStripButtonMovePrevious.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButtonMovePrevious.Name = "ToolStripButtonMovePrevious"
        Me.ToolStripButtonMovePrevious.Size = New System.Drawing.Size(23, 22)
        Me.ToolStripButtonMovePrevious.Text = "Pécèdent"
        '
        'ToolStripLabelPosition
        '
        Me.ToolStripLabelPosition.Name = "ToolStripLabelPosition"
        Me.ToolStripLabelPosition.Size = New System.Drawing.Size(40, 22)
        Me.ToolStripLabelPosition.Text = "{0}/{1}"
        '
        'ToolStripButtonMoveNext
        '
        Me.ToolStripButtonMoveNext.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButtonMoveNext.Image = Global.CLI.My.Resources.Resources.DataContainer_MoveNextHS
        Me.ToolStripButtonMoveNext.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.ToolStripButtonMoveNext.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButtonMoveNext.Name = "ToolStripButtonMoveNext"
        Me.ToolStripButtonMoveNext.Size = New System.Drawing.Size(23, 22)
        Me.ToolStripButtonMoveNext.Text = "Suivant"
        '
        'ToolStripButtonMoveLast
        '
        Me.ToolStripButtonMoveLast.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButtonMoveLast.Image = Global.CLI.My.Resources.Resources.DataContainer_MoveLastHS
        Me.ToolStripButtonMoveLast.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.ToolStripButtonMoveLast.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButtonMoveLast.Name = "ToolStripButtonMoveLast"
        Me.ToolStripButtonMoveLast.Size = New System.Drawing.Size(23, 22)
        Me.ToolStripButtonMoveLast.Text = "Dernier"
        '
        'T_CommandeVenteTableAdapter
        '
        Me.T_CommandeVenteTableAdapter.ClearBeforeFill = True
        '
        'T_CommandeVente_LigneTableAdapter
        '
        Me.T_CommandeVente_LigneTableAdapter.ClearBeforeFill = True
        '
        'T_EtatCommandeVenteTableAdapter
        '
        Me.T_EtatCommandeVenteTableAdapter.ClearBeforeFill = True
        '
        'T_PaysTableAdapter
        '
        Me.T_PaysTableAdapter.ClearBeforeFill = True
        '
        'T_MoyenPaiementTableAdapter
        '
        Me.T_MoyenPaiementTableAdapter.ClearBeforeFill = True
        '
        'V_Avoir_clientTableAdapter
        '
        Me.V_Avoir_clientTableAdapter.ClearBeforeFill = True
        '
        'T_ReglementTableAdapter
        '
        Me.T_ReglementTableAdapter.ClearBeforeFill = True
        '
        'T_modeReglementTableAdapter
        '
        Me.T_modeReglementTableAdapter.ClearBeforeFill = True
        '
        'V_reglementTableAdapter
        '
        Me.V_reglementTableAdapter.ClearBeforeFill = True
        '
        'V_chequecadeau_clientTableAdapter
        '
        Me.V_chequecadeau_clientTableAdapter.ClearBeforeFill = True
        '
        'T_MoyenPaiementValideTableAdapter
        '
        Me.T_MoyenPaiementValideTableAdapter.ClearBeforeFill = True
        '
        'T_ModeReglementValideTableAdapter
        '
        Me.T_ModeReglementValideTableAdapter.ClearBeforeFill = True
        '
        'FormCaisse
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1285, 905)
        Me.Controls.Add(Me.ToolStrip2)
        Me.Controls.Add(Me.BT_Refresh)
        Me.Controls.Add(Me.TabControl1)
        Me.Name = "FormCaisse"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Commande"
        CType(Me.T_CommandeVente_LigneBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CLIDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.T_CommandeVenteBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.V_reglementBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.V_chequecadeau_clientBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.V_Avoir_clientBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.VreglementBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TReglementBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.T_ReglementBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabControl1.ResumeLayout(False)
        Me.TabCommande.ResumeLayout(False)
        Me.TabCommande.PerformLayout()
        Me.GroupBoxCodesSpeciaux.ResumeLayout(False)
        Me.GroupBoxCodesSpeciaux.PerformLayout()
        Me.EnteteGroupBox.ResumeLayout(False)
        Me.EnteteGroupBox.PerformLayout()
        CType(Me.TPaysBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TEtatCommandeVenteBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ContextMenuStripClient.ResumeLayout(False)
        Me.GroupBoxAjout.ResumeLayout(False)
        Me.GroupBoxAjout.PerformLayout()
        Me.ContextMenuStripArticle.ResumeLayout(False)
        CType(Me.DataGridViewCommande, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TCommandeVenteLigneBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ToolStrip.ResumeLayout(False)
        Me.ToolStrip.PerformLayout()
        Me.TabReglement.ResumeLayout(False)
        Me.ExpeditionGroupBox.ResumeLayout(False)
        Me.ExpeditionGroupBox.PerformLayout()
        Me.SortieStockGroupBox.ResumeLayout(False)
        Me.SortieStockGroupBox.PerformLayout()
        Me.TicketFactureGroupBox.ResumeLayout(False)
        Me.TicketFactureGroupBox.PerformLayout()
        Me.RenduGroupBox.ResumeLayout(False)
        Me.RenduGroupBox.PerformLayout()
        Me.PaiementGroupBox.ResumeLayout(False)
        Me.PaiementGroupBox.PerformLayout()
        Me.GroupBoxAjoutReglement.ResumeLayout(False)
        Me.GroupBoxAjoutReglement.PerformLayout()
        CType(Me.TModeReglementValideBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TMoyenPaiementValideBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.T_ReglementDataGridView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TmodeReglementBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TMoyenPaiementdgview, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TMoyenPaiementBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.FKTReglementTCommandeVenteBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ToolStrip2.ResumeLayout(False)
        Me.ToolStrip2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabCommande As System.Windows.Forms.TabPage
    Friend WithEvents TabReglement As System.Windows.Forms.TabPage
    Friend WithEvents ToolStrip As System.Windows.Forms.ToolStrip
    Friend WithEvents NouveauToolStripButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripButton2 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents CopierGeneToolStripButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents CollerGeneToolStripButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents SupprimerToolStripButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripButton5 As System.Windows.Forms.ToolStripButton
    Friend WithEvents BT_Enregistrer As System.Windows.Forms.Button
    Friend WithEvents BT_Refresh As System.Windows.Forms.Button
    Friend WithEvents BT_Ticket As System.Windows.Forms.Button
    Friend WithEvents BT_Facture As System.Windows.Forms.Button
    Friend WithEvents BT_Scan As System.Windows.Forms.Button
    Friend WithEvents LabelArticles As System.Windows.Forms.Label
    Friend WithEvents DataGridViewCommande As System.Windows.Forms.DataGridView
    Friend WithEvents CLIDataSet As CLI.CLIDataSet
    Friend WithEvents T_CommandeVenteBindingSource As System.Windows.Forms.BindingSource

    Friend WithEvents TEtatCommandeVenteBindingSource As System.Windows.Forms.BindingSource

    Friend WithEvents LabelTotalCommandeHT As System.Windows.Forms.Label
    Friend WithEvents I_TotalHT As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents I_TotalTTC As System.Windows.Forms.TextBox
    Friend WithEvents I_TVA196 As System.Windows.Forms.TextBox
    Friend WithEvents I_TVA55 As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents I_Qte As System.Windows.Forms.TextBox
    Friend WithEvents I_PUTTCRemise As System.Windows.Forms.TextBox
    Friend WithEvents I_Remise As System.Windows.Forms.TextBox
    Friend WithEvents I_PuTTC As System.Windows.Forms.TextBox
    Friend WithEvents I_Designation As System.Windows.Forms.TextBox
    Friend WithEvents I_Ref As System.Windows.Forms.TextBox
    Friend WithEvents BT_Plus As System.Windows.Forms.Button
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents I_TVA As System.Windows.Forms.TextBox
    Friend WithEvents ContextMenuStripArticle As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents RechercherToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents BT_ClearTampon As System.Windows.Forms.Button
    Friend WithEvents GroupBoxAjout As System.Windows.Forms.GroupBox
    Friend WithEvents ToolStrip2 As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStripButtonMovefirst As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripButtonMovePrevious As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripLabelPosition As System.Windows.Forms.ToolStripLabel
    Friend WithEvents ToolStripButtonMoveNext As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripButtonMoveLast As System.Windows.Forms.ToolStripButton
    Friend WithEvents T_CommandeVenteTableAdapter As CLI.CLIDataSetTableAdapters.T_CommandeVenteTableAdapter
    Friend WithEvents TCommandeVenteLigneBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents T_CommandeVente_LigneTableAdapter As CLI.CLIDataSetTableAdapters.T_CommandeVente_LigneTableAdapter
    Friend WithEvents ModifieLeTextBox As System.Windows.Forms.TextBox
    Friend WithEvents ModifieParTextBox As System.Windows.Forms.TextBox
    Friend WithEvents CreeLeTextBox As System.Windows.Forms.TextBox
    Friend WithEvents CreeParTextBox As System.Windows.Forms.TextBox
    Friend WithEvents BT_Basculer_Avoir As System.Windows.Forms.Button
    Friend WithEvents MontantRenduTTCTextBox As System.Windows.Forms.TextBox
    Friend WithEvents MontantPaiementTTCTextBox As System.Windows.Forms.TextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents TotalAPayerTextBox As System.Windows.Forms.TextBox
    Friend WithEvents MontantARendreTTCTextBox As System.Windows.Forms.TextBox
    Friend WithEvents T_CommandeVente_LigneBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents T_EtatCommandeVenteTableAdapter As CLI.CLIDataSetTableAdapters.T_EtatCommandeVenteTableAdapter
    Friend WithEvents TPaysBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents T_PaysTableAdapter As CLI.CLIDataSetTableAdapters.T_PaysTableAdapter
    Friend WithEvents BT_RendreLaMonnaie As System.Windows.Forms.Button
    Friend WithEvents AvoirCreeNoTextBox As System.Windows.Forms.TextBox
    Friend WithEvents RenduLeTextBox As System.Windows.Forms.TextBox
    Friend WithEvents RenduGroupBox As System.Windows.Forms.GroupBox
    Friend WithEvents ExpeditionNumsuiviTextBox As System.Windows.Forms.TextBox
    Friend WithEvents PaiementGroupBox As System.Windows.Forms.GroupBox
    Friend WithEvents FactureLeTextBox As System.Windows.Forms.TextBox
    Friend WithEvents TicketLeTextBox As System.Windows.Forms.TextBox
    Friend WithEvents ExpedieLeTextBox As System.Windows.Forms.TextBox
    Friend WithEvents BT_SortirStock As System.Windows.Forms.Button
    Friend WithEvents SortieStockGroupBox As System.Windows.Forms.GroupBox
    Friend WithEvents TicketFactureGroupBox As System.Windows.Forms.GroupBox
    Friend WithEvents TMoyenPaiementBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents T_MoyenPaiementTableAdapter As CLI.CLIDataSetTableAdapters.T_MoyenPaiementTableAdapter
    Friend WithEvents EnteteGroupBox As System.Windows.Forms.GroupBox
    Friend WithEvents PaysComboBox As System.Windows.Forms.ComboBox
    Friend WithEvents EtatLibelleTextBox As System.Windows.Forms.TextBox
    Friend WithEvents EmailTextBox As System.Windows.Forms.TextBox
    Friend WithEvents MobileTextBox As System.Windows.Forms.TextBox
    Friend WithEvents FaxTextBox As System.Windows.Forms.TextBox
    Friend WithEvents TelTextBox As System.Windows.Forms.TextBox
    Friend WithEvents VilleTextBox As System.Windows.Forms.TextBox
    Friend WithEvents CodePostalTextBox As System.Windows.Forms.TextBox
    Friend WithEvents AdresseL3TextBox As System.Windows.Forms.TextBox
    Friend WithEvents AdresseL2TextBox As System.Windows.Forms.TextBox
    Friend WithEvents AdresseL1TextBox As System.Windows.Forms.TextBox
    Friend WithEvents I_Web As System.Windows.Forms.CheckBox
    Friend WithEvents PrénomTextBox As System.Windows.Forms.TextBox
    Friend WithEvents NomTextBox As System.Windows.Forms.TextBox
    Friend WithEvents CodeClientTextBox As System.Windows.Forms.TextBox
    Friend WithEvents SociétéTextBox As System.Windows.Forms.TextBox
    Friend WithEvents ID_T_CommandeVenteTextBox As System.Windows.Forms.TextBox
    Friend WithEvents BT_Etape_Règlement As System.Windows.Forms.Button
    Friend WithEvents BT_revenir_commande As System.Windows.Forms.Button
    Friend WithEvents BT_AnnulerCommande As System.Windows.Forms.Button
    Friend WithEvents FactureReportViewer As Microsoft.Reporting.WinForms.ReportViewer
    Friend WithEvents AvoirReportViewer As Microsoft.Reporting.WinForms.ReportViewer
    Friend WithEvents V_Avoir_clientBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents V_Avoir_clientTableAdapter As CLI.CLIDataSetTableAdapters.V_Avoir_clientTableAdapter
    Friend WithEvents BT_ImprimerAvoir As System.Windows.Forms.Button
    Friend WithEvents BT_OuvrirCaisse As System.Windows.Forms.Button
    Friend WithEvents ContextMenuStripClient As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents ToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents BT_Facture_Envoi As System.Windows.Forms.Button
    Friend WithEvents Commentaires_factureTextBox As System.Windows.Forms.TextBox
    Friend WithEvents ExportCheckBox As System.Windows.Forms.CheckBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents I_MontantDeduire As System.Windows.Forms.TextBox
    Friend WithEvents T_ReglementBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents T_ReglementTableAdapter As CLI.CLIDataSetTableAdapters.T_ReglementTableAdapter
    Friend WithEvents FKTReglementTCommandeVenteBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents GroupBoxAjoutReglement As System.Windows.Forms.GroupBox
    Friend WithEvents Bt_effaceReglement As System.Windows.Forms.Button
    Friend WithEvents Bt_addReglement As System.Windows.Forms.Button
    Friend WithEvents I_echeanceLe As System.Windows.Forms.TextBox
    Friend WithEvents I_montantReglement As System.Windows.Forms.TextBox
    Friend WithEvents I_ModeReglement As System.Windows.Forms.ComboBox
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents T_ReglementDataGridView As System.Windows.Forms.DataGridView
    Friend WithEvents BT_Paiement As System.Windows.Forms.Button
    Friend WithEvents I_conditions As System.Windows.Forms.ComboBox
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents TmodeReglementBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents T_modeReglementTableAdapter As CLI.CLIDataSetTableAdapters.T_modeReglementTableAdapter
    Friend WithEvents I_encaisse As System.Windows.Forms.CheckBox
    Friend WithEvents ReferenceavoirDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents montantEncaisseTextbox As System.Windows.Forms.TextBox
    Friend WithEvents TMoyenPaiementdgview As System.Windows.Forms.BindingSource
    Friend WithEvents I_RefAvoir As System.Windows.Forms.ComboBox
    Friend WithEvents TReglementBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents VreglementBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents V_reglementTableAdapter As CLI.CLIDataSetTableAdapters.V_reglementTableAdapter
    Friend WithEvents GroupBoxCodesSpeciaux As System.Windows.Forms.GroupBox
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents Label26 As System.Windows.Forms.Label
    Friend WithEvents Label27 As System.Windows.Forms.Label
    Friend WithEvents Label28 As System.Windows.Forms.Label
    Friend WithEvents BT_Etiquette As System.Windows.Forms.Button
    Friend WithEvents BT_Imprimer_devis As System.Windows.Forms.Button
    Friend WithEvents DevisReportViewer As Microsoft.Reporting.WinForms.ReportViewer
    Friend WithEvents V_reglementBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents Label29 As System.Windows.Forms.Label
    Friend WithEvents I_ChequeCadeauIdClient As System.Windows.Forms.TextBox
    Friend WithEvents IL_codebenef As System.Windows.Forms.Label
    Friend WithEvents I_NomBeneficiaire As System.Windows.Forms.TextBox
    Friend WithEvents ChequeCadeauReportViewer As Microsoft.Reporting.WinForms.ReportViewer
    Friend WithEvents V_chequecadeau_clientBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents V_chequecadeau_clientTableAdapter As CLI.CLIDataSetTableAdapters.V_chequecadeau_clientTableAdapter
    Friend WithEvents BT_ImprimerChequeCadeau As System.Windows.Forms.Button
    Friend WithEvents NoSiretTextBox As System.Windows.Forms.TextBox
    Friend WithEvents NoTVATextBox As System.Windows.Forms.TextBox
    Friend WithEvents BT_Imprimer_reservation As System.Windows.Forms.Button
    Friend WithEvents BT_Imprimer_test As System.Windows.Forms.Button
    Friend WithEvents VuAvecTextBox As System.Windows.Forms.TextBox
    Friend WithEvents CommentairesCommandeTextBox As System.Windows.Forms.TextBox
    Friend WithEvents BT_Envoi_etat_commande As System.Windows.Forms.Button
    Friend WithEvents BT_Imprimer As System.Windows.Forms.Button
    Friend WithEvents BT_BL As System.Windows.Forms.Button
    Friend WithEvents I_Vpc_on As System.Windows.Forms.CheckBox
    Friend WithEvents ExpeditionGroupBox As System.Windows.Forms.GroupBox
    Friend WithEvents BT_Expedier As System.Windows.Forms.Button
    Friend WithEvents ExpeditionLeTextBox As System.Windows.Forms.TextBox
    Friend WithEvents BT_ReExpedier As System.Windows.Forms.Button
    Friend WithEvents Id_T_TransporteurComboBox As System.Windows.Forms.ComboBox
    Friend WithEvents Label30 As Label
    Friend WithEvents I_Total_TTC_avantDeduction As TextBox
    Friend WithEvents ID_T_CommandeVenteLigne As DataGridViewTextBoxColumn
    Friend WithEvents ID_T_CommandeVente As DataGridViewTextBoxColumn
    Friend WithEvents Ref As DataGridViewTextBoxColumn
    Friend WithEvents Designation As DataGridViewTextBoxColumn
    Friend WithEvents Qte As DataGridViewTextBoxColumn
    Friend WithEvents prix_vente_initial_HT As DataGridViewTextBoxColumn
    Friend WithEvents TVA As DataGridViewTextBoxColumn
    Friend WithEvents PUinitialTTC As DataGridViewTextBoxColumn
    Friend WithEvents Remise As DataGridViewTextBoxColumn
    Friend WithEvents PUremiseTTC As DataGridViewTextBoxColumn
    Friend WithEvents prix_total_HT As DataGridViewTextBoxColumn
    Friend WithEvents TotalLigne As DataGridViewTextBoxColumn
    Friend WithEvents Label31 As Label
    Friend WithEvents I_Caisse As ComboBox
    Friend WithEvents TMoyenPaiementValideBindingSource As BindingSource
    Friend WithEvents T_MoyenPaiementValideTableAdapter As CLIDataSetTableAdapters.T_MoyenPaiementValideTableAdapter
    Friend WithEvents T_ModeReglementValideTableAdapter As CLIDataSetTableAdapters.T_ModeReglementValideTableAdapter
    Friend WithEvents TModeReglementValideBindingSource As BindingSource
    Friend WithEvents Conditionreglement As DataGridViewComboBoxColumn
    Friend WithEvents Moyenpaiement As DataGridViewComboBoxColumn
    Friend WithEvents Reference_avoir_bon As DataGridViewTextBoxColumn
    Friend WithEvents Montant As DataGridViewTextBoxColumn
    Friend WithEvents Echeancele As DataGridViewTextBoxColumn
    Friend WithEvents Encaissele As DataGridViewTextBoxColumn
    Friend WithEvents Enregistrele As DataGridViewTextBoxColumn
    Friend WithEvents A_Encaisser As DataGridViewCheckBoxColumn
    Friend WithEvents Idtcommandevente As DataGridViewTextBoxColumn
    Friend WithEvents BT_DetailSynchro As Button
    Friend WithEvents I_EtatSynchroPrestashop As TextBox
    Friend WithEvents I_IdCommandePrestashop As TextBox
    Friend WithEvents I_ReferenceCommandePrestashop As TextBox
    Friend WithEvents Label32 As Label
    Friend WithEvents I_IdPanierPrestashop As TextBox
    Friend WithEvents Label33 As Label
End Class
