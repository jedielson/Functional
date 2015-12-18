using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Functional.Application.Common;
using Functional.Application.Interfaces;
using Functional.Domain.Entities.Model;
using Functional.Domain.Validation;
using Functional.Domain.Interfaces.Service;

namespace Functional.Application
{
    public class ProjetoAppService : AppServiceBase<Projeto>, IProjetoAppService
    {
        private readonly IProjetoService _projetoService;

        public ProjetoAppService(IProjetoService service)
        {
            _projetoService = service;
        }

        public IEnumerable<Projeto> All(bool @readonly = false)
        {
            return _projetoService.All(@readonly);
        }

        public ValidationResult Create(Projeto entity)
        {
            BeginTransaction();

            ValidationResult.Add(_projetoService.Create(entity));

            if (ValidationResult.IsValid)
            {
                Commit();
            }

            return ValidationResult;
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public IEnumerable<Projeto> Find(Expression<Func<Projeto, bool>> predicate, bool @readonly = false)
        {
            return _projetoService.Find(predicate, @readonly);
        }

        public Projeto Get(int id)
        {
            return _projetoService.Get(id);
        }

        public ValidationResult Remove(Projeto entity)
        {
            BeginTransaction();

            ValidationResult.Add(_projetoService.Delete(entity));

            if (ValidationResult.IsValid)
            {
                Commit();
            }

            return ValidationResult;
        }

        public ValidationResult Update(Projeto entity)
        {
            BeginTransaction();

            ValidationResult.Add(_projetoService.Update(entity));

            if (ValidationResult.IsValid)
            {
                Commit();
            }

            return ValidationResult;
        }
    }
}
