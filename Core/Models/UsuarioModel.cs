using FluxoMedicoTesteNeoApp.Models;

namespace FluxoMedicoTesteNeoApp.Core.Models
{
    public class UsuarioModel
    {
        public int Id { get; set; }
        public string Login { get; set; }

        public string Senha { get; set; }

        public PacienteModel PacienteUsuario { get; set; }

        public MedicoModel MedicoUsuario { get; set; }
    }
}
