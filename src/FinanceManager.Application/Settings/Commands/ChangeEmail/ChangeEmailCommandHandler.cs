using ErrorOr;
using FinanceManager.Application.Common.Interfaces;
using FinanceManager.Application.Settings.Common;
using MediatR;

namespace FinanceManager.Application.Settings.Commands.ChangeEmail
{
    public class ChangeEmailCommandHandler : IRequestHandler<ChangeEmailCommand, ErrorOr<SettingsResult>>
    {
        private readonly IAuth _auth;
        public ChangeEmailCommandHandler(IAuth auth)
        {
            _auth = auth;
        }

        public async Task<ErrorOr<SettingsResult>> Handle(ChangeEmailCommand command, CancellationToken cancellationToken)
        {
            var result = await _auth.ChangeEmail(command.OldEmail, command.NewEmail, command.Password);

            return result.Match<ErrorOr<SettingsResult>>(
                authResult => new SettingsResult(),
                errors => errors
            );
        }
    }
}
