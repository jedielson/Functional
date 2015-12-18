using Functional.Application.Interfaces.Common;
using Functional.Domain.Interfaces.Context.Common;
using Functional.Domain.Validation;
using Microsoft.Practices.ServiceLocation;

namespace Functional.Application.Common
{
    public abstract class AppServiceBase<TEntity> : ITransactionAppService where TEntity : class
    {
        private IUnidadeDeTrabalho _uow;
        protected ValidationResult ValidationResult { get; private  set; }

        protected AppServiceBase()
        {
            ValidationResult = new ValidationResult();
        }

        public void BeginTransaction()
        {
            _uow = ServiceLocator.Current.GetInstance<IUnidadeDeTrabalho>();
            _uow.IniciarTransacao();
        }

        public void Commit()
        {
            _uow.ConfirmarTransacao();
        }
    }
}
