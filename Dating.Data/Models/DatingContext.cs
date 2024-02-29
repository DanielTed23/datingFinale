using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Dating.Data.Models;

public partial class DatingContext : DbContext
{
    public DatingContext()
    {
    }

    public DatingContext(DbContextOptions<DatingContext> options)
        : base(options)
    {
    }

    public virtual DbSet<AccountProfile> Accounts { get; set; }

    public virtual DbSet<City> Cities { get; set; }

    public virtual DbSet<Like> Likes { get; set; }

    public virtual DbSet<Message> Messages { get; set; }

    public virtual DbSet<Profil> Profils { get; set; }

    public virtual DbSet<ProfilDetail> ProfilDetails { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=dating;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Definerer en entitet konfiguration for AccountProfile klassen.
        modelBuilder.Entity<AccountProfile>(entity =>
        {
            // Angiver at egenskaben 'Id' er primærnøglen for AccountProfile entiteten.
            // 'HasName' metoden angiver navnet på den primære nøgle begrænsning i databasen.
            entity.HasKey(e => e.Id).HasName("PK__Account__3214EC07B1A3C8A8");

            // Mapper AccountProfile klassen til en tabel med navnet 'Account' i databasen.
            entity.ToTable("Account");

            // Opretter et unikt indeks for 'UserName' egenskaben for at sikre,
            // at brugernavne er unikke i 'Account' tabellen.
            entity.HasIndex(e => e.UserName, "UQ__Account__C9F28456A16BBCA3").IsUnique();

            // Definerer maksimal længde af 'Password' egenskaben til 50 tegn.
            entity.Property(e => e.Password).HasMaxLength(50);

            // Definerer maksimal længde af 'UserName' egenskaben til 50 tegn.
            entity.Property(e => e.UserName).HasMaxLength(50);
        });
        // Konfigurerer 'City' entiteten i modellen.
        modelBuilder.Entity<City>(entity =>
        {
            // Angiver at 'Id' egenskaben er primærnøglen for 'City' entiteten.
            // 'HasName' metoden angiver navnet på den primære nøglebegrænsning i databasen.
            entity.HasKey(e => e.Id).HasName("PK__City__3214EC077D787EC2");

            // Mapper 'City' klassen til en tabel med navnet 'City' i databasen.
            entity.ToTable("City");

            // Angiver at 'Id' egenskaben ikke automatisk genereres af databasen.
            // Dette betyder, at du skal angive 'Id' værdien manuelt, når du opretter en ny 'City'.
            entity.Property(e => e.Id).ValueGeneratedNever();

            // Definerer maksimal længde af 'CityName' egenskaben til 50 tegn.
            entity.Property(e => e.CityName).HasMaxLength(50);
        });

        // Konfigurerer 'Like' entiteten i modellen.
        modelBuilder.Entity<Like>(entity =>
        {
            // Angiver at 'Id' egenskaben er primærnøglen for 'Like' entiteten.
            // 'HasName' metoden angiver navnet på den primære nøglebegrænsning i databasen.
            entity.HasKey(e => e.Id).HasName("PK__Like__3214EC07CB5B5426");

            // Mapper 'Like' klassen til en tabel med navnet 'Like' i databasen.
            entity.ToTable("Like");

            // Konfigurerer relationen mellem 'Like' og 'Profil' entiteter.
            // Angiver at hver 'Like' entitet har én 'FromProfil' (den profil, der giver et 'like').
            entity.HasOne(d => d.FromProfil)
                .WithMany(p => p.LikeFromProfils) // En 'Profil' kan have mange 'Likes' fra.
                .HasForeignKey(d => d.FromProfilId) // Angiver den fremmednøgle, der forbinder til 'FromProfil'.
                .OnDelete(DeleteBehavior.ClientSetNull) // Angiver, at hvis 'Profil' slettes, sættes fremmednøglen i 'Like' til null.
                .HasConstraintName("FK_Like_FromProfil"); // Angiver navnet på fremmednøglebegrænsningen.

            // Lignende konfiguration for 'ToProfil' (den profil, der modtager et 'like').
            entity.HasOne(d => d.ToProfil)
                .WithMany(p => p.LikeToProfils) // En 'Profil' kan have mange 'Likes' til.
                .HasForeignKey(d => d.ToProfilId) // Angiver den fremmednøgle, der forbinder til 'ToProfil'.
                .OnDelete(DeleteBehavior.ClientSetNull) // Angiver, at hvis 'Profil' slettes, sættes fremmednøglen i 'Like' til null.
                .HasConstraintName("FK_Like_ToProfil"); // Angiver navnet på fremmednøglebegrænsningen.
        });


        // Konfigurerer 'Message' entiteten i modellen.
        modelBuilder.Entity<Message>(entity =>
        {
            // Angiver at 'Id' egenskaben er primærnøglen for 'Message' entiteten.
            // 'HasName' metoden angiver navnet på den primære nøglebegrænsning i databasen.
            entity.HasKey(e => e.Id).HasName("PK__Message__3214EC0752C66F83");

            // Mapper 'Message' klassen til en tabel med navnet 'Message' i databasen.
            entity.ToTable("Message");

            // Definerer egenskaben 'MessageText' med en maksimal længde på 250 tegn.
            entity.Property(e => e.MessageText).HasMaxLength(250);

            // Definerer egenskaben 'SentDate' og angiver standardværdien til det aktuelle tidspunkt
            // ved brug af SQL funktionen 'getdate()'. Angiver også typen til 'datetime'.
            entity.Property(e => e.SentDate)
                 .HasDefaultValueSql("(getdate())")
                 .HasColumnType("datetime");

            // Konfigurerer en en-til-mange relation mellem 'Message' og 'Profil' entiteter,
            // hvor 'FromProfil' angiver, hvem der sender beskeden. Hver 'Profil' kan have sendt mange 'Messages'.
            entity.HasOne(d => d.FromProfil).WithMany(p => p.MessageFromProfils)
                 .HasForeignKey(d => d.FromProfilId) // Angiver den fremmednøgle, der forbinder til 'FromProfil'.
                 .OnDelete(DeleteBehavior.ClientSetNull) // Hvis 'Profil' slettes, sættes fremmednøglen i 'Message' til null.
                 .HasConstraintName("FK_Message_FromProfil"); // Angiver navnet på fremmednøglebegrænsningen.

            // Konfigurerer en en-til-mange relation mellem 'Message' og 'Profil' for 'ToProfil',
            // hvilket angiver, hvem der modtager beskeden. Hver 'Profil' kan have modtaget mange 'Messages'.
            entity.HasOne(d => d.ToProfil).WithMany(p => p.MessageToProfils)
                 .HasForeignKey(d => d.ToProfilId) // Angiver den fremmednøgle, der forbinder til 'ToProfil'.
                 .OnDelete(DeleteBehavior.ClientSetNull) // Hvis 'Profil' slettes, sættes fremmednøglen i 'Message' til null.
                 .HasConstraintName("FK_Message_ToProfil"); // Angiver navnet på fremmednøglebegrænsningen.
        });
                                

        modelBuilder.Entity<Profil>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Profil__3214EC07B31F36A2");

            entity.ToTable("Profil");

            entity.HasIndex(e => e.AccountId, "UQ__Profil__349DA5A7D6FD6A8B").IsUnique();

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Gender).HasMaxLength(50);
            entity.Property(e => e.ProfilName).HasMaxLength(50);

            entity.HasOne(d => d.Account).WithOne(p => p.Profil)
                .HasForeignKey<Profil>(d => d.AccountId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Profil_Account");

            entity.HasOne(d => d.City).WithMany(p => p.Profils)
                .HasForeignKey(d => d.CityId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Profil_City");
        });

        modelBuilder.Entity<ProfilDetail>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__ProfilDe__3214EC079BD4DCDF");

            entity.ToTable("ProfilDetail");

            entity.HasIndex(e => e.ProfilId, "UQ__ProfilDe__5E0A2DBC117D2639").IsUnique();

            entity.Property(e => e.ProfilText).HasMaxLength(250);

            entity.HasOne(d => d.Profil).WithOne(p => p.ProfilDetail)
                .HasForeignKey<ProfilDetail>(d => d.ProfilId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ProfilDetail_Profil");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
