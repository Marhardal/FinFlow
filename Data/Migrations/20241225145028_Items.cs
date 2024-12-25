using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FinFlow.Data.Migrations
{
    /// <inheritdoc />
    public partial class Items : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ItemsModelId",
                table: "Category",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Items",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SelectedCategoryId = table.Column<int>(type: "int", nullable: true),
                    Measurement = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Items", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Items_Category_SelectedCategoryId",
                        column: x => x.SelectedCategoryId,
                        principalTable: "Category",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Category_ItemsModelId",
                table: "Category",
                column: "ItemsModelId");

            migrationBuilder.CreateIndex(
                name: "IX_Items_SelectedCategoryId",
                table: "Items",
                column: "SelectedCategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Category_Items_ItemsModelId",
                table: "Category",
                column: "ItemsModelId",
                principalTable: "Items",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Category_Items_ItemsModelId",
                table: "Category");

            migrationBuilder.DropTable(
                name: "Items");

            migrationBuilder.DropIndex(
                name: "IX_Category_ItemsModelId",
                table: "Category");

            migrationBuilder.DropColumn(
                name: "ItemsModelId",
                table: "Category");
        }
    }
}
