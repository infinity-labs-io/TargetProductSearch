using InfinityLabs.Target.ProductSearch.Api.Enums;
using MongoDB.Bson.Serialization.Attributes;

namespace InfinityLabs.Target.ProductSearch.Api.Models
{
    public class PricingInformation : BaseModel
    {

        [BsonElement("currency_code")]
        public CurrencyCode CurrencyCode { get; set; }

        [BsonElement("value")]
        public decimal Value { get; set; }
    }
}