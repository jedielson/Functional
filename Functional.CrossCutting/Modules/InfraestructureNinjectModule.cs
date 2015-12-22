namespace Functional.CrossCutting.Ioc.Modules
{
    using Functional.Data.Context;
    using Functional.Data.Context.Interfaces;

    using Ninject.Modules;

    public class InfraestructureNinjectModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IDbContext>().To<FunctionalContext>();
            Bind(typeof(IContextManager<>)).To(typeof(ContextManager<>));
            Bind(typeof(IUnitOfWork<>)).To(typeof(UnitOfWork<>));
        }
    }
}
