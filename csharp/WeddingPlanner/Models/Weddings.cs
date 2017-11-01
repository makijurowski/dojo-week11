using System;
using System.Collections.Generic;

namespace WeddingPlanner.Models
{
    public partial class Weddings
    {
        public Weddings()
        {
            var Rsvps = new HashSet<Rsvps>();
        }

        public int WeddingId { get; set; }
        public int UserId { get; set; }
        public Users User { get; set; }
        public string Address { get; set; }
        public string BrideName { get; set; }
        public string GroomName { get; set; }
        public DateTime? Date { get; set; }

        public ICollection<Rsvps> Guests { get; set; }
    }
}
