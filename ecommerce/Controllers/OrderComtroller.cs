using Microsoft.AspNetCore.Mvc;
using System.Linq;
using ecommerce.Models;
using System.Security.Claims;

namespace ecommerce.Controllers
{
    public class OrderController : Controller
    {
        private readonly EcommerceContext _context;

        public OrderController(EcommerceContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> AddToOrder(int id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }


            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (userId == null)
            {
                return RedirectToPage("/Account/Login", new { area = "Identity" });
            }


            var order = new OrderEntity
            {
                ProductId = product.Id,
                UserId = userId,
                OrderDate = DateTime.Now,
                IsPaid = false
            };

            _context.Orders.Add(order);
            await _context.SaveChangesAsync();

            return RedirectToAction("Index", "Orders");


        }
        public async Task<IActionResult> Index()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (userId == null)
            {
                return RedirectToPage("/Account/Login", new { area = "Identity" });
            }

            var orders = await _context.Orders
                .Include(o => o.Product)
                .Where(o => o.UserId == userId)
                .ToListAsync();

            return View(orders);
        }

    }
}
