using System.Collections.Generic;

namespace NederlandsWebsiteVDS.Models
{
    public class VragenViewModel
    {
        public List<Vraag> VraagCollection { get; set; }
        public List<Antwoord> AntwoordCollection { get; set; }
    }
}