using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Diet__Fix.Models
{
    public partial class Diet_FixContext : DbContext
    {
        public Diet_FixContext()
        {
        }

        public Diet_FixContext(DbContextOptions<Diet_FixContext> options)
            : base(options)
        {
        }

        public virtual DbSet<CostAnalysis> CostAnalysis { get; set; }
        public virtual DbSet<DietType> DietType { get; set; }
        public virtual DbSet<UserAccount> UserAccount { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {

                optionsBuilder.UseSqlServer("Server=DESKTOP-B8RHK7G\\MSSQLSERVER01;Database=Diet_Fix;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CostAnalysis>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.CostOptions).IsUnicode(false);

                entity.HasOne(d => d.IdNavigation)
                    .WithOne(p => p.CostAnalysis)
                    .HasForeignKey<CostAnalysis>(d => d.Id)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__CostAnalysis__ID__29572725");
            });

            modelBuilder.Entity<DietType>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.KetoDesc).IsUnicode(false);

                entity.Property(e => e.MediDesc).IsUnicode(false);

                entity.Property(e => e.PaleoDesc).IsUnicode(false);

                entity.Property(e => e.PescDesc).IsUnicode(false);

                entity.HasOne(d => d.IdNavigation)
                    .WithOne(p => p.DietType)
                    .HasForeignKey<DietType>(d => d.Id)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__DietType__MediDe__267ABA7A");
            });

            modelBuilder.Entity<UserAccount>(entity =>
            {
                entity.Property(e => e.FullName).HasMaxLength(50);

                entity.Property(e => e.MealLog).IsUnicode(false);

                entity.Property(e => e.UserProgression).IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
