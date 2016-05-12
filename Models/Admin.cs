using System.Collections.Generic;

namespace NederlandsWebsiteVDS.Models
{
    public class Admin
    {
        public List<ApplicationUser> GebruikerVM { get; set; }
        public List<Onderwerp> OnderwerpVM { get; set; }
        public List<Uitleg> UitlegVM { get; set; }
        public List<Opdracht> OpdrachtVM { get; set; }
        public List<Categorie> CategorieVM { get; set; } 
    }
}