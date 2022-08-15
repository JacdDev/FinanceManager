using ErrorOr;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Linq;

namespace FinanceManager.UI.Controllers
{
    [ApiController]
    public class ApiControllerBase : ControllerBase
    {

        protected IActionResult Problem(List<Error> errors)
        {
            if(errors.Count is 0)
            {
                return Problem();
            }

            var statusCode = errors[0].Type switch
            {
                ErrorType.Conflict => StatusCodes.Status409Conflict,
                _ => StatusCodes.Status500InternalServerError,
            };

            var problemDetails = (ProblemDetails?)Problem(statusCode: statusCode).Value;

            var dictionaryErrors = errors.ToDictionary(error => error.Code, error => new List<string>() { error.Description });
            problemDetails?.Extensions.Add("errors", dictionaryErrors);
            
            return new ObjectResult(problemDetails);
        }
    }
}
