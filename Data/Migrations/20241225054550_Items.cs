using System;
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
                name: "SelectedCategoryId",
                table: "Items",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<DateTime>(
                name: "Date",
                table: "Expenses",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(byte[]),
                oldType: "timestamp");

            migrationBuilder.CreateIndex(
                name: "IX_Items_SelectedCategoryId",
                table: "Items",
                column: "SelectedCategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Items_Category_SelectedCategoryId",
                table: "Items",
                column: "SelectedCategoryId",
                principalTable: "Category",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Items_Category_SelectedCategoryId",
                table: "Items");

            migrationBuilder.DropIndex(
                name: "IX_Items_SelectedCategoryId",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "SelectedCategoryId",
                table: "Items");

            migrationBuilder.AlterColumn<byte[]>(
                name: "Date",
                table: "Expenses",
                type: "timestamp",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");
        }
    }
}
