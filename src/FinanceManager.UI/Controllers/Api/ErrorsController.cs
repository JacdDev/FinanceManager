using Microsoft.AspNetCore.Mvc;

namespace FinanceManager.UI.Controllers.Api
{
    public class ErrorsController : ControllerBase
    {
        [Route("/error")]
        public IActionResult Error()
        {
            return Problem();
        }
    }

}