using System;
using System.Collections.Generic;

namespace CLICore.Models;

public partial class TUser
{
    public long IdTUser { get; set; }

    public string Nom { get; set; } = null!;

    public string? Prenom { get; set; }

    public string Login { get; set; } = null!;

    public string Password { get; set; } = null!;

    public long IdTProfil { get; set; }

    public bool Actif { get; set; }

    public string CodeBar { get; set; } = null!;

    public bool? JournalCaisseUn { get; set; }

    public bool? JournalCaisseDeux { get; set; }

    public virtual TProfil IdTProfilNavigation { get; set; } = null!;
}
