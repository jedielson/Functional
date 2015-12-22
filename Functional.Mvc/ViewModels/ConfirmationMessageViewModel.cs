namespace Functional.Mvc.ViewModels
{
    using System;

    public class ConfirmationMessageViewModel
    {
        public Guid ModelId { get; set; }

        public string Message { get; set; }

        public string ActionDelete { get; set; }

        public string ControllerDelete { get; set; }
    }
}