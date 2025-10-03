using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GrainBroker.Entities.Migrations
{
    /// <inheritdoc />
    public partial class UpdateLocation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: new Guid("33b9f49e-0380-4a80-8eb4-85f1d56ebca8"));

            migrationBuilder.DeleteData(
                table: "Suppliers",
                keyColumn: "Id",
                keyValue: new Guid("b449c2f1-e009-4b61-81da-aeb34c1fad23"));

            migrationBuilder.RenameColumn(
                name: "Location",
                table: "Suppliers",
                newName: "SupplierLocation");

            migrationBuilder.RenameColumn(
                name: "Location",
                table: "Customers",
                newName: "CustomerLocation");

            migrationBuilder.AddColumn<string>(
                name: "SupplierName",
                table: "Suppliers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "CustomerName",
                table: "Customers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "CustomerLocation", "CustomerName" },
                values: new object[] { new Guid("7204d36f-49c2-47f4-a76f-543864e51c0c"), "Cincinatti", "ABC" });

            migrationBuilder.InsertData(
                table: "Suppliers",
                columns: new[] { "Id", "SupplierLocation", "SupplierName" },
                values: new object[] { new Guid("8dab58d1-125d-4864-8dd3-dd8965456a87"), "Omaha", "XYZ" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: new Guid("7204d36f-49c2-47f4-a76f-543864e51c0c"));

            migrationBuilder.DeleteData(
                table: "Suppliers",
                keyColumn: "Id",
                keyValue: new Guid("8dab58d1-125d-4864-8dd3-dd8965456a87"));

            migrationBuilder.DropColumn(
                name: "SupplierName",
                table: "Suppliers");

            migrationBuilder.DropColumn(
                name: "CustomerName",
                table: "Customers");

            migrationBuilder.RenameColumn(
                name: "SupplierLocation",
                table: "Suppliers",
                newName: "Location");

            migrationBuilder.RenameColumn(
                name: "CustomerLocation",
                table: "Customers",
                newName: "Location");

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "Location" },
                values: new object[] { new Guid("33b9f49e-0380-4a80-8eb4-85f1d56ebca8"), "Sample Location" });

            migrationBuilder.InsertData(
                table: "Suppliers",
                columns: new[] { "Id", "Location" },
                values: new object[] { new Guid("b449c2f1-e009-4b61-81da-aeb34c1fad23"), "Sample Location" });
        }
    }
}
