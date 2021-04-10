using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Agreed.DataAccess.Migrations
{
    public partial class UserPassword : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "Users",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CargoDeliveryDate", "OrderDate" },
                values: new object[] { new DateTime(2021, 4, 10, 23, 27, 46, 323, DateTimeKind.Local).AddTicks(5215), new DateTime(2021, 4, 3, 23, 27, 46, 327, DateTimeKind.Local).AddTicks(1436) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Password",
                table: "Users");

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CargoDeliveryDate", "OrderDate" },
                values: new object[] { new DateTime(2021, 4, 5, 1, 33, 14, 53, DateTimeKind.Local).AddTicks(8561), new DateTime(2021, 3, 29, 1, 33, 14, 56, DateTimeKind.Local).AddTicks(5108) });
        }
    }
}
