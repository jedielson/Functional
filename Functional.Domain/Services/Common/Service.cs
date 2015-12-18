using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Functional.Domain.Interfaces.Entities;
using Functional.Domain.Interfaces.Repository.Common;
using Functional.Domain.Interfaces.Service.Common;
using Functional.Domain.Validation;

namespace Functional.Domain.Services.Common
{
    public class Service<TEntity> : IService<TEntity>
        where TEntity : IEntityBase
    {
        #region Constructor

        private readonly IRepository<TEntity> _repository;
        private readonly IReadOnlyRepository<TEntity> _readOnlyRepository;
        private readonly ValidationResult _validationResult;

        public Service(
            IRepository<TEntity> repository,
            IReadOnlyRepository<TEntity> readOnlyRepository)
        {
            _repository = repository;
            _readOnlyRepository = readOnlyRepository;
            _validationResult = new ValidationResult();
        }

        #endregion

        #region Properties

        protected IRepository<TEntity> Repository
        {
            get { return _repository; }
        }

        protected IReadOnlyRepository<TEntity> ReadOnlyRepository
        {
            get { return _readOnlyRepository; }
        }

        protected ValidationResult ValidationResult
        {
            get { return _validationResult; }
        }

        #endregion

        #region Read Methods

        public virtual TEntity Get(int id, bool @readonly = false)
        {
            return @readonly
                ? _readOnlyRepository.Get(id)
                : _repository.Get(id);
        }

        public virtual IEnumerable<TEntity> All(bool @readonly = false)
        {
            return @readonly ? _readOnlyRepository.All() : _repository.All();
        }

        public virtual IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate, bool @readonly = false)
        {
            // ReSharper disable once ConditionIsAlwaysTrueOrFalse : O argumento pode ser alterado na chamada do método
            return @readonly ? _readOnlyRepository.Find(predicate) : _repository.Find(predicate);
        }

        #endregion

        #region CRUD Methods

        public virtual ValidationResult Create(TEntity entity)
        {
            if (!entity.IsValid)
                return entity.ValidationResult;

            _repository.Save(entity);
            return entity.ValidationResult;
        }

        public virtual ValidationResult Update(TEntity entity)
        {
            if (!entity.IsValid)
                return entity.ValidationResult;

            _repository.Update(entity);
            return entity.ValidationResult;
        }

        public virtual ValidationResult Delete(TEntity entity)
        {
            if (!entity.IsValid)
                return entity.ValidationResult;

            _repository.Delete(entity);
            return entity.ValidationResult;
        }

        #endregion
    }
}
