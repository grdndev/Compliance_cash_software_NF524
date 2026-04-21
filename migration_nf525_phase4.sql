-- ====================================================================================
-- NF525 PHASE 4 - MIGRATIONS COMPLÉMENTAIRES
-- ====================================================================================
-- Ce script ajoute les colonnes nécessaires pour :
--   1. La purge sécurisée des données (PurgeLe, PurgePar sur T_CommandeVente)
--   2. La préparation au hachage PBKDF2 des mots de passe (colonne Password étendue)
-- TARGET DATABASE: CLI / CHINOOKSUR
-- DATE: 2026-03-26
-- ====================================================================================

BEGIN TRANSACTION;

BEGIN TRY

    -- ─────────────────────────────────────────────────────────────
    -- 1. Colonnes de purge sécurisée sur T_CommandeVente
    --    NF525 : toute purge doit être tracée (pas de DELETE physique).
    --    Les tickets purgés restent en base avec PurgeLe renseigné.
    -- ─────────────────────────────────────────────────────────────
    IF NOT EXISTS (
        SELECT * FROM sys.columns
        WHERE object_id = OBJECT_ID(N'[dbo].[T_CommandeVente]') AND name = 'PurgeLe'
    )
    BEGIN
        ALTER TABLE [dbo].[T_CommandeVente] ADD [PurgeLe]  DATETIME NULL;
        ALTER TABLE [dbo].[T_CommandeVente] ADD [PurgePar] VARCHAR(50) NULL;
        PRINT '✅ Colonnes PurgeLe / PurgePar ajoutées à T_CommandeVente';
    END
    ELSE
    BEGIN
        PRINT 'ℹ️  Colonnes PurgeLe / PurgePar déjà présentes sur T_CommandeVente';
    END

    -- ─────────────────────────────────────────────────────────────
    -- 2. Extension de la colonne Password pour le format PBKDF2
    --    Le hash PBKDF2 (format $pbkdf2sha1v1$...) fait ~110 caractères.
    --    Si la colonne est trop courte, l'élargir à VARCHAR(255).
    -- ─────────────────────────────────────────────────────────────
    DECLARE @TypePassword VARCHAR(20);
    DECLARE @LongueurPassword INT;

    SELECT
        @TypePassword    = DATA_TYPE,
        @LongueurPassword = CHARACTER_MAXIMUM_LENGTH
    FROM INFORMATION_SCHEMA.COLUMNS
    WHERE TABLE_NAME = 't_user' AND COLUMN_NAME = 'password';

    IF @LongueurPassword IS NOT NULL AND @LongueurPassword < 255
    BEGIN
        ALTER TABLE [dbo].[t_user] ALTER COLUMN [password] VARCHAR(255) NOT NULL;
        PRINT '✅ Colonne t_user.password élargie à VARCHAR(255) pour PBKDF2';
    END
    ELSE
    BEGIN
        PRINT 'ℹ️  Colonne t_user.password déjà à taille suffisante (' +
              CAST(ISNULL(@LongueurPassword, 0) AS VARCHAR) + ')';
    END

    -- ─────────────────────────────────────────────────────────────
    -- 3. Index de performance sur T_CommandeVente (purge et archive)
    -- ─────────────────────────────────────────────────────────────
    IF NOT EXISTS (
        SELECT * FROM sys.indexes
        WHERE name = 'IX_T_CommandeVente_TicketLe_Etat'
          AND object_id = OBJECT_ID('T_CommandeVente')
    )
    BEGIN
        CREATE NONCLUSTERED INDEX [IX_T_CommandeVente_TicketLe_Etat]
        ON [dbo].[T_CommandeVente] ([TicketLe], [ID_EtatCommandeVente])
        INCLUDE ([Total_TTC], [Signature], [PurgeLe]);
        PRINT '✅ Index IX_T_CommandeVente_TicketLe_Etat créé';
    END
    ELSE
    BEGIN
        PRINT 'ℹ️  Index IX_T_CommandeVente_TicketLe_Etat déjà présent';
    END

    -- ─────────────────────────────────────────────────────────────
    -- 4. Vérification de la monotonie du Grand Total Perpétuel
    --    (Requête diagnostic — résultat doit être 0 ligne)
    -- ─────────────────────────────────────────────────────────────
    PRINT '';
    PRINT '── Vérification monotonie Grand Total Perpétuel ──────────────';
    SELECT
        c1.Id_Cloture,
        c1.DateCloture,
        c1.TypeCloture,
        c1.GrandTotal_Perpetuel_TTC AS GTP_Actuel,
        (
            SELECT TOP 1 c2.GrandTotal_Perpetuel_TTC
            FROM T_Cloture c2
            WHERE c2.Id_Cloture < c1.Id_Cloture
            ORDER BY c2.Id_Cloture DESC
        ) AS GTP_Precedent
    FROM T_Cloture c1
    WHERE c1.GrandTotal_Perpetuel_TTC < (
        SELECT TOP 1 c2.GrandTotal_Perpetuel_TTC
        FROM T_Cloture c2
        WHERE c2.Id_Cloture < c1.Id_Cloture
        ORDER BY c2.Id_Cloture DESC
    );

    -- Si la requête ci-dessus retourne des lignes → ANOMALIE CRITIQUE
    PRINT 'Si aucun résultat ci-dessus : ✅ Grand Total Perpétuel valide';
    PRINT 'Si des lignes apparaissent  : ❌ ANOMALIE - Contacter référent NF525';
    PRINT '';

    COMMIT TRANSACTION;
    PRINT '✅ Migration NF525 Phase 4 terminée avec succès.';

END TRY
BEGIN CATCH
    ROLLBACK TRANSACTION;
    PRINT '❌ Erreur lors de la migration : ' + ERROR_MESSAGE();
END CATCH;

-- ====================================================================================
-- GUIDE DE MIGRATION DES MOTS DE PASSE VERS PBKDF2
-- ====================================================================================
--
-- La migration des mots de passe en clair vers PBKDF2 est AUTOMATIQUE :
-- Lors de la prochaine connexion de chaque utilisateur, FormIdentification.vb
-- détecte si le mot de passe est en clair et le migre automatiquement vers PBKDF2.
--
-- Pour vérifier l'état de la migration :
--
-- SELECT login,
--        CASE WHEN password LIKE '$pbkdf2sha1v1$%' THEN '✅ PBKDF2'
--             ELSE '⚠️  Plaintext (pas encore connecté depuis la mise à jour)'
--        END AS Statut_MDP
-- FROM t_user WHERE actif = 1;
--
-- Pour forcer la migration d'un utilisateur spécifique SANS connexion :
-- (Remplacer 'MotDePasseEnClair' par le vrai mot de passe)
-- Utiliser l'interface d'administration du logiciel → Gestion des utilisateurs.
-- ====================================================================================
