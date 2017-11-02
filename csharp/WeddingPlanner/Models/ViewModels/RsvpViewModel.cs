using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace WeddingPlanner.Models.ViewModels
{
    public class RsvpViewModel
    {
        [HiddenInput(DisplayValue = false)]
        public int WeddingId { get; set; }
    }
}