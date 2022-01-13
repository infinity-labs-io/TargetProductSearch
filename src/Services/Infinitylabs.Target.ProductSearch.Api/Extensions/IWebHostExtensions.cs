using System.Threading.Tasks;
using InfinityLabs.Target.ProductSearch.Api.Seeders;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace InfinityLabs.Target.ProductSearch.Api.Extensions
{
    public static class IWebHostExtensions
    {
        public static async Task SeedDatabaseAsync(this IHost host)
        {
            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                var environment = services.GetService<IWebHostEnvironment>();
                if (environment.IsDevelopment())
                {
                    await services
                        .GetService<IDatabaseSeeder>()
                        .SeedAsync();
                }
            }
        }
    }
}