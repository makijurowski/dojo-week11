using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace QuotingDojo.Models
{
    public class Author : BaseEntity
    {
        [Key]
        public int author_id { get; set; }

        public string name { get; set; }
        public Nullable<System.DateTime> created_at { get; }
        public Nullable<System.DateTime> updated_at { get; }
    }
}