using FluxoMedicoTesteNeoApp.Core.Models;
using FluxoMedicoTesteNeoApp.Models;

namespace FluxoMedicoTesteNeoApp.Core.Repository
{
    public interface IPacienteRepository
    {
        Task<PacienteModel> Salvar(PacienteModel paciente);

    }
}
