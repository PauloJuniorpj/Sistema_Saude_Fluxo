using FluxoMedicoTesteNeoApp.Models;

namespace FluxoMedicoTesteNeoApp.Core.Dtos
{
    public class ConsultaMedicaDto
    {

     

        public string NomePaciente { get; set; }

        public string NomeMedico {  get; set; }
        public string CpfPaciente { get; set; }
        public string Diagnostico { get; set; }

    }
}
