using Microsoft.EntityFrameworkCore.Migrations;

namespace Suzy.Data.Migrations
{
    public partial class UserName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserName",
                table: "Senders",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserName",
                table: "Recipients",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserName",
                table: "Senders");

            migrationBuilder.DropColumn(
                name: "UserName",
                table: "Recipients");
        }
    }
}
