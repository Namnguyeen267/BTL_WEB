using BTL_WEB.Data;
using BTL_WEB.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace BTL_WEB.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly DtbContext _context;

        public HomeController(DtbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Login() 
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(string Username,string Password)
        {
				var user = _context.Accounts.Include(u=>u.Role).FirstOrDefault(u => u.Username == Username && u.Password == Password);
				if (user != null)
				{
                    if(user.RoleID == 1)
                    {
                        return RedirectToAction("Index","Home" /*new {area="Admin"}*/);
                    }
                    else
                    {
                        return RedirectToAction("Index", "Home");
                    }
				}
                else
                {
                    return RedirectToAction("Login", "Home");
                }
			
        }
        public IActionResult Register()
        {
            return View();
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
