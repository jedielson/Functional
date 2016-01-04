namespace Functional.Mvc.ViewModels
{
    using System;

    public class PassoViewModel
    {
        public Guid PassoId { get; set; }

        public int Sequencia { get; set; }

        public string Descricao { get; set; }

        public Guid FluxoId { get; set; }
    }
}