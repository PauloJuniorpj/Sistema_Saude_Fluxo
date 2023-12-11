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

        public async Task<ConsultaModel> AlterarConsulta(ConsultaMedicaAtualizarDto consultaMedicaAtualizar)
        {
            var consultaAtualizada = new ConsultaModel(consultaMedicaAtualizar); 
            if(consultaAtualizada == null)  {
                throw new System.Exception("Houve um erro na atualozação da consulta!");
            }
            _bancoContext.ConsultasMedicas.Update(consultaAtualizada);
            await _bancoContext.SaveChangesAsync();
            return consultaAtualizada;
        }

        public async Task<bool> ExcluirMedico(int id)
        {
            ConsultaModel consulta = await ConsultaMedicasById(id);
            if (consulta == null)
            {
                throw new System.Exception("Houve um erro na exlusao do usuário");
            }

            _bancoContext.ConsultasMedicas.Remove(consulta);
            _bancoContext.SaveChanges();

            return true;
        }
    }
}
