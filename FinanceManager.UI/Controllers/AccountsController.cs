using Microsoft.AspNetCore.Mvc;

namespace FinanceManager.UI.Controllers
{
    [Route("[controller]")]
    public class AccountsController : ApiControllerBase
    {
        [HttpGet]
        public IActionResult ListAccounts()
        {
            return Ok(Array.Empty<string>());
        }
    }
}
