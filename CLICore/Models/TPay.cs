using System;
using System.Collections.Generic;

namespace CLICore.Models;

public partial class TPay
{
    public long Id { get; set; }

    public string? Libelle { get; set; }

    public bool? Active { get; set; }

    public bool? TvaOn { get; set; }

    public string? CodePays { get; set; }

    public string? CodeIso { get; set; }
}
