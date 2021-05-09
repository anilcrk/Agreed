using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Agreed.DataAccess.Migrations
{
    public partial class companyIdaded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CompanyId",
                table: "Orders",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CompanyId",
                table: "Commissions",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CompanyId",
                table: "Cargoes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CargoDeliveryDate", "OrderDate" },
                values: new object[] { new DateTime(2021, 5, 2, 3, 43, 59, 64, DateTimeKind.Local).AddTicks(3624), new DateTime(2021, 4, 25, 3, 43, 59, 66, DateTimeKind.Local).AddTicks(8382) });

            migrationBuilder.CreateIndex(
                name: "IX_Orders_CompanyId",
                table: "Orders",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_Commissions_CompanyId",
                table: "Commissions",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_Cargoes_CompanyId",
                table: "Cargoes",
                column: "CompanyId");

            migrationBuilder.AddForeignKey(
                name: "FK_Cargoes_Companies_CompanyId",
                table: "Cargoes",
                column: "CompanyId",
                principalTable: "Companies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Commissions_Companies_CompanyId",
                table: "Commissions",
                column: "CompanyId",
                principalTable: "Companies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Company",
                table: "Orders",
                column: "CompanyId",
                principalTable: "Companies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cargoes_Companies_CompanyId",
                table: "Cargoes");

            migrationBuilder.DropForeignKey(
                name: "FK_Commissions_Companies_CompanyId",
                table: "Commissions");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Company",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_CompanyId",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Commissions_CompanyId",
                table: "Commissions");

            migrationBuilder.DropIndex(
                name: "IX_Cargoes_CompanyId",
                table: "Cargoes");

            migrationBuilder.DropColumn(
                name: "CompanyId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "CompanyId",
                table: "Commissions");

            migrationBuilder.DropColumn(
                name: "CompanyId",
                table: "Cargoes");

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CargoDeliveryDate", "OrderDate" },
                values: new object[] { new DateTime(2021, 5, 2, 0, 8, 30, 893, DateTimeKind.Local).AddTicks(2896), new DateTime(2021, 4, 25, 0, 8, 30, 896, DateTimeKind.Local).AddTicks(5087) });
        }
    }
}
