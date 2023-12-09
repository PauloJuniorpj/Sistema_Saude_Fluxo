using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FluxoMedicoTesteNeoApp.Migrations
{
    /// <inheritdoc />
    public partial class RelacioNamentosConsultaMedicosPacientes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
        }
    }
}
