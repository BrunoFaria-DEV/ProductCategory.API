using Microsoft.AspNetCore.Mvc;

namespace ProductCategory.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        [HttpGet]
        public IActionResult Index()
        {
            return NotFound();
        }
    }
}
