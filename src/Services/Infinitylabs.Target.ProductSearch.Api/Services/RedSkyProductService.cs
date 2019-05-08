using System;
using System.Net.Http;
using System.Threading.Tasks;
using InfinityLabs.Target.ProductSearch.Api.Models;
using Newtonsoft.Json;

namespace InfinityLabs.Target.ProductSearch.Api.Services
{
    public class RedSkyProductService : IProductService
    {
        private readonly HttpClient _httpClient;

        public RedSkyProductService(IRedSkyConfiguration configuration)
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri(configuration.BaseUrl);
        }
        
        public async Task<ProductInformation> GetByIdAsync(int id)
        {
            if (id == -1)
            {
                throw new ArgumentOutOfRangeException($"Id '{id}' is invalid.");
            }
            var route = $"/pdp/tcin/{id}?excludes=taxonomy,price,promotion,bulk_ship,rating_and_review_reviews,rating_and_review_statistics,question_answer_statistics";
            var response =  await _httpClient.GetAsync(route);
            if (response.IsSuccessStatusCode) {
                var data = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<ProductInformation>(data);
            }
            // TODO: Throw better error
            throw new InvalidOperationException("Failed to get product");
        }
    }
}