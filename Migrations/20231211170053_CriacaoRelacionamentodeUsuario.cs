using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace FluxoMedicoTesteNeoApp.Migrations
{
    /// <inheritdoc />
    public partial class CriacaoRelacionamentodeUsuario : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.CreateTable(
                name: "Medicos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nome = table.Column<string>(type: "text", nullable: false),
                    Especialidade = table.Column<string>(type: "text", nullable: false),
                    DataCadastroMedico = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    Perfil = table.Column<int>(type: "integer", nullable: false),
                    IdUsuarioMedico = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Medicos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Medicos_Usuarios_IdUsuarioMedico",
                        column: x => x.IdUsuarioMedico,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
                    DataCadastroPaciente = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    Perfil = table.Column<int>(type: "integer", nullable: false),
                    IdUsuarioPaciente = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pacientes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pacientes_Usuarios_IdUsuarioPaciente",
                        column: x => x.IdUsuarioPaciente,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ConsultasMedicas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Cpf = table.Column<string>(type: "text", nullable: false),
                    Nome = table.Column<string>(type: "text", nullable: false),
                    PacienteId = table.Column<int>(type: "integer", nullable: true),
                    MedicoId = table.Column<int>(type: "integer", nullable: true),
                    Diagnostico = table.Column<string>(type: "text", nullable: false),
                    DataConsulta = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConsultasMedicas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ConsultasMedicas_Medicos_MedicoId",
                        column: x => x.MedicoId,
                        principalTable: "Medicos",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ConsultasMedicas_Pacientes_PacienteId",
                        column: x => x.PacienteId,
                        principalTable: "Pacientes",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "tb_medico_paciente",
                columns: table => new
                {
                    id_paciente = table.Column<int>(type: "integer", nullable: false),
                    id_Medico = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_medico_paciente", x => new { x.id_Medico, x.id_paciente });
                    table.ForeignKey(
                        name: "FK_tb_medico_paciente_Medicos_id_Medico",
                        column: x => x.id_Medico,
                        principalTable: "Medicos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tb_medico_paciente_Pacientes_id_paciente",
                        column: x => x.id_paciente,
                        principalTable: "Pacientes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ConsultasMedicas_MedicoId",
                table: "ConsultasMedicas",
                column: "MedicoId");

            migrationBuilder.CreateIndex(
                name: "IX_ConsultasMedicas_PacienteId",
                table: "ConsultasMedicas",
                column: "PacienteId");

            migrationBuilder.CreateIndex(
                name: "IX_Medicos_IdUsuarioMedico",
                table: "Medicos",
                column: "IdUsuarioMedico",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Pacientes_IdUsuarioPaciente",
                table: "Pacientes",
                column: "IdUsuarioPaciente",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_tb_medico_paciente_id_paciente",
                table: "tb_medico_paciente",
                column: "id_paciente");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ConsultasMedicas");

            migrationBuilder.DropTable(
                name: "tb_medico_paciente");

            migrationBuilder.DropTable(
                name: "Medicos");

            migrationBuilder.DropTable(
                name: "Pacientes");

            migrationBuilder.DropTable(
                name: "Usuarios");
        }
    }
}
