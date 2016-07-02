using System.Collections;
using System.Collections.Generic;

namespace NederlandsWebsiteVDS.Models
{
    public class Admin : IEnumerable
    {
        public List<ApplicationUser> GebruikerVM { get; set; }
        public List<Onderwerp> OnderwerpVM { get; set; }
        public List<Uitleg> UitlegVM { get; set; }
        public List<Opdracht> OpdrachtVM { get; set; }
        public List<Categorie> CategorieVM { get; set; }
        public List<Link> LinkVM { get; set; }
        public List<Vraag> VraagVM { get; set; }
        public List<Antwoord> AntwoordVM { get; set; }
        public IEnumerator GetEnumerator()
        {
            throw new System.NotImplementedException();
        }
    }
}