using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace server.Migrations
{
    /// <inheritdoc />
    public partial class taxmodelupdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "isSubmitted",
                table: "TaxDeclarations",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "TaxDeclarations",
                keyColumn: "taxId",
                keyValue: 1,
                column: "isSubmitted",
                value: false);

            migrationBuilder.UpdateData(
                table: "TaxDeclarations",
                keyColumn: "taxId",
                keyValue: 2,
                column: "isSubmitted",
                value: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "isSubmitted",
                table: "TaxDeclarations");
        }
    }
}
