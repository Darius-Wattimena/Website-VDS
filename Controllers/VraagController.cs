using System.Net;
using System.Web.Mvc;
using NederlandsWebsiteVDS.Models;

namespace NederlandsWebsiteVDS.Controllers
{
    public class VraagController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public ActionResult Create(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Opdracht opdracht = db.Opdracht.Find(id);
            if (opdracht == null)
            {
                return HttpNotFound();
            }
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Context,CorrectAntwoord,OpdrachtId")] Vraag vraag)
        {
            if (ModelState.IsValid)
            {
                db.Vraag.Add(vraag);
                db.SaveChanges();
                return RedirectToAction("Index", "Admin");
            }

            return View(vraag);
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
