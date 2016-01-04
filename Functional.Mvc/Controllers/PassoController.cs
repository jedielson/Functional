namespace Functional.Mvc.Controllers
{
    using System.Web.Mvc;

    public class PassoController : Controller
    {
        public ActionResult Create()
        {
            return this.View();
        }
    }
}