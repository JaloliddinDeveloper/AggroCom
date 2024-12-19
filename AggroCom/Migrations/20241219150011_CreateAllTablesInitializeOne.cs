// ---------------------------------------------------------------------------------- 
// Copyright (c) The Standard Organization, a coalition of the Good-Hearted Engineers 
// ----------------------------------------------------------------------------------
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AggroCom.Migrations
{
    public partial class CreateAllTablesInitializeOne : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Addition",
                table: "ProductOnes",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "IconUrl",
                table: "ProductOnes",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Addition",
                table: "ProductOnes");

            migrationBuilder.DropColumn(
                name: "IconUrl",
                table: "ProductOnes");
        }
    }
}
