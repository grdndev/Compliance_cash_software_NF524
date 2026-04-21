using System;
using System.Collections.Generic;

namespace CLICore.Models;

public partial class TCodeTva
{
    public long Id { get; set; }

    public double? Taux { get; set; }

    public long? IdTaxPrestashop { get; set; }
}
