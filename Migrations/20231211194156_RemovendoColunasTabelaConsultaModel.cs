using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FluxoMedicoTesteNeoApp.Migrations
{
    /// <inheritdoc />
    public partial class RemovendoColunasTabelaConsultaModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Cpf",
                table: "ConsultasMedicas");

            migrationBuilder.DropColumn(
                name: "Nome",
                table: "ConsultasMedicas");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Cpf",
                table: "ConsultasMedicas",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Nome",
                table: "ConsultasMedicas",
                type: "text",
                nullable: false,
                defaultValue: "");
        }
    }
}
