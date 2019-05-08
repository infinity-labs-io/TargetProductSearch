using System.Threading.Tasks;
using InfinityLabs.Target.ProductSearch.Api.Models;

namespace InfinityLabs.Target.ProductSearch.Api.Services
{
    public interface IProductPricingService
    {
        Task<ProductPricingAggregate> GetByIdAsync(int id);
    }
}