using FinanceManager.UI.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Globalization;

namespace FinanceManager.UI.Controllers.View
{
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

        [Route("/")]
        public IActionResult Index()
        {
            if (_signInManager.IsSignedIn(User))
            {
                return RedirectToAction("UserHome");
            }

            return View();
        }

        public async Task<IActionResult> UserHome()
        {
            foreach (var temp in TempData)
            {
                ViewData.Add(temp);
            }

            if (_signInManager.IsSignedIn(User))
            {
                var request = new GetAccountsRequest(
                User?.FindFirst("http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier")?.Value ?? "");

                var response = await _accountsService.GetAccounts(request);

                if (response is OkObjectResult)
                {
                    ViewData.Add("Accounts", (response as OkObjectResult)?.Value);
                }

                return View();
            }

            return Unauthorized();
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
                TempData.Add("SuccessAccountOperation", "ChangesApplied");
                return RedirectToAction("UserHome");
            }

            var errorType = (((response as ObjectResult)?.Value as ProblemDetails)?.Extensions["errors"] as Dictionary<string, List<string>>)?.FirstOrDefault().Key;
            TempData.Add("ErrorAccountOperation", errorType ?? "UnknownError");

            return RedirectToAction("UserHome");
        }

        [HttpPost]
        public async Task<IActionResult> UpdateAccount(string id, string name, string description)
        {
            var request = new UpdateAccountRequest(
                User?.FindFirst("http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier")?.Value ?? "",
                id,
                name,
                description);

            var response = await _accountsService.UpdateAccount(request);

            if (response is OkObjectResult)
            {
                TempData.Add("SuccessAccountOperation", "ChangesApplied");
                return RedirectToAction("UserHome");
            }

            var errorType = (((response as ObjectResult)?.Value as ProblemDetails)?.Extensions["errors"] as Dictionary<string, List<string>>)?.FirstOrDefault().Key;
            TempData.Add("ErrorAccountOperation", errorType ?? "UnknownError");

            return RedirectToAction("UserHome");
        }

        [HttpPost]
        public async Task<IActionResult> ShareAccount(string id, string email)
        {
            var request = new ShareAccountRequest(
                User?.FindFirst("http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier")?.Value ?? "",
                id,
                email);

            var response = await _accountsService.ShareAccount(request);

            if (response is OkObjectResult)
            {
                TempData.Add("SuccessAccountOperation", "ChangesApplied");
                return RedirectToAction("UserHome");
            }

            var errorType = (((response as ObjectResult)?.Value as ProblemDetails)?.Extensions["errors"] as Dictionary<string, List<string>>)?.FirstOrDefault().Key;
            TempData.Add("ErrorAccountOperation", errorType ?? "UnknownError");

            return RedirectToAction("UserHome");
        }

        [HttpPost]
        public async Task<IActionResult> DeleteAccount(string id)
        {
            var request = new DeleteAccountRequest(
                User?.FindFirst("http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier")?.Value ?? "",
                id);

            var response = await _accountsService.DeleteAccount(request);

            if (response is OkObjectResult)
            {
                TempData.Add("SuccessAccountOperation", "ChangesApplied");
                return RedirectToAction("UserHome");
            }

            var errorType = (((response as ObjectResult)?.Value as ProblemDetails)?.Extensions["errors"] as Dictionary<string, List<string>>)?.FirstOrDefault().Key;
            TempData.Add("ErrorAccountOperation", errorType ?? "UnknownError");

            return RedirectToAction("UserHome");
        }
    }
}
