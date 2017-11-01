using Microsoft.EntityFrameworkCore;

namespace WeddingPlanner.Models
{
    public class WeddingPlannerContext : DbContext
    {
        public WeddingPlannerContext(DbContextOptions<WeddingPlannerContext> options) : base(options) { }
        public DbSet<Author> authors { get; set; }
        public DbSet<Category> categories { get; set; }
        public DbSet<Meta> metas { get; set; }
        public DbSet<Quote> quotes { get; set; }
        public DbSet<QuoteCategory> quotecategories { get; set; }
    }
}