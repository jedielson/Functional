using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Functional.Domain.Validation;
using Functional.Domain.Interfaces.Validation;

namespace Functional.Domain.Interfaces.Service.Common
{
    public interface IService<TEntity>
        where TEntity : ISelfValidation
    {
        TEntity Get(int id, bool @readonly = false);
        IEnumerable<TEntity> All(bool @readonly = false);
        IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate, bool @readonly = false);
        ValidationResult Create(TEntity entity);
        ValidationResult Update(TEntity entity);
        ValidationResult Delete(TEntity entity);
    }
}
