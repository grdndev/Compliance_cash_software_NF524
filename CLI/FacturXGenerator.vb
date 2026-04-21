' =============================================
' NF525 REFORME 2026 - FACTUR-X GENERATOR
' =============================================
' Date: 2026-02-16
' Auteur: Antigravity
' Description: 
'   Moteur de génération du fichier XML Factur-X (Norme EN 16931)
'   Profil: BASIC
'   Ce module construit le fichier XML qui sera intégré au PDF/A-3
' =============================================

Imports System.Xml
Imports System.IO
Imports System.Text

Public Class FacturXGenerator

    ''' <summary>
    ''' Génère le XML Factur-X pour une vente donnée
    ''' </summary>
    ''' <param name="vente">Données de la vente (T_CommandeVente)</param>
    ''' <param name="lignes">Lignes de la vente</param>
    ''' <param name="client">Informations client</param>
    ''' <returns>String contenant le XML complet</returns>
    Public Shared Function GenerateXML(vente As DataRow, lignes As DataTable, client As DataRow) As String
        Dim xmlDoc As New XmlDocument()
        
        ' 1. Déclaration Espace de noms
        Dim root As XmlElement = xmlDoc.CreateElement("rsm:CrossIndustryInvoice", "urn:un:unece:uncefact:data:standard:CrossIndustryInvoice:100")
        root.SetAttribute("xmlns:rsm", "urn:un:unece:uncefact:data:standard:CrossIndustryInvoice:100")
        root.SetAttribute("xmlns:ram", "urn:un:unece:uncefact:data:standard:ReusableAggregateBusinessInformationEntity:100")
        root.SetAttribute("xmlns:udt", "urn:un:unece:uncefact:data:standard:UnqualifiedDataType:100")
        xmlDoc.AppendChild(root)

        ' 2. Contexte (Profil BASIC)
        Dim context As XmlElement = CreateElement(xmlDoc, "rsm:ExchangedDocumentContext", "")
        Dim guideline As XmlElement = CreateElement(xmlDoc, "ram:GuidelineSpecifiedDocumentContextParameter", "")
        guideline.AppendChild(CreateElement(xmlDoc, "ram:ID", "urn:cen.eu:en16931:2017#compliant#urn:factur-x.eu:1p0:basic"))
        context.AppendChild(guideline)
        root.AppendChild(context)

        ' 3. Document Header (Numéro de facture, Date, Type)
        Dim header As XmlElement = CreateElement(xmlDoc, "rsm:ExchangedDocument", "")
        header.AppendChild(CreateElement(xmlDoc, "ram:ID", vente("NoPiece").ToString())) ' Numéro Facture
        header.AppendChild(CreateElement(xmlDoc, "ram:TypeCode", "380")) ' 380 = Facture commerciale
        
        Dim issueDate As XmlElement = CreateElement(xmlDoc, "ram:IssueDateTime", "")
        Dim dateString As String = CType(vente("DatePiece"), DateTime).ToString("yyyyMMdd")
        Dim dateNode As XmlElement = CreateElement(xmlDoc, "udt:DateTimeString", dateString)
        dateNode.SetAttribute("format", "102") ' YYYYMMDD
        issueDate.AppendChild(dateNode)
        header.AppendChild(issueDate)

        ' --- INTEGRATION NF525 ---
        ' On insère la signature NF525 dans une note incluse
        ' C'est CRUCIAL pour la conformité mixte
        Dim noteNF525 As XmlElement = CreateElement(xmlDoc, "ram:IncludedNote", "")
        noteNF525.AppendChild(CreateElement(xmlDoc, "ram:Content", "Signature NF525: " & vente("Signature").ToString()))
        noteNF525.AppendChild(CreateElement(xmlDoc, "ram:SubjectCode", "ADV")) ' Avenant / Information légale
        header.AppendChild(noteNF525)
        ' -------------------------

        root.AppendChild(header)

        ' 4. Transaction
        Dim transaction As XmlElement = CreateElement(xmlDoc, "rsm:SupplyChainTradeTransaction", "")

        ' 4.1. Lignes de facture
        Dim lineItem As XmlElement = CreateElement(xmlDoc, "ram:IncludedSupplyChainTradeLineItem", "")
        ' Note: Dans Basic, on peut simplifier en ne mettant que les totaux, 
        ' ou itérer sur les lignes si nécessaire. Pour l'instant, on fait simple pour le POC.
        ' TODO: Boucle sur les lignes (DataTable)
        transaction.AppendChild(lineItem)

        ' 4.2. Header Trade Agreement (Vendeur / Acheteur)
        Dim agreement As XmlElement = CreateElement(xmlDoc, "ram:ApplicableHeaderTradeAgreement", "")
        
        ' Vendeur (Nous)
        Dim seller As XmlElement = CreateElement(xmlDoc, "ram:SellerTradeParty", "")
        seller.AppendChild(CreateElement(xmlDoc, "ram:Name", "CHINOOK LEUCATE")) ' TODO: Paramètre
        Dim sellerLegal As XmlElement = CreateElement(xmlDoc, "ram:SpecifiedLegalOrganization", "")
        sellerLegal.AppendChild(CreateElement(xmlDoc, "ram:ID", "48450148100010")) ' SIRET Vendeur
        sellerLegal.LastChild.SetAttribute("schemeID", "0009") ' 0009 = SIRET
        seller.AppendChild(sellerLegal)
        agreement.AppendChild(seller)

        ' Acheteur (Client)
        Dim buyer As XmlElement = CreateElement(xmlDoc, "ram:BuyerTradeParty", "")
        buyer.AppendChild(CreateElement(xmlDoc, "ram:Name", client("Nom").ToString()))
        Dim buyerLegal As XmlElement = CreateElement(xmlDoc, "ram:SpecifiedLegalOrganization", "")
        ' Gestion SIRET Client (si pro)
        If client.Table.Columns.Contains("NoSiret") AndAlso Not String.IsNullOrEmpty(client("NoSiret").ToString()) Then
            Dim siretClient As XmlElement = CreateElement(xmlDoc, "ram:ID", client("NoSiret").ToString())
            siretClient.SetAttribute("schemeID", "0009")
            buyerLegal.AppendChild(siretClient)
        End If
        buyer.AppendChild(buyerLegal)
        agreement.AppendChild(buyer)
        transaction.AppendChild(agreement)

        ' 4.3. Header Trade Delivery (Livraison)
        Dim delivery As XmlElement = CreateElement(xmlDoc, "ram:ApplicableHeaderTradeDelivery", "")
        ' Adresse Livraison
        Dim shipTo As XmlElement = CreateElement(xmlDoc, "ram:ShipToTradeParty", "")
        shipTo.AppendChild(CreateElement(xmlDoc, "ram:Name", client("Nom").ToString()))
        
        Dim postalVars As XmlElement = CreateElement(xmlDoc, "ram:PostalTradeAddress", "")
        postalVars.AppendChild(CreateElement(xmlDoc, "ram:PostcodeCode", client("CodePostal").ToString()))
        postalVars.AppendChild(CreateElement(xmlDoc, "ram:LineOne", client("Adresse").ToString()))
        postalVars.AppendChild(CreateElement(xmlDoc, "ram:CityName", client("Ville").ToString()))
        postalVars.AppendChild(CreateElement(xmlDoc, "ram:CountryID", "FR")) ' TODO: Mapper T_Pays
        
        shipTo.AppendChild(postalVars)
        delivery.AppendChild(shipTo)
        transaction.AppendChild(delivery)

        ' 4.4. Header Trade Settlement (Totaux & Taxes)
        Dim settlement As XmlElement = CreateElement(xmlDoc, "ram:ApplicableHeaderTradeSettlement", "")
        
        ' Monnaie
        settlement.AppendChild(CreateElement(xmlDoc, "ram:InvoiceCurrencyCode", "EUR"))

        ' Totaux (Map sur T_CommandeVente)
        Dim summation As XmlElement = CreateElement(xmlDoc, "ram:SpecifiedTradeSettlementHeaderMonetarySummation", "")
        
        ' Total HT
        Dim totalHT As Decimal = Convert.ToDecimal(vente("Total_HT"))
        summation.AppendChild(CreateElement(xmlDoc, "ram:LineTotalAmount", totalHT.ToString("F2").Replace(",", ".")))
        
        ' Total Taxes
        Dim totalTVA As Decimal = Convert.ToDecimal(vente("Total_TVA"))
        summation.AppendChild(CreateElement(xmlDoc, "ram:TaxBasisTotalAmount", totalTVA.ToString("F2").Replace(",", ".")))
        
        ' Total TTC (Grand Total)
        Dim totalTTC As Decimal = Convert.ToDecimal(vente("Total_TTC"))
        summation.AppendChild(CreateElement(xmlDoc, "ram:GrandTotalAmount", totalTTC.ToString("F2").Replace(",", ".")))
        
        ' Montant dû
        summation.AppendChild(CreateElement(xmlDoc, "ram:DuePayableAmount", totalTTC.ToString("F2").Replace(",", ".")))

        settlement.AppendChild(summation)
        transaction.AppendChild(settlement)

        root.AppendChild(transaction)

        ' Conversion en string
        Using sw As New StringWriter()
            Using xw As New XmlTextWriter(sw)
                xw.Formatting = Formatting.Indented
                xmlDoc.WriteTo(xw)
            End Using
            Return sw.ToString()
        End Using
    End Function

    ''' <summary>
    ''' Helper pour créer un élément XML avec ou sans préfixe
    ''' </summary>
    Private Shared Function CreateElement(doc As XmlDocument, name As String, value As String) As XmlElement
        Dim parts As String() = name.Split(":"c)
        Dim el As XmlElement
        If parts.Length > 1 Then
            ' Avec namespace (rsm, ram, udt)
            Dim prefix As String = parts(0)
            Dim localName As String = parts(1)
            ' Trouver l'URI correspondant au préfixe
            Dim namespaceURI As String = ""
            Select Case prefix
                Case "rsm" : namespaceURI = "urn:un:unece:uncefact:data:standard:CrossIndustryInvoice:100"
                Case "ram" : namespaceURI = "urn:un:unece:uncefact:data:standard:ReusableAggregateBusinessInformationEntity:100"
                Case "udt" : namespaceURI = "urn:un:unece:uncefact:data:standard:UnqualifiedDataType:100"
            End Select
            el = doc.CreateElement(prefix, localName, namespaceURI)
        Else
            el = doc.CreateElement(name)
        End If

        If Not String.IsNullOrEmpty(value) Then
            el.InnerText = value
        End If
        Return el
    End Function

    ''' <summary>
    ''' Fusionne le PDF visuel et le XML Factur-X en un PDF/A-3
    ''' Nécessite la librairie PdfSharp (disponible via NuGet)
    ''' </summary>
    Public Shared Sub AttachXMLToPDF(pdfPath As String, xmlContent As String, outputPath As String)
        ' NOTE: Cette méthode est un STUB pour l'implémentation future avec PdfSharp
        ' Elle simule le comportement ou nécessite la référence DLL
        
        Try
            ' 1. Sauvegarder XML temporaire
            Dim xmlPath As String = Path.ChangeExtension(outputPath, ".xml")
            File.WriteAllText(xmlPath, xmlContent, Encoding.UTF8)
            
            ' 2. Simulation PDF/A-3
            ' Si PdfSharp n'est pas dispo, on copie juste le PDF original
            File.Copy(pdfPath, outputPath, True)
            
            ' TODO: Décommenter et adapter quand PdfSharp.dll sera référencée
            ' Using doc As PdfDocument = PdfReader.Open(pdfPath, PdfDocumentOpenMode.Modify)
            '     ' Créer l'attachement
            '     Dim attachment As New PdfDictionary(doc)
            '     attachment.Elements("/Type") = new PdfName("/Filespec")
            '     attachment.Elements("/F") = new PdfString("factur-x.xml")
            '     attachment.Elements("/UF") = new PdfString("factur-x.xml")
            '     attachment.Elements("/Desc") = new PdfString("Factur-X Invoice Data")
            '     
            '     Dim stream As New PdfDictionary(doc)
            '     ' ... Ajouter contenu XML au stream ...
            '     
            '     ' Ajouter aux EmbeddedFiles
            '     doc.Save(outputPath)
            ' End Using
            
        Catch ex As Exception
            Throw New Exception("Erreur lors de la création du PDF/A-3 : " & ex.Message)
        End Try
    End Sub

End Class
