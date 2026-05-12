# Guide — Facturation électronique 2026-2027

**Logiciel :** CHINOOK LEUCATE — CLI 4.0
**Réforme :** Ordonnance n° 2021-1190 (15/09/2021) + Décret n° 2022-1299 + Loi de finances 2024
**Cible :** PME (SARL Chinook ≤ 250 salariés)

---

## 1. Le calendrier légal

| Échéance | Qui | Obligation |
|----------|-----|------------|
| **1er sept. 2026** | Toutes les entreprises | **Réception** des factures électroniques B2B obligatoire |
| **1er sept. 2026** | Grandes entreprises + ETI | **Émission** Factur-X / UBL / CII obligatoire |
| **1er sept. 2027** | PME et TPE (≈ Chinook) | **Émission** Factur-X / UBL / CII obligatoire |
| **1er sept. 2027** | Toutes les entreprises | **e-Reporting** B2C obligatoire (cas Chinook : ventes magasin) |

→ Pour Chinook (SARL = PME) :
- **Avant sept. 2026** : capacité à **recevoir** les factures de fournisseurs au format électronique
- **Avant sept. 2027** : capacité à **émettre** des factures B2B en Factur-X et à transmettre les ventes B2C en e-Reporting

---

## 2. Vue d'ensemble de l'implémentation CLI 4.0

```
┌──────────────────────┐                   ┌──────────────────────┐
│ Vente magasin (B2C)  │                   │ Vente pro (B2B)      │
│ FormCaisse           │                   │ FormCaisse — facture │
└──────────┬───────────┘                   └──────────┬───────────┘
           │                                          │
           │ ticket Z signé NF525                     │ Factur-X PDF/A-3
           ▼                                          ▼
   ┌──────────────────┐                       ┌──────────────────┐
   │ T_Cloture        │                       │ FacturXGenerator │
   │ (signature       │                       │  → XML CII v23   │
   │  chaînée)        │                       └────────┬─────────┘
   └─────────┬────────┘                                │
             │ décade                                  │ + PDF visuel
             ▼                                         ▼
   ┌──────────────────────┐                  ┌──────────────────────┐
   │ EReportingService    │                  │ FacturXPdfEmbedder   │
   │  → XML DGFiP         │                  │  → PDF/A-3 + XMP     │
   │  → HTTP POST PDP     │                  │  → Factur-X marker   │
   └─────────┬────────────┘                  └─────────┬────────────┘
             │                                         │
             └──────────┬──────────────────────────────┘
                        ▼
              ┌──────────────────────────┐
              │ PDP (Plateforme tierce)  │
              │ Pennylane / Esker /      │
              │ Sage Network / Generix   │
              └──────────┬───────────────┘
                         │ + factures fournisseurs entrantes
                         ▼
              ┌──────────────────────────┐
              │ FactureElectronique-     │
              │ Receiver (poll PDP)      │
              │  → T_FactureElectronique │
              │    _Recue                │
              └──────────────────────────┘
```

---

## 3. Modules livrés

### 3.1 [`CLI/FacturXGenerator.vb`](CLI/FacturXGenerator.vb) — Émission Factur-X

Génère le XML CII v23 conforme à la norme EN 16931 et au profil Factur-X.

**Profils supportés** : `MINIMUM`, `BASIC WL`, `BASIC`, `EN 16931`, `EXTENDED`.

**Utilisation depuis le code :**

```vb
' Génération directe depuis l'ID commande
Dim xml As String = FacturXGenerator.GenerateXML(
    idCommandeVente:=12345,
    connectionString:=My.Settings.CLIConnectionString,
    profil:=FacturXGenerator.PROFIL_EN16931)
```

**Données récupérées automatiquement :**
- En-tête facture : NoFacture, FactureLe, Total_HT, Total_TTC, Signature NF525, ModeReglement
- Client : Société, Nom, Prénom, AdresseL1/L2, CodePostal, Ville, Pays, NoSiret, NoTva, Email
- Lignes : designation, reference, Qte, prix_unitaire_HT, prix_total_HT, CodeTva
- Paramètres entreprise lus depuis `T_Params` (clés `FacturX_Entreprise_*`)

### 3.2 [`CLI/FacturXPdfEmbedder.vb`](CLI/FacturXPdfEmbedder.vb) — Production PDF/A-3

Embarque le XML Factur-X dans un PDF existant (généré par les rapports RDLC) par **incremental update PDF** — aucune dépendance externe.

**Utilisation depuis le code :**

```vb
Dim xml As String = FacturXGenerator.GenerateXML(idCmd, connStr, FacturXGenerator.PROFIL_EN16931)
FacturXPdfEmbedder.AttachToPdfA3(
    pdfPath:="C:\Temp\facture_visuelle.pdf",
    xmlContent:=xml,
    outputPath:="C:\Exports\facture_facturx.pdf",
    profil:="EN16931")
```

Le PDF de sortie contient :
- Le PDF d'origine intact (visuel)
- Un objet **EmbeddedFile** `factur-x.xml`
- Un **AFRelationship** `/Source` au niveau du Catalog
- Le **XMP metadata** marquant le document comme PDF/A-3 + Factur-X

> NB : pour un PDF/A-3b strictement conforme (chaîne de fontes, profil ICC, transparence interdite), le PDF source doit déjà être généré en PDF/A. La conformité PDF/A-3 stricte peut être assurée par la PDP lors de la transmission.

### 3.3 [`CLI/EReportingService.vb`](CLI/EReportingService.vb) — e-Reporting B2C agrégé

Pour les ventes magasin (B2C — comptoir, sans facture nominative), Chinook doit transmettre un **e-Reporting agrégé** à la DGFiP via une PDP, à fréquence **décadaire** (tous les 10 jours par défaut).

**Utilisation :**

```vb
Dim svc As New EReportingService(My.Settings.CLIConnectionString)

' Exécution d'un cycle décadaire (typiquement le 11 du mois pour la décade 1-10)
Dim ok As Boolean = svc.ExecuterCycleEReporting(
    dateDebut:=New DateTime(2026, 9, 1),
    dateFin:=New DateTime(2026, 9, 10))

' Rejeu des cycles en échec (à appeler par un scheduler ou bouton admin)
Dim nb As Integer = svc.RejouerEnEchec()
```

**Contenu du XML transmis :**
- En-tête : SIRET, NomEntreprise, période, date génération
- Pour chaque jour de la décade : TotalTTC, TotalHT, NbTickets, GrandTotal Perpétuel, signature de clôture, ventilation TVA par taux

### 3.4 [`CLI/FactureElectroniqueReceiver.vb`](CLI/FactureElectroniqueReceiver.vb) — Réception

À partir du **1er septembre 2026**, Chinook doit pouvoir **recevoir** les factures de ses fournisseurs au format électronique. Ce service :

1. Poll la PDP via HTTP GET pour lister les factures fournisseur en attente
2. Télécharge chaque PDF Factur-X
3. Extrait le XML embarqué (méthode `ExtraireXmlDuPdf`)
4. Parse le XML CII pour pré-remplir les champs (`ParserXmlFacturX`)
5. Insère dans `T_FactureElectronique_Recue` avec statut `RECUE`
6. Trace dans le JET (événements `RECEPTION_FACTURE_ELEC`)

**Utilisation :**

```vb
Dim recv As New FactureElectroniqueReceiver(My.Settings.CLIConnectionString)
Dim nb As Integer = recv.ExecuterCycleReception()
```

Idéalement appelé par un **scheduler externe** (Tâche planifiée Windows) à fréquence horaire ou quotidienne.

---

## 4. Schéma de base de données

Cf. [`05_facturation_electronique.sql`](05_facturation_electronique.sql)

### Table `T_FactureElectronique_Emise`
Trace toute facture émise (Factur-X ou e-Reporting) avec son cycle de vie complet :
`INITIE → TRANSMIS → ACCEPTE_PDP → ACCEPTE_DGFIP → ENCAISSE` (ou `REJETE_PDP` / `REJETE_DGFIP` / `ECHEC`).

Triggers append-only : la suppression est interdite (mêmes principes que NF525 sur T_JournalEvenements).

### Table `T_FactureElectronique_Recue`
Stocke les factures fournisseurs reçues via la PDP, avec leur statut métier :
`RECUE → EN_COURS_VALIDATION → VALIDEE → PAYEE` (ou `REFUSEE` / `LITIGE`).

Contient le PDF binaire + le XML extrait pour audit et historique.

---

## 5. Configuration PDP

### 5.1 Choix d'une PDP

| PDP | Public cible | Pricing indicatif | Avantages |
|-----|-------------|-------------------|-----------|
| **Pennylane** | TPE/PME | 30-60 € HT/mois | Simple, comptable intégré, API claire |
| **Esker** | PME/ETI | sur devis | Intégrations PrestaShop natives |
| **Sage Network** | Clients Sage | inclus comptabilité | Si Chinook utilise Sage |
| **Generix** | Retail | sur devis | Spécialisé commerce |
| **Yooz** | PME multi-sites | sur devis | Focus dématérialisation totale |
| **Tessi Documents** | Tous | sur devis | Acteur historique |

→ **Pour Chinook** : Pennylane est recommandée pour le ratio coût/simplicité.

### 5.2 Configuration dans `T_Params`

Après souscription PDP :

```sql
UPDATE T_Params SET Paramvalue = 'https://api.pennylane.com/v1' WHERE Paramname = 'PDP_API_URL';
UPDATE T_Params SET Paramvalue = 'votre_api_key_ici'            WHERE Paramname = 'PDP_API_KEY';
UPDATE T_Params SET Paramvalue = 'BEARER'                       WHERE Paramname = 'PDP_API_AUTH_TYPE';
UPDATE T_Params SET Paramvalue = 'Pennylane'                    WHERE Paramname = 'PDP_NOM';
```

Adapter les endpoints aux URL exactes de la PDP retenue :

```sql
UPDATE T_Params SET Paramvalue = 'invoices/submit'              WHERE Paramname = 'PDP_API_ENDPOINT_FACTURX';
UPDATE T_Params SET Paramvalue = 'ereporting/submit'            WHERE Paramname = 'PDP_API_ENDPOINT_ER';
UPDATE T_Params SET Paramvalue = 'invoices/inbox?status=new'    WHERE Paramname = 'PDP_API_ENDPOINT_INBOX';
UPDATE T_Params SET Paramvalue = 'invoices/{id}/download'       WHERE Paramname = 'PDP_API_ENDPOINT_DOWNLOAD';
```

### 5.3 Paramètres entreprise

Compléter les coordonnées Chinook **avant toute émission Factur-X** :

```sql
UPDATE T_Params SET Paramvalue = 'FR40484501481'      WHERE Paramname = 'FacturX_Entreprise_TvaIntracom';
UPDATE T_Params SET Paramvalue = 'FR76 ...'           WHERE Paramname = 'FacturX_Entreprise_IBAN';
UPDATE T_Params SET Paramvalue = 'BNPAFRPP...'        WHERE Paramname = 'FacturX_Entreprise_BIC';
UPDATE T_Params SET Paramvalue = 'CHINOOK SARL'       WHERE Paramname = 'FacturX_Entreprise_TitulaireCompte';
UPDATE T_Params SET Paramvalue = '47.71Z'             WHERE Paramname = 'FacturX_Entreprise_CodeAPE';
UPDATE T_Params SET Paramvalue = '10000'              WHERE Paramname = 'FacturX_Entreprise_Capital';
```

---

## 6. Plan de tests

### 6.1 Test émission Factur-X
1. Créer une facture B2B (client avec SIRET) dans CLI sur la base DEV
2. Exécuter dans une console VB :
   ```vb
   Dim xml = FacturXGenerator.GenerateXML(idCommande, My.Settings.CLIConnectionString)
   File.WriteAllText("C:\Temp\facture.xml", xml)
   ```
3. Valider le XML via un validateur Factur-X (ex : https://services.fnfe-mpe.org/)
4. Embarquer dans le PDF :
   ```vb
   FacturXPdfEmbedder.AttachToPdfA3("C:\Temp\facture.pdf", xml, "C:\Temp\facturx.pdf")
   ```
5. Vérifier la présence de l'attachement avec Adobe Reader → Pièces jointes
6. Soumettre à la PDP en mode bac à sable → vérifier acceptation

### 6.2 Test e-Reporting
1. S'assurer qu'au moins une clôture Z est présente dans `T_Cloture` pour la période testée
2. Exécuter :
   ```vb
   Dim svc = New EReportingService(My.Settings.CLIConnectionString)
   svc.ExecuterCycleEReporting(New DateTime(2026, 5, 1), New DateTime(2026, 5, 10))
   ```
3. Vérifier :
   - Une ligne dans `T_FactureElectronique_Emise` avec `Statut = 'TRANSMIS'`
   - Un événement `E_REPORTING_TRANSMIS` dans `T_JournalEvenements`
   - Réception côté PDP (interface web de la PDP)

### 6.3 Test réception
1. Demander à un fournisseur de test (ou utiliser la sandbox de la PDP) d'envoyer une facture
2. Exécuter :
   ```vb
   Dim recv = New FactureElectroniqueReceiver(My.Settings.CLIConnectionString)
   Dim n = recv.ExecuterCycleReception()
   ```
3. Vérifier :
   - Une ligne dans `T_FactureElectronique_Recue` avec données pré-remplies
   - PDF binaire stocké
   - Événement `RECEPTION_FACTURE_ELEC` dans JET

### 6.4 Test mode dégradé (PDP indisponible)
1. Vider `PDP_API_URL` temporairement
2. Exécuter `ExecuterCycleEReporting` → doit produire un fichier local dans `Exports\EReporting_Pending\`
3. Remettre `PDP_API_URL`, exécuter `RejouerEnEchec()` → doit reprendre les pendings

---

## 7. Intégration UI (à faire côté FormCaisse / Form admin)

Les modules sont prêts mais pas encore intégrés à l'UI. Travail restant :

1. **Bouton "Émettre Factur-X"** sur `FormFacture` ou `FormCaisse` après validation d'une facture B2B
2. **Écran admin "Factures émises"** listant `T_FactureElectronique_Emise` avec :
   - Filtre par statut
   - Action "Rejouer" sur les `ECHEC`
   - Téléchargement du PDF Factur-X
3. **Écran admin "Factures fournisseurs reçues"** listant `T_FactureElectronique_Recue` avec :
   - Validation / Refus
   - Mise en paiement
   - Téléchargement du PDF
4. **Tâche planifiée** (cron Windows) appelant :
   - `EReportingService.ExecuterCycleEReporting()` les 11, 21 et 1er de chaque mois
   - `FactureElectroniqueReceiver.ExecuterCycleReception()` toutes les heures

---

## 8. Conformité — points clés à vérifier

- ✅ XML CII v23 valide selon EN 16931 (utiliser le validateur FNFE-MPE)
- ✅ Profil annoncé dans l'XMP cohérent avec le contenu (BASIC / EN 16931 / etc.)
- ✅ SIRET émetteur + acheteur renseignés (schemeID `0009`)
- ✅ TVA intracom renseignée (schemeID `VA`)
- ✅ Ventilation TVA par taux conforme (BG-23)
- ✅ Numéro de facture unique et séquentiel
- ✅ Mention « Factur-X » dans les metadata XMP
- ✅ AFRelationship `/Source` (et non `/Data` ni `/Alternative`)
- ✅ Signature NF525 du ticket source inclus en note (cohérence audit fiscal)

---

## 9. Aide / dépannage

| Symptôme | Cause probable | Solution |
|----------|---------------|----------|
| XML rejeté par le validateur FNFE-MPE | Champ obligatoire manquant (SIRET acheteur en mode B2B, devise…) | Vérifier les T_Params entreprise et les colonnes de la commande |
| Erreur PDP "401 Unauthorized" | Mauvais type d'auth ou clé API expirée | Vérifier `PDP_API_AUTH_TYPE` et régénérer la clé chez la PDP |
| Erreur PDP "400 Bad Request" | XML mal formé ou profil non supporté par la PDP | Tester via la sandbox de la PDP avec un XML minimal |
| Cycle e-Reporting "AUCUNE_DONNEE" | Aucune clôture Z sur la période | Exécuter une clôture Z dans CLI avant de relancer le cycle |
| PDF/A-3 rejeté par certains outils | PDF source non PDF/A | Utiliser un générateur PDF/A natif côté rapport RDLC (ou laisser la PDP convertir) |

---

## 10. Contacts utiles

- **FNFE-MPE (Forum National de la Facture Électronique)** — validateur public + documentation : https://fnfe-mpe.org/
- **AIFE (Agence pour l'Informatique Financière de l'État)** — opérateur du PPF : https://communaute.chorus-pro.gouv.fr/
- **DGFiP — réforme facturation électronique** : https://www.impots.gouv.fr/portail/facturation-electronique
