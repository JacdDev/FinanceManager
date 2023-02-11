using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FinanceManager.UI.Controllers.View
{
    [Authorize]
    [Route("[controller]/[action]")]
    public class SettingsController : Controller
    {
        // GET: SettingsController
        public ActionResult Index()
        {
            return View();
        }
    }
}
