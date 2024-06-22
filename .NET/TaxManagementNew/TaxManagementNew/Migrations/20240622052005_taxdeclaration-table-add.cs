using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TaxManagementNew.Migrations
{
    /// <inheritdoc />
    public partial class taxdeclarationtableadd : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2da025a6-c138-4bf4-8a92-e2700a292dd3");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ef66eaa9-ab27-48bb-911f-0cf67daa7667");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "11623653-d2bf-49c4-9c76-b38ec7b4b1e5");

            migrationBuilder.CreateTable(
                name: "TaxDeclarations",
                columns: table => new
                {
                    TaxId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmpId = table.Column<int>(type: "int", nullable: false),
                    AnyOtherIncome = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    SukanyaSamriddhiAccount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PPF = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    LifeInsurancePremium = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TuitionFee = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    BankFixedDeposit = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PrincipalHousingLoan = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    NPS = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    HigherEducationLoanInterest = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    InterestHousingLoan = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    HouseRent = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TDS = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    MediClaim = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PreventiveHealthCheckUp = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    LTA = table.Column<bool>(type: "bit", nullable: false),
                    FinancialYear = table.Column<int>(type: "int", nullable: false),
                    isFrozen = table.Column<bool>(type: "bit", nullable: false),
                    DateOfDeclaration = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    isSubmitted = table.Column<bool>(type: "bit", nullable: false),
                    isDrafted = table.Column<bool>(type: "bit", nullable: false),
                    isAccepted = table.Column<bool>(type: "bit", nullable: false),
                    isRejected = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaxDeclarations", x => x.TaxId);
                });

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TaxDeclarations");

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

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "2da025a6-c138-4bf4-8a92-e2700a292dd3", null, "client", "client" },
                    { "ef66eaa9-ab27-48bb-911f-0cf67daa7667", null, "admin", "admin" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Address", "Age", "ConcurrencyStamp", "DateOfBirth", "Email", "EmailConfirmed", "EmpId", "LockoutEnabled", "LockoutEnd", "Name", "NormalizedEmail", "NormalizedUserName", "PanNo", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "11623653-d2bf-49c4-9c76-b38ec7b4b1e5", 0, "123 Main St, City, Country", 22, "01be2f19-d7b4-4fad-9614-5fb2b309874d", new DateTime(2002, 1, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, 1000, false, null, "Vishal Kumar", null, null, "ABCDE1234F", null, "1234567890", false, "f2112f59-b271-49c7-ada3-8beb709e8606", false, null });
        }
    }
}
