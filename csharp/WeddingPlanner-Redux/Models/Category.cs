using System;
using System.Collections.Generic;

namespace WeddingPlanner.Models
{
    public class Category : BaseEntity
    {
        public int categoryid { get; set; }
        public string name { get; set; }
        public List<QuoteCategory> qcats { get; set; }
        public Category()
        {
            qcats = new List<QuoteCategory>();
        }
    }
}