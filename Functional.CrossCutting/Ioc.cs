using CommonServiceLocator.NinjectAdapter.Unofficial;
using Functional.CrossCutting.Ioc.Modules;
using Microsoft.Practices.ServiceLocation;
using Ninject;

namespace Functional.CrossCutting.Ioc
{
    public class Ioc
    {
        public IKernel Kernel { get; set; }

        public Ioc()
        {
            Kernel = GetNinjectModules();
            ServiceLocator.SetLocatorProvider(() => new NinjectServiceLocator(Kernel));

        }

        /// <summary>
        /// Retorna os módulos predefinidos do Ninject
        /// </summary>
        /// <returns>Os Módulos Predefinidos do Ninject</returns>
        private static IKernel GetNinjectModules()
        {
            return new StandardKernel(new ServicesNinjectModule()
                , new InfraestructureNinjectModule()
                , new RepositoryNinjectModule()
                , new ApplicationNinjectModule());
        }
    }
}
