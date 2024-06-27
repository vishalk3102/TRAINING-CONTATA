using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TaxManagementNew.Migrations
{
    /// <inheritdoc />
    public partial class updatechangerequesttable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6e85f99e-2d9b-4620-a381-d4a57845b30d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c080ff7e-dfa5-4642-b0ac-1493b384ab36");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7f49676f-2ef5-444b-a292-3873b99c96b7");

            migrationBuilder.RenameColumn(
                name: "taxId",
                table: "ChangeRequests",
                newName: "TaxId");

            migrationBuilder.RenameColumn(
                name: "reason",
                table: "ChangeRequests",
                newName: "Reason");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "ChangeRequests",
                newName: "Id");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.RenameColumn(
                name: "TaxId",
                table: "ChangeRequests",
                newName: "taxId");

            migrationBuilder.RenameColumn(
                name: "Reason",
                table: "ChangeRequests",
                newName: "reason");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "ChangeRequests",
                newName: "id");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "6e85f99e-2d9b-4620-a381-d4a57845b30d", null, "admin", "admin" },
                    { "c080ff7e-dfa5-4642-b0ac-1493b384ab36", null, "client", "client" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Address", "Age", "ConcurrencyStamp", "DateOfBirth", "Email", "EmailConfirmed", "EmpId", "LockoutEnabled", "LockoutEnd", "Name", "NormalizedEmail", "NormalizedUserName", "PanNo", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "7f49676f-2ef5-444b-a292-3873b99c96b7", 0, "123 Main St, City, Country", 22, "0bbc7313-52e1-4f35-8c4f-642f82f67fc0", new DateTime(2002, 1, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, 1000, false, null, "Vishal Kumar", null, null, "ABCDE1234F", null, "1234567890", false, "257fcad8-acf7-4974-b0e5-5333c637b5ba", false, null });
        }
    }
}
