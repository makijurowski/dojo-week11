using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace QuotingDojo.Models
{
    public class Note : BaseEntity
    {
        [Key]
        public int note_id { get; set; }
        public string note_text { get; set; }

        public Quote quote { get; set; }

        public Note()
        {
            // quote_categories = new List<QuoteCategory>();
        }
    }
}