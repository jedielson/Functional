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
        public ProjetoService(IProjetoRepository repository, IProjetoReadOnlyRepository readOnlyRepository) : base(repository, readOnlyRepository)
        {
        }

        public string ObtemUmNovoCodigo()
        {
            var quantidadeDeProjetosAtivos = Repository.All().ToList().Count;
            return "PRJ" + (quantidadeDeProjetosAtivos + 1);
        }

        public override ValidationResult Create(Projeto entity)
        {
            entity.Codigo = ObtemUmNovoCodigo();
            return base.Create(entity);
        }
    }
}
