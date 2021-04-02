using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Agreed.DataAccess.Migrations
{
    public partial class AddedUserTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderNumber",
                keyValue: "123",
                columns: new[] { "CargoDeliveryDate", "OrderDate" },
                values: new object[] { new DateTime(2021, 3, 26, 23, 19, 37, 899, DateTimeKind.Local).AddTicks(424), new DateTime(2021, 3, 19, 23, 19, 37, 902, DateTimeKind.Local).AddTicks(2565) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderNumber",
                keyValue: "123",
                columns: new[] { "CargoDeliveryDate", "OrderDate" },
                values: new object[] { new DateTime(2021, 3, 21, 0, 0, 21, 585, DateTimeKind.Local).AddTicks(4192), new DateTime(2021, 3, 14, 0, 0, 21, 587, DateTimeKind.Local).AddTicks(4994) });
        }
    }
}
