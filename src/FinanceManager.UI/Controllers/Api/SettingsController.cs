using FinanceManager.Application.Authentication.Commands.Register;
using FinanceManager.Application.Authentication.Queries.Login;
using FinanceManager.Application.Authentication.Queries.Logout;
using FinanceManager.UI.Models;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FinanceManager.UI.Controllers.Api
{
    [Route("api/[controller]")]
    public class SettingsController : ApiControllerBase
    {
        private readonly ISender _mediator;
        private readonly IMapper _mapper;
        public SettingsController(ISender mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpPatch("changeemail")]
        public async Task<IActionResult> ChangeEmail(RegisterRequest request)
        {
            var command = _mapper.Map<RegisterCommand>(request);

            var commandResult = await _mediator.Send(command);

            return commandResult.Match(
                authResult => Ok(_mapper.Map<AuthenticationResponse>(authResult)),
                errors => Problem(errors)
            );
        }

        [HttpPatch("changepassword")]
        public async Task<IActionResult> ChangePassword(LoginRequest request)
        {
            var command = _mapper.Map<LoginQuery>(request);

            var commandResult = await _mediator.Send(command);

            return commandResult.Match(
                authResult => Ok(_mapper.Map<AuthenticationResponse>(authResult)),
                errors => Problem(errors)
            );
        }

        [HttpDelete("deleteaccount")]
        public async Task<IActionResult> DeleteAccount()
        {
            var commandResult = await _mediator.Send(new LogoutQuery());

            return commandResult.Match(
                authResult => Ok(),
                errors => Problem(errors)
            );
        }
    }
}
