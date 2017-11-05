using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace IdeaExchange
{
    public class ApplicationUser : IdentityUser
    {
        public int UserId { get; set; }
        public string Alias { get; set; }
        public string Fname { get; set; }
    }
}