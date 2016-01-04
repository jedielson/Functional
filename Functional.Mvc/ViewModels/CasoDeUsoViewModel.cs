namespace Functional.Mvc.ViewModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Web.Mvc;

    using Functional.Domain.Entities.Model;

    using global::AutoMapper;

    public class CasoDeUsoViewModel
    {
        [Key]
        public Guid CasoDeUsoId { get; set; }
        
        [ScaffoldColumn(false)]
        public string Codigo { get; set; }
        
        [Required(ErrorMessage = "O Título é obrigatório")]
        // [Range(10, 100, ErrorMessage = "O título deve possuir no mínimo 10 e no máximo 100 caracteres")]
        public string Titulo { get; set; }

        [AllowHtml]
        [Display(Name = "Pré Condições")]
        public string PreCondicoes { get; set; }

        [AllowHtml]
        [Display(Name = "Pós Condições")]
        public string PosCondicoes { get; set; }

        [AllowHtml]
        [Display(Name = "Descrição")]
        public string Descricao { get; set; }

        [Display(Name = "Requisito")]
        public string RequisitoSelecionado { get; set; }

        public IEnumerable<RequisitoViewModel> Requisitos { get; set; }

        public FluxoPrincipalViewModel FluxoPrincipal { get; set; }

        public static CasoDeUsoViewModel ToViewModel(CasoDeUso model)
        {
            return Mapper.Map<CasoDeUsoViewModel>(model);
        }

        public static IEnumerable<CasoDeUsoViewModel> ToViewModel(IEnumerable<CasoDeUso> model)
        {
            return Mapper.Map<IEnumerable<CasoDeUsoViewModel>>(model);
        }

        public static CasoDeUso ToDomainModel(CasoDeUsoViewModel viewModel)
        {
            return Mapper.Map<CasoDeUso>(viewModel);
        }

        public static IEnumerable<CasoDeUso> ToDomainModel(IEnumerable<CasoDeUsoViewModel> viewModel)
        {
            return Mapper.Map<IEnumerable<CasoDeUso>>(viewModel);
        }
    }
}