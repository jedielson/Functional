namespace Functional.Mvc.ViewModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using Functional.Domain.Entities.Model;

    using global::AutoMapper;

    public class RequisitoViewModel
    {
        [Key]
        public Guid RequisitoId { get; set; }


        public string Codigo { get; set; }

        [Required(ErrorMessage = "O título do requisito é obrigatório")]
        [MaxLength(100, ErrorMessage = "O título deve possuir no máximo 100 caracteres")]
        public string Titulo { get; set; }

        [Required(ErrorMessage = "A descrição do requisito é obrigatória")]
        [MaxLength(500, ErrorMessage = "A ~descrição deve possuir no máximo 500 caracteres")]
        public string Descricao { get; set; }

        public DateTime DataDeCriacao { get; set; }

        public DateTime DataUltimaAlteracao { get; set; }

        [Required(ErrorMessage = "O requisito deve estar associado à um projeto")]
        public Guid ProjetoId { get; set; }

        public ProjetoViewModel Projeto { get; set; }

        public string NomeFormatado => this.Codigo + " - " + this.Titulo;

        public static RequisitoViewModel ToViewModel(Requisito model)
        {
            return Mapper.Map<RequisitoViewModel>(model);
        }

        public static IEnumerable<RequisitoViewModel> ToViewModel(IEnumerable<Requisito> model)
        {
            return Mapper.Map<IEnumerable<RequisitoViewModel>>(model);
        }

        public static Requisito ToDomainModel(RequisitoViewModel model)
        {
            return Mapper.Map<Requisito>(model);
        }
    }
}