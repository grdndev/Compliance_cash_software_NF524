using System;
using System.Collections.Generic;

namespace CLICore.Models;

public partial class TApiCall
{
    public long Id { get; set; }

    public DateTime? CreatedDate { get; set; }

    public string? Url { get; set; }

    public string? Params { get; set; }

    public string? HttpMethod { get; set; }

    public DateTime? CallDate { get; set; }
}
