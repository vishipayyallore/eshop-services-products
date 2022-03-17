using Microsoft.Extensions.Logging;
using Moq;
using Products.API.Controllers;
using Products.Core.Interfaces;
using System;
using Xunit;

namespace Products.API.Tests.Controllers
{
    public class ProductsControllerTests
    {

        [Fact]
        public void When_ProductsController_Receives_Two_Nulls_Arguments()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                new ProductsController(null, null);
            });
        }

        [Fact]
        public void When_ProductsController_Receives_Null_For_ILogger_Argument()
        {
            // Arrange
            var mockedProductRepository = new Mock<IProductRepository>();

            Assert.Throws<ArgumentNullException>(() =>
            {
                new ProductsController(mockedProductRepository.Object, null);
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
    }
}
