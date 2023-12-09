using FluxoMedicoTesteNeoApp.Core.Models;
using FluxoMedicoTesteNeoApp.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FluxoMedicoTesteNeoApp.Data.Map
{
    public class MedicoMap : IEntityTypeConfiguration<MedicoModel>
    {
        public void Configure(EntityTypeBuilder<MedicoModel> builder)
        {
            //Relacionamento Muitos pra Muitos
            builder.HasMany(x => x.Pacientes).WithMany(x => x.Medicos)
                .UsingEntity<MedicosPacientes>(
                    x => x.HasOne(p => p.Paciente).WithMany().HasForeignKey(p => p.PacienteId),
                    x => x.HasOne(m => m.Medico).WithMany().HasForeignKey(m => m.MedicoId),
                    
                    //Criando o nome da tabela e a chave composta
                    x =>
                    {
                        x.ToTable("tb_medico_paciente");

                        x.HasKey(m => new { m.MedicoId, m.PacienteId });

                        //definindo o nome das chaves compostas
                        x.Property(x => x.MedicoId).HasColumnName("id_Medico").IsRequired();
                        x.Property(x => x.PacienteId).HasColumnName("id_paciente").IsRequired();
                    }

                ); 

            
        }
    }
}
