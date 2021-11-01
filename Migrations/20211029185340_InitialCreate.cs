using Microsoft.EntityFrameworkCore.Migrations;

namespace UnixAuto.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CarManufacturer",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarManufacturer", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ModelDetail",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    YearOfManufacture = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Seats = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ModelDetail", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CarModel",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CardetailId = table.Column<int>(type: "int", nullable: false),
                    CarManufacturerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarModel", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CarModel_CarManufacturer_CarManufacturerId",
                        column: x => x.CarManufacturerId,
                        principalTable: "CarManufacturer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CarModel_ModelDetail_CardetailId",
                        column: x => x.CardetailId,
                        principalTable: "ModelDetail",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CarModel_CardetailId",
                table: "CarModel",
                column: "CardetailId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CarModel_CarManufacturerId",
                table: "CarModel",
                column: "CarManufacturerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CarModel");

            migrationBuilder.DropTable(
                name: "CarManufacturer");

            migrationBuilder.DropTable(
                name: "ModelDetail");
        }
    }
}
