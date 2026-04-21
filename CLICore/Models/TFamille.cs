using System;
using System.Collections.Generic;

namespace CLICore.Models;

public partial class TFamille
{
    public long IdTFamille { get; set; }

    public string? Libelle { get; set; }

    public long? Tri { get; set; }

    public string? BoutiqueTexte { get; set; }

    public string? BoutiqueCuber { get; set; }

    public string? BoutiqueOccasionTexte { get; set; }

    public string? BoutiqueOccasionCuber { get; set; }

    public string? BoutiquePromotionTexte { get; set; }

    public string? BoutiquePromotionCuber { get; set; }

    public string? ImportFile { get; set; }

    public string? ExportFile { get; set; }

    public virtual ICollection<TSousFamille> TSousFamilles { get; set; } = new List<TSousFamille>();
}
