using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace starwars_api_net_core.Migrations
{
    public partial class StarshipsFilms : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "StarshipsFilms",
                columns: table => new
                {
                    StarshipId = table.Column<Guid>(nullable: false),
                    FilmId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StarshipsFilms", x => new { x.FilmId, x.StarshipId });
                    table.ForeignKey(
                        name: "FK_StarshipsFilms_Films_FilmId",
                        column: x => x.FilmId,
                        principalTable: "Films",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StarshipsFilms_Starship_StarshipId",
                        column: x => x.StarshipId,
                        principalTable: "Starship",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_StarshipsFilms_StarshipId",
                table: "StarshipsFilms",
                column: "StarshipId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StarshipsFilms");
        }
    }
}
