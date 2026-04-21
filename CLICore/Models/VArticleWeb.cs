using System;
using System.Collections.Generic;

namespace CLICore.Models;

public partial class VArticleWeb
{
    public string? LibelleFamille { get; set; }

    public long? TriFamille { get; set; }

    public string? LibelleSousFamille { get; set; }

    public long? TriSoufamille { get; set; }

    public long IdTArticleEntete { get; set; }

    public string? PhotoModele { get; set; }

    public string? PhotoMini1 { get; set; }

    public string? PhotoMini2 { get; set; }

    public string? PhotoMini3 { get; set; }

    public string? PhotoBig1 { get; set; }

    public string? PhotoBig2 { get; set; }

    public string? PhotoBig3 { get; set; }

    public string? Annee { get; set; }

    public string? Marque { get; set; }

    public string? Modele { get; set; }

    public string? Description { get; set; }

    public string? Description2 { get; set; }

    public string? Lien { get; set; }

    public string? CodePort { get; set; }

    public double? CodeTva { get; set; }

    public long IdTArticleDetail { get; set; }

    public double? Surface { get; set; }

    public string? Wishbone { get; set; }

    public string? Guindant { get; set; }

    public string? Mat { get; set; }

    public int? Lattes { get; set; }

    public int? Cam { get; set; }

    public string? Longueur { get; set; }

    public string? Largeur { get; set; }

    public string? LargeurArriere { get; set; }

    public string? Boitier { get; set; }

    public string? Aileron { get; set; }

    public string? SurfaceVoile { get; set; }

    public double? Volume { get; set; }

    public double? NombreDeLignes { get; set; }

    public bool? _5emeLigne { get; set; }

    public string? Ratio { get; set; }

    public string? Barre { get; set; }

    public double? LongueurLigne { get; set; }

    public string? Fins { get; set; }

    public string? Taille { get; set; }

    public string? Epaisseur { get; set; }

    public double? Imcs { get; set; }

    public bool? Rdm { get; set; }

    public double? SizeMin { get; set; }

    public double? SizeMax { get; set; }

    public string? Programme { get; set; }

    public string? Type { get; set; }

    public long IdTArticleVersion { get; set; }

    public string? RefFournisseur { get; set; }

    public decimal? PrixVenteInitialTtc { get; set; }

    public decimal? PrixVenteRemiseTtc { get; set; }

    public double? Remise { get; set; }

    public decimal? PrixFournisseur { get; set; }

    public double? Poids { get; set; }

    public string? Libelle { get; set; }

    public string? DescriptionPanier { get; set; }

    public bool? StockLimite { get; set; }

    public bool? Occaz { get; set; }

    public bool? DepotVente { get; set; }

    public bool? Reappro { get; set; }

    public bool? Precommande { get; set; }

    public bool? WebOn { get; set; }

    public bool? MagasinOn { get; set; }

    public bool? ActiveOn { get; set; }

    public long? IdTFournisseur { get; set; }

    public long? IdTClient { get; set; }

    public long IdTSousFamille { get; set; }

    public long IdTFamille { get; set; }

    public bool? Surcommande { get; set; }

    public DateTime? NouveauDu { get; set; }

    public DateTime? NouveauAu { get; set; }

    public DateTime? SoldeDu { get; set; }

    public DateTime? SoldeAu { get; set; }

    public long? Colonneweb { get; set; }

    public double? Stock { get; set; }

    public string? DescriptionModele { get; set; }

    public bool? Test { get; set; }

    public string? IdTArticleEnteteLies { get; set; }

    public string? Rdmtype { get; set; }

    public string? Type2 { get; set; }

    public string? Type3 { get; set; }
}
