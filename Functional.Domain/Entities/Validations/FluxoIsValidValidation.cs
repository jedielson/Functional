namespace Functional.Domain.Entities.Validations
{
    using Functional.Domain.Entities.Model;
    using Functional.Domain.Entities.Specifications.FluxoSpecs;
    using Functional.Domain.Entities.Validations.Common;
    using Functional.Domain.Validation;
    class FluxoIsValidValidation : Validation<Fluxo>
    {
        public FluxoIsValidValidation()
        {
            // ReSharper disable once RedundantBaseQualifier
            base.AddRule(new ValidationRule<Fluxo>(new FluxoDevePossuirUmTituloSpec(), ValidationMessages.FluxoErroFluxoDevePossuirUmTitulo));

            // ReSharper disable once RedundantBaseQualifier
            base.AddRule(new ValidationRule<Fluxo>(new FluxoDevePossuirPassosSpec(), ValidationMessages.FluxoErroFluxoDevePossuirPassos));
        }
    }
}
