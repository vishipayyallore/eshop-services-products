using Products.Core.Interfaces;

namespace Products.Core.Configuration
{

    public class MongoDbSettings : IMongoDbSettings
    {
        public string ConnectionString { get; set; } = string.Empty;

        public string DatabaseName { get; set; } = string.Empty;

        public string CollectionName { get; set; } = string.Empty;
    }

}
