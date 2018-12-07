using Microsoft.EntityFrameworkCore.Migrations;

namespace Suzy.Data.Migrations
{
    public partial class AddListOfPackagesToCourier : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CourierId",
                table: "Packages",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Packages_CourierId",
                table: "Packages",
                column: "CourierId");

            migrationBuilder.AddForeignKey(
                name: "FK_Packages_Couriers_CourierId",
                table: "Packages",
                column: "CourierId",
                principalTable: "Couriers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Packages_Couriers_CourierId",
                table: "Packages");

            migrationBuilder.DropIndex(
                name: "IX_Packages_CourierId",
                table: "Packages");

            migrationBuilder.DropColumn(
                name: "CourierId",
                table: "Packages");
        }
    }
}
