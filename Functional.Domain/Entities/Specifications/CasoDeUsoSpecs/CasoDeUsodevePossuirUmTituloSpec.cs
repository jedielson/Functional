namespace Functional.Domain.Entities.Specifications.CasoDeUsoSpecs
{
    using Functional.Domain.Entities.Model;
    using Functional.Domain.Interfaces.Specification;
    class CasoDeUsodevePossuirUmTituloSpec : ISpecification<CasoDeUso>
    {
        public bool IsSatisfiedBy(CasoDeUso entity)
        {
            return entity != null && string.IsNullOrEmpty(entity.Titulo?.Trim());
        }
    }
}
