using FinanceManager.UI.Models;
using Microsoft.AspNetCore.Mvc;

namespace FinanceManager.UI.Controllers.View
{
    [Route("[controller]/[action]")]
    public class AuthenticationController : Controller
    {
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(RegisterRequest RegisterRequest)
        {
            return View();
        }
        public IActionResult Login()
        {
            return View();
        }
    }
}
