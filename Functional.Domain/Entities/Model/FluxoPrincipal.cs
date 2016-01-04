namespace Functional.Domain.Entities.Model
{
    using System;
    using System.Collections.Generic;

    using Functional.Domain.Entities.Validations;
    using Functional.Domain.Interfaces.Entities;
    using Functional.Domain.Validation;

    public class FluxoPrincipal : Fluxo, IEntityBase
    {
        public Guid CasoDeUsoId { get; set; }

        public CasoDeUso CasoDeUso { get; set; }

        public ICollection<FluxoAlternativo> FluxosAlternativos { get; set; }

        public ICollection<FluxoDeExcecao> FluxosDeExcecao { get; set; }

        public ValidationResult ValidationResult { get; private set; }

        public bool IsValid
        {
            get
            {
                var valid = new FluxoIsValidValidation();
                this.ValidationResult = valid.Valid(this);
                return this.ValidationResult.IsValid;
            }
        }
    }
}
