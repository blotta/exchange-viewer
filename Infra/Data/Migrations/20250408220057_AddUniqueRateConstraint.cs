using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddUniqueRateConstraint : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_ExchangeRates_Date_BaseCurrency_Currency",
                table: "ExchangeRates",
                columns: new[] { "Date", "BaseCurrency", "Currency" },
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_ExchangeRates_Date_BaseCurrency_Currency",
                table: "ExchangeRates");
        }
    }
}
