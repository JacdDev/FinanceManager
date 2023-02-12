using FinanceManager.UI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace FinanceManager.UI.Controllers.View
{
    [Route("[controller]/[action]")]
    public class AuthenticationController : Controller
    {
        private readonly Api.AuthenticationController _authService;
        public AuthenticationController(Api.AuthenticationController authService)
        {
            _authService = authService;
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterRequest request)
        {
            var response = await _authService.Register(request);

            if (response is OkObjectResult)
            {
                return Redirect("/");
            }

            var errorType = (((response as ObjectResult)?.Value as ProblemDetails)?.Extensions["errors"] as Dictionary<string, List<string>>)?.FirstOrDefault().Key;
            ViewData.Add("Error", errorType);
            ViewData.Add("Email", request.Email);

            return View();
        }
        public IActionResult Login()
        {
            var returnUrl = HttpContext.Request.Query["ReturnUrl"].ToString();
            if (returnUrl.IsNullOrEmpty())
            {
                returnUrl = "/";
            }

            ViewData.Add("ReturnUrl", returnUrl);

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginRequest request)
        {
            var response = await _authService.Login(request);

            if (response is OkObjectResult)
            {
                return Redirect("/");
            }

            var errorType = (((response as ObjectResult)?.Value as ProblemDetails)?.Extensions["errors"] as Dictionary<string, List<string>>)?.FirstOrDefault().Key;
            ViewData.Add("Error", errorType);
            ViewData.Add("Email", request.Email);

            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            var response = await _authService.Logout();

            if (response is OkResult)
            {
                return Redirect("/");
            }

            var errorType = (((response as ObjectResult)?.Value as ProblemDetails)?.Extensions["errors"] as Dictionary<string, List<string>>)?.FirstOrDefault().Key;
            ViewData.Add("Error", errorType);

            return View();

        }
    }
}
