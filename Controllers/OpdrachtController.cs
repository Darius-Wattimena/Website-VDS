using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using NederlandsWebsiteVDS.Models;

namespace NederlandsWebsiteVDS.Controllers
{
    public class OpdrachtController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Opdracht
        public ActionResult Index()
        {
            var opdracht = db.Opdracht.Include(o => o.Onderwerp);
            return View(opdracht.ToList());
        }

        // GET: Opdracht/Details/5
        public ActionResult Details(int? id)
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

        // GET: Opdracht/Create
        public ActionResult Create()
        {
            ViewBag.Onderwerp = new SelectList(db.Onderwerp, "Id", "Naam");
            return View();
        }

        // POST: Opdracht/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Context,OnderwerpId")] Opdracht opdracht)
        {
            if (ModelState.IsValid)
            {
                var currentUserId = User.Identity.GetUserId();
                ApplicationUser currentUser = db.Users.FirstOrDefault(x => x.Id == currentUserId);
                var newOpdracht = new Opdracht();
                newOpdracht.Context = opdracht.Context;
                newOpdracht.OnderwerpId = opdracht.OnderwerpId;
                newOpdracht.User = currentUser;
                db.Opdracht.Add(newOpdracht);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.OnderwerpId = new SelectList(db.Onderwerp, "Id", "Naam", opdracht.OnderwerpId);
            return View(opdracht);
        }

        // GET: Opdracht/Edit/5
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

        // POST: Opdracht/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Context,OnderwerpId")] Opdracht opdracht)
        {
            if (ModelState.IsValid)
            {
                db.Entry(opdracht).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.OnderwerpId = new SelectList(db.Onderwerp, "Id", "Naam", opdracht.OnderwerpId);
            return View(opdracht);
        }

        // GET: Opdracht/Delete/5
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

        // POST: Opdracht/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Opdracht opdracht = db.Opdracht.Find(id);
            db.Opdracht.Remove(opdracht);
            db.SaveChanges();
            return RedirectToAction("Index");
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
