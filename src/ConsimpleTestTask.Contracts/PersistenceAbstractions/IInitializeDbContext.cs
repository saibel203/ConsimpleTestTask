namespace ConsimpleTestTask.Contracts.PersistenceAbstractions;

public interface IInitializeDbContext
{
    Task InitializeDatabaseAsync();
    Task SeedDatabaseAsync();
}