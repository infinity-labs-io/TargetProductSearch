using System;
using System.Threading.Tasks;
using InfinityLabs.Target.ProductSearch.Api.Models;
using MongoDB.Driver;

namespace InfinityLabs.Target.ProductSearch.Api.Services
{
    public class MongoPricingService : IPricingService
    {
        private readonly IMongoCollection<PricingInformation> _pricing;
        
        public MongoPricingService(IMongoConfiguration configuration)
        {
            var connectionString = configuration.ConnectionString;
            var dbName = configuration.DatabaseName;
            var client = new MongoClient(connectionString);
            var database = client.GetDatabase(dbName);
            _pricing = database.GetCollection<PricingInformation>("Pricing");

        }
        
        public async Task<PricingInformation> GetByIdAsync(int id)
        {
            return await _pricing.Find(p => p.Id == id).SingleOrDefaultAsync();
        }

        public async Task PutByIdAsync(int id, PricingInformation information)
        {
            await _pricing.ReplaceOneAsync(p => p.Id == id, information);
        }
    }
}