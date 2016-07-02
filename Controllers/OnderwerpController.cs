using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using NederlandsWebsiteVDS.BL;
using NederlandsWebsiteVDS.Models;

namespace NederlandsWebsiteVDS.Controllers
{
    public class OnderwerpController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        [RoleCheck(Roles = "Admin")]
        public ActionResult Create()
        {
            ViewBag.CategorieId = new SelectList(db.Categorie, "Id", "Naam");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Naam,CategorieId")] Onderwerp onderwerp)
        {
            if (ModelState.IsValid)
            {
                db.Onderwerp.Add(onderwerp);
                db.SaveChanges();
                return RedirectToAction("Index", "Admin");
            }

            ViewBag.CategorieId = new SelectList(db.Categorie, "Id", "Naam", onderwerp.CategorieId);
            return View(onderwerp);
        }

        [RoleCheck(Roles = "Admin")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Onderwerp onderwerp = db.Onderwerp.Find(id);
            if (onderwerp == null)
            {
                return HttpNotFound();
            }
            ViewBag.CategorieId = new SelectList(db.Categorie, "Id", "Naam", onderwerp.CategorieId);
            return View(onderwerp);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Naam,CategorieId")] Onderwerp onderwerp)
        {
            if (ModelState.IsValid)
            {
                db.Entry(onderwerp).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index", "Admin");
            }
            ViewBag.CategorieId = new SelectList(db.Categorie, "Id", "Naam", onderwerp.CategorieId);
            return View(onderwerp);
        }

        [RoleCheck(Roles = "Admin")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Onderwerp onderwerp = db.Onderwerp.Find(id);
            if (onderwerp == null)
            {
                return HttpNotFound();
            }
            return View(onderwerp);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Onderwerp onderwerp = db.Onderwerp.Find(id);
            db.Onderwerp.Remove(onderwerp);
            db.SaveChanges();
            return RedirectToAction("Index", "Admin");
        }

        public new ActionResult View(string categorie, string onderwerp)
        {
            if (categorie == "" || onderwerp == "")
                return HttpNotFound();
            var opdrachten = from m in db.Opdracht select m;
            var uitleg = from m in db.Uitleg select m;
            opdrachten = opdrachten.Where(s => s.Onderwerp.Naam.Contains(onderwerp));
            uitleg = uitleg.Where(u => u.Onderwerp.Naam.Contains(onderwerp));

            var onderwerpVm = new Admin
            {
                UitlegVM = new List<Uitleg>(uitleg),
                OpdrachtVM = new List<Opdracht>(opdrachten)
            };
            return View(onderwerpVm);
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
