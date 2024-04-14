using Microsoft.AspNetCore.Mvc;

namespace BTL_WEB.Controllers
{
    public class TennisController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
