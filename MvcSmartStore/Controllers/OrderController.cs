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
                return RedirectToAction("All", "Smartphone");
            }

            var orderitems = _db.Orders
                .Where(r => r.UserId == user.Id)
                .ToList();

            return View(orderitems);

        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
