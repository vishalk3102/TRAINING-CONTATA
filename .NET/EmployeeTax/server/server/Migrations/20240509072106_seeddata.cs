using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace server.Migrations
{
    /// <inheritdoc />
    public partial class seeddata : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ChangeRequests",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    taxId = table.Column<int>(type: "int", nullable: false),
                    empId = table.Column<int>(type: "int", nullable: false),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    financialYear = table.Column<int>(type: "int", nullable: false),
                    dateOfSubmission = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    reason = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChangeRequests", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    empId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    age = table.Column<int>(type: "int", nullable: false),
                    dateOfBirth = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    gender = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    phoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    panNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    role = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    password = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.empId);
                });

            migrationBuilder.CreateTable(
                name: "TaxDeclarations",
                columns: table => new
                {
                    taxId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    empId = table.Column<int>(type: "int", nullable: false),
                    anyOtherIncome = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    sukanyaSamriddhiAccount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PPF = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    lifeInsurancePremium = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    tuitionFee = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    bankFixedDeposit = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    principalHousingLoan = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    NPS = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    higherEducationLoanInterest = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    interestHousingLoan = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    houseRent = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TDS = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    mediClaim = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    preventiveHealthCheckUp = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    LTA = table.Column<bool>(type: "bit", nullable: false),
                    financialYear = table.Column<int>(type: "int", nullable: false),
                    isFrozen = table.Column<bool>(type: "bit", nullable: false),
                    dateOfDeclaration = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    status = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaxDeclarations", x => x.taxId);
                });

            migrationBuilder.InsertData(
                table: "ChangeRequests",
                columns: new[] { "id", "dateOfSubmission", "empId", "financialYear", "name", "reason", "taxId" },
                values: new object[,]
                {
                    { 1, "2024-04-21", 1, 2024, "Vishal Kumar", "Wrong", 1 },
                    { 2, "2024-04-21", 2, 2024, "Vishal Kumar", "Wrong", 2 }
                });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "empId", "address", "age", "dateOfBirth", "gender", "name", "panNo", "password", "phoneNumber", "role" },
                values: new object[,]
                {
                    { 1, "123 Main St, City, Country", 22, "2002-01-31", "Male", "Vishal Kumar", "ABCDE1234F", "emp@123", "1234567890", "employee" },
                    { 2, "123 Main St, City, Country", 21, "2002-01-31", "Male", "Vishal", "ABCDE1234F", "admin@123", "8459126643", "admin" }
                });

            migrationBuilder.InsertData(
                table: "TaxDeclarations",
                columns: new[] { "taxId", "LTA", "NPS", "PPF", "TDS", "anyOtherIncome", "bankFixedDeposit", "dateOfDeclaration", "empId", "financialYear", "higherEducationLoanInterest", "houseRent", "interestHousingLoan", "isFrozen", "lifeInsurancePremium", "mediClaim", "preventiveHealthCheckUp", "principalHousingLoan", "status", "sukanyaSamriddhiAccount", "tuitionFee" },
                values: new object[,]
                {
                    { 1, true, 30000m, 20000m, 25000m, 0m, 40000m, "2024-04-28", 1, 2025, 20000m, 20000m, 25000m, false, 25000m, 15000m, 10000m, 35000m, "accepted", 15000m, 30000m },
                    { 2, true, 30000m, 20000m, 25000m, 0m, 40000m, "2024-04-25", 2, 2024, 20000m, 20000m, 25000m, false, 25000m, 15000m, 10000m, 35000m, "drafted", 15000m, 30000m }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ChangeRequests");

            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "TaxDeclarations");
        }
    }
}
