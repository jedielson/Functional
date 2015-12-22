namespace Functional.Mvc.Controllers
{
    using System.Web.Mvc;

    using Functional.Mvc.ViewModels;

    public class MessagesController : Controller
    {
        [HttpGet]
        public ActionResult Confirmation(ConfirmationMessageViewModel model)
        {
            return PartialView(model);
        }
    }
}