-- ==============================================================================
-- CLI 4.0 — Réforme facturation électronique 2026-2027
-- Tables et paramètres pour Factur-X (émission) + e-Reporting (B2C agrégé)
-- + réception des factures fournisseurs
--
-- À exécuter UNE FOIS sur la base CLI / CHINOOKSUR, après les 4 scripts NF525.
-- Ordre global recommandé :
--   01_database_update_nf525.sql
--   02_triggers_nf525_appendonly.sql
--   03_migration_nf525_phase4.sql
--   04_setup_dpd_transporteur.sql
--   05_facturation_electronique.sql      ← CE SCRIPT
-- ==============================================================================

SET NOCOUNT ON;

-- ╔══════════════════════════════════════════════════════════════════════════════
-- ║ 1. TABLE — FACTURES ÉLECTRONIQUES ÉMISES (Factur-X + e-Reporting B2C)
-- ╚══════════════════════════════════════════════════════════════════════════════
IF NOT EXISTS (SELECT 1 FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'T_FactureElectronique_Emise')
BEGIN
    CREATE TABLE T_FactureElectronique_Emise (
        Id_FactureElec        BIGINT IDENTITY(1,1) PRIMARY KEY,
        TypeFlux              VARCHAR(20) NOT NULL,    -- 'FACTUR_X' | 'E_REPORTING'
        ID_T_CommandeVente    BIGINT NULL,             -- renseigné pour FACTUR_X
        DateDebut             DATETIME NULL,           -- renseigné pour E_REPORTING (début décade)
        DateFin               DATETIME NULL,           -- renseigné pour E_REPORTING (fin décade)

        NumeroFacture         VARCHAR(50) NULL,        -- numéro lisible
        DestinataireNom       VARCHAR(255) NULL,
        DestinataireSiret     VARCHAR(20) NULL,
        DestinataireEmail     VARCHAR(255) NULL,
        MontantHT             DECIMAL(19,2) NULL,
        MontantTVA            DECIMAL(19,2) NULL,
        MontantTTC            DECIMAL(19,2) NULL,

        XmlContent            NVARCHAR(MAX) NULL,      -- XML Factur-X ou e-Reporting
        PdfBytes              VARBINARY(MAX) NULL,     -- PDF/A-3 Factur-X émis
        Profil                VARCHAR(50) NULL,        -- EN16931 / BASIC / EXTENDED

        Statut                VARCHAR(30) NOT NULL DEFAULT 'INITIE',
        -- 'INITIE' | 'TRANSMIS' | 'ACCEPTE_PDP' | 'REJETE_PDP' | 'ACCEPTE_DGFIP'
        -- | 'REJETE_DGFIP' | 'ENCAISSE' | 'ECHEC' | 'ERREUR_INTERNE'
        IdentifiantPDP        VARCHAR(100) NULL,       -- ID retourné par la PDP
        MessagePDP            NVARCHAR(MAX) NULL,      -- réponse texte de la PDP

        NbTentatives          INT NOT NULL DEFAULT 0,
        DateCreation          DATETIME NOT NULL DEFAULT GETDATE(),
        DateMaj               DATETIME NULL,
        CreePar               VARCHAR(100) NULL
    );

    CREATE INDEX IX_FactureElec_Emise_Statut ON T_FactureElectronique_Emise(Statut);
    CREATE INDEX IX_FactureElec_Emise_TypeFlux ON T_FactureElectronique_Emise(TypeFlux);
    CREATE INDEX IX_FactureElec_Emise_DateCreation ON T_FactureElectronique_Emise(DateCreation);
    CREATE INDEX IX_FactureElec_Emise_IdPdp ON T_FactureElectronique_Emise(IdentifiantPDP);

    PRINT 'Table T_FactureElectronique_Emise créée.';
END
ELSE
BEGIN
    PRINT 'Table T_FactureElectronique_Emise existe déjà.';
END

-- ╔══════════════════════════════════════════════════════════════════════════════
-- ║ 2. TABLE — FACTURES ÉLECTRONIQUES REÇUES (fournisseurs)
-- ╚══════════════════════════════════════════════════════════════════════════════
IF NOT EXISTS (SELECT 1 FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'T_FactureElectronique_Recue')
BEGIN
    CREATE TABLE T_FactureElectronique_Recue (
        Id_FactureRecue       BIGINT IDENTITY(1,1) PRIMARY KEY,
        IdentifiantPDP        VARCHAR(100) NOT NULL UNIQUE,

        NumeroFacture         VARCHAR(50) NULL,
        DateFacture           DATETIME NULL,
        DateEcheance          DATETIME NULL,

        FournisseurNom        VARCHAR(255) NULL,
        FournisseurSiret      VARCHAR(20) NULL,
        FournisseurTvaIntracom VARCHAR(30) NULL,

        MontantHT             DECIMAL(19,2) NULL,
        MontantTVA            DECIMAL(19,2) NULL,
        MontantTTC            DECIMAL(19,2) NULL,
        Devises               VARCHAR(3) NOT NULL DEFAULT 'EUR',
        Profil                VARCHAR(100) NULL,

        XmlContent            NVARCHAR(MAX) NULL,
        PdfBytes              VARBINARY(MAX) NULL,

        Statut                VARCHAR(30) NOT NULL DEFAULT 'RECUE',
        -- 'RECUE' | 'EN_COURS_VALIDATION' | 'VALIDEE' | 'REFUSEE' | 'PAYEE' | 'LITIGE'
        MotifRefus            NVARCHAR(MAX) NULL,
        DatePaiement          DATETIME NULL,
        RefPaiement           VARCHAR(50) NULL,
        CommentaireInterne    NVARCHAR(MAX) NULL,

        DateReception         DATETIME NOT NULL DEFAULT GETDATE(),
        DateMaj               DATETIME NULL,
        ValidePar             VARCHAR(100) NULL
    );

    CREATE INDEX IX_FactureElec_Recue_Statut ON T_FactureElectronique_Recue(Statut);
    CREATE INDEX IX_FactureElec_Recue_DateFacture ON T_FactureElectronique_Recue(DateFacture);
    CREATE INDEX IX_FactureElec_Recue_Fournisseur ON T_FactureElectronique_Recue(FournisseurSiret);
    CREATE INDEX IX_FactureElec_Recue_DateEcheance ON T_FactureElectronique_Recue(DateEcheance);

    PRINT 'Table T_FactureElectronique_Recue créée.';
END
ELSE
BEGIN
    PRINT 'Table T_FactureElectronique_Recue existe déjà.';
END

-- ╔══════════════════════════════════════════════════════════════════════════════
-- ║ 3. TRIGGER — Append-only sur T_FactureElectronique_Emise
-- ║    Une fois transmise à la PDP, une facture ne peut plus être supprimée ni
-- ║    modifiée arbitrairement. Seuls Statut / IdentifiantPDP / MessagePDP /
-- ║    DateMaj / NbTentatives peuvent évoluer (cycle de vie légal).
-- ╚══════════════════════════════════════════════════════════════════════════════
IF EXISTS (SELECT 1 FROM sys.triggers WHERE name = 'trg_FactureElec_Emise_NoDelete')
    DROP TRIGGER trg_FactureElec_Emise_NoDelete;
GO

CREATE TRIGGER trg_FactureElec_Emise_NoDelete
ON T_FactureElectronique_Emise
INSTEAD OF DELETE
AS
BEGIN
    RAISERROR('NF525 / Réforme facturation électronique : suppression interdite sur les factures émises (utiliser le statut REJETE_PDP ou ERREUR_INTERNE).', 16, 1);
    ROLLBACK TRANSACTION;
END
GO

-- ╔══════════════════════════════════════════════════════════════════════════════
-- ║ 4. T_Param — Paramètres Factur-X entreprise (à renseigner par Chinook)
-- ╚══════════════════════════════════════════════════════════════════════════════
DECLARE @paramsEntreprise TABLE (Cle VARCHAR(100), Defaut VARCHAR(255));
INSERT INTO @paramsEntreprise VALUES
    ('FacturX_Entreprise_Nom',              'CHINOOK LEUCATE'),
    ('FacturX_Entreprise_Adresse1',         'Route de la plage'),
    ('FacturX_Entreprise_Adresse2',         ''),
    ('FacturX_Entreprise_CodePostal',       '11370'),
    ('FacturX_Entreprise_Ville',            'Leucate'),
    ('FacturX_Entreprise_CodePays',         'FR'),
    ('FacturX_Entreprise_Siret',            '48450148100010'),
    ('FacturX_Entreprise_Siren',            '484501481'),
    ('FacturX_Entreprise_TvaIntracom',      ''),
    ('FacturX_Entreprise_CodeAPE',          ''),
    ('FacturX_Entreprise_FormeJuridique',   'SARL'),
    ('FacturX_Entreprise_Capital',          ''),
    ('FacturX_Entreprise_Email',            'contact@chinook-leucate.com'),
    ('FacturX_Entreprise_Telephone',        '+33 4 68 40 17 17'),
    ('FacturX_Entreprise_IBAN',             ''),
    ('FacturX_Entreprise_BIC',              ''),
    ('FacturX_Entreprise_TitulaireCompte',  '');

DECLARE @cle VARCHAR(100), @defaut VARCHAR(255);
DECLARE curParams CURSOR FOR SELECT Cle, Defaut FROM @paramsEntreprise;
OPEN curParams;
FETCH NEXT FROM curParams INTO @cle, @defaut;
WHILE @@FETCH_STATUS = 0
BEGIN
    IF NOT EXISTS (SELECT 1 FROM T_Param WHERE Paramname = @cle)
        INSERT INTO T_Param (Paramname, Paramvalue) VALUES (@cle, @defaut);
    FETCH NEXT FROM curParams INTO @cle, @defaut;
END
CLOSE curParams;
DEALLOCATE curParams;
PRINT 'Paramètres entreprise Factur-X initialisés.';

-- ╔══════════════════════════════════════════════════════════════════════════════
-- ║ 5. T_Param — Paramètres PDP (Plateforme de Dématérialisation Partenaire)
-- ║    À configurer une fois la PDP choisie (Pennylane, Esker, Sage Network,
-- ║    Generix, Yooz, etc.). Toutes les valeurs sont vides par défaut.
-- ╚══════════════════════════════════════════════════════════════════════════════
DECLARE @paramsPdp TABLE (Cle VARCHAR(100), Defaut VARCHAR(255));
INSERT INTO @paramsPdp VALUES
    ('PDP_API_URL',                ''),                       -- ex: https://api.pennylane.com/v1
    ('PDP_API_KEY',                ''),                       -- clé API ou token
    ('PDP_API_AUTH_TYPE',          'BEARER'),                 -- BEARER | APIKEY | BASIC
    ('PDP_API_ENDPOINT_FACTURX',   'invoices/submit'),        -- POST émission Factur-X
    ('PDP_API_ENDPOINT_ER',        'ereporting/submit'),      -- POST e-Reporting
    ('PDP_API_ENDPOINT_INBOX',     'invoices/inbox?status=new'), -- GET liste factures fournisseurs
    ('PDP_API_ENDPOINT_DOWNLOAD',  'invoices/{id}/download'), -- GET PDF facture entrante
    ('PDP_API_MAX_RETRIES',        '3'),
    ('PDP_API_RETRY_DELAY_MS',     '2000'),
    ('PDP_NOM',                    ''),                        -- nom commercial PDP retenue
    ('FacturX_AutoEmission',       '0'),                       -- 0 = manuel, 1 = auto à validation facture
    ('FacturX_ProfilDefaut',       'EN16931'),                 -- MINIMUM / BASICWL / BASIC / EN16931 / EXTENDED
    ('EReporting_Frequence',       'DECADAIRE'),               -- DECADAIRE | MENSUELLE
    ('EReporting_AutoTransmission','0');                       -- 0 = manuel, 1 = exécution auto par scheduler

DECLARE curPdp CURSOR FOR SELECT Cle, Defaut FROM @paramsPdp;
OPEN curPdp;
FETCH NEXT FROM curPdp INTO @cle, @defaut;
WHILE @@FETCH_STATUS = 0
BEGIN
    IF NOT EXISTS (SELECT 1 FROM T_Param WHERE Paramname = @cle)
        INSERT INTO T_Param (Paramname, Paramvalue) VALUES (@cle, @defaut);
    FETCH NEXT FROM curPdp INTO @cle, @defaut;
END
CLOSE curPdp;
DEALLOCATE curPdp;
PRINT 'Paramètres PDP initialisés.';

-- ╔══════════════════════════════════════════════════════════════════════════════
-- ║ 6. Vérification
-- ╚══════════════════════════════════════════════════════════════════════════════
SELECT 'T_FactureElectronique_Emise' AS Table_, COUNT(*) AS Lignes FROM T_FactureElectronique_Emise
UNION ALL
SELECT 'T_FactureElectronique_Recue', COUNT(*) FROM T_FactureElectronique_Recue;

SELECT Paramname, Paramvalue
FROM T_Param
WHERE Paramname LIKE 'FacturX_%' OR Paramname LIKE 'PDP_%' OR Paramname LIKE 'EReporting_%'
ORDER BY Paramname;

-- ==============================================================================
-- ÉTAPES SUIVANTES (à effectuer par Chinook avant utilisation en production) :
--
-- 1. Choisir une PDP partenaire :
--    - Pennylane (recommandée PME)
--    - Esker / Sage Network / Generix / Yooz / Tessi Documents Services
--
-- 2. Souscrire un abonnement à la PDP et obtenir les credentials API :
--    - URL de base
--    - Clé API (Bearer / APIKEY / BASIC)
--
-- 3. Renseigner les T_Param correspondants :
--    UPDATE T_Param SET Paramvalue = '<url>'   WHERE Paramname = 'PDP_API_URL';
--    UPDATE T_Param SET Paramvalue = '<key>'   WHERE Paramname = 'PDP_API_KEY';
--    UPDATE T_Param SET Paramvalue = '<type>'  WHERE Paramname = 'PDP_API_AUTH_TYPE';
--    UPDATE T_Param SET Paramvalue = '<nom>'   WHERE Paramname = 'PDP_NOM';
--
-- 4. Compléter les paramètres entreprise (TVA intracom, IBAN, etc.) :
--    UPDATE T_Param SET Paramvalue = 'FR12345678901' WHERE Paramname = 'FacturX_Entreprise_TvaIntracom';
--    UPDATE T_Param SET Paramvalue = '<IBAN>'        WHERE Paramname = 'FacturX_Entreprise_IBAN';
--    UPDATE T_Param SET Paramvalue = '<BIC>'         WHERE Paramname = 'FacturX_Entreprise_BIC';
--
-- 5. Tester :
--    - Émission Factur-X via FacturXGenerator.GenerateXML(idCommande)
--    - Transmission via EReportingService.ExecuterCycleEReporting()
--    - Réception via FactureElectroniqueReceiver.ExecuterCycleReception()
-- ==============================================================================
