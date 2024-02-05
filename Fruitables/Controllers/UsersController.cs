using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;

namespace Fruitables.Controllers
{
    public class UsersController : Controller
    {
        private readonly UserManager<IdentityUser> _manager;
        public UsersController(UserManager<IdentityUser> userManager)
        {
            _manager = userManager;
        }
        public IActionResult Index()
        {
            var roles = _manager.Users;
            return View(roles);
        }
    }
}
