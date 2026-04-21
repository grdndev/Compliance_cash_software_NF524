using System;
using System.Collections.Generic;

namespace CLICore.Models;

public partial class TReglement
{
    public long IdTReglement { get; set; }

    public long? ConditionReglement { get; set; }

    public long? MoyenPaiement { get; set; }

    public double? Montant { get; set; }

    public long? ReferenceAvoirBon { get; set; }

    public DateTime? EnregistreLe { get; set; }

    public DateTime? EcheanceLe { get; set; }

    public DateTime? EncaisseLe { get; set; }

    public bool? AEncaisser { get; set; }

    public long? IdTCommandeVente { get; set; }

    public virtual TCommandeVente? IdTCommandeVenteNavigation { get; set; }
}
