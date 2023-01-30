using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ToysAndGamesAPI.Data;
using ToysAndGamesAPI.DTOs;
using ToysAndGamesAPI.Entities;

namespace ToysAndGamesAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
       
        private readonly IProductRepository _repository;
        private readonly IMapper _mapper;

        public ProductsController( IProductRepository repository, IMapper mapper)
        {
           
            _repository = repository;
            _mapper = mapper;
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
        public async Task<ActionResult<ProductDTO>> AddProduct(ProductDTO product)
        {

            _repository.AddProduct(product);

       
            if (await _repository.SaveAll())
                return Ok();

            return BadRequest("Failed to add product");
        }

        [HttpPatch("updateproduct")]
        public async Task<ActionResult> UpdateProduct(ProductDTO product)
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
