using FluxoMedicoTesteNeoApp.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FluxoMedicoTesteNeoApp.Data.Map
{
    public class ConsultasMap : IEntityTypeConfiguration<ConsultaModel>
    {
        public void Configure(EntityTypeBuilder<ConsultaModel> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasOne(x => x.Medico);

            builder.HasKey(x => x.Id);
            builder.HasOne(x => x.Paciente);

        }
    }
}
