using System;
using System.Threading.Tasks;
using InfinityLabs.Target.ProductSearch.Api.Models;

namespace InfinityLabs.Target.ProductSearch.Api.Services
{
    public class ProductPricingService : IProductPricingService
    {
        public Task<ProductPricingAggregate> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}