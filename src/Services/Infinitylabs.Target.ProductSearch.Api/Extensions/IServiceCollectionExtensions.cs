using System;
using InfinityLabs.Target.ProductSearch.Api.Seeders;
using Microsoft.Extensions.DependencyInjection;

namespace InfinityLabs.Target.ProductSearch.Api.Extensions
{
    public static class IServiceCollectionExtensions
    {
        public static IServiceCollection AddSeeders(
            this IServiceCollection services, 
            Action<DatabaseSeederBuilder> options)
        {
            var builder = new DatabaseSeederBuilder(services);
            options(builder);

            return services
                .AddScoped<IDatabaseSeeder, DatabaseSeeder>(serviceProvider => {
                    return new DatabaseSeeder(serviceProvider, builder);
                });
        }
    }
}