namespace Functional.Domain.Entities.Validations
{
    using Functional.Domain.Entities.Model;
    using Functional.Domain.Entities.Specifications.CasoDeUsoSpecs;
    using Functional.Domain.Entities.Validations.Common;
    using Functional.Domain.Validation;
    class CasoDeUsoIsValidValidation : Validation<CasoDeUso>
    {
        public CasoDeUsoIsValidValidation()
        {
            // ReSharper disable once RedundantBaseQualifier
            base.AddRule(new ValidationRule<CasoDeUso>(new CasoDeUsodevePossuirUmCodigoSpec(), ValidationMessages.CasoDeUsoErroCasoDeUsoDevePossuirUmCodigo));

            // ReSharper disable once RedundantBaseQualifier
            base.AddRule(new ValidationRule<CasoDeUso>(new CasoDeUsodevePossuirUmTituloSpec(), ValidationMessages.CasoDeUsoErroCasoDeUsoDevePossuirUmTitulo));
        }
    }
}
