using System;
using System.Collections.Generic;

namespace WeddingPlanner.Models
{
    public partial class Rsvps
    {
        public Rsvps()
        {}

        public int RsvpId { get; set; }
        public Rsvps Rsvp { get; set; }

        public int UserId { get; set; }
        public Users User { get; set; }

        public int WeddingId { get; set; }
        public Weddings Wedding { get; set; }
    }
}