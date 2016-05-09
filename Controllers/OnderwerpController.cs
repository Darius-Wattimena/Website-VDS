using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using NederlandsWebsiteVDS.Models;

namespace NederlandsWebsiteVDS.Controllers
{
    public class OnderwerpController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Onderwerp
        public ActionResult Index()
        {
            var onderwerp = db.Onderwerp.Include(o => o.Categorie);
            return View(onderwerp.ToList());
        }

        // GET: Onderwerp/Details/5
        public ActionResult Details(int? id)
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

        // GET: Onderwerp/Create
        public ActionResult Create()
        {
            ViewBag.CategorieId = new SelectList(db.Categorie, "Id", "Naam");
            return View();
        }

        // POST: Onderwerp/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Naam,CategorieId")] Onderwerp onderwerp)
        {
            if (ModelState.IsValid)
            {
                db.Onderwerp.Add(onderwerp);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CategorieId = new SelectList(db.Categorie, "Id", "Naam", onderwerp.CategorieId);
            return View(onderwerp);
        }

        // GET: Onderwerp/Edit/5
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

        // POST: Onderwerp/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Naam,CategorieId")] Onderwerp onderwerp)
        {
            if (ModelState.IsValid)
            {
                db.Entry(onderwerp).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CategorieId = new SelectList(db.Categorie, "Id", "Naam", onderwerp.CategorieId);
            return View(onderwerp);
        }

        // GET: Onderwerp/Delete/5
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

        // POST: Onderwerp/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Onderwerp onderwerp = db.Onderwerp.Find(id);
            db.Onderwerp.Remove(onderwerp);
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
