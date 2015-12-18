namespace Functional.Data.Context
{
    using System;

    using Functional.Data.Context.Interfaces;

    using Microsoft.Practices.ServiceLocation;

    public class UnitOfWork<TContext> : IUnitOfWork<TContext>, IDisposable
        where TContext : IDbContext, new()
    {
        private readonly ContextManager<TContext> _contextManager =
            ServiceLocator.Current.GetInstance<IContextManager<TContext>>() as ContextManager<TContext>;

        private readonly IDbContext _dbContext;

        private bool _disposed;

        public UnitOfWork()
        {
            this._dbContext = this._contextManager.GetContext();

        }

        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        public void BeginTransaction()
        {
            this._disposed = false;
        }

        public void SaveChanges()
        {
            this._dbContext.SaveChanges();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!this._disposed)
            {
                if (disposing)
                {
                    this._dbContext.Dispose();
                }
            }
            this._disposed = true;
        }
    }
}
