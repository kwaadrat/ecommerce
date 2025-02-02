using Microsoft.AspNetCore.Mvc;
using System.Linq;
using ecommerce.Models;

namespace ecommerce.Controllers
{
    public class UserController : Controller
    {
        static List<UsersViewModel> Users = new List<UsersViewModel>();

        [HttpGet]
        public IActionResult Index(string searchString)
        {
            var filteredUsers = string.IsNullOrEmpty(searchString)
                ? Users
                : Users.Where(s => s.Name.Contains(searchString, StringComparison.OrdinalIgnoreCase) ||
                                      s.PhoneNumber.Contains(searchString)).ToList();

            ViewBag.SearchString = searchString;
            return View(filteredUsers);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(UsersViewModel User)
        {
            if (ModelState.IsValid)
            {
                User.Id = Users.Any() ? Users.Max(x => x.Id) + 1 : 1;
                Users.Add(User);
                return RedirectToAction("Index");
            }

            return View();
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var User = Users.FirstOrDefault(s => s.Id == id);
            if (User == null) return NotFound();

            return View(User);
        }

        [HttpPost]
        public IActionResult Edit(UsersViewModel updatedUser)
        {
            var User = Users.FirstOrDefault(s => s.Id == updatedUser.Id);
            if (User == null) return NotFound();

            if (ModelState.IsValid)
            {
                User.Name = updatedUser.Name;
                User.Email = updatedUser.Email;
                User.PhoneNumber = updatedUser.PhoneNumber;
                User.Birth = updatedUser.Birth;

                return RedirectToAction("Index");
            }

            return View(updatedUser);
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var User = Users.FirstOrDefault(s => s.Id == id);
            if (User == null) return NotFound();

            return View(User);
        }

        [HttpPost]
        public IActionResult DeleteConfirmed(int id)
        {
            var User = Users.FirstOrDefault(s => s.Id == id);
            if (User == null) return NotFound();

            Users.Remove(User);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            var User = Users.FirstOrDefault(s => s.Id == id);
            if (User == null) return NotFound();

            return View(User);
        }
    }
}