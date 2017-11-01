using System;

namespace WeddingPlanner.Models.Old
{
    public class Meta : BaseEntity
    {
        public int metaid { get; set; }
        public string notes { get; set; }
        public Quote quote { get; set; }
    }
}