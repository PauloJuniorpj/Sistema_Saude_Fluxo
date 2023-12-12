using FluxoMedicoTesteNeoApp.Core.Dtos;
using FluxoMedicoTesteNeoApp.Models;

namespace FluxoMedicoTesteNeoApp.Core.Repository
{
    public interface IMedicoRepository
    {
        Task<IEnumerable<MedicoModel>> ConsultarMedico();
        Task<MedicoModel> BuscarMedicoById(int? id);
        Task<MedicoModel> Salvar(MedicoDto medicoDto);

        Task<bool> ExcluirMedico(int id);
        Task<MedicoModel> AlterarDadosMedico(MedicoAtualizadoDto medicoAtualizadoDto);
       
    }
}
