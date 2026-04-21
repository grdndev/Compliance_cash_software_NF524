using System;
using System.Collections.Generic;

namespace CLICore.Models;

public partial class TCommandeVenteLigne
{
    public long IdTCommandeVenteLigne { get; set; }

    public long? IdTCommandeVente { get; set; }

    public long IdTArticleVersion { get; set; }

    public double? Qte { get; set; }

    public decimal? PrixVenteInitialTtc { get; set; }

    public decimal? PrixVenteRemiseTtc { get; set; }

    public double? Remise { get; set; }

    public decimal? PrixTotalTtc { get; set; }

    public decimal? PrixFournisseur { get; set; }

    public double? CodeTva { get; set; }

    public string? DescriptionPanier { get; set; }

    public double? Poids { get; set; }

    public long? IdEtatCommandeVenteLigne { get; set; }

    public bool? Occaz { get; set; }

    public bool? DepotVente { get; set; }

    public long? ChequeCadeauIdClient { get; set; }

    public double? PrixVenteInitialHt { get; set; }

    public double? PrixVenteRemiseHt { get; set; }

    public double? PrixTotalHt { get; set; }

    public virtual TCommandeVente? IdTCommandeVenteNavigation { get; set; }
}
