using Microsoft.AspNetCore.Mvc;
using MvcSmartStore.Data;

namespace MvcSmartStore.Controllers
{
    public class SmartphoneController : Controller
    {
        private readonly AppDbContext _db;

        public SmartphoneController(AppDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult All()
        {
            var smartphones = _db.Smartphones.ToList();
            return View(smartphones);
        }
    }

}
