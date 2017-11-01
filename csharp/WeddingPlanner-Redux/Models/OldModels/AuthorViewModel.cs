using System.ComponentModel.DataAnnotations;

namespace WeddingPlanner.Models.Old
{
    public class AuthorViewModel : BaseEntity
    {
        [Required]
        [MinLength(6)]
        public string name { get; set; }
    }
}