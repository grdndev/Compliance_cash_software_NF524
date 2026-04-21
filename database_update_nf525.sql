-- ====================================================================================
-- NF525 Compliance - Database Schema Update Script
-- ====================================================================================
-- This script adds the necessary columns for Data Chaining (Inalterability)
-- and creates the new tables for Conservation (Closures) and Security (Audit Log).
--
-- TARGET DATABASE: CLI / CHINOOKSUR
-- AUTHOR: Antigravity
-- DATE: 2024-05-23
-- ====================================================================================

BEGIN TRANSACTION;

BEGIN TRY
    -- 1. Add Signature Columns to Sales Header
    IF NOT EXISTS (SELECT * FROM sys.columns WHERE object_id = OBJECT_ID(N'[dbo].[T_CommandeVente]') AND name = 'Signature')
    BEGIN
        ALTER TABLE [dbo].[T_CommandeVente] ADD [Signature] VARCHAR(255) NULL;
        ALTER TABLE [dbo].[T_CommandeVente] ADD [PreviousSignature] VARCHAR(255) NULL;
        PRINT 'Added Signature columns to T_CommandeVente';
    END

    -- 2. Add Signature Columns to Sales Lines
    IF NOT EXISTS (SELECT * FROM sys.columns WHERE object_id = OBJECT_ID(N'[dbo].[T_CommandeVente_Ligne]') AND name = 'Signature')
    BEGIN
        ALTER TABLE [dbo].[T_CommandeVente_Ligne] ADD [Signature] VARCHAR(255) NULL;
        -- Lines are usually chained to the Ticket, but having a PreviousSignature allows for 
        -- line-by-line chaining if requested by a strict auditor. We add it for safety.
        ALTER TABLE [dbo].[T_CommandeVente_Ligne] ADD [PreviousSignature] VARCHAR(255) NULL;
        PRINT 'Added Signature columns to T_CommandeVente_Ligne';
    END

    -- 3. Add Signature Columns to Payments
    IF NOT EXISTS (SELECT * FROM sys.columns WHERE object_id = OBJECT_ID(N'[dbo].[T_Reglement]') AND name = 'Signature')
    BEGIN
        ALTER TABLE [dbo].[T_Reglement] ADD [Signature] VARCHAR(255) NULL;
        ALTER TABLE [dbo].[T_Reglement] ADD [PreviousSignature] VARCHAR(255) NULL;
        PRINT 'Added Signature columns to T_Reglement';
    END

    -- 4. Create Table for Closures (Z Reports)
    -- This table stores the "Grand Total" (Perpetual) which must never decrease.
    IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[T_Cloture]') AND type in (N'U'))
    BEGIN
        CREATE TABLE [dbo].[T_Cloture](
            [Id_Cloture] [bigint] IDENTITY(1,1) NOT NULL,
            [DateCloture] [datetime] NOT NULL DEFAULT GETDATE(),
            [TypeCloture] [varchar](20) NOT NULL, -- 'JOUR', 'MOIS', 'ANNEE'
            [MontantTotal_Jour_TTC] [decimal](18, 2) NOT NULL DEFAULT 0,
            [GrandTotal_Perpetuel_TTC] [decimal](18, 2) NOT NULL DEFAULT 0,
            [PremierTicketID] [bigint] NULL,
            [DernierTicketID] [bigint] NULL,
            [Signature] [varchar](255) NOT NULL,
            [PreviousSignature] [varchar](255) NOT NULL,
            [CreePar] [varchar](50) NULL,
            CONSTRAINT [PK_T_Cloture] PRIMARY KEY CLUSTERED ([Id_Cloture] ASC)
        );
        PRINT 'Created table T_Cloture';
    END

    -- 5. Create Table for Technical Event Log (JET - Journal des Evènements Techniques)
    -- Tracks: Startup, Tax Changes, Price Changes, Archive Exports.
    IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[T_JournalEvenements]') AND type in (N'U'))
    BEGIN
        CREATE TABLE [dbo].[T_JournalEvenements](
            [Id_Event] [bigint] IDENTITY(1,1) NOT NULL,
            [DateEvent] [datetime] NOT NULL DEFAULT GETDATE(),
            [TypeEvent] [varchar](50) NOT NULL, -- e.g. 'DEMARRAGE', 'CHANGEMENT_TVA'
            [Description] [nvarchar](max) NULL,
            [AncienneValeur] [nvarchar](max) NULL,
            [NouvelleValeur] [nvarchar](max) NULL,
            [Utilisateur] [varchar](50) NULL,
            [VersionLogiciel] [varchar](50) NULL, -- Important for NF525
            [Signature] [varchar](255) NOT NULL,
            [PreviousSignature] [varchar](255) NOT NULL,
            CONSTRAINT [PK_T_JournalEvenements] PRIMARY KEY CLUSTERED ([Id_Event] ASC)
        );
        PRINT 'Created table T_JournalEvenements';
    END

    -- 6. Add Cancellation Columns for Logical Deletion (NF525 Requirement)
    IF NOT EXISTS (SELECT * FROM sys.columns WHERE object_id = OBJECT_ID(N'[dbo].[T_CommandeVente]') AND name = 'Annule')
    BEGIN
        ALTER TABLE [dbo].[T_CommandeVente] ADD [Annule] BIT NOT NULL DEFAULT 0;
        ALTER TABLE [dbo].[T_CommandeVente] ADD [AnnuleLe] DATETIME NULL;
        ALTER TABLE [dbo].[T_CommandeVente] ADD [AnnulePar] VARCHAR(50) NULL;
        PRINT 'Added Cancellation columns to T_CommandeVente';
    END

    IF NOT EXISTS (SELECT * FROM sys.columns WHERE object_id = OBJECT_ID(N'[dbo].[T_Avoir]') AND name = 'Annule')
    BEGIN
        ALTER TABLE [dbo].[T_Avoir] ADD [Annule] BIT NOT NULL DEFAULT 0;
        ALTER TABLE [dbo].[T_Avoir] ADD [AnnuleLe] DATETIME NULL;
        ALTER TABLE [dbo].[T_Avoir] ADD [AnnulePar] VARCHAR(50) NULL;
        PRINT 'Added Cancellation columns to T_Avoir';
    END

    COMMIT TRANSACTION;
    PRINT 'Database schema update completed successfully.';

END TRY
BEGIN CATCH
    ROLLBACK TRANSACTION;
    PRINT 'Error during update: ' + ERROR_MESSAGE();
END CATCH;
