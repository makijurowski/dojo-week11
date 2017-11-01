using System;

namespace WeddingPlanner.Models
{
    public class Meta : BaseEntity
    {
        public int metaid { get; set; }
        public string notes { get; set; }
        public Quote quote { get; set; }
    }
}