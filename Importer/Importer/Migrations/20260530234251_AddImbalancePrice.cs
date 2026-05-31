using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Importer.Migrations
{
    /// <inheritdoc />
    public partial class AddImbalancePrice : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ImbalancedPrices",
                columns: table => new
                {
                    TimestampUtc = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Area = table.Column<int>(type: "INTEGER", nullable: false),
                    ImbalancePriceEUR = table.Column<decimal>(type: "TEXT", nullable: true),
                    ImbalancePriceDKK = table.Column<decimal>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ImbalancedPrices", x => new { x.TimestampUtc, x.Area });
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ImbalancedPrices");
        }
    }
}
