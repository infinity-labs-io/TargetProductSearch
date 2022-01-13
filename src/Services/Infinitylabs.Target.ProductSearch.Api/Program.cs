using InfinityLabs.Target.ProductSearch.Api.Extensions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace InfinityLabs.Target.ProductSearch.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();
            host.SeedDatabaseAsync()
                .Wait(30000);
            
            host.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(builder => {
                    builder.UseStartup<Startup>();
                })
                .ConfigureAppConfiguration((context, config) => {
                    config.AddJsonFile("secrets.json");
                })
                .ConfigureLogging(logging => {
                    logging
                        .ClearProviders()
                        .AddConsole();
                });
    }
}
