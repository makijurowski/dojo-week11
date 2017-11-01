using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WeddingPlanner.Models
{
    public partial class Weddings : BaseEntity
    {
        public Weddings() 
        { 
            // wedding_guests = new List<Users>();
        }

        [Key]
        public int WeddingId { get; set; }

        public int UserId { get; set; }
        public Users User { get; set; }

        public string Address { get; set; }
        public string BrideName { get; set; }
        public string GroomName { get; set; }
        public DateTime? Date { get; set; }

        // public List<Users> wedding_guests { get; set; }
    }
}