using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GrainBroker.Entities.Migrations
{
    /// <inheritdoc />
    public partial class UpdateRelationship : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderFulfillments_Suppliers_SupplierId",
                table: "OrderFulfillments");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Customers_CustomerId",
                table: "Orders");

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: new Guid("7204d36f-49c2-47f4-a76f-543864e51c0c"));

            migrationBuilder.DeleteData(
                table: "Suppliers",
                keyColumn: "Id",
                keyValue: new Guid("8dab58d1-125d-4864-8dd3-dd8965456a87"));

            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "Suppliers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "StockAvailable",
                table: "Suppliers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "Orders",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "Customers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "CustomerLocation", "CustomerName", "Status" },
                values: new object[] { new Guid("b5e0ebed-af05-4dfd-9c27-35281a080f0d"), "Cincinatti", "ABC", "Active" });

            migrationBuilder.InsertData(
                table: "Suppliers",
                columns: new[] { "Id", "Status", "StockAvailable", "SupplierLocation", "SupplierName" },
                values: new object[] { new Guid("6f8755b3-47cb-4660-aa7b-dddfa110fee9"), "Active", 0, "Omaha", "XYZ" });

            migrationBuilder.AddForeignKey(
                name: "FK_OrderFulfillments_Suppliers_SupplierId",
                table: "OrderFulfillments",
                column: "SupplierId",
                principalTable: "Suppliers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Customers_CustomerId",
                table: "Orders",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderFulfillments_Suppliers_SupplierId",
                table: "OrderFulfillments");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Customers_CustomerId",
                table: "Orders");

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: new Guid("b5e0ebed-af05-4dfd-9c27-35281a080f0d"));

            migrationBuilder.DeleteData(
                table: "Suppliers",
                keyColumn: "Id",
                keyValue: new Guid("6f8755b3-47cb-4660-aa7b-dddfa110fee9"));

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Suppliers");

            migrationBuilder.DropColumn(
                name: "StockAvailable",
                table: "Suppliers");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Customers");

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "CustomerLocation", "CustomerName" },
                values: new object[] { new Guid("7204d36f-49c2-47f4-a76f-543864e51c0c"), "Cincinatti", "ABC" });

            migrationBuilder.InsertData(
                table: "Suppliers",
                columns: new[] { "Id", "SupplierLocation", "SupplierName" },
                values: new object[] { new Guid("8dab58d1-125d-4864-8dd3-dd8965456a87"), "Omaha", "XYZ" });

            migrationBuilder.AddForeignKey(
                name: "FK_OrderFulfillments_Suppliers_SupplierId",
                table: "OrderFulfillments",
                column: "SupplierId",
                principalTable: "Suppliers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Customers_CustomerId",
                table: "Orders",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
