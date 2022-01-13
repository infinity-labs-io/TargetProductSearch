using System.Threading.Tasks;
using InfinityLabs.Target.ProductSearch.Api.Models;
using InfinityLabs.Target.ProductSearch.Api.Providers;
using Microsoft.Extensions.Logging;
using MongoDB.Driver;

namespace InfinityLabs.Target.ProductSearch.Api.Seeders
{
    public abstract class MongoSeederBase<T> : IDatabaseSeeder
    {
        protected readonly ILogger _logger;
        private readonly string _key;
        private readonly IMongoProvider _provider;

        protected MongoSeederBase(string key, IMongoProvider provider, ILogger logger)
        {
            _key = key;
            _provider = provider;
            _logger = logger;
        }

        public async Task SeedAsync()
        {
            _logger.LogInformation("Seeding database");

            var dbName = _provider.Configuration.DatabaseName;
            await _provider.Client.DropDatabaseAsync(dbName);
            
            await SeedAsync(_provider.GetCollection<T>(_key));
        }

        protected abstract Task SeedAsync(IMongoCollection<T> collection);
    }
}