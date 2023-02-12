using FinanceManager.Application.Authentication.Queries.Logout;
using FinanceManager.Application.Settings.Commands.ChangeEmail;
using FinanceManager.Application.Settings.Commands.ChangePassword;
using FinanceManager.UI.Models;
using MapsterMapper;
using MediatR;
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
        public async Task<IActionResult> ChangeEmail(ChangeEmailRequest request)
        {
            var command = _mapper.Map<ChangeEmailCommand>(request);

            var commandResult = await _mediator.Send(command);

            return commandResult.Match(
                settingsResult => Ok(_mapper.Map<SettingsResponse>(settingsResult)),
                errors => Problem(errors)
            );
        }

        [HttpPatch("changepassword")]
        public async Task<IActionResult> ChangePassword(ChangePasswordRequest request)
        {
            var command = _mapper.Map<ChangePasswordCommand>(request);

            var commandResult = await _mediator.Send(command);

            return commandResult.Match(
                settingsResult => Ok(_mapper.Map<SettingsResponse>(settingsResult)),
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
