# 🔒 CHINOOK-LEUCATE - Logiciel de Caisse Certifié NF525

![NF525](https://img.shields.io/badge/NF525-En%20cours-yellow)
![Conformité](https://img.shields.io/badge/Conformité-32%25-orange)
![Version](https://img.shields.io/badge/Version-4.0-blue)
![Status](https://img.shields.io/badge/Status-Production-green)

---

## 📋 À PROPOS

**CLI (Chinook-Leucate Interface)** est un logiciel de point de vente développé pour CHINOOK SURF SHOP (Leucate, France).

Suite à la fin de l'auto-attestation en 2025, le logiciel est actuellement en cours de mise en conformité avec la **norme NF525** (référentiel INFOCERT/AFNOR).

---

## 🎯 CERTIFICATION NF525

### Progression globale : **32%** ✅

| Pilier ISCA | Conformité | Status |
|------------|------------|--------|
| **Inaltérabilité** | 70% | 🟡 En cours |
| **Sécurisation** | 60% | 🟡 En cours |
| **Conservation** | 40% | 🟡 En cours |
| **Archivage** | 80% | 🟢 Avancé |

---

## ⚡ DÉMARRAGE RAPIDE

### **Nouveau développeur ?**

#### 1. Lire la documentation

```bash
cd "/Users/jayance/Desktop/NF525 CHINOOK/CLI4.0"
open INDEX.md  # Index de toute la documentation
open RAPPORT_AVANCEMENT.md  # ⭐ Commencer ici
```

#### 2. Exécuter le script SQL

```bash
# Voir le guide détaillé
open GUIDE_EXECUTION_SQL.md
```

#### 3. Compiler le projet

```bash
# Ouvrir Visual Studio 2022
open CLI.sln
# Rebuild Solution (Cmd+Shift+B)
```

---

## 📊 ÉTAT DU PROJET

### **✅ Tâches terminées : 12/37**

- ✅ Module de signature cryptographique (HMAC-SHA256)
- ✅ Intégration signature dans flux de vente
- ✅ Suppression des DELETE physiques
- ✅ Désactivation suppression UI
- ✅ Journal des événements techniques (JET)
- ✅ Fonction de clôture journalière
- ✅ Vérification d'intégrité cryptographique
- ✅ Export fiscal XML

### **⏳ Tâches en cours : 1/37**

- ⏳ P0-001 : Exécution script SQL (bloquant)

### **🔴 Vulnérabilités critiques : 3/9 restantes**

- 🔴 Colonnes Signature absentes de la BDD (P0-001)
- 🔴 Aucune clôture Z dans l'interface (P1-006)
- 🔴 Grand Total non affiché sur tickets (P1-009)

---

## 🏗️ ARCHITECTURE

### **Stack technique**

- **Langage** : Visual Basic .NET
- **Framework** : .NET Framework 4.5+
- **Base de données** : SQL Server (Azure)
- **ORM** : ADO.NET (TableAdapters)
- **Cryptographie** : HMAC-SHA256 (conforme NF525)

### **Structure du projet**

```
CLI4.0/
├── CLI/                          # Application principale
│   ├── NF525/                    # Module certification
│   │   └── SignatureHelper.vb    # Signature crypto ✅
│   ├── ModuleNF525.vb            # Fonctions métier NF525 ✅
│   ├── FormCaisse.vb             # Interface caisse ✅
│   └── CLIDataSet.xsd            # Dataset SQL Server
│
├── CLIMinimalApi/                # API REST
├── CLISyncService/               # Service de synchronisation
├── CLIPrestashopConnector/       # Connecteur e-commerce
│
└── Dll/                          # Dépendances externes
```

---

## 🔐 SÉCURITÉ NF525

### **Signature cryptographique**

Chaque transaction est scellée avec un hash HMAC-SHA256 :

```vb
' Exemple : Ticket #1235
Data: "1235202602011430045.90AB12CD34..."
Signature: "CD56EF78..." (Base64)
PreviousSignature: "AB12CD34..." (chaînage)
```

### **Chaînage des transactions**

```
Ticket N-1  →  Ticket N  →  Ticket N+1
   Sig: AB      Sig: CD      Sig: EF
                ↑PrevSig: AB  ↑PrevSig: CD
```

### **Inaltérabilité**

- ❌ Aucun DELETE physique autorisé
- ❌ Aucune modification de ticket validé
- ✅ Annulation logique uniquement (flag `Annule=1`)

---

## 📖 DOCUMENTATION

| Document | Description |
|----------|-------------|
| [INDEX.md](INDEX.md) | 📚 Index de toute la documentation |
| [RAPPORT_AVANCEMENT.md](RAPPORT_AVANCEMENT.md) | ⭐ Rapport d'avancement (32%) |
| [KANBAN_NF525.md](KANBAN_NF525.md) | 📊 Suivi de projet (37 tâches) |
| [AUDIT_NF525_RAPPORT_TECHNIQUE.md](AUDIT_NF525_RAPPORT_TECHNIQUE.md) | 🔍 Audit technique complet |
| [GUIDE_EXECUTION_SQL.md](GUIDE_EXECUTION_SQL.md) | ⚙️ Guide script SQL |

---

## 🧪 TESTS

### **Tests unitaires signature**

```sql
-- Vérifier intégrité du chaînage
WITH Chaine AS (
    SELECT 
        ID_T_CommandeVente,
        Signature,
        PreviousSignature,
        LAG(Signature) OVER (ORDER BY ID_T_CommandeVente) AS SignaturePrecedente
    FROM T_CommandeVente
    WHERE TicketLe IS NOT NULL
)
SELECT * FROM Chaine
WHERE PreviousSignature <> ISNULL(SignaturePrecedente, 'INITIAL_CHAIN_START');
-- Résultat attendu : 0 lignes (aucune rupture)
```

### **Tests conformité**

```bash
# Rechercher DELETE restants (doit retourner 0)
grep -ri "delete from" CLI/*.vb | grep -v ".Designer.vb" | wc -l

# Vérifier signatures activées
grep -A2 "ticketRow.Signature =" CLI/NF525/SignatureHelper.vb
```

---

## 🚀 ROADMAP

### **Semaine 1 (J1-J7) - Infrastructure**
- [x] P0-007 : Activer module signature
- [x] P0-010 : Intégrer signature dans Enregistrer()
- [x] P0-014-015 : Supprimer DELETE physiques
- [ ] P0-001 : Exécuter script SQL ⚠️ URGENT
- [ ] P0-004 : Rafraîchir Dataset Visual Studio

### **Semaine 2 (J8-J14) - Clôtures**
- [ ] P1-005 : Imprimer Ticket Z
- [ ] P1-006 : Bouton "Clôture Z" dans l'interface
- [ ] P1-009-011 : Afficher Grand Total sur tickets

### **Semaine 3 (J15-J21) - Certification**
- [ ] P3-001-004 : Tests de charge (10 000 tickets)
- [ ] P3-005-008 : Audit interne
- [ ] P3-013 : Soumission organisme certificateur

---

## 👥 ÉQUIPE

| Rôle | Nom | Responsabilité |
|------|-----|----------------|
| **Chef de projet** | [À définir] | Coordination |
| **Développeur Lead** | [À définir] | Développement VB.NET |
| **DBA** | [À définir] | Base de données SQL Server |
| **Expert NF525** | Antigravity | Conformité & Audit |

---

## 📞 CONTACT

**CHINOOK SURF SHOP**  
📍 Leucate, France  
🌐 www.chinook-leucate.com

**Support technique** :  
📧 admin@chinook-leucate.com  
🔐 Accès serveur : Voir avec Cyril

---

## 📜 LICENCE

**Propriétaire** : CHINOOK SURF SHOP  
**Confidentiel** : Ce code est propriétaire et confidentiel.

---

## 🏆 STATUT DE CERTIFICATION

**Organisme certificateur** : INFOCERT (ou AFNOR)  
**Date de soumission prévue** : 23/02/2026  
**Conformité actuelle** : 32%  
**Statut** : 🟡 En cours de mise en conformité

---

**Dernière mise à jour** : 02/02/2026  
**Version README** : 1.0
