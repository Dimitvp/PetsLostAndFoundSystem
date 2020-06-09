using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PetsLostAndFoundSystem.Migrations
{
    public partial class AddShelterEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Shelters",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 100, nullable: false),
                    Type = table.Column<int>(nullable: false),
                    WebPageUrl = table.Column<string>(maxLength: 2000, nullable: true),
                    City = table.Column<string>(maxLength: 90, nullable: false),
                    Address = table.Column<string>(maxLength: 250, nullable: false),
                    LatLocation = table.Column<double>(nullable: false),
                    LngLocation = table.Column<double>(nullable: false),
                    PetType = table.Column<int>(nullable: false),
                    Note = table.Column<string>(nullable: true),
                    PicUrl = table.Column<string>(maxLength: 2000, nullable: true),
                    Image = table.Column<string>(nullable: true),
                    PublishDate = table.Column<DateTime>(nullable: false),
                    IsApproved = table.Column<bool>(nullable: false),
                    AuthorId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Shelters", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Shelters_AspNetUsers_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Shelters_AuthorId",
                table: "Shelters",
                column: "AuthorId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Shelters");
        }
    }
}
