using System.ComponentModel.DataAnnotations;

namespace NederlandsWebsiteVDS.Models
{
    public class Link
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 1)]
        public string Naam { get; set; }
        public string Url { get; set; }
    }
}