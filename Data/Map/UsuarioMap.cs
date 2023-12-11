using FluxoMedicoTesteNeoApp.Core.Models;
using FluxoMedicoTesteNeoApp.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FluxoMedicoTesteNeoApp.Data.Map
{
    public class UsuarioMap : IEntityTypeConfiguration<UsuarioModel>
    {
        public void Configure(EntityTypeBuilder<UsuarioModel> builder)
        {
           // builder.HasOne(u => u.MedicoUsuario).WithOne(medico => medico.UsuarioMedico).HasForeignKey<MedicoModel>(medico => medico.IdUsuarioMedico);
           // builder.HasOne(u => u.PacienteUsuario).WithOne(paciente => paciente.UsuarioPaciente).HasForeignKey<PacienteModel>(paciente => paciente.IdUsuarioPaciente);

        }
    }
}
