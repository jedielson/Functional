using Functional.Domain.Interfaces.Validation;
using Functional.Domain.Validation;
using System;
using System.Collections.Generic;

namespace Functional.Domain.Entities
{
    public class Projeto : ISelfValidation
    {
        public virtual int ProjetoId { get; set; }

        public virtual string Codigo { get; set; }

        public virtual string Nome { get; set; }

        public virtual DateTime DataDeCriacao { get; set; }

        public virtual DateTime DataUltimaAlteracao { get; set; }

        public virtual IEnumerable<Requisito> Requisitos { get; set; }

        public virtual ValidationResult ValidationResult
        {
            get { throw new System.NotImplementedException(); }
        }

        public virtual bool IsValid
        {
            get { throw new System.NotImplementedException(); }
        }
    }
}
