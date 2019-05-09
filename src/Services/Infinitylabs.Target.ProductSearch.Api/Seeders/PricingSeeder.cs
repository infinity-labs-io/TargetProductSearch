using System.Threading.Tasks;
using InfinityLabs.Target.ProductSearch.Api.Enums;
using InfinityLabs.Target.ProductSearch.Api.Models;
using InfinityLabs.Target.ProductSearch.Api.Providers;
using MongoDB.Driver;

namespace InfinityLabs.Target.ProductSearch.Api.Seeders
{
    public class PricingSeeder : MongoSeederBase<PricingInformation>
    {
        public PricingSeeder(IMongoProvider provider) 
            : base("Pricing", provider)
        {
        }

        protected override async Task SeedAsync(IMongoCollection<PricingInformation> collection)
        {
            await collection.InsertOneAsync(new PricingInformation()
            {
                Id = 13860428,
                CurrencyCode = CurrencyCode.USD,
                Value = 30.3m
            });
        }
    }
}