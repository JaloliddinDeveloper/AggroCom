// ---------------------------------------------------------------------------------- 
// Copyright (c) The Standard Organization, a coalition of the Good-Hearted Engineers 
// ----------------------------------------------------------------------------------
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AggroCom.Migrations
{
    /// <inheritdoc />
    public partial class CreateAllTablesAddTableTwo1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TableTwo_ProductTwos_ProductTwoId",
                table: "TableTwo");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TableTwo",
                table: "TableTwo");

            migrationBuilder.RenameTable(
                name: "TableTwo",
                newName: "TableTwos");

            migrationBuilder.RenameIndex(
                name: "IX_TableTwo_ProductTwoId",
                table: "TableTwos",
                newName: "IX_TableTwos_ProductTwoId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TableTwos",
                table: "TableTwos",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TableTwos_ProductTwos_ProductTwoId",
                table: "TableTwos",
                column: "ProductTwoId",
                principalTable: "ProductTwos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TableTwos_ProductTwos_ProductTwoId",
                table: "TableTwos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TableTwos",
                table: "TableTwos");

            migrationBuilder.RenameTable(
                name: "TableTwos",
                newName: "TableTwo");

            migrationBuilder.RenameIndex(
                name: "IX_TableTwos_ProductTwoId",
                table: "TableTwo",
                newName: "IX_TableTwo_ProductTwoId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TableTwo",
                table: "TableTwo",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TableTwo_ProductTwos_ProductTwoId",
                table: "TableTwo",
                column: "ProductTwoId",
                principalTable: "ProductTwos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
