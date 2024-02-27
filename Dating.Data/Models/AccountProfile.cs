using System;
using System.Collections.Generic;

namespace Dating.Data.Models;

public partial class AccountProfile
{
    public int Id { get; set; }

    public string UserName { get; set; } = null!;

    public string Password { get; set; } = null!;

    public int? IsDeleted { get; set; }

    public virtual Profil? Profil { get; set; }
}
