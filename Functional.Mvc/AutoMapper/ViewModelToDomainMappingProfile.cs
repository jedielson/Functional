using AutoMapper;
using Functional.Domain.Entities.Model;
using Functional.Mvc.ViewModels;

namespace Functional.Mvc.AutoMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public override string ProfileName => "ViewModelToDomainMappings";

        protected override void Configure()
        {
            Mapper.CreateMap<ProjetoViewModel, Projeto>();
            Mapper.CreateMap<RequisitoViewModel, Requisito>();
            Mapper.CreateMap<CasoDeUsoViewModel, CasoDeUso>();
        }

    }
}