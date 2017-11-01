using System.ComponentModel.DataAnnotations;

namespace WeddingPlanner.Models
{
    public class QuoteViewModel : BaseEntity
    {
        [Required]
        [MinLength(10)]
        public string quote { get; set; }

        [Required]
        public int authorid { get; set; }

        [Required]
        public string meta { get; set; }
        
        [Required]
        public int categoryid { get; set; }
    }
}