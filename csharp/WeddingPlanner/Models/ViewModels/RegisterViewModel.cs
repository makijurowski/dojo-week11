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

        [Required, EmailAddress, MaxLength(256), Display(Name = "Email")]
        public string REmail { get; set; }

        [Required, Compare("ConfirmPassword", ErrorMessage = "Password must match!"), DataType(DataType.Password), MinLength(4), MaxLength(50), Display(Name = "Password")]
        public string RPassword { get; set; }

        [Required, DataType(DataType.Password), MinLength(4), MaxLength(50), Display(Name = "Confirm Password")]
        public string ConfirmPassword { get; set; }

        [Required, DataType(DataType.Date)]
        public DateTime Birthdate { get; set; }
    }
}