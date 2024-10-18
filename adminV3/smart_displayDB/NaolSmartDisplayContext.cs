using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace adminV3.smart_displayDB;

public partial class NaolSmartDisplayContext : DbContext
{
    public NaolSmartDisplayContext()
    {
    }

    public NaolSmartDisplayContext(DbContextOptions<NaolSmartDisplayContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Afficheur> Afficheurs { get; set; }

    public virtual DbSet<Batiment> Batiments { get; set; }

    public virtual DbSet<Co2> Co2s { get; set; }

    public virtual DbSet<DateImportante> DateImportantes { get; set; }

    public virtual DbSet<Luminosite> Luminosites { get; set; }

    public virtual DbSet<OffresProfessionnelle> OffresProfessionnelles { get; set; }

    public virtual DbSet<Salle> Salles { get; set; }

    public virtual DbSet<Temperature> Temperatures { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseMySql("server=mysql-naol.alwaysdata.net;port=3306;user=naol;password=estenaolthomas2005;database=naol_smart_display", Microsoft.EntityFrameworkCore.ServerVersion.Parse("10.11.8-mariadb"));

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_general_ci")
            .HasCharSet("utf8mb4");

        modelBuilder.Entity<Afficheur>(entity =>
        {
            entity.HasKey(e => e.Idcapteur).HasName("PRIMARY");

            entity.ToTable("Afficheur");

            entity.HasIndex(e => e.SalleIdsalle, "fk_Afficheur_salle1_idx");

            entity.Property(e => e.Idcapteur)
                .HasColumnType("int(11)")
                .HasColumnName("idcapteur");
            entity.Property(e => e.DateInstall).HasColumnName("Date_Install");
            entity.Property(e => e.SalleIdsalle)
                .HasColumnType("int(11)")
                .HasColumnName("salle_idsalle");

            entity.HasOne(d => d.SalleIdsalleNavigation).WithMany(p => p.Afficheurs)
                .HasForeignKey(d => d.SalleIdsalle)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_Afficheur_salle1_new");
        });

        modelBuilder.Entity<Batiment>(entity =>
        {
            entity.HasKey(e => e.Idbatiment).HasName("PRIMARY");

            entity.ToTable("batiment");

            entity.Property(e => e.Idbatiment)
                .HasColumnType("int(11)")
                .HasColumnName("idbatiment");
            entity.Property(e => e.Nom)
                .HasMaxLength(45)
                .HasColumnName("nom");
        });

        modelBuilder.Entity<Co2>(entity =>
        {
            entity.HasKey(e => e.IdCo2).HasName("PRIMARY");

            entity.ToTable("CO2");

            entity.HasIndex(e => e.AfficheurIdcapteur, "fk_CO2_Afficheur1_idx");

            entity.Property(e => e.IdCo2)
                .HasColumnType("int(11)")
                .HasColumnName("IdCO2");
            entity.Property(e => e.AfficheurIdcapteur)
                .HasColumnType("int(11)")
                .HasColumnName("Afficheur_idcapteur");
            entity.Property(e => e.Valeur).HasMaxLength(45);

            entity.HasOne(d => d.AfficheurIdcapteurNavigation).WithMany(p => p.Co2s)
                .HasForeignKey(d => d.AfficheurIdcapteur)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_CO2_Afficheur1");
        });

        modelBuilder.Entity<DateImportante>(entity =>
        {
            entity.HasKey(e => e.IddateImportante).HasName("PRIMARY");

            entity.ToTable("date_importante");

            entity.Property(e => e.IddateImportante)
                .HasColumnType("int(11)")
                .HasColumnName("iddate_importante");
            entity.Property(e => e.Date).HasColumnName("DATE");
            entity.Property(e => e.Info)
                .HasMaxLength(45)
                .HasColumnName("info");
            entity.Property(e => e.Type).HasColumnType("enum('DS','reunion','Event')");
        });

        modelBuilder.Entity<Luminosite>(entity =>
        {
            entity.HasKey(e => e.IdLumin).HasName("PRIMARY");

            entity.ToTable("Luminosite");

            entity.HasIndex(e => e.AfficheurIdcapteur, "fk_Luminosite_Afficheur1_idx");

            entity.Property(e => e.IdLumin).HasColumnType("int(11)");
            entity.Property(e => e.AfficheurIdcapteur)
                .HasColumnType("int(11)")
                .HasColumnName("Afficheur_idcapteur");
            entity.Property(e => e.Valeur).HasMaxLength(45);

            entity.HasOne(d => d.AfficheurIdcapteurNavigation).WithMany(p => p.Luminosites)
                .HasForeignKey(d => d.AfficheurIdcapteur)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_Luminosite_Afficheur1");
        });

        modelBuilder.Entity<OffresProfessionnelle>(entity =>
        {
            entity.HasKey(e => e.IdoffresProfessionnelles).HasName("PRIMARY");

            entity.ToTable("offres_professionnelles");

            entity.Property(e => e.IdoffresProfessionnelles)
                .HasColumnType("int(11)")
                .HasColumnName("idoffres_professionnelles");
            entity.Property(e => e.DatePoste).HasColumnName("Date_Poste");
            entity.Property(e => e.Entreprise)
                .HasMaxLength(45)
                .HasColumnName("entreprise");
        });

        modelBuilder.Entity<Salle>(entity =>
        {
            entity.HasKey(e => e.Idsalle).HasName("PRIMARY");

            entity.ToTable("salle");

            entity.HasIndex(e => e.BatimentIdbatiment, "fk_salle_batiment1_idx");

            entity.Property(e => e.Idsalle)
                .HasColumnType("int(11)")
                .HasColumnName("idsalle");
            entity.Property(e => e.BatimentIdbatiment)
                .HasColumnType("int(11)")
                .HasColumnName("batiment_idbatiment");
            entity.Property(e => e.NumeroSalle)
                .HasMaxLength(45)
                .HasColumnName("numero_salle");

            entity.HasOne(d => d.BatimentIdbatimentNavigation).WithMany(p => p.Salles)
                .HasForeignKey(d => d.BatimentIdbatiment)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_salle_batiment1");
        });

        modelBuilder.Entity<Temperature>(entity =>
        {
            entity.HasKey(e => e.IdTemp).HasName("PRIMARY");

            entity.ToTable("Temperature");

            entity.HasIndex(e => e.AfficheurIdcapteur, "fk_Temperature_Afficheur1_idx");

            entity.Property(e => e.IdTemp).HasColumnType("int(11)");
            entity.Property(e => e.AfficheurIdcapteur)
                .HasColumnType("int(11)")
                .HasColumnName("Afficheur_idcapteur");
            entity.Property(e => e.Valeur).HasMaxLength(45);

            entity.HasOne(d => d.AfficheurIdcapteurNavigation).WithMany(p => p.Temperatures)
                .HasForeignKey(d => d.AfficheurIdcapteur)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_Temperature_Afficheur1");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Iduser).HasName("PRIMARY");

            entity.ToTable("user");

            entity.Property(e => e.Iduser)
                .HasColumnType("int(11)")
                .HasColumnName("iduser");
            entity.Property(e => e.DateDeNaissance).HasColumnName("date_de_naissance");
            entity.Property(e => e.Email)
                .HasMaxLength(45)
                .HasColumnName("email");
            entity.Property(e => e.Nom)
                .HasMaxLength(45)
                .HasColumnName("nom");
            entity.Property(e => e.Statut)
                .HasColumnType("enum('Professeur','eleve','admin')")
                .HasColumnName("statut");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
