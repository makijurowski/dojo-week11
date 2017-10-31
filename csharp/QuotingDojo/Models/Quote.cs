using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace QuotingDojo.Models
{
    public class Quote
    {
        [Key]
        public int quote_id { get; set; }

        public string quote { get; set; }
        public int author_id { get; set; }
        public Nullable<System.DateTime> created_at { get; }
        public Nullable<System.DateTime> updated_at { get; }
    }
}