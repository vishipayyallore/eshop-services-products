﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using Products.API.Controllers;
using Products.Core.Entities;
using Products.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using Xunit;

namespace Products.API.Tests.Controllers
{

    [ExcludeFromCodeCoverage]
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

            var apiReturnedValue = await productsController.GetProducts();
            Assert.NotNull(apiReturnedValue);

            var productsResults = apiReturnedValue.Result as OkObjectResult;
            var productsList = productsResults?.Value as IEnumerable<Product>;
            _ = Assert.IsType<List<Product>>(productsList);
            Assert.Equal(2, productsList?.Count());
        }

        [Fact]
        public async void When_ProductsController_GetProductById_IsCalled_Returns_DataNotFound()
        {
            // Arrange
            var mockedProductRepository = new Mock<IProductRepository>();
            var mockedILogger = new Mock<ILogger<ProductsController>>();
#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
            Product product = null;
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.

#pragma warning disable CS8620 // Argument cannot be used for parameter due to differences in the nullability of reference types.
            mockedProductRepository.Setup(repo => repo.GetProduct(It.IsAny<string>()))
                .ReturnsAsync(product);
#pragma warning restore CS8620 // Argument cannot be used for parameter due to differences in the nullability of reference types.

            var productsController = new ProductsController(mockedProductRepository.Object, mockedILogger.Object);

            Assert.NotNull(productsController);

            var apiReturnedValue = await productsController.GetProduct("602d2149e773f2a3990b47f5");
            Assert.NotNull(apiReturnedValue);

            _ = Assert.IsType<NotFoundResult>(apiReturnedValue.Result as NotFoundResult);
        }

        [Fact]
        public async void When_ProductsController_GetProductById_IsCalled_Returns_Data()
        {
            // Arrange
            var mockedProductRepository = new Mock<IProductRepository>();
            var mockedILogger = new Mock<ILogger<ProductsController>>();

            mockedProductRepository.Setup(repo => repo.GetProduct(It.IsAny<string>()))
                .ReturnsAsync(new Product());

            var productsController = new ProductsController(mockedProductRepository.Object, mockedILogger.Object);

            Assert.NotNull(productsController);

            var apiReturnedValue = await productsController.GetProduct("602d2149e773f2a3990b47f5");
            Assert.NotNull(apiReturnedValue);

            _ = Assert.IsType<OkObjectResult>(apiReturnedValue.Result as OkObjectResult);
            var productResults = apiReturnedValue.Result as OkObjectResult;

            var productRetrieved = productResults?.Value as Product;
            _ = Assert.IsType<Product>(productRetrieved);
            Assert.Equal("No Name", productRetrieved?.CreatedBy);
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
