using System;
using System.Collections.Generic;

namespace Dating.Data.Models;

public partial class Message
{
    public int Id { get; set; }

    public int FromProfilId { get; set; }

    public int ToProfilId { get; set; }

    public string MessageText { get; set; } = null!;

    public DateTime SentDate { get; set; }

    public virtual Profil FromProfil { get; set; } = null!;

    public virtual Profil ToProfil { get; set; } = null!;
}
