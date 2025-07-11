using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ConexaoSolidaria.Migrations
{
    /// <inheritdoc />
    public partial class AddPontoDeApoio : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Descricao",
                table: "PontosApoio",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Endereco",
                table: "PontosApoio",
                type: "TEXT",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Descricao",
                table: "PontosApoio");

            migrationBuilder.DropColumn(
                name: "Endereco",
                table: "PontosApoio");
        }
    }
}
