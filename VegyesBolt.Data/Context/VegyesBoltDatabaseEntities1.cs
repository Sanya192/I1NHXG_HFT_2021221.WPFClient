using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace VegyesBolt.Data {
    public partial class VegyesBoltDatabaseEntities1 : DbContext
    {
        public VegyesBoltDatabaseEntities1()
        {
        }

        public VegyesBoltDatabaseEntities1(DbContextOptions<VegyesBoltDatabaseEntities1> options)
            : base(options)
        {
        }

        public virtual DbSet<Megyek> Megyeks { get; set; }
        public virtual DbSet<Termekek> Termekeks { get; set; }
        public virtual DbSet<Vasarlasok> Vasarlasoks { get; set; }
        public virtual DbSet<Vasarlok> Vasarloks { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\Vegyesbolt.mdf;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Megyek>(entity =>
            {
                entity.ToTable("Megyek");

                entity.Property(e => e.Nev)
                    .IsRequired()
                    .HasMaxLength(42)
                    .IsUnicode(false);

                entity.Property(e => e.Szekhely)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Termekek>(entity =>
            {
                entity.ToTable("Termekek");

                entity.Property(e => e.AfasAra).HasComputedColumnSql("([Ara]*(1.27))", true);

                entity.Property(e => e.TermekNeve)
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Vasarlasok>(entity =>
            {
                entity.HasKey(e => new { e.TermekId, e.VasarloId, e.VasarlasDatuma })
                    .HasName("VASARLASOK_PK");

                entity.ToTable("Vasarlasok");

                entity.Property(e => e.VasarlasDatuma).HasColumnType("datetime");

                entity.HasOne(d => d.Termek)
                    .WithMany(p => p.Vasarlasoks)
                    .HasForeignKey(d => d.TermekId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("VASARLASOK_TERMEKEK_ID_FK");

                entity.HasOne(d => d.Vasarlo)
                    .WithMany(p => p.Vasarlasoks)
                    .HasForeignKey(d => d.VasarloId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("VASARLASOK_VASARLOK_ID_FK");
            });

            modelBuilder.Entity<Vasarlok>(entity =>
            {
                entity.ToTable("Vasarlok");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Nev)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.RegDate).HasColumnType("datetime");

                entity.HasOne(d => d.MegyeNavigation)
                    .WithMany(p => p.Vasarloks)
                    .HasForeignKey(d => d.Megye)
                    .HasConstraintName("VASARLOK_MEGYEK_ID_FK");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
