using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace FinanceManager.UI.Controllers.View
{
    [Route("/")]
    [Route("[controller]/[action]")]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            HttpContext.Request.Cookies.TryGetValue("authToken", out string? authToken);

            if(authToken.IsNullOrEmpty())
                return View();

            ViewData["authToken"] = authToken;
            return View("UserHome");
        }

    }
}
