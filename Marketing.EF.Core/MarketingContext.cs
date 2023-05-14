using Marketing.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace Marketing.EF.Core
{
    public class MarketingContext : DbContext
    {
        public MarketingContext(DbContextOptions<MarketingContext> options) : base(options)
        {

        }
        public DbSet<Service> Services { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }
    }
}