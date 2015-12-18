using System.Collections.Generic;
using Functional.Domain.Interfaces.Entities;
using Functional.Domain.Validation;

namespace Functional.Domain.Entities.Model
{
    using System;

    public class CasoDeUso : IEntityBase
    {
        public Guid CasoDeUsoId { get; set; }

        public string Codigo { get; set; }

        public string Titulo { get; set; }

        public ICollection<Requisito> Requisitos { get; set; }

        public FluxoPrincipal FluxoPrincipal { get; set; }

        // public ICollection<FluxoAlternativo> FluxosAlternativos { get; set; }

        ////public ICollection<FluxoDeExcessao> FluxosExcecao { get; set; }

        public ValidationResult ValidationResult
        {
            get { throw new System.NotImplementedException(); }
        }

        public bool IsValid
        {
            get { throw new System.NotImplementedException(); }
        }
    }
}
