using Microsoft.EntityFrameworkCore.Migrations;

namespace TargetInvoiceSystem.Infrastructure.Migrations
{
    public partial class RemoveColIsSellInvoiceFromTableInvoiceProduct : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsSellInvoice",
                table: "InvoiceProducts");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsSellInvoice",
                table: "InvoiceProducts",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
