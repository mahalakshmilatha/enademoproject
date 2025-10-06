using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GrainBroker.Entities.Migrations
{
    /// <inheritdoc />
    public partial class AddedStatuscolumn2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: new Guid("36328e54-eeb2-483c-911c-d86633a2d621"));

            migrationBuilder.DeleteData(
                table: "Suppliers",
                keyColumn: "Id",
                keyValue: new Guid("50110191-0d4c-48f3-bf48-88a59049ffb0"));

            migrationBuilder.AlterColumn<string>(
                name: "Status",
                table: "Orders",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "CustomerLocation", "CustomerName", "Status" },
                values: new object[] { new Guid("22b0057e-1bf3-4683-8e75-0292cac5fd03"), "Cincinatti", "ABC", "Active" });

            migrationBuilder.InsertData(
                table: "Suppliers",
                columns: new[] { "Id", "Status", "StockAvailable", "SupplierLocation", "SupplierName" },
                values: new object[] { new Guid("c46ff4fb-f1d2-4bad-a4e4-625dcc45f261"), "Active", 0, "Omaha", "XYZ" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: new Guid("22b0057e-1bf3-4683-8e75-0292cac5fd03"));

            migrationBuilder.DeleteData(
                table: "Suppliers",
                keyColumn: "Id",
                keyValue: new Guid("c46ff4fb-f1d2-4bad-a4e4-625dcc45f261"));

            migrationBuilder.AlterColumn<string>(
                name: "Status",
                table: "Orders",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "CustomerLocation", "CustomerName", "Status" },
                values: new object[] { new Guid("36328e54-eeb2-483c-911c-d86633a2d621"), "Cincinatti", "ABC", "Active" });

            migrationBuilder.InsertData(
                table: "Suppliers",
                columns: new[] { "Id", "Status", "StockAvailable", "SupplierLocation", "SupplierName" },
                values: new object[] { new Guid("50110191-0d4c-48f3-bf48-88a59049ffb0"), "Active", 0, "Omaha", "XYZ" });
        }
    }
}
