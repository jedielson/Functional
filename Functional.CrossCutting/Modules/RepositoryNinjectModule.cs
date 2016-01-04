namespace Functional.CrossCutting.Ioc.Modules
{
    using Functional.Data.Repository;
    using Functional.Data.Repository.Common;
    using Functional.Domain.Entities.Model;
    using Functional.Domain.Interfaces.Repository;
    using Functional.Domain.Interfaces.Repository.Common;

    using Ninject.Modules;

    class RepositoryNinjectModule : NinjectModule
    {
        public override void Load()
        {
            Bind(typeof (IRepository<>)).To(typeof(RepositoryBase<>));
            
            Bind<IProjetoRepository>().To<ProjetoRepository>();
            Bind<IRepository<Projeto>>().To<ProjetoRepository>();

            Bind<IRequisitoRepository>().To<RequisitoRepository>();
            Bind<IRepository<Requisito>>().To<RequisitoRepository>();

            Bind<ICasoDeUsoRepository>().To<CasoDeUsoRepository>();
            Bind<IRepository<CasoDeUso>>().To<CasoDeUsoRepository>();
        }
    }
}
