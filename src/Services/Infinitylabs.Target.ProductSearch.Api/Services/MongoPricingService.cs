using System;
using System.Threading.Tasks;
using InfinityLabs.Target.ProductSearch.Api.Exceptions;
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
            var pricing = await _pricing.Find(p => p.Id == id).FirstOrDefaultAsync();
            if (pricing == null)
            {
                throw new PricingNotFoundException("No pricing exists for id '{id}'.");
            }
            return pricing;
        }

        public async Task PutByIdAsync(int id, PricingInformation information)
        {
            await _pricing.ReplaceOneAsync(p => p.Id == id, information);
        }
    }
}