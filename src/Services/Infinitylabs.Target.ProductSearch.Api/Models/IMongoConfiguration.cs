namespace InfinityLabs.Target.ProductSearch.Api.Models
{
    public interface IMongoConfiguration
    {
        string ConnectionString { get; }
        
        string DatabaseName { get; }
    }
}