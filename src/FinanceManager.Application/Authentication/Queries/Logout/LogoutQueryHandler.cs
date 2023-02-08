using ErrorOr;
using FinanceManager.Application.Common.Interfaces;
using MediatR;

namespace FinanceManager.Application.Authentication.Queries.Logout
{
    public class LogoutQueryHandler
        : IRequestHandler<LogoutQuery, ErrorOr<Unit>>
    {
        private readonly IAuth _auth;

        public LogoutQueryHandler(IAuth auth)
        {
            _auth = auth;
        }

        public async Task<ErrorOr<Unit>> Handle(LogoutQuery request, CancellationToken cancellationToken)
        {
            await _auth.Logout();

            return new Unit();
        }
    }
}
