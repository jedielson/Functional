namespace Functional.Mvc.ViewModels
{
    using System;
    using System.Collections.Generic;

    public class RequisitosIndexViewModel
    {
        public IEnumerable<ProjetoViewModel> Projetos { get; set; }

        public Guid ProjetoId { get; set; }

        public IEnumerable<RequisitoViewModel> Requisitos { get; set; }
    }
}