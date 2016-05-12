using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NederlandsWebsiteVDS.Models;

namespace NederlandsWebsiteVDS.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        public ActionResult Index()
        {
            Admin indexVM = new Admin();
            indexVM.UitlegVM = db.Uitleg.ToList();
            indexVM.OnderwerpVM = db.Onderwerp.ToList();
            indexVM.OpdrachtVM = db.Opdracht.ToList();
            indexVM.GebruikerVM = db.Users.ToList();
            indexVM.CategorieVM = db.Categorie.ToList();
            return View(indexVM);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}