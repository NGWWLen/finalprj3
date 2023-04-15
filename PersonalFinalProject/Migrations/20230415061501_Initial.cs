using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PersonalFinalProject.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sittings_SittingTypes_SittingTypeId",
                table: "Sittings");

            migrationBuilder.DropIndex(
                name: "IX_Sittings_SittingTypeId",
                table: "Sittings");

            migrationBuilder.DropColumn(
                name: "SittingTypeId",
                table: "Sittings");

            migrationBuilder.AddColumn<int>(
                name: "SittingId",
                table: "SittingTypes",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "NumberOfPeople",
                table: "Reservations",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_SittingTypes_SittingId",
                table: "SittingTypes",
                column: "SittingId");

            migrationBuilder.AddForeignKey(
                name: "FK_SittingTypes_Sittings_SittingId",
                table: "SittingTypes",
                column: "SittingId",
                principalTable: "Sittings",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SittingTypes_Sittings_SittingId",
                table: "SittingTypes");

            migrationBuilder.DropIndex(
                name: "IX_SittingTypes_SittingId",
                table: "SittingTypes");

            migrationBuilder.DropColumn(
                name: "SittingId",
                table: "SittingTypes");

            migrationBuilder.DropColumn(
                name: "NumberOfPeople",
                table: "Reservations");

            migrationBuilder.AddColumn<int>(
                name: "SittingTypeId",
                table: "Sittings",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Sittings_SittingTypeId",
                table: "Sittings",
                column: "SittingTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Sittings_SittingTypes_SittingTypeId",
                table: "Sittings",
                column: "SittingTypeId",
                principalTable: "SittingTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
