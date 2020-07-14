using Microsoft.EntityFrameworkCore.Migrations;

namespace TargetInvoiceSystem.Infrastructure.Migrations
{
    public partial class FixProductUnit_UnitRelation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_ProductUnits_UnitId",
                table: "ProductUnits");

            migrationBuilder.CreateIndex(
                name: "IX_ProductUnits_UnitId",
                table: "ProductUnits",
                column: "UnitId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_ProductUnits_UnitId",
                table: "ProductUnits");

            migrationBuilder.CreateIndex(
                name: "IX_ProductUnits_UnitId",
                table: "ProductUnits",
                column: "UnitId",
                unique: true);
        }
    }
}
