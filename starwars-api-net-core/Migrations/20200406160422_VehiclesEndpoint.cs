using Microsoft.EntityFrameworkCore.Migrations;

namespace starwars_api_net_core.Migrations
{
    public partial class VehiclesEndpoint : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_VehicleFilm_Vehicle_VehicleId",
                table: "VehicleFilm");

            migrationBuilder.DropForeignKey(
                name: "FK_VehiclePilot_Vehicle_VehicleId",
                table: "VehiclePilot");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Vehicle",
                table: "Vehicle");

            migrationBuilder.RenameTable(
                name: "Vehicle",
                newName: "Vehicles");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Vehicles",
                table: "Vehicles",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_VehicleFilm_Vehicles_VehicleId",
                table: "VehicleFilm",
                column: "VehicleId",
                principalTable: "Vehicles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_VehiclePilot_Vehicles_VehicleId",
                table: "VehiclePilot",
                column: "VehicleId",
                principalTable: "Vehicles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_VehicleFilm_Vehicles_VehicleId",
                table: "VehicleFilm");

            migrationBuilder.DropForeignKey(
                name: "FK_VehiclePilot_Vehicles_VehicleId",
                table: "VehiclePilot");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Vehicles",
                table: "Vehicles");

            migrationBuilder.RenameTable(
                name: "Vehicles",
                newName: "Vehicle");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Vehicle",
                table: "Vehicle",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_VehicleFilm_Vehicle_VehicleId",
                table: "VehicleFilm",
                column: "VehicleId",
                principalTable: "Vehicle",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_VehiclePilot_Vehicle_VehicleId",
                table: "VehiclePilot",
                column: "VehicleId",
                principalTable: "Vehicle",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
