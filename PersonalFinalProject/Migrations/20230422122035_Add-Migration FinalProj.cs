using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PersonalFinalProject.Migrations
{
    public partial class AddMigrationFinalProj : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reservations_Sittings_SittingId",
                table: "Reservations");

            migrationBuilder.DropForeignKey(
                name: "FK_ReservationTable_Reservations_ReservationId",
                table: "ReservationTable");

            migrationBuilder.DropForeignKey(
                name: "FK_ReservationTable_RestaurantTables_RestaurantTableId",
                table: "ReservationTable");

            migrationBuilder.DropForeignKey(
                name: "FK_Sittings_Restaurants_RestaurantId",
                table: "Sittings");

            migrationBuilder.DropForeignKey(
                name: "FK_SittingTypes_Sittings_SittingId",
                table: "SittingTypes");

            migrationBuilder.DropIndex(
                name: "IX_SittingTypes_SittingId",
                table: "SittingTypes");

            migrationBuilder.DropIndex(
                name: "IX_ReservationTable_RestaurantTableId",
                table: "ReservationTable");

            migrationBuilder.DropIndex(
                name: "IX_Reservations_SittingId",
                table: "Reservations");

            migrationBuilder.DropColumn(
                name: "SittingId",
                table: "SittingTypes");

            migrationBuilder.DropColumn(
                name: "RestaurantTableId",
                table: "ReservationTable");

            migrationBuilder.DropColumn(
                name: "NumberOfPeople",
                table: "Reservations");

            migrationBuilder.DropColumn(
                name: "SittingId",
                table: "Reservations");

            migrationBuilder.RenameColumn(
                name: "RestaurantId",
                table: "Sittings",
                newName: "SittingTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_Sittings_RestaurantId",
                table: "Sittings",
                newName: "IX_Sittings_SittingTypeId");

            migrationBuilder.RenameColumn(
                name: "Note",
                table: "Reservations",
                newName: "PhoneNumber");

            migrationBuilder.RenameColumn(
                name: "Guest",
                table: "Reservations",
                newName: "GuestNumber");

            migrationBuilder.AlterColumn<bool>(
                name: "Active",
                table: "Sittings",
                type: "bit",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<int>(
                name: "ReservationId",
                table: "ReservationTable",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Reservations",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "Reservations",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "Reservations",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Notes",
                table: "Reservations",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Reservations",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ReservationSitting",
                columns: table => new
                {
                    ReservationsId = table.Column<int>(type: "int", nullable: false),
                    SittingsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReservationSitting", x => new { x.ReservationsId, x.SittingsId });
                    table.ForeignKey(
                        name: "FK_ReservationSitting_Reservations_ReservationsId",
                        column: x => x.ReservationsId,
                        principalTable: "Reservations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ReservationSitting_Sittings_SittingsId",
                        column: x => x.SittingsId,
                        principalTable: "Sittings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ReservationTableRestaurantTable",
                columns: table => new
                {
                    ReservationTablesId = table.Column<int>(type: "int", nullable: false),
                    RestaurantTablesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReservationTableRestaurantTable", x => new { x.ReservationTablesId, x.RestaurantTablesId });
                    table.ForeignKey(
                        name: "FK_ReservationTableRestaurantTable_ReservationTable_ReservationTablesId",
                        column: x => x.ReservationTablesId,
                        principalTable: "ReservationTable",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ReservationTableRestaurantTable_RestaurantTables_RestaurantTablesId",
                        column: x => x.RestaurantTablesId,
                        principalTable: "RestaurantTables",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    UserTypeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                    table.ForeignKey(
                        name: "FK_User_UserType_UserTypeId",
                        column: x => x.UserTypeId,
                        principalTable: "UserType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_UserId",
                table: "Reservations",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_ReservationSitting_SittingsId",
                table: "ReservationSitting",
                column: "SittingsId");

            migrationBuilder.CreateIndex(
                name: "IX_ReservationTableRestaurantTable_RestaurantTablesId",
                table: "ReservationTableRestaurantTable",
                column: "RestaurantTablesId");

            migrationBuilder.CreateIndex(
                name: "IX_User_UserTypeId",
                table: "User",
                column: "UserTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Reservations_User_UserId",
                table: "Reservations",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ReservationTable_Reservations_ReservationId",
                table: "ReservationTable",
                column: "ReservationId",
                principalTable: "Reservations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Sittings_SittingTypes_SittingTypeId",
                table: "Sittings",
                column: "SittingTypeId",
                principalTable: "SittingTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reservations_User_UserId",
                table: "Reservations");

            migrationBuilder.DropForeignKey(
                name: "FK_ReservationTable_Reservations_ReservationId",
                table: "ReservationTable");

            migrationBuilder.DropForeignKey(
                name: "FK_Sittings_SittingTypes_SittingTypeId",
                table: "Sittings");

            migrationBuilder.DropTable(
                name: "ReservationSitting");

            migrationBuilder.DropTable(
                name: "ReservationTableRestaurantTable");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "UserType");

            migrationBuilder.DropIndex(
                name: "IX_Reservations_UserId",
                table: "Reservations");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "Reservations");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "Reservations");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "Reservations");

            migrationBuilder.DropColumn(
                name: "Notes",
                table: "Reservations");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Reservations");

            migrationBuilder.RenameColumn(
                name: "SittingTypeId",
                table: "Sittings",
                newName: "RestaurantId");

            migrationBuilder.RenameIndex(
                name: "IX_Sittings_SittingTypeId",
                table: "Sittings",
                newName: "IX_Sittings_RestaurantId");

            migrationBuilder.RenameColumn(
                name: "PhoneNumber",
                table: "Reservations",
                newName: "Note");

            migrationBuilder.RenameColumn(
                name: "GuestNumber",
                table: "Reservations",
                newName: "Guest");

            migrationBuilder.AddColumn<int>(
                name: "SittingId",
                table: "SittingTypes",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Active",
                table: "Sittings",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<int>(
                name: "ReservationId",
                table: "ReservationTable",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "RestaurantTableId",
                table: "ReservationTable",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "NumberOfPeople",
                table: "Reservations",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SittingId",
                table: "Reservations",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_SittingTypes_SittingId",
                table: "SittingTypes",
                column: "SittingId");

            migrationBuilder.CreateIndex(
                name: "IX_ReservationTable_RestaurantTableId",
                table: "ReservationTable",
                column: "RestaurantTableId");

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_SittingId",
                table: "Reservations",
                column: "SittingId");

            migrationBuilder.AddForeignKey(
                name: "FK_Reservations_Sittings_SittingId",
                table: "Reservations",
                column: "SittingId",
                principalTable: "Sittings",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ReservationTable_Reservations_ReservationId",
                table: "ReservationTable",
                column: "ReservationId",
                principalTable: "Reservations",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ReservationTable_RestaurantTables_RestaurantTableId",
                table: "ReservationTable",
                column: "RestaurantTableId",
                principalTable: "RestaurantTables",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Sittings_Restaurants_RestaurantId",
                table: "Sittings",
                column: "RestaurantId",
                principalTable: "Restaurants",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SittingTypes_Sittings_SittingId",
                table: "SittingTypes",
                column: "SittingId",
                principalTable: "Sittings",
                principalColumn: "Id");
        }
    }
}
