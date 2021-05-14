using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace API.Models
{
    public partial class Remuner8Context : IdentityDbContext<ApplicationUser>
    {
        public Remuner8Context(DbContextOptions<Remuner8Context> options)
            : base(options)
        {
        }

        public virtual DbSet<AssigneeTable> AssigneeTables { get; set; }
        public virtual DbSet<Bonus> Bonuses { get; set; }
        public virtual DbSet<Department> Departments { get; set; }
        public virtual DbSet<EmployeeBiodata> EmployeeBiodatas { get; set; }
        public virtual DbSet<EmploymentType> EmploymentTypes { get; set; }
        public virtual DbSet<JobDescription> JobDescriptions { get; set; }
        public virtual DbSet<RefreshToken> RefreshTokens { get; set; }
        public virtual DbSet<LeaveType> LeaveTypes { get; set; }
        public virtual DbSet<PayrollAdditionItem> PayrollAdditionItems { get; set; }
        public virtual DbSet<PayrollAdditionItemsAssignment> PayrollAdditionItemsAssignments { get; set; }
        public virtual DbSet<PayrollCategory> PayrollCategories { get; set; }
        public virtual DbSet<PayrollDeductionItem> PayrollDeductionItems { get; set; }
        public virtual DbSet<PayrollDeductionItemsAssignment> PayrollDeductionItemsAssignments { get; set; }
        public virtual DbSet<PayrollDefault> PayrollDefaults { get; set; }
        public virtual DbSet<PayrollOvertimeItem> PayrollOvertimeItems { get; set; }
        public virtual DbSet<PayrollOvertimeItemsAssignment> PayrollOvertimeItemsAssignments { get; set; }
        public virtual DbSet<PayrollRate> PayrollRates { get; set; }
        public virtual DbSet<PayrollTransaction> PayrollTransactions { get; set; }
        public virtual DbSet<Payslip> Payslips { get; set; }
        public virtual DbSet<PensionFundAdministration> PensionFundAdministrations { get; set; }
        public virtual DbSet<Request> Requests { get; set; }
        public virtual DbSet<StatutoryDeduction> StatutoryDeductions { get; set; }
        public virtual DbSet<SystemDefault> SystemDefaults { get; set; }
        public virtual DbSet<Tax> Taxes { get; set; }
        public virtual DbSet<TimeSheet> TimeSheets { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Name=Remuner8DB");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<AssigneeTable>(entity =>
            {
                entity.HasKey(e => e.Assigneeid)
                    .HasName("PK__Assignee__52B4679E1CEB1FA5");

                entity.Property(e => e.AssigneeName).IsUnicode(false);
            });

            modelBuilder.Entity<Bonus>(entity =>
            {
                entity.Property(e => e.BonusName).IsUnicode(false);

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

                entity.Property(e => e.Avatar).IsUnicode(false);

                entity.Property(e => e.BankName).IsUnicode(false);

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

                entity.HasOne(d => d.Department)
                    .WithMany(p => p.EmployeeBiodatas)
                    .HasForeignKey(d => d.DepartmentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__EmployeeB__depar__3A81B327");

                //entity.HasOne(d => d.EmailAddressNavigation)
                //    .WithOne(p => p.EmployeeBiodata)
                //    .HasForeignKey<EmployeeBiodata>(d => d.EmailAddress)
                //    .OnDelete(DeleteBehavior.ClientSetNull)
                //    .HasConstraintName("FK__EmployeeB__email__3D5E1FD2");

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

                entity.HasOne(d => d.Department)
                    .WithMany(p => p.JobDescriptions)
                    .HasForeignKey(d => d.DepartmentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_JobDescriptions_Departments");
            });

            modelBuilder.Entity<LeaveType>(entity =>
            {
                entity.Property(e => e.Name).IsUnicode(false);
            });

            modelBuilder.Entity<PayrollAdditionItem>(entity =>
            {
                entity.Property(e => e.Name).IsUnicode(false);

                entity.HasOne(d => d.Assignee)
                    .WithMany(p => p.PayrollAdditionItems)
                    .HasForeignKey(d => d.AssigneeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PayrollAdditionItems_AssigneeTable");

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.PayrollAdditionItems)
                    .HasForeignKey(d => d.CategoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PayrollAdditionItems_PayrollCategories");
            });

            modelBuilder.Entity<PayrollAdditionItemsAssignment>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.EmployeeId).IsUnicode(false);

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.PayrollAdditionItemsAssignments)
                    .HasForeignKey(d => d.EmployeeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PayrollAdditionItemsAssignment_EmployeeBiodata");

                entity.HasOne(d => d.PayrollItem)
                    .WithMany(p => p.PayrollAdditionItemsAssignments)
                    .HasForeignKey(d => d.PayrollItemId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PayrollAdditionItemsAssignment_PayrollAdditionItems");
            });

            modelBuilder.Entity<PayrollCategory>(entity =>
            {
                entity.HasKey(e => e.CategoryId)
                    .HasName("PK__PayrollC__23CAF1D8676751FC");

                entity.Property(e => e.CategoryName).IsUnicode(false);
            });

            modelBuilder.Entity<PayrollDeductionItem>(entity =>
            {
                entity.Property(e => e.Name).IsUnicode(false);

                entity.HasOne(d => d.Assignee)
                    .WithMany(p => p.PayrollDeductionItems)
                    .HasForeignKey(d => d.AssigneeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PayrollDeductionItems_AssigneeTable");
            });

            modelBuilder.Entity<PayrollDeductionItemsAssignment>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.EmployeeId).IsUnicode(false);

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.PayrollDeductionItemsAssignments)
                    .HasForeignKey(d => d.EmployeeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PayrollDeductionItemsAssignment_EmployeeBiodata");

                entity.HasOne(d => d.PayrollItem)
                    .WithMany(p => p.PayrollDeductionItemsAssignments)
                    .HasForeignKey(d => d.PayrollItemId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PayrollDeductionItemsAssignment_PayrollDeductionItems");
            });

            modelBuilder.Entity<PayrollDefault>(entity =>
            {
                entity.Property(e => e.Address).IsUnicode(false);

                entity.Property(e => e.Office).IsUnicode(false);

                entity.Property(e => e.Tax).IsUnicode(false);
            });

            modelBuilder.Entity<PayrollOvertimeItem>(entity =>
            {
                entity.Property(e => e.Name).IsUnicode(false);

                entity.HasOne(d => d.Rate)
                    .WithMany(p => p.PayrollOvertimeItems)
                    .HasForeignKey(d => d.Rateid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PayrollOvertimeItems_PayrollRates");
            });

            modelBuilder.Entity<PayrollOvertimeItemsAssignment>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.EmployeeId).IsUnicode(false);

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.PayrollOvertimeItemsAssignments)
                    .HasForeignKey(d => d.EmployeeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PayrollOvertimeItemsAssignment_EmployeeBiodata");

                entity.HasOne(d => d.PayrollItem)
                    .WithMany(p => p.PayrollOvertimeItemsAssignments)
                    .HasForeignKey(d => d.PayrollItemId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PayrollOvertimeItemsAssignment_PayrollOvertimeItems");
            });

            modelBuilder.Entity<PayrollRate>(entity =>
            {
                entity.HasKey(e => e.RateId)
                    .HasName("PK__PayrollR__5705EA1446EDB076");

                entity.Property(e => e.RateType).IsUnicode(false);
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

            modelBuilder.Entity<Payslip>(entity =>
            {
                entity.Property(e => e.PayslipId).IsUnicode(false);

                entity.Property(e => e.Date).IsUnicode(false);

                entity.Property(e => e.EmployeeId).IsUnicode(false);

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.Payslips)
                    .HasForeignKey(d => d.EmployeeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Payslip_EmployeeBiodata");
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

            modelBuilder.Entity<Request>(entity =>
            {
                entity.Property(e => e.Date).IsUnicode(false);

                entity.Property(e => e.Name).IsUnicode(false);

                entity.Property(e => e.Reason).IsUnicode(false);

                entity.Property(e => e.Status).IsUnicode(false);
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
                    .WithOne(p => p.Tax)
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

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}