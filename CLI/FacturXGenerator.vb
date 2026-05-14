' =============================================
' Réforme facturation électronique 2026-2027
' FACTUR-X GENERATOR — Profil EN 16931 (BASIC + WL)
' =============================================
' Spécification : Factur-X v1.0.07 — Cross-Industry Invoice CII v23
' Norme : EN 16931 (European Norm) + extensions FNFE/AFNOR FR
' Cible : .NET Framework 3.5 (compatible postes magasin Chinook)
'
' Production : un fichier XML CII conforme EN 16931 prêt à être embarqué
'              dans un PDF/A-3 (cf. FacturXPdfEmbedder) pour transmission
'              vers une Plateforme de Dématérialisation Partenaire (PDP).
' =============================================

Imports System.Data.SqlClient
Imports System.Globalization
Imports System.IO
Imports System.Text
Imports System.Xml

''' <summary>
''' Générateur du XML Factur-X / EN 16931 pour les factures clients de Chinook.
''' Lit les paramètres entreprise depuis T_Param (SIRET, TVA intracom, IBAN…)
''' et produit le XML CII complet : en-tête, vendeur, acheteur, lignes,
''' ventilation TVA, modes de paiement, totaux.
'''
''' Usage typique :
'''   Dim xml As String = FacturXGenerator.GenerateXML(idCommande, My.Settings.CLIConnectionString)
'''   FacturXPdfEmbedder.AttachToPdfA3(pdfPath, xml, outputPath)
''' </summary>
Public Class FacturXGenerator

    ' ── Constantes namespaces CII v23 ──
    Private Const NS_RSM As String = "urn:un:unece:uncefact:data:standard:CrossIndustryInvoice:100"
    Private Const NS_RAM As String = "urn:un:unece:uncefact:data:standard:ReusableAggregateBusinessInformationEntity:100"
    Private Const NS_UDT As String = "urn:un:unece:uncefact:data:standard:UnqualifiedDataType:100"
    Private Const NS_QDT As String = "urn:un:unece:uncefact:data:standard:QualifiedDataType:100"

    ' ── Profils Factur-X disponibles (du moins riche au plus riche) ──
    Public Const PROFIL_MINIMUM As String = "urn:factur-x.eu:1p0:minimum"
    Public Const PROFIL_BASICWL As String = "urn:factur-x.eu:1p0:basicwl"
    Public Const PROFIL_BASIC As String = "urn:cen.eu:en16931:2017#compliant#urn:factur-x.eu:1p0:basic"
    Public Const PROFIL_EN16931 As String = "urn:cen.eu:en16931:2017"
    Public Const PROFIL_EXTENDED As String = "urn:cen.eu:en16931:2017#conformant#urn:factur-x.eu:1p0:extended"

#Region "Point d'entrée"

    ''' <summary>
    ''' Génère le XML Factur-X pour une commande/facture par son ID.
    ''' </summary>
    ''' <param name="idCommandeVente">ID T_CommandeVente</param>
    ''' <param name="connectionString">Chaîne de connexion SQL</param>
    ''' <param name="profil">Profil Factur-X à appliquer (défaut : EN16931)</param>
    ''' <returns>Chaîne XML CII v23 conforme EN 16931</returns>
    Public Shared Function GenerateXML(idCommandeVente As Long,
                                       connectionString As String,
                                       Optional profil As String = PROFIL_EN16931) As String
        Dim params As ParametresEntreprise = LireParametresEntreprise(connectionString)
        Dim facture As DonneesFacture = LireFacture(idCommandeVente, connectionString)

        Return BuildXml(facture, params, profil)
    End Function

    ''' <summary>
    ''' Variante : génère le XML à partir de structures déjà chargées
    ''' (utile pour les tests unitaires sans accès base).
    ''' </summary>
    Public Shared Function GenerateXML(facture As DonneesFacture,
                                       params As ParametresEntreprise,
                                       Optional profil As String = PROFIL_EN16931) As String
        Return BuildXml(facture, params, profil)
    End Function

#End Region

#Region "Lecture des paramètres entreprise et de la facture"

    ''' <summary>Paramètres de l'entreprise émettrice, lus depuis T_Param.</summary>
    Public Class ParametresEntreprise
        Public Nom As String = ""
        Public Adresse1 As String = ""
        Public Adresse2 As String = ""
        Public CodePostal As String = ""
        Public Ville As String = ""
        Public CodePays As String = "FR"
        Public Siret As String = ""
        Public Siren As String = ""
        Public NumeroTvaIntracom As String = ""
        Public CodeAPE As String = ""
        Public FormeJuridique As String = ""
        Public Capital As String = ""
        Public Email As String = ""
        Public Telephone As String = ""
        Public Iban As String = ""
        Public Bic As String = ""
        Public TitulaireCompte As String = ""
    End Class

    ''' <summary>Données d'une facture pour génération CII.</summary>
    Public Class DonneesFacture
        Public IdCommande As Long
        Public NumeroFacture As String = ""
        Public DateFacture As DateTime
        Public DateEcheance As DateTime
        Public DevisesCode As String = "EUR"
        Public NF525Signature As String = ""

        Public Client As New DonneesClient()
        Public Lignes As New System.Collections.Generic.List(Of LigneFacture)()
        Public TotalHT As Decimal
        Public TotalTVA As Decimal
        Public TotalTTC As Decimal
        Public ModeReglement As String = "" ' '30' = virement, '10' = espèces, '20' = chèque, '48' = CB
    End Class

    Public Class DonneesClient
        Public Nom As String = ""
        Public Societe As String = ""
        Public Adresse1 As String = ""
        Public Adresse2 As String = ""
        Public CodePostal As String = ""
        Public Ville As String = ""
        Public CodePays As String = "FR"
        Public Siret As String = ""
        Public NumeroTvaIntracom As String = ""
        Public Email As String = ""
    End Class

    Public Class LigneFacture
        Public Numero As Integer
        Public Designation As String = ""
        Public ReferenceArticle As String = ""
        Public Quantite As Decimal
        Public UnitePrix As String = "C62" ' C62 = unité simple (UN/CEFACT)
        Public PrixUnitaireHT As Decimal
        Public PrixTotalHT As Decimal
        Public TauxTVA As Decimal ' 20.0, 5.5, 10.0, 2.1, 0.0
    End Class

    ''' <summary>Lit les paramètres entreprise depuis T_Param (clés FacturX_*).</summary>
    Public Shared Function LireParametresEntreprise(connectionString As String) As ParametresEntreprise
        Dim p As New ParametresEntreprise()
        Dim cles As String() = New String() {
            "FacturX_Entreprise_Nom", "FacturX_Entreprise_Adresse1", "FacturX_Entreprise_Adresse2",
            "FacturX_Entreprise_CodePostal", "FacturX_Entreprise_Ville", "FacturX_Entreprise_CodePays",
            "FacturX_Entreprise_Siret", "FacturX_Entreprise_Siren", "FacturX_Entreprise_TvaIntracom",
            "FacturX_Entreprise_CodeAPE", "FacturX_Entreprise_FormeJuridique", "FacturX_Entreprise_Capital",
            "FacturX_Entreprise_Email", "FacturX_Entreprise_Telephone",
            "FacturX_Entreprise_IBAN", "FacturX_Entreprise_BIC", "FacturX_Entreprise_TitulaireCompte"
        }
        Dim valeurs As New System.Collections.Generic.Dictionary(Of String, String)()
        Using cnn As New SqlConnection(connectionString)
            cnn.Open()
            Using cmd As New SqlCommand("SELECT Paramname, Paramvalue FROM T_Param WHERE Paramname LIKE 'FacturX_Entreprise_%'", cnn)
                Using rdr As SqlDataReader = cmd.ExecuteReader()
                    While rdr.Read()
                        valeurs(rdr.GetString(0)) = If(rdr.IsDBNull(1), "", rdr.GetString(1))
                    End While
                End Using
            End Using
        End Using

        Dim Get_ As Func(Of String, String) = Function(k As String)
                                                  If valeurs.ContainsKey(k) Then Return valeurs(k)
                                                  Return ""
                                              End Function

        p.Nom = Get_("FacturX_Entreprise_Nom")
        p.Adresse1 = Get_("FacturX_Entreprise_Adresse1")
        p.Adresse2 = Get_("FacturX_Entreprise_Adresse2")
        p.CodePostal = Get_("FacturX_Entreprise_CodePostal")
        p.Ville = Get_("FacturX_Entreprise_Ville")
        p.CodePays = If(String.IsNullOrEmpty(Get_("FacturX_Entreprise_CodePays")), "FR", Get_("FacturX_Entreprise_CodePays"))
        p.Siret = Get_("FacturX_Entreprise_Siret")
        p.Siren = If(String.IsNullOrEmpty(Get_("FacturX_Entreprise_Siren")) AndAlso p.Siret.Length >= 9, p.Siret.Substring(0, 9), Get_("FacturX_Entreprise_Siren"))
        p.NumeroTvaIntracom = Get_("FacturX_Entreprise_TvaIntracom")
        p.CodeAPE = Get_("FacturX_Entreprise_CodeAPE")
        p.FormeJuridique = Get_("FacturX_Entreprise_FormeJuridique")
        p.Capital = Get_("FacturX_Entreprise_Capital")
        p.Email = Get_("FacturX_Entreprise_Email")
        p.Telephone = Get_("FacturX_Entreprise_Telephone")
        p.Iban = Get_("FacturX_Entreprise_IBAN")
        p.Bic = Get_("FacturX_Entreprise_BIC")
        p.TitulaireCompte = Get_("FacturX_Entreprise_TitulaireCompte")
        Return p
    End Function

    ''' <summary>
    ''' Lit une facture (T_CommandeVente + T_CommandeVente_Ligne) et retourne
    ''' la structure DonneesFacture utilisée par le générateur.
    ''' </summary>
    Public Shared Function LireFacture(idCommandeVente As Long, connectionString As String) As DonneesFacture
        Dim f As New DonneesFacture()
        f.IdCommande = idCommandeVente

        Using cnn As New SqlConnection(connectionString)
            cnn.Open()

            ' En-tête commande + client
            Using cmd As New SqlCommand(
                "SELECT cv.ID_T_CommandeVente, cv.NoFacture, cv.FactureLe, " &
                "       cv.Total_HT, cv.Total_TTC, cv.Signature, cv.ModeReglement, " &
                "       cv.Société, cv.Nom, cv.Prénom, cv.AdresseL1, cv.AdresseL2, " &
                "       cv.CodePostal, cv.Ville, cv.Pays, cv.NoSiret, cv.NoTva, cv.Email, " &
                "       ISNULL(p.code_pays, 'FR') AS CodePays " &
                "FROM T_CommandeVente cv " &
                "LEFT JOIN T_Pays p ON p.libelle = cv.Pays " &
                "WHERE cv.ID_T_CommandeVente = @Id", cnn)
                cmd.Parameters.AddWithValue("@Id", idCommandeVente)
                Using rdr As SqlDataReader = cmd.ExecuteReader()
                    If Not rdr.Read() Then
                        Throw New Exception("Commande #" & idCommandeVente & " introuvable.")
                    End If
                    f.NumeroFacture = If(IsDBNull(rdr("NoFacture")), "F" & idCommandeVente.ToString("D8"), rdr("NoFacture").ToString())
                    f.DateFacture = If(IsDBNull(rdr("FactureLe")), DateTime.Now, CDate(rdr("FactureLe")))
                    f.DateEcheance = f.DateFacture.AddDays(30)
                    f.TotalHT = If(IsDBNull(rdr("Total_HT")), 0D, CDec(rdr("Total_HT")))
                    f.TotalTTC = If(IsDBNull(rdr("Total_TTC")), 0D, CDec(rdr("Total_TTC")))
                    f.TotalTVA = f.TotalTTC - f.TotalHT
                    f.NF525Signature = If(IsDBNull(rdr("Signature")), "", rdr("Signature").ToString())
                    f.ModeReglement = MapperModeReglement(If(IsDBNull(rdr("ModeReglement")), "", rdr("ModeReglement").ToString()))

                    f.Client.Societe = If(IsDBNull(rdr("Société")), "", rdr("Société").ToString())
                    f.Client.Nom = (If(IsDBNull(rdr("Nom")), "", rdr("Nom").ToString()) & " " &
                                    If(IsDBNull(rdr("Prénom")), "", rdr("Prénom").ToString())).Trim()
                    f.Client.Adresse1 = If(IsDBNull(rdr("AdresseL1")), "", rdr("AdresseL1").ToString())
                    f.Client.Adresse2 = If(IsDBNull(rdr("AdresseL2")), "", rdr("AdresseL2").ToString())
                    f.Client.CodePostal = If(IsDBNull(rdr("CodePostal")), "", rdr("CodePostal").ToString())
                    f.Client.Ville = If(IsDBNull(rdr("Ville")), "", rdr("Ville").ToString())
                    f.Client.CodePays = If(IsDBNull(rdr("CodePays")), "FR", rdr("CodePays").ToString())
                    f.Client.Siret = If(IsDBNull(rdr("NoSiret")), "", rdr("NoSiret").ToString())
                    f.Client.NumeroTvaIntracom = If(IsDBNull(rdr("NoTva")), "", rdr("NoTva").ToString())
                    f.Client.Email = If(IsDBNull(rdr("Email")), "", rdr("Email").ToString())
                End Using
            End Using

            ' Lignes de facture
            Using cmd2 As New SqlCommand(
                "SELECT l.ID_T_CommandeVente_Ligne, l.designation_ligne, l.reference_ligne, " &
                "       l.Qte, l.prix_unitaire_HT, l.prix_total_HT, l.prix_total_TTC, l.CodeTva " &
                "FROM T_CommandeVente_Ligne l " &
                "WHERE l.ID_T_CommandeVente = @Id " &
                "ORDER BY l.ID_T_CommandeVente_Ligne", cnn)
                cmd2.Parameters.AddWithValue("@Id", idCommandeVente)
                Using rdr As SqlDataReader = cmd2.ExecuteReader()
                    Dim num As Integer = 1
                    While rdr.Read()
                        Dim lf As New LigneFacture()
                        lf.Numero = num
                        num += 1
                        lf.Designation = If(IsDBNull(rdr("designation_ligne")), "", rdr("designation_ligne").ToString())
                        lf.ReferenceArticle = If(IsDBNull(rdr("reference_ligne")), "", rdr("reference_ligne").ToString())
                        lf.Quantite = If(IsDBNull(rdr("Qte")), 1D, CDec(rdr("Qte")))
                        lf.PrixUnitaireHT = If(IsDBNull(rdr("prix_unitaire_HT")), 0D, CDec(rdr("prix_unitaire_HT")))
                        lf.PrixTotalHT = If(IsDBNull(rdr("prix_total_HT")), 0D, CDec(rdr("prix_total_HT")))
                        lf.TauxTVA = If(IsDBNull(rdr("CodeTva")), 0D, CDec(rdr("CodeTva")))
                        f.Lignes.Add(lf)
                    End While
                End Using
            End Using
        End Using

        Return f
    End Function

    ''' <summary>Map mode règlement Chinook -> code UN/CEFACT 4461 utilisé par CII.</summary>
    Private Shared Function MapperModeReglement(modeChinook As String) As String
        Select Case modeChinook.Trim().ToUpper()
            Case "CB", "CARTE"
                Return "48" ' Bank card
            Case "VIREMENT", "VIR"
                Return "30" ' Credit transfer
            Case "CHEQUE", "CHÈQUE"
                Return "20"
            Case "ESPECES", "ESPÈCES", "CASH"
                Return "10"
            Case "PRELEVEMENT", "PRÉLÈVEMENT"
                Return "59" ' SEPA direct debit
            Case Else
                Return "1" ' Instrument not defined
        End Select
    End Function

#End Region

#Region "Construction du document XML CII v23"

    Private Shared Function BuildXml(f As DonneesFacture, p As ParametresEntreprise, profil As String) As String
        Dim doc As New XmlDocument()
        Dim decl As XmlDeclaration = doc.CreateXmlDeclaration("1.0", "UTF-8", Nothing)
        doc.AppendChild(decl)

        Dim root As XmlElement = doc.CreateElement("rsm", "CrossIndustryInvoice", NS_RSM)
        root.SetAttribute("xmlns:ram", NS_RAM)
        root.SetAttribute("xmlns:udt", NS_UDT)
        root.SetAttribute("xmlns:qdt", NS_QDT)
        doc.AppendChild(root)

        ' ── 1. ExchangedDocumentContext (profil + business process) ──
        Dim ctx As XmlElement = AppendElement(doc, root, "rsm", "ExchangedDocumentContext", NS_RSM)
        Dim bp As XmlElement = AppendElement(doc, ctx, "ram", "BusinessProcessSpecifiedDocumentContextParameter", NS_RAM)
        AppendElementText(doc, bp, "ram", "ID", NS_RAM, "A1")
        Dim guide As XmlElement = AppendElement(doc, ctx, "ram", "GuidelineSpecifiedDocumentContextParameter", NS_RAM)
        AppendElementText(doc, guide, "ram", "ID", NS_RAM, profil)

        ' ── 2. ExchangedDocument (en-tête facture) ──
        Dim head As XmlElement = AppendElement(doc, root, "rsm", "ExchangedDocument", NS_RSM)
        AppendElementText(doc, head, "ram", "ID", NS_RAM, f.NumeroFacture)
        AppendElementText(doc, head, "ram", "TypeCode", NS_RAM, "380") ' 380 = facture commerciale (UN/CEFACT 1001)

        Dim dt As XmlElement = AppendElement(doc, head, "ram", "IssueDateTime", NS_RAM)
        Dim dts As XmlElement = AppendElementText(doc, dt, "udt", "DateTimeString", NS_UDT, f.DateFacture.ToString("yyyyMMdd"))
        dts.SetAttribute("format", "102")

        ' Note NF525 : on insère la signature pour conformité mixte (BT-22)
        If Not String.IsNullOrEmpty(f.NF525Signature) Then
            Dim noteNF As XmlElement = AppendElement(doc, head, "ram", "IncludedNote", NS_RAM)
            AppendElementText(doc, noteNF, "ram", "Content", NS_RAM, "Signature NF525 : " & f.NF525Signature)
            AppendElementText(doc, noteNF, "ram", "SubjectCode", NS_RAM, "REG") ' REG = Régulatoire
        End If

        ' ── 3. SupplyChainTradeTransaction ──
        Dim tx As XmlElement = AppendElement(doc, root, "rsm", "SupplyChainTradeTransaction", NS_RSM)

        ' 3.1 IncludedSupplyChainTradeLineItem (une ligne par article)
        For Each l As LigneFacture In f.Lignes
            AppendLigneFacture(doc, tx, l)
        Next

        ' 3.2 ApplicableHeaderTradeAgreement (vendeur + acheteur)
        Dim agreement As XmlElement = AppendElement(doc, tx, "ram", "ApplicableHeaderTradeAgreement", NS_RAM)
        AppendVendeur(doc, agreement, p)
        AppendAcheteur(doc, agreement, f.Client)

        ' 3.3 ApplicableHeaderTradeDelivery (livraison = adresse client par défaut)
        Dim delivery As XmlElement = AppendElement(doc, tx, "ram", "ApplicableHeaderTradeDelivery", NS_RAM)
        Dim shipTo As XmlElement = AppendElement(doc, delivery, "ram", "ShipToTradeParty", NS_RAM)
        AppendElementText(doc, shipTo, "ram", "Name", NS_RAM, If(String.IsNullOrEmpty(f.Client.Societe), f.Client.Nom, f.Client.Societe))
        AppendAdressePostale(doc, shipTo, f.Client.Adresse1, f.Client.Adresse2, f.Client.CodePostal, f.Client.Ville, f.Client.CodePays)

        Dim deliveryDt As XmlElement = AppendElement(doc, delivery, "ram", "ActualDeliverySupplyChainEvent", NS_RAM)
        Dim deliveryDate As XmlElement = AppendElement(doc, deliveryDt, "ram", "OccurrenceDateTime", NS_RAM)
        Dim deliveryDateStr As XmlElement = AppendElementText(doc, deliveryDate, "udt", "DateTimeString", NS_UDT, f.DateFacture.ToString("yyyyMMdd"))
        deliveryDateStr.SetAttribute("format", "102")

        ' 3.4 ApplicableHeaderTradeSettlement (paiement + TVA + totaux)
        Dim settle As XmlElement = AppendElement(doc, tx, "ram", "ApplicableHeaderTradeSettlement", NS_RAM)
        AppendElementText(doc, settle, "ram", "InvoiceCurrencyCode", NS_RAM, f.DevisesCode)

        ' Moyen de paiement
        Dim payMeans As XmlElement = AppendElement(doc, settle, "ram", "SpecifiedTradeSettlementPaymentMeans", NS_RAM)
        AppendElementText(doc, payMeans, "ram", "TypeCode", NS_RAM, f.ModeReglement)
        AppendElementText(doc, payMeans, "ram", "Information", NS_RAM, "Paiement à 30 jours fin de mois")
        If Not String.IsNullOrEmpty(p.Iban) Then
            Dim payAccount As XmlElement = AppendElement(doc, payMeans, "ram", "PayeePartyCreditorFinancialAccount", NS_RAM)
            AppendElementText(doc, payAccount, "ram", "IBANID", NS_RAM, p.Iban)
            If Not String.IsNullOrEmpty(p.TitulaireCompte) Then
                AppendElementText(doc, payAccount, "ram", "AccountName", NS_RAM, p.TitulaireCompte)
            End If
            If Not String.IsNullOrEmpty(p.Bic) Then
                Dim payInst As XmlElement = AppendElement(doc, payMeans, "ram", "PayeeSpecifiedCreditorFinancialInstitution", NS_RAM)
                AppendElementText(doc, payInst, "ram", "BICID", NS_RAM, p.Bic)
            End If
        End If

        ' Ventilation TVA par taux (BG-23 ApplicableTradeTax)
        Dim tva As System.Collections.Generic.Dictionary(Of Decimal, Decimal) = ConsoliderTVA(f.Lignes)
        For Each kvp As System.Collections.Generic.KeyValuePair(Of Decimal, Decimal) In tva
            Dim taux As Decimal = kvp.Key
            Dim baseHT As Decimal = kvp.Value
            Dim montantTVA As Decimal = Math.Round(baseHT * taux / 100D, 2)

            Dim trTax As XmlElement = AppendElement(doc, settle, "ram", "ApplicableTradeTax", NS_RAM)
            AppendElementText(doc, trTax, "ram", "CalculatedAmount", NS_RAM, FormatDec(montantTVA))
            AppendElementText(doc, trTax, "ram", "TypeCode", NS_RAM, "VAT")
            AppendElementText(doc, trTax, "ram", "BasisAmount", NS_RAM, FormatDec(baseHT))
            AppendElementText(doc, trTax, "ram", "CategoryCode", NS_RAM, If(taux > 0, "S", "Z")) ' S=Standard, Z=Zero
            AppendElementText(doc, trTax, "ram", "RateApplicablePercent", NS_RAM, FormatDec(taux))
        Next

        ' Période de paiement
        Dim payTerms As XmlElement = AppendElement(doc, settle, "ram", "SpecifiedTradePaymentTerms", NS_RAM)
        AppendElementText(doc, payTerms, "ram", "Description", NS_RAM, "Paiement à réception")
        Dim dueDt As XmlElement = AppendElement(doc, payTerms, "ram", "DueDateDateTime", NS_RAM)
        Dim dueStr As XmlElement = AppendElementText(doc, dueDt, "udt", "DateTimeString", NS_UDT, f.DateEcheance.ToString("yyyyMMdd"))
        dueStr.SetAttribute("format", "102")

        ' Totaux (BG-22 SpecifiedTradeSettlementHeaderMonetarySummation)
        Dim summ As XmlElement = AppendElement(doc, settle, "ram", "SpecifiedTradeSettlementHeaderMonetarySummation", NS_RAM)
        AppendElementText(doc, summ, "ram", "LineTotalAmount", NS_RAM, FormatDec(f.TotalHT))
        AppendElementText(doc, summ, "ram", "TaxBasisTotalAmount", NS_RAM, FormatDec(f.TotalHT))
        Dim taxTotal As XmlElement = AppendElementText(doc, summ, "ram", "TaxTotalAmount", NS_RAM, FormatDec(f.TotalTVA))
        taxTotal.SetAttribute("currencyID", f.DevisesCode)
        AppendElementText(doc, summ, "ram", "GrandTotalAmount", NS_RAM, FormatDec(f.TotalTTC))
        AppendElementText(doc, summ, "ram", "DuePayableAmount", NS_RAM, FormatDec(f.TotalTTC))

        Return SerializeXml(doc)
    End Function

    ''' <summary>Insère un IncludedSupplyChainTradeLineItem pour une ligne de facture.</summary>
    Private Shared Sub AppendLigneFacture(doc As XmlDocument, parent As XmlElement, l As LigneFacture)
        Dim line As XmlElement = AppendElement(doc, parent, "ram", "IncludedSupplyChainTradeLineItem", NS_RAM)

        ' Identification ligne
        Dim assoc As XmlElement = AppendElement(doc, line, "ram", "AssociatedDocumentLineDocument", NS_RAM)
        AppendElementText(doc, assoc, "ram", "LineID", NS_RAM, l.Numero.ToString(CultureInfo.InvariantCulture))

        ' Produit
        Dim prod As XmlElement = AppendElement(doc, line, "ram", "SpecifiedTradeProduct", NS_RAM)
        If Not String.IsNullOrEmpty(l.ReferenceArticle) Then
            AppendElementText(doc, prod, "ram", "SellerAssignedID", NS_RAM, l.ReferenceArticle)
        End If
        AppendElementText(doc, prod, "ram", "Name", NS_RAM, l.Designation)

        ' Prix unitaire ligne
        Dim lineAgr As XmlElement = AppendElement(doc, line, "ram", "SpecifiedLineTradeAgreement", NS_RAM)
        Dim netPrice As XmlElement = AppendElement(doc, lineAgr, "ram", "NetPriceProductTradePrice", NS_RAM)
        AppendElementText(doc, netPrice, "ram", "ChargeAmount", NS_RAM, FormatDec(l.PrixUnitaireHT))

        ' Quantité ligne
        Dim lineDel As XmlElement = AppendElement(doc, line, "ram", "SpecifiedLineTradeDelivery", NS_RAM)
        Dim billedQty As XmlElement = AppendElementText(doc, lineDel, "ram", "BilledQuantity", NS_RAM, FormatDec(l.Quantite))
        billedQty.SetAttribute("unitCode", l.UnitePrix)

        ' Settlement ligne (TVA + total)
        Dim lineSet As XmlElement = AppendElement(doc, line, "ram", "SpecifiedLineTradeSettlement", NS_RAM)
        Dim lineTax As XmlElement = AppendElement(doc, lineSet, "ram", "ApplicableTradeTax", NS_RAM)
        AppendElementText(doc, lineTax, "ram", "TypeCode", NS_RAM, "VAT")
        AppendElementText(doc, lineTax, "ram", "CategoryCode", NS_RAM, If(l.TauxTVA > 0, "S", "Z"))
        AppendElementText(doc, lineTax, "ram", "RateApplicablePercent", NS_RAM, FormatDec(l.TauxTVA))

        Dim lineSumm As XmlElement = AppendElement(doc, lineSet, "ram", "SpecifiedTradeSettlementLineMonetarySummation", NS_RAM)
        AppendElementText(doc, lineSumm, "ram", "LineTotalAmount", NS_RAM, FormatDec(l.PrixTotalHT))
    End Sub

    Private Shared Sub AppendVendeur(doc As XmlDocument, parent As XmlElement, p As ParametresEntreprise)
        Dim seller As XmlElement = AppendElement(doc, parent, "ram", "SellerTradeParty", NS_RAM)
        AppendElementText(doc, seller, "ram", "Name", NS_RAM, p.Nom)

        ' Organisation légale (SIRET + forme juridique)
        If Not String.IsNullOrEmpty(p.Siret) Then
            Dim legal As XmlElement = AppendElement(doc, seller, "ram", "SpecifiedLegalOrganization", NS_RAM)
            Dim siretEl As XmlElement = AppendElementText(doc, legal, "ram", "ID", NS_RAM, p.Siret)
            siretEl.SetAttribute("schemeID", "0009") ' 0009 = SIRET FR
            If Not String.IsNullOrEmpty(p.FormeJuridique) Then
                AppendElementText(doc, legal, "ram", "TradingBusinessName", NS_RAM, p.Nom & " " & p.FormeJuridique)
            End If
        End If

        ' Adresse
        AppendAdressePostale(doc, seller, p.Adresse1, p.Adresse2, p.CodePostal, p.Ville, p.CodePays)

        ' Email vendeur
        If Not String.IsNullOrEmpty(p.Email) Then
            Dim contact As XmlElement = AppendElement(doc, seller, "ram", "DefinedTradeContact", NS_RAM)
            Dim contactEmail As XmlElement = AppendElement(doc, contact, "ram", "EmailURIUniversalCommunication", NS_RAM)
            AppendElementText(doc, contactEmail, "ram", "URIID", NS_RAM, p.Email).SetAttribute("schemeID", "EM")
        End If

        ' TVA intracom (FC = no TVA, VA = numéro TVA)
        If Not String.IsNullOrEmpty(p.NumeroTvaIntracom) Then
            Dim taxReg As XmlElement = AppendElement(doc, seller, "ram", "SpecifiedTaxRegistration", NS_RAM)
            Dim taxId As XmlElement = AppendElementText(doc, taxReg, "ram", "ID", NS_RAM, p.NumeroTvaIntracom)
            taxId.SetAttribute("schemeID", "VA")
        End If
    End Sub

    Private Shared Sub AppendAcheteur(doc As XmlDocument, parent As XmlElement, c As DonneesClient)
        Dim buyer As XmlElement = AppendElement(doc, parent, "ram", "BuyerTradeParty", NS_RAM)
        Dim nomAcheteur As String = If(String.IsNullOrEmpty(c.Societe), c.Nom, c.Societe)
        AppendElementText(doc, buyer, "ram", "Name", NS_RAM, nomAcheteur)

        ' Si client professionnel : ajouter SIRET
        If Not String.IsNullOrEmpty(c.Siret) Then
            Dim legal As XmlElement = AppendElement(doc, buyer, "ram", "SpecifiedLegalOrganization", NS_RAM)
            Dim siretEl As XmlElement = AppendElementText(doc, legal, "ram", "ID", NS_RAM, c.Siret)
            siretEl.SetAttribute("schemeID", "0009")
        End If

        AppendAdressePostale(doc, buyer, c.Adresse1, c.Adresse2, c.CodePostal, c.Ville, c.CodePays)

        If Not String.IsNullOrEmpty(c.Email) Then
            Dim contact As XmlElement = AppendElement(doc, buyer, "ram", "DefinedTradeContact", NS_RAM)
            Dim contactEmail As XmlElement = AppendElement(doc, contact, "ram", "EmailURIUniversalCommunication", NS_RAM)
            AppendElementText(doc, contactEmail, "ram", "URIID", NS_RAM, c.Email).SetAttribute("schemeID", "EM")
        End If

        If Not String.IsNullOrEmpty(c.NumeroTvaIntracom) Then
            Dim taxReg As XmlElement = AppendElement(doc, buyer, "ram", "SpecifiedTaxRegistration", NS_RAM)
            Dim taxId As XmlElement = AppendElementText(doc, taxReg, "ram", "ID", NS_RAM, c.NumeroTvaIntracom)
            taxId.SetAttribute("schemeID", "VA")
        End If
    End Sub

    Private Shared Sub AppendAdressePostale(doc As XmlDocument, parent As XmlElement,
                                            l1 As String, l2 As String, cp As String, ville As String, pays As String)
        Dim addr As XmlElement = AppendElement(doc, parent, "ram", "PostalTradeAddress", NS_RAM)
        AppendElementText(doc, addr, "ram", "PostcodeCode", NS_RAM, cp)
        AppendElementText(doc, addr, "ram", "LineOne", NS_RAM, l1)
        If Not String.IsNullOrEmpty(l2) Then
            AppendElementText(doc, addr, "ram", "LineTwo", NS_RAM, l2)
        End If
        AppendElementText(doc, addr, "ram", "CityName", NS_RAM, ville)
        AppendElementText(doc, addr, "ram", "CountryID", NS_RAM, If(String.IsNullOrEmpty(pays), "FR", pays))
    End Sub

    Private Shared Function ConsoliderTVA(lignes As System.Collections.Generic.List(Of LigneFacture)) As System.Collections.Generic.Dictionary(Of Decimal, Decimal)
        Dim dico As New System.Collections.Generic.Dictionary(Of Decimal, Decimal)()
        For Each l As LigneFacture In lignes
            If Not dico.ContainsKey(l.TauxTVA) Then dico.Add(l.TauxTVA, 0D)
            dico(l.TauxTVA) += l.PrixTotalHT
        Next
        Return dico
    End Function

#End Region

#Region "Helpers XML"

    Private Shared Function AppendElement(doc As XmlDocument, parent As XmlElement,
                                          prefix As String, localName As String, ns As String) As XmlElement
        Dim el As XmlElement = doc.CreateElement(prefix, localName, ns)
        parent.AppendChild(el)
        Return el
    End Function

    Private Shared Function AppendElementText(doc As XmlDocument, parent As XmlElement,
                                              prefix As String, localName As String, ns As String, value As String) As XmlElement
        Dim el As XmlElement = doc.CreateElement(prefix, localName, ns)
        el.InnerText = If(value, "")
        parent.AppendChild(el)
        Return el
    End Function

    Private Shared Function FormatDec(d As Decimal) As String
        Return d.ToString("F2", CultureInfo.InvariantCulture)
    End Function

    Private Shared Function SerializeXml(doc As XmlDocument) As String
        Dim settings As New XmlWriterSettings()
        settings.Indent = True
        settings.Encoding = New UTF8Encoding(False)
        settings.OmitXmlDeclaration = False
        Using sw As New StringWriter()
            Using writer As XmlWriter = XmlWriter.Create(sw, settings)
                doc.Save(writer)
            End Using
            ' StringWriter est UTF-16, donc on remplace l'encodage déclaré pour cohérence
            Return sw.ToString().Replace("utf-16", "UTF-8")
        End Using
    End Function

#End Region

End Class
