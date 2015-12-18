namespace Functional.Domain.Entities.Model
{
    using System;

    using Functional.Domain.Interfaces.Entities;
    using Functional.Domain.Validation;

    public class FluxoDeExcecao : Fluxo, IEntityBase
    {
        public Guid FluxoPrincipalId { get; set; }

        public FluxoPrincipal FluxoPrincipal { get; set; }

        public virtual ValidationResult ValidationResult
        {
            get { throw new NotImplementedException(); }
        }

        public virtual bool IsValid
        {
            get { throw new NotImplementedException(); }
        }
    }
}
