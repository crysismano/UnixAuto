using Microsoft.EntityFrameworkCore.Migrations;

namespace UnixAuto.Migrations
{
    public partial class CarDetailChangedToModelDetail : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CarModel_ModelDetail_CardetailId",
                table: "CarModel");

            migrationBuilder.RenameColumn(
                name: "CardetailId",
                table: "CarModel",
                newName: "ModelDetailId");

            migrationBuilder.RenameIndex(
                name: "IX_CarModel_CardetailId",
                table: "CarModel",
                newName: "IX_CarModel_ModelDetailId");

            migrationBuilder.AddForeignKey(
                name: "FK_CarModel_ModelDetail_ModelDetailId",
                table: "CarModel",
                column: "ModelDetailId",
                principalTable: "ModelDetail",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CarModel_ModelDetail_ModelDetailId",
                table: "CarModel");

            migrationBuilder.RenameColumn(
                name: "ModelDetailId",
                table: "CarModel",
                newName: "CardetailId");

            migrationBuilder.RenameIndex(
                name: "IX_CarModel_ModelDetailId",
                table: "CarModel",
                newName: "IX_CarModel_CardetailId");

            migrationBuilder.AddForeignKey(
                name: "FK_CarModel_ModelDetail_CardetailId",
                table: "CarModel",
                column: "CardetailId",
                principalTable: "ModelDetail",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
