using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Agreed.DataAccess.Migrations
{
    public partial class AddedUserTables_4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderNumber",
                keyValue: "123",
                columns: new[] { "CargoDeliveryDate", "OrderDate" },
                values: new object[] { new DateTime(2021, 3, 26, 23, 53, 28, 708, DateTimeKind.Local).AddTicks(5855), new DateTime(2021, 3, 19, 23, 53, 28, 710, DateTimeKind.Local).AddTicks(6060) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderNumber",
                keyValue: "123",
                columns: new[] { "CargoDeliveryDate", "OrderDate" },
                values: new object[] { new DateTime(2021, 3, 26, 23, 30, 53, 356, DateTimeKind.Local).AddTicks(1348), new DateTime(2021, 3, 19, 23, 30, 53, 359, DateTimeKind.Local).AddTicks(5257) });
        }
    }
}
