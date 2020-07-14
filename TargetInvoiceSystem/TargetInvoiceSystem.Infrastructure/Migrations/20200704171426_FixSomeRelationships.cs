using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TargetInvoiceSystem.Infrastructure.Migrations
{
    public partial class FixSomeRelationships : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MainUnits_Units_MainUnitId",
                table: "MainUnits");

            migrationBuilder.DropForeignKey(
                name: "FK_SubUnits_Units_SubUnitId",
                table: "SubUnits");

            migrationBuilder.DropIndex(
                name: "IX_SubUnits_SubUnitId",
                table: "SubUnits");

            migrationBuilder.DropIndex(
                name: "IX_MainUnits_MainUnitId",
                table: "MainUnits");

            migrationBuilder.DropColumn(
                name: "SubUnitId",
                table: "SubUnits");

            migrationBuilder.DropColumn(
                name: "MainUnitId",
                table: "MainUnits");

            migrationBuilder.CreateIndex(
                name: "IX_Units_MainUnitId",
                table: "Units",
                column: "MainUnitId");

            migrationBuilder.CreateIndex(
                name: "IX_Units_SubUnitId",
                table: "Units",
                column: "SubUnitId");

            migrationBuilder.AddForeignKey(
                name: "FK_Units_MainUnits_MainUnitId",
                table: "Units",
                column: "MainUnitId",
                principalTable: "MainUnits",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Units_SubUnits_SubUnitId",
                table: "Units",
                column: "SubUnitId",
                principalTable: "SubUnits",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Units_MainUnits_MainUnitId",
                table: "Units");

            migrationBuilder.DropForeignKey(
                name: "FK_Units_SubUnits_SubUnitId",
                table: "Units");

            migrationBuilder.DropIndex(
                name: "IX_Units_MainUnitId",
                table: "Units");

            migrationBuilder.DropIndex(
                name: "IX_Units_SubUnitId",
                table: "Units");

            migrationBuilder.AddColumn<Guid>(
                name: "SubUnitId",
                table: "SubUnits",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "MainUnitId",
                table: "MainUnits",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_SubUnits_SubUnitId",
                table: "SubUnits",
                column: "SubUnitId");

            migrationBuilder.CreateIndex(
                name: "IX_MainUnits_MainUnitId",
                table: "MainUnits",
                column: "MainUnitId");

            migrationBuilder.AddForeignKey(
                name: "FK_MainUnits_Units_MainUnitId",
                table: "MainUnits",
                column: "MainUnitId",
                principalTable: "Units",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SubUnits_Units_SubUnitId",
                table: "SubUnits",
                column: "SubUnitId",
                principalTable: "Units",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
