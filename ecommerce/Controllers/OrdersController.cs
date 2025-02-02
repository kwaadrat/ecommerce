using Microsoft.AspNetCore.Mvc;

namespace ecommerce.Controllers
{
    public class OrdersController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
