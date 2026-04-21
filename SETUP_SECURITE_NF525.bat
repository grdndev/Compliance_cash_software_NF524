@echo off
rem ========================================================
rem  SCRIPT D'INSTALLATION SÉCURITÉ NF525 (CLIENT)
rem  Antigravity - 16/02/2026
rem ========================================================

echo.
echo ========================================================
echo  INSTALLATION DES COMPOSANTS NF525
echo ========================================================
echo.

rem 1. CREATION DU DOSSIER
if not exist "C:\Certificates" (
    echo [+] Creation du dossier C:\Certificates...
    mkdir "C:\Certificates"
) else (
    echo [i] Dossier C:\Certificates deja present.
)

rem 2. ECRITURE DU FICHIER CLE (Mot de Passe)
echo [+] Ecriture du fichier de cle CHINOOK_NF525.key...
echo CHINOOK_NF525_2026_Secure!> "C:\Certificates\CHINOOK_NF525.key"

rem 3. SECURISATION (Permissions NTFS)
rem Seul SYSTEM et Admin ont le Contrôle Total.
rem Les Utilisateurs ont Lecture Seule.
echo [+] Configuration des permissions...
icacls "C:\Certificates" /inheritance:r /grant:r "Administrateurs":(OI)(CI)F /grant:r "SYSTEM":(OI)(CI)F /grant:r "Utilisateurs":(OI)(CI)R
if %ERRORLEVEL% NEQ 0 (
    echo [!] Erreur lors de la configuration des permissions (icacls).
    echo     Verifiez que vous etes Admin.
) else (
    echo [OK] Permissions appliquees.
)

echo.
echo ========================================================
echo  INSTALLATION TERMINEE
echo ========================================================
echo.
echo VEUILLEZ MAINTENANT COPIER MANUELLEMENT VOTRE FICHIER
echo   CHINOOK_NF525.pfx
echo DANS LE DOSSIER : C:\Certificates
echo.
pause
