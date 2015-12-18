using Functional.Application;
using Functional.Application.Interfaces;
using Ninject.Modules;

namespace Functional.CrossCutting.Ioc.Modules
{
    public class ApplicationNinjectModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IProjetoAppService>().To<ProjetoAppService>();
        }
    }
}
