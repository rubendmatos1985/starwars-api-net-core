using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace starwars_api_net_core.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Films",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Title = table.Column<string>(nullable: false),
                    Episode = table.Column<int>(nullable: false),
                    OpeningCrawl = table.Column<string>(nullable: false),
                    Director = table.Column<string>(nullable: false),
                    Producer = table.Column<string>(nullable: false),
                    ReleaseDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Films", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Planets",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    RotationPeriod = table.Column<int>(nullable: false),
                    OrbitalPeriod = table.Column<int>(nullable: false),
                    Diameter = table.Column<double>(nullable: false),
                    Climate = table.Column<string>(nullable: true),
                    Gravity = table.Column<string>(nullable: true),
                    Terrain = table.Column<string>(nullable: true),
                    SurfaceWater = table.Column<int>(nullable: false),
                    Population = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Planets", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FilmPlanets",
                columns: table => new
                {
                    FilmId = table.Column<Guid>(nullable: false),
                    PlanetId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FilmPlanets", x => new { x.FilmId, x.PlanetId });
                    table.ForeignKey(
                        name: "FK_FilmPlanets_Films_FilmId",
                        column: x => x.FilmId,
                        principalTable: "Films",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FilmPlanets_Planets_PlanetId",
                        column: x => x.PlanetId,
                        principalTable: "Planets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "People",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Height = table.Column<double>(nullable: false),
                    Mass = table.Column<int>(nullable: false),
                    HairColor = table.Column<string>(nullable: true),
                    SkinColor = table.Column<string>(nullable: true),
                    EyeColor = table.Column<string>(nullable: true),
                    BirthYear = table.Column<string>(nullable: true),
                    Gender = table.Column<string>(nullable: false),
                    HomeWorldId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_People", x => x.Id);
                    table.ForeignKey(
                        name: "FK_People_Planets_HomeWorldId",
                        column: x => x.HomeWorldId,
                        principalTable: "Planets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PeopleFilms",
                columns: table => new
                {
                    PeopleId = table.Column<Guid>(nullable: false),
                    FilmId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PeopleFilms", x => new { x.FilmId, x.PeopleId });
                    table.ForeignKey(
                        name: "FK_PeopleFilms_Films_FilmId",
                        column: x => x.FilmId,
                        principalTable: "Films",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PeopleFilms_People_PeopleId",
                        column: x => x.PeopleId,
                        principalTable: "People",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FilmPlanets_PlanetId",
                table: "FilmPlanets",
                column: "PlanetId");

            migrationBuilder.CreateIndex(
                name: "IX_People_HomeWorldId",
                table: "People",
                column: "HomeWorldId");

            migrationBuilder.CreateIndex(
                name: "IX_PeopleFilms_PeopleId",
                table: "PeopleFilms",
                column: "PeopleId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FilmPlanets");

            migrationBuilder.DropTable(
                name: "PeopleFilms");

            migrationBuilder.DropTable(
                name: "Films");

            migrationBuilder.DropTable(
                name: "People");

            migrationBuilder.DropTable(
                name: "Planets");
        }
    }
}
