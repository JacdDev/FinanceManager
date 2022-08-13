using ErrorOr;
using Microsoft.AspNetCore.Mvc;

namespace FinanceManager.UI.Controllers
{
    [ApiController]
    public class ApiControllerBase : ControllerBase
    {
        protected IActionResult Problem(List<Error> errors)
        {
            var firstError = errors[0];

            var statusCode = firstError.Type switch
            {
                ErrorType.Conflict => StatusCodes.Status409Conflict,
                _ => StatusCodes.Status500InternalServerError,
            };

            return Problem(
                statusCode: statusCode,
                title: firstError.Description);
        }
    }
}
