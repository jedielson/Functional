namespace Functional.Domain.Entities.Specifications.FluxoSpecs
{
    using Functional.Domain.Entities.Model;
    using Functional.Domain.Interfaces.Specification;
    class FluxoDevePossuirUmTituloSpec : ISpecification<Fluxo>
    {
        public bool IsSatisfiedBy(Fluxo entity)
        {
            return entity != null && string.IsNullOrEmpty(entity.Titulo?.Trim());
        }
    }
}
