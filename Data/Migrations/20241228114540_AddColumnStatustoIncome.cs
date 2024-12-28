using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FinFlow.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddColumnStatustoIncome : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Expenses_Budgets_BudgetModelId",
                table: "Expenses");

            migrationBuilder.DropIndex(
                name: "IX_Expenses_BudgetModelId",
                table: "Expenses");

            migrationBuilder.DropColumn(
                name: "BudgetModelId",
                table: "Expenses");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Date",
                table: "Incomes",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateOnly),
                oldType: "date");

            migrationBuilder.AddColumn<bool>(
                name: "Status",
                table: "Incomes",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateIndex(
                name: "IX_Expenses_BudgetID",
                table: "Expenses",
                column: "BudgetID");

            migrationBuilder.AddForeignKey(
                name: "FK_Expenses_Budgets_BudgetID",
                table: "Expenses",
                column: "BudgetID",
                principalTable: "Budgets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Expenses_Budgets_BudgetID",
                table: "Expenses");

            migrationBuilder.DropIndex(
                name: "IX_Expenses_BudgetID",
                table: "Expenses");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Incomes");

            migrationBuilder.AlterColumn<DateOnly>(
                name: "Date",
                table: "Incomes",
                type: "date",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AddColumn<int>(
                name: "BudgetModelId",
                table: "Expenses",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Expenses_BudgetModelId",
                table: "Expenses",
                column: "BudgetModelId");

            migrationBuilder.AddForeignKey(
                name: "FK_Expenses_Budgets_BudgetModelId",
                table: "Expenses",
                column: "BudgetModelId",
                principalTable: "Budgets",
                principalColumn: "Id");
        }
    }
}
