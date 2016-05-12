using System.Linq;
using System.Web.Mvc;
using NederlandsWebsiteVDS.Models;

namespace NederlandsWebsiteVDS.Controllers
{
    public class AdminController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        // GET: Admin
        public ActionResult Index()
        {
            Admin adminVM = new Admin();
            adminVM.UitlegVM = db.Uitleg.ToList();
            adminVM.OnderwerpVM = db.Onderwerp.ToList();
            adminVM.OpdrachtVM = db.Opdracht.ToList();
            adminVM.GebruikerVM = db.Users.ToList();
            adminVM.CategorieVM = db.Categorie.ToList();
            return View(adminVM);
        }
    }
}