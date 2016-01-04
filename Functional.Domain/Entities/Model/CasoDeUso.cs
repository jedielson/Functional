using System.Collections.Generic;
using Functional.Domain.Interfaces.Entities;
using Functional.Domain.Validation;

namespace Functional.Domain.Entities.Model
{
    using System;

    using Functional.Domain.Entities.Validations;

    public class CasoDeUso : IEntityBase
    {
        public Guid CasoDeUsoId { get; set; }

        public string Codigo { get; set; }

        public string Titulo { get; set; }

        public string PreCondicoes { get; set; }

        public string PosCondicoes { get; set; }

        public string Descricao { get; set; }

        public ICollection<Requisito> Requisitos { get; set; }

        public FluxoPrincipal FluxoPrincipal { get; set; }

        public ValidationResult ValidationResult { get; private set; }

        public bool IsValid
        {
            get
            {
                var validacao = new CasoDeUsoIsValidValidation();
                this.ValidationResult = validacao.Valid(this);
                return this.ValidationResult.IsValid;
            }
        }
    }
}
