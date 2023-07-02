using AspNetBasicApplication.Model;
using Microsoft.EntityFrameworkCore;

namespace AspNetBasicApplication
{
    public class DataContext : DbContext
    {
      
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase("Basics");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Order>()
                .HasOne<Customer>(o => o.Customer)
                .WithMany(c => c.Orders)
                .HasForeignKey(o => o.CustomerID);

            base.OnModelCreating(modelBuilder);
        }
    }
}
