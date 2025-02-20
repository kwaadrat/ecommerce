
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Web.Views.Shared.Components
{
    public class CartSummaryViewComponent : ViewComponent
    {
        private readonly EcommerceContext _context;

        public CartSummaryViewComponent(EcommerceContext context)
        {
            _context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var userId = HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (userId == null)
            {
                return View(0);
            }

            var orderCount = _context.Orders.Count(o => o.UserId == userId);

            return View(orderCount);
        }
    }
}
