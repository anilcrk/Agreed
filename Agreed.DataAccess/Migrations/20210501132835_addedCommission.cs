using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Agreed.DataAccess.Migrations
{
    public partial class addedCommission : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Commissions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TransactionId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProcessType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Barcode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OrderNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OrderDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    OdemeStatus = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProcessDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Seller = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VendorCurrentName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProductName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CommissionRate = table.Column<double>(type: "float", nullable: false),
                    TYProgressPayment = table.Column<double>(type: "float", nullable: false),
                    SellerProgressPayment = table.Column<double>(type: "float", nullable: false),
                    TermTime = table.Column<int>(type: "int", nullable: false),
                    TermDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AgreeDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Deliverydate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MaturityDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CommissionInvoiceNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TotalAmount = table.Column<double>(type: "float", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Surname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ShippingDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Commissions", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CargoDeliveryDate", "OrderDate" },
                values: new object[] { new DateTime(2021, 5, 1, 16, 28, 34, 28, DateTimeKind.Local).AddTicks(5842), new DateTime(2021, 4, 24, 16, 28, 34, 31, DateTimeKind.Local).AddTicks(3203) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Commissions");

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CargoDeliveryDate", "OrderDate" },
                values: new object[] { new DateTime(2021, 5, 1, 16, 26, 15, 120, DateTimeKind.Local).AddTicks(3802), new DateTime(2021, 4, 24, 16, 26, 15, 123, DateTimeKind.Local).AddTicks(1449) });
        }
    }
}
