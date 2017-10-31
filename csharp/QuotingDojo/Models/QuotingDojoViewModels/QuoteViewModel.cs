using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace QuotingDojo.Models
{
    public class QuoteViewModel
    {
        [Required]
        public int author_id { get; set; }

        [Required]
        [MinLength(10)]
        public string quote { get; set; }

        // [Required]
        // public string meta { get; set; }
    }
}