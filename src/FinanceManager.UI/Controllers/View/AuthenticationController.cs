using FinanceManager.UI.Common.Interfaces;
using FinanceManager.UI.Models;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;

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
            {
                return Redirect("/");
            }

            var jsonResponse = JsonNode.Parse(response.Content.ReadAsStream());
            var errorType = jsonResponse?["errors"]?.AsObject().FirstOrDefault().Key;
            ViewData.Add("Error", errorType);
            ViewData.Add("Email", request.Email);

            return View();
        }
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginRequest request)
        {
            var response = await _resourcesService.Login(request);
            if (response.IsSuccessStatusCode)
            {
                return Redirect("/");
            }

            var jsonResponse = JsonNode.Parse(response.Content.ReadAsStream());
            var errorType = jsonResponse?["errors"]?.AsObject().FirstOrDefault().Key;
            ViewData.Add("Error", errorType);
            ViewData.Add("Email", request.Email);

            return View();
        }
    }
}
