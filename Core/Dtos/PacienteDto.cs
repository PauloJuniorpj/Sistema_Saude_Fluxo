using FluxoMedicoTesteNeoApp.Enums;

namespace FluxoMedicoTesteNeoApp.Core.Dtos
{
    public class PacienteDto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public int Idade { get; set; }

        //public int idMedico { get; set; }
    }
}
