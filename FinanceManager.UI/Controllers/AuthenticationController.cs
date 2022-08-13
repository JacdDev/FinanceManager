using FinanceManager.Application.Authentication.Commands.Register;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FinanceManager.UI.Controllers
{
    [Route("auth")]
    [ApiController]
    public class AuthenticationController : ApiControllerBase
    {
        private readonly ISender _mediator;
        public AuthenticationController(ISender mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterCommand request)
        {
            var registerResult = await _mediator.Send(request);

            return registerResult.Match(
                authResult => Ok(authResult),
                errors => Problem(errors)
            );
        }


    }
}
