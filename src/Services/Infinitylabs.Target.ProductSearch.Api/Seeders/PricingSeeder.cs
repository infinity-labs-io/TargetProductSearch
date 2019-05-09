using System;
using System.Linq;
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
            var rand = new Random();
            var range = Enumerable.Range(13860000, 1000)
                .Select(id => {
                    return new PricingInformation() {
                        Id = id,
                        CurrencyCode = CurrencyCode.USD,
                        Value = randomDecimal(rand, 10, 50)
                    };
                })
                .ToArray();
            await collection.InsertManyAsync(range);
        }

        private decimal randomDecimal(Random rand, int min, int max)
        {
            var value = (decimal)(max + (rand.NextDouble() * (max - min)));
            return Math.Round(value, 2);
        }
    }
}