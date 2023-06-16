using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Cine_Net.Infra.Migrations
{
    /// <inheritdoc />
    public partial class ReorganizacaoDataBase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ingresso_Cliente_ClienteId",
                table: "Ingresso");

            migrationBuilder.DropForeignKey(
                name: "FK_Ingresso_Sessao_SessaoId",
                table: "Ingresso");

            migrationBuilder.DropForeignKey(
                name: "FK_Sala_Cinema_CinemaId",
                table: "Sala");

            migrationBuilder.DropForeignKey(
                name: "FK_Sessao_Filme_FilmeId",
                table: "Sessao");

            migrationBuilder.DropForeignKey(
                name: "FK_Sessao_Sala_SalaId",
                table: "Sessao");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FilmeCategoria",
                table: "FilmeCategoria");

            migrationBuilder.DropColumn(
                name: "Categorias",
                table: "Categoria");

            migrationBuilder.AlterColumn<int>(
                name: "SalaId",
                table: "Sessao",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "FilmeId",
                table: "Sessao",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "IngressoId",
                table: "Sessao",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "CinemaId",
                table: "Sala",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SessaoId",
                table: "Sala",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "SessaoId",
                table: "Ingresso",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ClienteId",
                table: "Ingresso",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SessaoId",
                table: "Filme",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "IngressoId",
                table: "Cliente",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "Nome",
                table: "Cinema",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Endereco",
                table: "Cinema",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SalaId",
                table: "Cinema",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "FilmeId",
                table: "Categoria",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("Relational:ColumnOrder", 1);

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Categoria",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("SqlServer:Identity", "1, 1")
                .OldAnnotation("Relational:ColumnOrder", 2)
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FilmeCategoria",
                table: "FilmeCategoria",
                columns: new[] { "CategoriaId", "FilmeId" });

            migrationBuilder.CreateIndex(
                name: "IX_FilmeCategoria_FilmeId",
                table: "FilmeCategoria",
                column: "FilmeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Ingresso_Cliente_ClienteId",
                table: "Ingresso",
                column: "ClienteId",
                principalTable: "Cliente",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Ingresso_Sessao_SessaoId",
                table: "Ingresso",
                column: "SessaoId",
                principalTable: "Sessao",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Sala_Cinema_CinemaId",
                table: "Sala",
                column: "CinemaId",
                principalTable: "Cinema",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Sessao_Filme_FilmeId",
                table: "Sessao",
                column: "FilmeId",
                principalTable: "Filme",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Sessao_Sala_SalaId",
                table: "Sessao",
                column: "SalaId",
                principalTable: "Sala",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ingresso_Cliente_ClienteId",
                table: "Ingresso");

            migrationBuilder.DropForeignKey(
                name: "FK_Ingresso_Sessao_SessaoId",
                table: "Ingresso");

            migrationBuilder.DropForeignKey(
                name: "FK_Sala_Cinema_CinemaId",
                table: "Sala");

            migrationBuilder.DropForeignKey(
                name: "FK_Sessao_Filme_FilmeId",
                table: "Sessao");

            migrationBuilder.DropForeignKey(
                name: "FK_Sessao_Sala_SalaId",
                table: "Sessao");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FilmeCategoria",
                table: "FilmeCategoria");

            migrationBuilder.DropIndex(
                name: "IX_FilmeCategoria_FilmeId",
                table: "FilmeCategoria");

            migrationBuilder.DropColumn(
                name: "IngressoId",
                table: "Sessao");

            migrationBuilder.DropColumn(
                name: "SessaoId",
                table: "Sala");

            migrationBuilder.DropColumn(
                name: "SessaoId",
                table: "Filme");

            migrationBuilder.DropColumn(
                name: "IngressoId",
                table: "Cliente");

            migrationBuilder.DropColumn(
                name: "SalaId",
                table: "Cinema");

            migrationBuilder.AlterColumn<int>(
                name: "SalaId",
                table: "Sessao",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "FilmeId",
                table: "Sessao",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "CinemaId",
                table: "Sala",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "SessaoId",
                table: "Ingresso",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "ClienteId",
                table: "Ingresso",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "Nome",
                table: "Cinema",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Endereco",
                table: "Cinema",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<int>(
                name: "FilmeId",
                table: "Categoria",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("Relational:ColumnOrder", 1);

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Categoria",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("Relational:ColumnOrder", 2)
                .Annotation("SqlServer:Identity", "1, 1")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<string>(
                name: "Categorias",
                table: "Categoria",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_FilmeCategoria",
                table: "FilmeCategoria",
                columns: new[] { "FilmeId", "CategoriaId" });

            migrationBuilder.AddForeignKey(
                name: "FK_Ingresso_Cliente_ClienteId",
                table: "Ingresso",
                column: "ClienteId",
                principalTable: "Cliente",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Ingresso_Sessao_SessaoId",
                table: "Ingresso",
                column: "SessaoId",
                principalTable: "Sessao",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Sala_Cinema_CinemaId",
                table: "Sala",
                column: "CinemaId",
                principalTable: "Cinema",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Sessao_Filme_FilmeId",
                table: "Sessao",
                column: "FilmeId",
                principalTable: "Filme",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Sessao_Sala_SalaId",
                table: "Sessao",
                column: "SalaId",
                principalTable: "Sala",
                principalColumn: "Id");
        }
    }
}
