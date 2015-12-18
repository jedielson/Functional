using Functional.Domain.Entities.Model;
using Functional.Domain.Entities.Specifications.ProjetoSpecs;
using Functional.Domain.Entities.Validations.Common;
using Functional.Domain.Validation;

namespace Functional.Domain.Entities.Validations
{
    internal class ProjectIsValidValidation : Validation<Projeto>
    {
        public ProjectIsValidValidation()
        {
            base.AddRule(new ValidationRule<Projeto>(new ProjetoDeveTerUmNomeSpec(), ValidationMessages.ErroProjetoPrecisaTerUmNome));
            base.AddRule(new ValidationRule<Projeto>(new CodigoDoProjetoDeveSerFormatadoSpec(), ValidationMessages.ErroCodigoDeProjetoMalFormatado));
        }
    }
}
