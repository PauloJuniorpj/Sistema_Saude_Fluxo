using FluxoMedicoTesteNeoApp.Core.Dtos;
using FluxoMedicoTesteNeoApp.Data;
using FluxoMedicoTesteNeoApp.Models;
using Microsoft.EntityFrameworkCore;

namespace FluxoMedicoTesteNeoApp.Core.Repository
{
    public class ConsultaMedicaRepository : IConsultaMedicaRepository
    {

        private readonly BancoContext _bancoContext;

        public ConsultaMedicaRepository(BancoContext bancoContext)
        {
            _bancoContext = bancoContext;
        }

        public async Task<IEnumerable<ConsultaModel>> ConsultaMedicas()
        {
            return await _bancoContext.ConsultasMedicas.ToListAsync();
        }

        public async Task<ConsultaModel> ConsultaMedicasById(int id)
        {
            return await _bancoContext.ConsultasMedicas.Where(x => x.Id == id) .FirstOrDefaultAsync(x => x.Id == id);
        }



        //Methodo de salvar CREATE
        public async Task<ConsultaModel> Salvar(ConsultaMedicaDto consulta)
        {
            ConsultaModel model = new ConsultaModel(consulta);
           await _bancoContext.ConsultasMedicas.AddAsync(model);
            _bancoContext.SaveChanges();
            return model;
        }
    }
}
