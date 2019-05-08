using System;
using System.Threading.Tasks;
using InfinityLabs.Target.ProductSearch.Api.Models;

namespace InfinityLabs.Target.ProductSearch.Api.Services
{
    public class PricingService : IPricingService
    {
        public Task<PricingInformation> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task PutByIdAsync(PricingInformation information)
        {
            throw new NotImplementedException();
        }
    }
}