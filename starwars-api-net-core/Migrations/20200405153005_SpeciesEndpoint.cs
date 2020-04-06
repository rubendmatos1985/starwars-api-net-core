using Microsoft.EntityFrameworkCore.Migrations;

namespace starwars_api_net_core.Migrations
{
    public partial class SpeciesEndpoint : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FilmPlanets_Films_FilmId",
                table: "FilmPlanets");

            migrationBuilder.DropForeignKey(
                name: "FK_FilmPlanets_Planets_PlanetId",
                table: "FilmPlanets");

            migrationBuilder.DropForeignKey(
                name: "FK_FilmSpecie_Specie_SpecieId",
                table: "FilmSpecie");

            migrationBuilder.DropForeignKey(
                name: "FK_People_Specie_SpecieId",
                table: "People");

            migrationBuilder.DropForeignKey(
                name: "FK_Specie_Planets_HomeworldId",
                table: "Specie");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Specie",
                table: "Specie");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FilmPlanets",
                table: "FilmPlanets");

            migrationBuilder.RenameTable(
                name: "Specie",
                newName: "Species");

            migrationBuilder.RenameTable(
                name: "FilmPlanets",
                newName: "FilmPlanet");

            migrationBuilder.RenameIndex(
                name: "IX_Specie_HomeworldId",
                table: "Species",
                newName: "IX_Species_HomeworldId");

            migrationBuilder.RenameIndex(
                name: "IX_FilmPlanets_PlanetId",
                table: "FilmPlanet",
                newName: "IX_FilmPlanet_PlanetId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Species",
                table: "Species",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FilmPlanet",
                table: "FilmPlanet",
                columns: new[] { "FilmId", "PlanetId" });

            migrationBuilder.AddForeignKey(
                name: "FK_FilmPlanet_Films_FilmId",
                table: "FilmPlanet",
                column: "FilmId",
                principalTable: "Films",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FilmPlanet_Planets_PlanetId",
                table: "FilmPlanet",
                column: "PlanetId",
                principalTable: "Planets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FilmSpecie_Species_SpecieId",
                table: "FilmSpecie",
                column: "SpecieId",
                principalTable: "Species",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_People_Species_SpecieId",
                table: "People",
                column: "SpecieId",
                principalTable: "Species",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Species_Planets_HomeworldId",
                table: "Species",
                column: "HomeworldId",
                principalTable: "Planets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FilmPlanet_Films_FilmId",
                table: "FilmPlanet");

            migrationBuilder.DropForeignKey(
                name: "FK_FilmPlanet_Planets_PlanetId",
                table: "FilmPlanet");

            migrationBuilder.DropForeignKey(
                name: "FK_FilmSpecie_Species_SpecieId",
                table: "FilmSpecie");

            migrationBuilder.DropForeignKey(
                name: "FK_People_Species_SpecieId",
                table: "People");

            migrationBuilder.DropForeignKey(
                name: "FK_Species_Planets_HomeworldId",
                table: "Species");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Species",
                table: "Species");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FilmPlanet",
                table: "FilmPlanet");

            migrationBuilder.RenameTable(
                name: "Species",
                newName: "Specie");

            migrationBuilder.RenameTable(
                name: "FilmPlanet",
                newName: "FilmPlanets");

            migrationBuilder.RenameIndex(
                name: "IX_Species_HomeworldId",
                table: "Specie",
                newName: "IX_Specie_HomeworldId");

            migrationBuilder.RenameIndex(
                name: "IX_FilmPlanet_PlanetId",
                table: "FilmPlanets",
                newName: "IX_FilmPlanets_PlanetId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Specie",
                table: "Specie",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FilmPlanets",
                table: "FilmPlanets",
                columns: new[] { "FilmId", "PlanetId" });

            migrationBuilder.AddForeignKey(
                name: "FK_FilmPlanets_Films_FilmId",
                table: "FilmPlanets",
                column: "FilmId",
                principalTable: "Films",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FilmPlanets_Planets_PlanetId",
                table: "FilmPlanets",
                column: "PlanetId",
                principalTable: "Planets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FilmSpecie_Specie_SpecieId",
                table: "FilmSpecie",
                column: "SpecieId",
                principalTable: "Specie",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_People_Specie_SpecieId",
                table: "People",
                column: "SpecieId",
                principalTable: "Specie",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Specie_Planets_HomeworldId",
                table: "Specie",
                column: "HomeworldId",
                principalTable: "Planets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
