using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WeddingPlanner
{
    public partial class Weddings
    {
        public Weddings()
        {
            Rsvps = new HashSet<Rsvps>();
        }

        [Key]
        public int WeddingId { get; set; }

        public int UserId { get; set; }
        
        public string Address { get; set; }
        public string BrideName { get; set; }
        public DateTime? Date { get; set; }
        public string GroomName { get; set; }

        public ICollection<Rsvps> Rsvps { get; set; }
    }
}