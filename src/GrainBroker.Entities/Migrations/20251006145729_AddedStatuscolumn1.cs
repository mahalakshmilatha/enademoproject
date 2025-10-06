using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GrainBroker.Entities.Migrations
{
    /// <inheritdoc />
    public partial class AddedStatuscolumn1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_OrderFulfillments_OrderId",
                table: "OrderFulfillments");

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: new Guid("42578cec-4e98-4198-b8db-44964fa6a427"));

            migrationBuilder.DeleteData(
                table: "Suppliers",
                keyColumn: "Id",
                keyValue: new Guid("34695fc0-b6ea-4095-82f9-165c90ba919f"));

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "CustomerLocation", "CustomerName", "Status" },
                values: new object[] { new Guid("c01094a4-0e66-49d5-b23f-c5c887bb1540"), "Cincinatti", "ABC", "Active" });

            migrationBuilder.InsertData(
                table: "Suppliers",
                columns: new[] { "Id", "Status", "StockAvailable", "SupplierLocation", "SupplierName" },
                values: new object[] { new Guid("7ca5e308-d40b-42fd-85b1-4af7c2e72cf9"), "Active", 0, "Omaha", "XYZ" });

            migrationBuilder.CreateIndex(
                name: "IX_OrderFulfillments_OrderId",
                table: "OrderFulfillments",
                column: "OrderId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_OrderFulfillments_OrderId",
                table: "OrderFulfillments");

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
                values: new object[] { new Guid("42578cec-4e98-4198-b8db-44964fa6a427"), "Cincinatti", "ABC", "Active" });

            migrationBuilder.InsertData(
                table: "Suppliers",
                columns: new[] { "Id", "Status", "StockAvailable", "SupplierLocation", "SupplierName" },
                values: new object[] { new Guid("34695fc0-b6ea-4095-82f9-165c90ba919f"), "Active", 0, "Omaha", "XYZ" });

            migrationBuilder.CreateIndex(
                name: "IX_OrderFulfillments_OrderId",
                table: "OrderFulfillments",
                column: "OrderId",
                unique: true);
        }
    }
}
