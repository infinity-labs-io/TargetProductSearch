using System;
using System.Threading.Tasks;
using InfinityLabs.Target.ProductSearch.Api.Models;

namespace InfinityLabs.Target.ProductSearch.Api.Services
{
    public class ProductPricingService : IProductPricingService
    {
        private IPricingService _pricingService;
        private readonly IProductService _productService;

        public ProductPricingService(
            IPricingService pricingService, 
            IProductService productService)
        {
            _pricingService = pricingService;
            _productService = productService;
        }
        
        public async Task<ProductPricingAggregate> GetByIdAsync(int id)
        {
            var pricing = _pricingService.GetByIdAsync(id);
            var product = _productService.GetByIdAsync(id);
            await Task.WhenAll(product);
            var pricingResult = await pricing;
            var productResult = await product;
            return new ProductPricingAggregate()
            {
                Id = id,
                Name = productResult.Name
            };
        }
    }
}