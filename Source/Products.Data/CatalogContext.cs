using MongoDB.Driver;
using Products.Core.Entities;
using Products.Core.Interfaces;

namespace Products.Data
{

    public class CatalogContext : ICatalogContext
    {
        public IMongoCollection<Product> Products { get; }

        public CatalogContext(IMongoDbSettings mongoDbSettings)
        {
            var client = new MongoClient(mongoDbSettings.ConnectionString);
            var database = client.GetDatabase(mongoDbSettings.DatabaseName);

            Products = database.GetCollection<Product>(mongoDbSettings.CollectionName);

            // Seed the required data
            CatalogContextSeed.SeedData(Products);
        }
    }

}
