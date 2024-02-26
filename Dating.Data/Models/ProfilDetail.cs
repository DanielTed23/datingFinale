using System;
using System.Collections.Generic;

namespace Dating.Data.Models;

public partial class ProfilDetail
{
    public int Id { get; set; }

    public int ProfilId { get; set; }

    public double? Height { get; set; }

    public double? Weight { get; set; }

    public string? ProfilText { get; set; }

    public virtual Profil Profil { get; set; } = null!;
}
