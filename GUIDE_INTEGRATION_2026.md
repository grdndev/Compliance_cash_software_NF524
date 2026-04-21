# 🔌 GUIDE D'INTÉGRATION - RÉFORME 2026

Ce document explique comment brancher les nouveaux modules **Factur-X** et **E-Reporting** (disponibles dans `/CLI`) au logiciel CLI existant.

---

## 1. Factur-X (B2B) - Génération de Factures

**Fichier cible** : `CLI/FormCaisse.vb`
**Méthode cible** : `PrintFacture(...)` ou événement clic Bouton Impression

### Code à insérer :

```vb
' 1. Générer le PDF visuel (existant)
Dim pdfBytes As Byte() = ReportViewer.LocalReport.Render("PDF", ...)
Dim tempPdfPath As String = Path.GetTempFileName() & ".pdf"
File.WriteAllBytes(tempPdfPath, pdfBytes)

' 2. Préparer les données pour Factur-X
' Récupérer DataRow de la vente et du client
Dim venteRow As DataRow = ...
Dim linesTable As DataTable = ... 
Dim clientRow As DataRow = ...

' 3. Générer le XML EN16931
Dim xmlContent As String = FacturXGenerator.GenerateXML(venteRow, linesTable, clientRow)

' 4. Fusionner en PDF/A-3 (Facture Finale)
Dim finalPdfPath As String = "C:\Factures\Factur-X_" & venteRow("NoPiece") & ".pdf"
FacturXGenerator.AttachXMLToPDF(tempPdfPath, xmlContent, finalPdfPath)

' 5. Ouvrir ou Imprimer le PDF/A-3
Process.Start(finalPdfPath)
```

⚠️ **Prérequis** : Assurez-vous que `PdfSharp.dll` est référencée dans le projet pour que la fusion fonctionne réellement.

---

## 2. E-Reporting (B2C) - Transmission Décadaire

**Fichier cible** : `CLI/FormPrincipale.vb` (Menu Admin) ou Service Windows
**Déclencheur** : Tâche planifiée ou Bouton "Transmettre E-Reporting"

### Code à insérer :

```vb
' 1. Définir la période (ex: 10 derniers jours)
Dim endDate As DateTime = DateTime.Now
Dim startDate As DateTime = endDate.AddDays(-10)

' 2. Instancier le service
Dim reportingService As New EReportingService(My.Settings.CLIConnectionString)

' 3. Générer le rapport XML
Dim reportXml As String = reportingService.GenerateReport(startDate, endDate)

If reportXml = "AUCUNE_DONNEE" Then
    MessageBox.Show("Aucune clôture à transmettre pour cette période.")
    Exit Sub
End If

' 4. Transmettre (Simulé via écriture ficher)
If reportingService.TransmitReport(reportXml) Then
    MessageBox.Show("✅ Rapport E-Reporting transmis avec succès dans /Exports.")
Else
    MessageBox.Show("❌ Erreur lors de la transmission.")
End If
```

---

## 3. Dépendances

- **System.Xml** (Standard)
- **PdfSharp** (NuGet package à installer pour la partie fusion PDF)
- **Tables NF525** (Phase 2) : `T_Cloture` doit être alimentée correctement pour que le E-Reporting fonctionne.

---

**État au 16/02/2026** :
- Les classes de génération (`FacturXGenerator`, `EReportingService`) sont prêtes ✅.
- La logique métier (XML EN16931 Basic) est implémentée ✅.
- La connectivité API réelle (PDP) reste à configurer avec les identifiants de production du client.
