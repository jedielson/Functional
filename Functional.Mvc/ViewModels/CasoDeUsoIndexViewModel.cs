namespace Functional.Mvc.ViewModels
{
    using System;
    using System.Collections.Generic;

    public class CasoDeUsoIndexViewModel
    {
        public Guid ProjetoId { get; set; }

        public IEnumerable<ProjetoViewModel> Projetos { get; set; }

        public IEnumerable<CasoDeUsoViewModel> CasosDeUso { get; set; }

    }
}