using Microsoft.AspNetCore.Mvc;
using Products.Core.Entities;
using Products.Core.Interfaces;
using System.Net;

namespace Products.API.Controllers
{

    /// <summary>
    /// Description: To be done
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
        /// <param name="repository"></param>
        /// <param name="logger"></param>
        /// <exception cref="ArgumentNullException"></exception>
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
        /// Description: To be done
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
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
        /// Description: To be done
        /// </summary>
        /// <param name="category"></param>
        /// <returns></returns>
        [Route("[action]/{category}", Name = "GetProductByCategory")]
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<Product>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<Product>>> GetProductByCategory(string category)
        {
            var products = await _repository.GetProductsByCategory(category);

            return Ok(products);
        }

        /// <summary>
        /// Description: To be done
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
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
        /// Description: To be done
        /// </summary>
        /// <param name="product"></param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(typeof(Product), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<Product>> CreateProduct([FromBody] Product product)
        {
            await _repository.CreateProduct(product);

            return CreatedAtRoute("GetProduct", new { id = product.Id }, product);
        }

        /// <summary>
        /// Description: To be done
        /// </summary>
        /// <param name="product"></param>
        /// <returns></returns>
        [HttpPut]
        [ProducesResponseType(typeof(Product), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> UpdateProduct([FromBody] Product product)
        {
            return Ok(await _repository.UpdateProduct(product));
        }

        /// <summary>
        /// Description: To be done
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id:length(24)}", Name = "DeleteProduct")]
        [ProducesResponseType(typeof(Product), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> DeleteProductById(string id)
        {
            return Ok(await _repository.DeleteProduct(id));
        }

    }

}
