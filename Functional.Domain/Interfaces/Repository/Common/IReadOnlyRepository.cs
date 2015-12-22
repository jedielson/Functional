namespace Functional.Domain.Interfaces.Repository.Common
{
    using System;
    using System.Linq;
    using System.Linq.Expressions;

    public interface IReadOnlyRepository<TEntity>
        where TEntity : class
    {
        TEntity Get(Guid id);
        IQueryable<TEntity> All();
        IQueryable<TEntity> Find(Expression<Func<TEntity, bool>> predicate);
    }
}
