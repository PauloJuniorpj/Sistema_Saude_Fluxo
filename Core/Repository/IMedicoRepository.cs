using FluxoMedicoTesteNeoApp.Core.Dtos;
using FluxoMedicoTesteNeoApp.Models;

namespace FluxoMedicoTesteNeoApp.Core.Repository
{
    public interface IMedicoRepository
    {
        Task<MedicoModel> Salvar(MedicoModel medico);
    }
}
