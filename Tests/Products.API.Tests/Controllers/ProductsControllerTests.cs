using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using Products.API.Controllers;
using Products.Core.Entities;
using Products.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Products.API.Tests.Controllers
{

    [ExcludeFromCodeCoverage]
    public class ProductsControllerTests : IDisposable
    {

        private readonly Mock<IProductRepository> _mockedProductRepository;
        private readonly Mock<ILogger<ProductsController>> _mockedILogger;

        public ProductsControllerTests()
        {
            _mockedProductRepository = new Mock<IProductRepository>();

            _mockedILogger = new Mock<ILogger<ProductsController>>();
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        [Fact]
        public void When_ProductsController_Receives_Two_Nulls_Arguments()
        {
            _ = Assert.Throws<ArgumentNullException>(() =>
              {
                  _ = new ProductsController(repository: default, logger: default);
              });
        }

        [Fact]
        public void When_ProductsController_Receives_Null_For_ILogger_Argument()
        {
            _ = Assert.Throws<ArgumentNullException>(() =>
              {
                  _ = new ProductsController(_mockedProductRepository.Object, logger: default);
              });
        }

        [Fact]
        public void When_ProductsController_Receives_Valid_Arguments()
        {
            var productsController = new ProductsController(_mockedProductRepository.Object, _mockedILogger.Object);

            Assert.NotNull(productsController);
        }

        [Fact]
        public async void When_ProductsController_GetProducts_IsCalled_Returns_Data()
        {
            _mockedProductRepository.Setup(repo => repo.GetProducts())
                .ReturnsAsync(GetDummyProducts());

            var productsController = new ProductsController(_mockedProductRepository.Object, _mockedILogger.Object);

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
            Product? product = default;

#pragma warning disable CS8620 // Argument cannot be used for parameter due to differences in the nullability of reference types.
            _mockedProductRepository.Setup(repo => repo.GetProduct(It.IsAny<string>()))
                .ReturnsAsync(product);
#pragma warning restore CS8620 // Argument cannot be used for parameter due to differences in the nullability of reference types.

            var productsController = new ProductsController(_mockedProductRepository.Object, _mockedILogger.Object);

            Assert.NotNull(productsController);

            var apiReturnedValue = await productsController.GetProduct("602d2149e773f2a3990b47f5");
            Assert.NotNull(apiReturnedValue);

            _ = Assert.IsType<NotFoundResult>(apiReturnedValue.Result as NotFoundResult);
        }

        [Fact]
        public async void When_ProductsController_GetProductById_IsCalled_Returns_Data()
        {
            _mockedProductRepository.Setup(repo => repo.GetProduct(It.IsAny<string>()))
                .ReturnsAsync(new Product());

            var productsController = new ProductsController(_mockedProductRepository.Object, _mockedILogger.Object);

            Assert.NotNull(productsController);

            var apiReturnedValue = await productsController.GetProduct("602d2149e773f2a3990b47f5");
            Assert.NotNull(apiReturnedValue);

            _ = Assert.IsType<OkObjectResult>(apiReturnedValue.Result as OkObjectResult);
            var productResults = apiReturnedValue.Result as OkObjectResult;

            var productRetrieved = productResults?.Value as Product;
            _ = Assert.IsType<Product>(productRetrieved);
            Assert.Equal("No Name", productRetrieved?.CreatedBy);
        }

        [Fact]
        public async void When_ProductsController_GetProductsByCategory_IsCalled_Returns_DataNotFound()
        {
            IEnumerable<Product> products = new List<Product>();

            _mockedProductRepository.Setup(repo => repo.GetProductsByCategory(It.IsAny<string>()))
                .ReturnsAsync(products);

            var productsController = new ProductsController(_mockedProductRepository.Object, _mockedILogger.Object);

            Assert.NotNull(productsController);

            var apiReturnedValue = await productsController.GetProductsByCategory("DummyCategory");
            Assert.NotNull(apiReturnedValue);

            _ = Assert.IsType<NotFoundResult>(apiReturnedValue.Result as NotFoundResult);
        }

        [Fact]
        public async void When_ProductsController_GetProductsByCategory_IsCalled_Returns_Data()
        {
            _mockedProductRepository.Setup(repo => repo.GetProductsByCategory(It.IsAny<string>()))
                .ReturnsAsync(GetDummyProducts());

            var productsController = new ProductsController(_mockedProductRepository.Object, _mockedILogger.Object);

            Assert.NotNull(productsController);

            var apiReturnedValue = await productsController.GetProductsByCategory("DummyCategory");
            Assert.NotNull(apiReturnedValue);

            _ = Assert.IsType<OkObjectResult>(apiReturnedValue.Result as OkObjectResult);
            var productResults = apiReturnedValue.Result as OkObjectResult;

            var productsRetrieved = productResults?.Value as IEnumerable<Product>;
            _ = Assert.IsType<List<Product>>(productsRetrieved);
            Assert.Equal(2, productsRetrieved?.Count());
        }

        [Fact]
        public async void When_ProductsController_GetProductsByName_IsCalled_Returns_DataNotFound()
        {
            IEnumerable<Product> products = new List<Product>();

            _mockedProductRepository.Setup(repo => repo.GetProductsByName(It.IsAny<string>()))
                .ReturnsAsync(products);

            var productsController = new ProductsController(_mockedProductRepository.Object, _mockedILogger.Object);

            Assert.NotNull(productsController);

            var apiReturnedValue = await productsController.GetProductsByName("DummyProductName");
            Assert.NotNull(apiReturnedValue);

            _ = Assert.IsType<NotFoundResult>(apiReturnedValue.Result as NotFoundResult);
        }

        [Fact]
        public async void When_ProductsController_GetProductsByName_IsCalled_Returns_Data()
        {
            _mockedProductRepository.Setup(repo => repo.GetProductsByName(It.IsAny<string>()))
                .ReturnsAsync(GetDummyProducts());

            var productsController = new ProductsController(_mockedProductRepository.Object, _mockedILogger.Object);

            Assert.NotNull(productsController);

            var apiReturnedValue = await productsController.GetProductsByName("DummyProductName");
            Assert.NotNull(apiReturnedValue);

            _ = Assert.IsType<OkObjectResult>(apiReturnedValue.Result as OkObjectResult);
            var productResults = apiReturnedValue.Result as OkObjectResult;

            var productsRetrieved = productResults?.Value as IEnumerable<Product>;
            _ = Assert.IsType<List<Product>>(productsRetrieved);
            Assert.Equal(2, productsRetrieved?.Count());
        }

        [Fact]
        public async void When_ProductsController_CreateProduct_IsCalled_Creates_Product()
        {
            var product = new Product() { };

            _mockedProductRepository.Setup(repo => repo.CreateProduct(It.IsAny<Product>()))
                .Returns(Task.CompletedTask);

            var productsController = new ProductsController(_mockedProductRepository.Object, _mockedILogger.Object);

            Assert.NotNull(productsController);

            var apiReturnedValue = await productsController.CreateProduct(product);
            Assert.NotNull(apiReturnedValue);

            _ = Assert.IsType<CreatedAtRouteResult>(apiReturnedValue.Result as CreatedAtRouteResult);
            var productResults = apiReturnedValue.Result as CreatedAtRouteResult;
        }

        [Fact]
        public async void When_ProductsController_UpdateProduct_IsCalled_Updates_Product()
        {
            var product = new Product() { };

            _mockedProductRepository.Setup(repo => repo.UpdateProduct(It.IsAny<Product>()))
                .Returns(Task.FromResult(true));

            var productsController = new ProductsController(_mockedProductRepository.Object, _mockedILogger.Object);

            Assert.NotNull(productsController);

            var updateProductResults = await productsController.UpdateProduct(product);
            Assert.NotNull(updateProductResults);

            _ = Assert.IsType<OkObjectResult>(updateProductResults as OkObjectResult);
            var productResults = updateProductResults as OkObjectResult;
            Assert.True(productResults?.Value is bool);
        }

        [Fact]
        public async void When_ProductsController_DeleteProductById_IsCalled_Deletes_Product()
        {
            _mockedProductRepository.Setup(repo => repo.DeleteProduct(It.IsAny<string>()))
                .Returns(Task.FromResult(true));

            var productsController = new ProductsController(_mockedProductRepository.Object, _mockedILogger.Object);
            Assert.NotNull(productsController);

            var deleteProductResults = await productsController.DeleteProductById("DummyId");
            Assert.NotNull(deleteProductResults);

            _ = Assert.IsType<OkObjectResult>(deleteProductResults as OkObjectResult);
            var productResults = deleteProductResults as OkObjectResult;
            Assert.True(productResults?.Value is bool);
        }

        private static IEnumerable<Product> GetDummyProducts()
        {
            return new List<Product>()
            {
                new Product { Id = "602d2149e773f2a3990b47f5", Name = "IPhone", CreatedBy = "No Name", ModifiedBy = "No Name" },
                new Product { Id = "602d2149e773f2a3990b47f6", Name = "YourPhone", CreatedBy = "No Name", ModifiedBy = "No Name" }
            };
        }

    }

}
