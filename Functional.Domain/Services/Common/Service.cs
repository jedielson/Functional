namespace Functional.Domain.Services.Common
{
    using System;
    using System.Linq;
    using System.Linq.Expressions;

    using Functional.Domain.Interfaces.Repository.Common;
    using Functional.Domain.Interfaces.Service.Common;
    using Functional.Domain.Interfaces.Validation;
    using Functional.Domain.Validation;

    public class Service<TEntity> : IService<TEntity> where TEntity : class, ISelfValidation
    {
        #region Constructor

        private readonly IRepository<TEntity> _repository;

        public Service(IRepository<TEntity> repository)
        {
            _repository = repository;
            this.ValidationResult = new ValidationResult();
        }

        #endregion

        #region Properties

        protected IRepository<TEntity> Repository => this._repository;

        protected ValidationResult ValidationResult { get; }

        #endregion

        #region Read Methods

        public virtual TEntity Get(Guid id, bool @readonly = false)
        {
            return _repository.Get(id);
        }

        public virtual IQueryable<TEntity> All(bool @readonly = false)
        {
            return _repository.All(@readonly);
        }

        public virtual IQueryable<TEntity> Find(Expression<Func<TEntity, bool>> predicate, bool @readonly = false)
        {
            return _repository.Find(predicate, @readonly);
        }

        #endregion

        #region CRUD Methods

        public virtual ValidationResult Create(TEntity entity)
        {
            if (entity == null)
            {
                throw new ArgumentException("Não é possível persistir uma entidade nula.");
            }

            if (!entity.IsValid)
            {
                return entity.ValidationResult;
            }

            _repository.Save(entity);
            return entity.ValidationResult;
        }

        public virtual ValidationResult Update(TEntity entity)
        {
            if (entity == null)
            {
                throw new ArgumentException("Não é possível persistir uma entidade nula.");
            }

            if (!entity.IsValid)
            {
                return entity.ValidationResult;
            }

            _repository.Update(entity);
            return entity.ValidationResult;
        }

        public virtual ValidationResult Delete(TEntity entity)
        {
            if (entity == null)
            {
                throw new ArgumentException("Não é possível remover uma entidade nula.");
            }

            if (!entity.IsValid)
                return entity.ValidationResult;

            _repository.Delete(entity);
            return entity.ValidationResult;
        }

        #endregion
    }
}
