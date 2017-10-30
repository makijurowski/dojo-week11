using System;
using System.Collections.Generic;

namespace WeddingPlanner
{
    public partial class Rsvps
    {
        public int RsvpId { get; set; }
        public int UsersUserId { get; set; }
        public int WeddingId { get; set; }
        public int UserId { get; set; }

        public Users UsersUser { get; set; }
        public Weddings Weddings { get; set; }
    }
}
