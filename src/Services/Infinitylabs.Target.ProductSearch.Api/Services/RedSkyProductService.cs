using System;
using System.Threading.Tasks;
using InfinityLabs.Target.ProductSearch.Api.Models;

namespace InfinityLabs.Target.ProductSearch.Api.Services
{
    public class RedSkyProductService : IProductService
    {
        public Task<ProductInformation> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}