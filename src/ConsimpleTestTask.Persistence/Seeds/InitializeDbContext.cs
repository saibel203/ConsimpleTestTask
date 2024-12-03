using ConsimpleTestTask.Contracts.PersistenceAbstractions;
using ConsimpleTestTask.Domain.Model.Entities;
using Microsoft.EntityFrameworkCore;
using Serilog;

namespace ConsimpleTestTask.Persistence.Seeds;

public class InitializeDbContext(
    ConsimpleDbContext dbContext) : IInitializeDbContext
{
    private readonly ILogger _logger = Log.ForContext<InitializeDbContext>();

    public async Task InitializeDatabaseAsync()
    {
        try
        {
            if (dbContext.Database.IsSqlServer())
                await dbContext.Database.MigrateAsync();

            _logger.Information("The data database has been successfully initialized");
        }
        catch (Exception ex)
        {
            _logger.Error(ex, "An error occurred while trying to initialize the data database.");
            throw;
        }
    }

    public async Task SeedDatabaseAsync()
    {
        try
        {
            await TrySeedDataAsync();
        }
        catch (Exception ex)
        {
            _logger.Error(ex, "An error occurred while trying to seed the database");
            throw;
        }
    }

    private async Task TrySeedDataAsync()
    {
        Client[] clients =
        [
            new Client
            {
                FirstName = "Maxim",
                LastName = "Logvin",
                FatherName = "Eduardovich",
                BirthDate = new DateTime(2004, 1, 21),
                RegisterDate = new DateTime(2024, 1, 10)
            },
            new Client
            {
                FirstName = "Anton",
                LastName = "Manan",
                FatherName = "Makarovich",
                BirthDate = new DateTime(2004, 1, 21),
                RegisterDate = new DateTime(2024, 1, 10)
            },
            new Client
            {
                FirstName = "Jana",
                LastName = "Stevenson",
                FatherName = "Albanovna",
                BirthDate = new DateTime(2000, 1, 1),
                RegisterDate = new DateTime(2024, 1, 10)
            },
            new Client
            {
                FirstName = "Yolanda",
                LastName = "Giles",
                FatherName = "Albanovna",
                BirthDate = new DateTime(2002, 11, 12),
                RegisterDate = new DateTime(2024, 1, 10)
            },
            new Client
            {
                FirstName = "Sharron",
                LastName = "Hess",
                FatherName = "Albanovna",
                BirthDate = new DateTime(2002, 11, 12),
                RegisterDate = new DateTime(2024, 1, 10)
            }
        ];

        if (!await dbContext.Clients.AnyAsync())
        {
            await dbContext.Clients.AddRangeAsync(clients);
            await dbContext.SaveChangesAsync();
        }

        ProductCategory[] productCategories =
        [
            new ProductCategory { Name = "Electronics" },
            new ProductCategory { Name = "Clothing" },
            new ProductCategory { Name = "Books" },
            new ProductCategory { Name = "Furniture" },
            new ProductCategory { Name = "Toys" }
        ];

        if (!await dbContext.ProductCategories.AnyAsync())
        {
            await dbContext.ProductCategories.AddRangeAsync(productCategories);
            await dbContext.SaveChangesAsync();
        }

        Product[] products =
        [
            new Product { Name = "Laptop", Sku = "LAP123", Price = 1200m, CategoryId = 1 },
            new Product { Name = "Smartphone", Sku = "SMR123", Price = 800m, CategoryId = 1 },
            new Product { Name = "Headphones", Sku = "HEA123", Price = 100m, CategoryId = 1 },
            new Product { Name = "Smartwatch", Sku = "SW123", Price = 200m, CategoryId = 1 },
            new Product { Name = "Gaming Console", Sku = "GC123", Price = 350m, CategoryId = 1 },
            new Product { Name = "TV", Sku = "TV123", Price = 500m, CategoryId = 1 },
            new Product { Name = "T-Shirt", Sku = "TSH123", Price = 20m, CategoryId = 2 },
            new Product { Name = "Jeans", Sku = "JNS123", Price = 40m, CategoryId = 2 },
            new Product { Name = "Jacket", Sku = "JKT123", Price = 60m, CategoryId = 2 },
            new Product { Name = "Dress", Sku = "DRS123", Price = 70m, CategoryId = 2 },
            new Product { Name = "Shirt", Sku = "SHR123", Price = 30m, CategoryId = 2 },
            new Product { Name = "Sweater", Sku = "SWT123", Price = 50m, CategoryId = 2 },
            new Product { Name = "Book - C# Programming", Sku = "BOK123", Price = 30m, CategoryId = 3 },
            new Product { Name = "Book - JavaScript", Sku = "BOK124", Price = 25m, CategoryId = 3 },
            new Product { Name = "Book - Python", Sku = "BOK125", Price = 35m, CategoryId = 3 },
            new Product { Name = "Book - SQL", Sku = "BOK126", Price = 20m, CategoryId = 3 },
            new Product { Name = "Book - Web Development", Sku = "BOK127", Price = 40m, CategoryId = 3 },
            new Product { Name = "Sofa", Sku = "SOF123", Price = 500m, CategoryId = 4 },
            new Product { Name = "Chair", Sku = "CHA123", Price = 50m, CategoryId = 4 },
            new Product { Name = "Table", Sku = "TBL123", Price = 100m, CategoryId = 4 },
            new Product { Name = "Bookshelf", Sku = "BSF123", Price = 150m, CategoryId = 4 },
            new Product { Name = "Doll", Sku = "DOL123", Price = 15m, CategoryId = 5 },
            new Product { Name = "Action Figure", Sku = "AF123", Price = 25m, CategoryId = 5 },
            new Product { Name = "Board Game", Sku = "BG123", Price = 35m, CategoryId = 5 },
            new Product { Name = "Puzzle", Sku = "PUZ123", Price = 10m, CategoryId = 5 },
            new Product { Name = "Teddy Bear", Sku = "TB123", Price = 20m, CategoryId = 5 },
            new Product { Name = "Video Game", Sku = "VG123", Price = 40m, CategoryId = 5 },
            new Product { Name = "Smartphone Case", Sku = "SMC123", Price = 15m, CategoryId = 1 },
            new Product { Name = "Portable Charger", Sku = "PC123", Price = 25m, CategoryId = 1 },
            new Product { Name = "Bluetooth Speaker", Sku = "BTS123", Price = 50m, CategoryId = 1 }
        ];

        if (!await dbContext.Products.AnyAsync())
        {
            await dbContext.Products.AddRangeAsync(products);
            await dbContext.SaveChangesAsync();   
        }

        Purchase[] purchases =
        [
            new Purchase { Date = new DateTime(2024, 11, 20), ClientId = 1 },
            new Purchase { Date = new DateTime(2024, 11, 22), ClientId = 2 },
            new Purchase { Date = new DateTime(2024, 10, 10), ClientId = 1 },
            new Purchase { Date = new DateTime(2024, 11, 15), ClientId = 3 },
            new Purchase { Date = new DateTime(2024, 11, 12), ClientId = 4 },
            new Purchase { Date = new DateTime(2024, 11, 21), ClientId = 2 },
            new Purchase { Date = new DateTime(2024, 11, 17), ClientId = 4 },
            new Purchase { Date = new DateTime(2024, 11, 30), ClientId = 1 },
            new Purchase { Date = new DateTime(2024, 11, 29), ClientId = 3 },
            new Purchase { Date = new DateTime(2024, 11, 5), ClientId = 2 }
        ];

        if (!await dbContext.Purchases.AnyAsync())
        {
            await dbContext.Purchases.AddRangeAsync(purchases);
            await dbContext.SaveChangesAsync();
        }

        PurchaseItem[] purchaseItems =
        [
            new PurchaseItem { PurchaseId = 1, ProductId = 1, Quantity = 1 }, // Laptop
            new PurchaseItem { PurchaseId = 1, ProductId = 3, Quantity = 2 }, // Headphones
            new PurchaseItem { PurchaseId = 2, ProductId = 7, Quantity = 1 }, // T-Shirt
            new PurchaseItem { PurchaseId = 2, ProductId = 8, Quantity = 2 }, // Jeans
            new PurchaseItem { PurchaseId = 3, ProductId = 13, Quantity = 3 }, // Book - C# Programming
            new PurchaseItem { PurchaseId = 3, ProductId = 14, Quantity = 1 }, // Book - JavaScript
            new PurchaseItem { PurchaseId = 4, ProductId = 18, Quantity = 1 }, // Sofa
            new PurchaseItem { PurchaseId = 5, ProductId = 23, Quantity = 1 }, // Action Figure
            new PurchaseItem { PurchaseId = 6, ProductId = 5, Quantity = 1 }, // Gaming Console
            new PurchaseItem { PurchaseId = 6, ProductId = 6, Quantity = 1 }, // TV
            new PurchaseItem { PurchaseId = 7, ProductId = 4, Quantity = 2 }, // Smartwatch
            new PurchaseItem { PurchaseId = 7, ProductId = 19, Quantity = 1 }, // Chair
            new PurchaseItem { PurchaseId = 8, ProductId = 2, Quantity = 1 }, // Smartphone
            new PurchaseItem { PurchaseId = 9, ProductId = 25, Quantity = 3 }, // Puzzle
            new PurchaseItem { PurchaseId = 10, ProductId = 12, Quantity = 1 }, // Sweater
            new PurchaseItem { PurchaseId = 10, ProductId = 9, Quantity = 1 }, // Jacket
            new PurchaseItem { PurchaseId = 10, ProductId = 10, Quantity = 1 }, // Dress
            new PurchaseItem { PurchaseId = 4, ProductId = 22, Quantity = 2 }, // Doll
            new PurchaseItem { PurchaseId = 5, ProductId = 24, Quantity = 1 } // Board Game
        ];

        if (!await dbContext.PurchaseItems.AnyAsync())
        {
            await dbContext.PurchaseItems.AddRangeAsync(purchaseItems);
            await dbContext.SaveChangesAsync();
        }
    }
}