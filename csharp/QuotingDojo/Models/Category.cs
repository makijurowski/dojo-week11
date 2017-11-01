using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace QuotingDojo.Models
{
    public class Category : BaseEntity
    {
        [Key]
        public int category_id { get; set; }
        public string category_name { get; set; }
        
        // public List<QuoteCategory> quote_categories { get; set; }

        public Category()
        {
            // quote_categories = new List<QuoteCategory>();
        }
    }
}