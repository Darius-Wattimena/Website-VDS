using System.Linq;
using System.Web.Mvc;
using NederlandsWebsiteVDS.Models;

namespace NederlandsWebsiteVDS.Controllers
{
    public class MenuController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        [ChildActionOnly]
        public PartialViewResult _Navbar()
        {
            var model = new Admin
            {
                OnderwerpVM = db.Onderwerp.ToList(),
                CategorieVM = db.Categorie.ToList()
            };
            return PartialView("~/Views/Shared/_Navbar.cshtml", model);
        }

        public PartialViewResult _Footer()
        {
            return PartialView("~/Views/Shared/_Footer.cshtml");
        }

        public PartialViewResult _Header()
        {
            return PartialView("~/Views/Shared/_Header.cshtml");
        }
    }
}