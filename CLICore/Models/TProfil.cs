using System;
using System.Collections.Generic;

namespace CLICore.Models;

public partial class TProfil
{
    public long IdTProfil { get; set; }

    public string? Libelle { get; set; }

    public bool? Admin { get; set; }

    public bool? VenteR { get; set; }

    public bool? VenteW { get; set; }

    public bool? AchatR { get; set; }

    public bool? AchatW { get; set; }

    public bool? ArticleR { get; set; }

    public bool? ArticleW { get; set; }

    public bool? ArticleStock { get; set; }

    public bool? ArticleOccazOnly { get; set; }

    public bool? ArticleWeb { get; set; }

    public bool? ArticleMag { get; set; }

    public bool? Statistiques { get; set; }

    public bool? Transactions { get; set; }

    public bool? MenuActivationWeb { get; set; }

    public bool? PrixStock { get; set; }

    public bool? ArticleOccazTestOnly { get; set; }

    public virtual ICollection<TUser> TUsers { get; set; } = new List<TUser>();
}
