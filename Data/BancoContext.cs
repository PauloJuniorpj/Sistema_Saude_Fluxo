using FluxoMedicoTesteNeoApp.Core.Models;
using FluxoMedicoTesteNeoApp.Data.Map;
using FluxoMedicoTesteNeoApp.Models;
using Microsoft.EntityFrameworkCore;

namespace FluxoMedicoTesteNeoApp.Data
{
    public class BancoContext : DbContext
    {   
        // Configuração do nosso banco unsando o EntityFramework
        public BancoContext(DbContextOptions<BancoContext> options) : base(options) { }

        public DbSet<ConsultaModel> ConsultasMedicas { get; set; }

        public DbSet<MedicoModel> Medicos { get; set;}

        public DbSet<PacienteModel> Pacientes { get; set;}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {   
            //Config de relacionamentos de Consultas com Medicos e Pacientes 
            modelBuilder.ApplyConfiguration(new ConsultasMap());

            //Config de relacionamentos de Medicos com pacientes 
            modelBuilder.ApplyConfiguration(new MedicoMap());

            base.OnModelCreating(modelBuilder);
        }
    }

}
