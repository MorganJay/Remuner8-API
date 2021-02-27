using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace API.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Banks",
                columns: table => new
                {
                    bankCode = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: false),
                    bankName = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Banks__7C3F297BF1E3C219", x => x.bankCode);
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
                name: "JobDescriptions",
                columns: table => new
                {
                    jobDescriptionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    jobDescriptionName = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    basicSalary = table.Column<decimal>(type: "decimal(19,4)", nullable: false),
                    housingAllowance = table.Column<decimal>(type: "decimal(19,4)", nullable: false),
                    transportAllowance = table.Column<decimal>(type: "decimal(19,4)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobDescriptions", x => x.jobDescriptionId);
                });

            migrationBuilder.CreateTable(
                name: "Passwords",
                columns: table => new
                {
                    email = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    password = table.Column<string>(type: "varchar(32)", unicode: false, maxLength: 32, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Password__AB6E6165CEDA53DD", x => x.email);
                });

            migrationBuilder.CreateTable(
                name: "PayrollAdditionItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CategoryId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    amount2 = table.Column<decimal>(type: "decimal(19,4)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PayrollAdditionItems", x => x.Id);
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
                name: "UserRoles",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    role = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRoles", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Bonuses",
                columns: table => new
                {
                    jobDescriptionId = table.Column<int>(type: "int", nullable: false),
                    departmentId = table.Column<int>(type: "int", nullable: false),
                    bonusName = table.Column<decimal>(type: "decimal(19,4)", nullable: false),
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
                    avatar = table.Column<byte[]>(type: "image", nullable: true),
                    firstName = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    lastName = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    otherName = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    dateOfBirth = table.Column<DateTime>(type: "date", nullable: false),
                    address = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: false),
                    phoneNumber = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    emailAddress = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    gender = table.Column<string>(type: "char(6)", unicode: false, fixedLength: true, maxLength: 6, nullable: false),
                    countryName = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: false),
                    stateName = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: false),
                    maritalStatus = table.Column<string>(type: "char(12)", unicode: false, fixedLength: true, maxLength: 12, nullable: false),
                    departmentId = table.Column<int>(type: "int", nullable: false),
                    jobDescriptionId = table.Column<int>(type: "int", nullable: false),
                    dateEmployed = table.Column<DateTime>(type: "date", nullable: false),
                    otherAllowances = table.Column<decimal>(type: "decimal(10,4)", nullable: true),
                    grossSalary = table.Column<decimal>(type: "decimal(19,4)", nullable: false),
                    bankCode = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: false),
                    accountNumber = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: false),
                    PayrollAdditionItemId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Employee__C134C9C1771E4F30", x => x.employeeId);
                    table.ForeignKey(
                        name: "FK__EmployeeB__bankC__3C69FB99",
                        column: x => x.bankCode,
                        principalTable: "Banks",
                        principalColumn: "bankCode",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__EmployeeB__depar__3A81B327",
                        column: x => x.departmentId,
                        principalTable: "Departments",
                        principalColumn: "departmentId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__EmployeeB__email__3D5E1FD2",
                        column: x => x.emailAddress,
                        principalTable: "Passwords",
                        principalColumn: "email",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__EmployeeB__jobDe__3B75D760",
                        column: x => x.jobDescriptionId,
                        principalTable: "JobDescriptions",
                        principalColumn: "jobDescriptionId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EmployeeBiodata_PayrollAdditionItems_PayrollAdditionItemId",
                        column: x => x.PayrollAdditionItemId,
                        principalTable: "PayrollAdditionItems",
                        principalColumn: "Id",
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
                    employeeId = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: false),
                    PAYE = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    pension = table.Column<decimal>(type: "decimal(19,4)", nullable: true)
                },
                constraints: table =>
                {
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
                    timeIn = table.Column<TimeSpan>(type: "time(0)", nullable: true),
                    timeOut = table.Column<TimeSpan>(type: "time(0)", nullable: true),
                    hoursWorked = table.Column<TimeSpan>(type: "time(0)", nullable: true)
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
                name: "UQ__Banks__3EA6523332347041",
                table: "Banks",
                column: "bankName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Bonuses_departmentId",
                table: "Bonuses",
                column: "departmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Bonuses_jobDescriptionId",
                table: "Bonuses",
                column: "jobDescriptionId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeBiodata_bankCode",
                table: "EmployeeBiodata",
                column: "bankCode");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeBiodata_departmentId",
                table: "EmployeeBiodata",
                column: "departmentId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeBiodata_jobDescriptionId",
                table: "EmployeeBiodata",
                column: "jobDescriptionId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeBiodata_PayrollAdditionItemId",
                table: "EmployeeBiodata",
                column: "PayrollAdditionItemId");

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
                name: "IX_PayrollTransactions_employeeId",
                table: "PayrollTransactions",
                column: "employeeId");

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

            migrationBuilder.CreateIndex(
                name: "UQ__UserRole__863D21484D4C2003",
                table: "UserRoles",
                column: "role",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Bonuses");

            migrationBuilder.DropTable(
                name: "EmploymentType");

            migrationBuilder.DropTable(
                name: "PayrollTransactions");

            migrationBuilder.DropTable(
                name: "StatutoryDeductions");

            migrationBuilder.DropTable(
                name: "SystemDefaults");

            migrationBuilder.DropTable(
                name: "Taxes");

            migrationBuilder.DropTable(
                name: "TimeSheet");

            migrationBuilder.DropTable(
                name: "UserRoles");

            migrationBuilder.DropTable(
                name: "PensionFundAdministration");

            migrationBuilder.DropTable(
                name: "EmployeeBiodata");

            migrationBuilder.DropTable(
                name: "Banks");

            migrationBuilder.DropTable(
                name: "Departments");

            migrationBuilder.DropTable(
                name: "Passwords");

            migrationBuilder.DropTable(
                name: "JobDescriptions");

            migrationBuilder.DropTable(
                name: "PayrollAdditionItems");
        }
    }
}
