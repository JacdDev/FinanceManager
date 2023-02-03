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
            var jsonResponse = JsonNode.Parse(response.Content.ReadAsStream());

            if (response.IsSuccessStatusCode)
            {
                HttpContext.Response.Cookies.Append("authToken",
                    jsonResponse?["authToken"]?.ToString() ?? "",
                    new CookieOptions()
                    {
                        Expires = request.RememberMe ? DateTimeOffset.MaxValue : null,
                    });

                HttpContext.Response.Cookies.Append("rememberMe",
                    request.RememberMe?"1":"0",
                    new CookieOptions()
                    {
                        Expires = request.RememberMe ? DateTimeOffset.MaxValue : null,
                    });

                return Redirect("/");
            }

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
            var jsonResponse = JsonNode.Parse(response.Content.ReadAsStream());

            if (response.IsSuccessStatusCode)
            {
                HttpContext.Response.Cookies.Append(
                    "authToken", 
                    jsonResponse?["authToken"]?.ToString() ?? "",
                    new CookieOptions()
                    {
                        Expires = request.RememberMe ? DateTimeOffset.MaxValue : null,
                    });

                HttpContext.Response.Cookies.Append("rememberMe",
                    request.RememberMe ? "1" : "0",
                    new CookieOptions()
                    {
                        Expires = request.RememberMe ? DateTimeOffset.MaxValue : null,
                    });

                return Redirect("/");
            }

            var errorType = jsonResponse?["errors"]?.AsObject().FirstOrDefault().Key;
            ViewData.Add("Error", errorType);
            ViewData.Add("Email", request.Email);

            return View();
        }

        public IActionResult Logout()
        {
            HttpContext.Response.Cookies.Delete("authToken");
            return Redirect("/");
        }
    }
}
