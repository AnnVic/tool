using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BookSharing.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class SeedRoles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("2f2d6f75-b680-42f7-824a-87ff8a1b135a"), "29d9a2b4-a477-4700-ae6e-04c2dde2919b", "Moderator", "MODERATOR" },
                    { new Guid("7d91c8c1-2e5a-4252-a791-438a2b270e82"), "0a7db5d1-ec2a-47da-b630-bd49925a2814", "Admin", "ADMIN" },
                    { new Guid("b286a029-04f8-4292-a032-462394eb7f5e"), "88e00b2f-d7f2-448b-bcc4-eb5112780b0e", "User", "USER" },
                    { new Guid("f4479f11-dfd1-4342-83ab-c7133e5c3ea2"), "c0e810dc-6bab-45f6-a435-9582874f43e0", "Guest", "GUEST" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("2f2d6f75-b680-42f7-824a-87ff8a1b135a"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("7d91c8c1-2e5a-4252-a791-438a2b270e82"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("b286a029-04f8-4292-a032-462394eb7f5e"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("f4479f11-dfd1-4342-83ab-c7133e5c3ea2"));
        }
    }
}
