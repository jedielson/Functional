namespace Functional.Domain.Entities.Specifications.PassoSpecs
{
    using Functional.Domain.Entities.Model;
    using Functional.Domain.Interfaces.Specification;
    class PassoDevePossuirDescricaoSpec : ISpecification<Passo>
    {
        public bool IsSatisfiedBy(Passo entity)
        {
            return entity != null && string.IsNullOrEmpty(entity.Descricao?.Trim());
        }
    }
}
