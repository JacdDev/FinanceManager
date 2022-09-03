using Microsoft.AspNetCore.Mvc;

namespace FinanceManager.UI.Controllers.View
{
    [Route("/")]
    [Route("[controller]/[action]")]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
