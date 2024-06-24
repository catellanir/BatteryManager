using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BatteryManager.UI.Migrations
{
    /// <inheritdoc />
    public partial class AddBatteryClasses : Migration
    {
        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Batteries_BatteryTypes_BatteryTypeId",
                schema: "BatteryManager",
                table: "Batteries");

            migrationBuilder.DropTable(
                name: "BatteryTypes",
                schema: "BatteryManager");

            migrationBuilder.DropTable(
                name: "BatteryClasses",
                schema: "BatteryManager");

            migrationBuilder.DropIndex(
                name: "IX_Batteries_BatteryTypeId",
                schema: "BatteryManager",
                table: "Batteries");

            migrationBuilder.DropColumn(
                name: "BatteryTypeId",
                schema: "BatteryManager",
                table: "Batteries");
        }

        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BatteryTypeId",
                schema: "BatteryManager",
                table: "Batteries",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "BatteryClasses",
                schema: "BatteryManager",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BatteryClasses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BatteryTypes",
                schema: "BatteryManager",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BatteryClassId = table.Column<int>(type: "int", nullable: false),
                    Capacity = table.Column<int>(type: "int", nullable: false),
                    Voltage = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BatteryTypes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BatteryTypes_BatteryClasses_BatteryClassId",
                        column: x => x.BatteryClassId,
                        principalSchema: "BatteryManager",
                        principalTable: "BatteryClasses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Batteries_BatteryTypeId",
                schema: "BatteryManager",
                table: "Batteries",
                column: "BatteryTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_BatteryTypes_BatteryClassId",
                schema: "BatteryManager",
                table: "BatteryTypes",
                column: "BatteryClassId");

            migrationBuilder.AddForeignKey(
                name: "FK_Batteries_BatteryTypes_BatteryTypeId",
                schema: "BatteryManager",
                table: "Batteries",
                column: "BatteryTypeId",
                principalSchema: "BatteryManager",
                principalTable: "BatteryTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}