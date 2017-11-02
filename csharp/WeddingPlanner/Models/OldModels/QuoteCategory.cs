using System;

namespace WeddingPlanner.Models.Old
{
    public class QuoteCategory : BaseEntity
    {
        public int id { get; set; }
        public int quoteid { get; set; }
        public Quote quote { get; set; }
        public int categoryid { get; set; }
        public Category category { get; set; }
    }
}