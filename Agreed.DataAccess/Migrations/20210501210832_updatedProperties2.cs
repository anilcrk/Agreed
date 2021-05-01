using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Agreed.DataAccess.Migrations
{
    public partial class updatedProperties2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "SellerID",
                table: "Cargoes",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "NumberOfProducts",
                table: "Cargoes",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "Desi",
                table: "Cargoes",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "BoutiqueId",
                table: "Cargoes",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CargoDeliveryDate", "OrderDate" },
                values: new object[] { new DateTime(2021, 5, 2, 0, 8, 30, 893, DateTimeKind.Local).AddTicks(2896), new DateTime(2021, 4, 25, 0, 8, 30, 896, DateTimeKind.Local).AddTicks(5087) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "SellerID",
                table: "Cargoes",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "NumberOfProducts",
                table: "Cargoes",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Desi",
                table: "Cargoes",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "BoutiqueId",
                table: "Cargoes",
                type: "int",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CargoDeliveryDate", "OrderDate" },
                values: new object[] { new DateTime(2021, 5, 2, 0, 6, 22, 396, DateTimeKind.Local).AddTicks(2209), new DateTime(2021, 4, 25, 0, 6, 22, 398, DateTimeKind.Local).AddTicks(1643) });
        }
    }
}
