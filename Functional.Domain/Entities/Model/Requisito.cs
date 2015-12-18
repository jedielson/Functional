using System;
using System.Collections.Generic;
using Functional.Domain.Interfaces.Entities;
using Functional.Domain.Validation;

namespace Functional.Domain.Entities.Model
{
    public class Requisito : IEntityBase
    {
        public Guid RequisitoId { get; set; }

        public string Codigo { get; set; }

        public string Titulo { get; set; }

        public string Descricao { get; set; }

        public DateTime DataDeCriacao { get; set; }

        public DateTime DataUltimaAlteracao { get; set; }

        public Guid ProjetoId { get; set; }

        public Projeto Projeto { get; set; }

        public ICollection<CasoDeUso> CasosDeUso { get; set; }

        public ValidationResult ValidationResult
        {
            get { throw new NotImplementedException(); }
        }

        public bool IsValid
        {
            get { throw new NotImplementedException(); }
        }
    }
}
