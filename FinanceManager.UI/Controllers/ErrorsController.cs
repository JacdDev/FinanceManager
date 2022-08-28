using Microsoft.AspNetCore.Mvc;

namespace FinanceManager.Api.Controllers
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