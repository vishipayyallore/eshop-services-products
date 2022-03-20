using MongoDB.Driver;
using Moq;
using Products.Core.Entities;
using Products.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
            var asyncCursor = new Mock<IAsyncCursor<Product>>();

            asyncCursor.SetupSequence(_async => _async.MoveNextAsync(default))
                .Returns(Task.FromResult(true))
                .Returns(Task.FromResult(false));
            asyncCursor.SetupGet(_async => _async.Current).Returns(_list);

            var mockIMongoCollection = new Mock<IMongoCollection<Product>>();
            
            mockIMongoCollection.Setup(_collection => _collection.FindAsync(
                 Builders<Product>.Filter.Empty,
                 It.IsAny<FindOptions<Product>>(),
                 default))
               .ReturnsAsync(asyncCursor.Object);

            //Act 
            var mockedProductContext = new Mock<IProductContext>();
            mockedProductContext.SetupGet(x => x.Products).Returns(mockIMongoCollection.Object);

            var productRepository = new ProductRepository(mockedProductContext.Object);
            var result = await productRepository.GetProducts();

            //Assert 
            Assert.Equal(_list.Count, result.Count());
        }

    }
}