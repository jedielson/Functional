namespace Functional.Domain.Entities.Model
{
    using System;
    using System.Collections.Generic;

    using Functional.Domain.Interfaces.Entities;
    using Functional.Domain.Validation;

    public class FluxoPrincipal : Fluxo, IEntityBase
    {
        public Guid CasoDeUsoId { get; set; }

        public CasoDeUso CasoDeUso { get; set; }

        public ICollection<FluxoAlternativo> FluxosAlternativos { get; set; }

        public ICollection<FluxoDeExcecao> FluxosDeExcecao { get; set; }

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
