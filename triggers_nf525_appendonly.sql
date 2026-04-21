-- =============================================
-- NF525 COMPLIANCE - TRIGGERS APPEND-ONLY
-- =============================================
-- DATE: 2026-02-12
-- OBJECTIVE: Bloquer toute modification/suppression sur tables NF525
-- Phase 2 - JET Append-Only Protection
-- =============================================

USE CLI;
GO

-- =============================================
-- TRIGGER 1: Protection T_JournalEvenements (JET)
-- =============================================
-- Le Journal des Événements Techniques DOIT être Append-Only
-- Aucune modification ni suppression autorisée (même admin)

IF EXISTS (SELECT * FROM sys.triggers WHERE name = 'TR_JET_AppendOnly')
    DROP TRIGGER TR_JET_AppendOnly;
GO

CREATE TRIGGER TR_JET_AppendOnly
ON T_JournalEvenements
INSTEAD OF UPDATE, DELETE
AS
BEGIN
    SET NOCOUNT ON;
    
    DECLARE @ErrorMessage NVARCHAR(1000) = 
        '❌ NF525 VIOLATION - APPEND-ONLY PROTECTION' + CHAR(13) + CHAR(10) +
        'Le Journal des Événements Techniques (JET) est en mode Append-Only.' + CHAR(13) + CHAR(10) +
        'Aucune modification ou suppression n''est autorisée, conformément à la norme NF525.' + CHAR(13) + CHAR(10) +
        'Cette restriction s''applique même aux administrateurs système.' + CHAR(13) + CHAR(10) +
        'Date de tentative: ' + CONVERT(VARCHAR(30), GETDATE(), 120) + CHAR(13) + CHAR(10) +
        'Utilisateur: ' + SUSER_SNAME();
    
    -- Logger la tentative dans un fichier (si possible)
    -- Note: En production, activer xp_logevent ou autre mécanisme
    
    RAISERROR(@ErrorMessage, 16, 1);
    ROLLBACK TRANSACTION;
END;
GO

PRINT '✅ Trigger TR_JET_AppendOnly créé sur T_JournalEvenements';
GO

-- =============================================
-- TRIGGER 2: Protection signature T_CommandeVente
-- =============================================
-- Empêcher toute modification des colonnes de signature
-- Permet UPDATE sur autres colonnes (Total, État, etc.)

IF EXISTS (SELECT * FROM sys.triggers WHERE name = 'TR_Vente_NoModifSignature')
    DROP TRIGGER TR_Vente_NoModifSignature;
GO

CREATE TRIGGER TR_Vente_NoModifSignature
ON T_CommandeVente
FOR UPDATE
AS
BEGIN
    SET NOCOUNT ON;
    
    -- Vérifier si Signature ou PreviousSignature ont été modifiées
    IF UPDATE(Signature) OR UPDATE(PreviousSignature)
    BEGIN
        -- Vérifier s'il y a vraiment eu un changement de valeur
        IF EXISTS (
            SELECT 1 
            FROM inserted i
            INNER JOIN deleted d ON i.ID_T_CommandeVente = d.ID_T_CommandeVente
            WHERE 
                (i.Signature IS NULL AND d.Signature IS NOT NULL) OR
                (i.Signature IS NOT NULL AND d.Signature IS NULL) OR
                (i.Signature <> d.Signature) OR
                (i.PreviousSignature IS NULL AND d.PreviousSignature IS NOT NULL) OR
                (i.PreviousSignature IS NOT NULL AND d.PreviousSignature IS NULL) OR
                (i.PreviousSignature <> d.PreviousSignature)
        )
        BEGIN
            DECLARE @ErrorMsg NVARCHAR(500) = 
                '❌ NF525 VIOLATION - SIGNATURE PROTECTION' + CHAR(13) + CHAR(10) +
                'Impossible de modifier les signatures cryptographiques.' + CHAR(13) + CHAR(10) +
                'Les colonnes Signature et PreviousSignature sont inaltérables (NF525).' + CHAR(13) + CHAR(10) +
                'Date: ' + CONVERT(VARCHAR(30), GETDATE(), 120);
            
            RAISERROR(@ErrorMsg, 16, 1);
            ROLLBACK TRANSACTION;
        END
    END
END;
GO

PRINT '✅ Trigger TR_Vente_NoModifSignature créé sur T_CommandeVente';
GO

-- =============================================
-- TRIGGER 3: Protection signature T_CommandeVente_Ligne
-- =============================================

IF EXISTS (SELECT * FROM sys.triggers WHERE name = 'TR_VenteLigne_NoModifSignature')
    DROP TRIGGER TR_VenteLigne_NoModifSignature;
GO

CREATE TRIGGER TR_VenteLigne_NoModifSignature
ON T_CommandeVente_Ligne
FOR UPDATE
AS
BEGIN
    SET NOCOUNT ON;
    
    IF UPDATE(Signature) OR UPDATE(PreviousSignature)
    BEGIN
        IF EXISTS (
            SELECT 1 
            FROM inserted i
            INNER JOIN deleted d ON i.ID_T_CommandeVente_Ligne = d.ID_T_CommandeVente_Ligne
            WHERE 
                (i.Signature IS NULL AND d.Signature IS NOT NULL) OR
                (i.Signature IS NOT NULL AND d.Signature IS NULL) OR
                (i.Signature <> d.Signature) OR
                (i.PreviousSignature IS NULL AND d.PreviousSignature IS NOT NULL) OR
                (i.PreviousSignature IS NOT NULL AND d.PreviousSignature IS NULL) OR
                (i.PreviousSignature <> d.PreviousSignature)
        )
        BEGIN
            RAISERROR('❌ NF525: Impossible de modifier les signatures des lignes de vente', 16, 1);
            ROLLBACK TRANSACTION;
        END
    END
END;
GO

PRINT '✅ Trigger TR_VenteLigne_NoModifSignature créé sur T_CommandeVente_Ligne';
GO

-- =============================================
-- TRIGGER 4: Protection signature T_Cloture
-- =============================================

IF EXISTS (SELECT * FROM sys.triggers WHERE name = 'TR_Cloture_AppendOnly')
    DROP TRIGGER TR_Cloture_AppendOnly;
GO

CREATE TRIGGER TR_Cloture_AppendOnly
ON T_Cloture
INSTEAD OF UPDATE, DELETE
AS
BEGIN
    SET NOCOUNT ON;
    
    DECLARE @ErrorCloture NVARCHAR(500) = 
        '❌ NF525 VIOLATION - CLÔTURE PROTECTION' + CHAR(13) + CHAR(10) +
        'Les clôtures journalières (Ticket Z) sont inaltérables.' + CHAR(13) + CHAR(10) +
        'Aucune modification ou suppression autorisée (NF525 - Grand Total Perpétuel).' + CHAR(13) + CHAR(10) +
        'Date: ' + CONVERT(VARCHAR(30), GETDATE(), 120);
    
    RAISERROR(@ErrorCloture, 16, 1);
    ROLLBACK TRANSACTION;
END;
GO

PRINT '✅ Trigger TR_Cloture_AppendOnly créé sur T_Cloture';
GO

-- =============================================
-- TEST DES TRIGGERS (optionnel - décommenter pour tester)
-- =============================================
/*
PRINT '';
PRINT '===== TESTS DES TRIGGERS =====';

-- Test 1: Tentative UPDATE sur JET (doit échouer)
PRINT 'Test 1: Tentative UPDATE sur T_JournalEvenements...';
BEGIN TRY
    UPDATE T_JournalEvenements SET Description = 'TEST' WHERE Id_Event = 1;
    PRINT '❌ ÉCHEC: UPDATE autorisé (ne devrait pas)';
END TRY
BEGIN CATCH
    PRINT '✅ SUCCÈS: UPDATE bloqué - ' + ERROR_MESSAGE();
END CATCH

-- Test 2: Tentative DELETE sur JET (doit échouer)
PRINT 'Test 2: Tentative DELETE sur T_JournalEvenements...';
BEGIN TRY
    DELETE FROM T_JournalEvenements WHERE Id_Event = 1;
    PRINT '❌ ÉCHEC: DELETE autorisé (ne devrait pas)';
END TRY
BEGIN CATCH
    PRINT '✅ SUCCÈS: DELETE bloqué - ' + ERROR_MESSAGE();
END CATCH

-- Test 3: Tentative modif signature vente (doit échouer)
PRINT 'Test 3: Tentative UPDATE Signature sur T_CommandeVente...';
BEGIN TRY
    UPDATE T_CommandeVente SET Signature = 'MODIFIED' WHERE ID_T_CommandeVente = 1;
    PRINT '❌ ÉCHEC: Modification signature autorisée (ne devrait pas)';
END TRY
BEGIN CATCH
    PRINT '✅ SUCCÈS: Modification signature bloquée - ' + ERROR_MESSAGE();
END CATCH

PRINT '===== FIN DES TESTS =====';
*/

-- =============================================
-- VÉRIFICATION INSTALLATION
-- =============================================

PRINT '';
PRINT '========================================';
PRINT 'RÉSUMÉ INSTALLATION TRIGGERS NF525';
PRINT '========================================';

SELECT 
    OBJECT_NAME(parent_id) AS [Table],
    name AS [Trigger],
    create_date AS [Date_Creation],
    modify_date AS [Derniere_Modif]
FROM sys.triggers
WHERE name IN (
    'TR_JET_AppendOnly',
    'TR_Vente_NoModifSignature',
    'TR_VenteLigne_NoModifSignature',
    'TR_Cloture_AppendOnly'
)
ORDER BY OBJECT_NAME(parent_id);

PRINT '';
PRINT '✅ Tous les triggers NF525 Append-Only sont installés';
PRINT '✅ Phase 2 - Protection SQL : 100% complète';
PRINT '';
PRINT 'Pour tester les triggers, décommentez la section /* TEST DES TRIGGERS */';
PRINT 'et exécutez à nouveau ce script.';
PRINT '';

GO
