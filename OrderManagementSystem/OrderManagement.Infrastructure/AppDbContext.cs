using Microsoft.EntityFrameworkCore;
using OrderManagement.Domain.Entities;

namespace OrderManagement.Infrastructure;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
    
    public DbSet<Product> Products => Set<Product>();
    public DbSet<Order> Orders => Set<Order>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Order>()
            .OwnsMany(o => o.Items, oi =>
            {
                oi.WithOwner().HasForeignKey("OrderId");
                oi.Property<Guid>("Id");
                oi.HasKey("Id");
            });

        base.OnModelCreating(modelBuilder);
    }
}
