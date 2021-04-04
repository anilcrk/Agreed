using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Agreed.DataAccess.Migrations
{
    public partial class RemovedEnum : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "OrderStatus",
                table: "Orders",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderNumber",
                keyValue: "123",
                columns: new[] { "CargoDeliveryDate", "OrderDate", "OrderStatus" },
                values: new object[] { new DateTime(2021, 4, 5, 0, 51, 2, 546, DateTimeKind.Local).AddTicks(9808), new DateTime(2021, 3, 29, 0, 51, 2, 549, DateTimeKind.Local).AddTicks(8354), "" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "OrderStatus",
                table: "Orders",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderNumber",
                keyValue: "123",
                columns: new[] { "CargoDeliveryDate", "OrderDate", "OrderStatus" },
                values: new object[] { new DateTime(2021, 3, 26, 23, 53, 28, 708, DateTimeKind.Local).AddTicks(5855), new DateTime(2021, 3, 19, 23, 53, 28, 710, DateTimeKind.Local).AddTicks(6060), 0 });
        }
    }
}
