using System.Collections.Generic;

namespace Functional.Domain.Entities.Model
{
    using System;

    public abstract class Fluxo
    {
        public Guid FluxoId { get; set; }

        public string Titulo { get; set; }

        public virtual ICollection<Passo> Passos { get; set; }
    }
}
