﻿using FluxoMedicoTesteNeoApp.Core.Models;
using FluxoMedicoTesteNeoApp.Enums;

namespace FluxoMedicoTesteNeoApp.Models
{
    public class MedicoModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        
        public string Especialidade { get; set; }

        public PerfilEnum Perfil { get; set; }
       
        public List<PacienteModel> Pacientes {  get; set; } 

        public virtual List<ConsultaModel> Consultas { get; set; }

    }
}
