namespace Functional.Mvc.ViewModels
{
    using System;
    using System.Collections.Generic;

    using Functional.Mvc.ViewModels.Enumerations;

    public class SelectProjetoViewModel
    {
        public IEnumerable<ProjetoViewModel> Projetos { get; set; }

        public Guid ProjetoId { get; set; }

        public ViewModelEnumerations.TelaDropDownSelectProjeto? Tela { get; set; }
    }
}