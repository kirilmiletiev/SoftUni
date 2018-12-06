using Microsoft.EntityFrameworkCore.Migrations;

namespace Suzy.Data.Migrations
{
    public partial class NotWhatU : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "RecipientId",
                table: "Packages",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SenderId",
                table: "Packages",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Packages_RecipientId",
                table: "Packages",
                column: "RecipientId");

            migrationBuilder.CreateIndex(
                name: "IX_Packages_SenderId",
                table: "Packages",
                column: "SenderId");

            migrationBuilder.AddForeignKey(
                name: "FK_Packages_Recipients_RecipientId",
                table: "Packages",
                column: "RecipientId",
                principalTable: "Recipients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Packages_Senders_SenderId",
                table: "Packages",
                column: "SenderId",
                principalTable: "Senders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Packages_Recipients_RecipientId",
                table: "Packages");

            migrationBuilder.DropForeignKey(
                name: "FK_Packages_Senders_SenderId",
                table: "Packages");

            migrationBuilder.DropIndex(
                name: "IX_Packages_RecipientId",
                table: "Packages");

            migrationBuilder.DropIndex(
                name: "IX_Packages_SenderId",
                table: "Packages");

            migrationBuilder.DropColumn(
                name: "RecipientId",
                table: "Packages");

            migrationBuilder.DropColumn(
                name: "SenderId",
                table: "Packages");
        }
    }
}
