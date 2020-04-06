using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace starwars_api_net_core.Migrations
{
    public partial class PeopleSpecieNullable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_People_Specie_SpecieId",
                table: "People");

            migrationBuilder.AlterColumn<Guid>(
                name: "SpecieId",
                table: "People",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

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
                name: "FK_People_Specie_SpecieId",
                table: "People");

            migrationBuilder.AlterColumn<Guid>(
                name: "SpecieId",
                table: "People",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(Guid),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_People_Specie_SpecieId",
                table: "People",
                column: "SpecieId",
                principalTable: "Specie",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
