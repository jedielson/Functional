using AutoMapper;
using Functional.Domain.Entities.Model;
using Functional.Mvc.ViewModels;

namespace Functional.Mvc.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public override string ProfileName
        {
            get { return "DomainToViewModelMappings"; }
        }

        protected override void Configure()
        {
            Mapper.CreateMap<Projeto, ProjetoViewModel>();
        }
    }
}