# MANUEL UTILISATEUR — FONCTIONS NF525
## CHINOOK LEUCATE CLI 4.0

---

**Version :** 4.0
**Date :** 2026-03-26
**Public cible :** Utilisateurs, responsables de caisse, administrateurs

---

## TABLE DES MATIÈRES

1. Introduction — Qu'est-ce que la norme NF525 ?
2. Connexion et sécurité du compte
3. Réaliser une vente conforme NF525
4. Clôture journalière — Ticket Z
5. Clôtures mensuelle et annuelle
6. Vérification de l'intégrité des données
7. Archivage fiscal
8. Export FEC
9. Gestion de la purge des données
10. Alertes et messages NF525
11. Foire aux questions (FAQ)
12. Contacts et assistance

---

## 1. INTRODUCTION — QU'EST-CE QUE LA NORME NF525 ?

Depuis le **1er janvier 2018**, la loi française (article 88 de la loi de finances 2016, BOI-TVA-DECLA-30-10-30) impose à tous les assujettis à la TVA utilisant un logiciel de caisse de disposer d'un système certifié **NF525** ou **ISO 9001**.

La certification NF525 garantit que le logiciel de caisse :

- **Ne peut pas être falsifié** : chaque ticket est signé électroniquement et chaîné au précédent
- **Conserve toutes les données** : aucune suppression physique n'est possible
- **Produit des clôtures traçables** : le Ticket Z quotidien récapitule l'activité avec un total cumulé (Grand Total Perpétuel)
- **Permet le contrôle fiscal** : export FEC disponible sur demande de l'administration

> **Important :** En cas de contrôle fiscal, l'absence de certification expose l'entreprise à une amende de **7 500 € par logiciel non certifié**.

---

## 2. CONNEXION ET SÉCURITÉ DU COMPTE

### 2.1 Première connexion après mise à jour

Lors de votre première connexion après l'installation de CLI 4.0, si votre mot de passe était stocké en format ancien, il sera **automatiquement sécurisé** (converti en format PBKDF2) sans aucune action de votre part.

Vous n'avez pas besoin de changer votre mot de passe.

### 2.2 Règles de sécurité du mot de passe

- Longueur minimale recommandée : **8 caractères**
- Mélangez lettres, chiffres et caractères spéciaux
- Ne communiquez jamais votre mot de passe à un tiers
- Chaque utilisateur doit avoir son propre compte (partage de compte interdit NF525)

### 2.3 Alertes de sécurité

Après **5 tentatives de connexion échouées en 15 minutes**, une alerte s'affiche. Cela peut signifier :
- Vous avez mal saisi votre mot de passe → essayez à nouveau
- Quelqu'un tente d'accéder à votre compte → contactez votre administrateur

### 2.4 Déconnexion

Déconnectez-vous systématiquement lorsque vous quittez le poste de caisse. Chaque session est tracée dans le journal d'audit.

---

## 3. RÉALISER UNE VENTE CONFORME NF525

### 3.1 Enregistrement d'une vente

Le processus de vente est identique aux versions précédentes. La conformité NF525 est transparente pour le caissier :

1. Sélectionnez les articles
2. Appliquez les remises éventuelles
3. Encaissez le paiement
4. Validez le ticket → **la signature est calculée automatiquement**

### 3.2 Ce que vous ne pouvez pas faire (NF525)

- **Modifier un ticket validé** : toute modification est bloquée au niveau de la base de données
- **Supprimer un ticket** : seule la procédure d'avoir (annulation) est autorisée
- **Modifier la TVA d'un article après validation** : l'historique des taux est conservé

### 3.3 Avoirs et annulations

Pour annuler un ticket validé :

1. Accédez au ticket via **Historique des ventes**
2. Cliquez sur **Créer un avoir**
3. L'avoir est créé avec référence au ticket original
4. Un nouveau ticket d'avoir signé est généré

> Un avoir ne supprime pas le ticket original : les deux restent en base pour la piste d'audit.

---

## 4. CLÔTURE JOURNALIÈRE — TICKET Z

### 4.1 Obligation légale

La clôture journalière (Ticket Z) est **obligatoire tous les jours où des ventes ont été réalisées**. Elle doit être effectuée avant la fin de la journée (ou au plus tard avant les premières ventes du lendemain).

### 4.2 Effectuer une clôture Z

1. Accédez à **Administration → Clôtures → Clôture journalière**
2. Le système calcule automatiquement les totaux de la journée
3. Cliquez sur **Effectuer la clôture**
4. Le **Ticket Z** s'imprime automatiquement

> **Vous ne pouvez pas effectuer deux clôtures Z pour la même journée.** Si vous tentez de re-clôturer une journée déjà clôturée, un message d'erreur s'affiche.

### 4.3 Contenu du Ticket Z

Le Ticket Z imprimé contient :

```
================================
      CHINOOK LEUCATE
      [Adresse]
      SIRET : [SIRET]
================================
  CLÔTURE JOURNALIÈRE (Z)
  Date : [date]    Heure : [heure]

Tickets de la journée : [nombre]
────────────────────────────────
TVA  5,5% │ HT : [montant]
           │ TVA: [montant]
TVA 10,0% │ HT : [montant]
           │ TVA: [montant]
TVA 20,0% │ HT : [montant]
           │ TVA: [montant]
────────────────────────────────
TOTAL HT          : [montant] €
TOTAL TVA          : [montant] €
TOTAL TTC          : [montant] €
────────────────────────────────
Avoirs             : [nombre]
Montant avoirs     : [montant] €
────────────────────────────────
GRAND TOTAL PERPÉTUEL
(cumul depuis le 1er ticket)
GTP TTC            : [montant] €
────────────────────────────────
Signature : [extrait 16 car.]
Conforme NF525 — INFOCERT
================================
```

### 4.4 Conservation du Ticket Z

Le Ticket Z papier doit être **conservé 6 ans** (article L102 B du LPF). Classez-les chronologiquement dans un classeur dédié.

---

## 5. CLÔTURES MENSUELLE ET ANNUELLE

### 5.1 Clôture mensuelle

La clôture mensuelle récapitule l'activité du mois. Elle est recommandée mais non obligatoire si les clôtures Z quotidiennes sont correctement effectuées.

**Accès :** Administration → Clôtures → Clôture mensuelle

> Effectuez la clôture mensuelle le dernier jour du mois, après la dernière clôture Z du mois.

### 5.2 Clôture annuelle

La clôture annuelle récapitule l'exercice comptable.

**Accès :** Administration → Clôtures → Clôture annuelle

> Effectuez la clôture annuelle au 31 décembre ou au dernier jour de l'exercice, après la clôture mensuelle de décembre.

### 5.3 Impossible d'effectuer une double clôture

Pour chaque type de clôture, le système vérifie qu'aucune clôture n'a déjà été effectuée pour la même période. Un message d'erreur s'affiche si vous tentez une double clôture.

---

## 6. VÉRIFICATION DE L'INTÉGRITÉ DES DONNÉES

### 6.1 À quoi sert la vérification ?

La vérification d'intégrité contrôle que :
- Aucun ticket n'a été modifié ou supprimé depuis sa création
- La chaîne de signatures est continue (pas de rupture)
- Le Grand Total Perpétuel ne diminue jamais

### 6.2 Lancer la vérification

**Accès :** Administration → NF525 → Vérification d'intégrité

Cette opération peut prendre quelques minutes si la base contient de nombreux tickets.

### 6.3 Interpréter le résultat

| Résultat | Signification | Action |
|---|---|---|
| ✅ INTÉGRITÉ OK | Tous les tickets sont valides | Aucune action requise |
| ❌ ANOMALIE DÉTECTÉE | Un ou plusieurs tickets ont été modifiés | Contacter immédiatement votre référent NF525 |

> **En cas d'anomalie**, ne pas effectuer de nouvelles ventes. Contactez le support technique immédiatement. Une anomalie d'intégrité doit être signalée à votre expert-comptable.

---

## 7. ARCHIVAGE FISCAL

### 7.1 Obligation d'archivage

Les données de vente doivent être archivées et conservées **6 ans minimum** à partir de la date de la dernière opération enregistrée dans l'archive.

### 7.2 Créer une archive fiscale

1. Accédez à **Administration → Archives → Créer une archive**
2. Sélectionnez la période (date de début, date de fin)
3. Choisissez le dossier de destination
4. Cliquez sur **Générer l'archive**

L'archive est créée au format XML signé. Conservez ce fichier sur un support externe (disque dur externe, serveur de sauvegarde).

### 7.3 Consulter une archive

1. Accédez à **Administration → Archives → Consulter une archive**
2. Sélectionnez le fichier archive
3. L'intégrité du fichier est vérifiée automatiquement

> Toute consultation d'archive est tracée dans le journal d'audit.

### 7.4 Contenu de l'archive

L'archive XML contient :
- Tous les tickets de vente de la période
- Le détail de chaque ligne de vente
- La ventilation TVA par taux
- Les clôtures de la période
- Les signatures cryptographiques de chaque ticket

---

## 8. EXPORT FEC

### 8.1 Qu'est-ce que le FEC ?

Le **Fichier des Écritures Comptables (FEC)** est un fichier standardisé exigé par l'administration fiscale lors d'un contrôle. Il contient l'ensemble des écritures comptables de la période dans un format lisible par les outils de contrôle de la DGFiP.

**Base légale :** Article A47 A-1 du CGI, article L47 A du LPF.

### 8.2 Générer le FEC

1. Accédez à **Administration → Exports → Fichier FEC**
2. Sélectionnez la période comptable (ex : 01/01/2025 → 31/12/2025)
3. Choisissez le dossier de destination
4. Cliquez sur **Générer le FEC**

Le fichier généré est nommé automatiquement selon le format DGFiP : `[SIRET]FEC[YYYYMMDD].txt`

### 8.3 Format du fichier

Le FEC est un fichier texte avec :
- Encodage UTF-8 avec BOM
- Séparateur : tabulation (`\t`)
- 18 colonnes imposées par la DGFiP
- Montants avec virgule décimale (format français)

### 8.4 Remise à l'administration fiscale

En cas de demande de contrôle fiscal :
- Délai de remise : **15 jours** à compter de la demande
- Format : fichier FEC sur support informatique (clé USB ou transmission électronique)
- Accompagner le fichier de la documentation NF525 du logiciel

---

## 9. GESTION DE LA PURGE DES DONNÉES

### 9.1 Qu'est-ce que la purge ?

La purge permet de "désactiver" des données anciennes pour alléger la base de données, tout en conservant les données dans la chaîne de signatures (conformément à NF525).

> **Important :** La purge NF525 ne supprime jamais physiquement les données. Les tickets purgés restent en base mais sont marqués comme purgés.

### 9.2 Conditions de purge

Avant de pouvoir purger une période, les conditions suivantes doivent être réunies :

1. **Une archive fiscale doit exister** pour la période à purger
2. **L'intégrité de la chaîne de signatures doit être vérifiée** pour la période
3. **La période doit être antérieure à 3 ans** (recommandation — la conservation légale est de 6 ans)

### 9.3 Effectuer une purge

1. Accédez à **Administration → Archives → Purge sécurisée**
2. Sélectionnez la période
3. Le système vérifie automatiquement les conditions
4. Si toutes les conditions sont remplies, confirmez la purge

La purge est tracée dans le journal d'audit avec votre identité et la date.

---

## 10. ALERTES ET MESSAGES NF525

### 10.1 Alerte clôtures manquantes

Au démarrage du logiciel, si des **jours sans clôture Z** sont détectés (alors que des ventes ont été effectuées), une alerte s'affiche :

```
⚠️  CLÔTURES MANQUANTES DÉTECTÉES
Des jours avec des ventes n'ont pas de clôture Z :
- [Date 1] : [N] ticket(s)
- [Date 2] : [N] ticket(s)

NF525 : une clôture Z par journée d'activité est obligatoire.
```

**Action requise :** Effectuez les clôtures manquantes dès que possible. En cas de doute, contactez votre comptable.

### 10.2 Alerte Grand Total Perpétuel

Si une anomalie est détectée dans le GTP (valeur qui diminue), une alerte critique s'affiche. Cette situation est **grave** et doit être signalée immédiatement à votre référent NF525 et à votre expert-comptable.

### 10.3 Message de validation de clôture

Après chaque clôture réussie, un message de confirmation affiche :
- Le montant total TTC de la période
- Le nouveau Grand Total Perpétuel
- Le numéro de clôture

---

## 11. FOIRE AUX QUESTIONS (FAQ)

### Q : Puis-je modifier un ticket après validation ?

**Non.** La norme NF525 interdit toute modification d'un ticket validé. Si une erreur s'est produite, vous devez créer un **avoir** pour annuler le ticket, puis re-saisir la vente correcte.

### Q : Que faire si j'ai oublié d'effectuer la clôture Z ?

Effectuez la clôture dès que vous vous en rendez compte. Le système vous proposera de clôturer la journée manquante. Si plusieurs jours sont manquants, effectuez les clôtures dans l'ordre chronologique.

### Q : Puis-je utiliser le logiciel sans effectuer les clôtures Z ?

Techniquement oui, mais cela constitue une **non-conformité NF525**. En cas de contrôle fiscal, l'absence de clôtures quotidiennes peut être sanctionnée.

### Q : Combien de temps dois-je conserver les archives ?

**6 ans minimum** à compter de la date de la dernière opération contenue dans l'archive (article L102 B du LPF). Par exemple, une archive de l'année 2025 doit être conservée jusqu'au 31 décembre 2031 au minimum.

### Q : Que faire si le ticket imprimante est en panne lors de la clôture Z ?

La clôture est quand même enregistrée en base de données. Vous pouvez réimprimer le Ticket Z depuis **Historique → Clôtures → Réimprimer**. Notez que la réimpression doit être tracée.

### Q : Comment savoir si mon logiciel est bien certifié ?

Le certificat NF525 est affiché dans **Aide → À propos → Certification NF525**. Vous y trouverez le numéro de certificat, la date de certification et l'organisme (INFOCERT).

### Q : Qu'est-ce que le Grand Total Perpétuel ?

C'est le total cumulé de toutes les ventes TTC depuis la première transaction enregistrée dans le logiciel. Il ne peut jamais diminuer — même si vous faites des avoirs. C'est un indicateur de fiabilité NF525.

### Q : Qui a accès aux fonctions d'archivage et d'export FEC ?

Uniquement les utilisateurs avec le rôle **Administrateur**. Ces opérations sont tracées dans le journal d'audit.

---

## 12. CONTACTS ET ASSISTANCE

### Support technique

En cas de dysfonctionnement du logiciel lié aux fonctions NF525, contactez votre prestataire informatique :

- **Prestataire :** [Raison sociale — à compléter]
- **Email :** [Email support — à compléter]
- **Téléphone :** [Numéro — à compléter]
- **Horaires :** [Horaires — à compléter]

### Urgences NF525

En cas d'**anomalie d'intégrité** (message "ANOMALIE DÉTECTÉE") :
1. Ne réalisez plus aucune vente
2. Contactez immédiatement votre prestataire technique
3. Prévenez votre expert-comptable
4. Conservez tous les messages d'erreur affichés

### Organisme de certification

**INFOCERT**
Site : www.infocert.fr
Pour toute question relative à la certification NF525.

---

*Ce manuel est fourni avec le logiciel CHINOOK LEUCATE CLI 4.0 certifié NF525.*
*Il doit être accessible à tous les utilisateurs du logiciel et conservé pendant toute la durée d'utilisation.*
*Version du document : 1.0 — 2026-03-26*
