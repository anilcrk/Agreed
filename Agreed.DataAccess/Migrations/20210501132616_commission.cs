using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Agreed.DataAccess.Migrations
{
    public partial class commission : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CargoDeliveryDate", "OrderDate" },
                values: new object[] { new DateTime(2021, 5, 1, 16, 26, 15, 120, DateTimeKind.Local).AddTicks(3802), new DateTime(2021, 4, 24, 16, 26, 15, 123, DateTimeKind.Local).AddTicks(1449) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CargoDeliveryDate", "OrderDate" },
                values: new object[] { new DateTime(2021, 4, 10, 23, 27, 46, 323, DateTimeKind.Local).AddTicks(5215), new DateTime(2021, 4, 3, 23, 27, 46, 327, DateTimeKind.Local).AddTicks(1436) });
        }
    }
}
