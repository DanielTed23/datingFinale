using System;
using System.Collections.Generic;

namespace Dating.Data.Models;

public partial class Profil
{
    public int Id { get; set; }

    public int AccountId { get; set; }

    public int CityId { get; set; }

    public string ProfilName { get; set; } = null!;

    public DateOnly Birthdate { get; set; }

    public string? Gender { get; set; }

    public virtual Account Account { get; set; } = null!;

    public virtual City City { get; set; } = null!;

    public virtual ICollection<Like> LikeFromProfils { get; set; } = new List<Like>();

    public virtual ICollection<Like> LikeToProfils { get; set; } = new List<Like>();

    public virtual ICollection<Message> MessageFromProfils { get; set; } = new List<Message>();

    public virtual ICollection<Message> MessageToProfils { get; set; } = new List<Message>();

    public virtual ProfilDetail? ProfilDetail { get; set; }
}
