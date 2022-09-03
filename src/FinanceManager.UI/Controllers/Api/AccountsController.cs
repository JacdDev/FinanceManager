using Microsoft.AspNetCore.Mvc;

namespace FinanceManager.UI.Controllers.Api
{
    [Route("api/[controller]")]
    public class AccountsController : ApiControllerBase
    {
        [HttpGet]
        public IActionResult ListAccounts()
        {
            return Ok(Array.Empty<string>());
        }
    }
}
