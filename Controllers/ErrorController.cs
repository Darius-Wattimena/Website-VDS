using System.Web.Mvc;

namespace NederlandsWebsiteVDS.Controllers
{
    public class ErrorController : Controller
    {
        public ActionResult Unauthorized()
        {
            return View();
        }
    }
}