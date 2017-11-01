using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace QuotingDojo.Models
{
    public class QuoteViewModel : BaseEntity
    {
        [Required]
        public int author_id { get; set; }

        [Required]
        [MinLength(10)]
        public string quote_text { get; set; }

        [Required]
        [MinLength(10)]
        public string note_text { get; set; }

        [Required]
        public int category_id { get; set; }

    }
}