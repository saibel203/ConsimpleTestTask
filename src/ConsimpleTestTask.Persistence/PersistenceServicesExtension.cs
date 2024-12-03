using ConsimpleTestTask.Contracts.PersistenceAbstractions;
using ConsimpleTestTask.Contracts.RepositoryAbstractions;
using ConsimpleTestTask.Contracts.RepositoryAbstractions.Base;
using ConsimpleTestTask.Persistence.Repositories;
using ConsimpleTestTask.Persistence.Repositories.Base;
using ConsimpleTestTask.Persistence.Seeds;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ConsimpleTestTask.Persistence;

public static class PersistenceServicesExtension
{
    public static void AddPersistenceServices(this IServiceCollection services,
        IConfiguration configuration)
    {
        const string connectionStringName = "BaseConnectionString";
        string? databaseConnectionString = configuration.GetConnectionString(connectionStringName);

        if (databaseConnectionString is null)
            throw new NullReferenceException("Error trying to get a database connection string");

        // Register SqlServer DbContext
        services.AddDbContext<ConsimpleDbContext>(options =>
            options.UseSqlServer(databaseConnectionString));

        // Register DbSeed service
        services.AddScoped<IInitializeDbContext, InitializeDbContext>();
        
        // Register UnitOfWork
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddScoped<IPurchaseRepository, PurchaseRepository>();
        services.AddScoped<IPurchaseItemRepository, PurchaseItemRepository>();
    }
}