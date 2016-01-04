namespace Functional.Domain.Entities.Model
{
    using System;
    using System.Collections.Generic;

    using Functional.Domain.Entities.Validations;
    using Functional.Domain.Interfaces.Entities;
    using Functional.Domain.Validation;

    public class Passo : IEntityBase
    {
        public Guid PassoId { get; set; }

        public int Sequencia { get; set; }
        
        public string Descricao { get; set; }

        public Guid FluxoId { get; set; }

        public virtual Fluxo Fluxo { get; set; }

        public virtual ICollection<RegraDeNegocio> RegrasDeNegocio { get; set; }

        public ValidationResult ValidationResult { get; private set; }

        public bool IsValid
        {
            get
            {
                var valid = new PassoIsValidValidation();
                this.ValidationResult = valid.Valid(this);
                return this.ValidationResult.IsValid;
            }
        }
    }
}
