using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WeddingPlanner.Models.Old
{
    public class Quote : BaseEntity
    {
        public int quoteid { get; set; }
        public string quote { get; set; }
        public int metaid { get; set; }
        public Meta meta { get; set; }
        public int authorid { get; set; }
        public Author author { get; set; }
        public List<QuoteCategory> quotecs { get; set; }
        public Quote()
        {
            quotecs = new List<QuoteCategory>();
        }
    }
}