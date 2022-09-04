using FinanceManager.UI.Common.Interfaces;
using FinanceManager.UI.Models;
using Microsoft.AspNetCore.Mvc;

namespace FinanceManager.UI.Controllers.View
{
    [Route("[controller]/[action]")]
    public class AuthenticationController : Controller
    {
        private readonly IResourcesService _resourcesService;
        public AuthenticationController(IResourcesService resourcesService)
        {
            _resourcesService = resourcesService;
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterRequest request)
        {
            var response = await _resourcesService.Register(request);
            if (response.IsSuccessStatusCode)
                return Redirect("/");
            return View();
        }
        public IActionResult Login()
        {
            return View();
        }
    }
}
