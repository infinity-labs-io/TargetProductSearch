namespace InfinityLabs.Target.ProductSearch.Api.Models
{
    public class MongoConfiguration : IMongoConfiguration
    {
        public string ConnectionString { get; set; }

        public string DatabaseName { get; set; }
    }
}