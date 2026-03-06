using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Collections.Generic;

namespace LinqEfDemo;

public class AppDbContext : DbContext
{
    public DbSet<Customer> Customers => Set<Customer>();
    public DbSet<Order> Orders => Set<Order>();

    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        var connectionString =
            "server=localhost;port=3306;database=LinqEfDb;user=root;password=root;";

        options.UseMySql(
            connectionString,
            ServerVersion.AutoDetect(connectionString)
        );
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Customer>()
            .HasMany(c => c.Orders)
            .WithOne(o => o.Customer)
            .HasForeignKey(o => o.CustomerId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}

