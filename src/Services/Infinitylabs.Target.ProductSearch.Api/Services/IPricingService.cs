using System.Threading.Tasks;
using InfinityLabs.Target.ProductSearch.Api.Models;

namespace InfinityLabs.Target.ProductSearch.Api.Services
{
    public interface IPricingService
    {
        Task<PricingInformation> GetByIdAsync(int id);

        Task PutByIdAsync(int id, PricingInformation information);
    }
}