using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace FluxoMedicoTesteNeoApp.Migrations
{
    /// <inheritdoc />
    public partial class CriandoTabelasMedicosPacientes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Nome",
                table: "ConsultasMedicas");

            migrationBuilder.AddColumn<int>(
                name: "MedicoId",
                table: "ConsultasMedicas",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PacienteId",
                table: "ConsultasMedicas",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Medicos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nome = table.Column<string>(type: "text", nullable: false),
                    Especialidade = table.Column<string>(type: "text", nullable: false),
                    Perfil = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Medicos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Pacientes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nome = table.Column<string>(type: "text", nullable: false),
                    Cpf = table.Column<string>(type: "text", nullable: false),
                    Idade = table.Column<int>(type: "integer", nullable: false),
                    Perfil = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pacientes", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ConsultasMedicas_MedicoId",
                table: "ConsultasMedicas",
                column: "MedicoId");

            migrationBuilder.CreateIndex(
                name: "IX_ConsultasMedicas_PacienteId",
                table: "ConsultasMedicas",
                column: "PacienteId");

            migrationBuilder.AddForeignKey(
                name: "FK_ConsultasMedicas_Medicos_MedicoId",
                table: "ConsultasMedicas",
                column: "MedicoId",
                principalTable: "Medicos",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ConsultasMedicas_Pacientes_PacienteId",
                table: "ConsultasMedicas",
                column: "PacienteId",
                principalTable: "Pacientes",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ConsultasMedicas_Medicos_MedicoId",
                table: "ConsultasMedicas");

            migrationBuilder.DropForeignKey(
                name: "FK_ConsultasMedicas_Pacientes_PacienteId",
                table: "ConsultasMedicas");

            migrationBuilder.DropTable(
                name: "Medicos");

            migrationBuilder.DropTable(
                name: "Pacientes");

            migrationBuilder.DropIndex(
                name: "IX_ConsultasMedicas_MedicoId",
                table: "ConsultasMedicas");

            migrationBuilder.DropIndex(
                name: "IX_ConsultasMedicas_PacienteId",
                table: "ConsultasMedicas");

            migrationBuilder.DropColumn(
                name: "MedicoId",
                table: "ConsultasMedicas");

            migrationBuilder.DropColumn(
                name: "PacienteId",
                table: "ConsultasMedicas");

            migrationBuilder.AddColumn<string>(
                name: "Nome",
                table: "ConsultasMedicas",
                type: "text",
                nullable: false,
                defaultValue: "");
        }
    }
}
