namespace Functional.Domain.Entities.Specifications.RequisitoSpecs
{
    using Functional.CrossCutting.Util;
    using Functional.Domain.Entities.Model;
    using Functional.Domain.Interfaces.Specification;
    class RequisitoDevePertencerAUmProjetoValido : ISpecification<Requisito>
    {
        public bool IsSatisfiedBy(Requisito entity)
        {
            return entity.Projeto != null && !entity.ProjetoId.IsEmpty() && entity.Projeto.IsValid;
        }
    }
}
