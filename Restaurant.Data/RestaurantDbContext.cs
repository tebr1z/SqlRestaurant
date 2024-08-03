using Microsoft.EntityFrameworkCore;
using Restaurant.Core.Entities;

namespace Restaurant.Data;

public class RestaurantDbContext:DbContext
{
    public DbSet<MenuItem> MenuItems { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<OrderItem> OrderItems { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=DESKTOP-C20TBEU;Database=RestaurantTs;Trusted_Connection=Yes;TrustServerCertificate=True");
        base.OnConfiguring(optionsBuilder);
    }
}
