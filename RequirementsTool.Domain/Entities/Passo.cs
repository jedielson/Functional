using Functional.Domain.Interfaces.Validation;
using Functional.Domain.Validation;
using System;
using System.Collections.Generic;

namespace Functional.Domain.Entities
{
    public class Passo : ISelfValidation
    {
        public virtual int PassoId { get; set; }

        public virtual int Sequencia { get; set; }

        public virtual String Descricao { get; set; }

        public virtual Fluxo Fluxo { get; set; }

        public virtual IEnumerable<RegraDeNegocio> RegrasDeNegocio { get; set; }

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
