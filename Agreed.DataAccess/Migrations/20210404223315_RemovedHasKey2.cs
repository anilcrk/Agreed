using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Agreed.DataAccess.Migrations
{
    public partial class RemovedHasKey2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Orders",
                table: "Orders");

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "Barcode",
                keyValue: "0000000000001998");

            migrationBuilder.AlterColumn<string>(
                name: "Barcode",
                table: "Orders",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Orders",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Orders",
                table: "Orders",
                column: "Id");

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "Id", "AmountTobeBilled", "Barcode", "BillingAddress", "BoutiqueNumber", "Brand", "CargoCode", "CargoCompany", "CargoDeliveryDate", "CommissionRate", "DeliveryAddress", "DiscountAmount", "Email", "OrderDate", "OrderNumber", "OrderStatus", "PackageNumber", "Piece", "ProductName", "Receiver", "SalesAmount", "StockCode", "UnitPrice" },
                values: new object[] { 1, 150m, "0000000000001998", "İstanbul", "123456", "HAC", "123456", "HAC CARGO", new DateTime(2021, 4, 5, 1, 33, 14, 53, DateTimeKind.Local).AddTicks(8561), 10.5, "Denizli", 10m, "anil@hacyazilim.com.tr", new DateTime(2021, 3, 29, 1, 33, 14, 56, DateTimeKind.Local).AddTicks(5108), "123", "", "123", 1, "HAC", "", 150m, "aaaa", 150m });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Orders",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Orders");

            migrationBuilder.AlterColumn<string>(
                name: "Barcode",
                table: "Orders",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Orders",
                table: "Orders",
                column: "Barcode");

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Barcode",
                keyValue: "0000000000001998",
                columns: new[] { "CargoDeliveryDate", "OrderDate" },
                values: new object[] { new DateTime(2021, 4, 5, 1, 27, 45, 535, DateTimeKind.Local).AddTicks(2610), new DateTime(2021, 3, 29, 1, 27, 45, 541, DateTimeKind.Local).AddTicks(3454) });
        }
    }
}
