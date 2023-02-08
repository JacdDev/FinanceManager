using FinanceManager.Application.Authentication.Commands.Register;
using FinanceManager.Application.Authentication.Queries.Login;
using FinanceManager.Application.Authentication.Queries.Logout;
using FinanceManager.UI.Models;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace FinanceManager.UI.Controllers.Api
{
    [Route("api/[controller]")]
    [AllowAnonymous]
    public class AuthenticationController : ApiControllerBase
    {
        private readonly ISender _mediator;
        private readonly IMapper _mapper;
        public AuthenticationController(ISender mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterRequest request)
        {
            var command = _mapper.Map<RegisterCommand>(request);

            var commandResult = await _mediator.Send(command);

            return commandResult.Match(
                authResult => Ok(_mapper.Map<AuthenticationResponse>(authResult)),
                errors => Problem(errors)
            );
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginRequest request)
        {
            var command = _mapper.Map<LoginQuery>(request);

            var commandResult = await _mediator.Send(command);

            return commandResult.Match(
                authResult => Ok(_mapper.Map<AuthenticationResponse>(authResult)),
                errors => Problem(errors)
            );
        }

        [HttpPost("logout")]
        public async Task<IActionResult> Logout()
        {
            var commandResult = await _mediator.Send(new LogoutQuery());

            return commandResult.Match(
                authResult => Ok(),
                errors => Problem(errors)
            );
        }
    }
}
