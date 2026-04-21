# 📦 GUIDE DE DÉPLOIEMENT CLIENT - SÉCURITÉ NF525

Ce guide explique comment installer les composants de sécurité NF525 sur le poste de caisse du client ("Production").

## 1. Prérequis
- Le logiciel CLI 4.0 installé.
- Le fichier du certificat numérique : **`CHINOOK_NF525.pfx`** (fourni séparément).
- Le fichier de clé (mot de passe) : **`CHINOOK_NF525.key`** (fourni ci-dessous).

---

## 2. Structure des Dossiers

Le logiciel est programmé pour chercher le certificat dans cet ordre :

### Option A (Recommandée - Installation Système)
Dossier fixe sur le disque C:
*   📁 `C:\Certificates\`
    *   📄 `CHINOOK_NF525.pfx`
    *   📄 `CHINOOK_NF525.key`

### Option B (Portable - Dossier de l'application)
Dans le sous-dossier de l'application (à côté de `CLI.exe`) :
*   📁 `[DossierInstallation]\Certificates\`
    *   📄 `CHINOOK_NF525.pfx`
    *   📄 `CHINOOK_NF525.key`

---

## 3. Installation Automatisée (Script)

Un script **`SETUP_SECURITE_NF525.bat`** a été créé pour vous.
Il effectue les actions suivantes :
1.  Crée le dossier `C:\Certificates`.
2.  Y place le fichier `.key` avec le mot de passe.
3.  **Sécurise le dossier** (Lecture seule pour l'utilisateur, Full Control pour Admin).

### Procédure pour le technicien :
1.  Copier `SETUP_SECURITE_NF525.bat` sur le poste client.
2.  Lancer le script en **Administrateur** (Clic droit > Exécuter en tant qu'admin).
3.  Copier manuellement le fichier `CHINOOK_NF525.pfx` dans `C:\Certificates`.

---

## 4. Vérification
Au lancement de `CLI.exe`, le logiciel va :
1.  Lire `C:\Certificates\CHINOOK_NF525.pfx`.
2.  Lire `C:\Certificates\CHINOOK_NF525.key` pour obtenir le mot de passe.
3.  Activer la signature électronique Factur-X / NF525.

Si le certificat est absent ou le mot de passe incorrect, le logiciel affichera une alerte de sécurité.
