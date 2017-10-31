using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace QuotingDojo.Models
{
    public class AuthorViewModel
    {
        [Required]
        public string name { get; set; }
    }
}