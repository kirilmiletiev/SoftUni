using Microsoft.EntityFrameworkCore.Migrations;

namespace Chushka.Data.Migrations
{
    public partial class IsLoggedIn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsLoggedIn",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsLoggedIn",
                table: "AspNetUsers");
        }
    }
}
