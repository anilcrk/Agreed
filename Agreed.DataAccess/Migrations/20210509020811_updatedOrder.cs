using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Agreed.DataAccess.Migrations
{
    public partial class updatedOrder : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CargoId",
                table: "Orders",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "CargoStatus",
                table: "Orders",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "CommissionId",
                table: "Orders",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "CommissionStatus",
                table: "Orders",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CargoDeliveryDate", "OrderDate" },
                values: new object[] { new DateTime(2021, 5, 9, 5, 8, 10, 279, DateTimeKind.Local).AddTicks(9130), new DateTime(2021, 5, 2, 5, 8, 10, 282, DateTimeKind.Local).AddTicks(1229) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CargoId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "CargoStatus",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "CommissionId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "CommissionStatus",
                table: "Orders");

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CargoDeliveryDate", "OrderDate" },
                values: new object[] { new DateTime(2021, 5, 2, 3, 43, 59, 64, DateTimeKind.Local).AddTicks(3624), new DateTime(2021, 4, 25, 3, 43, 59, 66, DateTimeKind.Local).AddTicks(8382) });
        }
    }
}
