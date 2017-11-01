using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WeddingPlanner.Models
{
    public partial class Rsvps : BaseEntity
    {
        public Rsvps()
        {}

        [Key]
        public int RsvpId { get; set; }

        public int UserId { get; set; }
        public Users User { get; set; }

        public int WeddingId { get; set; }
        public Weddings Wedding { get; set; }
    }
}