-- ==============================================================================
-- CHINOOK LEUCATE CLI — Setup transporteur DPD + TParams CLISyncService
-- À exécuter UNE FOIS sur la base CLI / CHINOOKSUR
--
-- Ce script :
--   1. Ajoute DPD dans T_Transporteur (si absent)
--   2. Récupère l'ID DPD attribué et l'enregistre dans T_Params
--      sous le paramètre IdTTransporteurDPD (utilisé par CLISyncService)
--   3. Initialise les paramètres FTP/Synology pour l'export DPD
--
-- ARCHITECTURE (alignée sur le pattern Colissimo) :
--   - CLI : le vendeur choisit "DPD" dans l'onglet transporteur, puis Expédier.
--           La commande est enregistrée avec IdTTransporteur = ID DPD.
--   - CLISyncService (sur le serveur PrestaShop) : poll la base toutes les
--           CliTransfertDPDDelay ms, génère le fichier V110 (format CargoNET
--           Station.NET v5.7c) et le dépose sur le partage Synology dans
--           soDevelopement / soStaging / soProduction.
-- ==============================================================================

SET NOCOUNT ON;

-- ── 1. Ajouter DPD dans T_Transporteur ─────────────────────────────────────────
IF NOT EXISTS (SELECT 1 FROM T_Transporteur WHERE libelle = 'DPD')
BEGIN
    INSERT INTO T_Transporteur (libelle) VALUES ('DPD');
    PRINT 'Transporteur DPD ajouté.';
END
ELSE
BEGIN
    PRINT 'Transporteur DPD existe déjà.';
END

-- ── 2. Récupérer l'ID DPD et le stocker dans T_Params ──────────────────────────
DECLARE @IdDPD INT;
SELECT @IdDPD = id_t_transporteur FROM T_Transporteur WHERE libelle = 'DPD';

IF NOT EXISTS (SELECT 1 FROM T_Params WHERE Paramname = 'IdTTransporteurDPD')
    INSERT INTO T_Params (Paramname, Paramvalue) VALUES ('IdTTransporteurDPD', CAST(@IdDPD AS VARCHAR(10)));
ELSE
    UPDATE T_Params SET Paramvalue = CAST(@IdDPD AS VARCHAR(10)) WHERE Paramname = 'IdTTransporteurDPD';

PRINT 'Param IdTTransporteurDPD = ' + CAST(@IdDPD AS VARCHAR(10));

-- ── 3. Paramètres CLISyncService (TransfertDPD) ────────────────────────────────
-- Délai entre deux scans (ms) — par défaut 60 secondes
IF NOT EXISTS (SELECT 1 FROM T_Params WHERE Paramname = 'CliTransfertDPDDelay')
    INSERT INTO T_Params (Paramname, Paramvalue) VALUES ('CliTransfertDPDDelay', '60000');

-- Date de dernière extraction (initialisée à 1900 pour traiter l'historique
-- au premier passage — à ajuster manuellement si vous voulez démarrer "now")
IF NOT EXISTS (SELECT 1 FROM T_Params WHERE Paramname = 'CliDateDerniereExtractionDPD')
    INSERT INTO T_Params (Paramname, Paramvalue) VALUES ('CliDateDerniereExtractionDPD', '1900-01-01 00:00:00');

-- Cible FTP/SFTP : Synology par environnement
--   DEV     → /soDevelopement/DPD/
--   STAGING → /soStaging/DPD/
--   PROD    → /soProduction/DPD/
-- À configurer avec les vraies credentials par Cyril/Christophe
IF NOT EXISTS (SELECT 1 FROM T_Params WHERE Paramname = 'FTP_Host_DPD')
    INSERT INTO T_Params (Paramname, Paramvalue) VALUES ('FTP_Host_DPD', '');
IF NOT EXISTS (SELECT 1 FROM T_Params WHERE Paramname = 'FTP_UID_DPD')
    INSERT INTO T_Params (Paramname, Paramvalue) VALUES ('FTP_UID_DPD', '');
IF NOT EXISTS (SELECT 1 FROM T_Params WHERE Paramname = 'FTP_PWD_DPD')
    INSERT INTO T_Params (Paramname, Paramvalue) VALUES ('FTP_PWD_DPD', '');
IF NOT EXISTS (SELECT 1 FROM T_Params WHERE Paramname = 'FTP_remote_path_DPD')
    INSERT INTO T_Params (Paramname, Paramvalue) VALUES ('FTP_remote_path_DPD', '/soDevelopement/DPD/');
IF NOT EXISTS (SELECT 1 FROM T_Params WHERE Paramname = 'FTP_file_name_DPD')
    INSERT INTO T_Params (Paramname, Paramvalue) VALUES ('FTP_file_name_DPD', 'DPD');

PRINT 'Paramètres CLISyncService DPD initialisés.';

-- ── 4. Vérification ────────────────────────────────────────────────────────────
SELECT id_t_transporteur, libelle FROM T_Transporteur ORDER BY id_t_transporteur;
SELECT Paramname, Paramvalue FROM T_Params
 WHERE Paramname LIKE '%DPD%' ORDER BY Paramname;

-- ==============================================================================
-- APRÈS EXÉCUTION :
--   1. Renseigner FTP_Host_DPD / FTP_UID_DPD / FTP_PWD_DPD avec les credentials
--      du Synology pour l'environnement cible.
--   2. Ajuster FTP_remote_path_DPD selon l'environnement :
--        DEV     → /soDevelopement/DPD/
--        STAGING → /soStaging/DPD/
--        PROD    → /soProduction/DPD/
--   3. Redémarrer CLISyncService côté serveur pour qu'il prenne en compte
--      le nouveau hosted service TransfertDPD.
--   4. Test : créer une commande WEB/VPC dans CLI avec transporteur DPD,
--      cliquer Expédier, attendre <CliTransfertDPDDelay> ms, vérifier que
--      le fichier .dat apparaît dans le dossier Synology.
-- ==============================================================================
