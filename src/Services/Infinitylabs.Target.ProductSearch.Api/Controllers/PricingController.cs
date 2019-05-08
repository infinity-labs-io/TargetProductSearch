using System.Threading.Tasks;
using InfinityLabs.Target.ProductSearch.Api.Services;
using Microsoft.AspNetCore.Mvc;

namespace InfinityLabs.Target.ProductSearch.Api.Controllers
{
    public class PricingController : ApiControllerBase
    {
        private readonly IPricingService _pricingService;

        public PricingController(IPricingService pricingService)
        {
            _pricingService = pricingService;
        }
        
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await _pricingService.GetByIdAsync(id));
        }
    }
}