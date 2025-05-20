using System.Diagnostics;
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
        //adduser
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
		[HttpPost]
		public IActionResult Register(User user)
        {
            if (_db.Users.Any(r => r.Username == user.Username))
            {
                ModelState.AddModelError("Username", "Username already taken.");
                return View(user);
            }
            if (ModelState.IsValid) 
            {
                _db.Users.Add(user);
                _db.SaveChanges();
                TempData["PopUpMessage"] = "Register succesful.";
                return RedirectToAction("Login");
            }
            return View(user);
        }
        //login
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(User user)
        {
            var login = _db.Users.FirstOrDefault(r=>r.Username ==user.Username && r.Password == user.Password);
            if (login != null)
            {
                HttpContext.Session.SetInt32("UserId", login.Id);
                TempData["PopUpMessage"] = "Login succesful.";
                return RedirectToAction("All", "Smartphone"); 
            }
            TempData["PopUpMessage"] = "Login Error, wrong password or username.";
            return View(user);
        }
        //logout
        public IActionResult Logout()
        {
            var check = HttpContext.Session.GetInt32("UserId");
            if(check!=null)
            {
                HttpContext.Session.Remove("UserId");
                TempData["PopUpMessage"] = "Logout succesful.";
                return RedirectToAction("All", "Smartphone");
            }
            return RedirectToAction("All", "Smartphone");
        }
        public IActionResult Allusers()
        {
            var users = _db.Users.ToList();
            return View(users);
        }
    }
}
