using System;
using System.Collections.Generic;

namespace WeddingPlanner.Models
{
    public partial class Rsvps
    {
        public int RsvpId { get; set; }
        public Users Guest { get; set; }
        public int WeddingId { get; set; }
        public int GuestId { get; set; }

        public Weddings Weddings { get; set; }
    }
}
