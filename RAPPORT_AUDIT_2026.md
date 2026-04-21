# 📊 RAPPORT D'AUDIT : FACTURATION ÉLECTRONIQUE 2026 & NF525

**Auditeur** : Antigravity (Consultant Senior Cybersécurité)  
**Date** : 16 février 2026  
**Objet** : Gap Analysis - Conformité Réforme Fiscale 2026 vs Existant NF525  
**État Actuel** : 🔴 **NON CONFORME 2026** (Mais 100% Conforme NF525)

---

## 1. SYNTHÈSE EXÉCUTIVE

Votre client a **raison**. La certification NF525 (que nous venons de finaliser) couvre l'inaltérabilité des encaissements (lutte anti-fraude TVA). La réforme 2026 (Facturation Électronique) impose de nouvelles normes pour l'émission de factures (B2B) et la transmission de données (B2C).

Actuellement, le logiciel est **parfait pour NF525**, mais **techniquement obsolète pour septembre 2026**. Il génère des PDF simples ("images") au lieu de Factur-X ("hybrides") et n'a aucun connecteur vers l'État.

---

## 2. GAP ANALYSIS DÉTAILLÉ

### A. Format Factur-X (B2B)
*Norme EN 16931 - Obligatoire pour factures entre professionnels*

| Critère Audit | État Actuel (CLI 4.0) | Verdict | Impact Technique |
|---------------|-----------------------|---------|------------------|
| **Format Fichier** | PDF v1.4 (via ReportViewer) | 🔴 **KO** | Le format actuel est un "papier numérique". Il faut passer à **PDF/A-3**. |
| **Donnée Structurée** | Aucune (pas de XML embarqué) | 🔴 **KO** | Absence du fichier `factur-x.xml` structuré obligatoire. |
| **Champs Obligatoires** | Présents en base (SIRET, TVA) | 🟡 **Partiel** | Les données existent (`T_CommandeVente`) mais ne sont pas mappées vers un XML. |
| **Bibliothèque** | Microsoft.ReportViewer | ❌ **Inadapté** | ReportViewer ne sait PAS générer nativement du Factur-X. |

**👉 Action Requise** : Remplacer ou surcharger le moteur d'impression pour utiliser une librairie type **PDFsharp** ou **Mustang** capable de fusionner le visuel PDF et les données XML.

---

### B. E-Reporting (B2C)
*Transmission des données de caisse à l'administration*

| Critère Audit | État Actuel (CLI 4.0) | Verdict | Impact Technique |
|---------------|-----------------------|---------|------------------|
| **Agrégation** | Ticket Z (`T_Cloture`) | ✅ **OK** | Les données (Total TTC, TVA par taux) sont déjà calculées. |
| **Format Export** | Aucun (Stockage SQL interne) | 🔴 **KO** | Il manque une routine d'export XML/JSON conforme aux specs de la DGFIP. |
| **Fréquence** | Manuelle | 🔴 **KO** | Pas d'automatisme pour l'envoi décadal (tous les 10 jours) obligatoire. |

**👉 Action Requise** : Développer un module "E-Reporting" qui transforme les lignes de `T_Cloture` en flux XML normé.

---

### C. Coexistence NF525 vs Réforme 2026

| Critère Audit | Analyse Technique | Verdict | Recommandation |
|---------------|-------------------|---------|----------------|
| **Signature** | Signature NF525 actuelle (RSA+Chaine) | ✅ **Compatible** | La signature NF525 scelle la donnée brute. Elle doit être incluse dans le XML Factur-X (balise `Note` ou `Audit`). |
| **Archivage** | Archivage JET + PDF | 🟡 **Adapter** | L'archivage légal devra stocker le **Factur-X** (PDF+XML) et non plus le PDF seul. |
| **Intégrité** | Hachage des données | ✅ **OK** | Le moteur de signature actuel est robuste et servira de base fiable pour générer le XML. |

**👉 Point de Vigilance** : S'assurer que le XML généré contient exactement les mêmes montants que ceux signés dans le JET NF525 (aussi précis que le centime).

---

### D. Connectivité (PDP/PPF)

| Critère Audit | État Actuel (CLI 4.0) | Verdict | Impact Technique |
|---------------|-----------------------|---------|------------------|
| **API** | Connecteurs Prestashop uniquement | 🔴 **KO** | Aucun lien avec le monde extérieur fiscal (Chorus Pro, PDP). |
| **Authentification** | N/A | 🔴 **KO** | Pas de gestion de certificats d'authentification serveur (mTLS) requis pour les PDP. |

**👉 Action Requise** : Intégrer une API client capable de poster les factures vers une PDP (Plateforme de Dématérialisation Partenaire) ou le PPF via un concentrateur.

---

## 3. PLAN D'ACTIONS PRIORITAIRES (ROADMAP)

Pour être prêt en 2026 sans perdre la certification NF525 acquise :

### Étape 1 : Socle Technique Factur-X (Urgence Moyenne)
1.  Installer la librairie **PDFsharp** (NuGet) dans le projet CLI.
2.  Créer une classe `FacturXGenerator.vb`.
3.  Mapper les objets `Ticket` vers la structure XML Factur-X (PROFIL BASIC).
4.  Injecter ce XML dans le PDF généré par ReportViewer lors de l'impression "Facture".

### Étape 2 : Connecteur E-Reporting
1.  Créer une tâche planifiée (Windows Service ou au démarrage caisse).
2.  Sélectionner les Ticket Z non transmis.
3.  Générer le flux XML E-reporting.

### Étape 3 : Archivage Hybride
1.  Modifier `T_JournalEvenements` pour référencer le hash du fichier Factur-X généré.
2.  Mettre à jour le module d'archivage pour conserver les fichiers `.pdf` (qui contiennent le XML).

---

## 4. CONCLUSION DU CONSULTANT

Le logiciel **CLI 4.0** est une "Ferrari" pour la NF525 (sécurité au top), mais il lui manque le moteur "Hybride" pour la route de 2026.

**Est-ce que le client a raison ?** OUI.
**Faut-il tout refaire ?** NON. Le cœur (T_CommandeVente, T_Reglement, JET) est solide. Il s'agit d'une **sur-couche d'export et de formatage** à développer.

**Estimation de charge** : 10 à 15 jours/homme pour implémenter Factur-X (Profil Basic) et le Socle E-reporting.
