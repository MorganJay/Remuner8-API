using System;
using API.DataModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace Remuner8_Backend.Models
{
    public partial class Remuner8Context : DbContext
    {
        public Remuner8Context()
        {
        }

        public Remuner8Context(DbContextOptions<Remuner8Context> options)
            : base(options)
        {
        }

        public virtual DbSet<Bank> Banks { get; set; }
        public virtual DbSet<Bonus> Bonuses { get; set; }
        public virtual DbSet<Department> Departments { get; set; }
        public virtual DbSet<EmployeeBiodata> EmployeeBiodatas { get; set; }
        public virtual DbSet<EmploymentType> EmploymentTypes { get; set; }
        public virtual DbSet<JobDescription> JobDescriptions { get; set; }
        public virtual DbSet<Password> Passwords { get; set; }
        public virtual DbSet<PayrollTransaction> PayrollTransactions { get; set; }
        public virtual DbSet<PensionFundAdministration> PensionFundAdministrations { get; set; }
        public virtual DbSet<StatutoryDeduction> StatutoryDeductions { get; set; }
        public virtual DbSet<SystemDefault> SystemDefaults { get; set; }
        public virtual DbSet<Tax> Taxes { get; set; }
        public virtual DbSet<TimeSheet> TimeSheets { get; set; }
        public virtual DbSet<UserRole> UserRoles { get; set; }
        public virtual DbSet<PayrollAdditionItem> PayrollAdditionItems { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Name=DefaultConnection");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Bank>(entity =>
            {
                entity.HasKey(e => e.BankCode)
                    .HasName("PK__Banks__7C3F297BF1E3C219");

                entity.Property(e => e.BankCode).IsUnicode(false);

                entity.Property(e => e.BankName).IsUnicode(false);
            });

            modelBuilder.Entity<Bonus>(entity =>
            {
                entity.HasOne(d => d.Department)
                    .WithMany()
                    .HasForeignKey(d => d.DepartmentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Bonuses__departm__2B3F6F97");

                entity.HasOne(d => d.JobDescription)
                    .WithMany()
                    .HasForeignKey(d => d.JobDescriptionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Bonuses__jobDesc__2C3393D0");
            });

            modelBuilder.Entity<Department>(entity =>
            {
                entity.Property(e => e.DepartmentName).IsUnicode(false);
            });

            modelBuilder.Entity<EmployeeBiodata>(entity =>
            {
                entity.HasKey(e => e.EmployeeId)
                    .HasName("PK__Employee__C134C9C1771E4F30");

                entity.Property(e => e.EmployeeId).IsUnicode(false);

                entity.Property(e => e.AccountNumber).IsUnicode(false);

                entity.Property(e => e.Address).IsUnicode(false);

                entity.Property(e => e.BankCode).IsUnicode(false);

                entity.Property(e => e.CountryName).IsUnicode(false);

                entity.Property(e => e.EmailAddress).IsUnicode(false);

                entity.Property(e => e.FirstName).IsUnicode(false);

                entity.Property(e => e.Gender)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.LastName).IsUnicode(false);

                entity.Property(e => e.MaritalStatus)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.OtherName).IsUnicode(false);

                entity.Property(e => e.PhoneNumber).IsUnicode(false);

                entity.Property(e => e.StateName).IsUnicode(false);

                entity.HasOne(d => d.BankCodeNavigation)
                    .WithMany(p => p.EmployeeBiodatas)
                    .HasForeignKey(d => d.BankCode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__EmployeeB__bankC__3C69FB99");

                entity.HasOne(d => d.Department)
                    .WithMany(p => p.EmployeeBiodatas)
                    .HasForeignKey(d => d.DepartmentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__EmployeeB__depar__3A81B327");

                entity.HasOne(d => d.EmailAddressNavigation)
                    .WithOne(p => p.EmployeeBiodata)
                    .HasForeignKey<EmployeeBiodata>(d => d.EmailAddress)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__EmployeeB__email__3D5E1FD2");

                entity.HasOne(d => d.JobDescription)
                    .WithMany(p => p.EmployeeBiodatas)
                    .HasForeignKey(d => d.JobDescriptionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__EmployeeB__jobDe__3B75D760");
            });

            modelBuilder.Entity<EmploymentType>(entity =>
            {
                entity.Property(e => e.EmploymentName).IsUnicode(false);
            });

            modelBuilder.Entity<JobDescription>(entity =>
            {
                entity.Property(e => e.JobDescriptionName).IsUnicode(false);
            });

            modelBuilder.Entity<Password>(entity =>
            {
                entity.HasKey(e => e.Email)
                    .HasName("PK__Password__AB6E6165CEDA53DD");

                entity.Property(e => e.Email).IsUnicode(false);

                entity.Property(e => e.Password1).IsUnicode(false);
            });

            modelBuilder.Entity<PayrollTransaction>(entity =>
            {
                entity.HasKey(e => e.TransactionId)
                    .HasName("PK__PayrollT__9B57CF7249445F48");

                entity.Property(e => e.EmployeeId).IsUnicode(false);

                entity.Property(e => e.TransactionDateTime).HasPrecision(0);

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.PayrollTransactions)
                    .HasForeignKey(d => d.EmployeeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__PayrollTr__emplo__440B1D61");
            });

            modelBuilder.Entity<PensionFundAdministration>(entity =>
            {
                entity.HasKey(e => e.PfaCode)
                    .HasName("PK__PensionF__056D327AA7859729");

                entity.Property(e => e.PfaCode).IsUnicode(false);

                entity.Property(e => e.AccountNumber).IsUnicode(false);

                entity.Property(e => e.Address).IsUnicode(false);

                entity.Property(e => e.PfaName).IsUnicode(false);
            });

            modelBuilder.Entity<StatutoryDeduction>(entity =>
            {
                entity.HasKey(e => e.StatutoryTypeId)
                    .HasName("PK__Statutor__8001A5961FCE4767");

                entity.Property(e => e.Description).IsUnicode(false);

                entity.Property(e => e.EmployeeId).IsUnicode(false);

                entity.Property(e => e.PfaAccountNumber).IsUnicode(false);

                entity.Property(e => e.PfaAccountNumber1).IsUnicode(false);

                entity.Property(e => e.PfaCode).IsUnicode(false);

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.StatutoryDeductions)
                    .HasForeignKey(d => d.EmployeeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Statutory__emplo__403A8C7D");

                entity.HasOne(d => d.PfaCodeNavigation)
                    .WithMany(p => p.StatutoryDeductions)
                    .HasForeignKey(d => d.PfaCode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Statutory__pfaCo__412EB0B6");
            });

            modelBuilder.Entity<SystemDefault>(entity =>
            {
                entity.Property(e => e.Address).IsUnicode(false);

                entity.Property(e => e.CompanyName).IsUnicode(false);

                entity.Property(e => e.Email).IsUnicode(false);

                entity.Property(e => e.MobileNumber).IsUnicode(false);

                entity.Property(e => e.OfficialPhoneNumber).IsUnicode(false);

                entity.Property(e => e.PostalCode).IsUnicode(false);

                entity.Property(e => e.WebsiteUrl).IsUnicode(false);
            });

            modelBuilder.Entity<Tax>(entity =>
            {
                entity.Property(e => e.EmployeeId).IsUnicode(false);

                entity.HasOne(d => d.Employee)
                    .WithOne()
                    .HasForeignKey<Tax>(d => d.EmployeeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Taxes__employeeI__48CFD27E");
            });

            modelBuilder.Entity<TimeSheet>(entity =>
            {
                entity.Property(e => e.EmployeeId).IsUnicode(false);

                entity.HasOne(d => d.Employee)
                    .WithMany()
                    .HasForeignKey(d => d.EmployeeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__TimeSheet__emplo__45F365D3");
            });

            modelBuilder.Entity<UserRole>(entity =>
            {
                entity.Property(e => e.Role).IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}