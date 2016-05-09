using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NederlandsWebsiteVDS.Models
{
    public class Onderwerp
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 1)]
        public string Naam { get; set; }

        [Required]
        [ForeignKey("Categorie")]
        public int CategorieId { get; set; }

        public virtual Categorie Categorie { get; set; }
        public virtual ICollection<Uitleg> UitlegCollection { get; set; }
        public virtual ICollection<Opdracht> OpdrachtCollection { get; set; }
    }
}