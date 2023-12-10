using FluxoMedicoTesteNeoApp.Core.Dtos;
using FluxoMedicoTesteNeoApp.Core.Models;
using FluxoMedicoTesteNeoApp.Data;
using FluxoMedicoTesteNeoApp.Models;
using Microsoft.EntityFrameworkCore;

namespace FluxoMedicoTesteNeoApp.Core.Repository
{
    public class MedicoRepository : IMedicoRepository
    {
        private readonly BancoContext _bancoContext;
        public MedicoRepository(BancoContext bancoContext) {
            _bancoContext = bancoContext;
        }

        public async Task<IEnumerable<MedicoModel>> ConsultarMedico()
        {
            return await _bancoContext.Medicos.ToListAsync();
        }

        public async Task<MedicoModel> BuscarMedicoById(int id)
        {
            if (id == null)
            {
                throw new System.Exception("Verifique o Id passado se está correto!");

            }
            return await _bancoContext.Medicos.Where(x => x.Id == id).FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<MedicoModel> Salvar(MedicoDto medicoDto)
        {
            if (medicoDto == null)
            {
                throw new SystemException("Houve um erro nas informações do Paciente");
            }
            MedicoModel medico = new MedicoModel(medicoDto);
            medico.Perfil = Enums.PerfilEnum.Medico;
            await _bancoContext.Medicos.AddAsync(medico);
            await _bancoContext.SaveChangesAsync();
            return medico;
        }

        public async Task<bool> ExluirMedico(int id)
        {
            MedicoModel medico = await BuscarMedicoById(id);
            if (medico == null)
            {
                throw new System.Exception("Houve um erro na exlusao do usuário");
            }

            _bancoContext.Medicos.Remove(medico);
            _bancoContext.SaveChanges();

            return true;
        }
    }
}
