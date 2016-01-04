namespace Functional.Data.Repository.Common
{
    using System;
    using System.Data.Entity;
    using System.Linq;
    using System.Linq.Expressions;

    using Functional.Data.Context;
    using Functional.Data.Context.Interfaces;
    using Functional.Domain.Interfaces.Repository.Common;

    using Microsoft.Practices.ServiceLocation;

    public abstract class RepositoryBase<TEntity> : IRepository<TEntity>, IDisposable where TEntity : class
    {

        private readonly IDbContext _dbContext;

        protected RepositoryBase()
        {
            var contextManager = ServiceLocator.Current.GetInstance<IContextManager<FunctionalContext>>()
                as ContextManager<FunctionalContext>;

            _dbContext = contextManager.GetContext();
            this.DbSet = _dbContext.Set<TEntity>();
        }

        protected IDbContext Context => this._dbContext;

        protected IDbSet<TEntity> DbSet { get; }

        public virtual void Save(TEntity entity)
        {
            DbSet.Add(entity);
        }

        public virtual void Update(TEntity entity)
        {
            var entry = Context.Entry(entity);
            DbSet.Attach(entity);
            entry.State = EntityState.Modified;
        }

        public virtual void Delete(TEntity entity)
        {
            DbSet.Remove(entity);
        }

        public virtual TEntity Get(Guid id)
        {
            return DbSet.Find(id);
        }

        public virtual IQueryable<TEntity> All(bool @readonly = false)
        {
            return @readonly ? DbSet.AsNoTracking() : DbSet;
        }

        public virtual IQueryable<TEntity> Find(Expression<Func<TEntity, bool>> predicate, bool @readonly = false)
        {
            return @readonly
                ? DbSet.Where(predicate).AsNoTracking()
                : DbSet.Where(predicate);
        }

        #region Dispose

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposing) return;

            Context?.Dispose();
        }

        #endregion
    }
}
