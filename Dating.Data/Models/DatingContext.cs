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

    public virtual DbSet<Account> Accounts { get; set; }

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
        modelBuilder.Entity<Account>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Account__3214EC07B1A3C8A8");

            entity.ToTable("Account");

            entity.HasIndex(e => e.UserName, "UQ__Account__C9F28456A16BBCA3").IsUnique();

            entity.Property(e => e.Password).HasMaxLength(50);
            entity.Property(e => e.UserName).HasMaxLength(50);
        });

        modelBuilder.Entity<City>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__City__3214EC077D787EC2");

            entity.ToTable("City");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.CityName).HasMaxLength(50);
        });

        modelBuilder.Entity<Like>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Like__3214EC07CB5B5426");

            entity.ToTable("Like");

            entity.HasOne(d => d.FromProfil).WithMany(p => p.LikeFromProfils)
                .HasForeignKey(d => d.FromProfilId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Like_FromProfil");

            entity.HasOne(d => d.ToProfil).WithMany(p => p.LikeToProfils)
                .HasForeignKey(d => d.ToProfilId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Like_ToProfil");
        });

        modelBuilder.Entity<Message>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Message__3214EC0752C66F83");

            entity.ToTable("Message");

            entity.Property(e => e.MessageText).HasMaxLength(250);
            entity.Property(e => e.SentDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");

            entity.HasOne(d => d.FromProfil).WithMany(p => p.MessageFromProfils)
                .HasForeignKey(d => d.FromProfilId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Message_FromProfil");

            entity.HasOne(d => d.ToProfil).WithMany(p => p.MessageToProfils)
                .HasForeignKey(d => d.ToProfilId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Message_ToProfil");
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
