using System;
using System.Collections.Generic;

namespace CLICore.Models;

public partial class TAdresse
{
    public long IdTAdresse { get; set; }

    public long? IdTClient { get; set; }

    public string? Libelle { get; set; }

    public string? Société { get; set; }

    public string? Nom { get; set; }

    public string? Prenom { get; set; }

    public string? AdresseL1 { get; set; }

    public string? AdresseL2 { get; set; }

    public string? AdresseL3 { get; set; }

    public string? CodePostal { get; set; }

    public string? Ville { get; set; }

    public string? Pays { get; set; }

    public long? IdAddressPrestashop { get; set; }

    public string? Tel { get; set; }

    public string? Mobile { get; set; }

    public string? NumeroIdentite { get; set; }

    public string? Autre { get; set; }

    public string? NoTva { get; set; }

    public string? CreePar { get; set; }

    public string? ModifiePar { get; set; }

    public DateTime? CreeLe { get; set; }

    public DateTime? ModifieLe { get; set; }
}
