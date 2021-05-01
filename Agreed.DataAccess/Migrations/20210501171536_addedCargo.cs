using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Agreed.DataAccess.Migrations
{
    public partial class addedCargo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cargoes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SellerID = table.Column<int>(type: "int", nullable: false),
                    ShipmentFee = table.Column<double>(type: "float", nullable: false),
                    Desi = table.Column<int>(type: "int", nullable: false),
                    SellerName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OrderNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ShipmentIsReturns = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ShipmentIsReturnCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CargoCompany = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OrderDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ShipmentDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    OrderAmount = table.Column<double>(type: "float", nullable: false),
                    MinCampaignScale = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NumberOfProducts = table.Column<int>(type: "int", nullable: false),
                    BoutiqueId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cargoes", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CargoDeliveryDate", "OrderDate" },
                values: new object[] { new DateTime(2021, 5, 1, 20, 15, 35, 724, DateTimeKind.Local).AddTicks(5606), new DateTime(2021, 4, 24, 20, 15, 35, 726, DateTimeKind.Local).AddTicks(4762) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cargoes");

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CargoDeliveryDate", "OrderDate" },
                values: new object[] { new DateTime(2021, 5, 1, 16, 28, 34, 28, DateTimeKind.Local).AddTicks(5842), new DateTime(2021, 4, 24, 16, 28, 34, 31, DateTimeKind.Local).AddTicks(3203) });
        }
    }
}
