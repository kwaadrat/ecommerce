using Microsoft.AspNetCore.Mvc;
using System.Linq;
using ecommerce.Models;

namespace ecommerce.Controllers
{
    public class OrderController : Controller
    {
        static List<OrdersViewModel> Orders = new List<OrdersViewModel>();

        [HttpGet]
        public IActionResult Index(string searchString)
        {
            var filteredOrders = string.IsNullOrEmpty(searchString)
                ? Orders
                : Orders.Where(s => s.User.Contains(searchString, StringComparison.OrdinalIgnoreCase) ||
                                      s.Price.Contains(searchString)).ToList();

            ViewBag.SearchString = searchString;
            return View(filteredOrders);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(OrdersViewModel Order)
        {
            if (ModelState.IsValid)
            {
                Order.Id = Orders.Any() ? Orders.Max(x => x.Id) + 1 : 1;
                Orders.Add(Order);
                return RedirectToAction("Index");
            }

            return View();
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var Order = Orders.FirstOrDefault(s => s.Id == id);
            if (Order == null) return NotFound();

            return View(Order);
        }

        [HttpPost]
        public IActionResult Edit(OrdersViewModel updatedOrder)
        {
            var Order = Orders.FirstOrDefault(s => s.Id == updatedOrder.Id);
            if (Order == null) return NotFound();

            if (ModelState.IsValid)
            {
                Order.User = updatedOrder.User;
                Order.Price = updatedOrder.Price;

                return RedirectToAction("Index");
            }

            return View(updatedOrder);
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var Order = Orders.FirstOrDefault(s => s.Id == id);
            if (Order == null) return NotFound();

            return View(Order);
        }

        [HttpPost]
        public IActionResult DeleteConfirmed(int id)
        {
            var Order = Orders.FirstOrDefault(s => s.Id == id);
            if (Order == null) return NotFound();

            Orders.Remove(Order);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            var Order = Orders.FirstOrDefault(s => s.Id == id);
            if (Order == null) return NotFound();

            return View(Order);
        }
    }
}