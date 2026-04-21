# 🔧 GUIDE D'EXÉCUTION SQL - NF525
## Mise à jour du schéma de base de données

**⚠️ CETTE ÉTAPE EST OBLIGATOIRE AVANT DE COMPILER LE CODE ⚠️**

---

## 📋 PRÉREQUIS

- [ ] Accès SSH au serveur www.chinook-leucate.com (port 49152)
- [ ] SQL Server Management Studio (SSMS) OU Azure Data Studio
- [ ] Droits d'administration sur la base de données `CLI`
- [ ] Sauvegarde de la base effectuée (recommandé)

---

## 🎯 OBJECTIF

Ajouter les colonnes et tables nécessaires pour la certification NF525 :
- Colonnes `Signature` et `PreviousSignature` (3 tables)
- Table `T_Cloture` (clôtures Z)
- Table `T_JournalEvenements` (JET)

---

## 📍 MÉTHODE 1 : Depuis votre poste (Recommandé)

### **Étape 1 : Se connecter au serveur SQL**

Le serveur SQL est hébergé sur **www.chinook-leucate.com**.

**Option A : Via SQL Server Management Studio (SSMS)**

1. Ouvrir SSMS
2. Cliquer sur **Connect** → **Database Engine**
3. Renseigner :
   - **Server name** : `www.chinook-leucate.com,1433`
   - **Authentication** : SQL Server Authentication
   - **Login** : `sa` (ou votre login admin)
   - **Password** : [Demander à Cyril]
4. Cliquer sur **Connect**

**Option B : Via Azure Data Studio**

1. Ouvrir Azure Data Studio
2. Cliquer sur **New Connection**
3. Renseigner :
   - **Server** : `www.chinook-leucate.com,1433`
   - **Authentication type** : SQL Login
   - **User name** : `sa`
   - **Password** : [Demander à Cyril]
   - **Database** : `CLI`
4. Cliquer sur **Connect**

---

### **Étape 2 : Exécuter le script**

1. **Sélectionner la base de données** :
   ```sql
   USE CLI;
   GO
   ```

2. **Copier-coller le contenu du fichier** :
   - Ouvrir `/Users/jayance/Desktop/NF525 CHINOOK/CLI4.0/database_update_nf525.sql`
   - Sélectionner TOUT le contenu (Cmd+A)
   - Copier (Cmd+C)
   - Coller dans SSMS/Azure Data Studio (Cmd+V)

3. **Exécuter** :
   - SSMS: Cliquer sur **Execute** (F5)
   - Azure Data Studio: Cliquer sur **Run** (F5)

4. **Vérifier les messages** :
   ```
   Added Signature columns to T_CommandeVente
   Added Signature columns to T_CommandeVente_Ligne
   Added Signature columns to T_Reglement
   Created table T_Cloture
   Created table T_JournalEvenements
   Database schema update completed successfully.
   ```

✅ Si vous voyez ces messages → **SUCCÈS !**

---

### **Étape 3 : Vérifier les modifications**

Exécuter cette requête pour confirmer :

```sql
-- Vérifier les colonnes Signature
SELECT 
    TABLE_NAME, 
    COLUMN_NAME 
FROM INFORMATION_SCHEMA.COLUMNS 
WHERE COLUMN_NAME IN ('Signature', 'PreviousSignature')
ORDER BY TABLE_NAME, COLUMN_NAME;

-- Résultat attendu :
-- T_CommandeVente         | PreviousSignature
-- T_CommandeVente         | Signature
-- T_CommandeVente_Ligne   | PreviousSignature
-- T_CommandeVente_Ligne   | Signature
-- T_Reglement             | PreviousSignature
-- T_Reglement             | Signature

-- Vérifier les nouvelles tables
SELECT name FROM sys.tables 
WHERE name IN ('T_Cloture', 'T_JournalEvenements');

-- Résultat attendu :
-- T_Cloture
-- T_JournalEvenements
```

---

## 📍 MÉTHODE 2 : Via SSH (Alternative)

### **Étape 1 : Se connecter au serveur**

```bash
ssh -p 49152 -i ~/.ssh/chinook_private_key ssssirhc@www.chinook-leucate.com
# Phrase secrète : v1bnhgcn
```

---

### **Étape 2 : Copier le script sur le serveur**

**Option A : Via SCP**

Depuis votre Mac :
```bash
scp -P 49152 -i ~/.ssh/chinook_private_key \
    "/Users/jayance/Desktop/NF525 CHINOOK/CLI4.0/database_update_nf525.sql" \
    ssssirhc@www.chinook-leucate.com:~/nf525_update.sql
```

**Option B : Via SFTP**

1. Utiliser FileZilla ou Cyberduck
2. Se connecter à `www.chinook-leucate.com` port `49152`
3. Uploader `database_update_nf525.sql`

---

### **Étape 3 : Exécuter le script**

Une fois connecté en SSH :

```bash
# Installer sqlcmd si nécessaire (normalement déjà présent)
# sudo apt-get install mssql-tools

# Exécuter le script
/opt/mssql-tools/bin/sqlcmd -S localhost -U sa -P [PASSWORD] -d CLI -i ~/nf525_update.sql

# OU si la base est sur un autre serveur
/opt/mssql-tools/bin/sqlcmd -S www.chinook-leucate.com -U sa -P [PASSWORD] -d CLI -i ~/nf525_update.sql
```

---

## ⚠️ EN CAS D'ERREUR

### **Erreur : "Column 'Signature' already exists"**

✅ **C'EST NORMAL !** Cela signifie que les colonnes existent déjà.

Le script est **idempotent** (peut être exécuté plusieurs fois sans danger) :
```sql
IF NOT EXISTS (SELECT * FROM sys.columns WHERE ...)
BEGIN
    ALTER TABLE ...
END
```

Continuez normalement.

---

### **Erreur : "Cannot connect to server"**

**Causes possibles** :
1. Firewall bloque le port 1433
2. SQL Server n'accepte pas les connexions externes
3. Mauvais login/password

**Solution** :
- Vérifier que SQL Server autorise les connexions TCP/IP
- Contacter Cyril pour les credentials
- Utiliser la **Méthode 2 (SSH)** si connexion directe impossible

---

### **Erreur : "Permission denied"**

Vous n'avez pas les droits `ALTER TABLE` et `CREATE TABLE`.

**Solution** :
- Demander à l'administrateur d'exécuter le script
- OU demander les droits `db_ddladmin`

---

## ✅ APRÈS EXÉCUTION RÉUSSIE

### **1. Ajouter les colonnes d'annulation à T_Avoir**

Le script principal ne touche pas à `T_Avoir`. Il faut ajouter manuellement :

```sql
USE CLI;
GO

-- Ajouter colonnes d'annulation logique
IF NOT EXISTS (SELECT * FROM sys.columns WHERE object_id = OBJECT_ID(N'[dbo].[T_Avoir]') AND name = 'Annule')
BEGIN
    ALTER TABLE [dbo].[T_Avoir] ADD [Annule] BIT DEFAULT 0 NOT NULL;
    ALTER TABLE [dbo].[T_Avoir] ADD [AnnuleLe] DATETIME NULL;
    ALTER TABLE [dbo].[T_Avoir] ADD [AnnulePar] VARCHAR(50) NULL;
    PRINT 'Added Annule columns to T_Avoir';
END
GO
```

---

### **2. Rafraîchir le Dataset Visual Studio**

⚠️ **CRUCIAL** : Sans cette étape, le code VB ne verra pas les nouvelles colonnes !

1. Ouvrir **Visual Studio 2022**
2. Ouvrir le projet `CLI.sln`
3. Dans l'**Explorateur de solutions**, double-cliquer sur `CLIDataSet.xsd`
4. Pour chaque table modifiée :
   
   **Pour T_CommandeVente** :
   - Clic droit sur `T_CommandeVente` (dans le designer XSD)
   - Cliquer sur **Configure** → **Next** → **Next**
   - Cocher **Refresh columns** → **Finish**
   
   **Pour T_CommandeVente_Ligne** :
   - Clic droit sur `T_CommandeVente_Ligne`
   - Cliquer sur **Configure** → **Next** → **Next**
   - Cocher **Refresh columns** → **Finish**
   
   **Pour T_Reglement** :
   - Clic droit sur `T_Reglement`
   - Cliquer sur **Configure** → **Next** → **Next**
   - Cocher **Refresh columns** → **Finish**

5. **Ajouter les nouvelles tables** :
   - Clic droit sur le fond du designer XSD
   - Cliquer sur **Add** → **TableAdapter**
   - Suivre l'assistant pour ajouter `T_Cloture` et `T_JournalEvenements`

6. **Sauvegarder** (Cmd+S)

7. **Reconstruire le projet** :
   - Menu **Build** → **Rebuild Solution**
   - Vérifier qu'il n'y a **AUCUNE ERREUR**

---

### **3. Tester le code**

Lancer l'application en **mode Debug** :

```vb
' Au démarrage de FormCaisse, vérifier dans la fenêtre Output :
' "Ouverture du module de caisse" devrait apparaître

' Créer un ticket de test et vérifier en SQL :
SELECT TOP 1 
    ID_T_CommandeVente, 
    LEFT(Signature, 20) AS Signature,
    LEFT(PreviousSignature, 20) AS PrevSig
FROM T_CommandeVente 
WHERE TicketLe IS NOT NULL 
ORDER BY ID_T_CommandeVente DESC;
```

Si vous voyez des signatures → ✅ **SUCCÈS TOTAL !**

---

## 📊 CHECKLIST FINALE

Avant de passer à la suite, vérifier :

- [  ] Script SQL exécuté avec succès
- [ ] 6 colonnes `Signature` / `PreviousSignature` créées
- [ ] 2 tables `T_Cloture` et `T_JournalEvenements` créées
- [ ] 3 colonnes `Annule`, `AnnuleLe`, `AnnulePar` ajoutées à `T_Avoir`
- [ ] Dataset Visual Studio rafraîchi (3 tables)
- [ ] Nouvelles tables ajoutées au Dataset (2 tables)
- [ ] Projet recompilé sans erreur
- [ ] Test de signature sur un ticket réussi

---

## 🆘 BESOIN D'AIDE ?

**Contact technique** :
- Cyril (accès serveur, credentials SQL)
- Admin réseau (firewall, VPN)

**Documentation** :
- `/Users/jayance/Desktop/NF525 CHINOOK/CLI4.0/AUDIT_NF525_RAPPORT_TECHNIQUE.md`
- `/Users/jayance/Desktop/NF525 CHINOOK/CLI4.0/PROGRES_KANBAN.md`

---

**Date de création** : 02/02/2026  
**Version** : 1.0  
**Tâche Kanban** : P0-001
