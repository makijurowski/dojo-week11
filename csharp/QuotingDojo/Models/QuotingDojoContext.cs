using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using QuotingDojo.Models;

namespace QuotingDojo.Models
{
    public class QuotingDojoContext : DbContext
    {
        public QuotingDojoContext(DbContextOptions<QuotingDojoContext> options)
            : base(options)
        {
        }
        public DbSet<Author> authors { get; set; }
        public DbSet<Quote> quotes { get; set; }
        public DbSet<Category> categories { get; set; }
        public DbSet<Note> notes { get; set; }
        // public DbSet<QuoteCategory> quote_categories { get; set; }
    }
}