using Microsoft.EntityFrameworkCore.Migrations;

namespace DepsWebApp.Migrations
{
    public partial class Some : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "HashPassword",
                table: "Users",
                newName: "Hash_Password");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Hash_Password",
                table: "Users",
                newName: "HashPassword");
        }
    }
}
