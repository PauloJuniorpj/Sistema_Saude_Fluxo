using AutoMapper;
using FluxoMedicoTesteNeoApp.Core.Dtos;
using FluxoMedicoTesteNeoApp.Models;

namespace FluxoMedicoTesteNeoApp.Core.AutoMappers
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile() {
            //Criando Relacionamento do Mapper dos Dtos com minha Model
            CreateMap<ConsultaMedicaDto, ConsultaModel>();

            // Se minha consulta for diferente de null ela vai manter os dados na base que ja existem
            CreateMap<ConsultaMedicaAtualizarDto, ConsultaModel>()
                .ForAllMembers(opts => opts.Condition((consultadto, consulta, srcConsulta) => srcConsulta != null));

        }
    }
}
