using Microsoft.EntityFrameworkCore;
using TestTask.API.Models;

namespace TestTask.API.Data
{
    public class DataContext:DbContext
    {
        public DbSet<Order> Orers { get; set; }
        public DbSet<User> Users { get; set; }
        public DataContext(DbContextOptions options): base(options)
        {
            
        }
         protected override void OnModelCreating(ModelBuilder builder)
        {

            builder.Entity<Order>().HasData(
                new Order
                {
                    Id = 1,
                    Name = "Order1",
                    Sum = 50
                },
                new Order
                {
                    Id = 2,
                    Name = "Order2",
                    Sum = 100
                },
                new Order
                {
                    Id = 3,
                    Name = "Order3",
                    Sum = 200
                }
            );
        }
    }
}