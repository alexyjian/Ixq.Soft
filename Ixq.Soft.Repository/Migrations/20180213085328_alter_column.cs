using Microsoft.EntityFrameworkCore.Migrations;

namespace Ixq.Soft.EntityFrameworkCore.Migrations
{
    public partial class alter_column : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IsDelete",
                table: "Base_ApplicationUser",
                newName: "IsDeleted");

            migrationBuilder.RenameColumn(
                name: "IsDelete",
                table: "Base_ApplicationRole",
                newName: "IsDeleted");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IsDeleted",
                table: "Base_ApplicationUser",
                newName: "IsDelete");

            migrationBuilder.RenameColumn(
                name: "IsDeleted",
                table: "Base_ApplicationRole",
                newName: "IsDelete");
        }
    }
}
