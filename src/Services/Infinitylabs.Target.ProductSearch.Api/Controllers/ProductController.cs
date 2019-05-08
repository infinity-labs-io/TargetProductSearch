using System.Threading.Tasks;
using InfinityLabs.Target.ProductSearch.Api.Models;
using InfinityLabs.Target.ProductSearch.Api.Services;
using Microsoft.AspNetCore.Mvc;

namespace InfinityLabs.Target.ProductSearch.Api.Controllers
{
    [ApiController]
    public class ProductController : Controller
    {
        private readonly IProductPricingService _productPricing;
        private readonly IPricingService _pricingService;

        public ProductController(IProductPricingService productPricing, IPricingService pricingService)
        {
            _productPricing = productPricing;
            _pricingService = pricingService;
        }

        [HttpGet("products/{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var product = await _productPricing.GetByIdAsync(id);
            return Ok(product);
        }

        [HttpPut("products/{id}")]
        public async Task<IActionResult> Put([FromBody] ProductPricingAggregate product)
        {
            await _pricingService.PutByIdAsync(product.CurrentPrice);
            return Accepted();
        }
    }
}