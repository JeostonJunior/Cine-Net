using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Cine_Net.Infra.Migrations
{
    /// <inheritdoc />
    public partial class Rebase3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SalaId",
                table: "Sala",
                type: "int",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SalaId",
                table: "Sala");
        }
    }
}
