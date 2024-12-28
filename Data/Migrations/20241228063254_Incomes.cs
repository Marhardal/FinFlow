using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FinFlow.Data.Migrations
{
    /// <inheritdoc />
    public partial class Incomes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IncomeModelId",
                table: "IncomeCategories",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Incomes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    incCategoryID = table.Column<int>(type: "int", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    Date = table.Column<DateOnly>(type: "date", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Incomes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Incomes_IncomeCategories_incCategoryID",
                        column: x => x.incCategoryID,
                        principalTable: "IncomeCategories",
                        principalColumn: "Id");
                });

            migrationBuilder.UpdateData(
                table: "IncomeCategories",
                keyColumn: "Id",
                keyValue: 1,
                column: "IncomeModelId",
                value: null);

            migrationBuilder.UpdateData(
                table: "IncomeCategories",
                keyColumn: "Id",
                keyValue: 2,
                column: "IncomeModelId",
                value: null);

            migrationBuilder.UpdateData(
                table: "IncomeCategories",
                keyColumn: "Id",
                keyValue: 3,
                column: "IncomeModelId",
                value: null);

            migrationBuilder.UpdateData(
                table: "IncomeCategories",
                keyColumn: "Id",
                keyValue: 4,
                column: "IncomeModelId",
                value: null);

            migrationBuilder.UpdateData(
                table: "IncomeCategories",
                keyColumn: "Id",
                keyValue: 5,
                column: "IncomeModelId",
                value: null);

            migrationBuilder.UpdateData(
                table: "IncomeCategories",
                keyColumn: "Id",
                keyValue: 6,
                column: "IncomeModelId",
                value: null);

            migrationBuilder.CreateIndex(
                name: "IX_IncomeCategories_IncomeModelId",
                table: "IncomeCategories",
                column: "IncomeModelId");

            migrationBuilder.CreateIndex(
                name: "IX_Incomes_incCategoryID",
                table: "Incomes",
                column: "incCategoryID");

            migrationBuilder.AddForeignKey(
                name: "FK_IncomeCategories_Incomes_IncomeModelId",
                table: "IncomeCategories",
                column: "IncomeModelId",
                principalTable: "Incomes",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_IncomeCategories_Incomes_IncomeModelId",
                table: "IncomeCategories");

            migrationBuilder.DropTable(
                name: "Incomes");

            migrationBuilder.DropIndex(
                name: "IX_IncomeCategories_IncomeModelId",
                table: "IncomeCategories");

            migrationBuilder.DropColumn(
                name: "IncomeModelId",
                table: "IncomeCategories");
        }
    }
}
