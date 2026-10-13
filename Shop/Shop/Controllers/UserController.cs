using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Shop.Data;
using Shop.Models;

namespace Shop.Controllers
{
    public class UserController : Controller
    {
        private ApplicationDbContext _db;
        private UserManager<User> _useerManager;
        public UserController(ApplicationDbContext db , UserManager<User> useerManager)
        {
            _db = db;
            _useerManager = useerManager;
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
