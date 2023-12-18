using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BookSharing.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class UpdatedEnums : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("9669e346-2104-45e7-898c-f0b0a1281f90"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("e7386ba0-8e0f-4513-a282-3fdea9dc8502"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("e7dc9965-ead7-403c-a286-3e1de1fd991e"));

            migrationBuilder.RenameColumn(
                name: "Status",
                table: "Books",
                newName: "UploadStatus");

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "DeadlineExtensionRequests",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "AvailabilityStatus",
                table: "Books",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("6b24e195-0954-42a7-bd6d-b58fa01270fd"), "bee40704-d6e9-4973-9ed0-80398ef06531", "User", "USER" },
                    { new Guid("b0ea73fd-7b63-4f0d-833c-7575029f4f26"), "3dec2d96-8dfe-4fc4-bcaf-b97d80b1ee88", "Admin", "ADMIN" },
                    { new Guid("b905533f-4ed9-4a2d-b7e7-52e36755ff75"), "a6be764a-b03f-4d62-8dfc-b00c751d3ef8", "Super Admin", "SUPER ADMIN" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("6b24e195-0954-42a7-bd6d-b58fa01270fd"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("b0ea73fd-7b63-4f0d-833c-7575029f4f26"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("b905533f-4ed9-4a2d-b7e7-52e36755ff75"));

            migrationBuilder.DropColumn(
                name: "Status",
                table: "DeadlineExtensionRequests");

            migrationBuilder.DropColumn(
                name: "AvailabilityStatus",
                table: "Books");

            migrationBuilder.RenameColumn(
                name: "UploadStatus",
                table: "Books",
                newName: "Status");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("9669e346-2104-45e7-898c-f0b0a1281f90"), "d2944272-7a87-418f-be11-60a62daab113", "User", "USER" },
                    { new Guid("e7386ba0-8e0f-4513-a282-3fdea9dc8502"), "704ab610-663a-4ae4-86bd-d8691b7d338a", "Super Admin", "SUPER ADMIN" },
                    { new Guid("e7dc9965-ead7-403c-a286-3e1de1fd991e"), "c66e432a-dbde-4b86-a4c5-d9704e897c0e", "Admin", "ADMIN" }
                });
        }
    }
}
