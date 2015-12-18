using System;
using Functional.Domain.Interfaces.Specification;
using Functional.Domain.Entities.Model;

namespace Functional.Domain.Entities.Specifications.ProjetoSpecs
{
    class CodigoDoProjetoDeveSerFormatadoSpec : ISpecification<Projeto>
    {
        public bool IsSatisfiedBy(Projeto entity)
        {
            return entity.Codigo != null && !string.IsNullOrEmpty(entity.Codigo.Trim()) && entity.Codigo.Substring(0, 3) == "PRJ";
        }
    }
}
