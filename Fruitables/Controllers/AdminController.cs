using Microsoft.AspNetCore.Mvc;

namespace Fruitables.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
