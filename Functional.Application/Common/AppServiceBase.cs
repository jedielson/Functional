namespace Functional.Application.Common
{
    using Functional.Application.Interfaces.Common;
    using Functional.Data.Context.Interfaces;
    using Functional.Domain.Validation;

    using Microsoft.Practices.ServiceLocation;

    public abstract class AppServiceBase<TContext> : ITransactionAppService<TContext>
        where TContext : IDbContext, new()
    {
        private IUnitOfWork<TContext> _uow;

        protected AppServiceBase()
        {
            ValidationResult = new ValidationResult();
        }

        protected ValidationResult ValidationResult { get; set; }

        public virtual void BeginTransaction()
        {
            _uow = ServiceLocator.Current.GetInstance<IUnitOfWork<TContext>>();
            _uow.BeginTransaction();
        }

        public virtual void Commit()
        {
            _uow.SaveChanges();
        }
    }
}
