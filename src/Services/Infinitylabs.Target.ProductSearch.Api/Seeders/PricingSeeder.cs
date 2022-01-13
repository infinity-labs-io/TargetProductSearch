using System;
using System.Linq;
using System.Threading.Tasks;
using InfinityLabs.Target.ProductSearch.Api.Enums;
using InfinityLabs.Target.ProductSearch.Api.Models;
using InfinityLabs.Target.ProductSearch.Api.Providers;
using Microsoft.Extensions.Logging;
using MongoDB.Driver;

namespace InfinityLabs.Target.ProductSearch.Api.Seeders
{
    public class PricingSeeder : MongoSeederBase<PricingInformation>
    {
        public PricingSeeder(IMongoProvider provider, ILogger<PricingSeeder> logger) 
            : base("Pricing", provider, logger)
        {
        }

        protected override async Task SeedAsync(IMongoCollection<PricingInformation> collection)
        {
            await Task.WhenAll(
                new [] {
                    SeedRangeAsync(collection, 13000000, 1000000),
                    SeedRangeAsync(collection, 54000000, 400000)
                }
            );
        }

        private async Task SeedRangeAsync(IMongoCollection<PricingInformation> collection, int startIndex, int count)
        {
            var rand = new Random();
            var range = Enumerable.Range(startIndex, count)
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