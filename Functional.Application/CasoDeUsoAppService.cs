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

    public class CasoDeUsoAppService : AppServiceBase<FunctionalContext>, ICasoDeUsoAppService
    {

        private readonly ICasoDeUsoService _casoDeUsoService;

        public CasoDeUsoAppService(ICasoDeUsoService casoDeUsoService)
        {
            this._casoDeUsoService = casoDeUsoService;
        }

        public ValidationResult Create(CasoDeUso entity)
        {
            throw new NotImplementedException();
        }

        public ValidationResult Update(CasoDeUso entity)
        {
            throw new NotImplementedException();
        }

        public ValidationResult Remove(CasoDeUso entity)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public CasoDeUso Get(Guid id, bool @readonly = false)
        {
            throw new NotImplementedException();
        }

        public IQueryable<CasoDeUso> All(bool @readonly = false)
        {
            throw new NotImplementedException();
        }

        public IQueryable<CasoDeUso> Find(Expression<Func<CasoDeUso, bool>> predicate, bool @readonly = false)
        {
            throw new NotImplementedException();
        }
    }
}
