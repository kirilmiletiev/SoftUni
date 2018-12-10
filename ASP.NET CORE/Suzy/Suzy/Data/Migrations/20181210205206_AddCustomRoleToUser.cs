using Microsoft.EntityFrameworkCore.Migrations;

namespace Suzy.Data.Migrations
{
    public partial class AddCustomRoleToUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CustomRole",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CustomRole",
                table: "AspNetUsers");
        }
    }
}
