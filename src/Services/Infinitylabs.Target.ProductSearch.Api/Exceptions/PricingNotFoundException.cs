using System;
using System.Runtime.Serialization;

namespace InfinityLabs.Target.ProductSearch.Api.Exceptions
{
    public class PricingNotFoundException : NotFoundException
    {
        public PricingNotFoundException(int id) 
            : base("Pricing", id)
        {
        }
    }
}