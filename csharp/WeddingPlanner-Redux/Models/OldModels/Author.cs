using System;
using System.Collections.Generic;

namespace WeddingPlanner.Models.Old
{
    public class Author : BaseEntity
    {
        public int authorid { get; set; }
        public string name { get; set; }
        public List<Quote> quotes { get; set; }
        public Author()
        {
            quotes = new List<Quote>();
        }
    }
}