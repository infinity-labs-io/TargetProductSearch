using System;
using System.Threading.Tasks;
using InfinityLabs.Target.ProductSearch.Api.Models;
using InfinityLabs.Target.ProductSearch.Api.Providers;
using MongoDB.Driver;

namespace InfinityLabs.Target.ProductSearch.Api.Services
{
    public class MongoPricingService : IPricingService
    {
        private readonly IMongoCollection<PricingInformation> _pricing;
        
        public MongoPricingService(IMongoProvider provider)
        {
            _pricing = provider.GetCollection<PricingInformation>("Pricing");

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