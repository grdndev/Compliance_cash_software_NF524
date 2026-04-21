# POLITIQUE DE GESTION DES VERSIONS
## CHINOOK LEUCATE CLI — Certification NF525

**Éditeur :** [Raison sociale — à compléter]
**Logiciel :** CHINOOK LEUCATE CLI
**Version du document :** 1.0
**Date :** 2026-04-10
**Référentiel :** NF525 (AFNOR XP Z10-003) — BOI-TVA-DECLA-30-10-30

---

## 1. NUMÉROTATION SÉMANTIQUE DES VERSIONS

### 1.1 Format

```
MAJEUR.MINEUR.CORRECTIF.BUILD
  4  .  0  .    0    .  XXXX
```

| Composant | Définition | Exemple de changement |
|---|---|---|
| **MAJEUR** | Rupture de compatibilité descendante ou changement d'algorithme cryptographique | Migration HMAC → RSA/X.509, refonte base de données |
| **MINEUR** | Nouvelle fonctionnalité NF525 sans rupture de chaîne | Nouveau type de clôture, nouvel export |
| **CORRECTIF** | Correction de bug sans impact sur les données fiscales | Fix d'affichage, correction d'un message d'erreur |
| **BUILD** | Numéro de compilation automatique (CI/CD) | Incrémenté à chaque build |

### 1.2 Exemples

| Version | Nature du changement |
|---|---|
| 3.x.x → **4.0.0** | Ajout chaînage cryptographique NF525, refonte complète |
| 4.0.0 → **4.1.0** | Ajout export FEC |
| 4.1.0 → **4.1.1** | Correction bug d'affichage Ticket Z |
| 4.1.1 → **4.1.1.1042** | Rebuild sans changement fonctionnel |

### 1.3 Versionnage dans le code

Le numéro de version est défini dans `CLI.vbproj` (`AssemblyVersion`) et accessible via `Application.ProductVersion`. Il doit figurer sur :
- L'écran "À propos"
- Le pied du Ticket Z imprimé
- Les archives fiscales XML (balise `<Version>`)
- Le Dossier Technique soumis à INFOCERT

---

## 2. PROCÉDURE DE MISE À JOUR SANS RUPTURE DE CHAÎNE CRYPTOGRAPHIQUE

### 2.1 Principe fondamental

> **Toute mise à jour du logiciel ne doit jamais altérer la chaîne de signatures existante.**  
> Les tickets signés avant la mise à jour doivent rester vérifiables après.

### 2.2 Mise à jour CORRECTIF (4.x.x → 4.x.y)

**Prérequis :** Aucun impact sur les algorithmes de signature ni le schéma de base de données.

**Procédure :**
1. Effectuer la clôture journalière du jour en cours avant la mise à jour
2. Sauvegarder la base de données SQL Server (backup complet)
3. Déployer le nouvel exécutable (`CLI.exe`)
4. Vérifier la clôture précédente est toujours accessible
5. Lancer `VerifierIntegriteChaine()` — vérifier résultat `INTEGRITE_OK`
6. Consigner dans le JET : `MISE_A_JOUR_LOGICIEL` (version précédente → nouvelle version)

**Durée estimée :** 15 minutes. Réversible par rollback de l'exécutable.

### 2.3 Mise à jour MINEUR (4.x → 4.y)

**Prérequis :** Potentiellement des migrations SQL (nouvelles colonnes, nouveaux index).

**Procédure :**
1. Effectuer clôture journalière + clôture mensuelle si fin de mois
2. Sauvegarder la base de données (backup complet + log)
3. Exécuter les scripts SQL de migration dans l'ordre croissant
4. Vérifier que les triggers append-only sont toujours actifs
5. Déployer le nouvel exécutable
6. Lancer `VerifierIntegriteChaine()` et `VerifierMonotonieGTP()`
7. Effectuer une vente test, vérifier la signature dans `T_CommandeVente`
8. Consigner : `MISE_A_JOUR_LOGICIEL` dans le JET

**Durée estimée :** 30 à 60 minutes. Réversible par restauration backup.

### 2.4 Mise à jour MAJEURE (x → y — changement d'algorithme cryptographique)

**Ce cas concerne notamment la migration HMAC → RSA/X.509.**

**Règle impérative :** La nouvelle version doit rester capable de **vérifier** les signatures de l'ancien algorithme (mode hybride). Voir `VerifierIntegriteChaineX509()` qui distingue automatiquement HMAC (44 chars) et RSA (>100 chars).

**Procédure complète :**
1. Effectuer clôture annuelle (si changement d'exercice) ou clôture mensuelle
2. Exporter une archive fiscale couvrant toute la période précédente
3. Vérifier l'intégrité de l'archive exportée
4. Backup complet de la base de données (archiver le backup 6 ans)
5. Exécuter les scripts de migration SQL
6. Déployer le nouvel exécutable
7. Générer/installer le nouveau certificat X.509 si nécessaire
8. Vérifier que `VerifierIntegriteChaineX509()` valide les anciennes ET nouvelles signatures
9. Effectuer une vente test avec le nouvel algorithme
10. Notifier INFOCERT si la mise à jour majeure impacte les mécanismes certifiés (**obligation de recertification**)

---

## 3. GESTION DES CORRECTIFS DE SÉCURITÉ

### 3.1 Classification des vulnérabilités

| Niveau | Définition | Délai de correctif |
|---|---|---|
| **Critique** | Impact sur la chaîne de signatures, contournement d'authentification, accès non autorisé aux données fiscales | **48 heures** |
| **Élevé** | Vulnérabilité exploitable à distance, injection SQL résiduelle | **7 jours** |
| **Moyen** | Fuite d'information non critique, déni de service local | **30 jours** |
| **Faible** | Amélioration de durcissement sans impact immédiat | **Prochaine version MINEUR** |

### 3.2 Procédure de gestion d'un incident de sécurité

1. **Détection** : par audit interne, signalement client ou veille CVE
2. **Qualification** : évaluation du niveau selon tableau ci-dessus
3. **Isolation** : si critique, recommander la suspension du logiciel jusqu'au correctif
4. **Correction** : développement, test, validation
5. **Déploiement** : procédure de mise à jour CORRECTIF (§2.2)
6. **Traçabilité** : entrée dans le Registre des Incidents de Sécurité
7. **Notification INFOCERT** : obligatoire si la vulnérabilité touche les mécanismes certifiés

### 3.3 Clé HMAC et certificat X.509

En cas de compromission suspectée de la clé HMAC ou du certificat :
1. Générer immédiatement une nouvelle clé / un nouveau certificat
2. Mettre à jour `C:\Certificates\CHINOOK_NF525_HMAC.key` et `NF525_CERT_PWD`
3. Lancer `InvaliderCacheClé()` et `InvaliderCacheCertificat()` (sans redémarrage)
4. Documenter l'incident dans le Registre des Incidents
5. Notifier le client et INFOCERT

---

## 4. ARCHIVAGE DES VERSIONS ANTÉRIEURES

### 4.1 Durée de conservation des binaires

| Composant | Durée minimale | Lieu de stockage |
|---|---|---|
| Exécutables (`CLI.exe`, DLL) | **6 ans** après fin de commercialisation | Dépôt Git + archive ZIP horodatée |
| Scripts SQL de migration | **6 ans** | Dépôt Git + archive ZIP |
| Dossiers Techniques INFOCERT | **6 ans** après expiration du certificat | Archivage papier + numérique |
| Certificats X.509 (PFX) | **6 ans** après expiration | Coffre-fort sécurisé |

### 4.2 Référentiel de versions

Chaque version publiée doit être taguée dans le dépôt Git :

```
git tag -a v4.0.0 -m "NF525 v4.0.0 — Certification INFOCERT [date]"
git push origin v4.0.0
```

### 4.3 Registre des versions certifiées

| Version | Date de certification | N° certificat INFOCERT | Algorithme signature | Statut |
|---|---|---|---|---|
| CLI 4.0 | [à compléter] | [à compléter] | HMAC-SHA256 + RSA-2048/X.509 | En cours de certification |

### 4.4 Obligation de recertification

Une recertification INFOCERT est **obligatoire** dans les cas suivants :
- Changement du mécanisme de signature (algorithme, longueur de clé)
- Modification des triggers SQL de protection
- Changement de la structure de `T_CommandeVente`, `T_Cloture` ou `T_JournalEvenements`
- Mise à jour MAJEURE du logiciel

Une recertification est **recommandée** (mais non obligatoire) pour les mises à jour MINEUR.

---

*Ce document doit être mis à jour à chaque changement de version majeure ou mineure.*
*Version du document : 1.0 — 2026-04-10*
