namespace Functional.Domain.Entities.Model
{
    using System;
    using System.Collections.Generic;

    using Functional.Domain.Interfaces.Entities;
    using Functional.Domain.Validation;

    public class FluxoAlternativo : Fluxo, IEntityBase
    {
        public Guid FluxoPrincipalId { get; set; }

        public FluxoPrincipal FluxoPrincipal { get; set; }

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
