using Catalog.API.Entities;
using Catalog.API.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace Catalog.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CatalogController : ControllerBase
    {
        private readonly IProductRespository productRespository;
        private readonly ILogger<CatalogController> logger;

        public CatalogController(IProductRespository productRespository, ILogger<CatalogController> logger)
        {
            this.productRespository = productRespository;
            this.logger = logger;
        }
        [HttpGet]
        [Route("get-all-products")]
        [ProducesResponseType(typeof(IEnumerable<Product>),(int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<Product>>> GetProducts()
        {
            var products = await productRespository.GetProducts();
            return Ok(products);
        }
        [HttpGet("get-products-by-id/{id}")]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(Product), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<Product>> GetProductById(string id)
        {
            var product = await productRespository.GetProductById(id);
            if (product == null)
            {
                logger.LogError($"Product with Id: {id}, not found");
                return NotFound();
            }
            return Ok(product);
        }

        [HttpGet]
        [Route("get-products-by-category-name")]
        [ProducesResponseType(typeof(IEnumerable<Product>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<Product>>> GetProductsByCategory(string categoryName)
        {
            var products = await productRespository.GetProductByCategory(categoryName);
            return Ok(products);
        }
        [HttpPost]
        [Route("create-product")]
        [ProducesResponseType(typeof(Product), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<Product>> CreateProduct([FromBody] Product product)
        {
            await productRespository.CreateProduct(product);
            return CreatedAtRoute("get-products-by-id", new { id = product.Id }, product);
        }
        [HttpPut]
        [Route("update-product")]
        [ProducesResponseType(typeof(Product), (int)HttpStatusCode.OK)]
        // use IActionResult if you don't want to return anything
        public async Task<IActionResult> UpdateProduct([FromBody] Product product)
        {
            return Ok(await productRespository.UpdateProduct(product));
        }
        [HttpDelete("delete-product-by-id/{id:length(24)}")]
        public async Task<IActionResult> DeleteProductById(string id)
        {
            return Ok(await productRespository.DeleteProduct(id));
        }

    }
}
