using System;
using System.Collections.Generic;

namespace WeddingPlanner
{
    public partial class Users
    {
        public Users()
        {
            Rsvps = new HashSet<Rsvps>();
            Weddings = new HashSet<Weddings>();
        }

        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public ICollection<Rsvps> Rsvps { get; set; }
        public ICollection<Weddings> Weddings { get; set; }
    }
}
