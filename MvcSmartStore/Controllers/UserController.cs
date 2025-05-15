using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MvcSmartStore.Data;
using MvcSmartStore.Models;

namespace MvcSmartStore.Controllers
{
    public class UserController : Controller
    {
        private readonly AppDbContext _db;

        public UserController(AppDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            return View();
        }
        //adduser
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
		[HttpPost]
		public IActionResult Create(User user)
        {
            if(ModelState.IsValid) 
            {
                _db.Users.Add(user);
                _db.SaveChanges();
                return RedirectToAction("Allusers");
            }
            return View(user);
        }
        //deleteuser
        public IActionResult Delete()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Delete(int id)
        {
            var user = _db.Users.FirstOrDefault(r => r.Id == id);
            if(user != null)
            {
                _db.Users.Remove(user);
                _db.SaveChanges();
            }
            return RedirectToAction("Allusers");
        }
        //showallusers
        public IActionResult Allusers()
        {
            var users = _db.Users.ToList();
            return View(users);
        }
    }
}
