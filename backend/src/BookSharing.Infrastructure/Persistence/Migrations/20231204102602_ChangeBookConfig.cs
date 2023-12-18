using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BookSharing.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class ChangeBookConfig : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AlterColumn<string>(
                name: "CoverImage",
                table: "Books",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(255)",
                oldMaxLength: 255);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("8ba374b7-4b84-4a84-a86a-e712ea7efd30"), "080b519c-8e25-4fca-85ab-ad86fc8036fc", "Admin", "ADMIN" },
                    { new Guid("961de8d5-e43f-4174-8aa2-9d4f2f193247"), "2732e31c-05c9-49ef-9e6d-d85f7b6ecefd", "User", "USER" },
                    { new Guid("c92ed2eb-5428-4fd6-b989-075527261b13"), "5a47202b-c574-40b6-ba88-19d9d3943c65", "Super Admin", "SUPER ADMIN" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("8ba374b7-4b84-4a84-a86a-e712ea7efd30"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("961de8d5-e43f-4174-8aa2-9d4f2f193247"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("c92ed2eb-5428-4fd6-b989-075527261b13"));

            migrationBuilder.AlterColumn<string>(
                name: "CoverImage",
                table: "Books",
                type: "character varying(255)",
                maxLength: 255,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

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
    }
}
