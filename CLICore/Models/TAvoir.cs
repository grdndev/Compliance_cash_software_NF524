using System;
using System.Collections.Generic;

namespace CLICore.Models;

public partial class TAvoir
{
    public long IdTAvoir { get; set; }

    public long? IdTClient { get; set; }

    public long IdTCommandeVente { get; set; }

    public double? Montant { get; set; }

    public string? Commentaire { get; set; }

    public string? CreePar { get; set; }

    public DateTime? CreeLe { get; set; }

    public string? ModifiePar { get; set; }

    public DateTime? ModifieLe { get; set; }

    public DateTime? UtiliseLe { get; set; }

    public bool? ChequeCadeau { get; set; }

    public long? IdCartRulePrestashop { get; set; }
}
