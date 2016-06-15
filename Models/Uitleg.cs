using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Mvc;

namespace NederlandsWebsiteVDS.Models
{
    public class Uitleg
    {
        public int Id { get; set; }

        [Required]
        public string Naam { get; set; }

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