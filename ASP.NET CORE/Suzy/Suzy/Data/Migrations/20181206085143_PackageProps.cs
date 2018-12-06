using Microsoft.EntityFrameworkCore.Migrations;

namespace Suzy.Data.Migrations
{
    public partial class PackageProps : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsPackageDelivered",
                table: "Packages",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsPackagePaid",
                table: "Packages",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<double>(
                name: "Weight",
                table: "Packages",
                nullable: false,
                defaultValue: 0.0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsPackageDelivered",
                table: "Packages");

            migrationBuilder.DropColumn(
                name: "IsPackagePaid",
                table: "Packages");

            migrationBuilder.DropColumn(
                name: "Weight",
                table: "Packages");
        }
    }
}
