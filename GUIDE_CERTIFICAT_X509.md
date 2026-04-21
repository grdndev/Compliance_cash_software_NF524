# Guide de Génération - Certificat X.509 pour NF525

**Date** : 12 février 2026  
**Objectif** : Créer un certificat X.509 auto-signé pour signer les transactions NF525

---

## Option 1 : PowerShell (Windows - Recommandé)

### Étape 1 : Générer le certificat

```powershell
# Ouvrir PowerShell en Administrateur

# Créer un certificat auto-signé avec clé privée exportable
$cert = New-SelfSignedCertificate `
    -Subject "CN=CHINOOK LEUCATE NF525, O=CHINOOK, C=FR" `
    -FriendlyName "CHINOOK NF525 Signature" `
    -KeyLength 2048 `
    -KeyAlgorithm RSA `
    -KeyUsage DigitalSignature, DataEncipherment `
    -NotBefore (Get-Date) `
    -NotAfter (Get-Date).AddYears(10) `
    -CertStoreLocation "Cert:\CurrentUser\My" `
    -KeyExportPolicy Exportable

# Afficher le certificat créé
$cert | Format-List Subject, Thumbprint, NotBefore, NotAfter
```

### Étape 2 : Exporter en .PFX (avec clé privée)

```powershell
# Définir un mot de passe sécurisé
$password = ConvertTo-SecureString -String "CHINOOK_NF525_2026_Secure!" -Force -AsPlainText

# Exporter le certificat + clé privée
Export-PfxCertificate `
    -Cert $cert `
    -FilePath "C:\Certificates\CHINOOK_NF525.pfx" `
    -Password $password

Write-Host "✅ Certificat exporté : C:\Certificates\CHINOOK_NF525.pfx"
```

### Étape 3 : Exporter la clé publique (.CER - optionnel)

```powershell
# Exporter uniquement la clé publique (pour vérification externe)
Export-Certificate `
    -Cert $cert `
    -FilePath "C:\Certificates\CHINOOK_NF525_Public.cer"

Write-Host "✅ Clé publique exportée : C:\Certificates\CHINOOK_NF525_Public.cer"
```

---

## Option 2 : OpenSSL (Multi-plateforme)

### Prérequis
- Installer OpenSSL : https://slproweb.com/products/Win32OpenSSL.html (Windows)
- Ou utiliser Git Bash qui inclut OpenSSL

### Étape 1 : Générer clé privée RSA

```bash
# Créer le dossier
mkdir -p /c/Certificates

# Générer clé privée 2048 bits
openssl genrsa -out /c/Certificates/CHINOOK_NF525_private.key 2048

# Afficher la clé (optionnel)
cat /c/Certificates/CHINOOK_NF525_private.key
```

### Étape 2 : Créer le certificat auto-signé

```bash
# Créer certificat X.509 valide 10 ans
openssl req -new -x509 -key /c/Certificates/CHINOOK_NF525_private.key \
    -out /c/Certificates/CHINOOK_NF525.cer \
    -days 3650 \
    -subj "/C=FR/O=CHINOOK/CN=CHINOOK LEUCATE NF525"

# Vérifier le certificat
openssl x509 -in /c/Certificates/CHINOOK_NF525.cer -text -noout
```

### Étape 3 : Convertir en .PFX (format Windows)

```bash
# Combiner clé privée + certificat en .pfx
openssl pkcs12 -export \
    -out /c/Certificates/CHINOOK_NF525.pfx \
    -inkey /c/Certificates/CHINOOK_NF525_private.key \
    -in /c/Certificates/CHINOOK_NF525.cer \
    -password pass:CHINOOK_NF525_2026_Secure!

echo "✅ Certificat PFX créé : /c/Certificates/CHINOOK_NF525.pfx"
```

---

## Option 3 : Certificat Commercial (Production)

Pour un environnement de production, il est recommandé d'acheter un certificat auprès d'une autorité de certification reconnue.

### Fournisseurs Recommandés
- **DigiCert** : https://www.digicert.com/
- **GlobalSign** : https://www.globalsign.com/
- **Certinomis** (France) : https://www.certinomis.com/

### Avantages
✅ Reconnu par toutes les OS/navigateurs  
✅ Validité juridique renforcée  
✅ Pas d'alerte "certificat non fiable"  
✅ Support technique professionnel  

### Prix Indicatifs
- Code Signing : 200-400€/an
- EV Code Signing : 400-800€/an

---

## Vérification du Certificat

### Avec PowerShell

```powershell
# Charger le certificat
$pfx = New-Object System.Security.Cryptography.X509Certificates.X509Certificate2
$pfx.Import("C:\Certificates\CHINOOK_NF525.pfx", "CHINOOK_NF525_2026_Secure!", "Exportable")

# Afficher les informations
Write-Host "Subject:" $pfx.Subject
Write-Host "Issuer:" $pfx.Issuer
Write-Host "Valide du:" $pfx.NotBefore "au" $pfx.NotAfter
Write-Host "Thumbprint:" $pfx.Thumbprint
Write-Host "Longueur clé:" $pfx.PublicKey.Key.KeySize "bits"

# Vérifier que la clé privée est présente
if ($pfx.HasPrivateKey) {
    Write-Host "✅ Clé privée présente"
} else {
    Write-Host "❌ Clé privée ABSENTE - Certificat inutilisable pour signature"
}
```

### Avec OpenSSL

```bash
# Vérifier le .pfx
openssl pkcs12 -info -in /c/Certificates/CHINOOK_NF525.pfx \
    -passin pass:CHINOOK_NF525_2026_Secure! -noout

# Vérifier le certificat
openssl x509 -in /c/Certificates/CHINOOK_NF525.cer -text -noout | grep "Subject\|Not Before\|Not After\|Public-Key"
```

---

## Stockage Sécurisé

### ⚠️ IMPORTANT : Sécuriser la Clé Privée

```
❌ NE JAMAIS :
- Commiter le .pfx dans Git
- Partager le mot de passe par email
- Stocker en clair sur un serveur web
- Donner accès à des non-administrateurs

✅ À FAIRE :
- Stocker dans C:\Certificates\ avec permissions restreintes
- Utiliser un coffre-fort de mots de passe (KeePass, 1Password)
- Effectuer des backups chiffrés
- Documenter le mot de passe dans un lieu sûr
```

### Permissions Windows

```powershell
# Créer le dossier avec permissions restreintes
New-Item -Path "C:\Certificates" -ItemType Directory -Force

# Retirer l'héritage et définir les permissions
$acl = Get-Acl "C:\Certificates"
$acl.SetAccessRuleProtection($true, $false)

# Autoriser uniquement Administrators et SYSTEM
$admins = New-Object System.Security.Principal.SecurityIdentifier("S-1-5-32-544")
$system = New-Object System.Security.Principal.SecurityIdentifier("S-1-5-18")

$rule1 = New-Object System.Security.AccessControl.FileSystemAccessRule($admins, "FullControl", "ContainerInherit,ObjectInherit", "None", "Allow")
$rule2 = New-Object System.Security.AccessControl.FileSystemAccessRule($system, "FullControl", "ContainerInherit,ObjectInherit", "None", "Allow")

$acl.AddAccessRule($rule1)
$acl.AddAccessRule($rule2)

Set-Acl "C:\Certificates" $acl

Write-Host "✅ Permissions sécurisées appliquées à C:\Certificates"
```

---

## Checklist Installation

- [ ] Certificat généré (PowerShell ou OpenSSL)
- [ ] Fichier .pfx créé : `C:\Certificates\CHINOOK_NF525.pfx`
- [ ] Mot de passe documenté : `CHINOOK_NF525_2026_Secure!`
- [ ] Clé privée vérifiée (HasPrivateKey = True)
- [ ] Permissions dossier sécurisées
- [ ] Backup du certificat effectué
- [ ] Clé publique (.cer) exportée (optionnel)

---

## Utilisation dans le Code VB.NET

Voir fichier : `SignatureHelperPKI.vb`

```vb
' Charger le certificat
Dim cert As New X509Certificate2("C:\Certificates\CHINOOK_NF525.pfx", "CHINOOK_NF525_2026_Secure!")

' Vérifier
If cert.HasPrivateKey Then
    MessageBox.Show("✅ Certificat chargé avec succès")
Else
    MessageBox.Show("❌ Erreur : pas de clé privée")
End If
```

---

**Guide créé le** : 12 février 2026  
**Temps estimé** : 15 minutes
