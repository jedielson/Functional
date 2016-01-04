namespace Functional.Mvc.Controllers.Common
{
    using System.Web.Mvc;

    using Functional.Domain.Validation;

    public class BaseController : Controller
    {
        protected void AddModelErrors(string error)
        {
            ModelState.AddModelError("", error);
        }

        protected void AddModelErrors(ValidationResult validationResult)
        {
            foreach(var item in validationResult.Errors)
            {
                AddModelErrors(item.Message);
            }
        }
    }
}