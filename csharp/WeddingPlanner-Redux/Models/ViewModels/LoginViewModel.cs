using System;
using Microsoft.AspNetCore.Identity;
using WeddingPlanner.Models;
using System.ComponentModel.DataAnnotations;

namespace WeddingPlanner.Models.ViewModels
{
    public class LoginViewModel
    {
        [Required, DataType(DataType.Password), MinLength(4), MaxLength(50)]
        public string Password { get; set; }

        [Required, EmailAddress]
        public string Email { get; set; }

        [Display(Name = "Remember me?")]
        public bool RememberMe { get; set; }
    }
}