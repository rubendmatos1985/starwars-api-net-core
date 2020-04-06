using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace starwars_api_net_core.Migrations
{
    public partial class FilmSpecie : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_People_Planets_HomeWorldId",
                table: "People");

            migrationBuilder.AlterColumn<Guid>(
                name: "HomeWorldId",
                table: "People",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddColumn<Guid>(
                name: "SpecieId",
                table: "People",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Specie",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Classification = table.Column<string>(nullable: true),
                    Designation = table.Column<string>(nullable: true),
                    AverageHeight = table.Column<int>(nullable: false),
                    SkinColors = table.Column<string>(nullable: true),
                    EyeColors = table.Column<string>(nullable: true),
                    HairColors = table.Column<string>(nullable: true),
                    AverageLifespan = table.Column<int>(nullable: false),
                    HomeworldId = table.Column<Guid>(nullable: true),
                    Language = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Specie", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Specie_Planets_HomeworldId",
                        column: x => x.HomeworldId,
                        principalTable: "Planets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "FilmSpecie",
                columns: table => new
                {
                    FilmId = table.Column<Guid>(nullable: false),
                    SpecieId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FilmSpecie", x => new { x.FilmId, x.SpecieId });
                    table.ForeignKey(
                        name: "FK_FilmSpecie_Films_FilmId",
                        column: x => x.FilmId,
                        principalTable: "Films",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FilmSpecie_Specie_SpecieId",
                        column: x => x.SpecieId,
                        principalTable: "Specie",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_People_SpecieId",
                table: "People",
                column: "SpecieId");

            migrationBuilder.CreateIndex(
                name: "IX_FilmSpecie_SpecieId",
                table: "FilmSpecie",
                column: "SpecieId");

            migrationBuilder.CreateIndex(
                name: "IX_Specie_HomeworldId",
                table: "Specie",
                column: "HomeworldId");

            migrationBuilder.AddForeignKey(
                name: "FK_People_Planets_HomeWorldId",
                table: "People",
                column: "HomeWorldId",
                principalTable: "Planets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_People_Specie_SpecieId",
                table: "People",
                column: "SpecieId",
                principalTable: "Specie",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_People_Planets_HomeWorldId",
                table: "People");

            migrationBuilder.DropForeignKey(
                name: "FK_People_Specie_SpecieId",
                table: "People");

            migrationBuilder.DropTable(
                name: "FilmSpecie");

            migrationBuilder.DropTable(
                name: "Specie");

            migrationBuilder.DropIndex(
                name: "IX_People_SpecieId",
                table: "People");

            migrationBuilder.DropColumn(
                name: "SpecieId",
                table: "People");

            migrationBuilder.AlterColumn<Guid>(
                name: "HomeWorldId",
                table: "People",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(Guid),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_People_Planets_HomeWorldId",
                table: "People",
                column: "HomeWorldId",
                principalTable: "Planets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
