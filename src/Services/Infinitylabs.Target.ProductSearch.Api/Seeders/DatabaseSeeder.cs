using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InfinityLabs.Target.ProductSearch.Api.Providers;
using Microsoft.Extensions.DependencyInjection;

namespace InfinityLabs.Target.ProductSearch.Api.Seeders
{
    public class DatabaseSeeder : IDatabaseSeeder
    {
        private readonly IEnumerable<IDatabaseSeeder> _seeders;

        public DatabaseSeeder(
            IServiceProvider services,
            DatabaseSeederBuilder builder)
        {
            _seeders = builder.Seeders
                .Select(s => services.GetService(s))
                .Cast<IDatabaseSeeder>();
        }
        
        public async Task SeedAsync()
        {
            var tasks = _seeders
                .Select(s => s.SeedAsync())
                .ToArray();
                
            await Task.WhenAll(tasks);
        }
    }
}