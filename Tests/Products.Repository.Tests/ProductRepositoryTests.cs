using MongoDB.Driver;
using Moq;
using Products.Core.Configuration;
using Products.Core.Entities;
using Products.Core.Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;
using Xunit;

namespace Products.Repository.Tests
{
    public class ProductRepositoryTests
    {

        [Fact]
        public void When_ProductRepository_Receives_Null_Argument()
        {
            _ = Assert.Throws<ArgumentNullException>(() =>
              {
                  _ = new ProductRepository(null);
              });
        }

        [Fact]
        public void When_ProductRepository_Receives_Valid_Arguments()
        {
            // Arrange
            var mockedProductContext = new Mock<IProductContext>();

            var productRepository = new ProductRepository(mockedProductContext.Object);

            Assert.NotNull(productRepository);
        }


        [Fact]
        public async void When_ProductRepository_GetProducts_IsCalled_ReturnsData()
        {
            //Mock<IMongoDbSettings> _mockMongoDbSettings;
            //Mock<IMongoDatabase> _mockDB;
            //Mock<IMongoClient> _mockClient;

            //_mockMongoDbSettings = new Mock<IMongoDbSettings>();
            //_mockDB = new Mock<IMongoDatabase>();
            //_mockClient = new Mock<IMongoClient>();

            //var settings = new MongoDbSettings()
            //{
            //    DatabaseName = "TestDB",
            //    CollectionName = "TestProducts",
            //    ConnectionString = "mongodb://tes123 "
            //};

            //_mockMongoDbSettings.Setup(s => s.ConnectionString).Returns(settings.ConnectionString);
            //_mockMongoDbSettings.Setup(s => s.DatabaseName).Returns(settings.DatabaseName);
            //_mockMongoDbSettings.Setup(s => s.CollectionName).Returns(settings.CollectionName);

            //_mockClient.Setup(c => c
            //    .GetDatabase(_mockMongoDbSettings.Object.DatabaseName, null))
            //    .Returns(_mockDB.Object);

            IEnumerable<Product> productsList = new List<Product>()
            {
                new Product {
                    Id = "DummyId",
                    Name = "IPhone" }
            };

            // Arrange
            Mock<IMongoCollection<Product>> _mockProductsCollection = new();
            _mockProductsCollection.Setup(p => p).Returns((IMongoCollection<Product>)productsList);

            var mockedProductContext = new Mock<IProductContext>();
            mockedProductContext.Setup(x => x.Products).Returns(_mockProductsCollection.Object);
            // mockedProductContext.Setup(x => x.Products.Find).Returns(productsList);

            var o = mockedProductContext.Object.Products;

            

            var productRepository = new ProductRepository(mockedProductContext.Object);

            Assert.NotNull(productRepository);

            var products = await productRepository.GetProducts();
        }

    }
}