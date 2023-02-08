using ErrorOr;
using FinanceManager.Application.Authentication.Common;
using FinanceManager.Application.Common.Interfaces;
using MediatR;

namespace FinanceManager.Application.Authentication.Queries.Login
{
    public class LoginQueryHandler
        : IRequestHandler<LoginQuery, ErrorOr<AuthenticationResult>>
    {
        private readonly IAuth _auth;

        public LoginQueryHandler(IAuth auth)
        {
            _auth = auth;
        }

        public async Task<ErrorOr<AuthenticationResult>> Handle(LoginQuery request, CancellationToken cancellationToken)
        {
            return await _auth.Login(request.Email, request.Password, request.RememberMe);
        }
    }
}
