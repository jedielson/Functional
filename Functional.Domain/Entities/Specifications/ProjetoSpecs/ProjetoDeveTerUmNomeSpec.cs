using System;
using Functional.Domain.Entities.Model;
using Functional.Domain.Interfaces.Specification;

namespace Functional.Domain.Entities.Specifications.ProjetoSpecs
{
    public class ProjetoDeveTerUmNomeSpec : ISpecification<Projeto>
    {
        public bool IsSatisfiedBy(Projeto entity)
        {
            return !string.IsNullOrEmpty(entity.Nome) && !string.IsNullOrWhiteSpace(entity.Nome);
        }
    }
}
