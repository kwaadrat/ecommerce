using Microsoft.AspNetCore.Mvc;

namespace ecommerce.Controllers
{
    public class ProductsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
