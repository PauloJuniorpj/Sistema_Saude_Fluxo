using FluxoMedicoTesteNeoApp.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FluxoMedicoTesteNeoApp.Data.Map
{
    public class MedicoMap : IEntityTypeConfiguration<MedicoModel>
    {
        public void Configure(EntityTypeBuilder<MedicoModel> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasOne(x => x.Paciente);
        }
    }
}
