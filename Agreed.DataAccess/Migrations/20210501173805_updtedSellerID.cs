using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Agreed.DataAccess.Migrations
{
    public partial class updtedSellerID : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CargoDeliveryDate", "OrderDate" },
                values: new object[] { new DateTime(2021, 5, 1, 20, 38, 4, 239, DateTimeKind.Local).AddTicks(9405), new DateTime(2021, 4, 24, 20, 38, 4, 242, DateTimeKind.Local).AddTicks(7583) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CargoDeliveryDate", "OrderDate" },
                values: new object[] { new DateTime(2021, 5, 1, 20, 15, 35, 724, DateTimeKind.Local).AddTicks(5606), new DateTime(2021, 4, 24, 20, 15, 35, 726, DateTimeKind.Local).AddTicks(4762) });
        }
    }
}
