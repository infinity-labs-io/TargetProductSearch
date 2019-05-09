using InfinityLabs.Target.ProductSearch.Api.Enums;
using MongoDB.Bson.Serialization.Attributes;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace InfinityLabs.Target.ProductSearch.Api.Models
{
    public class PricingInformation : BaseModel
    {

        [BsonElement("currency_code")]
        [JsonConverter(typeof(StringEnumConverter))]
        public CurrencyCode CurrencyCode { get; set; }

        [BsonElement("value")]
        public decimal Value { get; set; }
    }
}