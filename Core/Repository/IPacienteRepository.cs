using FluxoMedicoTesteNeoApp.Core.Dtos;
using FluxoMedicoTesteNeoApp.Core.Models;
using FluxoMedicoTesteNeoApp.Models;

namespace FluxoMedicoTesteNeoApp.Core.Repository
{
    public interface IPacienteRepository
    {
        Task<PacienteModel> BuscarPacienteById(int id);
        Task<IEnumerable<PacienteModel>> ConsultaPacientes();
        Task<PacienteModel> Salvar(PacienteDto pacienteDto);

        Task<bool> ExluirPaciente(int id);
    }
}
