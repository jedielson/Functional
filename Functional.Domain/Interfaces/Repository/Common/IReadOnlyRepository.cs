using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Functional.Domain.Interfaces.Entities;

namespace Functional.Domain.Interfaces.Repository.Common
{
    public interface IReadOnlyRepository<TEntity>
        where TEntity : IEntityBase
    {
        TEntity Get(int id);
        IEnumerable<TEntity> All();
        IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate);
    }
}
