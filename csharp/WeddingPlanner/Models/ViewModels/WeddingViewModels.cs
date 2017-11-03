using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WeddingPlanner.Models.ViewModels
{
    public class WeddingViewModel
    {
        [Required, Display(Name = "Name of Bride")]
        public string BrideName { get; set; }

        [Required, Display(Name = "Name of Groom")]
        public string GroomName { get; set; }

        [FutureDate, Display(Name = "Wedding Date")]
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }

        [Required, Display(Name = "Wedding Location (Full Address)")]
        public string Address { get; set; }
    }

    public class FutureDate : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            DateTime date = (DateTime)value;
            return date < DateTime.Now ? new ValidationResult("Date must be in the future") : ValidationResult.Success;
        }
    }
}