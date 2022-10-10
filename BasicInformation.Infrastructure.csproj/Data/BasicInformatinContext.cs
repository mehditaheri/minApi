using BasicInformation.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace BasicInformation.Infrastructure.Data
{
    public partial class BasicInformatinContext : DbContext
    {
        public BasicInformatinContext()
        {
        }

        public BasicInformatinContext(DbContextOptions<BasicInformatinContext> options) : base(options)
        {
        }

        public virtual DbSet<TblLocation> TblLocations { get; set; } = null!;
        public virtual DbSet<TblLocation1Province> TblLocation1Provinces { get; set; } = null!;
        public virtual DbSet<TblLocation2County> TblLocation2Counties { get; set; } = null!;
        public virtual DbSet<TblLocation3District> TblLocation3Districts { get; set; } = null!;
        public virtual DbSet<TblLocation4City> TblLocation4Cities { get; set; } = null!;
        public virtual DbSet<TblLocation4RuralDistrict> TblLocation4RuralDistricts { get; set; } = null!;
        public virtual DbSet<TblLocation5Village> TblLocation5Villages { get; set; } = null!;
        public virtual DbSet<TblLocationType> TblLocationTypes { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
//            if (!optionsBuilder.IsConfigured)
//            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
//                optionsBuilder.UseSqlServer("Server=IT-TAHERI;DataBase=BasicInformatin;User Id=sa;Password=123654789;");
//            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TblLocation>(entity =>
            {
                entity.HasKey(e => e.Id)
                    .HasName("PK_TblLocation_1");

                entity.ToTable("TblLocation");

                entity.Property(e => e.Id).HasColumnName("LocationId").ValueGeneratedNever();

                entity.Property(e => e.Lat).HasColumnType("decimal(12, 9)");

                entity.Property(e => e.Lng).HasColumnType("decimal(12, 9)");

                entity.Property(e => e.Title).HasMaxLength(500);

                entity.Property(e => e.Username).HasMaxLength(50);
            });

            modelBuilder.Entity<TblLocation1Province>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("TblLocation1Province");

                entity.Property(e => e.Id).HasColumnName("LocationId");

                entity.Property(e => e.Title).HasMaxLength(500);

                entity.Property(e => e.Username).HasMaxLength(50);
            });

            modelBuilder.Entity<TblLocation2County>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("TblLocation2County");

                entity.Property(e => e.Id).HasColumnName("LocationId");

                entity.Property(e => e.Title).HasMaxLength(500);

                entity.Property(e => e.Username).HasMaxLength(50);
            });

            modelBuilder.Entity<TblLocation3District>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("TblLocation3District");

                entity.Property(e => e.Id).HasColumnName("LocationId");

                entity.Property(e => e.Title).HasMaxLength(500);

                entity.Property(e => e.Username).HasMaxLength(50);
            });

            modelBuilder.Entity<TblLocation4City>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("TblLocation4City");

                entity.Property(e => e.Id).HasColumnName("LocationId");

                entity.Property(e => e.Title).HasMaxLength(500);

                entity.Property(e => e.Username).HasMaxLength(50);
            });

            modelBuilder.Entity<TblLocation4RuralDistrict>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("TblLocation4RuralDistricts");

                entity.Property(e => e.Id).HasColumnName("LocationId");

                entity.Property(e => e.Title).HasMaxLength(500);

                entity.Property(e => e.Username).HasMaxLength(50);
            });

            modelBuilder.Entity<TblLocation5Village>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("TblLocation5Village");

                entity.Property(e => e.Id).HasColumnName("LocationId");

                entity.Property(e => e.Title).HasMaxLength(500);

                entity.Property(e => e.Username).HasMaxLength(50);
            });

            modelBuilder.Entity<TblLocationType>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.ToTable("TblLocationType"); 

                entity.Property(e => e.Id).HasColumnName("LocationTypeId").ValueGeneratedNever();

                entity.Property(e => e.EnglishTitle).HasMaxLength(50);

                entity.Property(e => e.Title).HasMaxLength(50);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
