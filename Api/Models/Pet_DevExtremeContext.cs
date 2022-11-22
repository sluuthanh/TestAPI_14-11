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
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<District> Districts { get; set; }
        public virtual DbSet<DistrictNew> DistrictNews { get; set; }
        public virtual DbSet<Metacombobox> Metacomboboxes { get; set; }
        public virtual DbSet<Metadatum> Metadata { get; set; }
        public virtual DbSet<Province> Provinces { get; set; }
        public virtual DbSet<Student> Students { get; set; }
        public virtual DbSet<Ward> Wards { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=.;Database=Pet_DevExtreme;uid=sa;pwd=sa;");
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

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("customer");

                entity.Property(e => e.Avatar)
                    .HasMaxLength(200)
                    .HasColumnName("avatar");

                entity.Property(e => e.DateOfBirth)
                    .HasColumnType("date")
                    .HasColumnName("date_of_birth");

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("email");

                entity.Property(e => e.Firstname)
                    .HasMaxLength(80)
                    .HasColumnName("firstname");

                entity.Property(e => e.Fullname)
                    .HasMaxLength(100)
                    .HasColumnName("fullname");

                entity.Property(e => e.FullnameDisplay)
                    .HasMaxLength(100)
                    .HasColumnName("fullname_display");

                entity.Property(e => e.GenderId).HasColumnName("gender_id");

                entity.Property(e => e.Id)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("id");

                entity.Property(e => e.IsActive).HasColumnName("is_active");

                entity.Property(e => e.Lastname)
                    .HasMaxLength(20)
                    .HasColumnName("lastname");

                entity.Property(e => e.MobilePhone)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("mobile_phone");

                entity.Property(e => e.PermanentAddress)
                    .HasMaxLength(100)
                    .HasColumnName("permanent_address");

                entity.Property(e => e.PermanentDistrictId).HasColumnName("permanent_district_id");

                entity.Property(e => e.PermanentProvinceId).HasColumnName("permanent_province_id");

                entity.Property(e => e.PermanentWardId).HasColumnName("permanent_ward_id");

                entity.Property(e => e.Phone)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("phone");

                entity.Property(e => e.StatusId).HasColumnName("status_id");

                entity.Property(e => e.TemporaryAddress)
                    .HasMaxLength(100)
                    .HasColumnName("temporary_address");

                entity.Property(e => e.TemporaryDistrictId).HasColumnName("temporary_district_id");

                entity.Property(e => e.TemporaryProvinceId).HasColumnName("temporary_province_id");

                entity.Property(e => e.TemporaryWardId).HasColumnName("temporary_ward_id");
            });

            modelBuilder.Entity<District>(entity =>
            {
                entity.ToTable("district");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.District1)
                    .HasMaxLength(50)
                    .HasColumnName("district");
            });

            modelBuilder.Entity<DistrictNew>(entity =>
            {
                entity.ToTable("district-new");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.ApprovedDate).HasColumnName("approved_date");

                entity.Property(e => e.ApprovedUpdateDate).HasColumnName("approved_update_date");

                entity.Property(e => e.ApproverCode)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("approver_code");

                entity.Property(e => e.ApproverUpdateCode)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("approver_update_code");

                entity.Property(e => e.AuthorCode)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("author_code");

                entity.Property(e => e.CreatedDate)
                    .HasColumnName("created_date")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Gcrecord).HasColumnName("GCRecord");

                entity.Property(e => e.IsActive).HasColumnName("is_active");

                entity.Property(e => e.IsDeleted).HasColumnName("is_deleted");

                entity.Property(e => e.Latilongtude)
                    .HasMaxLength(50)
                    .HasColumnName("latilongtude");

                entity.Property(e => e.Name)
                    .HasMaxLength(250)
                    .HasColumnName("name");

                entity.Property(e => e.ProvinceId).HasColumnName("province_id");

                entity.Property(e => e.Sortorder).HasColumnName("sortorder");

                entity.Property(e => e.StatusId).HasColumnName("status_id");

                entity.Property(e => e.Type)
                    .HasMaxLength(50)
                    .HasColumnName("type");

                entity.Property(e => e.UpdatedCode)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("updated_code");

                entity.Property(e => e.UpdatedDate).HasColumnName("updated_date");

                entity.HasOne(d => d.Province)
                    .WithMany(p => p.DistrictNews)
                    .HasForeignKey(d => d.ProvinceId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_district_province");
            });

            modelBuilder.Entity<Metacombobox>(entity =>
            {
                entity.ToTable("metacombobox");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.Code)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("code");

                entity.Property(e => e.CreateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("create_date")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.ExternalCode)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("external_code");

                entity.Property(e => e.IsActive)
                    .HasColumnName("is_active")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.NameMeta)
                    .HasMaxLength(800)
                    .HasColumnName("name_meta");

                entity.Property(e => e.ParentId).HasColumnName("parent_id");

                entity.Property(e => e.Sort)
                    .HasColumnName("sort")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.StatusId).HasColumnName("status_id");

                entity.HasOne(d => d.Parent)
                    .WithMany(p => p.InverseParent)
                    .HasForeignKey(d => d.ParentId)
                    .HasConstraintName("FK__metacombo__paren__20238DFD");
            });

            modelBuilder.Entity<Metadatum>(entity =>
            {
                entity.ToTable("metadata");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.ApprovedDate).HasColumnName("approved_date");

                entity.Property(e => e.ApprovedUpdateDate).HasColumnName("approved_update_date");

                entity.Property(e => e.ApproverCode)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("approver_code");

                entity.Property(e => e.ApproverUpdateCode)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("approver_update_code");

                entity.Property(e => e.AuthorCode)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("author_code");

                entity.Property(e => e.CreatedDate)
                    .HasColumnName("created_date")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Description)
                    .HasMaxLength(800)
                    .HasColumnName("description");

                entity.Property(e => e.ExternalCode)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("external_code")
                    .HasComment("Mã liên kết bên ngoài");

                entity.Property(e => e.Gcrecord).HasColumnName("GCRecord");

                entity.Property(e => e.GroupId).HasColumnName("group_id");

                entity.Property(e => e.GroupText)
                    .IsRequired()
                    .HasMaxLength(200)
                    .HasColumnName("group_text");

                entity.Property(e => e.IsActive)
                    .HasColumnName("is_active")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.ItemCode)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("item_code")
                    .HasComment("Giá trị kiểu code");

                entity.Property(e => e.ItemId).HasColumnName("item_id");

                entity.Property(e => e.ItemText)
                    .HasMaxLength(800)
                    .HasColumnName("item_text");

                entity.Property(e => e.Sort)
                    .HasColumnName("sort")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.StatusId).HasColumnName("status_id");

                entity.Property(e => e.UpdatedCode)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("updated_code");

                entity.Property(e => e.UpdatedDate).HasColumnName("updated_date");
            });

            modelBuilder.Entity<Province>(entity =>
            {
                entity.ToTable("province");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.ApprovedDate).HasColumnName("approved_date");

                entity.Property(e => e.ApprovedUpdateDate).HasColumnName("approved_update_date");

                entity.Property(e => e.ApproverCode)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("approver_code");

                entity.Property(e => e.ApproverUpdateCode)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("approver_update_code");

                entity.Property(e => e.AuthorCode)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("author_code");

                entity.Property(e => e.CountryCode)
                    .HasMaxLength(2)
                    .HasColumnName("country_code");

                entity.Property(e => e.CountryId).HasColumnName("country_id");

                entity.Property(e => e.CreatedDate)
                    .HasColumnName("created_date")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Gcrecord).HasColumnName("GCRecord");

                entity.Property(e => e.IsActive).HasColumnName("is_active");

                entity.Property(e => e.IsDeleted).HasColumnName("is_deleted");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(250)
                    .HasColumnName("name");

                entity.Property(e => e.Sortorder).HasColumnName("sortorder");

                entity.Property(e => e.StatusId).HasColumnName("status_id");

                entity.Property(e => e.Telephonecode).HasColumnName("telephonecode");

                entity.Property(e => e.Type)
                    .HasMaxLength(20)
                    .HasColumnName("type");

                entity.Property(e => e.UpdatedCode)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("updated_code");

                entity.Property(e => e.UpdatedDate).HasColumnName("updated_date");

                entity.Property(e => e.Zipcode)
                    .HasMaxLength(20)
                    .HasColumnName("zipcode");
            });

            modelBuilder.Entity<Student>(entity =>
            {
                entity.HasKey(e => e.SchedulerId);

                entity.ToTable("Student");

                entity.Property(e => e.SchedulerId).HasColumnName("SchedulerID");

                entity.Property(e => e.CityId).HasColumnName("city_id");

                entity.Property(e => e.DistrictId).HasColumnName("district_id");

                entity.Property(e => e.DoB).HasColumnType("date");

                entity.Property(e => e.PermanentAddress)
                    .HasMaxLength(100)
                    .HasColumnName("permanent_address");

                entity.Property(e => e.PermanentDistrictId).HasColumnName("permanent_district_id");

                entity.Property(e => e.PermanentProvinceId).HasColumnName("permanent_province_id");

                entity.Property(e => e.PermanentWardId).HasColumnName("permanent_ward_id");

                entity.Property(e => e.TemporaryAddress)
                    .HasMaxLength(100)
                    .HasColumnName("temporary_address");

                entity.Property(e => e.TemporaryDistrictId).HasColumnName("temporary_district_id");

                entity.Property(e => e.TemporaryProvinceId).HasColumnName("temporary_province_id");

                entity.Property(e => e.TemporaryWardId).HasColumnName("temporary_ward_id");

                entity.HasOne(d => d.City)
                    .WithMany(p => p.Students)
                    .HasForeignKey(d => d.CityId)
                    .HasConstraintName("FK_Student_City");

                entity.HasOne(d => d.District)
                    .WithMany(p => p.Students)
                    .HasForeignKey(d => d.DistrictId)
                    .HasConstraintName("FK_Student_district");
            });

            modelBuilder.Entity<Ward>(entity =>
            {
                entity.ToTable("ward");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.ApprovedDate).HasColumnName("approved_date");

                entity.Property(e => e.ApprovedUpdateDate).HasColumnName("approved_update_date");

                entity.Property(e => e.ApproverCode)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("approver_code");

                entity.Property(e => e.ApproverUpdateCode)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("approver_update_code");

                entity.Property(e => e.AuthorCode)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("author_code");

                entity.Property(e => e.CreatedDate)
                    .HasColumnName("created_date")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.DistrictId).HasColumnName("district_id");

                entity.Property(e => e.Gcrecord).HasColumnName("GCRecord");

                entity.Property(e => e.IsActive).HasColumnName("is_active");

                entity.Property(e => e.IsDeleted).HasColumnName("is_deleted");

                entity.Property(e => e.Latilongtude)
                    .HasMaxLength(50)
                    .HasColumnName("latilongtude");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("name");

                entity.Property(e => e.Sortorder).HasColumnName("sortorder");

                entity.Property(e => e.StatusId).HasColumnName("status_id");

                entity.Property(e => e.Type)
                    .HasMaxLength(50)
                    .HasColumnName("type");

                entity.Property(e => e.UpdatedCode)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("updated_code");

                entity.Property(e => e.UpdatedDate).HasColumnName("updated_date");

                entity.HasOne(d => d.District)
                    .WithMany(p => p.Wards)
                    .HasForeignKey(d => d.DistrictId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ward_district");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
