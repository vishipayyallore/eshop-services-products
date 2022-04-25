using Microsoft.Extensions.Logging;
using MongoDB.Driver;
using Products.Core.Entities;
using Products.Core.Interfaces;

namespace Products.Data
{

    public class ProductContext : IProductContext
    {
        public IMongoCollection<Product> Products { get; }

        public ProductContext(IMongoDbSettings mongoDbSettings, ILogger<ProductContext> logger)
        {

            logger.Log(LogLevel.Information, "Starting ProductContext::ProductContext().");
            // logger.LogInformation($"{mongoDbSettings.ConnectionString}");

            var client = new MongoClient(mongoDbSettings.ConnectionString);
            var database = client.GetDatabase(mongoDbSettings.DatabaseName);

            Products = database.GetCollection<Product>(mongoDbSettings.CollectionName);

            logger.Log(LogLevel.Information, "Completed ProductContext::Products IMongoCollection.");

            // Seed the required data
            ProductContextSeed.SeedData(Products);
        }
    }

}
