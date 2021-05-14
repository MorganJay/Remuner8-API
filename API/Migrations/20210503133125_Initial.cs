using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace API.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AssigneeTable",
                columns: table => new
                {
                    assigneeid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    assigneeName = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Assignee__52B4679E1CEB1FA5", x => x.assigneeid);
                });

            migrationBuilder.CreateTable(
                name: "Departments",
                columns: table => new
                {
                    departmentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    departmentName = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departments", x => x.departmentId);
                });

            migrationBuilder.CreateTable(
                name: "EmploymentType",
                columns: table => new
                {
                    employmentTypeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    employmentName = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmploymentType", x => x.employmentTypeId);
                });

            migrationBuilder.CreateTable(
                name: "LeaveTypes",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    days = table.Column<int>(type: "int", nullable: false),
                    status = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LeaveTypes", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "PayrollCategories",
                columns: table => new
                {
                    categoryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    categoryName = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__PayrollC__23CAF1D8676751FC", x => x.categoryId);
                });

            migrationBuilder.CreateTable(
                name: "PayrollDefaults",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MinimumSalaryPeriod = table.Column<DateTime>(type: "date", nullable: false),
                    MaximumSalaryPeriod = table.Column<DateTime>(type: "date", nullable: false),
                    MaxWorkingDays = table.Column<int>(type: "int", nullable: false),
                    MaxOvertimeHours = table.Column<int>(type: "int", nullable: false),
                    MinTaxPercentage = table.Column<decimal>(type: "decimal(5,2)", nullable: false),
                    NonTaxableIncome = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    FirstAnnualTaxableIncome = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    SecondAnnualTaxableIncome = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ThirdAnnualTaxableIncome = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    FourthAnnualTaxableIncome = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    FifthAnnualTaxableIncome = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    SixthAnnualTaxableIncome = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Tax = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
                    Office = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    Address = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PayrollDefaults", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "PayrollRates",
                columns: table => new
                {
                    rateId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    rateType = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__PayrollR__5705EA1446EDB076", x => x.rateId);
                });

            migrationBuilder.CreateTable(
                name: "PensionFundAdministration",
                columns: table => new
                {
                    pfaCode = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: false),
                    pfaName = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    accountNumber = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: false),
                    address = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__PensionF__056D327AA7859729", x => x.pfaCode);
                });

            migrationBuilder.CreateTable(
                name: "Requests",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
                    Date = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    Reason = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    Status = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Requests", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SystemDefaults",
                columns: table => new
                {
                    companyName = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: false),
                    address = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: false),
                    email = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    officialPhoneNumber = table.Column<string>(type: "varchar(15)", unicode: false, maxLength: 15, nullable: false),
                    mobileNumber = table.Column<string>(type: "varchar(15)", unicode: false, maxLength: 15, nullable: true),
                    websiteURL = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    postalCode = table.Column<string>(type: "varchar(7)", unicode: false, maxLength: 7, nullable: true),
                    maxSalaryDays = table.Column<int>(type: "int", nullable: false),
                    salaryStartDate = table.Column<DateTime>(type: "date", nullable: false),
                    salaryEndDate = table.Column<DateTime>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RefreshTokens",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Token = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    JwtId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsUsed = table.Column<bool>(type: "bit", nullable: false),
                    IsRevoked = table.Column<bool>(type: "bit", nullable: false),
                    AddedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ExpiryDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RefreshTokens", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RefreshTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PayrollDeductionItems",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    amount = table.Column<decimal>(type: "decimal(19,4)", nullable: false),
                    assigneeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PayrollDeductionItems", x => x.id);
                    table.ForeignKey(
                        name: "FK_PayrollDeductionItems_AssigneeTable",
                        column: x => x.assigneeId,
                        principalTable: "AssigneeTable",
                        principalColumn: "assigneeid",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "JobDescriptions",
                columns: table => new
                {
                    jobDescriptionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    jobDescriptionName = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    basicSalary = table.Column<decimal>(type: "decimal(19,4)", nullable: false),
                    housingAllowance = table.Column<decimal>(type: "decimal(19,4)", nullable: false),
                    transportAllowance = table.Column<decimal>(type: "decimal(19,4)", nullable: false),
                    departmentId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobDescriptions", x => x.jobDescriptionId);
                    table.ForeignKey(
                        name: "FK_JobDescriptions_Departments",
                        column: x => x.departmentId,
                        principalTable: "Departments",
                        principalColumn: "departmentId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PayrollAdditionItems",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    categoryId = table.Column<int>(type: "int", nullable: false),
                    amount = table.Column<decimal>(type: "decimal(19,4)", nullable: false),
                    assigneeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PayrollAdditionItems", x => x.id);
                    table.ForeignKey(
                        name: "FK_PayrollAdditionItems_AssigneeTable",
                        column: x => x.assigneeId,
                        principalTable: "AssigneeTable",
                        principalColumn: "assigneeid",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PayrollAdditionItems_PayrollCategories",
                        column: x => x.categoryId,
                        principalTable: "PayrollCategories",
                        principalColumn: "categoryId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PayrollOvertimeItems",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: false),
                    rateid = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PayrollOvertimeItems", x => x.id);
                    table.ForeignKey(
                        name: "FK_PayrollOvertimeItems_PayrollRates",
                        column: x => x.rateid,
                        principalTable: "PayrollRates",
                        principalColumn: "rateId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Bonuses",
                columns: table => new
                {
                    jobDescriptionId = table.Column<int>(type: "int", nullable: false),
                    departmentId = table.Column<int>(type: "int", nullable: false),
                    bonusName = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    amount = table.Column<decimal>(type: "decimal(19,4)", nullable: false)
                },
                constraints: table =>
                {
                    table.ForeignKey(
                        name: "FK__Bonuses__departm__2B3F6F97",
                        column: x => x.departmentId,
                        principalTable: "Departments",
                        principalColumn: "departmentId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__Bonuses__jobDesc__2C3393D0",
                        column: x => x.jobDescriptionId,
                        principalTable: "JobDescriptions",
                        principalColumn: "jobDescriptionId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "EmployeeBiodata",
                columns: table => new
                {
                    employeeId = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: false),
                    avatar = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
                    firstName = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    lastName = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    otherName = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    dateOfBirth = table.Column<DateTime>(type: "date", nullable: false),
                    address = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: false),
                    phoneNumber = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    emailAddress = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    gender = table.Column<string>(type: "char(6)", unicode: false, fixedLength: true, maxLength: 6, nullable: false),
                    countryName = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: false),
                    stateName = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: false),
                    maritalStatus = table.Column<string>(type: "char(12)", unicode: false, fixedLength: true, maxLength: 12, nullable: false),
                    departmentId = table.Column<int>(type: "int", nullable: false),
                    jobDescriptionId = table.Column<int>(type: "int", nullable: false),
                    dateEmployed = table.Column<DateTime>(type: "date", nullable: false),
                    otherAllowances = table.Column<decimal>(type: "decimal(19,4)", nullable: false),
                    grossSalary = table.Column<decimal>(type: "decimal(19,4)", nullable: false),
                    bankName = table.Column<string>(type: "varchar(150)", unicode: false, maxLength: 150, nullable: false),
                    accountNumber = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Employee__C134C9C1771E4F30", x => x.employeeId);
                    table.ForeignKey(
                        name: "FK__EmployeeB__depar__3A81B327",
                        column: x => x.departmentId,
                        principalTable: "Departments",
                        principalColumn: "departmentId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__EmployeeB__jobDe__3B75D760",
                        column: x => x.jobDescriptionId,
                        principalTable: "JobDescriptions",
                        principalColumn: "jobDescriptionId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PayrollAdditionItemsAssignment",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false),
                    PayrollItemId = table.Column<int>(type: "int", nullable: false),
                    EmployeeId = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(19,4)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PayrollAdditionItemsAssignment", x => x.id);
                    table.ForeignKey(
                        name: "FK_PayrollAdditionItemsAssignment_EmployeeBiodata",
                        column: x => x.EmployeeId,
                        principalTable: "EmployeeBiodata",
                        principalColumn: "employeeId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PayrollAdditionItemsAssignment_PayrollAdditionItems",
                        column: x => x.PayrollItemId,
                        principalTable: "PayrollAdditionItems",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PayrollDeductionItemsAssignment",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false),
                    PayrollItemId = table.Column<int>(type: "int", nullable: false),
                    EmployeeId = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(19,4)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PayrollDeductionItemsAssignment", x => x.id);
                    table.ForeignKey(
                        name: "FK_PayrollDeductionItemsAssignment_EmployeeBiodata",
                        column: x => x.EmployeeId,
                        principalTable: "EmployeeBiodata",
                        principalColumn: "employeeId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PayrollDeductionItemsAssignment_PayrollDeductionItems",
                        column: x => x.PayrollItemId,
                        principalTable: "PayrollDeductionItems",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PayrollOvertimeItemsAssignment",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false),
                    PayrollItemId = table.Column<int>(type: "int", nullable: false),
                    EmployeeId = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(19,4)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PayrollOvertimeItemsAssignment", x => x.id);
                    table.ForeignKey(
                        name: "FK_PayrollOvertimeItemsAssignment_EmployeeBiodata",
                        column: x => x.EmployeeId,
                        principalTable: "EmployeeBiodata",
                        principalColumn: "employeeId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PayrollOvertimeItemsAssignment_PayrollOvertimeItems",
                        column: x => x.PayrollItemId,
                        principalTable: "PayrollOvertimeItems",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PayrollTransactions",
                columns: table => new
                {
                    transactionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    employeeId = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: false),
                    transactionDateTime = table.Column<DateTime>(type: "datetime2(0)", precision: 0, nullable: false),
                    deduction = table.Column<bool>(type: "bit", nullable: false),
                    principal = table.Column<decimal>(type: "decimal(15,2)", nullable: false),
                    rate = table.Column<decimal>(type: "decimal(3,2)", nullable: false),
                    balance = table.Column<decimal>(type: "decimal(15,2)", nullable: false),
                    statutory = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__PayrollT__9B57CF7249445F48", x => x.transactionId);
                    table.ForeignKey(
                        name: "FK__PayrollTr__emplo__440B1D61",
                        column: x => x.employeeId,
                        principalTable: "EmployeeBiodata",
                        principalColumn: "employeeId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Payslip",
                columns: table => new
                {
                    payslipId = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: false),
                    date = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    employeeId = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: false),
                    totalEarnings = table.Column<decimal>(type: "decimal(19,4)", nullable: false),
                    totalDeductions = table.Column<decimal>(type: "decimal(19,4)", nullable: false),
                    netSalary = table.Column<decimal>(type: "decimal(19,4)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payslip", x => x.payslipId);
                    table.ForeignKey(
                        name: "FK_Payslip_EmployeeBiodata",
                        column: x => x.employeeId,
                        principalTable: "EmployeeBiodata",
                        principalColumn: "employeeId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "StatutoryDeductions",
                columns: table => new
                {
                    statutoryTypeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    employeeId = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: false),
                    amount1 = table.Column<decimal>(type: "decimal(19,4)", nullable: false),
                    amount2 = table.Column<decimal>(type: "decimal(19,4)", nullable: false),
                    pfaCode = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: false),
                    pfaAccountNumber = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: false),
                    pfaAccountNumber1 = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: false),
                    description = table.Column<string>(type: "varchar(max)", unicode: false, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Statutor__8001A5961FCE4767", x => x.statutoryTypeId);
                    table.ForeignKey(
                        name: "FK__Statutory__emplo__403A8C7D",
                        column: x => x.employeeId,
                        principalTable: "EmployeeBiodata",
                        principalColumn: "employeeId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__Statutory__pfaCo__412EB0B6",
                        column: x => x.pfaCode,
                        principalTable: "PensionFundAdministration",
                        principalColumn: "pfaCode",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Taxes",
                columns: table => new
                {
                    taxId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    employeeId = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: false),
                    PAYE = table.Column<decimal>(type: "decimal(19,4)", nullable: false),
                    pension = table.Column<decimal>(type: "decimal(19,4)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Taxes", x => x.taxId);
                    table.ForeignKey(
                        name: "FK__Taxes__employeeI__48CFD27E",
                        column: x => x.employeeId,
                        principalTable: "EmployeeBiodata",
                        principalColumn: "employeeId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TimeSheet",
                columns: table => new
                {
                    employeeId = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: false),
                    date = table.Column<DateTime>(type: "date", nullable: false),
                    timeIn = table.Column<TimeSpan>(type: "time(0)", nullable: false),
                    timeOut = table.Column<TimeSpan>(type: "time(0)", nullable: false),
                    hoursWorked = table.Column<TimeSpan>(type: "time(0)", nullable: false)
                },
                constraints: table =>
                {
                    table.ForeignKey(
                        name: "FK__TimeSheet__emplo__45F365D3",
                        column: x => x.employeeId,
                        principalTable: "EmployeeBiodata",
                        principalColumn: "employeeId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Bonuses_departmentId",
                table: "Bonuses",
                column: "departmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Bonuses_jobDescriptionId",
                table: "Bonuses",
                column: "jobDescriptionId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeBiodata_departmentId",
                table: "EmployeeBiodata",
                column: "departmentId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeBiodata_jobDescriptionId",
                table: "EmployeeBiodata",
                column: "jobDescriptionId");

            migrationBuilder.CreateIndex(
                name: "UQ__Employee__347C3027AEE39C36",
                table: "EmployeeBiodata",
                column: "emailAddress",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "UQ__Employee__4849DA01CAB71A88",
                table: "EmployeeBiodata",
                column: "phoneNumber",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "UQ__Employme__7E571DB88372C814",
                table: "EmploymentType",
                column: "employmentName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_JobDescriptions_departmentId",
                table: "JobDescriptions",
                column: "departmentId");

            migrationBuilder.CreateIndex(
                name: "UQ__LeaveTyp__72E12F1BF20C58BD",
                table: "LeaveTypes",
                column: "name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PayrollAdditionItems_AssigneeTableAssigneeid",
                table: "PayrollAdditionItems",
                column: "assigneeId");

            migrationBuilder.CreateIndex(
                name: "IX_PayrollAdditionItems_PayrollCategoryCategoryId",
                table: "PayrollAdditionItems",
                column: "categoryId");

            migrationBuilder.CreateIndex(
                name: "IX_PayrollAdditionItemsAssignment_EmployeeId",
                table: "PayrollAdditionItemsAssignment",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_PayrollAdditionItemsAssignment_PayrollItemId",
                table: "PayrollAdditionItemsAssignment",
                column: "PayrollItemId");

            migrationBuilder.CreateIndex(
                name: "IX_PayrollDeductionItems_assigneeId",
                table: "PayrollDeductionItems",
                column: "assigneeId");

            migrationBuilder.CreateIndex(
                name: "IX_PayrollDeductionItemsAssignment_EmployeeId",
                table: "PayrollDeductionItemsAssignment",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_PayrollDeductionItemsAssignment_PayrollItemId",
                table: "PayrollDeductionItemsAssignment",
                column: "PayrollItemId");

            migrationBuilder.CreateIndex(
                name: "IX_PayrollOvertimeItems_rateid",
                table: "PayrollOvertimeItems",
                column: "rateid");

            migrationBuilder.CreateIndex(
                name: "IX_PayrollOvertimeItemsAssignment_EmployeeId",
                table: "PayrollOvertimeItemsAssignment",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_PayrollOvertimeItemsAssignment_PayrollItemId",
                table: "PayrollOvertimeItemsAssignment",
                column: "PayrollItemId");

            migrationBuilder.CreateIndex(
                name: "IX_PayrollTransactions_employeeId",
                table: "PayrollTransactions",
                column: "employeeId");

            migrationBuilder.CreateIndex(
                name: "IX_Payslip_employeeId",
                table: "Payslip",
                column: "employeeId");

            migrationBuilder.CreateIndex(
                name: "IX_RefreshTokens_UserId",
                table: "RefreshTokens",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_StatutoryDeductions_employeeId",
                table: "StatutoryDeductions",
                column: "employeeId");

            migrationBuilder.CreateIndex(
                name: "IX_StatutoryDeductions_pfaCode",
                table: "StatutoryDeductions",
                column: "pfaCode");

            migrationBuilder.CreateIndex(
                name: "UQ__Taxes__C134C9C0AE6154C9",
                table: "Taxes",
                column: "employeeId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TimeSheet_employeeId",
                table: "TimeSheet",
                column: "employeeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Bonuses");

            migrationBuilder.DropTable(
                name: "EmploymentType");

            migrationBuilder.DropTable(
                name: "LeaveTypes");

            migrationBuilder.DropTable(
                name: "PayrollAdditionItemsAssignment");

            migrationBuilder.DropTable(
                name: "PayrollDeductionItemsAssignment");

            migrationBuilder.DropTable(
                name: "PayrollDefaults");

            migrationBuilder.DropTable(
                name: "PayrollOvertimeItemsAssignment");

            migrationBuilder.DropTable(
                name: "PayrollTransactions");

            migrationBuilder.DropTable(
                name: "Payslip");

            migrationBuilder.DropTable(
                name: "RefreshTokens");

            migrationBuilder.DropTable(
                name: "Requests");

            migrationBuilder.DropTable(
                name: "StatutoryDeductions");

            migrationBuilder.DropTable(
                name: "SystemDefaults");

            migrationBuilder.DropTable(
                name: "Taxes");

            migrationBuilder.DropTable(
                name: "TimeSheet");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "PayrollAdditionItems");

            migrationBuilder.DropTable(
                name: "PayrollDeductionItems");

            migrationBuilder.DropTable(
                name: "PayrollOvertimeItems");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "PensionFundAdministration");

            migrationBuilder.DropTable(
                name: "EmployeeBiodata");

            migrationBuilder.DropTable(
                name: "PayrollCategories");

            migrationBuilder.DropTable(
                name: "AssigneeTable");

            migrationBuilder.DropTable(
                name: "PayrollRates");

            migrationBuilder.DropTable(
                name: "JobDescriptions");

            migrationBuilder.DropTable(
                name: "Departments");
        }
    }
}