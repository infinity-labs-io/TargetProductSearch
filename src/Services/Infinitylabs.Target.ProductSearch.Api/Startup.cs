using System.Text.Json.Serialization;
using InfinityLabs.Target.ProductSearch.Api.Extensions;
using InfinityLabs.Target.ProductSearch.Api.Middleware;
using InfinityLabs.Target.ProductSearch.Api.Models;
using InfinityLabs.Target.ProductSearch.Api.Providers;
using InfinityLabs.Target.ProductSearch.Api.Seeders;
using InfinityLabs.Target.ProductSearch.Api.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace InfinityLabs.Target.ProductSearch.Api
{
    public class Startup
    {
        private readonly IConfiguration _configuration;

        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        
        public void ConfigureServices(IServiceCollection services)
        {
            var config = new MongoConfiguration();
            var redSkyConfig = new RedSkyConfiguration();
            _configuration.Bind("Mongo", config);
            _configuration.Bind("RedSky", redSkyConfig);

            var authSecret = new AuthSecrets();
            _configuration.Bind("auth", authSecret);

            services
                .AddSingleton<IMongoConfiguration>(config)
                .AddSingleton<IRedSkyConfiguration>(redSkyConfig)
                .AddSingleton<IAuthentication>(authSecret);
            
            services
                .AddScoped<IMongoProvider, MongoProvider>()
                .AddScoped<IPricingService, MongoPricingService>()
                .AddScoped<IProductPricingService, ProductPricingService>()
                .AddScoped<IProductService, RedSkyProductService>();

            services
                .AddSeeders(options => {
                    options.AddSeeder<PricingSeeder>();
                })
                .AddControllers()
                .AddJsonOptions(options =>
                {
                    options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
                });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseMiddleware<ExceptionMiddleware>();
            app.UseRouting();
            app.UseEndpoints(endpoints => {
                endpoints.MapControllers();
            });
        }
    }
}
