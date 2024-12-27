using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FinFlow.Data.Migrations
{
    /// <inheritdoc />
    public partial class IncomeCategories : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Expenses_Budgets_BudgetID",
                table: "Expenses");

            migrationBuilder.CreateTable(
                name: "IncomeCategories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IncomeCategories", x => x.Id);
                });

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

            migrationBuilder.DropTable(
                name: "IncomeCategories");

            migrationBuilder.AddForeignKey(
                name: "FK_Expenses_Budgets_BudgetID",
                table: "Expenses",
                column: "BudgetID",
                principalTable: "Budgets",
                principalColumn: "Id");
        }
    }
}
