using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace FluxoMedicoTesteNeoApp.Migrations
{
    /// <inheritdoc />
    public partial class RemovendoColunasETabela : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Medicos_Usuarios_IdUsuarioMedico",
                table: "Medicos");

            migrationBuilder.DropForeignKey(
                name: "FK_Pacientes_Usuarios_IdUsuarioPaciente",
                table: "Pacientes");

            migrationBuilder.DropTable(
                name: "Usuarios");

            migrationBuilder.DropIndex(
                name: "IX_Pacientes_IdUsuarioPaciente",
                table: "Pacientes");

            migrationBuilder.DropIndex(
                name: "IX_Medicos_IdUsuarioMedico",
                table: "Medicos");

            migrationBuilder.DropColumn(
                name: "IdUsuarioPaciente",
                table: "Pacientes");

            migrationBuilder.DropColumn(
                name: "IdUsuarioMedico",
                table: "Medicos");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IdUsuarioPaciente",
                table: "Pacientes",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "IdUsuarioMedico",
                table: "Medicos",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Login = table.Column<string>(type: "text", nullable: false),
                    Senha = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Pacientes_IdUsuarioPaciente",
                table: "Pacientes",
                column: "IdUsuarioPaciente",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Medicos_IdUsuarioMedico",
                table: "Medicos",
                column: "IdUsuarioMedico",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Medicos_Usuarios_IdUsuarioMedico",
                table: "Medicos",
                column: "IdUsuarioMedico",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Pacientes_Usuarios_IdUsuarioPaciente",
                table: "Pacientes",
                column: "IdUsuarioPaciente",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
