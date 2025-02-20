using Microsoft.AspNetCore.Mvc;
using Data.Entities;

namespace ecommerce.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Produces("application/json")]
    public class ProductApiController : ControllerBase
    {
        private readonly EcommerceContext _context;

        public ProductApiController(EcommerceContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetProducts()
        {
            var products = await _context.Products.ToListAsync();
            return Ok(products);
        }
    }
}
