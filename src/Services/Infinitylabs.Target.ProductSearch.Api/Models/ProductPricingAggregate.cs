namespace InfinityLabs.Target.ProductSearch.Api.Models
{
    public class ProductPricingAggregate : ProductInformation
    {        
        public PricingInformation CurrentPrice { get; set; }
    }
}