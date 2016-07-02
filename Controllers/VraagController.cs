using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Web.Mvc;
using Microsoft.Ajax.Utilities;
using NederlandsWebsiteVDS.Models;
using NederlandsWebsiteVDS.BL;

namespace NederlandsWebsiteVDS.Controllers
{
    public class VraagController : Controller
    {
        private int i = 0;
        private ApplicationDbContext db = new ApplicationDbContext();
        public List<Vraag> DataList = new List<Vraag>();
        private CreateList cl = new CreateList();


        public ActionResult Create(int id)
        {
            Opdracht opdracht = db.Opdracht.Find(id);
            if (opdracht == null)
            {
                return HttpNotFound();
            }

            DataList.Add(cl.CreateListVraag(1));
            DataList.Add(cl.CreateListVraag(2));
            Session["DataList"] = DataList;

            return View(Session["DataList"]);
        }

        [HttpPost]
        public ActionResult Create(int id, IEnumerable<Vraag> vragen)
        {
            var vragenlist = new List<Vraag>();
            foreach (var item in vragen)
            {
                Vraag vraag = new Vraag();
                vraag.Naam = item.Naam;
                vraag.OpdrachtId = id;
                vragenlist.Add(vraag);
                db.Vraag.Add(vraag);
            }
            db.SaveChanges();
            return RedirectToAction("Index", "Admin");
        }

        public ViewResult CreateVraag()
        {
            DataList = (List<Vraag>) Session["DataList"];
            if (DataList == null) return View("Create");
            var count = DataList.Count;
            DataList.Add(cl.CreateListVraag(count + 1));
            Session["DataList"] = DataList;
            return View("Create", Session["DataList"]);
        }

        public ViewResult CreateAntwoord(int id)
        {
            DataList = (List<Vraag>)Session["DataList"];
            foreach (var data in DataList)
            {
                if (data.Id == id)
                {
                    var count = data.AntwoordCollection.Count;
                    data.AntwoordCollection.Add(cl.CreateAntwoord(count + 1));
                }
            }
            Session["DataList"] = DataList;
            return View("Create", Session["DataList"]);
        }

        public ViewResult DeleteVraag(int id)
        {
            DataList = (List<Vraag>)Session["DataList"];
            foreach (var data in DataList)
            {
                if (data.Id != id) continue;
                DataList.Remove(data);
                Session["DataList"] = DataList;
                return View("Create", Session["DataList"]);
            }
            return View("Create", Session["DataList"]);
        }

        public ViewResult DeleteAntwoord(int id, int antwoordId)
        {
            DataList = (List<Vraag>)Session["DataList"];
            foreach (var data in DataList)
            {
                if (data.Id != id) continue;
                foreach (var antwoord in data.AntwoordCollection)
                {
                    if (antwoord.Id != antwoordId) continue;
                    data.AntwoordCollection.Remove(antwoord);
                    Session["DataList"] = DataList;
                    return View("Create", Session["DataList"]);
                }
            }
            return View("Create", Session["DataList"]);
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
