namespace QuotingDojo.Models
{
    public class QuotingDojoContext : DbContext
    {
        public QuotingDojoContext(DbContextOptions<QuotingDojoContext> options)
        {

        }   

        // public DbSet<Author> authors { get; set; }
    }
}