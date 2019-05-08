using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InfinityLabs.Target.ProductSearch.Api.Models;
using InfinityLabs.Target.ProductSearch.Api.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infinitylabs.Target.ProductSearch.Api
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

            services
                .AddSingleton<IMongoConfiguration>(config)
                .AddSingleton<IRedSkyConfiguration>(redSkyConfig);
            
            services
                .AddScoped<IPricingService, MongoPricingService>()
                .AddScoped<IProductPricingService, ProductPricingService>()
                .AddScoped<IProductService, RedSkyProductService>();

            services
                .AddMvc();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc(routes => {
                routes.MapRoute("default", "api/*");
            });
        }
    }
}
