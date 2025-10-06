using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GrainBroker.Entities.Migrations
{
    /// <inheritdoc />
    public partial class AddedStatuscolumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: new Guid("b5e0ebed-af05-4dfd-9c27-35281a080f0d"));

            migrationBuilder.DeleteData(
                table: "Suppliers",
                keyColumn: "Id",
                keyValue: new Guid("6f8755b3-47cb-4660-aa7b-dddfa110fee9"));

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "CustomerLocation", "CustomerName", "Status" },
                values: new object[] { new Guid("4c8f3ab3-42f6-498d-a5cb-bc2f04c9334d"), "Cincinatti", "ABC", "Active" });

            migrationBuilder.InsertData(
                table: "Suppliers",
                columns: new[] { "Id", "Status", "StockAvailable", "SupplierLocation", "SupplierName" },
                values: new object[] { new Guid("cde5091d-eb7b-4f6b-aab7-6bc7bb8adefb"), "Active", 0, "Omaha", "XYZ" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: new Guid("4c8f3ab3-42f6-498d-a5cb-bc2f04c9334d"));

            migrationBuilder.DeleteData(
                table: "Suppliers",
                keyColumn: "Id",
                keyValue: new Guid("cde5091d-eb7b-4f6b-aab7-6bc7bb8adefb"));

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "CustomerLocation", "CustomerName", "Status" },
                values: new object[] { new Guid("b5e0ebed-af05-4dfd-9c27-35281a080f0d"), "Cincinatti", "ABC", "Active" });

            migrationBuilder.InsertData(
                table: "Suppliers",
                columns: new[] { "Id", "Status", "StockAvailable", "SupplierLocation", "SupplierName" },
                values: new object[] { new Guid("6f8755b3-47cb-4660-aa7b-dddfa110fee9"), "Active", 0, "Omaha", "XYZ" });
        }
    }
}
