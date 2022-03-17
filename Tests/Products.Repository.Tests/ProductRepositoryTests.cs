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
            Assert.Throws<ArgumentNullException>(() =>
            {
                new ProductRepository(null);
            });
        }

        //[Fact]
        //public void When_ProductsController_Receives_Valid_Arguments()
        //{
        //    // Arrange
        //    var mockedProductRepository = new Mock<IProductRepository>();
        //    var mockedILogger = new Mock<ILogger<ProductsController>>();

        //    var productsController = new ProductsController(mockedProductRepository.Object, mockedILogger.Object);

        //    Assert.NotNull(productsController);
        //}

    }
}