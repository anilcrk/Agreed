using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Agreed.DataAccess.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    OrderNumber = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Barcode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PackageNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CargoCompany = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OrderDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CargoDeliveryDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CargoCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Receiver = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeliveryAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProductName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BillingAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OrderStatus = table.Column<int>(type: "int", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CommissionRate = table.Column<double>(type: "float", nullable: false),
                    Brand = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StockCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Piece = table.Column<int>(type: "int", nullable: false),
                    UnitPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    SalesAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DiscountAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    AmountTobeBilled = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    BoutiqueNumber = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.OrderNumber);
                });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "OrderNumber", "AmountTobeBilled", "Barcode", "BillingAddress", "BoutiqueNumber", "Brand", "CargoCode", "CargoCompany", "CargoDeliveryDate", "CommissionRate", "DeliveryAddress", "DiscountAmount", "Email", "OrderDate", "OrderStatus", "PackageNumber", "Piece", "ProductName", "Receiver", "SalesAmount", "StockCode", "UnitPrice" },
                values: new object[] { "123", 150m, "0000000000001998", "İstanbul", "123456", "HAC", "123456", "HAC CARGO", new DateTime(2021, 3, 21, 0, 0, 21, 585, DateTimeKind.Local).AddTicks(4192), 10.5, "Denizli", 10m, "anil@hacyazilim.com.tr", new DateTime(2021, 3, 14, 0, 0, 21, 587, DateTimeKind.Local).AddTicks(4994), 0, "123", 1, "HAC", "", 150m, "aaaa", 150m });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Orders");
        }
    }
}
