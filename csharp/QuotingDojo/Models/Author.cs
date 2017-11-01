using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace QuotingDojo.Models
{
    public class Author : BaseEntity
    {
        [Key]
        public int author_id { get; set; }
        public string author_name { get; set; }

        public List<Quote> quotes { get; set; }
        
        public Author()
        {
            quotes = new List<Quote>();
        }
    }
}