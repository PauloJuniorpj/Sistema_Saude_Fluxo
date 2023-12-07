using FluxoMedicoTesteNeoApp.Models;
using Microsoft.EntityFrameworkCore;

namespace FluxoMedicoTesteNeoApp.Data
{
    public class BancoContext : DbContext
    {   
        // Configuração do nosso banco unsando o EntityFramework
        public BancoContext(DbContextOptions<BancoContext> options) : base(options) { }

        public DbSet<ConsultaModel> ConsultasMedicas { get; set; }
    }
}
