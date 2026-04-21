# PROCÉDURE DE SURVEILLANCE ANNUELLE NF525
## CHINOOK LEUCATE CLI 4.0

**Version du document :** 1.0
**Date :** 2026-04-10
**Fréquence :** Annuelle (à effectuer avant le 31 mars de chaque année N+1)
**Responsable :** [Nom du responsable technique — à compléter]
**Référentiel :** NF525 (AFNOR XP Z10-003) — Obligations post-certification INFOCERT

---

## OBJECTIF

La surveillance annuelle est une **obligation post-certification NF525**.  
Elle vise à vérifier que le logiciel reste conforme à la norme après une année d'exploitation, et à détecter toute dérive ou anomalie avant qu'elle ne constitue un risque fiscal pour le client.

Elle produit un **Rapport de Surveillance Annuelle** qui doit être conservé 6 ans et peut être demandé par INFOCERT lors d'un audit de suivi.

---

## PLANNING RECOMMANDÉ

| Étape | Période | Responsable |
|---|---|---|
| Lancement de la revue | Janvier de l'année N+1 | Responsable technique |
| Collecte des données | Janvier – Février | Responsable technique |
| Exécution des contrôles | Février – Mars | Responsable technique |
| Rédaction du rapport | Mars | Responsable technique |
| Validation du rapport | Avant le 31 mars | Responsable légal / dirigeant |
| Archivage du rapport | Avant le 31 mars | Responsable technique |

---

## CONTRÔLE 1 — VÉRIFICATION DE L'INTÉGRITÉ DE LA CHAÎNE DE SIGNATURES

**Outil :** `VerifierIntegriteChaine()` ou `VerifierIntegriteChaineX509()` (selon mode activé)

**Procédure :**
1. Se connecter avec un compte Administrateur
2. Accéder à Administration → NF525 → Vérification d'intégrité
3. Lancer la vérification sur l'ensemble de la période de l'exercice
4. Consulter le résultat dans le Journal des Événements Techniques :
   - Rechercher `INTEGRITE_X509_OK` ou `INTEGRITE_KO`

**Résultat attendu :** 0 rupture de chaîne, 0 signature invalide

| Résultat | Action |
|---|---|
| ✅ `INTEGRITE_OK` | Consigner dans le rapport, aucune action |
| ❌ `INTEGRITE_KO` | Arrêt immédiat — escalade P1 — notifier INFOCERT sous 48h |

**À documenter dans le rapport :**
- Nombre de tickets vérifiés (RSA + HMAC)
- Nombre de ruptures de chaîne : [0 attendu]
- Nombre de signatures invalides : [0 attendu]
- Date d'exécution du contrôle

---

## CONTRÔLE 2 — VÉRIFICATION DE LA MONOTONIE DU GRAND TOTAL PERPÉTUEL

**Outil :** `VerifierMonotonieGTP(True)`

**Procédure :**
1. Accéder à Administration → NF525 → Contrôle GTP
2. Lancer la vérification
3. Consulter le résultat

**Résultat attendu :** GTP strictement croissant sur toute la période — 0 anomalie

| Résultat | Action |
|---|---|
| ✅ GTP monotone | Consigner dans le rapport |
| ❌ GTP décroissant détecté | Escalade P1 — notifier INFOCERT |

**À documenter :**
- Valeur du GTP au 1er janvier de l'exercice
- Valeur du GTP au 31 décembre de l'exercice
- Confirmation de la croissance monotone : Oui / Non

---

## CONTRÔLE 3 — VÉRIFICATION DES CLÔTURES JOURNALIÈRES

**Outil :** `VerifierCloturesJournalieresManquantes(01/01/N, 31/12/N)`

**Procédure :**
1. Accéder à Administration → NF525 → Contrôle clôtures
2. Saisir la période : 01/01/[année] → 31/12/[année]
3. Lancer la vérification

**Résultat attendu :** 0 jour avec des ventes sans clôture Z

| Résultat | Action |
|---|---|
| ✅ 0 clôture manquante | Consigner dans le rapport |
| ⚠️ Clôtures manquantes | Effectuer les clôtures tardives documentées, signaler dans le rapport |

**À documenter :**
- Nombre de jours d'activité (jours avec au moins une vente)
- Nombre de clôtures Z effectuées
- Liste des jours manquants éventuels avec justification

---

## CONTRÔLE 4 — REVUE DES ARCHIVES FISCALES

**Outil :** `ConsulterArchiveFiscale(chemin)` pour chaque archive

**Procédure :**
1. Lister toutes les archives fiscales générées dans l'année
2. Pour chaque archive : vérifier l'intégrité (SHA-256)
3. Vérifier que la couverture est complète (pas de période non archivée)

**À documenter :**
- Nombre d'archives générées dans l'année
- Résultat de vérification d'intégrité pour chacune (OK / KO)
- Localisation des archives (chemin serveur, support externe)
- Confirmation de la sauvegarde hors site

---

## CONTRÔLE 5 — REVUE DES ACCÈS ET DES COMPTES UTILISATEURS

**Procédure SQL :**
```sql
-- Lister tous les comptes actifs
SELECT login, role, password FROM t_user ORDER BY role, login;

-- Vérifier que tous les mots de passe sont en format PBKDF2
SELECT COUNT(*) AS TotalComptes,
       SUM(CASE WHEN password LIKE '$pbkdf2sha1v1$%' THEN 1 ELSE 0 END) AS ComptesSecurises,
       SUM(CASE WHEN password NOT LIKE '$pbkdf2sha1v1$%' THEN 1 ELSE 0 END) AS ComptesNonSecurises
FROM t_user;

-- Revue des accès administrateurs dans le JET (12 derniers mois)
-- Note : colonnes réelles = TypeEvent, DateEvent, Utilisateur (schéma T_JournalEvenements)
SELECT DateEvent, TypeEvent, Utilisateur, Description
FROM T_JournalEvenements
WHERE TypeEvent IN ('CONNEXION_REUSSIE', 'ACCES_ADMIN', 'ECHEC_AUTHENTIFICATION')
  AND DateEvent >= DATEADD(YEAR, -1, GETDATE())
ORDER BY DateEvent DESC;
```

**Vérifications à effectuer :**
- [ ] Tous les mots de passe sont au format PBKDF2 (`$pbkdf2sha1v1$`)
- [ ] Aucun compte générique ou partagé (chaque employé a son propre compte)
- [ ] Les comptes d'anciens employés sont désactivés
- [ ] Le nombre de comptes Administrateur est justifié (principe du moindre privilège)

**À documenter :**
- Nombre de comptes actifs par rôle
- Nombre de comptes avec mot de passe non sécurisé (doit être 0)
- Éventuels comptes suspects ou à désactiver

---

## CONTRÔLE 6 — VÉRIFICATION DES TRIGGERS ET DE LA BASE DE DONNÉES

**Procédure SQL :**
```sql
-- Vérifier que les triggers sont actifs
SELECT name, is_disabled, type_desc
FROM sys.triggers
WHERE name IN (
  'TR_JET_AppendOnly',
  'TR_Vente_NoModifSignature',
  'TR_VenteLigne_NoModifSignature',
  'TR_Cloture_AppendOnly'
);

-- Test du trigger JET (doit échouer)
-- UPDATE T_JournalEvenements SET Description = 'TEST' WHERE Id = 1;
```

**Résultat attendu :** 4 triggers présents, `is_disabled = 0` pour tous

| Trigger | Présent | Actif | Résultat test blocage |
|---|---|---|---|
| TR_JET_AppendOnly | ☐ Oui / ☐ Non | ☐ Oui / ☐ Non | ☐ Bloqué / ☐ Non bloqué |
| TR_Vente_NoModifSignature | ☐ Oui / ☐ Non | ☐ Oui / ☐ Non | ☐ Bloqué / ☐ Non bloqué |
| TR_VenteLigne_NoModifSignature | ☐ Oui / ☐ Non | ☐ Oui / ☐ Non | ☐ Bloqué / ☐ Non bloqué |
| TR_Cloture_AppendOnly | ☐ Oui / ☐ Non | ☐ Oui / ☐ Non | ☐ Bloqué / ☐ Non bloqué |

---

## CONTRÔLE 7 — VÉRIFICATION DU CERTIFICAT X.509

**Procédure :**
1. Accéder à Administration → NF525 → Informations certificat
2. Vérifier :
   - La date d'expiration (NotAfter) — renouveler si < 3 mois
   - La présence de la clé privée
   - L'algorithme (doit être RSA-2048 minimum)

**À documenter :**
- Sujet du certificat
- Date d'expiration
- Algorithme et longueur de clé
- Action si renouvellement nécessaire : date cible, responsable

---

## CONTRÔLE 8 — REVUE DU JOURNAL DES ÉVÉNEMENTS TECHNIQUES

**Procédure SQL :**
```sql
-- Statistiques annuelles du JET
SELECT TypeEvent, COUNT(*) AS NbOccurrences
FROM T_JournalEvenements
WHERE DateEvent >= DATEADD(YEAR, -1, GETDATE())
GROUP BY TypeEvent
ORDER BY NbOccurrences DESC;

-- Alertes et erreurs
SELECT DateEvent, TypeEvent, Description, Utilisateur
FROM T_JournalEvenements
WHERE (TypeEvent LIKE 'ERREUR%'
   OR TypeEvent LIKE '%KO%'
   OR TypeEvent LIKE 'ALERTE%')
   AND DateEvent >= DATEADD(YEAR, -1, GETDATE())
ORDER BY DateEvent DESC;
```

**À documenter :**
- Nombre total d'entrées JET dans l'année
- Nombre d'erreurs et d'alertes
- Événements anormaux identifiés et actions prises

---

## RAPPORT DE SURVEILLANCE ANNUELLE

*Template à remplir et signer.*

---

### RAPPORT DE SURVEILLANCE NF525 — EXERCICE [AAAA]

**Logiciel :** CHINOOK LEUCATE CLI 4.0
**Version déployée :** [x.x.x.xxxx]
**Période couverte :** 01/01/[AAAA] → 31/12/[AAAA]
**Date du rapport :** [JJ/MM/AAAA]
**Rédacteur :** [Nom, Prénom, Qualité]

#### Résumé des contrôles

| Contrôle | Résultat | Anomalies | Actions prises |
|---|---|---|---|
| 1 — Intégrité chaîne signatures | ✅ / ❌ | | |
| 2 — Monotonie GTP | ✅ / ❌ | | |
| 3 — Clôtures journalières | ✅ / ❌ | | |
| 4 — Archives fiscales | ✅ / ❌ | | |
| 5 — Accès et comptes | ✅ / ❌ | | |
| 6 — Triggers BDD | ✅ / ❌ | | |
| 7 — Certificat X.509 | ✅ / ❌ | | |
| 8 — Journal des événements | ✅ / ❌ | | |

#### Statistiques annuelles

| Indicateur | Valeur |
|---|---|
| Nombre de tickets de vente | |
| Nombre de clôtures Z effectuées | |
| GTP au 01/01/[AAAA] | € |
| GTP au 31/12/[AAAA] | € |
| CA total TTC de l'exercice | € |
| Nombre d'archives fiscales | |
| Nombre d'incidents de sécurité | |

#### Conclusion

☐ Le logiciel CHINOOK LEUCATE CLI 4.0 est **conforme** à la norme NF525 pour l'exercice [AAAA].
☐ Des **non-conformités** ont été détectées — voir détail ci-dessus.

#### Notification INFOCERT

☐ Aucune notification nécessaire
☐ Notification effectuée le [date] — Réf. [référence]

---

**Signature du responsable technique :**
Nom : _________________________________
Qualité : _________________________________
Date : _________________________________
Signature : _________________________________

---

*Ce rapport doit être conservé 6 ans. Il peut être demandé par INFOCERT lors d'un audit de suivi.*
*Version du document : 1.0 — 2026-04-10*
