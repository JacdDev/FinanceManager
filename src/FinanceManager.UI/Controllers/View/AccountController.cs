using FinanceManager.UI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FinanceManager.UI.Controllers.View
{
    [Authorize]
    [Route("[controller]/[action]")]
    public class AccountController : Controller
    {
        private readonly Api.AccountsController _accountsService;
        public AccountController(Api.AccountsController accountsService)
        {
            _accountsService = accountsService;
        }

        public async Task<IActionResult> Index(string accountId)
        {
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


            return View();
        }
    }
}
