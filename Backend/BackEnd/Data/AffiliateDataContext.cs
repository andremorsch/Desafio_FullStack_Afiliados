using BackEnd.Models;
using Microsoft.EntityFrameworkCore;

namespace BackEnd.Data
{
    public class AffiliateDataContext : DbContext
    {
        public AffiliateDataContext(DbContextOptions<AffiliateDataContext> options) 
            : base(options)
        {
        }

        public DbSet<AffiliateData> AffiliateData { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new AffiliateDataMap());
        }
    }
}
