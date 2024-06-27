using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TaxManagementNew.Migrations
{
    /// <inheritdoc />
    public partial class addedchangerequesttable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0b20ec61-6493-4e84-9b00-3a9d06249084");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "595fa70d-1149-4457-8784-48065359c54d");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7180883f-ad55-46c1-8e25-16ef6878df51");

            migrationBuilder.CreateTable(
                name: "ChangeRequests",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    taxId = table.Column<int>(type: "int", nullable: false),
                    reason = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChangeRequests", x => x.id);
                });

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

            migrationBuilder.InsertData(
                table: "ChangeRequests",
                columns: new[] { "id", "reason", "taxId" },
                values: new object[,]
                {
                    { 1, "Wrong", 1 },
                    { 2, "Wrong", 2 }
                });

            migrationBuilder.InsertData(
                table: "TaxDeclarations",
                columns: new[] { "TaxId", "AnyOtherIncome", "BankFixedDeposit", "DateOfDeclaration", "EmpId", "FinancialYear", "HigherEducationLoanInterest", "HouseRent", "InterestHousingLoan", "LTA", "LifeInsurancePremium", "MediClaim", "NPS", "PPF", "PreventiveHealthCheckUp", "PrincipalHousingLoan", "Status", "SukanyaSamriddhiAccount", "TDS", "TuitionFee", "isAccepted", "isDrafted", "isFrozen", "isRejected", "isSubmitted" },
                values: new object[,]
                {
                    { 1, 0m, 40000m, "2024-04-28", 1001, 2025, 20000m, 20000m, 25000m, true, 25000m, 15000m, 30000m, 20000m, 10000m, 35000m, "accepted", 15000m, 25000m, 30000m, true, false, false, false, false },
                    { 2, 0m, 40000m, "2024-04-28", 1001, 2025, 20000m, 20000m, 25000m, true, 25000m, 15000m, 30000m, 20000m, 10000m, 35000m, "rejected", 15000m, 25000m, 30000m, false, false, false, true, false }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ChangeRequests");

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

            migrationBuilder.DeleteData(
                table: "TaxDeclarations",
                keyColumn: "TaxId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "TaxDeclarations",
                keyColumn: "TaxId",
                keyValue: 2);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "0b20ec61-6493-4e84-9b00-3a9d06249084", null, "client", "client" },
                    { "595fa70d-1149-4457-8784-48065359c54d", null, "admin", "admin" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Address", "Age", "ConcurrencyStamp", "DateOfBirth", "Email", "EmailConfirmed", "EmpId", "LockoutEnabled", "LockoutEnd", "Name", "NormalizedEmail", "NormalizedUserName", "PanNo", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "7180883f-ad55-46c1-8e25-16ef6878df51", 0, "123 Main St, City, Country", 22, "eb8ad64a-6cb1-41cd-995e-163fe125a7dc", new DateTime(2002, 1, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, 1000, false, null, "Vishal Kumar", null, null, "ABCDE1234F", null, "1234567890", false, "afe064c7-0da2-4ee0-9326-0ed1fa1c98b8", false, null });
        }
    }
}
