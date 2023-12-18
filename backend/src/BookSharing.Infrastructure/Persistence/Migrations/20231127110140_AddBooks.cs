using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BookSharing.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddBooks : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("509b9697-6616-4d1d-8b1c-3241af7c8884"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("cc029b09-e2ed-40dd-853c-1ca27d13d83d"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("d7e1180f-8547-497f-85d1-18d1bbecffaf"));

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("509b9697-6616-4d1d-8b1c-3241af7c8884"), "1f12bd93-cd4a-4b80-848f-64a4e5c18d9c", "User", "USER" },
                    { new Guid("cc029b09-e2ed-40dd-853c-1ca27d13d83d"), "d17e30fe-fca1-4082-bbdd-c7ff1eabea72", "Super Admin", "SUPER ADMIN" },
                    { new Guid("d7e1180f-8547-497f-85d1-18d1bbecffaf"), "ad2aae7d-b57d-4bfb-8df5-889c454579f8", "Admin", "ADMIN" }
                });
        }
    }
}
