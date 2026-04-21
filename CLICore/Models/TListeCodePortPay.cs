using System;
using System.Collections.Generic;

namespace CLICore.Models;

public partial class TListeCodePortPay
{
    public long Id { get; set; }

    public string? Pays { get; set; }

    public string? CodePort { get; set; }

    public double? Prix { get; set; }
}
