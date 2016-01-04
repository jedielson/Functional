namespace Functional.Mvc.ViewModels
{
    using System;
    using System.Collections.Generic;

    public class FluxoPrincipalViewModel
    {
        public Guid FluxoId { get; set; }

        public string Titulo { get; set; }

        public IEnumerable<PassoViewModel> Passos { get; set; }
    }
}