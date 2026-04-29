# CHINOOK LEUCATE — CLI 4.0

**Logiciel de caisse certifiable NF525 (AFNOR XP Z10-003) pour CHINOOK SURF SHOP — Leucate, France.**

![NF525](https://img.shields.io/badge/NF525-Conforme-success)
![Pilier I](https://img.shields.io/badge/Inalt%C3%A9rabilit%C3%A9-100%25-success)
![Pilier S](https://img.shields.io/badge/S%C3%A9curisation-100%25-success)
![Pilier C](https://img.shields.io/badge/Conservation-100%25-success)
![Pilier A](https://img.shields.io/badge/Archivage-100%25-success)
![Version](https://img.shields.io/badge/Version-4.0-blue)
![Status](https://img.shields.io/badge/Status-Production%20Ready-success)

---

## Statut de conformité NF525

**Audit complet validé sur les 4 piliers ISCA** (Inaltérabilité, Sécurisation, Conservation, Archivage). Le logiciel est prêt pour la soumission à l'organisme certificateur (INFOCERT / AFNOR).

| Pilier ISCA | Statut | Mécanismes |
|------------|--------|------------|
| **Inaltérabilité** | ✅ Conforme | Signature HMAC-SHA256 + RSA-2048 chaînée, triggers append-only sur T_JournalEvenements, suppression désactivée, GTP strictement croissant |
| **Sécurisation** | ✅ Conforme | PBKDF2-SHA1 (600 000 itérations) sur mots de passe, comparaison constant-time, détection brute-force (5 tentatives / 15 min), JET événement `ECHEC_AUTHENTIFICATION` |
| **Conservation** | ✅ Conforme | Clôtures journalière (Z) / mensuelle / annuelle signées, GTP perpétuel non décrémentable, journal des événements append-only |
| **Archivage** | ✅ Conforme | Export FEC (Art. A47 A-1 CGI, 18 colonnes, UTF-8 BOM, séparateur tab), export fiscal XML signé, conservation ≥ 6 ans |

---

## Architecture de la solution

```
┌─────────────────────┐         ┌──────────────────────────┐
│   CLI (caisse)      │         │   SQL Server             │
│   VB.NET / .NET 3.5 │◀───────▶│   Base CLI / CHINOOKSUR  │
│   Windows Forms     │   ADO   │   - T_CommandeVente      │
└──────────┬──────────┘         │   - T_JournalEvenements  │
           │                    │   - T_GrandTotal         │
           │                    │   - T_Cloture*           │
           │                    └──────────┬───────────────┘
           │                               │
           │ HTTPS                         │ EF Core
           ▼                               ▼
┌─────────────────────┐         ┌──────────────────────────┐
│   CLIMinimalApi     │         │   CLISyncService         │
│   .NET 7/8 — REST   │         │   .NET 8 BackgroundSvc   │
│   Webhooks Presta   │         │   - Worker (API calls)   │
└─────────────────────┘         │   - TransfertExpeditor   │
                                │     (Colissimo CSV)      │
                                │   - TransfertDPD         │
                                │     (DPD V110 CargoNET)  │
                                └──────────┬───────────────┘
                                           │ FTP/SFTP
                                           ▼
                                ┌──────────────────────────┐
                                │   Synology (NAS local)   │
                                │   /soDevelopement/       │
                                │   /soStaging/            │
                                │   /soProduction/         │
                                └──────────┬───────────────┘
                                           │ partage SMB
                                           ▼
                                ┌──────────────────────────┐
                                │   Poste VPC magasin      │
                                │   - Station.NET DPD      │
                                │   - Colissimo desktop    │
                                │   - impression étiquette │
                                └──────────────────────────┘
```

---

## Stack technique

| Composant | Tech | Rôle |
|-----------|------|------|
| **CLI** | VB.NET, .NET Framework 3.5, Windows Forms | Application caisse (postes magasin) |
| **CLIMinimalApi** | C#, ASP.NET Core 8, Minimal API | API REST consommée par PrestaShop / webhooks |
| **CLISyncService** | C#, .NET 8, Worker Service | Background service : sync Presta + export transporteurs |
| **CLIPrestashopConnector** | C#, PrestaSharp | Adaptateur API PrestaShop |
| **CLICore** | C#, EF Core 8 | Modèles de domaine + DbContext partagés |
| **Base de données** | SQL Server (prod : `www.chinook-leucate.com`) | Stockage transactionnel, JET, clôtures |

---

## Démarrage rapide

### Prérequis Windows (poste de dev)

- Windows 10 / 11
- Visual Studio 2022 (workloads .NET Framework + .NET 8)
- .NET Framework 3.5 (Activer dans `Fonctionnalités Windows`)
- POS for .NET v1.12 (`lib/POS for .Net v1.12.exe`)
- Police `C39HrP24DhTt` (codes-barres ticket Z)
- DYMO Label SDK + driver `DYMO LabelWriter Twin Turbo` (impression étiquettes)

### Build CLI (caisse)

```powershell
git clone https://github.com/grdndev/Compliance_cash_software_NF524.git
cd Compliance_cash_software_NF524

# Restaurer les packages NuGet (CLI utilise packages.config)
nuget restore CLI.sln

# Ouvrir la solution + Rebuild
start CLI.sln
```

Les DLLs natives sont fournies dans [`lib/`](lib/) :
- `DataGridViewExtension.dll`
- `DGVEPdfExporting.dll`
- `Interop.Dymo.dll`
- `POS for .Net v1.12.exe` (installer SDK)

### Build CLISyncService (serveur)

```bash
cd CLISyncService
dotnet build -c Release
# Ou via Docker (voir Dockerfile)
docker compose -f /home/ssssirhc/docker/app/docker-compose.yml up -d --build clisyncservice
```

---

## Configuration base de données

**Exécuter les scripts dans cet ordre** sur la base CLI / CHINOOKSUR :

```sql
-- 1. Schéma NF525 : colonnes Signature, PreviousSignature, GTP, JET, clôtures
:r database_update_nf525.sql

-- 2. Triggers append-only sur T_JournalEvenements (anti-altération)
:r triggers_nf525_appendonly.sql

-- 3. Migration phase 4 : passwords PBKDF2, certificats X.509
:r migration_nf525_phase4.sql

-- 4. Transporteur DPD + paramètres CLISyncService.TransfertDPD
:r setup_dpd_transporteur.sql
```

Après le script DPD, renseigner les TParams FTP :

```sql
UPDATE T_Params SET Paramvalue = 'synology.local'         WHERE Paramname = 'FTP_Host_DPD';
UPDATE T_Params SET Paramvalue = '<user>'                 WHERE Paramname = 'FTP_UID_DPD';
UPDATE T_Params SET Paramvalue = '<password>'             WHERE Paramname = 'FTP_PWD_DPD';
UPDATE T_Params SET Paramvalue = '/soProduction/DPD/'     WHERE Paramname = 'FTP_remote_path_DPD';
-- DEV → /soDevelopement/DPD/   STAGING → /soStaging/DPD/   PROD → /soProduction/DPD/
```

---

## Mécanismes NF525

### Signature & chaînage des tickets

Chaque transaction est scellée puis chaînée à la précédente :

```
Format signé : [ID_Ticket][yyyyMMddHHmmss][TTC:0.00][PrevSig]
```

- **HMAC-SHA256** : signature rapide pour scellement intra-session
- **RSA-2048 / X.509** : signature finale via `RSACryptoServiceProvider` + `SHA256Managed` + `CryptoConfig.MapNameToOID("SHA256")` (compatible .NET Framework 3.5)
- **Chaînage** : la `PreviousSignature` du ticket N reproduit la `Signature` du ticket N-1 ; le premier ticket utilise la sentinelle `INITIAL_CHAIN_START`
- **Vérification** : [`SignatureHelperPKI.VerifierIntegriteChaineX509()`](CLI/NF525/SignatureHelperPKI.vb) parcourt toute la chaîne et recalcule chaque signature pour détecter toute altération

```
Ticket N-1 ──► Ticket N ──► Ticket N+1
  Sig: AB        Sig: CD       Sig: EF
                 PrevSig: AB   PrevSig: CD
```

### Grand Total Perpétuel (GTP)

Total TTC cumulé strictement croissant, jamais décrémenté.

- Incrémenté **uniquement** par les clôtures Z journalières
- Les clôtures mensuelles et annuelles **ne ré-incrémentent pas** (correctif appliqué dans [`ModuleNF525.ClotureMensuelle()`](CLI/ModuleNF525.vb) et `ClotureAnnuelle()`) — le GTP reste celui des Z déjà comptabilisées
- Affiché sur chaque ticket de vente, ticket Z, et FEC

### Journal des Événements Techniques (JET)

Table `T_JournalEvenements` avec triggers `INSTEAD OF UPDATE / DELETE` qui rejettent toute modification — append-only strict.

Événements tracés :
- `DEMARRAGE` (lancement application, machine, OS, version)
- `DEMARRAGE_CAISSE`, `OUVERTURE_CAISSE`, `FERMETURE_CAISSE`
- `AUTHENTIFICATION`, `ECHEC_AUTHENTIFICATION` (anti-brute-force)
- `MODIFICATION_TVA`, `CREATION_TVA` (signés via [`FormParamTva`](CLI/FormParamTva.vb))
- `CLOTURE_Z`, `CLOTURE_MENSUELLE`, `CLOTURE_ANNUELLE`
- `EXPORT_FEC`, `EXPORT_XML`

Chaque entrée porte une `Signature` chaînée à la précédente (`PreviousSignature`).

### Sécurisation des mots de passe

- **PBKDF2-SHA1** avec **600 000 itérations**, sel 32 octets ([`PasswordHasherNF525.vb`](CLI/NF525/PasswordHasherNF525.vb))
- Comparaison **constant-time** (anti-timing attack)
- **Migration automatique** des comptes en clair lors de la première connexion réussie
- **Détection brute-force** : 5 échecs en 15 min → blocage du compte + alerte JET

### Archivage FEC

Export Fichier des Écritures Comptables conforme **Art. A47 A-1 CGI** :

- 18 colonnes obligatoires (JournalCode, JournalLib, EcritureNum, …)
- Encodage **UTF-8 avec BOM**
- Séparateur **tabulation**
- Format date `yyyyMMdd`, format montant `0.00`
- Détail TVA agrégé par taux via [`ModuleNF525.GenererFEC()`](CLI/ModuleNF525.vb)
- Conservation ≥ 6 ans + signature de l'export

---

## Intégration DPD CargoNET

L'export DPD suit **strictement le même pattern que Colissimo** : pas d'export local côté CLI, le service `CLISyncService` côté serveur poll la base et dépose le fichier sur le partage Synology.

### Flux

1. **Caisse** : le vendeur choisit `DPD` dans l'onglet transporteur, clique `Expédier`. La commande est enregistrée avec `IdTTransporteur = IdTTransporteurDPD`.
2. **CLISyncService** : `TransfertDPD` poll toutes les `CliTransfertDPDDelay` ms (défaut : 60 s) les commandes `WebOn || VpcOn` non annulées avec ce transporteur et `ExpeditionLe >= CliDateDerniereExtractionDPD`.
3. **Génération V110** : fichier texte à longueur fixe **3126 caractères + CRLF par colis**, en-tête `$VERSION=110`, encodage **iso-8859-1** (spec CargoNET Station.NET v5.7c, 12/2024).
4. **Upload FTP** : dépôt sur le Synology dans `/soDevelopement/DPD/`, `/soStaging/DPD/` ou `/soProduction/DPD/` selon l'environnement.
5. **Poste VPC** : récupère le `.dat` via le partage SMB, le charge dans Station.NET, le vendeur sélectionne le compte (Classic 066-7485 / Predict 066-7486 / Relais 066-7487), complète le poids, imprime l'étiquette.

### Paramètres T_Params

| Paramètre | Description | Exemple |
|-----------|-------------|---------|
| `IdTTransporteurDPD` | ID DPD dans T_Transporteur | `4` |
| `CliTransfertDPDDelay` | Intervalle de polling (ms) | `60000` |
| `CliDateDerniereExtractionDPD` | Watermark de la dernière extraction | `2026-04-29 12:00:00` |
| `FTP_Host_DPD` | Hôte FTP Synology | `synology.local` |
| `FTP_UID_DPD` | Login FTP | — |
| `FTP_PWD_DPD` | Mot de passe FTP | — |
| `FTP_remote_path_DPD` | Dossier cible par environnement | `/soProduction/DPD/` |
| `FTP_file_name_DPD` | Préfixe nom de fichier | `DPD` (→ `DPD_20260429120000.dat`) |

---

## Scénarios de test NF525

### 1. Vente standard
- Créer un ticket avec 2 articles (TVA 20% et 5,5%)
- Vérifier `T_CommandeVente.Signature` non nulle, `PreviousSignature` correcte
- Vérifier l'événement JET correspondant

### 2. Chaînage signatures
```sql
WITH C AS (
    SELECT ID_T_CommandeVente, Signature, PreviousSignature,
           LAG(Signature) OVER (ORDER BY ID_T_CommandeVente) AS PrevAttendu
    FROM T_CommandeVente WHERE TicketLe IS NOT NULL
)
SELECT * FROM C
WHERE PreviousSignature <> ISNULL(PrevAttendu, 'INITIAL_CHAIN_START');
-- 0 ligne attendue
```

### 3. Clôture Z journalière
- Bouton **Clôture Z** dans `FormCaisse`
- Vérifier insertion `T_ClotureJournaliere` + `T_GrandTotal` mis à jour
- Vérifier événement JET `CLOTURE_Z`
- Imprimer le ticket Z et vérifier la présence du GTP

### 4. Tentatives d'authentification
- Saisir 5 mauvais mots de passe en moins de 15 min → compte bloqué
- Vérifier 5 entrées `ECHEC_AUTHENTIFICATION` dans JET

### 5. Modification TVA
- Modifier un taux dans `Administration → Paramètres → TVA`
- Vérifier événement JET `MODIFICATION_TVA` avec `AncienneValeur` et `NouvelleValeur`

### 6. Expédition DPD
- Créer commande WEB avec transporteur DPD
- Cliquer Expédier
- Attendre `CliTransfertDPDDelay` ms
- Vérifier la présence du `.dat` sur le Synology

---

## Vérification d'intégrité

```vb
' Recalcule chaque signature de la chaîne et la compare à la valeur stockée
Dim resultat = SignatureHelperPKI.VerifierIntegriteChaineX509()
If resultat.RuptureDetectee Then
    ' Alerte : ticket #{resultat.PremierTicketCorrompu} altéré
End If
```

Procédure annuelle complète : voir [PROCEDURE_SURVEILLANCE_ANNUELLE_NF525.md](PROCEDURE_SURVEILLANCE_ANNUELLE_NF525.md)

---

## Documentation

| Document | Contenu |
|----------|---------|
| [DOSSIER_TECHNIQUE_INFOCERT_NF525.md](DOSSIER_TECHNIQUE_INFOCERT_NF525.md) | Dossier technique pour soumission organisme certificateur |
| [AUDIT_NF525_RAPPORT_TECHNIQUE.md](AUDIT_NF525_RAPPORT_TECHNIQUE.md) | Rapport d'audit technique complet |
| [MANUEL_UTILISATEUR_NF525.md](MANUEL_UTILISATEUR_NF525.md) | Manuel utilisateur — clôtures, JET, signatures |
| [GUIDE_COMPILATION.md](GUIDE_COMPILATION.md) | Guide compilation VS 2022 |
| [GUIDE_DEPLOIEMENT_CLIENT.md](GUIDE_DEPLOIEMENT_CLIENT.md) | Procédure de déploiement sur poste magasin |
| [GUIDE_EXECUTION_SQL.md](GUIDE_EXECUTION_SQL.md) | Exécution des scripts SQL NF525 |
| [GUIDE_CERTIFICAT_X509.md](GUIDE_CERTIFICAT_X509.md) | Génération / installation du certificat X.509 |
| [PLAN_TESTS_NR_NF525.md](PLAN_TESTS_NR_NF525.md) | Plan de tests de non-régression NF525 |
| [PROCEDURE_SURVEILLANCE_ANNUELLE_NF525.md](PROCEDURE_SURVEILLANCE_ANNUELLE_NF525.md) | Procédure de surveillance annuelle (audit interne) |
| [POLITIQUE_GESTION_VERSIONS_NF525.md](POLITIQUE_GESTION_VERSIONS_NF525.md) | Politique de gestion des versions |
| [POLITIQUE_SAV_NF525.md](POLITIQUE_SAV_NF525.md) | Politique SAV / support |
| [REGISTRE_INCIDENTS_SECURITE_NF525.md](REGISTRE_INCIDENTS_SECURITE_NF525.md) | Registre des incidents de sécurité |

---

## Sécurité du code source

- **Aucun mot de passe en clair** dans le repo (vérifié par grep + audit complet)
- **Certificats `.pfx`/`.key` ignorés** par `.gitignore` (à déposer manuellement dans `Certificates/` après clonage)
- **Mot de passe certificat X.509** lu via `Environment.GetEnvironmentVariable("NF525_CERT_PWD")` — jamais commité
- **Connection strings de prod** sans password embarqué (authentification SQL configurée par paramètre runtime)

---

## Contact

**CHINOOK SURF SHOP** — Route de la plage, 11370 Leucate
Tél : +33 (0)4 68 40 17 17
Web : https://www.chinook-leucate.com

**Intégration NF525 + DPD** : Codialis (Jayan GRONDIN)
Repo : https://github.com/grdndev/Compliance_cash_software_NF524

---

## Licence

Code propriétaire et confidentiel — CHINOOK SURF SHOP. Reproduction et redistribution interdites sans autorisation écrite.
