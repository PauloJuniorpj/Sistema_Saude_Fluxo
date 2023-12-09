using FluxoMedicoTesteNeoApp.Models;

namespace FluxoMedicoTesteNeoApp.Core.Models
{
    public class MedicosPacientes
    {   
        public int PacienteId { get; set; }
        public PacienteModel Paciente { get; set; }
        public int MedicoId { get; set; }
        public MedicoModel Medico { get; set; }

    }
}
