using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace IdeaExchange.Models.ViewModels
{
    public class PostViewModel
    {
        [Required, Display(Name = "Post something witty here...")]
        public string PostContent { get; set; }
    }
}