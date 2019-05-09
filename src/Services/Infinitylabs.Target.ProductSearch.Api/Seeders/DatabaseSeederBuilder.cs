using System;
using System.Collections.Generic;
using Microsoft.Extensions.DependencyInjection;

namespace InfinityLabs.Target.ProductSearch.Api.Seeders
{
    public class DatabaseSeederBuilder
    {
        private readonly IServiceCollection _services;

        public List<Type> Seeders { get; }

        public DatabaseSeederBuilder(IServiceCollection services)
        {
            _services = services;

            Seeders = new List<Type>();
        }
        
        public DatabaseSeederBuilder AddSeeder<T>()
            where T : class, IDatabaseSeeder
        {
            _services.AddScoped<T>();
            Seeders.Add(typeof(T));
            
            return this;
        }
    }
}