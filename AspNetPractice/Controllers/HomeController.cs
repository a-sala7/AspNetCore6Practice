using Microsoft.AspNetCore.Mvc;

namespace AspNetPractice.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
