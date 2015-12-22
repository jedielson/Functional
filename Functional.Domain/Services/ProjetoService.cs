using Functional.Domain.Entities.Model;
using Functional.Domain.Interfaces.Repository;
using Functional.Domain.Interfaces.Repository.ReadOnly;
using Functional.Domain.Interfaces.Service;
using Functional.Domain.Services.Common;
using System.Linq;
using Functional.Domain.Validation;

namespace Functional.Domain.Services
{
    public class ProjetoService : Service<Projeto>, IProjetoService
    {
        public ProjetoService(IProjetoRepository repository) : base(repository)
        {
        }
    }
}
