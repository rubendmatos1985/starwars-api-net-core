using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace starwars_api_net_core.Migrations
{
    public partial class HomeworldOnDelete : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_People_Specie_SpecieId",
                table: "People");

            migrationBuilder.AlterColumn<Guid>(
                name: "SpecieId",
                table: "People",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "SkinColor",
                table: "People",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "HairColor",
                table: "People",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "EyeColor",
                table: "People",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "BirthYear",
                table: "People",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_People_Specie_SpecieId",
                table: "People",
                column: "SpecieId",
                principalTable: "Specie",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
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
                nullable: true,
                oldClrType: typeof(Guid));

            migrationBuilder.AlterColumn<string>(
                name: "SkinColor",
                table: "People",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "HairColor",
                table: "People",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "EyeColor",
                table: "People",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "BirthYear",
                table: "People",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AddForeignKey(
                name: "FK_People_Specie_SpecieId",
                table: "People",
                column: "SpecieId",
                principalTable: "Specie",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
