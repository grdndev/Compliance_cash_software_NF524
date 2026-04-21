# REGISTRE DES INCIDENTS DE SÉCURITÉ NF525
## CHINOOK LEUCATE CLI 4.0

**Document :** Template — à instancier pour chaque incident
**Version :** 1.0
**Date de création :** 2026-04-10
**Responsable du registre :** [Nom — à compléter]
**Référentiel :** NF525 (AFNOR XP Z10-003) — Exigences qualité INFOCERT

---

> **Instruction :** Ce registre doit être tenu à jour pour chaque incident de sécurité ou anomalie NF525 détecté.  
> Conserver ce document **6 ans minimum** après clôture du dernier incident.  
> En cas d'incident affectant les mécanismes certifiés, notifier INFOCERT dans les **48 heures**.

---

## TEMPLATE — FICHE INCIDENT

*Copier ce bloc pour chaque nouvel incident.*

---

### INCIDENT #[NUMÉRO] — [TITRE COURT]

**Date de détection :** JJ/MM/AAAA HH:MM
**Détecté par :** [Nom / Système automatique]
**Priorité :** ☐ P1 Critique  ☐ P2 Urgent  ☐ P3 Normal  ☐ P4 Faible

#### 1. Description de l'incident

> *Décrire précisément ce qui s'est passé : comportement observé, messages d'erreur, contexte.*

[Description]

#### 2. Périmètre NF525 impacté

| Pilier NF525 | Impacté ? | Détail |
|---|---|---|
| I — Inaltérabilité (signatures) | ☐ Oui  ☐ Non | |
| S — Sécurisation (accès/auth) | ☐ Oui  ☐ Non | |
| C — Conservation (données) | ☐ Oui  ☐ Non | |
| A — Archivage | ☐ Oui  ☐ Non | |
| GTP — Grand Total Perpétuel | ☐ Oui  ☐ Non | |

#### 3. Impact

**Impact sur la chaîne de signatures :** ☐ Oui  ☐ Non  ☐ Inconnu

**Tickets de vente affectés :**
- Nombre de tickets concernés : [nombre ou "aucun"]
- Plage de tickets : #[premier] → #[dernier]
- Période concernée : [date début] → [date fin]

**Impact client :**
- Caisse arrêtée : ☐ Oui  ☐ Non
- Données fiscales compromises : ☐ Oui  ☐ Non
- Clôtures impactées : ☐ Oui  ☐ Non

#### 4. Cause racine

> *Après analyse, quelle est la cause précise de l'incident ?*

**Type de cause :**
- ☐ Bug logiciel
- ☐ Erreur de configuration
- ☐ Attaque externe (tentative d'intrusion, force brute)
- ☐ Défaillance matérielle
- ☐ Erreur humaine
- ☐ Expiration certificat / clé

**Description de la cause :**
[Description]

#### 5. Chronologie

| Date/Heure | Événement |
|---|---|
| [JJ/MM HH:MM] | Détection de l'incident |
| [JJ/MM HH:MM] | Notification interne |
| [JJ/MM HH:MM] | Début investigation |
| [JJ/MM HH:MM] | Identification cause racine |
| [JJ/MM HH:MM] | Mise en œuvre du correctif |
| [JJ/MM HH:MM] | Tests de validation |
| [JJ/MM HH:MM] | Clôture de l'incident |

#### 6. Actions correctives

| # | Action | Responsable | Délai | Statut |
|---|---|---|---|---|
| 1 | [Description action] | [Nom] | [Date] | ☐ En cours  ☐ Terminé |
| 2 | | | | |
| 3 | | | | |

#### 7. Actions préventives

> *Que faire pour éviter que cet incident se reproduise ?*

| # | Action préventive | Responsable | Délai |
|---|---|---|---|
| 1 | [Description] | | |
| 2 | | | |

#### 8. Notification INFOCERT

**Notification requise :** ☐ Oui  ☐ Non

Si oui :
- Date de notification : [JJ/MM/AAAA]
- Référence dossier INFOCERT : [référence]
- Réponse INFOCERT : [résumé]

#### 9. Clôture

**Date de clôture :** [JJ/MM/AAAA]
**Clôturé par :** [Nom]
**Résolution :** ☐ Résolue  ☐ Partiellement résolue  ☐ Risque résiduel accepté

**Résumé de clôture :**
[Texte]

---

## TABLEAU DE BORD DES INCIDENTS

*Mettre à jour à chaque nouvel incident ou changement de statut.*

| # | Date | Titre | Priorité | Pilier NF525 | Statut | Date clôture |
|---|---|---|---|---|---|---|
| — | — | Aucun incident enregistré | — | — | — | — |

---

## INDICATEURS ANNUELS

*À compléter lors de la revue annuelle (voir PROCEDURE_SURVEILLANCE_ANNUELLE_NF525.md)*

| Année | Nb incidents total | Nb P1 | Nb P2 | Nb impacts chaîne signatures | Nb notifications INFOCERT |
|---|---|---|---|---|---|
| 2026 | | | | | |
| 2027 | | | | | |

---

*Ce registre est un document confidentiel soumis aux obligations de conservation NF525 (6 ans).*
*Version du document : 1.0 — 2026-04-10*
