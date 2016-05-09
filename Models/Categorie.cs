using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace NederlandsWebsiteVDS.Models
{
    public class Categorie
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 1)]
        public string Naam { get; set; }

        public virtual ICollection<Onderwerp> OnderwerpCollection { get; set; }
    }
}