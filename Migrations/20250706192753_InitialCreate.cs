using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ConexaoSolidaria.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    NomeCompleto = table.Column<string>(type: "TEXT", nullable: false),
                    DataNascimento = table.Column<string>(type: "TEXT", nullable: false),
                    CPF = table.Column<string>(type: "TEXT", nullable: false),
                    RG = table.Column<string>(type: "TEXT", nullable: false),
                    NomeMae = table.Column<string>(type: "TEXT", nullable: false),
                    Foto = table.Column<string>(type: "TEXT", nullable: false),
                    TelefoneCelular = table.Column<string>(type: "TEXT", nullable: false),
                    TelefoneFixo = table.Column<string>(type: "TEXT", nullable: false),
                    NumeroPessoasFamilia = table.Column<string>(type: "TEXT", nullable: false),
                    EnderecoReferencia = table.Column<string>(type: "TEXT", nullable: false),
                    Renda = table.Column<string>(type: "TEXT", nullable: false),
                    Profissao = table.Column<string>(type: "TEXT", nullable: false),
                    ProgramaSocial = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Usuarios");
        }
    }
}
