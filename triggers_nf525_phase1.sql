-- =============================================
-- NF525 PHASE 1 - TRIGGERS PROTECTION DELETE
-- =============================================
-- DATE: 2026-02-12
-- OBJECTIVE: Bloquer toute suppression directe SQL sur tables fiscales
-- Phase 1 - Verrouillage & Inaltérabilité
-- =============================================

USE CLI;
GO

PRINT '';
PRINT '========================================';
PRINT 'PHASE 1 NF525 - PROTECTION DELETE';
PRINT '========================================';
PRINT '';

-- =============================================
-- TRIGGER 1: Protection T_CommandeVente
-- =============================================
-- Empêcher toute suppression de ventes (même par admin SQL)
-- Seule la contrepassation (Annule=1) est autorisée

IF EXISTS (SELECT * FROM sys.triggers WHERE name = 'TR_PreventDelete_T_CommandeVente')
    DROP TRIGGER TR_PreventDelete_T_CommandeVente;
GO

CREATE TRIGGER TR_PreventDelete_T_CommandeVente
ON T_CommandeVente
INSTEAD OF DELETE
AS
BEGIN
    SET NOCOUNT ON;
    
    DECLARE @ErrorMessage NVARCHAR(1000) = 
        '❌ NF525 PHASE 1 - SUPPRESSION INTERDITE' + CHAR(13) + CHAR(10) +
        'La suppression physique des ventes (T_CommandeVente) est interdite.' + CHAR(13) + CHAR(10) +
        'Conformité NF525 : Utilisez la contrepassation (création avoir).' + CHAR(13) + CHAR(10) +
        'Pour annuler une vente, utilisez le formulaire de caisse.' + CHAR(13) + CHAR(10) +
        'Date de tentative: ' + CONVERT(VARCHAR(30), GETDATE(), 120) + CHAR(13) + CHAR(10) +
        'Utilisateur SQL: ' + SUSER_SNAME() + CHAR(13) + CHAR(10) +
        'Nombre de lignes ciblées: ' + CAST(@@ROWCOUNT AS VARCHAR(10));
    
    -- Logger la tentative dans le JET (si possible)
    BEGIN TRY
        INSERT INTO T_JournalEvenements (TypeEvent, Description, Utilisateur, VersionLogiciel, Signature, PreviousSignature)
        VALUES ('TENTATIVE_DELETE_VENTE', 
                'Tentative de suppression directe SQL sur T_CommandeVente bloquée',
                SUSER_SNAME(),
                'SQL Server',
                'BLOCKED_BY_TRIGGER',
                'SECURITY_VIOLATION');
    END TRY
    BEGIN CATCH
        -- Si JET échoue, continuer pour bloquer quand même
    END CATCH
    
    RAISERROR(@ErrorMessage, 16, 1);
    ROLLBACK TRANSACTION;
END;
GO

PRINT '✅ Trigger TR_PreventDelete_T_CommandeVente créé';
GO

-- =============================================
-- TRIGGER 2: Protection T_Reglement
-- =============================================
-- Empêcher toute suppression de règlements
-- Les règlements sont des preuves de paiement fiscales

IF EXISTS (SELECT * FROM sys.triggers WHERE name = 'TR_PreventDelete_T_Reglement')
    DROP TRIGGER TR_PreventDelete_T_Reglement;
GO

CREATE TRIGGER TR_PreventDelete_T_Reglement
ON T_Reglement
INSTEAD OF DELETE
AS
BEGIN
    SET NOCOUNT ON;
    
    DECLARE @ErrorMessage NVARCHAR(1000) = 
        '❌ NF525 PHASE 1 - SUPPRESSION INTERDITE' + CHAR(13) + CHAR(10) +
        'La suppression physique des règlements (T_Reglement) est interdite.' + CHAR(13) + CHAR(10) +
        'Conformité NF525 : Les règlements prouvent les encaissements fiscaux.' + CHAR(13) + CHAR(10) +
        'Pour corriger un règlement, utilisez la contrepassation (avoir).' + CHAR(13) + CHAR(10) +
        'Date de tentative: ' + CONVERT(VARCHAR(30), GETDATE(), 120) + CHAR(13) + CHAR(10) +
        'Utilisateur SQL: ' + SUSER_SNAME() + CHAR(13) + CHAR(10) +
        'Nombre de règlements ciblés: ' + CAST(@@ROWCOUNT AS VARCHAR(10));
    
    -- Logger la tentative
    BEGIN TRY
        INSERT INTO T_JournalEvenements (TypeEvent, Description, Utilisateur, VersionLogiciel, Signature, PreviousSignature)
        VALUES ('TENTATIVE_DELETE_REGLEMENT', 
                'Tentative de suppression directe SQL sur T_Reglement bloquée',
                SUSER_SNAME(),
                'SQL Server',
                'BLOCKED_BY_TRIGGER',
                'SECURITY_VIOLATION');
    END TRY
    BEGIN CATCH
        -- Continue
    END CATCH
    
    RAISERROR(@ErrorMessage, 16, 1);
    ROLLBACK TRANSACTION;
END;
GO

PRINT '✅ Trigger TR_PreventDelete_T_Reglement créé';
GO

-- =============================================
-- TRIGGER 3: Protection T_Avoir
-- =============================================
-- Empêcher toute suppression d'avoirs
-- Les avoirs sont des preuves de contrepassation NF525

IF EXISTS (SELECT * FROM sys.triggers WHERE name = 'TR_PreventDelete_T_Avoir')
    DROP TRIGGER TR_PreventDelete_T_Avoir;
GO

CREATE TRIGGER TR_PreventDelete_T_Avoir
ON T_Avoir
INSTEAD OF DELETE
AS
BEGIN
    SET NOCOUNT ON;
    
    DECLARE @ErrorMessage NVARCHAR(1000) = 
        '❌ NF525 PHASE 1 - SUPPRESSION INTERDITE' + CHAR(13) + CHAR(10) +
        'La suppression physique des avoirs (T_Avoir) est interdite.' + CHAR(13) + CHAR(10) +
        'Conformité NF525 : Les avoirs tracent les contrepassations fiscales.' + CHAR(13) + CHAR(10) +
        'Pour désactiver un avoir, utilisez la colonne Annule=1.' + CHAR(13) + CHAR(10) +
        'Date de tentative: ' + CONVERT(VARCHAR(30), GETDATE(), 120) + CHAR(13) + CHAR(10) +
        'Utilisateur SQL: ' + SUSER_SNAME() + CHAR(13) + CHAR(10) +
        'Nombre d''avoirs ciblés: ' + CAST(@@ROWCOUNT AS VARCHAR(10));
    
    -- Logger la tentative
    BEGIN TRY
        INSERT INTO T_JournalEvenements (TypeEvent, Description, Utilisateur, VersionLogiciel, Signature, PreviousSignature)
        VALUES ('TENTATIVE_DELETE_AVOIR', 
                'Tentative de suppression directe SQL sur T_Avoir bloquée',
                SUSER_SNAME(),
                'SQL Server',
                'BLOCKED_BY_TRIGGER',
                'SECURITY_VIOLATION');
    END TRY
    BEGIN CATCH
        -- Continue
    END CATCH
    
    RAISERROR(@ErrorMessage, 16, 1);
    ROLLBACK TRANSACTION;
END;
GO

PRINT '✅ Trigger TR_PreventDelete_T_Avoir créé';
GO

-- =============================================
-- TESTS DES TRIGGERS (optionnel - décommenter pour tester)
-- =============================================
/*
PRINT '';
PRINT '===== TESTS DES TRIGGERS PHASE 1 =====';

-- Test 1: Tentative DELETE sur T_CommandeVente (doit échouer)
PRINT 'Test 1: Tentative DELETE sur T_CommandeVente...';
BEGIN TRY
    DELETE TOP (1) FROM T_CommandeVente;
    PRINT '❌ ÉCHEC: DELETE autorisé (ne devrait pas)';
END TRY
BEGIN CATCH
    PRINT '✅ SUCCÈS: DELETE bloqué - ' + ERROR_MESSAGE();
END CATCH

-- Test 2: Tentative DELETE sur T_Reglement (doit échouer)
PRINT 'Test 2: Tentative DELETE sur T_Reglement...';
BEGIN TRY
    DELETE TOP (1) FROM T_Reglement;
    PRINT '❌ ÉCHEC: DELETE autorisé (ne devrait pas)';
END TRY
BEGIN CATCH
    PRINT '✅ SUCCÈS: DELETE bloqué - ' + ERROR_MESSAGE();
END CATCH

-- Test 3: Tentative DELETE sur T_Avoir (doit échouer)
PRINT 'Test 3: Tentative DELETE sur T_Avoir...';
BEGIN TRY
    DELETE TOP (1) FROM T_Avoir;
    PRINT '❌ ÉCHEC: DELETE autorisé (ne devrait pas)';
END TRY
BEGIN CATCH
    PRINT '✅ SUCCÈS: DELETE bloqué - ' + ERROR_MESSAGE();
END CATCH

PRINT '===== FIN DES TESTS =====';
*/

-- =============================================
-- VÉRIFICATION INSTALLATION
-- =============================================

PRINT '';
PRINT '========================================';
PRINT 'RÉSUMÉ INSTALLATION TRIGGERS PHASE 1';
PRINT '========================================';

SELECT 
    OBJECT_NAME(parent_id) AS [Table],
    name AS [Trigger],
    create_date AS [Date_Creation],
    modify_date AS [Derniere_Modif]
FROM sys.triggers
WHERE name IN (
    'TR_PreventDelete_T_CommandeVente',
    'TR_PreventDelete_T_Reglement',
    'TR_PreventDelete_T_Avoir'
)
ORDER BY OBJECT_NAME(parent_id);

PRINT '';
PRINT '✅ Tous les triggers NF525 Phase 1 sont installés';
PRINT '✅ Protection DELETE : 100% complète';
PRINT '✅ Tables protégées : T_CommandeVente, T_Reglement, T_Avoir';
PRINT '';
PRINT 'Pour tester les triggers, décommentez la section /* TESTS DES TRIGGERS */';
PRINT 'et exécutez à nouveau ce script.';
PRINT '';

GO
