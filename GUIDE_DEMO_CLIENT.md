# CLI 4.0 — Guide installation pour la démo

Bonjour Arnaud, Christophe, Cyril,

Voici le package de test du logiciel CLI 4.0 (NF525 + DPD CargoNET).
Suivez les étapes ci-dessous, c'est simple.

---

## Ce que vous recevez dans le ZIP

```
CLI_4.0_Demo/
├── App/                              ← le logiciel compilé
│   ├── CLI.exe
│   ├── CLI.exe.config
│   ├── *.dll (toutes les dépendances)
│   ├── lib/                          ← DLLs natives (Dymo, DGV, POS)
│   └── 11354*.label                  ← étiquettes Dymo
├── SQL/                              ← scripts à exécuter sur la base DEV
│   ├── 1_database_update_nf525.sql
│   ├── 2_triggers_nf525_appendonly.sql
│   ├── 3_migration_nf525_phase4.sql
│   └── 4_setup_dpd_transporteur.sql
└── README_INSTALL.txt                ← ce fichier en TXT
```

---

## Étape 1 — Exécuter les scripts SQL (5 min)

Sur la base CLI dev (`dev.chinook-leucate.com`) avec SQL Server Management Studio.

**Dans l'ordre, exécutez :**

1. `SQL/1_database_update_nf525.sql`
   → Ajoute les colonnes Signature, GTP, et les tables T_JournalEvenements, T_GrandTotal, T_Cloture*

2. `SQL/2_triggers_nf525_appendonly.sql`
   → Active les triggers append-only sur T_JournalEvenements

3. `SQL/3_migration_nf525_phase4.sql`
   → Migre les mots de passe en PBKDF2 + initialise les certificats

4. `SQL/4_setup_dpd_transporteur.sql`
   → Crée le transporteur DPD + paramètres CLISyncService

**Après le script 4**, renseignez les credentials FTP du Synology :

```sql
UPDATE T_Params SET Paramvalue = 'synology.local'      WHERE Paramname = 'FTP_Host_DPD';
UPDATE T_Params SET Paramvalue = 'votre_user_synology' WHERE Paramname = 'FTP_UID_DPD';
UPDATE T_Params SET Paramvalue = 'votre_mdp_synology'  WHERE Paramname = 'FTP_PWD_DPD';
UPDATE T_Params SET Paramvalue = '/soDevelopement/DPD/' WHERE Paramname = 'FTP_remote_path_DPD';
```

---

## Étape 2 — Lancer le logiciel (1 min)

Sur un poste Windows :

1. Décompressez le ZIP dans `C:\CLI_Demo\`
2. **Si pas déjà installé sur ce poste**, exécutez `App/lib/POS for .Net v1.12.exe`
3. Double-cliquez sur `App/CLI.exe`
4. Connectez-vous avec votre login/mot de passe habituel

**Le logiciel est configuré pour pointer sur `dev.chinook-leucate.com` (base DEV).**

Pour basculer sur une autre base, éditez `App/CLI.exe.config` :

```xml
<add name="CLI.My.MySettings.CLIConnectionString"
     connectionString="Data Source=dev.chinook-leucate.com;Initial Catalog=CLI;User ID=chinooksur;Password=XXX;TrustServerCertificate=True"
     providerName="System.Data.SqlClient" />
```

---

## Étape 3 — Cas de test à valider (cas tordus bienvenus)

### A. Vente standard
1. Encaisser une vente avec 2 articles à TVA différentes (ex: 20% + 5,5%)
2. Imprimer le ticket → vérifier la présence de la **Signature** (en bas du ticket)
3. Vérifier en base : `SELECT TOP 5 ID_T_CommandeVente, Signature, PreviousSignature FROM T_CommandeVente ORDER BY ID_T_CommandeVente DESC`

### B. Chaînage signatures
Exécuter en SQL :
```sql
WITH C AS (
    SELECT ID_T_CommandeVente, Signature, PreviousSignature,
           LAG(Signature) OVER (ORDER BY ID_T_CommandeVente) AS PrevAttendu
    FROM T_CommandeVente WHERE TicketLe IS NOT NULL
)
SELECT * FROM C
WHERE PreviousSignature <> ISNULL(PrevAttendu, 'INITIAL_CHAIN_START');
```
**Résultat attendu : 0 ligne** (sinon rupture de chaîne).

### C. Clôture Z
1. Menu **Caisse → Clôture Z** (ou bouton dédié)
2. Vérifier l'impression du ticket Z avec le **Grand Total Perpétuel**
3. Vérifier en base :
```sql
SELECT TOP 1 * FROM T_ClotureJournaliere ORDER BY DateCloture DESC;
SELECT TOP 1 * FROM T_GrandTotal       ORDER BY DateMaj      DESC;
SELECT TOP 5 * FROM T_JournalEvenements WHERE TypeEvent = 'CLOTURE_Z' ORDER BY DateEvent DESC;
```

### D. Authentification — détection brute-force
1. Saisir 5 mauvais mots de passe en moins de 15 minutes pour le même login
2. Le 6e doit être **bloqué** même avec le bon mot de passe
3. Vérifier les 5 entrées `ECHEC_AUTHENTIFICATION` dans T_JournalEvenements

### E. Modification TVA tracée
1. Aller dans **Administration → Paramètres → TVA**
2. Modifier un taux (ex: 5,5 → 5,4)
3. Sauvegarder
4. Vérifier l'événement JET :
```sql
SELECT TOP 5 * FROM T_JournalEvenements
 WHERE TypeEvent = 'MODIFICATION_TVA' ORDER BY DateEvent DESC;
```

### F. Expédition DPD
1. Créer une commande WEB avec adresse complète
2. Onglet **Transporteur** → choisir **DPD** → cliquer **Expédier**
3. Attendre 60 secondes (délai par défaut `CliTransfertDPDDelay`)
4. Vérifier que le fichier `.dat` apparaît dans `/soDevelopement/DPD/` sur le Synology
5. Ouvrir le fichier dans un éditeur texte → vérifier l'en-tête `$VERSION=110` + ligne fixe 3126 caractères

> **Note** : `CLISyncService` doit tourner côté serveur pour que l'export DPD se déclenche. Si non démarré, redémarrer le container Docker.

---

## En cas de problème

| Symptôme | Solution |
|----------|----------|
| `CLI.exe` ne démarre pas (erreur .NET) | Activer **.NET Framework 3.5** dans Fonctionnalités Windows |
| `OPOS error` au démarrage | Pas grave en démo (pas d'imprimante caisse). Cliquer Ignorer. |
| Connexion SQL refusée | Vérifier le mot de passe dans `CLI.exe.config` |
| Le ticket s'imprime sans signature | Vérifier que le script SQL #1 a bien tourné |
| Aucun fichier DPD ne sort | Vérifier que CLISyncService tourne côté serveur (`docker ps`) |

---

## Contact

**Jayan GRONDIN — Codialis**
📧 jayan@codialis.com
📱 +33 7 83 90 57 17 / +262 693 49 84 20

N'hésitez pas si un cas de test ne passe pas, je débugue à distance.
