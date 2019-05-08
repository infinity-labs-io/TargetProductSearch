using System;
using System.Threading.Tasks;
using InfinityLabs.Target.ProductSearch.Api.Models;

namespace InfinityLabs.Target.ProductSearch.Api.Services
{
    public class MongoPricingService : IPricingService
    {
        public Task<PricingInformation> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task PutByIdAsync(int id, PricingInformation information)
        {
            throw new NotImplementedException();
        }
    }
}