using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FluxoMedicoTesteNeoApp.Migrations
{
    /// <inheritdoc />
    public partial class CriandoTabelaMedicosPacientesManyToMany : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Medicos_Pacientes_PacienteId",
                table: "Medicos");

            migrationBuilder.DropIndex(
                name: "IX_Medicos_PacienteId",
                table: "Medicos");

            migrationBuilder.DropColumn(
                name: "PacienteId",
                table: "Medicos");

            migrationBuilder.AddColumn<string>(
                name: "Nome",
                table: "ConsultasMedicas",
                type: "text",
                nullable: false,
                defaultValue: "");

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
                name: "IX_tb_medico_paciente_id_paciente",
                table: "tb_medico_paciente",
                column: "id_paciente");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tb_medico_paciente");

            migrationBuilder.DropColumn(
                name: "Nome",
                table: "ConsultasMedicas");

            migrationBuilder.AddColumn<int>(
                name: "PacienteId",
                table: "Medicos",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Medicos_PacienteId",
                table: "Medicos",
                column: "PacienteId");

            migrationBuilder.AddForeignKey(
                name: "FK_Medicos_Pacientes_PacienteId",
                table: "Medicos",
                column: "PacienteId",
                principalTable: "Pacientes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
