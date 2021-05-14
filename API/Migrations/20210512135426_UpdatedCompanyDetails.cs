using Microsoft.EntityFrameworkCore.Migrations;

namespace API.Migrations
{
    public partial class UpdatedCompanyDetails : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "companyId",
                table: "SystemDefaults",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SystemDefaults",
                table: "SystemDefaults",
                column: "companyId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_SystemDefaults",
                table: "SystemDefaults");

            migrationBuilder.DropColumn(
                name: "companyId",
                table: "SystemDefaults");
        }
    }
}
