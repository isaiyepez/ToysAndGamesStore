using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ToysAndGamesAPI.Data;
using ToysAndGamesAPI.Entities;

namespace ToysAndGamesAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
       
        private readonly IProductRepository _repository;

        public ProductsController( IProductRepository repository)
        {
           
            _repository = repository;
        }

        [HttpGet("getproducts")]
        public async Task<IActionResult> GetProducts()
        {
            return Ok(await _repository.AllProducts());

        }
        
        [HttpGet("getproduct/{id}")]
        public async Task<ActionResult<Product>> GetProduct(int id)
        {
            return Ok(await _repository.GetProduct(id));            
        }

        [HttpPost("addproduct")]
        public async Task<ActionResult<Product>> AddProduct(Product product)
        {
            _repository.AddProduct(product);

            if (await _repository.SaveAll())
                return Ok();

            return BadRequest("Failed to add product");
        }

        [HttpPatch("updateproduct")]
        public async Task<ActionResult> UpdateProduct(Product product)
        {
            _repository.UpdateProduct(product);

            if (await _repository.SaveAll())
                return Ok();

            return BadRequest("Failed to update product");
        }

        [HttpDelete("deleteproduct/{id}")]
        public async Task<ActionResult> DeleteProduct(int id)
        {
            _repository.DeleteProduct(id);

            if (await _repository.SaveAll())
                return Ok();

            return BadRequest("Failed to delete product");
        }
    }
}
