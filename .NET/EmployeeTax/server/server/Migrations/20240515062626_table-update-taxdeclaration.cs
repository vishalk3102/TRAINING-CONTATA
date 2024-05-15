using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace server.Migrations
{
    /// <inheritdoc />
    public partial class tableupdatetaxdeclaration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "isAccepted",
                table: "TaxDeclarations",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "isDrafted",
                table: "TaxDeclarations",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "isRejected",
                table: "TaxDeclarations",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "TaxDeclarations",
                keyColumn: "taxId",
                keyValue: 1,
                columns: new[] { "isAccepted", "isDrafted", "isRejected", "status" },
                values: new object[] { true, false, false, "accepted" });

            migrationBuilder.UpdateData(
                table: "TaxDeclarations",
                keyColumn: "taxId",
                keyValue: 2,
                columns: new[] { "isAccepted", "isDrafted", "isRejected", "status" },
                values: new object[] { false, false, true, "rejected" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "isAccepted",
                table: "TaxDeclarations");

            migrationBuilder.DropColumn(
                name: "isDrafted",
                table: "TaxDeclarations");

            migrationBuilder.DropColumn(
                name: "isRejected",
                table: "TaxDeclarations");

            migrationBuilder.UpdateData(
                table: "TaxDeclarations",
                keyColumn: "taxId",
                keyValue: 1,
                column: "status",
                value: "drafted");

            migrationBuilder.UpdateData(
                table: "TaxDeclarations",
                keyColumn: "taxId",
                keyValue: 2,
                column: "status",
                value: "drafted");
        }
    }
}
