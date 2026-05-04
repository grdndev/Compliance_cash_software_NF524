-- ==============================================================================
-- CLI 4.0 — Tests d'intrusion NF525 (script rejouable)
--
-- Réf. : RAPPORT_TESTS_INTRUSION_NF525.md
-- Phase devis : 5 — Durcissement, Tests de Certification & Documentation
--
-- À exécuter sur la base DEV uniquement.
-- L'objectif est de valider que les triggers et mécanismes NF525 bloquent
-- effectivement les 6 attaques typiques sur un logiciel de caisse certifié.
--
-- Critère : tous les tests doivent retourner "PASS".
-- ==============================================================================

SET NOCOUNT ON;
PRINT '======================================================================';
PRINT 'CLI 4.0 — Tests d''intrusion NF525';
PRINT '======================================================================';
PRINT '';

-- ────────────────────────────────────────────────────────────────────────────
-- TEST 2 — UPDATE direct sur T_JournalEvenements (le test 1 se fait via UI)
-- ────────────────────────────────────────────────────────────────────────────
PRINT '─── TEST 2 : UPDATE direct sur T_JournalEvenements ───';

DECLARE @id_jet INT = (SELECT TOP 1 Id_Event FROM T_JournalEvenements ORDER BY Id_Event);
IF @id_jet IS NULL
BEGIN
    PRINT 'SKIP — table T_JournalEvenements vide, lancer CLI au moins une fois';
END
ELSE
BEGIN
    BEGIN TRY
        UPDATE T_JournalEvenements
        SET Description = 'TEST_FRAUDE_PENTEST'
        WHERE Id_Event = @id_jet;
        PRINT '❌ FAIL — l''UPDATE a réussi (faille critique)';
    END TRY
    BEGIN CATCH
        PRINT '✅ PASS — UPDATE rejeté : ' + ERROR_MESSAGE();
    END CATCH
END
PRINT '';

-- ────────────────────────────────────────────────────────────────────────────
-- TEST 3 — DELETE direct sur T_CommandeVente
-- ────────────────────────────────────────────────────────────────────────────
PRINT '─── TEST 3 : DELETE direct sur T_CommandeVente ───';

DECLARE @id_vente INT = (SELECT TOP 1 ID_T_CommandeVente FROM T_CommandeVente
                         WHERE TicketLe IS NOT NULL ORDER BY ID_T_CommandeVente DESC);
IF @id_vente IS NULL
BEGIN
    PRINT 'SKIP — aucun ticket en base, créer une vente de test d''abord';
END
ELSE
BEGIN
    BEGIN TRY
        DELETE FROM T_CommandeVente WHERE ID_T_CommandeVente = @id_vente;
        PRINT '❌ FAIL — la suppression a réussi (faille critique)';
    END TRY
    BEGIN CATCH
        PRINT '✅ PASS — DELETE rejeté : ' + ERROR_MESSAGE();
    END CATCH
    -- Vérification : le ticket doit toujours exister
    IF EXISTS (SELECT 1 FROM T_CommandeVente WHERE ID_T_CommandeVente = @id_vente)
        PRINT '   → ticket #' + CAST(@id_vente AS VARCHAR) + ' toujours présent ✓';
    ELSE
        PRINT '❌ FAIL — le ticket a disparu de la base';
END
PRINT '';

-- ────────────────────────────────────────────────────────────────────────────
-- TEST 5 — Tentative de remise à zéro du Grand Total Perpétuel
-- ────────────────────────────────────────────────────────────────────────────
PRINT '─── TEST 5 : Reset Grand Total Perpétuel ───';

DECLARE @gtpAvant DECIMAL(19,2) = (SELECT TOP 1 MontantTotal_TTC FROM T_GrandTotal ORDER BY DateMaj DESC);
IF @gtpAvant IS NULL
BEGIN
    PRINT 'SKIP — table T_GrandTotal vide, lancer une clôture Z d''abord';
END
ELSE
BEGIN
    PRINT '   GTP avant test : ' + CAST(@gtpAvant AS VARCHAR(20));
    BEGIN TRY
        UPDATE T_GrandTotal SET MontantTotal_TTC = 0;
        DECLARE @gtpApres DECIMAL(19,2) = (SELECT TOP 1 MontantTotal_TTC FROM T_GrandTotal ORDER BY DateMaj DESC);
        IF @gtpApres < @gtpAvant
            PRINT '❌ FAIL — GTP réinitialisé à ' + CAST(@gtpApres AS VARCHAR(20));
        ELSE
            PRINT '✅ PASS — GTP intact (UPDATE silencieusement ignoré)';
    END TRY
    BEGIN CATCH
        PRINT '✅ PASS — UPDATE GTP rejeté : ' + ERROR_MESSAGE();
    END CATCH
    PRINT '   GTP après test : ' + CAST((SELECT TOP 1 MontantTotal_TTC FROM T_GrandTotal ORDER BY DateMaj DESC) AS VARCHAR(20));
END
PRINT '';

-- ────────────────────────────────────────────────────────────────────────────
-- TEST 6 — Brute-force : compter les ECHEC_AUTHENTIFICATION récents
-- ────────────────────────────────────────────────────────────────────────────
PRINT '─── TEST 6 : Détection brute-force (lecture seule) ───';
PRINT '   (à exécuter APRÈS avoir tenté 5 connexions ratées via CLI.exe)';

SELECT TOP 10
    DateEvent,
    TypeEvent,
    Utilisateur,
    Description
FROM T_JournalEvenements
WHERE TypeEvent IN ('ECHEC_AUTHENTIFICATION', 'BLOCAGE_BRUTE_FORCE',
                    'BLOCAGE_AUTHENTIFICATION', 'AUTHENTIFICATION_REUSSIE')
  AND DateEvent >= DATEADD(MINUTE, -30, GETDATE())
ORDER BY DateEvent DESC;

PRINT '';
PRINT '======================================================================';
PRINT 'Tests SQL terminés.';
PRINT 'Tests UI restants à effectuer manuellement :';
PRINT '   • Test 1 : SQL injection sur écran de connexion (CLI.exe)';
PRINT '   • Test 4 : modification d''un ticket et appel à VerifierIntegriteChaineX509()';
PRINT '   • Test 6 : 6 connexions consécutives (5 ratées + 1 avec bon mdp)';
PRINT '======================================================================';
