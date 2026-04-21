# 🔒 AUDIT NF525 - RAPPORT TECHNIQUE DE CONFORMITÉ
## Application de Caisse CHINOOK-LEUCATE

**Date d'audit** : 02/02/2026  
**Expert** : Consultant Cybersécurité NF525  
**Version logiciel** : CLI 4.0  
**Référentiel** : INFOCERT/AFNOR NF525 (Critères ISCA)  

---

## 📋 SOMMAIRE

1. [Résumé exécutif](#résumé-exécutif)
2. [Analyse par pilier ISCA](#analyse-par-pilier-isca)
3. [Vulnérabilités critiques identifiées](#vulnérabilités-critiques)
4. [Fonctions prioritaires à auditer](#fonctions-prioritaires)
5. [Plan de mise en conformité](#plan-de-mise-en-conformité)
6. [Annexes techniques](#annexes-techniques)

---

## 🎯 RÉSUMÉ EXÉCUTIF

### Verdict global : ⚠️ **NON CONFORME - TRAVAUX URGENTS REQUIS**

L'application de caisse présente actuellement **des risques majeurs de refus de certification** suite à la fin de l'auto-attestation en 2025. Les défauts suivants ont été identifiés :

| Pilier ISCA | État | Niveau de risque | Priorité |
|------------|------|-----------------|----------|
| **Inaltérabilité** | 🔴 Non conforme | CRITIQUE | P0 |
| **Sécurisation** | 🔴 Non conforme | CRITIQUE | P0 |
| **Conservation** | 🟠 Partiellement conforme | ÉLEVÉ | P1 |
| **Archivage** | 🔴 Non conforme | CRITIQUE | P1 |

### Constats majeurs

✅ **Points positifs identifiés :**
- Script SQL de mise en conformité déjà préparé (`database_update_nf525.sql`)
- Module de signature cryptographique développé (`SignatureHelper.vb`)
- Structure de base existante pour les transactions

🔴 **Défauts bloquants :**
1. **Module de signature NON INTÉGRÉ** dans le flux de vente
2. **Fonction de suppression active** (DELETE) sur les données fiscales
3. **Absence de clôtures journalières obligatoires (Z)**
4. **Aucun mécanisme d'archivage fiscal**
5. **Pas de journal des événements techniques (JET)**

---

## 📊 ANALYSE PAR PILIER ISCA

### 1️⃣ INALTÉRABILITÉ - 🔴 NON CONFORME

#### Critère NF525
> *"Toute donnée de transaction doit être figée. Toute modification doit être tracée par une nouvelle opération (pas d'overwrite)."*

#### Constats d'audit

##### ✅ Points positifs
- **Module cryptographique préparé** : `SignatureHelper.vb` implémente HMAC-SHA256
- **Schéma de chaînage défini** : Colonnes `Signature` et `PreviousSignature` prévues
- **Tables concernées** :
  - `T_CommandeVente` (en-tête de vente)
  - `T_CommandeVente_Ligne` (lignes de ticket)
  - `T_Reglement` (paiements)

##### 🔴 **Vulnérabilités critiques détectées**

**1. MODULE DE SIGNATURE NON INTÉGRÉ**
```vb
' Fichier : FormCaisse.vb, ligne 2621-2699
Private Sub Enregistrer()
    ' ... code existant ...
    Me.T_CommandeVenteTableAdapter.Update(Me.CLIDataSet.T_CommandeVente)
    ' ❌ AUCUN APPEL À SignatureHelper.SignTransaction() !
End Sub
```
**Impact** : Les transactions sont enregistrées SANS signature cryptographique.  
**Risque** : Refus immédiat de certification.

**2. FONCTION DELETE ACTIVE SUR DONNÉES FISCALES**
```vb
' Fichier : FormCaisse.vb, ligne 1662
command.CommandText = "delete from T_avoir where id_t_commandevente=" & r.Item("ID_T_CommandeVente")
command.ExecuteNonQuery()
```
**Impact** : Suppression physique de lignes comptables (avoirs).  
**Risque** : **Violation MAJEURE du principe d'inaltérabilité.**

**3. AllowUserToDeleteRows = TRUE**
```vb
' Fichier : FormCaisse.vb, lignes 708, 754, 826...
DataGridViewCommande.AllowUserToDeleteRows = gVente_w
```
**Impact** : L'utilisateur peut supprimer des lignes de vente dans l'interface.  
**Mécanisme** : Event handler `DataGridViewCommande_UserDeletedRow` (ligne 583)

##### 📌 Recommandations

**URGENT (Avant certification)**

1. **Intégrer le module de signature dans `Enregistrer()`**
```vb
Private Sub Enregistrer()
    ' ... code existant ...
    
    ' ✅ AVANT DE SAUVEGARDER : Signer la transaction
    If Not Me.T_CommandeVenteBindingSource.Current Is Nothing Then
        Dim ticketRow As CLIDataSet.T_CommandeVenteRow = _
            DirectCast(Me.T_CommandeVenteBindingSource.Current.Row, CLIDataSet.T_CommandeVenteRow)
        Dim lines As CLIDataSet.T_CommandeVente_LigneDataTable = _
            Me.CLIDataSet.T_CommandeVente_Ligne.Select("ID_T_CommandeVente=" & ticketRow.ID_T_CommandeVente)
        
        ' Signature cryptographique obligatoire NF525
        NF525.SignatureHelper.SignTransaction(ticketRow, lines)
    End If
    
    Me.T_CommandeVenteTableAdapter.Update(Me.CLIDataSet.T_CommandeVente)
    ' ...
End Sub
```

2. **Désactiver TOUTES les fonctions DELETE**
```vb
' ❌ REMPLACER :
command.CommandText = "delete from T_avoir where id_t_commandevente=" & id

' ✅ PAR (annulation logique) :
command.CommandText = "UPDATE T_avoir SET Annule=1, AnnuleLe=GETDATE(), AnnulePar=@User WHERE id_t_commandevente=" & id
```

3. **Ajouter colonne d'annulation**
```sql
ALTER TABLE T_Avoir ADD Annule BIT DEFAULT 0;
ALTER TABLE T_Avoir ADD AnnuleLe DATETIME NULL;
ALTER TABLE T_Avoir ADD AnnulePar VARCHAR(50) NULL;
```

4. **Désactiver suppression UI**
```vb
' Ligne 708 et suivantes - FORCER À FALSE :
DataGridViewCommande.AllowUserToDeleteRows = False
T_ReglementDataGridView.AllowUserToDeleteRows = False
```

---

### 2️⃣ SÉCURISATION - 🔴 NON CONFORME

#### Critère NF525
> *"Les données doivent être scellées (hachage/chaînage des transactions, signature électronique ou condensat)."*

#### Constats d'audit

##### ✅ Points positifs
- **Algorithme conforme** : HMAC-SHA256 implémenté
- **Clé secrète définie** (ligne 14 de SignatureHelper.vb)
- **Fonction de chaînage** : `GetPreviousTicketSignature()` récupère le hash n-1

##### 🔴 **Vulnérabilités critiques**

**1. MODULE DE SÉCURISATION NON ACTIVÉ**
```vb
' SignatureHelper.vb, lignes 117, 124, 130
' ticketRow.PreviousSignature = previousSign  ' ❌ COMMENTÉ !
' ticketRow.Signature = currentSign           ' ❌ COMMENTÉ !
' line.Signature = lineSign                   ' ❌ COMMENTÉ !
```
**Impact** : Le code de signature existe mais n'est **jamais exécuté**.

**2. COLONNES SIGNATURE NON PRÉSENTES DANS LE DATASET**
```vb
' SignatureHelper.vb, lignes 114-115
' Note: requires the 'Signature' and 'PreviousSignature' columns 
' to be added to the Dataset/DB first.
```
**Impact** : Erreur d'exécution garantie si le code est décommenté.

**3. CLÉ SECRÈTE EN DUR DANS LE CODE**
```vb
' SignatureHelper.vb, ligne 14
Private Const SECRET_KEY As String = "CHINOOK_NF525_SECRET_KEY_2024_!Secure!"
```
**Impact** : Non conforme aux exigences de sécurité avancée.  
**Recommandation auditeur** : Acceptable pour certification de base, mais devra être externalisée pour un niveau de sécurité renforcé.

##### 📌 Recommandations

**URGENT**

1. **Exécuter le script SQL fourni**
```bash
# Se connecter à la base SQL Server
sqlcmd -S www.chinook-leucate.com -U sa -P [PASSWORD] -d CLI -i database_update_nf525.sql
```

2. **Rafraîchir le Dataset Visual Studio**
- Ouvrir `CLIDataSet.xsd`
- Clic droit sur `T_CommandeVente` → Configure → Refresh
- Idem pour `T_CommandeVente_Ligne` et `T_Reglement`

3. **Décommenter les lignes de signature**
```vb
' SignatureHelper.vb, lignes 117-130
ticketRow.PreviousSignature = previousSign  ' ✅ ACTIVER
ticketRow.Signature = currentSign           ' ✅ ACTIVER
line.Signature = lineSign                   ' ✅ ACTIVER
```

**RECOMMANDÉ (Après certification)**

4. **Externaliser la clé secrète**
- Utiliser Azure Key Vault
- Ou cryptage dans `app.config` avec DPAPI

---

### 3️⃣ CONSERVATION - 🟠 PARTIELLEMENT CONFORME

#### Critère NF525
> *"Gestion des clôtures (journalières, mensuelles, annuelles) et intégrité des données cumulées."*

#### Constats d'audit

##### ✅ Points positifs
- **Table de clôture créée** : `T_Cloture` définie dans le script SQL
- **Structure conforme** :
  - `GrandTotal_Perpetuel_TTC` : Grand Total cumulé (ne doit JAMAIS diminuer)
  - `Signature` : Hash de scellement de la clôture
  - `PreviousSignature` : Chaînage cryptographique

##### 🔴 **Vulnérabilités critiques**

**1. AUCUNE CLÔTURE Z IMPLÉMENTÉE**
```
# Recherche dans tout le code source :
grep -ri "cloture" FormCaisse.vb   # Résultat : AUCUNE OCCURRENCE
```
**Impact** : Absence de **ticket Z journalier obligatoire**.  
**Non-conformité** : Article L47 A du LPF (Livre des Procédures Fiscales).

**2. PAS DE MÉCANISME DE GRAND TOTAL**
Le Grand Total Perpétuel est un **compteur fiscal irrévocable** :
- Doit s'incrémenter à chaque vente
- Ne peut JAMAIS décroître (même en cas d'annulation)
- Doit être présent sur chaque ticket de caisse

**Absence constatée** : Aucun champ `GrandTotal` dans `FormCaisse.vb`.

##### 📌 Recommandations

**URGENT**

1. **Créer la fonction de clôture journalière**
```vb
Private Sub ClotureJournaliere()
    ' 1. Calculer le CA du jour
    Dim sql As String = "SELECT SUM(Total_TTC) FROM T_CommandeVente " & _
                        "WHERE CAST(TicketLe AS DATE) = CAST(GETDATE() AS DATE) " & _
                        "AND ID_EtatCommandeVente >= 20"  ' Tickets validés uniquement
    
    Dim montantJour As Decimal = ExecuteScalar(sql)
    
    ' 2. Récupérer le Grand Total précédent
    sql = "SELECT TOP 1 GrandTotal_Perpetuel_TTC FROM T_Cloture ORDER BY Id_Cloture DESC"
    Dim grandTotalPrecedent As Decimal = ExecuteScalar(sql)
    
    ' 3. Calculer le nouveau Grand Total
    Dim nouveauGrandTotal As Decimal = grandTotalPrecedent + montantJour
    
    ' 4. Enregistrer la clôture
    Dim cloture As New CLIDataSet.T_ClotureRow()
    cloture.TypeCloture = "JOUR"
    cloture.DateCloture = Now()
    cloture.MontantTotal_Jour_TTC = montantJour
    cloture.GrandTotal_Perpetuel_TTC = nouveauGrandTotal
    
    ' 5. Signer la clôture (NF525)
    Dim dataCloture As String = cloture.Id_Cloture & _
                                cloture.DateCloture.ToString("yyyyMMddHHmmss") & _
                                nouveauGrandTotal.ToString("0.00", InvariantCulture)
    Dim prevSignCloture As String = GetPreviousClotureSignature()
    cloture.PreviousSignature = prevSignCloture
    cloture.Signature = NF525.SignatureHelper.ComputeSignature(dataCloture & prevSignCloture)
    
    ' 6. Sauvegarder
    Me.T_ClotureTableAdapter.Insert(cloture)
    
    ' 7. Imprimer le ticket Z
    ImprimerTicketZ(cloture)
End Sub
```

2. **Ajouter un bouton de clôture dans l'interface**
- Menu "Caisse" → "Clôture journalière (Z)"
- Bloquer la création de nouvelles ventes après clôture (jusqu'à minuit)

3. **Afficher le Grand Total sur chaque ticket**
```vb
' Dans ImpressionTicketCaisse(), ligne 3250+
m_Printer.PrintNormal(PrinterStation.Receipt, _
    ESC + "|1C" + "GRAND TOTAL: " + FormatNumber(GetGrandTotalActuel(), 2) + " €" + vbCrLf)
```

---

### 4️⃣ ARCHIVAGE - 🔴 NON CONFORME

#### Critère NF525
> *"Génération d'archives fiscales lisibles (format ouvert) et scellées."*

#### Constats d'audit

##### 🔴 **Vulnérabilités critiques**

**1. AUCUN MODULE D'ARCHIVAGE FISCAL**
- Pas de génération XML/CSV des tickets
- Pas d'export FEC (Fichier des Écritures Comptables)
- Pas de scellement cryptographique des archives

**2. ABSENCE DE JOURNAL DES ÉVÉNEMENTS TECHNIQUES (JET)**
La table `T_JournalEvenements` existe dans le script SQL, mais :
- Aucune fonction d'écriture dans le code
- Aucun enregistrement des événements obligatoires :
  - Démarrage du logiciel
  - Changement de TVA
  - Changement de prix
  - Export d'archives

##### 📌 Recommandations

**URGENT**

1. **Implémenter le Journal des Événements**
```vb
Public Sub LogEventTechnique(eventType As String, description As String, _
                             Optional ancienneValeur As String = "", _
                             Optional nouvelleValeur As String = "")
    Dim evt As New CLIDataSet.T_JournalEvenementsRow()
    evt.TypeEvent = eventType
    evt.Description = description
    evt.AncienneValeur = ancienneValeur
    evt.NouvelleValeur = nouvelleValeur
    evt.Utilisateur = gLogin
    evt.VersionLogiciel = Application.ProductVersion
    
    ' Signature NF525
    Dim dataEvt As String = evt.TypeEvent & evt.DateEvent.ToString("yyyyMMddHHmmss") & _
                            evt.Description & evt.Utilisateur
    Dim prevSig As String = GetPreviousEventSignature()
    evt.PreviousSignature = prevSig
    evt.Signature = NF525.SignatureHelper.ComputeSignature(dataEvt & prevSig)
    
    Me.T_JournalEvenementsTableAdapter.Insert(evt)
End Sub
```

2. **Enregistrer le démarrage du logiciel**
```vb
' Dans FormCaisse_Load(), ligne 37+
LogEventTechnique("DEMARRAGE", "Ouverture du module de caisse", "", "")
```

3. **Créer la fonction d'export fiscal**
```vb
Private Sub ExporterArchiveFiscale(dateDebut As Date, dateFin As Date)
    ' 1. Générer XML conforme au référentiel
    ' 2. Inclure TOUS les tickets avec leurs signatures
    ' 3. Sceller l'archive avec un hash SHA-256
    ' 4. Enregistrer dans T_JournalEvenements
    LogEventTechnique("EXPORT_ARCHIVE", _
                     "Export fiscal " & dateDebut.ToString("dd/MM/yyyy") & " - " & dateFin.ToString("dd/MM/yyyy"), _
                     "", "Archive_" & Now.ToString("yyyyMMdd_HHmmss") & ".xml")
End Sub
```

---

## 🔥 VULNÉRABILITÉS CRITIQUES IDENTIFIÉES

### Tableau de synthèse

| # | Vulnérabilité | Fichier | Ligne | Gravité | Impact certification |
|---|--------------|---------|-------|---------|---------------------|
| 1 | Signature non intégrée | `FormCaisse.vb` | 2621-2699 | 🔴 BLOQUANT | Refus immédiat |
| 2 | DELETE sur T_Avoir | `FormCaisse.vb` | 1662 | 🔴 BLOQUANT | Refus immédiat |
| 3 | AllowUserToDeleteRows | `FormCaisse.vb` | 708, 754... | 🔴 BLOQUANT | Refus immédiat |
| 4 | Module signature commenté | `SignatureHelper.vb` | 117-130 | 🔴 BLOQUANT | Refus immédiat |
| 5 | Colonnes signature absentes | Dataset | N/A | 🔴 BLOQUANT | Erreur runtime |
| 6 | Aucune clôture Z | Tout le code | N/A | 🔴 BLOQUANT | Non-conformité LPF |
| 7 | Pas de Grand Total | Tout le code | N/A | 🔴 BLOQUANT | Non-conformité NF525 |
| 8 | Aucun archivage fiscal | Tout le code | N/A | 🟠 MAJEUR | Refus probable |
| 9 | JET non implémenté | Tout le code | N/A | 🟠 MAJEUR | Refus probable |

---

## 🎯 FONCTIONS PRIORITAIRES À AUDITER

### Ordre de priorité pour la mise en conformité

#### **P0 - CRITIQUE (Correction immédiate)**

**1. `FormCaisse.vb::Enregistrer()` (ligne 2621)**
- **Rôle** : Enregistrement des commandes de vente
- **Audit requis** :
  1. Intégrer l'appel à `SignatureHelper.SignTransaction()`
  2. Vérifier que `TicketLe` est bien renseigné avant signature
  3. S'assurer que le Grand Total est mis à jour

**2. `FormCaisse.vb::AnnulerCommande()` (ligne 616)**
- **Rôle** : Annulation d'une commande
- **Audit requis** :
  1. Transformer en annulation logique (flag `Annule=1`)
  2. NE JAMAIS supprimer physiquement (`DELETE`)
  3. Logger l'événement dans `T_JournalEvenements`

**3. `FormCaisse.vb::DestructionAutoAvoir()` (ligne 1640)**
- **Rôle** : Suppression d'avoirs lors de l'annulation
- **Audit requis** :
  1. **SUPPRIMER COMPLÈTEMENT CETTE FONCTION**
  2. Remplacer par une annulation logique

**4. `SignatureHelper.vb::SignTransaction()` (ligne 109)**
- **Audit requis** :
  1. Décommenter les lignes 117, 124, 130
  2. Vérifier que les colonnes existent dans le Dataset
  3. Tester le chaînage cryptographique

#### **P1 - ÉLEVÉ (Sous 1 semaine)**

**5. Créer `FormCaisse.vb::ClotureJournaliere()`**
- Fonction à développer ENTIÈREMENT
- Doit générer le ticket Z
- Doit mettre à jour le Grand Total

**6. Créer `FormCaisse.vb::LogEventTechnique()`**
- Journal des événements techniques
- Doit tracer :
  - Démarrages
  - Changements de TVA/prix
  - Exports d'archives

**7. `FormCaisse.vb::ImpressionTicketCaisse()` (ligne 3151)**
- **Audit requis** :
  1. Ajouter l'affichage de la **signature du ticket** (hash)
  2. Ajouter le **Grand Total cumulé**
  3. Afficher le **numéro de séquence unique**

#### **P2 - MOYEN (Sous 2 semaines)**

**8. Créer module d'archivage fiscal**
- Export XML/CSV des tickets
- Export FEC comptable
- Scellement cryptographique

**9. Audit de la base de données**
- **Vérifier les triggers existants** (s'il y en a)
- Créer des **contraintes d'intégrité** :
  ```sql
  -- Empêcher la modification des tickets validés
  CREATE TRIGGER TR_T_CommandeVente_NoUpdateIfTicketed
  ON T_CommandeVente
  INSTEAD OF UPDATE
  AS BEGIN
      IF EXISTS (SELECT 1 FROM inserted i 
                 INNER JOIN deleted d ON i.ID_T_CommandeVente = d.ID_T_CommandeVente
                 WHERE d.TicketLe IS NOT NULL)
      BEGIN
          RAISERROR('NF525: Impossible de modifier un ticket validé', 16, 1)
          ROLLBACK TRANSACTION
      END
  END
  ```

**10. Sécuriser la fonction `ModuleGeneral.vb::ExecuteRequeteR()`**
- Vérifier l'absence de requêtes DELETE non contrôlées

---

## 📋 PLAN DE MISE EN CONFORMITÉ

### Phase 1 : Correction des vulnérabilités critiques (J+0 à J+3)

#### Jour 1 : Infrastructure de base

**Matin**
- [ ] Exécuter `database_update_nf525.sql` sur la base DEV
- [ ] Rafraîchir le Dataset dans Visual Studio
- [ ] Compiler et tester le build

**Après-midi**
- [ ] Décommenter les lignes de signature dans `SignatureHelper.vb`
- [ ] Intégrer l'appel à `SignTransaction()` dans `Enregistrer()`
- [ ] Tests unitaires de signature

#### Jour 2 : Suppression des DELETE

**Matin**
- [ ] Ajouter colonnes d'annulation (`Annule`, `AnnuleLe`, `AnnulePar`)
- [ ] Remplacer `DELETE` par `UPDATE ... SET Annule=1` dans :
  - `DestructionAutoAvoir()`
  - `ResetAvoir()`
  - Tous les appels SQL directs

**Après-midi**
- [ ] Désactiver `AllowUserToDeleteRows` dans toute l'interface
- [ ] Remplacer les event handlers de suppression par des annulations logiques
- [ ] Tests de non-régression

#### Jour 3 : Validation du chaînage

**Toute la journée**
- [ ] Créer une fonction de **vérification d'intégrité de la chaîne**
  ```vb
  Public Function VerifierIntegriteChaine() As Boolean
      ' Recalculer toutes les signatures et comparer
  End Function
  ```
- [ ] Tester sur 100 tickets fictifs
- [ ] Documenter les résultats

### Phase 2 : Clôtures et conservation (J+4 à J+7)

#### Jour 4-5 : Clôture journalière

- [ ] Développer `ClotureJournaliere()`
- [ ] Développer `GetGrandTotalActuel()`
- [ ] Créer le rapport de clôture (Ticket Z)
- [ ] Ajouter le bouton dans l'interface

#### Jour 6-7 : Grand Total sur tickets

- [ ] Modifier `ImpressionTicketCaisse()` pour afficher :
  - Signature du ticket (hash tronqué)
  - Grand Total cumulé
  - Numéro de séquence
- [ ] Tests d'impression

### Phase 3 : Journal des événements (J+8 à J+10)

- [ ] Développer `LogEventTechnique()`
- [ ] Implémenter le logging dans :
  - `FormCaisse_Load()` (démarrage)
  - `FormParamTva.vb` (changement TVA)
  - `FormArticle2.vb` (changement prix)
- [ ] Tests de traçabilité

### Phase 4 : Archivage fiscal (J+11 à J+14)

- [ ] Développer `ExporterArchiveFiscale()`
- [ ] Format XML conforme au référentiel
- [ ] Scellement cryptographique de l'archive
- [ ] Tests d'export

### Phase 5 : Validation et certification (J+15 à J+21)

- [ ] Tests de charge (10 000 tickets)
- [ ] Audit interne de conformité
- [ ] Rédaction du dossier de certification
- [ ] Soumission à l'organisme certificateur

---

## 📎 ANNEXES TECHNIQUES

### A. Structure de la chaîne cryptographique

```
Ticket N-1                    Ticket N                      Ticket N+1
┌──────────────┐             ┌──────────────┐             ┌──────────────┐
│ ID: 1234     │             │ ID: 1235     │             │ ID: 1236     │
│ Date: 01/02  │──SHA256───▶│ PrevSig: AB  │──SHA256───▶│ PrevSig: CD  │
│ Total: 45.90 │             │ Data: ...    │             │ Data: ...    │
│ Signature:   │             │ Signature:   │             │ Signature:   │
│  AB12CD34... │             │  CD56EF78... │             │  EF90GH12... │
└──────────────┘             └──────────────┘             └──────────────┘
```

### B. Format de données pour signature

**Ticket (Header)**
```
[ID][Date(yyyyMMddHHmmss)][TotalTTC][PreviousSignature]
Exemple : "1235202602011430045.90AB12CD34..."
```

**Ligne de ticket**
```
[LineID][ArticleID][Qte][TotalTTC][TicketID]
Exemple : "567891234502100.00001235"
```

**Clôture**
```
[ClotureID][Date][GrandTotal][PreviousSignature]
Exemple : "120240201185000012345.67AB12CD34..."
```

### C. Checklist de l'auditeur

```
☐ Les colonnes Signature/PreviousSignature existent-elles dans la base ?
☐ SignTransaction() est-il appelé AVANT chaque Update() ?
☐ Existe-t-il un seul endroit où DELETE est utilisé ?
☐ AllowUserToDeleteRows est-il FORCÉ à False partout ?
☐ Les clôtures Z sont-elles générées automatiquement ?
☐ Le Grand Total est-il affiché sur chaque ticket ?
☐ Le JET enregistre-t-il les démarrages du logiciel ?
☐ Un export fiscal est-il disponible pour l'administration ?
```

### D. Scripts SQL de validation

**Vérifier l'intégrité de la chaîne**
```sql
WITH Chaine AS (
    SELECT 
        ID_T_CommandeVente,
        TicketLe,
        Total_TTC,
        Signature,
        PreviousSignature,
        LAG(Signature) OVER (ORDER BY ID_T_CommandeVente) AS SignaturePrecedente
    FROM T_CommandeVente
    WHERE TicketLe IS NOT NULL
)
SELECT * FROM Chaine
WHERE PreviousSignature <> ISNULL(SignaturePrecedente, 'INITIAL_CHAIN_START');
-- Résultat attendu : 0 lignes (aucune rupture de chaîne)
```

**Détecter les DELETE non autorisés**
```sql
-- Activer l'audit SQL Server
ALTER DATABASE CLI SET CHANGE_TRACKING = ON;

-- Créer un trigger d'alerte
CREATE TRIGGER TR_PreventDelete_T_CommandeVente
ON T_CommandeVente
INSTEAD OF DELETE
AS BEGIN
    RAISERROR('NF525 VIOLATION: DELETE interdit sur les tickets de caisse', 16, 1)
    ROLLBACK TRANSACTION
END;
```

---

## 🎓 CONCLUSION

### Points d'attention pour le développeur

1. **NE JAMAIS** utiliser `DELETE` sur les tables fiscales
2. **TOUJOURS** vérifier que la signature est bien enregistrée
3. **TESTER** la chaîne cryptographique après chaque modification
4. **DOCUMENTER** chaque changement lié à NF525

### Contact de l'auditeur

Pour toute question technique sur ce rapport :
- **Expert** : Consultant Cybersécurité NF525
- **Référentiel** : AFNOR NF525:2018
- **Organisme** : INFOCERT

---

**Date de validité de ce rapport** : 02/02/2026  
**Prochaine révision** : Après implémentation des correctifs (J+21)

---

*Ce document est confidentiel et destiné uniquement à l'équipe de développement de CHINOOK-LEUCATE.*
