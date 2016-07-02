using System.Data.Entity;
using System.Net;
using System.Web.Mvc;
using NederlandsWebsiteVDS.BL;
using NederlandsWebsiteVDS.Models;

namespace NederlandsWebsiteVDS.Controllers
{
    public class UitlegController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        [RoleCheck(Roles = "Admin")]
        public ActionResult Create()
        {
            ViewBag.OnderwerpId = new SelectList(db.Onderwerp, "Id", "Naam");
            return View();
        }

        [ValidateInput(false)]
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Create([Bind(Include = "Id,Naam,Context,OnderwerpId")] Uitleg uitleg)
        {
            if (ModelState.IsValid)
            {
                db.Uitleg.Add(uitleg);
                db.SaveChanges();
                return RedirectToAction("Index", "Admin");
            }

            ViewBag.OnderwerpId = new SelectList(db.Onderwerp, "Id", "Naam", uitleg.OnderwerpId);
            return View(uitleg);
        }

        [RoleCheck(Roles = "Admin")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Uitleg uitleg = db.Uitleg.Find(id);
            if (uitleg == null)
            {
                return HttpNotFound();
            }
            ViewBag.OnderwerpId = new SelectList(db.Onderwerp, "Id", "Naam", uitleg.OnderwerpId);
            return View(uitleg);
        }

        [ValidateInput(false)]
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Edit([Bind(Include = "Id,Naam,Context,OnderwerpId")] Uitleg uitleg)
        {
            if (ModelState.IsValid)
            {
                db.Entry(uitleg).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index", "Admin");
            }
            ViewBag.OnderwerpId = new SelectList(db.Onderwerp, "Id", "Naam", uitleg.OnderwerpId);
            return View(uitleg);
        }

        [RoleCheck(Roles = "Admin")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Uitleg uitleg = db.Uitleg.Find(id);
            if (uitleg == null)
            {
                return HttpNotFound();
            }
            return View(uitleg);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Uitleg uitleg = db.Uitleg.Find(id);
            db.Uitleg.Remove(uitleg);
            db.SaveChanges();
            return RedirectToAction("Index", "Admin");
        }

        public ActionResult View(int? uitleg)
        {
            if (uitleg == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var selectedUitleg = db.Uitleg.Find(uitleg);

            if (selectedUitleg == null)
            {
                return HttpNotFound();
            }

            return View(selectedUitleg);
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
