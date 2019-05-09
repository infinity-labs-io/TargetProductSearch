using System;
using System.Runtime.Serialization;

namespace InfinityLabs.Target.ProductSearch.Api.Exceptions
{
    public class PricingNotFoundException : Exception
    {
        public PricingNotFoundException()
        {
        }

        public PricingNotFoundException(string message) : base(message)
        {
        }

        public PricingNotFoundException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected PricingNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}