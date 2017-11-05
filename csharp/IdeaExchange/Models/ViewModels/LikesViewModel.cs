using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace IdeaExchange.Models.ViewModels
{
    public class LikesViewModel
    {
        [HiddenInput(DisplayValue = false)]
        public int PostId { get; set; }
    }
}