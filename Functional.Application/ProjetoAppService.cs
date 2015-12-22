namespace Functional.Application
{
    using System;
    using System.Linq;
    using System.Linq.Expressions;

    using Functional.Application.Common;
    using Functional.Application.Interfaces;
    using Functional.Data.Context;
    using Functional.Domain.Entities.Model;
    using Functional.Domain.Interfaces.Service;
    using Functional.Domain.Validation;

    /// <summary>
    /// Fornece as operações básicas de leitura e escrita para um <see cref="Projeto"/>
    /// </summary>
    /// <seealso cref="Functional.Application.Common.AppServiceBase{FunctionalContext}" />
    /// <seealso cref="Functional.Application.Interfaces.IProjetoAppService" />
    public class ProjetoAppService : AppServiceBase<FunctionalContext>, IProjetoAppService
    {
        private readonly IProjetoService _projetoService;

        /// <summary>
        /// Initializes a new instance of the <see cref="ProjetoAppService"/> class.
        /// </summary>
        /// <param name="projetoService">The projeto service.</param>
        public ProjetoAppService(IProjetoService projetoService)
        {
            this._projetoService = projetoService;
        }

        public ValidationResult Create(Projeto entity)
        {
            try
            {
                this.BeginTransaction();
                this.ValidationResult = this._projetoService.Create(entity);
                if (!this.ValidationResult.IsValid)
                {
                    return this.ValidationResult;
                }

                this.Commit();
                return this.ValidationResult;
            }
            catch (Exception ex)
            {
                this.ValidationResult.Add(new ValidationError(ex.Message));
                return this.ValidationResult;
            }
        }

        public ValidationResult Update(Projeto entity)
        {
            try
            {
                this.BeginTransaction();
                this.ValidationResult = this._projetoService.Update(entity);
                if (!this.ValidationResult.IsValid)
                {
                    return this.ValidationResult;
                }

                this.Commit();
                return this.ValidationResult;
            }
            catch (Exception ex)
            {
                this.ValidationResult.Add(new ValidationError(ex.Message));
                return this.ValidationResult;
            }
        }

        public ValidationResult Remove(Projeto entity)
        {
            try
            {
                this.BeginTransaction();
                this.ValidationResult = this._projetoService.Delete(entity);
                if (!this.ValidationResult.IsValid)
                {
                    return this.ValidationResult;
                }

                this.Commit();
                return this.ValidationResult;
            }
            catch (Exception ex)
            {
                this.ValidationResult.Add(new ValidationError(ex.Message));
                return this.ValidationResult;
            }
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public Projeto Get(Guid id, bool @readonly = false)
        {
            return this._projetoService.Get(id, @readonly);
        }

        public IQueryable<Projeto> All(bool @readonly = false)
        {
            return this._projetoService.All(@readonly);
        }

        public IQueryable<Projeto> Find(Expression<Func<Projeto, bool>> predicate, bool @readonly = false)
        {
            return this._projetoService.Find(predicate, @readonly);
        }
    }
}
