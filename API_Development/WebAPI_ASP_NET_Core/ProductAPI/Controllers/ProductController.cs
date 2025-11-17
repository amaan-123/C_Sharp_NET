using Microsoft.AspNetCore.Mvc;

namespace ProductAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductsController : ControllerBase
    {

        [HttpGet]
        public IActionResult GetAllProducts()
        {
            var products = new List<object>
        {
            new { Id = 1, Name = "Laptop", Price = 999.99m },
            new { Id = 2, Name = "Mouse", Price = 29.99m }
        };
            return Ok(products);
        }

        // GET: api/products/5
        [HttpGet("{id}")]
        public IActionResult GetProduct(int id)
        {
            if (id <= 0)
                return BadRequest("Invalid product ID");

            var product = new { Id = id, Name = "Sample Product", Price = 99.99m };
            return Ok(product);
        }

        // POST: api/products
        [HttpPost]
        public IActionResult CreateProduct([FromBody] object product)
        {
            // Logic to create product
            return CreatedAtAction(nameof(GetProduct), new { id = 1 }, product);
        }

        // PUT: api/products/5
        [HttpPut("{id}")]
        public IActionResult UpdateProduct(int id, [FromBody] object product)
        {
            // Logic to update product
            return NoContent();
        }

        // DELETE: api/products/5
        [HttpDelete("{id}")]
        public IActionResult DeleteProduct(int id)
        {
            // Logic to delete product
            return NoContent();
        }
    }
}
