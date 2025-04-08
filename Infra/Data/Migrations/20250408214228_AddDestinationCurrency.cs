using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddDestinationCurrency : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Rate",
                table: "ExchangeRates",
                newName: "Amount");

            migrationBuilder.AddColumn<string>(
                name: "Currency",
                table: "ExchangeRates",
                type: "nvarchar(3)",
                maxLength: 3,
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Currency",
                table: "ExchangeRates");

            migrationBuilder.RenameColumn(
                name: "Amount",
                table: "ExchangeRates",
                newName: "Rate");
        }
    }
}
