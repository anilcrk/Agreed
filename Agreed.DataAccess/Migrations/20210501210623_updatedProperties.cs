using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Agreed.DataAccess.Migrations
{
    public partial class updatedProperties : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CargoDeliveryDate", "OrderDate" },
                values: new object[] { new DateTime(2021, 5, 2, 0, 6, 22, 396, DateTimeKind.Local).AddTicks(2209), new DateTime(2021, 4, 25, 0, 6, 22, 398, DateTimeKind.Local).AddTicks(1643) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CargoDeliveryDate", "OrderDate" },
                values: new object[] { new DateTime(2021, 5, 1, 21, 24, 17, 329, DateTimeKind.Local).AddTicks(4577), new DateTime(2021, 4, 24, 21, 24, 17, 331, DateTimeKind.Local).AddTicks(1529) });
        }
    }
}
