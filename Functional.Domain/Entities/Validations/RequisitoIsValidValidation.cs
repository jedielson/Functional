namespace Functional.Domain.Entities.Validations
{
    using Functional.Domain.Entities.Model;
    using Functional.Domain.Entities.Specifications.RequisitoSpecs;
    using Functional.Domain.Entities.Validations.Common;
    using Functional.Domain.Validation;

    class RequisitoIsValidValidation : Validation<Requisito>
    {
        public RequisitoIsValidValidation()
        {
            // ReSharper disable once RedundantBaseQualifier
            base.AddRule(new ValidationRule<Requisito>(new RequisitoDevePertencerAUmProjetoValido(), ValidationMessages.RequisitoDevePertencerAUmProjetoValido));
        }
    }
}
