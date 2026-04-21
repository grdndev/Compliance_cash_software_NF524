using System;
using System.Collections.Generic;

namespace CLICore.Models;

public partial class TArticleEntete
{
    public long IdTArticleEntete { get; set; }

    public long? IdTSousfamille { get; set; }

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

    public string? CreePar { get; set; }

    public DateTime? CreeLe { get; set; }

    public string? ModifiePar { get; set; }

    public DateTime? ModifieLe { get; set; }

    public DateTime? SoldeDu { get; set; }

    public DateTime? SoldeAu { get; set; }

    public DateTime? NouveauDu { get; set; }

    public DateTime? NouveauAu { get; set; }

    public DateTime? RemiseAutoDu { get; set; }

    public DateTime? RemiseAutoAu { get; set; }

    public double? RemiseAuto { get; set; }

    public string? IdTArticleEnteteLies { get; set; }

    public virtual TSousFamille? IdTSousfamilleNavigation { get; set; }

    public virtual ICollection<TArticleDetail> TArticleDetails { get; set; } = new List<TArticleDetail>();
}
