using ConsimpleTestTask.Domain.Model.Entities;
using Microsoft.EntityFrameworkCore;

namespace ConsimpleTestTask.Persistence;

public class ConsimpleDbContext(
    DbContextOptions<ConsimpleDbContext> options) : DbContext(options)
{
    public DbSet<Client> Clients { get; set; }

    public DbSet<ProductCategory> ProductCategories { get; set; }
    public DbSet<Product> Products { get; set; }

    public DbSet<Purchase> Purchases { get; set; }
    public DbSet<PurchaseItem> PurchaseItems { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
    }
}