// ---------------------------------------------------------------------------------- 
// Copyright (c) The Standard Organization, a coalition of the Good-Hearted Engineers 
// ----------------------------------------------------------------------------------
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AggroCom.Migrations
{
    /// <inheritdoc />
    public partial class PartOne11 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "TableTwos",
                newName: "NameUz");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "ProductTwos",
                newName: "TitleUz");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "ProductTwos",
                newName: "TitleRu");

            migrationBuilder.RenameColumn(
                name: "Des",
                table: "ProductTwos",
                newName: "SarfUz");

            migrationBuilder.AddColumn<string>(
                name: "Foiz",
                table: "TableTwos",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "NameRu",
                table: "TableTwos",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "DesRu",
                table: "ProductTwos",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "DesUz",
                table: "ProductTwos",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "DescriptionRu",
                table: "ProductTwos",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "DescriptionUZ",
                table: "ProductTwos",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "NameRu",
                table: "ProductTwos",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "NameUz",
                table: "ProductTwos",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "SarfRu",
                table: "ProductTwos",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Foiz",
                table: "TableTwos");

            migrationBuilder.DropColumn(
                name: "NameRu",
                table: "TableTwos");

            migrationBuilder.DropColumn(
                name: "DesRu",
                table: "ProductTwos");

            migrationBuilder.DropColumn(
                name: "DesUz",
                table: "ProductTwos");

            migrationBuilder.DropColumn(
                name: "DescriptionRu",
                table: "ProductTwos");

            migrationBuilder.DropColumn(
                name: "DescriptionUZ",
                table: "ProductTwos");

            migrationBuilder.DropColumn(
                name: "NameRu",
                table: "ProductTwos");

            migrationBuilder.DropColumn(
                name: "NameUz",
                table: "ProductTwos");

            migrationBuilder.DropColumn(
                name: "SarfRu",
                table: "ProductTwos");

            migrationBuilder.RenameColumn(
                name: "NameUz",
                table: "TableTwos",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "TitleUz",
                table: "ProductTwos",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "TitleRu",
                table: "ProductTwos",
                newName: "Description");

            migrationBuilder.RenameColumn(
                name: "SarfUz",
                table: "ProductTwos",
                newName: "Des");
        }
    }
}
