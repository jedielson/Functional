namespace Functional.Domain.Services
{
    using Functional.Domain.Entities.Model;
    using Functional.Domain.Interfaces.Repository;
    using Functional.Domain.Interfaces.Service;
    using Functional.Domain.Services.Common;
    public class CasoDeUsoService : Service<CasoDeUso>, ICasoDeUsoService
    {
        public CasoDeUsoService(ICasoDeUsoRepository repository)
            : base(repository)
        {
        }
    }
}
