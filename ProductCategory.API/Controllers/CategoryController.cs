using Microsoft.AspNetCore.Mvc;
using ProductCategory.Application.Interface;
using ProductCategory.Domain.Dto;

namespace ProductCategory.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoryController(ICategoryService categoryService) : ControllerBase
    {
        private readonly ICategoryService _categoryService = categoryService;

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] int pageNumber, [FromQuery] int pageSize)
        {
            var categories = await _categoryService.Get(pageNumber, pageSize);
            if (categories.Categories == null || !categories.Categories.Any())
                return NotFound();

            return Ok(categories);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var category = await _categoryService.GetById(id);
            if (category == null)
                return NotFound();

            return Ok(category);
        }

        [HttpGet("search")]
        public async Task<IActionResult> GetByName([FromQuery] string name, [FromQuery] int pageNumber, [FromQuery] int pageSize)
        {
            var categories = await _categoryService.GetByName(name, pageNumber, pageSize);
            if (categories.Categories == null || !categories.Categories.Any())
                return NotFound();

            return Ok(categories);
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CategoryDto categoryDto)
        {
            var result = await _categoryService.Add(categoryDto);
            if (result == false)
                return BadRequest();

            return Ok(categoryDto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] CategoryDto categoryDto)
        {
            var result = await _categoryService.Update(id, categoryDto);
            if (result == false)
                return BadRequest();

            return Ok(categoryDto);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _categoryService.Delete(id);
            if (result == false)
                return BadRequest();

            return Ok();
        }

    }
}
