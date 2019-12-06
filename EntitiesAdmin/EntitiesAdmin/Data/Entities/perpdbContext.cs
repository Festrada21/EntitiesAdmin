using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace EntitiesAdmin.Data.Entities
{
    public partial class perpdbContext : DbContext
    {
        public perpdbContext()
        {
        }

        public perpdbContext(DbContextOptions<perpdbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AspNetRoleClaims> AspNetRoleClaims { get; set; }
        public virtual DbSet<AspNetRoles> AspNetRoles { get; set; }
        public virtual DbSet<AspNetUserClaims> AspNetUserClaims { get; set; }
        public virtual DbSet<AspNetUserLogins> AspNetUserLogins { get; set; }
        public virtual DbSet<AspNetUserRoles> AspNetUserRoles { get; set; }
        public virtual DbSet<AspNetUserTokens> AspNetUserTokens { get; set; }
        public virtual DbSet<AspNetUsers> AspNetUsers { get; set; }
        public virtual DbSet<Countries> Countries { get; set; }
        public virtual DbSet<Departments> Departments { get; set; }
        public virtual DbSet<Employees> Employees { get; set; }
        public virtual DbSet<JobPositions> JobPositions { get; set; }
        public virtual DbSet<RequestCategories> RequestCategories { get; set; }
        public virtual DbSet<Requests> Requests { get; set; }
        public virtual DbSet<Rosters> Rosters { get; set; }
        public virtual DbSet<Site> Site { get; set; }
        public virtual DbSet<Skills> Skills { get; set; }
        public virtual DbSet<StatusEmployees> StatusEmployees { get; set; }
        public virtual DbSet<StatusFields> StatusFields { get; set; }
        public virtual DbSet<StatusRequest> StatusRequest { get; set; }
        public virtual DbSet<TypeRequests> TypeRequests { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
            //To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=172.16.9.125;Initial Catalog=perpdb;User ID=sa;Password=abc123**;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AspNetRoleClaims>(entity =>
            {
                entity.HasIndex(e => e.RoleId);

                entity.Property(e => e.RoleId).IsRequired();

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.AspNetRoleClaims)
                    .HasForeignKey(d => d.RoleId);
            });

            modelBuilder.Entity<AspNetRoles>(entity =>
            {
                entity.HasIndex(e => e.NormalizedName)
                    .HasName("RoleNameIndex")
                    .IsUnique()
                    .HasFilter("([NormalizedName] IS NOT NULL)");

                entity.Property(e => e.Name).HasMaxLength(256);

                entity.Property(e => e.NormalizedName).HasMaxLength(256);
            });

            modelBuilder.Entity<AspNetUserClaims>(entity =>
            {
                entity.HasIndex(e => e.UserId);

                entity.Property(e => e.UserId).IsRequired();

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserClaims)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUserLogins>(entity =>
            {
                entity.HasKey(e => new { e.LoginProvider, e.ProviderKey });

                entity.HasIndex(e => e.UserId);

                entity.Property(e => e.UserId).IsRequired();

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserLogins)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUserRoles>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.RoleId });

                entity.HasIndex(e => e.RoleId);

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.AspNetUserRoles)
                    .HasForeignKey(d => d.RoleId);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserRoles)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUserTokens>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.LoginProvider, e.Name });

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserTokens)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUsers>(entity =>
            {
                entity.HasIndex(e => e.EmployeeId);

                entity.HasIndex(e => e.NormalizedEmail)
                    .HasName("EmailIndex");

                entity.HasIndex(e => e.NormalizedUserName)
                    .HasName("UserNameIndex")
                    .IsUnique()
                    .HasFilter("([NormalizedUserName] IS NOT NULL)");

                entity.Property(e => e.Email).HasMaxLength(256);

                entity.Property(e => e.NormalizedEmail).HasMaxLength(256);

                entity.Property(e => e.NormalizedUserName).HasMaxLength(256);

                entity.Property(e => e.UserName).HasMaxLength(256);

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.AspNetUsers)
                    .HasForeignKey(d => d.EmployeeId);
            });

            modelBuilder.Entity<Countries>(entity =>
            {
                entity.HasKey(e => e.CountryId);

                entity.HasIndex(e => e.Name)
                    .HasName("UName")
                    .IsUnique();

                entity.HasIndex(e => e.StatusFieldId);

                entity.HasIndex(e => e.UserId);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.StatusField)
                    .WithMany(p => p.Countries)
                    .HasForeignKey(d => d.StatusFieldId);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Countries)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<Departments>(entity =>
            {
                entity.HasKey(e => e.DepartmentId);

                entity.HasIndex(e => e.RosterId);

                entity.HasIndex(e => e.StatusFieldId);

                entity.HasIndex(e => e.UserId);

                entity.HasIndex(e => new { e.RosterId, e.Name })
                    .HasName("URosterIdName")
                    .IsUnique();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.Roster)
                    .WithMany(p => p.Departments)
                    .HasForeignKey(d => d.RosterId)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.StatusField)
                    .WithMany(p => p.Departments)
                    .HasForeignKey(d => d.StatusFieldId);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Departments)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<Employees>(entity =>
            {
                entity.HasKey(e => e.EmployeeId);

                entity.HasIndex(e => e.CountryId);

                entity.HasIndex(e => e.EmployeeCode)
                    .HasName("UEmployeeCodeEmployees")
                    .IsUnique();

                entity.HasIndex(e => e.JobPositionId);

                entity.HasIndex(e => e.SiteId);

                entity.HasIndex(e => e.SkillId);

                entity.HasIndex(e => e.StatusEmployeeId);

                entity.Property(e => e.EmployeeCode)
                    .IsRequired()
                    .HasMaxLength(25);

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.FirstSurname)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.MiddleName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.SecondSurname)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.Country)
                    .WithMany(p => p.Employees)
                    .HasForeignKey(d => d.CountryId);

                entity.HasOne(d => d.JobPosition)
                    .WithMany(p => p.Employees)
                    .HasForeignKey(d => d.JobPositionId);

                entity.HasOne(d => d.Site)
                    .WithMany(p => p.Employees)
                    .HasForeignKey(d => d.SiteId);

                entity.HasOne(d => d.Skill)
                    .WithMany(p => p.Employees)
                    .HasForeignKey(d => d.SkillId);

                entity.HasOne(d => d.StatusEmployee)
                    .WithMany(p => p.Employees)
                    .HasForeignKey(d => d.StatusEmployeeId);
            });

            modelBuilder.Entity<JobPositions>(entity =>
            {
                entity.HasKey(e => e.PositionId);

                entity.HasIndex(e => e.Name)
                    .HasName("UNameJobpositions")
                    .IsUnique();

                entity.HasIndex(e => e.StatusFieldId);

                entity.HasIndex(e => e.UserId);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.StatusField)
                    .WithMany(p => p.JobPositions)
                    .HasForeignKey(d => d.StatusFieldId);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.JobPositions)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<RequestCategories>(entity =>
            {
                entity.HasKey(e => e.RequestCategoryId);

                entity.HasIndex(e => e.Name)
                    .HasName("UNameRequestCategories")
                    .IsUnique();

                entity.HasIndex(e => e.StatusFieldId);

                entity.HasIndex(e => e.UserId);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.StatusField)
                    .WithMany(p => p.RequestCategories)
                    .HasForeignKey(d => d.StatusFieldId);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.RequestCategories)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<Requests>(entity =>
            {
                entity.HasKey(e => e.RequestId);

                entity.HasIndex(e => e.StatusRequestId);

                entity.HasIndex(e => e.TypeRequestId);

                entity.HasIndex(e => e.UserId);

                entity.Property(e => e.Remarks).IsRequired();

                entity.Property(e => e.Subject)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.UserId).IsRequired();

                entity.HasOne(d => d.StatusRequest)
                    .WithMany(p => p.Requests)
                    .HasForeignKey(d => d.StatusRequestId);

                entity.HasOne(d => d.TypeRequest)
                    .WithMany(p => p.Requests)
                    .HasForeignKey(d => d.TypeRequestId);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Requests)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<Rosters>(entity =>
            {
                entity.HasKey(e => e.RosterId);

                entity.HasIndex(e => e.Name)
                    .HasName("UNameRoster")
                    .IsUnique();

                entity.HasIndex(e => e.StatusFieldId);

                entity.HasIndex(e => e.UserId);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.StatusField)
                    .WithMany(p => p.Rosters)
                    .HasForeignKey(d => d.StatusFieldId);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Rosters)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<Site>(entity =>
            {
                entity.HasIndex(e => e.CountryId);

                entity.HasIndex(e => e.StatusFieldId);

                entity.HasIndex(e => e.UserId);

                entity.HasIndex(e => new { e.CountryId, e.Name })
                    .HasName("UName_CountryID_Site")
                    .IsUnique();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.Country)
                    .WithMany(p => p.Site)
                    .HasForeignKey(d => d.CountryId);

                entity.HasOne(d => d.StatusField)
                    .WithMany(p => p.Site)
                    .HasForeignKey(d => d.StatusFieldId);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Site)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<Skills>(entity =>
            {
                entity.HasKey(e => e.SkillId);

                entity.HasIndex(e => e.DepartmentId)
                    .HasName("IX_Skills_DepartmentID_Name");

                entity.HasIndex(e => e.StatusFieldId);

                entity.HasIndex(e => e.UserId);

                entity.HasIndex(e => new { e.DepartmentId, e.Name })
                    .HasName("UNameSkill_Department")
                    .IsUnique();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.Department)
                    .WithMany(p => p.Skills)
                    .HasForeignKey(d => d.DepartmentId)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.StatusField)
                    .WithMany(p => p.Skills)
                    .HasForeignKey(d => d.StatusFieldId);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Skills)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<StatusEmployees>(entity =>
            {
                entity.HasKey(e => e.StatusEmployeeId);

                entity.HasIndex(e => e.Name)
                    .HasName("UNameStatusEmployee")
                    .IsUnique();

                entity.HasIndex(e => e.StatusFieldId);

                entity.HasIndex(e => e.UserId);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.StatusField)
                    .WithMany(p => p.StatusEmployees)
                    .HasForeignKey(d => d.StatusFieldId);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.StatusEmployees)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<StatusFields>(entity =>
            {
                entity.HasKey(e => e.StatusFieldId);

                entity.HasIndex(e => e.Name)
                    .HasName("UNameStatusField")
                    .IsUnique();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<StatusRequest>(entity =>
            {
                entity.HasIndex(e => e.Name)
                    .HasName("UNameStatusRequest")
                    .IsUnique();

                entity.HasIndex(e => e.StatusFieldId);

                entity.HasIndex(e => e.UserId);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.StatusField)
                    .WithMany(p => p.StatusRequest)
                    .HasForeignKey(d => d.StatusFieldId);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.StatusRequest)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<TypeRequests>(entity =>
            {
                entity.HasKey(e => e.TypeRequestId);

                entity.HasIndex(e => e.DepartmentId);

                entity.HasIndex(e => e.RequestCategoryId);

                entity.HasIndex(e => e.StatusFieldId);

                entity.HasIndex(e => e.UserId);

                entity.HasIndex(e => new { e.DepartmentId, e.Name })
                    .HasName("UNameDepartmantTypeRequest")
                    .IsUnique();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.Department)
                    .WithMany(p => p.TypeRequests)
                    .HasForeignKey(d => d.DepartmentId);

                entity.HasOne(d => d.RequestCategory)
                    .WithMany(p => p.TypeRequests)
                    .HasForeignKey(d => d.RequestCategoryId);

                entity.HasOne(d => d.StatusField)
                    .WithMany(p => p.TypeRequests)
                    .HasForeignKey(d => d.StatusFieldId);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.TypeRequests)
                    .HasForeignKey(d => d.UserId);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
