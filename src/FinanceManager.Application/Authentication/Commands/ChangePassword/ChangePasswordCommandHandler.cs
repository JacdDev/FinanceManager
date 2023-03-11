using ErrorOr;
using FinanceManager.Application.Authentication.Common;
using FinanceManager.Application.Common.Interfaces;
using MediatR;

namespace FinanceManager.Application.Authentication.Commands.ChangePassword
{
    public class ChangePasswordCommandHandler : IRequestHandler<ChangePasswordCommand, ErrorOr<AuthenticationResult>>
    {
        private readonly IAuth _auth;
        public ChangePasswordCommandHandler(IAuth auth)
        {
            _auth = auth;
        }

        public async Task<ErrorOr<AuthenticationResult>> Handle(ChangePasswordCommand command, CancellationToken cancellationToken)
        {
            return await _auth.ChangePassword(command.Email, command.OldPassword, command.NewPassword);
        }
    }
}
