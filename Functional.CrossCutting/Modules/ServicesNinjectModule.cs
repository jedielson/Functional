using Functional.Domain.Interfaces.Service;
using Functional.Domain.Interfaces.Service.Common;
using Functional.Domain.Services;
using Functional.Domain.Services.Common;
using Ninject.Modules;

namespace Functional.CrossCutting.Ioc.Modules
{
    class ServicesNinjectModule : NinjectModule
    {
        public override void Load()
        {
            Bind(typeof (IService<>)).To(typeof (Service<>));
            Bind<IProjetoService>().To<ProjetoService>();
        }
    }
}
