using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BookSharing.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class Delete_New_Author_From_Book : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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
                name: "NewAuthor",
                table: "Books");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("40e1e37d-99e0-40b8-8701-bb437259a97d"), "dd4c8b6d-1583-4314-9b5a-b598071a7e44", "Super Admin", "SUPER ADMIN" },
                    { new Guid("cdf7297c-4976-47e1-a18c-28583ae93b11"), "15369de3-cb0c-410c-8c51-4c3b970b1734", "User", "USER" },
                    { new Guid("e79ae51b-992b-4891-be94-0a4abbde9cf1"), "f67a0c10-271c-4982-b248-0abc90e54988", "Admin", "ADMIN" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("40e1e37d-99e0-40b8-8701-bb437259a97d"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("cdf7297c-4976-47e1-a18c-28583ae93b11"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("e79ae51b-992b-4891-be94-0a4abbde9cf1"));

            migrationBuilder.AddColumn<string>(
                name: "NewAuthor",
                table: "Books",
                type: "character varying(61)",
                maxLength: 61,
                nullable: true);

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
    }
}
