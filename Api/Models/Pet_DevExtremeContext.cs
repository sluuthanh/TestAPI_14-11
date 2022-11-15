using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace Api.Models
{
    public partial class Pet_DevExtremeContext : DbContext
    {
        public Pet_DevExtremeContext()
        {
        }

        public Pet_DevExtremeContext(DbContextOptions<Pet_DevExtremeContext> options)
            : base(options)
        {
        }

        public virtual DbSet<City> Cities { get; set; }
        public virtual DbSet<CityDistrict> CityDistricts { get; set; }
        public virtual DbSet<District> Districts { get; set; }
        public virtual DbSet<Facility> Facilities { get; set; }
        public virtual DbSet<Feedback> Feedbacks { get; set; }
        public virtual DbSet<HanhKiem> HanhKiems { get; set; }
        public virtual DbSet<Rank> Ranks { get; set; }
        public virtual DbSet<Student> Students { get; set; }
        public virtual DbSet<TestDb> TestDbs { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=.;Database=Pet_DevExtreme;uid=sa;pwd=sa");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<City>(entity =>
            {
                entity.ToTable("City");

                entity.Property(e => e.City1)
                    .HasMaxLength(50)
                    .HasColumnName("City");
            });

            modelBuilder.Entity<CityDistrict>(entity =>
            {
                entity.ToTable("city_district");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CityId).HasColumnName("city_id");

                entity.Property(e => e.DistrictId).HasColumnName("district_id");

                entity.HasOne(d => d.City)
                    .WithMany(p => p.CityDistricts)
                    .HasForeignKey(d => d.CityId)
                    .HasConstraintName("FK_city_district_City");

                entity.HasOne(d => d.District)
                    .WithMany(p => p.CityDistricts)
                    .HasForeignKey(d => d.DistrictId)
                    .HasConstraintName("FK_city_district_district");
            });

            modelBuilder.Entity<District>(entity =>
            {
                entity.ToTable("district");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.District1)
                    .HasMaxLength(50)
                    .HasColumnName("district");
            });

            modelBuilder.Entity<Facility>(entity =>
            {
                entity.ToTable("Facility");
            });

            modelBuilder.Entity<Feedback>(entity =>
            {
                entity.ToTable("Feedback");
            });

            modelBuilder.Entity<HanhKiem>(entity =>
            {
                entity.HasKey(e => e.IdHanhKiem);

                entity.ToTable("HanhKiem");

                entity.Property(e => e.LoaiHanhKiem).IsRequired();
            });

            modelBuilder.Entity<Rank>(entity =>
            {
                entity.HasKey(e => e.IdLoai);

                entity.ToTable("Rank");

                entity.Property(e => e.Loai)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Student>(entity =>
            {
                entity.HasKey(e => e.SchedulerId);

                entity.ToTable("Student");

                entity.Property(e => e.SchedulerId).HasColumnName("SchedulerID");

                entity.Property(e => e.CityId).HasColumnName("city_id");

                entity.Property(e => e.DistrictId).HasColumnName("district_id");

                entity.Property(e => e.DoB).HasColumnType("date");

                entity.HasOne(d => d.City)
                    .WithMany(p => p.Students)
                    .HasForeignKey(d => d.CityId)
                    .HasConstraintName("FK_Student_City");

                entity.HasOne(d => d.District)
                    .WithMany(p => p.Students)
                    .HasForeignKey(d => d.DistrictId)
                    .HasConstraintName("FK_Student_district");
            });

            modelBuilder.Entity<TestDb>(entity =>
            {
                entity.ToTable("TestDB");

                entity.Property(e => e.Name).IsRequired();
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
