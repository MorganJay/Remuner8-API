using Microsoft.EntityFrameworkCore.Migrations;

namespace API.Migrations
{
    public partial class SecondMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK__EmployeeB__bankC__3C69FB99",
                table: "EmployeeBiodata");

            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeBiodata_PayrollAdditionItems_PayrollAdditionItemId",
                table: "EmployeeBiodata");

            migrationBuilder.DropTable(
                name: "Banks");

            migrationBuilder.DropIndex(
                name: "IX_EmployeeBiodata_bankCode",
                table: "EmployeeBiodata");

            migrationBuilder.DropIndex(
                name: "IX_EmployeeBiodata_PayrollAdditionItemId",
                table: "EmployeeBiodata");

            migrationBuilder.DropColumn(
                name: "PayrollAdditionItemId",
                table: "EmployeeBiodata");

            migrationBuilder.DropColumn(
                name: "bankCode",
                table: "EmployeeBiodata");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "PayrollAdditionItems",
                newName: "name");

            migrationBuilder.RenameColumn(
                name: "CategoryId",
                table: "PayrollAdditionItems",
                newName: "categoryId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "PayrollAdditionItems",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "amount2",
                table: "PayrollAdditionItems",
                newName: "amount");

            migrationBuilder.AlterColumn<string>(
                name: "name",
                table: "PayrollAdditionItems",
                type: "varchar(100)",
                unicode: false,
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<int>(
                name: "categoryId",
                table: "PayrollAdditionItems",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<int>(
                name: "assigneeId",
                table: "PayrollAdditionItems",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "bankName",
                table: "EmployeeBiodata",
                type: "varchar(150)",
                unicode: false,
                maxLength: 150,
                nullable: false,
                defaultValue: "");

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
                name: "PayrollAdditionItemsAssignment",
                columns: table => new
                {
                    PayrollItemId = table.Column<int>(type: "int", nullable: false),
                    EmployeeId = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(19,4)", nullable: false)
                },
                constraints: table =>
                {
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
                name: "PayrollDeductionItemsAssignment",
                columns: table => new
                {
                    PayrollItemId = table.Column<int>(type: "int", nullable: false),
                    EmployeeId = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(19,4)", nullable: false)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "PayrollOvertimeItemsAssignment",
                columns: table => new
                {
                    PayrollItemId = table.Column<int>(type: "int", nullable: false),
                    EmployeeId = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(19,4)", nullable: false)
                },
                constraints: table =>
                {
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

            migrationBuilder.CreateIndex(
                name: "IX_PayrollAdditionItems_assigneeId",
                table: "PayrollAdditionItems",
                column: "assigneeId");

            migrationBuilder.CreateIndex(
                name: "IX_PayrollAdditionItems_categoryId",
                table: "PayrollAdditionItems",
                column: "categoryId");

            migrationBuilder.CreateIndex(
                name: "UQ__LeaveTyp__72E12F1BF20C58BD",
                table: "LeaveTypes",
                column: "name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PayrollDeductionItems_assigneeId",
                table: "PayrollDeductionItems",
                column: "assigneeId");

            migrationBuilder.CreateIndex(
                name: "IX_PayrollOvertimeItems_rateid",
                table: "PayrollOvertimeItems",
                column: "rateid");

            migrationBuilder.AddForeignKey(
                name: "FK_PayrollAdditionItems_AssigneeTable",
                table: "PayrollAdditionItems",
                column: "assigneeId",
                principalTable: "AssigneeTable",
                principalColumn: "assigneeid",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PayrollAdditionItems_PayrollCategories",
                table: "PayrollAdditionItems",
                column: "categoryId",
                principalTable: "PayrollCategories",
                principalColumn: "categoryId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PayrollAdditionItems_AssigneeTable",
                table: "PayrollAdditionItems");

            migrationBuilder.DropForeignKey(
                name: "FK_PayrollAdditionItems_PayrollCategories",
                table: "PayrollAdditionItems");

            migrationBuilder.DropTable(
                name: "LeaveTypes");

            migrationBuilder.DropTable(
                name: "PayrollAdditionItemsAssignment");

            migrationBuilder.DropTable(
                name: "PayrollCategories");

            migrationBuilder.DropTable(
                name: "PayrollDeductionItems");

            migrationBuilder.DropTable(
                name: "PayrollDeductionItemsAssignment");

            migrationBuilder.DropTable(
                name: "PayrollOvertimeItems");

            migrationBuilder.DropTable(
                name: "PayrollOvertimeItemsAssignment");

            migrationBuilder.DropTable(
                name: "AssigneeTable");

            migrationBuilder.DropTable(
                name: "PayrollRates");

            migrationBuilder.DropIndex(
                name: "IX_PayrollAdditionItems_assigneeId",
                table: "PayrollAdditionItems");

            migrationBuilder.DropIndex(
                name: "IX_PayrollAdditionItems_categoryId",
                table: "PayrollAdditionItems");

            migrationBuilder.DropColumn(
                name: "assigneeId",
                table: "PayrollAdditionItems");

            migrationBuilder.DropColumn(
                name: "bankName",
                table: "EmployeeBiodata");

            migrationBuilder.RenameColumn(
                name: "name",
                table: "PayrollAdditionItems",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "categoryId",
                table: "PayrollAdditionItems",
                newName: "CategoryId");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "PayrollAdditionItems",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "amount",
                table: "PayrollAdditionItems",
                newName: "amount2");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "PayrollAdditionItems",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(100)",
                oldUnicode: false,
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "CategoryId",
                table: "PayrollAdditionItems",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "PayrollAdditionItemId",
                table: "EmployeeBiodata",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "bankCode",
                table: "EmployeeBiodata",
                type: "varchar(10)",
                unicode: false,
                maxLength: 10,
                nullable: false,
                defaultValue: "");

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

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeBiodata_bankCode",
                table: "EmployeeBiodata",
                column: "bankCode");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeBiodata_PayrollAdditionItemId",
                table: "EmployeeBiodata",
                column: "PayrollAdditionItemId");

            migrationBuilder.CreateIndex(
                name: "UQ__Banks__3EA6523332347041",
                table: "Banks",
                column: "bankName",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK__EmployeeB__bankC__3C69FB99",
                table: "EmployeeBiodata",
                column: "bankCode",
                principalTable: "Banks",
                principalColumn: "bankCode",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeBiodata_PayrollAdditionItems_PayrollAdditionItemId",
                table: "EmployeeBiodata",
                column: "PayrollAdditionItemId",
                principalTable: "PayrollAdditionItems",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
