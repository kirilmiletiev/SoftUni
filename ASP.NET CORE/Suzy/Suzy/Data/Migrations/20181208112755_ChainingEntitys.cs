using Microsoft.EntityFrameworkCore.Migrations;

namespace Suzy.Data.Migrations
{
    public partial class ChainingEntitys : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Senders",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Recipients",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Packages",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Senders_UserId",
                table: "Senders",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Recipients_UserId",
                table: "Recipients",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Packages_UserId",
                table: "Packages",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Packages_AspNetUsers_UserId",
                table: "Packages",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Recipients_AspNetUsers_UserId",
                table: "Recipients",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Senders_AspNetUsers_UserId",
                table: "Senders",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Packages_AspNetUsers_UserId",
                table: "Packages");

            migrationBuilder.DropForeignKey(
                name: "FK_Recipients_AspNetUsers_UserId",
                table: "Recipients");

            migrationBuilder.DropForeignKey(
                name: "FK_Senders_AspNetUsers_UserId",
                table: "Senders");

            migrationBuilder.DropIndex(
                name: "IX_Senders_UserId",
                table: "Senders");

            migrationBuilder.DropIndex(
                name: "IX_Recipients_UserId",
                table: "Recipients");

            migrationBuilder.DropIndex(
                name: "IX_Packages_UserId",
                table: "Packages");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Senders");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Recipients");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Packages");
        }
    }
}
