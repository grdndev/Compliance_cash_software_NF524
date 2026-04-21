using System;
using System.Collections.Generic;

namespace CLICore.Models;

public partial class VLog
{
    public long Id { get; set; }

    public DateTime? LogDateTime { get; set; }

    public string? LogEntry { get; set; }

    public string? LogDetail { get; set; }

    public long? LogAssociatedRecordId { get; set; }

    public string? LogAssociatedRecordType { get; set; }

    public string? LogType { get; set; }

    public string? LogVersionApi { get; set; }

    public string? Errors { get; set; }

    public long? Rn { get; set; }
}
