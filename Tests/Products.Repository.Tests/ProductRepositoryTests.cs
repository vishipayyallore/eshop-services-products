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

        private Mock<IAsyncCursor<Product>>? asyncCursor;
        private Mock<IMongoCollection<Product>>? mockIMongoCollection;
        private Mock<IProductContext>? mockedProductContext;

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
            List<Product> _productsList = GetDummyProducts();

            // Arrange
            asyncCursor = new Mock<IAsyncCursor<Product>>();
            mockIMongoCollection = new Mock<IMongoCollection<Product>>();
            mockedProductContext = new Mock<IProductContext>();

            asyncCursor.SetupSequence(_async => _async.MoveNextAsync(default))
                .Returns(Task.FromResult(true))
                .Returns(Task.FromResult(false));
            asyncCursor.SetupGet(_async => _async.Current).Returns(_productsList);

            mockIMongoCollection.Setup(_collection => _collection.FindAsync(
                 Builders<Product>.Filter.Empty,
                 It.IsAny<FindOptions<Product>>(),
                 default))
               .ReturnsAsync(asyncCursor.Object);

            //Act 
            mockedProductContext.SetupGet(x => x.Products).Returns(mockIMongoCollection.Object);

            var productRepository = new ProductRepository(mockedProductContext.Object);
            var productsRetrieved = await productRepository.GetProducts();

            //Assert 
            Assert.Equal(_productsList.Count, productsRetrieved.Count());
        }

        [Fact]
        public async void When_ProductRepository_GetProducts_IsCalled_Returns_EmptyList()
        {
            List<Product> _productsList = GetEmptyProductsList();

            // Arrange
            asyncCursor = new Mock<IAsyncCursor<Product>>();
            mockIMongoCollection = new Mock<IMongoCollection<Product>>();
            mockedProductContext = new Mock<IProductContext>();

            asyncCursor.SetupSequence(_async => _async.MoveNextAsync(default))
                .Returns(Task.FromResult(true))
                .Returns(Task.FromResult(false));
            asyncCursor.SetupGet(_async => _async.Current).Returns(_productsList);

            mockIMongoCollection.Setup(_collection => _collection.FindAsync(
                 Builders<Product>.Filter.Empty,
                 It.IsAny<FindOptions<Product>>(),
                 default))
               .ReturnsAsync(asyncCursor.Object);

            //Act 
            mockedProductContext.SetupGet(x => x.Products).Returns(mockIMongoCollection.Object);

            var productRepository = new ProductRepository(mockedProductContext.Object);
            var productsRetrieved = await productRepository.GetProducts();

            //Assert 
            Assert.Equal(_productsList.Count, productsRetrieved.Count());
        }

        [Fact]
        public async void When_ProductRepository_GetProductById_IsCalled_WithValidId_Returns_Data()
        {
            List<Product> _productsList = GetDummyProducts();

            // Arrange
            asyncCursor = new Mock<IAsyncCursor<Product>>();
            mockIMongoCollection = new Mock<IMongoCollection<Product>>();
            mockedProductContext = new Mock<IProductContext>();

            asyncCursor.SetupSequence(_async => _async.MoveNextAsync(default))
                .Returns(Task.FromResult(true))
                .Returns(Task.FromResult(false));
            asyncCursor.SetupGet(_async => _async.Current).Returns(_productsList);

            mockIMongoCollection.Setup(_collection => _collection.FindAsync(
                 Builders<Product>.Filter.Empty,
                 It.IsAny<FindOptions<Product>>(),
                 default))
               .ReturnsAsync(asyncCursor.Object);

            //Act 
            mockedProductContext.SetupGet(x => x.Products).Returns(mockIMongoCollection.Object);

            var productRepository = new ProductRepository(mockedProductContext.Object);
            string productId = "602d2149e773f2a3990b47f5";
            // var productRetrieved = await productRepository.GetProduct(productId);

            ////Assert 
            //Assert.NotNull(productRetrieved);
        }

        private static List<Product> GetDummyProducts()
        {
            return new List<Product>()
            {
                new Product { Id = "602d2149e773f2a3990b47f5", Name = "IPhone" },
                new Product { Id = "602d2149e773f2a3990b47f6", Name = "YourPhone" }
            };
        }

        private static List<Product> GetEmptyProductsList()
        {
            return new List<Product>()
            {
            };
        }

    }

}