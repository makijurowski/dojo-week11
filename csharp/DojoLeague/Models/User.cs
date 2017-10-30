using System;
using System.ComponentModel.DataAnnotations;

namespace DojoLeague.Models
{
    public abstract class BaseEntity {}

    public class User : BaseEntity
    {
        [Key]
        public long Id { get; set; }

        [Required]
        [MinLength(2)]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Name can only contain letters")]
        [Display(Name="First Name")]
        public string First_Name { get; set; }

        [Required]
        [MinLength(2)]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Name can only contain letters")]
        [Display(Name="Last Name")]
        public string Last_Name { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        [EmailAddress(ErrorMessage="Invalid email.")]
        [Display(Name="Email")]
        public string Email { get; set; }

        [Required]
        [MinLength(6)]
        [DataType(DataType.Password)]
        [Display(Name="Password")]
        public string Password { get; set; }
    }
}