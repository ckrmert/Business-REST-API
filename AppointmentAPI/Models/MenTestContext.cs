using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace AppointmentAPI.Models
{
    public partial class MenTestContext : DbContext
    {
        public MenTestContext()
        {
        }

        public MenTestContext(DbContextOptions<MenTestContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Banner> Banners { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Check> Checks { get; set; }
        public virtual DbSet<Personel> Personels { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source = 10.34.57.6; Initial Catalog = MenTest; User ID = sa; Password=Csa12r!E6eljCyeg");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Turkish_CI_AS");

            modelBuilder.Entity<Banner>(entity =>
            {
                entity.Property(e => e.Image)
                    .IsRequired()
                    .HasMaxLength(500);
            });

            modelBuilder.Entity<Category>(entity =>
            {
                entity.Property(e => e.Description).HasMaxLength(500);

                entity.Property(e => e.IconColour).HasMaxLength(500);

                entity.Property(e => e.IconName).HasMaxLength(500);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<Check>(entity =>
            {
                entity.Property(e => e.AppVersion)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("appVersion");

                entity.Property(e => e.DeviceAgent)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("deviceAgent");

                entity.Property(e => e.IpAddress)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("ipAddress");

                entity.Property(e => e.Latitute).HasColumnName("latitute");

                entity.Property(e => e.Longitute).HasColumnName("longitute");

                entity.Property(e => e.MacAddress)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("macAddress");

                entity.Property(e => e.Platform)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("platform");

                entity.Property(e => e.PlatformVersion)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("platformVersion");
            });

            modelBuilder.Entity<Personel>(entity =>
            {
                entity.Property(e => e.Bio)
                    .IsRequired()
                    .HasMaxLength(500);

                entity.Property(e => e.Image).HasMaxLength(500);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Surname)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.Personels)
                    .HasForeignKey(d => d.CategoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Personels_Categories");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.Mail)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(500);

                entity.Property(e => e.Phone)
                    .IsRequired()
                    .HasMaxLength(15);

                entity.Property(e => e.Surname)
                    .IsRequired()
                    .HasMaxLength(30);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
