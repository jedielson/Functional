using Functional.Domain.Interfaces.Validation;
using Functional.Domain.Validation;

namespace Functional.Domain.Entities
{
    public class FluxoAlternativo : Fluxo, ISelfValidation
    {
        public virtual CasoDeUso CasoDeUso { get; set; }

        public ValidationResult ValidationResult
        {
            get { throw new System.NotImplementedException(); }
        }

        public bool IsValid
        {
            get { throw new System.NotImplementedException(); }
        }
    }
}
