// ---------------------------------------------------------------------------------- 
// Copyright (c) The Standard Organization, a coalition of the Good-Hearted Engineers 
// ----------------------------------------------------------------------------------
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AggroCom.Migrations
{
    /// <inheritdoc />
    public partial class CreateAllTablesInitializeOneData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "SarfMeyori",
                table: "TableOnes",
                newName: "SarfMeyoriUz");

            migrationBuilder.RenameColumn(
                name: "EkinTuri",
                table: "TableOnes",
                newName: "SarfMeyoriRu");

            migrationBuilder.RenameColumn(
                name: "Cheklovlar",
                table: "TableOnes",
                newName: "EkinTuriUz");

            migrationBuilder.RenameColumn(
                name: "BegonaQarshi",
                table: "TableOnes",
                newName: "EkinTuriRu");

            migrationBuilder.RenameColumn(
                name: "Title",
                table: "ProductOnes",
                newName: "TitleUz");

            migrationBuilder.RenameColumn(
                name: "TasirModda",
                table: "ProductOnes",
                newName: "TitleRu");

            migrationBuilder.RenameColumn(
                name: "Qadogi",
                table: "ProductOnes",
                newName: "TasirModdaUz");

            migrationBuilder.RenameColumn(
                name: "PreparatShakli",
                table: "ProductOnes",
                newName: "TasirModdaRu");

            migrationBuilder.RenameColumn(
                name: "KimyoviySinfi",
                table: "ProductOnes",
                newName: "QadogiUz");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "ProductOnes",
                newName: "QadogiRu");

            migrationBuilder.RenameColumn(
                name: "Addition",
                table: "ProductOnes",
                newName: "PreparatShakliUz");

            migrationBuilder.AddColumn<string>(
                name: "BegonaQarshiRu",
                table: "TableOnes",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "BegonaQarshiUz",
                table: "TableOnes",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "CheklovlarRu",
                table: "TableOnes",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "CheklovlarUz",
                table: "TableOnes",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "AdditionRu",
                table: "ProductOnes",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "AdditionUz",
                table: "ProductOnes",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "DesRu",
                table: "ProductOnes",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "DesUz",
                table: "ProductOnes",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "DescriptionRu",
                table: "ProductOnes",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "DescriptionUz",
                table: "ProductOnes",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "KimyoviySinfiRu",
                table: "ProductOnes",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "KimyoviySinfiUz",
                table: "ProductOnes",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "PreparatShakliRu",
                table: "ProductOnes",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BegonaQarshiRu",
                table: "TableOnes");

            migrationBuilder.DropColumn(
                name: "BegonaQarshiUz",
                table: "TableOnes");

            migrationBuilder.DropColumn(
                name: "CheklovlarRu",
                table: "TableOnes");

            migrationBuilder.DropColumn(
                name: "CheklovlarUz",
                table: "TableOnes");

            migrationBuilder.DropColumn(
                name: "AdditionRu",
                table: "ProductOnes");

            migrationBuilder.DropColumn(
                name: "AdditionUz",
                table: "ProductOnes");

            migrationBuilder.DropColumn(
                name: "DesRu",
                table: "ProductOnes");

            migrationBuilder.DropColumn(
                name: "DesUz",
                table: "ProductOnes");

            migrationBuilder.DropColumn(
                name: "DescriptionRu",
                table: "ProductOnes");

            migrationBuilder.DropColumn(
                name: "DescriptionUz",
                table: "ProductOnes");

            migrationBuilder.DropColumn(
                name: "KimyoviySinfiRu",
                table: "ProductOnes");

            migrationBuilder.DropColumn(
                name: "KimyoviySinfiUz",
                table: "ProductOnes");

            migrationBuilder.DropColumn(
                name: "PreparatShakliRu",
                table: "ProductOnes");

            migrationBuilder.RenameColumn(
                name: "SarfMeyoriUz",
                table: "TableOnes",
                newName: "SarfMeyori");

            migrationBuilder.RenameColumn(
                name: "SarfMeyoriRu",
                table: "TableOnes",
                newName: "EkinTuri");

            migrationBuilder.RenameColumn(
                name: "EkinTuriUz",
                table: "TableOnes",
                newName: "Cheklovlar");

            migrationBuilder.RenameColumn(
                name: "EkinTuriRu",
                table: "TableOnes",
                newName: "BegonaQarshi");

            migrationBuilder.RenameColumn(
                name: "TitleUz",
                table: "ProductOnes",
                newName: "Title");

            migrationBuilder.RenameColumn(
                name: "TitleRu",
                table: "ProductOnes",
                newName: "TasirModda");

            migrationBuilder.RenameColumn(
                name: "TasirModdaUz",
                table: "ProductOnes",
                newName: "Qadogi");

            migrationBuilder.RenameColumn(
                name: "TasirModdaRu",
                table: "ProductOnes",
                newName: "PreparatShakli");

            migrationBuilder.RenameColumn(
                name: "QadogiUz",
                table: "ProductOnes",
                newName: "KimyoviySinfi");

            migrationBuilder.RenameColumn(
                name: "QadogiRu",
                table: "ProductOnes",
                newName: "Description");

            migrationBuilder.RenameColumn(
                name: "PreparatShakliUz",
                table: "ProductOnes",
                newName: "Addition");
        }
    }
}
