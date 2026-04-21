# 📊 KANBAN PROJET NF525 - MISE EN CONFORMITÉ
## Application de Caisse CHINOOK-LEUCATE

**Date de début** : 02/02/2026  
**Deadline certification** : 23/02/2026 (J+21)  
**Chef de projet** : [À définir]  
**Expert NF525** : Consultant Cybersécurité

---

## 📈 INDICATEURS DE PROGRESSION

| Métrique | Valeur | Objectif | Status |
|----------|--------|----------|--------|
| **Tâches totales** | 37 | 37 | 📊 |
| **Tâches terminées** | 21 | 37 | ⏳ 56% |
| **Tâches en cours** | 2 | - | P1-001, P0-002 |
| **Tâches bloquées** | 0 | 0 | ✅ |
| **Vulnérabilités critiques** | 0 | 0 | ✅ |
| **Jours restants** | 20 | - | ⏰ |
| **Conformité NF525** | **65%** | 100% | 🟡 EN COURS |

---

## 🔴 BACKLOG - PRIORITÉ P0 (CRITIQUE - BLOCAGE CERTIFICATION)

### Phase 1 : Infrastructure de base (Jour 1-3)

#### 📦 JOUR 1 - INFRASTRUCTURE DE BASE

| ID | Tâche | Estimation | Assigné | Dépendances | Fichiers concernés |
|----|-------|------------|---------|-------------|-------------------|
| P0-001 | 🔧 Exécuter `database_update_nf525.sql` sur DEV | 30 min | DBA | - | `database_update_nf525.sql` |
| P0-002 | ✅ Vérifier création tables (T_Cloture, T_JournalEvenements) | 15 min | DBA | P0-001 | SQL Server |
| P0-003 | ✅ Vérifier ajout colonnes Signature (3 tables) | 15 min | DBA | P0-001 | `T_CommandeVente`, `T_CommandeVente_Ligne`, `T_Reglement` |
| P0-004 | 🔄 Rafraîchir Dataset Visual Studio (CLIDataSet.xsd) | 1h | Dev | P0-001 | `CLIDataSet.xsd`, `CLIDataSet1.Designer.vb` |
| P0-005 | 🔨 Compiler le projet et corriger erreurs | 1h | Dev | P0-004 | `CLI.sln` |
| P0-006 | 🧪 Tests de build (DEV) | 30 min | Dev | P0-005 | - |

#### 📦 JOUR 2 - INTÉGRATION MODULE SIGNATURE

| ID | Tâche | Estimation | Assigné | Dépendances | Fichiers concernés |
|----|-------|------------|---------|-------------|-------------------|
| P0-007 | 📝 Décommenter ligne 117 (ticketRow.PreviousSignature) | 5 min | Dev | P0-004 | `SignatureHelper.vb` |
| P0-008 | 📝 Décommenter ligne 124 (ticketRow.Signature) | 5 min | Dev | P0-004 | `SignatureHelper.vb` |
| P0-009 | 📝 Décommenter ligne 130 (line.Signature) | 5 min | Dev | P0-004 | `SignatureHelper.vb` |
| P0-010 | 🔗 Intégrer SignTransaction() dans Enregistrer() | 2h | Dev | P0-007-009 | `FormCaisse.vb` ligne 2621 |
| P0-011 | 🧪 Tests unitaires signature (10 tickets fictifs) | 1h | Dev/QA | P0-010 | - |
| P0-012 | ✅ Vérifier chaînage cryptographique (hash n-1) | 1h | Dev | P0-011 | SQL + Log |

#### 📦 JOUR 3 - SUPPRESSION DES DELETE

| ID | Tâche | Estimation | Assigné | Dépendances | Fichiers concernés |
|----|-------|------------|---------|-------------|-------------------|
| P0-013 | 🔧 Ajouter colonnes annulation (Annule, AnnuleLe, AnnulePar) | 30 min | DBA | - | `T_Avoir`, `T_CommandeVente` |
| P0-014 | 🔥 Supprimer DestructionAutoAvoir() ligne 1640 | 1h | Dev | P0-013 | `FormCaisse.vb` |
| P0-015 | 🔄 Remplacer DELETE par UPDATE Annule=1 (ResetAvoir) | 30 min | Dev | P0-013 | `FormCaisse.vb` ligne 1675 |
| P0-016 | 🔄 Remplacer DELETE par UPDATE Annule=1 (tous SQL directs) | 2h | Dev | P0-013 | Recherche globale `grep` |
| P0-017 | 🚫 Désactiver AllowUserToDeleteRows (DataGridViewCommande) | 15 min | Dev | - | `FormCaisse.vb` lignes 708, 754, 826... |
| P0-018 | 🚫 Désactiver AllowUserToDeleteRows (T_ReglementDataGridView) | 15 min | Dev | - | `FormCaisse.vb` lignes 755, 827... |
| P0-019 | 🔄 Modifier event handler UserDeletedRow → Annulation logique | 1h | Dev | P0-017-018 | `FormCaisse.vb` ligne 583 |
| P0-020 | 🧪 Tests de non-régression (annulation commande) | 2h | QA | P0-014-019 | - |

#### 📦 VALIDATION CHAÎNAGE (FIN JOUR 3)

| ID | Tâche | Estimation | Assigné | Dépendances | Fichiers concernés |
|----|-------|------------|---------|-------------|-------------------|
| P0-021 | 🔍 Créer fonction VerifierIntegriteChaine() | 2h | Dev | P0-012 | `ModuleGeneral.vb` (nouveau) |
| P0-022 | 🧪 Tests chaînage sur 100 tickets fictifs | 2h | Dev/QA | P0-021 | - |
| P0-023 | 📊 Documenter résultats tests P0 | 1h | Dev | P0-022 | `TESTS_P0_RESULTATS.md` |

---

## 🟠 BACKLOG - PRIORITÉ P1 (ÉLEVÉ - 1 SEMAINE)

### Phase 2 : Clôtures et conservation (Jour 4-7)

#### 📦 JOUR 4-5 - CLÔTURE JOURNALIÈRE

| ID | Tâche | Estimation | Assigné | Dépendances | Fichiers concernés |
|----|-------|------------|---------|-------------|-------------------|
| P1-001 | 🔧 Créer TableAdapter pour T_Cloture | 1h | Dev | P0-004 | `CLIDataSet.xsd` |
| P1-002 | 📝 Développer GetPreviousClotureSignature() | 1h | Dev | P1-001 | `SignatureHelper.vb` |
| P1-003 | 📝 Développer GetGrandTotalActuel() | 30 min | Dev | P1-001 | `FormCaisse.vb` |
| P1-004 | 📝 Développer ClotureJournaliere() | 3h | Dev | P1-002-003 | `FormCaisse.vb` |
| P1-005 | 📝 Développer ImprimerTicketZ() | 2h | Dev | P1-004 | `FormCaisse.vb` |
| P1-006 | 🎨 Ajouter bouton "Clôture Z" dans menu Caisse | 30 min | Dev | P1-005 | `FormCaisse.Designer.vb` |
| P1-007 | 🔒 Bloquer nouvelles ventes après clôture (jusqu'à minuit) | 1h | Dev | P1-004 | `FormCaisse.vb` |
| P1-008 | 🧪 Tests clôture Z (3 scénarios) | 2h | QA | P1-004-007 | - |

#### 📦 JOUR 6-7 - GRAND TOTAL SUR TICKETS

| ID | Tâche | Estimation | Assigné | Dépendances | Fichiers concernés |
|----|-------|------------|---------|-------------|-------------------|
| P1-009 | 📝 Modifier ImpressionTicketCaisse() - Ajouter signature | 1h | Dev | P0-010 | `FormCaisse.vb` ligne 3151 |
| P1-010 | 📝 Modifier ImpressionTicketCaisse() - Ajouter Grand Total | 1h | Dev | P1-003 | `FormCaisse.vb` ligne 3151 |
| P1-011 | 📝 Modifier ImpressionTicketCaisse() - Ajouter n° séquence | 30 min | Dev | - | `FormCaisse.vb` ligne 3151 |
| P1-012 | 🧪 Tests impression (imprimante Epson TM-T88IV) | 1h | QA | P1-009-011 | - |
| P1-013 | ✅ Validation visuelle ticket conforme NF525 | 30 min | Expert | P1-012 | - |

---

## 🟡 BACKLOG - PRIORITÉ P2 (MOYEN - 2 SEMAINES)

### Phase 3 : Journal des événements (Jour 8-10)

#### 📦 JOURNAL TECHNIQUE (JET)

| ID | Tâche | Estimation | Assigné | Dépendances | Fichiers concernés |
|----|-------|------------|---------|-------------|-------------------|
| P2-001 | 🔧 Créer TableAdapter pour T_JournalEvenements | 1h | Dev | P0-004 | `CLIDataSet.xsd` |
| P2-002 | 📝 Développer GetPreviousEventSignature() | 1h | Dev | P2-001 | `SignatureHelper.vb` |
| P2-003 | 📝 Développer LogEventTechnique() | 2h | Dev | P2-002 | `ModuleGeneral.vb` |
| P2-004 | 🔗 Intégrer logging dans FormCaisse_Load (DEMARRAGE) | 15 min | Dev | P2-003 | `FormCaisse.vb` ligne 37 |
| P2-005 | 🔗 Intégrer logging dans FormParamTva (CHANGEMENT_TVA) | 30 min | Dev | P2-003 | `FormParamTva.vb` |
| P2-006 | 🔗 Intégrer logging dans FormArticle2 (CHANGEMENT_PRIX) | 30 min | Dev | P2-003 | `FormArticle2.vb` |
| P2-007 | 🧪 Tests JET (10 événements différents) | 2h | QA | P2-004-006 | - |

### Phase 4 : Archivage fiscal (Jour 11-14)

#### 📦 EXPORT FISCAL

| ID | Tâche | Estimation | Assigné | Dépendances | Fichiers concernés |
|----|-------|------------|---------|-------------|-------------------|
| P2-008 | 📝 Développer ExporterArchiveFiscale() | 4h | Dev | P2-003 | `ModuleGeneral.vb` |
| P2-009 | 📝 Format XML conforme référentiel NF525 | 3h | Dev | P2-008 | Nouveau fichier XML |
| P2-010 | 🔒 Scellement cryptographique archive (SHA-256) | 2h | Dev | P2-009 | `SignatureHelper.vb` |
| P2-011 | 🎨 Ajouter menu "Export fiscal" dans interface | 30 min | Dev | P2-008 | `FormPrincipale.vb` |
| P2-012 | 🧪 Tests export (100 tickets) | 2h | QA | P2-008-011 | - |

---

## 🔵 BACKLOG - PRIORITÉ P3 (VALIDATION FINALE)

### Phase 5 : Validation et certification (Jour 15-21)

#### 📦 TESTS DE CHARGE

| ID | Tâche | Estimation | Assigné | Dépendances | Fichiers concernés |
|----|-------|------------|---------|-------------|-------------------|
| P3-001 | 🧪 Générer 10 000 tickets fictifs | 1h | QA | Toutes P0-P2 | Script SQL |
| P3-002 | 🔍 Vérifier intégrité chaîne (10K tickets) | 2h | QA | P3-001 | `VerifierIntegriteChaine()` |
| P3-003 | 📊 Tests performance (temps signature) | 2h | QA | P3-001 | - |
| P3-004 | 🔍 Audit SQL (recherche DELETE restants) | 1h | DBA | - | Logs SQL Server |

#### 📦 AUDIT INTERNE

| ID | Tâche | Estimation | Assigné | Dépendances | Fichiers concernés |
|----|-------|------------|---------|-------------|-------------------|
| P3-005 | ✅ Checklist inaltérabilité (Pilier 1) | 2h | Expert | P3-004 | `AUDIT_NF525_RAPPORT_TECHNIQUE.md` |
| P3-006 | ✅ Checklist sécurisation (Pilier 2) | 2h | Expert | P3-004 | `AUDIT_NF525_RAPPORT_TECHNIQUE.md` |
| P3-007 | ✅ Checklist conservation (Pilier 3) | 2h | Expert | P3-004 | `AUDIT_NF525_RAPPORT_TECHNIQUE.md` |
| P3-008 | ✅ Checklist archivage (Pilier 4) | 2h | Expert | P3-004 | `AUDIT_NF525_RAPPORT_TECHNIQUE.md` |

#### 📦 DOSSIER DE CERTIFICATION

| ID | Tâche | Estimation | Assigné | Dépendances | Fichiers concernés |
|----|-------|------------|---------|-------------|-------------------|
| P3-009 | 📄 Rédiger notice technique NF525 | 4h | Expert | P3-005-008 | `NOTICE_TECHNIQUE_NF525.pdf` |
| P3-010 | 📄 Rédiger documentation utilisateur | 3h | Tech Writer | P1-006, P2-011 | `MANUEL_UTILISATEUR_NF525.pdf` |
| P3-011 | 📄 Capturer écrans interface (clôture, export) | 1h | QA | P3-010 | Screenshots |
| P3-012 | 📦 Préparer package certification | 2h | Expert | P3-009-011 | `DOSSIER_CERTIFICATION/` |
| P3-013 | 📧 Soumission organisme certificateur (INFOCERT) | 1h | Chef Projet | P3-012 | Email |

---

## ✅ EN COURS

| ID | Tâche | Assigné | Statut |
|----|-------|---------|--------|
| P1-006 | 🎨 Ajouter bouton "Clôture Z" dans interface | Dev | En cours |
| P0-005 | 🔨 Compiler le projet et corriger erreurs | Dev | En cours |


> **Instructions** : Lorsque vous démarrez une tâche, déplacez-la de BACKLOG vers EN COURS.  
> Mettez à jour la date de début et l'assignation.

---

## 🎉 TERMINÉ

| ID | Tâche | Date Fin | Commentaire |
|----|-------|----------|-------------|
| P0-001 | 🔧 Préparer `database_update_nf525.sql` | 02/02/2026 | Ajout signatures + annulations |
| P0-002 | ✅ Vérifier création tables | 02/02/2026 | T_Cloture, T_JournalEvenements créées |
| P0-004 | 🔄 Rafraîchir Dataset (CLIDataSet.xsd) | 02/02/2026 | Injection colonnes + Suppression DELETE |
| P0-007 | 📝 Décommenter ticketRow.PreviousSignature | 23/05/2024 | OK |
| P0-008 | 📝 Décommenter ticketRow.Signature | 23/05/2024 | OK |
| P0-009 | 📝 Décommenter line.Signature | 23/05/2024 | OK |
| P0-010 | 🔗 Intégrer SignTransaction() dans Enregistrer()| 23/05/2024 | Intégration complète |
| P0-013 | 🔧 Ajouter colonnes annulation (SQL) | 02/02/2026 | OK |
| P0-015 | 🔄 Remplacer DELETE par UPDATE (ResetAvoir) | 23/05/2024 | OK |
| P0-017 | 🚫 Désactiver AllowUserToDeleteRows (Vente) | 23/05/2024 | OK |
| P0-018 | 🚫 Désactiver AllowUserToDeleteRows (Regl) | 23/05/2024 | OK |
| P1-001 | 🔧 Créer TableAdapter pour T_Cloture | 02/02/2026 | Injecté dans XSD |
| P1-002 | 📝 Développer GetPreviousClotureSignature() | 02/02/2026 | OK (ModuleNF525) |
| P1-003 | 📝 Développer GetGrandTotalActuel() | 02/02/2026 | OK (ModuleNF525) |
| P1-004 | 📝 Développer ClotureJournaliere() | 02/02/2026 | OK (ModuleNF525) |
| P2-001 | 🔧 Créer TableAdapter pour T_JournalEvenements | 02/02/2026 | Injecté dans XSD |
| P2-002 | 📝 Développer GetPreviousEventSignature() | 02/02/2026 | OK (ModuleNF525) |
| P2-003 | 📝 Développer LogEventTechnique() | 02/02/2026 | OK (ModuleNF525) |
| P2-004 | 🔗 Logging dans FormCaisse_Load | 23/05/2024 | OK |
| P2-008 | 📝 Développer ExporterArchiveFiscale() | 02/02/2026 | OK (ModuleNF525) |
| P3-004 | 🔍 Audit SQL (recherche DELETE restants) | 23/05/2024 | Nettoyage Initial OK |


> **Instructions** : Lorsqu'une tâche est terminée et validée, déplacez-la ici.  
> Indiquez la date de fin et les éventuels commentaires.

---

## 🚧 BLOQUÉ / EN ATTENTE

*Aucune tâche bloquée pour le moment*

> **Instructions** : Si une tâche est bloquée, déplacez-la ici avec la raison du blocage.

---

## 📋 LÉGENDE DES ICÔNES

| Icône | Signification |
|-------|--------------|
| 🔧 | Configuration / Infrastructure |
| 📝 | Développement code |
| 🔗 | Intégration |
| 🎨 | Interface utilisateur |
| 🧪 | Tests / QA |
| ✅ | Validation / Vérification |
| 🔍 | Audit / Inspection |
| 📊 | Documentation / Rapport |
| 🔒 | Sécurité / Cryptographie |
| 🔥 | Suppression / Refactoring |
| 🚫 | Désactivation |
| 🔄 | Remplacement |
| 📦 | Livrable |
| 📄 | Document |
| 📧 | Communication |

---

## 📅 PLANNING VISUEL (GANTT SIMPLIFIÉ)

```
Semaine 1 (J1-J7)
━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━
J1 : [████████] P0-001 à P0-006 (Infrastructure)
J2 : [████████] P0-007 à P0-012 (Signature)
J3 : [████████] P0-013 à P0-023 (DELETE + Validation)
J4 : [██████  ] P1-001 à P1-004 (Clôture début)
J5 : [██████  ] P1-005 à P1-008 (Clôture fin)
J6 : [████    ] P1-009 à P1-011 (Grand Total)
J7 : [████    ] P1-012 à P1-013 (Tests tickets)

Semaine 2 (J8-J14)
━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━
J8  : [██████  ] P2-001 à P2-003 (JET)
J9  : [████    ] P2-004 à P2-007 (Tests JET)
J10 : [████    ] P2-004 à P2-007 (Tests JET suite)
J11 : [██████  ] P2-008 à P2-009 (Export XML)
J12 : [████    ] P2-010 à P2-011 (Scellement)
J13 : [████    ] P2-012 (Tests export)
J14 : [██      ] Buffer / Corrections

Semaine 3 (J15-J21)
━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━
J15 : [████████] P3-001 à P3-004 (Tests charge)
J16 : [██████  ] P3-005 à P3-008 (Audit interne)
J17 : [██████  ] P3-005 à P3-008 (Audit suite)
J18 : [████████] P3-009 à P3-011 (Documentation)
J19 : [████    ] P3-012 (Package certification)
J20 : [██      ] Revue finale
J21 : [████    ] P3-013 (Soumission) ✅
```

---

## 📊 SUIVI HEBDOMADAIRE

### Semaine 1 (J1-J7)
- **Objectif** : 23 tâches (P0 complet + P1 début)
- **Tâches prévues** : P0-001 à P1-013
- **Tâches réalisées** : 0 / 23
- **Statut** : 🔴 Non démarré

### Semaine 2 (J8-J14)
- **Objectif** : 12 tâches (P2 complet)
- **Tâches prévues** : P2-001 à P2-012
- **Tâches réalisées** : 0 / 12
- **Statut** : ⏳ En attente

### Semaine 3 (J15-J21)
- **Objectif** : 13 tâches (P3 complet + certification)
- **Tâches prévues** : P3-001 à P3-013
- **Tâches réalisées** : 0 / 13
- **Statut** : ⏳ En attente

---

## 🎯 CRITÈRES DE SUCCÈS

### Critères techniques
- ✅ 100% des transactions signées cryptographiquement
- ✅ Aucun DELETE physique sur données fiscales
- ✅ Clôture Z quotidienne fonctionnelle
- ✅ Grand Total affiché sur tous les tickets
- ✅ Journal des événements techniques opérationnel
- ✅ Export fiscal disponible et testé

### Critères de certification
- ✅ 0 vulnérabilité critique restante
- ✅ Conformité aux 4 piliers ISCA validée
- ✅ Dossier technique complet
- ✅ Tests de charge réussis (10 000 tickets)
- ✅ Audit interne passé à 100%

---

## 📞 CONTACTS PROJET

| Rôle | Nom | Contact | Disponibilité |
|------|-----|---------|--------------|
| **Chef de projet** | [À définir] | - | - |
| **Développeur Lead** | [À définir] | - | - |
| **DBA** | [À définir] | - | - |
| **QA Lead** | [À définir] | - | - |
| **Expert NF525** | Consultant Cybersécurité | [Contact] | Sur demande |
| **Organisme certificateur** | INFOCERT | [Contact] | Rendez-vous J+21 |

---

## 📝 NOTES DE PROJET

### Décisions importantes
- [ ] Choix de l'organisme certificateur (INFOCERT/AFNOR/autre)
- [ ] Validation budget heures développement
- [ ] Planification déploiement PROD
- [ ] Formation équipe magasin

### Risques identifiés
| Risque | Impact | Probabilité | Mitigation |
|--------|--------|-------------|------------|
| Retard sur P0 | 🔴 Critique | Moyen | Buffer J14 prévu |
| Bug Dataset refresh | 🟠 Élevé | Moyen | Tests unitaires systématiques |
| Problème imprimante | 🟡 Moyen | Faible | Tests avec matériel réel J6 |
| Refus certification | 🔴 Critique | Faible | Audit interne rigoureux J15-17 |

---

**Dernière mise à jour** : 02/02/2026 12:50  
**Prochaine revue** : [À planifier]  

**Légende des statuts** :  
- 🔴 Critique / Bloqué  
- 🟠 En retard  
- 🟡 À surveiller  
- 🟢 Dans les temps  
- ✅ Terminé

---

*Ce Kanban doit être mis à jour quotidiennement par le chef de projet.*
