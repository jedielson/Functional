using Functional.Domain.Interfaces.Validation;
using Functional.Domain.Validation;
using System.Collections.Generic;

namespace Functional.Domain.Entities
{
    public class CasoDeUso : ISelfValidation
    {
        public virtual int CasoDeUsoId { get; set; }

        public virtual string Codigo { get; set; }

        public virtual string Titulo { get; set; }

        public virtual IEnumerable<Requisito> Requisitos { get; set; }

        public virtual FluxoPrincipal FluxoPrincipal { get; set; }

        public virtual IEnumerable<FluxoAlternativo> FluxosAlternativos { get; set; }

        public virtual IEnumerable<FluxoDeExcecao> FluxosExcecao { get; set; }

        public virtual ValidationResult ValidationResult
        {
            get { throw new System.NotImplementedException(); }
        }

        public virtual bool IsValid
        {
            get { throw new System.NotImplementedException(); }
        }
    }
}
