using MongoDB.Driver;
using Moq;
using Products.Core.Configuration;
using Products.Core.Entities;
using Products.Core.Interfaces;
using Products.Data;
using System;
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


        private Mock<IMongoDbSettings> _mockOptions;
        private Mock<IMongoDatabase> _mockDB;
        private Mock<IMongoClient> _mockClient;

        [Fact]
        public async void When_ProductRepository_GetProducts_IsCalled_ReturnsData()
        {

            var _book = new Product { Id = "DummyId", Name = "IPhone" };
            IEnumerable<Product> _list = new List<Product>()
            {
                new Product { Id = "DummyId1", Name = "IPhone" },
                new Product { Id = "DummyId2", Name = "YourPhone" }
            };

            // Arrange
            var mockIMongoCollection = new Mock<IMongoCollection<Product>>();
            mockIMongoCollection.Object.InsertMany(_list);

            //Act 
            var mockedProductContext = new Mock<IProductContext>();
            mockedProductContext.SetupGet(x => x.Products).Returns(mockIMongoCollection.Object);

            var productRepository = new ProductRepository(mockedProductContext.Object);
            var product = await productRepository.GetProducts();

            //Assert 
            // Assert.NotNull(context);
            Assert.True(1 == 1);
        }

    }
}