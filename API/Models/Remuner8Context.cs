using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace API.Models
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

        public virtual DbSet<Assignee> Assignees { get; set; }
        public virtual DbSet<Bank> Banks { get; set; }
        public virtual DbSet<Bonus> Bonuses { get; set; }
        public virtual DbSet<Department> Departments { get; set; }
        public virtual DbSet<EmployeeBiodata> EmployeeBiodatas { get; set; }
        public virtual DbSet<EmploymentType> EmploymentTypes { get; set; }
        public virtual DbSet<JobDescription> JobDescriptions { get; set; }
        public virtual DbSet<Password> Passwords { get; set; }
        public virtual DbSet<PayrollAdditionItem> PayrollAdditionItems { get; set; }
        public virtual DbSet<PayrollCategory> PayrollCategories { get; set; }
        public virtual DbSet<PayrollDeductionItem> PayrollDeductionItems { get; set; }
        public virtual DbSet<PayrollOvertime> PayrollOvertimes { get; set; }
        public virtual DbSet<PayrollRate> PayrollRates { get; set; }
        public virtual DbSet<PayrollTransaction> PayrollTransactions { get; set; }
        public virtual DbSet<PensionFundAdministration> PensionFundAdministrations { get; set; }
        public virtual DbSet<StatutoryDeduction> StatutoryDeductions { get; set; }
        public virtual DbSet<SystemDefault> SystemDefaults { get; set; }
        public virtual DbSet<Tax> Taxes { get; set; }
        public virtual DbSet<TimeSheet> TimeSheets { get; set; }
        public virtual DbSet<UserRole> UserRoles { get; set; }

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

            modelBuilder.Entity<Assignee>(entity =>
            {
                entity.ToTable("Assignee");

                entity.Property(e => e.AssigneeId)
                    .ValueGeneratedNever()
                    .HasColumnName("assigneeId");

                entity.Property(e => e.AssigneeName)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("assigneeName");
            });

            modelBuilder.Entity<Bank>(entity =>
            {
                entity.HasKey(e => e.BankCode)
                    .HasName("PK__Banks__7C3F297BF1E3C219");

                entity.HasIndex(e => e.BankName, "UQ__Banks__3EA6523332347041")
                    .IsUnique();

                entity.Property(e => e.BankCode)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("bankCode");

                entity.Property(e => e.BankName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("bankName");
            });

            modelBuilder.Entity<Bonus>(entity =>
            {
                entity.HasNoKey();

                entity.HasIndex(e => e.DepartmentId, "IX_Bonuses_departmentId");

                entity.HasIndex(e => e.JobDescriptionId, "IX_Bonuses_jobDescriptionId");

                entity.Property(e => e.Amount)
                    .HasColumnType("decimal(19, 4)")
                    .HasColumnName("amount");

                entity.Property(e => e.BonusName)
                    .HasColumnType("decimal(19, 4)")
                    .HasColumnName("bonusName");

                entity.Property(e => e.DepartmentId).HasColumnName("departmentId");

                entity.Property(e => e.JobDescriptionId).HasColumnName("jobDescriptionId");

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
                entity.Property(e => e.DepartmentId).HasColumnName("departmentId");

                entity.Property(e => e.DepartmentName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("departmentName");
            });

            modelBuilder.Entity<EmployeeBiodata>(entity =>
            {
                entity.HasKey(e => e.EmployeeId)
                    .HasName("PK__Employee__C134C9C1771E4F30");

                entity.ToTable("EmployeeBiodata");

                entity.HasIndex(e => e.PayrollAdditionItemId, "IX_EmployeeBiodata_PayrollAdditionItemId");

                entity.HasIndex(e => e.BankCode, "IX_EmployeeBiodata_bankCode");

                entity.HasIndex(e => e.DepartmentId, "IX_EmployeeBiodata_departmentId");

                entity.HasIndex(e => e.JobDescriptionId, "IX_EmployeeBiodata_jobDescriptionId");

                entity.HasIndex(e => e.EmailAddress, "UQ__Employee__347C3027AEE39C36")
                    .IsUnique();

                entity.HasIndex(e => e.PhoneNumber, "UQ__Employee__4849DA01CAB71A88")
                    .IsUnique();

                entity.Property(e => e.EmployeeId)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("employeeId");

                entity.Property(e => e.AccountNumber)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("accountNumber");

                entity.Property(e => e.Address)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("address");

                entity.Property(e => e.Avatar)
                    .HasColumnType("image")
                    .HasColumnName("avatar");

                entity.Property(e => e.BankCode)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("bankCode");

                entity.Property(e => e.CountryName)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("countryName");

                entity.Property(e => e.DateEmployed)
                    .HasColumnType("date")
                    .HasColumnName("dateEmployed");

                entity.Property(e => e.DateOfBirth)
                    .HasColumnType("date")
                    .HasColumnName("dateOfBirth");

                entity.Property(e => e.DepartmentId).HasColumnName("departmentId");

                entity.Property(e => e.EmailAddress)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("emailAddress");

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("firstName");

                entity.Property(e => e.Gender)
                    .IsRequired()
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("gender")
                    .IsFixedLength(true);

                entity.Property(e => e.GrossSalary)
                    .HasColumnType("decimal(19, 4)")
                    .HasColumnName("grossSalary");

                entity.Property(e => e.JobDescriptionId).HasColumnName("jobDescriptionId");

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("lastName");

                entity.Property(e => e.MaritalStatus)
                    .IsRequired()
                    .HasMaxLength(12)
                    .IsUnicode(false)
                    .HasColumnName("maritalStatus")
                    .IsFixedLength(true);

                entity.Property(e => e.OtherAllowances)
                    .HasColumnType("decimal(10, 4)")
                    .HasColumnName("otherAllowances");

                entity.Property(e => e.OtherName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("otherName");

                entity.Property(e => e.PhoneNumber)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("phoneNumber");

                entity.Property(e => e.StateName)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("stateName");

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

                entity.HasOne(d => d.PayrollAdditionItem)
                    .WithMany(p => p.EmployeeBiodatas)
                    .HasForeignKey(d => d.PayrollAdditionItemId);
            });

            modelBuilder.Entity<EmploymentType>(entity =>
            {
                entity.ToTable("EmploymentType");

                entity.HasIndex(e => e.EmploymentName, "UQ__Employme__7E571DB88372C814")
                    .IsUnique();

                entity.Property(e => e.EmploymentTypeId).HasColumnName("employmentTypeId");

                entity.Property(e => e.EmploymentName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("employmentName");
            });

            modelBuilder.Entity<JobDescription>(entity =>
            {
                entity.Property(e => e.JobDescriptionId).HasColumnName("jobDescriptionId");

                entity.Property(e => e.BasicSalary)
                    .HasColumnType("decimal(19, 4)")
                    .HasColumnName("basicSalary");

                entity.Property(e => e.HousingAllowance)
                    .HasColumnType("decimal(19, 4)")
                    .HasColumnName("housingAllowance");

                entity.Property(e => e.JobDescriptionName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("jobDescriptionName");

                entity.Property(e => e.TransportAllowance)
                    .HasColumnType("decimal(19, 4)")
                    .HasColumnName("transportAllowance");
            });

            modelBuilder.Entity<Password>(entity =>
            {
                entity.HasKey(e => e.Email)
                    .HasName("PK__Password__AB6E6165CEDA53DD");

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("email");

                entity.Property(e => e.Password1)
                    .IsRequired()
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasColumnName("password");
            });

            modelBuilder.Entity<PayrollAdditionItem>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Amount)
                    .HasColumnType("decimal(19, 4)")
                    .HasColumnName("amount");

                entity.Property(e => e.CategoryId).HasColumnName("categoryId");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name");
            });

            modelBuilder.Entity<PayrollCategory>(entity =>
            {
                entity.HasKey(e => e.CategoryId)
                    .HasName("PK__PayrollC__23CDE5900CA6AF29");

                entity.ToTable("PayrollCategory");

                entity.Property(e => e.CategoryId)
                    .ValueGeneratedNever()
                    .HasColumnName("categoryId");

                entity.Property(e => e.CategoryName)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("categoryName");
            });

            modelBuilder.Entity<PayrollDeductionItem>(entity =>
            {
                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.Amount)
                    .HasColumnType("decimal(19, 4)")
                    .HasColumnName("amount");

                entity.Property(e => e.AssigneeId).HasColumnName("assigneeId");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("name");
            });

            modelBuilder.Entity<PayrollOvertime>(entity =>
            {
                entity.ToTable("PayrollOvertime");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("name");

                entity.Property(e => e.Rate)
                    .HasColumnType("decimal(3, 2)")
                    .HasColumnName("rate");

                entity.Property(e => e.Rateid).HasColumnName("rateid");
            });

            modelBuilder.Entity<PayrollRate>(entity =>
            {
                entity.HasKey(e => e.RateId)
                    .HasName("PK__PayrollR__5704EE3CAC8CC71B");

                entity.ToTable("PayrollRate");

                entity.Property(e => e.RateId)
                    .ValueGeneratedNever()
                    .HasColumnName("rateId");

                entity.Property(e => e.RateType)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("rateType");
            });

            modelBuilder.Entity<PayrollTransaction>(entity =>
            {
                entity.HasKey(e => e.TransactionId)
                    .HasName("PK__PayrollT__9B57CF7249445F48");

                entity.HasIndex(e => e.EmployeeId, "IX_PayrollTransactions_employeeId");

                entity.Property(e => e.TransactionId).HasColumnName("transactionId");

                entity.Property(e => e.Balance)
                    .HasColumnType("decimal(15, 2)")
                    .HasColumnName("balance");

                entity.Property(e => e.Deduction).HasColumnName("deduction");

                entity.Property(e => e.EmployeeId)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("employeeId");

                entity.Property(e => e.Principal)
                    .HasColumnType("decimal(15, 2)")
                    .HasColumnName("principal");

                entity.Property(e => e.Rate)
                    .HasColumnType("decimal(3, 2)")
                    .HasColumnName("rate");

                entity.Property(e => e.Statutory).HasColumnName("statutory");

                entity.Property(e => e.TransactionDateTime)
                    .HasPrecision(0)
                    .HasColumnName("transactionDateTime");

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

                entity.ToTable("PensionFundAdministration");

                entity.Property(e => e.PfaCode)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("pfaCode");

                entity.Property(e => e.AccountNumber)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("accountNumber");

                entity.Property(e => e.Address)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("address");

                entity.Property(e => e.PfaName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("pfaName");
            });

            modelBuilder.Entity<StatutoryDeduction>(entity =>
            {
                entity.HasKey(e => e.StatutoryTypeId)
                    .HasName("PK__Statutor__8001A5961FCE4767");

                entity.HasIndex(e => e.EmployeeId, "IX_StatutoryDeductions_employeeId");

                entity.HasIndex(e => e.PfaCode, "IX_StatutoryDeductions_pfaCode");

                entity.Property(e => e.StatutoryTypeId).HasColumnName("statutoryTypeId");

                entity.Property(e => e.Amount1)
                    .HasColumnType("decimal(19, 4)")
                    .HasColumnName("amount1");

                entity.Property(e => e.Amount2)
                    .HasColumnType("decimal(19, 4)")
                    .HasColumnName("amount2");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .IsUnicode(false)
                    .HasColumnName("description");

                entity.Property(e => e.EmployeeId)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("employeeId");

                entity.Property(e => e.PfaAccountNumber)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("pfaAccountNumber");

                entity.Property(e => e.PfaAccountNumber1)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("pfaAccountNumber1");

                entity.Property(e => e.PfaCode)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("pfaCode");

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
                entity.HasNoKey();

                entity.Property(e => e.Address)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("address");

                entity.Property(e => e.CompanyName)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("companyName");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("email");

                entity.Property(e => e.MaxSalaryDays).HasColumnName("maxSalaryDays");

                entity.Property(e => e.MobileNumber)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("mobileNumber");

                entity.Property(e => e.OfficialPhoneNumber)
                    .IsRequired()
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("officialPhoneNumber");

                entity.Property(e => e.PostalCode)
                    .HasMaxLength(7)
                    .IsUnicode(false)
                    .HasColumnName("postalCode");

                entity.Property(e => e.SalaryEndDate)
                    .HasColumnType("date")
                    .HasColumnName("salaryEndDate");

                entity.Property(e => e.SalaryStartDate)
                    .HasColumnType("date")
                    .HasColumnName("salaryStartDate");

                entity.Property(e => e.WebsiteUrl)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("websiteURL");
            });

            modelBuilder.Entity<Tax>(entity =>
            {
                entity.HasNoKey();

                entity.HasIndex(e => e.EmployeeId, "UQ__Taxes__C134C9C0AE6154C9")
                    .IsUnique();

                entity.Property(e => e.EmployeeId)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("employeeId");

                entity.Property(e => e.Paye)
                    .HasColumnType("decimal(19, 4)")
                    .HasColumnName("PAYE");

                entity.Property(e => e.Pension)
                    .HasColumnType("decimal(19, 4)")
                    .HasColumnName("pension");

                entity.HasOne(d => d.Employee)
                    .WithOne()
                    .HasForeignKey<Tax>(d => d.EmployeeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Taxes__employeeI__48CFD27E");
            });

            modelBuilder.Entity<TimeSheet>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("TimeSheet");

                entity.HasIndex(e => e.EmployeeId, "IX_TimeSheet_employeeId");

                entity.Property(e => e.Date)
                    .HasColumnType("date")
                    .HasColumnName("date");

                entity.Property(e => e.EmployeeId)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("employeeId");

                entity.Property(e => e.HoursWorked)
                    .HasColumnType("time(0)")
                    .HasColumnName("hoursWorked");

                entity.Property(e => e.TimeIn)
                    .HasColumnType("time(0)")
                    .HasColumnName("timeIn");

                entity.Property(e => e.TimeOut)
                    .HasColumnType("time(0)")
                    .HasColumnName("timeOut");

                entity.HasOne(d => d.Employee)
                    .WithMany()
                    .HasForeignKey(d => d.EmployeeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__TimeSheet__emplo__45F365D3");
            });

            modelBuilder.Entity<UserRole>(entity =>
            {
                entity.HasIndex(e => e.Role, "UQ__UserRole__863D21484D4C2003")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Role)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("role");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
