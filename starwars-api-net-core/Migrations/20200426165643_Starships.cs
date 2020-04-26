using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace starwars_api_net_core.Migrations
{
    public partial class Starships : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Starship",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Model = table.Column<string>(nullable: true),
                    Manufacturer = table.Column<string>(nullable: true),
                    CostInCredits = table.Column<double>(nullable: false),
                    Length = table.Column<double>(nullable: false),
                    MaxAtmospheringSpeed = table.Column<double>(nullable: false),
                    Crew = table.Column<int>(nullable: false),
                    Passengers = table.Column<int>(nullable: false),
                    CargoCapacity = table.Column<double>(nullable: false),
                    Consumables = table.Column<string>(nullable: true),
                    HyperdriveRating = table.Column<double>(nullable: false),
                    MGLT = table.Column<double>(nullable: false),
                    StarshipClass = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Starship", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Starship");
        }
    }
}
