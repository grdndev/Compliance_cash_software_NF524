using System;
using System.Collections.Generic;

namespace CLICore.Models;

public partial class TClient
{
    public long IdTClient { get; set; }

    public string? Société { get; set; }

    public string? Nom { get; set; }

    public string? Prenom { get; set; }

    public string? AdresseL1 { get; set; }

    public string? AdresseL2 { get; set; }

    public string? AdresseL3 { get; set; }

    public string? CodePostal { get; set; }

    public string? Ville { get; set; }

    public string? Pays { get; set; }

    public string? Tel { get; set; }

    public string? Fax { get; set; }

    public string? Mobile { get; set; }

    public string? Email { get; set; }

    public string? ModeReglement { get; set; }

    public bool? Actif { get; set; }

    public string? CreePar { get; set; }

    public DateTime? CreeLe { get; set; }

    public string? ModifiePar { get; set; }

    public DateTime? ModifieLe { get; set; }

    public string? Password { get; set; }

    public bool? NewsLetter { get; set; }

    public string? NumeroIdentite { get; set; }

    public string? NoTva { get; set; }

    public string? NoSiret { get; set; }

    public string? Commentaires { get; set; }

    public string? ChangementMotdePasse { get; set; }

    public DateOnly? Datenaissance { get; set; }

    public bool? Wind { get; set; }

    public bool? Kite { get; set; }

    public bool? Sup { get; set; }

    public string? ImportFile { get; set; }

    public string? ExportFile { get; set; }

    public bool? Export { get; set; }

    public long? IdCustomerPrestashop { get; set; }

    public long? Titre { get; set; }

    public string? Ape { get; set; }

    public bool? ToSync { get; set; }
}
