using AutoMapper;
using MongoDB.Driver;
using Products.Core.Dtos;
using Products.Core.Entities;
using Products.Core.Interfaces;

namespace Products.Repository
{

    public class ProductRepository : IProductRepository
    {
        private readonly IProductContext _productContext;
        private readonly IMapper _mapper;

        public ProductRepository(IProductContext? context, IMapper? mapper)
        {
            _productContext = context ?? throw new ArgumentNullException(nameof(context));

            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<IEnumerable<ProductDto>> GetProducts()
        {
            var products = await _productContext.Products
                                    .Find(Builders<Product>.Filter.Empty)
                                    .ToListAsync();

            return _mapper.Map<List<ProductDto>>(products);
        }

        public async Task<Product> GetProduct(string id)
        {
            return await _productContext
                           .Products
                           .Find(p => p.Id == id)
                           .FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Product>> GetProductsByName(string name)
        {
            FilterDefinition<Product> filter = Builders<Product>.Filter.Regex("Name", name);

            return await _productContext
                            .Products
                            .Find(filter)
                            .ToListAsync();
        }

        public async Task<IEnumerable<Product>> GetProductsByCategory(string categoryName)
        {
            FilterDefinition<Product> filter = Builders<Product>.Filter.Eq(p => p.Category, categoryName);

            return await _productContext
                            .Products
                            .Find(filter)
                            .ToListAsync();
        }

        public async Task CreateProduct(Product product)
        {
            // TODO: Verify Auto Generation on Id. Also, Return the Product
            await _productContext.Products.InsertOneAsync(product);
        }

        public async Task<bool> UpdateProduct(Product product)
        {
            var updateResult = await _productContext
                                        .Products
                                        .ReplaceOneAsync(filter: g => g.Id == product.Id, replacement: product);

            return updateResult.IsAcknowledged
                    && updateResult.ModifiedCount > 0;
        }

        public async Task<bool> DeleteProduct(string id)
        {
            FilterDefinition<Product> filter = Builders<Product>.Filter.Eq(p => p.Id, id);

            DeleteResult deleteResult = await _productContext
                                                .Products
                                                .DeleteOneAsync(filter);

            return deleteResult.IsAcknowledged
                && deleteResult.DeletedCount > 0;
        }

    }

}
