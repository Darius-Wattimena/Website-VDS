using System.Linq;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using NederlandsWebsiteVDS.Models;

namespace NederlandsWebsiteVDS.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        public ActionResult Index()
        {
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(new ApplicationDbContext()));
            if (!roleManager.RoleExists("Admin"))
            {
                var role = new IdentityRole("Admin");
                roleManager.Create(role);
            }
            if (!roleManager.RoleExists("User"))
            {
                var role = new IdentityRole("User");
                roleManager.Create(role);
            }

            Admin indexVM = new Admin();
            indexVM.UitlegVM = db.Uitleg.ToList();
            indexVM.OnderwerpVM = db.Onderwerp.ToList();
            indexVM.OpdrachtVM = db.Opdracht.ToList();
            indexVM.GebruikerVM = db.Users.ToList();
            indexVM.CategorieVM = db.Categorie.ToList();
            indexVM.LinkVM = db.Link.ToList();
            return View(indexVM);
        }
    }
}