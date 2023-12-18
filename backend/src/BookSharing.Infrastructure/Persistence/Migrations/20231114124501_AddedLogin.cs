using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BookSharing.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddedLogin : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("1d35371d-f5ae-40a8-a100-9eeb1959dd97"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("b5f902c4-b7b4-4cbd-bc75-5cf1686b20ef"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("fe1fac03-f051-4b4e-b839-fb4a007af1a8"));

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("7f5bbb4b-9688-4131-9393-17cfacf6e0c1"), "66f475cc-7353-48f4-8e0b-076206149f78", "Guest", "GUEST" },
                    { new Guid("a47f8816-03d9-4e6c-a01e-aee9600fe534"), "8b630afc-2793-4598-a3be-c5fb2f74469c", "Admin", "ADMIN" },
                    { new Guid("c86d7387-be03-4d58-b5f7-c79d899ddf8a"), "216e902f-d8e7-4487-a94c-dbe35a8219dd", "User", "USER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("7f5bbb4b-9688-4131-9393-17cfacf6e0c1"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("a47f8816-03d9-4e6c-a01e-aee9600fe534"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("c86d7387-be03-4d58-b5f7-c79d899ddf8a"));

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("1d35371d-f5ae-40a8-a100-9eeb1959dd97"), "ab579327-f872-43ab-aafb-71e85ecc95d2", "Guest", "GUEST" },
                    { new Guid("b5f902c4-b7b4-4cbd-bc75-5cf1686b20ef"), "9046c424-fadf-4fb9-88c3-30ae676c20f7", "User", "USER" },
                    { new Guid("fe1fac03-f051-4b4e-b839-fb4a007af1a8"), "acfa2142-7817-4535-a66a-804f6131b6d4", "Admin", "ADMIN" }
                });
        }
    }
}
