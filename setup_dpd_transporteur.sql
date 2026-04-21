-- ==============================================================================
-- CHINOOK LEUCATE CLI — Setup transporteur DPD
-- À exécuter UNE FOIS sur la base CLI / CHINOOKSUR
-- ==============================================================================

-- 1. Ajouter DPD dans la table T_Transporteur
--    (vérifie avant d'insérer pour éviter les doublons)

IF NOT EXISTS (SELECT 1 FROM T_Transporteur WHERE libelle = 'DPD')
BEGIN
    INSERT INTO T_Transporteur (libelle)
    VALUES ('DPD');
    PRINT 'Transporteur DPD ajouté.';
END
ELSE
BEGIN
    PRINT 'Transporteur DPD existe déjà.';
END

-- 2. Vérifier l''ID attribué à DPD (à reporter dans My.Settings DPDTransporteurId)
SELECT id_t_transporteur, libelle
FROM T_Transporteur
ORDER BY id_t_transporteur;

-- ==============================================================================
-- APRÈS EXÉCUTION :
--   1. Notez l'ID de DPD (colonne id_t_transporteur)
--   2. Configurez ce même ID dans CLI :
--        Administration → Paramètres → DPDTransporteurId = [ID de DPD]
--      ou directement dans My.Settings.DPDStationNetFolder / DPDTransporteurId
--
-- DOSSIER Station.NET :
--   Par défaut : C:\DPD\Import\
--   Créer ce dossier et le configurer dans Station.NET comme dossier de surveillance.
-- ==============================================================================
