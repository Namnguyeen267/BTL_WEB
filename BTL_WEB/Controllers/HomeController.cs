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
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            var user = _context.Accounts.Include(u => u.Role).FirstOrDefault(u => u.Username == model.UserName && u.Password == model.Password);
            if (user != null)
            {
                // Lưu thông tin về vai trò của người dùng vào Session
                if (user.Role != null && user.Role.RoleName == "Admin")
                {
                    // Lưu thông tin về vai trò của người dùng vào Session
                    HttpContext.Session.SetString("UserRole", "Admin");

                    // Chuyển hướng đến action Index của controller Home trong khu vực Admin
                    return RedirectToAction("Index", "Roles", new { area = "Admin" });
                }
                else
                {
                    // Lưu thông tin về vai trò của người dùng vào Session
                    HttpContext.Session.SetString("UserRole", "User");

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
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            HttpContext.Session.Remove("Username");
            return RedirectToAction("Login", "Home");
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
