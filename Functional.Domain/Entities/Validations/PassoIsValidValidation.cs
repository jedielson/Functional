namespace Functional.Domain.Entities.Validations
{
    using Functional.Domain.Entities.Model;
    using Functional.Domain.Entities.Specifications.PassoSpecs;
    using Functional.Domain.Entities.Validations.Common;

    using Validation;

    class PassoIsValidValidation : Validation<Passo>
    {
        public PassoIsValidValidation()
        {
            // ReSharper disable once RedundantBaseQualifier
            base.AddRule(new ValidationRule<Passo>(new PassoDevePossuirSequenciaSpec(), ValidationMessages.PassoErroPassoDevePossuirSequencia));

            // ReSharper disable once RedundantBaseQualifier
            base.AddRule(new ValidationRule<Passo>(new PassoDevePossuirDescricaoSpec(), ValidationMessages.PassoErroPassoDevePossuirDescricao));
        }
    }
}
