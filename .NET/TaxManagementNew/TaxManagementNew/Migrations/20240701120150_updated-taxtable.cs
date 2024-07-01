using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TaxManagementNew.Migrations
{
    /// <inheritdoc />
    public partial class updatedtaxtable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "914b46ef-25ed-4252-ba15-085b1b2491ed");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f847dda5-477d-4b19-b4d9-642d3b8add7c");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "909d85cf-afba-4831-8c2d-09b39afcd1c7");

            migrationBuilder.AlterColumn<string>(
                name: "PanNo",
                table: "AspNetUsers",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "3c719cfc-7259-4d0b-8ec2-5a22d6ef1374", null, "admin", "admin" },
                    { "f8c0e14b-bc51-45b4-923a-226d05310e6f", null, "client", "client" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Address", "Age", "ConcurrencyStamp", "DateOfBirth", "Email", "EmailConfirmed", "EmpId", "LockoutEnabled", "LockoutEnd", "Name", "NormalizedEmail", "NormalizedUserName", "PanNo", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "6fc59d85-9fc1-429d-885b-89769dcc1d54", 0, "123 Main St, City, Country", 22, "335cc1f4-83f5-40c9-94e9-1ffe2985e9fc", new DateTime(2002, 1, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, 1000, false, null, "Vishal Kumar", null, null, "ABCDE1234F", null, "1234567890", false, "86e40666-fd4d-4208-9539-5052ceb0b693", false, null });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_PanNo",
                table: "AspNetUsers",
                column: "PanNo",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_PanNo",
                table: "AspNetUsers");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3c719cfc-7259-4d0b-8ec2-5a22d6ef1374");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f8c0e14b-bc51-45b4-923a-226d05310e6f");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6fc59d85-9fc1-429d-885b-89769dcc1d54");

            migrationBuilder.AlterColumn<string>(
                name: "PanNo",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "914b46ef-25ed-4252-ba15-085b1b2491ed", null, "admin", "admin" },
                    { "f847dda5-477d-4b19-b4d9-642d3b8add7c", null, "client", "client" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Address", "Age", "ConcurrencyStamp", "DateOfBirth", "Email", "EmailConfirmed", "EmpId", "LockoutEnabled", "LockoutEnd", "Name", "NormalizedEmail", "NormalizedUserName", "PanNo", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "909d85cf-afba-4831-8c2d-09b39afcd1c7", 0, "123 Main St, City, Country", 22, "deae23e3-ee26-451a-943f-0c07584d91b4", new DateTime(2002, 1, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, 1000, false, null, "Vishal Kumar", null, null, "ABCDE1234F", null, "1234567890", false, "f72b0438-06c9-469a-a5f0-dbec263fa0f2", false, null });
        }
    }
}
