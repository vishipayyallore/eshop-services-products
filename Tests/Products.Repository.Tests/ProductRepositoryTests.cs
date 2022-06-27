using AutoMapper;
using MongoDB.Driver;
using Moq;
using Products.Core.Dtos;
using Products.Core.Entities;
using Products.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Products.Repository.Tests
{
    [ExcludeFromCodeCoverage]
    public class ProductRepositoryTests : IDisposable
    {

        private Mock<IAsyncCursor<Product>>? asyncCursor;
        private Mock<IMongoCollection<Product>>? mockIMongoCollection;
        private Mock<IProductContext>? mockedProductContext;
        private Mock<IMapper>? mockedMapper;

        public ProductRepositoryTests()
        {
            mockedProductContext = new Mock<IProductContext>();
            mockedMapper = new Mock<IMapper>();
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        [Fact]
        public void When_ProductRepository_Receives_Two_Null_Argument()
        {
            _ = Assert.Throws<ArgumentNullException>(() =>
              {
                  _ = new ProductRepository(default, default);
              });
        }

        [Fact]
        public void When_ProductRepository_Receives_Null_Argument()
        {
            _ = Assert.Throws<ArgumentNullException>(() =>
            {
                _ = new ProductRepository(mockedProductContext?.Object, default);
            });
        }

        [Fact]
        public void When_ProductRepository_Receives_Valid_Arguments()
        {
            var productRepository = new ProductRepository(mockedProductContext?.Object, mockedMapper?.Object);

            Assert.NotNull(productRepository);
        }

        [Fact]
        public async void When_ProductRepository_GetProducts_IsCalled_ReturnsData()
        {
            List<Product> _productsList = GetDummyProducts();
            List<ProductDto> _productsListDto = GetDummyProductsDto();

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
            mockedMapper?.Setup(x => x.Map<List<ProductDto>>(It.IsAny<List<Product>>())).Returns(_productsListDto);

            var productRepository = new ProductRepository(mockedProductContext?.Object, mockedMapper?.Object);
            var productsRetrieved = await productRepository.GetProducts();

            //Assert 
            Assert.Equal(_productsList.Count, productsRetrieved.Count());
        }

        [Fact]
        public async void When_ProductRepository_GetProducts_IsCalled_Returns_EmptyList()
        {
            List<Product> _productsList = GetEmptyProductsList();
            List<ProductDto> _productsListDto = GetEmptyProductsDtoList();

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
            mockedMapper?.Setup(x => x.Map<List<ProductDto>>(It.IsAny<List<Product>>())).Returns(_productsListDto);

            var productRepository = new ProductRepository(mockedProductContext?.Object, mockedMapper?.Object);
            var productsRetrieved = await productRepository.GetProducts();

            //Assert 
            Assert.Equal(_productsList.Count, productsRetrieved.Count());
        }

        [Fact]
        public async void When_ProductRepository_GetProductById_IsCalled_WithValidId_Returns_Data()
        {
            List<Product> _productsList = GetDummyProducts();
            string expectedId = _productsList[1].Id ?? string.Empty;
            List<Product> _expectedResultsList = _productsList.Where(p => p.Id == expectedId).ToList();

            // Arrange
            asyncCursor = new Mock<IAsyncCursor<Product>>();
            mockIMongoCollection = new Mock<IMongoCollection<Product>>();
            mockedProductContext = new Mock<IProductContext>();

            asyncCursor.SetupSequence(_async => _async.MoveNextAsync(default))
                .Returns(Task.FromResult(true))
                .Returns(Task.FromResult(false));
            asyncCursor.SetupGet(_async => _async.Current).Returns(_expectedResultsList);

            mockIMongoCollection.Setup(_collection => _collection.FindAsync(
                 It.IsAny<FilterDefinition<Product>>(),
                 It.IsAny<FindOptions<Product>>(),
                 default))
               .ReturnsAsync(asyncCursor.Object);

            //Act 
            mockedProductContext.SetupGet(x => x.Products).Returns(mockIMongoCollection.Object);

            var productRepository = new ProductRepository(mockedProductContext?.Object, mockedMapper?.Object);
            var received = await productRepository.GetProduct(expectedId!);

            //Assert 
            Assert.NotNull(received);
            Assert.Equal(expectedId, received.Id);
        }

        [Fact]
        public async void When_ProductRepository_GetProductsByName_IsCalled_WithValid_Name_Returns_Data()
        {
            List<Product> _productsList = GetDummyProducts();
            string expectedName = _productsList[1].Name!;
            List<Product> _expectedResultsList = _productsList.Where(p => p.Name == expectedName).ToList();

            // Arrange
            asyncCursor = new Mock<IAsyncCursor<Product>>();
            mockIMongoCollection = new Mock<IMongoCollection<Product>>();
            mockedProductContext = new Mock<IProductContext>();

            asyncCursor.SetupSequence(_async => _async.MoveNextAsync(default))
                .Returns(Task.FromResult(true))
                .Returns(Task.FromResult(false));
            asyncCursor.SetupGet(_async => _async.Current).Returns(_expectedResultsList);

            mockIMongoCollection.Setup(_collection => _collection.FindAsync(
                 It.IsAny<FilterDefinition<Product>>(),
                 It.IsAny<FindOptions<Product>>(),
                 default))
               .ReturnsAsync(asyncCursor.Object);

            //Act 
            mockedProductContext.SetupGet(x => x.Products).Returns(mockIMongoCollection.Object);

            var productRepository = new ProductRepository(mockedProductContext?.Object, mockedMapper?.Object);
            var received = await productRepository.GetProductsByName(_productsList[1].Name!);

            //Assert 
            Assert.NotNull(received);

            Assert.Equal(expectedName, received.FirstOrDefault()?.Name);
        }

        [Fact]
        public async void When_ProductRepository_GetProductsByName_IsCalled_WithValid_Names_Returns_Data()
        {
            List<Product> _productsList = GetDummyProducts();
            string expectedName = _productsList[2].Name!;
            List<Product> _expectedResultsList = _productsList.Where(p => p.Name!.Contains(expectedName)).ToList();

            // Arrange
            asyncCursor = new Mock<IAsyncCursor<Product>>();
            mockIMongoCollection = new Mock<IMongoCollection<Product>>();
            mockedProductContext = new Mock<IProductContext>();

            asyncCursor.SetupSequence(_async => _async.MoveNextAsync(default))
                .Returns(Task.FromResult(true))
                .Returns(Task.FromResult(false));
            asyncCursor.SetupGet(_async => _async.Current).Returns(_expectedResultsList);

            mockIMongoCollection.Setup(_collection => _collection.FindAsync(
                 It.IsAny<FilterDefinition<Product>>(),
                 It.IsAny<FindOptions<Product>>(),
                 default))
               .ReturnsAsync(asyncCursor.Object);

            //Act 
            mockedProductContext.SetupGet(x => x.Products).Returns(mockIMongoCollection.Object);

            var productRepository = new ProductRepository(mockedProductContext?.Object, mockedMapper?.Object);
            var received = await productRepository.GetProductsByName(_productsList[2].Name!);

            //Assert 
            Assert.NotNull(received);

            Assert.Equal(_expectedResultsList.Count, received.Count());
        }


        [Fact]
        public async void Create_Product_And_Inserts_It()
        {
            List<Product> _productsList = GetDummyProducts();

            // Arrange
            mockIMongoCollection = new Mock<IMongoCollection<Product>>();
            mockedProductContext = new Mock<IProductContext>();

            //Act
            Product? _transientProduct = null;
            mockedProductContext.SetupGet(_context => _context.Products).Returns(mockIMongoCollection.Object);
            mockedProductContext.Setup(_context => _context.Products.InsertOneAsync(
                It.IsAny<Product>(),
                It.IsAny<InsertOneOptions>(),
                default))
              .Callback((Product _newProduct, object _options, object _cancellation) =>
              {
                  _transientProduct = _newProduct;
                  _productsList.Add(_newProduct);
              })
              .Returns(Task.FromResult(_transientProduct));
            var productRepository = new ProductRepository(mockedProductContext?.Object, mockedMapper?.Object);

            //precondition
            // Assert productRepository does not contain product with name MyPhone
            var precondition = _productsList.FindAll(x => x.Name == "MyPhone").Count();
            Assert.Equal(0, precondition);

            Product product = new Product
            {
                Name = "MyPhone"
            };
            await productRepository.CreateProduct(product);

            // validation
            // Assert productRepository does contain product with name MyPhon
            var receivedRaw = _productsList.FindAll(x => x.Name == "MyPhone").ToList();
            int received = receivedRaw.Count();
            Assert.Equal(1, received);

            // TODO: Verify Auto Generation on Id. -- this is not currently working
            // var receivedProduct = receivedRaw[0];
            // Assert.NotNull(receivedProduct.Id);
        }


        [Fact]
        public async void Delete_Product_Deletes_It()
        {
            List<Product> _productsList = GetDummyProducts();
            Product product = new Product
            {
                Id = "602d2149e773f2a3990b47f8",
                Name = "MyPhone"
            };
            int expectedLength = _productsList.Count();

            // Arrange
            mockIMongoCollection = new Mock<IMongoCollection<Product>>();
            mockedProductContext = new Mock<IProductContext>();

            //Act
            Product? _transientProduct = null;
            bool transientDeleted = false;
            DeleteResult? transientDeleteResult = new DeleteResult.Acknowledged(0);
            mockedProductContext.SetupGet(_context => _context.Products).Returns(mockIMongoCollection.Object);
            mockedProductContext.Setup(_context => _context.Products.InsertOneAsync(
                It.IsAny<Product>(),
                It.IsAny<InsertOneOptions>(),
                default))
              .Callback((Product _newProduct, object _options, object _cancellation) =>
              {
                  _transientProduct = _newProduct;
                  _productsList.Add(_newProduct);
              })
              .Returns(Task.FromResult(_transientProduct));
            mockedProductContext.Setup(_context => _context.Products.DeleteOneAsync(
                It.IsAny<FilterDefinition<Product>>(),
                default))
              .Callback((FilterDefinition<Product> _filterProducts, object _cancellation) =>
              {
                  _productsList.RemoveAll(item =>
                  {
                      if (transientDeleted) return false;
                      bool matches = item.Id == product.Id;
                      if (matches)
                      {
                          transientDeleted = true;
                          transientDeleteResult = new DeleteResult.Acknowledged(1);
                          return true;
                      }
                      return false;
                  });
              })
              .Returns(() => Task.FromResult(transientDeleteResult));

            var productRepository = new ProductRepository(mockedProductContext?.Object, mockedMapper?.Object);

            //precondition
            // Assert productRepository does not contain product with our product's id
            var precondition1 = _productsList.FindAll(x => x.Id == product.Id).Count();
            Assert.Equal(0, precondition1);

            await productRepository.CreateProduct(product);

            //precondition
            // Assert productRepository now contains product with our product's id
            var precondition = _productsList.FindAll(x => x.Id == product.Id).Count();
            Assert.Equal(1, precondition);

            bool received = await productRepository.DeleteProduct(product.Id);

            // validation
            Assert.True(received);
            Assert.Equal(expectedLength, _productsList.Count());
        }


        [Fact]
        public async void Delete_Product_Returns_False_If_No_Product_Was_Deleted()
        {
            List<Product> _productsList = GetDummyProducts();
            string targetId = "dummy-data";
            int expectedLength = _productsList.Count();

            // Arrange
            mockIMongoCollection = new Mock<IMongoCollection<Product>>();
            mockedProductContext = new Mock<IProductContext>();

            //Act
            bool transientDeleted = false;
            mockedProductContext.SetupGet(_context => _context.Products).Returns(mockIMongoCollection.Object);
            mockedProductContext.Setup(_context => _context.Products.DeleteOneAsync(
                It.IsAny<FilterDefinition<Product>>(),
                default))
              .Callback((FilterDefinition<Product> _filterProducts, object _cancellation) =>
              {
                  _productsList.RemoveAll(item => {
                      if (transientDeleted) return false;
                      bool matches = item.Id == targetId;
                      if (matches)
                      {
                          transientDeleted = true;
                          return true;
                      }
                      return false;
                  });
              })
              .Returns(Task.FromResult((DeleteResult)new DeleteResult.Acknowledged(transientDeleted ? 1 : 0)));

            var productRepository = new ProductRepository(mockedProductContext?.Object, mockedMapper?.Object);

            //precondition
            // Assert productRepository does not contain product with id dummy-data
            var precondition = _productsList.FindAll(x => x.Id == targetId).Count();
            Assert.Equal(0, precondition);

            bool received = await productRepository.DeleteProduct(targetId);

            // validation
            Assert.False(received);
            Assert.Equal(expectedLength, _productsList.Count());
        }


        private static List<Product> GetDummyProducts()
        {
            return new List<Product>()
            {
                new Product { Id = "602d2149e773f2a3990b47f5", Name = "IPhone" },
                new Product { Id = "602d2149e773f2a3990b47f6", Name = "YourPhone" },
                new Product { Id = "602d2149e773f2a3990b47f7", Name = "ourPhone" }
            };
        }

        private static List<ProductDto> GetDummyProductsDto()
        {
            return new List<ProductDto>()
            {
                new ProductDto { Id = "602d2149e773f2a3990b47f5", Name = "IPhone" },
                new ProductDto { Id = "602d2149e773f2a3990b47f6", Name = "YourPhone" },
                new ProductDto { Id = "602d2149e773f2a3990b47f7", Name = "ourPhone" }
            };
        }

        private static List<Product> GetEmptyProductsList()
        {
            return new List<Product>()
            {
            };
        }

        private static List<ProductDto> GetEmptyProductsDtoList()
        {
            return new List<ProductDto>()
            {
            };
        }

    }

}