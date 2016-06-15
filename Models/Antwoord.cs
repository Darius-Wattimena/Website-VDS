using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NederlandsWebsiteVDS.Models
{
    public class Antwoord
    {
        public int Id { get; set; }

        [Required]
        public string Context { get; set; }

        [Required] 
        public bool CorrectAntwoord { get; set; }

        [Required]
        [ForeignKey("Vraag")]
        public int VraagId { get; set; }

        public virtual Vraag Vraag { get; set; }
    }
}