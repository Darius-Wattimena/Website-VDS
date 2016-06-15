using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NederlandsWebsiteVDS.Models
{
    public class Vraag
    {
        public int Id { get; set; }

        [Required]
        public string Naam { get; set; }

        [Required]
        [ForeignKey("Opdracht")]
        public int OpdrachtId  { get; set; }

        public virtual Opdracht Opdracht { get; set; }
        public virtual ICollection<Antwoord> AntwoordCollection { get; set; }
    }
}