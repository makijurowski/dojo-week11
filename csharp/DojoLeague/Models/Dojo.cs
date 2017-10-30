using System;
using System.ComponentModel.DataAnnotations;

namespace DojoLeague.Models
{
    public class Dojo : BaseEntity
    {
        [Key]
        public long Id { get; set; }

        [Required]
        [MinLength(1)]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Name can only contain letters")]
        [Display(Name = "Dojo Name")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Dojo Location")]
        public string Location { get; set; }

        [Display(Name = "Optional Information")]
        public string Information { get; set; }
    }
}