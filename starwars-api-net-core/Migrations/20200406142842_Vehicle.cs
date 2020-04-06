using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace starwars_api_net_core.Migrations
{
    public partial class Vehicle : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Vehicle",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Model = table.Column<string>(nullable: true),
                    Manufacturer = table.Column<string>(nullable: true),
                    CostInCredits = table.Column<double>(nullable: false),
                    Length = table.Column<float>(nullable: false),
                    MaxAtmosphericSpeed = table.Column<double>(nullable: false),
                    Crew = table.Column<int>(nullable: false),
                    Passengers = table.Column<int>(nullable: false),
                    CargoCapacity = table.Column<int>(nullable: false),
                    Consumables = table.Column<string>(nullable: true),
                    VehicleClass = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vehicle", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "VehicleFilm",
                columns: table => new
                {
                    FilmId = table.Column<Guid>(nullable: false),
                    VehicleId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VehicleFilm", x => new { x.FilmId, x.VehicleId });
                    table.ForeignKey(
                        name: "FK_VehicleFilm_Films_FilmId",
                        column: x => x.FilmId,
                        principalTable: "Films",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_VehicleFilm_Vehicle_VehicleId",
                        column: x => x.VehicleId,
                        principalTable: "Vehicle",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "VehiclePilot",
                columns: table => new
                {
                    PeopleId = table.Column<Guid>(nullable: false),
                    VehicleId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VehiclePilot", x => new { x.VehicleId, x.PeopleId });
                    table.ForeignKey(
                        name: "FK_VehiclePilot_People_PeopleId",
                        column: x => x.PeopleId,
                        principalTable: "People",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_VehiclePilot_Vehicle_VehicleId",
                        column: x => x.VehicleId,
                        principalTable: "Vehicle",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_VehicleFilm_VehicleId",
                table: "VehicleFilm",
                column: "VehicleId");

            migrationBuilder.CreateIndex(
                name: "IX_VehiclePilot_PeopleId",
                table: "VehiclePilot",
                column: "PeopleId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "VehicleFilm");

            migrationBuilder.DropTable(
                name: "VehiclePilot");

            migrationBuilder.DropTable(
                name: "Vehicle");
        }
    }
}
