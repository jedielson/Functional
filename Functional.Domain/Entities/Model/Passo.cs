namespace Functional.Domain.Entities.Model
{
    using System;
    using System.Collections.Generic;

    using Functional.Domain.Interfaces.Entities;
    using Functional.Domain.Validation;

    public class Passo : IEntityBase
    {
        public Guid PassoId { get; set; }

        public int Sequencia { get; set; }

        public string Descricao { get; set; }

        public Guid FluxoId { get; set; }

        public Fluxo Fluxo { get; set; }

        public ICollection<RegraDeNegocio> RegrasDeNegocio { get; set; }

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
