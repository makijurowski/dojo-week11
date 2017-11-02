using System;
using Microsoft.AspNetCore.Identity;
using WeddingPlanner.Models;
using System.ComponentModel.DataAnnotations;

namespace WeddingPlanner.Models.ViewModels
{
    public class LoginViewModel
    {
        [Required, EmailAddress, Display(Name = "Email")]
        public string LEmail { get; set; }

        [Required, DataType(DataType.Password), MinLength(4), MaxLength(50), Display(Name = "Password")]
        public string LPassword { get; set; }

        [Display(Name = "Remember me?")]
        public bool RememberMe { get; set; }
    }
}