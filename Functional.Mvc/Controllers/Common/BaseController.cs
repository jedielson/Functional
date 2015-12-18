using Functional.Domain.Validation;
using System.Web.Mvc;

namespace Functional.Mvc.Controllers.Common
{
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