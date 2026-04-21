# PLAN DE TESTS DE NON-RÉGRESSION NF525
## CHINOOK LEUCATE CLI 4.0

**Version du document :** 1.0
**Date :** 2026-04-10
**Référentiel :** NF525 (AFNOR XP Z10-003) — Piliers ISCA

---

## GRILLE DE LECTURE

| Symbole | Signification |
|---|---|
| ✅ | Test réussi — résultat conforme |
| ❌ | Test échoué — non-conformité |
| ⚠️ | Résultat partiel — vérification manuelle requise |
| N/A | Non applicable à la configuration testée |

**Fréquence d'exécution :** Avant chaque déploiement en production. Obligatoire après toute mise à jour MINEUR ou MAJEURE.

---

## PILIER I — INALTÉRABILITÉ

### I-01 : Signature HMAC d'un nouveau ticket

| Champ | Valeur |
|---|---|
| **Objectif** | Vérifier que chaque ticket reçoit une signature HMAC-SHA256 lors de sa validation |
| **Prérequis** | Clé HMAC configurée (`NF525_HMAC_KEY` ou fichier `.key`) |
| **Étapes** | 1. Créer une vente test (article quelconque, montant > 0) |
| | 2. Valider le ticket |
| | 3. Requêter `SELECT Signature, PreviousSignature FROM T_CommandeVente WHERE ID_T_CommandeVente = [id]` |
| **Résultat attendu** | Colonne `Signature` renseignée, longueur 44 chars (Base64 SHA-256), `PreviousSignature` = signature du ticket précédent |
| **Résultat obtenu** | |
| **Statut** | |

### I-02 : Signature RSA/X.509 (si PKI activée)

| Champ | Valeur |
|---|---|
| **Objectif** | Vérifier que la signature RSA est générée et vérifiable |
| **Prérequis** | Certificat PFX installé, `NF525_CERT_PWD` configuré |
| **Étapes** | 1. Créer une vente test |
| | 2. Requêter `SELECT Signature FROM T_CommandeVente WHERE ID_T_CommandeVente = [id]` |
| | 3. Appeler `VerifierIntegriteChaineX509(True)` |
| **Résultat attendu** | Signature longueur ~344 chars, MessageBox "INTÉGRITÉ VALIDÉE", JET contient `INTEGRITE_X509_OK` |
| **Résultat obtenu** | |
| **Statut** | |

### I-03 : Chaînage des signatures

| Champ | Valeur |
|---|---|
| **Objectif** | Vérifier que `PreviousSignature[n]` = `Signature[n-1]` pour tous les tickets |
| **Étapes** | 1. Appeler `VerifierIntegriteChaine(True)` (HMAC) ou `VerifierIntegriteChaineX509(True)` |
| **Résultat attendu** | "Intégrité VALIDÉE", 0 rupture de chaîne dans le JET |
| **Résultat obtenu** | |
| **Statut** | |

### I-04 : Blocage modification de la colonne Signature (trigger)

| Champ | Valeur |
|---|---|
| **Objectif** | Vérifier que le trigger `TR_Vente_NoModifSignature` bloque toute modification |
| **Étapes** | 1. Exécuter directement en SQL : `UPDATE T_CommandeVente SET Signature = 'XXXX' WHERE ID_T_CommandeVente = [id]` |
| **Résultat attendu** | Erreur SQL : "Modification de la signature interdite (NF525)" — aucune ligne modifiée |
| **Résultat obtenu** | |
| **Statut** | |

### I-05 : Blocage suppression ticket (trigger)

| Champ | Valeur |
|---|---|
| **Objectif** | Vérifier qu'aucun ticket ne peut être supprimé |
| **Étapes** | 1. Tenter `DELETE FROM T_CommandeVente WHERE ID_T_CommandeVente = [id]` en SQL direct |
| **Résultat attendu** | Erreur SQL ou 0 ligne supprimée — le ticket est toujours présent |
| **Résultat obtenu** | |
| **Statut** | |

### I-06 : Détection de rupture de chaîne

| Champ | Valeur |
|---|---|
| **Objectif** | Vérifier que `VerifierIntegriteChaine` détecte une altération simulée |
| **Étapes** | 1. Désactiver temporairement le trigger (environnement de test isolé) |
| | 2. Modifier manuellement `PreviousSignature` d'un ticket |
| | 3. Réactiver le trigger |
| | 4. Appeler `VerifierIntegriteChaine(True)` |
| **Résultat attendu** | "INTÉGRITÉ COMPROMISE", JET contient `INTEGRITE_KO` avec le numéro du ticket concerné |
| **Résultat obtenu** | |
| **Statut** | |

---

## PILIER S — SÉCURISATION

### S-01 : Authentification PBKDF2

| Champ | Valeur |
|---|---|
| **Objectif** | Vérifier que la connexion fonctionne avec un mot de passe haché PBKDF2 |
| **Étapes** | 1. Se connecter avec un compte dont le mot de passe a été migré |
| | 2. Vérifier dans `t_user` que `password` commence par `$pbkdf2sha1v1$` |
| **Résultat attendu** | Connexion réussie, JET contient `CONNEXION_REUSSIE` |
| **Résultat obtenu** | |
| **Statut** | |

### S-02 : Migration automatique mot de passe en clair

| Champ | Valeur |
|---|---|
| **Objectif** | Vérifier la migration transparente plaintext → PBKDF2 à la première connexion |
| **Prérequis** | Créer un utilisateur test avec mot de passe en clair dans `t_user` |
| **Étapes** | 1. Se connecter avec le compte test |
| | 2. Vérifier `t_user.password` après connexion |
| **Résultat attendu** | `password` désormais au format `$pbkdf2sha1v1$...`, connexion réussie |
| **Résultat obtenu** | |
| **Statut** | |

### S-03 : Rejet mot de passe incorrect

| Champ | Valeur |
|---|---|
| **Objectif** | Vérifier que le mauvais mot de passe est rejeté |
| **Étapes** | 1. Tenter de se connecter avec un mot de passe incorrect |
| **Résultat attendu** | Connexion refusée, JET contient `ECHEC_AUTH` |
| **Résultat obtenu** | |
| **Statut** | |

### S-04 : Détection force brute (5 échecs / 15 min)

| Champ | Valeur |
|---|---|
| **Objectif** | Vérifier l'alerte après 5 échecs consécutifs |
| **Étapes** | 1. Effectuer 5 tentatives avec mauvais mot de passe en moins de 15 minutes |
| **Résultat attendu** | Alerte visuelle à la 5e tentative, JET contient 5 entrées `ECHEC_AUTH` |
| **Résultat obtenu** | |
| **Statut** | |

### S-05 : Chiffrement connexion SQL Server

| Champ | Valeur |
|---|---|
| **Objectif** | Vérifier que la connexion SQL est chiffrée |
| **Étapes** | 1. Vérifier `appsettings.Production.json` : `Encrypt=True` |
| | 2. Capturer le trafic réseau (Wireshark) et confirmer que les données SQL sont chiffrées |
| **Résultat attendu** | Flux TLS visible, pas de données SQL en clair |
| **Résultat obtenu** | |
| **Statut** | |

### S-06 : Blocage injection SQL

| Champ | Valeur |
|---|---|
| **Objectif** | Vérifier que les champs de connexion résistent à l'injection SQL |
| **Étapes** | 1. Saisir `admin' OR '1'='1` dans le champ login |
| | 2. Saisir `' ; DROP TABLE t_user --` dans le champ mot de passe |
| **Résultat attendu** | Connexion refusée, aucune erreur SQL exposée, JET contient `ECHEC_AUTH` |
| **Résultat obtenu** | |
| **Statut** | |

---

## PILIER C — CONSERVATION

### C-01 : Purge marquée, non supprimée

| Champ | Valeur |
|---|---|
| **Objectif** | Vérifier que la purge ne supprime pas physiquement les tickets |
| **Prérequis** | Archive fiscale couvrant la période, intégrité vérifiée |
| **Étapes** | 1. Appeler `PurgeDonneesPeriode(dateDebut, dateFin)` |
| | 2. Vérifier `SELECT COUNT(*) FROM T_CommandeVente WHERE PurgeLe IS NOT NULL` |
| | 3. Vérifier que `SELECT COUNT(*)` total n'a pas diminué |
| **Résultat attendu** | Tickets marqués `PurgeLe`/`PurgePar`, aucun ticket physiquement supprimé |
| **Résultat obtenu** | |
| **Statut** | |

### C-02 : Blocage purge sans archive

| Champ | Valeur |
|---|---|
| **Objectif** | Vérifier que la purge est refusée si aucune archive ne couvre la période |
| **Étapes** | 1. Appeler `PurgeDonneesPeriode` sur une période sans archive |
| **Résultat attendu** | `InvalidOperationException` : "PURGE BLOQUÉE : aucune archive fiscale" |
| **Résultat obtenu** | |
| **Statut** | |

### C-03 : Triggers JET append-only

| Champ | Valeur |
|---|---|
| **Objectif** | Vérifier que le JET est immuable |
| **Étapes** | 1. Tenter `UPDATE T_JournalEvenements SET Description = 'MODIF' WHERE Id = [id]` |
| | 2. Tenter `DELETE FROM T_JournalEvenements WHERE Id = [id]` |
| **Résultat attendu** | Erreurs SQL, aucune ligne modifiée ni supprimée |
| **Résultat obtenu** | |
| **Statut** | |

---

## PILIER A — ARCHIVAGE

### A-01 : Génération archive XML

| Champ | Valeur |
|---|---|
| **Objectif** | Vérifier la génération d'une archive fiscale complète |
| **Étapes** | 1. Appeler `ExporterArchiveFiscale(dateDebut, dateFin, chemin)` |
| | 2. Ouvrir le fichier XML généré |
| **Résultat attendu** | Fichier XML valide contenant tickets, lignes, TVA par taux, clôtures, signature SHA-256 |
| **Résultat obtenu** | |
| **Statut** | |

### A-02 : Vérification intégrité archive

| Champ | Valeur |
|---|---|
| **Objectif** | Vérifier que la consultation détecte une archive modifiée |
| **Étapes** | 1. Modifier manuellement un octet dans le fichier XML d'archive |
| | 2. Appeler `ConsulterArchiveFiscale(chemin)` |
| **Résultat attendu** | Alerte "intégrité compromise", JET contient `CONSULTATION_ARCHIVE` avec anomalie |
| **Résultat obtenu** | |
| **Statut** | |

### A-03 : Export FEC conforme DGFiP

| Champ | Valeur |
|---|---|
| **Objectif** | Vérifier la conformité du fichier FEC |
| **Étapes** | 1. Appeler `ExporterFEC(dateDebut, dateFin, chemin)` |
| | 2. Ouvrir dans Excel / éditeur texte |
| | 3. Compter les colonnes (tabulation), vérifier encodage UTF-8 BOM |
| | 4. Vérifier l'équilibre débit/crédit pour chaque écriture |
| **Résultat attendu** | 18 colonnes, UTF-8 BOM, séparateur tabulation, débit = crédit pour chaque ticket |
| **Résultat obtenu** | |
| **Statut** | |

---

## CLÔTURES ET GTP

### G-01 : Clôture journalière (Ticket Z)

| Champ | Valeur |
|---|---|
| **Objectif** | Vérifier la clôture et l'impression du Ticket Z |
| **Étapes** | 1. Effectuer au moins une vente |
| | 2. Appeler la clôture journalière |
| | 3. Vérifier dans `T_Cloture` l'entrée `TypeCloture = 'JOUR'` |
| | 4. Vérifier que le Ticket Z s'imprime (aperçu ou impression) |
| **Résultat attendu** | Ligne `T_Cloture` créée, GTP mis à jour, Ticket Z imprimé avec signature, JET contient `CLOTURE_JOUR` |
| **Résultat obtenu** | |
| **Statut** | |

### G-02 : Blocage double clôture

| Champ | Valeur |
|---|---|
| **Objectif** | Vérifier qu'on ne peut pas clôturer deux fois la même journée |
| **Étapes** | 1. Effectuer une clôture journalière |
| | 2. Tenter immédiatement une seconde clôture journalière |
| **Résultat attendu** | `InvalidOperationException` : "Une clôture JOUR existe déjà pour cette journée" |
| **Résultat obtenu** | |
| **Statut** | |

### G-03 : Monotonie du GTP

| Champ | Valeur |
|---|---|
| **Objectif** | Vérifier que le GTP ne diminue jamais |
| **Étapes** | 1. Appeler `VerifierMonotonieGTP(True)` |
| **Résultat attendu** | "GTP valide — monotonie confirmée", 0 anomalie |
| **Résultat obtenu** | |
| **Statut** | |

### G-04 : Détection clôtures manquantes

| Champ | Valeur |
|---|---|
| **Objectif** | Vérifier la détection des jours avec ventes sans clôture Z |
| **Prérequis** | Avoir au moins un jour avec des ventes et sans clôture |
| **Étapes** | 1. Appeler `AlerterCloturesManquantes()` |
| **Résultat attendu** | MessageBox d'alerte listant les jours manquants, JET contient `ALERTE_CLOTURE_MANQUANTE` |
| **Résultat obtenu** | |
| **Statut** | |

---

## PROCÉDURE DE RE-CERTIFICATION APRÈS MISE À JOUR MAJEURE

Toute mise à jour MAJEURE (changement d'algorithme de signature, refonte base de données) nécessite une re-certification auprès d'INFOCERT. La procédure est la suivante :

1. **Mettre à jour le Dossier Technique** : décrire les changements apportés
2. **Exécuter l'intégralité de ce plan de tests** sur l'environnement de pré-production
3. **Constituer le dossier de preuves** : captures d'écran, logs JET, résultats des tests
4. **Soumettre à INFOCERT** : dossier technique + résultats de tests + binaires signés
5. **Audit INFOCERT** : présentation technique, réponse aux questions
6. **Réception du certificat** : numéro de certificat à intégrer dans le logiciel et les documents

---

*Ce plan de tests doit être conservé avec les résultats de chaque exécution, datés et signés par le responsable technique.*
*Version du document : 1.0 — 2026-04-10*
