using ErrorOr;
using FinanceManager.Application.Common.Interfaces;
using FinanceManager.Application.Settings.Common;
using MediatR;

namespace FinanceManager.Application.Settings.Commands.ChangePassword
{
    public class ChangePasswordCommandHandler : IRequestHandler<ChangePasswordCommand, ErrorOr<SettingsResult>>
    {
        private readonly IAuth _auth;
        public ChangePasswordCommandHandler(IAuth auth)
        {
            _auth = auth;
        }

        public async Task<ErrorOr<SettingsResult>> Handle(ChangePasswordCommand command, CancellationToken cancellationToken)
        {
            var result = await _auth.ChangePassword(command.Email, command.OldPassword, command.NewPassword);

            return result.Match<ErrorOr<SettingsResult>>(
                authResult => new SettingsResult(),
                errors => errors
            );
        }
    }
}
