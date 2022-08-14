using ErrorOr;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Linq;

namespace FinanceManager.UI.Controllers
{
    [ApiController]
    public class ApiControllerBase : ControllerBase
    {

        protected ObjectResult Problem(List<Error> errors)
        {
            var firstError = errors[0];

            var statusCode = firstError.Type switch
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
