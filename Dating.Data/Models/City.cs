using System;
using System.Collections.Generic;

namespace Dating.Data.Models;

public partial class City
{
    public int Id { get; set; }

    public string CityName { get; set; } = null!;

    public virtual ICollection<Profil> Profils { get; set; } = new List<Profil>();
}
