using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace QuotingDojo.Models
{
    public class Quote : BaseEntity
    {
        [Key]
        public int quote_id { get; set; }
        public string quote_text { get; set; }

        public int author_id { get; set; }
        public Author author { get; set; }

        public int category_id { get; set; }
        public Category category { get; set; }

        public int note_id { get; set; }
        public Note note { get; set; }

        // public List<QuoteCategory> quote_categories { get; set; }

        public Quote()
        {
            // quote_categories = new List<QuoteCategory>();
        }
    }
}