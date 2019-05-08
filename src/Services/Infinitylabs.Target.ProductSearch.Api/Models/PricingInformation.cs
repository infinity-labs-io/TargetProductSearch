using InfinityLabs.Target.ProductSearch.Api.Enums;

namespace InfinityLabs.Target.ProductSearch.Api.Models
{
    public class PricingInformation : BaseModel
    {
        public CurrencyCode CurrencyCode { get; set; }
        
        public decimal Value { get; set; }
    }
}