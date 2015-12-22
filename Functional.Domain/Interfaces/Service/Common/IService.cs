using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Functional.Domain.Validation;
using Functional.Domain.Interfaces.Validation;

namespace Functional.Domain.Interfaces.Service.Common
{
    using System.Linq;

    public interface IService<TEntity> where TEntity : class, ISelfValidation
    {
        TEntity Get(Guid id, bool @readonly = false);

        IQueryable<TEntity> All(bool @readonly = false);

        IQueryable<TEntity> Find(Expression<Func<TEntity, bool>> predicate, bool @readonly = false);

        ValidationResult Create(TEntity entity);

        ValidationResult Update(TEntity entity);

        ValidationResult Delete(TEntity entity);
    }
}
