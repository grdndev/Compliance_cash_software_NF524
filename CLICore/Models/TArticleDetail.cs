using System;
using System.Collections.Generic;

namespace CLICore.Models;

public partial class TArticleDetail
{
    public long IdTArticleDetail { get; set; }

    public long? IdTArticleEntete { get; set; }

    public double? Surface { get; set; }

    public string? Guindant { get; set; }

    public string? Wishbone { get; set; }

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

    public string? Matiere { get; set; }

    public string? Programme { get; set; }

    public string? Type { get; set; }

    public string? CreePar { get; set; }

    public DateTime? CreeLe { get; set; }

    public string? ModifiePar { get; set; }

    public DateTime? ModifieLe { get; set; }

    public string? Carbone { get; set; }

    public string? Rdmtype { get; set; }

    public string? Type2 { get; set; }

    public string? Type3 { get; set; }

    public string? Type4 { get; set; }

    public double? FoilSurfaceAileAvant { get; set; }

    public double? FoilSurfaceAileArriere { get; set; }

    public double? FoilLongueurMat { get; set; }

    public double? FoilLongueurFuselage { get; set; }

    public string? FoilBoitier { get; set; }

    public virtual TArticleEntete? IdTArticleEnteteNavigation { get; set; }

    public virtual ICollection<TArticleVersion> TArticleVersions { get; set; } = new List<TArticleVersion>();
}
