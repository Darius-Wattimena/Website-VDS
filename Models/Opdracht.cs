using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NederlandsWebsiteVDS.Models
{
    public class Opdracht
    {
        public int Id { get; set; }

        [Required]
        public string Context { get; set; }

        

        [Required]
        [ForeignKey("Onderwerp")]
        public int OnderwerpId { get; set; }

        [Required]
        [ForeignKey("AspNetUsers")]
        public char UserId { get; set; }

        public virtual ApplicationUser User { get; set; }
        public virtual Onderwerp Onderwerp { get; set; }
    }
}