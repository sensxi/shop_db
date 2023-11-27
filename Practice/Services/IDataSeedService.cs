namespace Task9.Services
{
    public interface IDataSeedService
    {
        Task<string> SeedDatabaseAsync();
    }
}
