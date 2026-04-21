using System;
using System.Collections.Generic;

namespace CLICore.Models;

public partial class TArticleStock
{
    public long IdTArticleStock { get; set; }

    public long IdTArticleVersion { get; set; }

    public double? Operation { get; set; }

    public long? IdTCommandeVente { get; set; }

    public long? IdTCommandeAchat { get; set; }

    public string? Signature { get; set; }

    public DateTime? Date { get; set; }

    public int? Numcaisse { get; set; }

    public virtual TArticleVersion IdTArticleVersionNavigation { get; set; } = null!;
}
