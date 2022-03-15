using Microsoft.AspNetCore.Mvc;
using Products.Core.Entities;
using Products.Core.Interfaces;
using System.Net;

namespace Products.API.Controllers
{

    /// <summary>
    /// Description: Products Controller to handle all the requests related to products
    /// </summary>
    [ApiController]
    [Route("api/v1/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly IProductRepository _repository;
        private readonly ILogger<ProductsController> _logger;

        /// <summary>
        /// Description: To be done
        /// </summary>
        /// <param name="repository">IProductRepository through dependency injection</param>
        /// <param name="logger">ILogger<ProductsController> through dependency injection</param>
        /// <exception cref="ArgumentNullException">Throws the exception, when any of the dependencies are missing</exception>
        public ProductsController(IProductRepository repository, ILogger<ProductsController> logger)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));

            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        /// <summary>
        /// Description: Retrieves all the products. Expensive call ;)
        /// </summary>
        /// <returns>Returns all the products</returns>
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<Product>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<Product>>> GetProducts()
        {
            var products = await _repository.GetProducts();

            return Ok(products);
        }

        /// <summary>
        /// Description: Retrieves a product by id.
        /// </summary>
        /// <param name="id">Product Id to be searched</param>
        /// <returns>Task<ActionResult<Product>></returns>
        [HttpGet("{id:length(24)}", Name = "GetProduct")]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(Product), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<Product>> GetProductById(string id)
        {
            var product = await _repository.GetProduct(id);

            if (product == null)
            {
                _logger.LogError($"Product with id: {id}, not found.");
                return NotFound();
            }

            return Ok(product);
        }

        /// <summary>
        /// Description: Retrieves set of Products by category.
        /// </summary>
        /// <param name="category">Category of products to be retrieved</param>
        /// <returns>Task<ActionResult<IEnumerable<Product>>></returns>
        [Route("[action]/{category}", Name = "GetProductByCategory")]
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<Product>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<Product>>> GetProductByCategory(string category)
        {
            var products = await _repository.GetProductsByCategory(category);

            return Ok(products);
        }

        /// <summary>
        /// Description: Retrieves set of Products by name.
        /// </summary>
        /// <param name="name">Name to be searched in the projects</param>
        /// <returns>Task<ActionResult<IEnumerable<Product>>></returns>
        [Route("[action]/{name}", Name = "GetProductByName")]
        [HttpGet]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(IEnumerable<Product>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<Product>>> GetProductByName(string name)
        {
            var items = await _repository.GetProductByName(name);
            if (items == null)
            {
                _logger.LogError($"Products with name: {name} not found.");
                return NotFound();
            }

            return Ok(items);
        }

        /// <summary>
        /// Description: Create a new product.
        /// </summary>
        /// <param name="product">Details of the Product to be created</param>
        /// <returns>Task<ActionResult<Product>></returns>
        [HttpPost]
        [ProducesResponseType(typeof(Product), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<Product>> CreateProduct([FromBody] Product product)
        {
            await _repository.CreateProduct(product);

            return CreatedAtRoute("GetProduct", new { id = product.Id }, product);
        }

        /// <summary>
        /// Description: Update an existing product.
        /// </summary>
        /// <param name="product">Details of the existing Product to be modified</param>
        /// <returns>Task<IActionResult></returns>
        [HttpPut]
        [ProducesResponseType(typeof(Product), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> UpdateProduct([FromBody] Product product)
        {
            return Ok(await _repository.UpdateProduct(product));
        }

        /// <summary>
        /// Description: Delete an existing product.
        /// </summary>
        /// <param name="id">Id of the existing Product</param>
        /// <returns>Task<IActionResult></returns>
        [HttpDelete("{id:length(24)}", Name = "DeleteProduct")]
        [ProducesResponseType(typeof(Product), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> DeleteProductById(string id)
        {
            return Ok(await _repository.DeleteProduct(id));
        }

    }

}
