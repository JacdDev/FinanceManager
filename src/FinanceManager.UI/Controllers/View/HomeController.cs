using FinanceManager.UI.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Globalization;

namespace FinanceManager.UI.Controllers.View
{

    [Route("/")]
    [Route("[controller]/[action]")]
    public class HomeController : Controller
    {
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly Api.AccountsController _accountsService;
        public HomeController(SignInManager<IdentityUser> signInManager, Api.AccountsController accountsService)
        {
            _signInManager = signInManager;
            _accountsService = accountsService;
        }

        public IActionResult Index()
        {
            if (_signInManager.IsSignedIn(User))
            {
                return View("UserHome");
            }

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateAccount(string name, string description, string amount)
        {
            var request = new CreateAccountRequest(
                User?.FindFirst("http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier")?.Value ?? "",
                name, 
                description, 
                Convert.ToDouble(amount.Replace(",", "."), CultureInfo.InvariantCulture));

            var response = await _accountsService.CreateAccount(request);

            if (response is OkObjectResult)
            {
                ViewData.Add("SuccessAddAccount", "ChangesApplied");
                return View("UserHome");
            }

            var errorType = (((response as ObjectResult)?.Value as ProblemDetails)?.Extensions["errors"] as Dictionary<string, List<string>>)?.FirstOrDefault().Key;
            ViewData.Add("ErrorAddAccount", errorType ?? "UnknownError");

            return View("UserHome");
        }
    }
}
