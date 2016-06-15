using System.Data.Entity;
using System.Net;
using System.Web.Mvc;
using NederlandsWebsiteVDS.BL;
using NederlandsWebsiteVDS.Models;

namespace NederlandsWebsiteVDS.Controllers
{
    public class OpdrachtController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        [MyAuthorize(Roles = "Admin")]
        public ActionResult Create()
        {
            ViewBag.OnderwerpId = new SelectList(db.Onderwerp, "Id", "Naam");
            return View();
        }

        [ValidateInput(false)]
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Create([Bind(Include = "Id,Naam,Context,OnderwerpId")] Opdracht opdracht)
        {
            if (ModelState.IsValid)
            {
                db.Opdracht.Add(opdracht);
                db.SaveChanges();
                return RedirectToAction("Create", "Vraag", new { id = opdracht.Id});
            }

            ViewBag.OnderwerpId = new SelectList(db.Onderwerp, "Id", "Naam", opdracht.OnderwerpId);
            return View(opdracht);
        }

        [MyAuthorize(Roles = "Admin")]
        public ActionResult Edit(int? id)
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

            ViewBag.OnderwerpId = new SelectList(db.Onderwerp, "Id", "Naam", opdracht.OnderwerpId);
            return View(opdracht);
        }

        [ValidateInput(false)]
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Edit([Bind(Include = "Id,Naam,Context,OnderwerpId")] Opdracht opdracht)
        {
            if (ModelState.IsValid)
            {
                db.Entry(opdracht).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index", "Admin");
            }
            ViewBag.OnderwerpId = new SelectList(db.Onderwerp, "Id", "Naam", opdracht.OnderwerpId);
            return View(opdracht);
        }

        [MyAuthorize(Roles = "Admin")]
        public ActionResult Delete(int? id)
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
            return View(opdracht);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Opdracht opdracht = db.Opdracht.Find(id);
            db.Opdracht.Remove(opdracht);
            db.SaveChanges();
            return RedirectToAction("Index", "Admin");
        }

        public ActionResult View(int? opdracht)
        {
            if (opdracht == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var selectedOpdracht = db.Opdracht.Find(opdracht);

            if (selectedOpdracht == null)
            {
                return HttpNotFound();
            }

            return View(selectedOpdracht);
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
