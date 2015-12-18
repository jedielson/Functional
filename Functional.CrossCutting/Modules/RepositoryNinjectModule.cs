using Functional.Data.Nhibernate.SqlServer.Context;
using Functional.Data.Nhibernate.SqlServer.Repository;
using Functional.Data.Nhibernate.SqlServer.Repository.Common;
using Functional.Data.Nhibernate.SqlServer.Repository.ReadOnly;
using Functional.Domain.Entities.Model;
using Functional.Domain.Interfaces.Context.Common;
using Functional.Domain.Interfaces.Repository;
using Functional.Domain.Interfaces.Repository.Common;
using Functional.Domain.Interfaces.Repository.ReadOnly;
using Ninject.Modules;

namespace Functional.CrossCutting.Ioc.Modules
{
    class RepositoryNinjectModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IUnidadeDeTrabalho>().To<UnidadeDeTrabalhoNh>();

            Bind(typeof (IRepository<>)).To(typeof(RepositoryBase<>));
            Bind(typeof (IReadOnlyRepository<>)).To(typeof (ReadOnlyRepositoryBase<>));
            
            Bind<IProjetoRepository>().To<ProjetoRepository>();
            Bind<IRepository<Projeto>>().To<ProjetoRepository>();
            Bind<IProjetoReadOnlyRepository>().To<ProjetoReadOnlyRepository>();
            Bind<IReadOnlyRepository<Projeto>>().To<ProjetoReadOnlyRepository>();
        }
    }
}
