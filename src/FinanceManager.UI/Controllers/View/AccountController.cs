using FinanceManager.UI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Globalization;

namespace FinanceManager.UI.Controllers.View
{
    [Authorize]
    [Route("[controller]/[action]")]
    public class AccountController : Controller
    {
        private readonly Api.AccountsController _accountsService;
        private readonly Api.MovementsController _movementsService;
        private readonly Api.TagsController _tagsService;
        public AccountController(Api.AccountsController accountsService, Api.MovementsController movementsService, Api.TagsController tagsService)
        {
            _accountsService = accountsService;
            _movementsService = movementsService;
            _tagsService = tagsService;
        }

        public async Task<IActionResult> Index(string accountId, string tab = "movement")
        {
            foreach (var temp in TempData)
            {
                ViewData.Add(temp);
            }

            var userId = User?.FindFirst("http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier")?.Value ?? "";
            var userAccountsResponse = await _accountsService.GetAccounts(new Models.GetAccountsRequest(userId));

            if (userAccountsResponse is not OkObjectResult)
            {
                return userAccountsResponse;
            }

            var userAccounts = (userAccountsResponse as OkObjectResult)?.Value as IEnumerable<AccountResponse>;
            if (userAccounts == null)
            {
                return NotFound();
            }

            var requestedAccount = userAccounts.FirstOrDefault(account => account.Id == accountId);
            if (requestedAccount == null)
            {
                return NotFound();
            }

            ViewData.Add("AccountInfo", requestedAccount);
            ViewData.Add("tab", tab);


            return View("Index");
        }

        [HttpPost]
        public async Task<IActionResult> CreateMovement(string amount, string concept, DateTime date, bool isIncoming, string? tags, string id)
        {
            var request = new CreateMovementRequest(
                User?.FindFirst("http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier")?.Value ?? "",
                Convert.ToDouble(amount.Replace(",", "."), CultureInfo.InvariantCulture),
                concept,
                isIncoming,
                date,
                tags?.Split(',') ?? new string[0],
                id);

            var response = await _movementsService.CreateMovement(request);

            if (response is OkObjectResult)
            {
                TempData.Add("SuccessMovementOperation", "ChangesApplied");
                return RedirectToAction("Index", new { accountId = id, tab = "movement" });
            }

            var errorType = (((response as ObjectResult)?.Value as ProblemDetails)?.Extensions["errors"] as Dictionary<string, List<string>>)?.FirstOrDefault().Key;
            TempData.Add("ErrorMovementOperation", errorType ?? "UnknownError");

            return RedirectToAction("Index", new { accountId = id, tab = "movement" });
        }

        [HttpPost]
        public async Task<IActionResult> CreateTag(string name, string color, string id)
        {
            var request = new CreateTagRequest(
                User?.FindFirst("http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier")?.Value ?? "",
                name,
                color,
                id);

            var response = await _tagsService.CreateTag(request);

            if (response is OkObjectResult)
            {
                TempData.Add("SuccessTagOperation", "ChangesApplied");
                return RedirectToAction("Index", new { accountId = id, tab = "tag" });
            }

            var errorType = (((response as ObjectResult)?.Value as ProblemDetails)?.Extensions["errors"] as Dictionary<string, List<string>>)?.FirstOrDefault().Key;
            TempData.Add("ErrorTagOperation", errorType ?? "UnknownError");

            return RedirectToAction("Index", new { accountId = id, tab = "tag" });
        }

        [HttpPost]
        public async Task<IActionResult> UpdateTag(string tagId, string name, string color, string accountId)
        {
            var request = new UpdateTagRequest(
                User?.FindFirst("http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier")?.Value ?? "",
                tagId,
                name,
                color);

            var response = await _tagsService.UpdateTag(request);

            if (response is OkObjectResult)
            {
                TempData.Add("SuccessTagOperation", "ChangesApplied");
                return RedirectToAction("Index", new { accountId = accountId, tab = "tag" });
            }

            var errorType = (((response as ObjectResult)?.Value as ProblemDetails)?.Extensions["errors"] as Dictionary<string, List<string>>)?.FirstOrDefault().Key;
            TempData.Add("ErrorTagOperation", errorType ?? "UnknownError");

            return RedirectToAction("Index", new { accountId = accountId, tab = "tag" });
        }

        [HttpPost]
        public async Task<IActionResult> DeleteTag(string tagId, string accountId)
        {
            var request = new DeleteTagRequest(
                User?.FindFirst("http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier")?.Value ?? "",
                tagId);

            var response = await _tagsService.DeleteTag(request);

            if (response is OkObjectResult)
            {
                TempData.Add("SuccessTagOperation", "ChangesApplied");
                return RedirectToAction("Index", new { accountId = accountId, tab = "tag" });
            }

            var errorType = (((response as ObjectResult)?.Value as ProblemDetails)?.Extensions["errors"] as Dictionary<string, List<string>>)?.FirstOrDefault().Key;
            TempData.Add("ErrorTagOperation", errorType ?? "UnknownError");

            return RedirectToAction("Index", new { accountId = accountId, tab = "tag" });
        }
    }
}
