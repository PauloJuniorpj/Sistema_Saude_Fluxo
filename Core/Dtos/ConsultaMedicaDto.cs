using FluxoMedicoTesteNeoApp.Core.Models;
using FluxoMedicoTesteNeoApp.Models;
using System.Diagnostics.Tracing;

namespace FluxoMedicoTesteNeoApp.Core.Dtos
{
    public class ConsultaMedicaDto
    {   
        public int IdMedico { get; set; }

        public int IdPaciente{ get; set; }
        public string diagnostico { get; set; } 

    }
}
