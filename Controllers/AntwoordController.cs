using System.Web.Mvc;
using NederlandsWebsiteVDS.Models;

namespace NederlandsWebsiteVDS.Controllers
{
    public class AntwoordController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        
        public ActionResult Create()
        {
            return PartialView("~/Views/Antwoord/Create.cshtml");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Context,CorrectAntwoord,VraagId")] Antwoord antwoord)
        {
            if (ModelState.IsValid)
            {
                db.Antwoord.Add(antwoord);
                db.SaveChanges();
            }

            ViewBag.VraagId = new SelectList(db.Vraag, "Id", "Naam", antwoord.VraagId);
            return View(antwoord);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
