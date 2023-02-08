using ErrorOr;
using FinanceManager.Application.Authentication.Common;
using FinanceManager.Application.Common.Interfaces;
using MediatR;

namespace FinanceManager.Application.Authentication.Commands.Register
{
    public class RegisterCommandHandler : IRequestHandler<RegisterCommand, ErrorOr<AuthenticationResult>>
    {
        private readonly IAuth _auth;
        public RegisterCommandHandler(IAuth auth)
        {
            _auth = auth;
        }

        public async Task<ErrorOr<AuthenticationResult>> Handle(RegisterCommand command, CancellationToken cancellationToken)
        {
            return await _auth.Register(command.Email, command.Password, command.RememberMe);
        }
    }
}
