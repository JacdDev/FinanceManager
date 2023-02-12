using FinanceManager.UI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FinanceManager.UI.Controllers.View
{
    [Authorize]
    [Route("[controller]/[action]")]
    public class SettingsController : Controller
    {
        private readonly Api.SettingsController _settingsService;
        public SettingsController(Api.SettingsController settingsService)
        {
            _settingsService = settingsService;
        }

        // GET: SettingsController
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ChangeEmail(string newEmail, string password)
        {
            var request = new ChangeEmailRequest(
                User?.FindFirst("http://schemas.xmlsoap.org/ws/2005/05/identity/claims/emailaddress")?.Value ?? "",
                newEmail,
                password);

            var response = await _settingsService.ChangeEmail(request);

            if (response is OkObjectResult)
            {
                ViewData.Add("SuccessChangeEmail", "ChangesApplied");
                return View("index");
            }

            var errorType = (((response as ObjectResult)?.Value as ProblemDetails)?.Extensions["errors"] as Dictionary<string, List<string>>)?.FirstOrDefault().Key;
            ViewData.Add("ErrorChangeEmail", errorType);
            ViewData.Add("Email", request.NewEmail);

            return View("index");
        }

        [HttpPost]
        public async Task<IActionResult> ChangePassword(string oldPassword, string newPassword)
        {
            var request = new ChangePasswordRequest(
                User?.FindFirst("http://schemas.xmlsoap.org/ws/2005/05/identity/claims/emailaddress")?.Value ?? "",
                oldPassword,
                newPassword);

            var response = await _settingsService.ChangePassword(request);

            if (response is OkObjectResult)
            {
                ViewData.Add("SuccessChangePassword", "ChangesApplied");
                return View("index");
            }

            var errorType = (((response as ObjectResult)?.Value as ProblemDetails)?.Extensions["errors"] as Dictionary<string, List<string>>)?.FirstOrDefault().Key;
            ViewData.Add("ErrorChangePassword", errorType);

            return View("index");
        }
    }
}
