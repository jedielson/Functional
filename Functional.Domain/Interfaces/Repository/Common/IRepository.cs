using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Functional.Domain.Interfaces.Entities;

namespace Functional.Domain.Interfaces.Repository.Common
{
    using System.Linq;

    public interface IRepository<TEntity>
      where TEntity : class
    {
        void Save(TEntity entity);

        void Update(TEntity entity);

        void Delete(TEntity entity);

        TEntity Get(int id);

        IQueryable<TEntity> All(bool @readonly = false);

        IQueryable<TEntity> Find(Expression<Func<TEntity, bool>> predicate, bool @readonly = false);
    }
}
