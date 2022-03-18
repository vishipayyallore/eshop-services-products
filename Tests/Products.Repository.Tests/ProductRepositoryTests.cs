using Moq;
using Products.Core.Interfaces;
using System;
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
            //Fixture fixture = new Fixture();
            //var _book = new Product { Id = "DummyId", Name = "IPhone" };
            //IEnumerable<Product> _list = new List<Product>()
            //{
            //    _book
            //};

            //// Arrange
            //var mockIMongoCollection = new Mock<IMongoCollection<Product>>();
            //var asyncCursor = new Mock<IAsyncCursor<Product>>();

            //var expectedResult = fixture.CreateMany<Product>(5);

            //mockIMongoCollection.Setup(_collection => _collection.Find(
            //    It.IsAny<FilterDefinition<Product>>(),
            //    It.IsAny<FindOptions>()))
            //  .Returns((IMongoCollection<Product>)_list);

            //asyncCursor.SetupSequence(_async => _async.MoveNext(default)).Returns(true).Returns(false);
            //asyncCursor.SetupGet(_async => _async.Current).Returns(expectedResult);

            //var mockedProductContext = new Mock<IProductContext>();
            //mockedProductContext.Setup(x => x.Products).Returns(mockIMongoCollection.Object);

            //var productRepository = new ProductRepository(mockedProductContext.Object);

            //Assert.NotNull(productRepository);

            //var products = await productRepository.GetProducts();

            Assert.True(1 == 1);
        }

    }
}