using System;
using System.Collections.Generic;
using CLICore.Models;
using Microsoft.EntityFrameworkCore;

namespace CLICore.Data;

public partial class CLIContext : DbContext
{
    public CLIContext()
    {
    }

    public CLIContext(DbContextOptions<CLIContext> options)
        : base(options)
    {
    }

    public virtual DbSet<TAdresse> TAdresses { get; set; }

    public virtual DbSet<TApiCall> TApiCalls { get; set; }

    public virtual DbSet<TArticleDetail> TArticleDetails { get; set; }

    public virtual DbSet<TArticleEntete> TArticleEntetes { get; set; }

    public virtual DbSet<TArticleStock> TArticleStocks { get; set; }

    public virtual DbSet<TArticleVersion> TArticleVersions { get; set; }

    public virtual DbSet<TAvoir> TAvoirs { get; set; }

    public virtual DbSet<TClient> TClients { get; set; }

    public virtual DbSet<TCodeTva> TCodeTvas { get; set; }

    public virtual DbSet<TCommandeVente> TCommandeVentes { get; set; }

    public virtual DbSet<TCommandeVenteLigne> TCommandeVenteLignes { get; set; }

    public virtual DbSet<TFamille> TFamilles { get; set; }

    public virtual DbSet<TListeCodePortPay> TListeCodePortPays { get; set; }

    public virtual DbSet<TLog> TLogs { get; set; }

    public virtual DbSet<TParam> TParams { get; set; }

    public virtual DbSet<TPay> TPays { get; set; }

    public virtual DbSet<TProfil> TProfils { get; set; }

    public virtual DbSet<TReglement> TReglements { get; set; }

    public virtual DbSet<TSousFamille> TSousFamilles { get; set; }

    public virtual DbSet<TUser> TUsers { get; set; }

    public virtual DbSet<VArticleStock> VArticleStocks { get; set; }

    public virtual DbSet<VArticleWeb> VArticleWebs { get; set; }

    public virtual DbSet<VLog> VLogs { get; set; }

//     protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
// #warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
//         => optionsBuilder.UseSqlServer("Server=dev.chinook-leucate.com;Database=CLI;Uid=chinooksur;Encrypt=False");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .HasDefaultSchema("CHINOOKSUR")
            .UseCollation("French_CI_AS");

        modelBuilder.Entity<TAdresse>(entity =>
        {
            entity.HasKey(e => e.IdTAdresse);

            entity.ToTable("T_adresse", "dbo");

            entity.Property(e => e.IdTAdresse).HasColumnName("id_t_adresse");
            entity.Property(e => e.AdresseL1)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.AdresseL2)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.AdresseL3)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Autre)
                .HasMaxLength(300)
                .IsUnicode(false);
            entity.Property(e => e.CodePostal)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.CreeLe)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.CreePar)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.IdTClient).HasColumnName("id_t_client");
            entity.Property(e => e.Libelle).IsUnicode(false);
            entity.Property(e => e.Mobile)
                .HasMaxLength(32)
                .IsUnicode(false);
            entity.Property(e => e.ModifieLe)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.ModifiePar)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.NoTva)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("NoTVA");
            entity.Property(e => e.Nom)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.NumeroIdentite)
                .HasMaxLength(16)
                .IsUnicode(false);
            entity.Property(e => e.Pays)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Prenom)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Société)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Tel)
                .HasMaxLength(32)
                .IsUnicode(false);
            entity.Property(e => e.Ville)
                .HasMaxLength(255)
                .IsUnicode(false);
        });

        modelBuilder.Entity<TApiCall>(entity =>
        {
            entity.ToTable("T_ApiCall", "dbo");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CallDate).HasColumnType("datetime");
            entity.Property(e => e.CreatedDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.HttpMethod)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Params).IsUnicode(false);
            entity.Property(e => e.Url)
                .HasMaxLength(255)
                .IsUnicode(false);
        });

        modelBuilder.Entity<TArticleDetail>(entity =>
        {
            entity.HasKey(e => e.IdTArticleDetail);

            entity.ToTable("T_Article_Detail", "dbo");

            entity.HasIndex(e => e.IdTArticleEntete, "RechercheRapide2");

            entity.Property(e => e.IdTArticleDetail).HasColumnName("ID_t_article_detail");
            entity.Property(e => e.Aileron)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("aileron");
            entity.Property(e => e.Barre)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Boitier)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("boitier");
            entity.Property(e => e.Carbone)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.CreeLe)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.CreePar)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Epaisseur)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("epaisseur");
            entity.Property(e => e.Fins)
                .HasMaxLength(53)
                .IsUnicode(false)
                .HasColumnName("fins");
            entity.Property(e => e.FoilBoitier)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Guindant)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("guindant");
            entity.Property(e => e.IdTArticleEntete).HasColumnName("ID_t_article_entete");
            entity.Property(e => e.Imcs).HasColumnName("IMCS");
            entity.Property(e => e.Largeur)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("largeur");
            entity.Property(e => e.LargeurArriere)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("largeur_arriere");
            entity.Property(e => e.Longueur)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("longueur");
            entity.Property(e => e.LongueurLigne).HasColumnName("longueur_ligne");
            entity.Property(e => e.Mat)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Matiere)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("matiere");
            entity.Property(e => e.ModifieLe)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.ModifiePar)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.NombreDeLignes).HasColumnName("nombre_de_lignes");
            entity.Property(e => e.Programme)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("programme");
            entity.Property(e => e.Ratio)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Rdm).HasColumnName("RDM");
            entity.Property(e => e.Rdmtype)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("RDMtype");
            entity.Property(e => e.SizeMax).HasColumnName("size_max");
            entity.Property(e => e.SizeMin).HasColumnName("size_min");
            entity.Property(e => e.Surface).HasColumnName("surface");
            entity.Property(e => e.SurfaceVoile)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("surface_voile");
            entity.Property(e => e.Taille)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("taille");
            entity.Property(e => e.Type).HasMaxLength(255);
            entity.Property(e => e.Type2)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("type2");
            entity.Property(e => e.Type3)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("type3");
            entity.Property(e => e.Type4)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("type4");
            entity.Property(e => e.Wishbone)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("wishbone");
            entity.Property(e => e._5emeLigne).HasColumnName("5eme_ligne");

            entity.HasOne(d => d.IdTArticleEnteteNavigation).WithMany(p => p.TArticleDetails)
                .HasForeignKey(d => d.IdTArticleEntete)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_T_Article_Detail_T_Article_Entete");
        });

        modelBuilder.Entity<TArticleEntete>(entity =>
        {
            entity.HasKey(e => e.IdTArticleEntete);

            entity.ToTable("T_Article_Entete", "dbo");

            entity.Property(e => e.IdTArticleEntete).HasColumnName("ID_t_article_entete");
            entity.Property(e => e.Annee)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("annee");
            entity.Property(e => e.CodePort)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("Code_port");
            entity.Property(e => e.CodeTva).HasColumnName("Code_tva");
            entity.Property(e => e.CreeLe)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.CreePar)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Description)
                .HasColumnType("ntext")
                .HasColumnName("description");
            entity.Property(e => e.Description2)
                .HasColumnType("ntext")
                .HasColumnName("description2");
            entity.Property(e => e.IdTArticleEnteteLies)
                .IsUnicode(false)
                .HasColumnName("id_t_article_entete_lies");
            entity.Property(e => e.IdTSousfamille).HasColumnName("ID_t_sousfamille");
            entity.Property(e => e.Lien)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("lien");
            entity.Property(e => e.Marque)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("marque");
            entity.Property(e => e.Modele)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("modele");
            entity.Property(e => e.ModifieLe)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.ModifiePar)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.NouveauAu).HasColumnType("datetime");
            entity.Property(e => e.NouveauDu).HasColumnType("datetime");
            entity.Property(e => e.PhotoBig1)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("photo_big1");
            entity.Property(e => e.PhotoBig2)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("photo_big2");
            entity.Property(e => e.PhotoBig3)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("photo_big3");
            entity.Property(e => e.PhotoMini1)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("photo_mini1");
            entity.Property(e => e.PhotoMini2)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("photo_mini2");
            entity.Property(e => e.PhotoMini3)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("photo_mini3");
            entity.Property(e => e.PhotoModele)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("photo_modele");
            entity.Property(e => e.RemiseAutoAu).HasColumnType("datetime");
            entity.Property(e => e.RemiseAutoDu).HasColumnType("datetime");
            entity.Property(e => e.SoldeAu).HasColumnType("datetime");
            entity.Property(e => e.SoldeDu).HasColumnType("datetime");

            entity.HasOne(d => d.IdTSousfamilleNavigation).WithMany(p => p.TArticleEntetes)
                .HasForeignKey(d => d.IdTSousfamille)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_T_Article_Entete_T_SousFamille");
        });

        modelBuilder.Entity<TArticleStock>(entity =>
        {
            entity.HasKey(e => e.IdTArticleStock);

            entity.ToTable("T_Article_Stock", "dbo");

            entity.HasIndex(e => e.IdTArticleVersion, "RechercheRapide3");

            entity.Property(e => e.IdTArticleStock).HasColumnName("ID_t_article_stock");
            entity.Property(e => e.Date).HasColumnType("datetime");
            entity.Property(e => e.IdTArticleVersion).HasColumnName("ID_t_article_version");
            entity.Property(e => e.IdTCommandeAchat).HasColumnName("ID_t_commande_achat");
            entity.Property(e => e.IdTCommandeVente).HasColumnName("ID_t_commande_vente");
            entity.Property(e => e.Numcaisse).HasColumnName("numcaisse");
            entity.Property(e => e.Operation).HasColumnName("operation");
            entity.Property(e => e.Signature)
                .HasMaxLength(255)
                .IsUnicode(false);

            entity.HasOne(d => d.IdTArticleVersionNavigation).WithMany(p => p.TArticleStocks)
                .HasForeignKey(d => d.IdTArticleVersion)
                .HasConstraintName("FK_T_Article_Stock_T_Article_Version");
        });

        modelBuilder.Entity<TArticleVersion>(entity =>
        {
            entity.HasKey(e => e.IdTArticleVersion);

            entity.ToTable("T_Article_version", "dbo", tb => tb.HasTrigger("InsertVersion"));

            entity.HasIndex(e => new { e.WebOn, e.ActiveOn }, "RechercheRapide1");

            entity.HasIndex(e => new { e.Occaz, e.DepotVente, e.ActiveOn, e.Test }, "RechercheRapide4");

            entity.Property(e => e.IdTArticleVersion).HasColumnName("ID_t_article_version");
            entity.Property(e => e.ActiveOn)
                .HasDefaultValue(true)
                .HasColumnName("Active_on");
            entity.Property(e => e.AutoRemisePrixVenteInitialTtc)
                .HasColumnType("money")
                .HasColumnName("AutoRemise_prix_vente_initial_TTC");
            entity.Property(e => e.AutoRemisePrixVenteRemiseTtc)
                .HasColumnType("money")
                .HasColumnName("AutoRemise_prix_vente_remise_TTC");
            entity.Property(e => e.AutoRemiseRemise).HasColumnName("AutoRemise_Remise");
            entity.Property(e => e.Commentaires)
                .HasMaxLength(4000)
                .IsUnicode(false);
            entity.Property(e => e.CreeLe)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.CreePar)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.DepotVente)
                .HasDefaultValue(false)
                .HasColumnName("depot_vente");
            entity.Property(e => e.DescriptionAuto)
                .HasDefaultValue(true)
                .HasColumnName("Description_auto");
            entity.Property(e => e.DescriptionPanier)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("description_panier");
            entity.Property(e => e.ExportFile)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.ExportStockFile)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.IdTArticleDetail).HasColumnName("ID_t_article_detail");
            entity.Property(e => e.IdTClient).HasColumnName("ID_T_Client");
            entity.Property(e => e.IdTFournisseur).HasColumnName("ID_T_Fournisseur");
            entity.Property(e => e.ImportFile)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.ImportStockFile)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Libelle)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("libelle");
            entity.Property(e => e.MagasinOn)
                .HasDefaultValue(true)
                .HasColumnName("magasin_on");
            entity.Property(e => e.ModifieLe)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.ModifiePar)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Occaz)
                .HasDefaultValue(false)
                .HasColumnName("occaz");
            entity.Property(e => e.Poids).HasColumnName("poids");
            entity.Property(e => e.Precommande)
                .HasDefaultValue(false)
                .HasColumnName("precommande");
            entity.Property(e => e.PrixFournisseur)
                .HasColumnType("money")
                .HasColumnName("prix_fournisseur");
            entity.Property(e => e.PrixRemiseFournisseur)
                .HasDefaultValue(0m)
                .HasColumnType("money")
                .HasColumnName("prix_remise_fournisseur");
            entity.Property(e => e.PrixVenteInitialTtc)
                .HasDefaultValue(0m)
                .HasColumnType("money")
                .HasColumnName("prix_vente_initial_TTC");
            entity.Property(e => e.PrixVenteRemiseTtc)
                .HasDefaultValue(0m)
                .HasColumnType("money")
                .HasColumnName("prix_vente_remise_TTC");
            entity.Property(e => e.Reappro)
                .HasDefaultValue(false)
                .HasColumnName("reappro");
            entity.Property(e => e.RefFournisseur)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("ref_fournisseur");
            entity.Property(e => e.Remise)
                .HasDefaultValue(0.0)
                .HasColumnName("remise");
            entity.Property(e => e.RemiseFournisseur)
                .HasDefaultValue(0.0)
                .HasColumnName("remise_fournisseur");
            entity.Property(e => e.StockLimite)
                .HasDefaultValue(false)
                .HasColumnName("stock_limite");
            entity.Property(e => e.Surcommande)
                .HasDefaultValue(false)
                .HasColumnName("surcommande");
            entity.Property(e => e.Test)
                .HasDefaultValue(false)
                .HasColumnName("test");
            entity.Property(e => e.WebOn)
                .HasDefaultValue(false)
                .HasColumnName("web_on");

            entity.HasOne(d => d.IdTArticleDetailNavigation).WithMany(p => p.TArticleVersions)
                .HasForeignKey(d => d.IdTArticleDetail)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_T_Article_version_T_Article_Detail");
        });

        modelBuilder.Entity<TAvoir>(entity =>
        {
            entity.HasKey(e => e.IdTAvoir);

            entity.ToTable("T_Avoir");

            entity.Property(e => e.IdTAvoir).HasColumnName("ID_T_Avoir");
            entity.Property(e => e.ChequeCadeau).HasDefaultValue(false);
            entity.Property(e => e.Commentaire).HasColumnType("ntext");
            entity.Property(e => e.CreeLe)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.CreePar)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.IdTClient).HasColumnName("ID_T_Client");
            entity.Property(e => e.IdTCommandeVente).HasColumnName("ID_T_CommandeVente");
            entity.Property(e => e.ModifieLe)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.ModifiePar)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.UtiliseLe).HasColumnType("datetime");
        });

        modelBuilder.Entity<TClient>(entity =>
        {
            entity.HasKey(e => e.IdTClient);

            entity.ToTable("T_Client", "dbo");

            entity.Property(e => e.IdTClient).HasColumnName("ID_T_Client");
            entity.Property(e => e.Actif).HasDefaultValue(true);
            entity.Property(e => e.AdresseL1)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.AdresseL2)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.AdresseL3)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Ape)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.ChangementMotdePasse)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasDefaultValueSql("((0))");
            entity.Property(e => e.CodePostal)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Commentaires)
                .HasMaxLength(4000)
                .IsUnicode(false);
            entity.Property(e => e.CreeLe)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.CreePar)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Email)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Export).HasDefaultValue(false);
            entity.Property(e => e.ExportFile)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Fax)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.ImportFile)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Kite).HasDefaultValue(false);
            entity.Property(e => e.Mobile)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.ModeReglement)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.ModifieLe)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.ModifiePar)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.NewsLetter).HasDefaultValue(false);
            entity.Property(e => e.NoSiret)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.NoTva)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("NoTVA");
            entity.Property(e => e.Nom)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.NumeroIdentite)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Password)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("password");
            entity.Property(e => e.Pays)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Prenom)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Société)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Sup).HasDefaultValue(false);
            entity.Property(e => e.Tel)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.ToSync).HasDefaultValue(false);
            entity.Property(e => e.Ville)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Wind).HasDefaultValue(false);
        });

        modelBuilder.Entity<TCodeTva>(entity =>
        {
            entity.ToTable("T_code_tva");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Taux).HasColumnName("taux");
        });

        modelBuilder.Entity<TCommandeVente>(entity =>
        {
            entity.HasKey(e => e.IdTCommandeVente);

            entity.ToTable("T_CommandeVente", "dbo");

            entity.Property(e => e.IdTCommandeVente).HasColumnName("ID_T_CommandeVente");
            entity.Property(e => e.AdresseL1)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.AdresseL2)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.AdresseL3)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.AvoirCreeNo).HasDefaultValue(0L);
            entity.Property(e => e.AvoirUtiliseMontant).HasDefaultValue(0.0);
            entity.Property(e => e.AvoirUtiliseNo).HasDefaultValue(0L);
            entity.Property(e => e.CodePostal)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.CommandeWebCaisse)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.CommentairesCommande)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.CommentairesFacture)
                .HasColumnType("ntext")
                .HasColumnName("Commentaires_facture");
            entity.Property(e => e.CreeLe)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.CreePar)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Email)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.ExpedieLe).HasColumnType("datetime");
            entity.Property(e => e.ExpeditionLe).HasColumnType("datetime");
            entity.Property(e => e.ExpeditionNumsuivi)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Export)
                .HasDefaultValue(false)
                .HasColumnName("export");
            entity.Property(e => e.ExportFile)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.FactureLe).HasColumnType("datetime");
            entity.Property(e => e.Fax)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.IdEtatCommandeVente).HasColumnName("ID_EtatCommandeVente");
            entity.Property(e => e.IdTClient).HasColumnName("ID_T_Client");
            entity.Property(e => e.IdTTransporteur).HasColumnName("Id_T_Transporteur");
            entity.Property(e => e.ImportFile)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Mobile)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.ModeReglement)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.ModifieLe)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.ModifiePar)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.MontantArendreTtc)
                .HasDefaultValue(0.0)
                .HasColumnName("MontantARendreTTC");
            entity.Property(e => e.MontantDeduire).HasColumnName("montant_deduire");
            entity.Property(e => e.MontantEncaisseTtc)
                .HasDefaultValue(0.0)
                .HasColumnName("MontantEncaisseTTC");
            entity.Property(e => e.MontantPaiementTtc)
                .HasDefaultValue(0.0)
                .HasColumnName("MontantPaiementTTC");
            entity.Property(e => e.MontantRenduTtc)
                .HasDefaultValue(0.0)
                .HasColumnName("MontantRenduTTC");
            entity.Property(e => e.NoSiret)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.NoTva)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("NoTVA");
            entity.Property(e => e.Nom)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Numcaisse)
                .HasDefaultValue(1)
                .HasColumnName("numcaisse");
            entity.Property(e => e.PayeLe).HasColumnType("datetime");
            entity.Property(e => e.Pays)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Prénom)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.ReferenceCommandePrestashop)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.RenduLe).HasColumnType("datetime");
            entity.Property(e => e.Société)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Tel)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.TicketLe).HasColumnType("datetime");
            entity.Property(e => e.TicketWebCaisse)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Total196).HasColumnName("Total_196");
            entity.Property(e => e.Total55).HasColumnName("Total_55");
            entity.Property(e => e.TotalHt).HasColumnName("Total_HT");
            entity.Property(e => e.TotalTtc).HasColumnName("Total_TTC");
            entity.Property(e => e.TotalTtcAvantDeduction)
                .HasComputedColumnSql("(([Total_HT]+[Total_55])+[Total_196])", false)
                .HasColumnName("Total_TTC_avantDeduction");
            entity.Property(e => e.TvaOn)
                .HasDefaultValue(true)
                .HasColumnName("tva_on");
            entity.Property(e => e.Ville)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.VpcOn)
                .HasDefaultValue(false)
                .HasColumnName("vpc_on");
            entity.Property(e => e.VuAvec)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.WebOn)
                .HasDefaultValue(false)
                .HasColumnName("Web_on");
        });

        modelBuilder.Entity<TCommandeVenteLigne>(entity =>
        {
            entity.HasKey(e => e.IdTCommandeVenteLigne);

            entity.ToTable("T_CommandeVente_Ligne", "dbo");

            entity.Property(e => e.IdTCommandeVenteLigne).HasColumnName("ID_T_CommandeVente_Ligne");
            entity.Property(e => e.ChequeCadeauIdClient).HasDefaultValue(0L);
            entity.Property(e => e.CodeTva).HasColumnName("Code_tva");
            entity.Property(e => e.DepotVente)
                .HasDefaultValue(false)
                .HasColumnName("depot_vente");
            entity.Property(e => e.DescriptionPanier)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("description_panier");
            entity.Property(e => e.IdEtatCommandeVenteLigne).HasColumnName("ID_EtatCommandeVenteLigne");
            entity.Property(e => e.IdTArticleVersion).HasColumnName("ID_t_article_version");
            entity.Property(e => e.IdTCommandeVente).HasColumnName("ID_T_CommandeVente");
            entity.Property(e => e.Occaz)
                .HasDefaultValue(false)
                .HasColumnName("occaz");
            entity.Property(e => e.Poids).HasColumnName("poids");
            entity.Property(e => e.PrixFournisseur)
                .HasColumnType("money")
                .HasColumnName("prix_fournisseur");
            entity.Property(e => e.PrixTotalHt)
                .HasComputedColumnSql("((([prix_vente_initial_TTC]/((1)+[code_tva]/(100)))*((1)-[remise]))*[qte])", false)
                .HasColumnName("prix_total_HT");
            entity.Property(e => e.PrixTotalTtc)
                .HasColumnType("money")
                .HasColumnName("prix_total_TTC");
            entity.Property(e => e.PrixVenteInitialHt)
                .HasComputedColumnSql("([prix_vente_initial_TTC]/((1)+[code_tva]/(100)))", false)
                .HasColumnName("prix_vente_initial_HT");
            entity.Property(e => e.PrixVenteInitialTtc)
                .HasDefaultValue(0m)
                .HasColumnType("money")
                .HasColumnName("prix_vente_initial_TTC");
            entity.Property(e => e.PrixVenteRemiseHt)
                .HasComputedColumnSql("(([prix_vente_initial_TTC]/((1)+[code_tva]/(100)))*((1)-[remise]))", false)
                .HasColumnName("prix_vente_remise_HT");
            entity.Property(e => e.PrixVenteRemiseTtc)
                .HasDefaultValue(0m)
                .HasColumnType("money")
                .HasColumnName("prix_vente_remise_TTC");
            entity.Property(e => e.Remise)
                .HasDefaultValue(0.0)
                .HasColumnName("remise");

            entity.HasOne(d => d.IdTCommandeVenteNavigation).WithMany(p => p.TCommandeVenteLignes)
                .HasForeignKey(d => d.IdTCommandeVente)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_T_CommandeVente_Ligne_T_CommandeVente");
        });

        modelBuilder.Entity<TFamille>(entity =>
        {
            entity.HasKey(e => e.IdTFamille);

            entity.ToTable("T_Famille", "dbo");

            entity.Property(e => e.IdTFamille).HasColumnName("ID_T_Famille");
            entity.Property(e => e.BoutiqueCuber).HasColumnType("ntext");
            entity.Property(e => e.BoutiqueOccasionCuber).HasColumnType("ntext");
            entity.Property(e => e.BoutiqueOccasionTexte).HasColumnType("ntext");
            entity.Property(e => e.BoutiquePromotionCuber).HasColumnType("ntext");
            entity.Property(e => e.BoutiquePromotionTexte).HasColumnType("ntext");
            entity.Property(e => e.BoutiqueTexte).HasColumnType("ntext");
            entity.Property(e => e.ExportFile)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.ImportFile)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Libelle)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Tri).HasColumnName("tri");
        });

        modelBuilder.Entity<TListeCodePortPay>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("T_liste_code_port_pays", "dbo");

            entity.Property(e => e.CodePort)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("Code_port");
            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .HasColumnName("id");
            entity.Property(e => e.Pays)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Prix).HasColumnName("prix");
        });

        modelBuilder.Entity<TLog>(entity =>
        {
            entity.ToTable("T_Log", "dbo");

            entity.Property(e => e.LogAssociatedRecordType).HasMaxLength(20);
            entity.Property(e => e.LogDateTime).HasColumnType("datetime");
            entity.Property(e => e.LogType).HasMaxLength(20);
            entity.Property(e => e.LogVersionApi)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<TParam>(entity =>
        {
            entity.HasKey(e => e.IdTParam);

            entity.ToTable("T_Param", "dbo");

            entity.Property(e => e.IdTParam).HasColumnName("ID_T_Param");
            entity.Property(e => e.Paramname)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("paramname");
            entity.Property(e => e.Paramvalue)
                .IsUnicode(false)
                .HasColumnName("paramvalue");
        });

        modelBuilder.Entity<TPay>(entity =>
        {
            entity.ToTable("T_Pays", "dbo");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Active).HasColumnName("active");
            entity.Property(e => e.CodeIso)
                .HasMaxLength(3)
                .IsUnicode(false);
            entity.Property(e => e.CodePays)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Libelle)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.TvaOn).HasColumnName("tva_on");
        });

        modelBuilder.Entity<TProfil>(entity =>
        {
            entity.HasKey(e => e.IdTProfil);

            entity.ToTable("T_Profil");

            entity.Property(e => e.IdTProfil).HasColumnName("ID_T_Profil");
            entity.Property(e => e.AchatR)
                .HasDefaultValue(false)
                .HasColumnName("Achat_r");
            entity.Property(e => e.AchatW).HasColumnName("Achat_w");
            entity.Property(e => e.Admin)
                .HasDefaultValue(false)
                .HasColumnName("admin");
            entity.Property(e => e.ArticleMag)
                .HasDefaultValue(false)
                .HasColumnName("Article_Mag");
            entity.Property(e => e.ArticleOccazOnly)
                .HasDefaultValue(false)
                .HasColumnName("Article_OccazOnly");
            entity.Property(e => e.ArticleOccazTestOnly)
                .HasDefaultValue(false)
                .HasColumnName("Article_OccazTestOnly");
            entity.Property(e => e.ArticleR)
                .HasDefaultValue(false)
                .HasColumnName("Article_r");
            entity.Property(e => e.ArticleStock)
                .HasDefaultValue(false)
                .HasColumnName("Article_stock");
            entity.Property(e => e.ArticleW)
                .HasDefaultValue(false)
                .HasColumnName("Article_w");
            entity.Property(e => e.ArticleWeb)
                .HasDefaultValue(false)
                .HasColumnName("Article_Web");
            entity.Property(e => e.Libelle)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.MenuActivationWeb)
                .HasDefaultValue(false)
                .HasColumnName("menu_activation_web");
            entity.Property(e => e.Statistiques).HasDefaultValue(false);
            entity.Property(e => e.Transactions).HasDefaultValue(false);
            entity.Property(e => e.VenteR)
                .HasDefaultValue(false)
                .HasColumnName("Vente_r");
            entity.Property(e => e.VenteW)
                .HasDefaultValue(false)
                .HasColumnName("Vente_w");
        });

        modelBuilder.Entity<TReglement>(entity =>
        {
            entity.HasKey(e => e.IdTReglement);

            entity.ToTable("T_Reglement", "dbo", tb => tb.HasTrigger("encaisse_le"));

            entity.Property(e => e.IdTReglement).HasColumnName("Id_T_Reglement");
            entity.Property(e => e.AEncaisser)
                .HasDefaultValue(false)
                .HasColumnName("A_Encaisser");
            entity.Property(e => e.ConditionReglement).HasColumnName("Condition_reglement");
            entity.Property(e => e.EcheanceLe)
                .HasColumnType("datetime")
                .HasColumnName("Echeance_le");
            entity.Property(e => e.EncaisseLe)
                .HasColumnType("datetime")
                .HasColumnName("Encaisse_le");
            entity.Property(e => e.EnregistreLe)
                .HasColumnType("datetime")
                .HasColumnName("Enregistre_le");
            entity.Property(e => e.IdTCommandeVente).HasColumnName("id_t_commande_vente");
            entity.Property(e => e.MoyenPaiement).HasColumnName("Moyen_paiement");
            entity.Property(e => e.ReferenceAvoirBon).HasColumnName("Reference_avoir_bon");

            entity.HasOne(d => d.IdTCommandeVenteNavigation).WithMany(p => p.TReglements)
                .HasForeignKey(d => d.IdTCommandeVente)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_T_Reglement_T_CommandeVente");
        });

        modelBuilder.Entity<TSousFamille>(entity =>
        {
            entity.HasKey(e => e.IdTSousFamille);

            entity.ToTable("T_SousFamille", "dbo");

            entity.Property(e => e.IdTSousFamille).HasColumnName("ID_T_SousFamille");
            entity.Property(e => e.AnneeOn)
                .HasDefaultValue(true)
                .HasColumnName("annee_on");
            entity.Property(e => e.AttributsPrestashop)
                .HasMaxLength(8000)
                .IsUnicode(false);
            entity.Property(e => e.Boitier)
                .HasMaxLength(8000)
                .IsUnicode(false);
            entity.Property(e => e.CaracteristiquesPrestashop)
                .HasMaxLength(8000)
                .IsUnicode(false);
            entity.Property(e => e.Carbone)
                .HasMaxLength(8000)
                .IsUnicode(false);
            entity.Property(e => e.ChampTech)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.ChampTriAttributsPrestashop)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.ChampVersion)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.ChampsObligatoiresMagasin)
                .HasMaxLength(8000)
                .IsUnicode(false);
            entity.Property(e => e.ChampsOptionnels)
                .HasMaxLength(8000)
                .IsUnicode(false);
            entity.Property(e => e.ChampsWeb)
                .HasMaxLength(8000)
                .IsUnicode(false);
            entity.Property(e => e.Colonneweb).HasColumnName("colonneweb");
            entity.Property(e => e.DescriptionModele)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("description_modele");
            entity.Property(e => e.DescriptionPanier)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("description_panier");
            entity.Property(e => e.IdTFamille).HasColumnName("ID_T_Famille");
            entity.Property(e => e.Libelle)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.LibelleListe)
                .HasMaxLength(8000)
                .IsUnicode(false);
            entity.Property(e => e.LibelleTech)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.LibelleVersion)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Marque)
                .HasMaxLength(8000)
                .IsUnicode(false);
            entity.Property(e => e.Poids)
                .HasMaxLength(8000)
                .IsUnicode(false);
            entity.Property(e => e.Programme)
                .HasMaxLength(8000)
                .IsUnicode(false);
            entity.Property(e => e.Rdmtype)
                .HasMaxLength(8000)
                .IsUnicode(false)
                .HasColumnName("RDMType");
            entity.Property(e => e.SousSousFamille)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.SousSousFamille2)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.SousSousFamille3)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.SousSousFamille4)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Taille)
                .HasMaxLength(8000)
                .IsUnicode(false);
            entity.Property(e => e.ToSync).HasColumnName("toSync");
            entity.Property(e => e.Tri).HasColumnName("tri");
            entity.Property(e => e.Type)
                .HasMaxLength(8000)
                .IsUnicode(false);
            entity.Property(e => e.Type2)
                .HasMaxLength(8000)
                .IsUnicode(false);
            entity.Property(e => e.Type3)
                .HasMaxLength(8000)
                .IsUnicode(false);
            entity.Property(e => e.Type4)
                .HasMaxLength(8000)
                .IsUnicode(false);
            entity.Property(e => e.Vignette)
                .HasMaxLength(255)
                .IsUnicode(false);

            entity.HasOne(d => d.IdTFamilleNavigation).WithMany(p => p.TSousFamilles)
                .HasForeignKey(d => d.IdTFamille)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_T_SousFamille_T_Famille");
        });

        modelBuilder.Entity<TUser>(entity =>
        {
            entity.HasKey(e => e.IdTUser);

            entity.ToTable("T_User");

            entity.HasIndex(e => e.CodeBar, "IX_T_User_CodeBar").IsUnique();

            entity.HasIndex(e => e.Login, "IX_T_User_Login").IsUnique();

            entity.Property(e => e.IdTUser).HasColumnName("ID_T_User");
            entity.Property(e => e.CodeBar)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.IdTProfil).HasColumnName("ID_T_Profil");
            entity.Property(e => e.JournalCaisseDeux).HasDefaultValue(false);
            entity.Property(e => e.JournalCaisseUn).HasDefaultValue(false);
            entity.Property(e => e.Login)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Nom)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Password)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Prenom)
                .HasMaxLength(255)
                .IsUnicode(false);

            entity.HasOne(d => d.IdTProfilNavigation).WithMany(p => p.TUsers)
                .HasForeignKey(d => d.IdTProfil)
                .HasConstraintName("FK_T_User_T_Profil");
        });

        modelBuilder.Entity<VArticleStock>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("V_Article_Stock", "dbo");

            entity.Property(e => e.IdTArticleVersion).HasColumnName("ID_t_article_version");
        });

        modelBuilder.Entity<VArticleWeb>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("V_Article_Web", "dbo");

            entity.Property(e => e.ActiveOn).HasColumnName("Active_on");
            entity.Property(e => e.Aileron)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("aileron");
            entity.Property(e => e.Annee)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("annee");
            entity.Property(e => e.Barre)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Boitier)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("boitier");
            entity.Property(e => e.CodePort)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("Code_port");
            entity.Property(e => e.CodeTva).HasColumnName("Code_tva");
            entity.Property(e => e.Colonneweb).HasColumnName("colonneweb");
            entity.Property(e => e.DepotVente).HasColumnName("depot_vente");
            entity.Property(e => e.Description)
                .HasColumnType("ntext")
                .HasColumnName("description");
            entity.Property(e => e.Description2)
                .HasColumnType("ntext")
                .HasColumnName("description2");
            entity.Property(e => e.DescriptionModele)
                .HasMaxLength(767)
                .IsUnicode(false)
                .HasColumnName("description_modele");
            entity.Property(e => e.DescriptionPanier)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("description_panier");
            entity.Property(e => e.Epaisseur)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("epaisseur");
            entity.Property(e => e.Fins)
                .HasMaxLength(53)
                .IsUnicode(false)
                .HasColumnName("fins");
            entity.Property(e => e.Guindant)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("guindant");
            entity.Property(e => e.IdTArticleDetail).HasColumnName("ID_t_article_detail");
            entity.Property(e => e.IdTArticleEntete).HasColumnName("ID_t_article_entete");
            entity.Property(e => e.IdTArticleEnteteLies)
                .IsUnicode(false)
                .HasColumnName("id_t_article_entete_lies");
            entity.Property(e => e.IdTArticleVersion).HasColumnName("ID_t_article_version");
            entity.Property(e => e.IdTClient).HasColumnName("ID_T_Client");
            entity.Property(e => e.IdTFamille).HasColumnName("ID_T_Famille");
            entity.Property(e => e.IdTFournisseur).HasColumnName("ID_T_Fournisseur");
            entity.Property(e => e.IdTSousFamille).HasColumnName("ID_T_SousFamille");
            entity.Property(e => e.Imcs).HasColumnName("IMCS");
            entity.Property(e => e.Largeur)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("largeur");
            entity.Property(e => e.LargeurArriere)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("largeur_arriere");
            entity.Property(e => e.Libelle)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("libelle");
            entity.Property(e => e.LibelleFamille)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.LibelleSousFamille)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Lien)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("lien");
            entity.Property(e => e.Longueur)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("longueur");
            entity.Property(e => e.LongueurLigne).HasColumnName("longueur_ligne");
            entity.Property(e => e.MagasinOn).HasColumnName("magasin_on");
            entity.Property(e => e.Marque)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("marque");
            entity.Property(e => e.Mat)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Modele)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("modele");
            entity.Property(e => e.NombreDeLignes).HasColumnName("nombre_de_lignes");
            entity.Property(e => e.NouveauAu).HasColumnType("datetime");
            entity.Property(e => e.NouveauDu).HasColumnType("datetime");
            entity.Property(e => e.Occaz).HasColumnName("occaz");
            entity.Property(e => e.PhotoBig1)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("photo_big1");
            entity.Property(e => e.PhotoBig2)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("photo_big2");
            entity.Property(e => e.PhotoBig3)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("photo_big3");
            entity.Property(e => e.PhotoMini1)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("photo_mini1");
            entity.Property(e => e.PhotoMini2)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("photo_mini2");
            entity.Property(e => e.PhotoMini3)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("photo_mini3");
            entity.Property(e => e.PhotoModele)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("photo_modele");
            entity.Property(e => e.Poids).HasColumnName("poids");
            entity.Property(e => e.Precommande).HasColumnName("precommande");
            entity.Property(e => e.PrixFournisseur)
                .HasColumnType("money")
                .HasColumnName("prix_fournisseur");
            entity.Property(e => e.PrixVenteInitialTtc)
                .HasColumnType("money")
                .HasColumnName("prix_vente_initial_TTC");
            entity.Property(e => e.PrixVenteRemiseTtc)
                .HasColumnType("money")
                .HasColumnName("prix_vente_remise_TTC");
            entity.Property(e => e.Programme)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("programme");
            entity.Property(e => e.Ratio)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Rdm).HasColumnName("RDM");
            entity.Property(e => e.Rdmtype)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("RDMtype");
            entity.Property(e => e.Reappro).HasColumnName("reappro");
            entity.Property(e => e.RefFournisseur)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("ref_fournisseur");
            entity.Property(e => e.Remise).HasColumnName("remise");
            entity.Property(e => e.SizeMax).HasColumnName("size_max");
            entity.Property(e => e.SizeMin).HasColumnName("size_min");
            entity.Property(e => e.SoldeAu).HasColumnType("datetime");
            entity.Property(e => e.SoldeDu).HasColumnType("datetime");
            entity.Property(e => e.StockLimite).HasColumnName("stock_limite");
            entity.Property(e => e.Surcommande).HasColumnName("surcommande");
            entity.Property(e => e.Surface).HasColumnName("surface");
            entity.Property(e => e.SurfaceVoile)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("surface_voile");
            entity.Property(e => e.Taille)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("taille");
            entity.Property(e => e.Test).HasColumnName("test");
            entity.Property(e => e.TriFamille).HasColumnName("triFamille");
            entity.Property(e => e.TriSoufamille).HasColumnName("triSoufamille");
            entity.Property(e => e.Type).HasMaxLength(255);
            entity.Property(e => e.Type2)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("type2");
            entity.Property(e => e.Type3)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("type3");
            entity.Property(e => e.WebOn).HasColumnName("web_on");
            entity.Property(e => e.Wishbone)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("wishbone");
            entity.Property(e => e._5emeLigne).HasColumnName("5eme_ligne");
        });

        modelBuilder.Entity<VLog>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("V_Log");

            entity.Property(e => e.Id).ValueGeneratedOnAdd();
            entity.Property(e => e.LogAssociatedRecordType).HasMaxLength(20);
            entity.Property(e => e.LogDateTime).HasColumnType("datetime");
            entity.Property(e => e.LogType).HasMaxLength(20);
            entity.Property(e => e.LogVersionApi)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Rn).HasColumnName("rn");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
