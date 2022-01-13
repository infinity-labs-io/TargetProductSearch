using System;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using InfinityLabs.Target.ProductSearch.Api.Exceptions;
using InfinityLabs.Target.ProductSearch.Api.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace InfinityLabs.Target.ProductSearch.Api.Services
{
    public class RedSkyProductService : IProductService
    {
        private readonly string _apiKey;
        private readonly ILogger _logger;
        private readonly HttpClient _httpClient;

        public RedSkyProductService(IRedSkyConfiguration configuration, IAuthentication authentication, ILogger<RedSkyProductService> logger)
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri(configuration.BaseAddress);
            _apiKey = authentication.RedSkyApiKey;
            _logger = logger;
        }
        
        public async Task<ProductInformation> GetByIdAsync(int id)
        {
            if (id < 10000000)
            {
                throw new ArgumentOutOfRangeException($"Id '{id}' is invalid.");
            }
            var queryString = new QueryString()
                .Add("key", _apiKey)
                .Add("tcin", id.ToString());
            var response =  await _httpClient.GetAsync(queryString.ToString());
            if (response.IsSuccessStatusCode) {
                var data = await response.Content.ReadAsStringAsync();
                _logger.LogInformation("RedSky request completed.", data);
                return deserialize(data);
            }
            throw new ProductNotFoundException(id);
        }

        private ProductInformation deserialize(string data) {
            var jsonObject = JObject.Parse(data);
            var item = jsonObject["data"]["product"]["item"];
            if (!item.HasValues) {
                throw new FormatException($"Red Sky response is not in the correct format\n{data}");
            }

            _logger.LogInformation($"Item found: {item.ToString(Formatting.Indented)}");
            
            var productDescription = item["product_description"];
            return new ProductInformation()
            {
                Name = productDescription["title"].Value<string>(),
                Description = productDescription["downstream_description"].Value<string>(),
            };
        }
    }
}