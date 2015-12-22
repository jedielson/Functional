using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using AutoMapper;
using Functional.Domain.Entities.Model;

namespace Functional.Mvc.ViewModels
{
    public class ProjetoViewModel
    {
        [Key]
        public virtual Guid ProjetoId { get; set; }

        [DisplayName("Código")]
        [MaxLength(10, ErrorMessage = "O código não pode ter mais que 10 caracteres")]
        [Required(ErrorMessage = "O código é obrigatório")]
        public virtual string Codigo { get; set; }

        [DisplayName("Nome")]
        [Required(ErrorMessage = "O nome é obrigatório")]
        [MaxLength(50, ErrorMessage = "O nome não pode ter mais que 50 caracteres")]
        public virtual string Nome { get; set; }

        [ScaffoldColumn(false)]
        public virtual DateTime DataDeCriacao { get; set; }

        [ScaffoldColumn(false)]
        public virtual DateTime DataUltimaAlteracao { get; set; }

        internal static ProjetoViewModel ToViewModel(Projeto entity)
        {
            return Mapper.Map<ProjetoViewModel>(entity);
        }

        internal static IEnumerable<ProjetoViewModel> ToViewModel(IEnumerable<Projeto> entities)
        {
            return Mapper.Map<IEnumerable<ProjetoViewModel>>(entities);
        }

        internal static Projeto ToDomainModel(ProjetoViewModel model)
        {
            return Mapper.Map<Projeto>(model);
        }
    }
}