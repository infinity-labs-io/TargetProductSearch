using System;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using InfinityLabs.Target.ProductSearch.Api.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace InfinityLabs.Target.ProductSearch.Api.Services
{
    public class RedSkyProductService : IProductService
    {
        private readonly HttpClient _httpClient;

        public RedSkyProductService(IRedSkyConfiguration configuration)
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri(configuration.BaseAddress);
        }
        
        public async Task<ProductInformation> GetByIdAsync(int id)
        {
            if (id == -1)
            {
                throw new ArgumentOutOfRangeException($"Id '{id}' is invalid.");
            }
            var route = $"v2/pdp/tcin/{id}?excludes=taxonomy,price,promotion,bulk_ship,rating_and_review_reviews,rating_and_review_statistics,question_answer_statistics";
            var response =  await _httpClient.GetAsync(route);
            if (response.IsSuccessStatusCode) {
                var data = await response.Content.ReadAsStringAsync();
                return deserialize(data);
            }
            // TODO: Throw better error
            var message = response.RequestMessage.RequestUri.ToString() + "\n" + response.ToString();
            throw new InvalidOperationException(message);
        }

        private ProductInformation deserialize(string data) {
            var jsonObject = JObject.Parse(data);
            var item = jsonObject["product"]["item"]; // { item: {} ... }
            if (!item.HasValues) {
                throw new FormatException($"Red Sky response is not in the correct format\n{data}");
            }
            var productDescription = item["product_description"];
            return new ProductInformation()
            {
                Name = productDescription["title"].Value<string>()
            };
        }
    }
}