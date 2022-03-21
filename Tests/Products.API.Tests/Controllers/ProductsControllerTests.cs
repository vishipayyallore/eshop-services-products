using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using Products.API.Controllers;
using Products.Core.Entities;
using Products.Core.Interfaces;
using System;
using System.Collections.Generic;
using Xunit;

namespace Products.API.Tests.Controllers
{
    public class ProductsControllerTests
    {

        [Fact]
        public void When_ProductsController_Receives_Two_Nulls_Arguments()
        {
            _ = Assert.Throws<ArgumentNullException>(() =>
              {
                  _ = new ProductsController(repository: null, logger: null);
              });
        }

        [Fact]
        public void When_ProductsController_Receives_Null_For_ILogger_Argument()
        {
            // Arrange
            var mockedProductRepository = new Mock<IProductRepository>();

            _ = Assert.Throws<ArgumentNullException>(() =>
              {
                  _ = new ProductsController(mockedProductRepository.Object, logger: null);
              });
        }

        [Fact]
        public void When_ProductsController_Receives_Valid_Arguments()
        {
            // Arrange
            var mockedProductRepository = new Mock<IProductRepository>();
            var mockedILogger = new Mock<ILogger<ProductsController>>();

            var productsController = new ProductsController(mockedProductRepository.Object, mockedILogger.Object);

            Assert.NotNull(productsController);
        }

        [Fact]
        public async void When_ProductsController_GetProducts_IsCalled_Returns_Data()
        {
            // Arrange
            var mockedProductRepository = new Mock<IProductRepository>();
            var mockedILogger = new Mock<ILogger<ProductsController>>();

            mockedProductRepository.Setup(repo => repo.GetProducts())
                .ReturnsAsync(GetDummyProducts());

            var productsController = new ProductsController(mockedProductRepository.Object, mockedILogger.Object);

            Assert.NotNull(productsController);
            
            var products = await productsController.GetProducts();
            Assert.NotNull(products);

            // Assert.IsType<OkObjectResult>(products as IEnumerable<Product>);

            // Assert.Equal(2, products);
        }

        private static List<Product> GetDummyProducts()
        {
            return new List<Product>()
            {
                new Product { Id = "602d2149e773f2a3990b47f5", Name = "IPhone" },
                new Product { Id = "602d2149e773f2a3990b47f6", Name = "YourPhone" }
            };
        }
    }

}
