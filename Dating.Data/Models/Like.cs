using System;
using System.Collections.Generic;

namespace Dating.Data.Models;

public partial class Like
{
    public int Id { get; set; }

    public int FromProfilId { get; set; }

    public int ToProfilId { get; set; }

    public int IsMutual { get; set; }

    public virtual Profil FromProfil { get; set; } = null!;

    public virtual Profil ToProfil { get; set; } = null!;
}
