using Functional.Domain.Interfaces.Validation;
using Functional.Domain.Validation;
using System;
using System.Collections.Generic;

namespace Functional.Domain.Entities
{
    public class RegraDeNegocio : ISelfValidation
    {
        public virtual int RegraDeNegocioId { get; set; }

        public virtual string Codigo { get; set; }

        public virtual string Descricao { get; set; }

        public virtual DateTime DataDeCriacao { get; set; }

        public virtual DateTime DataUltimaAlteracao { get; set; }

        public virtual IEnumerable<Passo> Passos { get; set; }

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
