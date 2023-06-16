using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Cine_Net.Infra.Migrations
{
    /// <inheritdoc />
    public partial class Rebase2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CategoriaFilme");

            migrationBuilder.AddColumn<string>(
                name: "Categorias",
                table: "Categoria",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Categorias",
                table: "Categoria");

            migrationBuilder.CreateTable(
                name: "CategoriaFilme",
                columns: table => new
                {
                    FilmeId = table.Column<int>(type: "int", nullable: false),
                    FilmeId1 = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoriaFilme", x => new { x.FilmeId, x.FilmeId1 });
                });
        }
    }
}
