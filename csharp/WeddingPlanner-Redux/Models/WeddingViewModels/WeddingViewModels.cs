using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WeddingPlanner.Models.ViewModels
{
    public class Dashboard
    {
        public List<Weddings> Weddings { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
    }

    public class ViewWedding
    {
        [Required]
        public string BrideName { get; set; }

        [Required]
        public string GroomName { get; set; }

        [FutureDate]
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }

        [Required]
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