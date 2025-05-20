using Microsoft.AspNetCore.Mvc;
using MvcSmartStore.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MvcSmartStore.Data;
using MvcSmartStore.Models;

namespace MvcSmartStore.Controllers
{
    public class OrderController : Controller
    {
        private readonly AppDbContext _db;
        public OrderController(AppDbContext db)
        {
            _db = db;
        }
        public IActionResult ShowCart()
        {
            var userId = HttpContext.Session.GetInt32("UserId");
            var user = _db.Users.FirstOrDefault(r => r.Id == userId);

            if (user == null)
            {
                TempData["PopUpMessage"] = "First login to add to cart.";
                return RedirectToAction("All", "Smartphone");
            }

            var orderitems = _db.Orders
                .Where(r => r.UserId == user.Id)
                .Include(r=>r.Smartphone)
                .ToList();

            return View(orderitems);

        }

        public IActionResult AddToCart(int id)
        {
            var check = HttpContext.Session.GetInt32("UserId");
            if (check == null)
            {
                TempData["PopUpMessage"] = "First Log in.";
                return RedirectToAction("All", "Smartphone");
            }
            var order = new Order
            {
                UserId = check.Value,
                SmartphoneId = id,
                OrderDate = DateTime.Now
            };

            _db.Orders.Add(order);
            _db.SaveChanges();

            return RedirectToAction("All", "Smartphone");
        }
        public IActionResult RemoveFromCart(int id)
        {
            var userId = HttpContext.Session.GetInt32("UserId");
            if (userId == null)
            {
                return BadRequest("You must login first to remove a product from cart");
            }

            var order = _db.Orders.FirstOrDefault(o => o.Id == id && o.UserId == userId.Value);
            if (order != null)
            {
                _db.Orders.Remove(order);
                _db.SaveChanges();
            }

            return RedirectToAction("ShowCart");
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
