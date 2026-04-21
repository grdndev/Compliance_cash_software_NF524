using System;
using System.Collections.Generic;

namespace CLICore.Models;

public partial class TSousFamille
{
    public long IdTSousFamille { get; set; }

    public long? IdTFamille { get; set; }

    public string? Libelle { get; set; }

    public long? Tri { get; set; }

    public bool? AnneeOn { get; set; }

    public string? DescriptionPanier { get; set; }

    public string? DescriptionModele { get; set; }

    public string? ChampsObligatoiresMagasin { get; set; }

    public string? ChampsWeb { get; set; }

    public string? ChampsOptionnels { get; set; }

    public string? LibelleTech { get; set; }

    public string? ChampTech { get; set; }

    public string? LibelleVersion { get; set; }

    public string? ChampVersion { get; set; }

    public string? Marque { get; set; }

    public string? Programme { get; set; }

    public string? Type { get; set; }

    public string? Poids { get; set; }

    public string? Boitier { get; set; }

    public string? Taille { get; set; }

    public string? Carbone { get; set; }

    public long? Colonneweb { get; set; }

    public string? Rdmtype { get; set; }

    public string? Type2 { get; set; }

    public string? Type3 { get; set; }

    public string? Vignette { get; set; }

    public string? LibelleListe { get; set; }

    public string? CaracteristiquesPrestashop { get; set; }

    public string? AttributsPrestashop { get; set; }

    public string? SousSousFamille { get; set; }

    public string? SousSousFamille2 { get; set; }

    public string? SousSousFamille3 { get; set; }

    public string? SousSousFamille4 { get; set; }

    public string? ChampTriAttributsPrestashop { get; set; }

    public bool ToSync { get; set; }

    public string? Type4 { get; set; }

    public virtual TFamille? IdTFamilleNavigation { get; set; }

    public virtual ICollection<TArticleEntete> TArticleEntetes { get; set; } = new List<TArticleEntete>();
}
