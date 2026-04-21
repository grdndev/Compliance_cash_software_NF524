# POLITIQUE DE SERVICE APRÈS-VENTE (SAV)
## CHINOOK LEUCATE CLI 4.0 — Certification NF525

**Éditeur :** [Raison sociale — à compléter]
**Version du document :** 1.0
**Date :** 2026-04-10
**Référentiel :** NF525 (AFNOR XP Z10-003) — Exigences qualité INFOCERT

---

## 1. PÉRIMÈTRE ET ENGAGEMENTS

### 1.1 Périmètre couvert

Cette politique de SAV couvre le logiciel de caisse **CHINOOK LEUCATE CLI 4.0** et ses composants :
- Application WinForms (CLI.exe)
- Module NF525 (signatures, clôtures, archivage, FEC)
- API de synchronisation (CLIMinimalApi)
- Service de synchronisation (CLISyncService)

### 1.2 Engagements généraux

L'éditeur s'engage à :
- Maintenir le logiciel en conformité avec la norme NF525 pendant toute la durée de vie du certificat
- Corriger tout bug affectant les mécanismes de certification dans les délais définis ci-dessous
- Notifier les clients de toute mise à jour impactant la certification
- Fournir un support technique aux utilisateurs et administrateurs
- Répondre aux demandes de l'organisme certificateur INFOCERT

---

## 2. NIVEAUX DE SUPPORT

### 2.1 Classification des incidents

| Priorité | Définition | Exemples |
|---|---|---|
| **P1 — Critique** | Arrêt de la caisse ou impact sur la chaîne de signatures NF525 | Clôture impossible, signature échoue, logiciel ne démarre pas |
| **P2 — Urgent** | Fonctionnalité NF525 dégradée mais caisse utilisable | Ticket Z ne s'imprime pas, export FEC échoue |
| **P3 — Normal** | Anomalie fonctionnelle sans impact NF525 | Bug d'affichage, lenteur |
| **P4 — Faible** | Amélioration ou question | Demande d'évolution, question d'utilisation |

### 2.2 Délais de traitement

| Priorité | Délai de prise en charge | Délai de résolution |
|---|---|---|
| P1 — Critique | **2 heures** (jours ouvrés) | **48 heures** |
| P2 — Urgent | **4 heures** (jours ouvrés) | **5 jours ouvrés** |
| P3 — Normal | **1 jour ouvré** | **30 jours** |
| P4 — Faible | **3 jours ouvrés** | Prochaine version MINEUR |

### 2.3 Horaires de support

| Niveau | Horaires |
|---|---|
| P1 (astreinte) | Lundi – Vendredi, 8h – 18h |
| P2, P3, P4 | Lundi – Vendredi, 9h – 17h |

*Hors jours fériés français.*

---

## 3. CONTACTS

### 3.1 Canaux de contact

| Canal | Priorités couvertes | Coordonnées |
|---|---|---|
| Email support | P1, P2, P3, P4 | [email support — à compléter] |
| Téléphone | P1, P2 | [téléphone — à compléter] |
| Ticketing | P3, P4 | [URL ticketing — à compléter] |

### 3.2 Contacts clients CHINOOK LEUCATE

| Rôle | Nom | Contact |
|---|---|---|
| Responsable technique | [Nom — à compléter] | [email/tél] |
| Responsable exploitation | [Nom — à compléter] | [email/tél] |

---

## 4. PROCÉDURE D'ESCALADE

### 4.1 Niveaux d'escalade

```
Niveau 1 : Support utilisateur (réponse aux questions, procédures)
    ↓ (si non résolu sous 4h pour P1/P2, 2j pour P3)
Niveau 2 : Support technique (analyse logs, correction paramétrage)
    ↓ (si non résolu sous 24h pour P1, 3j pour P2)
Niveau 3 : Développement (correction de code, patch d'urgence)
    ↓ (si impact certification)
Niveau 4 : INFOCERT (notification obligatoire si mécanismes certifiés affectés)
```

### 4.2 Critères d'escalade automatique vers INFOCERT

L'escalade vers INFOCERT est **obligatoire** dans les cas suivants :
- Anomalie d'intégrité de la chaîne de signatures détectée (`INTEGRITE_KO`)
- Compromission suspectée de la clé HMAC ou du certificat X.509
- Bug affectant le Grand Total Perpétuel (GTP)
- Modification involontaire de données fiscales
- Toute mise à jour majeure impactant les mécanismes certifiés

---

## 5. GESTION DES MISES À JOUR

### 5.1 Communication des mises à jour

| Type | Délai de notification | Canal |
|---|---|---|
| Mise à jour MAJEURE (recertification) | **30 jours avant** | Email + courrier |
| Mise à jour MINEUR | **15 jours avant** | Email |
| Correctif SÉCURITÉ | **Dès disponibilité** | Email urgent |

### 5.2 Déploiement des correctifs critiques

Pour les correctifs de sécurité P1, l'éditeur fournit :
1. Le binaire corrigé (CLI.exe)
2. Les scripts SQL de migration (si nécessaire)
3. La procédure de déploiement pas à pas
4. Le support téléphonique pendant le déploiement

### 5.3 Compatibilité ascendante

L'éditeur garantit que toute mise à jour maintient la capacité de lire les données fiscales produites par les versions précédentes certifiées.

---

## 6. OBLIGATIONS DU CLIENT

Pour bénéficier du support SAV, le client doit :

1. **Maintenir l'infrastructure à jour** : SQL Server supporté, Windows supporté
2. **Conserver les fichiers de configuration** : clé HMAC, certificat X.509, variables d'environnement
3. **Effectuer les sauvegardes quotidiennes** de la base de données SQL Server
4. **Signaler les incidents** via les canaux officiels avec les informations demandées
5. **Ne pas modifier** la base de données directement (hors procédures documentées)
6. **Conserver les Tickets Z** papier pendant 6 ans minimum

---

## 7. INFORMATIONS À FOURNIR EN CAS D'INCIDENT

Lors du signalement d'un incident, communiquer systématiquement :

- [ ] Version du logiciel (`Aide → À propos`)
- [ ] Date et heure de l'incident
- [ ] Description précise du comportement observé
- [ ] Message d'erreur exact (copie d'écran bienvenue)
- [ ] Dernière action effectuée avant l'incident
- [ ] Version de Windows et SQL Server
- [ ] Extrait du Journal des Événements Techniques (JET) si accessible
- [ ] Nom de l'utilisateur connecté au moment de l'incident

---

## 8. GARANTIES ET EXCLUSIONS

### 8.1 Garanties incluses

- Conformité du logiciel certifié avec la norme NF525 en vigueur
- Correction des bugs affectant les mécanismes de certification
- Mise à disposition des scripts de migration base de données

### 8.2 Exclusions

- Incidents causés par une modification directe de la base de données par le client
- Perte de données due à l'absence de sauvegarde
- Dysfonctionnements liés à une infrastructure non conforme (Windows XP sans SP3, SQL Server 2005)
- Incidents causés par la perte ou la compromission de la clé HMAC ou du certificat X.509

---

*Ce document est un engagement contractuel de l'éditeur envers ses clients.*
*Version du document : 1.0 — 2026-04-10*
