using System;
using System.Collections.Generic;

namespace CLICore.Models;

public partial class TArticleVersion
{
    public long IdTArticleVersion { get; set; }

    public long? IdTArticleDetail { get; set; }

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

    public string? CreePar { get; set; }

    public DateTime? CreeLe { get; set; }

    public string? ModifiePar { get; set; }

    public DateTime? ModifieLe { get; set; }

    public bool? DescriptionAuto { get; set; }

    public bool? Surcommande { get; set; }

    public decimal? PrixRemiseFournisseur { get; set; }

    public double? RemiseFournisseur { get; set; }

    public string? Commentaires { get; set; }

    public decimal? AutoRemisePrixVenteInitialTtc { get; set; }

    public decimal? AutoRemisePrixVenteRemiseTtc { get; set; }

    public double? AutoRemiseRemise { get; set; }

    public bool? Test { get; set; }

    public string? ImportFile { get; set; }

    public string? ExportFile { get; set; }

    public string? ImportStockFile { get; set; }

    public string? ExportStockFile { get; set; }

    public virtual TArticleDetail? IdTArticleDetailNavigation { get; set; }

    public virtual ICollection<TArticleStock> TArticleStocks { get; set; } = new List<TArticleStock>();
}
