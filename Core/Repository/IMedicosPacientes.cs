using FluxoMedicoTesteNeoApp.Core.Dtos;
using FluxoMedicoTesteNeoApp.Core.Models;

namespace FluxoMedicoTesteNeoApp.Core.Repository
{
    public interface IMedicosPacientes
    {
        Task<MedicosPacientes> Salvar(MedicosPacientes medicosPacientes);
    }
}
