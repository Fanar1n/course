using Microsoft.EntityFrameworkCore;

namespace Laba5.Models
{
    public class RestaurantContext : DbContext
    {
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Dish> Dishes { get; set; }
        public DbSet<Table> Tables { get; set; }

        public RestaurantContext(DbContextOptions<RestaurantContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
