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
        public virtual int ProjetoId { get; set; }

        [DisplayName("Código")]
        public virtual string Codigo { get; set; }

        [DisplayName("Nome")]
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