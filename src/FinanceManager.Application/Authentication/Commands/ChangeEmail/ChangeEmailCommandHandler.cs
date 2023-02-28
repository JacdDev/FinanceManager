using ErrorOr;
using FinanceManager.Application.Authentication.Common;
using FinanceManager.Application.Common.Interfaces;
using MediatR;

namespace FinanceManager.Application.Authentication.Commands.ChangeEmail
{
    public class ChangeEmailCommandHandler : IRequestHandler<ChangeEmailCommand, ErrorOr<AuthenticationResult>>
    {
        private readonly IAuth _auth;
        public ChangeEmailCommandHandler(IAuth auth)
        {
            _auth = auth;
        }

        public async Task<ErrorOr<AuthenticationResult>> Handle(ChangeEmailCommand command, CancellationToken cancellationToken)
        {
            var result = await _auth.ChangeEmail(command.OldEmail, command.NewEmail, command.Password);

            return result.Match<ErrorOr<AuthenticationResult>>(
                authResult => new AuthenticationResult(),
                errors => errors
            );
        }
    }
}
