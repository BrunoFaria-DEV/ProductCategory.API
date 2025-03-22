using Microsoft.AspNetCore.Mvc;
using ProductCategory.Application.Interface;
using ProductCategory.Domain.Dto;

namespace ProductCategory.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController(IProductService productService) : ControllerBase
    {
        private readonly IProductService _productService = productService;

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var products = await _productService.Get();
            if (products == null || !products.Any()) 
                return NotFound();
            
            return Ok( products );
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var product = await _productService.GetById(id);
            if (product == null)
                return NotFound();

            return Ok(product);
        }

        [HttpGet("get_by_name/{name}")]
        public async Task<IActionResult> GetByName(string name)
        {
            var products = await _productService.GetByName(name);
            if (products == null || !products.Any())
                return NotFound();

            return Ok(products);
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] ProductDto productDto)
        {
            var result = await _productService.Add(productDto);
            if (result == false)
                return BadRequest();
            
            return Ok( productDto );
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] ProductDto productDto)
        {
            var result = await _productService.Update(id, productDto);
            if (result == false)
                return BadRequest();

            return Ok( productDto );
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _productService.Delete(id);
            if (result == false)
                return BadRequest();

            return Ok();
        }
    }
}
