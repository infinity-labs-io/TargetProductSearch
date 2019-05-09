using InfinityLabs.Target.ProductSearch.Api.Models;
using MongoDB.Driver;

namespace InfinityLabs.Target.ProductSearch.Api.Providers
{
    public class MongoProvider : IMongoProvider
    {
        private readonly IMongoDatabase _database;

        public IMongoConfiguration Configuration { get; }

        public IMongoClient Client { get; }

        public MongoProvider(IMongoConfiguration configuration)
        {
            Configuration = configuration;
            var connectionString = Configuration.ConnectionString;
            var dbName = configuration.DatabaseName;
            Client = new MongoClient(connectionString);
            _database = Client.GetDatabase(dbName);
        }

        public IMongoCollection<T> GetCollection<T>(string key)
        {
            return _database.GetCollection<T>(key);
        }
    }
}