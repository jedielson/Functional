namespace Functional.Domain.Entities.Model
{
    using System;
    using System.Collections.Generic;

    using Functional.Domain.Interfaces.Entities;
    using Functional.Domain.Validation;

    public class RegraDeNegocio : IEntityBase
    {
        public Guid RegraDeNegocioId { get; set; }

        public string Codigo { get; set; }

        public string Descricao { get; set; }

        public DateTime DataDeCriacao { get; set; }

        public DateTime DataUltimaAlteracao { get; set; }

        public ICollection<Passo> Passos { get; set; }

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
