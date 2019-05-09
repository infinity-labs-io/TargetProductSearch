using InfinityLabs.Target.ProductSearch.Api.Models;
using MongoDB.Driver;

namespace InfinityLabs.Target.ProductSearch.Api.Providers
{
    public interface IMongoProvider
    {
        IMongoClient Client { get; }

        IMongoConfiguration Configuration { get; }
        
        IMongoCollection<T> GetCollection<T>(string key);
    }
}