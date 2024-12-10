using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AggroCom.Migrations
{
    /// <inheritdoc />
    public partial class OneMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ProductOnes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TasirModda = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KimyoviySinfi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PreparatShakli = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Qadogi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProductPicture = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProductType = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductOnes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TableOnes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EkinTuri = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BegonaQarshi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SarfMeyori = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Cheklovlar = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MavsumNechta = table.Column<int>(type: "int", nullable: false),
                    ProductOneId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TableOnes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TableOnes_ProductOnes_ProductOneId",
                        column: x => x.ProductOneId,
                        principalTable: "ProductOnes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TableOnes_ProductOneId",
                table: "TableOnes",
                column: "ProductOneId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TableOnes");

            migrationBuilder.DropTable(
                name: "ProductOnes");
        }
    }
}
