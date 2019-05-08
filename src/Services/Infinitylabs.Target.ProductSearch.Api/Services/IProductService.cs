using System.Threading.Tasks;
using InfinityLabs.Target.ProductSearch.Api.Models;

namespace InfinityLabs.Target.ProductSearch.Api.Services
{
    public interface IProductService
    {
        Task<ProductInformation> GetByIdAsync(int id);
    }
}