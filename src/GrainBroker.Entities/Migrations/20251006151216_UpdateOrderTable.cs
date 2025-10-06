using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GrainBroker.Entities.Migrations
{
    /// <inheritdoc />
    public partial class UpdateOrderTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: new Guid("c01094a4-0e66-49d5-b23f-c5c887bb1540"));

            migrationBuilder.DeleteData(
                table: "Suppliers",
                keyColumn: "Id",
                keyValue: new Guid("7ca5e308-d40b-42fd-85b1-4af7c2e72cf9"));

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "CustomerLocation", "CustomerName", "Status" },
                values: new object[] { new Guid("36328e54-eeb2-483c-911c-d86633a2d621"), "Cincinatti", "ABC", "Active" });

            migrationBuilder.InsertData(
                table: "Suppliers",
                columns: new[] { "Id", "Status", "StockAvailable", "SupplierLocation", "SupplierName" },
                values: new object[] { new Guid("50110191-0d4c-48f3-bf48-88a59049ffb0"), "Active", 0, "Omaha", "XYZ" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: new Guid("36328e54-eeb2-483c-911c-d86633a2d621"));

            migrationBuilder.DeleteData(
                table: "Suppliers",
                keyColumn: "Id",
                keyValue: new Guid("50110191-0d4c-48f3-bf48-88a59049ffb0"));

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "CustomerLocation", "CustomerName", "Status" },
                values: new object[] { new Guid("c01094a4-0e66-49d5-b23f-c5c887bb1540"), "Cincinatti", "ABC", "Active" });

            migrationBuilder.InsertData(
                table: "Suppliers",
                columns: new[] { "Id", "Status", "StockAvailable", "SupplierLocation", "SupplierName" },
                values: new object[] { new Guid("7ca5e308-d40b-42fd-85b1-4af7c2e72cf9"), "Active", 0, "Omaha", "XYZ" });
        }
    }
}
