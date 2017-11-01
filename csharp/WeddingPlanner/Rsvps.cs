using System;
using System.Collections.Generic;

namespace WeddingPlanner
{
    public partial class Rsvps
    {
        public int RsvpId { get; set; }
        public int UserId { get; set; }
        public int WeddingId { get; set; }

        public Weddings Wedding { get; set; }
    }
}
