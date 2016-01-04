namespace Functional.Domain.Entities.Specifications.FluxoSpecs
{
    using System.Linq;

    using Functional.Domain.Entities.Model;
    using Functional.Domain.Interfaces.Specification;
    class FluxoDevePossuirPassosSpec : ISpecification<Fluxo>
    {
        public bool IsSatisfiedBy(Fluxo entity)
        {
            var retorno = entity?.Passos != null && entity.Passos.Any();

            if (!retorno)
            {
                return false;
            }

            if (entity.Passos.Any(passo => !passo.IsValid))
            {
                return false;
            }

            return true;
        }
    }
}
