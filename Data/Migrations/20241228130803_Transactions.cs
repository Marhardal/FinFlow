using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FinFlow.Data.Migrations
{
    /// <inheritdoc />
    public partial class Transactions : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Transactions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TypeID = table.Column<int>(type: "int", nullable: true),
                    PaymentTypeID = table.Column<int>(type: "int", nullable: true),
                    LinkedEntityId = table.Column<int>(type: "int", nullable: true),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: true),
                    RefNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TransTypesId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transactions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Transactions_PaymentTypes_PaymentTypeID",
                        column: x => x.PaymentTypeID,
                        principalTable: "PaymentTypes",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_Transactions_TransactionType_TransTypesId",
                        column: x => x.TransTypesId,
                        principalTable: "TransactionType",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Transactions_TransactionType_TypeID",
                        column: x => x.TypeID,
                        principalTable: "TransactionType",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_PaymentTypeID",
                table: "Transactions",
                column: "PaymentTypeID",
                unique: true,
                filter: "[PaymentTypeID] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_TransTypesId",
                table: "Transactions",
                column: "TransTypesId");

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_TypeID",
                table: "Transactions",
                column: "TypeID",
                unique: true,
                filter: "[TypeID] IS NOT NULL");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Transactions");
        }
    }
}
