using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace InfinityLabs.Target.ProductSearch.Api.Models
{
    public abstract class BaseModel
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public int Id { get; set; }
    }
}