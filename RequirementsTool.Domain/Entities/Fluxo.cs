using Functional.Domain.Interfaces.Validation;
using Functional.Domain.Validation;
using System.Collections.Generic;

namespace Functional.Domain.Entities
{
    public abstract class Fluxo
    {
        public virtual int FluxoId { get; set; }

        public virtual int Tipo { get; set; }

        public virtual string Titulo { get; set; }

        public virtual IEnumerable<Passo> Passos { get; set; }
    }
}
