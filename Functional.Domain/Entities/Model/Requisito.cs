using System;
using System.Collections.Generic;
using Functional.Domain.Interfaces.Entities;
using Functional.Domain.Validation;

namespace Functional.Domain.Entities.Model
{
    using Functional.Domain.Entities.Validations;

    public class Requisito : IEntityBase
    {
        public Guid RequisitoId { get; set; }

        public string Codigo { get; set; }

        public string Titulo { get; set; }

        public string Descricao { get; set; }

        public DateTime DataDeCriacao { get; set; }

        public DateTime DataUltimaAlteracao { get; set; }

        public Guid ProjetoId { get; set; }

        public virtual Projeto Projeto { get; set; }

        public virtual ICollection<CasoDeUso> CasosDeUso { get; set; }

        public ValidationResult ValidationResult
        {
            get; private set;
        }

        public bool IsValid
        {
            get
            {
                var valid = new RequisitoIsValidValidation();
                this.ValidationResult = valid.Valid(this);
                return this.ValidationResult.IsValid;
            }
        }
    }
}
