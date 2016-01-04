namespace Functional.Domain.Entities.Specifications.CasoDeUsoSpecs
{
    using Functional.Domain.Entities.Model;
    using Functional.Domain.Interfaces.Specification;
    class CasoDeUsodevePossuirUmCodigoSpec : ISpecification<CasoDeUso>
    {
        public bool IsSatisfiedBy(CasoDeUso entity)
        {
            return string.IsNullOrEmpty(entity.Codigo?.Trim());
        }
    }
}
