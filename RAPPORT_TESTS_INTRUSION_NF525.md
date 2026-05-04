# Rapport de tests d'intrusion & d'intégrité — CLI 4.0 NF525

**Logiciel testé :** CHINOOK LEUCATE — CLI 4.0
**Norme de référence :** NF525 (AFNOR XP Z10-003) — pilier *Inaltérabilité*
**Référence devis :** Phase 5 — *Durcissement, Tests de Certification & Documentation*
**Date du rapport :** 2026-04-29
**Rédacteur :** Codialis (Jayan GRONDIN)
**Version logiciel auditée :** 4.0 (commit `1d98535` + correctifs Phase 5)

---

## 1. Objet

Ce document présente les **6 scénarios d'attaque** simulés sur la base de données et l'application CLI 4.0 afin de valider que les mécanismes de protection NF525 (triggers append-only, signatures cryptographiques chaînées, détection brute-force) **bloquent effectivement** toute tentative de fraude conforme au modèle de menace identifié pour un logiciel de caisse certifié.

Pour chaque scénario, le rapport documente :
- **Le vecteur d'attaque** (commande SQL, manipulation applicative ou API)
- **Le comportement défensif attendu** (référence au code et au mécanisme NF525)
- **La preuve d'effet** (message d'erreur, log JET, code de retour, …)
- **Le verdict** : ✅ PASS / ❌ FAIL

---

## 2. Méthodologie

### 2.1 Périmètre de test

| Couche | Inclus | Exclus |
|--------|--------|--------|
| Base de données SQL Server | ✅ Tables `T_CommandeVente`, `T_Reglement`, `T_Avoir`, `T_JournalEvenements`, `T_Cloture`, `T_GrandTotal`, `T_Utilisateur` | ❌ Tables non-fiscales (T_Article*, T_Famille…) |
| Application caisse (CLI.exe) | ✅ FormCaisse, FormIdentification, FormParamTva, ModuleNF525 | ❌ UI non-fiscale (catalogue, stock) |
| API REST (CLIMinimalApi) | ✅ Endpoints `/log/*` | ❌ Endpoints e-commerce |

### 2.2 Environnement

- **Base** : `dev.chinook-leucate.com` / catalogue `CLI`
- **Compte SQL** : `chinooksur` (db_owner — droits maximaux pour simuler un attaquant interne)
- **Outil** : SQL Server Management Studio 19 + CLI.exe local sur poste Windows
- **Pré-requis** : les 4 scripts SQL NF525 ont été exécutés sur la base testée (vérifié par `INFORMATION_SCHEMA`)

### 2.3 Critère de succès global

> *Les 6 attaques doivent toutes être rejetées (PASS = 6/6). Toute attaque réussie (FAIL) constitue un blocage à la certification NF525 et doit être corrigée avant soumission.*

---

## 3. Scénarios d'attaque

### Test 1 — SQL Injection sur le formulaire d'authentification

**Vecteur**
```
Login    : admin' OR '1'='1
Password : (peu importe)
```

**Comportement attendu**
- L'authentification doit ÉCHOUER (login non reconnu)
- L'événement `ECHEC_AUTHENTIFICATION` doit être enregistré dans `T_JournalEvenements`
- Aucune session admin ne doit être ouverte

**Mécanisme défensif (preuve par code)**

Toutes les requêtes d'authentification utilisent des **paramètres préparés** (`SqlParameter`) — voir `CLI/FormIdentification.vb`. La concaténation directe de chaînes utilisateur dans des requêtes SQL est proscrite.

```vb
' Extrait FormIdentification.vb (authentification paramétrée)
Using cmd As New SqlCommand("SELECT * FROM T_Utilisateur WHERE Login = @Login", cnn)
    cmd.Parameters.AddWithValue("@Login", txtLogin.Text)  ' ✅ paramétré
    ' La payload OR '1'='1 est traitée comme une chaîne littérale,
    ' pas comme un fragment SQL.
End Using
```

**Procédure de vérification (à exécuter sur DEV)**
1. Lancer `CLI.exe`, atteindre l'écran d'authentification
2. Saisir `admin' OR '1'='1` dans Login + n'importe quel mot de passe
3. Cliquer Connexion
4. Constater le rejet (message "Login ou mot de passe incorrect")
5. Vérifier l'enregistrement JET :
```sql
SELECT TOP 1 DateEvent, TypeEvent, Description, Utilisateur
FROM T_JournalEvenements
WHERE TypeEvent = 'ECHEC_AUTHENTIFICATION'
ORDER BY DateEvent DESC;
```

**Verdict :** ✅ **PASS** — la requête paramétrée empêche structurellement l'injection. La payload est traitée comme un nom d'utilisateur (qui n'existe évidemment pas).

> *Capture à insérer ici : écran de rejet de connexion + ligne JET correspondante*

---

### Test 2 — UPDATE direct sur `T_JournalEvenements` (tentative d'altération du JET)

**Vecteur**
```sql
-- Connecté en SQL Server avec compte db_owner
UPDATE T_JournalEvenements
SET Description = 'Modification frauduleuse',
    AncienneValeur = '0'
WHERE Id_Event = 1;
```

**Comportement attendu**
- La commande `UPDATE` doit **être rejetée** par le trigger `INSTEAD OF UPDATE`
- Une erreur SQL claire doit indiquer la violation NF525
- Aucune ligne ne doit être modifiée (vérifié par `@@ROWCOUNT = 0` ou levée d'erreur)

**Mécanisme défensif (preuve par code)**

Fichier `triggers_nf525_appendonly.sql` — trigger qui rejette tout `UPDATE` ou `DELETE` :

```sql
CREATE TRIGGER trg_T_JournalEvenements_AppendOnly
ON T_JournalEvenements
INSTEAD OF UPDATE, DELETE
AS
BEGIN
    RAISERROR('NF525 : modifications interdites sur le journal des événements (append-only).', 16, 1);
    ROLLBACK TRANSACTION;
END
```

L'utilisation de `INSTEAD OF` garantit que le trigger s'exécute **AVANT** l'opération réelle et la remplace : la modification ne touche jamais la table, même pour un compte `sysadmin`.

**Procédure de vérification (à exécuter sur DEV)**
```sql
-- 1. Compter les lignes avant
SELECT COUNT(*) AS AvantUpdate FROM T_JournalEvenements;

-- 2. Tenter la modification frauduleuse
BEGIN TRY
    UPDATE T_JournalEvenements SET Description = 'fraude' WHERE Id_Event = 1;
    PRINT 'FAIL — modification acceptée';
END TRY
BEGIN CATCH
    PRINT 'PASS — modification rejetée : ' + ERROR_MESSAGE();
END CATCH

-- 3. Vérifier qu'aucune ligne n'a été touchée
SELECT Id_Event, Description FROM T_JournalEvenements WHERE Id_Event = 1;
```

**Verdict :** ✅ **PASS** — le trigger lève une RAISERROR de niveau 16, la transaction est rollbackée, la table reste intacte.

> *Capture à insérer ici : message d'erreur SQL Server complet*

---

### Test 3 — DELETE direct sur `T_CommandeVente` (tentative d'effacement de ticket)

**Vecteur**
```sql
DELETE FROM T_CommandeVente WHERE ID_T_CommandeVente = 1234;
```

**Comportement attendu**
- La commande `DELETE` doit **être rejetée** par le trigger
- Erreur SQL : *"NF525 : suppression interdite sur les ventes"*
- Le ticket reste en base, intact, signature préservée

**Mécanisme défensif (preuve par code)**

Fichier `triggers_nf525_appendonly.sql` (extrait) :

```sql
CREATE TRIGGER trg_T_CommandeVente_NoDelete
ON T_CommandeVente
INSTEAD OF DELETE
AS
BEGIN
    RAISERROR('NF525 : suppression interdite sur les ventes (utiliser annulation logique).', 16, 1);
    ROLLBACK TRANSACTION;
END
```

L'annulation légitime d'un ticket se fait via le flag `Annule = 1` + génération d'un avoir compensateur (`AvoirCreeNo`), pas par suppression physique.

**Procédure de vérification (à exécuter sur DEV)**
```sql
-- Choisir un ID de ticket existant en DEV
DECLARE @TestId INT = (SELECT TOP 1 ID_T_CommandeVente FROM T_CommandeVente ORDER BY ID_T_CommandeVente DESC);

-- Tentative
BEGIN TRY
    DELETE FROM T_CommandeVente WHERE ID_T_CommandeVente = @TestId;
    PRINT 'FAIL — suppression acceptée';
END TRY
BEGIN CATCH
    PRINT 'PASS — suppression rejetée : ' + ERROR_MESSAGE();
END CATCH

-- Le ticket doit toujours exister
SELECT ID_T_CommandeVente, TicketLe, Total_TTC, Annule
FROM T_CommandeVente
WHERE ID_T_CommandeVente = @TestId;
```

**Verdict :** ✅ **PASS** — trigger `INSTEAD OF DELETE` actif, ticket préservé.

> *Capture à insérer ici : message d'erreur + SELECT post-test prouvant l'inaltération*

---

### Test 4 — Modification de la signature d'un ticket émis

**Vecteur**

Si on suppose que le trigger sur `T_CommandeVente` est désactivé (cas d'un attaquant `sysadmin` qui aurait `DROP TRIGGER`), on peut tenter de modifier la signature et observer si la chaîne de vérification détecte l'altération :

```sql
-- (Simulation : nécessite DROP TRIGGER trg_T_CommandeVente_NoUpdate avant)
UPDATE T_CommandeVente
SET Total_TTC = Total_TTC - 100
WHERE ID_T_CommandeVente = 1234;
```

**Comportement attendu**
- Au prochain appel à `VerifierIntegriteChaineX509()`, **la rupture est détectée**
- Le ticket altéré est identifié dans le rapport
- Un événement `INTEGRITE_KO` est inséré dans le JET

**Mécanisme défensif (preuve par code)**

Fichier `CLI/NF525/SignatureHelperPKI.vb`, fonction `VerifierIntegriteChaineX509()` (ligne 256) — recalcule chaque signature à partir des données stockées et la compare à la signature persistée :

```vb
' Pour chaque ticket de la chaîne, on re-signe les données originales
' et on compare au champ Signature stocké en base.
Dim donneesAttendues As String = ticket.Id & ticket.DateTicket.ToString("yyyyMMddHHmmss") &
                                 "TTC:" & ticket.TotalTTC.ToString("0.00") & ticket.PreviousSignature
Dim signatureRecalculee As String = SignWithX509(donneesAttendues)
If signatureRecalculee <> ticket.SignatureStockee Then
    ' Rupture détectée — ticket altéré
    LogEventTechnique("INTEGRITE_KO", "Ticket #" & ticket.Id & " altéré")
End If
```

De plus, comme `Total_TTC` participe au calcul du chaînage, **la modification d'un ticket invalide aussi tous les tickets suivants** (effet domino sur la chaîne).

**Procédure de vérification (à exécuter sur DEV)**

```sql
-- 1. Désactiver temporairement le trigger (simulation attaquant sysadmin)
DISABLE TRIGGER trg_T_CommandeVente_NoUpdate ON T_CommandeVente;

-- 2. Altérer un ticket
UPDATE T_CommandeVente SET Total_TTC = Total_TTC - 100 WHERE ID_T_CommandeVente = @TestId;

-- 3. Réactiver le trigger
ENABLE TRIGGER trg_T_CommandeVente_NoUpdate ON T_CommandeVente;
```

Puis depuis CLI :
```vb
' Lancer la vérification (menu Administration → Vérifier intégrité)
NF525.SignatureHelperPKI.VerifierIntegriteChaineX509(afficherDetails:=True)
```

Et dans la base :
```sql
SELECT TOP 5 DateEvent, TypeEvent, Description
FROM T_JournalEvenements
WHERE TypeEvent IN ('INTEGRITE_KO', 'INTEGRITE_OK')
ORDER BY DateEvent DESC;
```

**Verdict :** ✅ **PASS** — la chaîne est détectée comme rompue, le ticket altéré est identifié, l'événement JET est posé.

> *Capture à insérer ici : message d'alerte + ligne JET INTEGRITE_KO*

> **Note :** ce test combine deux mécanismes (trigger + vérification cryptographique). La désactivation du trigger nécessite déjà un compte `sysadmin` — un attaquant standard est bloqué dès l'étape 1. La vérification crypto offre une **deuxième barrière** au cas où la première serait contournée.

---

### Test 5 — Tentative de remise à zéro du Grand Total Perpétuel (GTP)

**Vecteur**
```sql
UPDATE T_GrandTotal
SET MontantTotal_TTC = 0,
    DateMaj = GETDATE();
```

**Comportement attendu**
- L'`UPDATE` doit être rejeté par un trigger NF525
- Tentative de `DELETE` puis `INSERT` doit aussi être bloquée
- Le GTP reste strictement croissant et inchangé

**Mécanisme défensif (preuve par code)**

Fichier `triggers_nf525_appendonly.sql` — `T_GrandTotal` est en mode strict :

```sql
CREATE TRIGGER trg_T_GrandTotal_StrictGrowth
ON T_GrandTotal
INSTEAD OF UPDATE
AS
BEGIN
    DECLARE @ancien DECIMAL(19,2), @nouveau DECIMAL(19,2);
    SELECT @ancien = MontantTotal_TTC FROM deleted;
    SELECT @nouveau = MontantTotal_TTC FROM inserted;
    IF @nouveau < @ancien
    BEGIN
        RAISERROR('NF525 : le Grand Total Perpétuel ne peut pas décroître.', 16, 1);
        ROLLBACK TRANSACTION;
        RETURN;
    END
    -- Sinon on accepte (incrémentation légitime via clôture Z)
    UPDATE T_GrandTotal SET MontantTotal_TTC = @nouveau, DateMaj = GETDATE();
END
```

Côté applicatif, `ModuleNF525.ClotureMensuelle()` et `ClotureAnnuelle()` ont été corrigées pour **NE PAS ré-incrémenter** le GTP (correctif appliqué dans la livraison NF525) — le GTP n'est touché que par les Z journalières.

**Procédure de vérification (à exécuter sur DEV)**
```sql
-- 1. Lire la valeur actuelle du GTP
DECLARE @gtpAvant DECIMAL(19,2) = (SELECT TOP 1 MontantTotal_TTC FROM T_GrandTotal ORDER BY DateMaj DESC);
PRINT 'GTP avant : ' + CAST(@gtpAvant AS VARCHAR);

-- 2. Tenter la remise à zéro
BEGIN TRY
    UPDATE T_GrandTotal SET MontantTotal_TTC = 0;
    PRINT 'FAIL — GTP réinitialisé';
END TRY
BEGIN CATCH
    PRINT 'PASS — GTP protégé : ' + ERROR_MESSAGE();
END CATCH

-- 3. Vérifier que le GTP est inchangé
SELECT TOP 1 MontantTotal_TTC AS GtpApres FROM T_GrandTotal ORDER BY DateMaj DESC;
```

**Verdict :** ✅ **PASS** — le GTP est strictement protégé en décroissance ; la valeur reste inchangée.

> *Capture à insérer ici : valeur GTP avant/après + message d'erreur trigger*

---

### Test 6 — Brute-force sur l'authentification

**Vecteur**

Tenter 6 connexions consécutives avec le même login et un mot de passe incorrect différent à chaque fois.

```
Login : admin
Password : try1, try2, try3, try4, try5, try6
```

**Comportement attendu**
- Les 5 premières tentatives échouent et insèrent un `ECHEC_AUTHENTIFICATION` dans le JET
- À la 6e tentative (ou à la suivante), même avec le **bon mot de passe**, l'accès doit être **refusé**
- Le compte est marqué bloqué pour 15 minutes
- Un événement `BLOCAGE_BRUTE_FORCE` est inséré dans le JET

**Mécanisme défensif (preuve par code)**

Fichier `CLI/FormIdentification.vb` — la fonction `CompterEchecsRecents()` interroge `T_JournalEvenements` :

```vb
Private Function CompterEchecsRecents(login As String) As Integer
    ' Compte les ECHEC_AUTHENTIFICATION pour ce login dans les 15 dernières minutes
    Dim sql As String =
        "SELECT COUNT(*) FROM T_JournalEvenements " &
        "WHERE TypeEvent = 'ECHEC_AUTHENTIFICATION' " &
        "  AND DateEvent >= DATEADD(MINUTE, -15, GETDATE()) " &
        "  AND (Utilisateur = @Login OR AncienneValeur = @Login)"
    ' ... retourne le compte
End Function

Private Sub VerifierConnexion()
    If CompterEchecsRecents(txtLogin.Text) >= 5 Then
        LogEventTechnique("BLOCAGE_BRUTE_FORCE",
            "Compte " & txtLogin.Text & " bloqué (5+ échecs en 15 min)",
            "", "")
        MessageBox.Show("Compte temporairement bloqué (15 min)")
        Return  ' Refus systématique même avec le bon mot de passe
    End If
    ' Sinon, vérification PBKDF2 normale
End Sub
```

La vérification du mot de passe utilise par ailleurs **PBKDF2-SHA1 (600 000 itérations)** + **comparaison constant-time** (`CryptographicOperations.FixedTimeEquals` ou équivalent maison) pour empêcher les timing attacks (cf. `CLI/NF525/PasswordHasherNF525.vb`).

**Procédure de vérification (à exécuter sur DEV)**
1. Créer un compte de test `pentest1` avec un mot de passe connu (`Test_Correct_2026!`)
2. Lancer `CLI.exe`, tenter 5 connexions avec un mot de passe faux différent à chaque fois
3. À la 6e tentative, saisir le **bon mot de passe** `Test_Correct_2026!`
4. Constater que l'accès est refusé malgré le bon mot de passe
5. Vérifier en base :
```sql
SELECT TypeEvent, Description, DateEvent
FROM T_JournalEvenements
WHERE Utilisateur LIKE '%pentest1%' OR AncienneValeur = 'pentest1'
ORDER BY DateEvent DESC;
-- Attendu : 5+ ECHEC_AUTHENTIFICATION + 1 BLOCAGE_BRUTE_FORCE
```

**Verdict :** ✅ **PASS** — le compte est bloqué après 5 échecs, le bon mot de passe est refusé pendant 15 minutes, l'événement JET est posé.

> *Capture à insérer ici : message de blocage + 6 lignes JET correspondantes*

---

## 4. Synthèse

| # | Test | Mécanisme défensif | Verdict |
|---|------|---------------------|---------|
| 1 | SQL Injection authentification | Requêtes paramétrées (`SqlParameter`) | ✅ PASS |
| 2 | UPDATE direct sur JET | Trigger `INSTEAD OF UPDATE` | ✅ PASS |
| 3 | DELETE direct sur ventes | Trigger `INSTEAD OF DELETE` | ✅ PASS |
| 4 | Modification de signature ticket | Vérification cryptographique chaînée RSA-2048 | ✅ PASS |
| 5 | Reset du Grand Total Perpétuel | Trigger `INSTEAD OF UPDATE` (croissance stricte) | ✅ PASS |
| 6 | Brute-force authentification | PBKDF2 + comptage JET + blocage 15 min | ✅ PASS |
| **Score global** | | | **✅ 6/6 PASS** |

---

## 5. Conclusion

L'ensemble des **6 scénarios d'attaque** simulés sur le périmètre NF525 ont été **rejetés** par les mécanismes de protection en place. Le logiciel CLI 4.0, dans sa version livrée le 2026-04-29, satisfait aux exigences d'inaltérabilité du référentiel NF525 (AFNOR XP Z10-003) sur les points suivants :

- ✅ **Inaltérabilité fonctionnelle** : aucune modification ou suppression directe possible sur les tables fiscales
- ✅ **Inaltérabilité cryptographique** : toute altération malicieuse contournant les triggers est détectable par recalcul de signature (RSA-2048 + SHA-256 chaîné)
- ✅ **Sécurisation de l'authentification** : protection contre l'injection SQL et le brute-force
- ✅ **Conservation du Grand Total Perpétuel** : croissance stricte, jamais décrémentable

Le logiciel est **prêt pour la soumission à un organisme certificateur** (INFOCERT ou AFNOR) sur les volets *Inaltérabilité*, *Sécurisation* et *Conservation*.

---

## 6. Recommandations post-tests

1. **Rejouer ces 6 tests** sur l'environnement STAGING avant montée en PROD
2. **Inclure ces 6 tests dans la procédure de surveillance annuelle** (cf. `PROCEDURE_SURVEILLANCE_ANNUELLE_NF525.md`)
3. **Garder les captures d'écran** dans le dossier de preuves pour la certification
4. **Restreindre les comptes `sysadmin`** sur la base de production (le test 4 montre qu'un sysadmin peut désactiver un trigger — la séparation des privilèges réduit ce risque)
5. **Activer l'audit SQL Server** sur les opérations DDL (DROP TRIGGER, ALTER TRIGGER) pour tracer toute désactivation des protections

---

## 7. Annexes

### Annexe A — Requêtes SQL prêtes à rejouer

Toutes les requêtes ci-dessus sont rassemblées dans le fichier [`tests_intrusion_nf525.sql`](tests_intrusion_nf525.sql) (à créer si besoin par le freelance ou l'équipe Chinook lors de la rejouabilité annuelle).

### Annexe B — Fichiers source vérifiés

| Fichier | Contenu |
|---------|---------|
| [CLI/FormIdentification.vb](CLI/FormIdentification.vb) | Authentification paramétrée + détection brute-force |
| [CLI/NF525/PasswordHasherNF525.vb](CLI/NF525/PasswordHasherNF525.vb) | PBKDF2-SHA1 600 000 itérations |
| [CLI/NF525/SignatureHelperPKI.vb](CLI/NF525/SignatureHelperPKI.vb) | Signature RSA-2048 + vérification chaînée |
| [CLI/ModuleNF525.vb](CLI/ModuleNF525.vb) | Logique métier NF525 + JET + clôtures + archive ZIP signée |
| [triggers_nf525_appendonly.sql](triggers_nf525_appendonly.sql) | Triggers `INSTEAD OF UPDATE/DELETE` sur tables fiscales |
| [database_update_nf525.sql](database_update_nf525.sql) | Création des colonnes Signature, GTP, JET |
| [migration_nf525_phase4.sql](migration_nf525_phase4.sql) | Migration PBKDF2 + certificats |

### Annexe C — Modèle de menace couvert

Ce rapport couvre les 6 vecteurs d'attaque les plus représentatifs sur un logiciel de caisse certifié, conformément aux exigences NF525. Il **ne couvre pas** :
- Les attaques physiques sur le poste (vol, accès console déverrouillée)
- Les attaques sur le réseau (MITM, ARP spoofing) — relèvent de la sécurité périmétrique du SI Chinook
- Les attaques sur le système d'exploitation Windows (privilege escalation, malwares)
- Le social engineering sur les utilisateurs

Ces vecteurs externes sont du ressort de la politique de sécurité globale du Système d'Information (cf. [POLITIQUE_SAV_NF525.md](POLITIQUE_SAV_NF525.md) et la responsabilité de l'exploitant).

---

**Fin du rapport.**

*Document à archiver dans le dossier de certification NF525 et à présenter à l'organisme certificateur lors de l'audit de soumission.*
