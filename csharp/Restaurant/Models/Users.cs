using System;
using System.Collections.Generic;
using Restaurant.Models;

namespace Restaurant
{
    public partial class Users
    {
        public Users()
        {
            Blogs = new HashSet<Blogs>();
        }

        public int UserId { get; set; }
        public string Name { get; set; }

        public ICollection<Blogs> Blogs { get; set; }
    }
}