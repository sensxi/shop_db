namespace Practice.Services
{
    public interface IDataSeedService
    {
        Task<string> SeedDatabaseAsync();
    }
}
