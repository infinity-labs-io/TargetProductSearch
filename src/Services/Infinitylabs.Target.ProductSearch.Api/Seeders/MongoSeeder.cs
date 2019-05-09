using System.Threading.Tasks;
using InfinityLabs.Target.ProductSearch.Api.Models;
using InfinityLabs.Target.ProductSearch.Api.Providers;
using MongoDB.Driver;

namespace InfinityLabs.Target.ProductSearch.Api.Seeders
{
    public abstract class MongoSeederBase<T> : IDatabaseSeeder
    {
        private readonly string _key;
        private readonly IMongoProvider _provider;

        protected MongoSeederBase(string key, IMongoProvider provider)
        {
            _key = key;
            _provider = provider;
        }

        public async Task SeedAsync()
        {
            var dbName = _provider.Configuration.DatabaseName;
            await _provider.Client.DropDatabaseAsync(dbName);
            
            await SeedAsync(_provider.GetCollection<T>(_key));
        }

        protected abstract Task SeedAsync(IMongoCollection<T> collection);
    }
}