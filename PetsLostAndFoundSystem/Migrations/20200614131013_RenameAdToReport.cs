using Microsoft.EntityFrameworkCore.Migrations;

namespace PetsLostAndFoundSystem.Migrations
{
    public partial class RenameAdToReport : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ads_AspNetUsers_AuthorId",
                table: "Ads");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Ads",
                table: "Ads");

            migrationBuilder.RenameTable(
                name: "Ads",
                newName: "Reports");

            migrationBuilder.RenameIndex(
                name: "IX_Ads_AuthorId",
                table: "Reports",
                newName: "IX_Reports_AuthorId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Reports",
                table: "Reports",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Reports_AspNetUsers_AuthorId",
                table: "Reports",
                column: "AuthorId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reports_AspNetUsers_AuthorId",
                table: "Reports");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Reports",
                table: "Reports");

            migrationBuilder.RenameTable(
                name: "Reports",
                newName: "Ads");

            migrationBuilder.RenameIndex(
                name: "IX_Reports_AuthorId",
                table: "Ads",
                newName: "IX_Ads_AuthorId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Ads",
                table: "Ads",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Ads_AspNetUsers_AuthorId",
                table: "Ads",
                column: "AuthorId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
