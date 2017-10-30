using System;
using System.ComponentModel.DataAnnotations;

namespace DojoLeague.Models
{
    public class Ninja : BaseEntity
    {
        [Key]
        public long Id { get; set; }

        [Required]
        [MinLength(1)]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Name can only contain letters")]
        [Display(Name="Ninja Name")]
        public string Name { get; set; }

        [Required]
        [Display(Name="Ninja Level")]
        public int Level { get; set; }

        [Required]
        [Display(Name="Assigned Dojo")]
        public string Location { get; set; }

        [Display(Name="Optional Description")]
        public string Description { get; set; }
    }
}