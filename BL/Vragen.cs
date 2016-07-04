using NederlandsWebsiteVDS.Models;

namespace NederlandsWebsiteVDS.BL
{
    public class Vragen
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        public void AddVraag(int id, Vraag vragen)
        {
            Vraag vraag = new Vraag();
            vraag.Naam = vragen.Naam;
            vraag.OpdrachtId = id;
            vraag.AntwoordCollection = vragen.AntwoordCollection;
            db.Vraag.Add(vraag);
        }
    }
}