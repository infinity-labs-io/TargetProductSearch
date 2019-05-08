using System.Threading.Tasks;
using InfinityLabs.Target.ProductSearch.Api.Models;
using InfinityLabs.Target.ProductSearch.Api.Services;
using Microsoft.AspNetCore.Mvc;

namespace InfinityLabs.Target.ProductSearch.Api.Controllers
{
    public class ProductsController : ApiControllerBase
    {
        private readonly IProductPricingService _productPricing;
        private readonly IPricingService _pricingService;

        public ProductsController(IProductPricingService productPricing, IPricingService pricingService)
        {
            _productPricing = productPricing;
            _pricingService = pricingService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var product = await _productPricing.GetByIdAsync(id);
            return Ok(product);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] PricingInformation pricing)
        {
            await _pricingService.PutByIdAsync(id, pricing);
            return Accepted();
        }
    }
}