using System.ComponentModel.DataAnnotations;

namespace WeddingPlanner.Models
{
    public class AuthorViewModel : BaseEntity
    {
        [Required]
        [MinLength(6)]
        public string name { get; set; }
    }
}