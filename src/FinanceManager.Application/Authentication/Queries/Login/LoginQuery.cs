using ErrorOr;
using FinanceManager.Application.Authentication.Common;
using MediatR;

namespace FinanceManager.Application.Authentication.Queries.Login
{
    public record LoginQuery(
    string Email,
    string Password,
    bool RememberMe) : IRequest<ErrorOr<AuthenticationResult>>;
}
