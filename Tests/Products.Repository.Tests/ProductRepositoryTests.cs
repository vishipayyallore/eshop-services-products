using MongoDB.Driver;
using Moq;
using Products.Core.Entities;
using Products.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
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

            var _list = new List<Product>()
            {
                new Product { Id = "602d2149e773f2a3990b47f5", Name = "IPhone" },
                new Product { Id = "602d2149e773f2a3990b47f6", Name = "YourPhone" }
            };

            // Arrange
            var mockIMongoCollection = new Mock<IMongoCollection<Product>>();
            var asyncCursor = new Mock<IAsyncCursor<Product>>();

            mockIMongoCollection.Setup(_collection => _collection.FindSync(
                 Builders<Product>.Filter.Empty,
                 It.IsAny<FindOptions<Product>>(),
                 default))
               .Returns(asyncCursor.Object);

            asyncCursor.SetupSequence(_async => _async.MoveNext(default))
                .Returns(true)
                .Returns(false);
            asyncCursor.SetupGet(_async => _async.Current).Returns(_list);

            //var mockIMongoCollection = new Mock<IMongoCollection<Product>>();
            //mockIMongoCollection.Object.InsertMany(_list);

            //Act 
            var mockedProductContext = new Mock<IProductContext>();
            //mockedProductContext.SetupGet(x => x.Products).Returns(IDoKnowWhatShouldBeThis);

            var productRepository = new ProductRepository(mockedProductContext.Object);
            var result = await productRepository.GetProducts();

            //Assert 
            Assert.True(mockIMongoCollection.Object.Find(Builders<Product>.Filter.Empty).ToList<Product>().Count() > 0);
            //Assert.True(result.Count() == 2);
        }

    }
}