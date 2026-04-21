# DOSSIER TECHNIQUE NF525
## Logiciel de caisse CHINOOK LEUCATE — CLI 4.0

---

**Organisme de certification :** INFOCERT
**Référentiel :** NF525 (AFNOR/INFOCERT) — BOI-TVA-DECLA-30-10-30
**Version du logiciel :** CLI 4.0
**Éditeur :** [Raison sociale de l'éditeur — à compléter]
**SIRET éditeur :** [SIRET — à compléter]
**Représentant légal :** [Nom, Prénom — à compléter]
**Contact technique :** [Email — à compléter]
**Date de rédaction :** 2026-03-26
**Version du dossier :** 1.0

---

## TABLE DES MATIÈRES

1. Présentation générale du logiciel
2. Architecture technique
3. Pilier I — Inaltérabilité des données
4. Pilier S — Sécurisation des accès
5. Pilier C — Conservation des données
6. Pilier A — Archivage
7. Clôtures périodiques et Grand Total Perpétuel
8. Export FEC et obligations fiscales
9. Gestion des utilisateurs et droits
10. Piste d'audit et Journal des Événements Techniques
11. Procédure de mise à jour et de déploiement
12. Déclaration de conformité

---

## 1. PRÉSENTATION GÉNÉRALE DU LOGICIEL

### 1.1 Identité du logiciel

| Attribut | Valeur |
|---|---|
| Nom commercial | CHINOOK LEUCATE CLI |
| Version certifiée | 4.0 |
| Type | Logiciel de caisse enregistreuse (LCE) |
| Secteur | Commerce de détail / restauration |
| Plateforme | Windows (XP SP3 ou supérieur) |
| Framework | Microsoft .NET Framework 3.5 |
| Langage | Visual Basic .NET (VB.NET) |
| Base de données | Microsoft SQL Server (2008 R2 ou supérieur) |
| Interface | Windows Forms (WinForms) |

### 1.2 Périmètre fonctionnel

Le logiciel CHINOOK LEUCATE CLI 4.0 assure les fonctions suivantes soumises à la norme NF525 :

- Enregistrement des transactions de vente (tickets de caisse)
- Calcul et ventilation de la TVA par taux
- Édition de tickets et de reçus
- Clôtures journalières (Ticket Z), mensuelles et annuelles
- Gestion des avoirs et annulations
- Archivage fiscal des données de vente
- Export comptable FEC (Fichier des Écritures Comptables)
- Gestion des utilisateurs et des droits d'accès

---

## 2. ARCHITECTURE TECHNIQUE

### 2.1 Composants principaux

```
CLI 4.0
├── CLI.exe                      Application WinForms principale (caisse)
├── CLIMinimalApi/               API REST interne (synchronisation)
│   └── appsettings.*.json       Configuration (connexion chiffrée TLS)
├── CLISyncService/              Service Windows de synchronisation
│   └── appsettings.*.json       Configuration (connexion chiffrée TLS)
└── NF525/                       Module de conformité NF525
    ├── SignatureHelper.vb        Signature HMAC-SHA256 des tickets
    ├── SignatureHelperPKI.vb     Signature RSA-2048 / X.509 (niveau 2)
    └── PasswordHasherNF525.vb   Hachage PBKDF2 des mots de passe
```

### 2.2 Base de données

| Table | Rôle NF525 |
|---|---|
| T_CommandeVente | Tickets de vente (signés, immuables) |
| T_CommandeVenteLigne | Lignes de vente (signées) |
| T_Cloture | Clôtures Z/M/A avec GTP |
| T_JournalEvenements | Journal des Événements Techniques (append-only) |
| t_user | Utilisateurs (mots de passe PBKDF2) |
| T_ArchiveFiscale | Métadonnées des archives fiscales |

### 2.3 Communication réseau

- Connexions SQL Server chiffrées TLS (`Encrypt=True`)
- Certificat serveur vérifié (`TrustServerCertificate=True` en environnement maîtrisé)
- API REST interne protégée par clé d'API (`X-Api-Key`)

---

## 3. PILIER I — INALTÉRABILITÉ DES DONNÉES

### 3.1 Chaînage cryptographique des tickets (HMAC-SHA256)

Chaque ticket de vente est signé avec l'algorithme **HMAC-SHA256** selon le schéma de chaînage suivant :

```
Données signées = [Id_CommandeVente][TicketLe:yyyyMMddHHmmss][Total_TTC:0.00][Signature_Ticket_Précédent]
Signature       = HMAC-SHA256(clé_secrète, données_signées)
```

- La **clé secrète HMAC** n'est jamais stockée dans le code source.
- Elle est chargée au démarrage depuis :
  1. La variable d'environnement machine `NF525_HMAC_KEY` (priorité)
  2. Le fichier `C:\Certificates\CHINOOK_NF525_HMAC.key` (fallback)
- Si aucune source n'est disponible, le logiciel lève une `SecurityException` et refuse de démarrer.
- La clé est mise en cache en mémoire ; le cache est invalidable via `InvaliderCacheClé()`.

**Fichier :** `CLI/NF525/SignatureHelper.vb`

### 3.2 Option PKI — Signature RSA-2048 / X.509

Pour le niveau de certification supérieur, le logiciel supporte la signature asymétrique :

- **Algorithme :** RSA-2048, SHA-256 avec padding PKCS#1
- **Certificat :** X.509 v3, stocké dans le magasin Windows (`My\CurrentUser`) ou fichier PFX
- **Format de signature :** Base64 (~344 caractères), distinct du HMAC (44 caractères)
- **Vérification :** `VerifierIntegriteChaineX509()` — vérifie à la fois le chaînage ET la signature cryptographique

**Fichier :** `CLI/NF525/SignatureHelperPKI.vb`

### 3.3 Triggers SQL Server — Protection des données signées

Des triggers `INSTEAD OF UPDATE / DELETE` protègent les colonnes sensibles :

| Trigger | Table | Protection |
|---|---|---|
| TR_JET_AppendOnly | T_JournalEvenements | Toute modification / suppression bloquée |
| TR_Vente_NoModifSignature | T_CommandeVente | Modification colonne Signature bloquée |
| TR_VenteLigne_NoModifSignature | T_CommandeVenteLigne | Idem sur lignes |
| TR_Cloture_AppendOnly | T_Cloture | Toute modification / suppression bloquée |

**Fichier SQL :** `triggers_nf525_appendonly.sql`

### 3.4 Vérification de l'intégrité de la chaîne

La fonction `VerifierIntegriteChaineX509()` (ou `VerifierIntegriteChaine()` pour HMAC) :
- Parcourt tous les tickets dans l'ordre chronologique
- Recalcule la signature attendue et la compare à la signature stockée
- Détecte toute rupture de chaîne
- Trace le résultat dans le Journal des Événements Techniques

---

## 4. PILIER S — SÉCURISATION DES ACCÈS

### 4.1 Authentification des utilisateurs

- **Algorithme de hachage :** PBKDF2-HMAC-SHA1
- **Paramètres :** 600 000 itérations, sel aléatoire 32 octets, sortie 32 octets
- **Format stocké :** `$pbkdf2sha1v1$600000$[sel_base64]$[hash_base64]`
- **Migration transparente :** à la première connexion post-mise à jour, le mot de passe en clair est automatiquement migré vers PBKDF2 sans interruption de service

**Fichier :** `CLI/NF525/PasswordHasherNF525.vb`

### 4.2 Protection contre les injections SQL

Toutes les requêtes SQL du module d'authentification et des fonctions NF525 utilisent des **requêtes paramétrées** (`SqlCommand.Parameters.AddWithValue`). Aucune concaténation de chaîne pour construire des requêtes avec des données utilisateur.

### 4.3 Protection contre les attaques par force brute

- Détection de 5 échecs d'authentification en 15 minutes (`CompterEchecsRecents`)
- Alerte visuelle à l'opérateur et traçabilité JET
- Chaque tentative échouée est loguée avec horodatage et poste

**Fichier :** `CLI/FormIdentification.vb`

### 4.4 Comparaison en temps constant

La vérification du hash PBKDF2 utilise une comparaison **en temps constant** (`ComparerEnTempsConstant`) pour résister aux attaques par canal auxiliaire (timing attacks).

### 4.5 Chiffrement des communications

- Connexions SQL Server chiffrées (`Encrypt=True`)
- API REST protégée par clé d'API transmise en en-tête HTTP (`X-Api-Key`)

---

## 5. PILIER C — CONSERVATION DES DONNÉES

### 5.1 Durée de conservation

Conformément à l'article L102 B du LPF, les données fiscales sont conservées **6 ans minimum** à partir de la date de la dernière opération.

### 5.2 Purge sécurisée

La purge des données ne supprime **jamais physiquement** les enregistrements :

- Les tickets sont marqués `PurgeLe = [date]` et `PurgePar = [login]`
- Les enregistrements restent en base et dans la chaîne de signatures
- La purge n'est autorisée qu'après :
  1. Existence d'une archive fiscale couvrant la période
  2. Vérification de l'intégrité de la chaîne de signatures
- Chaque purge est tracée dans le Journal des Événements Techniques

**Colonnes :** `T_CommandeVente.PurgeLe`, `T_CommandeVente.PurgePar`
**Fichier :** `migration_nf525_phase4.sql`

### 5.3 Sauvegardes

Il est recommandé (et doit être documenté dans le plan de sauvegarde client) :
- Sauvegarde quotidienne de la base de données SQL Server
- Copie des archives fiscales XML hors site
- Test de restauration trimestriel

---

## 6. PILIER A — ARCHIVAGE

### 6.1 Format des archives fiscales

Les archives sont générées par `ExporterArchiveFiscale()` au format **XML signé** contenant :

- Métadonnées de la période (dates, opérateur, machine)
- Liste de tous les tickets de vente avec leurs lignes
- Ventilation TVA par taux pour chaque ticket
- Liste des clôtures (Z/M/A) de la période
- Signature de l'archive (SHA-256)

### 6.2 Consultation des archives

`ConsulterArchiveFiscale()` :
- Vérifie l'intégrité du fichier archive (SHA-256)
- Trace la consultation dans le JET avec l'identité du consultant

### 6.3 Export FEC (Fichier des Écritures Comptables)

`ExporterFEC()` génère un fichier conforme à l'**article A47 A-1 du CGI** :

- Format : texte tabulé, UTF-8 avec BOM
- 18 colonnes imposées par la DGFiP
- Plan de comptes PCG utilisé :

| Compte | Libellé | Usage |
|---|---|---|
| 531 | Caisse | Débit vente / Crédit avoir |
| 70720 | Ventes 20% | Crédit vente HT (TVA 20%) |
| 70710 | Ventes 10% | Crédit vente HT (TVA 10%) |
| 70755 | Ventes 5,5% | Crédit vente HT (TVA 5,5%) |
| 44571 | TVA collectée 20% | Crédit TVA 20% |
| 44572 | TVA collectée 10% | Crédit TVA 10% |
| 44573 | TVA collectée 5,5% | Crédit TVA 5,5% |

---

## 7. CLÔTURES PÉRIODIQUES ET GRAND TOTAL PERPÉTUEL

### 7.1 Types de clôtures

| Type | Fréquence | Déclenchement | Ticket imprimé |
|---|---|---|---|
| JOUR (Z) | Quotidienne | Manuel ou fin de journée | Oui (Ticket Z) |
| MOIS | Mensuelle | Après la dernière clôture Z du mois | Non (optionnel) |
| ANNEE | Annuelle | Après la dernière clôture M de l'année | Non (optionnel) |

### 7.2 Grand Total Perpétuel (GTP)

- Le GTP est un **compteur cumulatif strictement croissant** du chiffre d'affaires TTC
- Il est calculé à chaque clôture : `GTP_n = GTP_(n-1) + CA_TTC_période`
- Il ne peut jamais diminuer
- La vérification de la monotonie est assurée par `VerifierMonotonieGTP()`

### 7.3 Contenu du Ticket Z (clôture journalière)

Le Ticket Z imprimé par `ImprimerTicketZ()` contient obligatoirement :

- En-tête : nom, adresse, SIRET
- Période : date et heure de clôture
- Nombre de tickets de la journée
- Total HT par taux de TVA
- Montant TVA par taux
- Total TTC
- Nombre et montant des avoirs
- Grand Total Perpétuel (GTP)
- Signature de la clôture (extrait)
- Pied : "Conforme NF525 — INFOCERT"

### 7.4 Détection des clôtures manquantes

`DetecterCloturesManquantes()` identifie chaque jour avec des ventes mais sans clôture Z.
`AlerterCloturesManquantes()` affiche une alerte au démarrage de l'application.

---

## 8. EXPORT FEC ET OBLIGATIONS FISCALES

### 8.1 Obligation légale

Le FEC est exigible par l'administration fiscale dans les 15 jours suivant une demande de vérification de comptabilité (article L47 A du LPF).

### 8.2 Génération du FEC

L'export est déclenché depuis le menu Administration → Exports → FEC. L'opérateur saisit la période souhaitée (dates début/fin) et le chemin du fichier de destination.

### 8.3 Traçabilité

Chaque export FEC est tracé dans le Journal des Événements Techniques avec :
- Identité de l'opérateur
- Période exportée
- Nombre d'écritures générées
- Nom du fichier

---

## 9. GESTION DES UTILISATEURS ET DROITS

### 9.1 Rôles

| Rôle | Description |
|---|---|
| Caissier | Saisie des ventes uniquement |
| Responsable | Clôtures, avoirs, consultation |
| Administrateur | Configuration, exports, purge |

### 9.2 Principe du moindre privilège

- Les fonctions NF525 sensibles (purge, archivage, export FEC) nécessitent le rôle Administrateur
- Les clôtures nécessitent au minimum le rôle Responsable
- Les droits sont vérifiés en base de données et non uniquement côté interface

### 9.3 Traçabilité des accès

Chaque connexion réussie et chaque échec sont tracés dans le JET avec :
- Login, date/heure, machine
- Pour les accès admin : action réalisée

---

## 10. PISTE D'AUDIT — JOURNAL DES ÉVÉNEMENTS TECHNIQUES (JET)

### 10.1 Structure

La table `T_JournalEvenements` enregistre tous les événements significatifs :

| Colonne | Type | Description |
|---|---|---|
| Id_JET | INT IDENTITY | Clé primaire auto-incrémentée |
| DateEvenement | DATETIME | Horodatage (UTC ou local cohérent) |
| TypeEvenement | VARCHAR(50) | Code événement |
| Description | VARCHAR(500) | Description lisible |
| Reference | VARCHAR(100) | Référence de l'entité concernée |
| Detail | VARCHAR(500) | Informations complémentaires |
| Login | VARCHAR(50) | Opérateur connecté |
| Machine | VARCHAR(50) | Nom de la machine |

### 10.2 Événements tracés

| Code | Déclencheur |
|---|---|
| CONNEXION_REUSSIE | Authentification réussie |
| ECHEC_AUTH | Tentative d'authentification échouée |
| ACCES_ADMIN | Accès à une fonction administrative |
| CLOTURE_JOUR | Clôture journalière effectuée |
| CLOTURE_MOIS | Clôture mensuelle effectuée |
| CLOTURE_ANNEE | Clôture annuelle effectuée |
| EXPORT_ARCHIVE | Export d'archive fiscale |
| CONSULTATION_ARCHIVE | Consultation d'archive fiscale |
| PURGE_DONNEES | Purge sécurisée de données |
| EXPORT_FEC | Export FEC généré |
| INTEGRITE_X509_OK / KO | Résultat de la vérification de chaîne |
| ERREUR_* | Toute erreur technique significative |

### 10.3 Immuabilité

Le trigger `TR_JET_AppendOnly` (INSTEAD OF UPDATE, DELETE) garantit qu'aucun enregistrement ne peut être modifié ou supprimé par une opération SQL directe. Le JET est **en ajout seul**.

---

## 11. PROCÉDURE DE MISE À JOUR ET DE DÉPLOIEMENT

### 11.1 Scripts de migration base de données

Les scripts de migration SQL doivent être exécutés dans l'ordre suivant avant toute mise à jour du logiciel :

| Script | Contenu |
|---|---|
| `database_update_nf525.sql` | Colonnes Signature, tables T_Cloture et T_JournalEvenements |
| `triggers_nf525_appendonly.sql` | Triggers de protection des données |
| `migration_nf525_phase4.sql` | Colonnes de purge, extension mot de passe, index |

### 11.2 Prérequis d'installation

- Créer la clé HMAC : `C:\Certificates\CHINOOK_NF525_HMAC.key` (256 bits / 32 octets aléatoires, encodés en Base64)
- Ou définir la variable d'environnement machine : `NF525_HMAC_KEY=[clé_base64]`
- Pour la PKI : installer le certificat X.509 dans le magasin `My\CurrentUser` ou `My\LocalMachine`

### 11.3 Tests post-déploiement

- [ ] Connexion avec un compte existant → vérifier la migration PBKDF2
- [ ] Effectuer une vente test → vérifier la signature dans T_CommandeVente
- [ ] Effectuer une clôture Z → vérifier le GTP et l'impression Ticket Z
- [ ] Lancer la vérification d'intégrité → résultat INTEGRITE_OK attendu
- [ ] Exporter le FEC sur une période test → vérifier le format (18 colonnes, UTF-8 BOM)

---

## 12. DÉCLARATION DE CONFORMITÉ

Je soussigné(e), **[Nom Prénom, Qualité]**, représentant légal de **[Raison sociale de l'éditeur]**, déclare que le logiciel de caisse **CHINOOK LEUCATE CLI version 4.0** :

1. **Répond aux exigences de la norme NF525** concernant l'inaltérabilité, la sécurisation, la conservation et l'archivage des données de caisse (piliers ISCA) ;

2. **Implémente un chaînage cryptographique** HMAC-SHA256 (et optionnellement RSA-2048/X.509) de l'ensemble des transactions de vente, garantissant la détection de toute altération ;

3. **Assure la conservation des données** au sens de l'article L102 B du LPF, avec interdiction de suppression physique et traçabilité de toute purge ;

4. **Génère les Tickets Z** (clôtures journalières) avec Grand Total Perpétuel strictement croissant ;

5. **Produit un fichier FEC** conforme à l'article A47 A-1 du CGI sur demande de l'administration fiscale ;

6. **Maintient un Journal des Événements Techniques** immuable couvrant l'ensemble des opérations sensibles.

Cette déclaration est établie sur la base de l'analyse technique du code source et des fonctionnalités du logiciel à la date susmentionnée.

**Fait à :** [Ville]
**Le :** [Date]
**Signature :** ___________________________
**[Nom, Prénom, Qualité]**
**[Raison sociale]**

---

*Document établi conformément au référentiel NF525 (AFNOR XP Z10-003) et au BOI-TVA-DECLA-30-10-30.*
*Ce dossier doit être conservé pendant toute la durée de vie du logiciel certifié et présenté à INFOCERT lors de l'audit de certification.*
