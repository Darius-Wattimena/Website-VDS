using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace NederlandsWebsiteVDS.Models
{
    public class Onderwerp
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 1)]
        public string Naam { get; set; }


        public virtual ICollection<Uitleg> UitlegCollection { get; set; }
        public virtual ICollection<Opdracht> OpdrachtCollection { get; set; }
    }
}