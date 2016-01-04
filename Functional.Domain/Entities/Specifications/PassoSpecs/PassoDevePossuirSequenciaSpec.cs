namespace Functional.Domain.Entities.Specifications.PassoSpecs
{
    using Functional.Domain.Entities.Model;
    using Functional.Domain.Interfaces.Specification;
    class PassoDevePossuirSequenciaSpec : ISpecification<Passo>
    {
        public bool IsSatisfiedBy(Passo entity)
        {
            return entity != null && entity.Sequencia > 0;
        }
    }
}
