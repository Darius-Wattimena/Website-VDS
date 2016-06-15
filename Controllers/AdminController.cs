using System.Linq;
using System.Web.Mvc;
using NederlandsWebsiteVDS.BL;
using NederlandsWebsiteVDS.Models;

namespace NederlandsWebsiteVDS.Controllers
{
    public class AdminController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        // GET: Admin
        [MyAuthorize(Roles = "Admin")]
        public ActionResult Index()
        {
            var adminVm = new Admin
            {
                UitlegVM = db.Uitleg.ToList(),
                OnderwerpVM = db.Onderwerp.ToList(),
                OpdrachtVM = db.Opdracht.ToList(),
                GebruikerVM = db.Users.ToList(),
                CategorieVM = db.Categorie.ToList(),
                LinkVM = db.Link.ToList()
            };
            return View(adminVm);
        }
    }
}