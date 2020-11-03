using Microsoft.EntityFrameworkCore;
using stock_app.Models.Entities;

namespace stock_app.Models.Databases
{
    public class StockContext : DbContext
    {
        public StockContext(DbContextOptions<StockContext> options) : base(options)
        {

        }

        public DbSet<Product> Products {get; set;}
        protected override void OnModelCreating(ModelBuilder builder)
        {
               builder.Entity<Product>().HasKey(m => m.Id);
               base.OnModelCreating(builder);
        }

    }
}