using System;
using System.Collections.Generic;
using Functional.Domain.Interfaces.Entities;
using Functional.Domain.Validation;
using Functional.Domain.Entities.Validations;

namespace Functional.Domain.Entities.Model
{
    public class Projeto : IEntityBase
    {
        public Guid ProjetoId { get; set; }

        public string Codigo { get; set; }

        public string Nome { get; set; }

        public DateTime DataDeCriacao { get; set; }

        public DateTime DataUltimaAlteracao { get; set; }

        public ICollection<Requisito> Requisitos { get; set; }

        public ValidationResult ValidationResult
        {
            get; protected set;
        }

        public bool IsValid
        {
            get
            {
                var valid = new ProjectIsValidValidation();
                this.ValidationResult = valid.Valid(this);
                return this.ValidationResult.IsValid;
            }
        }
    }
}
