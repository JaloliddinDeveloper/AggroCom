using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AggroCom.Migrations
{
    /// <inheritdoc />
    public partial class CreateAllTablesInitialize100 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MavsumNechta",
                table: "TableOnes");

            migrationBuilder.RenameColumn(
                name: "CheklovlarUz",
                table: "TableOnes",
                newName: "Onlsum");

            migrationBuilder.RenameColumn(
                name: "CheklovlarRu",
                table: "TableOnes",
                newName: "BirgaSarfUz");

            migrationBuilder.AddColumn<string>(
                name: "BirgaSarfRu",
                table: "TableOnes",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BirgaSarfRu",
                table: "TableOnes");

            migrationBuilder.RenameColumn(
                name: "Onlsum",
                table: "TableOnes",
                newName: "CheklovlarUz");

            migrationBuilder.RenameColumn(
                name: "BirgaSarfUz",
                table: "TableOnes",
                newName: "CheklovlarRu");

            migrationBuilder.AddColumn<int>(
                name: "MavsumNechta",
                table: "TableOnes",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
