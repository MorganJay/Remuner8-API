using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace Remuner8.Models
{
    public partial class db_payrollappContext : DbContext
    {
        public db_payrollappContext()
        {
        }

        public db_payrollappContext(DbContextOptions<db_payrollappContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Bank> Banks { get; set; }
        public virtual DbSet<Bonuse> Bonuses { get; set; }
        public virtual DbSet<Department> Departments { get; set; }
        public virtual DbSet<EmployeeBiodatum> EmployeeBiodata { get; set; }
        public virtual DbSet<EmploymentType> EmploymentTypes { get; set; }
        public virtual DbSet<JobDescription> JobDescriptions { get; set; }
        public virtual DbSet<Password> Passwords { get; set; }
        public virtual DbSet<PayrollTransaction> PayrollTransactions { get; set; }
        public virtual DbSet<PensionFundAdministration> PensionFundAdministrations { get; set; }
        public virtual DbSet<StatutoryDeduction> StatutoryDeductions { get; set; }
        public virtual DbSet<SystemDefault> SystemDefaults { get; set; }
        public virtual DbSet<Taxis> Taxes { get; set; }
        public virtual DbSet<TimeSheet> TimeSheets { get; set; }
        public virtual DbSet<UserRole> UserRoles { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("name=DefaultConnection", x => x.ServerVersion("8.0.20-mysql"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Bank>(entity =>
            {
                entity.HasKey(e => e.BankCode)
                    .HasName("PRIMARY");

                entity.HasIndex(e => e.BankName, "bankName")
                    .IsUnique();

                entity.Property(e => e.BankCode)
                    .HasColumnType("varchar(10)")
                    .HasColumnName("bankCode")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.BankName)
                    .IsRequired()
                    .HasColumnType("varchar(50)")
                    .HasColumnName("bankName")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");
            });

            modelBuilder.Entity<Bonuse>(entity =>
            {
                entity.HasNoKey();

                entity.HasIndex(e => e.DepartmentId, "departmentId");

                entity.HasIndex(e => e.JobDescriptionId, "jobDescriptionId");

                entity.Property(e => e.Amount)
                    .HasPrecision(19, 4)
                    .HasColumnName("amount");

                entity.Property(e => e.BonusName)
                    .HasPrecision(19, 4)
                    .HasColumnName("bonusName");

                entity.Property(e => e.DepartmentId).HasColumnName("departmentId");

                entity.Property(e => e.JobDescriptionId).HasColumnName("jobDescriptionId");

                entity.HasOne(d => d.Department)
                    .WithMany()
                    .HasForeignKey(d => d.DepartmentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Bonuses_ibfk_1");

                entity.HasOne(d => d.JobDescription)
                    .WithMany()
                    .HasForeignKey(d => d.JobDescriptionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Bonuses_ibfk_2");
            });

            modelBuilder.Entity<Department>(entity =>
            {
                entity.Property(e => e.DepartmentId).HasColumnName("departmentId");

                entity.Property(e => e.DepartmentName)
                    .IsRequired()
                    .HasColumnType("varchar(50)")
                    .HasColumnName("departmentName")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");
            });

            modelBuilder.Entity<EmployeeBiodatum>(entity =>
            {
                entity.HasKey(e => e.EmployeeId)
                    .HasName("PRIMARY");

                entity.HasIndex(e => e.BankCode, "bankCode");

                entity.HasIndex(e => e.DepartmentId, "departmentId");

                entity.HasIndex(e => e.EmailAddress, "emailAddress")
                    .IsUnique();

                entity.HasIndex(e => e.JobDescriptionId, "jobDescriptionId");

                entity.HasIndex(e => e.PhoneNumber, "phoneNumber")
                    .IsUnique();

                entity.Property(e => e.EmployeeId)
                    .HasColumnType("varchar(10)")
                    .HasColumnName("employeeId")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.AccountNumber)
                    .IsRequired()
                    .HasColumnType("varchar(10)")
                    .HasColumnName("accountNumber")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.Address)
                    .IsRequired()
                    .HasColumnType("varchar(200)")
                    .HasColumnName("address")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.Avatar)
                    .HasColumnType("mediumblob")
                    .HasColumnName("avatar");

                entity.Property(e => e.BankCode)
                    .IsRequired()
                    .HasColumnType("varchar(10)")
                    .HasColumnName("bankCode")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.CountryName)
                    .IsRequired()
                    .HasColumnType("varchar(30)")
                    .HasColumnName("countryName")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.DateEmployed)
                    .HasColumnType("date")
                    .HasColumnName("dateEmployed");

                entity.Property(e => e.DateOfBirth)
                    .HasColumnType("date")
                    .HasColumnName("dateOfBirth");

                entity.Property(e => e.DepartmentId).HasColumnName("departmentId");

                entity.Property(e => e.EmailAddress)
                    .IsRequired()
                    .HasColumnType("varchar(40)")
                    .HasColumnName("emailAddress")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasColumnType("varchar(50)")
                    .HasColumnName("firstName")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.Gender)
                    .IsRequired()
                    .HasColumnType("char(6)")
                    .HasColumnName("gender")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.GrossSalary)
                    .HasPrecision(19, 4)
                    .HasColumnName("grossSalary");

                entity.Property(e => e.JobDescriptionId).HasColumnName("jobDescriptionId");

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasColumnType("varchar(50)")
                    .HasColumnName("lastName")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.MaritalStatus)
                    .IsRequired()
                    .HasColumnType("char(12)")
                    .HasColumnName("maritalStatus")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.OtherAllowances)
                    .HasPrecision(10, 4)
                    .HasColumnName("otherAllowances");

                entity.Property(e => e.OtherName)
                    .IsRequired()
                    .HasColumnType("varchar(50)")
                    .HasColumnName("otherName")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.PhoneNumber)
                    .IsRequired()
                    .HasColumnType("varchar(20)")
                    .HasColumnName("phoneNumber")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.StateName)
                    .IsRequired()
                    .HasColumnType("varchar(30)")
                    .HasColumnName("stateName")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.HasOne(d => d.BankCodeNavigation)
                    .WithMany(p => p.EmployeeBiodata)
                    .HasForeignKey(d => d.BankCode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("EmployeeBiodata_ibfk_3");

                entity.HasOne(d => d.Department)
                    .WithMany(p => p.EmployeeBiodata)
                    .HasForeignKey(d => d.DepartmentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("EmployeeBiodata_ibfk_1");

                entity.HasOne(d => d.EmailAddressNavigation)
                    .WithOne(p => p.EmployeeBiodatum)
                    .HasForeignKey<EmployeeBiodatum>(d => d.EmailAddress)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("EmployeeBiodata_ibfk_4");

                entity.HasOne(d => d.JobDescription)
                    .WithMany(p => p.EmployeeBiodata)
                    .HasForeignKey(d => d.JobDescriptionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("EmployeeBiodata_ibfk_2");
            });

            modelBuilder.Entity<EmploymentType>(entity =>
            {
                entity.ToTable("EmploymentType");

                entity.HasIndex(e => e.EmploymentName, "employmentName")
                    .IsUnique();

                entity.Property(e => e.EmploymentTypeId).HasColumnName("employmentTypeId");

                entity.Property(e => e.EmploymentName)
                    .IsRequired()
                    .HasColumnType("varchar(50)")
                    .HasColumnName("employmentName")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");
            });

            modelBuilder.Entity<JobDescription>(entity =>
            {
                entity.Property(e => e.JobDescriptionId).HasColumnName("jobDescriptionId");

                entity.Property(e => e.BasicSalary)
                    .HasPrecision(19, 4)
                    .HasColumnName("basicSalary");

                entity.Property(e => e.HousingAllowance)
                    .HasPrecision(19, 4)
                    .HasColumnName("housingAllowance");

                entity.Property(e => e.JobDescriptionName)
                    .IsRequired()
                    .HasColumnType("varchar(50)")
                    .HasColumnName("jobDescriptionName")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.TransportAllowance)
                    .HasPrecision(19, 4)
                    .HasColumnName("transportAllowance");
            });

            modelBuilder.Entity<Password>(entity =>
            {
                entity.HasKey(e => e.Email)
                    .HasName("PRIMARY");

                entity.HasIndex(e => e.Email, "email")
                    .IsUnique();

                entity.Property(e => e.Email)
                    .HasColumnType("varchar(50)")
                    .HasColumnName("email")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.Password1)
                    .IsRequired()
                    .HasColumnType("varchar(32)")
                    .HasColumnName("password")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");
            });

            modelBuilder.Entity<PayrollTransaction>(entity =>
            {
                entity.HasKey(e => e.TransactionId)
                    .HasName("PRIMARY");

                entity.HasIndex(e => e.EmployeeId, "employeeId");

                entity.Property(e => e.TransactionId).HasColumnName("transactionId");

                entity.Property(e => e.Balance)
                    .HasPrecision(15, 2)
                    .HasColumnName("balance");

                entity.Property(e => e.Deduction).HasColumnName("deduction");

                entity.Property(e => e.EmployeeId)
                    .IsRequired()
                    .HasColumnType("varchar(10)")
                    .HasColumnName("employeeId")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.Principal)
                    .HasPrecision(15, 2)
                    .HasColumnName("principal");

                entity.Property(e => e.Rate)
                    .HasPrecision(3, 2)
                    .HasColumnName("rate");

                entity.Property(e => e.Statutory).HasColumnName("statutory");

                entity.Property(e => e.TransactionDateTime)
                    .HasColumnType("datetime")
                    .HasColumnName("transactionDateTime");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.PayrollTransactions)
                    .HasForeignKey(d => d.EmployeeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("PayrollTransactions_ibfk_1");
            });

            modelBuilder.Entity<PensionFundAdministration>(entity =>
            {
                entity.HasKey(e => e.PfaCode)
                    .HasName("PRIMARY");

                entity.ToTable("PensionFundAdministration");

                entity.Property(e => e.PfaCode)
                    .HasColumnType("varchar(10)")
                    .HasColumnName("pfaCode")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.AccountNumber)
                    .IsRequired()
                    .HasColumnType("varchar(10)")
                    .HasColumnName("accountNumber")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.Address)
                    .IsRequired()
                    .HasColumnType("varchar(200)")
                    .HasColumnName("address")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.PfaName)
                    .IsRequired()
                    .HasColumnType("varchar(50)")
                    .HasColumnName("pfaName")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");
            });

            modelBuilder.Entity<StatutoryDeduction>(entity =>
            {
                entity.HasKey(e => e.StatutoryTypeId)
                    .HasName("PRIMARY");

                entity.HasIndex(e => e.EmployeeId, "employeeId");

                entity.HasIndex(e => e.PfaCode, "pfaCode");

                entity.Property(e => e.StatutoryTypeId).HasColumnName("statutoryTypeId");

                entity.Property(e => e.Amount1)
                    .HasPrecision(19, 4)
                    .HasColumnName("amount1");

                entity.Property(e => e.Amount2)
                    .HasPrecision(19, 4)
                    .HasColumnName("amount2");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasColumnType("text")
                    .HasColumnName("description")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.EmployeeId)
                    .IsRequired()
                    .HasColumnType("varchar(10)")
                    .HasColumnName("employeeId")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.PfaAccountNumber)
                    .IsRequired()
                    .HasColumnType("varchar(10)")
                    .HasColumnName("pfaAccountNumber")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.PfaAccountNumber1)
                    .IsRequired()
                    .HasColumnType("varchar(10)")
                    .HasColumnName("pfaAccountNumber1")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.PfaCode)
                    .IsRequired()
                    .HasColumnType("varchar(10)")
                    .HasColumnName("pfaCode")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.StatutoryDeductions)
                    .HasForeignKey(d => d.EmployeeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("StatutoryDeductions_ibfk_1");

                entity.HasOne(d => d.PfaCodeNavigation)
                    .WithMany(p => p.StatutoryDeductions)
                    .HasForeignKey(d => d.PfaCode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("StatutoryDeductions_ibfk_2");
            });

            modelBuilder.Entity<SystemDefault>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.Address)
                    .IsRequired()
                    .HasColumnType("varchar(200)")
                    .HasColumnName("address")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.CompanyName)
                    .IsRequired()
                    .HasColumnType("varchar(30)")
                    .HasColumnName("companyName")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasColumnType("varchar(50)")
                    .HasColumnName("email")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.MaxSalaryDays).HasColumnName("maxSalaryDays");

                entity.Property(e => e.MobileNumber)
                    .HasColumnType("varchar(15)")
                    .HasColumnName("mobileNumber")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.OfficialPhoneNumber)
                    .IsRequired()
                    .HasColumnType("varchar(15)")
                    .HasColumnName("officialPhoneNumber")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.PostalCode)
                    .HasColumnType("varchar(7)")
                    .HasColumnName("postalCode")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.SalaryEndDate)
                    .HasColumnType("date")
                    .HasColumnName("salaryEndDate");

                entity.Property(e => e.SalaryStartDate)
                    .HasColumnType("date")
                    .HasColumnName("salaryStartDate");

                entity.Property(e => e.WebsiteUrl)
                    .IsRequired()
                    .HasColumnType("varchar(100)")
                    .HasColumnName("websiteURL")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");
            });

            modelBuilder.Entity<Taxis>(entity =>
            {
                entity.HasNoKey();

                entity.HasIndex(e => e.EmployeeId, "employeeId")
                    .IsUnique();

                entity.Property(e => e.EmployeeId)
                    .IsRequired()
                    .HasColumnType("varchar(10)")
                    .HasColumnName("employeeId")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.Paye)
                    .HasPrecision(19, 4)
                    .HasColumnName("PAYE");

                entity.Property(e => e.Pension)
                    .HasPrecision(19, 4)
                    .HasColumnName("pension");

                entity.HasOne(d => d.Employee)
                    .WithOne()
                    .HasForeignKey<Taxis>(d => d.EmployeeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Taxes_ibfk_1");
            });

            modelBuilder.Entity<TimeSheet>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("TimeSheet");

                entity.HasIndex(e => e.EmployeeId, "employeeId");

                entity.Property(e => e.Date)
                    .HasColumnType("date")
                    .HasColumnName("date");

                entity.Property(e => e.EmployeeId)
                    .IsRequired()
                    .HasColumnType("varchar(10)")
                    .HasColumnName("employeeId")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.HoursWorked)
                    .HasColumnType("time")
                    .HasColumnName("hoursWorked");

                entity.Property(e => e.TimeIn)
                    .HasColumnType("time")
                    .HasColumnName("timeIn");

                entity.Property(e => e.TimeOut)
                    .HasColumnType("time")
                    .HasColumnName("timeOut");

                entity.HasOne(d => d.Employee)
                    .WithMany()
                    .HasForeignKey(d => d.EmployeeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("TimeSheet_ibfk_1");
            });

            modelBuilder.Entity<UserRole>(entity =>
            {
                entity.HasIndex(e => e.Role, "role")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Role)
                    .IsRequired()
                    .HasColumnType("varchar(30)")
                    .HasColumnName("role")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}