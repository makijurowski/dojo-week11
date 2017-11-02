using System;
using System.ComponentModel.DataAnnotations;

namespace WeddingPlanner.Models.ViewModels
{
    public class RegisterViewModel
    {
        [Required, Display(Name = "First Name")]
        public string Fname { get; set; }

        [Required, Display(Name = "Last Name")]
        public string Lname { get; set; }

        [Required, EmailAddress, MaxLength(256)]
        public string Email { get; set; }

        [Required, Compare("ConfirmPassword", ErrorMessage = "Password must match!"), DataType(DataType.Password), MinLength(4), MaxLength(50)]
        public string Password { get; set; }

        [Required, DataType(DataType.Password), MinLength(4), MaxLength(50), Display(Name = "Confirm Password")]
        public string ConfirmPassword { get; set; }

        [Required, DataType(DataType.Date)]
        public DateTime Birthdate { get; set; }
    }
}