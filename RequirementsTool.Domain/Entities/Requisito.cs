using Functional.Domain.Interfaces.Validation;
using Functional.Domain.Validation;
using System;
using System.Collections.Generic;

namespace Functional.Domain.Entities
{
    public class Requisito : ISelfValidation
    {
        public virtual int RequisitoId { get; set; }

        public virtual string Codigo { get; set; }

        public virtual string Titulo { get; set; }

        public virtual string Descricao { get; set; }

        public virtual DateTime DataDeCriacao { get; set; }

        public virtual DateTime DataUltimaAlteracao { get; set; }

        public virtual Projeto Projeto { get; set; }

        public virtual IEnumerable<CasoDeUso> CasosDeUso { get; set; }

        public virtual ValidationResult ValidationResult
        {
            get { throw new NotImplementedException(); }
        }

        public virtual bool IsValid
        {
            get { throw new NotImplementedException(); }
        }
    }
}
