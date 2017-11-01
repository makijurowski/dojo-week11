using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WeddingPlanner.Models
{
    public partial class Users : BaseEntity
    {
        public Users()
        {
            // user_weddings = new List<Weddings>();
        }

        [Key]
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        // public List<Weddings> user_weddings { get; set; }
    }
}