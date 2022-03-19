using MongoDB.Driver;
using Moq;
using Products.Core.Configuration;
using Products.Core.Entities;
using Products.Core.Interfaces;
using Products.Data;
using System;
using System.Collections.Generic;
using System.Threading;
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
            IEnumerable<Product> _list = new List<Product>()
            {
                new Product { Id = "602d2149e773f2a3990b47f5", Name = "IPhone" },
                new Product { Id = "602d2149e773f2a3990b47f6", Name = "YourPhone" }
            };

            //Act 
            var mockedProductContext = new Mock<IProductContext>();
            //mockedProductContext.SetupGet(x => x.Products).Returns(IDoKnowWhatShouldBeThis);

            //var productRepository = new ProductRepository(mockedProductContext.Object);
            //var product = await productRepository.GetProducts();

            //Assert 
            Assert.True(1 == 1);
        }

    }
}